using System;

namespace Apache.Shiro.Authc
{
    public class ExcessiveAttemptsException : AccountException
    {
        public ExcessiveAttemptsException()
        {

        }

        public ExcessiveAttemptsException(string message)
            : base(message)
        {

        }

        public ExcessiveAttemptsException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}