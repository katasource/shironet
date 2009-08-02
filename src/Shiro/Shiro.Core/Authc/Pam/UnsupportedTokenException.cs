using System;

namespace Apache.Shiro.Authc.Pam
{
    public class UnsupportedTokenException : AuthenticationException
    {
        public UnsupportedTokenException()
        {

        }

        public UnsupportedTokenException(string message)
            : base(message)
        {

        }

        public UnsupportedTokenException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}