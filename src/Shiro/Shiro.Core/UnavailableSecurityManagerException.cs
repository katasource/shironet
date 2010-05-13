using System;

namespace Apache.Shiro
{
    public class UnavailableSecurityManagerException : ShiroException
    {
        public UnavailableSecurityManagerException(string message)
            : base(message)
        {

        }

        public UnavailableSecurityManagerException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}