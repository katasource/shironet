using Apache.Shiro.Subject;

namespace Apache.Shiro.Authc
{
    public interface IAuthenticationInfo
    {
        object Credentials
        {
            get;
        }

        IPrincipalCollection Principals
        {
            get;
        }
    }
}
