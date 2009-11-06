using System;

using Apache.Shiro.Aop;

namespace Apache.Shiro.Authz.Aop
{
    public abstract class AuthorizingAttributeHandler : AttributeHandler
    {
        protected AuthorizingAttributeHandler(Type attributeType)
            : base(attributeType)
        {

        }

        public abstract void AssertAuthorized(Attribute attribute);
    }
}