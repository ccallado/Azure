using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWCF
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Clase creada en el cliente del servicio
            ProxyWCF.MiServicioWCFClient s = new ProxyWCF.MiServicioWCFClient();
            //Si el contenido de la caja de texto petará
            Label1.Text = s.GetData(int.Parse(TextBox1.Text));
        }
    }
}