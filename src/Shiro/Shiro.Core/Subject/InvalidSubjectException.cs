using System;

namespace Apache.Shiro.Subject
{
    public class InvalidSubjectException : SubjectException
    {
        public InvalidSubjectException()
        {

        }

        public InvalidSubjectException(string message)
            : base(message)
        {

        }

        public InvalidSubjectException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}