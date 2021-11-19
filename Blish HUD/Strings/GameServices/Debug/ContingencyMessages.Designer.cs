﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blish_HUD.Strings.GameServices.Debug {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ContingencyMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ContingencyMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Blish_HUD.Strings.GameServices.Debug.ContingencyMessages", typeof(ContingencyMessages).Assembly);
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
        ///   Looks up a localized string similar to There is a custom &apos;d3dll.dll&apos; (e.g. ArcDPS) in the same directory as Blish HUD which will attempt to inject into Blish HUD and cause it to crash.  Please move Blish HUD to a different folder..
        /// </summary>
        internal static string ArcDpsSameDir_Description {
            get {
                return ResourceManager.GetString("ArcDpsSameDir_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Blish HUD Can&apos;t Run!.
        /// </summary>
        internal static string ArcDpsSameDir_Title {
            get {
                return ResourceManager.GetString("ArcDpsSameDir_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Blish HUD was actively blocked saving to &apos;{0}&apos; {1}.
        ///
        ///This is typically due to an anti-virus blocking us or Window&apos;s Controlled Folder Access. Ensure that Blish HUD is explicitly marked as allowed by your anti-virus..
        /// </summary>
        internal static string FileSaveAccessDenied_Description {
            get {
                return ResourceManager.GetString("FileSaveAccessDenied_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Blish HUD Was Blocked From Saving Data!.
        /// </summary>
        internal static string FileSaveAccessDenied_Title {
            get {
                return ResourceManager.GetString("FileSaveAccessDenied_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Check our &lt;a href=&quot;{0}&quot;&gt;troubleshooting guide&lt;/a&gt; for this issue or join our &lt;a href=&quot;{1}&quot;&gt;Discord 💢help channel&lt;/a&gt;..
        /// </summary>
        internal static string GenericUrl_Footer {
            get {
                return ResourceManager.GetString("GenericUrl_Footer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Blish HUD was unable to find the ref.dat file. When you download Blish HUD, be sure to extract all files from the zip and ensure they are within the same directory as Blish HUD.exe..
        /// </summary>
        internal static string MissingRef_Description {
            get {
                return ResourceManager.GetString("MissingRef_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Blish HUD Needs Re-extracted!.
        /// </summary>
        internal static string MissingRef_Title {
            get {
                return ResourceManager.GetString("MissingRef_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Blish HUD was unable to access to Guild Wars 2 process. It was likely started as an administrator.
        ///
        ///Relaunch Blish HUD as an administrator or relaunch Guild Wars 2 without admin..
        /// </summary>
        internal static string Win32AccessDenied_Description {
            get {
                return ResourceManager.GetString("Win32AccessDenied_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Blish HUD Access Denied!.
        /// </summary>
        internal static string Win32AccessDenied_Title {
            get {
                return ResourceManager.GetString("Win32AccessDenied_Title", resourceCulture);
            }
        }
    }
}