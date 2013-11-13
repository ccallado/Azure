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
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="G1" Text="Larga" />
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="G1" Text="Corta" />
        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="G1" Text="Completa" />
        <asp:Button ID="Button3" runat="server" Text="Fecha (con tipo)" 
            onclick="Button3_Click" />
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
