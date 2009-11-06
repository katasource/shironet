namespace Apache.Shiro.Authz.Aop
{
    public class PermissionsAttributeMethodInterceptor : AuthorizingAttributeMethodInterceptor
    {
        public PermissionsAttributeMethodInterceptor()
            : base(new PermissionAttributeHandler())
        {
            
        }
    }
}