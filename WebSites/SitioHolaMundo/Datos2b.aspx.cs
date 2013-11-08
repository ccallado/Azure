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
        Label3.Text = "";
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
            Panel1.Visible = false;
        }
        //else
        //    Panel1.Visible = true;
    }

    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
        Panel1.Visible = false;
    }

    protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //string cad = "";

        ////Hay que especificar el tipo  System.Collections.DictionaryEntry
        ////Valores antiguos
        //foreach (System.Collections.DictionaryEntry x in e.OldValues)
        //    cad += x.Key + "->>" +
        //           x.Value + " (" +
        //           x.Value.GetType() +
        //           ")    ";
        //cad = "";
        ////Valores actuales
        //foreach (System.Collections.DictionaryEntry x in e.NewValues )
        //    cad += x.Key + "->>" +
        //           x.Value + " (" +
        //           x.Value.GetType() +
        //           ")    ";
        //cad = "";
        ////Keys
        //foreach (System.Collections.DictionaryEntry x in e.Keys )
        //    cad += x.Key + "->>" +
        //           x.Value + " (" +
        //           x.Value.GetType() +
        //           ")    ";
        //cad = "";

        //Soluciono el posible problema del precio y del descuento...
        //Viene el signo del €uro

        decimal precio;
        bool precioOk = decimal.TryParse(e.NewValues["UnitPrice"].ToString(),
                                         System.Globalization.NumberStyles.Currency,
                                         System.Globalization.CultureInfo.CurrentCulture,
                                         out precio);
        Single descuento;
        bool descuentoOk;
        if (e.NewValues["Discount"].ToString().Contains("%"))
        {
            descuentoOk = Single.TryParse(e.NewValues["Discount"].ToString().Replace("%", ""),
                                           System.Globalization.NumberStyles.Float,
                                           System.Globalization.CultureInfo.CurrentCulture,
                                           out descuento);
            descuento /= 100;
        }
        else
            descuentoOk = Single.TryParse(e.NewValues["Discount"].ToString(),
                                           System.Globalization.NumberStyles.Float,
                                           System.Globalization.CultureInfo.CurrentCulture,
                                           out descuento);
        if (precioOk && descuentoOk)
        {
            e.OldValues["UnitPrice"] = decimal.Parse(e.OldValues["UnitPrice"].ToString(),
                                                     System.Globalization.NumberStyles.Currency);
            e.OldValues["Discount"] = Single.Parse(e.OldValues["Discount"].ToString().Replace("%", ""));
            e.NewValues["UnitPrice"] = precio;
            e.NewValues["Discount"] = descuento;
        }
        else
        {
            Label3.Text = (!precioOk ? "Precio incorrecto<br />" : "");
            Label3.Text += (!descuentoOk ? "Descuento incorrecto" : "");
            e.Cancel = true;
        }
    }

    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        e.Values["UnitPrice"] = decimal.Parse(e.Values["UnitPrice"].ToString(), System.Globalization.NumberStyles.Currency);
        string d = e.Values["Discount"].ToString().Replace("%", "");
        e.Values["Discount"] = Single.Parse(d) / 100;
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label2.Text = GridView1.SelectedRow.Cells[1].Text;
        Panel1.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        using (northwindModel.northwindEntities contexto =
            new northwindModel.northwindEntities())
        {
            northwindModel.Order_Detail od = new northwindModel.Order_Detail();
            od.OrderID = int.Parse(Label2.Text);
            od.ProductID = int.Parse(TextBox1.Text);
            od.UnitPrice = decimal.Parse(TextBox2.Text);
            od.Quantity = short.Parse(TextBox3.Text);
            od.Discount = Single.Parse(TextBox4.Text);

            contexto.Order_Details.AddObject(od);

            //Para grabar todo lo que esté pendiente
            contexto.SaveChanges();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            GridView3.DataBind();
            //var mio = GridView1.SelectedIndex;
            //GridView1.SelectedIndex = -1;
            //GridView1.SelectedIndex = mio;
            //            GridView1_SelectedIndexChanged(null, null);
        }
    }
}