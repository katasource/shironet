using System;

namespace Apache.Shiro.Authz.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    [Serializable]
    public class RequiresPermissionsAttribute : Attribute
    {
        public RequiresPermissionsAttribute(params string[] permissions)
        {
            Permissions = permissions;
        }

        public string[] Permissions { get; private set; }
    }
}