namespace Apache.Shiro.Authc
{
    public interface IAuthenticationEventPublisher
    {
        event LogoutEventHandler LoggedOut;
        event FailedLoginEventHandler LoginFailed;
        event SuccessfulLoginEventHandler LoginSuccessful;
    }

    public delegate void FailedLoginEventHandler(object source, FailedLoginEventArgs e);
    public delegate void LogoutEventHandler(object source, LogoutEventArgs e);
    public delegate void SuccessfulLoginEventHandler(object source, SuccessfulLoginEventArgs e);
}
