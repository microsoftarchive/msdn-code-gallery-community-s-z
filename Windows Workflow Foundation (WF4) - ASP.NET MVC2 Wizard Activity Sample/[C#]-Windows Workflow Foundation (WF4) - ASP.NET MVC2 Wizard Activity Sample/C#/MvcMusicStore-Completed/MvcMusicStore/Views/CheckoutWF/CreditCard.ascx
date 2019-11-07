<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

  <h2>Payment Information</h2>
    <p>
        Use the form below to enter payment information. 
    </p>
       
        <div>
            <fieldset>
                <legend>Credit Card  Information</legend>
                 <div class="editor-label">
                    <%= Html.Label("Card Type") %>
                </div>
                <div class="editor-field">
                    <%= Html.DropDownList("cardtype", new SelectList(new[] {"VISA","Master Card", "Dicover Card" })) %>
                   
                </div>
                <div class="editor-label">
                    <%= Html.Label("Card Holder Name") %>
                </div>
                <div class="editor-field">
                    <%= Html.TextBox("name") %>
                   
                </div>
              
                <div class="editor-label">
                    <%= Html.Label("Credit Card Number") %>
                </div>
                <div class="editor-field">
                    <%= Html.TextBox("number") %>
                </div>
                
                <div class="editor-label">
                   <%= Html.Label("Expiry Date") %>
                </div>
                <div class="editor-field">
                   <%= Html.TextBox("date") %>
                </div>
                
                <div class="editor-label">
                    <%= Html.Label("CCV Number") %>
                </div>
                <div class="editor-field">
                   <%= Html.TextBox("ccv") %>
                </div>
                
               
            </fieldset>
        </div>
 
