<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspNetCachingDemo._Default" %>

<%@ Register assembly="System.Web.Entity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System.Web.UI.WebControls" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
            DefaultContainerName="NorthwindEFEntities" EnableDelete="True" 
            ContextTypeName="AspNetCachingDemo.ExtendedNorthwindEntities, AspNetCachingDemo"
            EnableInsert="True" EnableUpdate="True" EntitySetName="Customers">
        </asp:EntityDataSource>
    
        <asp:EntityDataSource ID="EntityDataSource2" runat="server" 
            DefaultContainerName="NorthwindEFEntities" EnableDelete="True" 
            ContextTypeName="AspNetCachingDemo.ExtendedNorthwindEntities, AspNetCachingDemo"
            EnableInsert="True" EnableUpdate="True" EntitySetName="Orders" 
            EntityTypeFilter="InternationalOrder" ConnectionString="" 
            Select="" 
            Where="it.Customer.CustomerID = @CustomerID">
            <WhereParameters>
                <asp:ControlParameter ControlID="GridView1" DbType="String" 
                    DefaultValue="&quot;-----&quot;" Name="CustomerID" 
                    PropertyName="SelectedValue" />
            </WhereParameters>
        </asp:EntityDataSource>
    
        <br />
        <b>Customers:</b><br />
    
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="CustomerID" DataSourceID="EntityDataSource1" 
        AllowPaging="True" AllowSorting="True" AutoGenerateEditButton="True" 
        AutoGenerateSelectButton="True" BackColor="White" BorderColor="#E7E7FF" 
        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Horizontal" PageSize="5">
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <Columns>
            <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" 
                SortExpression="CustomerID" />
            <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" 
                SortExpression="CompanyName" />
            <asp:BoundField DataField="ContactName" HeaderText="ContactName" 
                SortExpression="ContactName" />
            <asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" 
                SortExpression="ContactTitle" />
            <asp:BoundField DataField="Address.Address" HeaderText="Address.Address" 
                SortExpression="Address.Address" />
            <asp:BoundField DataField="Address.City" HeaderText="Address.City" 
                SortExpression="Address.City" />
            <asp:BoundField DataField="Address.Region" HeaderText="Address.Region" 
                SortExpression="Address.Region" />
            <asp:BoundField DataField="Address.PostalCode" HeaderText="Address.PostalCode" 
                SortExpression="Address.PostalCode" />
            <asp:BoundField DataField="Address.Country" HeaderText="Address.Country" 
                SortExpression="Address.Country" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
            <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
    </asp:GridView>
    <br />
    Orders:<br />
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
        AllowSorting="True" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" 
        BorderWidth="1px" CellPadding="3" DataSourceID="EntityDataSource2" 
        GridLines="Horizontal">
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
    </asp:GridView>
    <br />
    </form>
</body>
</html>
