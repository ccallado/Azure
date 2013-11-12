<%@ Application Language="C#" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse la aplicación
        Application["Sesiones"] = 0;
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
        //Server.Transfer("PaginaErrores.aspx");

        //Si uso Response.Redirect en Application_Error SI necesito limpiar el error 
        // antes de terminar, porque si no el cliente recibe una redirección SIN Id de Sesión,
        //y pierde la variable de sesión porque empieza automáticamente otra sesión.
        Server.ClearError();
        //Llamo a la página de errores
        //Response.Redirect("PaginaErrores.aspx");
        
        //Al hacer Server.Transfer como la petición de la página NO viene del cliente
        //no vuelve a chequear la seguridad, y por lo tanto la página "PaginaErrores.aspx"
        //no tiene que tener el location con <allow Users="*" /> en el web.config
        Server.Transfer("PaginaErrores.aspx");

        //En cualquier caso, es RECOMENDABLE hacer el Server.ClearError() siempre
        //antes de usar Server.Transfer o Response.Redirect para que no se pierda
        //la sesión de usuario.
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando se inicia una nueva sesión
        //Bloqueo el objeto application
        Application.Lock();
        //Para convertir un objeto a otro tipo uso el cast y el convert
        //Con Cast
        Application["Sesiones"] = (int)Application["Sesiones"] + 1;
        //Con Convert
        //Application["Sesiones"] = Convert.ToInt32(Application["Sesiones"]) + 1;
        //Desbloqueo el objeto application
        Application.UnLock();
    }

    void Session_End(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: El evento Session_End se desencadena sólo con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer 
        // o SQLServer, el evento no se genera.
        //En nuestro caso es InProc
        Application["Sesiones"] = (int)Application["Sesiones"] - 1;
    }
       
</script>
