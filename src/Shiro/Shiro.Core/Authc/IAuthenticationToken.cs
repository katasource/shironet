namespace Apache.Shiro.Authc
{
    public interface IAuthenticationToken
    {
        object Credentials
        {
            get;
        }

        object Principal
        {
            get;
        }
    }
}
