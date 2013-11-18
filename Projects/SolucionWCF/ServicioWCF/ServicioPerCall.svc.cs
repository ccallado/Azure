using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioPerCall" en el código, en svc y en el archivo de configuración a la vez.
    //Los servicios son PerCall de manera predeterminada.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ServicioPerCall : IServicioPerCall
    {
        ClaseOperaciones co;

        public ServicioPerCall()
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
