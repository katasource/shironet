using System;
using System.Linq;

namespace Apache.Shiro.Aop
{
    public abstract class AttributeMethodInterceptor<T, U> : MethodInterceptorSupport
        where T : AttributeHandler<U>
        where U : Attribute
    {
        public AttributeMethodInterceptor(T handler)
        {
            Handler = handler;
        }

        public T Handler { get; set; }

        public bool Supports(IMethodInvocation invocation)
        {
            return (GetAttribute(invocation) != null);
        }

        protected U GetAttribute(IMethodInvocation invocation)
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

            var attributes = method.GetCustomAttributes(true);
            return attributes.OfType<U>().FirstOrDefault();
        }
    }
}