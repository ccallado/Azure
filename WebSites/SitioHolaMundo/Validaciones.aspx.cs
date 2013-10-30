using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Validaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
            Response.Redirect("~/Inicio.aspx");
    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {
        TextBox5.Text = TextBox5.Text.ToUpper();
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //La validación en cliente  será:
        //Contenido de la caja de texto entre cinco y diez caracteres.
        //La validación en servidor será:
        //El contenido de la caja sea PROFE o CURSO
        if (args.Value == "PROFE" || args.Value == "CURSO")
            args.IsValid = true;
        else
            args.IsValid = false;
    }
}