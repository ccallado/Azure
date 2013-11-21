using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.WindowsAzure.ServiceRuntime; //getconfigurationvalue (Valor de la configuración)
using Microsoft.WindowsAzure.Storage; //Antigua StorageClient 
using Microsoft.WindowsAzure.Storage.Queue; //Para trabajar con colas de mensajes

namespace InterfazWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Cuenta de almacenamiento local
            //Accedo a la cuenta
            CloudStorageAccount cuentaAlmacenamiento =
                CloudStorageAccount.DevelopmentStorageAccount;
            //Creo un cliente
            CloudQueueClient clienteColas =
                cuentaAlmacenamiento.CreateCloudQueueClient();
            string nombre = RoleEnvironment.GetConfigurationSettingValue("NombreColaMensages");
            //Obtenemos una referencia a la cola física
            CloudQueue cola = clienteColas.GetQueueReference(nombre);
            //Creo si no existe la cola
            cola.CreateIfNotExists();

            string texto;
            //Esto aquí está mal, la instancia sería la misma y al modificar el contenido
            //modificamos el contenido del mismo mensaje.
            //CloudQueueMessage msg = new CloudQueueMessage();
            CloudQueueMessage msg;

            for (int i = 1; i <= int.Parse(TextBox1.Text); i++)
            {
                texto = "Mensaje número " + i + " - enviado a las " + DateTime.Now.ToLongTimeString();
                //Hay que crear una instancia por cada mensaje
                msg = new CloudQueueMessage(texto);
                //msg.SetMessageContent(texto);
                cola.AddMessage(msg);
            }

            Label1.Text = "Mensajes enviados: " + TextBox1.Text + 
                          " a la cola <i>" + cola.Name + "</i>";
        }
    }
}
