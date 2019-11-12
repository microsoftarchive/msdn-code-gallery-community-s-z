<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
 
  <% using (Html.BeginForm()) {%>
	<% Html.RenderPartial("Breadcrumb", ViewData["bookmarkhistory"]); %>
	
    <% Html.RenderPartial((string)ViewData["PartialViewName"]); %>
	
	
    <% Html.RenderPartial("Navigation", ViewData["currentbookmark"]); %>
    
<% } %>
</asp:Content>
