namespace Apache.Shiro.Authz.Aop
{
    public class RolesAttributeMethodInterceptor : AuthorizingAttributeMethodInterceptor
    {
        public RolesAttributeMethodInterceptor()
            : base(new RolesAttributeHandler())
        {
            
        }
    }
}