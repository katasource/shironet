using System;

namespace Apache.Shiro.Session
{
    public class ExpiredSessionException : InvalidSessionException
    {
        public ExpiredSessionException()
        {

        }

        public ExpiredSessionException(string message)
            : base(message)
        {

        }

        public ExpiredSessionException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public ExpiredSessionException(object sessionId)
            : this("Session with ID [" + sessionId + "] has expired", sessionId)
        {

        }

        public ExpiredSessionException(string message, object sessionId)
            : base(message, sessionId)
        {

        }

        public ExpiredSessionException(string message, Exception innerException, object sessionId)
            : base(message, innerException, sessionId)
        {

        }
    }
}
