<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of MvcContacts.Contact))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index <%: ViewData("ControllerName")%></h2>
  
    <p>
        <%: Html.ActionLink("Create New", "Create")%>
    </p>
    
    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
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

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", New With {.id = item.Id})%> |
                <%: Html.ActionLink("Details", "Details", New With {.id = item.Id})%> |
                <%: Html.ActionLink("Delete", "Delete", New With {.id = item.Id})%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.FirstName %>
            </td>
            <td>
                <%: item.LastName %>
            </td>
            <td>
                <%: item.Phone %>
            </td>
            <td>
                <%: item.Email %>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

