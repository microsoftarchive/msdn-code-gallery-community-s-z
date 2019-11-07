<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AsyncPageLoad._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Simple Asynchronous Page Load
    </h2>
    <asp:Timer ID="Timer1" runat="server" Interval="1" OnTick="Timer1_Tick">
    </asp:Timer>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        Static Content. Doesn't change.
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Accordion ID="Accordion1" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent"
                            FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250" RequireOpenedPane="false"
                            SuppressHeaderPostbacks="true">
                            <panes>
                            </panes>
                        </asp:Accordion>
                        <asp:Label ID="lblLoading" runat="server" Text=""></asp:Label>
                        <asp:Image ID="imgLoading" runat="server" ImageUrl="images/loading.gif" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
