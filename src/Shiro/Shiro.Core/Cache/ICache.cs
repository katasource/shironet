using System.Collections.Generic;

namespace Apache.Shiro.Cache
{
    public interface ICache : IEnumerable<KeyValuePair<object, object>>
    {
        int Count
        {
            get;
        }

        bool IsReadOnly
        {
            get;
        }

        ICollection<object> Keys
        {
            get;
        }

        ICollection<object> Values
        {
            get;
        }

        object this[object key]
        {
            get;
            set;
        }

        void Add(object key, object value);

        void Clear();

        bool ContainsKey(object key);

        bool Remove(object key);

        bool TryGetValue(object key, out object value);
    }
}
