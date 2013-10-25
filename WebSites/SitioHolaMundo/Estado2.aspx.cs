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
        //Recupero la información de la petición
        HttpCookie cs = Request.Cookies["CookieSimple"];
        if (cs != null)
            Label1.Text = "Cookie Simple: <i>" + cs.Value + "<i>";
        else
            Label1.Text = "No hay Cookie Simple";
    }
}