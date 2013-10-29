using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaginaErrores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Evitamos que de error si no está creado y se llega a esta página desde la barra de direcciones.
        Exception ex = Session["Error"] as Exception ;
        Label1.Text = "";
        Label2.Text = "";

        if (ex != null)
        {
            if (ex is HttpUnhandledException)
            {
                Label1.Text = "<b>Error a nivel de APLICACIÓN.</b><br/>";
                ex = ex.GetBaseException(); 
            }
            Label1.Text += ex.GetType().ToString();
            Label2.Text = ex.Message;
            Session.Remove("Error");
        }
        else
            Label1.Text = "Página NO accesible...";
    }
}