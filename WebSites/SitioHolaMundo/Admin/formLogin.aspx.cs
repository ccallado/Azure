using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class formLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = "";
        //Cargamos los datos
        if (!Page.IsPostBack)
        {
            Label1.Text = "Profesor: " + System.Configuration.ConfigurationManager.AppSettings["Profesor"];
            Label1.Text += "<br />Alumno: " + System.Configuration.ConfigurationManager.AppSettings["Alumno"];
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "cursoAux" && TextBox2.Text == "cursoAux")
        {
            //Vamos a hacer que se mande una cookie de seguridad al servidor.
            //Hay que usar un método estatico de un objeto especial.
            System.Web.Security.FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, false);
        }
        else
            Label2.Text = "Usuario y/o password incorrectos...";
    }
}