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
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(ViewEntity); 

        //Varios métodos

        //Crear el objeto del modelo
        northwindModel.northwindEntities contexto;
        contexto = new northwindModel.northwindEntities();

        //TODA la tabla de SQL directamente en el contenedor de entidades...
        //DropDownList4.DataSource = contexto.Categories; //Se considera internamente como una consulta

        //TODA la tabla de SQL con consulta LINQ...
        //var categorias = from cat in contexto.Categories
        //                 select cat;
        //DropDownList4.DataSource = categorias;

        //Sólo los campos que necesitamos con consulta LINQ en clase definida por nosotros...
        //Usando una clase
        //var categorias = from cat in contexto.Categories
        //                 select new CategoriaBase() 
        //                 {
        //                     CategoryID = cat.CategoryID,
        //                     CategoryName = cat.CategoryName 
        //                 };

        //DropDownList4.DataSource = categorias;

        //Sólo los campos que necesitamos con consulta LINQ en tipo anónimo...
        var categorias = from cat in contexto.Categories
                         select new 
                         {
                             cat.CategoryID,
                             cat.CategoryName
                         };

        DropDownList4.DataSource = categorias;

        //Asignamos las columnas visible y de valor
        DropDownList4.DataTextField = "CategoryName";
        DropDownList4.DataValueField = "CategoryID";
        //Ejecutamos físicamente la consulta
        DropDownList4.DataBind();
        DropDownList4_SelectedIndexChanged(null, null);
    }

    public class CategoriaBase
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Cuando cambie modificaremos el contenido de la grid
        //Cuando no hay ninguno seleccionado valor -1
        if (DropDownList4.SelectedIndex != -1)
        {
            //Usando using no tiene nada que ver los de cabecera.
            //Saliendo del using se destruyen los datos.
            //Llamando al metodo .Dispose()
            using(northwindModel.northwindEntities contexto = 
                new northwindModel.northwindEntities())
            {
                int cat = int.Parse(DropDownList4.SelectedValue);
                //Usando consulta de LINQ
                //var productos = from p in contexto.Products
                //                where p.CategoryID == cat
                //                select p;
                ////No puedo usar p.CategoryID == int.Parse(DropDownList4.SelectedValue)
                ////el int.Parse lo hago fuera de LINQ en una variable y ya funciona.

                //Usando Método de extensión sobre el conjunto de entidades
                var productos = contexto.Products.Where(p => p.CategoryID == cat);
                //Esto lo filtra en la consulta no se trae todo hace lo mismo que el de arriba
                //En este formato todavía podemos seguir poniendo puntos (). ya que es un objeto
                //IQueryable

                GridView4.DataSource = productos;
                GridView4.DataBind();
            }
        }
    }
    protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(ViewValidaciones); 

    }
}