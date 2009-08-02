namespace Apache.Shiro.Authc.Credential
{
    public interface ICredentialsMatcher
    {
        bool DoCredentialsMatch(IAuthenticationToken token, IAuthenticationInfo info);
    }
}