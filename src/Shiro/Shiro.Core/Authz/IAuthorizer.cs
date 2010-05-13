using System.Collections.Generic;

using Apache.Shiro.Subject;

namespace Apache.Shiro.Authz
{
    public interface IAuthorizer
    {
        void CheckPermission(IPrincipalCollection principals, IPermission permission);

        void CheckPermission(IPrincipalCollection principals, string permission);

        void CheckPermissions(IPrincipalCollection principals, IEnumerable<IPermission> permissions);

        void CheckPermissions(IPrincipalCollection principals, params string[] permissions);

        void CheckRole(IPrincipalCollection principals, string roleId);

        void CheckRoles(IPrincipalCollection principals, IEnumerable<string> roleIds);

        bool HasAllRoles(IPrincipalCollection principals, IEnumerable<string> roleIds);

        bool HasRole(IPrincipalCollection principals, string roleId);

        bool[] HasRoles(IPrincipalCollection principals, IEnumerable<string> roleIds);

        bool IsPermitted(IPrincipalCollection principals, IPermission permission);

        bool[] IsPermitted(IPrincipalCollection principals, IEnumerable<IPermission> permissions);

        bool IsPermitted(IPrincipalCollection principals, string permission);

        bool[] IsPermitted(IPrincipalCollection principals, params string[] permissions);

        bool IsPermittedAll(IPrincipalCollection principals, IEnumerable<IPermission> permission);

        bool IsPermittedAll(IPrincipalCollection principals, params string[] permissions);
    }
}
