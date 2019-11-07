//'use strict';

ExecuteOrDelayUntilScriptLoaded(initializePage, "sp.js");

function initializePage() {
    var context = SP.ClientContext.get_current();
    var user = context.get_web().get_currentUser();
    var hostweburl;
    var appweburl;
    var appContextSite;
    var list;
    var listItems;
    var web;


    // This code runs when the DOM is ready and creates a context object which is needed to use the SharePoint object model
    $(document).ready(function () {
        getUrl();
    });

    // This function get the URL informations
    function getUrl() {
        hostweburl = getQueryStringParameter("SPHostUrl");
        appweburl = getQueryStringParameter("SPAppWebUrl");
        hostweburl = decodeURIComponent(hostweburl);
        appweburl = decodeURIComponent(appweburl).toString().replace("#", "");
        var scriptbase = hostweburl + "/_layouts/15/";
        $.getScript(scriptbase + "SP.RequestExecutor.js", execOperation);
    }

    // This function get list data from SharePoint
    function execOperation() {
        var factory = new SP.ProxyWebRequestExecutorFactory(appweburl);
        context.set_webRequestExecutorFactory(factory);
        appContextSite = new SP.AppContextSite(context, hostweburl);
        web = appContextSite.get_web();
        context.load(web);
        var camlQuery = new SP.CamlQuery();
        list = web.get_lists().getByTitle("Post Reach");
        listItems = list.getItems(camlQuery);
        context.load(list);
        context.load(listItems);
        context.executeQueryAsync(onGetSPListSuccess, onGetSPListFail);
    }


    // This function is executed if the above call is successful
    function onGetSPListSuccess() {
        $("#DivSPGrid").empty();
        var chartlabel = '';
        var chartdata1 = '';
        var chartdata2 = '';
        var barChartData = '';
        var listEnumerator = listItems.getEnumerator();
        chartlabel = "{\"labels\":[";
        chartdata1 = "],\"datasets\":[{" +
			    "\"fillColor\":\"rgba(220,220,220,0.5)\"," +
        "\"strokeColor\":\"rgba(220,220,220,0.8)\"," +
        "\"highlightFill\":\"rgba(220,220,220,0.75)\"," +
        "\"highlightStroke\":\"rgba(220,220,220,1)\"," +
        "\"data\":[";
        chartdata2 = "]},{" +
           "\"fillColor\":\"rgba(151,187,205,0.5)\"," +
           "\"strokeColor\":\"rgba(151,187,205,0.8)\"," +
           "\"highlightFill\":\"rgba(151,187,205,0.75)\"," +
           "\"highlightStroke\":\"rgba(151,187,205,1)\"," +
           "\"data\":[";
        while (listEnumerator.moveNext()) {
            var listItem = listEnumerator.get_current();
            chartlabel += "\"" + listItem.get_item("Title") + "\",";
            chartdata1 += listItem.get_item("Facebook") + ",";
            chartdata2 += listItem.get_item("Twitter") + ",";
        }
        chartlabel = chartlabel.replace(/,\s*$/, "");
        chartdata1 = chartdata1.replace(/,\s*$/, "");
        chartdata2 = chartdata2.replace(/,\s*$/, "");
        var str = chartlabel + chartdata1 + chartdata2 + ']}]}';
        barChartData = JSON.parse(str);
        var ctx = document.getElementById("chartCanvas").getContext("2d");
        window.myBar = new Chart(ctx).Bar(barChartData, { responsive: true });
    }

    // This function is executed if the above call fails
    function onGetSPListFail(sender, args) {
        alert('Failed to get list data. Error:' + args.get_message());
    }

    //This function split the url and trim the App and Host web URLs
    function getQueryStringParameter(paramToRetrieve) {
        var params =
        document.URL.split("?")[1].split("&");
        for (var i = 0; i < params.length; i = i + 1) {
            var singleParam = params[i].split("=");
            if (singleParam[0] == paramToRetrieve)
                return singleParam[1];
        }
    }
}
