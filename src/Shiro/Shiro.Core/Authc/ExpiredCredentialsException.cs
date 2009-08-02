using System;

namespace Apache.Shiro.Authc
{
    public class ExpiredCredentialsException : CredentialsException
    {
        public ExpiredCredentialsException()
        {

        }

        public ExpiredCredentialsException(string message)
            : base(message)
        {

        }

        public ExpiredCredentialsException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}