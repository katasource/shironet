namespace Apache.Shiro.Authz.Aop
{
    public class PermissionsAttributeMethodInterceptor
        : AuthorizingAttributeMethodInterceptor<RequiresPermissionsAttribute>
    {
        public PermissionsAttributeMethodInterceptor()
            : base(new PermissionAttributeHandler())
        {
            
        }
    }
}