namespace Apache.Shiro.Authz.Aop
{
    public class RolesAttributeMethodInterceptor : AuthorizingAttributeMethodInterceptor<RequiresRolesAttribute>
    {
        public RolesAttributeMethodInterceptor()
            : base(new RolesAttributeHandler())
        {
            
        }
    }
}