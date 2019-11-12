<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ScaleOutDemo.WebUI._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Test Run Settings
    </h2>
    <br />
    <table cellpadding="0" cellspacing="10" border="0" style="background-color: #f4f4f4">
        <tr>
            <td>
                Test Run ID:
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td width="260">
                <asp:TextBox ID="testRunIDTextBox" Width="100%" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:Button ID="generateTestRunID" runat="server" Text="Generate New" BorderStyle="Outset"
                    OnClick="generateTestRunID_Click" CausesValidation="False" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="testRunIDTextBox"
                    Display="Dynamic" ErrorMessage="Test Run ID is a compulsory value." ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Message Count:
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="messageCountTextBox" Width="50" runat="server" CausesValidation="True"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="messageCountTextBox"
                    Display="Dynamic" ErrorMessage="Please specify a value from 1 to 1000000." ForeColor="Red"
                    MaximumValue="1000000" MinimumValue="1" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>
                Message Size:
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:DropDownList ID="messageSizeDropDown" runat="server" CausesValidation="True">
                    <asp:ListItem Value="1024">1KB</asp:ListItem>
                    <asp:ListItem Value="10240">10KB</asp:ListItem>
                    <asp:ListItem Value="102400">100KB</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="messageSizeDropDown"
                    ErrorMessage="Please specify a value from 1KB to 100KB." ForeColor="Red" MaximumValue="102400"
                    MinimumValue="1024" Display="Dynamic"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                Publish Asynchronously:
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:CheckBox ID="publishAsyncCheckbox" runat="server" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Enable Async Dispatch:
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:CheckBox ID="enableAsyncDispatchCheckbox" runat="server" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Purge Diagnostic Trace Log:
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:CheckBox ID="purgeTraceLogTableCheckbox" runat="server" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Clean up IRC Topic:
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:CheckBox ID="requireTopicCleanupCheckbox" runat="server" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="startTestButton" runat="server" BorderStyle="Outset" Text="Start New Test"
                    Font-Bold="True" OnClick="startTestButton_Click" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <asp:Panel ID="panelException" runat="server" Visible="False">
        <pre>
        <asp:Label ID="labelExceptionDetails" runat="server" Font-Bold="True" Font-Names="Segoe UI"
            ForeColor="Red"></asp:Label>
        </pre>
    </asp:Panel>
    <asp:Panel ID="panelInfo" runat="server" Visible="False">
        <asp:Label ID="labelInfoText" runat="server" Font-Bold="True" Font-Names="Segoe UI">A request to start a new test run has been successfully submitted to the test controller. <br>Please navigate to the <a href="~/Results.aspx" runat="server">Result tab</a> to view the test results.</br></asp:Label>
    </asp:Panel>
    <p>
        To learn more about inter-role communication using Service Bus, visit the <a href="http://windowsazurecat.com/2011/08/how-to-simplify-scale-inter-role-communication-using-windows-azure-service-bus/"
            target="_blank">Windows Azure Customer Advisory Team blog</a>.
    </p>
</asp:Content>
