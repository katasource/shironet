using System;
using System.Linq;
using System.Collections.Generic;

namespace Apache.Shiro.Authz
{
    [Serializable]
    public class SimpleRole
    {
        public SimpleRole()
        {
            
        }

        public SimpleRole(string name, ISet<IPermission> permissions = null)
        {
            Name = name;
            Permissions = permissions;
        }

        public string Name { get; set; }

        public ISet<IPermission> Permissions { get; set; }

        public void Add(IPermission permission)
        {
            if (Permissions == null)
            {
                Permissions = new HashSet<IPermission>();
            }
            Permissions.Add(permission);
        }

        public void AddAll(IEnumerable<IPermission> e)
        {
            if (Permissions == null)
            {
                Permissions = new HashSet<IPermission>(e);
            }
            else
            {
                Permissions.UnionWith(e);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (obj is SimpleRole)
            {
                var role = (SimpleRole) obj;

                return (Name == null ? role.Name == null : Name == role.Name);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Name == null ? 0 : Name.GetHashCode());
        }

        public bool IsPermitted(IPermission permission)
        {
            return Permissions.Any(it => it.Implies(permission));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}