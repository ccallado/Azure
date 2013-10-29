using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "Hola, mundo...!";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/Default2.aspx");
        //Esta NO porque es externa
        //Server.Transfer("https://www.google.es");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default2.aspx");
        //Aquí SI aunque sea externa
        //Response.Redirect("https://www.google.es");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        int x, y;

        x = int.Parse(TextBox1.Text);
        y = int.Parse(TextBox2.Text);
        int res = x / y;
        Label2.Text = "División entera: " + res;
    }

    protected void Page_Error(object sender, EventArgs e)
    {
    //    Exception ex = Server.GetLastError();
    //    //string cad = "Excepción: " + ex.GetType() + 
    //    //             "<br />" + ex.Message;

    //    Session["Error"] = ex;
    //    //Llamo a la página de errores
    //    Server.Transfer("PaginaErrores.aspx");
    }
}