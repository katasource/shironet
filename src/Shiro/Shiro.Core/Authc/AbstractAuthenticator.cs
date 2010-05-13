using System;

using Common.Logging;

using Apache.Shiro.Subject;

namespace Apache.Shiro.Authc
{
    public abstract class AbstractAuthenticator : IAuthenticator, ILogoutAware
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public event LogoutEventHandler LoggedOut;
        public event FailedLoginEventHandler LoginFailed;
        public event SuccessfulLoginEventHandler LoginSuccessful;

        public IAuthenticationInfo Authenticate(IAuthenticationToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }

            Log.TraceFormat("Authentication attempt received for token [{0}]", token);
            try
            {
                IAuthenticationInfo info = DoAuthenticate(token);
                if (info == null)
                {
                    throw new AuthenticationException(
                        string.Format(Properties.Resources.NoAccountInformationForTokenMessage, token));
                }

                Log.DebugFormat("Authentication successful for token [{0}]. Returned account [{1}]", token, info);
                NotifySuccess(token, info);

                return info;
            }
            catch (Exception e)
            {
                AuthenticationException ae = null;
                if (e is AuthenticationException)
                {
                    ae = (AuthenticationException) e;
                }
                if (ae == null)
                {
                    ae = new AuthenticationException(
                        string.Format(Properties.Resources.AuthenticationFailedForTokenMessage, token));
                }
                NotifyFailure(token, ae);

                throw ae;
            }
        }

        public void OnLogout(IPrincipalCollection principals)
        {
            NotifyLogout(principals);
        }

        protected abstract IAuthenticationInfo DoAuthenticate(IAuthenticationToken token);

        protected void NotifyFailure(IAuthenticationToken token, AuthenticationException exception)
        {
            if (LoginFailed != null)
            {
                LoginFailed(this, new FailedLoginEventArgs(token, exception));
            }
        }

        protected void NotifyLogout(IPrincipalCollection principals)
        {
            if (LoggedOut != null)
            {
                LoggedOut(this, new LogoutEventArgs(principals));
            }
        }

        protected void NotifySuccess(IAuthenticationToken token, IAuthenticationInfo info)
        {
            if (LoginSuccessful != null)
            {
                LoginSuccessful(this, new SuccessfulLoginEventArgs(token, info));
            }
        }
    }
}