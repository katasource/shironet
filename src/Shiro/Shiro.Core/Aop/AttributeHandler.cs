using System;

using Apache.Shiro.Subject;

namespace Apache.Shiro.Aop
{
    public abstract class AttributeHandler
    {
        private Type _attributeType;

        protected AttributeHandler(Type attributeType)
        {
            AttributeType = attributeType;
        }

        public Type AttributeType
        {
            get
            {
                return _attributeType;
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _attributeType = value;
            }
        }

        protected ISubject GetSubject()
        {
            return SecurityUtils.GetSubject();
        }
    }
}