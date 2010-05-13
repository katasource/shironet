using System;
using System.Collections.Generic;
using System.Net;

namespace Apache.Shiro.Session
{
    public interface ISession
    {
        #region Properties

        ICollection<object> AttributeKeys
        {
            get;
        }

        string Host
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

        object GetAttribute(object key);

        object RemoveAttribute(object key);

        void SetAttribute(object key, object value);

        void Stop();

        void Touch();

        #endregion
    }
}
