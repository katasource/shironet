using System;

namespace Apache.Shiro.Authc
{
    public class ConcurrentAccessException : AccountException
    {
        public ConcurrentAccessException()
        {

        }

        public ConcurrentAccessException(string message)
            : base(message)
        {

        }

        public ConcurrentAccessException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}