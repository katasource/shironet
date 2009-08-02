using System;
using System.Net;

namespace Apache.Shiro.Session.Management
{
    public abstract class AbstractSessionManager : ISessionManager, ISessionEventPublisher
    {
        #region Public Fields

        public static readonly long DefaultGlobalSessionTimeout;

        #endregion

        static AbstractSessionManager()
        {
            DefaultGlobalSessionTimeout = (long)TimeSpan.FromMinutes(30).TotalMilliseconds;
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

        public ISessionAttributes GetAttributes(object sessionId)
        {
            return GetSession(sessionId).Attributes;
        }

        public IPAddress GetHostAddress(object sessionId)
        {
            return GetSession(sessionId).HostAddress;
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

        public void SetTimeout(object sessionId, long timeout)
        {
            ISession session = GetSession(sessionId);
            session.Timeout = timeout;
            OnChanged(session);
        }

        public object Start(IPAddress originatingHost)
        {
            ISession session = CreateSession(originatingHost);
            DoStart(session);
            return session.Id;
        }

        public void Stop(object sessionId)
        {
            ISession session = GetSession(sessionId);
            DoStop(session);
        }

        public void Touch(object sessionId)
        {
            ISession session = GetSession(sessionId);
            DoTouch(session);
        }

        #endregion

        #region ISessionEventPublisher Members

        public event SessionEventHandler Expired;

        public event SessionEventHandler Started;

        public event SessionEventHandler Stopped;

        #endregion

        #region Public Properties

        public long GlobalSessionTimeout { get; set; }

        #endregion

        #region Protected Methods

        protected abstract ISession CreateSession(IPAddress originatingHost);

        protected abstract ISession DoGetSession(object sessionId);

        protected virtual void DoStart(ISession session)
        {
            OnStarted(session);
        }

        protected virtual void DoStop(ISession session)
        {
            session.Stop();
            OnStopped(session);
        }

        protected virtual void DoTouch(ISession session)
        {
            session.Touch();
            OnChanged(session);
        }

        protected virtual ISession GetSession(object sessionId)
        {
            var session = DoGetSession(sessionId);
            if (session == null)
            {
                throw new UnknownSessionException("There is no session with ID [" + sessionId + "]");
            }
            return session;
        }

        protected virtual void OnChanged(ISession session)
        {

        }

        protected virtual void OnExpired(ISession session)
        {
            OnChanged(session);

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
            OnChanged(session);

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
