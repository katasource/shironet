namespace Apache.Shiro.Authz.Permission
{
    public interface IPermissionResolver
    {
        IPermission ResolvePermission(string permissionId);
    }
}