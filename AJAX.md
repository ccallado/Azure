##AJAX
Si queremos que la validación o lo que sea se haga en cliente tenemos que hacerlo en JavaScript.

Es un conjunto de controles que generan JavaScript en el cliente para hacer llamadas parciales al servidor.

Vamos a hacer peticiones parciales, hacemos peticiones no de la página completa sino de partes de ella.  
Reducimos de esta manera el tráfico con el servidor.  
Siempre tiene que haber *un objeto accesible y solo uno* de tipo **ScriptManager**.  
Este se encargará de añadir todo el JavaScript para los controles usados con Ajax.  
Luego pondremos 1 o muchos controles **UpdatePanel** estos serán los contenedores de todo lo que se verá afectado por Ajax.  
El updatepanel es un contenedor que puede tener varias cosas dentro. Debe tener la etiqueta ContentTemplate. Todo lo que meta dentro de la etiqueta se va a ejecutar via Ajax.  
Con Ajax se carga la página y ejecuta el load el sistema solo actualizará los controles que estén dentro de un UpdatePanel.

Las variables de sesión, de aplicación, cache, si se actualizan en el servidor, aunque en cliente no se viera actualizada, al ser llamadas por Ajax.

El Parse solo convierte desde cadenas (Pregunta de examen).

Existe un *control* dentro de Ajax llamado **Timer**, este lanza un evento en modo asíncrono vía ajax y actualiza todos los controles que tengan que actualizarse. La propiedad **Interval** viene a 60000 y es recomendable dejarlo en 60000, come mucho tráfico.

Cuando lanza el Timer borra la label de la hora por estar en un UpdatePanel, al cambiar el valor de la label en el evento Page_Load.

En los UpdatePanel hay una propiedad **UpdateMode** que viene a valor Always.

* **Always** se actualiza cada vez que se llama a la página via ajax.

* **Conditional** el contenido del UpdatePanel solo se actualiza si la llamada Ajax se lanza desde el mismo UpdatePanel o si explicitamente se indica que se deba actualizar.

Para que un control que está dentro de un UpdatePanel fuerce el PostBack de la página hay que ponerle al UpdatePanel un **PostBackTrigger**.

Etiquetas de `<Triggers>`:

* **PostBackTrigger**.- Control que ejecutará el triger del updatepanel.

  
Código:  

    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
      <Triggers>
        <asp:PostBackTrigger ControlID="Button3" />
      </Triggers>
      <ContentTemplate>
        Con AJAX (UpdatePanel2)
        <br />

Un control que está fuera de un UpdatePanel, puede forzar una llamada vía Ajax.

* **AsyncPostBackTrigger**.- Control que ejecutará el trigger y podríamos decirle también el evento que lo ejecutaría.

Código:

    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button7" />
        </Triggers>
        <ContentTemplate>
            Con AJAX (UpdatePanel3)

Cuando hacemos una llamada vía Ajax en el control ScriptManager de la página tiene una propiedad **IsInAsyncPostBack** que indica si el PostBack de la página se va a procesar de manera **asíncrona**.
Para poder acceder al **ScriptManager** que se está utilizando debemos usar el método estático **GetCurrent**

        if (ScriptManager.GetCurrent(this).IsInAsyncPostBack)
            Label4.Text += "<br />Llamada via AJAX";
        else
            Label4.Text += "<br />Llamada normal";

Este método será muy util para crear controles que se puedan introducir múltiples veces en una página que tomarán el control del ScriptManager de la página donde pongas estos controles.

**ScriptManagerProxy** se utiliza para tener conexión con el ScriptManager de la MasterPage.

El ScriptManager tiene unos métodos especiales para la gestión de scripts, para añadirlos dinámicamente lo haría con este control.

Control **UpdateProgress** no sirve para informar al cliente mientras el servidor realiza una tarea asíncrona. Debe tener una etiqueta ProgressTemplate lo que ponga ahí dentro es lo que se va a mostrar mientras se realice la tarea asíncrona. Cuando termine se borra automáticamente.

Para ejecutar una función JavaScript al pulsar un botón existe una propiedad OnClientClick donde le diremos la función de JavaScript que queremos ejecutar.

