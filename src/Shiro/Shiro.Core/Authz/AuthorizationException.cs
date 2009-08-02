using System;
using Apache.Shiro;

namespace Apache.Shiro.Authz
{
    public class AuthorizationException : ShiroException
    {
        public AuthorizationException()
        {

        }

        public AuthorizationException(string message)
            : base(message)
        {

        }

        public AuthorizationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}