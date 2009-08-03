using Apache.Shiro.Management;
using Apache.Shiro.Subject;
using Apache.Shiro.Util;

namespace Apache.Shiro
{
    public static class SecurityUtils
    {
        private static ISecurityManager _securityManager;

        public static ISubject GetSubject()
        {
            ISubject subject;

            ISecurityManager securityManager = ThreadContext.SecurityManager;
            if (securityManager == null)
            {
                subject = ThreadContext.Subject;
                if (subject == null && _securityManager != null)
                {
                    subject = _securityManager.GetSubject();
                }
            }
            else
            {
                subject = securityManager.GetSubject();
            }

            if (subject == null)
            {
                
            }

            return subject;
        }
    }
}