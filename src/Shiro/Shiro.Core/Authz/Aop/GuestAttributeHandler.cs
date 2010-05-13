using System;

using Apache.Shiro.Authz.Attributes;

namespace Apache.Shiro.Authz.Aop
{
    public class GuestAttributeHandler : AuthorizingAttributeHandler
    {
        public GuestAttributeHandler()
            : base(typeof(RequiresGuestAttribute))
        {
            
        }

        public override void AssertAuthorized(Attribute attribute)
        {
            if (attribute is RequiresGuestAttribute && GetSubject().Principal != null)
            {
                throw new UnauthenticatedException("Attempting to perform a guest-only operation. The current Subject is " +
                    "not a guest (they have been authenticated or remembered from a previous login). Access denied.");
            }
        }
    }
}