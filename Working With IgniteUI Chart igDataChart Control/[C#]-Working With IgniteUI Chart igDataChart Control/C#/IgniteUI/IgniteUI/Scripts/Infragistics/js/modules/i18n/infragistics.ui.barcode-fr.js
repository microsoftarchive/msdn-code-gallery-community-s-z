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