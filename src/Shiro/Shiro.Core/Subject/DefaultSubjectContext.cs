using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Common.Logging;

using Apache.Shiro.Authc;
using Apache.Shiro.Management;
using Apache.Shiro.Session;

namespace Apache.Shiro.Subject
{
    public class DefaultSubjectContext : ISubjectContext
    {
        #region Private Constants

        private const string AuthenticatedKey = KeyRoot + ".AUTHENTICATED";
        private const string AuthenticationInfoKey = KeyRoot + ".AUTHENTICATION_INFO";
        private const string AuthenticationTokenKey = KeyRoot + ".AUTHENTICATION_TOKEN";
        private const string HostKey = KeyRoot + ".HOST";
        private const string KeyRoot = "Apache.Shiro.Subject.DefaultSubjectContext";
        private const string PrincipalsKey = KeyRoot + ".PRINCIPALS";
        private const string SecurityManagerKey = KeyRoot + ".SECURITY_MANAGER";
        private const string SessionKey = KeyRoot + ".SESSION";
        private const string SessionIdKey = SessionKey + "_ID";
        private const string SubjectKey = KeyRoot + ".SUBJECT";

        #endregion

        #region Private Static Fields

        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Private Fields

        private readonly IDictionary<string, object> _dictionary;

        #endregion

        public DefaultSubjectContext()
        {
            _dictionary = new Dictionary<string, object>();
        }

        public DefaultSubjectContext(ISubjectContext other)
            : this()
        {
            if (other != null && other.Count > 0)
            {
                _dictionary.Concat(other);
            }
        }

        #region IDictionary<string, object> Members

        public object this[string key]
        {
            get
            {
                return _dictionary[key];
            }
            set
            {
                _dictionary[key] = value;
            }
        }

        public int Count
        {
            get
            {
                return _dictionary.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return _dictionary.IsReadOnly;
            }
        }

        public ICollection<string> Keys
        {
            get
            {
                return _dictionary.Keys;
            }
        }

        public ICollection<object> Values
        {
            get
            {
                return _dictionary.Values;
            }
        }

        public void Add(KeyValuePair<string, object> item)
        {
            _dictionary.Add(item);
        }

        public void Add(string key, object value)
        {
            _dictionary.Add(key, value);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return _dictionary.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return _dictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            _dictionary.CopyTo(array, arrayIndex);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return _dictionary.Remove(item);
        }

        public bool Remove(string key)
        {
            return _dictionary.Remove(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        #endregion

        #region ISubjectContext Members

        public bool Authenticated
        {
            get
            {
                return GetAs<bool>(AuthenticatedKey);
            }
            set
            {
                Add(AuthenticatedKey, value);
            }
        }

        public IAuthenticationInfo AuthenticationInfo
        {
            get
            {
                return GetAs<IAuthenticationInfo>(AuthenticationInfoKey);
            }
            set
            {
                AddIfSet(AuthenticationInfoKey, value);
            }
        }

        public IAuthenticationToken AuthenticationToken
        {
            get
            {
                return GetAs<IAuthenticationToken>(AuthenticationTokenKey);
            }
            set
            {
                AddIfSet(AuthenticationTokenKey, value);
            }
        }

        public string Host
        {
            get
            {
                return GetAs<string>(HostKey);
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    Add(HostKey, value);
                }
            }
        }

        public IPrincipalCollection Principals
        {
            get
            {
                return GetAs<IPrincipalCollection>(PrincipalsKey);
            }
            set
            {
                if (value != null && value.Count > 0)
                {
                    Add(PrincipalsKey, value);
                }
            }
        }

        public ISecurityManager SecurityManager
        {
            get
            {
                return GetAs<ISecurityManager>(SecurityManagerKey);
            }
            set
            {
                AddIfSet(SecurityManagerKey, value);
            }
        }

        public ISession Session
        {
            get
            {
                return GetAs<ISession>(SessionKey);
            }
            set
            {
                AddIfSet(SessionKey, value);
            }
        }

        public object SessionId
        {
            get
            {
                return _dictionary[SessionIdKey];
            }
            set
            {
                AddIfSet(SessionIdKey, value);
            }
        }

        public ISubject Subject
        {
            get
            {
                return GetAs<ISubject>(SubjectKey);
            }
            set
            {
                AddIfSet(SubjectKey, value);
            }
        }

        public bool ResolveAuthenticated()
        {
            if (_dictionary.ContainsKey(AuthenticatedKey))
            {
                return (bool) _dictionary[AuthenticatedKey];
            }
            if (AuthenticationInfo != null)
            {
                return true;
            }

            var session = ResolveSession();
            if (session == null)
            {
                return false;
            }

            var attribute = session.GetAttribute(SessionAttributeKey.Authenticated);
            return (attribute == null ? false : (bool) attribute);
        }

        public string ResolveHost()
        {
            var host = Host;
            if (host == null)
            {
                var token = AuthenticationToken;
                if (token is IHostAuthenticationToken)
                {
                    host = ((IHostAuthenticationToken) token).Host;
                }

                if (host == null)
                {
                    var session = ResolveSession();
                    if (session != null)
                    {
                        host = session.Host;
                    }
                }
            }

            return host;
        }

        public IPrincipalCollection ResolvePrincipals()
        {
            var principals = Principals;
            if (principals == null)
            {
                var info = AuthenticationInfo;
                if (info != null)
                {
                    principals = info.Principals;
                }

                if (principals == null)
                {
                    var subject = Subject;
                    if (subject != null)
                    {
                        principals = subject.Principals;
                    }

                    if (principals == null)
                    {
                        var session = ResolveSession();
                        if (session != null)
                        {
                            principals = (IPrincipalCollection)session.GetAttribute(SessionAttributeKey.Principals);
                        }
                    }
                }
            }
            return principals;
        }

        public ISecurityManager ResolveSecurityManager()
        {
            var securityManager = SecurityManager;
            if (securityManager == null)
            {
                try
                {
                    securityManager = SecurityUtils.SecurityManager;
                }
                catch (UnavailableSecurityManagerException e)
                {
                    Log.Debug("No SecurityManager available via SecurityUtils. Heuristics exhausted", e);
                }
            }
            return securityManager;
        }

        public ISession ResolveSession()
        {
            var session = Session;
            if (session == null)
            {
                var subject = Subject;
                if (subject != null)
                {
                    session = subject.GetSession(false);
                }
            }
            return session;
        }

        #endregion

        #region Public Methods

        public T GetAs<T>(string key)
        {
            if (_dictionary.ContainsKey(key))
            {
                return (T) _dictionary[key];
            }
            return default(T);
        }

        #endregion

        #region Private Methods

        private void AddIfSet(string key, object value)
        {
            if (value != null)
            {
                Add(key, value);
            }
        }

        #endregion
    }
}