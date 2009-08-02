using System;

namespace Apache.Shiro.Authz
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RequiresAuthenticationAttribute : Attribute
    {
        
    }
}