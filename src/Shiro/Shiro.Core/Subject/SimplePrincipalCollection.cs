using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Apache.Shiro.Subject
{
    public class SimplePrincipalCollection : IMutablePrincipalCollection
    {
        #region Private Fields

        private readonly IDictionary<string, HashSet<object>> _realmPrincipals;

        #endregion

        public SimplePrincipalCollection()
        {
            _realmPrincipals = new Dictionary<string, HashSet<object>>();
        }

        public SimplePrincipalCollection(object principal, string realmName)
            : this()
        {
            if (principal is ICollection)
            {
                AddAll(principal as ICollection<object>, realmName);
            }
            else
            {
                Add(principal, realmName);
            }
        }

        public SimplePrincipalCollection(ICollection<object> principals, string realmName)
            : this()
        {
            AddAll(principals, realmName);
        }

        public SimplePrincipalCollection(IPrincipalCollection principals)
            : this()
        {
            AddAll(principals);
        }

        #region IMutablePrincipalCollection Members

        public void Add(object principal, string realmName)
        {
            if (realmName == null)
            {
                throw new ArgumentNullException("realmName");
            }
            if (principal == null)
            {
                throw new ArgumentNullException("principal");
            }

            this[realmName].Add(principal);
        }

        public void AddAll(ICollection<object> principals, string realmName)
        {
            if (realmName == null)
            {
                throw new ArgumentNullException("realmName");
            }
            if (principals == null)
            {
                throw new ArgumentNullException("principals");
            }
            this[realmName].UnionWith(principals);
        }

        public void AddAll(IPrincipalCollection principals)
        {
            if (principals == null)
            {
                throw new ArgumentNullException("principals");
            }

            var realmNames = principals.RealmNames;
            if (realmNames == null || realmNames.Count <= 0)
            {
                return;
            }

            foreach (var realmName in realmNames)
            {
                AddAll(principals.FromRealm(realmName), realmName);
            }
        }

        public void Clear()
        {
            _realmPrincipals.Clear();
        }

        #endregion

        #region IPrincipalCollection Members

        public int Count
        {
            get
            {
                return _realmPrincipals.Count;
            }
        }

        public ICollection<string> RealmNames
        {
            get
            {
                return _realmPrincipals.Keys;
            }
        }

        public ICollection<object> AsCollection()
        {
            var all = new HashSet<object>();
            foreach (var principal in _realmPrincipals.Values)
            {
                all.UnionWith(principal);
            }

            return all;
        }

        public IList<object> AsList()
        {
            return new List<object>(AsCollection());
        }

        public ICollection<T> ByType<T>()
        {
            var principals = _realmPrincipals.SelectMany(keyValue => keyValue.Value.OfType<T>());

            return new List<T>(principals);
        }

        public ICollection<object> FromRealm(string realmName)
        {
            if (_realmPrincipals.ContainsKey(realmName))
            {
                return new HashSet<object>(_realmPrincipals[realmName]);
            }

            //Zero-length arrays are immutable collections.
            return new object[0];
        }

        public T OneByType<T>()
        {
            return ByType<T>().FirstOrDefault();
        }

        #endregion

        #region IEnumerable<object> Members

        public IEnumerator<object> GetEnumerator()
        {
            return AsCollection().GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Private Methods

        private HashSet<object> this[string realmName]
        {
            get
            {
                HashSet<object> principals;
                if (_realmPrincipals.ContainsKey(realmName))
                {
                    principals = _realmPrincipals[realmName];
                }
                else
                {
                    principals = new HashSet<object>();

                    _realmPrincipals.Add(realmName, principals);
                }

                return principals;
            }
        }

        #endregion
    }
}