using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Datos2b : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Recupero de Request la colección QueryString 
            string id = Request.QueryString["Id"];
            if (id == null)
                Label1.Text = "Id de cliente necesario...";
            else
            {
                using (northwindModel.northwindEntities contexto =
                    new northwindModel.northwindEntities())
                {
                    //Solo queremos una entidad (Cliente)
                    //var cliente = contexto.Customers
                    //                      .Where(c => c.CustomerID == id)
                    //                      .SingleOrDefault();
                    //Más fácil podemos filtrar en el SingleOrDefault
                    var cliente = contexto.Customers
                        //.Where(c => c.CustomerID == id)
                                          .SingleOrDefault(c => c.CustomerID == id);
                    if (cliente == null)
                        Label1.Text = "Id de cliente no encontrado...";
                    else
                    {
                        Label1.Text = "<b>" + cliente.CompanyName +
                                      "</b> <i>" + cliente.ContactName + "</i>";
                    }
                }
            }
        }
    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
    }
}