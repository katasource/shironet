using System.Net;

namespace Apache.Shiro.Session.Management
{
    public class SimpleSessionFactory : ISessionFactory
    {
        public ISession CreateSession(IPAddress originatingHost)
        {
            return new SimpleSession(originatingHost);
        }
    }
}