namespace Apache.Shiro.Session.Management
{
    /// <summary>
    /// Interface that should be implemented by classes that can control validating sessions on a regular
    /// basis.
    /// </summary>
    public interface ISessionValidationScheduler
    {
        bool IsEnabled
        {
            get;
        }

        void DisableSessionValidation();

        void EnableSessionValidation();
    }
}
