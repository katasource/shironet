using System.Collections.Generic;

using Apache.Shiro.Authc;
using Apache.Shiro.Management;
using Apache.Shiro.Session;

namespace Apache.Shiro.Subject
{
    public interface ISubjectContext : IDictionary<string, object>
    {
        bool Authenticated
        {
            get;
            set;
        }

        IAuthenticationInfo AuthenticationInfo
        {
            get;
            set;
        }

        IAuthenticationToken AuthenticationToken
        {
            get;
            set;
        }

        string Host
        {
            get;
            set;
        }

        IPrincipalCollection Principals
        {
            get;
            set;
        }

        ISecurityManager SecurityManager
        {
            get;
            set;
        }

        ISession Session
        {
            get;
            set;
        }

        object SessionId
        {
            get;
            set;
        }

        ISubject Subject
        {
            get;
            set;
        }

        bool ResolveAuthenticated();

        string ResolveHost();

        IPrincipalCollection ResolvePrincipals();

        ISecurityManager ResolveSecurityManager();

        ISession ResolveSession();
    }
}