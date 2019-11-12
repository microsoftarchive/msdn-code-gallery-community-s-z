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

    var ONE_HOUR         = 60 * 60 * 1000
      , HOURS_PER_DAY    = 24
      , HOURS_PER_WEEK   = 24 * 7
      , HOURS_PER_YEAR   = 24 * 365
      , DAYS_PER_WEEK    = 7
      , WEEKS_PER_PERIOD = 12
      , MONTHS_PER_YEAR = 12

    // Starts on the same date as our static data set, Data.Static, ends.
      , currentDate = new Date('2012-12-31T07:00:00.000Z').getTime()

    // Stores the current data set
      , state = {};

    // DataService manages the set of data used by the various charts
    // and graphs. It will generate random data each time the fetch()
    // method is called, and store the current data set in "state"
    var DataService = new WinJS.Class.define(

        // Initialize the data set
        function () {
            state = Data.Static;
        },

        {
            // Updates and returns the data set
            fetch: function () {
                step();
                return fetchState();
            }
        }
    );

    // Adds one hour of data to the current data set
    function step() {
        currentDate += ONE_HOUR;
        for (var key in state) {
            updateState(state[key]);
        }
    }

    // Returns only the "data" within the data set
    function fetchState() {
        var result = {};
        for (var key in state) {
            result[key] = state[key].data;
        }
        return result;
    }

    // Generates a random value within a certain range of "baseValue". If "date"
    // is provided, then the current hour is used to calculate the variance:
    // The result will be larger if the current hour is close to 12:00pm (noon).
    function random(baseValue, date) {

        var floor = baseValue
          , variance = .1
          , p;

        if (date) {
            p = Math.max(1, Math.abs(date.getHours() - 12) / 4);
            floor = baseValue / p;
        }

        return floor * (1 + Math.random() - variance / (variance * 10)) << 0;
    }

    // Returns a shallow clone of an object. Primarily used to avoid errors
    // caused by changing values that were passed by reference.
    function clone(obj) {
        var result = JSON.parse(JSON.stringify(obj));
        if (result.date) {
            result.date = new Date(result.date);
        }
        return result;
    }

    // Creates a new entry in the data set. The format of the entry is
    // defined by a template. The "value" property of each item in the
    // template is used to generate a random value for the result.
    // 
    // e.g:
    // 
    // var templates = [
    //    { "label": "net", "value": 6000 },
    //    { "label": "gross", "value": 10000 }
    // ];
    //
    function createEntry(date, templates) {

        var result = { date: date, values: [], ct: 0 }
          , i = 0
          , len = templates.length
          , temp;

        for (i; i < len; i++) {
            temp = templates[i];
            temp.value = random(temp.value, date);
            result.values.push(temp)
        }

        return result;
    }

    // Adds a list of values to the values in an existing entry.
    function addValue(entry, values) {

        var result = entry
          , i = 0
          , len = values.length
          , temp;

        for (i; i < len; i++) {
            result.values[i].value += values[i].value;
        }

        entry.ct++;

        return result;
    }

    // Adds new values to the current data set.
    function updateState(state) {

        var model = state.data
          , curday = model.daily[model.daily.length - 1]
          , curweek = model.weekly[model.weekly.length - 1]
          , curmonth = model.monthly[model.monthly.length - 1]
          , date = new Date(currentDate)
          , templates = clone(state.templates)
          , curhour
          , newvalues;

        // Update hours
        model.hourly.push(createEntry(date, templates));
        if (model.hourly.length > HOURS_PER_DAY / 2) {
            model.hourly.shift();
        }

        curhour = model.hourly[model.hourly.length - 1];
        newvalues = curhour.values;

        // Update days
        if (curday && date.getDate() == curday.date.getDate()) {
            curday = addValue(curday, newvalues);
        }
        else {
            model.daily.push(clone(curhour));
        }
        if (model.daily.length > DAYS_PER_WEEK) {
            model.daily.shift();
        }

        // Update weeks
        if (curweek && curweek.ct < HOURS_PER_WEEK) {
            curweek = addValue(curweek, newvalues);
        }
        else {
            model.weekly.push(clone(curhour));
        }
        if (model.weekly.length > WEEKS_PER_PERIOD) {
            model.weekly.shift();
        }

        // Update months
        if (curmonth && date.getMonth() == curday.date.getMonth()) {
            curmonth = addValue(curmonth, newvalues);
        }
        else {
            model.monthly.push(clone(curhour));
        }
        if (model.monthly.length > MONTHS_PER_YEAR) {
            model.monthly.shift();
        }
    }

    // Exposes a single instance of DataService
    WinJS.Namespace.define("Data", {
        DataService: new DataService()
    });

})();