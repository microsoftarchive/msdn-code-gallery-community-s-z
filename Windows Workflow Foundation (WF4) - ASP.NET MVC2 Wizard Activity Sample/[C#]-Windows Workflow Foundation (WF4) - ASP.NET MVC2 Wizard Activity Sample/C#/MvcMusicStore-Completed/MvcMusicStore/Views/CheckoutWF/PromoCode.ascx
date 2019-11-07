<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
 <h2>Promotions</h2>
    <p>
        If you have a promo code enter here. 
    </p>
       <div>
 <fieldset>

        <legend>Promo Code</legend>

        <p>
            We're running a promotion: all music is free with the promo code "FREE"
        </p>

        <div class="editor-label">
            <%: Html.Label("Promo Code") %>
        </div>

        <div class="editor-field">
            <%: Html.TextBox("PromoCode") %>
        </div>

    </fieldset>
    </div>