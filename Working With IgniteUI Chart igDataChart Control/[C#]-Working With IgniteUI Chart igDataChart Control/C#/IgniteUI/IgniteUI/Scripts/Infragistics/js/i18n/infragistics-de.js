/*!@license
* Infragistics.Web.ClientUI data source localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {

    $.ig = $.ig || {};

    if (!$.ig.DataSourceLocale) {
	    $.ig.DataSourceLocale = {};

	    $.extend($.ig.DataSourceLocale, {

		    locale: {
			    invalidDataSource: "Die angegebene Datenquelle ist ungültig. Es kann ein Skalar sein.",
			    unknownDataSource: "Der Datenquellentyp kann nicht bestimmt werden. Bitte angeben, ob es sich um JSON- oder XML-Daten handelt.",
			    errorParsingArrays: "Bei der Analyse der Arraydaten und der Anwendung des definierten Datenschemas ist ein Fehler aufgetreten: ",
			    errorParsingJson: "Bei der Analyse der JSON-Daten und der Anwendung des definierten Datenschemas ist ein Fehler aufgetreten: ",
			    errorParsingXml: "Bei der Analyse der XML-Daten und der Anwendung des definierten Datenschemas ist ein Fehler aufgetreten: ",
			    errorParsingHtmlTable: "Beim Extrahieren der Daten aus der HTML-Tabelle und der Anwendung des Schemas ist ein Fehler aufgetreten: ",
			    errorExpectedTbodyParameter: "tbody oder table wurde als Parameter erwartet.",
			    errorTableWithIdNotFound: "Die HTML-Tabelle mit der folgenden ID wurde nicht gefunden: ",
			    errorParsingHtmlTableNoSchema: "Bei der Analyse der Tabelle DOM ist ein Fehler aufgetreten: ",
			    errorParsingJsonNoSchema: "Bei der Analyse/Auswertung der JSON-Zeichenfolge ist ein Fehler aufgetreten: ",
			    errorParsingXmlNoSchema: "Bei der Analyse der XML-Zeichenfolge ist ein Fehler aufgetreten: ",
			    errorXmlSourceWithoutSchema: "Die angegebene Datenquelle ist ein XML-Dokument, aber es gibt kein definiertes Datenschema ($.IgDataSchema). ",
			    errorUnrecognizedFilterCondition: " Die angegebene Filterbedingung wurde nicht erkannt: ",
			    errorRemoteRequest: "Die Remoteanforderung zum Abrufen von Daten ist fehlgeschlagen: ",
			    errorSchemaMismatch: "Die Eingabedaten stimmen nicht mit dem Schema überein, das folgende Feld konnte nicht zugeordnet werden: ",
			    errorSchemaFieldCountMismatch: "Die Eingabedaten stimmen in Bezug auf die Anzahl Felder nicht mit dem Schema überein. ",
			    errorUnrecognizedResponseType: "Der Antworttyp wurde entweder nicht korrekt eingestellt oder konnte nicht automatisch erkannt werden. Bitte settings.responseDataType und/oder settings.responseContentType einstellen.",
			    hierarchicalTablesNotSupported: "Tabellen werden nicht für HierarchicalSchema unterstützt.",
			    cannotBuildTemplate: "Die jQuery-Vorlage konnte nicht erstellt werden. Es gibt keine Datensätze in der Datenquelle und keine definierten Spalten.",
			    unrecognizedCondition: "Nicht erkannte Filterbedingung im folgenden Ausdruck: ",
			    fieldMismatch: "Der folgende Ausdruck enthält ein ungültiges Feld oder eine ungültige Filterbedingung: ",
			    noSortingFields: "Es wurden keine Felder angegeben. Beim Aufrufen von sort() muss mindestens ein Feld zum Sortieren angegeben werden.",
			    filteringNoSchema: "Es wurden kein Schema / Felder angegeben. Es muss ein Schema mit Felddefinitionen und Feldtypen angegeben werden, um die Datenquelle filtern zu können.",
			    noSaveChanges: "Speichern der Änderungen war nicht erfolgreich. Server hat Success-Objekt nicht zurückgegeben oder Success:false zurückgegeben.",
			    errorUnexpectedCustomFilterFunction: "Für eine kundenspezifische Filterfunktion wurde ein unerwarteter Wert angegeben. Eine Funktion oder Zeichenfolge wird erwartet."
		    }
	    });

    }
})(jQuery);

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

/*!@license
* Infragistics.Web.ClientUI shared localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
$.ig = $.ig || {};

if (!$.ig.SharedLocale) {
	$.ig.SharedLocale = {};

	$.extend($.ig.SharedLocale, {

		locale: {
		    
		}
	});

}
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI templating localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Templating) {
	    $.ig.Templating = {};

	    $.extend($.ig.Templating, {
		    locale: {
			    undefinedArgument: 'Beim Abrufen der Datenquellen-Eigenschaft ist ein Fehler aufgetreten: '
		    }
	    });
    }
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Barcode localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Barcode) {
	    $.ig.Barcode = {
		    locale: {
			    aILength: "Der AI muss mindestens 2-stellig sein.",
			    badFormedUCCValue: "Die UCC Barcode-Daten sind nicht korrekt formatiert. Das korrekte Format lautet (AI)GTIN.",
			    code39_NonNumericError: "Das Zeichen '{0}' ist für CODE39 Barcode-Daten ungültig. Gültige Zeichen: {1}",
			    countryError: "Fehler bei der Konvertierung des Ländercodes. Er muss ein numerischer Wert sein.",
			    emptyValueMsg: "Der Datenwert ist leer.",
			    encodingError: "Fehler bei der Konvertierung. Die gültigen Eigenschaftswerte finden Sie in der Dokumentation.",
			    errorMessageText: "Ungültiger Wert! Weitere Informationen über die gültige Barcode-Datenstruktur finden Sie in der Dokumentation.",
			    gS1ExMaxAlphanumNumber: "GS1 DataBar Expanded kann bis zu 41 alphanumerische Zeichen codieren.",
			    gS1ExMaxNumericNumber: "GS1 DataBar Expanded kann bis zu 74 numerische Zeichen codieren.",
			    gS1Length: "GS1 DataBar Data wird für die GTIN - 8, 12, 13 oder 14 verwendet und muss 7-, 11-, 12- oder 13-stellig sein. An letzter Stelle steht eine Prüfsumme.",
			    gS1LimitedFirstChar: "Die erste Ziffer von GS1 DataBar Limited muss der Wert 0 oder 1 sein. Bei der Codierung von GTIN-14 Datenstrukturen mit einem Indikatorwert größer als 1 muss der Barcode des Typs Omnidirectional, Stacked, Stacked Omnidirectional oder Truncated verwendet werden.",
			    i25Length: "Der Interleaved2of5-Barcode muss aus einer geraden Anzahl Ziffern bestehen. Bei einer ungeraden Anzahl kann 0 vorangestellt werden.",
			    intelligentMailLength: "Der Intelligent Mail Barcode besteht aus 20, 25, 29 oder 31 Zeichen - ein 20-stelliger Verfolgungscode (2 Zeichen für die Barcode-ID, 3 Ziffern für die Diensttyp-ID, 6 oder 9 Ziffern für die Adressfeld-ID und 9 oder 6 Ziffern für die Seriennummer) und 0, 5, 9 oder 11 Postleitzahlensymbole.",
			    intelligentMailSecondDigit: "Die zweite Ziffer muss im Bereich 0-4 liegen.",
			    invalidAI: "Ungültige Elementzeichenfolge für Application Identifier. Vergewissern Sie sich, dass die AI-Zeichenfolge in den Daten das korrekte Format hat.",
			    invalidCharacter: "Das Zeichen '{0}' ist für den aktuellen Barcode-Typ ungültig. Gültige Zeichen: {1}",
			    invalidDimension: "Keine Möglichkeit zur Visualisierung von Barcode wegen inkorrekter Kombination von Eigenschaftswerten - Stretch, BarsFillMode und XDimension.",
			    invalidHeight: "Die Barcode-Rasterzeilen (Anzahl {0}) passen nicht in diese Höhe ({1} Pixel).",
			    invalidLength: "Der Barcode muss aus {0} Ziffern bestehen.",
			    invalidPostalCode: "Ungültiger PostalCode-Wert - Mode 2 codiert bis 9-stellige Postleitzahlen (Postleitzahl in USA), Mode 3 dagegen alphanumerische Codes mit bis zu 6 Zeichen.",
			    invalidPropertyValue: "Der Eigenschaftswert {0} muss im Bereich {1}-{2} liegen.",
			    invalidVersion: "Die SizeVersion-Nummer generiert nicht genügend Zellen für die Codierung der Daten mit dem aktuellen Codierungsmodus und der Fehlerkorrekturebene.",
			    invalidWidth: "Die Barcode-Rasterspalten (Anzahl {0}) passen nicht in diese Breite ({1} Pixel). Überprüfen Sie XDimension und/oder die WidthToHeightRatio Eigenschaftswerte.",
			    invalidXDimensionValue: "Für den aktuellen Barcode-Typ muss der X-Dimension-Wert im Bereich {0} bis {1} liegen.",
			    maxLength: "Die Textlänge {0} überschreitet die für den aktuellen Barcode-Typ maximal codierbare Länge. Maximal {1} Zeichen können codiert werden.",
			    notSupportedEncoding: "Die Codierung entsprechend {0} {1} wird nicht unterstützt.",
			    pDF417InvalidRowsColumnsCombination: "Die Codewörter (Daten- und Fehlerkorrektur) sind mehr als in einem Symbol mit Matrix {0}x{1} codiert werden können.",
			    primaryMessageError: "Die Primärnachricht kann nicht aus dem Datenwert extrahiert werden. Die zugehörige Struktur finden Sie in der Dokumentation.",
			    serviceClassError: "Fehler bei der Konvertierung der Dienstklasse. Sie muss ein numerischer Wert sein.",
			    smallSize: "Mit den definierten Stretch-Einstellungen passt das Raster nicht in Size({0}, {1}).",
			    unencodableCharacter: "Das Zeichen '{0}' kann nicht codiert werden.",
			    uPCEFirstDigit: "Die erste UPC-E Ziffer ist der Spezifikation entsprechend immer Null.",
			    warningString: "Barcode Warnung: ",
			    wrongCompactionMode: "Die Datennachricht kann nicht mit dem {0} Modus komprimiert werden.",
			    notLoadedEncoding: "Die Codierung {0} ist nicht geladen."
		    }
	    };
    }
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Combo localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Combo) {
	    $.ig.Combo = {
		    locale: {
		        noMatchFoundText: 'Keine Ergebnisse',
		        dropDownButtonTitle: 'Dropdown anzeigen',
		        clearButtonTitle: 'Wert löschen',
		        placeHolder: 'auswählen...',
		        notSuported: 'Vorgang wird nicht unterstützt.',
		        errorNoSupportedTextsType: "Ein anderer Filtertext ist erforderlich. Einen Wert angeben, der entweder eine Zeichenfolge oder ein Array mit Zeichenfolgen ist.",
		        errorUnrecognizedHighlightMatchesMode: 'Ein anderer Modus zum Hervorheben von Übereinstimmungen ist erforderlich. Einen Wert aus "multi", "contains", "startsWith", "full" und "null" wählen.',
		        errorIncorrectGroupingKey: "Gruppierungsschlüssel ist nicht korrekt."
		    }
	    };
    }
})(jQuery);

/*!@license
* Infragistics.Web.ClientUI Dialog localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Dialog) {
	    $.ig.Dialog = {
		    locale: {
			    closeButtonTitle: "Schließen",
			    minimizeButtonTitle: "Minimieren",
			    maximizeButtonTitle: "Maximieren",
			    pinButtonTitle: "Anheften",
			    unpinButtonTitle: "Lösen",
			    restoreButtonTitle: "Wiederherstellen"
		    }
	    };
    }
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Doughnut Chart localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.igDoughnutChart) {
        $.ig.igDoughnutChart = {};

        $.extend($.ig.igDoughnutChart, {
            locale: {
                invalidBaseElement: " wird nicht als Basiselement unterstützt. Stattdessen DIV verwenden."
            }
        });
    }
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Editors localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Editor) {
	    $.ig.Editor = {
		    locale: {
			    spinUpperTitle: 'Erhöhen',
			    spinLowerTitle: 'Verringern',
			    buttonTitle: 'Liste anzeigen',
			    clearTitle: 'Wert löschen',
			    ariaTextEditorFieldLabel: 'Text-Editor',
			    ariaNumericEditorFieldLabel: 'Zahlen-Editor',
			    ariaCurrencyEditorFieldLabel: 'Währungseditor',
			    ariaPercentEditorFieldLabel: 'Prozent-Editor',
			    ariaMaskEditorFieldLabel: 'Masken-Editor',
			    ariaDateEditorFieldLabel: 'Daten-Editor',
			    ariaDatePickerFieldLabel: 'Datumsauswahl',
			    ariaSpinUpButton: 'Nach oben drehen',
			    ariaSpinDownButton: 'Nach unten drehen',
			    ariaDropDownButton: 'Aufklappen',
			    ariaClearButton: 'Löschen',
			    ariaCalendarButton: 'Kalender',
			    datePickerButtonTitle: 'Kalender anzeigen',
			    updateModeUnsupportedValue: 'Die Option updateMode unterstützt zwei mögliche Werte - "onChange" und "immediate"',
			    updateModeNotSupported: 'updateMode-Eigenschaft unterstützt ausschließlich „onchange“-Modus für igMaskEditor-, igDateEditor- und igDatePicker-Erweiterungen',
			    renderErrMsg: "Ein Basiseditor kann nicht direkt instantiiert werden. Mit einem Text-, Nummern-, Daten- oder anderen Editor versuchen.",
			    multilineErrMsg: 'textArea erfordert eine andere Konfiguration. Der textMode sollte auf "multiline" eingestellt sein.',
			    targetNotSupported: "Dieses Zielelement wird nicht unterstützt.",
			    placeHolderNotSupported: "Das Platzhalterattribut wird von Ihrem Browser nicht unterstützt.",
			    allowedValuesMsg: "Einen Wert von der Drop-Down-Liste wählen",
			    maxLengthErrMsg: "Eintrag ist zu lang und wurde auf {0} Symbole reduziert",
			    maxLengthWarningMsg: "Eintrag hat die maximal zulässige Zeichenlänge von {0} für dieses Feld erreicht",
			    minLengthErrMsg: "Mindestens {0} Zeichen sollten eingegeben werden",
			    maxValErrMsg: "Eintrag hat den maximalen Wert von {0} für dieses Feld erreicht",
			    minValErrMsg: "Eintrag hat den minimalen Wert von {0} für dieses Feld erreicht",
			    maxValExceedRevertErrMsg: "Eintrag hat den maximalen Wert von {0} überstiegen und wurde auf den vorherigen zurückgestellt",
			    minValExceedRevertErrMsg: "Eintrag lag unter dem Mindestwert von {0} und wurde auf den vorherigen zurückgesetzt",
			    maxValExceedSetErrMsg: "Entry exceeded the maximum value of {0} and was set to the maximum value",
			    minValExceedSetErrMsg: "Entry exceeded the minimum value of {0} and was set to the minimum value",
			    maxValExceededWrappedAroundErrMsg: "Eintrag hat den maximalen Wert von {0} überstiegen und wurde auf den minimal erlaubten eingestellt",
			    minValExceededWrappedAroundErrMsg: "Eintrag lag unter dem Mindestwert von {0} und wurde auf den maximal zulässigen eingestellt",
			    btnValueNotSupported: 'Ein anderer Schaltflächenwert ist erforderlich. Wert zwischen "dropdown", "clear" und "spin" wählen.',
			    scientificFormatErrMsg: 'Ein anderes scientificFormat ist erforderlich. Wert zwischen "E", "e", "E+" und "e+" wählen.',
			    spinDeltaIsOfTypeNumber: "Ein anderer Typ von spinDelta ist erforderlich. Eine positive Zahl sollte eingegeben werden.",
			    spinDeltaCouldntBeNegative: "Die spinDelta-Option kann nicht negativ sein. Eine positive Zahl sollte eingegeben werden.",
			    spinDeltaContainsExceedsMaxDecimals: "Maximal erlaubte Bruchzahlen für spinDelta sind auf {0} festgelegt. Entweder MaxDecimals ändern oder versuchen, Ihren Wert zu verringern.",
			    spinDeltaIncorrectFloatingPoint: 'Ein Gleitkomma-spinDelta erfordert eine andere Konfiguration. Stellen Sie den dataMode des Editors entweder auf „double“ oder „float“ oder stellen Sie spinDelta auf eine ganze Zahl.',
			    notEditableOptionByInit: "Diese Option kann nach der Initialisierung nicht bearbeitet werden. Ihr Wert sollte während der Initialisierung festgelegt werden.",
			    numericEditorNoSuchMethod: "Der Zahleneditor unterstützt diese Methode nicht.",
			    numericEditorNoSuchOption: "Der Zahlen-Editor unterstützt diese Option nicht.",
			    displayFactorIsOfTypeNumber: "displayFactor erfordert einen anderen Wert. Sein Wert sollte auf 1 oder 100 als Zahl festgelegt werden.",
			    displayFactorAllowedValue: "displayFactor erfordert einen anderen Wert. Sein Wert sollte auf 1 oder 100 als Zahl festgelegt werden.",
			    instantiateCheckBoxErrMsg: "igCheckboxEditor erfordert ein anderes Element. INPUT, SPAN oder DIV-Element benutzen.",
			    cannotParseNonBoolValue: "igCheckboxEditor erfordert einen anderen Wert. Ein boolescher Wert sollte zur Verfügung stehen.",
			    cannotSetNonBoolValue: "igCheckboxEditor erfordert einen anderen Wert. Ein boolescher Wert sollte zur Verfügung stehen.",
			    maskEditorNoSuchMethod: "Der Masken-Editor unterstützt diese Methode nicht.",
			    datePickerEditorNoSuchMethod: "Der Daten-Editor unterstützt diese Methode nicht.",
			    datePickerNoSuchMethodDropDownContainer: "Der Daten-Editor unterstützt diese Methode nicht. Verwenden Sie stattdessen „getCalendar“.",
			    buttonTypeIsDropDownOnly: "Der Datepicker erlaubt nur Dropdown und Wert löschen für die buttonType-Option.",
			    dateEditorMinValue: "MinValue-Option kann nicht zur Laufzeit festgelegt werden.",
			    dateEditorMaxValue: "MaxValue-Option kann nicht zur Laufzeit festgelegt werden.",
			    cannotSetRuntime: "Diese Option kann nicht zur Laufzeit festgelegt werden",
                invalidDate: "Ungültiges Datum",
                maskMessage: 'Alle erforderlichen Positionen sollten ausgefüllt werden',
                dateMessage: 'Ein gültiges Datum sollte eingegeben werden',
                centuryThresholdValidValues: "centuryThreshold-Eigenschaft muss zwischen 0 und 99 liegen. Der Wert wurde auf Standardwerte zurückgesetzt.",
                noListItemsNoButton: "Es wird keine Spin- oder Dropdown-Schaltfläche gerendert, da keine Listenelemente vorliegen."
		    }
	    };
    }
})(jQuery);
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

/*!@license
* Infragistics.Web.ClientUI HTML Editor localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
$.ig = $.ig || {};

if (!$.ig.HtmlEditor) {
	$.ig.HtmlEditor = {};

	$.extend($.ig.HtmlEditor, {

		locale: {
			boldButtonTitle: 'Fett',
			italicButtonTitle: 'Kursiv',
			underlineButtonTitle: 'Unterstrichen',
			strikethroughButtonTitle: 'Durchgestrichen',
			increaseFontSizeButtonTitle: 'Schriftart vergrößern',
			decreaseFontSizeButtonTitle: 'Schriftart verkleinern',
			alignTextLeftButtonTitle: 'Text linksbündig ausrichten',
			alignTextRightButtonTitle: 'Text rechtsbündig ausrichten',
			alignTextCenterButtonTitle: 'Zentrieren',
			justifyButtonTitle: 'Ausrichten',
			bulletsButtonTitle: 'Aufzählungszeichen',
			numberingButtonTitle: 'Nummerierung',
			decreaseIndentButtonTitle: 'Einzug verkleinern',
			increaseIndentButtonTitle: 'Einzug vergrößern',
			insertPictureButtonTitle: 'Bild einfügen',
			fontColorButtonTitle: 'Schriftfarbe',
			textHighlightButtonTitle: 'Texthervorhebungsfarbe',
			insertLinkButtonTitle: 'Hyperlink einfügen',
			insertTableButtonTitle: 'Tabelle',
			addRowButtonTitle: 'Zeile hinzufügen',
			removeRowButtonTitle: 'Zeile entfernen',
			addColumnButtonTitle: 'Spalte hinzufügen',
			removeColumnButtonTitle: 'Spalte entfernen',
			inserHRButtonTitle: 'Horizontale Linie einfügen',
			viewSourceButtonTitle: 'Quelle anzeigen',
			cutButtonTitle: 'Ausschneiden',
			copyButtonTitle: 'Kopieren',
			pasteButtonTitle: 'Einfügen',
			undoButtonTitle: 'Rückgängig',
			redoButtonTitle: 'Wiederholen',
			imageUrlDialogText: 'Bild-URL:',
			imageAlternativeTextDialogText: 'Alternativer Text:',
			imageWidthDialogText: 'Bildbreite:',
			imageHeihgtDialogText: 'Bildhöhe:',
			linkNavigateToUrlDialogText: 'Zu URL navigieren:',
			linkDisplayTextDialogText: 'Text anzeigen:',
			linkOpenInDialogText: 'Öffnen in:',
			linkTargetNewWindowDialogText: 'Neues Fenster',
			linkTargetSameWindowDialogText: 'Gleiches Fenster',
			linkTargetParentWindowDialogText: 'Übergeordnetes Fenster',
			linkTargetTopmostWindowDialogText: 'Fenster im Vordergrund',
			applyButtonTitle: 'Übernehmen',
			cancelButtonTitle: 'Abbrechen',
			defaultToolbars: {
			    textToolbar: "text manipulation toolbar",
			    formattingToolbar: "text formatting toolbar",
			    insertObjectToolbar: "objects insertion toolbar",
			    copyPasteToolbar: "copy/paste toolbar"
			},
			fontNames: {
				win: [
						{ text: "Times New Roman", value: "Times New Roman" },
						{ text: "Arial", value: "Arial" },
						{ text: "Arial Black", value: "Arial Black" },
						{ text: "Helvetica", value: "Helvetica" },
						{ text: "Comic Sans MS", value: "Comic Sans MS" },
						{ text: "Courier New", value: "Courier New" },
						{ text: "Georgia", value: "Georgia" },
						{ text: "Impact", value: "Impact" },
						{ text: "Lucida Console", value: "Lucida Console" },
						{ text: "Lucida Sans Unicode", value: "Lucida Sans Unicode" },
						{ text: "Palatino Linotype", value: "Palatino Linotype" },
						{ text: "Tahoma", value: "Tahoma" },
						{ text: "Trebuchet MS", value: "Trebuchet MS" },
						{ text: "Verdana", value: "Verdana" },
						{ text: "Symbol", value: "Symbol" },
						{ text: "Webdings", value: "Webdings" },
						{ text: "Wingdings", value: "Wingdings" },
						{ text: "MS Sans Serif", value: "MS Sans Serif" },
						{ text: "MS Serif", value: "MS Serif" }
					],
				mac: [
						{ text: "Times New Roman", value: "Times New Roman" },
						{ text: "Arial", value: "Arial" },
						{ text: "Arial Black", value: "Arial Black" },
						{ text: "Helvetica", value: "Helvetica" },
						{ text: "Comic Sans MS", value: "Comic Sans MS" },
						{ text: "Courier New", value: "Courier New" },
						{ text: "Georgia", value: "Georgia" },
						{ text: "Impact", value: "Impact" },
						{ text: "Monaco", value: "Monaco" },
						{ text: "Lucida Grande", value: "Lucida Grande" },
						{ text: "Book Antiqua", value: "Book Antiqua" },
						{ text: "Geneva", value: "Geneva" },
						{ text: "Trebuchet MS", value: "Trebuchet" },
						{ text: "Verdana", value: "Verdana" },
						{ text: "Symbol", value: "Symbol" },
						{ text: "Webdings", value: "Webdings" },
						{ text: "Zapf Dingbats", value: "Zapf Dingbats" },
						{ text: "New York", value: "New York" }
					]
			},
			fontSizes: [
				{ text: "1", value: "7.5 pt" },
				{ text: "2", value: "10 pt" },
				{ text: "3", value: "12 pt" },
				{ text: "4", value: "13.5 pt" },
				{ text: "5", value: "18 pt" },
				{ text: "6", value: "24 pt" },
				{ text: "7", value: "36 pt" }
			],
			formatsList: [
					{ text: "h1", value: "Überschrift 1" },
					{ text: "h2", value: "Überschrift 2" },
					{ text: "h3", value: "Überschrift 3" },
					{ text: "h4", value: "Überschrift 4" },
					{ text: "h5", value: "Überschrift 5" },
					{ text: "h6", value: "Überschrift 6" },
                    { text: "p", value: "Normal" }
				]
		}

	});
}
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Notifier localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function($) {
$.ig = $.ig || {};

if (!$.ig.Notifier) {
	$.ig.Notifier = {};

	$.extend($.ig.Notifier, {
		locale: {
		    successMsg: "Erfolgreich",
		    errorMsg: "Fehler",
		    warningMsg: "Warnung"
		}
	});

}
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Pivot Shared localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.PivotShared) {
        $.ig.PivotShared = {};

        $.extend($.ig.PivotShared, {
            locale: {
                invalidDataSource: "Die angegebene Datenquelle ist entweder Null oder wird nicht unterstützt.",
                measureList: "Measures",
                ok: "OK",
                cancel: "Abbrechen",
                addToMeasures: "Zu Measures hinzufügen",
                addToFilters: "Zu Filtern hinzufügen",
                addToColumns: "Zu Spalten hinzufügen",
                addToRows: "Zu Zeilen hinzufügen"
            }
        });
    }
})(jQuery);
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
                invalidBaseElement: " wird nicht als Basiselement unterstützt. Stattdessen DIV verwenden.",
                catalog: "Katalog",
                cube: "Cube",
                measureGroup: "Measuregruppe",
                measureGroupAll: "(Alle)",
                rows: "Zeilen",
                columns: "Spalten",
                measures: "Measures",
                filters: "Filter",
                deferUpdate: "Aktualisierung verzögern",
                updateLayout: "Layout aktualisieren",
                selectAll: "Alle auswählen"
            }
        });
    }
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Pivot Grid localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.PivotGrid) {
        $.ig.PivotGrid = {};

        $.extend($.ig.PivotGrid, {
            locale: {
                filtersHeader: "Filterfelder hier ablegen",
                measuresHeader: "Datenfelder hierher ziehen",
                rowsHeader: "Zeilenfelder hierher ziehen",
                columnsHeader: "Spaltenfelder hierher ziehen",
                disabledFiltersHeader: "Filterfelder",
                disabledMeasuresHeader: "Datenelemente",
                disabledRowsHeader: "Zeilenfelder",
                disabledColumnsHeader: "Spaltenfelder",
                noSuchAxis: "Keine solche Achse"
            }
        });
    }
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Popover localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
$.ig = $.ig || {};

if (!$.ig.Popover) {
	$.ig.Popover = {};

	$.extend( $.ig.Popover, {
		locale: {
			popoverOptionChangeNotSupported: "Die Änderung der folgenden Option nach der Initialisierung von igPopover wird nicht unterstützt:",
			popoverShowMethodWithoutTarget: "Der Target-Parameter der Show-Funktion ist obligatorisch, wenn die Selectors-Option verwendet wird"
		}
	});

}
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Rating localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Rating) {
	    $.ig.Rating = {};

	    $.extend($.ig.Rating, {
		    locale: {
			    setOptionError: 'Laufzeit-Änderungen sind für die folgende Option nicht zugelassen: '
		    }
	    });
    }
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Splitter localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
$.ig = $.ig || {};

if (!$.ig.Splitter) {
	$.ig.Splitter = {};

	$.extend($.ig.Splitter, {
		locale: {
		    errorPanels: 'Die Anzahl Bereiche muss größer als zwei sein.',
		    errorSettingOption: 'Option der Fehlereinstellung.'
		}
	});

}
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Tile Manager localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
$.ig = $.ig || {};

if (!$.ig.TileManager) {
	$.ig.TileManager = {};

	$.extend($.ig.TileManager, {
		locale: {
		    renderDataError: "Die Daten wurden nicht erfolgreich abgerufen oder analysiert.",
		    setOptionItemsLengthError: "The length of the items configurations does not match the number of the tiles."
		}
	});

}
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Toolbar localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
$.ig = $.ig || {};

if (!$.ig.Toolbar) {
    $.ig.Toolbar = {};

    $.extend($.ig.Toolbar, {

		locale: {
			collapseButtonTitle: 'Reduzieren',
			expandButtonTitle: 'Erweitern'
		}

	});
}
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Tree localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Tree) {
	    $.ig.Tree = {};

	    $.extend($.ig.Tree, {
		    locale: {
			    invalidArgumentType: 'Ungültiger Argumenttyp angegeben.',
			    errorOnRequest: 'Beim Abrufen von Daten ist ein Fehler aufgetreten: ',
			    noDataSourceUrl: 'Für die igTree Steuerung muss eine dataSourceUrl angegeben werden, um eine Anforderung für Daten an diese URL zu initiieren.',
			    incorrectPath: 'Am angegebenen Pfad wurde kein Knoten gefunden: ',
			    incorrectNodeObject: 'Das angegebene Argument ist kein jQuery Knotenelement.',
			    setOptionError: 'Laufzeit-Änderungen sind für die folgende Option nicht zugelassen: ',
			    moveTo: '<strong>Verschieben nach</strong> {0}',
			    moveBetween: '<strong>Verschieben zwischen</strong> {0} und {1}',
			    moveAfter: '<strong>Verschieben nach</strong> {0}',
			    moveBefore: '<strong>Verschieben vor</strong> {0}',
			    copyTo: '<strong>Kopieren nach</strong> {0}',
			    copyBetween: '<strong>Kopieren zwischen</strong> {0} und {1}',
			    copyAfter: '<strong>Kopieren nach</strong> {0}',
			    copyBefore: '<strong>Kopieren vor</strong> {0}',
			    and: 'und'
		    }
	    });

    }
})(jQuery);
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
                fixedVirtualizationNotSupported: 'RowVirtualization erfordert eine andere virtualizationMode-Konfiguration. Der virtualizationMode sollte auf "continuous" eingestellt sein.'
            }
        });

        $.ig.TreeGridPaging = $.ig.TreeGridPaging || {};

        $.extend($.ig.TreeGridPaging, {
            locale: {
                contextRowLoadingText: "Ladevorgang läuft...",
                contextRowRootText: "Stamm",
                columnFixingWithContextRowNotSupported: 'ColumnFixing erfordert eine andere contextRowMode-Konfiguration. contextRowMode sollte auf "none" gestellt werden, um ColumnFixing zu aktivieren.'
            }
        });

        $.ig.TreeGridFiltering = $.ig.TreeGridFiltering || {};

        $.extend($.ig.TreeGridFiltering, {
            locale: {
                filterSummaryInPagerTemplate: "${currentPageMatches} von ${totalMatches} übereinstimmenden Datensätzen"
            }
        });

        $.ig.TreeGridRowSelectors = $.ig.TreeGridRowSelectors || {};

        $.extend($.ig.TreeGridRowSelectors, {
        	locale: {
        	    multipleSelectionWithTriStateCheckboxesNotSupported: "Multiples Auswählen erfordert eine andere checkBoxMode-Konfiguration. checkBoxMode sollte auf biState gestellt werden, um multiples Auswählen zu aktivieren."
        	}
        });
    }
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Upload localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Upload) {
	    $.ig.Upload = {};

	    $.extend($.ig.Upload, {

		    locale: {
			    labelUploadButton: "Datei hochladen",
			    labelAddButton: "Hinzufügen",
			    labelClearAllButton: "Hochgeladene löschen",
			    // M.H. 13 May 2011 - fix bug 75042
			    labelSummaryTemplate: "{0} von {1} hochgeladenen",
			    labelSummaryProgressBarTemplate: "{0}/{1}",
			    labelShowDetails: "Details anzeigen",
			    labelHideDetails: "Details ausblenden",
			    labelSummaryProgressButtonCancel: "Abbrechen",
			    // M.H. 1 June 2011 Fix bug #77532
			    labelSummaryProgressButtonContinue: "Hochladen",
			    labelSummaryProgressButtonDone: "Fertig",
			    labelProgressBarFileNameContinue: "...",

			    //error messages
			    errorMessageFileSizeExceeded: "Max. Dateigröße überschritten",
			    errorMessageGetFileStatus: "Ihr aktueller Dateistatus konnte nicht erfasst werden! Wahrscheinlich ist Verbindung abgebrochen.",
			    errorMessageCancelUpload: "Befehl zum Abbrechen des Upload-Vorgangs konnte nicht an Server gesendet werden! Wahrscheinlich ist Verbindung abgebrochen.",
			    errorMessageNoSuchFile: "Die angeforderte Datei konnte nicht gefunden werden. Wahrscheinlich ist diese Datei zu groß.",
			    errorMessageOther: "Beim Hochladen der Datei ist ein interner Fehler aufgetreten. Fehlercode: {0}.",
			    errorMessageValidatingFileExtension: "Überprüfung der Datenerweiterung ist fehlgeschlagen.",
			    errorMessageAJAXRequestFileSize: "Beim Erfassen der Dateigröße ist ein AJAX-Fehler aufgetreten.",
			    errorMessageMaxUploadedFiles: "Die maximale Anzahl von hochladbaren Dateien wurde überschritten.",
			    errorMessageMaxSimultaneousFiles: "Der Wert von maxSimultaneousFilesUploads ist falsch. Er muss mehr als 0 oder Null lauten.",
			    errorMessageTryToRemoveNonExistingFile: "Sie versuchen, eine nicht vorhandene Datei mit ID {0} zu entfernen.",
			    errorMessageTryToStartNonExistingFile: "Sie versuchen, eine nicht vorhandene Datei mit ID {0} zu starten.",
			    errorMessageDropMultipleFilesWhenSingleModel: "Es ist nicht erlaubt, im Einfachmodus mehr als 1 Datei abzulegen",

			    // M.H. 12 May 2011 - fix bug 74763: add title to all buttons
			    // title attributes            
			    titleUploadFileButtonInit: "Datei hochladen",
			    titleAddFileButton: "Hinzufügen",
			    titleCancelUploadButton: "Abbrechen",
			    // M.H. 1 June 2011 Fix bug #77532
			    titleSummaryProgressButtonContinue: "Hochladen",
			    titleClearUploaded: "Hochgeladene löschen",
			    titleShowDetailsButton: "Details anzeigen",
			    titleHideDetailsButton: "Details ausblenden",
			    titleSummaryProgressButtonCancel: "Abbrechen",
			    titleSummaryProgressButtonDone: "Fertig",
			    // M.H. 1 June 2011 Fix bug #77532
			    titleSingleUploadButtonContinue: "Hochladen",
			    titleClearAllButton: "Hochgeladene löschen"
		    }
	    });

    }
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Validator localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Validator) {
	    $.ig.Validator = {
		    locale: {
			    defaultMessage: 'Bitte korrigieren Sie dieses Feld',
			    selectMessage: 'Bitte wählen Sie einen Wert aus',
			    rangeSelectMessage: 'Bitte wählen Sie nicht mehr als {0} und nicht weniger als {1} Elemente',
			    minSelectMessage: 'Bitte wählen Sie mindestens {0} Elemente',
			    maxSelectMessage: 'Bitte wählen Sie nicht mehr als {0} Elemente',
			    rangeLengthMessage: 'Bitte geben Sie einen Wert zwischen {0} und {1} Zeichen ein',
			    minLengthMessage: 'Bitte geben Sie mindestens {0} Zeichen ein',
			    maxLengthMessage: 'Bitte geben Sie nicht mehr als {0} Zeichen ein',
			    requiredMessage: 'Dieses Feld ist erforderlich',
			    patternMessage: 'Eintrag entspricht nicht dem erforderlichen Muster',
			    maskMessage: 'Bitte füllen Sie alle erforderlichen Positionen aus',
			    dateFieldsMessage: 'Bitte geben Sie Werte in Datumsfelder ein',
			    invalidDayMessage: 'Ungültiger Tag des Monats Bitte geben Sie einen korrekten Tag ein',
			    dateMessage: 'Bitte geben Sie ein gültiges Datum ein',
			    numberMessage: 'Bitte geben Sie eine gültige Nummer ein',
                rangeValueMessage: 'Bitte geben Sie einen Wert zwischen {0} und {1} ein',
		        minValueMessage: 'Bitte geben Sie einen Wert größer oder gleich {0} ein',
		        maxValueMessage: 'Bitte geben Sie einen Wert kleiner oder gleich {0} ein',
		        emailMessage: 'Eine gültige E-Mail-Adresse sollte eingegeben werden',
		        equalToMessage: 'Die zwei Werte stimmen nicht überein',
		        optionalString: '(optional)'
		    }
	    };
    }
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Video Player localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.VideoPlayer) {
	    $.ig.VideoPlayer = {};

	    $.extend($.ig.VideoPlayer, {

		    locale: {
			    liveStream: "Live-Video",
			    live: "Live",
			    paused: "Pause",
			    playing: "Wiedergabe",
			    play: 'Wiedergeben',
			    volume: "Lautstärke",
			    unsupportedVideoSource: "Die aktuellen Videoquellen enthalten kein Format, das von Ihrem Browser unterstützt wird.",
			    missingVideoSource: "Keine kompatible Videoquelle.",
			    progressLabelLongFormat: "$currentTime$ / $duration$",
			    progressLabelShortFormat: "$currentTime$",
			    enterFullscreen: "In Vollbildmodus wechseln",
			    exitFullscreen: "Vollbildmodus beenden",
			    skipTo: "ÜBERSPRINGEN ZU",
			    unsupportedBrowser: "Der aktuelle Browser unterstützt HTML5 Video nicht. <br/>Führen Sie ein Upgrade auf eine der folgenden Versionen durch:",
			    currentBrowser: "Aktueller Browser: {0}",
			    ie9: "Microsoft Internet Explorer V 9+",
			    chrome8: "Google Chrome V 8+",
			    firefox36: "Mozilla Firefox V 3.6+",
			    safari5: "Apple Safari V 5+",
			    opera11: "Opera V 11+",
			    ieDownload: "http://www.microsoft.com/windows/internet-explorer/default.aspx",
			    operaDownload: "http://www.opera.com/download/",
			    chromeDownload: "http://www.google.com/chrome",
			    firefoxDownload: "http://www.mozilla.com/",
			    safariDownload: "http://www.apple.com/safari/download/",
			    buffering: 'Pufferung...',
			    adMessage: 'Anzeige: Das Video wird in $duration$ Sekunden fortgesetzt.',
			    adMessageLong: 'Anzeige: Das Video wird in $duration$ fortgesetzt.',
			    adMessageNoDuration: 'Anzeige: Das Video wird nach der Werbung fortgesetzt.',
			    adNewWindowTip: 'Anzeige: Klicken, um Anzeigeinhalt in einem neuen Fenster zu öffnen.',
			    nonDivException: 'Der Infragistics HTML5 Videoplayer kann nur auf einem DIV Tag instanziiert werden.',
			    relatedVideos: 'VERWANDTE VIDEOS',
			    replayButton: 'Wiedergeben',
			    replayTooltip: 'Klicken, um das letzte Video wiederzugeben.'
		    }
	    });

    }
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI Zoombar localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
$.ig = $.ig || {};

if (!$.ig.Zoombar) {
	$.ig.Zoombar = {};

	$.extend($.ig.Zoombar, {

	    locale: {
	        zoombarTargetNotSpecified: "igZoombar erfordert ein gültiges Ziel zum Anfügen.",
	        zoombarTypeNotSupported: "Der Widget-Typ, an den sich die Zoomleiste anzufügen versucht, wird nicht unterstützt.",
	        optionChangeNotSupported: "Die Änderung der folgenden Option nach der Erstellung der igZoombar wird nicht unterstützt:"
		}
	});

}
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI utilities localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.util) {
	    $.ig.util = {};

	    $.extend($.ig.util, {

		    locale: {
			    unsupportedBrowser: "Der aktuelle Browser unterstützt HTML5 Canvas Element nicht. <br/>Führen Sie ein Upgrade auf eine der folgenden Versionen durch:",
			    currentBrowser: "Aktueller Browser: {0}",
			    ie9: "Microsoft Internet Explorer V 9+",
			    chrome8: "Google Chrome V 8+",
			    firefox36: "Mozilla Firefox V 3.6+",
			    safari5: "Apple Safari V 5+",
			    opera11: "Opera V 11+",
			    ieDownload: "http://www.microsoft.com/windows/internet-explorer/default.aspx",
			    operaDownload: "http://www.opera.com/download/",
			    chromeDownload: "http://www.google.com/chrome",
			    firefoxDownload: "http://www.mozilla.com/",
			    safariDownload: "http://www.apple.com/safari/download/"
		    }
	    });

    }
})(jQuery);

