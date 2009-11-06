using System;
using System.Linq;

namespace Apache.Shiro.Aop
{
    public abstract class AttributeMethodInterceptor<T> : MethodInterceptorSupport where T : AttributeHandler
    {
        protected AttributeMethodInterceptor(T handler)
        {
            Handler = handler;
        }

        public T Handler { get; set; }

        public bool Supports(IMethodInvocation invocation)
        {
            return (GetAttribute(invocation) != null);
        }

        protected Attribute GetAttribute(IMethodInvocation invocation)
        {
            if (invocation == null)
            {
                throw new ArgumentNullException("invocation");
            }

            var method = invocation.Method;
            if (method == null)
            {
                throw new ArgumentException(Properties.Resources.InvalidMethodInvocationMessage);
            }

            var attributes = method.GetCustomAttributes(Handler.AttributeType, true);
            return attributes.Cast<Attribute>().FirstOrDefault();
        }
    }
}