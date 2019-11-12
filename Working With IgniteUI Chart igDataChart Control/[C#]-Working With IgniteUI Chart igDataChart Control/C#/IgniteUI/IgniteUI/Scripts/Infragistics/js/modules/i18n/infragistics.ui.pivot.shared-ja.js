/*!@license
* Infragistics.Web.ClientUI Pivot Shared localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.PivotShared) {
        $.ig.PivotShared = {};

        $.extend($.ig.PivotShared, {
            locale: {
                invalidDataSource: "渡されたデータ ソースが null 値またはサポートされていません。",
                measureList: "メジャー",
                ok: "OK",
                cancel: "キャンセル",
                addToMeasures: "メジャーに追加",
                addToFilters: "フィルターに追加",
                addToColumns: "列に追加",
                addToRows: "行に追加"
            }
        });
    }
})(jQuery);