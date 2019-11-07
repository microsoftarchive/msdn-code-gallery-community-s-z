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

    var margin = Ideabook.Tile.margin
      , duration = Ideabook.Tile.duration
      , formatters = Ideabook.Tile.formatters
      , height = Ideabook.Tile.height
      , width = Ideabook.Tile.width
      , sw = width - 100
      , sh = height - (margin * 2)
      , _cache = []
      , _needsTranslation = false
      , ranges = {
            hourly: d3.scale.linear().domain([1000, 0]).range([margin * 2, height - margin * 4]),
            daily: d3.scale.linear().domain([1000 * 24, 0]).range([margin * 2, height - margin * 4]),
            weekly: d3.scale.linear().domain([1000 * 24 * 7, 0]).range([margin * 2, height - margin * 4]),
            monthly: d3.scale.linear().domain([1000 * 24 * 31, 0]).range([margin * 2, height - margin * 4])
       };
      

    WinJS.Namespace.define("Ideabook", {
        FootTrafficTile: WinJS.Class.derive(Ideabook.Tile,

        // constructor
        function (data) {        
            Ideabook.Tile.call(this, data, "footTraffic");
        },

        // instance members (in an object)
        {

            _update: function (isFilter) {

                this.filter = Data.GraphingModel.filter;
            
                var data = this.data[this.filter].concat([]);

                data = unshift.call(this, data);
                stepPath.call(this, data);
                _cache = shift.call(this, data).concat([]);

                this._oldFilter = this.filter;
                _needsTranslation = false;
            },


            _render: function (data) {

                this._element = document.createElement('div');
                this._element.className = data.key + '-graph graph';

                this.body = d3.select(this._element);
                this._stage = this.body.append('svg').attr('id', 'foot-traffic').attr('height', height).attr('width', width);
                this.path = this._stage.append('path').attr('height', height).attr('width', sw);
                this.meta = this._stage.append('g').attr('height', height).attr('width', sw);
                this._oldFilter = '';

                this._update();
            },
        }
    )
    });

    function unshift(data) {
        if (this.filter == this._oldFilter && _cache.length > 0 && _cache[0] !== data[0]) {
            data.unshift(_cache[0]);
            _needsTranslation = true;
        }
        return data;
    }

    function shift(data) {
        if (_needsTranslation == true) {
            data.shift();
        }
        return data;
    }

    function stepPath(data) {

        var xr = (_needsTranslation) ? [margin, width - margin * 2 + width / data.length] : [margin, width - margin * 2];

        var rangeY = ranges[this.filter]
          , rangeX = d3.scale.linear().domain([0, data.length - 1]).range(xr)
          , line = d3.svg.line()
          , path = this.path
          , circles = this.meta.selectAll('circle').data(data, function (d) { return this.filter + d.date.toUTCString(); }.bind(this));

        line.x(function (d, i) { return rangeX(i); });
        line.y(function (d, i) { return rangeY(d.values[0].value); });

        circles.exit().remove();

        circles.enter().insert('circle')
            .attr('r', 6)
            .attr('cx', line.x())
            .attr('cy', line.y())
            .attr('i', function(d,i) { return i });

        if (_needsTranslation == false) {

            path.attr('d', line(data))
                .attr('transform', 'translate(0)');

            circles.attr('transform', 'translate(0)')
                .attr('cx', line.x())
                .attr('cy', line.y());
        }
        else {
            path.attr('d', line(data))
                .attr('transform', 'translate(0)')
                    .transition()
                    .duration(duration)
                    .ease('linear')
                        .attr('transform', 'translate(' + rangeX(-1) + ')');

            circles.attr('transform', 'translate(0)')
                .attr('cx', line.x())
                .transition()
                .duration(duration)
                .ease('linear')
                    .attr('transform', 'translate(' + rangeX(-1) + ')');
        }

        stepMeta.call(this, data, line);
    };

    function stepMeta(data, line) {

        var xr = (_needsTranslation) ? [margin, width - margin * 2 + width / data.length] : [margin, width - margin * 2];

        var rangeY = ranges[this.filter]
          , rangeX = d3.scale.linear().domain([0, data.length - 1]).range(xr)
          , xAxes = this.meta.selectAll('.xAxis').data(data, function (d) { return this.filter + d.date.toUTCString(); }.bind(this))
          , labels = this.meta.selectAll('.label').data(data, function (d) { return this.filter + d.date.toUTCString(); }.bind(this))
          , dateFormatter = formatters[this.filter];

        line.x(function (d, i) { return rangeX(i); });
        line.y(function (d, i) { return rangeY(d.values[0].value) - 15; });

        xAxes.exit().remove();
        labels.exit().remove();

        xAxes.enter().insert('text')
            .attr('class', 'xAxis')
            .attr('y', sh + 30)
            .attr('x', line.x())
            .text(function (d, i) { return dateFormatter(d.date); });

        labels.enter().insert('text')
            .attr('class', 'label')
            .attr('y', line.y())
            .attr('x', line.x())
            .text(function (d, i) { return d.values[0].value; });

        if (_needsTranslation == false) {

            xAxes.attr('transform', 'translate(0)')
                .attr('x', line.x())
                .text(function (d, i) { return dateFormatter(d.date); });

            labels.attr('transform', 'translate(0)')
                .attr('x', line.x())
                .attr('y', line.y())
                .text(function (d, i) { return d.values[0].value; });
        }
        else {

            xAxes.attr('transform', 'translate(0)')
                .attr('x', line.x())
                .transition()
                .duration(duration)
                .ease('linear')
                    .attr('transform', 'translate(' + rangeX(-1) + ')');

            labels.attr('transform', 'translate(0)')
                .attr('x', line.x())
                .transition()
                .duration(duration)
                .ease('linear')
                    .attr('transform', 'translate(' + rangeX(-1) + ')');
        }
    };

}());