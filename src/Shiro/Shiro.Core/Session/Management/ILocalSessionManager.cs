namespace Apache.Shiro.Session.Management
{
    /// <summary>
    /// A <see cref="Apache.Shiro.Session.Management.ISessionManager"/> that is available in a local CLR only.
    /// It is not intended to be accessible in remoting scenarios.
    /// </summary>
    /// <author>Les Hazlewood</author>
    /// <author>Bryan Turner (.NET)</author>
    public interface ILocalSessionManager : ISessionManager
    {
        /// <summary>
        /// Returns the currently-accessible <see cref="Apache.Shiro.Session.ISession"/> based on the runtime
        /// environment. This is mostly returned from a <code>LocalDataStoreSlot</code>. static memory, or
        /// based on a thread-bound request/response pair in a web environment.
        /// </summary>
        /// <returns>the currently-accessible <see cref="Apache.Shiro.Session.ISession"/></returns>
        ISession GetCurrentSession();
    }
}
