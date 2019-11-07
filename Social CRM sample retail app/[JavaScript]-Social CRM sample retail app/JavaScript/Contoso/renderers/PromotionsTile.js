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

    var formatters = {
          hourly: d3.time.format('%I %p'),
          month: d3.time.format('%b'),
          day: d3.time.format('%I %p'),
          currency: d3.format('s')
        }
      , width = Ideabook.Tile.width
      , height = Ideabook.Tile.height
      , margin = Ideabook.Tile.margin
      , duration = Ideabook.Tile.duration
      , ranges = {
          hourly: d3.scale.linear().domain([0, 40000]).range([margin * 2, height - margin * 4]),
          daily: d3.scale.linear().domain([0, 40000 * 24]).range([margin * 2, height - margin * 4]),
          weekly: d3.scale.linear().domain([0, 40000 * 24 * 7]).range([margin * 2, height - margin * 4]),
          monthly: d3.scale.linear().domain([0, 40000 * 24 * 31]).range([margin * 2, height - margin * 4])
      };

    WinJS.Namespace.define("Ideabook", {
        PromotionsTile: WinJS.Class.derive(Ideabook.Tile,

        // constructor
        function (data) {
            Ideabook.Tile.call(this, data, "promotions");
        },

        // instance members (in an object)
        {

            _filterData: function () {
                return this.data[this.filter];
            },

            _update: function () {

                var data;

                this.filter = Data.GraphingModel.filter;

                data = this.data[this.filter].concat([]);
                data = this.unshift(data);

                for (var i = 0; i < this._paths.length; i++) {
                    renderPath.call(this, data, i);
                }
                renderLabel.call(this);

                this._cache = this.shift(data);
                this._oldFilter = this.filter;
            },

            _render: function (data) {

                var numPaths = this.data['daily'][0]['values'].length
                  , i = 0;

                this._element = document.createElement('div');
                this._element.className = data.key + '-graph graph';

                this._stage = d3.select(this._element).append('svg');
                this._stage.attr('id', 'promotions')
                    .attr('class', 'chart')
                    .attr('width', width - 10)
                    .attr('height', height - 10);

                this._paths = [];
                this._cache = [];
                this._oldFilter = '';
                this._needsTranslation = false;

                for (i; i < numPaths; i++) {
                    this._paths.push(this._stage.append('path').attr('class', 'p' + i));
                }

                this._update();
            },

            unshift: function(data) {
                if (this.filter == this._oldFilter && this._cache.length > 0 && this._cache[0] !== data[0]) {
                    data.unshift(this._cache[0]);
                    this._needsTranslation = true;
                }
                return data;
            },

            shift: function(data) {
                if (this._needsTranslation == true) {
                    data.shift();
                    this._needsTranslation = false;
                }
                return data;
            }
        }
    )
    });

    function getSelected(selector) {
        return this._stage.selectAll(selector).data(this.data[this.filter], getSelectedKey.bind(this));
    }

    function getSelectedKey(d) {
        return this.filter + d.date.toUTCString();
    }

    function renderPath(data, index) {

        var rangeY = ranges[this.filter]
          , rangeX = d3.scale.linear().domain([0, data.length - 3]).range([0, width])
          , line = d3.svg.area().interpolate('cardinal')
          , path = this._paths[index];

        line.x(function (d, i) { return rangeX(i); });
        line.y0(height - margin - 5);
        line.y1(function (d, i) { return rangeY(d.values[index].value); });

        if (!this._needsTranslation) {
            path.attr('d', line(data))
                .attr('transform', 'translate(0)');
        }
        else {
            path.attr('d', line(data))
                .attr('transform', 'translate(0)')
                .transition()
                    .duration(duration)
                    .ease('linear')
                    .attr('transform', 'translate(' + rangeX(-1) + ')');
        }
    };

    function renderLabel() {

        var selected = getSelected.call(this, 'text.label')
          , floor = height - 5
          , fn = (function (barWidth, dateFormatter) {
              return {
                  x: function (d, i) { return i * barWidth * 2 + barWidth * .5 + 10; },
                  xx: function (d, i) { return (i + 1) * barWidth * 2 + 10 },
                  xxx: function (d, i) { return (i - 1) * barWidth * 2 + 10 },
                  y: function (d, i) { return floor; },
                  text: function (d, i) { return dateFormatter(d.date).toUpperCase(); }
              };
          }((width - 20) / (this.data[this.filter].length * 2 - 1), Ideabook.Tile.formatters[this.filter]));

        selected.enter().insert('text')
          .attr('class', 'label')
          .text(fn.text)
          .attr('x', fn.xx)
          .attr('y', fn.y)
          .attr('fill-opacity', 0);

        selected
          .text(fn.text)
            .transition()
              .duration(duration)
              .attr('x', fn.x)
              .attr('fill-opacity', 1);

        selected.exit().transition()
          .duration(duration)
              .attr('x', fn.xxx)
              .attr('fill-opacity', 0)
              .remove();
    }

}());