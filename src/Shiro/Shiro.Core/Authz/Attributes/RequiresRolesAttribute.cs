using System;

namespace Apache.Shiro.Authz.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    [Serializable]
    public class RequiresRolesAttribute : Attribute
    {
        public RequiresRolesAttribute(params string[] roles)
        {
            Roles = roles;
        }

        public string[] Roles { get; private set; }
    }
}