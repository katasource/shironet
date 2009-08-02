using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Apache.Shiro.IO
{
    public class DefaultSerializer : ISerializer
    {
        #region ISerializer Members

        public object Deserialize(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            if (bytes.Length == 0)
            {
                throw new ArgumentException("The provided byte array cannot be deserialized; it contains no data");
            }

            using (var stream = new MemoryStream(bytes))
            {
                var formatter = new BinaryFormatter();

                return formatter.Deserialize(stream);
            }
        }

        public byte[] Serialize(object o)
        {
            if (o == null)
            {
                throw new ArgumentNullException("o");
            }

            var type = o.GetType();
            if (!type.IsDefined(typeof(SerializableAttribute), true))
            {
                throw new ArgumentException(
                    string.Format("The provided object cannot be serialized; [{0}] is not serializable", type));
            }

            using (var stream = new MemoryStream())
            {
                var buffer = new BufferedStream(stream);
                var formatter = new BinaryFormatter();

                formatter.Serialize(buffer, o);
                buffer.Flush();

                return stream.GetBuffer();
            }
        }

        #endregion
    }
}