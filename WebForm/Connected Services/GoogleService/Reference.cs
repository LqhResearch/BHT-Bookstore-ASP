﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebForm.GoogleService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserClass", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class UserClass : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string given_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string family_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string linkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string pictureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string genderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string localeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string emailField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string id {
            get {
                return this.idField;
            }
            set {
                if ((object.ReferenceEquals(this.idField, value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string given_name {
            get {
                return this.given_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.given_nameField, value) != true)) {
                    this.given_nameField = value;
                    this.RaisePropertyChanged("given_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string family_name {
            get {
                return this.family_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.family_nameField, value) != true)) {
                    this.family_nameField = value;
                    this.RaisePropertyChanged("family_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string link {
            get {
                return this.linkField;
            }
            set {
                if ((object.ReferenceEquals(this.linkField, value) != true)) {
                    this.linkField = value;
                    this.RaisePropertyChanged("link");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string picture {
            get {
                return this.pictureField;
            }
            set {
                if ((object.ReferenceEquals(this.pictureField, value) != true)) {
                    this.pictureField = value;
                    this.RaisePropertyChanged("picture");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string gender {
            get {
                return this.genderField;
            }
            set {
                if ((object.ReferenceEquals(this.genderField, value) != true)) {
                    this.genderField = value;
                    this.RaisePropertyChanged("gender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string locale {
            get {
                return this.localeField;
            }
            set {
                if ((object.ReferenceEquals(this.localeField, value) != true)) {
                    this.localeField = value;
                    this.RaisePropertyChanged("locale");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string email {
            get {
                return this.emailField;
            }
            set {
                if ((object.ReferenceEquals(this.emailField, value) != true)) {
                    this.emailField = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GoogleService.GoogleServiceSoap")]
    public interface GoogleServiceSoap {
        
        // CODEGEN: Generating message contract since element name code from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetToken", ReplyAction="*")]
        WebForm.GoogleService.GetTokenResponse GetToken(WebForm.GoogleService.GetTokenRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetToken", ReplyAction="*")]
        System.Threading.Tasks.Task<WebForm.GoogleService.GetTokenResponse> GetTokenAsync(WebForm.GoogleService.GetTokenRequest request);
        
        // CODEGEN: Generating message contract since element name userinfo from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GoogleSignUp", ReplyAction="*")]
        WebForm.GoogleService.GoogleSignUpResponse GoogleSignUp(WebForm.GoogleService.GoogleSignUpRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GoogleSignUp", ReplyAction="*")]
        System.Threading.Tasks.Task<WebForm.GoogleService.GoogleSignUpResponse> GoogleSignUpAsync(WebForm.GoogleService.GoogleSignUpRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetTokenRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetToken", Namespace="http://tempuri.org/", Order=0)]
        public WebForm.GoogleService.GetTokenRequestBody Body;
        
        public GetTokenRequest() {
        }
        
        public GetTokenRequest(WebForm.GoogleService.GetTokenRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetTokenRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string code;
        
        public GetTokenRequestBody() {
        }
        
        public GetTokenRequestBody(string code) {
            this.code = code;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetTokenResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetTokenResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebForm.GoogleService.GetTokenResponseBody Body;
        
        public GetTokenResponse() {
        }
        
        public GetTokenResponse(WebForm.GoogleService.GetTokenResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetTokenResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public WebForm.GoogleService.UserClass GetTokenResult;
        
        public GetTokenResponseBody() {
        }
        
        public GetTokenResponseBody(WebForm.GoogleService.UserClass GetTokenResult) {
            this.GetTokenResult = GetTokenResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GoogleSignUpRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GoogleSignUp", Namespace="http://tempuri.org/", Order=0)]
        public WebForm.GoogleService.GoogleSignUpRequestBody Body;
        
        public GoogleSignUpRequest() {
        }
        
        public GoogleSignUpRequest(WebForm.GoogleService.GoogleSignUpRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GoogleSignUpRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public WebForm.GoogleService.UserClass userinfo;
        
        public GoogleSignUpRequestBody() {
        }
        
        public GoogleSignUpRequestBody(WebForm.GoogleService.UserClass userinfo) {
            this.userinfo = userinfo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GoogleSignUpResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GoogleSignUpResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebForm.GoogleService.GoogleSignUpResponseBody Body;
        
        public GoogleSignUpResponse() {
        }
        
        public GoogleSignUpResponse(WebForm.GoogleService.GoogleSignUpResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GoogleSignUpResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool GoogleSignUpResult;
        
        public GoogleSignUpResponseBody() {
        }
        
        public GoogleSignUpResponseBody(bool GoogleSignUpResult) {
            this.GoogleSignUpResult = GoogleSignUpResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GoogleServiceSoapChannel : WebForm.GoogleService.GoogleServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GoogleServiceSoapClient : System.ServiceModel.ClientBase<WebForm.GoogleService.GoogleServiceSoap>, WebForm.GoogleService.GoogleServiceSoap {
        
        public GoogleServiceSoapClient() {
        }
        
        public GoogleServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GoogleServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GoogleServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GoogleServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebForm.GoogleService.GetTokenResponse WebForm.GoogleService.GoogleServiceSoap.GetToken(WebForm.GoogleService.GetTokenRequest request) {
            return base.Channel.GetToken(request);
        }
        
        public WebForm.GoogleService.UserClass GetToken(string code) {
            WebForm.GoogleService.GetTokenRequest inValue = new WebForm.GoogleService.GetTokenRequest();
            inValue.Body = new WebForm.GoogleService.GetTokenRequestBody();
            inValue.Body.code = code;
            WebForm.GoogleService.GetTokenResponse retVal = ((WebForm.GoogleService.GoogleServiceSoap)(this)).GetToken(inValue);
            return retVal.Body.GetTokenResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebForm.GoogleService.GetTokenResponse> WebForm.GoogleService.GoogleServiceSoap.GetTokenAsync(WebForm.GoogleService.GetTokenRequest request) {
            return base.Channel.GetTokenAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebForm.GoogleService.GetTokenResponse> GetTokenAsync(string code) {
            WebForm.GoogleService.GetTokenRequest inValue = new WebForm.GoogleService.GetTokenRequest();
            inValue.Body = new WebForm.GoogleService.GetTokenRequestBody();
            inValue.Body.code = code;
            return ((WebForm.GoogleService.GoogleServiceSoap)(this)).GetTokenAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebForm.GoogleService.GoogleSignUpResponse WebForm.GoogleService.GoogleServiceSoap.GoogleSignUp(WebForm.GoogleService.GoogleSignUpRequest request) {
            return base.Channel.GoogleSignUp(request);
        }
        
        public bool GoogleSignUp(WebForm.GoogleService.UserClass userinfo) {
            WebForm.GoogleService.GoogleSignUpRequest inValue = new WebForm.GoogleService.GoogleSignUpRequest();
            inValue.Body = new WebForm.GoogleService.GoogleSignUpRequestBody();
            inValue.Body.userinfo = userinfo;
            WebForm.GoogleService.GoogleSignUpResponse retVal = ((WebForm.GoogleService.GoogleServiceSoap)(this)).GoogleSignUp(inValue);
            return retVal.Body.GoogleSignUpResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebForm.GoogleService.GoogleSignUpResponse> WebForm.GoogleService.GoogleServiceSoap.GoogleSignUpAsync(WebForm.GoogleService.GoogleSignUpRequest request) {
            return base.Channel.GoogleSignUpAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebForm.GoogleService.GoogleSignUpResponse> GoogleSignUpAsync(WebForm.GoogleService.UserClass userinfo) {
            WebForm.GoogleService.GoogleSignUpRequest inValue = new WebForm.GoogleService.GoogleSignUpRequest();
            inValue.Body = new WebForm.GoogleService.GoogleSignUpRequestBody();
            inValue.Body.userinfo = userinfo;
            return ((WebForm.GoogleService.GoogleServiceSoap)(this)).GoogleSignUpAsync(inValue);
        }
    }
}
