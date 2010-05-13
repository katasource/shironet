using System;
using System.Collections.Generic;

using Apache.Shiro.Management;
using Apache.Shiro.Subject;

namespace Apache.Shiro.Util
{
    public static class ThreadContext
    {
        public const string SecurityManagerKey = KeyRoot + "SECURITY_MANAGER";
        public const string SubjectKey = KeyRoot + "SUBJECT";

        private const string KeyRoot = "Apache.Shiro.Util.ThreadContext.";

        [ThreadStatic]
        private static IDictionary<string, object> _context;

        public static ISecurityManager SecurityManager
        {
            get
            {
                return GetAs<ISecurityManager>(SecurityManagerKey);
            }
            set
            {
                Set(SecurityManagerKey, value);
            }
        }

        public static ISubject Subject
        {
            get
            {
                return GetAs<ISubject>(SubjectKey);
            }
            set
            {
                Set(SubjectKey, value);
            }
        }

        public static void Clear()
        {
            //Don't initialize this thread's context just to clear it
            if (_context != null)
            {
                _context.Clear();
            }
        }

        public static bool ContainsKey(string key)
        {
            return (_context != null && _context.ContainsKey(key));
        }

        public static object Get(string key)
        {
            return Context.ContainsKey(key) ? Context[key] : null;
        }

        public static T GetAs<T>(string key)
        {
            var value = Get(key);
            if (value is T)
            {
                return (T) value;
            }

            return default(T);
        }

        public static bool Remove(string key)
        {
            //Don't initialize this thread's context to try and remove something--if the context
            //is not initialized there won't be any objects to remove.
            return _context != null && _context.Remove(key);
        }

        public static void Set(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            if (value == null)
            {
                Remove(key);
            }
            else
            {
                Context.Add(key, value);
            }
        }

        private static IDictionary<string, object> Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new Dictionary<string, object>();
                }
                return _context;
            }
        }
    }
}