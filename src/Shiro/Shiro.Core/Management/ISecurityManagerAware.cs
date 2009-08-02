namespace Apache.Shiro.Management
{
    public interface ISecurityManagerAware
    {
        ISecurityManager SecurityManager
        {
            set;
        }
    }
}
