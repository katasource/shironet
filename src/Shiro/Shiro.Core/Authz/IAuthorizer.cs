using System.Collections.Generic;

using Apache.Shiro.Subject;

namespace Apache.Shiro.Authz
{
    public interface IAuthorizer
    {
        void CheckPermission(IPrincipalCollection principals, IPermission permission);

        void CheckPermission(IPrincipalCollection principals, string permission);

        void CheckPermissions(IPrincipalCollection principals, ICollection<IPermission> permissions);

        void CheckPermissions(IPrincipalCollection principals, params string[] permissions);

        void CheckRole(IPrincipalCollection principals, string roleId);

        void CheckRoles(IPrincipalCollection principals, ICollection<string> roleIds);

        bool HasAllRoles(IPrincipalCollection principals, ICollection<string> roleIds);

        bool HasRole(IPrincipalCollection principals, string roleId);

        bool[] HasRoles(IPrincipalCollection principals, ICollection<string> roleIds);

        bool IsPermitted(IPrincipalCollection principals, IPermission permission);

        bool[] IsPermitted(IPrincipalCollection principals, ICollection<IPermission> permissions);

        bool IsPermitted(IPrincipalCollection principals, string permission);

        bool[] IsPermitted(IPrincipalCollection principals, params string[] permissions);

        bool IsPermittedAll(IPrincipalCollection principals, ICollection<IPermission> permission);

        bool IsPermittedAll(IPrincipalCollection principals, params string[] permissions);
    }
}
