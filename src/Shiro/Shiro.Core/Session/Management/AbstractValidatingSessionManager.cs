using System;

namespace Apache.Shiro.Session.Management
{
    public abstract class AbstractValidatingSessionManager : AbstractSessionManager,
                                                             IDisposable,
                                                             IValidatingSessionManager
    {
        #region Public Fields

        public static readonly long DefaultSessionValidationInterval;

        #endregion

        #region Protected Fields

        protected long _sessionValidationInterval;

        #endregion

        static AbstractValidatingSessionManager()
        {
            DefaultSessionValidationInterval = (long)TimeSpan.FromHours(1).TotalMilliseconds;
        }

        protected AbstractValidatingSessionManager()
        {
            AutoCreateWhenInvalid = true;
            _sessionValidationInterval = DefaultSessionValidationInterval;
            SessionValidationSchedulerEnabled = true;
        }

        #region IDisposable Members

        public void Dispose()
        {
            DisableSessionValidation();
        }

        #endregion

        #region IValidatingSessionManager Members

        public void Validate(object sessionId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void ValidateAll()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Public Properties

        public bool AutoCreateWhenInvalid { get; set; }

        public ISessionValidationScheduler SessionValidationScheduler { get; set; }

        public bool SessionValidationSchedulerEnabled { get; set; }

        #endregion

        #region Protected Methods

        protected virtual void EnableSessionValidation()
        {

        }

        #endregion

        #region Private Methods

        private void DisableSessionValidation()
        {

        }

        private void EnableSessionValidationIfNecessary()
        {
            if (SessionValidationSchedulerEnabled &&
                (SessionValidationScheduler == null || !SessionValidationScheduler.IsEnabled))
            {
                EnableSessionValidation();
            }
        }

        #endregion
    }
}
