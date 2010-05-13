using System.Collections.Generic;

namespace Apache.Shiro.Authz
{
    public class SimpleAuthorizationInfo : IAuthorizationInfo
    {
        private ISet<IPermission> _objectPermissions;
        private ISet<string> _roles;
        private ISet<string> _stringPermissions;

        public SimpleAuthorizationInfo()
        {

        }

        public SimpleAuthorizationInfo(ISet<string> roles)
        {
            _roles = roles;
        }

        public ICollection<IPermission> ObjectPermissions
        {
            get
            {
                return _objectPermissions;
            }
            set
            {
                _objectPermissions = (value == null ? null : new HashSet<IPermission>(value));
            }
        }

        public ICollection<string> Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = (value == null ? null : new HashSet<string>(value));
            }
        }

        public ICollection<string> StringPermissions
        {
            get
            {
                return _stringPermissions;
            }
            set
            {
                _stringPermissions = (value == null ? null : new HashSet<string>(value));
            }
        }

        public void AddObjectPermission(IPermission permission)
        {
            if (_objectPermissions == null)
            {
                _objectPermissions = new HashSet<IPermission>();
            }
            _objectPermissions.Add(permission);
        }

        public void AddObjectPermissions(IEnumerable<IPermission> e)
        {
            if (_objectPermissions == null)
            {
                _objectPermissions = new HashSet<IPermission>(e);
            }
            else
            {
                _objectPermissions.UnionWith(e);
            }
        }

        public void AddRole(string role)
        {
            if (_roles == null)
            {
                _roles = new HashSet<string>();
            }
            _roles.Add(role);
        }

        public void AddRoles(IEnumerable<string> e)
        {
            if (_roles == null)
            {
                _roles = new HashSet<string>(e);
            }
            else
            {
                _roles.UnionWith(e);
            }
        }

        public void AddStringPermission(string permission)
        {
            if (_stringPermissions == null)
            {
                _stringPermissions = new HashSet<string>();
            }
            _stringPermissions.Add(permission);
        }

        public void AddStringPermissions(IEnumerable<string> e)
        {
            if (_stringPermissions == null)
            {
                _stringPermissions = new HashSet<string>(e);
            }
            else
            {
                _stringPermissions.UnionWith(e);
            }
        }
    }
}