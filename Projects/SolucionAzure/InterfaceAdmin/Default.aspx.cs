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
            CloudQueueMessage msg = null;

            cola.FetchAttributes();
            //Devuelve el número de mensajes en cola.
            //Los "ocultos" leidos pero no borrados CUENTAS,
            //pero al llamar a GetMessage no los tiene en cuenta,
            //con lo que este valor podrá ser superior al de mensajes que se puedan leer,
            int cant = cola.ApproximateMessageCount.Value;
            if (cant > 0)
            {
                int i;
                for (i = 1; i <= cant; i++)
                {
                    //Esto los "oculta" sólo durante 10 segundos.
                    msg = cola.GetMessage(new TimeSpan(0,0,10));
                    //si no quedan mensajes, se sale del for.
                    if (msg == null)
                        break;
                    if (CheckBox1.Checked)
                        cola.DeleteMessage(msg);

                    Label1.Text += msg.AsString + " - " +
                                   msg.InsertionTime.Value.LocalDateTime.ToLongTimeString() + 
                                   "<br />";
                }
                Label1.Text += "Procesados: " + (i - 1);
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
            if (cola.ApproximateMessageCount.Value != null)
                Label1.Text = "Mensajes pendientes: " + cola.ApproximateMessageCount.Value;
            else
                Label1.Text = "Mensajes pendientes: 0"; 
        }
    }
}
