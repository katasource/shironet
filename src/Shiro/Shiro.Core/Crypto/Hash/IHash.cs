namespace Apache.Shiro.Crypto.Hash
{
    public interface IHash
    {
        byte[] Bytes
        {
            get;
        }

        string ToBase64();
        string ToHex();
    }
}