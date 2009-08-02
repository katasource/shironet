using System;

namespace Apache.Shiro.Authz
{
    public class UnauthenticatedException : AuthorizationException
    {
        public UnauthenticatedException()
        {

        }

        public UnauthenticatedException(string message)
            : base(message)
        {

        }

        public UnauthenticatedException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}