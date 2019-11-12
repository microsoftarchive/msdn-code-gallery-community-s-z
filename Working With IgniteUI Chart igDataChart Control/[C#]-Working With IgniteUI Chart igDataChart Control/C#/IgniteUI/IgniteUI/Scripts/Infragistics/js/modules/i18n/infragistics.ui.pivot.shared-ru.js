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
                invalidDataSource: "Предоставленный источник данных либо null, либо не поддерживается.",
                measureList: "Меры",
                ok: "OK",
                cancel: "Отмена",
                addToMeasures: "Добавить в меры",
                addToFilters: "Добавить в фильтры",
                addToColumns: "Добавить в колонки",
                addToRows: "Добавить в ряды"
            }
        });
    }
})(jQuery);