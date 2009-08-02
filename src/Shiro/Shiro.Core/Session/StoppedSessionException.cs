using System;

namespace Apache.Shiro.Session
{
    public class StoppedSessionException : InvalidSessionException
    {
        public StoppedSessionException()
        {

        }

        public StoppedSessionException(string message)
            : base(message)
        {

        }

        public StoppedSessionException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public StoppedSessionException(object sessionId)
            : base(sessionId)
        {

        }

        public StoppedSessionException(string message, object sessionId)
            : base(message, sessionId)
        {

        }

        public StoppedSessionException(string message, Exception innerException, object sessionId)
            : base(message, innerException, sessionId)
        {

        }
    }
}
