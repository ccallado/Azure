<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hola Mundo en C#</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Saludo" onclick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <hr />

        Peticiones de páginas:
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" Text="Default 2" NavigateUrl="~/Controles.aspx">HyperLink</asp:HyperLink>

    </div>
    </form>
</body>
</html>
