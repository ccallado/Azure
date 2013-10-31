using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Datos1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(ViewAccess); 
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(ViewSql); 
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(ViewDataset);
        
        //Este no el modo normal de utilizarlo, porque en cuanto instancio
        //un DataSet automáticamente me instancia todas las tablas de las que está
        //compuesto y ocupa recursos en exceso.
        //Instancia del DataSet
        NWDataSet ds = new NWDataSet();
        //Instancia del TableAdapter
        NWDataSetTableAdapters.CategoriesTableAdapter taCat =
            new NWDataSetTableAdapters.CategoriesTableAdapter();
        //Cargamos los datos
        taCat.LlenarTabla(ds.Categories);

        //Enlazamos el DropDownList a la tabla.
        DropDownList3.DataSource = ds.Categories;
        //Asignamos las columnas visible y de valor
        DropDownList3.DataTextField = "CategoryName";
        DropDownList3.DataValueField = "CategoryID";
        DropDownList3.DataBind();
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Cuando cambie modificaremos el contenido de la grid

    }
}