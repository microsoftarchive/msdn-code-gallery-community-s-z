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

    var VALID_FILTERS = ['hourly', 'daily', 'weekly', 'monthly']
      , UPDATE_EVENT = 'update'
      , FILTER_EVENT = 'filter'

    // Contains the current set of data
      , cache = {};

    // This is the data access layer. In the real-world it would be
    // backed by a remote webservice, but in this demo it is backed
    // by DataService.js
    var GraphingModel = WinJS.Class.define(

        // Initialize
        function () {
            this._running = false;
            this._filter = VALID_FILTERS[0];
            this._updateCache();
        },

        {
            interval: {

                // Sets the time to wait before updating the cache in ms
                set: function (value) {
                    this._interval = value;
                }
            },

            filter: {

                // Sets the filter and triggers an update of the cache
                set: function (value) {

                    var wasRunning = this._running;

                    // Use the default filter if "value" is not a valid filter
                    if (VALID_FILTERS.indexOf(value) > -1) {
                        this._filter = value;
                    }
                    else {
                        this._filter = VALID_FILTERS[0];
                    }

                    this.stopTimer();

                    // Signal to listeners that a filter event has occured
                    this.dispatchEvent(FILTER_EVENT, { keys: this.keys, filter: this._filter });

                    this._updateCache();

                    // Restart the update timer if necessary
                    if (wasRunning) {
                        this.startTimer();
                    }
                },

                // Returns the current filter
                get: function () {
                    return this._filter;
                }
            },

            filters: {
                
                // Returns the list of valid filters
                get: function () {
                    return VALID_FILTERS;
                }
            },

            keys: {

                // Returns a list of in the cache. These keys will map to
                // specific sets of data, e.g: "footTraffic" or "revenue"
                get: function () {
                    return Object.keys(cache);
                }
            },

            data: {

                // Returns the data contained in the cache. If a key is provided
                // it will only return the data associated with that key
                get: function (key) {

                    if (!key) {
                        return cache;
                    }
                    else {
                        return cache[key];
                    }
                }
            },

            // Starts the update timer
            startTimer: function () {
                this._running = true;
                this._step();
            },

            // Pauses the update timer if it is running
            stopTimer: function () {

                this._running = false;

                if (this._timer) {
                    this._timer.cancel();
                    this._timer = null;
                }
            },

            // Continuously updates the cache
            _step: function () {

                this._timer = WinJS.Promise.timeout(this._interval).then(function () {
                    this._updateCache();
                    this._step();
                }.bind(this));
            },

            // Fetches fresh data from DataService and updates the cache
            _updateCache: function() {

                cache = Data.DataService.fetch();

                // Signal to listeners that an update event has ocurred
                this.dispatchEvent(UPDATE_EVENT, { keys: this.keys, filter: this._filter });
            }
        }, 
        {
            // Static list of valid filters
            filters: VALID_FILTERS
        }
    )

    // Gives GraphingModel the addEventListener, removeEventListener, and dispatchEvent methods
    WinJS.Class.mix(GraphingModel, WinJS.Utilities.eventMixin);

    // Exposes a single instance of GraphingModel
    WinJS.Namespace.define('Data', {
        GraphingModel: new GraphingModel() 
    });

}());