using System;

namespace Apache.Shiro.Authc
{
    public class DisabledAccountException : AccountException
    {
        public DisabledAccountException()
        {

        }

        public DisabledAccountException(string message)
            : base(message)
        {

        }

        public DisabledAccountException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}