using Apache.Shiro.Aop;

namespace Apache.Shiro.Authz.Aop
{
    public abstract class AuthorizingMethodInterceptorSupport : MethodInterceptorSupport, IAuthorizingMethodInterceptor
    {
        public override object Invoke(IMethodInvocation invocation)
        {
            AssertAuthorized(invocation);

            return invocation.Proceed();
        }

        public abstract void AssertAuthorized(IMethodInvocation invocation);
    }
}