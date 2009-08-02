using System.Collections.Generic;

using Apache.Shiro.Authc;
using Apache.Shiro.Authz;
using Apache.Shiro.Session;

namespace Apache.Shiro.Subject
{
    public interface ISubject
    {
        #region Properties

        bool Authenticated
        {
            get;
        }

        object Principal
        {
            get;
        }

        IPrincipalCollection Principals
        {
            get;
        }

        #endregion

        #region Methods

        void CheckPermission(IPermission permission);

        void CheckPermissions(ICollection<IPermission> permissions);

        void CheckPermission(string permission);

        void CheckPermissions(params string[] permissions);

        void CheckRole(string roleId);

        void CheckRoles(ICollection<string> roleIds);

        ISession GetSession();

        ISession GetSession(bool create);

        bool HasAllRoles(ICollection<string> roleIds);

        bool HasRole(string roleId);

        bool[] HasRoles(ICollection<string> roleIds);

        bool IsPermitted(IPermission permission);

        bool[] IsPermitted(ICollection<IPermission> permissions);

        bool IsPermitted(string permission);

        bool[] IsPermitted(params string[] permissions);

        bool IsPermittedAll(ICollection<IPermission> permissions);

        bool IsPermittedAll(params string[] permissions);

        void Login(IAuthenticationToken token);

        void Logout();

        #endregion
    }
}
