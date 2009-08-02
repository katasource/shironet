using System;

namespace Apache.Shiro.Authc
{
    public class LockedAccountException : DisabledAccountException
    {
        public LockedAccountException()
        {

        }

        public LockedAccountException(string message)
            : base(message)
        {

        }

        public LockedAccountException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}