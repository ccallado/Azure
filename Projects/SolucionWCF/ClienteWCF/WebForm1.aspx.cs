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
            //Actualizo la Grid
            //DropDownList1_SelectedIndexChanged(null, null);
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                DropDownList1.DataSource = s.CategoriasConectado(false);
                DropDownList1.DataTextField = "NombreCategoria";
                DropDownList1.DataValueField = "IdCategoria";
                DropDownList1.DataBind();
                //GridView1.DataSource = s.Productos(-1);
                //GridView1.DataBind();
                //Se puede decir que la pagina actualice todos los binding
                //Page.DataBind();
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                GridView1.DataSource = s.Productos();
                GridView1.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                GridView1.DataSource = s.ProductosPorCategoria(int.Parse(DropDownList1.SelectedValue));
                GridView1.DataBind();
            }
        }

        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {
            //Actualizo la Grid
            DropDownList1_SelectedIndexChanged(null, null);
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Button3_Click(null, null);
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Button3_Click(null, null);
        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Button3_Click(null, null);
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                DropDownList2.DataSource = s.ClientesConPedido();
                DropDownList2.DataBind();
            }
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                GridView2.DataSource = s.PedidosPorCliente(DropDownList2.SelectedValue);
                GridView2.DataBind();
                GridView2.SelectedIndex = -1;
                GridView3.DataSource = null;
                GridView3.DataBind();
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                GridView3.DataSource = s.DetallesPedido((int)GridView2.SelectedValue);
                GridView3.DataBind();
            }
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                try
                {
                    var Pedido = s.Pedido(int.Parse(TextBox4.Text));
                    Label6.Text = "Cliente: " + Pedido.CustomerID +
                                "<br />Fecha: " + Pedido.OrderDate.Value.ToLongDateString();
                }
                catch (System.ServiceModel.FaultException ex)
                {
                    Label6.Text = "Error de tipo " +
                                  ex.GetType() +
                                  "<br />Mensaje: " + ex.Message;
                }
                catch (Exception ex)
                {
                    Label6.Text = "Error de tipo " +
                                  ex.GetType() +
                                  "<br />Mensaje: " + ex.Message;
                }
            }
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            using (MiServicioWCFClient s = new MiServicioWCFClient())
            {
                try
                {
                    var Pedido = s.PedidoConErrorGeneral(int.Parse(TextBox4.Text));
                    Label6.Text = "Cliente: " + Pedido.CustomerID +
                                "<br />Fecha: " + Pedido.OrderDate.Value.ToLongDateString();
                }
                catch (System.ServiceModel.FaultException<ProxyWCF.ClaseErrorGeneral> ex)
                {
                    Label6.Text = "Error de tipo " +
                                  ex.GetType() +
                                  "<br />Mensaje: ";
                    ProxyWCF.ClaseErrorGeneral ceg = ex.Detail;
                    if (ceg != null)
                        Label6.Text += "<br />Operacion: " + ceg.Operacion +
                                       "<br />Mensaje: " +ceg.Mensaje;
                    if (ceg.ExcepcionEnServicio != null)
                        Label6.Text += "<br />Excepcion en Servicio: " + ceg.ExcepcionEnServicio.GetType()";
                        System.InvalidOperationException esc = ceg.ExcepcionEnServicio as System.InvalidOperationException;
                                       "<br />Mensaje: " + ceg.ExcepcionEnServicio.
                }
                catch (System.Exception ex)
                {
                    Label6.Text = "Error de tipo " +
                                  ex.GetType() +
                                  "<br />Mensaje: " + ex.Message;
                }
            }
        }
    }
}
