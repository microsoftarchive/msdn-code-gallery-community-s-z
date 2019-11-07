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
			    invalidDataSource: "La source de données fournie est invalide. Il s'agit d'un scalaire.",
			    unknownDataSource: "Impossible de déterminer le type de source de données. Veuillez préciser s'il s'agit de données JSON ou XML.",
			    errorParsingArrays: "Une erreur s'est produite lors de l'analyse syntaxique des données de tableaux  et de l'application du schéma de données défini : ",
			    errorParsingJson: "Une erreur s'est produite lors de l'analyse syntaxique des données JSON et de l'application du schéma de données défini : ",
			    errorParsingXml: "Une erreur s'est produite lors de l'analyse syntaxique des données XML et de l'application du schéma de données défini : ",
			    errorParsingHtmlTable: "Une erreur s'est produite lors de l'extraction des données du tableau HTML et lors de l'application du schéma : ",
			    errorExpectedTbodyParameter: "Un corps ou un tableau était attendu comme paramètre.",
			    errorTableWithIdNotFound: "Le tableau HTML avec l'ID suivant n'a pas été trouvé : ",
			    errorParsingHtmlTableNoSchema: "Une erreur s'est produite lors de l'analyse syntaxique du tableau DOM : ",
			    errorParsingJsonNoSchema: "Une erreur s'est produite lors de l'analyse syntaxique/l'évaluation de la chaîne JSON : ",
			    errorParsingXmlNoSchema: "Une erreur s'est produite lors de l'analyse syntaxique de la chaîne XML : ",
			    errorXmlSourceWithoutSchema: "La source de données fournie est un document xml, mais il n'existe pas de schéma de données défini ($.IgDataSchema) ",
			    errorUnrecognizedFilterCondition: " La condition de filtre spécifiée n'a pas été reconnue : ",
			    errorRemoteRequest: "La requête à distance pour récupérer les données a échoué : ",
			    errorSchemaMismatch: "Les données entrées ne coïncident pas avec le schéma, le champ suivant n'a pas pu être cartographié : ",
			    errorSchemaFieldCountMismatch: "Les données entrées ne coïncident pas avec le schéma en termes de nombre de champs. ",
			    errorUnrecognizedResponseType: "Le type de réponse n'a pas été défini correctement ou il était impossible de le détecter automatiquement. Veuillez définir settings.responseDataType et/ou settings.responseContentType.",
			    hierarchicalTablesNotSupported: "Les tableaux ne sont pas pris en charge pour HierarchicalSchema",
			    cannotBuildTemplate: "Le modèle jQuery n'a pas pu être créé. Aucune archive présente dans la source de données et aucune colonne définie.",
			    unrecognizedCondition: "Condition de filtrage non reconnue dans l'expression suivante : ",
			    fieldMismatch: "L'expression suivante contient un champ ou une condition de filtrage invalide : ",
			    noSortingFields: "Aucun champ spécifié. Spécifiez au moins un champ de tri pour utiliser l'option de tri ().",
			    filteringNoSchema: "Aucun schéma/champ spécifié. Spécifiez un schéma avec des définitions et types de champs pour pouvoir filtrer la source de données.",
			    noSaveChanges: "Échec de l’enregistrement des modifications. Le serveur n’a pas renvoyé l’objet Success ou a renvoyé Success:false.",
			    errorUnexpectedCustomFilterFunction: "Une valeur inattendue a été fournie pour une fonction de filtre personnalisé. Une fonction ou une chaîne est attendue."
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
		    undefinedArgument: "Une erreur s'est produite pendant la récupération de la propriété de la source de données : "
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
                aILength: "L'AI doit avoir au moins 2 chiffres.",
                badFormedUCCValue: "Les Données du code-barres UCC ne sont pas bien formées. Le format correct doit être (AI)GTIN.",
                code39_NonNumericError: "Le caractère '{0}' est non valide pour les Données du code-barres CODE39. Les caractères valides sont: {1}",
                countryError: "Erreur dans la conversion du code du pays. Ce doit être une valeur numérique.",
                emptyValueMsg: "La valeur des Données est vide.",
                encodingError: "Erreur dans la conversion. Reportez-vous à la documentation pour les valeurs appropriées des propriétés.",
                errorMessageText: "Valeur non valide! Reportez-vous à la documentation pour la structure appropriée des Données du code-barres.",
                gS1ExMaxAlphanumNumber: "La famille GS1 DataBar Expanded peut encoder jusqu'à 41 caractères alphanumériques.",
                gS1ExMaxNumericNumber: "La famille GS1 DataBar Expanded peut encoder jusqu'à 74 caractères numériques.",
                gS1Length: "Les données du GS1 DataBar sont utilisées pour GTIN - 8, 12, 13, 14 et leur longueur doit être de 7, 11, 12 ou 13. Le dernier chiffre est réservé à une somme de contrôle.",
                gS1LimitedFirstChar: "Le premier chiffre de GS1 DataBar Limited doit être 0 ou 1. Lors de l'encodage de structures de données GTIN-14 avec une valeur de l'indicateur supérieure à 1, le type de code-barres Omnidirectional, Stacked, Stacked Omnidirectional ou Truncated doit être utilisé.",
                i25Length: "Le code-barres Interleaved2of5 doit avoir un nombre de chiffres pair. Vous pouvez mettre un 0 au début s'il s'agit d'un nombre impair.",
                intelligentMailLength: "Les Données du code-barres Intelligent Mail doivent avoir 20, 25, 29 ou 31 caractères - code de suivi à 20 chiffres (2 pour l'identificateur du code-barres, 3 pour l'identificateur du type de service, 6 ou 9 pour l'identificateur de l'expéditeur et 9 ou 6 pour le numéro de série) et 0, 5, 9 ou 11 symboles pour le code postal.",
                intelligentMailSecondDigit: "Le deuxième chiffre doit être compris dans la plage 0-4.",
                invalidAI: "Chaînes d'éléments de l'identificateur d'application non valides. Assurez-vous que la chaîne de l'AI spécifiée dans les Données est bien formée.",
                invalidCharacter: "Le caractère '{0}' est non valide pour le type de code-barres actif. Les caractères valides sont: {1}",
                invalidDimension: "La taille du code-barres ne peut pas être définie en raison d'une combinaison incorrecte des valeurs des propriétés Stretch, BarsFillMode et XDimension.",
                invalidHeight: "Les lignes de la grille du code-barres (nombre {0}) ne peuvent pas être placées sur une telle hauteur ({1} pixels).",
                invalidLength: "Les Données du code-barres doivent contenir {0} chiffres.",
                invalidPostalCode: "Valeur PostalCode non valide - le Mode 2 encode un code postal pouvant contenir jusqu'à 9 chiffres (code postal américain) tandis que le Mode 3 encode un code alphanumérique pouvant contenir jusqu'à 6 caractères.",
                invalidPropertyValue: "La valeur de propriété {0} doit être comprise dans la plage {1}-{2}.",
                invalidVersion: "Le numéro de SizeVersion ne peut pas générer suffisamment de cellules pour encoder les données avec le mode d'encodage et le niveau de correction des erreurs actifs.",
                invalidWidth: "Les colonnes de la grille du code-barres (nombre {0}) ne peuvent pas être placées sur une telle largeur ({1} pixels). Vérifier les valeurs des propriétés XDimension et WidthToHeightRatio.",
                invalidXDimensionValue: "La valeur XDimension doit être comprise dans la plage de {0} à {1} pour le type de code-barres actif.",
                maxLength: "La longueur {0} du texte dépasse le maximum encodable pour le type de code-barres actif. Le maximum encodable est de {1} caractères.",
                notSupportedEncoding: "L'encodage correspondant sous la plage {0} {1} n'est pas pris en charge.",
                pDF417InvalidRowsColumnsCombination: "Les mots de code (correction des données et erreurs) sont plus nombreux que ceux pouvant être encodés en symboles avec une matrice {0}x{1}.",
                primaryMessageError: "Impossible d'extraire le message principal de la valeur des données. Reportez-vous à la documentation pour sa structure.",
                serviceClassError: "Erreur dans la conversion de la classe de service. Ce doit être une valeur numérique.",
                smallSize: "Impossible de placer la grille dans Size({0}, {1}) avec les paramètres Stretch définis.",
                unencodableCharacter: "Le caractère '{0}' ne peut pas être encodé.",
                uPCEFirstDigit: "Le premier chiffre de l'UPCE doit toujours être zéro par spécification.",
                warningString: "Avertissement Barcode: ",
                wrongCompactionMode: "Le message de données ne peut pas être compacté avec le mode {0}.",
                notLoadedEncoding: "L'encodage {0} n'est pas chargé."
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
		        noMatchFoundText: 'Aucun résultat',
		        dropDownButtonTitle: 'Afficher la liste déroulante',
		        clearButtonTitle: 'Effacer la valeur',
		        placeHolder: 'sélectionner...',
		        notSuported: 'L’opération n’est pas prise en charge.',
		        errorNoSupportedTextsType: "Un texte de filtrage différent est requis. Fournissez une valeur correspondant soit à une chaîne, soit à un tableau de chaînes.",
		        errorUnrecognizedHighlightMatchesMode: "Un mode d’association de surbrillance différent est requis. Choisissez une valeur entre « multi », « contains », « startsWith », « full » et « null ».",
		        errorIncorrectGroupingKey: "La clé de groupement n’est pas correcte."
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
			    closeButtonTitle: "Fermer",
			    minimizeButtonTitle: "Minimiser",
			    maximizeButtonTitle: "Maximiser",
			    pinButtonTitle: "Punaiser",
			    unpinButtonTitle: "Dépunaiser",
			    restoreButtonTitle: "Restaurer"
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
                invalidBaseElement: " n'est pas pris en charge comme élément de base. Utiliser plutôt DIV."
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
			    spinUpperTitle: 'Augmenter',
			    spinLowerTitle: 'Diminuer',
			    buttonTitle: 'Afficher la liste',
			    clearTitle: 'Effacer la valeur',
			    ariaTextEditorFieldLabel: 'Éditeur de texte',
			    ariaNumericEditorFieldLabel: 'Éditeur numérique',
			    ariaCurrencyEditorFieldLabel: 'Éditeur de monnaie',
			    ariaPercentEditorFieldLabel: 'Éditeur de pourcentage',
			    ariaMaskEditorFieldLabel: 'Éditeur de masque',
			    ariaDateEditorFieldLabel: 'Éditeur de date',
			    ariaDatePickerFieldLabel: 'Sélecteur de date',
			    ariaSpinUpButton: 'Rotation vers le haut',
			    ariaSpinDownButton: 'Rotation vers le bas',
			    ariaDropDownButton: 'Défilement vers le bas',
			    ariaClearButton: 'Effacer',
			    ariaCalendarButton: 'Calendrier',
			    datePickerButtonTitle: 'Afficher le calendrier',
			    updateModeUnsupportedValue: 'L\'option updateMode prend en charge deux valeurs possibles - "onChange" et "immediate"',
			    updateModeNotSupported: 'La propriété updateMode ne prend en charge que le mode "onchange" pour les extensions igMaskEditor, igDateEditor et igDatePicker',
			    renderErrMsg: "L’éditeur de base ne peut pas être directement instancié. Essayez avec du texte, une donnée numérique, une date ou un autre éditeur.",
			    multilineErrMsg: "textArea requiert une configuration différente. textMode doit être réglé sur « multiline ».",
			    targetNotSupported: "L’élément cible n’est pas pris en charge.",
			    placeHolderNotSupported: "L’attribut de l’espace réservé n’est pas pris en charge par votre navigateur.",
			    allowedValuesMsg: "Choisissez une valeur dans la liste déroulante",
			    maxLengthErrMsg: "La valeur entrée est trop longue et a été réduite à {0} symboles",
			    maxLengthWarningMsg: "La saisie a atteint la longueur maximale de {0} pour ce champ",
			    minLengthErrMsg: "La saisie doit comporter {0} caractères au minimum",
			    maxValErrMsg: "La valeur entrée a atteint la valeur maximum fixée à {0} pour ce champ",
			    minValErrMsg: "La valeur entrée a atteint la valeur minimum fixée à {0} pour ce champ",
			    maxValExceedRevertErrMsg: "La valeur entrée a atteint la valeur maximum fixée à {0} et est revenue à la valeur antérieure",
			    minValExceedRevertErrMsg: "La saisie est inférieure à la valeur minimale de {0} et a été ramenée à la précédente",
			    maxValExceedSetErrMsg: "Entry exceeded the maximum value of {0} and was set to the maximum value",
			    minValExceedSetErrMsg: "Entry exceeded the minimum value of {0} and was set to the minimum value",
			    maxValExceededWrappedAroundErrMsg: "La valeur entrée a atteint la valeur maximum fixée à {0} et a été fixée à la valeur minimum autorisée",
			    minValExceededWrappedAroundErrMsg: "La saisie est inférieure à la valeur minimale de {0} et a été réglée sur la valeur maximale autorisée",
			    btnValueNotSupported: "Une valeur de bouton différente est requise. Choisissez une valeur entre « dropdown », « clear » et « spin ».",
			    scientificFormatErrMsg: "Un scientificFormat différent est requis. Choisissez une valeur entre « E », « e », « E+ » et « e+ ».",
			    spinDeltaIsOfTypeNumber: "Un type de spinDelta différent est requis. Un nombre positif doit être saisi.",
			    spinDeltaCouldntBeNegative: "L’option spinDelta ne peut pas être négative. Un nombre positif doit être saisi.",
			    spinDeltaContainsExceedsMaxDecimals: "Le nombre maximum de fractions autorisées pour spinDelta est de {0}. Modifiez MaxDecimals ou diminuez la valeur.",
			    spinDeltaIncorrectFloatingPoint: "La virgule flottante spinDelta requiert une configuration différente. Réglez le dataMode de l’éditeur sur 'double' ou 'float', ou réglez spinDelta sur 'integer'.",
			    notEditableOptionByInit: "Cette option ne peut pas être modifiée après l’initialisation. Ses valeurs doivent être définies pendant l’initialisation.",
			    numericEditorNoSuchMethod: "L’éditeur numérique ne prend pas cette méthode en charge.",
			    numericEditorNoSuchOption: "L’éditeur numérique ne prend pas cette option en charge.",
			    displayFactorIsOfTypeNumber: "displayFactor requiert une valeur différente. Sa valeur doit être un nombre compris entre 1 et 100.",
			    displayFactorAllowedValue: "displayFactor requiert une valeur différente. Sa valeur doit être un nombre compris entre 1 et 100.",
			    instantiateCheckBoxErrMsg: "igCheckboxEditor requiert un élément différent. Choisissez entre l’élément INPUT, SPAN ou DIV.",
			    cannotParseNonBoolValue: "igCheckboxEditor requiert une valeur différente. Une valeur booléenne doit être fournie.",
			    cannotSetNonBoolValue: "igCheckboxEditor requiert une valeur différente. Une valeur booléenne doit être fournie.",
			    maskEditorNoSuchMethod: "L’éditeur de masque ne prend pas cette méthode en charge.",
			    datePickerEditorNoSuchMethod: "L’éditeur de date ne prend pas cette méthode en charge.",
			    datePickerNoSuchMethodDropDownContainer: "L’éditeur de date ne prend pas cette méthode en charge. Utilisez 'getCalendar' à la place.",
			    buttonTypeIsDropDownOnly: "Le sélecteur de dates autorise uniquement les valeurs de la liste déroulante ou d’effacement pour l’option buttonType.",
			    dateEditorMinValue: "L’option MinValue ne peut pas être définie lors de l’exécution.",
			    dateEditorMaxValue: "L’option MaxValue ne peut pas être définie lors de l’exécution.",
			    cannotSetRuntime: "Cette option ne peut pas être définie lors de l’exécution",
			    invalidDate: "Date non valide",
			    maskMessage: 'Tous les postes requis doivent être remplis',
			    dateMessage: 'Une date valide doit être saisie',
			    centuryThresholdValidValues: "La propriété centuryThreshold doit être comprise entre 0 et 99. La valeur a été réinitialisée à son état par défaut.",
			    noListItemsNoButton: "Aucun compteur ni bouton de liste ne s’affiche car il n’y a pas d’éléments de liste."
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
		    noSuchWidget: "{featureName} n’a pas été reconnu. Vérifiez que cette fonctionnalité existe et que l’orthographe est correcte.",
			autoGenerateColumnsNoRecords: "L'option autoGenerateColumns est activée, mais il n'y a aucune archive dans la source de données permettant de déterminer les colonnes",
			optionChangeNotSupported: "{optionName} ne peut pas être modifié après l’initialisation. Ses valeurs doivent être définies pendant l’initialisation.",
			optionChangeNotScrollingGrid: "{optionName} ne peut pas être modifié après l’initialisation car votre grille initiale ne défile pas. Le re-rendering complet est nécessaire. Cette option doit être définie pendant l’initialisation.",
			widthChangeFromPixelsToPercentagesNotSupported: "Cannot change dynamically option width of the grid from pixels to percentages.",
			widthChangeFromPercentagesToPixelsNotSupported: "Cannot change dynamically option width of the grid from percentages to pixels.",
			noPrimaryKeyDefined: "Aucune clé principale n'est définie pour la grille. Pour utiliser les fonctions telles que Grid Editing, vous devez définir une clé principale.",
			indexOutOfRange: "L’index de ligne spécifié est hors plage. Un index de ligne compris entre {0} et {max} doit être fourni.",
			noSuchColumnDefined: "La clé de colonne spécifiée ne coïncide avec aucune des colonnes définies de la grille.",
			columnIndexOutOfRange: "L’index de colonne spécifié est hors plage. Un index de colonne compris entre {0} et {max} doit être fourni.",
			recordNotFound: "Impossible de trouver l’archive avec l’id {id} dans la vue des données. Vérifiez l’id utilisé pour la recherche et modifiez-le si nécessaire.",
			columnNotFound: "La colonne avec la clé {key} n’a pas pu être trouvée. Vérifiez la clé utilisée pour la recherche et modifiez-la si nécessaire.",
			colPrefix: "Colonne ",
			columnVirtualizationRequiresWidth: "Virtualisation / columnVirtualization est défini sur vrai, mais aucune largeur n'a pu être déduite pour les colonnes de la grille. Choisissez l'un des réglages a) largeur grille, b) defaultColumnWidth, c) définir largeur pour chaque colonne",
			virtualizationRequiresHeight: "Virtualisation est définie sur vrai, ce qui nécessite de définir également la hauteur de la grille.",
            colVirtualizationDenied: "columnVirtualization est applicable à la virtualisation fixe uniquement",
			noColumnsButAutoGenerateTrue: "L'option autoGenerateColumns est définie sur faux, mais aucune colonne du tableau n'est définie. Définissez l'option autoGenerateColumns sur vrai ou spécifiez des colonnes manuellement",
			noPrimaryKey: "Le widget igHierarchicalGrid nécessite la définition d'une clé principale.",
			templatingEnabledButNoTemplate: "L'option jQueryTemplating est définie sur vrai, mais aucun rowTemplate n'est défini.",
			expandTooltip: "Étendre la ligne",
			collapseTooltip: "Réduire la ligne",
			featureChooserTooltip: "Choix de fonctionnalité",
			movingNotAllowedOrIncompatible: "Impossible de déplacer la colonne demandée. La colonne n'a pas été trouvée ou le résultat n'était pas compatible avec la disposition des colonnes.",
			allColumnsHiddenOnInitialization: "Impossible de masquer toutes les colonnes de la grille. Veuillez définir au moins une des colonnes à afficher.",
			virtualizationNotSupportedWithAutoSizeCols: "La virtualisation nécessite une configuration de largeur de colonne différente de ’*’. La largeur de colonne doit être définie avec un nombre de pixels.",
			columnVirtualizationNotSupportedWithPercentageWidth: "La virtualisation de colonne n'est pas prise en charge lorsque la largeur de grille est définie en unités de pourcentage.",
			mixedWidthsNotSupported: "Les paramètres de largeur de colonne mélangés/partiels ne sont pas pris en charge. Les scénarios dans lesquels certaines largeurs de colonne sont définies en pourcentage tandis que d'autres sont définies en pixels (ou ne sont pas du tout définies) ne sont pas pris en charge.",
			multiRowLayoutColumnError: "La colonne avec la touche {key1} n’a pas pu être ajoutée à la mise en page à lignes multiples car son emplacement dans la mise en page est déjà occupé par la colonne avec la touche {key2}.",
			multiRowLayoutNotComplete: "La mise en page à lignes multiples est incomplète. La définition de colonne crée une mise en page contenant des espaces vides et qui ne peut pas s’afficher correctement.",
			multiRowLayoutMixedWidths: "Les largeurs mixtes (pourcentage et pixels) ne sont pas prises en charge pour la mise en page à lignes multiples. Configurez l’ensemble des largeurs de colonne soit en pixels, soit en pourcentage. ",
			scrollableGridAreaNotVisible: "Les zones d’en-tête et de pied de page fixes sont supérieures à la hauteur de grille disponible. La zone de défilement n’est pas visible. Configurez une plus grande hauteur de grille."
		}
	});

	$.ig.GridFiltering = $.ig.GridFiltering || {};

	$.extend($.ig.GridFiltering, {
		locale: {
			startsWithNullText: "Commence par...",
			endsWithNullText: "Finit par...",
			containsNullText: "Contient...",
			doesNotContainNullText: "Ne contient pas...",
			equalsNullText: "Est égal à...",
			doesNotEqualNullText: "Est différent de...",
			greaterThanNullText: "Supérieur à...",
			lessThanNullText: "Inférieur à...",
			greaterThanOrEqualToNullText: "Supérieur ou égal à...",
			lessThanOrEqualToNullText: "Inférieur ou égal à...",
			onNullText: "Le...",
			notOnNullText: "Pas le...",
			afterNullText: "Après",
			beforeNullText: "Avant",
			emptyNullText: "Vide",
			notEmptyNullText: "Pas vide",
			nullNullText: "Nul",
			notNullNullText: "Pas nul",
			startsWithLabel: "Commence par",
			endsWithLabel: "Finit par",
			containsLabel: "Contient",
			doesNotContainLabel: "Ne contient pas",
			equalsLabel: "Est égal à",
			doesNotEqualLabel: "Est différent de",
			greaterThanLabel: "Supérieur à",
			lessThanLabel: "Inférieur à",
			greaterThanOrEqualToLabel: "Supérieur ou égal à",
			lessThanOrEqualToLabel: "Inférieur ou égal à",
			trueLabel: "Vrai",
			falseLabel: "Faux",
			afterLabel: "Après",
			beforeLabel: "Avant",
			todayLabel: "Aujourd'hui",
			yesterdayLabel: "Hier",
			thisMonthLabel: "Ce mois",
			lastMonthLabel: "Mois précédent",
			nextMonthLabel: "Mois suivant",
			thisYearLabel: "Cette année",
			lastYearLabel: "Année précédente",
			nextYearLabel: "Année suivante",
			clearLabel: "Effacer le filtre",
			noFilterLabel: "Non",
			onLabel: "Le",
			notOnLabel: "Pas le",
			advancedButtonLabel: "Avancé",
			filterDialogCaptionLabel: "FILTRE AVANCÉ",
			filterDialogConditionLabel1: "Afficher les rangées concordantes ",
			filterDialogConditionLabel2: " avec les critères suivants",
			filterDialogConditionDropDownLabel: "Condition de filtre",
			filterDialogOkLabel: "Chercher",
			filterDialogCancelLabel: "Annuler",
			filterDialogAnyLabel: "N'IMPORTE LEQUEL",
			filterDialogAllLabel: "TOUS",
			filterDialogAddLabel: "Ajouter",
			filterDialogErrorLabel: "Nombre de filtres maximum excédé.",
			filterDialogCloseLabel: "Fermer le dialogue de filtre",
			filterSummaryTitleLabel: "Résultats de la recherche",
			filterSummaryTemplate: "${matches} rangées concordantes",
			filterDialogClearAllLabel: "Effacer tous",
			tooltipTemplate: "${condition} filtre appliqué",
			// M.H. 13 Oct. 2011 Fix for bug #91007
			featureChooserText: "Masquer le filtre",
			featureChooserTextHide: "Afficher le filtre",
			// M.H. 17 Oct. 2011 Fix for bug #91007
			featureChooserTextAdvancedFilter: "Filtre avancé",
			virtualizationSimpleFilteringNotAllowed: "Le filtrage simple (filtre ligne) n'est pas pris en compte si la virtualisation horizontale est activée. Placez le mode sur 'avancé' et/ou n'activez pas advancedModeEditorsVisible",
			multiRowLayoutSimpleFilteringNotAllowed: "La mise en page à lignes multiples nécessite un autre type de filtrage. Réglez le mode de filtrage sur 'advanced'",
			featureChooserNotReferenced: "Le script de choix de fonctionnalité n'est pas référencé. Pour éviter de recevoir ce message d'erreur, veuillez inclure le fichier ig.ui.grid.featurechooser.js ou utiliser le chargeur ou utiliser l'un des fichiers de script combiné.",
			conditionListLengthCannotBeZero: "Le tableau conditionList dans columnSettings est vide. Un tableau adapté pour conditionList doit être fourni.",
			conditionNotValidForColumnType: "La condition ’{0}’ n’est pas valide pour la configuration actuelle. Elle doit être remplacée par une condition adaptée au type de colonne {1}.",
			defaultConditionContainsInvalidCondition: "defaultExpression pour la colonne ’{0}’ contient une condition qui n’est pas autorisée. Remplacez-la par une condition adaptée au type de colonne {0}."
		}
	});

	$.ig.GridGroupBy = $.ig.GridGroupBy || {};

	$.extend($.ig.GridGroupBy, {
		locale: {
		    emptyGroupByAreaContent: "Glissez une colonne ici ou {0} pour créer des groupes",
			emptyGroupByAreaContentSelectColumns: "sélectionnez les colonnes",
			emptyGroupByAreaContentSelectColumnsCaption: "sélectionnez les colonnes",
			expandTooltip: "Etendre ligne groupée",
			collapseTooltip: "Réduire ligne groupée",
			removeButtonTooltip: "Supprimer colonne groupée",
			modalDialogCaptionButtonDesc: "Trier dans l'ordre croissant",
			modalDialogCaptionButtonAsc: "Trier dans l'ordre décroissant",
			modalDialogCaptionButtonUngroup: "Cliquez pour dégrouper",
			modalDialogGroupByButtonText: "Grouper par",
			modalDialogCaptionText: 'Ajouter à Grouper par',
			modalDialogDropDownLabel: 'Affichage :',
			modalDialogClearAllButtonLabel: 'Effacer tous',
			modalDialogRootLevelHierarchicalGrid: 'racine',
			modalDialogDropDownButtonCaption: "Afficher/Masquer",
			modalDialogButtonApplyText: 'Appliquer',
			modalDialogButtonCancelText: 'Annuler',
			fixedVirualizationNotSupported: 'La fonction GroupBy ne fonctionne pas avec la virtualisation verrouillée.',
			summaryRowTitle: 'Groupement de la ligne résumé'
		}
	});

	$.ig.GridHiding = $.ig.GridHiding || {};

	$.extend($.ig.GridHiding, {
		locale: {
			columnChooserDisplayText: "Choix de colonnes",
			hiddenColumnIndicatorTooltipText: "Colonnes masquées",
			columnHideText: "Masquer",
			columnChooserCaptionLabel: "Choix de colonnes",
			columnChooserCheckboxesHeader: "vue",
			columnChooserColumnsHeader: "colonne",
			columnChooserCloseButtonTooltip: "Fermer",
			hideColumnIconTooltip: "Masquer",
			featureChooserNotReferenced: "Le script de choix de fonctionnalité n'est pas référencé. Pour éviter de recevoir ce message d'erreur, veuillez inclure le fichier ig.ui.grille.choixfonctionnalité.js ou utiliser l'un des fichiers de script combiné.",
			columnChooserShowText: "Afficher",
			columnChooserHideText: "Masquer",
			columnChooserResetButtonLabel: "Réinitialiser",
			columnChooserButtonApplyText: 'Appliquer',
			columnChooserButtonCancelText: 'Annuler'
		}
	});

		$.ig.GridResizing = $.ig.GridResizing || {};

		$.extend($.ig.GridResizing, {
			locale: {
			    noSuchVisibleColumn: "Aucune colonne visible correspondant à la clé spécifiée n'a été trouvée. Vous pouvez uniquement redimensionner les colonnes visibles.",
			    resizingAndFixedVirtualizationNotSupported: "La fonction de redimensionnement ne fonctionne pas lorsque la virtualisation ou bien la virtualisation de colonne est activée avec le virtualizationMode verrouillé. Pour empêcher cette exception, veuillez définir virtualizationMode sur 'continuous' ou utiliser uniquement rowVirtualization."
			}
		});

	$.ig.GridPaging = $.ig.GridPaging || {};

	$.extend($.ig.GridPaging, {

		locale: {
			pageSizeDropDownLabel: "Afficher ",
			pageSizeDropDownTrailingLabel: "rangées",
			//pageSizeDropDownTemplate: "Afficher les rangées ${dropdown}",
			nextPageLabelText: "suiv",
			prevPageLabelText: "préc",
			firstPageLabelText: "",
			lastPageLabelText: "",
			currentPageDropDownLeadingLabel: "Pg",
			currentPageDropDownTrailingLabel: "de ${count}",
			//currentPageDropDownTemplate: "Pg ${dropdown} de ${count}",
			currentPageDropDownTooltip: "Choisir la page",
			pageSizeDropDownTooltip: "Choisir le nombre de rangées par page",
			pagerRecordsLabelTooltip: "Plage de rangées actuelle",
			prevPageTooltip: "Aller à la page précédente",
			nextPageTooltip: "Aller à la page suivante",
			firstPageTooltip: "Aller à la première page",
			lastPageTooltip: "Aller à la dernière page",
			pageTooltipFormat: "page ${index}",
			    pagerRecordsLabelTemplate: "${startRecord} - ${endRecord} de ${recordCount} rangées",
			    invalidPageIndex: "Index de page non valide - il doit être supérieur ou égal à 0 et doit être inférieur au nombre de pages"
		}
	});

    $.ig.GridSelection = $.ig.GridSelection || {};

    $.extend($.ig.GridSelection, {
        locale: {
            persistenceImpossible: "L'option primaryKey d'igGrid doit être définie pour pouvoir réaliser une sélection persistante entre les états. Pour éviter d'obtenir cette erreur, veuillez définir une clé primaire ou désactiver la persistance."
        }
    });

	$.ig.GridRowSelectors = $.ig.GridRowSelectors || {};

	$.extend($.ig.GridRowSelectors, {

		locale: {
			selectionNotLoaded: "igGridSelection n'est pas initialisé. Pour éviter de recevoir ce message d'erreur, veuillez activer la fonctionnalité Sélection pour la grille ou définir la propriété requireSelection de la fonction de Sélectionneurs de lignes sur faux.",
			columnVirtualizationEnabled: "igGridRowSelectors n'est pas pris en charge lorsque la virtualisation de colonne est activée. Pour éviter de recevoir ce message d'erreur, veuillez activer uniquement la virtualisation de ligne en réglant la propriété 'rowVirtualization' de la grille sur vrai ou en changeant le mode de virtualisation sur 'continuous'.",
			selectedRecordsText: "Vous avez sélectionné les archives ${checked}.",
			deselectedRecordsText: "Vous avez désélectionné les archives ${unchecked}.",
			selectAllText: "Sélectionner toutes les archives ${totalRecordsCount}",
			deselectAllText: "Désélectionner toutes les archives ${totalRecordsCount}",
			requireSelectionWithCheckboxes: "La sélection est requise lorsque les cases à cocher sont activées"
		}
	});

	$.ig.GridSorting = $.ig.GridSorting || {};

	$.extend($.ig.GridSorting, {
		locale: {
			sortedColumnTooltipFormat: 'trié ${direction}',
			unsortedColumnTooltip: 'Cliquez pour trier la colonne',
			ascending: "dans l'ordre croissant",
			descending: "dans l'ordre décroissant",
			modalDialogSortByButtonText: 'trier par',
			modalDialogResetButton: "réinitialiser",
			modalDialogCaptionButtonDesc: "Trier dans l'ordre décroissant",
			modalDialogCaptionButtonAsc: "Trier dans l'ordre croissant",
			modalDialogCaptionButtonUnsort: "Annuler le tri",
			featureChooserText: "Trier selon Multiple",
			modalDialogCaptionText: "Trier Multiple",
			modalDialogButtonApplyText: 'Appliquer',
			modalDialogButtonCancelText: 'Annuler',
			sortingHiddenColumnNotSupport: "Le tri de la colonne masquée n'est pas pris en charge",
			featureChooserSortAsc: 'Trier de A à Z',
			featureChooserSortDesc: 'Trier de Z à A'
			//modalDialogButtonSlideCaption: "Afficher/Masquer les colonnes triées"
		}
	});

	$.ig.GridSummaries = $.ig.GridSummaries || {};

	$.extend($.ig.GridSummaries, {
		locale: {
		    featureChooserText: "Masquer synthèse",
		    featureChooserTextHide: "Afficher synthèse",
			dialogButtonOKText: 'OK',
			dialogButtonCancelText: 'Annuler',
			emptyCellText: '',
			summariesHeaderButtonTooltip: 'Afficher/Masquer la synthèse',
			// M.H. 13 Oct. 2011 Fix for bug 91008
			defaultSummaryRowDisplayLabelCount: 'Nombre',
			defaultSummaryRowDisplayLabelMin: 'Min',
			defaultSummaryRowDisplayLabelMax: 'Max',
			defaultSummaryRowDisplayLabelSum: 'Total',
			defaultSummaryRowDisplayLabelAvg: 'Moy',
			defaultSummaryRowDisplayLabelCustom: 'Personnalisé',
			calculateSummaryColumnKeyNotSpecified: "Indiquez la clé de colonne pour calculer la synthèse",
			featureChooserNotReferenced: "Le script de choix de fonctionnalité n'est pas référencé. Pour éviter de recevoir ce message d'erreur, veuillez inclure le fichier g.ui.grid.featurechooser.js ou utiliser l'un des fichiers de script combiné."
		}
	});

	$.ig.GridUpdating = $.ig.GridUpdating || {};

	$.extend($.ig.GridUpdating, {
		locale: {
			doneLabel: 'Terminé',
			doneTooltip: "Arrêter l'édition et mettre à jour",
			cancelLabel: 'Annuler',
			cancelTooltip: "Arrêter l'édition et ne pas mettre à jour",
			addRowLabel: 'Ajouter une ligne',
			addRowTooltip: 'Cliquez pour ajouter une ligne',
			deleteRowLabel: 'Supprimer une ligne',
			deleteRowTooltip: 'Supprimer une ligne',
			igTextEditorException: 'Il est actuellement impossible d’effectuer la mise à jour des colonnes de la chaîne dans la grille. ui.igTextEditor doit d’abord être chargé.',
			igNumericEditorException: 'Il est actuellement impossible d’effectuer la mise à jour des colonnes numériques dans la grille. ui.igNumericEditor doit d’abord être chargé.',
			igCheckboxEditorException: 'Il est actuellement impossible d’effectuer la mise à jour des colonnes des cases à cocher dans la grille. ui.igCheckboxEditor doit d’abord être chargé.',
			igCurrencyEditorException: 'Il est actuellement impossible d’effectuer la mise à jour des colonnes numériques avec un format monétaire dans la grille. ui.igCurrencyEditor doit d’abord être chargé.',
			igPercentEditorException: 'Il est actuellement impossible d’effectuer la mise à jour des colonnes numériques avec un format pourcentage dans la grille. ui.igPercentEditor doit d’abord être chargé.',
			igDateEditorException: 'Il est actuellement impossible d’effectuer la mise à jour des colonnes de date dans la grille. ui.igDateEditor doit d’abord être chargé.',
			igDatePickerException: 'Il est actuellement impossible d’effectuer la mise à jour des colonnes de date dans la grille. ui.igDatePicker doit d’abord être chargé.',
			igComboException: 'Pour utiliser le type combo pour ui.igGrid, ui.igCombo doit être chargé',
			igRatingException: 'Pour utiliser le igRating comme éditeur pour ui.igGrid, ui.igRating doit être chargé',
			igValidatorException: 'Les options de validation définies dans igGridUpdating requièrent de charger ui.igValidator',
			editorTypeCannotBeDetermined: 'La mise à jour n’avait pas assez d’informations pour déterminer correctement le type d’éditeur à utiliser pour la colonne : ',
			noPrimaryKeyException: "Pour la prise en charge des opérations de mise à jour après la suppression d'une ligne, l'application doit définir la 'primaryKey' dans les options de igGrid.",
			hiddenColumnValidationException: "Impossible d'éditer une ligne contenant une colonne masquée avec la validation activée.",
			dataDirtyException: "La grille contient des transactions en cours qui peuvent affecter le rendu des données. Pour éviter l'exception, l'application peut activer l'option 'autoCommit' d'igGrid ou elle doit traiter l'événement 'dataDirty' d'igGridUpdating et retourner la mention faux. Tout en traitant cet événement, l'application peut aussi 'archiver()' les données dans igGrid.",
			recordOrPropertyNotFoundException: 'L’archive ou la propriété spécifiée est introuvable. Vérifiez vos critères de recherche et modifiez-les si nécessaire.',
			rowEditDialogCaptionLabel: 'Editer les données de ligne', 
            excelNavigationNotSupportedWithCurrentEditMode: "ExcelNavigation requiert une configuration différente. editMode doit être défini sur « cell » ou « row ».",
            columnNotFound: "La clé de colonne spécifiée n’a pas été trouvée dans l’ensemble des colonnes visibles ou l’index spécifié était hors plage.",
            rowOrColumnSpecifiedOutOfView: "L’édition de la ligne ou de la colonne spécifiée est actuellement impossible. Elle devrait s’afficher dans la page actuelle et dans le cadre de virtualisation.",
            editingInProgress: "Une ligne ou une cellule est actuellement en cours d’édition. Une autre procédure de mise à jour ne peut être effectuée avant que l’édition en cours ne soit terminée.",
            undefinedCellValue: '"Undefined" ne peut être défini comme valeur de cellule.',
            addChildTooltip: 'Ajouter une ligne enfant',
            multiRowGridNotSupportedWithCurrentEditMode: "Lorsque la mise en page à lignes multiples est activée pour la grille, seul le mode d’édition de dialogue est pris en charge."
		}
    });

    $.ig.ColumnMoving = $.ig.ColumnMoving || {};

    $.extend($.ig.ColumnMoving, {
        locale: {
            movingDialogButtonApplyText: 'Appliquer',
            movingDialogButtonCancelText: 'Annuler',
            movingDialogCaptionButtonDesc: 'Descendre',
            movingDialogCaptionButtonAsc: 'Monter',
            movingDialogCaptionText: 'Déplacer les colonnes',
            movingDialogDisplayText: 'Déplacer les colonnes',
            movingDialogDropTooltipText: "Déplacer ici",
            movingDialogCloseButtonTitle: 'Fermer la boîte de dialogue de déplacement',
            dropDownMoveLeftText: 'Déplacer vers la gauche',
            dropDownMoveRightText: 'Déplacer vers la droite',
            dropDownMoveFirstText: 'Déplacer en premier',
            dropDownMoveLastText: 'Déplacer en dernier',
            featureChooserNotReferenced: "Le script de choix de fonctionnalité n'est pas référencé. Pour éviter de recevoir ce message d'erreur, veuillez inclure le fichier ig.ui.grid.featurechooser.js ou utiliser le chargeur ou utiliser l'un des fichiers de script combiné.",
            movingToolTipMove: 'Déplacer',
            featureChooserSubmenuText: 'Déplacer'
        }
    });

    $.ig.ColumnFixing = $.ig.ColumnFixing || {};

    $.extend($.ig.ColumnFixing, {
        locale: {
            headerFixButtonText: 'Cliquer pour verrouiller cette colonne',
            headerUnfixButtonText: 'Cliquer pour déverrouiller cette colonne',
            featureChooserTextFixedColumn: 'Verrouiller colonne',
            featureChooserTextUnfixedColumn: 'Détacher colonne',
            groupByNotSupported: "igGridGroupBy n'est pas pris en charge avec ColumnFixing",
            virtualizationNotSupported: "L'option de virtualisation de la grille permet la virtualisation de ligne et de colonne. La virtualisation de colonne n'est pas prise en charge avec ColumnFixing. Veuillez définir l'option rowVirtualization de la grille sur vrai",
            columnVirtualizationNotSupported: "La virtualisation de colonne n'est pas prise en charge avec ColumnFixing",
            columnMovingNotSupported: "igGridColumnMoving n'est pas pris en charge avec ColumnFixing",
            hidingNotSupported: "igGridHiding n'est pas pris en charge avec ColumnFixing",
            hierarchicalGridNotSupported: "igHierarchicalGrid n'est pas pris en charge avec ColumnFixing",
            responsiveNotSupported: "igGridResponsive n'est pas pris en charge avec ColumnFixing",
            noGridWidthNotSupported: 'La fixation de colonne nécessite une configuration différente. La largeur de la grille doit être réglée en pourcentage ou avec des nombres en pixels.',
            gridHeightInPercentageNotSupported: 'La fixation de colonne nécessite une configuration différente. La hauteur de la grille doit être réglée en pixels.',
            defaultColumnWidthInPercentageNotSupported: "La largeur de colonne par défaut en pourcentage n'est pas prise en charge lors de l'utilisation de ColumnFixing",
            columnsWidthShouldBeSetInPixels: 'ColumnFixing requiert un paramètre de largeur de colonne différent. La largeur de colonne avec la clé {key} doit être définie avec un nombre de pixels.',
            unboundColumnsNotSupported: "ColumnFixing n'est pas pris en charge avec les colonnes indépendantes",
            excelNavigationNotSupportedWithCurrentEditMode: "Le mode de navigation Excel est pris en charge uniquement pour les modes Modification cellule et Modification ligne. Pour prévenir cette erreur, désactivez excelNavigationMode ou bien définissez editMode sur cellule ou ligne.",
            initialFixingNotApplied: "Le verrouillage initial n'a pas pu être appliqué sur les colonnes avec la clé : {0}. Raison : {1}", // {0} is placeholder for columnKey, {1} error message
            setOptionGridWidthException: 'Valeur incorrecte pour la largeur de grille facultative. Avec des colonnes fixes, la largeur de la zone visible de la ou des colonnes non fixes doit être supérieure ou égale à la valeur de minimalVisibleAreaWidth.',
            internalErrors: {
                none: 'Aucune erreur',
                notValidIdentifier: "Il n'existe aucune colonne avec l'identifiant spécifié",
                fixingRefused: 'Verrouillage refusé car il existe UNIQUEMENT une colonne non verrouillée visible',
                fixingRefusedMinVisibleAreaWidth: "Le verrouillage de colonne n'est pas autorisé, en raison de la largeur minimale de la zone visible des colonnes non verrouillées",
                alreadyHidden: 'Vous essayez de verrouiller/déverrouiller une colonne masquée',
                alreadyUnfixed: 'La colonne que vous essayez de déverrouiller est déjà déverrouillée',
                alreadyFixed: 'La colonne que vous essayez de verrouiller est déjà verrouillée',
				unfixingRefused: "Le déverrouillage est refusé car il n'existe qu'une seule colonne verrouillée visible et car il existe au moins une colonne verrouillée masquée.",
				targetNotFound: 'La colonne cible avec la clé {key} n’a pas pu être trouvée. Vérifiez la clé utilisée pour la recherche et modifiez-la si nécessaire.'
            }
        }
    });

    $.ig.GridAppendRowsOnDemand = $.ig.GridAppendRowsOnDemand || {};

    $.extend($.ig.GridAppendRowsOnDemand, {
    	locale: {
    		loadMoreDataButtonText: "Charger d'autres données",
    		appendRowsOnDemandRequiresHeight: "La fonction AppendRowsOnDemand requiert une hauteur",
    		groupByNotSupported: "igGridGroupBy n'est pas pris en charge avec AppendRowsOnDemand",
    		pagingNotSupported: "igGridPaging n'est pas pris en charge avec AppendRowsOnDemand",
    		cellMergingNotSupported: "igGridCellMerging n'est pas pris en charge avec AppendRowsOnDemand",
    		virtualizationNotSupported: "La virtualisation n'est pas prise en charge avec AppendRowsOnDemand"
    	}
    });


    $.ig.igGridResponsive = $.ig.igGridResponsive || {};

    $.extend($.ig.igGridResponsive, {
    	locale: {
    		fixedVirualizationNotSupported: "igGridResponsive n'est pas pris en charge avec la virtualisation verrouillée"
    	}
    });

    $.ig.igGridMultiColumnHeaders = $.ig.igGridMultiColumnHeaders || {};

    $.extend($.ig.igGridMultiColumnHeaders, {
    	locale: {
    		multiColumnHeadersNotSupportedWithColumnVirtualization: "La fonction d'en-têtes de colonnes multiples n'est pas prise en charge avec columnVirtualization"
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
			boldButtonTitle: 'Gras',
			italicButtonTitle: 'Italique',
			underlineButtonTitle: 'Souligné',
			strikethroughButtonTitle: 'Barré',
			increaseFontSizeButtonTitle: 'Agrandir la police',
			decreaseFontSizeButtonTitle: 'Réduire la police',
			alignTextLeftButtonTitle: 'Aligner le texte à gauche',
			alignTextRightButtonTitle: 'Aligner le texte à droite',
			alignTextCenterButtonTitle: 'Centrer',
			justifyButtonTitle: 'Justifier',
			bulletsButtonTitle: 'Puces',
			numberingButtonTitle: 'Numérotation',
			decreaseIndentButtonTitle: 'Diminuer le retrait',
			increaseIndentButtonTitle: 'Augmenter le retrait',
			insertPictureButtonTitle: 'Insérer une image',
			fontColorButtonTitle: 'Couleur de police',
			textHighlightButtonTitle: 'Couleur de surbrillance du texte',
			insertLinkButtonTitle: 'Insérer un lien hypertexte',
			insertTableButtonTitle: 'Tableau',
			addRowButtonTitle: 'Ajouter une ligne',
			removeRowButtonTitle: 'Supprimer une ligne',
			addColumnButtonTitle: 'Ajouter une colonne',
			removeColumnButtonTitle: 'Supprimer une colonne',
			inserHRButtonTitle: 'Insérer une règle horizontale',
			viewSourceButtonTitle: 'Afficher la source',
			cutButtonTitle: 'Couper',
			copyButtonTitle: 'Copier',
			pasteButtonTitle: 'Coller',
			undoButtonTitle: 'Annuler',
			redoButtonTitle: 'Rétablir',
			imageUrlDialogText: 'URL image :',
			imageAlternativeTextDialogText: 'Texte alternatif :',
			imageWidthDialogText: "Largeur de l'image :",
			imageHeihgtDialogText: "Hauteur de l'image :",
			linkNavigateToUrlDialogText: "Naviguer vers l'URL :",
			linkDisplayTextDialogText: 'Afficher le texte :',
			linkOpenInDialogText: 'Ouvrir dans :',
			linkTargetNewWindowDialogText: 'Nouvelle fenêtre',
			linkTargetSameWindowDialogText: 'Même fenêtre',
			linkTargetParentWindowDialogText: 'Fenêtre parent',
			linkTargetTopmostWindowDialogText: 'Fenêtre supérieure',
			applyButtonTitle: 'Appliquer',
			cancelButtonTitle: 'Annuler',
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
					{ text: "h1", value: "En-tête 1" },
					{ text: "h2", value: "En-tête 2" },
					{ text: "h3", value: "En-tête 3" },
					{ text: "h4", value: "En-tête 4" },
					{ text: "h5", value: "En-tête 5" },
					{ text: "h6", value: "En-tête 6" },
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
		    successMsg: "Réussite",
		    errorMsg: "Erreur",
		    warningMsg: "Avertissement"
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
                invalidDataSource: "La source de données spécifiée est nulle ou n'est pas prise en charge.",
                measureList: "Mesures",
                ok: "OK",
                cancel: "Annuler",
                addToMeasures: "Ajouter aux Mesures",
                addToFilters: "Ajouter aux Filtres",
                addToColumns: "Ajouter aux Colonnes",
                addToRows: "Ajouter aux Lignes"
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
                invalidBaseElement: " n'est pas pris en charge comme élément de base. Utiliser plutôt DIV.",
                catalog: "Catalogue",
                cube: "Cube",
                measureGroup: "Groupe de mesures",
                measureGroupAll: "(Tous)",
                rows: "Lignes",
                columns: "Colonnes",
                measures: "Mesures",
                filters: "Filtres",
                deferUpdate: "Différer la mise à jour",
                updateLayout: "Mettre à jour la disposition",
                selectAll: "Sélectionner tout"
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
                filtersHeader: "Placer les champs de filtre ici",
                measuresHeader: "Placer les éléments de données ici",
                rowsHeader: "Placer les champs de ligne ici",
                columnsHeader: "Placer les champs de colonne ici",
                disabledFiltersHeader: "Champs de filtre",
                disabledMeasuresHeader: "Éléments de données",
                disabledRowsHeader: "Champs de ligne",
                disabledColumnsHeader: "Champs de colonne",
                noSuchAxis: "Aucun axe de ce type"
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
			popoverOptionChangeNotSupported: "La modification de l'option suivante après l'initialisation de FinPopig n'est pas prise en charge :",
			popoverShowMethodWithoutTarget: "Le paramètre target de la fonction show est obligatoire lorsque l'option selectors est utilisée"
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
			    setOptionError: "Les modifications de temps d'exécution ne sont pas autorisées pour l'option suivante : "
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
		    errorPanels: 'Le nombre de panneaux ne doit pas être supérieur à deux.',
		    errorSettingOption: "Erreur lors du réglage de l'option."
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
		    renderDataError: "Échec de la récupération ou de l'analyse des données.",
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
			collapseButtonTitle: 'Réduire',
			expandButtonTitle: 'Etendre'
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
			    invalidArgumentType: "Type d'argument fourni invalide.",
			    errorOnRequest: "Une erreur s'est produite pendant la récupération des données : ",
			    noDataSourceUrl: 'La commande igTree requiert une dataSourceUrl pour initier une requête de données pour cette URL.',
			    incorrectPath: 'Un nœud a été trouvé sur le chemin fourni : ',
			    incorrectNodeObject: "L'argument fourni n'est pas un élément de nœud jQuery.",
			    setOptionError: "Les modifications de temps d'exécution ne sont pas autorisées pour l'option suivante : ",
			    moveTo: '<strong>Déplacer vers</strong> {0}',
			    moveBetween: '<strong>Déplacer entre</strong> {0} et {1}',
			    moveAfter: '<strong>Déplacer après</strong> {0}',
			    moveBefore: '<strong>Déplacer avant</strong> {0}',
			    copyTo: '<strong>Copier vers</strong> {0}',
			    copyBetween: '<strong>Copier entre</strong> {0} et {1}',
			    copyAfter: '<strong>Copier après</strong> {0}',
			    copyBefore: '<strong>Copier avant</strong> {0}',
			    and: 'et'
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
			    labelUploadButton: "Charger le fichier",
			    labelAddButton: "Ajouter",
			    labelClearAllButton: "Effacer chargés",
			    // M.H. 13 May 2011 - fix bug 75042
			    labelSummaryTemplate: "{0} de {1} chargés",
			    labelSummaryProgressBarTemplate: "{0}/{1}",
			    labelShowDetails: "Afficher Détails",
			    labelHideDetails: "Masquer Détails",
			    labelSummaryProgressButtonCancel: "Annuler",
			    // M.H. 1 June 2011 Fix bug #77532
			    labelSummaryProgressButtonContinue: "Charger",
			    labelSummaryProgressButtonDone: "Terminé",
			    labelProgressBarFileNameContinue: "...",

			    //error messages
			    errorMessageFileSizeExceeded: "Taille de fichier maxi excédée.",
			    errorMessageGetFileStatus: "Impossible d'obtenir votre statut de fichier actuel ! Connexion probablement perdue.",
			    errorMessageCancelUpload: "Impossible d'envoyer au serveur l'ordre d'annuler le chargement ! Connexion probablement perdue.",
			    errorMessageNoSuchFile: "Impossible de trouver le fichier demandé. Fichier probablement trop gros.",
			    errorMessageOther: "Erreur interne lors du chargement du fichier. Code d'erreur : {0}.",
			    errorMessageValidatingFileExtension: "Echec validation de l'extension du fichier.",
			    errorMessageAJAXRequestFileSize: "Erreur AJAX lors de la détermination de la taille du fichier.",
			    errorMessageMaxUploadedFiles: "Nombre maxi de fichiers chargés excédé.",
			    errorMessageMaxSimultaneousFiles: "La valeur igTree est incorrecte. Elle doit être supérieure ou égale à 0.",
			    errorMessageTryToRemoveNonExistingFile: "Vous essayez de supprimer un fichier qui n'existe pas avec l'id {0}.",
			    errorMessageTryToStartNonExistingFile: "Vous essayez de démarrer un fichier qui n'existe pas avec l'id {0}.",
			    errorMessageDropMultipleFilesWhenSingleModel: "Vous ne pouvez pas déposer plus d’un fichier en mode simple",

			    // M.H. 12 May 2011 - fix bug 74763: add title to all buttons
			    // title attributes            
			    titleUploadFileButtonInit: "Charger le fichier",
			    titleAddFileButton: "Ajouter",
			    titleCancelUploadButton: "Annuler",
			    // M.H. 1 June 2011 Fix bug #77532
			    titleSummaryProgressButtonContinue: "Charger",
			    titleClearUploaded: "Effacer chargés",
			    titleShowDetailsButton: "Afficher Détails",
			    titleHideDetailsButton: "Masquer Détails",
			    titleSummaryProgressButtonCancel: "Annuler",
			    titleSummaryProgressButtonDone: "Terminé",
			    // M.H. 1 June 2011 Fix bug #77532
			    titleSingleUploadButtonContinue: "Charger",
			    titleClearAllButton: "Effacer chargés"
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
			    defaultMessage: 'Veuillez réparer ce champ',
			    selectMessage: 'Veuillez sélectionner une valeur',
			    rangeSelectMessage: 'Veuillez sélectionner au maximum {0} et au minimum {1} éléments',
			    minSelectMessage: 'Veuillez sélectionner au moins {0} éléments',
			    maxSelectMessage: 'Veuillez sélectionner au maximum {0} éléments',
			    rangeLengthMessage: 'Veuillez entrer une valeur contenant {0} à {1} caractères',
			    minLengthMessage: 'Veuillez entrer au moins {0} caractères',
			    maxLengthMessage: 'Veuillez sélectionner au maximum {0} caractères',
			    requiredMessage: 'Ce champ est obligatoire',
			    patternMessage: 'La valeur entrée ne correspond pas au schéma requis',
			    maskMessage: 'Veuillez remplir tous les postes requis',
			    dateFieldsMessage: 'Veuillez entrer des valeurs dans les champs de dates',
			    invalidDayMessage: 'Jour du mois invalide. Veuillez entrer un jour correct',
			    dateMessage: 'Veuillez entrer une date valide',
			    numberMessage: 'Veuillez entrer un nombre valide',
                rangeValueMessage: 'Veuillez entrer une valeur entre {0} et {1}',
		        minValueMessage: 'Veuillez entrer une valeur supérieure ou égale à {0}',
		        maxValueMessage: 'Veuillez entrer une valeur inférieure ou égale à {0}',
		        emailMessage: 'Une adresse e-mail valide doit être saisie',
		        equalToMessage: 'Les deux valeurs ne correspondent pas',
		        optionalString: '(facultatif)'
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
			    liveStream: "Vidéo en direct",
			    live: "En direct",
			    paused: "Pause",
			    playing: "Lecture en cours",
			    play: 'Lecture',
			    volume: "Volume",
			    unsupportedVideoSource: "Les sources de la vidéo actuelles ne contiennent pas un format pris en charge par votre navigateur.",
			    missingVideoSource: "Source vidéo incompatible.",
			    progressLabelLongFormat: "$currentTime$ / $duration$",
			    progressLabelShortFormat: "$currentTime$",
			    enterFullscreen: "Plein écran",
			    exitFullscreen: "Quitter plein écran",
			    skipTo: "PASSER A",
			    unsupportedBrowser: "Le navigateur actuel ne prend pas en charge les vidéos HTML5. <br/>Essayez la mise à niveau vers l'une des versions suivantes :",
			    currentBrowser: "Navigateur actuel : {0}",
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
			    buffering: 'Mise en mémoire tampon...',
			    adMessage: 'Publicité : La vidéo reprendra dans $duration$ secondes.',
			    adMessageLong: 'Publicité : La vidéo reprendra dans $duration$.',
			    adMessageNoDuration: 'Publicité : La vidéo reprendra après la publicité.',
			    adNewWindowTip: 'Publicité : Cliquez pour ouvrir le contenu de la publicité dans une nouvelle fenêtre.',
			    nonDivException: 'Le lecteur vidéo Infragistics HTML5 peut uniquement être instancié sur une balise DIV.',
			    relatedVideos: 'VIDÉOS RELIÉES',
			    replayButton: 'Rejouer',
			    replayTooltip: 'Cliquer pour rejouer la dernière vidéo.'
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
	        zoombarTargetNotSpecified: "igZoombar a besoin d'une cible valide à laquelle s'attacher.",
	        zoombarTypeNotSupported: "Le type de widget auquel la barre de zoom tente de s'attacher n'est pas pris en charge.",
	        optionChangeNotSupported: "La modification de l'option suivante après la création de igZoombar n'est pas prise en charge :"
		}
	});

}
})(jQuery);
/*!@license
* Infragistics.Web.ClientUI common utilities localization resources 16.1.20161.2052
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
			    unsupportedBrowser: "Le navigateur actuel ne prend pas en charge l'élément canvas HTML5. <br/>Essayez la mise à niveau vers l'une des versions suivantes :",
			    currentBrowser: "Navigateur actuel : {0}",
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

