<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Datos2b.aspx.cs" Inherits="Datos2b" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="EntityDataSource1"
        AllowPaging="True" AllowSorting="True" BackColor="LightGoldenrodYellow" BorderColor="Tan"
        BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" PageSize="5"
        OnPageIndexChanged="GridView1_PageIndexChanged" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="&gt;&gt;" ShowSelectButton="True" />
            <asp:BoundField DataField="OrderID" HeaderText="Pedido" ReadOnly="True" SortExpression="OrderID" />
            <asp:BoundField DataField="EmployeeID" HeaderText="Empleado" ReadOnly="True" SortExpression="EmployeeID" />
            <asp:BoundField DataField="OrderDate" HeaderText="Fecha pedido" ReadOnly="True" SortExpression="OrderDate"
                DataFormatString="{0:d}" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=northwindEntities"
        DefaultContainerName="northwindEntities" EnableFlattening="False" EntitySetName="Orders"
        Select="it.[OrderID], it.[EmployeeID], it.[OrderDate]" Where="it.[CustomerID]=@id"
        OrderBy="it.[OrderID]">
        <WhereParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="id" QueryStringField="Id" Size="5"
                Type="String" />
        </WhereParameters>
    </asp:EntityDataSource>
    <asp:GridView ID="GridView3" runat="server" DataSourceID="EntityDataSource2" AutoGenerateColumns="False"
        DataKeyNames="OrderID,ProductID" OnRowUpdating="GridView3_RowUpdating" BackColor="White"
        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
        GridLines="None" OnRowDeleting="GridView3_RowDeleting">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" SortExpression="OrderID" />
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" SortExpression="ProductID" />
            <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="UnitPrice"
                SortExpression="UnitPrice" ApplyFormatInEditMode="True" />
            <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxCantidad" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                      ControlToValidate="TextBoxCantidad"
                      ErrorMessage="La cantidad debe estar entre 1 y 100" 
                      Text="*" 
                      ToolTip="La cantidad debe estar entre 1 y 100"
                      MinimumValue="1" 
                      MaximumValue="100" 
                      Type="Integer"
                      ForeColor="Red"
                      Font-Bold="true">
                    </asp:RangeValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Discount" DataFormatString="{0:p}" HeaderText="Discount"
                SortExpression="Discount" ApplyFormatInEditMode="True" />
        </Columns>
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#594B9C" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#33276A" />
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSource2" runat="server" ConnectionString="name=northwindEntities"
        DefaultContainerName="northwindEntities" EnableDelete="True" EnableFlattening="False"
        EnableUpdate="True" EntitySetName="Order_Details" Where="it.[OrderID]=@pedido"
        EntityTypeFilter="" Select="">
        <WhereParameters>
            <asp:ControlParameter ControlID="GridView1" Name="pedido" PropertyName="SelectedRow.Cells[1].Text"
                Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>
    <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="Red"></asp:Label>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <br />
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Insertar" OnClick="Button1_Click" />
    </asp:Panel>
</asp:Content>
