using System;

namespace Apache.Shiro.Authc
{
    public class CredentialsException : AuthenticationException
    {
        public CredentialsException()
        {

        }

        public CredentialsException(string message)
            : base(message)
        {

        }

        public CredentialsException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}