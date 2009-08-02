using System;
using System.Collections.Generic;

using Apache.Shiro.Util;

namespace Apache.Shiro.Cache
{
    public class DictionaryCacheManager : ICacheManager, IDisposable
    {
        private readonly IDictionary<string, ICache> _caches;

        public DictionaryCacheManager()
        {
            _caches = new Dictionary<string, ICache>();
        }

        #region ICacheManager Members

        public ICache GetCache(string cacheName)
        {
            if (string.IsNullOrEmpty(cacheName))
            {
                throw new CacheException("Cache name cannot be null or empty");
            }

            lock (_caches)
            {
                if (_caches.ContainsKey(cacheName))
                {
                    return _caches[cacheName];
                }

                ICache cache = new DictionaryCache();
                _caches.Add(cacheName, cache);

                return cache;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            lock (_caches)
            {
                LifecycleUtils.Dispose(_caches.Values);

                _caches.Clear();
            }
        }

        #endregion
    }
}
