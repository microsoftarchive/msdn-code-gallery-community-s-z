<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcMusicStore.Models.Order>" %>

    
    

    <h2>Shipping </h2>

    <fieldset>
        <legend>Shipping Information</legend>
        <%: Html.EditorForModel() %>
    </fieldset>