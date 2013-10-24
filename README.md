Azure
=====

  Desarrollo para la plataforma Windows Azure con Visual Studio

Orden de los cursos
-------------------
* 10267 Web Basico  
* 10264 Web Avanzado
* 10263 WCF  
* 50466 Azure  

## MODULO: 10267A: Introducción al Desarrollo Web con Microsoft Visual Studio 2010. 32 horas de duración

### CONTENIDOS TEÓRICOS
--
#### MODULO 1: EXPLORACION DE MICROSOFT APLICACIONES WEB ASP.NET EN MICROSOFT VISUAL STUDIO 2010
* Introducción al Marco. NET
* Visión general de SAP.NET
* Visión general de la aplicación del laboratorio

#### MODULO 2: CREACIÓN DE APLICACIONES WEB. MEDIANTE MICROSOFT VISUAL ESTUDIO 2010 Y MICROSOFT NET.
* Elección de un lenguaje de programacion
* Descripcion general de Visual Studio 2010
* Creación de una aplicación web simple

***23/10/2013***  
Todas las aplicaciones WEB necesitan un servidor IIS.

#####ASP
El fichero .asp tiene etiquetas de HTML
Las etiquetas de tipo \<%-------%\> lo procesará el servidor.
Al pedir una página al servidor IIS este realiza una copia del fichero para el usuario que las ha pedido.
El servidor procesa todas las etiquetas \<% y una vez que ha convertido a etiquetas estandar , el servidor manda el fichero, lo borra y no espera a ninguna respuesta por parte del cliente.
Si quiero de nuevo la página el proceso se repetirá.

#####.NET
El fichero .aspx, estas páginas normalmente llevan un fichero asociado con el mismo nombre de la página
**.aspx.cs** en visual basic **.aspx.vb**  
El servidor manda el .aspx.cs a Framework, los resultados serán para los controles del .aspx

`\<asp:TextBox .......`


![Imagen 1](Imagenes/CursoAzureImg01.png)
Cada vez que compilamos un proyecto crea un **Ensamblado**

#####Solución
Conjunto de proyectos destinados a solucionar un problema.

Siempre se va a crear una solución para trabajar con Visual Studio.
**Ficheros:**  
**.sln** información de los proyectos que tiene que cargar Visual Studio y en que orden
**.suo**

Jerarquicamente de la solución cuelgan los diferentes proyectos, puede ir en diferentes directorios o no según seleccionemos.

Por cada proyecto creará un fichero **.csproj**
![Imagen 2](Imagenes/CursoAzureImg02.png)

#####Proyectos Web
Un proyecto en el cual vamos a tener el fichero **.csproj, .aspx y .aspx.cs, web.config, etc...**  
Esto va a crear una DLL con todo el contenido del proyecto y todos los ficheros aspx, web.config y otros que no se compilan.

#####Sitio Web
No hay fichero de proyecto, no va a haber ninguna DLL compilada y por defecto todo lo que está en el directorio forma parte del sitio web.
Tienen una caracteristica mas, están pensadas para una aplicación más pequeña y no tienen espacio de nombres.

#####Nota:
Todo proyecto al compilarse va en la misma DLL, obliga a que esté todo en el mismo lenguaje.
En los sitios web se puede mezclar la programación de diferentes lenguajes. Basicamente porque no se crea DLL, aunque existe una compilación temporal, cada pagina es una DLL en lenguaje **IL** que se recompila a binario sin distinguir ya VB o C#.
![Imagen 3](Imagenes/CursoAzureImg03.png)

Visual Studio al ejecutar un Sitio Web abre la página que estés editando.
Si queremos que una página sea la inicial en el esplorador de soluciones, sobre la página que queramos botón derecho/establecer como página principal
Si queremos cambiar más cosas, sobre solución boton derecho Pagina de propiedades y están todas las opciones, en Opciones de inicio están las diferentes opciones posibles.

Que ocurre cuando pulso F5 en Visual Studio,
El código fuente se precompila en IL automáticamente se recompila y es cuando en memoria se crea el binario.
![Imagen 4](Imagenes/CursoAzureImg04.png)

#####Explicacion del HTML
`\<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %\>`

**Page** indica que es una página web  
**Language** es el lenguaje de programación en que está creado el código.  
**Codefile** En que fichero físico está la clase de esta página.  
**Inherits** Es el nombre de la clase.  
Esto funciona porque la clase está definida como **partial**.  

Existe un formato donde podemos incluir **todo en un fichero**.  
Se crea con un pinchito al crear el nuevo elemento para el sitio web.  
El cliente no recibe el código que se genera en la cabecera del fichero .aspx.  
**\<head\>** Cabecera del fichero HTML  
**\<title\>** Título de la página.
**\<body\>** todo lo visible.
**\<form\>** en .NET solo puede haber un form que se ejecute en el servidor.  
**\<div\>**  

En .NET por defecto cualquier control que haga que mi pagina se envie al servidor para cualquier cosa hace que el servidor reciba esa página y que por defecto devuelva **la misma página** reprocesada.
No hay que especificar el action en la etiqueta form porque no funciona así. El lo reconvierte automáticamente.  

#####Comentar líneas en ASPX
**\<%--     --%\>** ***No*** lo recibe el cliente en el HTML  
**\<!--     --\>**  ***Si*** lo recibe el cliente en el HTML  

#####Scripting en el cliente
Javascript que se ejecutará en el cliente sin necesidad de mandar la página al servidor hasta que es necesario.  
C# siempre se ejecutará en el servidor.  

Por defecto todos los controles de .net guardan o mantienen el estado es decir el valor entre peticiones.  
Los de HTML no guardan el valor entre peticiones, este comportamiento es por defecto, pero se puede cambiar en los dos.  

La etiqueta **runat="server"** permite que vea el objeto en el servidor, en este caso el valor se guarda entre peticiones, además que añade el parametro name a la etiqueta.  

***24/10/2013***    
