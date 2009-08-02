using System;

namespace Apache.Shiro.Authz
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RequiresRolesAttribute : Attribute
    {
        private readonly string[] _roles;

        public RequiresRolesAttribute(string[] roles)
        {
            _roles = roles;
        }

        public string[] Roles
        {
            get
            {
                return _roles;
            }
        }
    }
}