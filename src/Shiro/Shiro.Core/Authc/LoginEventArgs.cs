using System;
using System.Collections.Generic;
using System.Text;

namespace Apache.Shiro.Authc
{
    public class LoginEventArgs : AuthenticationEventArgs
    {
        private readonly IAuthenticationToken _token;

        public LoginEventArgs(IAuthenticationToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }
            _token = token;
        }

        public IAuthenticationToken AuthenticationToken
        {
            get
            {
                return _token;
            }
        }
    }
}
