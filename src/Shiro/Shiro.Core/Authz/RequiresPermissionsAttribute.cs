using System;

namespace Apache.Shiro.Authz
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RequiresPermissionsAttribute : Attribute
    {
        private readonly string[] _permissions;

        public RequiresPermissionsAttribute(string[] permissions)
        {
            _permissions = permissions;
        }

        public string[] Permissions
        {
            get
            {
                return _permissions;
            }
        }
    }
}