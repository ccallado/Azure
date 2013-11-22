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
    }
}
