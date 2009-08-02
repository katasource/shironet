using System.Collections.Generic;

namespace Apache.Shiro.Authz
{
    public interface IAuthorizationInfo
    {
        ICollection<IPermission> Permissions
        {
            get;
        }

        ICollection<string> Roles
        {
            get;
        }

        ICollection<string> GetPermissionsAsStrings();
    }
}
