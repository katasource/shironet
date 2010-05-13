using System;
using System.Collections.Generic;

using Common.Logging;

namespace Apache.Shiro.Session.Management
{
    public class SimpleSession : IValidatingSession
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (SimpleSession));

        public SimpleSession()
            : this(null)
        {

        }

        public SimpleSession(string host)
        {
            Host = host;
            StartTime = DateTime.Now;
            LastAccessTime = StartTime;
        }

        #region ISession Members

        public ICollection<object> AttributeKeys
        {
            get
            {
                return Attributes == null ? new Object[0] : Attributes.Keys;
            }
        }

        public string Host
        {
            get;
            set;
        }

        public object Id
        {
            get;
            set;
        }

        public DateTime LastAccessTime
        {
            get;
            private set;
        }

        public DateTime StartTime
        {
            get;
            set;
        }

        public long Timeout { get; set; }

        public object GetAttribute(object key)
        {
            if (Attributes == null)
            {
                return null;
            }

            object value;
            Attributes.TryGetValue(key, out value);
            return value;
        }

        public object RemoveAttribute(object key)
        {
            if (Attributes == null)
            {
                return null;
            }

            object value;
            if (Attributes.TryGetValue(key, out value))
            {
                Attributes.Remove(key);
            }
            return value;
        }

        public void SetAttribute(object key, object value)
        {
            if (Attributes == null)
            {
                Attributes = new Dictionary<object, object>();
            }
            Attributes.Add(key, value);
        }

        public void Stop()
        {
            if (StopTime.Ticks == 0)
            {
                StopTime = new DateTime();
            }
        }

        public void Touch()
        {
            LastAccessTime = new DateTime();
        }

        #endregion

        #region IValidatingSession Members

        public bool IsValid
        {
            get
            {
                return !(IsStopped || IsExpired);
            }
        }

        public void Validate()
        {
            if (IsStopped)
            {
                var msg = string.Format(Properties.Resources.SessionStoppedMessage, Id);
                throw new StoppedSessionException(msg);
            }

            if (IsTimedOut())
            {
                Expire();

                var span = TimeSpan.FromMilliseconds(Timeout);
                var msg = string.Format(Properties.Resources.SessionExpiredMessage,
                    Id, LastAccessTime, DateTime.Now, span.TotalSeconds, span.TotalMinutes);
                Log.Trace(msg);

                throw new ExpiredSessionException(msg);
            }
        }

        #endregion

        #region Public Properties

        public IDictionary<object, object> Attributes
        {
            get;
            set;
        }

        public bool IsExpired
        {
            get;
            set;
        }

        public bool IsStopped
        {
            get
            {
                return StopTime != default(DateTime);
            }
        }

        public DateTime StopTime
        {
            get;
            set;
        }

        #endregion

        #region Protected Methods

        protected void Expire()
        {
            Stop();
            if (!IsExpired)
            {
                IsExpired = true;
            }
        }

        protected bool IsTimedOut()
        {
            if (IsExpired)
            {
                return true;
            }

            if (Timeout > 1)
            {
                var span = DateTime.Now - LastAccessTime;

                return span.TotalMilliseconds > Timeout;
            }
            
            Log.TraceFormat("No timeout for session with ID [{0}]. Session is not considered expired", Id);
            return false;
        }

        #endregion
    }
}
