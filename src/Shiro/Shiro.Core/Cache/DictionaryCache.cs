using System.Collections.Generic;

using Apache.Shiro.Util;

namespace Apache.Shiro.Cache
{
    public class DictionaryCache : ProxiedDictionary<object, object>, ICache
    {
        public DictionaryCache()
            : base(new Dictionary<object, object>())
        {

        }

        public DictionaryCache(IDictionary<object, object> dictionary)
            : base(dictionary)
        {

        }

        public ICache AsReadOnly()
        {
            return new ImmutableProxiedCache(this);
        }
    }
}
