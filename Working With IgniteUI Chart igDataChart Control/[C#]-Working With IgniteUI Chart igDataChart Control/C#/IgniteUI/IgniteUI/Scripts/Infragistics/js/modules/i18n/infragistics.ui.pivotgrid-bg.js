/*!@license
* Infragistics.Web.ClientUI Pivot Grid localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.PivotGrid) {
        $.ig.PivotGrid = {};

        $.extend($.ig.PivotGrid, {
            locale: {
                filtersHeader: "Пусни филтърните полета тук",
                measuresHeader: "Пусни данните тук",
                rowsHeader: "Пусни полетата за редове тук",
                columnsHeader: "Пусни полетата за колони тук",
                disabledFiltersHeader: "Полета за филтриране",
                disabledMeasuresHeader: "Данни",
                disabledRowsHeader: "Полета за редове",
                disabledColumnsHeader: "Полета за колони",
                noSuchAxis: "Няма такава ос"
            }
        });
    }
})(jQuery);