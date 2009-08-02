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

        ICollection<object> AsCollection();

        IList<object> AsList();

        ICollection<T> ByType<T>();

        ICollection<object> FromRealm(string realmName);

        T OneByType<T>();
    }
}
