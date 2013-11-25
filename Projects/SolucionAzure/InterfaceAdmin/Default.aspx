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
    <asp:Button ID="Button4" runat="server" 
        Text="Recuperar mensajes Tabla (clasemsg1)" onclick="Button4_Click" />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button5" runat="server" Text="Recuperar mensajes Tabla (TODOS)" 
        onclick="Button5_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" 
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
        GridLines="None" EnableViewState="False">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:GridView>
</asp:Content>
