using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClienteWCF.ProxyWCF;

namespace ClienteWCF
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Clase creada en el cliente del servicio
            ProxyWCF.MiServicioWCFClient s = new ProxyWCF.MiServicioWCFClient();
            //Si el contenido de la caja de texto no es entero petará
            Label1.Text = s.GetData(int.Parse(TextBox1.Text));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                Label2.Text = s.Fecha();

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                if (RadioButton1.Checked)
                    Label3.Text = s.FechaConTipo(enumTipoFecha.Larga);
                else
                    if (RadioButton2.Checked)
                        Label3.Text = s.FechaConTipo(enumTipoFecha.Corta);
                    else
                        if (RadioButton3.Checked)
                            Label3.Text = s.FechaConTipo(enumTipoFecha.Completa);
                        else
                            Label3.Text = "Seleccione tipo...";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                string cad = s.NombreCategoria(int.Parse(TextBox2.Text));
                if (!string.IsNullOrWhiteSpace(cad))
                    Label4.Text = cad;
                else
                    Label4.Text = "<i>Categoría inexistente</i>";
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                //Esto traerá o 1 o ninguna fila
                var tCat = s.Categoria(int.Parse(TextBox3.Text));
                ProxyWCF.NwDataSet.CategoriesRow fila;
                /* //Sin usar LINQ
                   if (tCat.Rows.Count > 0)
                   {
                       //primer metodo usando Rows[0]
                       fila = tCat.Rows[0] as ProxyWCF.NwDataSet.CategoriesRow;
                       Label5.Text = "<b>" + fila.CategoryName + 
                                     "</b> - " + fila.Description;
                   }
                   else
                       Label5.Text = "<i>Categoría inexistente</i>"; */
                //Usando LINQ
                fila = tCat.SingleOrDefault();
                if (fila != null)
                {
                    Label5.Text = "<b>" + fila.CategoryName +
                                  "</b> - " + fila.Description;
                }
                else
                    Label5.Text = "<i>Categoría inexistente</i>";

            }

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                var c = s.Categoria2(int.Parse(TextBox3.Text));
                if (c != null)
                {
                    Label5.Text = "<b>" + c.NombreCategoria +
                                  "</b> - " + c.Descripcion;
                }
                else
                    Label5.Text = "<i>Categoría inexistente</i>";
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                var c = s.CategoriaConectado(int.Parse(TextBox3.Text));
                if (c != null)
                {
                    Label5.Text = "<b>" + c.NombreCategoria +
                                  "</b> - " + c.Descripcion;
                }
                else
                    Label5.Text = "<i>Categoría inexistente</i>";
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                DropDownList1.DataSource = s.Categorias();
                DropDownList1.DataTextField = "NombreCategoria";
                DropDownList1.DataValueField = "IdCategoria";
                DropDownList1.DataBind();
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                DropDownList1.DataSource = s.CategoriasConectado(false);
                DropDownList1.DataTextField = "NombreCategoria";
                DropDownList1.DataValueField = "IdCategoria";
                DropDownList1.DataBind();
            }
        }
    }
}