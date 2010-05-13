using System;
using System.Collections.Generic;
using Apache.Shiro.Authz;
using Apache.Shiro.Subject;

namespace Apache.Shiro.Authc
{
    [Serializable]
    public class SimpleAccount : IAccount, IMergeableAuthenticationInfo
    {
        private readonly SimpleAuthenticationInfo _authcInfo;
        private readonly SimpleAuthorizationInfo _authzInfo;

        public SimpleAccount()
        {

        }

        public SimpleAccount(object principal, object credentials, string realmName,
            ISet<string> roles = null, ISet<IPermission> permissions = null)
            : this(
                principal is IPrincipalCollection
                    ? (IPrincipalCollection) principal
                    : new SimplePrincipalCollection(principal, realmName), credentials, roles, permissions)
        {
            
        }

        public SimpleAccount(ICollection<object> principals, object credentials, string realmName,
            ISet<string> roles = null, ISet<IPermission> permissions = null)
            : this(new SimplePrincipalCollection(principals, realmName), credentials, roles, permissions)
        {
            
        }

        public SimpleAccount(IPrincipalCollection principals, object credentials,
            ISet<string> roles = null, ISet<IPermission> permissions = null)
        {
            _authcInfo = new SimpleAuthenticationInfo(principals, credentials);

            _authzInfo = (roles == null ? new SimpleAuthorizationInfo() : new SimpleAuthorizationInfo(roles));
            _authzInfo.ObjectPermissions = permissions;
        }

        public object Credentials
        {
            get
            {
                return _authcInfo.Credentials;
            }
            set
            {
                _authcInfo.Credentials = value;
            }
        }

        public bool CredentialsExpired { get; set; }

        public bool Locked { get; set; }

        public ICollection<IPermission> ObjectPermissions
        {
            get
            {
                return _authzInfo.ObjectPermissions;
            }
            set
            {
                _authzInfo.ObjectPermissions = value;
            }
        }

        public IPrincipalCollection Principals
        {
            get
            {
                return _authcInfo.Principals;
            }
            set
            {
                _authcInfo.Principals = value;
            }
        }

        public ICollection<string> Roles
        {
            get
            {
                return _authzInfo.Roles;
            }
            set
            {
                _authzInfo.Roles = value;
            }
        }

        public ICollection<string> StringPermissions
        {
            get
            {
                return _authzInfo.StringPermissions;
            }
            set
            {
                _authzInfo.StringPermissions = value;
            }
        }

        public void AddObjectPermission(IPermission permission)
        {
            _authzInfo.AddObjectPermission(permission);
        }

        public void AddObjectPermissions(IEnumerable<IPermission> e)
        {
            _authzInfo.AddObjectPermissions(e);
        }

        public void AddRole(string role)
        {
            _authzInfo.AddRole(role);
        }

        public void AddRoles(IEnumerable<string> roles)
        {
            _authzInfo.AddRoles(roles);
        }

        public void AddStringPermission(string permission)
        {
            _authzInfo.AddStringPermission(permission);
        }

        public void AddStringPermissions(IEnumerable<string> e)
        {
            _authzInfo.AddStringPermissions(e);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is SimpleAccount)
            {
                var account = (SimpleAccount) obj;

                return (Principals == null ? account.Principals == null : Principals.Equals(account.Principals));
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Principals == null ? 0 : Principals.GetHashCode());
        }

        public void Merge(IAuthenticationInfo other)
        {
            _authcInfo.Merge(other);

            if (other is SimpleAccount)
            {
                var account = (SimpleAccount) other;
                if (account.CredentialsExpired)
                {
                    CredentialsExpired = account.CredentialsExpired;
                }
                if (account.Locked)
                {
                    Locked = true;
                }
            }
        }

        public override string ToString()
        {
            return (Principals == null ? "Empty" : Principals.ToString());
        }
    }
}