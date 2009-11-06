namespace Apache.Shiro.Authz.Aop
{
    public class GuestAttributeMethodInterceptor : AuthorizingAttributeMethodInterceptor
    {
        public GuestAttributeMethodInterceptor()
            : base(new GuestAttributeHandler())
        {
            
        }
    }
}