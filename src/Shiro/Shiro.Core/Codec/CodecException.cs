using System;
using Apache.Shiro;

namespace Apache.Shiro.Codec
{
    public class CodecException : ShiroException
    {
        public CodecException()
        {

        }

        public CodecException(string message)
            : base(message)
        {
            
        }

        public CodecException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}