using System.Reflection;

namespace Apache.Shiro.Aop
{
    public interface IMethodInvocation
    {
        object[] Arguments
        {
            get;
        }

        MethodInfo Method
        { 
            get;
        }

        object Proceed();
    }
}