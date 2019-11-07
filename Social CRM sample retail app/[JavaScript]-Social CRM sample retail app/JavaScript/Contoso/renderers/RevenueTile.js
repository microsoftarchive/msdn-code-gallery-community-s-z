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

    var NET_INDEX = 0
      , GROSS_INDEX = 1
      , width = Ideabook.Tile.width
      , height = Ideabook.Tile.height
      , margin = Ideabook.Tile.margin
      , duration = Ideabook.Tile.duration
      , ranges = {
           hourly:  d3.scale.linear().domain([0, 20000]).range([margin * 2, height - margin * 4]),
           daily:   d3.scale.linear().domain([0, 20000 * 24]).range([margin * 2, height - margin * 4]),
           weekly:  d3.scale.linear().domain([0, 20000 * 24 * 7]).range([margin * 2, height - margin * 4]),
           monthly: d3.scale.linear().domain([0, 20000 * 24 * 31]).range([margin * 2, height - margin * 4])
        };

    WinJS.Namespace.define("Ideabook", {

        RevenueTile: WinJS.Class.derive(Ideabook.Tile,

            // constructor
            function (data) {
                Ideabook.Tile.call(this, data, 'revenue');
            },

            // instance members (in an object)
            {
                _update: function () {

                    this.filter = Data.GraphingModel.filter;
                    this.range = ranges[this.filter];
                    this.dateFormatter = Ideabook.Tile.formatters[this.filter];
                    this.currencyFormatter = Ideabook.Tile.formatters.currency;
                    this.barWidth = (width - 20) / (this.data[this.filter].length * 2 - 1);

                    renderNet.call(this);
                    renderGross.call(this);
                    renderLabel.call(this);
                    renderTotal.call(this);
                },

                _render: function (data) {

                    this._element = document.createElement('div');
                    this._element.className = data.key + '-graph graph';

                    this._stage = d3.select(this._element).append('svg');
                    this._stage.attr('id', 'revenue')
                        .attr('class', 'chart')
                        .attr('width', width)
                        .attr('height', height);

                    this._update();
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

    function renderNet() {

        var selected = getSelected.call(this, 'rect.net')
          , floor = height - 25
          , fn = (function (barWidth, range) {
              return {
                  x: function (d, i) { return i * barWidth * 2 + 10 },
                  xx: function (d, i) { return (i + 1) * barWidth * 2 + 10 },
                  xxx: function (d, i) { return (i - 1) * barWidth * 2 + 10 },
                  y: function (d, i) { return floor - range(d.values[NET_INDEX].value); },
                  h: function (d, i) { return range(d.values[NET_INDEX].value); },
                  w: barWidth
              };
          }(this.barWidth, this.range));

        selected.enter().insert('rect')
          .attr('class', 'net q0-11')
          .attr('x', fn.xx)
          .attr('y', fn.y)
          .attr('height', fn.h)
          .attr('width', fn.w)
          .attr('fill-opacity', 0);

        selected.transition()
          .duration(duration)
              .attr('x', fn.x)
              .attr('y', fn.y)
              .attr('height', fn.h)
              .attr('width', fn.w)
              .attr('fill-opacity', 1);

        selected.exit().transition()
          .duration(duration)
              .attr('x', fn.xxx)
              .attr('fill-opacity', 0)
              .remove();
    }

    function renderGross() {

        var selected = getSelected.call(this, 'rect.gross')
          , floor = height - 25
          , fn = (function (barWidth, range) {
              return {
                  x: function (d, i) { return i * barWidth * 2 + 10 },
                  xx: function (d, i) { return (i + 1) * barWidth * 2 + 10 },
                  xxx: function (d, i) { return (i - 1) * barWidth * 2 + 10 },
                  y: function (d, i) { return floor - range(d.values[NET_INDEX].value) - range(d.values[GROSS_INDEX].value - d.values[NET_INDEX].value); },
                  h: function (d, i) { return range(d.values[GROSS_INDEX].value - d.values[NET_INDEX].value); },
                  w: barWidth
              };
          }(this.barWidth, this.range));

        selected.enter().insert('rect')
          .attr('class', 'gross q2-11')
          .attr('x', fn.xx)
          .attr('y', fn.y)
          .attr('height', fn.h)
          .attr('width', fn.w)
          .attr('fill-opacity', 0);

        selected.transition()
          .duration(duration)
              .attr('x', fn.x)
              .attr('y', fn.y)
              .attr('height', fn.h)
              .attr('width', fn.w)
              .attr('fill-opacity', 1);

        selected.exit().transition()
          .duration(duration)
              .attr('x', fn.xxx)
              .attr('fill-opacity', 0)
              .remove();
    }

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
          }(this.barWidth, this.dateFormatter));

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

    function renderTotal() {

        var selected = getSelected.call(this, 'text.total')
          , floor = height - 35
          , fn = (function (barWidth, range, currencyFormatter) {
              return {
                  x: function (d, i) { return i * barWidth * 2 + barWidth * .5 + 10; },
                  xx: function (d, i) { return (i + 1) * barWidth * 2 + 10 },
                  xxx: function (d, i) { return (i - 1) * barWidth * 2 + 10 },
                  y: function (d, i) { return floor - range(d.values[NET_INDEX].value) - range(d.values[GROSS_INDEX].value - d.values[NET_INDEX].value); },
                  text: function (d, i) { return '$' + currencyFormatter(d.values[GROSS_INDEX].value); }
              };
          }(this.barWidth, this.range, this.currencyFormatter));

        selected.enter().insert('text')
          .attr('class', 'total')
          .text(fn.text)
          .attr('x', fn.xx)
          .attr('y', fn.y)
          .attr('fill-opacity', 0);

        selected
          .text(fn.text)
            .transition()
              .duration(duration)
              .attr('x', fn.x)
              .attr('y', fn.y)
              .attr('fill-opacity', 1);

        selected.exit().transition()
          .duration(duration)
              .attr('x', fn.xxx)
              .attr('fill-opacity', 0)
              .remove();
    }

}())
