namespace Apache.Shiro.Authz.Aop
{
    public class AuthenticatedAttributeMethodInterceptor : AuthorizingAttributeMethodInterceptor
    {
        public AuthenticatedAttributeMethodInterceptor()
            : base(new AuthenticatedAttributeHandler())
        {
            
        }
    }
}