using System;
using System.Collections.Generic;
using System.Net;

namespace Apache.Shiro.Session.Management
{
    public interface ISessionManager
    {
        void CheckValidity(object sessionId);

        object GetAttribute(object sessionId, object key);

        ICollection<object> GetAttributeKeys(object sessionId);

        string GetHost(object sessionId);

        DateTime GetLastAccessTime(object sessionId);

        DateTime GetStartTime(object sessionId);

        long GetTimeout(object sessionId);

        bool IsValid(object sessionId);

        object RemoveAttribute(object sessionId, object key);

        void SetAttribute(object sessionId, object key, object value);

        void SetTimeout(object sessionId, long timeout);

        object Start(string host);

        object Start(IDictionary<object, object> data);

        void Stop(object sessionId);

        void Touch(object sessionId);
    }
}
