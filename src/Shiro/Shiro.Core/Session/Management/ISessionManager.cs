using System;
using System.Net;

namespace Apache.Shiro.Session.Management
{
    public interface ISessionManager
    {
        void CheckValidity(object sessionId);

        ISessionAttributes GetAttributes(object sessionId);

        IPAddress GetHostAddress(object sessionId);

        DateTime GetLastAccessTime(object sessionId);

        DateTime GetStartTime(object sessionId);

        long GetTimeout(object sessionId);

        bool IsValid(object sessionId);

        void SetTimeout(object sessionId, long timeout);

        object Start(IPAddress originatingHost);

        void Stop(object sessionId);

        void Touch(object sessionId);
    }
}
