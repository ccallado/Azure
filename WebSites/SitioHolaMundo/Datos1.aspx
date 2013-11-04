<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Datos1.aspx.cs" Inherits="Datos1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="G1" Text="Access" AutoPostBack="True"
        OnCheckedChanged="RadioButton1_CheckedChanged" />
    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="G1" Text="Sql" AutoPostBack="True"
        OnCheckedChanged="RadioButton2_CheckedChanged" />
    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="G1" Text="Dataset" 
        AutoPostBack="True" oncheckedchanged="RadioButton3_CheckedChanged" />
    <asp:RadioButton ID="RadioButton4" runat="server" GroupName="G1" Text="Entity" 
        AutoPostBack="True" oncheckedchanged="RadioButton4_CheckedChanged" />
    <asp:RadioButton ID="RadioButton5" runat="server" GroupName="G1" Text="Validaciones" 
        AutoPostBack="True" oncheckedchanged="RadioButton5_CheckedChanged" />
    <br />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="ViewAccess" runat="server">
            <b>Datos Access</b>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="AccessDataSource1"
                DataTextField="CategoryName" DataValueField="CategoryID" AutoPostBack="True">
            </asp:DropDownList>
            <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Northwind.mdb"
                SelectCommand="SELECT [CategoryID], [CategoryName] FROM [Categories]"></asp:AccessDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ProductID"
                DataSourceID="AccessDataSource2" ForeColor="Black" GridLines="None">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False"
                        ReadOnly="True" SortExpression="ProductID" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                    <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" SortExpression="SupplierID" />
                    <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID" />
                    <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                    <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock" />
                    <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder" />
                    <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" SortExpression="ReorderLevel" />
                    <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
            <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/Northwind.mdb"
                SelectCommand="SELECT * FROM [Products] WHERE ([CategoryID] = ?)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" DefaultValue="0" Name="CategoryID"
                        PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:AccessDataSource>
        </asp:View>
        <asp:View ID="ViewSql" runat="server">
            <b>Datos Sql</b>
            <br />
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                DataTextField="CategoryName" DataValueField="CategoryID">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NWConnectionString %>"
                SelectCommand="SELECT [CategoryID], [CategoryName] FROM [Categories]"></asp:SqlDataSource>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
                DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False"
                        ReadOnly="True" SortExpression="ProductID" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                    <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" SortExpression="SupplierID" />
                    <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID" />
                    <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                    <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock" />
                    <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder" />
                    <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" SortExpression="ReorderLevel" />
                    <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NWConnectionString %>"
                SelectCommand="SELECT * FROM [Products] WHERE ([CategoryID] = @CategoryID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList2" DefaultValue="0" Name="CategoryID"
                        PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </asp:View>
        <asp:View ID="ViewDataset" runat="server">
            <b>Datos Dataset</b>
            <br />
            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList3_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:GridView ID="GridView3" runat="server">
            </asp:GridView>
        </asp:View>
        <asp:View ID="ViewEntity" runat="server">
            <b>Datos Entity</b>
            <br />
            <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList4_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:GridView ID="GridView4" runat="server">
            </asp:GridView>
        </asp:View>
        <asp:View ID="ViewValidaciones" runat="server">
            <b>Datos Validaciones</b>
            <br />
            Categoría
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="ID de Categoría obligatorio" ControlToValidate="TextBox1" 
                ForeColor="Red" ToolTip="Campo obligatorio">*</asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                ErrorMessage="El ID debe estar entre 1 y 1000" 
                ControlToValidate="TextBox1" ForeColor="Red" MaximumValue="1000" 
                MinimumValue="1" ToolTip="Valor incorrecto" Type="Integer">*</asp:RangeValidator>
            <asp:Button ID="Button1" runat="server" Text="Cargar" />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:GridView ID="GridView5" runat="server">
            </asp:GridView>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </asp:View>
    </asp:MultiView>
</asp:Content>
