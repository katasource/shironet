using System;

using Apache.Shiro.Subject;

namespace Apache.Shiro.Aop
{
    public abstract class AttributeHandler<T> where T : Attribute
    {
        protected AttributeHandler()
        {
            
        }

        protected ISubject GetSubject()
        {
            return SecurityUtils.GetSubject();
        }
    }
}