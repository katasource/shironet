namespace Apache.Shiro.Session.Management
{
    public interface IValidatingSession : ISession
    {
        bool IsValid
        {
            get;
        }

        void Validate();
    }
}
