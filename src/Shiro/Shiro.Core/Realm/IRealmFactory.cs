using System.Collections.Generic;

namespace Apache.Shiro.Realm
{
    public interface IRealmFactory
    {
        ICollection<IRealm> GetRealms();
    }
}
