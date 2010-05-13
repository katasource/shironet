using System;
using Apache.Shiro.Management;
using Apache.Shiro.Session;

namespace Apache.Shiro.Subject
{
    public class SubjectBuilder
    {
        private readonly ISecurityManager _securityManager;
        private readonly ISubjectContext _subjectContext;

        public SubjectBuilder()
            : this(SecurityUtils.SecurityManager)
        {
            
        }

        public SubjectBuilder(ISecurityManager securityManager)
        {
            if (securityManager == null)
            {
                throw new ArgumentNullException("securityManager");
            }
            _securityManager = securityManager;

            _subjectContext = NewSubjectContextInstance();
            if (_subjectContext == null)
            {
                throw new NullReferenceException("ISubjectContext instance returned from NewSubjectContextInstance cannot be null");
            }
            _subjectContext.SecurityManager = _securityManager;
        }

        public SubjectBuilder Authenticated(bool authenticated)
        {
            _subjectContext.Authenticated = authenticated;

            return this;
        }

        public ISubject BuildSubject()
        {
            return _securityManager.CreateSubject(_subjectContext);
        }

        public SubjectBuilder ContextAttribute(string attributeKey, object attributeValue)
        {
            if (string.IsNullOrEmpty(attributeKey))
            {
                throw new ArgumentNullException("attributeKey");
            }

            if (attributeValue == null)
            {
                _subjectContext.Remove(attributeKey);
            }
            else
            {
                _subjectContext.Add(attributeKey, attributeValue);
            }
            return this;
        }

        public SubjectBuilder Host(string host)
        {
            if (!string.IsNullOrWhiteSpace(host))
            {
                _subjectContext.Host = host;
            }
            return this;
        }

        public SubjectBuilder Principals(IPrincipalCollection principals)
        {
            if (principals != null && principals.Count > 0)
            {
                _subjectContext.Principals = principals;
            }
            return this;
        }

        public SubjectBuilder Session(ISession session)
        {
            if (session != null)
            {
                _subjectContext.Session = session;
            }
            return this;
        }

        public SubjectBuilder SessionId(object sessionId)
        {
            if (sessionId != null)
            {
                _subjectContext.SessionId = sessionId;
            }
            return this;
        }

        protected ISubjectContext SubjectContext
        {
            get
            {
                return _subjectContext;
            }
        }

        protected virtual ISubjectContext NewSubjectContextInstance()
        {
            return new DefaultSubjectContext();
        }
    }
}