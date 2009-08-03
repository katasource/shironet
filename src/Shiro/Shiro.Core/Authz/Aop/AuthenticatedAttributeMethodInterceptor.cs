namespace Apache.Shiro.Authz.Aop
{
    public class AuthenticatedAttributeMethodInterceptor
        : AuthorizingAttributeMethodInterceptor<RequiresAuthenticationAttribute>
    {
        public AuthenticatedAttributeMethodInterceptor()
            : base(new AuthenticatedAttributeHandler())
        {
            
        }
    }
}