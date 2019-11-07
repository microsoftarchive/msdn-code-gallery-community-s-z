<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserFreindRequest.ascx.cs"
    Inherits="Controls_UserFreindRequest" %>
<table cellpadding="1" cellspacing="1" width="100%" border="0">
    <tr>
        <td>
            Requisições de Amigos</td>
    </tr>
    <tr>
        <td align="center">
            <asp:Label ID="lblError" runat="server" CssClass="redtext"></asp:Label>
        </td>
    </tr>
    <tr>
        <td valign="top" align="center">
            <asp:DataList ID="FreindRequestList" runat="server" Width="100%" RepeatColumns="5"
                OnItemCommand="FreindRequestList_ItemCommand">
                <ItemTemplate>
                    <table border="0" cellpadding="2" cellspacing="2" align="center" style="background-color: #f5f5f5">
                        <tr>
                            <td align="center" valign="top">
                                <a href='<%#getHREF(Container.DataItem)%>'>
                                    <input type="hidden" id="hiddenId" value='<%# DataBinder.Eval(Container.DataItem, "Id") %>'
                                        runat="server" name="hiddenId" />
                                    <img src='<%# getSRC(Container.DataItem) %>' align="middle" border="0" width="80px">
                                    <br />
                                    <asp:Button ID="AcceptButton" runat="server" ToolTip="Aceitar" 
                                    Text="Aceitar" CommandName="Accept" /><br />
                                    <asp:Button ID="Deny" runat="server" ToolTip="Negar" Text="Negar" 
                                    CommandName="Deny" />
                                </a>&nbsp;
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
