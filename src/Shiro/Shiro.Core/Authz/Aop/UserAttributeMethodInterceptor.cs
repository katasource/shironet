namespace Apache.Shiro.Authz.Aop
{
    public class UserAttributeMethodInterceptor : AuthorizingAttributeMethodInterceptor
    {
        public UserAttributeMethodInterceptor()
            : base(new UserAttributeHandler())
        {
            
        }
    }
}