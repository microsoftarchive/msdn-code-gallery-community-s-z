<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcContacts.Contact)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>
     
     <%: ViewData("EditError")%>

    <%-- The following line works around an ASP.NET compiler warning --%>
    <%: ""%>

    <% Using Html.BeginForm() %>
        <%: Html.ValidationSummary(True) %>
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.DisplayFor(Function(model) model.Id)%>
            </div>
                       
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.FirstName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(Function(model) model.FirstName) %>
                <%: Html.ValidationMessageFor(Function(model) model.FirstName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.LastName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(Function(model) model.LastName) %>
                <%: Html.ValidationMessageFor(Function(model) model.LastName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.Phone) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(Function(model) model.Phone) %>
                <%: Html.ValidationMessageFor(Function(model) model.Phone) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(Function(model) model.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(Function(model) model.Email) %>
                <%: Html.ValidationMessageFor(Function(model) model.Email) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

