using System;

namespace Apache.Shiro.Session
{
    public class UnknownSessionException : InvalidSessionException
    {
        public UnknownSessionException()
        {

        }

        public UnknownSessionException(string message)
            : base(message)
        {

        }

        public UnknownSessionException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public UnknownSessionException(object sessionId)
            : base(sessionId)
        {

        }

        public UnknownSessionException(string message, object sessionId)
            : base(message, sessionId)
        {

        }

        public UnknownSessionException(string message, Exception innerException, object sessionId)
            : base(message, innerException, sessionId)
        {

        }
    }
}
