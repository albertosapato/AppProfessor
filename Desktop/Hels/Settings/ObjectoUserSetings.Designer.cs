﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Desktop.Hels.Settings {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class ObjectoUserSetings : global::System.Configuration.ApplicationSettingsBase {
        
        private static ObjectoUserSetings defaultInstance = ((ObjectoUserSetings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ObjectoUserSetings())));
        
        public static ObjectoUserSetings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Skin/Office 2019 Colorful")]
        public string DefaultAppSkin {
            get {
                return ((string)(this["DefaultAppSkin"]));
            }
            set {
                this["DefaultAppSkin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Yale")]
        public string DefaultPalette {
            get {
                return ((string)(this["DefaultPalette"]));
            }
            set {
                this["DefaultPalette"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool TouchUI {
            get {
                return ((bool)(this["TouchUI"]));
            }
            set {
                this["TouchUI"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Microsoft Sans Serif, 8.25pt")]
        public global::System.Drawing.Font DefaultAppFont {
            get {
                return ((global::System.Drawing.Font)(this["DefaultAppFont"]));
            }
            set {
                this["DefaultAppFont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SQLSERVER")]
        public string Conection {
            get {
                return ((string)(this["Conection"]));
            }
            set {
                this["Conection"] = value;
            }
        }
    }
}