using System;

namespace Apache.Shiro.Authc
{
    public class IncorrectCredentialsException : CredentialsException
    {
        public IncorrectCredentialsException()
        {

        }

        public IncorrectCredentialsException(string message)
            : base(message)
        {

        }

        public IncorrectCredentialsException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}