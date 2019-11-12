var siteUrl = '/sites/MySiteCollection';
var dfd = $.Deferred();
 
$(function () {
    // When the function has finished...
    $.when(retrieveListItemsInclude())
       .done(function (data) {
          // To do something
       })
       .fail(function (sender, args) {
          // To do something
       });
});

function retrieveListItemsInclude() {
 
    var clientContext = new SP.ClientContext(siteUrl);
    var oList = clientContext.get_web().get_lists().getByTitle('Announcements');
 
    var camlQuery = new SP.CamlQuery();
    camlQuery.set_viewXml('100');
    this.collListItem = oList.getItems(camlQuery);
 
    clientContext.load(collListItem, 'Include(Id, DisplayName, HasUniqueRoleAssignments)');
 
    clientContext.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceeded), Function.createDelegate(this, this.onQueryFailed));
     
    return dfd;
}
 
function onQuerySucceeded(sender, args) {
 
    var listItemInfo = '';
    var listItemEnumerator = collListItem.getEnumerator();
         
    while (listItemEnumerator.moveNext()) {
        var oListItem = listItemEnumerator.get_current();
        listItemInfo += '\nID: ' + oListItem.get_id() + 
            '\nDisplay name: ' + oListItem.get_displayName() + 
            '\nUnique role assignments: ' + oListItem.get_hasUniqueRoleAssignments();
    }
 
    dfd.resolve(listItemInfo.toString());
}
 
function onQueryFailed(sender, args) {
    dfd.reject(sender, args);
}
