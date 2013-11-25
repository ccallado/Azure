using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibreriaTablas
{
    //Clase por atributo
    //Agregar la REFERENCIA System.Data.Services.Client versión 4.0.0.0
    [System.Data.Services.Common.DataServiceKey("PartitionKey", "RowKey")]
    public class ClaseMsg1
    {
        //Propiedades OBLIGATORIAS para usar en Tablas de Azure
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTime Timestamp { get; set; }

        //Resto de propiedades (PropertyBag)
        public int IdMio { get; set; }
        public DateTime Envio { get; set; }
        public string mensajeOriginal { get; set; }
    }

    //Hace falta referenciar Microsoft.WindowsAzure.Storage.Table
    //que ya estaba porque la usamos en el objeto de contexto.
    //Heredamos de la clase y PartitionKey y RowKey automáticas
    public class ClaseMsg2 
        : Microsoft.WindowsAzure.Storage.Table.DataServices.TableServiceEntity 
    {
        //Ya hereda como clave PartitionKey, RowKey y Timestamp

        //Resto de propiedades (PropertyBag)
        public int IdMio { get; set; }
        public DateTime Envio { get; set; }
        public string mensajeOriginal { get; set; }

        public string IdMensajeCola { get; set; }
    }

    public class ClaseMsg
    {
        //Resto de propiedades (PropertyBag)
        public int IdMio { get; set; }
        public DateTime Envio { get; set; }
        public string mensajeOriginal { get; set; }
        public string TipoMsg { get; set; }
    }
}
