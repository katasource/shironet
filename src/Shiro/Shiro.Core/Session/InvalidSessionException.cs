using System;

namespace Apache.Shiro.Session
{
    public class InvalidSessionException : SessionException
    {
        public InvalidSessionException()
        {

        }

        public InvalidSessionException(string message)
            : base(message)
        {

        }

        public InvalidSessionException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public InvalidSessionException(object sessionId)
            : this("Session with ID [" + sessionId + "] has been invalidated", sessionId)
        {

        }

        public InvalidSessionException(string message, object sessionId)
            : base(message, sessionId)
        {

        }

        public InvalidSessionException(string message, Exception innerException, object sessionId)
            : base(message, innerException, sessionId)
        {

        }
    }
}
