var appweburl = decodeURIComponent(getQueryStringParameter("SPAppWebUrl"));
var collListItem;
var webProperties;

$(document).ready(function () {
    SP.SOD.executeFunc('sp.js', 'SP.ClientContext', GetColumns);
    SP.SOD.executeOrDelayUntilScriptLoaded(CallRibbon, 'sp.ribbon.js');
});


function TileShadow() {
    $('.Tile-Description').parent().mouseenter(function () {
        $(this).children('.Tile-Description').css('top', '125px');
        $(this).children('.Tile-Description').animate({ top: '-=125' }, 300);
    }).mouseleave(function () {
        $(this).children('.Tile-Description').css('top', '0px');
        $(this).children('.Tile-Description').animate({ top: '+=125' }, 300);
    });

    $(function () {
        $(".column").sortable({
            connectWith: ".column",
            stop: function (event, ui) {
                
                $(function () {
                    var count = 1;
                    $('.tile').each(function (i, v) {
                        var $this = $(this);
                        var Order = count + ";#" + $(this).parent().attr('id');
                        //SP.SOD.executeFunc('sp.js', 'SP.ClientContext', updateListItem($(this).attr('id'), Order));
                        updateListItem($(this).attr('id'), Order);
                        count = count + 1;
                        if ($(this).width() === 320)
                        {
                            $(this).parent().width(340);
                        }
                        $(this).children().css('top', '125px');
                    });
                })
                SP.UI.Notify.addNotification('The Tiles are updated!', false);
                // alert(ui.item.attr('id'));
            }
        });
    });
}

function updateListItem(itemvalue, Order) {
   
    try {
        var clientContext = new SP.ClientContext.get_current();
        oList = clientContext.get_web().get_lists().getByTitle('Tiles');

        this.oListItem = oList.getItemById(itemvalue);

        oListItem.set_item('Order1', Order);
        oListItem.update();

        clientContext.executeQueryAsync(Function.createDelegate(this, this.onQueryitemSucceeded), Function.createDelegate(this, this.onQueryitemFailed));
    }
    catch (err) {
        alert(err);
    }
}
function onQueryitemSucceeded() {
    
}

function onQueryFailed(sender, args) {
    SP.UI.Notify.addNotification('Request failed. ' + args.get_message() + '\n' + args.get_stackTrace(), true);
}


function retrieveListItems() {
    var context = new SP.ClientContext.get_current();
    var oList = context.get_web().get_lists().getByTitle('Tiles');

    var camlQuery = new SP.CamlQuery();
    camlQuery.set_viewXml('<View><Query><Where><Eq><FieldRef Name=\'Hide\' /><Value Type=\'Boolean\'>False</Value></Eq></Where><OrderBy><FieldRef Name=\'Order1\'  Ascending=\'FALSE\' /></OrderBy></Query><ViewFields><FieldRef Name=\'Id\' /><FieldRef Name=\'Order1\' /><FieldRef Name=\'Title\' /><FieldRef Name=\'Description1\' /><FieldRef Name=\'BackgroundImageLocation\' /><FieldRef Name=\'LinkLocation\' /><FieldRef Name=\'Color\' /><FieldRef Name=\'LaunchBehavior\' /><FieldRef Name=\'Size\' /><FieldRef Name=\'Round\' /></ViewFields></View>');
    this.collListItem = oList.getItems(camlQuery);

    context.load(collListItem, 'Include(Id, Title, Description1, BackgroundImageLocation, LinkLocation, Color, Size, LaunchBehavior, Order1,Round)');

    context.executeQueryAsync(Function.createDelegate(this, this.onQuerySucceeded), Function.createDelegate(this, this.onQueryFailed));
}

/*
Description:
Return Propertybag "vti_TilesColumns" and create the columns where will be the Tiles
*/
function getWebPropertiesSucceeded() {
    var TotalColumns = webProperties.get_item('vti_TilesColumns');
    var HtmlColumns = "";
    for (var i = 0; i < TotalColumns; i++) {
        HtmlColumns += '<div class="column" id="Col' + i + '"></div>';
    }

    $("#TitleSettings").append(HtmlColumns);
    retrieveListItems();
}

/*
Description:
Create the Tiles HTML with all properties
*/
function onQuerySucceeded(sender, args) {
    var listItemInfo = '';

    var listItemEnumerator = collListItem.getEnumerator();
    
    while (listItemEnumerator.moveNext()) {
        var oListItem = listItemEnumerator.get_current();
        var Border='tile';
        var str = oListItem.get_item('Order1');
        var substr = str.split(';#');
        var Behavior = "";
        var PageUrl = "";

        if (oListItem.get_item('LaunchBehavior') === "Dialog")
        {
            PageUrl = "ShowDialogTile(\"" + oListItem.get_item('LinkLocation').get_url() + "\",\"" + oListItem.get_item('Title') + "\")";
            Behavior = "<a href='#' onclick='" + PageUrl + "'>";
        }
        else if (oListItem.get_item('LaunchBehavior') === "New Tab") {
            Behavior = "<a href='" + oListItem.get_item('LinkLocation').get_url() + "' target='_blank'>";
        }
        else {
            Behavior = "<a href='" + oListItem.get_item('LinkLocation').get_url() + "'>";
        }

        
        if (oListItem.get_item('Round')) {
            Border = 'tile Corner';
        }
        else {
            Border = 'tile';
        }
        

        if (oListItem.get_item('Size') === "LARGE")
        {
            $("#" + substr[1]).css('width', '340px');
            $("#" + substr[1]).prepend("<div id='" + oListItem.get_id() + "' class='" + Border + " " + oListItem.get_item('Color') + "' style='width:320px;background-image:url(" + encodeURI(oListItem.get_item('BackgroundImageLocation').get_url()) + ");'><div class='Tile-Description' style='width:320px'>" + Behavior + "<div style='float:left;width:50%;text-align:left;'>" + oListItem.get_item('Title') + "</div></a><div style='float:right;width:50%;text-align:right'><a href='#' onclick='ShowDialog(" + oListItem.get_id() + ")'  style='text-align:right;z-index:1000'><img src='../Images/EditOption.png' /></a></div>" + Behavior + "<p>" + oListItem.get_item('Description1') + "</p></a></div></div>");
                
        }
        else {
            $("#" + substr[1]).prepend("<div id='" + oListItem.get_id() + "' class='" + Border + " " + oListItem.get_item('Color') + "' style='background-image:url(" + encodeURI(oListItem.get_item('BackgroundImageLocation').get_url()) + ");'><div class='Tile-Description'>" + Behavior + "<div style='float:left;width:50%;text-align:left;'>" + oListItem.get_item('Title') + "</div></a><div style='float:right;width:50%;text-align:right'><a href='#' onclick='ShowDialog(" + oListItem.get_id() + ")'  style='text-align:right;z-index:1000'><img src='../Images/EditOption.png' /></a></div>" + Behavior + "<p>" + oListItem.get_item('Description1') + "</p></a></div></div>");
        }
        
    }

    TileShadow();
}

function GetColumns() {
    var clientContext = new SP.ClientContext.get_current();
    webProperties = clientContext.get_web().get_allProperties();
    clientContext.load(webProperties, 'vti_TilesColumns');
    clientContext.executeQueryAsync(Function.createDelegate(this, this.getWebPropertiesSucceeded),
    Function.createDelegate(this, this.onQueryFailed));
}
function ShowDialog(ID) {

    var options = {
        url: "../Lists/Tiles/EditForm.aspx?ID=" +ID,
        allowMaximize: true,
        title: "Edit Tile",
        dialogReturnValueCallback: scallback
    };
    SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);   
    return false;
}
function scallback(dialogResult, returnValue) {
    if (dialogResult == SP.UI.DialogResult.OK) {
        SP.UI.ModalDialog.RefreshPage(SP.UI.DialogResult.OK);
    }
}

function ShowDialogTile(PageUrl, Title) {

    var options = {
        url: PageUrl ,
        allowMaximize: true,
        title: Title
    };
    SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    return false;
}

function CallRibbon() {

    var pm = SP.Ribbon.PageManager.get_instance();

    pm.add_ribbonInited(function () {
        TileTab();
    });

    var ribbon = null;
    try {
        ribbon = pm.get_ribbon();
    }
    catch (e) { }

    if (!ribbon) {
        if (typeof (_ribbonStartInit) == "function")
            _ribbonStartInit(_ribbon.initialTabId, false, null);
    }
    else {
        TileTab();
    }
}

function TileTab() {
    var shtml = "";
    var shtmlAction = "";
    shtml += "<a href='../Lists/Tiles/' ><img src='../images/View.png' /></a><br/>Tiles View";
    shtmlAction += "<a href='#' onclick='CallColumns();return false;'><img src='../Images/Columns32.png' /></a><br/>Manage Tiles Columns";

    var ribbon = SP.Ribbon.PageManager.get_instance().get_ribbon();
    if (ribbon !== null) {
        var tab = new CUI.Tab(ribbon, 'Tiles.Tab', 'Tiles', 'Use this tab to Manage Tiles', 'Tiles.Tab.Command', false, '', null);
        ribbon.addChildAtIndex(tab, 1);
        var group = new CUI.Group(ribbon, 'Tiles.Tab.Group', 'Tiles View', 'Use this group to manage Tiles operations', 'Tiles.Group.Command', null);
        tab.addChild(group);
        var group = new CUI.Group(ribbon, 'Tiles.Tab.Group', 'Tiles Actions', 'Use this group to manage Tiles operations', 'Tiles.Group.Command', null);
        tab.addChild(group);
    }
    SelectRibbonTab('Tiles.Tab', true);
    $("span:contains('Tiles View')").prev("span").html(shtml);
    $("span:contains('Tiles Actions')").prev("span").html(shtmlAction);
    SelectRibbonTab('Ribbon.Read', true);
}
function CallColumns() {
    var options = {
        url: '../Pages/TilesColumns.aspx',
        allowMaximize: true,
        title: 'Manage Columns',
        dialogReturnValueCallback: scallback
    };
    SP.SOD.execute('sp.ui.dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
}
function scallback(dialogResult, returnValue) {
    SP.UI.ModalDialog.RefreshPage(dialogResult);
}
function getQueryStringParameter(paramToRetrieve) {
    var params =
        document.URL.split("?")[1].split("&");
    var strParams = "";
    for (var i = 0; i < params.length; i = i + 1) {
        var singleParam = params[i].split("=");
        if (singleParam[0] === paramToRetrieve)
            return singleParam[1];
    }
}