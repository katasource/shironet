using System;
using Apache.Shiro.Aop;

namespace Apache.Shiro.Authz.Aop
{
    public interface IAuthorizingMethodInterceptor : IMethodInterceptor
    {
        void AssertAuthorized(IMethodInvocation invocation);
    }
}