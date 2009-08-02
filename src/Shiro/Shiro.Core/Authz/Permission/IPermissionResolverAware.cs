namespace Apache.Shiro.Authz.Permission
{
    public interface IPermissionResolverAware
    {
        IPermissionResolver PermissionResolver
        {
            set;
        }
    }
}