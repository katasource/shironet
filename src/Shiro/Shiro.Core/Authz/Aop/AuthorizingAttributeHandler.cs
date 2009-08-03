using System;

using Apache.Shiro.Aop;

namespace Apache.Shiro.Authz.Aop
{
    public abstract class AuthorizingAttributeHandler<T> : AttributeHandler<T> where T : Attribute
    {
        public abstract void AssertAuthorized(T attribute);
    }
}