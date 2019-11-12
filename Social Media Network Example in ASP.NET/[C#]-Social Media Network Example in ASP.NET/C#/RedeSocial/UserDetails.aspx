<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserDetails.aspx.cs" Inherits="UserDetails" %>

<%@ Register Src="~/Controls/GetUserScraps.ascx" TagName="UserScraps" TagPrefix="Uc1" %>
<%@ Register Src="~/Controls/UserFriends.ascx" TagName="UserFriends" TagPrefix="Uc2" %>
<%@ Register Src="~/Controls/UserFreindRequest.ascx" TagName="UserFriendRequest"
    TagPrefix="Uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td width="18%" valign="top" class="SkyBlueBorder" align="center">
                <asp:Image ID="UserImage" runat="server" Width="140px" />
                <br />
                <br />
                <span class="SmallBlackText">Ingressou em:</span>&nbsp;<asp:Label ID="lblCreated" runat="server"></asp:Label>
                <br />
                <br />
                <span class="SmallBlackText">Último Login:</span>&nbsp;<asp:Label ID="LabelLastLogin"
                    runat="server"></asp:Label>
                <br />
                <br />
                <span class="SmallBlackText">Visualizações:</span>&nbsp;<asp:Label ID="LabelTotalViews"
                    runat="server"></asp:Label>
            </td>
            <td valign="top" class="GreenBorder">
                <span class="BlackText">Sobre Mim:</span><br />
                <asp:Label ID="LabelAboutMe" runat="server"></asp:Label>
                <br />
                <br />
                <asp:LinkButton ID="AddToFriend" runat="server" 
                    Text="Enviar um recado a um amigo" OnClick="AddToFriend_Click"></asp:LinkButton><br />
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <br />
                <Uc3:UserFriendRequest ID="UserFriendRequest" runat="server" Visible="false" />
                <br />
                <asp:TextBox ID="TextBoxScrap" runat="server" TextMode="MultiLine" Height="65px"
                    Width="490px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="ButtonPostScrap" runat="server" Text="Enviar um recado" OnClick="ButtonPostScrap_Click" />
                <br />
                <br />
                <Uc1:UserScraps ID="UserScraps" runat="server" />
            </td>
            <td width="30%" valign="top">
                <Uc2:UserFriends ID="UserFriends" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
