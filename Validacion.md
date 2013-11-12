##Controles de validación

Son controles que van a permitir validar la entrada de datos de usuario, normalmente en cliente, dando la posibilidad de algunos de ellos validar en ambos sitios (Cliente/Servidor). El sistema crea normalmente código de javascript para realizar esta validación en cliente, aunque a veces no veremos este código por encontrarse en ficheros aparte con extensión **.js** que son librerías.  
Se ejecutaría el código y hay un error el control te muestra el error y no manda la página al servidor.  
![Imagen 16](Imagenes/CursoAzureImg16.png)  
Todas tienen propiedades comunes. Las tres propiedades que siempre tendremos que tener en cuenta son:  
* **ControlToValidate** me permite establecer que control de usuario quiero validar con este control.
* **Text**.- Texto que mostrará el control cuando haya error. Si dejo este en blanco cogería el de **ErrorMessage**.
* **ErrorMessage**.- Texto que se mostrará en el control de validación **ValidatiónSumary** si lo ponemos.
* **Display**.- **Static** el espacio se reserva se vea o no el control, **Dynamic** el espacio no se reserva y **None** el error no se ve.
###Controles de Validación:  
* **RequiredFieldValidator**.- Este control valida que haya dato o no en una caja de texto. Si hay dato el control valida correctamente, si no hay dato mostará los errores. Hay controles que validan cuando pierde el foco la caja de texto.
* **CompareValidator**.- Permite comparar el contenido de un control o bien contra otro control o bien contra un valor. Otras dos propiedades que tienen que ver con lo que queremos comparar, **ControlToCompare** control contra el que vamos a comparar, **ValueToCompare** para establecer el valor contra el que vamos a validar. En la propiedad **Operator** indicamos mayor, mayor igual, menor, menor igual, igual, distinto, chequear el tipo de dato. La propiedad **Type** debemos indicarle el tipo (string, integer, doble, date, currency). No comparan si el control está vacío CustomValidator si controla el vacío.
* **RegularExpressionValidator**.- No comparan si el control está vacío CustomValidator si controla el vacío.
* **RangeValidator**.- No comparan si el control está vacío CustomValidator si controla el vacío. Permite validar que el dato está dentro de un rango. Propiedades **MinimumValue**, **MaximumValue** y **Type**.
* **RegularExpressionValidator**.- Valida utilizando una expresión regular. Las expresiones regulares son cadenas (strings) que definen un formato o plantilla.  
Ejemplo:  
código postal
\d{5} escape \\ d - dígito entre llaves el número de caracteres.  
Dirección de correo electrónico.  
\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*  '
letras mínimo una (de 0 a n de un - o in + o un .) una @ caracteres de 1 a n veces (de 0 a n veces o - o . al menos una letra) un . de una a n letras (de 0 a n veces o - o . al menos una letra)  
Direción web  
http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?  
http una s o nada ://(una o mas veces una letra o un guión un punto) una letra o un guión una o mas veces una /
**\?** 1 o ninguna  
**\*** 0 a n veces  
**\+** 1 a n veces  
Web con una base de datos de expresiones regulares http://regexlib.com/DisplayPatterns.aspx  
* **CustomValidator**.- Como su nombre indica el customvalidator permite validar a gusto del consumidor. Yo voy a escribir la validación que voy a hacer. Este control igual que os otros tiene la propiedad EnableClientScript. Este cliente puede validad en cliente y en servidor cosas diferentes, si queremos validar en cliente tendremos que escribir una función de script para validar y si queremos validar en servidor usaremos el evento **ServerValidate**. Este control tiene un evento más que los demás controles **ServerValidate**. Primero valida en cliente y luego valida en servidor.

Todos estos controles validan en el cliente pero algunos puede validar tambien en servidor, por ejemplo en un rangevalidator los valores máximo y mínimo quiero que sea en base a otro dato que me haya dado en el formulario o que el servidor lo indique, tengo que hacer que el control vaya al servidor. Con la propiedad **EnambleClientScript** que por defecto el control valida en cliente si está puesta a true, cuando la ponemos a false no valida en cliente y pasa a validar en servidor.  
Si se valida en el servidor debemos hacer algo para que si hay un error en la validación no le permitamos que vaya a la página que le hemos indicado y que nos presente la pagina de nuevo con los errores. La variable Page.IsValid es false algún control de validación ha dicho que la página no es correcta, ya en el servidor.   

Un control de validación solo puede validar a un control.

En el evento del servidor el parámetro args es un objeto y tiene varias propiedades y metodos, uso normalmente **args.value**. Para devolver la validación correcta o incorrecta lo hacemos con la propiedad **args.IsValid = false**.    
ValidateEmptyText="True" comprueba la validación de cliente y de servidor aunque la caja esté vacía. Si lo ponemos a false no comprueba la caja vacía ni en cliente ni en el servidor.  
**Orden de los eventos de página:**  
* Load
* Eventos de Cambio
* Eventos de validación
* Eventos de Acción

Existen script que se ejecutan en cualquier momento de la página,  en el PostBack de la página y script de función que yo las llamo cuando quiero.  
Los de función se tienen que escribir antes de la línea en donde se use. Lo más normal es ponerlo en el head. Al estar en una página que usa una página maestra, lo pondremos en el ContentPlaceHolder del Head.  
El nombre de la función que hayamos creado en javascript se debe poner en la propiedad **ClientValidationFunction** del control.  

Como cambiar el Text y el ErrorMessage del control cumstomvalidator. Hay que acceder al control. El nombre del control se llama ContentPlaceHolder1_CustomValidator1 **NombreDelContenedor.NombreDelControl**
la propiedad Text del control de validación en JavaScript está en la propiedad **innerText**  
En este caso la función de JavaScript tiene un parametro **source** que me indica el control que ha llamado a la función, que es él mismo. Por lo tanto `source.innerText = "Longitud incorrecta";` será lo mismo que `document.getElementById("ContentPlaceHolder1_CustomValidator1").innerText = "Longitud incorrecta";`  
El ErrorMessage es un atributo del CustomValidator. En javascript se usa **source.errormessage** en minúsculas.  

El control **ValidationSummary** tiene una propiedad DisplyMode BulletList puntito y lista, List lista yu SingleParagraph que es un parrafo donde vienen todos los errores seguidos.
Dos propiedades para determinar como queremos mostrar los errores.  
**ShowSummary**.- que hace que salga una lista.  
**ShowMessageBox**.- Muestra un mensaje en el navegador del cliente. Típico **Alert** de JavaScript.  
Los controles que validan en el servidor no aparecen en el mensaje de alerta con ShowMessageBox a true.  

###Controles de navegación

Permiten moverse por las páginas del sitio según la estructura definida.  
Tiene que haber una jerarquía lógica no física en este proyecto todo cuelga del directorio raíz.  
Para utilizar el control SiteMap tenemos que añadir un fichero que se llama Web.sitemap es un fichero xml puro y duro, y con una estructura concreta, cuando lo creas, él te crea una estructura base.  
Hay un nodo principal que es **siteMap** y nodos en formato jerarquía con nombre **siteMapNode** parametros **url** la url de la página **title** el título de la página y **description** que es opcional donde pondremos una explicación que aparecerá como un tooltip.  

Para que este fichero que hemos creado se vea en la página, tendremos que crearla en la página maestra poniendo el control **SiteMapPath**.  
Todo lo que tenga que ver con datos en Web viene de un **DataSource**.  
En el menú del iconito sacamos una ventana elegimos origen de datos, nuevo origen de datos y en este caso Mapa de sitio.  
Para que el checkButton se ejecute en el servidor hay que cambiar la propiedad de los controles **AutoPostBack** a true.  

Tener en cuenta si es postbak o carga para rellenar controles al inicio.  

Se pueden poner validaciones en cliente con controles de validación en plantillas.
Es asp las columnas tienen este formato.

    <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                SortExpression="Quantity" />

Se habrá convertido en:

    <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
      <EditItemTemplate>
        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bin("Quantity") %>'>
        </asp:TextBox>
      </EditItemTemplate>
      <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
      </ItemTemplate>
    </asp:TemplateField>

Añadimos un RangeValidator.

      <EditItemTemplate>
        <asp:TextBox ID="TextBoxCantidad" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" 
          ControlToValidate="TextBoxCantidad"
          ErrorMessage="La cantidad debe estar entre 1 y 100" 
          Text="*" 
          TollTip="La cantidad debe estar entre 1 y 100"
          MinimumValue="1" 
          MaximumValue="100" 
          Type="Integer"
          ForeColor="Red"
          Font-Bold="true">
        </asp:RangeValidator>
      </EditItemTemplate>
