using Apache.Shiro.Authc;
using Apache.Shiro.Authz;

namespace Apache.Shiro.Realm
{
    public interface IRealm : IAuthorizer
    {
        string Name
        {
            get;
        }

        IAuthenticationInfo GetAuthenticationInfo(IAuthenticationToken token);

        bool IsSupported(IAuthenticationToken token);
    }
}
