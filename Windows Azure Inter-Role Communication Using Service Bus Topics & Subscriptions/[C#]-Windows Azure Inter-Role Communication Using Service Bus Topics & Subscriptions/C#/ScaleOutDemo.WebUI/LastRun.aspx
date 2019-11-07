<%@ Page Title="Last Test Run Details" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="LastRun.aspx.cs" Inherits="ScaleOutDemo.WebUI.LastRun" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Last Test Run Details
    </h2>
    <br />
    <asp:Panel ID="detailsPanel" Visible="false" runat="server">
        <table cellpadding="0" cellspacing="10" border="0" style="background-color: #f4f4f4">
            <tr>
                <td>
                    Test Run ID:
                </td>
                <td>
                    &nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="textBoxTestRunID" Enabled="false" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;&nbsp;<i>This is the unique ID of the last test run.</i>
                </td>
            </tr>
            <tr>
                <td>
                    Duration:
                </td>
                <td>
                    &nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="textBoxDuration" Enabled="false" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;&nbsp;<i>This is how long the last test run was being executed.</i>
                </td>
            </tr>
            <tr>
                <td>
                    Throughput:
                </td>
                <td>
                    &nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="textBoxThroughput" Width="80px" Enabled="false" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;&nbsp;<i>This is how fast (in messages per second) the last test run was.</i>
                </td>
            </tr>
            <tr>
                <td colspan="4"><hr /></td>
            </tr>
            <tr>
                <td>
                    Minimum Request Latency:
                </td>
                <td>
                    &nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="textBoxMinMulticastLatency" Width="80px" Enabled="false" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;&nbsp;<i>The minimum time (in milliseconds) it took to send a request message to the test clients.</i>
                </td>
            </tr>
            <tr>
                <td>
                    Average Request Latency:
                </td>
                <td>
                    &nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="textBoxAvgMulticastLatency" Width="80px" Enabled="false" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;&nbsp;<i>The average time (in milliseconds) it took to send a request message to the test clients.</i>
                </td>
            </tr>
            <tr>
                <td>
                    Maximum Request Latency:
                </td>
                <td>
                    &nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="textBoxMaxMulticastLatency" Width="80px" Enabled="false" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;&nbsp;<i>The maximum time (in milliseconds) it took to send a request message to the test clients.</i>
                </td>
            </tr>

            <tr>
                <td colspan="4"><hr /></td>
            </tr>

             <tr>
                <td>
                    Minimum Response Latency:
                </td>
                <td>
                    &nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="textBoxMinUnicastLatency" Width="80px" Enabled="false" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;&nbsp;<i>The minimum time (in milliseconds) it took to receive an ACK message from the test clients.</i>
                </td>
            </tr>
            <tr>
                <td>
                    Average Response Latency:
                </td>
                <td>
                    &nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="textBoxAvgUnicastLatency" Width="80px" Enabled="false" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;&nbsp;<i>The average time (in milliseconds) it took to receive an ACK message from the test clients.</i>
                </td>
            </tr>
            <tr>
                <td>
                    Maximum Response Latency:
                </td>
                <td>
                    &nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="textBoxMaxUnicastLatency" Width="80px" Enabled="false" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;&nbsp;<i>The maximum time (in milliseconds) it took to receive an ACK message from the test clients.</i>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="infoPanel" Visible="false" runat="server">
        <asp:Label ID="labelInfoText" runat="server" Font-Bold="True" Font-Names="Segoe UI">There is no test run to display. <br>Please navigate to the <a id="A1" href="~/Default.aspx" runat="server">Home tab</a> to kick off a new test run.</asp:Label>
    </asp:Panel>
</asp:Content>
