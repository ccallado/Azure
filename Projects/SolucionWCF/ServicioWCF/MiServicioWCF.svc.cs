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
    }
}
