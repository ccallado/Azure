using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract(Name="IMiServicioWCF")]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: agregue aquí sus operaciones de servicio

        //Método que va a devolver una string
        [OperationContract]
        string Fecha();

        //Creamos una sobrecarga del método, va a devolver una string 
        //pero con una enumeración
        [OperationContract(Name="FechaConTipo")]
        string Fecha(enumTipoFecha tipoFecha);

        [OperationContract]
        string NombreCategoria(int id);

        [OperationContract]
        //como CategoriesRow no puedo serializarlo
        //Primera solución mandamos una tabla sabiendo que solo hay una
        NwDataSet.CategoriesDataTable Categoria(int id);

        [OperationContract]
        Categoria Categoria2(int id);

        [OperationContract]
        Categoria CategoriaConectado(int id);

        [OperationContract]
        List<Categoria> Categorias();

        [OperationContract]
        List<Categoria> CategoriasConectado(bool IncluyeDescripcion);

    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
