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
        //Compruebo si las llamadas son en asincrono
        bool asincrono = ScriptManager1.IsInAsyncPostBack;

        //Al cargar la página pongo la hora.
        //No se actualizará hasta que carge de nuevo la página

        Label2.Text = DateTime.Now.ToLongDateString();
        Label3.Text = "hora: <i>" + DateTime.Now.ToLongTimeString() + "</i>";
        Label4.Text = "Sesiones: " + Application["Sesiones"];

        //Autenticación
        Label5.Text = "Usuario: " + 
            (Page.User.Identity.IsAuthenticated ?
            Page.User.Identity.Name + " <i>(" + Page.User.Identity.AuthenticationType + ")</i>":
            "<i>No autenticado...</i>");

        string ms = Session["MapaSitio"] as string;
        if (ms != null)
        { 
            if (ms == "Menu")
            {
                if (!Page.IsPostBack)
                {
                    RadioButton1.Checked = true;
                    Menu1.Visible = true;
                    TreeView1.Visible = false;
                }
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    RadioButton2.Checked = true;
                    Menu1.Visible = false;
                    TreeView1.Visible = true;
                }
            }
        }
        else
        {
            Menu1.Visible = false;
            TreeView1.Visible = false;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //Fuerza el cierre de sesión
        Session.Abandon();
        Response.Redirect("https://www.google.es");
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        Menu1.Visible = true;
        TreeView1.Visible = false;
        Session["MapaSitio"] = "Menu";
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        Menu1.Visible = false;
        TreeView1.Visible = true;
        Session["MapaSitio"] = "Treeview";
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        Label2.Text = DateTime.Now.ToShortTimeString();
    }
}
