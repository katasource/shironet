namespace Apache.Shiro.Session.Management.Enterprise
{
    public interface ISessionDaoAware
    {
        ISessionDao SessionDao
        {
            set;
        }
    }
}