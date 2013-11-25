using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;

using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
//O ponemos el using o los nombres "largos"...
//Dll de mi librería
using LibreriaTablas;

namespace Currito
{
    public class WorkerRole : RoleEntryPoint
    {
        CloudQueue cola;
        CloudTable tabla;

        public override void Run()
        {
            // Esta es la implementación de un trabajador de ejemplo. Reemplácela por su lógica.
            Trace.TraceInformation("Currito entry point called", "Information");

            while (true)
            {
                Thread.Sleep(10000);
                Trace.TraceInformation("Working", "Information");
                RecogeMensajes();
            }
        }

        public override bool OnStart()
        {
            //Cuenta de almacenamiento local
            //Accedo a la cuenta
            CloudStorageAccount cuentaAlmacenamiento =
                CloudStorageAccount.DevelopmentStorageAccount;



            //Creo un cliente
            //Para acceder a la cola de mensajes
            CloudQueueClient clienteColas =
                cuentaAlmacenamiento.CreateCloudQueueClient();

            //Mensajes para colamsg2
            string nombre = RoleEnvironment.GetConfigurationSettingValue("NombreColaMensagesTabla");
            //Obtenemos una referencia a la cola física
            cola = clienteColas.GetQueueReference(nombre);
            //Creo si no existe la cola
            cola.CreateIfNotExists();



            //Para acceder a la tabla
            CloudTableClient clienteTablas =
                cuentaAlmacenamiento.CreateCloudTableClient();

            //Mensajes para tablamsg
            nombre = RoleEnvironment.GetConfigurationSettingValue("NombreTablaMensajes");
            //Obtenemos una referencia a la cola física
            tabla = clienteTablas.GetTableReference(nombre);
            //Creo si no existe la cola
            tabla.CreateIfNotExists();



            // Establecer el número máximo de conexiones simultáneas 
            ServicePointManager.DefaultConnectionLimit = 12;

            // Para obtener información sobre cómo administrar los cambios de configuración
            // consulte el tema de MSDN en http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }

        private void RecogeMensajes()
        {
            //instancio objeto Context
            string nombreTabla = RoleEnvironment.GetConfigurationSettingValue("NombreTablaMensajes");
            LibreriaTablas.TablaMensajesContext contexto =
                new TablaMensajesContext(nombreTabla);

            //Recojo mensajes de la cola de mensajes
            //Leo el primer mensaje
            CloudQueueMessage msg = cola.GetMessage(new TimeSpan(0, 0, 30));

            while (msg != null)
            {
                //tengo el id del mensaje
                int id = int.Parse(msg.AsString.Substring(15, 2));

                //Pares por una clase de mensaje
                if (id % 2 != 0)
                {
                    ClaseMsg1 c = new ClaseMsg1();
                    c.PartitionKey = "Madrid";
                    c.RowKey = Guid.NewGuid().ToString(); //Numero Guid que no se debe repetir
                    c.IdMio = id;
                    c.Envio = msg.InsertionTime.Value.LocalDateTime;
                    c.mensajeOriginal = msg.AsString;

                    //Agrego el objeto c a la tabla
                    contexto.AddObject(nombreTabla, c);
                }
                //Impares por otra clase de mensaje con un campo más
                else
                {
                    ClaseMsg2 c = new ClaseMsg2();
                    c.PartitionKey = "Barcelona";
                    c.RowKey = Guid.NewGuid().ToString(); //Numero Guid que no se debe repetir
                    c.IdMio = id;
                    c.Envio = msg.InsertionTime.Value.LocalDateTime;
                    c.mensajeOriginal = msg.AsString;
                    c.IdMensajeCola = msg.Id;

                    //Agrego el objeto c a la tabla
                    contexto.AddObject(nombreTabla, c);
                }

                //Esto es como entity va almacenando los cambios para guardarlos al final
                //Ahora vamos a hacerlo mensaje a mensaje.
                contexto.SaveChanges();
                //Borro el mensaje
                cola.DeleteMessage(msg);

                //Leo el mensaje siguiente
                msg = cola.GetMessage(new TimeSpan(0, 0, 30));
            }

        }
    }
}
