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

        //Instancia del TableAdapter
        NWDataSetTableAdapters.CategoriesTableAdapter taCat =
            new NWDataSetTableAdapters.CategoriesTableAdapter();
        
        //Usando Dataset
        ////Instancia del DataSet
        //NWDataSet ds = new NWDataSet();
        ////Cargamos los datos
        //taCat.LlenarTabla(ds.Categories);

        ////Enlazamos el DropDownList a la tabla.
        //DropDownList3.DataSource = ds.Categories;
        
        //Usando Llenar pero SIN Dataset
        //NWDataSet.CategoriesDataTable tCat = new NWDataSet.CategoriesDataTable();
        //taCat.LlenarTabla(taCat);
        ////Enlazamos el DropDownList a la tabla.
        //DropDownList3.DataSource = taCat;

        //Usando Obtener con variable para la tabla
        //NWDataSet.CategoriesDataTable taCat = taCat.ObtenerTabla();
        ////Enlazamos el DropDownList a la tabla.
        //DropDownList3.DataSource = taCat;

        //Usando Llenar directamente sobre el DataSource
        DropDownList3.DataSource = taCat.ObtenerTabla();

        //Asignamos las columnas visible y de valor
        DropDownList3.DataTextField = "CategoryName";
        DropDownList3.DataValueField = "CategoryID";
        DropDownList3.DataBind();
        DropDownList3_SelectedIndexChanged(null, null);
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Cuando cambie modificaremos el contenido de la grid
        //Cuando no hay ninguno seleccionado valor -1
        if (DropDownList3.SelectedIndex != -1)
        {
            NWDataSetTableAdapters.ProductsTableAdapter taProd;
            taProd = new NWDataSetTableAdapters.ProductsTableAdapter();

            //Otro método para no cargar todas las tablas
            GridView3.DataSource=taProd.ObtenerTablaPorCategoryID(int.Parse(DropDownList3.SelectedValue));
            GridView3.DataBind();
        }
    }
}