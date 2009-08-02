using System;
using System.Net;

namespace Apache.Shiro.Session
{
    public interface ISession
    {
        #region Properties

        ISessionAttributes Attributes
        {
            get;
        }

        IPAddress HostAddress
        {
            get;
        }

        object Id
        {
            get;
        }

        DateTime LastAccessTime
        {
            get;
        }

        DateTime StartTime
        {
            get;
        }

        long Timeout
        {
            get;
            set;
        }

        #endregion

        #region Methods

        void Stop();

        void Touch();

        #endregion
    }
}
