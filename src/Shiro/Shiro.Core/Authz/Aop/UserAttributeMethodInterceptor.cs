namespace Apache.Shiro.Authz.Aop
{
    public class UserAttributeMethodInterceptor
        : AuthorizingAttributeMethodInterceptor<RequiresUserAttribute>
    {
        public UserAttributeMethodInterceptor()
            : base(new UserAttributeHandler())
        {
            
        }
    }
}