using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Estado1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Text = "Vuelta: ";
        if (!Page.IsPostBack)
        {
            HiddenField1.Value = "1";
         }
        else 
        {
            int x = int.Parse(HiddenField1.Value);
            x++;
            HiddenField1.Value = x.ToString();
        }
        Label4.Text += HiddenField1.Value;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() != "")
            Label1.Text = TextBox1.Text;

        if (TextBox2.Text.Trim() != "")
            Label2.Text = TextBox2.Text;
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        if (TextBox3.Text.Trim() != "")
            Label3.Text = TextBox3.Text;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        HttpCookie c = new HttpCookie("CookieSimple", TextBox4.Text );
        Response.Cookies.Add(c);
        Response.Redirect("~/Estado2.aspx");
        //Server.Transfer("~/Estado2.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        HttpCookie c = new HttpCookie("CookieCompuesta");
        c.Values.Add("DatoCaja", TextBox5.Text);
        c.Values.Add("Fecha", DateTime.Now.ToString());

        Response.Cookies.Add(c);
        Response.Redirect("~/Estado2.aspx");
        //Server.Transfer("~/Estado2.aspx");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        HttpCookie c = new HttpCookie("CookiePermanente", TextBox6.Text);
        //Hago caducar la cookie es de tipo datetime
        c.Expires = DateTime.Now.AddMinutes(1);
        Response.Cookies.Add(c);
        Response.Redirect("~/Estado2.aspx");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        HttpCookie cp = new HttpCookie("CookiePermanente", TextBox6.Text);
        cp.Expires = DateTime.Now.AddYears(-1);
        //Mando la página
        Response.Cookies.Add(cp);
        Response.Redirect("~/Estado2.aspx");
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        string cad = "";
        if (TextBox7.Text.Trim() != "")
            //Ojo no poner espacios
            //Metodo del objeto Server UrlEncode codifica el QueryString para todos los caracteres especiales.
            cad = "?DatoCaja=" + Server.UrlEncode(TextBox7.Text);
        Response.Redirect("~/Estado2.aspx" + cad);
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        if (TextBox8.Text.Trim() != "")
            //Esto es un Diccionario de objetos que se mantendrá abierto en la ejecución de la aplicación
            Session["DatoSesion"] = TextBox8.Text;
        else
            Session.Remove("DatoSesion");
        Response.Redirect("Estado2.aspx");
    }
}