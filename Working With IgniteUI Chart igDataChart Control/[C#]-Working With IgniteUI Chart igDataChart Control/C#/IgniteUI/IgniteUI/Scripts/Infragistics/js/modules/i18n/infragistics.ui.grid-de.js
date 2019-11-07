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
		        noSuchWidget: "{featureName} wurde nicht erkannt. Überprüfen, dass eine solche Funktion existiert und die Schreibweise richtig ist.",
			    autoGenerateColumnsNoRecords: "autoGenerateColumns ist aktiviert, aber es gibt keine Datensätze in der Datenquelle, um die Spalten zu bestimmen",
			    optionChangeNotSupported: "{optionName} kann nach der Initialisierung nicht bearbeitet werden. Ihr Wert sollte während der Initialisierung festgelegt werden.",
			    optionChangeNotScrollingGrid: "{optionName} kann nach der Initialisierung nicht bearbeitet werden, weil das Raster zu Beginn nicht abrollt und ein komplettes erneutes Rendering notwendig sein wird. Diese Option sollte während der Initialisierung festgelegt werden.",
			    widthChangeFromPixelsToPercentagesNotSupported: "Cannot change dynamically option width of the grid from pixels to percentages.",
			    widthChangeFromPercentagesToPixelsNotSupported: "Cannot change dynamically option width of the grid from percentages to pixels.",
			    noPrimaryKeyDefined: "Es wurde kein Primärschlüssel für das Raster definiert. Um Features wie Grid Editing verwenden zu können, muss ein Primärschlüssel definiert werden.",
			    indexOutOfRange: "Der angegebene Reihenindex liegt außerhalb des zulässigen Bereichs. Ein Reihenindex zwischen {0} und {max} sollte zur Verfügung stehen.",
			    noSuchColumnDefined: "Der angegebene Spaltenschlüssel stimmt mit keiner der angegebenen Rasterspalten überein.",
			    columnIndexOutOfRange: "Der angegebene Spaltenindex liegt außerhalb des zulässigen Bereichs. Ein Spaltenindex zwischen {0} und {max} sollte zur Verfügung stehen.",
			    recordNotFound: "Ein Datensatz mit ID {id} konnte in der Datenansicht nicht gefunden werden. Überprüfen Sie die ID, die für die Suche verwendet wurde, und passen Sie sie, wenn nötig, an.",
			    columnNotFound: "Eine Spalte mit Schlüssel {key} konnte nicht gefunden werden. Überprüfen Sie den Schlüssel, der für die Suche verwendet wurde, und passen Sie ihn, wenn nötig, an.",
			    colPrefix: "Spalte ",
			    columnVirtualizationRequiresWidth: "Virtualisierung / columnVirtualization ist auf True festgelegt, es konnte jedoch keine Breite für die Rasterspalten abgeleitet werden. Legen Sie entweder a) Rasterbreite oder b) defaultColumnWidth fest oder c) definieren Sie die Breite für jede Spalte",
			    virtualizationRequiresHeight: "Virtualisierung ist auf True festgelegt, daher muss auch die Rasterhöhe festgelegt werden.",
                colVirtualizationDenied: "columnVirtualization gilt nur für feste Virtualisierung",
			    noColumnsButAutoGenerateTrue: "autoGenerateColumns ist auf False festgelegt, im Raster sind jedoch keine Spalten definiert. Bitte legen Sie autoGenerateColumns auf True fest oder geben Sie manuell Spalten an",
			    noPrimaryKey: "Für das igHierarchicalGrid Widget muss ein Primärschlüssel definiert werden.",
			    templatingEnabledButNoTemplate: "jQueryTemplating ist auf True festgelegt, es ist jedoch kein rowTemplate definiert.",
			    expandTooltip: "Zeile erweitern",
			    collapseTooltip: "Zeile reduzieren",
			    featureChooserTooltip: "Featureauswahl",
			    movingNotAllowedOrIncompatible: "Das Verschieben der angeforderten Spalte konnte nicht abgeschlossen werden. Die Spalte wurde nicht gefunden oder das Ergebnis war nicht mit dem Spaltenlayout kompatibel.",
			    allColumnsHiddenOnInitialization: "Es können nicht alle Rasterspalten ausgeblendet werden. Bitte stellen Sie mindestens eine der Spalten so ein, dass sie angezeigt wird.",
			    virtualizationNotSupportedWithAutoSizeCols: "Die Virtualisierung erfordert eine andere Spaltenbreiten-Konfiguration als '*'. Die Spaltenbreite sollte als Pixelzahl eingestellt sein.",
			    columnVirtualizationNotSupportedWithPercentageWidth: "Die Spaltenvirtualisierung wird nicht unterstützt wenn die Rasterbreite in der Einheit Prozent angegeben wird.",
			    mixedWidthsNotSupported: "Gemischte/partielle Einstellungen der Spaltenbreite werden nicht unterstützt. Es werden keine Szenarien unterstützt, bei denen einige Spaltenbreiten in Prozent eingestellt sind, während andere in Pixel eingestellt sind (oder gar nicht angegeben werden).",
			    multiRowLayoutColumnError: "Die Spalte mit dem Schlüssel: {key1} konnte nicht zum mehrzeiligen Layout hinzugefügt werden, da ihr Platz im Layout bereits von der Spalte mit dem Schlüssel: {key2} eingenommen wurde.",
			    multiRowLayoutNotComplete: "Das mehrzeilige Layout ist nicht vollständig. Die Spaltendefinition erstellt ein Layout mit Leerräumen, das nicht korrekt gerendert werden kann.",
			    multiRowLayoutMixedWidths: "Vermischte Breiten (Prozent und Pixel) werden im Multi-Row Layout nicht unterstützt. Definieren Sie bitte alle Spaltenbreiten in Pixeln oder Prozent. ",
			    scrollableGridAreaNotVisible: "Fixierte Kopf- und Fußzeilenbereiche sind größer als die verfügbare Rasterhöhe. Der verschiebbare Bereich ist nicht sichtbar. Legen Sie bitte eine größere Rasterhöhe fest."
		    }
	    });

	    $.ig.GridFiltering = $.ig.GridFiltering || {};

	    $.extend($.ig.GridFiltering, {
		    locale: {
			    startsWithNullText: "Beginnt mit...",
			    endsWithNullText: "Endet mit...",
			    containsNullText: "Enthält...",
			    doesNotContainNullText: "Enthält nicht...",
			    equalsNullText: "Gleich...",
			    doesNotEqualNullText: "Nicht gleich...",
			    greaterThanNullText: "Größer als...",
			    lessThanNullText: "Kleiner als...",
			    greaterThanOrEqualToNullText: "Größer als oder gleich...",
			    lessThanOrEqualToNullText: "Kleiner als oder gleich...",
			    onNullText: "Am...",
			    notOnNullText: "Nicht am...",
			    afterNullText: "Nach",
			    beforeNullText: "Vor",
			    emptyNullText: "Leer",
			    notEmptyNullText: "Nicht leer",
			    nullNullText: "Null",
			    notNullNullText: "Nicht Null",
			    startsWithLabel: "Beginnt mit",
			    endsWithLabel: "Endet mit",
			    containsLabel: "Enthält",
			    doesNotContainLabel: "Enthält nicht",
			    equalsLabel: "Gleich",
			    doesNotEqualLabel: "Nicht gleich",
			    greaterThanLabel: "Größer als",
			    lessThanLabel: "Kleiner als",
			    greaterThanOrEqualToLabel: "Größer als oder gleich",
			    lessThanOrEqualToLabel: "Kleiner als oder gleich",
			    trueLabel: "Wahr",
			    falseLabel: "Falsch",
			    afterLabel: "Nach",
			    beforeLabel: "Vor",
			    todayLabel: "Heute",
			    yesterdayLabel: "Gestern",
			    thisMonthLabel: "Dieser Monat",
			    lastMonthLabel: "Letzter Monat",
			    nextMonthLabel: "Nächster Monat",
			    thisYearLabel: "Dieses Jahr",
			    lastYearLabel: "Letztes Jahr",
			    nextYearLabel: "Nächstes Jahr",
			    clearLabel: "Filter löschen",
			    noFilterLabel: "Kein",
			    onLabel: "Am",
			    notOnLabel: "Nicht am",
			    advancedButtonLabel: "Erweitert",
			    filterDialogCaptionLabel: "ERWEITERTER FILTER",
			    filterDialogConditionLabel1: "Datensätze anzeigen, die übereinstimmen mit ",
			    filterDialogConditionLabel2: " der folgenden Kriterien",
			    filterDialogConditionDropDownLabel: "Filterbedingung",
			    filterDialogOkLabel: "Suchen",
			    filterDialogCancelLabel: "Abbrechen",
			    filterDialogAnyLabel: "ANY",
			    filterDialogAllLabel: "ALL",
			    filterDialogAddLabel: "Hinzufügen",
			    filterDialogErrorLabel: "Maximale Filterzahl überschritten",
			    filterDialogCloseLabel: "Filterdialog schließen",
			    filterSummaryTitleLabel: "Suchergebnisse",
			    filterSummaryTemplate: "${matches} übereinstimmende Datensätze",
			    filterDialogClearAllLabel: "ALL löschen",
			    tooltipTemplate: "${condition} Filter angewendet",
			    // M.H. 13 Oct. 2011 Fix for bug #91007
			    featureChooserText: "Filter ausblenden",
			    featureChooserTextHide: "Filter anzeigen",
			    // M.H. 17 Oct. 2011 Fix for bug #91007
			    featureChooserTextAdvancedFilter: "Erweiterter Filter",
			    virtualizationSimpleFilteringNotAllowed: "Wenn die horizontale Virtualisierung aktiviert ist, wird die einfache Filterung (Filterzeile) nicht unterstützt. Bitte legen Sie den Modus auf 'erweitert' fest und/oder aktivieren Sie advancedModeEditorsVisible nicht",
			    multiRowLayoutSimpleFilteringNotAllowed: "Mehrzeiliges Layout erfordert einen anderen Filtertyp. Stellen Sie den Filtermodus auf „advanced“",
			    featureChooserNotReferenced: "Featureauswahl-Skript ist nicht referenziert. Um den Erhalt dieser Fehlermeldung zu vermeiden, schließen Sie bitte die Datei ig.ui.grid.featurechooser.js ein oder verwenden Sie das Ladeprogramm oder eine der kombinierten Skript-Dateien.",
			    conditionListLengthCannotBeZero: "Das Array für die conditionList in columnSettings ist leer. Ein passendes Array für die conditionList sollte zur Verfügung stehen.",
			    conditionNotValidForColumnType: "Die Bedingung '{0}' gilt nicht für die aktuelle Konfiguration. Sie sollte durch eine Bedingung ersetzt werden, die zum Spaltentyp {1} passt.",
			    defaultConditionContainsInvalidCondition: "defaultExpression für Spalte '{0}' enthält eine unerlaubte Bedingung. Sie sollte durch eine Bedingung ersetzt werden, die zum Spaltentyp {0} passt."
		    }
	    });

	    $.ig.GridGroupBy = $.ig.GridGroupBy || {};

	    $.extend($.ig.GridGroupBy, {
		    locale: {
			    emptyGroupByAreaContent: "Ziehen Sie eine Spalte hierher oder {0} zu Gruppiert nach",
			    emptyGroupByAreaContentSelectColumns: "Spalten auswählen",
			    emptyGroupByAreaContentSelectColumnsCaption: "Spalten auswählen",
			    expandTooltip: "Gruppierte Zeile erweitern",
			    collapseTooltip: "Gruppierte Zeile reduzieren",
			    removeButtonTooltip: "Gruppierte Spalte entfernen",
			    modalDialogCaptionButtonDesc: "Klicken, um aufsteigend zu sortieren",
			    modalDialogCaptionButtonAsc: "Klicken, um absteigend zu sortieren",
			    modalDialogCaptionButtonUngroup: "Klicken, um Gruppierung aufzuheben",
			    modalDialogGroupByButtonText: "Gruppieren nach",
			    modalDialogCaptionText: 'Zu Gruppieren nach hinzufügen',
			    modalDialogDropDownLabel: 'Anzeige:',
			    modalDialogClearAllButtonLabel: 'Alle löschen',
			    modalDialogRootLevelHierarchicalGrid: 'Stamm',
			    modalDialogDropDownButtonCaption: "Klicken, um anzuzeigen/auszublenden",
			    modalDialogButtonApplyText: 'Übernehmen',
			    modalDialogButtonCancelText: 'Abbrechen',
			    fixedVirualizationNotSupported: 'Die GroupBy-Funktion funktioniert nicht bei der fixierten Virtualisierung.',
			    summaryRowTitle: 'Gruppierungszusammenfassungszeile'
		    }
	    });

	    $.ig.GridHiding = $.ig.GridHiding || {};

	    $.extend($.ig.GridHiding, {
		    locale: {
		        columnChooserDisplayText: "Spaltenwahl",
			    hiddenColumnIndicatorTooltipText: "Ausgeblendete Spalte(n)",
			    columnHideText: "Ausblenden",
			    columnChooserCaptionLabel: "Spaltenauswahl",
			    columnChooserCheckboxesHeader: "Ansicht",
			    columnChooserColumnsHeader: "Spalte",
			    columnChooserCloseButtonTooltip: "Schließen",
			    hideColumnIconTooltip: "Ausblenden",
			    featureChooserNotReferenced: "Featureauswahl-Skript ist nicht referenziert. Um den Erhalt dieser Fehlermeldung zu vermeiden, schließen Sie bitte die Datei ig.ui.grid.featurechooser.js ein oder verwenden Sie eine der kombinierten Skript-Dateien.",
			    columnChooserShowText: "Anzeigen",
			    columnChooserHideText: "Ausblenden",
			    columnChooserResetButtonLabel: "Zurücksetzen",
			    columnChooserButtonApplyText: 'Übernehmen',
			    columnChooserButtonCancelText: 'Abbrechen'
		    }
	    });

		$.ig.GridResizing = $.ig.GridResizing || {};

		$.extend($.ig.GridResizing, {
			locale: {
			    noSuchVisibleColumn: "Mit dem angegebenen Schlüssel konnte keine sichtbare Spalte gefunden werden. Sie können nur die Größe sichtbarer Spalten ändern.",
			    resizingAndFixedVirtualizationNotSupported: "Die Funktion zur Größenänderung funktioniert nicht, wenn bei fixiertem virtualizationMode entweder die Virtualisierung oder die Spaltenvirtualisierung aktiviert ist. Um diese Ausnahme zu verhindern stellen Sie virtualizationMode bitte auf 'continuous' oder verwenden Sie nur rowVirtualization."
			}
		});

	    $.ig.GridPaging = $.ig.GridPaging || {};

	    $.extend($.ig.GridPaging, {

		    locale: {
			    pageSizeDropDownLabel: "Anzeigen ",
			    pageSizeDropDownTrailingLabel: "Datensätze",
			    //pageSizeDropDownTemplate: "${dropdown} Datensätze anzeigen",
			    nextPageLabelText: "Weiter",
			    prevPageLabelText: "Zurück",
			    firstPageLabelText: "",
			    lastPageLabelText: "",
			    currentPageDropDownLeadingLabel: "S.",
			    currentPageDropDownTrailingLabel: "von ${count}",
			    //currentPageDropDownTemplate: "S. ${dropdown} von ${count}",
			    currentPageDropDownTooltip: "Seitenindex auswählen",
			    pageSizeDropDownTooltip: "Anzahl der Datensätze pro Seite auswählen",
			    pagerRecordsLabelTooltip: "Aktueller Datensatzbereich",
			    prevPageTooltip: "Zur vorherigen Seite wechseln",
			    nextPageTooltip: "Zur nächsten Seite wechseln",
			    firstPageTooltip: "Zur ersten Seite wechseln",
			    lastPageTooltip: "Zur letzten Seite wechseln",
			    pageTooltipFormat: "Seite ${index}",
			    pagerRecordsLabelTemplate: "${startRecord} - ${endRecord} von ${recordCount} Datensätzen",
			    invalidPageIndex: "Ungültiger Seitenindex - er sollte größer oder gleich 0 und niedriger als die Seitenzahl sein"
		    }
	    });

    $.ig.GridSelection = $.ig.GridSelection || {};

    $.extend($.ig.GridSelection, {
        locale: {
            persistenceImpossible: "Für die dauerhafte Auswahl zwischen Zuständen ist es erforderlich, dass die igGrid's primaryKey-Option eingestellt ist. Um den Erhalt dieses Fehlers zu vermeiden definieren Sie bitte einen primary key oder deaktivieren Sie die Dauerhaftigkeit."
        }
    });

	    $.ig.GridRowSelectors = $.ig.GridRowSelectors || {};

	    $.extend($.ig.GridRowSelectors, {

		    locale: {
			    selectionNotLoaded: "igGridSelection ist nicht initialisiert. Um den Erhalt dieser Fehlermeldung zu vermeiden, aktivieren Sie bitte das Feature Selection für das Raster oder legen Sie die Eigenschaft requireSelection property der Funktion Row Selectors auf False fest.",
			    columnVirtualizationEnabled: "igGridRowSelectors wird bei aktivierter Spaltenvirtualisierung nicht unterstützt. Um das Erhalten dieser Fehlermeldung zu vermeiden, aktivieren Sie die Zeilenvirtualisierung bitte nur durch Aktivieren der Eigenschaft 'rowVirtualization' des Rasters oder durch Ändern des Virtualisierungsmodus auf 'continuous'.",
			    selectedRecordsText: "Sie haben ${checked} Datensätze ausgewählt.",
			    deselectedRecordsText: "Sie haben die Auswahl von ${unchecked} Datensätzen aufgehoben.",
			    selectAllText: "Wählen Sie alle ${totalRecordsCount} Datensätze aus",
			    deselectAllText: "Heben Sie die Auswahl von allen ${totalRecordsCount} Datensätzen auf",
			    requireSelectionWithCheckboxes: "Eine Auswahl ist erforderlich, wenn aktivierte Kontrollkästchen vorhanden sind"
		    }
	    });

	    $.ig.GridSorting = $.ig.GridSorting || {};

	    $.extend($.ig.GridSorting, {
		    locale: {
			    sortedColumnTooltipFormat: 'sortiert ${direction}',
			    unsortedColumnTooltip: 'Klicken, um Spalte zu sortieren',
			    ascending: 'aufsteigend',
			    descending: 'absteigend',
			    modalDialogSortByButtonText: 'Sortieren nach',
			    modalDialogResetButton: "Zurücksetzen",
			    modalDialogCaptionButtonDesc: "Klicken, um absteigend zu sortieren",
			    modalDialogCaptionButtonAsc: "Klicken, um aufsteigend zu sortieren",
			    modalDialogCaptionButtonUnsort: "Klicken, um Sortierung zu entfernen",
			    featureChooserText: "Mehrere sortieren",
			    modalDialogCaptionText: "Mehrere sortieren",
			    modalDialogButtonApplyText: 'Übernehmen',
			    modalDialogButtonCancelText: 'Abbrechen',
			    sortingHiddenColumnNotSupport: 'Sortierung von ausgeblendeten Spalten wird nicht unterstützt',
			    featureChooserSortAsc: 'Aufsteigend sortieren',
			    featureChooserSortDesc: 'Absteigend sortieren'
			    //modalDialogButtonSlideCaption: "Klicken, um sortierte Spalten anzuzeigen/auszublenden"
		    }
	    });

	    $.ig.GridSummaries = $.ig.GridSummaries || {};

	    $.extend($.ig.GridSummaries, {
		    locale: {
		        featureChooserText: "Übersicht ausblenden",
		        featureChooserTextHide: "Übersicht anzeigen",
			    dialogButtonOKText: 'OK',
			    dialogButtonCancelText: 'Abbrechen',
			    emptyCellText: '',
			    summariesHeaderButtonTooltip: 'Zusammenfassungen anzeigen/ausblenden',
			    // M.H. 13 Oct. 2011 Fix for bug 91008
			    defaultSummaryRowDisplayLabelCount: 'Anzahl',
			    defaultSummaryRowDisplayLabelMin: 'Min',
			    defaultSummaryRowDisplayLabelMax: 'Max',
			    defaultSummaryRowDisplayLabelSum: 'Summe',
			    defaultSummaryRowDisplayLabelAvg: 'Durchschnitt',
			    defaultSummaryRowDisplayLabelCustom: 'Benutzerdefiniert',
			    calculateSummaryColumnKeyNotSpecified: "Bitte geben Sie den Spaltenschlüssel für die Berechnung der Zusammenfassung an",
			    featureChooserNotReferenced: "Featureauswahl-Skript ist nicht referenziert. Um den Erhalt dieser Fehlermeldung zu vermeiden, schließen Sie bitte die Datei ig.ui.grid.featurechooser.js ein oder verwenden Sie eine der kombinierten Skript-Dateien."
		    }
	    });

	    $.ig.GridUpdating = $.ig.GridUpdating || {};

	    $.extend($.ig.GridUpdating, {
		    locale: {
			    doneLabel: 'Fertig',
			    doneTooltip: 'Bearbeitung beenden und aktualisieren',
			    cancelLabel: 'Abbrechen',
			    cancelTooltip: 'Bearbeitung beenden und nicht aktualisieren',
			    addRowLabel: 'Neue Zeile hinzufügen',
			    addRowTooltip: 'Klicken, um eine neue Zeile hinzuzufügen',
			    deleteRowLabel: 'Zeile löschen',
			    deleteRowTooltip: 'Zeile löschen',
			    igTextEditorException: 'Es ist momentan nicht möglich, Zeichenfolgen-Spalten im Raster zu aktualisieren. ui.igTextEditor sollte zuerst geladen werden.',
			    igNumericEditorException: 'Es ist momentan nicht möglich, numerische Spalten im Raster zu aktualisieren. ui.igNumericEditor sollte zuerst geladen werden.',
			    igCheckboxEditorException: 'Es ist momentan nicht möglich, Kontrollkästchen-Spalten im Raster zu aktualisieren. ui.igCheckboxEditor sollte zuerst geladen werden.',
			    igCurrencyEditorException: 'Es ist momentan nicht möglich, numerische Spalten mit Währungsformat im Raster zu aktualisieren. ui.igCurrencyEditor sollte zuerst geladen werden.',
			    igPercentEditorException: 'Es ist momentan nicht möglich, numerische Spalten mit Prozentformat im Raster zu aktualisieren. ui.igPercentEditor sollte zuerst geladen werden.',
			    igDateEditorException: 'Es ist momentan nicht möglich, Daten-Spalten im Raster zu aktualisieren. ui.igDateEditor sollte zuerst geladen werden.',
			    igDatePickerException: 'Es ist momentan nicht möglich, Daten-Spalten im Raster zu aktualisieren. ui.igDatePicker sollte zuerst geladen werden.',
			    igComboException: 'Um den Kombinationstyp für ui.igGrid zu verwenden, muss ui.igCombo geladen werden',
			    igRatingException: 'Um igRating als Editor für ui.igGrid zu verwenden, muss ui.igRating geladen werden',
			    igValidatorException: 'Für die in igGridUpdating definierten Überprüfungsoptionen muss ui.igValidator geladen werden',
			    editorTypeCannotBeDetermined: 'Bei der Aktualisierung waren nicht genügend Informationen zur richtigen Bestimmung des für die Spalte zu verwendenden Editortyps vorhanden: ',
			    noPrimaryKeyException: 'Um Aktualisierungsvorgänge zu unterstützen, nachdem eine Zeile gelöscht wurde, muss die Anwendung "primaryKey" in Optionen von igGrid definieren.',
			    hiddenColumnValidationException: 'Eine Zeile mit ausgeblendeter Spalte mit aktivierter Überprüfung kann nicht bearbeitet werden.',
			    dataDirtyException: 'Raster hat ausstehende Transaktionen, die das Rendern der Daten beeinflussen können Um eine Ausnahme zu vermeiden, kann die Anwendung die Option "autoCommit" von igGrid aktivieren oder sie muss das Ereignis "dataDirty" von igGridUpdating verarbeiten und False zurückgeben. Bei der Verarbeitung dieses Ereignisses kann die Anwendung auch "commit()" Daten in igGrid durchführen.',
			    recordOrPropertyNotFoundException: 'Der angegebene Datensatz oder die angegebene Eigenschaft wurde nicht gefunden. Überprüfen Sie die Kriterien für Ihre Suche und passen Sie sie, wenn nötig, an.',
			    rowEditDialogCaptionLabel: 'Zeilendaten bearbeiten',
			    excelNavigationNotSupportedWithCurrentEditMode: 'ExcelNavigation erfordert eine andere Konfiguration. editMode sollte auf "cell" oder "row" eingestellt werden.',
			    columnNotFound: "Der angegebene Spaltenschlüssel wurde nicht in der sichtbaren Spaltenauflistung gefunden oder der angegebene Index lag außerhalb des zulässigen Bereichs.",
			    rowOrColumnSpecifiedOutOfView: "Das Bearbeiten der angegebenen Reihe oder Spalte ist momentan nicht möglich. Es sollte auf der aktuellen Seite und im Virtualisierungsrahmen ersichtlich sein.",
			    editingInProgress: "Eine Reihe oder Zelle wird gerade bearbeitet. Ein anderer Aktualisierungsprozess kann nicht starten, bevor die aktuelle Bearbeitung beendet ist.",
			    undefinedCellValue: 'Nicht definiert, kann nicht als Zellenwert festgelegt werden.',
			    addChildTooltip: 'Tochterzeile hinzufügen',
			    multiRowGridNotSupportedWithCurrentEditMode: "Wenn mehrzeiliges Layout für das Raster aktiviert ist, wird lediglich der Dialogbearbeitungsmodus unterstützt."
		    }
        });

        $.ig.ColumnMoving = $.ig.ColumnMoving || {};

        $.extend($.ig.ColumnMoving, {
            locale: {
                movingDialogButtonApplyText: 'Übernehmen',
                movingDialogButtonCancelText: 'Abbrechen',
                movingDialogCaptionButtonDesc: 'Nach unten verschieben',
                movingDialogCaptionButtonAsc: 'Nach oben verschieben',
                movingDialogCaptionText: 'Spalten verschieben',
                movingDialogDisplayText: 'Spalten verschieben',
                movingDialogDropTooltipText: "Hierher verschieben",
                movingDialogCloseButtonTitle: 'Verschiebungsdialog schließen',
                dropDownMoveLeftText: 'Nach links verschieben',
                dropDownMoveRightText: 'Nach rechts verschieben',
                dropDownMoveFirstText: 'Erste verschieben',
                dropDownMoveLastText: 'Letzte verschieben',
                featureChooserNotReferenced: "Featureauswahl-Skript ist nicht referenziert. Um den Erhalt dieser Fehlermeldung zu vermeiden, schließen Sie bitte die Datei ig.ui.grid.featurechooser.js ein oder verwenden Sie das Ladeprogramm oder eine der kombinierten Skript-Dateien.",
                movingToolTipMove: 'Verschieben',
                featureChooserSubmenuText: 'Verschieben'
            }
        });
    
        $.ig.ColumnFixing = $.ig.ColumnFixing || {};

        $.extend($.ig.ColumnFixing, {
            locale: {
                headerFixButtonText: 'Klicken, um diese Spalte zu binden',
                headerUnfixButtonText: 'Klicken, um diese Spalte zu lösen',
                featureChooserTextFixedColumn: 'Spalte befestigen',
                featureChooserTextUnfixedColumn: 'Spalte lösen',
                groupByNotSupported: 'igGridGroupBy wird nicht von ColumnFixing unterstützt',
                virtualizationNotSupported: 'Die Optionsvirtualisierung des Rasters ermöglicht die Virtualisierung von Zeilen und Spalten. Bei ColumnFixing wird die Spaltenvirtualisierung nicht unterstützt. Bitte aktivieren Sie die Option rowVirtualization des Rasters',
                columnVirtualizationNotSupported: 'Bei ColumnFixing wird die Spaltenvirtualisierung nicht unterstützt',
                columnMovingNotSupported: 'igGridColumnMoving wird nicht von ColumnFixing unterstützt',
                hidingNotSupported: 'igGridHiding wird nicht von ColumnFixing unterstützt',
                hierarchicalGridNotSupported: 'igHierarchicalGrid wird nicht von ColumnFixing unterstützt',
                responsiveNotSupported: 'igGridResponsive wird nicht von ColumnFixing unterstützt',
                noGridWidthNotSupported: 'ColumnFixing erfordert eine andere Konfiguration. Die Rasterbreite muss entweder als Prozentsatz oder als Pixelanzahl eingestellt werden.',
                gridHeightInPercentageNotSupported: 'ColumnFixing erfordert eine andere Konfiguration. Die Rasterhöhe muss in Pixeln eingestellt werden.',
                defaultColumnWidthInPercentageNotSupported: "Bei der Verwendung von ColumnFixing wird die standardmäßige Spaltenbreite in Prozent nicht unterstützt",
                columnsWidthShouldBeSetInPixels: 'ColumnFixing erfordert eine andere Spaltenbreiten-Konfiguration. Die Spaltenbreite mit Schlüssel {key} sollte in Pixeln eingestellt sein.',
                unboundColumnsNotSupported: 'Bei ungebundenen Spalten wird ColumnFixing nicht unterstützt',
                excelNavigationNotSupportedWithCurrentEditMode: "Der Excel-Navigationsmodus wird nur für die Modi zur Bearbeitung der Zellen und der Zeilen unterstützt. Um diesen Fehler zu verhindern deaktivieren Sie excelNavigationMode oder stellen Sie den editMode auf Zelle oder Zeile ein.",
                initialFixingNotApplied: 'Das anfängliche Fixieren konnte bei der Spalte mit folgendem Schlüssel nicht angewendet werden: {0}. Grund: {1}', // {0} is placeholder for columnKey, {1} error message
                setOptionGridWidthException: 'Falscher Wert für Option Rasterbreite. Wenn fixierte Spalten vorliegen, muss die Breite des sichtbaren Bereichs nicht fixierter Spalten größer als oder gleich dem Wert für minimalVisibleAreaWidth sein.',
                internalErrors: {
                    none: 'Kein Fehler',
                    notValidIdentifier: 'Es gibt keine Spalte mit dem angegebenen Bezeichner',
                    fixingRefused: 'Das Fixieren wird verweigert, da es nur EINE sichtbare gelöste Spalte gibt',
                    fixingRefusedMinVisibleAreaWidth: 'Aufgrund der Mindestbreite des sichtbaren Bereichs für gelöste Spalten ist das Fixieren der Spalte nicht erlaubt',
                    alreadyHidden: 'Sie versuchen, eine ausgeblendete Spalte zu fixieren oder zu lösen',
                    alreadyUnfixed: 'Die Spalte, die Sie lösen wollen, ist bereits gelöst',
                    alreadyFixed: 'Die Spalte, die Sie fixieren wollen, ist bereits fixiert',
                    unfixingRefused: 'Das Lösen wird verweigert, da es nur eine sichtbare fixierte Spalte und mindestens eine ausgeblendete fixierte Spalte gibt.',
                    targetNotFound: 'Zielspalte mit Schlüssel {key} konnte nicht gefunden werden. Überprüfen Sie den Schlüssel, der für die Suche verwendet wurde, und passen Sie ihn, wenn nötig, an.'
                }
            }
        });

    $.ig.GridAppendRowsOnDemand = $.ig.GridAppendRowsOnDemand || {};

    $.extend($.ig.GridAppendRowsOnDemand, {
            locale: {
                loadMoreDataButtonText: 'Mehr Daten laden',
            appendRowsOnDemandRequiresHeight: 'Die Funktion AppendRowsOnDemand erfordert Höhe',
            groupByNotSupported: 'igGridGroupBy wird nicht mit AppendRowsOnDemand unterstützt',
            pagingNotSupported: 'igGridPaging wird nicht mit AppendRowsOnDemand unterstützt',
            cellMergingNotSupported: 'igGridCellMerging wird nicht mit AppendRowsOnDemand unterstützt',
            virtualizationNotSupported: 'Virtualisierung wird nicht mit AppendRowsOnDemand unterstützt'
            }
        });

    $.ig.igGridResponsive = $.ig.igGridResponsive || {};

    $.extend($.ig.igGridResponsive, {
    	locale: {
    	    fixedVirualizationNotSupported: 'Bei der fixierten Virtualisierung wird igGridResponsive nicht unterstützt'
    	}
    });

    $.ig.igGridMultiColumnHeaders = $.ig.igGridMultiColumnHeaders || {};

    $.extend($.ig.igGridMultiColumnHeaders, {
    	locale: {
    	    multiColumnHeadersNotSupportedWithColumnVirtualization: 'Bei columnVirtualization wird die Funktion für mehrspaltige Kopfzeilen nicht unterstützt'
    	}
    });

    }
})(jQuery);
