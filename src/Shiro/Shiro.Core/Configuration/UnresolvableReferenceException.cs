using System;

namespace Apache.Shiro.Configuration
{
    public class UnresolvableReferenceException : ConfigurationException
    {
        public UnresolvableReferenceException()
        {

        }

        public UnresolvableReferenceException(string message)
            : base(message)
        {

        }

        public UnresolvableReferenceException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}