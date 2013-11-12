using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CreaUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Esto podría valer si pusiesemos un QueryString para que se inicie con el primer
        //View del Multiview de creación de usuario
        //if (Page.ClientQueryString["N"] = "T")
        //    CreateUserWizard1.ActiveStepIndex = 0;
    }
}