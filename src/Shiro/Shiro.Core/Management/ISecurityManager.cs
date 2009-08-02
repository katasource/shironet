using Apache.Shiro.Authc;
using Apache.Shiro.Authz;
using Apache.Shiro.Session.Management;
using Apache.Shiro.Subject;

namespace Apache.Shiro.Management
{
    public interface ISecurityManager : IAuthenticator, IAuthorizer, ISessionManager
    {
        ISubject GetSubject();

        ISubject Login(IAuthenticationToken token);

        void Logout(IPrincipalCollection principals);
    }
}
