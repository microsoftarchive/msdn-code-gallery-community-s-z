'use strict';

var context = SP.ClientContext.get_current();

// This code runs when the DOM is ready and creates a context object which is needed to use the SharePoint object model
$(document).ready(function () {

    var spAppWebUrl = decodeURIComponent(getQueryStringParameter('SPAppWebUrl'));

    $("#searchButton").click(function () {
        var queryUrl = spAppWebUrl + "/_api/search/query?querytext='" + $("#searchTextBox").val() + "'";

        $.ajax({ url: queryUrl, method: "GET", headers: { "Accept": "application/json; odata=verbose" }, success: onQuerySuccess, error: onQueryError });
    });

});

function onQuerySuccess(data) {
    var results = data.d.query.PrimaryQueryResult.RelevantResults.Table.Rows.results;

    $("#resultsDiv").append('<table>');

    $.each(results, function () {
        $("#resultsDiv").append('<tr>');
        $.each(this.Cells.results, function () {
            $("#resultsDiv").append('<td>' + this.Value + '</td>');
        });
        $("#resultsDiv").append('</tr>');
    });

    $("#resultsDiv").append('</table>');
}

function onQueryError(error) {
    $("#resultsDiv").append(error.statusText)
}

//function to get a parameter value by a specific key
function getQueryStringParameter(urlParameterKey) {
    var params = document.URL.split('?')[1].split('&');
    var strParams = '';
    for (var i = 0; i < params.length; i = i + 1) {
        var singleParam = params[i].split('=');
        if (singleParam[0] == urlParameterKey)
            return decodeURIComponent(singleParam[1]);
    }
}