<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcMusicStore.Models.Order>" %>

    <h2>Billing</h2>
  
    <fieldset>
        <legend>Billing Information</legend>
        <%: Html.EditorForModel() %>
    </fieldset>