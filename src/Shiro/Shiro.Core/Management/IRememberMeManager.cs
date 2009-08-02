using Apache.Shiro.Subject;

namespace Apache.Shiro.Management
{
    public interface IRememberMeManager
    {
        IPrincipalCollection RememberedPrincipals
        {
            get;
        }
    }
}
