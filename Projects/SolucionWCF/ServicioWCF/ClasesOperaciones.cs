using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWCF
{
  public class ClaseOperaciones
  {
    public int Contador;
    
    DateTime _Creacion;
    public DateTime Creacion
    {
      get { return _Creacion; }
      //set { _Creacion = value; }
    }
    public ClaseOperaciones()
    {
      Contador = 0;
      _Creacion = DateTime.Now;
    }
    
    public string IncrementaContador()
    {
      
    }
  }
}
