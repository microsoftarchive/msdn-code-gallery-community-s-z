//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF 
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A 
//// PARTICULAR PURPOSE. 
//// 
//// Copyright (c) Microsoft Corporation. All rights reserved     
////
//// To see the topic that inspired this sample app, go to http://msdn.microsoft.com/en-us/library/windows/apps/dn163531

(function () {
    "use strict";

    var appView = Windows.UI.ViewManagement.ApplicationView;
    var appViewState = Windows.UI.ViewManagement.ApplicationViewState;
    var nav = WinJS.Navigation;
    var ui = WinJS.UI;

    var dataContext = Data.DataContext.getGroupedItemsModel();

    // Renders and returns the appropriate tile
    function homeRenderer(itemPromise) {

        var tile, element;
        switch (itemPromise._value.data.group.type) {
            case 'graph':
                tile = Ideabook.Tile.create(itemPromise._value.data.group.key, itemPromise._value.data.group);
                break;
            case 'static':
                tile =  tile = Ideabook.Tile.create('static', itemPromise._value.data.group);
                break;
            default :
                tile = Ideabook.Tile.create('keyMetrics', itemPromise._value.data.group);
                break;
        }
        tile._element.classList.add('win-item-' + itemPromise.handle)

        return {
            element: tile._element,
            renderComplete: itemPromise
        };
    };

    // Simply creates and returns the header of the tile groups
    function groupHeaderRenderer(itemPromise) {
        var header = new Ideabook.GroupHeader(itemPromise._value.data.group);
        return {
            element: header._element,
            renderComplete: itemPromise.then(function (item) {
                header._element.className = (item.handle.match(/socialReach/)) ? 'active' : '';
                header.data = item;
            })
        };
    };

    ui.Pages.define("/pages/groupedItems/groupedItems.html", {

        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        listView: '',

        ready: function (element, options) {
            this.listView = element.querySelector(".groupeditemslist").winControl;
            var listView = this.listView;
            WinJS.UI.setOptions(listView, {
                itemTemplate: homeRenderer,
                groupHeaderTemplate: groupHeaderRenderer,
                selectionMode: 'none',
                tapBehavior: 'invokeOnly'
            });

            this._initializeLayout(listView, appView.value);
            listView.element.focus();
            this.bindEventListeners();
        },
        unload: function() {
            this.unbindEventListeners();
        },

        // This function updates the page layout in response to viewState changes.
        updateLayout: function (element, viewState, lastViewState) {
            /// <param name="element" domElement="true" />

            var listView = this.listView;
            if (lastViewState !== viewState) {
                if (lastViewState === appViewState.snapped || viewState === appViewState.snapped) {
                    var handler = function (e) {
                        listView.removeEventListener("contentanimating", handler, false);
                        e.preventDefault();
                    }
                    listView.addEventListener("contentanimating", handler, false);
                    this._initializeLayout(listView, viewState);
                }
            }
        },

        // This function updates the ListView with new layouts
        _initializeLayout: function (listView, viewState) {          
            listView.itemDataSource = dataContext.lists.home.items.dataSource;
            listView.groupDataSource = dataContext.lists.home.groups.dataSource;
            listView.layout = new ui.GridLayout({
                groupHeaderPosition: "top",
                groupInfo: {
                    enableCellSpanning: true,
                    cellWidth: 10,
                    cellHeight: 125
                },
                maxRows: 4

            });
            this.renderHeader(dataContext.lists.home.groups.dataSource);
        },

        // Renders the dropdown next to the Contoso logo, and sets an event listener on change.
        renderHeader: function (data) {

            var dropdown = document.querySelector('#header-select')
              , filterArray = Data.GraphingModel.filters
              , opt;

            for (var i = 0, len = filterArray.length; i < len; i++) {
                opt = document.createElement('option');
                opt.setAttribute('value', filterArray[i]);
                opt.textContent = filterArray[i];
                dropdown.appendChild(opt);
            }

            dropdown.addEventListener('change', function (evt) {
                Data.GraphingModel.filter = evt.target.value;
            });
        },

        bindEventListeners: function() {
            this.listView.element.addEventListener('iteminvoked', this.onItemInvoked);
        },

        unbindEventListeners: function() {
            this.listView.removeEventListener('iteminvoked', this.onItemInvoked);
        },

        onItemInvoked: function (evt) {
            var item = Data.DataContext.lists.home.items.getAt(evt.detail.itemIndex);
            switch (item.group.key) {
                case "socialReach":
                    WinJS.Navigation.navigate('/pages/customerDetail/customerDetail.html', {});
                    break;
                default:
                    console.log(item.group.key);
                    break;
            }
        }
    });
})();
