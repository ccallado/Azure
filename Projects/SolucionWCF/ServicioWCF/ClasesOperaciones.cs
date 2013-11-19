using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWCF
{
    public class ClaseOperaciones
    {
        public int Contador;

        object objetoABloquear;

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

            //Instancio en el constructur la clase del objeto 
            //que voy a usar de flag para el bloqueo.
            objetoABloquear = new object();
        }

        public string IncrementaContador()
        {
            Contador++;
            System.Threading.Thread.Sleep(1000);
            return "Contador: " + Contador +
                " - Instancia: " + Creacion +
                " - Modificaci�n: " + DateTime.Now;
        }

        public string IncrementaContadorConBloqueo(int segundosParada)
        {
            #region SIN bloqueo... Este no nos vale porque se cruzan los incrementos
            //Contador++;
            //System.Threading.Thread.Sleep(1000 * segundosParada );
            //return "Contador: " + Contador +
            //    " - Instancia: " + Creacion +
            //    " - Modificaci�n: " + DateTime.Now;
            #endregion

            #region CON Interlocked... Este no nos vale porque solo bloquea la variable.
            ////Contador++;
            ////Solucionado el problema de bloqueo
            //System.Threading.Interlocked.Increment(ref Contador);
            ////Otros ejemplos de Interlocked
            ////System.Threading.Interlocked.Decrement (ref Contador);
            ////System.Threading.Interlocked.Add (ref Contador, 5);

            //System.Threading.Thread.Sleep(1000 * segundosParada);
            //return "Contador: " + Contador +
            //    " - Instancia: " + Creacion +
            //    " - Modificaci�n: " + DateTime.Now;
            #endregion

            #region con lock... Este bloquear� un bloque completo de c�digo.
            //lock (objetoABloquear)
            //{
            //    Contador++;
            //    System.Threading.Thread.Sleep(1000 * segundosParada);
            //    return "Contador: " + Contador +
            //        " - Instancia: " + Creacion +
            //        " - Modificaci�n: " + DateTime.Now;
            //}
            #endregion

            #region con el objeto Monitor
            ////Formato 1. Asumimos que el objeto PODREMOS bloquearlo siempre,
            ////           porque se queda en espera hasta que pueda bloquearlo...
            //System.Threading.Monitor.Enter(objetoABloquear);
            //try
            //{
            //    //C�digo bloqueado
            //    Contador++;
            //    System.Threading.Thread.Sleep(1000 * segundosParada);
            //    return "Contador: " + Contador +
            //        " - Instancia: " + Creacion +
            //        " - Modificaci�n: " + DateTime.Now;
            //}
            //finally
            //{
            //    // Esto se va a ejecutar SI o SI
            //    System.Threading.Monitor.Exit(objetoABloquear);
            //}

            //Formato 2. Asumimos que el objeto PODREMOS bloquearlo siempre,
            //           porque se queda en espera hasta que pueda bloquearlo...
            bool bloqueado = false;
            System.Threading.Monitor.TryEnter(objetoABloquear, 1500, ref bloqueado);
            try
            {
                if (bloqueado)
                {
                    //C�digo bloqueado
                    Contador++;
                    System.Threading.Thread.Sleep(1000 * segundosParada);
                    return "Contador: " + Contador +
                        " - Instancia: " + Creacion +
                        " - Modificaci�n: " + DateTime.Now;
                }
                throw new TimeoutException("No se pudo procesar la petici�n por Timeout...");
            }
            finally
            {
                if (bloqueado)
                    // Esto se va a ejecutar SI o SI
                    System.Threading.Monitor.Exit(objetoABloquear);
            }
            #endregion
        }
    }
}
