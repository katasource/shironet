namespace Apache.Shiro.Session.Management
{
    public interface ISessionFactoryAware
    {
        ISessionFactory SessionFactory
        {
            set;
        }
    }
}