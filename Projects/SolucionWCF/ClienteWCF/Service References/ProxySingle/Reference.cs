﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.225
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClienteWCF.ProxySingle {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProxySingle.IServicioSingle")]
    public interface IServicioSingle {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioSingle/IncrementaContador", ReplyAction="http://tempuri.org/IServicioSingle/IncrementaContadorResponse")]
        string IncrementaContador();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioSingle/IncrementaContadorConBloqueo", ReplyAction="http://tempuri.org/IServicioSingle/IncrementaContadorConBloqueoResponse")]
        string IncrementaContadorConBloqueo(int segundosParada);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioSingleChannel : ClienteWCF.ProxySingle.IServicioSingle, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioSingleClient : System.ServiceModel.ClientBase<ClienteWCF.ProxySingle.IServicioSingle>, ClienteWCF.ProxySingle.IServicioSingle {
        
        public ServicioSingleClient() {
        }
        
        public ServicioSingleClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioSingleClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioSingleClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioSingleClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string IncrementaContador() {
            return base.Channel.IncrementaContador();
        }
        
        public string IncrementaContadorConBloqueo(int segundosParada) {
            return base.Channel.IncrementaContadorConBloqueo(segundosParada);
        }
    }
}
