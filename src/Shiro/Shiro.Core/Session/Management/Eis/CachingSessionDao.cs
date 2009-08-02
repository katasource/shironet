using System;
using System.Collections.Generic;

using Apache.Shiro.Cache;

namespace Apache.Shiro.Session.Management.Eis
{
    public abstract class CachingSessionDao : ICacheManagerAware, ISessionDao
    {
        #region Constants

        public static string ACTIVE_SESSION_CACHE_NAME = "Shiro-activeSessionCache";

        #endregion

        #region Private Fields

        private ICache _activeSessions;
        private ICacheManager _cacheManager;

        private string _activeSessionsCacheName;

        #endregion

        public CachingSessionDao()
        {
            _activeSessionsCacheName = ACTIVE_SESSION_CACHE_NAME;
        }

        #region ICacheManagerAware Members

        public ICacheManager CacheManager
        {
            get
            {
                return _cacheManager;
            }
            set
            {
                _cacheManager = value;
                _activeSessions = null;
            }
        }

        #endregion

        #region ISessionDAO Members

        public object Create(ISession session)
        {
            object sessionId = DoCreate(session);
            VerifySessionId(sessionId);
            CacheValidSession(session, sessionId);
            return sessionId;
        }

        public void Delete(ISession session)
        {
            DoDelete(session);
            Uncache(session);
        }

        public ICollection<ISession> GetActiveSessions()
        {
            ICache cache = ActiveSessionsCache;
            if (cache == null)
            {
                return new ISession[0];
            }
            
            return cache.Values as ICollection<ISession>;
        }

        public ISession Read(object sessionId)
        {
            ISession session = GetCachedSession(sessionId);
            if (session == null)
            {
                session = DoRead(sessionId);
                if (session == null)
                {
                    throw new UnknownSessionException(
                        string.Format("There is no session with ID [{0}]", sessionId));
                }

                CacheValidSession(session, sessionId);
            }

            return session;
        }

        public void Update(ISession session)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Public Properties

        public ICache ActiveSessionsCache
        {
            get
            {
                return _activeSessions;
            }
            set
            {
                _activeSessions = value;
            }
        }

        public string ActiveSessionsCacheName
        {
            get
            {
                return _activeSessionsCacheName;
            }
            set
            {
                _activeSessionsCacheName = value;
            }
        }

        #endregion

        #region Protected Methods

        protected void Cache(ISession session, object sessionId, ICache cache)
        {
            cache.Add(sessionId, session);
        }

        protected void CacheValidSession(ISession session, object sessionId)
        {
            if (session == null || sessionId == null)
            {
                return;
            }

            ICache cache = ActiveSessionsCache;
            if (cache == null)
            {
                return;
            }

            if (session is IValidatingSession && !(session as IValidatingSession).IsValid)
            {
                Uncache(session);
            }
            else
            {
                Cache(session, sessionId, cache);
            }
        }

        protected ICache CreateActiveSessionsCache()
        {
            ICacheManager cacheManager = CacheManager;
            if (cacheManager == null)
            {
                return null;
            }

            return cacheManager.GetCache(ActiveSessionsCacheName);
        }

        protected abstract object DoCreate(ISession session);
        protected abstract void DoDelete(ISession session);
        protected abstract ISession DoRead(object sessionId);
        protected abstract void DoUpdate(ISession session);

        protected void EnsureUncached(object sessionId)
        {
            ICache cache = GetActiveSessionsCacheLazy();
            if (cache != null && cache.ContainsKey(sessionId))
            {
                throw new ArgumentException(
                    string.Format("A session already exists with ID [{0}]. Session IDs must be unique", sessionId));
            }
        }

        protected ICache GetActiveSessionsCacheLazy()
        {
            if (_activeSessions == null)
            {
                _activeSessions = CreateActiveSessionsCache();
            }
            return _activeSessions;
        }

        protected ISession GetCachedSession(object sessionId)
        {
            if (sessionId == null)
            {
                return null;
            }

            ICache cache = GetActiveSessionsCacheLazy();
            if (cache == null)
            {
                return null;
            }

            return GetCachedSession(sessionId, cache);
        }

        protected ISession GetCachedSession(object sessionId, ICache cache)
        {
            return (cache.ContainsKey(sessionId) ? cache[sessionId] as ISession : null);
        }

        protected void Uncache(ISession session)
        {
            if (session == null)
            {
                return;
            }

            object id = session.Id;
            if (id == null)
            {
                return;
            }

            ICache cache = ActiveSessionsCache;
            if (cache != null)
            {
                cache.Remove(id);
            }
        }

        protected void VerifySessionId(object sessionId)
        {
            if (sessionId == null)
            {
                throw new InvalidOperationException("DoCreate returned a null session ID. " +
                    "Please verify the implementation");
            }
            EnsureUncached(sessionId);
        }

        #endregion
    }
}
