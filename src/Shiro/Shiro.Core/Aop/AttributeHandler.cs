using System;

using Apache.Shiro.Subject;

namespace Apache.Shiro.Aop
{
    public abstract class AttributeHandler
    {
        protected AttributeHandler(Type attributeType)
        {
            AttributeType = attributeType;
        }

        public Type AttributeType { get; protected set; }

        protected ISubject GetSubject()
        {
            return SecurityUtils.GetSubject();
        }
    }
}