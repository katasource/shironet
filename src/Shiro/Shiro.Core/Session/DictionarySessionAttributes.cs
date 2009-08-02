using System.Collections.Generic;

using Apache.Shiro.Util;

namespace Apache.Shiro.Session
{
    public class DictionarySessionAttributes : ProxiedDictionary<object, object>, ISessionAttributes
    {
        public DictionarySessionAttributes()
            : base(new Dictionary<object, object>())
        {

        }

        public DictionarySessionAttributes(IDictionary<object, object> dictionary)
            : base(dictionary)
        {
            
        }

        public ISessionAttributes AsReadOnly()
        {
            return new ImmutableProxiedSessionAttributes(this);
        }
    }
}
