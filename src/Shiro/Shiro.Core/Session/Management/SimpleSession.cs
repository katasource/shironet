using System;
using System.Collections.Generic;
using System.Net;

using Common.Logging;

namespace Apache.Shiro.Session.Management
{
    public class SimpleSession : IValidatingSession
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (SimpleSession));

        private IDictionary<object, object> _attributes;
        private IPAddress _hostAddress;
        private DateTime _lastAccessTime;
        private DateTime _startTime;
        private DateTime _stopTime;

        private bool _expired;
        private object _id;
        private long _timeout;

        public SimpleSession()
            : this(IPAddress.Loopback)
        {

        }

        public SimpleSession(IPAddress hostAddress)
        {
            _hostAddress = hostAddress;
            _startTime = DateTime.Now;
            _lastAccessTime = _startTime;
        }

        #region ISession Members

        public ICollection<object> AttributeKeys
        {
            get
            {
                return _attributes == null ? new Object[0] : _attributes.Keys;
            }
        }

        public IPAddress HostAddress
        {
            get
            {
                return _hostAddress;
            }
            set
            {
                _hostAddress = value;
            }
        }

        public object Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public DateTime LastAccessTime
        {
            get
            {
                return _lastAccessTime;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        public long Timeout
        {
            get
            {
                return _timeout;
            }
            set
            {
                _timeout = value;
            }
        }

        public object GetAttribute(object key)
        {
            if (_attributes == null)
            {
                return null;
            }

            object value;
            _attributes.TryGetValue(key, out value);
            return value;
        }

        public object RemoveAttribute(object key)
        {
            if (_attributes == null)
            {
                return null;
            }

            object value;
            if (_attributes.TryGetValue(key, out value))
            {
                _attributes.Remove(key);
            }
            return value;
        }

        public void SetAttribute(object key, object value)
        {
            if (_attributes == null)
            {
                _attributes = new Dictionary<object, object>();
            }
            _attributes.Add(key, value);
        }

        public void Stop()
        {
            if (_stopTime.Ticks == 0)
            {
                _stopTime = new DateTime();
            }
        }

        public void Touch()
        {
            _lastAccessTime = new DateTime();
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
            get
            {
                return _attributes;
            }
            set
            {
                _attributes = value;
            }
        }

        public bool IsExpired
        {
            get
            {
                return _expired;
            }
            set
            {
                _expired = value;
            }
        }

        public bool IsStopped
        {
            get
            {
                return _stopTime != default(DateTime);
            }
        }

        public DateTime StopTime
        {
            get
            {
                return _stopTime;
            }
            set
            {
                _stopTime = value;
            }
        }

        #endregion

        #region Protected Methods

        protected void Expire()
        {
            Stop();
            if (!_expired)
            {
                _expired = true;
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
