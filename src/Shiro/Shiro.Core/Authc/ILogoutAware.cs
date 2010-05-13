using Apache.Shiro.Subject;

namespace Apache.Shiro.Authc
{
    public interface ILogoutAware
    {
        void OnLogout(IPrincipalCollection principals);
    }
}