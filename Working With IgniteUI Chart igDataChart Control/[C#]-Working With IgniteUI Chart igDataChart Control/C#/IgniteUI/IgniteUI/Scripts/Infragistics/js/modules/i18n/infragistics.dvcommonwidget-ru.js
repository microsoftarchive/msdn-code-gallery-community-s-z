/*!@license
* Infragistics.Web.ClientUI common DV widget localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Chart) {
	    $.ig.Chart = {};

	    $.extend($.ig.Chart, {

		    locale: {
			    seriesName: "необходимо установить опцию name при определении серий.",
			    axisName: "необходимо установить опцию name при определении осей.",
			    invalidLabelBinding: "Привязанное значение для пометок не существует.",
			    invalidSeriesAxisCombination: "Недопустимая комбинация типов ряда и оси: ",
			    close: "Закрыть",
			    overview: "Обзор",
			    zoomOut: "Уменьшить",
			    zoomIn: "Увеличить",
			    resetZoom: "Сброс увеличения",
			    seriesUnsupportedOption: "текущий тип ряда не поддерживает опцию: ",
			    seriesTypeNotLoaded: "the JavaScript file containing the requested series type has not been loaded or the series type is invalid: ",
			    axisTypeNotLoaded: "не загружен файл JavaScript, содержащий запрошенный тип оси, или недопустимый тип оси: ",
			    axisUnsupportedOption: "текущий тип оси не поддерживает опцию: "
		    }
	    });

    }
})(jQuery);