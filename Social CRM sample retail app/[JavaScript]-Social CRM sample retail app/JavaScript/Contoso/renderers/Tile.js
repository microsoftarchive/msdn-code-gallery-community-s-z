//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF 
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A 
//// PARTICULAR PURPOSE. 
//// 
//// Copyright (c) Microsoft Corporation. All rights reserved     
////
//// To see the topic that inspired this sample app, go to http://msdn.microsoft.com/en-us/library/windows/apps/dn163531

// the base class upon which all tiles are based. 
// tiles inherit the listeners and functions, providing a way
// to update all on update or filter. 

// Specific renderers for tiles are specified as static members, and 
// invoked by groupedItems.js

WinJS.Namespace.define("Ideabook", {
    Tile: WinJS.Class.define(//constructor, instanceMembers, staticMembers

    // constructor
    function (data, key) {

        // key is optional. Currently used by KeyMetrics to grab associated data for a given tile.
        this.key = key || '';

        this.model = Data.GraphingModel;
        this.model.addEventListener('update', this.onupdate.bind(this));
        this.model.addEventListener('filter', this.onfilter.bind(this));
        this._render(data);
    },

    // instance members (in an object)
    {
        data: {
            get: function () {
                return this.model.data[this.key];
            }
        },

        addEventListener: function (type, handler, useCapture) {
            this._element.addEventListener(type, handler, useCapture);
        },

        onfilter: function(evt) {
            this._update();
            // if a particular tile needs to handle rendering filtering differently than updating, it can override this method
        },

        onupdate: function(evt) {
            this._update();
        },

        _update: function () {
            // this will be overriden by the specific tile renderers
        },

        _render: function (group) {
            // this will be overriden by the specific tile renderers
        }

    },
    // Static Members
    {
        create: function (type, data) {
            switch(type) {
                case 'footTraffic':
                    return new Ideabook.FootTrafficTile(data);
                    break;
                case 'revenue':
                    return new Ideabook.RevenueTile(data);
                    break;
                case 'static':
                    return new Ideabook.StaticTile(data);
                    break;     
                case 'promotions':
                    return new Ideabook.PromotionsTile(data);
                    break;
                case 'customerDetail':
                    return new Ideabook.CustomerDetailTile(data);
                    break;
                case 'keyMetrics':
                default:
                    return new Ideabook.KeyMetricsTile(data);
                    break;
            }
        },

        // these static members are for visual consistency across tiles
        formatters: {
            hourly: d3.time.format('%-I%p'),
            daily: d3.time.format('%a'),
            weekly: d3.time.format('%b %-d'),
            monthly: d3.time.format('%b'),
            currency: d3.format('.3s')
        },

        duration: 400,

        height: 500,

        width: 700,
        
        margin: 20
    }
)
});
