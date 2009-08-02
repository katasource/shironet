using System.Collections.Generic;

namespace Apache.Shiro.Subject
{
    public interface IPrincipalCollection : IEnumerable<object>
    {
        int Count
        {
            get;
        }

        ICollection<string> RealmNames
        {
            get;
        }

        IList<object> AsList();

        HashSet<object> AsSet();

        ICollection<object> FromRealm(string realmName);

        T OneByType<T>();

        ICollection<T> ByType<T>();
    }
}
