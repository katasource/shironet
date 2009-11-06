using System;

namespace Apache.Shiro.Authz.Aop
{
    public class PermissionAttributeHandler : AuthorizingAttributeHandler
    {
        public PermissionAttributeHandler()
            : base(typeof(RequiresPermissionsAttribute))
        {
            
        }

        public override void AssertAuthorized(Attribute attribute)
        {
            if (attribute is RequiresPermissionsAttribute)
            {
                AssertAuthorized(attribute as RequiresPermissionsAttribute);
            }
        }

        private void AssertAuthorized(RequiresPermissionsAttribute attribute)
        {
            var permissions = attribute.Permissions;
            if (permissions == null || permissions.Length == 0)
            {
                return;
            }

            var subject = GetSubject();
            if (permissions.Length == 1)
            {
                var permission = permissions[0];
                if (!subject.IsPermitted(permission))
                {
                    throw new UnauthorizedException(
                        string.Format("Calling Subject does not have required permission [{0}]. Access denied", permission));
                }
            }
            else if (!subject.IsPermittedAll(permissions))
            {
                throw new UnauthorizedException(
                    string.Format("Calling Subject does not have all required permissions [{0}]. Access denied", permissions));
            }
        }
    }
}