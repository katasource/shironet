namespace Apache.Shiro.Authz.Aop
{
    public class GuestAttributeHandler : AuthorizingAttributeHandler<RequiresGuestAttribute>
    {
        public override void AssertAuthorized(RequiresGuestAttribute attribute)
        {
            if (GetSubject().Principal != null)
            {
                throw new UnauthenticatedException("Attempting to perform a guest-only operation. The current Subject is " +
                    "not a guest (they have been authenticated or remembered from a previous login). Access denied.");
            }
        }
    }
}