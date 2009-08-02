using System.Collections.Generic;

namespace Apache.Shiro.Session.Management
{
    public interface ISessionFactory
    {
        ISession CreateSession(IDictionary<object, object> data);
    }
}