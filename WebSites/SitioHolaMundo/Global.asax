﻿<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Código que se ejecuta al iniciarse la aplicación

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Código que se ejecuta cuando se cierra la aplicación

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Código que se ejecuta al producirse un error no controlado
        Exception ex = Server.GetLastError();
        //string cad = "Excepción: " + ex.GetType() + 
        //             "<br />" + ex.Message;

        Session["Error"] = ex;
        //Llamo a la página de errores
        Server.Transfer("PaginaErrores.aspx");

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Código que se ejecuta cuando se inicia una nueva sesión

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: El evento Session_End se desencadena sólo con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer 
        // o SQLServer, el evento no se genera.

    }
       
</script>
