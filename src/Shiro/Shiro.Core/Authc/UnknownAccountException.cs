using System;

namespace Apache.Shiro.Authc
{
    public class UnknownAccountException : AccountException
    {
        public UnknownAccountException()
        {

        }

        public UnknownAccountException(string message)
            : base(message)
        {

        }

        public UnknownAccountException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}