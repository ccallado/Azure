<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ClienteWCF.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Servicio PerCall
        <br />
        <asp:Button ID="Button1" runat="server" Text="Incrementar contador 3 veces" 
            onclick="Button1_Click" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        Servicio PerCall
        <br />
        <asp:Button ID="Button2" runat="server" Text="Incrementar contador 3 veces" onclick="Button2_Click" 
            />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        Servicio Single
        <br />
        <asp:Button ID="Button3" runat="server" Text="Incrementar contador 3 veces" onclick="Button3_Click" 
            />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <br />
        Servicio Single
        <br />
        <asp:Button ID="Button4" runat="server" Text="Incrementar contador 3 veces 2s." onclick="Button4_Click" 
            />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
