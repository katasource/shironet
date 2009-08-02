using System;
using Apache.Shiro;

namespace Apache.Shiro.IO
{
    public class SerializationException : ShiroException
    {
        public SerializationException()
        {

        }

        public SerializationException(string message)
            : base(message)
        {

        }

        public SerializationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}