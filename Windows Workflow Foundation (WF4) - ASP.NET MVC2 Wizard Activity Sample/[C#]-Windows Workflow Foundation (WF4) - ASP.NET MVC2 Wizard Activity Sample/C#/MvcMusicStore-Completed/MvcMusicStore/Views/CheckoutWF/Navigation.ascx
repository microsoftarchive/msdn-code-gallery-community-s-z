<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WizardActivityPack.Activities.CustomBookmark>" %>


 <input type="submit" name="Command" value="Start" />
<% if (Model.HasBack) {  %>
	 <input type="submit" name="Command" value="Back" />
     <% }  %>
     <% if (Model.HasNext) {  %>
	 <input type="submit" name="Command" value="Next" />
         <% }  %>