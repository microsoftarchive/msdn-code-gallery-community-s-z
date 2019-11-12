/*!@license
* Infragistics.Web.ClientUI Pivot Data Selector localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.PivotDataSelector) {
        $.ig.PivotDataSelector = {};

        $.extend($.ig.PivotDataSelector, {
            locale: {
                invalidBaseElement: " не се поддържа като основен елемент. Използвай DIV вместо това.",
                catalog: "Каталог",
                cube: "Куб",
                measureGroup: "Група от мерки",
                measureGroupAll: "(Всичко)",
                rows: "Редове",
                columns: "Колони",
                measures: "Мерки",
                filters: "Филтри",
                deferUpdate: "Отложи актуализацията",
                updateLayout: "Актуализирай оформлението",
                selectAll: "Избери всичко"
            }
        });
    }
})(jQuery);