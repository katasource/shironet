using System;
using System.IO;

namespace Apache.Shiro.IO
{
    [Serializable]
    public abstract class AbstractResource
    {
        protected AbstractResource()
        {
            
        }

        protected AbstractResource(Stream stream)
        {
            Load(stream);
        }

        protected AbstractResource(string resourcePath)
        {
            Load(resourcePath);
        }

        public abstract void Load(Stream stream);

        public virtual void Load(string resourcePath)
        {
            if (resourcePath == null)
            {
                throw new ArgumentNullException("resourcePath");
            }

            Load(GetStreamFromResourcePath(resourcePath));
        }

        protected abstract Stream GetStreamFromResourcePath(string resourcePath);
    }
}