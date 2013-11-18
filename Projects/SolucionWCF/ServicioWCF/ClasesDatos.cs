using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//using System.ServiceModel; //para [OperationContract]
//using System.Runtime.Serialization; //para [DataMember]

namespace ServicioWCF
{
    //[OperationContract]
    public class Categoria
    {
        //Si defino esto en la clase del servicio
        //Al generar referencias del servicio en el cliente
        //Este cliente cojerá un get/set vacío, el método de filtrado no van a pasar al cliente.
        int _IdCategoria;
        //[DataMember]
        public int IdCategoria
        {
            get { return _IdCategoria; }
            set
            {
                if (value >= 0)
                    _IdCategoria = value;
                else
                    throw new ArgumentOutOfRangeException("IdCategoria",
                                                          value,
                                                          "El Id no puede ser negativo");
            }
        }
        //public int IdCategoria {get; set;}
        public string NombreCategoria {get; set;}
        public string Descripcion { get; set; }

        public string InfoCategoria()
        {
            return NombreCategoria + " (" + IdCategoria + ")";
        }

        public override string ToString()
        {
            return InfoCategoria() + " - " + Descripcion;
        }
    }
    
    public class ClaseErrorGeneral
    {
        public string Operacion {get; set;}
        public string Mensaje {get; set;}
        public InvalidOperationException ExcepcionEnServicio {get; set;}
        
    }
}
