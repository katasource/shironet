using System.Collections.Generic;

namespace Apache.Shiro.Subject
{
    public interface IMutablePrincipalCollection : IPrincipalCollection
    {
        #region Methods

        void Add(object principal, string realmName);

        void AddAll(ICollection<object> principals, string realmName);

        void AddAll(IPrincipalCollection principals);

        void Clear();

        #endregion
    }
}
