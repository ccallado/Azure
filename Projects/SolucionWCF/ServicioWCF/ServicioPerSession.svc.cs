using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioPerSession" en el código, en svc y en el archivo de configuración a la vez.
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
