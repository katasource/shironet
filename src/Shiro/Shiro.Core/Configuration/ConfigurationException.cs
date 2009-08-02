using System;
using Apache.Shiro;

namespace Apache.Shiro.Configuration
{
    public class ConfigurationException : ShiroException
    {
        public ConfigurationException()
        {

        }

        public ConfigurationException(string message)
            : base(message)
        {

        }

        public ConfigurationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}