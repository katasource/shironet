namespace Apache.Shiro.Authz.Aop
{
    public class AuthenticatedAttributeHandler : AuthorizingAttributeHandler<RequiresAuthenticationAttribute>
    {
        public override void AssertAuthorized(RequiresAuthenticationAttribute attribute)
        {
            if (!GetSubject().Authenticated)
            {
                throw new UnauthenticatedException("The current Subject is not authenticated. Access denied.");
            }
        }
    }
}