using Apache.Shiro.Management;
using Apache.Shiro.Subject;
using Apache.Shiro.Util;

namespace Apache.Shiro
{
    public static class SecurityUtils
    {
        #region Private Static Fields

        private static ISecurityManager _securityManager;

        #endregion

        #region Public Properties

        public static ISecurityManager SecurityManager
        {
            //TODO: Why check ThreadContext first?
            get
            {
                var securityManager = ThreadContext.SecurityManager ?? _securityManager;
                if (securityManager == null)
                {
                    throw new UnavailableSecurityManagerException(
                        Properties.Resources.SecurityManagerUnavailableMessage);
                }
                return securityManager;
            }
            set
            {
                _securityManager = value;
            }
        }

        #endregion

        #region Public Methods

        public static ISubject GetSubject()
        {
            var subject = ThreadContext.Subject;
            if (subject == null)
            {
                subject = new SubjectBuilder().BuildSubject();
                ThreadContext.Subject = subject;
            }
            return subject;
        }

        #endregion
    }
}