using System;
using System.Collections.Generic;

using Apache.Shiro.Realm;

namespace Apache.Shiro.Authc.Pam
{
    public interface IAuthenticationStrategy
    {
        IAuthenticationInfo AfterAllAttempts(IAuthenticationToken token,
                                             IAuthenticationInfo aggregate);

        IAuthenticationInfo AfterAttempt(IRealm realm,
                                         IAuthenticationToken token,
                                         IAuthenticationInfo realmInfo,
                                         IAuthenticationInfo aggregate,
                                         Exception error);

        IAuthenticationInfo BeforeAllAttempts(ICollection<IRealm> realms,
                                              IAuthenticationToken token);

        IAuthenticationInfo BeforeAttempt(IRealm realm,
                                          IAuthenticationToken token,
                                          IAuthenticationInfo aggregate);
    }
}
