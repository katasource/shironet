using Apache.Shiro.Subject;

namespace Apache.Shiro.Aop
{
    public abstract class MethodInterceptorSupport : IMethodInterceptor
    {
        public MethodInterceptorSupport()
        {

        }

        public abstract object Invoke(IMethodInvocation methodInvocation);

        protected ISubject GetSubject()
        {
            return SecurityUtils.GetSubject();
        }
    }
}