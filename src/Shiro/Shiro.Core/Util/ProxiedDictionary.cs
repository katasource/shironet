using System;
using System.Collections;
using System.Collections.Generic;

namespace Apache.Shiro.Util
{
    public class ProxiedDictionary<K, V> : IDictionary<K, V>
    {
        #region Private Fields

        private readonly IDictionary<K, V> _delegate;

        #endregion

        public ProxiedDictionary(IDictionary<K, V> target)
        {
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            _delegate = target;
        }

        #region IDictionary<K,V> Members

        public virtual ICollection<K> Keys
        {
            get
            {
                return _delegate.Keys;
            }
        }

        public virtual ICollection<V> Values
        {
            get
            {
                return _delegate.Values;
            }
        }

        public virtual V this[K key]
        {
            get
            {
                return _delegate[key];
            }
            set
            {
                _delegate[key] = value;
            }
        }

        public virtual void Add(K key, V value)
        {
            _delegate.Add(key, value);
        }

        public bool ContainsKey(K key)
        {
            return _delegate.ContainsKey(key);
        }

        public virtual bool Remove(K key)
        {
            return _delegate.Remove(key);
        }

        public virtual bool TryGetValue(K key, out V value)
        {
            return _delegate.TryGetValue(key, out value);
        }

        #endregion

        #region ICollection<KeyValuePair<K,V>> Members

        public virtual int Count
        {
            get
            {
                return _delegate.Count;
            }
        }

        public virtual bool IsReadOnly
        {
            get
            {
                return _delegate.IsReadOnly;
            }
        }

        public virtual void Add(KeyValuePair<K, V> item)
        {
            _delegate.Add(item);
        }

        public virtual void Clear()
        {
            _delegate.Clear();
        }

        public virtual bool Contains(KeyValuePair<K, V> item)
        {
            return _delegate.Contains(item);
        }

        public virtual void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
        {
            _delegate.CopyTo(array, arrayIndex);
        }

        public virtual bool Remove(KeyValuePair<K, V> item)
        {
            return _delegate.Remove(item);
        }

        #endregion

        #region IEnumerable<KeyValuePair<K,V>> Members

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            return _delegate.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _delegate.GetEnumerator();
        }

        #endregion
    }
}
