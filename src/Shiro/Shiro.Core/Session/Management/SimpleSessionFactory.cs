using System.Collections.Generic;

namespace Apache.Shiro.Session.Management
{
    public class SimpleSessionFactory : ISessionFactory
    {
        public ISession CreateSession(string host)
        {
            return new SimpleSession(host);
        }

        public ISession CreateSession(IDictionary<object, object> data)
        {
            if (data != null && data.ContainsKey(SessionFactoryKey.Host))
            {
                return CreateSession((string) data[SessionFactoryKey.Host]);
            }
            return new SimpleSession();
        }
    }
}