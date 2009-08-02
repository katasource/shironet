using System.Net;

namespace Apache.Shiro.Authc
{
    public interface IInetAuthenticationToken : IAuthenticationToken
    {
        IPAddress HostAddress
        {
            get;
        }
    }
}
