using System;
using System.Text;

namespace Apache.Shiro.Codec
{
    public class Hex
    {
        private Hex()
        {
            
        }

        public static byte[] FromHexCharArray(char[] chars)
        {
            return FromHexString(new string(chars));
        }

        public static byte[] FromHexString(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            int length = value.Length;
            if (length % 2 == 1)
            {
                throw new ArgumentException(Properties.Resources.HexCharArrayOddLengthMessage);
            }

            byte[] bytes = new byte[length / 2];
            for (int i = 0, j = 0; j < length; j += 2, ++i)
            {
                bytes[i] = Convert.ToByte(value.Substring(j, 2), 16);
            }

            return bytes;
        }

        public static char[] ToHexCharArray(byte[] bytes)
        {
            return ToHexString(bytes).ToCharArray();
        }

        public static string ToHexString(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            int length = bytes.Length;

            StringBuilder buffer = new StringBuilder(length * 2);
            foreach (byte b in bytes)
            {
                buffer.Append(b.ToString("X2"));
            }

            return buffer.ToString();
        }
    }
}