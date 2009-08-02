namespace Apache.Shiro.Cache
{
    public interface ICacheManagerAware
    {
        ICacheManager CacheManager
        {
            set;
        }
    }
}
