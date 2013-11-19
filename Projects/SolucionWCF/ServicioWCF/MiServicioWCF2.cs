using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ServicioWCF
{
    [ServiceContract]
    public interface IMiServicioWCF2
    {
        [OperationContract]
        string FechayHora();

        [OperationContract(Name = "FechaConTipo")]
        string Fecha(enumTipoFecha tipoFecha);
    }
}
