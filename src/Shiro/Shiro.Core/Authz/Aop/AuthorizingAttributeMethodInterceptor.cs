using System;

using Apache.Shiro.Aop;

namespace Apache.Shiro.Authz.Aop
{
    public abstract class AuthorizingAttributeMethodInterceptor<T>
        : AttributeMethodInterceptor<AuthorizingAttributeHandler<T>, T>, IAuthorizingMethodInterceptor
        where T : Attribute
    {
        protected AuthorizingAttributeMethodInterceptor(AuthorizingAttributeHandler<T> handler)
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
            T attribute = GetAttribute(invocation);
            if (attribute != null)
            {
                Handler.AssertAuthorized(GetAttribute(invocation));
            }
        }
    }
}