using System;
using System.Collections;
using System.Collections.Generic;

namespace Apache.Shiro.Cache
{
    public sealed class ImmutableProxiedCache : ICache
    {
        #region Private Fields

        private readonly ICache _delegate;

        #endregion

        public ImmutableProxiedCache(ICache target)
        {
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            _delegate = target;
        }

        #region ICache Members

        public int Count
        {
            get
            {
                return _delegate.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        public ICollection<object> Keys
        {
            get
            {
                return _delegate.Keys;
            }
        }

        public ICollection<object> Values
        {
            get
            {
                return _delegate.Values;
            }
        }

        public object this[object key]
        {
            get
            {
                return _delegate[key];
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public void Add(object key, object value)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool ContainsKey(object key)
        {
            return _delegate.ContainsKey(key);
        }

        public bool Remove(object key)
        {
            return _delegate.Remove(key);
        }

        public bool TryGetValue(object key, out object value)
        {
            return _delegate.TryGetValue(key, out value);
        }

        #endregion

        #region IEnumerable<KeyValuePair<object,object>> Members

        public IEnumerator<KeyValuePair<object, object>> GetEnumerator()
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
