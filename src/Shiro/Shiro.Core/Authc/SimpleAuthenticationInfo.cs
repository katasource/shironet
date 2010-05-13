using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Apache.Shiro.Subject;

namespace Apache.Shiro.Authc
{
    public class SimpleAuthenticationInfo : IMergeableAuthenticationInfo
    {
        public SimpleAuthenticationInfo()
        {

        }

        public SimpleAuthenticationInfo(object principal, object credentials, string realmName)
            : this(new SimplePrincipalCollection(principal, realmName), credentials)
        {
            
        }

        public SimpleAuthenticationInfo(IPrincipalCollection principals, object credentials)
        {
            Principals = principals;
            Credentials = credentials;
        }

        public object Credentials { get; set; }

        public IPrincipalCollection Principals { get; set; }

        public void Merge(IAuthenticationInfo other)
        {
            if (other == null || other.Principals == null || other.Principals.Count == 0)
            {
                return;
            }

            if (Principals == null)
            {
                Principals = other.Principals;
            }
            else
            {
                if (!(Principals is IMutablePrincipalCollection))
                {
                    Principals = new SimplePrincipalCollection(Principals);
                }
                ((IMutablePrincipalCollection) Principals).AddAll(other.Principals);
            }

            if (other.Credentials == null)
            {
                return;
            }
            if (Credentials == null)
            {
                Credentials = other.Credentials;

                return;
            }

            //TODO: This has a metric ton of loopholes and weaknesses in .NET
            if (!(Credentials is ICollection))
            {
                Credentials = new HashSet<object> { Credentials };
            }

            var credentials = (ISet<object>) Credentials;
            if (other.Credentials is IEnumerable)
            {
                credentials.UnionWith((IEnumerable<object>) other.Credentials);
            }
            else
            {
                credentials.Add(other.Credentials);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            if (obj is SimpleAuthenticationInfo)
            {
                var info = (SimpleAuthenticationInfo) obj;

                return (Principals == null ? info.Principals == null : Principals.Equals(info.Principals));
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Principals == null ? 0 : Principals.GetHashCode());
        }

        public override string ToString()
        {
            return (Principals == null ? base.ToString() : Principals.ToString());
        }
    }
}