###Seguridad Membership

![Imagen 21](Imagenes/CursoAzureImg21.png)

**Authentication**.- La autentificación es el proceso por el que establecemos **la forma** en que validaremos al usuario. Hay cuatro valores:

* **Windows**.- El sistema tratará de obtener la información del **token** *(información del usuario de Windows, nombre, etc...)* del usuario de windows. Eso tiene la ventaja de que si el usuario está validado vía Windows no le pide autenticarse/validarse. Inconveniente solo funciona en un cliente Windows, ni Mac ni Linux, el cliente no tiene las librerías para que salga la ventana que pregunta el usuario y la contraseña.
* **Forms**.- Redirige a un formulario Web, para validarnos. Ventaja es una página web, es valido para cualquier usuario de cualquier sistema al ser un HTML. El inconveniente hay que hacer algún tipo de mantenimiento de usuarios.
* **Passport**.- Sistema de validación gestionado por Microsoft, que permite una única validación para diferentes aplicaciones y servicios. Ejemplo Hotmail, Drive, etc... esto se gestiona con passport una única contraseña/cliente. Se puede pedir a Microsoft, se instala en tu servidor IIS y funciona, (No se sabe si es de pago o libre).
* **None**.- No es ninguna de las anteriores. Permite que te configures tu propia gestión de seguridad que no usará ninguno de los formatos anteriores.

El valor por defecto es *Windows*.

**Authorization**.- Que es el proceso por el cual determinamos quienes pueden y quienes no pueden acceder a la aplicación o a parte de ella.

* IPrincipal.- Entidad principal que agrupa la seguridad.
   * IsInRole.- Pertenece al grupo.
   * IIdentity.- Información del usuario.
      * IsAuthenticated.- Esta autenticado.
      * AuttenticationType.- Tipo de autentication (Windows, Forms, Passport, None)
      * Name.- Nombre del usuario que puede ser lo que hemos tecleado o no, (lo lógico es que lo sea)

Controles de Membership

* **LoginName**.- Visualiza el nombre del usuario como una etiqueta (label), si no esta autenticado sale vacío.
* **LoginView**.- Este control es un MultiView con 2 vistas concretas. Y se enseñan de forma automática.
   * Tiene una vista para cuando el usuario está validado.
   * Otra vista para cuando no está validado.

* **LoginStatus**.- Este control muestra un link para forzar la validación/autenticación de usuario o para cerrar/abandonar la sesión de seguridad. Que NO es la sesión de SessionID. (Caduca la cookie de seguridad).

   Se puede configurar con la propiedad LoginAcction

   * **Refresh**.- recarga la página actual.
   * **Redirect** permite redirigir a una página concreta expecificada en la propiedad **LogoutPageUrl**.
   * **RedirectToLoginPage**.- redirecciona a la página de Login.
 
* **Login**.- Permite validar al usuario.
* **CreateUserWizard**.- Asistente para crear usuarios, normalmente vía Membership.
* **ChangePassword**.- Permite al propio usuario cambiar su password, normalmente vía Membership.
* **PasswordRecovery**.- Permite reinicializar la password a un valor generado por el sistema, que será enviado por correo electrónico al usuario, forzando a que la cambie nada más entrar (porque es una password caducada), normalmente vía Membership.

###Configuración Web.Config.

Hay una herramienta que nos ayuda a tocar este fichero con mayor facilidad.  
![Imagen 22](Imagenes/CursoAzureImg22.png)

![Imagen 23](Imagenes/CursoAzureImg23.png)

![Imagen 24](Imagenes/CursoAzureImg24.png)

![Imagen 25](Imagenes/CursoAzureImg25.png)

![Imagen 26](Imagenes/CursoAzureImg26.png)


Todas estas conexiones viene del fichero machine.config

Podemos guardar valores de configuración de aplicación.
![Imagen 27](Imagenes/CursoAzureImg27.png)

Poner la aplicación sin conexión, estado en el servidor IIS.

Podemos poner el Debug true o false para la depuración en Visual Studio.
![Imagen 28](Imagenes/CursoAzureImg28.png)

Depuración y traza.
La traza es una salida o bien por pantalla directamente en las páginas que me interese, o bien en un archivo temporal en el servidor. Que no existe en disco, solo está en memoria y se llama **trace.axd** se vería en el navegador en lugar de la página de inicio con el nombre indicado.

Se pueden ver cookies, variables de sesión, etc...

Definir página de errores predeterminada.

Si lo que falla es la aplicación se ejecuta el Page_Error o el application_Error.

Esto es para los errores 400 Página no existe, pues ponemos la página que queremos que nos enseñe. Son peticiones de HTTP las que están fallando.

**Seguridad**

![Imagen 29](Imagenes/CursoAzureImg29.png)

Automáticamente me ha creado la conexión a la base de datos. En App_Data ha creado **ASPNETDB.MDF**

![Imagen 30](Imagenes/CursoAzureImg30.png)

Si no hemos terminado no ha creado todavía de crear nada.

![Imagen 31](Imagenes/CursoAzureImg31.png)

**Usuario:** curso  
**Password:** QWERTY1!

Entramos en el **web.config** y vemos que nos ha añadido el siguiente código:

    <appSettings>
      <add key="Profesor" value="Javier" />
      <add key="Alumno" value="Carlos" />
    </appSettings>

y escondido en system.web

    <authentication mode="Forms" />

Si ejecutamos directamente al inicial sesión nos da un error Dirección URL solicitada: /SitioHolaMundo/login.aspx

La página que busca es login.aspx. Para cambiarlo he de cambiar la anterior etiqueta y quedaría:

    <authentication mode="Forms">
      <forms loginUrl="~/Admin/formLogin.aspx" />
    </authentication>



Podemos acceder a los datos de aplicación modificados en el web.config con:

    System.Configuration.ConfigurationManager
          .AppSettings["Profesor"]

**Para autenticar sin membership**

Vamos a hacer que se mande una cookie de seguridad al servidor.

Hay que usar un método estático **RedirectFromLoginPage** de un objeto especial **System.Web.Security.FormsAuthentication**.

    System.Web.Security.FormsAuthentication
          .RedirectFromLoginPage(TextBox1.Text, false);

En la segunda sobrecarga podemos decir que la cookie sea permanente o no.

###Autorización.

Se va a basar en una jerarquía de paso. hay que pasar por Empresa, Maquina, Servidor IIS, Aplicacion

Control de máquina, 

* Empresa (Seguridad a nivel general, seguridar de dominio)
	* Maquina (Seguridad a nivel de máquina **machine.config**)
		* Servidor IIS (Hasta aquí no limita nada, normalmente)
			* Aplicacion (validado o anónimo, a nivel de **web.config**)  
			   **allow** es para permitir explícitamente a usuarios o grupos de usuarios (roles).  
			   **deny** es para denegar explícitamente a usuarios o grupos de usuarios (roles).
			   Hay dos comodines `?` Anonimos, `*` Todos  
		            * Subdirectorios  
###.
    <authentication mode="Forms">
      <forms loginUrl="~/Admin/formLogin.aspx" />
    </authentication>
    <authorization>
      <deny users="?"/>
    </authorization>


