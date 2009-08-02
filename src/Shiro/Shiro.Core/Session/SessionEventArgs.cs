using System;

namespace Apache.Shiro.Session
{
    public class SessionEventArgs : EventArgs
    {
        private readonly ISession _session;

        public SessionEventArgs(ISession session)
        {
            _session = session;
        }

        public ISession Session
        {
            get
            {
                return _session;
            }
        }
    }
}
