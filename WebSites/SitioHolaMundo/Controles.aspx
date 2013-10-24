<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Controles.aspx.cs" Inherits="Controles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Calendario
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        jejeje
        <br />
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Seleccion 1" />
        <br />
        <asp:CheckBox ID="CheckBox2" runat="server" />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Uno</asp:ListItem>
            <asp:ListItem>Dos</asp:ListItem>
            <asp:ListItem>Tres</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Hola" Font-Bold="True" 
            ForeColor="Red"></asp:Label>
        <br />
        <asp:Literal ID="Literal1" runat="server" Text="Hola"></asp:Literal>
        <br />
        Contenedor:
        <br />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <br />
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="G1" Text="RB1" />
        <br />
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="G1" Text="RB2" />
        <br />
        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="G2" Text="RB3" />
        <br />
        <asp:RadioButton ID="RadioButton4" runat="server" GroupName="G2" Text="RB4" />
        <br />
    </div>
    </form>
</body>
</html>
