<%@ Page Title="Test Results Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Results.aspx.cs" Inherits="ScaleOutDemo.WebUI.Results" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Test Results
    </h2>
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" CellPadding="4" DataSourceID="AzureTableDataSource" 
        ForeColor="#333333" GridLines="None" EnableViewState="False" Width="100%">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="TestRunID" HeaderText="Test Run ID" />
            <asp:BoundField DataField="MessageCount" HeaderText="Message Count" />
            <asp:BoundField DataField="MessageSize" HeaderText="Message Size" />
            <asp:BoundField DataField="InstanceCount" HeaderText="# Of Instances" />
            <asp:BoundField DataField="StartDateTime" HeaderText="Test Started" />
            <asp:BoundField DataField="EndDateTime" HeaderText="Test Completed" />
            <asp:BoundField DataField="Throughput" HeaderText="Throughput (msg/sec)" 
                DataFormatString="{0:F0}" />
            <asp:BoundField DataField="AvgReqLatency" 
                HeaderText="Avg Request Latency (ms)" DataFormatString="{0:F0}" />
            <asp:BoundField DataField="AvgAckLatency" HeaderText="Avg ACK Latency (ms)" 
                DataFormatString="{0:F0}" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:ObjectDataSource ID="AzureTableDataSource" runat="server">
    </asp:ObjectDataSource>
    <br />
    <asp:Button ID="refreshButton" runat="server" BorderStyle="Outset" 
        CausesValidation="False" EnableViewState="False" Text="Refresh" 
        ViewStateMode="Disabled" Font-Bold="True" />
    <asp:Timer ID="Timer1" runat="server" Interval="3000" ontick="Timer1_Tick">
    </asp:Timer>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>

