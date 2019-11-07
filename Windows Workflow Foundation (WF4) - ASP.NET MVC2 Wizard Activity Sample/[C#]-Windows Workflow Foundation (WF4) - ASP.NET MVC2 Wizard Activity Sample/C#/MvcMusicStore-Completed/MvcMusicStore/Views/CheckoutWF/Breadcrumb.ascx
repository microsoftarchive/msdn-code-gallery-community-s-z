<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<WizardActivityPack.Activities.CustomBookmark>>" %>

 
 <p>
    <% foreach (var item in Model) { %>
    
    
    <% if (item != Model.Last())
       {  %>
    <a href="?Command=GoTo&Step=<%: item.StepID%>"><%:item.StepName%> > </a> 
   <%}
       else {  %>
       <%:item.StepName%> 
    <% } %>    
    <% } %>

    
     </p>

