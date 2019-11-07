'use strict';

ExecuteOrDelayUntilScriptLoaded(initializePage, "sp.js");

function initializePage()
{
    var user;
    var web;
    var webGroupsCollection; //gets a  web specificc groups
    var webCollection;
    var roleAssignments;
    var siteGroupsCollection ; //gets all site collections groups
    var collUser;
    var hostweburl;
    var appweburl ;
    var hostcontext;
    var appContextSite;
    var context;
    var factory;
    var currentWeb;
    var site;
    var rootWeb;
    var subWebs;
    var web;
    
    // This code runs when the DOM is ready and creates a context object which is needed to use the SharePoint object model
    $(document).ready(function () {


        hostweburl =
            decodeURIComponent(
                getQueryStringParameter("SPHostUrl")
        );
        appweburl =
            decodeURIComponent(
                getQueryStringParameter("SPAppWebUrl")
        );
       

        // resources are in URLs in the form: // web_url/_layouts/15/resource
        var scriptbase = hostweburl + "/_layouts/15/";

        // Load the js files and continue to the successHandler
        $.getScript(scriptbase + "SP.js",
                        function () { $.getScript(scriptbase + "SP.RequestExecutor.js", execCrossDomainRequest); }
        );
    });

    // Function to prepare and issue the request to get SharePoint data
    function execCrossDomainRequest() {

        // context: The ClientContext object provides access to the web and lists objects.
        context = new SP.ClientContext(appweburl);

        // factory: Initialize the factory object with the app web URL.
        factory = new SP.ProxyWebRequestExecutorFactory(appweburl);
        context.set_webRequestExecutorFactory(factory);
        appContextSite = new SP.AppContextSite(context, hostweburl);


        currentWeb = appContextSite.get_web();
        site = appContextSite.get_site();
        rootWeb = site.get_rootWeb();
        webCollection = rootWeb.get_webs();


        siteGroupsCollection = rootWeb.get_siteGroups();//To get the site collection groups
        roleAssignments = rootWeb.get_roleAssignments() //To get the groups from web/subsite level

        
        //Load to prepare the query
        context.load(webCollection)
        context.load(currentWeb);
        context.load(siteGroupsCollection);
        context.load(roleAssignments);
        context.load(siteGroupsCollection, 'Include(Title,Id,Users.Include(Title,Email))');

        //Execute the query with all the previous options and parameters
        context.executeQueryAsync(
            Function.createDelegate(this, onQuerySucceeded),
            Function.createDelegate(this, errorHandler)
        );

         // Function to handle the error event.Display the error message to the page.
        function errorHandler(data, errorCode, errorMessage) {
            document.getElementById("ErrorMessage").innerText =
                "Error occurred while retireving information. " + errorMessage;
        }
    }

    //Function to retrieve all user groups, and user information
    function onQuerySucceeded() {
     
        var userInfo = new Array();
        var webArray = [];
        var webGroupsCollectionArray = [];

        var webEnumerator = webCollection.getEnumerator();

        while (webEnumerator.moveNext()) {

            //get current website's groups
            web= webEnumerator.get_current();
            webGroupsCollection = web.get_roleAssignments().get_groups();

            //gets a  web specific groups
            context.load(webGroupsCollection);
            context.load(webGroupsCollection, 'Include(Users)');

            //Add the groups and web site information to array
            webArray.push(web);
            webGroupsCollectionArray.push(webGroupsCollection);
        }

        //Execute the query with all the previous options and parameters
            context.executeQueryAsync(
            function () {
                var index = 0;

                //Loop through each website and get the groups
                for (var i = 0; i < webArray.length; i++) {

                    var row = [];

                    row["webtitle"] = webArray[i].get_title();
                    row["weburl"] = webArray[i].get_url();

                    //Get all groups from the website
                    var groupEnumerator = webGroupsCollectionArray[i].getEnumerator();

                    if (webGroupsCollectionArray[i].get_count() == 0) { //If no groups added in the web
                        row["webtitle"] = webArray[i].get_title();
                        row["weburl"] = webArray[i].get_url();
                        row["groupid"] = "";
                        row["groupname"] = "";
                        row["username"] = "";
                        row["emailid"] = "";
                        userInfo[index++] = row;
                        row = [];
                    }
                    else
                        {
                        while (groupEnumerator.moveNext()) {

                            var oGroup = groupEnumerator.get_current();
                            var collUser = oGroup.get_users();

                            //Get all users from the group
                            var userEnumerator = collUser.getEnumerator();

                            if (collUser.get_count() == 0) { //If not users in the group
                                row["webtitle"] = webArray[i].get_title();
                                row["weburl"] = webArray[i].get_url();
                                row["groupid"] = oGroup.get_id();
                                row["groupname"] = oGroup.get_title();
                                row["username"] = "";
                                row["emailid"] = "";
                                userInfo[index++] = row;
                                row = [];
                            }
                            else {
                                while (userEnumerator.moveNext()) {

                                    //Add the properties to an array.
                                    var oUser = userEnumerator.get_current();
                                    row["webtitle"] = webArray[i].get_title();
                                    row["weburl"] = webArray[i].get_url();
                                    row["groupid"] = oGroup.get_id();
                                    row["groupname"] = oGroup.get_title();
                                    row["username"] = oUser.get_title();
                                    row["emailid"] = oUser.get_email();
                                    userInfo[index++] = row;
                                    row = [];

                                }
                            }
                        }
                    }                      
                }
                showGrid(userInfo);

            },
            Function.createDelegate(this, errorHandler)
        );

            function errorHandler(data, errorCode, errorMessage) {
                document.getElementById("ErrorMessage").innerText =
                    "Error occurred while retireving information. " + errorMessage;
            }
    }

    //Funtion to bind the data to grid.
    function showGrid(data){
        var source =
        {
            localdata: data,
            datatype: "array"
        };
        $("#jqxgrid").jqxGrid(
        {
            width: 1300,
            height: 420,
            source: source,
            showfilterrow: true,
            columnsresize: true,
            sortable: true,
            filterable: true,
            enabletooltips: true,
            autoshowfiltericon: true,
            groupable: true,
            columns: [
              { text: 'Web Title', datafield: 'webtitle', width: '10%' },
              { text: 'Group ID', datafield: 'groupid', width: '10%' },
              { text: 'Group Name', datafield: 'groupname', width: '15%' },
              { text: 'User Name', datafield: 'username', width: '15%' },
              { text: 'Email', datafield: 'emailid', width: '30%' },
              { text: 'Web URL', datafield: 'weburl', width: '30%' }

            ]
        });
    };
                    
    jQuery.browser = {};
    (function () {
        jQuery.browser.msie = false;
        jQuery.browser.version = 0;
        if (navigator.userAgent.match(/MSIE ([0-9]+)\./)) {
            jQuery.browser.msie = true;
            jQuery.browser.version = RegExp.$1;
        }
    })();
   

    function getQueryStringParameter(paramToRetrieve) {
        var params =
            document.URL.split("?")[1].split("&");
        var strParams = "";
        for (var i = 0; i < params.length; i = i + 1) {
            var singleParam = params[i].split("=");
            if (singleParam[0] == paramToRetrieve)
                return singleParam[1];
        }
    }
}
