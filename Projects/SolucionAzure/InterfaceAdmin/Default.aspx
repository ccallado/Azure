<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="InterfaceAdmin._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Button ID="Button1" runat="server" Text="Recuperar Mensajes" 
        onclick="Button1_Click1" />
    
    <asp:CheckBox ID="CheckBox1" runat="server" Text="Borrar mensajes" />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Cantidad de mensajes" 
        onclick="Button2_Click" />
    <asp:Button ID="Button3" runat="server" Text="Borra mensajes" 
        onclick="Button3_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
