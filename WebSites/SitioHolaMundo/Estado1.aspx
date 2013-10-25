<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Estado1.aspx.cs" Inherits="Estado1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="Button1" runat="server" Text="Recargar" />
    <!-- Contador de las recargas -->
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    <!-- Campo oculto -->
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <br />
    <asp:TextBox ID="TextBox1" runat="server" EnableViewState="False"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Text="Label" EnableViewState="False"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox3" runat="server" ontextchanged="TextBox3_TextChanged">Pepe</asp:TextBox>
    <asp:Label ID="Label3" runat="server" Text="Label" EnableViewState="False"></asp:Label>
    <br />
    <asp:Button ID="Button2" runat="server" Text="Asignar" 
        onclick="Button2_Click" />
</asp:Content>

