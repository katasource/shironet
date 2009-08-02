using Apache.Shiro;

namespace Apache.Shiro.Authz.Permission
{
    public class UnresolvablePermissionException : ShiroException
    {
        private readonly string _permissionId;

        public UnresolvablePermissionException(string message, string permissionId)
            : base(message)
        {
            _permissionId = permissionId;
        }

        public string PermissionId
        {
            get
            {
                return _permissionId;
            }
        }
    }
}
