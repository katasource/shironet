using System;
using System.IO;

using Apache.Shiro.Management;

namespace Apache.Shiro.Configuration
{
    [Serializable]
    public abstract class ResourceConfiguration : IConfiguration
    {
        private ISecurityManager _securityManager;

        public ISecurityManager SecurityManager
        {
            get
            {
                return _securityManager;
            }
            protected set
            {
                _securityManager = value;
            }
        }

        public abstract void Load(string path);
        public abstract void Load(Stream stream);
    }
}