﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    [ServiceBehavior(Name = "MiServicioWCF")]
    public class Service1 : IService1, IMiServicioWCF2 
    {
        public string GetData(int value)
        {
            //            return string.Format("You entered: {0}", value);
            return "Has enviado el " + value;
        }

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}


        public string Fecha()
        {
            return Fecha(enumTipoFecha.Completa);
        }

        public string Fecha(enumTipoFecha tipoFecha)
        {
            switch (tipoFecha)
            {
                case enumTipoFecha.Larga:
                    return DateTime.Now.ToLongDateString();
                case enumTipoFecha.Corta:
                    return DateTime.Now.ToShortDateString();
                //Esto que hay abajo se puede hacer porque no hay nada entre case y default
                //No puede haber ni siquiera un comentario.
                case enumTipoFecha.Completa:
                default:
                    return DateTime.Now.ToString();
            }
        }

        public string NombreCategoria(int id)
        {
            using (NwDataSetTableAdapters.CategoriesTableAdapter taCat =
                   new NwDataSetTableAdapters.CategoriesTableAdapter())
            {
                return taCat.NombreCategoria(id);
            }
        }

        //public NwDataSet.CategoriesRow Categoria(int id)
        //{
        //    using (NwDataSetTableAdapters.CategoriesTableAdapter taCat =
        //           new NwDataSetTableAdapters.CategoriesTableAdapter())
        //    {
        //        return ""; // taCat.FillByCategoryID(NwDataSet.CategoriesDataTable, Categoria, id);
        //    }
        //}


        public NwDataSet.CategoriesDataTable Categoria(int id)
        {
            using (NwDataSetTableAdapters.CategoriesTableAdapter taCat =
                   new NwDataSetTableAdapters.CategoriesTableAdapter())
            {
                //Vamos a optimizar para no instanciar todas las tablas del DataSet
                return taCat.GetDataByCategoryID(id);
            }
        }


        public Categoria Categoria2(int id)
        {
            //Tabla con las categorias 1 o ninguna
            var tCat = Categoria(id);
            var cat = (from c in tCat
                       select new Categoria
                       {
                           IdCategoria = c.CategoryID,
                           NombreCategoria = c.CategoryName,
                           Descripcion = c.Description
                       }).SingleOrDefault();
            //cat era un IEnumerable antes de añadirle .SingleOrDefault
            //Al poner el SingleOrDefault se convierte a una instancia de la clase categoria
            return cat;
        }

        public Categoria CategoriaConectado(int id)
        {
            using (System.Data.SqlClient.SqlConnection cnn =
                   new System.Data.SqlClient.SqlConnection())
            {
                cnn.ConnectionString = System.Configuration
                                             .ConfigurationManager
                                             .ConnectionStrings["northwindConnectionString"].ConnectionString;
                System.Data.SqlClient.SqlCommand cmd;
                cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Categories WHERE CategoryID = " + id;
                cnn.Open();
                var dr = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                Categoria c = null;
                if (dr.Read())   //(dr.HasRows) Porque solo va a haber un registro
                {
                    c = new Categoria();
                    c.IdCategoria = (int)dr["CategoryID"];
                    c.NombreCategoria = dr["CategoryName"].ToString();
                    c.Descripcion = dr["Description"].ToString();
                }
                return c;
            }
        }


        public List<Categoria> Categorias()
        {
            using (NwDataSetTableAdapters.CategoriesTableAdapter taCat =
                   new NwDataSetTableAdapters.CategoriesTableAdapter())
            {
                //Vamos a optimizar para no instanciar todas las tablas del DataSet
                return taCat.GetData()
                        .Select(c => new Categoria()
                        {
                            IdCategoria = c.CategoryID,
                            NombreCategoria = c.CategoryName,
                            Descripcion = c.Description
                        }).ToList<Categoria>();
                //lo mismo en LINQ
                /*                return (from c in taCat.GetData()
                                       select new Categoria()
                                                               {
                                                                   IdCategoria = c.CategoryID,
                                                                   NombreCategoria = c.CategoryName,
                                                                   Descripcion = c.Description
                                                               }).ToList<Categoria>();*/
            }
        }


        public List<Categoria> CategoriasConectado(bool IncluyeDescripcion)
        {
            using (System.Data.SqlClient.SqlConnection cnn =
                   new System.Data.SqlClient.SqlConnection())
            {
                cnn.ConnectionString = System.Configuration
                                             .ConfigurationManager
                                             .ConnectionStrings["northwindConnectionString"].ConnectionString;
                System.Data.SqlClient.SqlCommand cmd;
                cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT CategoryID, CategoryName" +
                    (IncluyeDescripcion ? ", Description" : "") +
                    " FROM Categories";
                cnn.Open();
                var dr = cmd.ExecuteReader();
                List<Categoria> categs = new List<ServicioWCF.Categoria>();
                Categoria c = null;
                while (dr.Read())
                {
                    c = new Categoria();
                    c.IdCategoria = (int)dr["CategoryID"];
                    c.NombreCategoria = dr["CategoryName"].ToString();
                    if (IncluyeDescripcion)
                        c.Descripcion = dr["Description"].ToString();

                    categs.Add(c);
                }
                return categs;
            }
        }

        public NwDataSet.ProductsDataTable Productos()
        {
            return Productos(-1);
        }

        //Parámetro opcional se inicializa con valor -1
        //El parametro es Opcional DENTRO del servicio, pero en el cliente lo genera
        //como obligatorio. El -1 es para que cargue TODOS los productos.

        public NwDataSet.ProductsDataTable Productos(int IdCategoria = -1)
        {
            using (NwDataSetTableAdapters.ProductsTableAdapter taProd =
                   new NwDataSetTableAdapters.ProductsTableAdapter())
            {
                if (IdCategoria == -1)
                    //Vamos a optimizar para no instanciar todas las tablas del DataSet
                    return taProd.GetData();
                else
                    return taProd.GetDataByCategoryID(IdCategoria);
            }
        }

        public List<string> ClientesConPedido()
        {
            using (northwindEntities contexto =
                new northwindEntities())
            {
                //var lista = (from c in contexto.Orders
                //             orderby c.CustomerID
                //             select c.CustomerID).Distinct();
                ////La devolución tiene que ser una lista.
                ////Asegurarse que la lista está leida, porque el Entity se perderá
                ////Por eso ponemos el ToList()
                //return lista.ToList();

                //Usando (Métodos de extensión)
                return contexto.Orders
                               .Select(o => o.CustomerID)
                               .Distinct()
                               .OrderBy(c => c)
                               .ToList();
            }
        }


        public List<Order> PedidosPorCliente(string IdCliente)
        {
            using (northwindEntities contexto =
                new northwindEntities())
            {
                //No sigue las propiedades de navegación
                contexto.ContextOptions.LazyLoadingEnabled = false;
                if (IdCliente == null)
                    return contexto.Orders.ToList();
                else
                    return contexto.Orders
                                   .Where(o => o.CustomerID == IdCliente)
                                   .ToList();
            }
        }


        public List<Order_Detail> DetallesPedido(int IdPedido)
        {
            using (northwindEntities contexto =
                new northwindEntities())
            {
                //No sigue las propiedades de navegación
                contexto.ContextOptions.LazyLoadingEnabled = false;
                if (IdPedido== null)
                    return contexto.Order_Details.ToList();
                else
                    return contexto.Order_Details
                                   .Where(o => o.OrderID == IdPedido)
                                   .ToList();
            }
        }


        public Order Pedido(int IdPedido)
        {
            using (northwindEntities contexto =
                new northwindEntities())
            {
                //No sigue las propiedades de navegación
                contexto.ContextOptions.LazyLoadingEnabled = false;

                try
                {
                    return contexto.Orders.Where(o => o.OrderID == IdPedido).Single();
                }
                catch (Exception ex)
                {
                    throw new FaultException(ex.Message);
                }
            }
        }

        public Order PedidoConErrorGeneral(int IdPedido)
        {
            using (northwindEntities contexto =
                new northwindEntities())
            {
                //No sigue las propiedades de navegación
                contexto.ContextOptions.LazyLoadingEnabled = false;

                try
                {
                    return contexto.Orders.Where(o => o.OrderID == IdPedido).Single();
                }
                catch (Exception ex)
                {
                    ClaseErrorGeneral ceg = new ClaseErrorGeneral();
                    ceg.Operacion = "PedidoConErrorGeneral";
                    ceg.Mensaje = ex.Message;
                    if (ex is InvalidOperationException)
                        ceg.ExcepcionEnServicio = ex as InvalidOperationException;
                        
                    FaultException<ClaseErrorGeneral> fe;
                    fe = new FaultException<ClaseErrorGeneral>(ceg, "Id de pedido no encontrado");
                        
                    throw fe;
                }
            }
        }

        public string FechayHora()
        {
            return DateTime.Now.ToString();
        }

        //string IMiServicioWCF2.FechayHora()
        //{
        //    throw new NotImplementedException();
        //}

        //string IMiServicioWCF2.Fecha(enumTipoFecha tipoFecha)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
