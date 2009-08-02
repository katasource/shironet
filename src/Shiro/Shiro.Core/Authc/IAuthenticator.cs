using System;
using System.Collections.Generic;
using System.Text;

namespace Apache.Shiro.Authc
{
    public interface IAuthenticator
    {
        IAuthenticationInfo Authenticate(IAuthenticationToken token);
    }
}
