﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Button ID="Button1" runat="server" Text="Default" 
        PostBackUrl="~/Default.aspx" />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Default2" 
        PostBackUrl="~/Default2.aspx" />
    <br />
    <asp:Button ID="Button3" runat="server" Text="Default3" 
        PostBackUrl="~/Default3.aspx" />
    <br />
    <asp:Button ID="Button4" runat="server" Text="Estado 1" 
        PostBackUrl="~/Estado1.aspx" />
    <br />
    <asp:Button ID="Button5" runat="server" Text="Validaciones" 
        PostBackUrl="~/Validaciones.aspx" />
    <br />
    <asp:Button ID="Button6" runat="server" Text="Datos" 
        PostBackUrl="~/Datos.aspx" />
    <br />

</asp:Content>

