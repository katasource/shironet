using System;
using System.Net;

namespace Apache.Shiro.Session
{
    public class ProxiedSession : ISession
    {
        private readonly ISession _delegate;

        public ProxiedSession(ISession target)
        {
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            _delegate = target;
        }

        #region ISession Members

        public virtual ISessionAttributes Attributes
        {
            get
            {
                return _delegate.Attributes;
            }
        }

        public virtual IPAddress HostAddress
        {
            get
            {
                return _delegate.HostAddress;
            }
        }

        public virtual object Id
        {
            get
            {
                return _delegate.Id;
            }
        }

        public virtual DateTime LastAccessTime
        {
            get
            {
                return _delegate.LastAccessTime;
            }
        }

        public virtual DateTime StartTime
        {
            get
            {
                return _delegate.StartTime;
            }
        }

        public virtual long Timeout
        {
            get
            {
                return _delegate.Timeout;
            }
            set
            {
                _delegate.Timeout = value;
            }
        }

        public virtual void Stop()
        {
            _delegate.Stop();
        }

        public virtual void Touch()
        {
            _delegate.Touch();
        }

        #endregion
    }
}
