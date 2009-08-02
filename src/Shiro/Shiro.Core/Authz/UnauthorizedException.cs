using System;

namespace Apache.Shiro.Authz
{
    public class UnauthorizedException : AuthorizationException
    {
        public UnauthorizedException()
        {

        }

        public UnauthorizedException(string message)
            : base(message)
        {
            
        }

        public UnauthorizedException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}