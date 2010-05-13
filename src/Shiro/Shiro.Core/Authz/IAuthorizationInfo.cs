using System.Collections.Generic;

namespace Apache.Shiro.Authz
{
    public interface IAuthorizationInfo
    {
        ICollection<IPermission> ObjectPermissions
        {
            get;
        }

        ICollection<string> Roles
        {
            get;
        }

        ICollection<string> StringPermissions
        {
            get;
        }
    }
}
