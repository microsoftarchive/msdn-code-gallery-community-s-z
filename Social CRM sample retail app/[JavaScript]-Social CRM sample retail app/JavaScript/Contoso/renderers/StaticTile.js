//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF 
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A 
//// PARTICULAR PURPOSE. 
//// 
//// Copyright (c) Microsoft Corporation. All rights reserved     
////
//// To see the topic that inspired this sample app, go to http://msdn.microsoft.com/en-us/library/windows/apps/dn163531

// this is a static tile renderer

(function () {

    var itemArray = ['XBOX 360', 'Halls Cough Drops', 'Contoso Cola', 'Contoso Jeans', 'Folgers Coffee', 'Surface RT', 'GE Microwave Oven', 'Hostess Twinkies', 'Organic Lemons', 'Old Spice Deodorant', 'Purell Hand Sanitizer', 'Tillamook cheese', 'Sanyo Television', 'Bissell vaccuum', 'iPod Touch', 'Men\'s Sleepwear', 'Baseball Bat', 'Oranges', 'Fuzzy socks', 'Tyson chicken'];
  
    WinJS.Namespace.define("Ideabook", {
        StaticTile: WinJS.Class.derive(Ideabook.Tile,

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

                var rand = Math.random();

                switch (this._group.index) {
                    case 1:
                        this._value.textContent = (d3.random.normal(30, 7)() << 0) / 10+"/5.0"
                        break;
                    case 1.1:
                        this._value.textContent = '$' + Math.floor(rand*1000000).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                        break;
                    case 1.2:
                        this._value.textContent = Math.floor(rand * 100000).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                        break;
                    case 1.3:
                        this._value.textContent = itemArray[Math.floor(rand * 20)]
                        break;
                    case 2:
                        this._value.textContent = "\"Pretty disappointed that the Seattle store isn't promoting  the new Contoso skinny jeans.\""
                        this._meta.textContent = "32 Comments, 11 Likes";
                        break;
                    case 2.1:
                        this._value.textContent = "\"When you promote something, sell it. #ContosoSeattle\"";
                        this._meta.textContent = "12 Replies, 10 Retweets"
                        break;
                    case 2.2:
                        this._value.textContent = "\"Checkout is WAY faster on the second floor!\"";
                        this._meta.textContent = "Review";
                        break;
                    case 2.3:
                        this._element.style.background = "url('/images/static/socialReachChart.png') center center no-repeat #3C4652";
                        this._value.style.display = 'none';
                        break;
                    case 5: case 5.1: case 5.2: case 5.3:
                        this._value.textContent = '$' + Math.floor(rand * 100000).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                        this._meta.textContent = itemArray[Math.floor(rand * 20)]
                        break;
                    case 5.4:
                        this._element.style.background = "url('/images/static/topProductsChart.png') center center no-repeat #3C4652";
                        this._value.style.display = 'none';
                        break;
                    case 6: case 6.1: case 6.2: case 6.3:
                        this._value.textContent = Math.floor(rand * 100);                        
                        break;
                    case 6.4:
                        this._element.style.background = "url('/images/static/pickupsChart.png') center center no-repeat #3C4652";
                        this._value.style.display = 'none';
                        break;
                    case 8:
                        this._element.style.background = "url('/images/static/conversionRateChart.png') center center no-repeat #3C4652";
                        this._value.style.display = 'none';
                        break;
                    case 8.1 : case 8.2:
                        this._meta.textContent = "Items";
                        break;
                    case 9:
                        this._element.style.backgroundImage = "url('/images/static/loyaltyCustomers.png')";
                        this._value.style.display = 'none';
                        break;
                    case 10:
                        this._element.style.backgroundImage = "url('/images/static/litwareLogo.png')";
                        this._value.style.display = 'none';
                        break;
                    case 10.1:
                        this._element.style.backgroundImage = "url('/images/static/adventureWorksLogo.png')";
                        this._value.style.display = 'none';
                        break;
                    case 10.2:
                        this._element.style.backgroundImage = "url('/images/static/northwindLogo.png')";
                        this._value.style.display = 'none';
                        break;
                    case 10.3:
                        this._element.style.backgroundImage = "url('/images/static/fabrikamLogo.png')";
                        this._value.style.display = 'none';
                        break;
                    default:
                        break;
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