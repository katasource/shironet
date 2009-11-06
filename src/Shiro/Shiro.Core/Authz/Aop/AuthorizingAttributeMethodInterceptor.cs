using System;

using Apache.Shiro.Aop;

namespace Apache.Shiro.Authz.Aop
{
    public abstract class AuthorizingAttributeMethodInterceptor
        : AttributeMethodInterceptor<AuthorizingAttributeHandler>, IAuthorizingMethodInterceptor
    {
        protected AuthorizingAttributeMethodInterceptor(AuthorizingAttributeHandler handler)
            : base(handler)
        {

        }

        public override object Invoke(IMethodInvocation invocation)
        {
            AssertAuthorized(invocation);

            return invocation.Proceed();
        }

        public void AssertAuthorized(IMethodInvocation invocation)
        {
            Attribute attribute = GetAttribute(invocation);
            if (attribute != null)
            {
                Handler.AssertAuthorized(attribute);
            }
        }
    }
}