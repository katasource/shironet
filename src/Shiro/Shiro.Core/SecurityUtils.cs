using System;

using Apache.Shiro.Management;
using Apache.Shiro.Subject;
using Apache.Shiro.Util;

namespace Apache.Shiro
{
    public static class SecurityUtils
    {
        #region Public Properties

        public static ISecurityManager SecurityManager{ get; set; }

        #endregion

        #region Public Methods

        public static ISubject GetSubject()
        {
            ISubject subject;

            ISecurityManager securityManager = ThreadContext.SecurityManager;
            if (securityManager == null)
            {
                subject = ThreadContext.Subject;
                if (subject == null && SecurityManager != null)
                {
                    subject = SecurityManager.GetSubject();
                }
            }
            else
            {
                subject = securityManager.GetSubject();
            }

            if (subject == null)
            {
                throw new InvalidOperationException(Properties.Resources.SecurityManagerUnavailableMessage);
            }

            return subject;
        }

        #endregion
    }
}