using System;

namespace Apache.Shiro.Authc
{
    public class SuccessfulLoginEventArgs : LoginEventArgs
    {
        private IAuthenticationInfo _info;

        public SuccessfulLoginEventArgs(IAuthenticationToken token, IAuthenticationInfo info)
            : base(token)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            _info = info;
        }

        public IAuthenticationInfo Info
        {
            get
            {
                return _info;
            }
        }
    }

    public delegate void SuccessfulLoginEventHandler(object sender, SuccessfulLoginEventArgs e);
}
