namespace Apache.Shiro.IO
{
    public interface ISerializer
    {
        object Deserialize(byte[] bytes);
        byte[] Serialize(object o);
    }
}
