using System;

namespace Apache.Shiro.Authz.Aop
{
    public class RolesAttributeHandler : AuthorizingAttributeHandler
    {
        public RolesAttributeHandler()
            : base(typeof(RequiresRolesAttribute))
        {
            
        }

        public override void AssertAuthorized(Attribute attribute)
        {
            if (attribute is RequiresRolesAttribute)
            {
                AssertAuthorized(attribute as RequiresRolesAttribute);
            }
        }

        private void AssertAuthorized(RequiresRolesAttribute attribute)
        {
            var roleIds = attribute.Roles;
            if (roleIds == null || roleIds.Length == 0)
            {
                return;
            }

            var subject = GetSubject();
            if (roleIds.Length == 1)
            {
                var roleId = roleIds[0];
                if (!subject.HasRole(roleId))
                {
                    throw new UnauthorizedException(
                        string.Format("Calling Subject does not have required role [{0}]. Access denied.", roleId));
                }
            }
            else if (!subject.HasAllRoles(roleIds))
            {
                throw new UnauthorizedException(
                    string.Format("Calling subject does not have all required roles [{0}]. Access denied.", roleIds));
            }
        }
    }
}