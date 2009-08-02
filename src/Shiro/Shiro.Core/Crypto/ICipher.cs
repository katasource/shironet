namespace Apache.Shiro.Crypto
{
    public interface ICipher
    {
        byte[] Decrypt(byte[] encrypted, byte[] key);
        byte[] Encrypt(byte[] raw, byte[] key);
    }
}
