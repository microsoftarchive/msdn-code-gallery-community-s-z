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
                invalidBaseElement: " не может быть использован в качестве базового элемента. Вместо этого используйте DIV.",
                catalog: "Каталог",
                cube: "Куб",
                measureGroup: "Группа Мер",
                measureGroupAll: "(Все)",
                rows: "Ряды",
                columns: "Колонки",
                measures: "Меры",
                filters: "Фильтры",
                deferUpdate: "Задержать Обновление",
                updateLayout: "Обновить Раскладку",
                selectAll: "Выбрать Все"
            }
        });
    }
})(jQuery);