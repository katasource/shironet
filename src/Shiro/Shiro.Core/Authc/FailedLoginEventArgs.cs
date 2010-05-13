using System;

namespace Apache.Shiro.Authc
{
    public class FailedLoginEventArgs : LoginEventArgs
    {
        private readonly AuthenticationException _exception;

        public FailedLoginEventArgs(IAuthenticationToken token, AuthenticationException exception)
            : base(token)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }
            _exception = exception;
        }

        public AuthenticationException Exception
        {
            get
            {
                return _exception;
            }
        }
    }

    public delegate void FailedLoginEventHandler(object source, FailedLoginEventArgs e);
}
