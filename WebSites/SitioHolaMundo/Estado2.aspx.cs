using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Estado2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Cookie Simple
        HttpCookie cs = Request.Cookies["CookieSimple"];
        if (cs != null)
            Label1.Text = "Cookie Simple: <i>" + cs.Value + "</i>";
        else
            Label1.Text = "No hay Cookie Simple";

        //CookieCompuesta
        HttpCookie cc = Request.Cookies["CookieCompuesta"];
        if (cc != null)
        {
            string dc = cc.Values["DatoCaja"];
            Label2.Text = "Cookie Compuesta: <i>" +
                        (!string.IsNullOrWhiteSpace(dc) ? dc : "sin dato...") + "</i>";
            string f = cc.Values["Fecha"];
            DateTime fecha = DateTime.Parse(f);
            Label2.Text += " (" + fecha.ToLongTimeString() +
                           " del " + fecha.ToLongDateString() + ")";
        }
        else
            Label2.Text = "No hay Cookie Compuesta";

        //Cookie Permanente
        HttpCookie cp = Request.Cookies["CookiePermanente"];
        if (cp != null)
            Label3.Text = "Cookie Permanente: <i>" + cp.Value + "</i>";
        else
            Label3.Text = "No hay Cookie Permanente";

        //QueryString
        Label4.Text = "QueryString (" + Request.QueryString.Count + " datos):";

        if (Request.QueryString.Count > 0)
        {
            string dcqs = Request.QueryString["DatoCaja"];
            if (dcqs != null)
                Label4.Text += "&nbsp;&nbsp;DatoCaja = <i>" + dcqs + "</i>";
            else
                Label4.Text += "&nbsp;&nbsp;No hay DatoCaja";
        }
    }
}