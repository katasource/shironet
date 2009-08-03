namespace Apache.Shiro.Authz.Aop
{
    public class GuestAttributeMethodInterceptor
        : AuthorizingAttributeMethodInterceptor<RequiresGuestAttribute>
    {
        public GuestAttributeMethodInterceptor()
            : base(new GuestAttributeHandler())
        {
            
        }
    }
}