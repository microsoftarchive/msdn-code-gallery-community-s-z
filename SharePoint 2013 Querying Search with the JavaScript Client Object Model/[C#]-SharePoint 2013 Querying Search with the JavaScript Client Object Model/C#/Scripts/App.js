'use strict';

var results;

var context = SP.ClientContext.get_current();
var user = context.get_web().get_currentUser();

// This code runs when the DOM is ready and creates a context object which is needed to use the SharePoint object model
$(document).ready(function () {

    $("#searchButton").click(function () {
        var keywordQuery = new Microsoft.SharePoint.Client.Search.Query.KeywordQuery(context);
        keywordQuery.set_queryText($("#searchTextBox").val());

        var searchExecutor = new Microsoft.SharePoint.Client.Search.Query.SearchExecutor(context);
        results = searchExecutor.executeQuery(keywordQuery);

        context.executeQueryAsync(onQuerySuccess, onQueryFail)
    });
});


function onQuerySuccess() {
    $("#resultsDiv").append('<table>');

    $.each(results.m_value.ResultTables[0].ResultRows, function () {
        $("#resultsDiv").append('<tr>');
        $("#resultsDiv").append('<td>' + this.Title + '</td>');
        $("#resultsDiv").append('<td>' + this.Author + '</td>');
        $("#resultsDiv").append('<td>' + this.Write + '</td>');
        $("#resultsDiv").append('<td>' + this.Path + '</td>');
        $("#resultsDiv").append('</tr>');
    });

    $("#resultsDiv").append('</table>');
}

function onQueryFail(sender, args) {
    alert('Query failed. Error:' + args.get_message());
}
