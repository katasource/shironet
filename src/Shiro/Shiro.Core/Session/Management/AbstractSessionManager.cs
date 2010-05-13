using System;
using System.Collections.Generic;

using Common.Logging;

namespace Apache.Shiro.Session.Management
{
    public abstract class AbstractSessionManager : ISessionManager
    {
        #region Public Static Fields

        public static readonly long DefaultGlobalSessionTimeout;

        #endregion

        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        static AbstractSessionManager()
        {
            DefaultGlobalSessionTimeout = (long) TimeSpan.FromMinutes(30).TotalMilliseconds;
        }

        public AbstractSessionManager()
        {
            GlobalSessionTimeout = DefaultGlobalSessionTimeout;
        }

        #region ISessionManager Members

        public void CheckValidity(object sessionId)
        {
            GetSession(sessionId);
        }

        public object GetAttribute(object sessionId, object key)
        {
            return GetSession(sessionId).GetAttribute(key);
        }

        public ICollection<object> GetAttributeKeys(object sessionId)
        {
            return GetSession(sessionId).AttributeKeys;
        }

        public string GetHost(object sessionId)
        {
            return GetSession(sessionId).Host;
        }

        public DateTime GetLastAccessTime(object sessionId)
        {
            return GetSession(sessionId).LastAccessTime;
        }

        public DateTime GetStartTime(object sessionId)
        {
            return GetSession(sessionId).StartTime;
        }

        public long GetTimeout(object sessionId)
        {
            return GetSession(sessionId).Timeout;
        }

        public bool IsValid(object sessionId)
        {
            try
            {
                CheckValidity(sessionId);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public object RemoveAttribute(object sessionId, object key)
        {
            var session = GetSession(sessionId);

            var removed = session.RemoveAttribute(key);
            if (removed != null)
            {
                AfterChanged(session);
            }
            return removed;
        }

        public void SetAttribute(object sessionId, object key, object value)
        {
            if (value == null)
            {
                RemoveAttribute(sessionId, key);
            }
            else
            {
                var session = GetSession(sessionId);
                session.SetAttribute(key, value);
                AfterChanged(session);
            }
        }

        public void SetTimeout(object sessionId, long timeout)
        {
            var session = GetSession(sessionId);
            session.Timeout = timeout;
            AfterChanged(session);
        }

        public object Start(string host)
        {
            IDictionary<object, object> data = null;
            if (!string.IsNullOrWhiteSpace(host))
            {
                data = new Dictionary<object, object>(1) {{SessionFactoryKey.Host, host}};
            }
            return Start(data);
        }

        public object Start(IDictionary<object, object> data)
        {
            var session = CreateSession(data);

            ApplyGlobalSessionTimeout(session);
            OnStarted(session);

            return session.Id;
        }

        public void Stop(object sessionId)
        {
            Log.DebugFormat("Stopping session with ID [{0}]", sessionId);
            var session = GetSession(sessionId);
            DoStop(session);
        }

        public void Touch(object sessionId)
        {
            var session = GetSession(sessionId);
            DoTouch(session);
        }

        #endregion

        #region Session Events

        public event SessionEventHandler Expired;

        public event SessionEventHandler Started;

        public event SessionEventHandler Stopped;

        #endregion

        #region Public Properties

        public long GlobalSessionTimeout { get; set; }

        #endregion

        #region Protected Methods

        protected virtual void AfterChanged(ISession session)
        {

        }

        protected virtual void AfterStopped(ISession session)
        {
            
        }

        protected void ApplyGlobalSessionTimeout(ISession session)
        {
            session.Timeout = GlobalSessionTimeout;
            AfterChanged(session);
        }

        protected abstract ISession CreateSession(IDictionary<object, object> data);

        protected abstract ISession DoGetSession(object sessionId);

        protected virtual void DoStart(ISession session)
        {
            OnStarted(session);
        }

        protected virtual void DoStop(ISession session)
        {
            session.Stop();
            OnStopped(session);
            AfterStopped(session);
        }

        protected virtual void DoTouch(ISession session)
        {
            session.Touch();
            AfterChanged(session);
        }

        protected virtual ISession GetSession(object sessionId)
        {
            if (sessionId == null)
            {
                throw new ArgumentNullException("sessionId");
            }

            var session = DoGetSession(sessionId);
            if (session == null)
            {
                throw new UnknownSessionException(
                    string.Format(Properties.Resources.SessionUnknownMessage, sessionId));
            }
            return session;
        }

        protected virtual void OnExpired(ISession session)
        {
            AfterChanged(session);

            var e = new SessionEventArgs(new ImmutableProxiedSession(session));
            OnExpired(e);
        }

        protected void OnExpired(SessionEventArgs e)
        {
            if (Expired == null)
            {
                return;
            }
            Expired(this, e);
        }

        protected virtual void OnStarted(ISession session)
        {
            var e = new SessionEventArgs(new ImmutableProxiedSession(session));
            OnStarted(e);
        }

        protected void OnStarted(SessionEventArgs e)
        {
            if (Started == null)
            {
                return;
            }
            Started(this, e);
        }

        protected virtual void OnStopped(ISession session)
        {
            AfterChanged(session);

            var e = new SessionEventArgs(new ImmutableProxiedSession(session));
            OnStopped(e);
            
        }

        protected void OnStopped(SessionEventArgs e)
        {
            if (Stopped == null)
            {
                return;
            }
            Stopped(this, e);
        }

        #endregion
    }
}
