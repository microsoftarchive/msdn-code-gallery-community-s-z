/*!@license
* Infragistics.Web.ClientUI Tree Grid localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
	$.ig = $.ig || {};

	if (!$.ig.TreeGrid) {
		$.ig.TreeGrid = {};

		$.extend($.ig.TreeGrid, {
			locale: {
			    fixedVirtualizationNotSupported: 'RowVirtualization requiert un paramètre virtualizationMode différent. virtualizationMode doit être réglé sur « continuous ».'
			}
		});

		$.ig.TreeGridPaging = $.ig.TreeGridPaging || {};

		$.extend($.ig.TreeGridPaging, {
			locale: {
			    contextRowLoadingText: "Chargement…",
				contextRowRootText: "Racine",
				columnFixingWithContextRowNotSupported: "ColumnFixing requiert un paramètre contextRowMode différent. contextRowMode doit être réglé sur « none » afin d’activer ColumnFixing."
			}
		});

		$.ig.TreeGridFiltering = $.ig.TreeGridFiltering || {};

		$.extend($.ig.TreeGridFiltering, {
			locale: {
			    filterSummaryInPagerTemplate: "${currentPageMatches} de ${totalMatches} archives correspondantes"
			}
		});

		$.ig.TreeGridRowSelectors = $.ig.TreeGridRowSelectors || {};

		$.extend($.ig.TreeGridRowSelectors, {
			locale: {
			    multipleSelectionWithTriStateCheckboxesNotSupported: "La sélection multiple requiert un paramètre checkBoxMode différent. checkBoxMode doit être réglé sur biState afin d’activer la sélection multiple."
			}
		});
	}
})(jQuery);