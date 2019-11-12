<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<%: Html.ActionLink("Cart (" + ViewData["CartCount"] + ")", "Index", "ShoppingCart", 
    new { id = "cart-status" })%>