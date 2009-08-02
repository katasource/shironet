using System;
using System.Net;

namespace Apache.Shiro.Authz
{
    public class HostUnauthorizedException : UnauthorizedException
    {
        private readonly IPAddress _hostAddress;

        public HostUnauthorizedException()
        {

        }

        public HostUnauthorizedException(IPAddress hostAddress)
        {
            _hostAddress = hostAddress;
        }

        public HostUnauthorizedException(string message)
            : base(message)
        {

        }

        public HostUnauthorizedException(string message, IPAddress hostAddress)
            : base(message)
        {
            _hostAddress = hostAddress;
        }

        public HostUnauthorizedException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public HostUnauthorizedException(string message,
                                         Exception innerException,
                                         IPAddress hostAddress)
            : base(message, innerException)
        {
            _hostAddress = hostAddress;
        }

        public IPAddress HostAddress
        {
            get
            {
                return _hostAddress;
            }
        }
    }
}
