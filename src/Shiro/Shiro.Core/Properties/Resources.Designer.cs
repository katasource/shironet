﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4016
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apache.Shiro.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Apache.Shiro.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Identity principals are not associated with this Subject instance - authorization operations require an identity to check against.  A Subject instance will acquire these identifying principals automatically after a successful login is performed be executing {0}.login({1}) or when &apos;Remember Me&apos; functionality is enabled. This exception can also occur when the current Subject has logged out, which relinquishes its identity and essentially makes it anonymous again. Because an identity is currently not known due [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AuthcCheckNotPossibleMessage {
            get {
                return ResourceManager.GetString("AuthcCheckNotPossibleMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided array contains an odd number of characters. Only even-sized arrays can be converted..
        /// </summary>
        internal static string HexCharArrayOddLengthMessage {
            get {
                return ResourceManager.GetString("HexCharArrayOddLengthMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This session is immutable and read-only--it cannot be altered. This is usually because the session has been stopped or is expired..
        /// </summary>
        internal static string ImmutableSessionMessage {
            get {
                return ResourceManager.GetString("ImmutableSessionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Principals returned from the ISecurityManager on login are null or empty. Principals after login must be non-null and populated with one or more elements.  Please check the SecurityManager implementation to ensure this happens after a successful login attempt..
        /// </summary>
        internal static string NullOrEmptyPrincipalsAfterLoginMessage {
            get {
                return ResourceManager.GetString("NullOrEmptyPrincipalsAfterLoginMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This dictionary is immutable and read-only--it cannot be altered..
        /// </summary>
        internal static string ReadOnlyDictionaryMessage {
            get {
                return ResourceManager.GetString("ReadOnlyDictionaryMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Session with ID [{0}] has expired. Last access time: {1}. Current time: {2}. Session timeout is set to {3} seconds ({4} minutes).
        /// </summary>
        internal static string SessionExpiredMessage {
            get {
                return ResourceManager.GetString("SessionExpiredMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Session with ID [{0}] has been explicitly stopped. No further interaction under this session is allowed..
        /// </summary>
        internal static string SessionStoppedMessage {
            get {
                return ResourceManager.GetString("SessionStoppedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is no session with ID [{0}]..
        /// </summary>
        internal static string SessionUnknownMessage {
            get {
                return ResourceManager.GetString("SessionUnknownMessage", resourceCulture);
            }
        }
    }
}
