using System;

using Apache.Shiro.Subject;

namespace Apache.Shiro.Authc
{
    public class LogoutEventArgs : AuthenticationEventArgs
    {
        private readonly IPrincipalCollection _principals;

        public LogoutEventArgs(IPrincipalCollection principals)
        {
            if (principals == null)
            {
                throw new ArgumentNullException("principals");
            }
            _principals = principals;
        }

        public IPrincipalCollection Principals
        {
            get
            {
                return _principals;
            }
        }
    }
}
