using System;

using Apache.Shiro.Authz.Attributes;

namespace Apache.Shiro.Authz.Aop
{
    public class UserAttributeHandler : AuthorizingAttributeHandler
    {
        public UserAttributeHandler()
            : base(typeof(RequiresUserAttribute))
        {
            
        }

        public override void AssertAuthorized(Attribute attribute)
        {
            if (attribute is RequiresUserAttribute && GetSubject().Principal == null)
            {
                throw new UnauthenticatedException("Attempting to perform a user-only operation. The current Subject is " +
                    "not a user (they haven't been authenticated or remembered from a previous login). Access denied.");
            }
        }
    }
}