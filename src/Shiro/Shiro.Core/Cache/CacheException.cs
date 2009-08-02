using System;
using Apache.Shiro;

namespace Apache.Shiro.Cache
{
    public class CacheException : ShiroException
    {
        public CacheException()
        {

        }

        public CacheException(string message)
            : base(message)
        {

        }

        public CacheException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
