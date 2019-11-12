<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="1" width="100%" border="0">
        <tr>
            <td>
                Resultado da Busca</td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" align="center">
                <asp:DataList ID="SearchResultList" runat="server" Width="100%" RepeatColumns="9">
                    <ItemTemplate>
                        <table border="0" cellpadding="2" cellspacing="2" align="center" style="background-color: #f5f5f5">
                            <tr>
                                <td align="center" valign="top">
                                    <a href='<%#getHREF(Container.DataItem)%>'>
                                        <img src='<%# getSRC(Container.DataItem) %>' align="middle" border="0" width="80px">
                                    </a>
                                &nbsp;</td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>
