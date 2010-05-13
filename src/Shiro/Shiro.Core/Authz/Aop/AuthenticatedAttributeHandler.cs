using System;

using Apache.Shiro.Authz.Attributes;

namespace Apache.Shiro.Authz.Aop
{
    public class AuthenticatedAttributeHandler : AuthorizingAttributeHandler
    {
        public AuthenticatedAttributeHandler()
            : base(typeof(RequiresAuthenticationAttribute))
        {
            
        }

        public override void AssertAuthorized(Attribute attribute)
        {
            if (attribute is RequiresAuthenticationAttribute && !GetSubject().Authenticated)
            {
                throw new UnauthenticatedException("The current Subject is not authenticated. Access denied.");
            }
        }
    }
}