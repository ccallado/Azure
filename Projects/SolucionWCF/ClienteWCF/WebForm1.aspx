<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ClienteWCF.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="GetData()" 
            onclick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Fecha()" 
            onclick="Button2_Click" />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="G1" Text="Larga" 
            AutoPostBack="True" oncheckedchanged="RadioButton1_CheckedChanged" />
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="G1" Text="Corta" 
            AutoPostBack="True" oncheckedchanged="RadioButton2_CheckedChanged" />
        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="G1" 
            Text="Completa" AutoPostBack="True" 
            oncheckedchanged="RadioButton3_CheckedChanged" />
        <asp:Button ID="Button3" runat="server" Text="Fecha (con tipo)" 
            onclick="Button3_Click" />
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <br />
        <hr />
        Datos mediante DataSet en Servicio
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="Button4" runat="server" Text="Nombre Categoría" 
            onclick="Button4_Click" />
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Button ID="Button5" runat="server" Text="Categoría (tabla)" 
            onclick="Button5_Click" />
        <asp:Button ID="Button6" runat="server" Text="Categoría (instancia)" 
            onclick="Button6_Click" />
        <asp:Button ID="Button7" runat="server" Text="Categoría (conectado)" onclick="Button7_Click" 
             />
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="Button8" runat="server" Text="Cargar Combo" 
            onclick="Button8_Click" />
        <asp:Button ID="Button9" runat="server" Text="Cargar Combo (conectado)" 
            onclick="Button9_Click" />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            ondatabound="DropDownList1_DataBound" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Button ID="Button10" runat="server" Text="Todos los Productos" 
            onclick="Button10_Click" />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <hr />
        Datos mediante Entity en Servicio
        <br />
        <asp:Button ID="Button11" runat="server" Text="Cargar Clientes Con Pedido" 
            onclick="Button11_Click" />
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </div>
    </form>
</body>
</html>
