using System;
using Apache.Shiro;

namespace Apache.Shiro.Subject
{
    public class SubjectException : ShiroException
    {
        public SubjectException()
        {

        }

        public SubjectException(string message)
            : base(message)
        {

        }

        public SubjectException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}