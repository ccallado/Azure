<%@ Page Title="Formulario de Login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="formLogin.aspx.cs" Inherits="formLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    Login SIN Membership y con controles NORMALES
    <br />
    Usuario
    <asp:TextBox ID="TextBox1" runat="server">cursoAux</asp:TextBox>
    <br />
    Password
    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Validar" 
        onclick="Button1_Click" />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="Red"></asp:Label>
</asp:Content>

