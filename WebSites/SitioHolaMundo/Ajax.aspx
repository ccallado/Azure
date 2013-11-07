<%@ Page Title="Ajax" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Ajax.aspx.cs" Inherits="Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="Label0" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    Sin AJAX
    <br />
    <asp:Button ID="Button1" runat="server" Text="Hora" OnClick="Button1_Click" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            Con AJAX (UpdatePanel1)
            <br />
            <asp:Button ID="Button2" runat="server" Text="Hora" onclick="Button2_Click"/>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
