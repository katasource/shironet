using Apache.Shiro.Subject;

namespace Apache.Shiro.Authz.Aop
{
    public class RolesAttributeHandler : AuthorizingAttributeHandler<RequiresRolesAttribute>
    {
        public override void AssertAuthorized(RequiresRolesAttribute attribute)
        {
            string[] roleIds = attribute.Roles;
            if (roleIds == null || roleIds.Length == 0)
            {
                return;
            }

            ISubject subject = GetSubject();
            if (roleIds.Length == 1)
            {
                string roleId = roleIds[0];
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