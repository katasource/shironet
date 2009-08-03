namespace Apache.Shiro.Authz.Aop
{
    public class UserAttributeHandler : AuthorizingAttributeHandler<RequiresUserAttribute>
    {
        public override void AssertAuthorized(RequiresUserAttribute attribute)
        {
            if (GetSubject().Principal == null)
            {
                throw new UnauthenticatedException("Attempting to perform a user-only operation. The current Subject is " +
                    "not a user (they haven't been authenticated or remembered from a previous login). Access denied.");
            }
        }
    }
}