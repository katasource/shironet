using Apache.Shiro.Subject;

namespace Apache.Shiro.Management
{
    public interface ISubjectBinder
    {
        ISubject Subject
        {
            get;
        }

        void Bind(ISubject subject);
        void Unbind(ISubject subject);
    }
}
