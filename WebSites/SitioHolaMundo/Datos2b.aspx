<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Datos2b.aspx.cs" Inherits="Datos2b" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="EntityDataSource1" AllowPaging="True" AllowSorting="True" 
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
        CellPadding="2" ForeColor="Black" GridLines="None" PageSize="5" 
        onpageindexchanged="GridView1_PageIndexChanged">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="&gt;&gt;" 
                ShowSelectButton="True" />
            <asp:BoundField DataField="OrderID" HeaderText="Pedido" ReadOnly="True" 
                SortExpression="OrderID" />
            <asp:BoundField DataField="EmployeeID" HeaderText="Empleado" ReadOnly="True" 
                SortExpression="EmployeeID" />
            <asp:BoundField DataField="OrderDate" HeaderText="Fecha pedido" ReadOnly="True" 
                SortExpression="OrderDate" DataFormatString="{0:d}" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
        ConnectionString="name=northwindEntities" 
        DefaultContainerName="northwindEntities" EnableFlattening="False" 
        EntitySetName="Orders" 
        Select="it.[OrderID], it.[EmployeeID], it.[OrderDate]" 
        Where="it.[CustomerID]=@id" OrderBy="it.[OrderID]">
        <WhereParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="id" 
                QueryStringField="Id" Size="5" Type="String" />
        </WhereParameters>
    </asp:EntityDataSource>
    <asp:GridView ID="GridView2" runat="server" DataSourceID="EntityDataSource2">
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSource2" runat="server" 
        ConnectionString="name=northwindEntities" 
        DefaultContainerName="northwindEntities" EnableDelete="True" 
        EnableFlattening="False" EnableUpdate="True" EntitySetName="Order_Details" 
        Where="it.[OrderID]=@pedido" EntityTypeFilter="" Select="">
        <WhereParameters>
            <asp:ControlParameter ControlID="GridView1" Name="pedido" 
                PropertyName="SelectedRow.Cells[1].Text" Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>
</asp:Content>

