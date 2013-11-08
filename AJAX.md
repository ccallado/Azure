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

Existe un *control* dentro de Ajax llamado **Timer**, este lanza un evento en modo asíncrono vía ajax y actualiza todos los controles que tengan que actualizarse. La propiedad **Interval** viene a 60000 y es recomendable dejarlo en 60000.

