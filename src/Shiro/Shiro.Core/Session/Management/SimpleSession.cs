using System;
using System.Net;

namespace Apache.Shiro.Session.Management
{
    public class SimpleSession : IValidatingSession
    {
        private ISessionAttributes _attributes;
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

        public ISessionAttributes Attributes
        {
            get
            {
                Touch();
                if (_attributes == null)
                {
                    _attributes = new DictionarySessionAttributes();
                }
                return _attributes;
            }
            set
            {
                Touch();
                _attributes = value;
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
                return (!IsStopped && !IsExpired);
            }
        }

        public void Validate()
        {
            if (IsStopped)
            {
                string msg = string.Format("Session with ID [{0}] has been explicitly " +
                    "stopped. No further interaction under this session is allowed.", Id);
                throw new StoppedSessionException(msg);
            }

            if (IsTimedOut())
            {
                Expire();

                string msg = string.Format("Session with ID [{0}] has expired. " +
                    "Last access time: {1}. " +
                    "Current time: {2}. " +
                    "Session timeout is set to {3}",
                    Id, LastAccessTime, DateTime.Now, TimeSpan.FromMilliseconds(Timeout));
                throw new ExpiredSessionException(msg);
            }
        }

        #endregion

        #region Public Properties

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
                TimeSpan span = DateTime.Now - LastAccessTime;

                return span.TotalMilliseconds > Timeout;
            }

            return false;
        }

        #endregion
    }
}
