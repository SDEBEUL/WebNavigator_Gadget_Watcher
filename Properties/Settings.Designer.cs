﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebNavigator_Gadget_Watcher.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.5.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("E:\\Scada\\MultiClient\\WebNavigator\\GadgetScreens.xml")]
        public string xmlConfig {
            get {
                return ((string)(this["xmlConfig"]));
            }
            set {
                this["xmlConfig"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool WatchConfig {
            get {
                return ((bool)(this["WatchConfig"]));
            }
            set {
                this["WatchConfig"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Program Files (x86)\\Siemens\\WinCC\\Webnavigator\\Server\\Web\\Image\\_gadget\\pdlIma" +
            "ge.jpg")]
        public string ExportedFile {
            get {
                return ((string)(this["ExportedFile"]));
            }
            set {
                this["ExportedFile"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\10.249.2.26\\equipmentshare\\SupervisieCMA")]
        public string netExportLocation {
            get {
                return ((string)(this["netExportLocation"]));
            }
            set {
                this["netExportLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("VCGENT\\appplcbck")]
        public string netExportUser {
            get {
                return ((string)(this["netExportUser"]));
            }
            set {
                this["netExportUser"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("System123")]
        public string netExportPass {
            get {
                return ((string)(this["netExportPass"]));
            }
            set {
                this["netExportPass"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool autostart {
            get {
                return ((bool)(this["autostart"]));
            }
            set {
                this["autostart"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://webapps.gen.volvocars.net/applications/eng/equipment/SuperVisieCma/")]
        public string htmlExportPath {
            get {
                return ((string)(this["htmlExportPath"]));
            }
            set {
                this["htmlExportPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("c:\\Windows\\SysWOW64\\config\\systemprofile\\AppData\\Local\\Microsoft\\Windows\\INetCach" +
            "e\\IE")]
        public string InetCachePath {
            get {
                return ((string)(this["InetCachePath"]));
            }
            set {
                this["InetCachePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool InetCachePathEnbl {
            get {
                return ((bool)(this["InetCachePathEnbl"]));
            }
            set {
                this["InetCachePathEnbl"] = value;
            }
        }
    }
}
