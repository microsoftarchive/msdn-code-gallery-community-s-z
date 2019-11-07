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
			    seriesName: "muss beim Einstellen von Optionen die Option Datenreihenname angeben.",
			    axisName: "muss beim Einstellen von Optionen die Option Achsenname angeben.",
			    invalidLabelBinding: "Es gibt keinen solchen Wert für die zu bindenden Bezeichnungen.",
			    invalidSeriesAxisCombination: "Ungültige Kombination aus Reihen- und Achsentypen: ",
			    close: "Schließen",
			    overview: "Übersicht",
			    zoomOut: "Verkleinern",
			    zoomIn: "Vergrößern",
			    resetZoom: "Zoom zurücksetzen",
			    seriesUnsupportedOption: "der aktuelle Reihentyp unterstützt nicht die Option: ",
			    seriesTypeNotLoaded: "die den geforderten Reihentyp enthaltende JavaScript-Datei wurde nicht geladen oder der Reihentyp ist ungültig: ",
			    axisTypeNotLoaded: "die den geforderten Achsentyp enthaltende JavaScript-Datei wurde nicht geladen oder der Achsentyp ist ungültig: ",
			    axisUnsupportedOption: "der aktuelle Achsentyp unterstützt nicht die Option: "
		    }
	    });

    }
})(jQuery);
