// Code Sample:
// Author: @MuShannak 

var context,
    web,
    spItems,
    position,
    nextPagingInfo,
    previousPagingInfo,
    listName = 'ContactsList',
    pageIndex = 1, // default page index value
    pageSize = 4, // default page size value
    list,
    camlQuery;

// This code runs when the DOM is ready and creates a context object which is needed to use the SharePoint object model 
$(document).ready(function () {
    context = SP.ClientContext.get_current();
    list = context.get_web().get_lists().getByTitle(listName);
    camlQuery = new SP.CamlQuery();

    $("#btnNext").click(function () {
        pageIndex = pageIndex + 1;
        if (nextPagingInfo) {
            position = new SP.ListItemCollectionPosition();
            position.set_pagingInfo(nextPagingInfo);
        }
        else {
            position = null;
        }

        GetListItems();
    });

    $("#btnBack").click(function () {
        pageIndex = pageIndex - 1;
        position = new SP.ListItemCollectionPosition();
        position.set_pagingInfo(previousPagingInfo);
        GetListItems();
    });

    GetListItems();
});

function GetListItems() {
    //Set the next or back list items collection position
    //First time the position will be null
    camlQuery.set_listItemCollectionPosition(position);

    // Create a CAML view that retrieves all contacts items  with assigne RowLimit value to the query
    camlQuery.set_viewXml("<View>" +
                              "<ViewFields>" +
                                     "<FieldRef Name='FirstName'/>" +
                                     "<FieldRef Name='Title'/>" +
                                     "<FieldRef Name='Company'/>" +
                                "</ViewFields>" +
                             "<RowLimit>" + pageSize + "</RowLimit></View>");

    spItems = list.getItems(camlQuery);

    context.load(spItems);
    context.executeQueryAsync(
            Function.createDelegate(this, onSuccess),
            Function.createDelegate(this, onFail)
        );
}

// This function is executed if the above OM call is successful
// This function render the returns items to html table
function onSuccess() {

    var listEnumerator = spItems.getEnumerator();
    var items = [];
    var item;

    while (listEnumerator.moveNext()) {
        item = listEnumerator.get_current();
        items.push("<td>" + item.get_item('FirstName') + "</td><td>" + item.get_item('Title') + "</td><td>" + item.get_item('Company') + "</td>");
    }

    var content = "<table><tr><th>First Name</th><th>Last Name</th><th>Company</th></tr><tr>"
                + items.join("</tr><tr>") + "</tr></table>";
    $('#content').html(content);

    managePagerControl();
}

function managePagerControl() {

    if (spItems.get_listItemCollectionPosition()) {
        nextPagingInfo = spItems.get_listItemCollectionPosition().get_pagingInfo();
    } else {
        nextPagingInfo = null;
    }

    //The following code line shall add page information between the next and back buttons
    $("#pageInfo").html((((pageIndex - 1) * pageSize) + 1) + " - " + ((pageIndex * pageSize) - (pageSize - spItems.get_count())));

    previousPagingInfo = "PagedPrev=TRUE&Paged=TRUE&p_ID=" + spItems.itemAt(0).get_item('ID');

    if (pageIndex <= 1) {
        $("#btnBack").attr('disabled', 'disabled');
    }
    else {
        $("#btnBack").removeAttr('disabled');
    }

    if (nextPagingInfo) {
        $("#btnNext").removeAttr('disabled');
    }
    else {
        $("#btnNext").attr('disabled', 'disabled');
    }

}

// This function is executed if the above call fails
function onFail(sender, args) {
    alert('Failed to get items. Error:' + args.get_message());
}

