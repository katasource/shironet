using System;

namespace Apache.Shiro.Authc
{
    public class AccountException : AuthenticationException
    {
        public AccountException()
        {

        }

        public AccountException(string message)
            : base(message)
        {

        }

        public AccountException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}