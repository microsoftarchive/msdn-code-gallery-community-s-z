//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF 
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A 
//// PARTICULAR PURPOSE. 
//// 
//// Copyright (c) Microsoft Corporation. All rights reserved     
////
//// To see the topic that inspired this sample app, go to http://msdn.microsoft.com/en-us/library/windows/apps/dn163531

(function () {

    var itemArray = ['XBOX 360', 'Halls Cough Drops', 'Contoso Cola', 'Contoso Jeans', 'Folgers Coffee', 'Surface RT', 'GE Microwave Oven', 'Hostess Twinkies', 'Organic Lemons', 'Old Spice Deodorant', 'Purell Hand Sanitizer', 'Tillamook cheese', 'Sanyo Television', 'Bissell vaccuum', 'iPod Touch', 'Men\'s Sleepwear', 'Baseball Bat', 'Oranges', 'Fuzzy socks', 'Tyson chicken'];
    var dateFormatter = d3.time.format('%m/%d/%Y');

    WinJS.Namespace.define("Ideabook", {
        CustomerDetailTile: WinJS.Class.derive(Ideabook.Tile,

        // constructor
        function (data) {
            // the key is defined by the group in DataContext, which associates the data with this metrics tile.
            Ideabook.Tile.call(this, data, data.key);
        },

        // instance members (in an object)
        {
            _dateCreator: function (amt) {
                var date = new Date();
                date = new Date(date.getTime() + (Math.random() * amt));
                
                return dateFormatter(date);
            },

            _update: function () {

                if (this.data) {
                    this.filter = Data.GraphingModel.filter;
                    filteredData = this.data[this.filter];
                }
                var filters = Data.GraphingModel.filters;

                var rand = Math.random();

                switch (this._group.index) {
                    case 1:
                        this._element.style.background = "url('/images/static/loyaltyCustomerProfile.jpg') top center no-repeat #3C4652";
                        this._element.style.backgroundSize = "cover";
                        this._value.style.display = 'none';
                        break;
                    case 1.1:
                        if (!document.querySelector('dl.profile-meta')) {
                            var dl, dt, dd;
                            dl = document.createElement('dl');
                            dl.className = 'profile-meta';
                            for (var i = 0; i < this._group.data.length; i++) {
                                dt = document.createElement('dt');
                                dt.textContent = this._group.data[i].title+':';

                                dd = document.createElement('dd');
                                dd.textContent = this._group.data[i].value;

                                dl.appendChild(dt);
                                dl.appendChild(dd);
                            }
                            this._element.appendChild(dl);
                            this._value.style.display = 'none';
                            this._meta.style.display = 'none';
                        }
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
                    case 3: 
                        this._element.style.background = "url('/images/static/loyalty-points-graph.png') top center no-repeat #3C4652";
                        this._element.style.backgroundSize = "cover";
                        this._value.style.display = 'none';
                        this._label.style.display = 'none';
                        this._meta.style.display = 'none';
                        break;
                    case 3.1: 
                        var gradient = '-ms-linear-gradient(left, rgb(64, 153, 255) 0%, rgb(64, 153, 255) ' + Math.floor(rand * 100) + '%, rgb(60, 70, 82) ' + Math.floor(rand * 100) + '.1%)';

                        this._element.style.backgroundImage = gradient;
                        this._value.textContent = '$'+Math.floor(rand * 100);
                        this._label.innerHTML = '<p>' + this._group.subtitle[0] + '</p><p>' + this._group.subtitle[1] + '</p>';
                        break;
                    case 3.3:
                        this._value.textContent = '$' + Math.floor(rand * 100);
                        this._label.innerHTML = '<p>' + this._group.subtitle[0] + '</p><p>' + this._group.subtitle[1] + '</p>';
                        break;
                    case 3.2: case 3.4:
                        this._value.textContent = Math.floor(rand * 20)+'%';
                        this._label.innerHTML = '<p>' + this._group.subtitle[0] + '</p><p>' + this._group.subtitle[1] + '</p>';
                        break;
                    case 4:
                        this._value.textContent = '$' + Math.floor(rand * 15);
                        this._meta.textContent = "EXP " + this._dateCreator(10000000000);
                        break;
                    case 4.1:
                        this._value.textContent = Math.floor(rand * 18)+'%';
                        this._meta.textContent = "EXP " + this._dateCreator(10000000000);
                        break;
                    case 4.2:
                        this._value.textContent = 'B.O.G.O.';
                        this._meta.textContent = "EXP " + this._dateCreator(10000000000);
                        break;
                    case 5:
                        this._value.textContent = '$' + (Math.floor(rand * 80) / 100);
                        this._meta.textContent = "EXP " + this._dateCreator(10000000000);
                        break;
                    case 5.1:                        
                        this._value.textContent = Math.floor(rand * 21)+'%';
                        this._meta.textContent = "EXP " + this._dateCreator(10000000000);
                        break;
                    case 5.2:
                        this._value.textContent = '$'+Math.floor(rand * 23);
                        this._meta.textContent = "EXP " + this._dateCreator(10000000000);
                        break;
                    case 5.3:
                        this._value.textContent = Math.floor(rand * 33) + '%';
                        this._meta.textContent = "EXP " + this._dateCreator(10000000000);
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