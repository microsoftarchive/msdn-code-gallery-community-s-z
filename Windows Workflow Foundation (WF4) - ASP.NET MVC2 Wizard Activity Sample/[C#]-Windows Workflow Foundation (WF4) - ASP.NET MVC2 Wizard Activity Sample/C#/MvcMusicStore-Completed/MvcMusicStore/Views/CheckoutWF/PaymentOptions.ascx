<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

  <h2>Payment</h2>
    <fieldset>
                <legend>Select a payment option</legend>
                
                <div class="editor-label">
    
     <%= Html.RadioButton("PaymentOption", "CreditCard")%> Credit Card
     </div>
     <div class="editor-label">
     <%= Html.RadioButton("PaymentOption", "GoogleCheckOut")%> Google Checkout
    </div>
     <div class="editor-label">
     <%= Html.RadioButton("PaymentOption", "PayPal")%> Paypal
    </div>
    </fieldset>
