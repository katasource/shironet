using System;
using System.Collections.Generic;
using System.Net;

namespace Apache.Shiro.Session.Management
{
    public class SimpleSessionFactory : ISessionFactory
    {
        public ISession CreateSession(IPAddress originatingHost)
        {
            return new SimpleSession(originatingHost);
        }

        public ISession CreateSession(IDictionary<object, object> data)
        {
            if (data != null && data.ContainsKey(SessionFactoryKey.OriginatingHost))
            {
                return CreateSession((IPAddress) data[SessionFactoryKey.OriginatingHost]);
            }
            return new SimpleSession();
        }
    }
}