<%@ Page Title="Controles de validación" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Validaciones.aspx.cs" Inherits="Validaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ChequeaCliente(source, args) {
            if (args.Value.length >= 5 &&
                args.Value.length <= 10) 
                args.IsValid = true;
            else
                arg.IsValid = false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Button ID="Button1" runat="server" Text="Inicio" OnClick="Button1_Click" />
    <hr />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Caja 1 obligatoria"
        ControlToValidate="TextBox1" Font-Bold="True" ForeColor="Red">Campo obligatorio</asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Caja 2 obligatoria"
        ControlToValidate="TextBox2" Font-Bold="True" ForeColor="Red" Display="Dynamic">Campo obligatorio</asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Caja 2 debe ser mayor que Caja 1"
        ControlToCompare="TextBox1" ControlToValidate="TextBox2" Operator="GreaterThan"
        Type="Integer">Debe ser mayor que Caja 1</asp:CompareValidator>
    <br />
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="La caja 3 debe estar entre 0 y 100"
        ControlToValidate="TextBox3" MaximumValue="100" MinimumValue="0" Type="Integer">Debe estar entre 0 y 100</asp:RangeValidator>
    <br />
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Caja 4 código postal incorrecto"
        ControlToValidate="TextBox4" ValidationExpression="\d{5}" EnableClientScript="False">Código postal incorrecto</asp:RegularExpressionValidator>
    <br />
    <asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Caja de texto 5 Texto incorrecto longitud de 5 a 10 caracteres y contenido PROFE o CURSO"
        ControlToValidate="TextBox5" OnServerValidate="CustomValidator1_ServerValidate"
        ValidateEmptyText="True" ClientValidationFunction="ChequeaCliente">Texto incorrecto longitud de 5 a 10 caracteres y contenido PROFE o CURSO</asp:CustomValidator>
    <hr />
    <div style="display: inline-block;">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
</asp:Content>
