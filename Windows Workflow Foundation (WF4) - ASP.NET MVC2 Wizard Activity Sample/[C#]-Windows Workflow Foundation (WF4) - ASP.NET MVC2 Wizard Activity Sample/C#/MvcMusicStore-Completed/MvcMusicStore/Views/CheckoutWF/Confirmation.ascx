<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<h2>
        Checkout Complete
    </h2>

    <p>
        Thanks for your order! Your order number is:11111
      
    </p>

    <p>
        Continue Shopping in
        <%: Html.ActionLink("store", "Index", "Home") %>?
    </p>