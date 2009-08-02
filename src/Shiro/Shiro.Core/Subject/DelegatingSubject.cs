using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using Apache.Shiro.Authc;
using Apache.Shiro.Authz;
using Apache.Shiro.Management;
using Apache.Shiro.Session;
using Apache.Shiro.Session.Management;
using Apache.Shiro.Util;

namespace Apache.Shiro.Subject
{
    public class DelegatingSubject : ISubject
    {
        #region Private Fields

        private ISession _session;

        #endregion

        public DelegatingSubject(ISecurityManager manager)
            : this(null, false, null, null, manager)
        {
            
        }

        public DelegatingSubject(IPrincipalCollection principals, bool authenticated, IPAddress address,
            ISession session, ISecurityManager manager)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("manager");
            }

            Authenticated = authenticated;
            Principals = principals;
            HostAddress = address ?? IPAddress.Loopback;
            SecurityManager = manager;

            _session = Decorate(session);
        }

        #region ISubject Members

        public bool Authenticated { get; private set; }

        public IPAddress HostAddress { get; protected set; }

        public object Principal
        {
            get
            {
                return Principals == null ? null : Principals.FirstOrDefault();
            }
        }

        public IPrincipalCollection Principals { get; private set; }

        public void CheckPermission(IPermission permission)
        {
            AssertAuthcCheckPossible();
            SecurityManager.CheckPermission(Principals, permission);
        }

        public void CheckPermissions(ICollection<IPermission> permissions)
        {
            AssertAuthcCheckPossible();
            SecurityManager.CheckPermissions(Principals, permissions);
        }

        public void CheckPermission(string permission)
        {
            AssertAuthcCheckPossible();
            SecurityManager.CheckPermission(Principals, permission);
        }

        public void CheckPermissions(params string[] permissions)
        {
            AssertAuthcCheckPossible();
            SecurityManager.CheckPermissions(Principals, permissions);
        }

        public void CheckRole(string roleId)
        {
            AssertAuthcCheckPossible();
            SecurityManager.CheckRole(Principals, roleId);
        }

        public void CheckRoles(ICollection<string> roleIds)
        {
            AssertAuthcCheckPossible();
            SecurityManager.CheckRoles(Principals, roleIds);
        }

        public ISession GetSession()
        {
            return GetSession(true);
        }

        public ISession GetSession(bool create)
        {
            if (_session == null && create)
            {
                
            }
            return _session;
        }

        public bool HasAllRoles(ICollection<string> roleIds)
        {
            return (HasPrincipals() && SecurityManager.HasAllRoles(Principals, roleIds));
        }

        public bool HasRole(string roleId)
        {
            return (HasPrincipals() && SecurityManager.HasRole(Principals, roleId));
        }

        public bool[] HasRoles(ICollection<string> roleIds)
        {
            return (HasPrincipals() ? SecurityManager.HasRoles(Principals, roleIds) : new bool[roleIds.Count]);
        }

        public bool IsPermitted(IPermission permission)
        {
            return (HasPrincipals() && SecurityManager.IsPermitted(Principals, permission));
        }

        public bool[] IsPermitted(ICollection<IPermission> permissions)
        {
            return (HasPrincipals() ? SecurityManager.IsPermitted(Principals, permissions) : new bool[permissions.Count]);
        }

        public bool IsPermitted(string permission)
        {
            return (HasPrincipals() && SecurityManager.IsPermitted(Principals, permission));
        }

        public bool[] IsPermitted(params string[] permissions)
        {
            return (HasPrincipals() ?
                SecurityManager.IsPermitted(Principals, permissions) : new bool[permissions.Length]);
        }

        public bool IsPermittedAll(ICollection<IPermission> permissions)
        {
            return (HasPrincipals() && SecurityManager.IsPermittedAll(Principals, permissions));
        }

        public bool IsPermittedAll(params string[] permissions)
        {
            return (HasPrincipals() && SecurityManager.IsPermittedAll(Principals, permissions));
        }

        public void Login(IAuthenticationToken token)
        {
            var subject = SecurityManager.Login(token);

            var principals = subject.Principals;
            if (principals == null || principals.Count == 0)
            {
                throw new InvalidSubjectException(Properties.Resources.NullOrEmptyPrincipalsAfterLoginMessage);
            }

            Authenticated = true;
            Principals = principals;
            if (token is IInetAuthenticationToken)
            {
                var address = ((IInetAuthenticationToken) token).HostAddress;
                if (address != null)
                {
                    HostAddress = address;
                }
            }

            var session = subject.GetSession(false);
            _session = (session == null ? null : Decorate(session));

            ThreadContext.Subject = this;
        }

        public void Logout()
        {
            try
            {
                SecurityManager.Logout(Principals);
            }
            finally
            {
                Authenticated = false;
                Principals = null;

                _session = null;
            }
        }

        #endregion

        #region Public Properties

        public ISecurityManager SecurityManager { get; protected set; }

        #endregion

        #region Protected Methods

        protected virtual void AssertAuthcCheckPossible()
        {
            if (!HasPrincipals())
            {
                throw new UnauthenticatedException(
                    string.Format(Properties.Resources.AuthcCheckNotPossibleMessage,
                        typeof(ISubject).Name, typeof(IAuthenticationInfo).Name));
            }
        }

        protected virtual ISession Decorate(ISession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException("session");
            }
            return DecorateSession(session.Id);
        }

        protected virtual ISession DecorateSession(object sessionId)
        {
            if (sessionId == null)
            {
                throw new ArgumentNullException("sessionId");
            }

            return new StoppingAwareProxiedSession(
                new DelegatingSession(SecurityManager, sessionId), this);
        }

        protected virtual bool HasPrincipals()
        {
            return (Principals != null && Principals.Count > 0);
        }

        #endregion

        #region Private Methods

        private void SessionStopped()
        {
            _session = null;
        }

        #endregion

        #region Private Inner Classes

        private class StoppingAwareProxiedSession : ProxiedSession
        {
            private readonly DelegatingSubject _owningSubject;

            public StoppingAwareProxiedSession(ISession session, DelegatingSubject owningSubject)
                : base(session)
            {
                _owningSubject = owningSubject;
            }

            public sealed override void Stop()
            {
                base.Stop();
                _owningSubject.SessionStopped();
            }
        }

        #endregion
    }
}