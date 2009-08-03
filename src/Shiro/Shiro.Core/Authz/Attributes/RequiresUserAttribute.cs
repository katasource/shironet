using System;

namespace Apache.Shiro.Authz.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    [Serializable]
    public class RequiresUserAttribute : Attribute
    {

    }
}