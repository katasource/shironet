namespace Apache.Shiro.Session.Management.Eis
{
    public interface ISessionDaoAware
    {
        ISessionDao SessionDao
        {
            set;
        }
    }
}