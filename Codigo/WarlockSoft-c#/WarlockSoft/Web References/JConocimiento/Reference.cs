﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace WarlockSoft.JConocimiento {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ConocimientoPortBinding", Namespace="http://Servicios/")]
    public partial class Conocimiento : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback obtenerConocimientosUsuarioOperationCompleted;
        
        private System.Threading.SendOrPostCallback obtenerConocimientosOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Conocimiento() {
            this.Url = global::WarlockSoft.Properties.Settings.Default.WarlockSoft_JConocimiento_Conocimiento;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event obtenerConocimientosUsuarioCompletedEventHandler obtenerConocimientosUsuarioCompleted;
        
        /// <remarks/>
        public event obtenerConocimientosCompletedEventHandler obtenerConocimientosCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://Servicios/", ResponseNamespace="http://Servicios/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string[] obtenerConocimientosUsuario([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] int id_usuario) {
            object[] results = this.Invoke("obtenerConocimientosUsuario", new object[] {
                        id_usuario});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void obtenerConocimientosUsuarioAsync(int id_usuario) {
            this.obtenerConocimientosUsuarioAsync(id_usuario, null);
        }
        
        /// <remarks/>
        public void obtenerConocimientosUsuarioAsync(int id_usuario, object userState) {
            if ((this.obtenerConocimientosUsuarioOperationCompleted == null)) {
                this.obtenerConocimientosUsuarioOperationCompleted = new System.Threading.SendOrPostCallback(this.OnobtenerConocimientosUsuarioOperationCompleted);
            }
            this.InvokeAsync("obtenerConocimientosUsuario", new object[] {
                        id_usuario}, this.obtenerConocimientosUsuarioOperationCompleted, userState);
        }
        
        private void OnobtenerConocimientosUsuarioOperationCompleted(object arg) {
            if ((this.obtenerConocimientosUsuarioCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.obtenerConocimientosUsuarioCompleted(this, new obtenerConocimientosUsuarioCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace="http://Servicios/", ResponseNamespace="http://Servicios/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public string[] obtenerConocimientos() {
            object[] results = this.Invoke("obtenerConocimientos", new object[0]);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void obtenerConocimientosAsync() {
            this.obtenerConocimientosAsync(null);
        }
        
        /// <remarks/>
        public void obtenerConocimientosAsync(object userState) {
            if ((this.obtenerConocimientosOperationCompleted == null)) {
                this.obtenerConocimientosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnobtenerConocimientosOperationCompleted);
            }
            this.InvokeAsync("obtenerConocimientos", new object[0], this.obtenerConocimientosOperationCompleted, userState);
        }
        
        private void OnobtenerConocimientosOperationCompleted(object arg) {
            if ((this.obtenerConocimientosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.obtenerConocimientosCompleted(this, new obtenerConocimientosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void obtenerConocimientosUsuarioCompletedEventHandler(object sender, obtenerConocimientosUsuarioCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class obtenerConocimientosUsuarioCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal obtenerConocimientosUsuarioCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    public delegate void obtenerConocimientosCompletedEventHandler(object sender, obtenerConocimientosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2556.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class obtenerConocimientosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal obtenerConocimientosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591