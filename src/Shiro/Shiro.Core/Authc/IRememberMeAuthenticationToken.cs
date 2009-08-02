using System;
using System.Collections.Generic;
using System.Text;

namespace Apache.Shiro.Authc
{
    public interface IRememberMeAuthenticationToken : IAuthenticationToken
    {
        bool RememberMe
        {
            get;
        }
    }
}
