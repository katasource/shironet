using System;
using System.Collections.Generic;

namespace Apache.Shiro.Session.Management
{
    public class DelegatingSession : ISession
    {
        #region Private Fields

        private string _host;
        private DateTime _startTime;

        #endregion

        public DelegatingSession()
        {
            
        }

        public DelegatingSession(ISessionManager manager, object id, string host = null)
        {
            Id = id;
            SessionManager = manager;

            _host = host;
        }

        #region ISession Members

        public ICollection<object> AttributeKeys
        {
            get
            {
                return Do(id => SessionManager.GetAttributeKeys(id));
            }
        }

        public string Host
        {
            get
            {
                if (_host == null)
                {
                    _host = Do(id => SessionManager.GetHost(id));
                }
                return _host;
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

        public object GetAttribute(object key)
        {
            return Do(id => SessionManager.GetAttribute(id, key));
        }

        public object RemoveAttribute(object key)
        {
            return Do(id => SessionManager.RemoveAttribute(id, key));
        }

        public void SetAttribute(object key, object value)
        {
            Do(id => SessionManager.SetAttribute(id, key, value));
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
            action(Id);
        }

        private T Do<T>(Func<object, T> function)
        {
            return function(Id);
        }

        #endregion
    }
}
