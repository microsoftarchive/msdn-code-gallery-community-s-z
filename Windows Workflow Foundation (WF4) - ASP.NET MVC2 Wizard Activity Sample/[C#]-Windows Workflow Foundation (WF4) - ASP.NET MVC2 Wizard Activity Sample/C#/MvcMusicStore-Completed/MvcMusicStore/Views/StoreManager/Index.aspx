<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcMusicStore.Models.Album>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>Title</th>
            <th>Artist</th>
            <th>Genre</th>
        </tr>

    <% foreach (var item in Model) { %>
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.AlbumId }) %> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.AlbumId })%>
            </td>
            <td><%: Html.Truncate(item.Title, 25) %></td>
            <td><%: Html.Truncate(item.Artist.Name, 25) %></td>
            <td><%: item.Genre.Name %></td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

