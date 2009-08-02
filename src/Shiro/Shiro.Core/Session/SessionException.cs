using System;
using Apache.Shiro;

namespace Apache.Shiro.Session
{
    public class SessionException : ShiroException
    {
        private object _sessionId;

        public SessionException()
        {

        }

        public SessionException(string message)
            : base(message)
        {

        }

        public SessionException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public SessionException(object sessionId)
        {
            _sessionId = sessionId;
        }

        public SessionException(string message, object sessionId)
            : base(message)
        {
            _sessionId = sessionId;
        }

        public SessionException(string message, Exception innerException, object sessionId)
            : base(message, innerException)
        {
            _sessionId = sessionId;
        }

        public object SessionId
        {
            get
            {
                return _sessionId;
            }
            set
            {
                _sessionId = value;
            }
        }
    }
}
