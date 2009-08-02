using System;
using Apache.Shiro;

namespace Apache.Shiro.Authc
{
    public class AuthenticationException : ShiroException
    {
        public AuthenticationException()
        {

        }

        public AuthenticationException(string message)
            : base(message)
        {

        }

        public AuthenticationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
