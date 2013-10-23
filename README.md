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

*3/10/2013*  
Todas las aplicaciones WEB necesitan un servidor IIS.

#####ASP
El fichero .asp tiene etiquetas de HTML
Las etiquetas de tipo <%-------%> lo procesará el servidor.
Al pedir una página al servidor IIS este realiza una copia del fichero para el usuario que las ha pedido.
El servidor procesa todas las etiquetas <% y una vez que ha convertido a etiquetas estandar , el servidor manda el fichero, lo borra y no espera a ninguna respuesta por parte del cliente.
Si quiero de nuevo la página el proceso se repetirá.

#####.NET
El fichero .aspx, estas páginas normalmente llevan un fichero asociado con el mismo nombre de la página
*.aspx.cs* en visual basic *.aspx.vb*
El servidor manda el .aspx.cs a Framework, los resultados serán para los controles del .aspx
'''asp
<asp:TextBox .......
'''
[Imagen 1]
Cada vez que compilamos un proyecto crea un **Ensamblado**

*Solución*  
Conjunto de proyectos destinados a solucionar un problema.

Siempre se va a crear una solución para trabajar con Visual Studio.
ficheros:  
.sln información de los proyectos que tiene que cargar Visual Studio y en que orden
.suo

Jerarquicamente de la solución cuelgan los diferentes proyectos, puede ir en diferentes directorios o no según seleccionemos.

Por cada proyecto creará un fichero .csproj
[Imagen 2]

Proyectos Web
Un proyecto en el cual vamos a tener el fichero .csproj, .aspx y .aspx.cs, web.config, etc...
Esto va a crear una DLL con todo el contenido del proyecto y todos los ficheros aspx, web.config y otros que no se compilan.

Sitio Web
No hay fichero de proyecto, no va a haber ninguna DLL compilada y por defecto todo lo que está en el directorio forma parte del sitio web.
Tienen una caracteristica mas, están pensadas para una aplicación más pequeña y no tienen espacio de nombres.

