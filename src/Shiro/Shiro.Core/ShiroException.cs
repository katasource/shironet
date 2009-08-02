using System;

namespace Apache.Shiro
{
    public class ShiroException : ApplicationException
    {
        public ShiroException()
        {

        }

        public ShiroException(string message)
            : base(message)
        {

        }

        public ShiroException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}