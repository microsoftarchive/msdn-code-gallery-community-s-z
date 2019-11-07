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

    var dataContext = Data.DataContext.getDetailItemsModel('customerDetail');

    // Renders and returns the appropriate tile
    function homeRenderer(itemPromise) {

        var tile, element;

        tile = Ideabook.Tile.create('customerDetail', itemPromise._value.data.group);

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
                header._element.className = (item.handle.match(/availableRewards|bonusRewards/)) ? 'active' : '';
                header.data = item;
            })
        };
    };

    ui.Pages.define("/pages/customerDetail/customerDetail.html", {

        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        ready: function (element, options) {
            var listView = element.querySelector(".groupeditemslist").winControl;
            WinJS.UI.setOptions(listView, {
                itemTemplate: homeRenderer,
                groupHeaderTemplate: groupHeaderRenderer,
                selectionMode: 'single',
                tapBehavior: 'none'
            });

            this._initializeLayout(listView, appView.value);
            listView.element.focus();
        },

        // This function updates the page layout in response to viewState changes.
        updateLayout: function (element, viewState, lastViewState) {
            /// <param name="element" domElement="true" />

            var listView = element.querySelector(".groupeditemslist").winControl;
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
            listView.itemDataSource = dataContext.lists.customerDetail.items.dataSource;
            listView.groupDataSource = dataContext.lists.customerDetail.groups.dataSource;
            listView.layout = new ui.GridLayout({
                groupHeaderPosition: "top",
                groupInfo: {
                    enableCellSpanning: true,
                    cellWidth: 10,
                    cellHeight: 125
                },
                maxRows: 4

            });
            this.renderHeader(dataContext.lists.customerDetail.groups.dataSource);

            listView.onselectionchanging = function (evt) {
                
                evt.detail.newSelection.getItems().then(function (res) {
                    if (!res || !res[0].groupKey.match(/availableRewards|bonusRewards/)) {
                        evt.preventDefault();
                    }
                });
            };
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
        }
    });
})();
