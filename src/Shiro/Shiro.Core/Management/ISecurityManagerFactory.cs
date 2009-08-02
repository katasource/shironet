namespace Apache.Shiro.Management
{
    public interface ISecurityManagerFactory
    {
        ISecurityManager SecurityManager
        {
            get;
        }
    }
}
