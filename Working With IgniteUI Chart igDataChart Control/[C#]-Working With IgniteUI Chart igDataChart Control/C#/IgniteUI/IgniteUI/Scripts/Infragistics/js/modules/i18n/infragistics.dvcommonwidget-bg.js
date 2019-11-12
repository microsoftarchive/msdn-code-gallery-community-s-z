/*
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
			    seriesName: "трябва да попълните series name в зададените от вас опции.",
			    axisName: "трябва да попълните axis name в зададените от вас опции.",
			    invalidLabelBinding: "Не съществува такава стойност, с която да се обвържат етикетите.",
			    invalidSeriesAxisCombination: "Невалидна комбинация от серия ос и тип: ",
			    close: "Затвори",
			    overview: "Преглед",
			    zoomOut: "Отдалечи",
			    zoomIn: "Увеличи",
			    resetZoom: "Рестартирай увеличението",
			    seriesUnsupportedOption: "Конкретния тип серия не поддържа опцията: ",
			    seriesTypeNotLoaded: "JavaScript файла, който съдържа заявената тип серия не е бил зареден или типа серия не е валиден: ",
			    axisTypeNotLoaded: "JavaScript файла, който съдържа заявената тип ос не е бил зареден или типа ос не е валиден: ",
			    axisUnsupportedOption: "Конкретния тип ос не поддържа опцията: "
		    }
	    });

    }
})(jQuery);