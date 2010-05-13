using Apache.Shiro.Authc;
using Apache.Shiro.Authz;
using Apache.Shiro.Session.Management;
using Apache.Shiro.Subject;

namespace Apache.Shiro.Management
{
    public interface ISecurityManager : IAuthenticator, IAuthorizer, ISessionManager
    {
        ISubject CreateSubject(ISubjectContext subjectContext);

        ISubject Login(ISubject subject, IAuthenticationToken token);

        void Logout(ISubject subject);
    }
}
