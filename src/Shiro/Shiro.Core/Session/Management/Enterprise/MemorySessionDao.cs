using System;
using System.Security.Cryptography;

using Apache.Shiro.Cache;

namespace Apache.Shiro.Session.Management.Enterprise
{
    public class MemorySessionDao : CachingSessionDao
    {
        private RandomNumberGenerator _randomNumberGenerator;

        public MemorySessionDao()
        {
            CacheManager = new DictionaryCacheManager();
        }

        public RandomNumberGenerator RandomNumberGenerator
        {
            get
            {
                if (_randomNumberGenerator == null)
                {
                    _randomNumberGenerator = CreateRandomNumberGenerator();
                }
                return _randomNumberGenerator;
            }
            set
            {
                _randomNumberGenerator = value;
            }
        }

        protected virtual void AssignSessionId(ISession session, object sessionId)
        {
            if (session is SimpleSession)
            {
                (session as SimpleSession).Id = sessionId;
            }
            else
            {
                throw new ArgumentException("Assigning a session ID requires a SimpleSession");
            }
        }

        protected override object DoCreate(ISession session)
        {
            var sessionId = GenerateNewSessionId();
            AssignSessionId(session, sessionId);
            return sessionId;
        }

        protected override void DoDelete(ISession session)
        {
            //Does nothing--parent class removes from the cache
        }

        protected override ISession DoRead(object sessionId)
        {
            //Should never execute because this implementation relies on parent class to access cache,
            //which is where all sessions reside--it is the cache implementation that determines if the
            //cache is memory-only or disk-persistent, etc.
            return null;
        }

        protected override void DoUpdate(ISession session)
        {
            //Does nothing--parent class persists to the cache
        }

        protected virtual object GenerateNewSessionId()
        {
            var buffer = new byte[8];
            RandomNumberGenerator.GetBytes(buffer);

            return BitConverter.ToUInt64(buffer, 0);
        }

        protected virtual RandomNumberGenerator CreateRandomNumberGenerator()
        {
            return RandomNumberGenerator.Create();
        }
    }
}
