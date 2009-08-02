using System;
using System.Collections.Generic;
using System.Text;

namespace Apache.Shiro.Authc
{
    public interface IMergeableAuthenticationInfo : IAuthenticationInfo
    {
        void Merge(IAuthenticationInfo other);
    }
}
