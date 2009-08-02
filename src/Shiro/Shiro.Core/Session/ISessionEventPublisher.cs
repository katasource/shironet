namespace Apache.Shiro.Session
{
    /// <summary>
    /// Defines a component capable of registering <see cref="Apache.Shiro.Session.SessionEventHandler"/>s
    /// that wish to be notified during <see cref="Apache.Shiro.Session.ISession"/> lifecycle events.
    /// </summary>
    /// <author>Bryan Turner</author>
    public interface ISessionEventPublisher
    {
        /// <summary>
        /// Notification event fired to indicate an <see cref="Apache.Shiro.Session.ISession"/> has expired.
        /// </summary>
        event SessionEventHandler Expired;

        /// <summary>
        /// Notification event fired to indicate a new <see cref="Apache.Shiro.Session.ISession"/> has been
        /// started.
        /// </summary>
        event SessionEventHandler Started;

        /// <summary>
        /// Notification event fired to indicate an <see cref="Apache.Shiro.Session.ISession"/> has stopped.
        /// </summary>
        event SessionEventHandler Stopped;
    }

    /// <summary>
    /// Represents the method that will handle an event related to a given
    /// <see cref="Apache.Shiro.Session.ISession"/>.
    /// </summary>
    /// <param name="sender">The source of the event</param>
    /// <param name="e">A <see cref="Apache.Shiro.Session.SessionEventArgs"/> containing ISession data</param>
    public delegate void SessionEventHandler(object sender, SessionEventArgs e);
}
