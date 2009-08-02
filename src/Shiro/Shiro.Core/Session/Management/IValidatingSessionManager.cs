namespace Apache.Shiro.Session.Management
{
    public interface IValidatingSessionManager : ISessionManager
    {
        void Validate(object sessionId);

        void ValidateAll();
    }
}
