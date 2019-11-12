///Author: Sohel Rana
/* Version 1.3
Modified on 27-Oct-2013    
Changes:
 1. css class support with js varaiable 'folder_nav_css'
 2. Added support for 'list/library' title or 'Root' for root folder through js variable 'useDocLibTitleAsRootFolderName'
*/

/*Version 1.2
Modified on 27-Oct-2013
Changes:
  1. Added in galleary
  2. Fixed the bug 'Filtering by clicking on field title would result duplicate navigation link'
  3. Fixed the bug 'breadcrumb title always lowercase'. Now breadcrumb title is as like the folder name in the library even with case (lower/upper)
  */


var folder_nav_css = 'folder-nav-container';
var useDocLibTitleAsRootFolderName = false;//whether to show 'Root' for root folder or document library title

//replace query string key with value
function replaceQueryStringAndGet(url, key, value) {
    var re = new RegExp("([?|&])" + key + "=.*?(&|$)", "i");
    separator = url.indexOf('?') !== -1 ? "&" : "?";
    if (url.match(re)) {
        return url.replace(re, '$1' + key + "=" + value + '$2');
    }
    else {
        return url + separator + key + "=" + value;
    }
}


function folderNavigation() {
    function onPostRender(renderCtx) {
        if (renderCtx.rootFolder) {
            var listUrl = decodeURIComponent(renderCtx.listUrlDir);
            var rootFolder = decodeURIComponent(renderCtx.rootFolder);
            if (renderCtx.rootFolder == '' || rootFolder.toLowerCase() == listUrl.toLowerCase())
                return;

            //get the folder path excluding list url. removing list url will give us path relative to current list url
            var folderPath = rootFolder.toLowerCase().indexOf(listUrl.toLowerCase()) == 0 ? rootFolder.substr(listUrl.length) : rootFolder;
            var pathArray = folderPath.split('/');
            var navigationItems = new Array();
            var currentFolderUrl = listUrl;

            var rootNavItem =
                {
                    title: useDocLibTitleAsRootFolderName ? renderCtx.ListTitle : "Root",
                    url: replaceQueryStringAndGet(document.location.href, 'RootFolder', listUrl)
                };
            navigationItems.push(rootNavItem);

            for (var index = 0; index < pathArray.length; index++) {
                if (pathArray[index] == '')
                    continue;
                var lastItem = index == pathArray.length - 1;
                currentFolderUrl += '/' + pathArray[index];
                var item =
                    {
                        title: pathArray[index],
                        url: lastItem ? '' : replaceQueryStringAndGet(document.location.href, 'RootFolder', encodeURIComponent(currentFolderUrl))
                    };
                navigationItems.push(item);
            }
            RenderItems(renderCtx, navigationItems);
        }
    }


    //Add a div and then render navigation items inside span
    function RenderItems(renderCtx, navigationItems) {
        if (navigationItems.length == 0) return;
        var folderNavDivId = 'foldernav_' + renderCtx.wpq;
        var webpartDivId = 'WebPart' + renderCtx.wpq;


        //a div is added beneth the header to show folder navigation
        var folderNavDiv = document.getElementById(folderNavDivId);
        var webpartDiv = document.getElementById(webpartDivId);
        if (folderNavDiv != null) {
            folderNavDiv.parentNode.removeChild(folderNavDiv);
            folderNavDiv = null;
        }
        if (folderNavDiv == null) {
            var folderNavDiv = document.createElement('div');
            folderNavDiv.setAttribute('id', folderNavDivId);
            folderNavDiv.setAttribute('class', folder_nav_css);
            webpartDiv.parentNode.insertBefore(folderNavDiv, webpartDiv);
            folderNavDiv = document.getElementById(folderNavDivId);
        }


        for (var index = 0; index < navigationItems.length; index++) {
            if (navigationItems[index].url == '') {
                var span = document.createElement('span');
                span.innerHTML = navigationItems[index].title;
                folderNavDiv.appendChild(span);
            }
            else {
                var span = document.createElement('span');
                var anchor = document.createElement('a');
                anchor.setAttribute('href', navigationItems[index].url);
                anchor.innerHTML = navigationItems[index].title;
                span.appendChild(anchor);
                folderNavDiv.appendChild(span);
            }

            //add arrow (>) to separate navigation items, except the last one
            if (index != navigationItems.length - 1) {
                var span = document.createElement('span');
                span.innerHTML = '&nbsp;>&nbsp;';
                folderNavDiv.appendChild(span);
            }
        }
    }


    function _registerTemplate() {
        var viewContext = {};

        viewContext.Templates = {};
        viewContext.OnPostRender = onPostRender;
        SPClientTemplates.TemplateManager.RegisterTemplateOverrides(viewContext);
    }
    //delay the execution of the script until clienttempltes.js gets loaded
    ExecuteOrDelayUntilScriptLoaded(_registerTemplate, 'clienttemplates.js');
};

//RegisterModuleInit ensure folderNavigation() function get executed when Minimum Download Strategy is enabled.
//if you deploy the FolderNavigation.js file in '_layouts' folder use 'FolderNavigation.js' as first paramter.
//if you deploy the FolderNavigation.js file in '_layouts/folder/subfolder' folder, use 'folder/subfolder/FolderNavigation.js as first parameter'
//if you are deploying in master page gallery, use '/_catalogs/masterpage/FolderNavigation.js' as first parameter
RegisterModuleInit('/_catalogs/masterpage/FolderNavigation.js', folderNavigation);

//this function get executed in case when Minimum Download Strategy not enabled.
folderNavigation();
