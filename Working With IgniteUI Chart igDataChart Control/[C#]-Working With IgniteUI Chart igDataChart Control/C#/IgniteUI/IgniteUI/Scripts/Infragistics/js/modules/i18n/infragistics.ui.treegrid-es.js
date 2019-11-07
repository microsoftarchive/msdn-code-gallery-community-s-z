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
			    fixedVirtualizationNotSupported: 'RowVirtualization requiere un ajuste de virtualizationMode diferente. virtualizationMode debería ajustarse a "continuous ".'
			}
		});

		$.ig.TreeGridPaging = $.ig.TreeGridPaging || {};

		$.extend($.ig.TreeGridPaging, {
			locale: {
			    contextRowLoadingText: "Cargando...",
				contextRowRootText: "Raíz",
				columnFixingWithContextRowNotSupported: 'ColumnFixing requiere un ajuste de contextRowMode diferente. contextRowMode debe ajustarse a "none" para habilitar ColumnFixing.'
			}
		});

		$.ig.TreeGridFiltering = $.ig.TreeGridFiltering || {};

		$.extend($.ig.TreeGridFiltering, {
			locale: {
			    filterSummaryInPagerTemplate: "${currentPageMatches} de ${totalMatches} registros coincidentes"
			}
		});

		$.ig.TreeGridRowSelectors = $.ig.TreeGridRowSelectors || {};

		$.extend($.ig.TreeGridRowSelectors, {
			locale: {
			    multipleSelectionWithTriStateCheckboxesNotSupported: "La selección múltiple requiere un ajuste de checkBoxMode diferente. checkBoxMode debe ajustarse a biState para habilitar la selección múltiple."
			}
		});
	}
})(jQuery);