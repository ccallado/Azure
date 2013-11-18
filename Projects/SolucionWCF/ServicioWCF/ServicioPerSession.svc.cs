using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioPerSession" en el código, en svc y en el archivo de configuración a la vez.
    //Los servicios PerSession crean una instancia del servicio por cada sesión de comunicaciones
    //que se corresponde con la vida del Proxy en el cliente.
    //Por defecto son PerSession, pero si el servicio no acepta sesiones en su Binding,
    //se comporta como si fuera PerCall.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ServicioPerSession : IServicioPerSession
    {
            ClaseOperaciones co;

            public ServicioPerSession()
            {
                co = new ClaseOperaciones();
            }
            public string IncrementaContador()
            {
                System.Threading.Thread.Sleep(1000);
                return co.IncrementaContador();
            }

    }
}
