using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PlaceHolder1.Controls.Add(new Literal(){ Text="Hola...<br>"});
        PlaceHolder1.Controls.Add(new Literal(){ Text="Hola...<br>"});
        PlaceHolder1.Controls.Add(new Literal(){ Text="Hola...<br>"});
    }

}