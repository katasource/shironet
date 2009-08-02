using System;
using Apache.Shiro;

namespace Apache.Shiro.IO
{
    public class ResourceException : ShiroException
    {
        public ResourceException()
        {

        }

        public ResourceException(string message)
            : base(message)
        {

        }

        public ResourceException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}