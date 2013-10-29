using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Al cargar la página pongo la hora.
        //No se actualizará hasta que carge de nuevo la página

        Label2.Text = DateTime.Now.ToLongDateString();
        Label3.Text = "hora: <i>" + DateTime.Now.ToLongTimeString() + "</i>";
        Label4.Text = "Sesiones: " + Application["Sesiones"];
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //Fuerza el cierre de sesión
        Session.Abandon();
        Response.Redirect("https://www.google.es");
    }
}
