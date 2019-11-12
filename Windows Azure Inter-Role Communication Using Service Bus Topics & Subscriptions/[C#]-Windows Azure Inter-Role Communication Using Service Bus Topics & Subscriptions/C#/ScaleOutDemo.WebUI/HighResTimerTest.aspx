<%@ Page Title="High Resolution Timer Test Page" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="HighResTimerTest.aspx.cs" Inherits="ScaleOutDemo.WebUI.HighResTimerTest" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        High Resolution Timer Test
    </h2>
    <br />
    <table cellpadding="0" cellspacing="10" border="0" style="background-color: #f4f4f4">
        <tr>
            <td>
                Hi-Res Timer Supported:
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="hiResTimerSupported" Enabled="false" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;&nbsp;<i>HighResolutionTimer.IsHighResolution</i>
            </td>
        </tr>
        <tr>
            <td>
                Hi-Res Timer Frequency:
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="hiResTimerFrequency" Enabled="false" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;&nbsp;<i>HighResolutionTimer.Frequency</i>
            </td>
        </tr>
        <tr>
            <td>
                Stopwatch Frequency:
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="stopwatchFrequency" Enabled="false" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;&nbsp;<i>Stopwatch.Frequency</i>
            </td>
        </tr>
        <tr>
            <td>
                Current Hi-Res Timer Tick Count:
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="currentTickCount" Enabled="false" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;&nbsp;<i>HighResolutionTimer.CurrentTickCount</i>
            </td>
        </tr>
        <tr>
            <td>
                Current Date/Time Tick Count:
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="currentDateTimeTickCount" Enabled="false" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;&nbsp;<i>DateTime.UtcNow.Ticks</i>
            </td>
        </tr>
        <tr>
            <td>
                5-second Delay With Stopwatch:
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="delayWithStopwatch" Enabled="false" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;&nbsp;<i>Thread.Sleep(5000)</i>
            </td>
        </tr>
        <tr>
            <td>
                5-second Delay With Hi-Res Timer:
            </td>
            <td>
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="delayWithHiResTimer" Enabled="false" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;&nbsp;<i>Thread.Sleep(5000)</i>
            </td>
        </tr>
    </table>
</asp:Content>
