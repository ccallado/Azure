using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.WindowsAzure.ServiceRuntime; //getconfigurationvalue (Valor de la configuración)
using Microsoft.WindowsAzure.Storage; //Antigua StorageClient 
using Microsoft.WindowsAzure.Storage.Queue; //Para trabajar con colas de mensajes

namespace InterfaceAdmin
{
    public partial class _Default : System.Web.UI.Page
    {
        CloudQueue cola;

        protected void Page_Load(object sender, EventArgs e)
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
            cola = clienteColas.GetQueueReference(nombre);
            //Creo si no existe la cola
            cola.CreateIfNotExists();
            Label1.Text = "";
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //string texto;
            CloudQueueMessage msg;

            cola.FetchAttributes();
            int cant = cola.ApproximateMessageCount.Value;
            if (cant > 0)
            {
                for (int i = 1; i <= cant; i++)
                {
                    msg = cola.GetMessage();
                    if (CheckBox1.Checked)
                        cola.DeleteMessage(msg);

                    Label1.Text += msg.AsString + " - " +
                                   msg.InsertionTime.Value.LocalDateTime.ToLongTimeString() + 
                                   "<br />";
                }
            }
            else
                Label1.Text = "Sin mensajes a leer...";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            cola.FetchAttributes();
            Label1.Text = "Mensajes pendientes: " + cola.ApproximateMessageCount.Value;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            cola.Clear();
            Label1.Text = "Mensajes pendientes: " + cola.ApproximateMessageCount.Value;
        }
    }
}
