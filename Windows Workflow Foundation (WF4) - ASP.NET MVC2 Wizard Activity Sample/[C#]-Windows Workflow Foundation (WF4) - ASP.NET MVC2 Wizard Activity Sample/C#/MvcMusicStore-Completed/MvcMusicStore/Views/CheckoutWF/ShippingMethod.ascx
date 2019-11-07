<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<MvcMusicStore.Models.ShippingMethod>>" %>

<h2>Shipping</h2>
    <fieldset>
                <legend>Select a shipping option</legend>
                
           
    <% foreach (MvcMusicStore.Models.ShippingMethod c in Model)
       {
       %>
            <div class="editor-label">
         <%= Html.RadioButton("ShippingOption",c.Name)%><%= c.Description%>
          
          
     </div>
    
    <%} %> 
    </fieldset>
