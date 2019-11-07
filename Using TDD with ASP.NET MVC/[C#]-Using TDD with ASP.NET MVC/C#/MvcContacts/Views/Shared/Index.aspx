<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
 Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcContacts.Models.Contact>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index For  <%= Html.Encode(ViewData["ControllerName"])%>   </h2>
     
    <table>
        <tr>
            <th></th>

            <th>
                FirstName
            </th>
            <th>
                LastName
            </th>
            <th>
                Phone
            </th>
            <th>
                Email
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id = item.Id })%>
                |
                <%: Html.ActionLink("Delete", "Delete", new { id = item.Id })%>
            </td>
 <%--           <td> <%: item.Id %> </td>
             <td> <%: Html.DisplayFor(c => item.Id) %> </td>--%>
            <td> <%: Html.DisplayFor(c => item.FirstName) %> </td>
            <td>  <%: Html.DisplayFor(c => item.LastName) %> </td>
            <td>  <%: Html.DisplayFor(c => item.Phone) %>  </td>
            <td>  <%: Html.DisplayFor(c => item.Email) %> </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

