using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioSingle" en el código, en svc y en el archivo de configuración a la vez.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single )]
    //Los Single crean una única instancia del servicio para todas las peticiones.

    public class ServicioSingle : IServicioSingle
    {
        ClaseOperaciones co;

        public ServicioSingle()
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
