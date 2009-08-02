using System.Net;

namespace Apache.Shiro.Session.Management
{
    public interface ISessionFactory
    {
        ISession CreateSession(IPAddress originatingHost);
    }
}