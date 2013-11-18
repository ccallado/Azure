using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWCF
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (ProxyPerCall.ServicioPerCallClient s =
                new ProxyPerCall.ServicioPerCallClient())
            {
                for (int i = 1; i <= 3; i++)
                {
                    Label1.Text += s.IncrementaContador() + "<br />";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label2.Text = "Using 1 <br />";
            using (ProxyPerSession.ServicioPerSessionClient s =
                new ProxyPerSession.ServicioPerSessionClient())
            {
                for (int i = 1; i <= 3; i++)
                {
                    Label2.Text += s.IncrementaContador() + "<br />";
                }
            }

            Label2.Text += "<br />Using 2 <br />";

            using (ProxyPerSession.ServicioPerSessionClient s =
                new ProxyPerSession.ServicioPerSessionClient())
            {
                for (int i = 1; i <= 3; i++)
                {
                    Label2.Text += s.IncrementaContador() + "<br />";
                }
            }
        }
    }
}