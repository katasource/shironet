using System;
using System.Net;

namespace Apache.Shiro.Session.Management
{
    public class DelegatingSession : ISession
    {
        #region Private Fields

        private IPAddress _hostAddress;
        private DateTime _startTime;

        #endregion

        public DelegatingSession()
        {
            
        }

        public DelegatingSession(ISessionManager manager, object id)
        {
            Id = id;
            SessionManager = manager;
        }

        #region ISession Members

        public ISessionAttributes Attributes
        {
            get
            {
                //TODO: This is going to be horrifically ineffecient and must be corrected
                return Do(id => SessionManager.GetAttributes(id));
            }
        }

        public IPAddress HostAddress
        {
            get
            {
                if (_hostAddress == null)
                {
                    _hostAddress = Do(id => SessionManager.GetHostAddress(id));
                }
                return _hostAddress;
            }
        }

        public object Id { get; set; }

        public DateTime LastAccessTime
        {
            get
            {
                return Do(id => SessionManager.GetLastAccessTime(id));
            }
        }

        public DateTime StartTime
        {
            get
            {
                if (_startTime.Year == 0)
                {
                    _startTime = Do(id => SessionManager.GetStartTime(id));
                }
                return _startTime;
            }
        }

        public long Timeout
        {
            get
            {
                return Do(id => SessionManager.GetTimeout(id));
            }
            set
            {
                Do(id => SessionManager.SetTimeout(id, value));
            }
        }

        public void Stop()
        {
            Do(id => SessionManager.Stop(id));
        }

        public void Touch()
        {
            Do(id => SessionManager.Touch(id));
        }

        #endregion

        #region Public Properties

        public ISessionManager SessionManager { get; set; }

        #endregion

        #region Private Methods

        private void Do(Action<object> action)
        {
            try
            {
                action(Id);
            }
            catch (ReplacedSessionException e)
            {
                Id = e.NewSessionId;

                action(Id);
            }
        }

        private T Do<T>(Func<object, T> function)
        {
            try
            {
                return function(Id);
            }
            catch (ReplacedSessionException e)
            {
                Id = e.NewSessionId;

                return function(Id);
            }
        }

        #endregion
    }
}
