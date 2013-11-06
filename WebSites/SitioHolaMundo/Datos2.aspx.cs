using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Datos2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "";
        Label2.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        using (northwindModel.northwindEntities contexto =
            new northwindModel.northwindEntities())
        {
            //Cojo la caja de texto y la prepara para LINQ
            string filtro = TextBox1.Text.Trim().ToUpper();

            //5 caracteres es el código del cliente
            if (filtro.Length == 5)
                GridView1.DataSource = contexto.Customers.Where(c => c.CustomerID == filtro);
            else
                if (filtro.Length > 0)
                    GridView1.DataSource = contexto.Customers.Where(c => c.CustomerID.StartsWith(filtro.Substring(0, 4)));
                else
                    GridView1.DataSource = contexto.Customers;
            GridView1.DataBind();
            GridView1.SelectedIndex = -1;

            //Hago un cast para convertirlo en colección y ya puedo contarlo
            int cant = ((IEnumerable<northwindModel.Customer>)GridView1.DataSource).Count();
            Label1.Text = "Cantidad: <i>" + cant + "</i>";
        }

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
            Response.Redirect("~/Datos2b.aspx?Id=" + GridView1.SelectedRow.Cells[1].Text);
        else
            Label2.Text = GridView1.SelectedRow.Cells[2].Text + " <i>(" + 
                          GridView1.SelectedRow.Cells[6].Text + ")</i>";
    }
}