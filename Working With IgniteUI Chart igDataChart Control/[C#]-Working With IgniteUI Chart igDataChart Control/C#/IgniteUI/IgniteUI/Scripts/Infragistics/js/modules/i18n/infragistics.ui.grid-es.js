/*!@license
* Infragistics.Web.ClientUI Grid localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
$.ig = $.ig || {};

if (!$.ig.Grid) {
	$.ig.Grid = {};

	$.extend($.ig.Grid, {

		locale: {
		    noSuchWidget: "{featureName} no se ha reconocido. Compruebe que existe dicha función y que la ortografía es correcta.",
			autoGenerateColumnsNoRecords: "autoGenerateColumns está habilitado, pero no hay registros en el origen de datos para determinar las columnas",
			optionChangeNotSupported: "{optionName} no se puede editar tras la inicialización. Su valor debe establecerse durante la inicialización.",
			optionChangeNotScrollingGrid: "{optionName} no se puede editar tras la inicialización porque su tabla no se desplaza en el inicio y será necesario volver a hacer una representación completa. Esta opción debe establecerse durante la inicialización.",
			widthChangeFromPixelsToPercentagesNotSupported: "Cannot change dynamically option width of the grid from pixels to percentages.",
			widthChangeFromPercentagesToPixelsNotSupported: "Cannot change dynamically option width of the grid from percentages to pixels.",
			noPrimaryKeyDefined: "No se ha definido una clave principal para la cuadrícula. Para usar funciones como la edición de cuadrículas, debe definir una clave principal.",
			indexOutOfRange: "El índice de filas especificadas está fuera de rango. Debe proporcionarse un índice de filas entre {0} y {max}.",
			noSuchColumnDefined: "La clave de columna especificada no coincide con ninguna de las columnas de cuadrícula definidas.",
			columnIndexOutOfRange: "Él índice de columnas especificadas está fuera de rango. Debe proporcionarse un índice de columnas entre {0} y {max}.",
			recordNotFound: "No se ha encontrado ningún registro con id {id} en la vista de datos. Compruebe el id que ha utilizado para la búsqueda y ajústelo si es necesario.",
			columnNotFound: "No se ha encontrado ninguna columna con la clave {key}. Compruebe la clave que ha utilizado para la búsqueda y ajústela si es necesario.",
			colPrefix: "Columna ",
			columnVirtualizationRequiresWidth: "La virtualización / columnVirtualization está establecida como Verdadero, pero no se ha podido deducir el ancho para las columnas de cuadrícula. Debe establecer uno de los siguientes parámetros: a) ancho de cuadrícula, b) defaultColumnWidth, c) ancho definido para cada columna",
			virtualizationRequiresHeight: "La virtualización está establecida como Verdadero; por tanto, también se debe establecer la altura de la cuadrícula.",
            colVirtualizationDenied: "columnVirtualization solo es aplicable a la virtualización fija",
			noColumnsButAutoGenerateTrue: "autoGenerateColumns está establecido como Falso, pero no hay columnas definidas en la cuadrícula. Establezca autoGenerateColumns como Verdadero o especifique las columnas manualmente",
			noPrimaryKey: "Se necesita una clave principal para definir el widget igHierarchicalGrid.",
			templatingEnabledButNoTemplate: "jQueryTemplating está establecido como Verdadero, pero no se ha definido ninguna rowTemplate.",
			expandTooltip: "Expandir fila",
			collapseTooltip: "Contraer fila",
			featureChooserTooltip: "Selector de funciones",
			movingNotAllowedOrIncompatible: "No se ha podido desplazar la columna deseada. No se ha encontrado la columna o el resultado no era compatible con el diseño de columna.",
			allColumnsHiddenOnInitialization: "No es posible ocultar todas las columnas de cuadrícula. Permita que se muestre al menos una de las columnas.",
			virtualizationNotSupportedWithAutoSizeCols: "Virtualization requiere una configuración de ancho de columna diferente de '*'. El ancho de columna debe ajustarse como una cantidad en píxeles.",
			columnVirtualizationNotSupportedWithPercentageWidth: "La virtualización de columnas no se admite cuando el ancho de la cuadrícula se define en unidades de porcentaje.",
			mixedWidthsNotSupported: "No se admite la configuración del ancho de columna mezclado/parcial. No se admiten los supuestos en los que algunos anchos de columna se establezcan en porcentajes y otros en píxeles (o no se establezcan).",
			multiRowLayoutColumnError: "No se ha podido añadir la columna con la clave: {key1} a la disposición de renglón múltiple debido a que su lugar en la disposición ya está ocupado por la columna con la clave: {key2}.",
			multiRowLayoutNotComplete: "La disposición de renglón múltiple no se ha completado. La definición de columna crea una disposición con espacios vacíos y no se puede representar correctamente.",
			multiRowLayoutMixedWidths: "Las anchuras mixtas (porcentaje y píxeles) no son compatibles en la disposición de renglón múltiple. Defina todos los anchos de columna en píxeles o porcentajes.",
			scrollableGridAreaNotVisible: "Las áreas fijas de encabezado y pie de página son más grandes que la altura disponible de la cuadrícula. El área desplegable no es visible. Configure una altura de cuadrícula más grande."
		}
	});

	$.ig.GridFiltering = $.ig.GridFiltering || {};

	$.extend($.ig.GridFiltering, {
		locale: {
			startsWithNullText: "Empieza por...",
			endsWithNullText: "Termina con...",
			containsNullText: "Contiene...",
			doesNotContainNullText: "No contiene...",
			equalsNullText: "Igual a...",
			doesNotEqualNullText: "No igual a...",
			greaterThanNullText: "Mayor de...",
			lessThanNullText: "Menor de...",
			greaterThanOrEqualToNullText: "Mayor o igual a...",
			lessThanOrEqualToNullText: "Menor o igual a...",
			onNullText: "En...",
			notOnNullText: "No en...",
			afterNullText: "Después",
			beforeNullText: "Antes",
			emptyNullText: "Vacío",
			notEmptyNullText: "No vacío",
			nullNullText: "Nulo",
			notNullNullText: "No nulo",
			startsWithLabel: "Empieza por",
			endsWithLabel: "Termina con",
			containsLabel: "Contiene",
			doesNotContainLabel: "No contiene",
			equalsLabel: "Igual a",
			doesNotEqualLabel: "Diferente de",
			greaterThanLabel: "Mayor de",
			lessThanLabel: "Menor de",
			greaterThanOrEqualToLabel: "Mayor o igual a",
			lessThanOrEqualToLabel: "Menor o igual a",
			trueLabel: "Verdadero",
			falseLabel: "Falso",
			afterLabel: "Después",
			beforeLabel: "Antes",
			todayLabel: "Hoy",
			yesterdayLabel: "Ayer",
			thisMonthLabel: "Este mes",
			lastMonthLabel: "El mes pasado",
			nextMonthLabel: "El mes siguiente",
			thisYearLabel: "Este año",
			lastYearLabel: "El año pasado",
			nextYearLabel: "El año siguiente",
			clearLabel: "Borrar filtro",
			noFilterLabel: "No",
			onLabel: "En",
			notOnLabel: "No en",
			advancedButtonLabel: "Avanzado",
			filterDialogCaptionLabel: "FILTRO AVANZADO",
			filterDialogConditionLabel1: "Mostrar registros coincidentes ",
			filterDialogConditionLabel2: " de los siguientes criterios",
			filterDialogConditionDropDownLabel: "Condición de filtrado",
			filterDialogOkLabel: "Buscar",
			filterDialogCancelLabel: "Cancelar",
			filterDialogAnyLabel: "CUALQUIERA",
			filterDialogAllLabel: "TODOS",
			filterDialogAddLabel: "Agregar",
			filterDialogErrorLabel: "Se ha superado el número máximo de filtros.",
			filterDialogCloseLabel: "Cerrar cuadro de diálogo de filtrado",
			filterSummaryTitleLabel: "Resultados de la búsqueda",
			filterSummaryTemplate: "${matches} registros coincidentes",
			filterDialogClearAllLabel: "Borrar TODOS",
			tooltipTemplate: "${condition} filtro aplicado",
			// M.H. 13 Oct. 2011 Fix for bug #91007
			featureChooserText: "Ocultar filtro",
			featureChooserTextHide: "Mostrar filtro",
			// M.H. 17 Oct. 2011 Fix for bug #91007
			featureChooserTextAdvancedFilter: "Filtro avanzado",
			virtualizationSimpleFilteringNotAllowed: "Cuando está habilitada la virtualización horizontal, no se admite el filtro simple (fila de filtro). Establezca el modo como 'avanzado' y/o no establezca advancedModeEditorsVisible",
			multiRowLayoutSimpleFilteringNotAllowed: "La disposición de renglón múltiple necesita un tipo de filtro diferente. Establezca el modo de filtro en 'advanced'",
			featureChooserNotReferenced: "No se hace referencia al script del Selector de Funciones. Para evitar recibir este mensaje de error, incluya el archivo ig.ui.grid.featurechooser.js o bien use el cargador o uno de los archivos de script combinado.",
			conditionListLengthCannotBeZero: "La matriz conditionList en columnSettings está vacía. Debe proporcionarse una matriz apropiada para conditionList.",
			conditionNotValidForColumnType: "La condición '{0}' no es válida para la configuración actual. Debe reemplazarse por una condición apropiada para el tipo de columna {1}.",
			defaultConditionContainsInvalidCondition: "defaultExpression para la columna '{0}' contiene una condición que no está permitida. Debe reemplazarse por una condición apropiada para el tipo de columna {0}."
		}
	});

	$.ig.GridGroupBy = $.ig.GridGroupBy || {};

	$.extend($.ig.GridGroupBy, {
		locale: {
			emptyGroupByAreaContent: "Arrastre una columna aquí o {0} para Agrupar por",
			emptyGroupByAreaContentSelectColumns: "seleccione columnas",
			emptyGroupByAreaContentSelectColumnsCaption: "seleccione columnas",
			expandTooltip: "Expandir fila agrupada",
			collapseTooltip: "Contraer fila agrupada",
			removeButtonTooltip: "Quitar columna agrupada",
			modalDialogCaptionButtonDesc: "Haga clic para ordenar de forma ascendente",
			modalDialogCaptionButtonAsc: "Haga clic para ordenar de forma descendente",
			modalDialogCaptionButtonUngroup: "Haga clic para desagrupar",
			modalDialogGroupByButtonText: "Agrupar por",
			modalDialogCaptionText: 'Agregar a Agrupar por',
			modalDialogDropDownLabel: 'Mostrando:',
			modalDialogClearAllButtonLabel: 'borrar todos',
			modalDialogRootLevelHierarchicalGrid: 'raíz',
			modalDialogDropDownButtonCaption: "Haga clic para mostrar/ocultar",
			modalDialogButtonApplyText: 'Aplicar',
			modalDialogButtonCancelText: 'Cancelar',
			fixedVirualizationNotSupported: 'La función GroupBy no funciona si la virtualización está ajustada.',
			summaryRowTitle: 'Fila de resumen de agrupamiento'
		}
	});

	$.ig.GridHiding = $.ig.GridHiding || {};

	$.extend($.ig.GridHiding, {
		locale: {
			columnChooserDisplayText: "Selector de columnas",
			hiddenColumnIndicatorTooltipText: "Columna(s) oculta(s)",
			columnHideText: "Ocultar",
			columnChooserCaptionLabel: "Selector de columnas",
			columnChooserCheckboxesHeader: "ver",
			columnChooserColumnsHeader: "columna",
			columnChooserCloseButtonTooltip: "Cerrar",
			hideColumnIconTooltip: "Ocultar",
			featureChooserNotReferenced: "No se hace referencia al script del Selector de Funciones. Para evitar recibir este mensaje de error, incluya el archivo ig.ui.grid.featurechooser.js o bien use uno de los archivos de script combinado.",
			columnChooserShowText: "Mostrar",
			columnChooserHideText: "Ocultar",
			columnChooserResetButtonLabel: "restablecer",
			columnChooserButtonApplyText: 'Aplicar',
			columnChooserButtonCancelText: 'Cancelar'
		}
	});

		$.ig.GridResizing = $.ig.GridResizing || {};

		$.extend($.ig.GridResizing, {
			locale: {
			    noSuchVisibleColumn: "No se ha encontrado ninguna columna visible con la clave especificada. Solo puede cambiar el tamaño de las columnas visibles.",
			    resizingAndFixedVirtualizationNotSupported: "La función de cambio de tamaño no funciona cuando la virtualización o la virtualización de columnas están habilitadas con virtualizationMode ajustado. Para evitar esta excepción establezca virtualizationMode en 'continuous' o utilice solo rowVirtualization."
			}
		});

	$.ig.GridPaging = $.ig.GridPaging || {};

	$.extend($.ig.GridPaging, {

		locale: {
			pageSizeDropDownLabel: "Mostrar ",
			pageSizeDropDownTrailingLabel: "registros",
			//pageSizeDropDownTemplate: "Mostrar ${dropdown} registros",
			nextPageLabelText: "siguiente",
			prevPageLabelText: "anterior",
			firstPageLabelText: "",
			lastPageLabelText: "",
			currentPageDropDownLeadingLabel: "Pág",
			currentPageDropDownTrailingLabel: "de ${count}",
			//currentPageDropDownTemplate: "Pág ${dropdown} de ${count}",
			currentPageDropDownTooltip: "Elegir índice de páginas",
			pageSizeDropDownTooltip: "Elegir número de registros por página",
			pagerRecordsLabelTooltip: "Intervalo de registros actuales",
			prevPageTooltip: "ir a la página anterior",
			nextPageTooltip: "ir a la página siguiente",
			firstPageTooltip: "ir a la primera página",
			lastPageTooltip: "ir a la última página",
			pageTooltipFormat: "página ${index}",
			    pagerRecordsLabelTemplate: "${startRecord} - ${endRecord} de ${recordCount} registros",
			    invalidPageIndex: "Índice de página no válido: debería ser igual o superior a 0 e inferior al número de página"
		}
	});

    $.ig.GridSelection = $.ig.GridSelection || {};

    $.extend($.ig.GridSelection, {
        locale: {
            persistenceImpossible: "La selección persistente entre los estados requiere que se defina la opción primaryKey de igGrid. Para evitar recibir este error, defina una clave principal o desactive la persistencia."
        }
    });

	$.ig.GridRowSelectors = $.ig.GridRowSelectors || {};

	$.extend($.ig.GridRowSelectors, {

		locale: {
			selectionNotLoaded: "igGridSelection no se ha inicializado. Para evitar recibir este mensaje de error, habilite la función de Selección para la cuadrícula o bien establezca la propiedad requireSelection de la función Selectores de Filas como Falso.",
			columnVirtualizationEnabled: "igGridRowSelectors no se admite cuando la virtualización de columnas está habilitada. Para evitar recibir este mensaje de error, habilite solo la virtualización de filas mediante la activación de la propiedad 'rowVirtualization' de la cuadrícula o la modificación del modo de virtualización a 'continuous'.",
			selectedRecordsText: "Ha seleccionado los registros ${checked}.",
			deselectedRecordsText: "Ha anulado la selección de los registros ${unchecked}.",
			selectAllText: "Seleccionar todos los registros ${totalRecordsCount}",
			deselectAllText: "Anular la selección de todos los registros ${totalRecordsCount}",
			requireSelectionWithCheckboxes: "La selección es necesaria cuando hay casillas de verificación habilitadas"
		}
	});

	$.ig.GridSorting = $.ig.GridSorting || {};

	$.extend($.ig.GridSorting, {
		locale: {
			sortedColumnTooltipFormat: 'ordenado ${direction}',
			unsortedColumnTooltip: 'haga clic para ordenar la columna',
			ascending: 'ascendente',
			descending: 'descendente',
			modalDialogSortByButtonText: 'ordenar por',
			modalDialogResetButton: "restablecer",
			modalDialogCaptionButtonDesc: "Haga clic para ordenar de forma descendente",
			modalDialogCaptionButtonAsc: "Haga clic para ordenar de forma ascendente",
			modalDialogCaptionButtonUnsort: "Haga clic para quitar criterios de ordenación",
			featureChooserText: "Ordenar en múltiples",
			modalDialogCaptionText: "Ordenar múltiples",
			modalDialogButtonApplyText: 'Aplicar',
			modalDialogButtonCancelText: 'Cancelar',
			sortingHiddenColumnNotSupport: 'La ordenación de columnas ocultas no se admite',
			featureChooserSortAsc: 'Ordenar de A a Z',
			featureChooserSortDesc: 'Ordenar de Z a A'
			//modalDialogButtonSlideCaption: "Haga clic para mostrar/ocultar columnas ordenadas"
		}
	});

	$.ig.GridSummaries = $.ig.GridSummaries || {};

	$.extend($.ig.GridSummaries, {
		locale: {
			featureChooserText: "Ocultar resúmenes",
			featureChooserTextHide: "Mostrar resúmenes",
			dialogButtonOKText: 'Aceptar',
			dialogButtonCancelText: 'Cancelar',
			emptyCellText: '',
			summariesHeaderButtonTooltip: 'Mostrar/ocultar resúmenes',
			// M.H. 13 Oct. 2011 Fix for bug 91008
			defaultSummaryRowDisplayLabelCount: 'Recuento',
			defaultSummaryRowDisplayLabelMin: 'Mín.',
			defaultSummaryRowDisplayLabelMax: 'Máx.',
			defaultSummaryRowDisplayLabelSum: 'Suma',
			defaultSummaryRowDisplayLabelAvg: 'Prom.',
			defaultSummaryRowDisplayLabelCustom: 'Personalizado',
			calculateSummaryColumnKeyNotSpecified: "Especifique la clave de columna para calcular el resumen",
			featureChooserNotReferenced: "No se hace referencia al script del Selector de Funciones. Para evitar recibir este mensaje de error, incluya el archivo ig.ui.grid.featurechooser.js o bien use uno de los archivos de script combinado."
		}
	});

	$.ig.GridUpdating = $.ig.GridUpdating || {};

	$.extend($.ig.GridUpdating, {
		locale: {
			doneLabel: 'Terminado',
			doneTooltip: 'Detener edición y actualizar',
			cancelLabel: 'Cancelar',
			cancelTooltip: 'Detener edición y no actualizar',
			addRowLabel: 'Agregar fila nueva',
			addRowTooltip: 'Haga clic para agregar una nueva fila',
			deleteRowLabel: 'Borrar fila',
			deleteRowTooltip: 'Borrar fila',
			igTextEditorException: 'En estos momentos no es posible actualizar una cadena de columnas en la tabla. Primero, debe cargarse ui.igTextEditor.',
			igNumericEditorException: 'En estos momentos no es posible actualizar columnas numéricas en la tabla. Primero, debe cargarse ui.igNumericEditor.',
			igCheckboxEditorException: 'En estos momentos no es posible actualizar columnas de casillas de verificación en la tabla. Primero, debe cargarse ui.igCheckboxEditor.',
			igCurrencyEditorException: 'En estos momentos no es posible actualizar columnas numéricas con formato de moneda en la tabla. Primero, debe cargarse ui.igCurrencyEditor.',
			igPercentEditorException: 'En estos momentos no es posible actualizar columnas numéricas con formato de porcentaje en la tabla. Primero, debe cargarse ui.igPercentEditor.',
			igDateEditorException: 'En estos momentos no es posible actualizar columnas de fecha en la tabla. Primero, debe cargarse ui.igDateEditor.',
			igDatePickerException: 'En estos momentos no es posible actualizar columnas de fecha en la tabla. Primero, debe cargarse ui.igDatePicker.',
			igComboException: 'Para usar el tipo combinado para ui.igGrid, ui.igCombo debe estar cargado',
			igRatingException: 'Para usar igRating como editor para ui.igGrid, ui.igRating debe estar cargado',
			igValidatorException: 'Las opciones de validación definidas en igGridUpdating necesitan que ui.igValidator esté cargado',
			editorTypeCannotBeDetermined: 'La actualización no tenía la información suficiente para determinar el tipo de editor que usar para la columna: ',
			noPrimaryKeyException: 'Para admitir las operaciones de actualización después de borrar una fila, la aplicación debe definir "primaryKey" en las opciones de igGrid.',
			hiddenColumnValidationException: 'No se puede editar una fila que tiene una columna oculta con validación habilitada.',
			dataDirtyException: 'La cuadrícula tiene transacciones pendientes que pueden afectar a la representación de datos. Para evitar excepciones, la aplicación puede habilitar la opción "autoCommit" de igGrid o bien debe procesar el evento "dataDirty" de igGridUpdating y devolver Falso. Al procesar ese evento, la aplicación también puede efectuar "commit()" datos en igGrid.',
			recordOrPropertyNotFoundException: 'No se ha encontrado el registro o la propiedad especificados. Compruebe los criterios de búsqueda y ajústelos si es necesario.',
			rowEditDialogCaptionLabel: 'Editar datos de fila',
			excelNavigationNotSupportedWithCurrentEditMode: 'ExcelNavigation requiere una configuración diferente. editMode debe ajustarse a "cell" o "row".',
			columnNotFound: "La clave de la columna especificada no se ha encontrado en la colección de columnas visible o el índice especificado estaba fuera de rango.",
			rowOrColumnSpecifiedOutOfView: "En estos momentos no es posible editar la fila o columna especificada. Debe mostrarse en la página actual y en el marco de visualización.",
			editingInProgress: "En estos momentos se está editando una fila o celda. No se puede iniciar otro proceso de actualización antes de que finalice la edición actual.",
			undefinedCellValue: 'No se puede seleccionar Undefined como valor de celda.',
			addChildTooltip: 'Añada una fija hija',
			multiRowGridNotSupportedWithCurrentEditMode: "Cuando la cuadrícula tiene una disposición de renglón múltiple habilitada, solo es compatible el modo de edición de cuadro de diálogo."
		}
    });

    $.ig.ColumnMoving = $.ig.ColumnMoving || {};

    $.extend($.ig.ColumnMoving, {
        locale: {
            movingDialogButtonApplyText: 'Aplicar',
            movingDialogButtonCancelText: 'Cancelar',
            movingDialogCaptionButtonDesc: 'Bajar',
            movingDialogCaptionButtonAsc: 'Subir',
            movingDialogCaptionText: 'Mover columnas',
            movingDialogDisplayText: 'Mover columnas',
            movingDialogDropTooltipText: "Mover aquí",
            movingDialogCloseButtonTitle: 'Cerrar el cuadro de diálogo móvil',
            dropDownMoveLeftText: 'Mover a la izquierda',
            dropDownMoveRightText: 'Mover a la derecha',
            dropDownMoveFirstText: 'Mover primero',
            dropDownMoveLastText: 'Mover último',
            featureChooserNotReferenced: "No se hace referencia al script del Selector de Funciones. Para evitar recibir este mensaje de error, incluya el archivo ig.ui.grid.featurechooser.js o bien use el cargador o uno de los archivos de script combinado.",
            movingToolTipMove: 'Mover',
            featureChooserSubmenuText: 'Mover'
        }
    });

    $.ig.ColumnFixing = $.ig.ColumnFixing || {};

    $.extend($.ig.ColumnFixing, {
        locale: {
            headerFixButtonText: 'Haga clic para fijar esta columna',
            headerUnfixButtonText: 'Haga clic para soltar esta columna',
            featureChooserTextFixedColumn: 'Fijar columna',
            featureChooserTextUnfixedColumn: 'Soltar columna',
            groupByNotSupported: 'igGridGroupBy no se admite con ColumnFixing',
            virtualizationNotSupported: 'La virtualización de la opción de cuadrícula permite la virtualización de filas y columnas. La virtualización de columnas no se admite con ColumnFixing. Active la opción rowVirtualization de cuadrícula',
            columnVirtualizationNotSupported: 'La virtualización de columnas no se admite con ColumnFixing',
            columnMovingNotSupported: 'igGridColumnMoving no se admite con ColumnFixing',
            hidingNotSupported: 'igGridHiding no se admite con ColumnFixing',
            hierarchicalGridNotSupported: 'igHierarchicalGrid no se admite con ColumnFixing',
            responsiveNotSupported: 'igGridResponsive no se admite con ColumnFixing',
            noGridWidthNotSupported: 'Column Fixing necesita una configuración diferente. El ancho de la cuadrícula debe configurarse en forma de porcentajes o como número en píxeles.',
            gridHeightInPercentageNotSupported: 'Column Fixing necesita una configuración diferente. La altura de la cuadrícula se debe configurar en píxeles.',
            defaultColumnWidthInPercentageNotSupported: "El ancho de columna predeterminado en porcentaje no se admite cuando se utiliza ColumnFixing",
            columnsWidthShouldBeSetInPixels: 'ColumnFixing requiere un ajuste de ancho de columna diferente. El ancho de columna con la clave {key} debe ajustarse en píxeles.',
            unboundColumnsNotSupported: 'ColumnFixing no se admite con columnas sueltas',
            excelNavigationNotSupportedWithCurrentEditMode: "El modo de navegación Excel solo se admite en los modos de edición de celda o de edición de fila. Para evitar este error, desactive excelNavigationMode o establezca editMode en celda o fila.",
            initialFixingNotApplied: 'No se ha podido aplicar la acción de fijado inicial en la columna con clave: {0}. Motivo: {1}', // {0} is placeholder for columnKey, {1} error message
            setOptionGridWidthException: 'Valor incorrecto para la anchura de la cuadrícula de opciones. Cuando hay columnas fijas, la anchura del área visible de las columnas que no están fijas debería ser más grande o igual al valor de minimalVisibleAreaWidth.',
            internalErrors: {
                none: 'No hay error',
                notValidIdentifier: 'No existe ninguna columna con el identificador especificado',
                fixingRefused: 'La acción de fijar se deniega porque SOLO hay una columna suelta visible',
                fixingRefusedMinVisibleAreaWidth: 'No se permite fijar una columna debido al ancho mínimo del área visible de columnas sueltas',
                alreadyHidden: 'Está intentando fijar/soltar una columna oculta',
                alreadyUnfixed: 'La columna que está intentando soltar ya está suelta',
                alreadyFixed: 'La columna que está intentando fijar ya está fijada',
                unfixingRefused: 'La acción de soltar se deniega porque solo hay una columna fijada visible y hay al menos una columna fijada oculta.',
                targetNotFound: 'No se ha encontrado la columna con la clave {key}. Compruebe la clave que ha utilizado para la búsqueda y ajústela si es necesario.'
            }
        }
    });

    $.ig.GridAppendRowsOnDemand = $.ig.GridAppendRowsOnDemand || {};

    $.extend($.ig.GridAppendRowsOnDemand, {
    	locale: {
    	    loadMoreDataButtonText: 'Cargar más datos',
    	    appendRowsOnDemandRequiresHeight: 'La función AppendRowsOnDemand necesita altura',
    	    groupByNotSupported: 'igGridGroupBy no se admite con AppendRowsOnDemand',
    	    pagingNotSupported: 'igGridPaging no se admite con AppendRowsOnDemand',
    	    cellMergingNotSupported: 'igGridCellMerging no se admite con AppendRowsOnDemand',
    	    virtualizationNotSupported: 'La virtualización no se admite con AppendRowsOnDemand'
    	}
    });

    $.ig.igGridResponsive = $.ig.igGridResponsive || {};

    $.extend($.ig.igGridResponsive, {
    	locale: {
    	    fixedVirualizationNotSupported: 'igGridResponsive no se admite con la virtualización fijada'
    	}
    });

    $.ig.igGridMultiColumnHeaders = $.ig.igGridMultiColumnHeaders || {};

    $.extend($.ig.igGridMultiColumnHeaders, {
    	locale: {
    	    multiColumnHeadersNotSupportedWithColumnVirtualization: 'La función de encabezados de columnas múltiples no se admite con columnVirtualization'
    	}
    });

}
})(jQuery);
