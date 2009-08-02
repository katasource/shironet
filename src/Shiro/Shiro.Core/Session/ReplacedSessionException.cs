using System;

namespace Apache.Shiro.Session
{
    public class ReplacedSessionException : InvalidSessionException
    {
        private readonly object _newSessionId;

        public ReplacedSessionException()
        {

        }

        public ReplacedSessionException(string message, Exception innerException, object originalSessionId, object newSessionId)
            : base(message, innerException, originalSessionId)
        {
            _newSessionId = newSessionId;
        }

        public object NewSessionId
        {
            get
            {
                return _newSessionId;
            }
        }

        public object OriginalSessionId
        {
            get
            {
                return SessionId;
            }
        }
    }
}
