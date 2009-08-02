using System;
using System.Collections.Generic;

namespace Apache.Shiro.Util
{
    public class LifecycleUtils
    {
        private LifecycleUtils()
        {

        }

        public static void Init(object o)
        {
            if (o is IInitializable)
            {
                Init((IInitializable)o);
            }
        }

        public static void Init(ICollection<object> collection)
        {
            if (collection == null || collection.Count == 0)
            {
                return;
            }

            foreach (object o in collection)
            {
                Init(o);
            }
        }

        public static void Init(IInitializable initializable)
        {
            if (initializable != null)
            {
                initializable.Init();
            }
        }

        public static void Dispose(object o)
        {
            if (o is IDisposable)
            {
                Dispose((IDisposable)o);
            }
        }

        public static void Dispose(ICollection<object> collection)
        {
            if (collection == null || collection.Count == 0)
            {
                return;
            }

            foreach (object o in collection)
            {
                Dispose(o);
            }
        }

        public static void Dispose(IDisposable disposable)
        {
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
