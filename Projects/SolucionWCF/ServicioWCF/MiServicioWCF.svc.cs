using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    [ServiceBehavior(Name="MiServicioWCF")]
    public class Service1 : IService1
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
            throw new NotImplementedException();
        }
    }
}
