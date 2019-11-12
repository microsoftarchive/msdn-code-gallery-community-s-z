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
	        seriesName: "doit spécifier l'option de nom de série lors de la définition des options.",
	        axisName: "doit spécifier l'option de nom d'axe lors de la définition des options.",
	        invalidLabelBinding: "Il n'y a aucune valeur pour les étiquettes à associer.",
	        invalidSeriesAxisCombination: "Combinaison non valide des types de série et d’axe :",
			close: "Fermer",
			overview: "Aperçu",
			zoomOut: "Zoom arrière",
			zoomIn: "Zoom avant",
			resetZoom: "Réinitialiser zoom",
			seriesUnsupportedOption: "the current series type does not support the option: ",
			seriesTypeNotLoaded: "Le fichier JavaScript contenant le type de série requis n’a pas été chargé ou le type de série n’est pas valide : ",
			axisTypeNotLoaded: "Le fichier JavaScript contenant le type d’axe requis n’a pas été chargé ou le type d’axe n’est pas valide : ",
			axisUnsupportedOption: "Le type d’axe actuel ne prend pas en charge l’option :"
		}
	});

}
})(jQuery);