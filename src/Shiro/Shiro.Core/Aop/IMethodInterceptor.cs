namespace Apache.Shiro.Aop
{
    public interface IMethodInterceptor
    {
        object Invoke(IMethodInvocation methodInvocation);
    }
}