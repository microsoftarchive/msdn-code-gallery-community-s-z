//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF 
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A 
//// PARTICULAR PURPOSE. 
//// 
//// Copyright (c) Microsoft Corporation. All rights reserved     
////
//// To see the topic that inspired this sample app, go to http://msdn.microsoft.com/en-us/library/windows/apps/dn163531


//For the simple use cases that we demonstrate within the current demo app, a single tile renderer with an switch within update
//suffices. It may be worth it to create new renderers for specific key metrics tiles.

//In a live data situation, the items would be assembled with the data and returned according to the specific parameters of the app.
//In this demo, we've created a static array of items to be used randomly in the various item-related key metric tiles.
(function () {
    var itemArray = ['XBOX 360', 'Halls Cough Drops', 'Contoso Cola', 'Contoso Jeans', 'Folgers Coffee', 'Surface RT', 'GE Microwave Oven', 'Hostess Twinkies', 'Organic Lemons', 'Old Spice Deodorant', 'Purell Hand Sanitizer', 'Tillamook cheese', 'Sanyo Television', 'Bissell vaccuum', 'iPod Touch', 'Men\'s Sleepwear', 'Baseball Bat', 'Oranges', 'Fuzzy socks', 'Tyson chicken'];

    WinJS.Namespace.define("Ideabook", {
        KeyMetricsTile: WinJS.Class.derive(Ideabook.Tile,

        // constructor
        function (data) {
            // the key is defined by the group in DataContext, which associates the data with this metrics tile.
            Ideabook.Tile.call(this, data, data.key);
        },

        // instance members (in an object)
        {

            _update: function () {

                if (this.data) {
                    this.filter = Data.GraphingModel.filter;
                    filteredData = this.data[this.filter];
                }
                var filters = Data.GraphingModel.filters;

                function nextLabel() {
                    for (var i = 0, len = filters.length; i < len; i++) {
                        if (filters[i] == this.filter) {
                            if (i < len - 1)
                                return filters[i + 1]
                            else
                                return "yearly";
                        }
                    }
                }

                switch (this._group.type) {
                    case "sentiment":
                        var value = parseFloat(this._value.textContent);
                        var dieRoll = Math.random();

                        if (dieRoll < 0.25) {
                            if (value < 1 || dieRoll < 0.125 && value < 4.86)
                                value += dieRoll;
                            else
                                value -= dieRoll / 2
                        }
                        this._value.textContent = Math.round(value * 10) / 10;

                        break;
                    case "compiled":
                        var compiled = d3.sum(filteredData, function (d) { return d.values[0].value });
                        this._value.textContent = compiled;

                        this._label.textContent = nextLabel.call(this) + ' ' + this._group.subtitle;
                        break;
                    case "max":
                        var max = d3.max(filteredData, function (d) {
                            return d.values[0].value
                        });
                        this._value.textContent = max;
                        this._label.textContent = "Most Traffic";
                        break;
                    case "min":
                        var min = d3.min(filteredData, function (d) {
                            return d.values[0].value
                        });
                        this._value.textContent = min;
                        this._label.textContent = "Least Traffic";
                        break;
                    case "gross":
                        var compiled = d3.sum(filteredData, function (d) {
                            return d.values[1].value
                        });

                        this._value.textContent = Ideabook.Tile.formatters.currency(compiled);
                        this._label.textContent = 'Gross ' + nextLabel.call(this) + ' Total';
                        break;
                    case "net":
                        var compiled = d3.sum(filteredData, function (d) {
                            return d.values[0].value
                        });

                        this._value.textContent = Ideabook.Tile.formatters.currency(compiled);
                        this._label.textContent = 'Net ' + nextLabel.call(this) + ' Total';
                        break;
                    case "item":
                        if (this._label.textContent.length > 0) {
                            var dieRoll = Math.round(Math.random() * 100);
                            value = parseFloat(this._value.textContent);

                            if (dieRoll < 25) {
                                if (value < 25 || dieRoll < 12 && value < 95) {
                                    value += dieRoll;
                                } else {
                                    value -= dieRoll
                                }
                            } else if (dieRoll > 25 && dieRoll < 50) {
                                var randomItem = itemArray[Math.floor(Math.random() * 10)];
                                value = Math.round(Math.random() * 100);
                                this._label.textContent = randomItem;
                            }
                            if (value < 20) {
                                this._element.classList.add('low-inventory');
                            } else {
                                this._element.classList.remove('low-inventory');
                            }
                            this._value.textContent = value;
                        } else {
                            this._value.textContent = Math.round(Math.random() * 100);


                            var randomItem = itemArray[Math.floor(Math.random() * 20)];
                            this._label.textContent = randomItem;
                        };
                }
            },

            _render: function (data) {

                this._element = document.createElement('div');
                this._element.className = data.key + '-callout callout ' + data.classes;

                this._group = data;

                this._value = document.createElement('span');
                this._value.className = 'callout-value heading';
                this._value.textContent = (d3.random.normal(30, 7)() << 0) / 10;

                this._label = document.createElement('span');
                this._label.className = 'callout-label label';
                this._label.textContent = data.subtitle;

                this._meta = document.createElement('span');
                this._meta.className = 'callout-meta meta';

                this._element.appendChild(this._value);
                this._element.appendChild(this._label);
                this._element.appendChild(this._meta);

                this._update();
            }
        }
    )
    });

})();