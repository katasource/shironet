using System.Net;

using Apache.Shiro.Authc;
using Apache.Shiro.Session;
using Apache.Shiro.Subject;

namespace Apache.Shiro.Management
{
    public interface ISubjectFactory
    {
        ISubject CreateSubject(IAuthenticationToken token, IAuthenticationInfo info, ISubject existing);

        ISubject CreateSubject(IPrincipalCollection principals, ISession existing,
            bool isAuthenticated, IPAddress originatingHost);
    }
}
