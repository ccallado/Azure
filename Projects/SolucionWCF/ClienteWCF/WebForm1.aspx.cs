using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClienteWCF.ProxyWCF;

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
            //Si el contenido de la caja de texto no es entero petará
            Label1.Text = s.GetData(int.Parse(TextBox1.Text));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                Label2.Text = s.Fecha();

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                if (RadioButton1.Checked)
                    Label3.Text = s.FechaConTipo(enumTipoFecha.Larga);
                else
                    if (RadioButton2.Checked)
                        Label3.Text = s.FechaConTipo(enumTipoFecha.Corta);
                    else
                        if (RadioButton3.Checked)
                            Label3.Text = s.FechaConTipo(enumTipoFecha.Completa);
                        else
                            Label3.Text = "Seleccione tipo...";
            }
        }
    }
}