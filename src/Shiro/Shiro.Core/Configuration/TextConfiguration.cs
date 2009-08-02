using System;
using System.IO;

using Apache.Shiro.IO;
using Apache.Shiro.Util;

namespace Apache.Shiro.Configuration
{
    public abstract class TextConfiguration : ResourceConfiguration, IInitializable
    {
        private string _configuration;

        public string Configuration
        {
            get
            {
                return _configuration;
            }
            set
            {
                _configuration = value;
            }
        }

        public void Init()
        {
            var securityManager = SecurityManager;
            if (securityManager != null)
            {
                return;
            }

            var configuration = Configuration;
            if (configuration != null)
            {
                LoadTextConfiguration(configuration);
            }
        }

        protected abstract void Load(TextReader reader);

        protected void LoadTextConfiguration(string configuration)
        {
            try
            {
                Load(new StringReader(configuration));
            }
            catch (Exception e)
            {
                throw new ResourceException("", e);
            }
        }
    }
}