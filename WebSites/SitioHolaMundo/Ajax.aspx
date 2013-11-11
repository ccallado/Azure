<%@ Page Title="Ajax" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Ajax.aspx.cs" Inherits="Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- Este NO hace falta al haberlo puesto en la MasterPage    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <script type="text/javascript">
        function BorraLabel() {
            document.getElementById("ContentPlaceHolder1_Label5").innerText = "";
        }

        function AbortarPostBack() {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm.get_isInAsyncPostBack) {
                prm.abortPostBack();
                document.getElementById("ContentPlaceHolder1_Label5").innerText = "Cancelado por el usuario...";
            }
        }
    </script>
    <asp:Label ID="Label0" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    Sin AJAX
    <br />
    <asp:Button ID="Button1" runat="server" Text="Hora" OnClick="Button1_Click" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            Con AJAX (UpdatePanel1)
            <br />
            <asp:Button ID="Button2" runat="server" Text="Hora" OnClick="Button2_Click" />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="Button3" />
        </Triggers>
        <ContentTemplate>
            Con AJAX (UpdatePanel2)
            <br />
            <asp:Button ID="Button3" runat="server" Text="Hora (PostBack)" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Text="Hora" OnClick="Button3_Click" />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Button7" />
        </Triggers>
        <ContentTemplate>
            Con AJAX (UpdatePanel3)
            <br />
            (Esta label solo se actualizará con el botón que hay FUERA y que se indica en los
            Triggers)
            <br />
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:Button ID="Button5" runat="server" Text="Recargar" />
    <asp:Button ID="Button6" runat="server" Text="Recargar TODO" OnClick="Button6_Click" />
    <asp:Button ID="Button7" runat="server" Text="Recargar AJAX" OnClick="Button6_Click" />
    <hr />
    <%--Solo se debe actualizar cuando se pulse el boton 8--%>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            Segundos Parada
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button8" runat="server" Text="Lanzar" OnClick="Button8_Click" OnClientClick="BorraLabel()" />
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <asp:Label ID="Label6" runat="server" Text="Proceso lanzado. Por favor, espere..."
                BackColor="#FFFF99" Font-Italic="True"></asp:Label>
            (
<%--            <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="AbortarPostBack()">Cancelar</asp:LinkButton>--%>
                <a href="#" onclick="AbortarPostBack()" >Cancelar</a>
            )
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
