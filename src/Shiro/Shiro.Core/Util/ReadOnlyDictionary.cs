using System;
using System.Collections.Generic;

namespace Apache.Shiro.Util
{
    public class ReadOnlyDictionary<K, V> : ProxiedDictionary<K, V>
    {
        public ReadOnlyDictionary(IDictionary<K, V> target)
            : base(target)
        {

        }

        public override bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public override V this[K key]
        {
            set
            {
                throw new NotSupportedException(Properties.Resources.ReadOnlyDictionaryMessage);
            }
        }

        public override void Add(K key, V value)
        {
            throw new NotSupportedException(Properties.Resources.ReadOnlyDictionaryMessage);
        }

        public override void Add(KeyValuePair<K, V> item)
        {
            throw new NotSupportedException(Properties.Resources.ReadOnlyDictionaryMessage);
        }

        public override void Clear()
        {
            throw new NotSupportedException(Properties.Resources.ReadOnlyDictionaryMessage);
        }

        public override bool Remove(K key)
        {
            throw new NotSupportedException(Properties.Resources.ReadOnlyDictionaryMessage);
        }

        public override bool Remove(KeyValuePair<K, V> item)
        {
            throw new NotSupportedException(Properties.Resources.ReadOnlyDictionaryMessage);
        }
    }
}
