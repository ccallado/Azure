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
        <asp:HyperLink ID="HyperLink1" runat="server" Text="Default 2" NavigateUrl="~/Default2.aspx">HyperLink</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" Text="Google" 
            NavigateUrl="https://www.google.es" Target="_blank"></asp:HyperLink>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default2.aspx">Default 2</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" 
            PostBackUrl="https://www.google.es">Google</asp:LinkButton>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Server.Transfer" 
            onclick="Button2_Click" />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Response.Redirect" 
            onclick="Button3_Click" />
        <hr />
        División para provocar y lanzar el Application_Error (en el <b>Global.asax</b>)
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Literal ID="Literal1" runat="server" Text=" / "></asp:Literal>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Literal ID="Literal2" runat="server" Text=" = "></asp:Literal>
        <asp:Button ID="Button4" runat="server" Text="Dividir" 
            onclick="Button4_Click" />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
