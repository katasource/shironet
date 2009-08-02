using System.IO;

namespace Apache.Shiro.IO
{
    public abstract class TextResource : AbstractResource
    {
        protected TextResource()
        {

        }

        protected TextResource(Stream stream)
            : base(stream)
        {

        }

        protected TextResource(string resourcePath)
            : base(resourcePath)
        {

        }

        protected TextResource(TextReader reader)
        {
            Load(reader);
        }

        public virtual void Load(TextReader reader)
        {
            
        }
    }
}