namespace Apache.Shiro.Cache
{
    public interface ICacheManager
    {
        ICache GetCache(string cacheName);
    }
}
