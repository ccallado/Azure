using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

//Agregamos las REFERENCIAS 
//Microsoft.WindowsAzure.ServiceRuntime
//Microsoft.WindowsAzure.Storage

//La clase debe heredar de 
//   Microsoft.WindowsAzure.Storage.Table.DataServices.TableServiceContext

namespace LibreriaTablas
{
    public class TablaMensajesContext 
        : Microsoft.WindowsAzure.Storage.Table.DataServices.TableServiceContext 
    {
        //Es necesario que estén como estáticos y me vale para todas las instancias
        //Accedo a la cuenta
        static CloudStorageAccount cuentaAlmacenamiento =
            CloudStorageAccount.DevelopmentStorageAccount;
        //Para acceder a la tabla
        static CloudTableClient clienteTablas =
            cuentaAlmacenamiento.CreateCloudTableClient();

        //No es estática para que cada instancia tenga una tabla
        CloudTable tabla;

        //Constructor
        public TablaMensajesContext(string nombreTabla) 
            : base(clienteTablas)
        {
            tabla = clienteTablas.GetTableReference(nombreTabla);
            tabla.CreateIfNotExists();
        }

        //Método que devuelve TODAS las instancias de un tipo concreto.
        public IEnumerable<ClaseMsg1> Mensajes1()
        {
            return this.CreateQuery<ClaseMsg1>(tabla.Name);
        }

        //Método que devuelve las instancias de un tipo concreto filtradas pod IdMio.
        public IEnumerable<ClaseMsg1> Mensajes1(int idMio)
        {
            return Mensajes1().Where(m => m.IdMio == idMio);
        }

        //Método que devuelve TODAS las instancias de un tipo concreto.
        public IEnumerable<ClaseMsg2> Mensajes2()
        {
            return this.CreateQuery<ClaseMsg2>(tabla.Name);
        }

        //Método que devuelve las instancias de un tipo concreto filtradas pod IdMio.
        public IEnumerable<ClaseMsg2> Mensajes2(int idMio)
        {
            return Mensajes2().Where(m => m.IdMio == idMio);
        }

        //Método nuevo para rellenar
        public IEnumerable<ClaseMsg> Mensajes()
        {
            var c1 = from m in Mensajes1()
                     select new ClaseMsg
                     {
                         IdMio = m.IdMio,
                         Envio = m.Envio,
                         mensajeOriginal = m.mensajeOriginal,
                         TipoMsg = "ClaseMsg1"
                     };

            var c2 = from m in Mensajes2()
                     select new ClaseMsg
                     {
                         IdMio = m.IdMio,
                         Envio = m.Envio,
                         mensajeOriginal = m.mensajeOriginal,
                         TipoMsg = "ClaseMsg2"
                     };

            return c1.Concat(c2);
        }
    }
}
