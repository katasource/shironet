using System;

using Apache.Shiro.Codec;

namespace Apache.Shiro.Crypto.Hash
{
    public abstract class AbstractHash : IHash
    {
        private string _base64Encoded;
        private byte[] _bytes;
        private string _hexEncoded;

        public AbstractHash(object source, object salt, int hashIterations)
        {
            byte[] sourceBytes = ToBytes(source);
            byte[] saltBytes = null;
            if (salt != null)
            {
                saltBytes = ToBytes(salt);
            }
            _bytes = Hash(sourceBytes, saltBytes, hashIterations);
        }

        public byte[] Bytes
        {
            get
            {
                return _bytes;
            }
            set
            {
                _bytes = value;
                _base64Encoded = null;
                _hexEncoded = null;
            }
        }

        public override bool Equals(object obj)
        {
            IHash hash = obj as IHash;
            if (hash == null)
            {
                return false;
            }

            return Equals(Bytes, hash.Bytes);
        }

        public override int GetHashCode()
        {
            return ToHex().GetHashCode();
        }

        public string ToBase64()
        {
            if (_base64Encoded == null)
            {
                _base64Encoded = Convert.ToBase64String(Bytes);
            }
            return _base64Encoded;
        }

        public string ToHex()
        {
            if (_hexEncoded == null)
            {
                _hexEncoded = Hex.ToHexString(Bytes);
            }
            return _hexEncoded;
        }

        public override string ToString()
        {
            return ToHex();
        }

        protected virtual byte[] Hash(byte[] bytes, byte[] salt, int hashIterations)
        {
            return bytes;
        }

        protected abstract byte[] ToBytes(object source);
    }
}