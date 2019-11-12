//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF 
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A 
//// PARTICULAR PURPOSE. 
//// 
//// Copyright (c) Microsoft Corporation. All rights reserved     
////
//// To see the topic that inspired this sample app, go to http://msdn.microsoft.com/en-us/library/windows/apps/dn163531

(function () {

    

    var DataContext = new WinJS.Class.define(function () {

        var lists = this.lists = {
            home: { list: new WinJS.Binding.List() },
            customerDetail: { list: new WinJS.Binding.List() }
        }

        // Get a reference for an item, using the group key and item title as a
        // unique reference to the item that can be easily serialized.
        this.getItemReference = function (item) {
            return [item.group.key, item.title];
        }

        // This function returns a WinJS.Binding.List containing only the items
        // that belong to the provided group.
        //this.getItemsFromGroup = function (group, list) {
        //    return list.createFiltered(function (item) { return item.group.key === group.key; });
        //}

        // Get the unique group corresponding to the provided group key.
        this.resolveGroupReference = function (key) {
            for (var i = 0; i < groupedItems.groups.length; i++) {
                if (groupedItems.groups.getAt(i).key === key) {
                    return groupedItems.groups.getAt(i);
                }
            }
        }

        // Get a unique item from the provided string array, which should contain a
        // group key and an item title.
        this.resolveItemReference = function (reference) {
            for (var i = 0; i < groupedItems.length; i++) {
                var item = groupedItems.getAt(i);
                if (item.group.key === reference[0] && item.title === reference[1]) {
                    return item;
                }
            }
        }

        // Returns an array of sample data that can be added to the application's
        // data list. 
        this.generateSampleData = function () {

            // Each of these sample groups must have a unique key to be displayed
            // separately. Type defines the renderer, and classes are added to the element.
            var dataGroups = [
                { key: "keyMetrics", title: "Key Metrics", subtitle: "Overall Sentiment", index: 1.0, type: "static", classes: "keyMetrics full" },
                { key: "keyMetrics", title: "Key Metrics", subtitle: "Revenue", index: 1.1, type: "static", classes: "keyMetrics full" },
                { key: "keyMetrics", title: "Key Metrics", subtitle: "Social Reach", index: 1.2, type: "static", classes: "keyMetrics full" },
                { key: "keyMetrics", title: "Key Metrics", subtitle: "Best Seller", index: 1.3, type: "static", classes: "keyMetrics full itemName" },

                { key: "socialReach", title: "Social Reach", subtitle: "Facebook", index: 2.0, type: "static", classes: 'socialReach full negative' },
                { key: "socialReach", title: "Social Reach", subtitle: "Twitter", index: 2.1, type: "static", classes: 'socialReach half negative' },
                { key: "socialReach", title: "Social Reach", subtitle: "Foursquare", index: 2.2, type: "static", classes: 'socialReach half' },
                { key: "socialReach", title: "Social Reach", subtitle: "", index: 2.3, type: "static", classes: 'socialReach staticChart' },

                { key: "footTraffic", title: "Foot Traffic", subtitle: "Sentiment", index: 3.0, type: "sentiment", classes: "box" },
                { key: "footTraffic", title: "Foot Traffic", subtitle: "Foot Traffic", index: 3.1, type: "graph", classes: '' },
                { key: "footTraffic", title: "Foot Traffic", subtitle: "Traffic", index: 3.2, type: "compiled", classes: "compiled full" },
                { key: "footTraffic", title: "Foot Traffic", subtitle: "Foot Traffic", index: 3.3, type: "max", classes: "max half" },
                { key: "footTraffic", title: "Foot Traffic", subtitle: "Foot Traffic", index: 3.4, type: "min", classes: "min half" },

                { key: "revenue", title: "Revenue", subtitle: "Sentiment", index: 4.0, type: "sentiment", classes: 'box' },
                { key: "revenue", title: "Revenue", subtitle: "Revenue", index: 4.1, type: "graph", classes: '' },
                { key: "revenue", title: "Revenue", subtitle: "Gross Earnings", index: 4.2, type: "gross", classes: 'gross full' },
                { key: "revenue", title: "Revenue", subtitle: "Net Earnings", index: 4.3, type: "net", classes: 'net full' },

                { key: "topProducts", title: "Top Products", subtitle: "Electronics", index: 5.0, type: "static", classes: 'topProducts half electronics' },
                { key: "topProducts", title: "Top Products", subtitle: "Food", index: 5.1, type: "static", classes: 'topProducts half food' },
                { key: "topProducts", title: "Top Products", subtitle: "Clothing", index: 5.2, type: "static", classes: 'topProducts half clothing' },
                { key: "topProducts", title: "Top Products", subtitle: "Appliances", index: 5.3, type: "static", classes: 'topProducts half appliances' },
                { key: "topProducts", title: "Top Products", subtitle: "", index: 5.4, type: "static", classes: 'topProducts staticChart' },

                { key: "pickups", title: "In-Store Pickups", subtitle: "Electronics", index: 6.0, type: "static", classes: 'pickups half electronics' },
                { key: "pickups", title: "In-Store Pickups", subtitle: "Food", index: 6.1, type: "static", classes: 'pickups half food' },
                { key: "pickups", title: "In-Store Pickups", subtitle: "Clothing", index: 6.2, type: "static", classes: 'pickups half clothing' },
                { key: "pickups", title: "In-Store Pickups", subtitle: "Appliances", index: 6.3, type: "static", classes: 'pickups half appliances' },
                { key: "pickups", title: "In-Store Pickups", subtitle: "", index: 6.4, type: "static", classes: 'pickups staticChart' },

                { key: "promotions", title: "Promotions", subtitle: "Sentiment", index: 6.0, type: "sentiment", classes: 'box' },
                { key: "promotions", title: "Promotions", subtitle: "Coupons!", index: 6.1, type: "graph" },
                { key: "promotions", title: "Promotions", subtitle: "", index: 6.2, type: "item", classes: 'promoItem box' },
                { key: "promotions", title: "Promotions", subtitle: "", index: 6.3, type: "item", classes: 'promoItem box' },
                { key: "promotions", title: "Promotions", subtitle: "", index: 6.4, type: "item", classes: 'promoItem box' },
                { key: "promotions", title: "Promotions", subtitle: "", index: 6.5, type: "item", classes: 'promoItem box' },

                { key: "restock", title: "Restock", subtitle: "", index: 7.0, type: "item", classes: 'restock full' },
                { key: "restock", title: "Restock", subtitle: "", index: 7.1, type: "item", classes: 'restock full' },
                { key: "restock", title: "Restock", subtitle: "", index: 7.2, type: "item", classes: 'restock full' },
                { key: "restock", title: "Restock", subtitle: "", index: 7.3, type: "item", classes: 'restock full' },

                { key: "conversionRate", title: "Conversion Rate", subtitle: "", index: 8.0, type: "static", classes: "conversionRate staticChart" },
                { key: "conversionRate", title: "Conversion Rate", subtitle: "Actual Conversions", index: 8.1, type: "static", classes: "conversionRate full actual" },
                { key: "conversionRate", title: "Conversion Rate", subtitle: "Conversions Goal", index: 8.2, type: "static", classes: "conversionRate full goal" },

                { key: "loyaltyCustomers", title: "Loyalty Customers", subtitle: "", index: 9.0, type: "static", classes: "loyaltyCustomers single" },

                { key: "mainCompetitors", title: "Main Competitors", subtitle: "Litware, Inc", index: 10.0, type: "static", classes: 'mainCompetitors full' },
                { key: "mainCompetitors", title: "Main Competitors", subtitle: "Adventure Works", index: 10.1, type: "static", classes: 'mainCompetitors full' },
                { key: "mainCompetitors", title: "Main Competitors", subtitle: "Northwind Traders", index: 10.2, type: "static", classes: 'mainCompetitors full' },
                { key: "mainCompetitors", title: "Main Competitors", subtitle: "Fabrikam", index: 10.3, type: "static", classes: 'mainCompetitors full' }
            ];
           
            return this.generateGroups(dataGroups);;
        }

        this.generateDetailData = function (cat) {
            var dataGroups;

            switch (cat) {
                case "customerDetail":
                    dataGroups = [                     
                        { key: "profile", title: "Profile", subtitle: "", index: 1.0, type: "static", classes: 'detail full profile', data: "images/"},
                        { key: "profile", title: "Profile", subtitle: "", index: 1.1, type: "static", classes: 'detail full profile', data: [{ key: "membership", title: "Membership", value: "Platinum Rewards" }, { key: "totalPoints", title: "Total Points Accumulated", value: 24089 } , { key: "memberSince", title: "Member Since", value: '02/16/2008' }] },

                        { key: "comments", title: "Comments", subtitle: "", index: 2.0, type: "static", classes: 'socialReach full negative' },
                        { key: "comments", title: "Comments", subtitle: "", index: 2.1, type: "static", classes: 'socialReach half negative' },
                        { key: "comments", title: "Comments", subtitle: "", index: 2.2, type: "static", classes: 'socialReach half' },

                        { key: "loyaltyProgress", title: "Loyalty Points Progress", subtitle: "Available Points", index: 3.0, type: "static", classes: 'loyaltyProgress double loyaltyChart' },
                        { key: "loyaltyProgress", title: "Loyalty Points Progress", subtitle: ["Next Reward:", "Gift Card"], index: 3.1, type: "static", classes: 'loyaltyProgress half' },
                        { key: "loyaltyProgress", title: "Loyalty Points Progress", subtitle: ["Future Reward:", "Gift Card"], index: 3.2, type: "static", classes: 'loyaltyProgress half' },
                        { key: "loyaltyProgress", title: "Loyalty Points Progress", subtitle: ["Future Reward:", "Off One Item"], index: 3.3, type: "static", classes: 'loyaltyProgress half' },
                        { key: "loyaltyProgress", title: "Loyalty Points Progress", subtitle: ["Future Reward:", "Off Total Purchase"], index: 3.4, type: "static", classes: 'loyaltyProgress half' },

                        { key: "availableRewards", title: "Available Rewards", subtitle: "Off Next Purchase", index: 4.0, type: "static", classes: 'availableRewards half' },
                        { key: "availableRewards", title: "Available Rewards", subtitle: "Off Next Purchase", index: 4.1, type: "static", classes: 'availableRewards half' },
                        { key: "availableRewards", title: "Available Rewards", subtitle: "In-Store Item Only", index: 4.2, type: "static", classes: 'availableRewards half' },

                        { key: "bonusRewards", title: "Bonus Rewards", subtitle: "Gas", index: 5.0, type: "static", classes: 'bonusRewards half' },
                        { key: "bonusRewards", title: "Bonus Rewards", subtitle: "Clothing", index: 5.1, type: "static", classes: 'bonusRewards half' },
                        { key: "bonusRewards", title: "Bonus Rewards", subtitle: "Off Next Purchase", index: 5.2, type: "static", classes: 'bonusRewards half' },
                        { key: "bonusRewards", title: "Bonus Rewards", subtitle: "Platinum Discount", index: 5.3, type: "static", classes: 'bonusRewards half' }

                        //{ key: "profile", title: "Profile", subtitle: "", index: 2.0, type: "static", classes: 'socialReach full negative' },
                        //{ key: "profile", title: "Profile", subtitle: "", index: 2.1, type: "static", classes: 'socialReach half negative' },
                       
                    ];
                    break;
                default:
                    dataGroups = [];
                    break;
            }
            return this.generateGroups(dataGroups);
        }

        this.generateGroups = function (dataGroups) {
            var inObj, outObj;
            var theArray = [];

            // creates the list of objects with the group property
            for (var i = 0; i < dataGroups.length; i++) {
                inObj = {};
                //inObj = theData[dataGroups[i].key];
                inObj.group = dataGroups[i];

                theArray.push(inObj);
            }

            return theArray;
        }

        // this will be called by the listview to create and define the groups
        this.getGroupedItemsModel = function (page) {

            this.generateSampleData().forEach(function (item) {
                lists.home.list.push(item);
            });

            this.groupedItems = this.createGroupedFromList(lists.home.list)

            this.lists.home.items = this.groupedItems;
            this.lists.home.groups = this.groupedItems.groups;

            return this;
        }

        this.getDetailItemsModel = function (cat) {
            this.generateDetailData(cat).forEach(function (item) {
                lists[cat].list.push(item);
            });

            this.groupedItems = this.createGroupedFromList(lists[cat].list)

            this.lists[cat].items = this.groupedItems;
            this.lists[cat].groups = this.groupedItems.groups;

            return this;
        }

        this.createGroupedFromList = function (list) {
            return list.createGrouped(
                function groupKeySelector(item) { return item.group.key; },
                function groupDataSelector(item) { return item.group; },
                function groupSorter(group1, group2) { return group1.index < group2.index; }
            );            
        }


    });

    WinJS.Namespace.define("Data", {
        //items: dc.groupedItems,
        //groups: dc.groupedItems.groups,
        //getItemReference: dc.getItemReference,
        //getItemsFromGroup: dc.getItemsFromGroup,
        //resolveGroupReference: dc.resolveGroupReference,
        //resolveItemReference: dc.resolveItemReference,
        DataContext: new DataContext()
    });


})();