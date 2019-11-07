<%@ Control Language="vb" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
	If Request.IsAuthenticated Then
%>
		Welcome <b><%:Page.User.Identity.Name%></b>!
		[ <%:Html.ActionLink("Log Off", "LogOff", "Account")%> ]
<%
	Else
%> 
		[ <%:Html.ActionLink("Log On", "LogOn", "Account")%> ]
<%
	End If
%>