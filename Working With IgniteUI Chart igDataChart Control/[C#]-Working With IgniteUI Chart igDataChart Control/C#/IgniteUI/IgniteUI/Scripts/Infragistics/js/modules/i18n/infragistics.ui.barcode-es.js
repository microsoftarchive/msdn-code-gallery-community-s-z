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
		    aILength: "El identificador de aplicaciones (AI) debe tener al menos 2 dígitos.",
		    badFormedUCCValue: "Los datos del código de barras UCC no están bien formados. Deben tener la estructura (AI)GTIN.",
		    code39_NonNumericError: "El carácter '{0}' no es válido para los datos CODE39. Los caracteres válidos son: {1}",
		    countryError: "Error al convertir el código de país. Debe ser un valor numérico.",
		    emptyValueMsg: "El valor de datos está vacío.",
		    encodingError: "Error de conversión. Consulte la documentación para conocer cuáles son los valores válidos para las propiedades.",
		    errorMessageText: "Valor no válido. Consulte la documentación para conocer cuál es la estructura de datos válida de los códigos de barras.",
		    gS1ExMaxAlphanumNumber: "La familia del GS1 DataBar ampliado puede codificar hasta 41 caracteres alfanuméricos.",
		    gS1ExMaxNumericNumber: "La familia del GS1 DataBar ampliado puede codificar hasta 74 caracteres numéricos.",
		    gS1Length: "El código de barras GS1 DataBar se utiliza para los códigos de barras GTIN 8, 12, 13, 14 y su longitud debe ser 7, 11, 12 o 13. El último dígito se reserva para una suma de comprobación.",
		    gS1LimitedFirstChar: "El código del GS1 DataBar limitado debe tener 0 o 1 como primer dígito. Cuando se codifican estructuras de datos GTIN-14 con un valor de indicador superior a 1, es preciso utilizar el tipo de código de barras Omnidirectional, Stacked, Stacked Omnidirectional o Truncated.",
		    i25Length: "El código de barras Interleaved2of5 debe tener un número par de dígitos. Si se trata de un número impar, puede poner un 0 delante.",
		    intelligentMailLength: "La longitud del valor de datos en el código de barras Intelligent Mail debe ser de 20, 25, 29 o 31 caracteres: código de rastreo de 20 dígitos (2 para el identificador del código de barras, 3 para el identificador del tipo de servicio, 6 o 9 para el identificador de mailer y 9 o 6 para el número de serie) y 0, 5, 9 o 11 símbolos de código postal.",
		    intelligentMailSecondDigit: "El segundo dígito debe encontrarse en el intervalo comprendido entre 0 y 4.",
		    invalidAI: "Cadenas no válidas en el elemento del identificador de aplicaciones. Asegúrese de que la cadena del identificador de aplicaciones de los datos esté bien formada.",
		    invalidCharacter: "El carácter '{0}'no es válido para el tipo de código de barras actual. Los caracteres válidos son: {1}",
		    invalidDimension: "Las dimensiones del código de barras no pueden determinarse porque se ha producido una combinación incorrecta de los valores de las propiedades Stretch, BarsFillMode y XDimension.",
		    invalidHeight: "Las líneas de cuadrícula del código de barras (número {0}) no puede adaptarse a esta altura ({1} píxeles).",
		    invalidLength: "El valor de datos del código de barras debe tener un número {0} de dígitos.",
		    invalidPostalCode: "Valor PostalCode no válido: El modo 2 codifica códigos postales de hasta 9 dígitos (código postal de EE.UU.), mientras que el modo 3 codifica códigos alfanuméricos de hasta 6 caracteres.",
		    invalidPropertyValue: "El valor de propiedad {0} debe encontrarse en un intervalo comprendido entre {1} y {2}.",
		    invalidVersion: "El número SizeVersion no genera celdas suficientes para codificar los datos con el modo de codificación y el nivel de corrección de errores actuales.",
		    invalidWidth: "Las columnas de cuadrícula del código de barras (número {0}) no puede adaptarse a esta anchura ({1} píxeles). Chequear el valor de la propiedad XDimension y/o el de WidthToHeightRatio.",
		    invalidXDimensionValue: "El valor XDimension de debe encontrarse en un intervalo comprendido entre {0} y {1} para el tipo de código de barras actual.",
		    maxLength: "La longitud {0} del texto supera el máximo codificable para el tipo actual de códigos de barras. Puede codificar como máximo {1} caracteres.",
		    notSupportedEncoding: "La codificación correspondiente bajo {0} {1} no se admite.",
		    pDF417InvalidRowsColumnsCombination: "Las palabras de código (corrección de datos y errores) son más de las que pueden codificarse en símbolos con una matriz {0}x{1}.",
		    primaryMessageError: "No se puede extraer el mensaje principal del valor de datos. Consulte la documentación para conocer la estructura.",
		    serviceClassError: "Error al convertir la clase de servicio. Debe ser un valor numérico.",
		    smallSize: "No es posible ajustar la cuadrícula en Size({0}, {1}) con la configuración Stretch definida.",
		    unencodableCharacter: "El carácter '{0}' no puede codificarse.",
		    uPCEFirstDigit: "De manera predeterminada, el primer dígito UPCE debe ser siempre cero.",
		    warningString: "Advertencia Barcode: ",
		    wrongCompactionMode: "El mensaje de datos no puede compactarse con el modo {0}.",
		    notLoadedEncoding: "La codificación {0} no se ha cargado."
		}
	};
}
})(jQuery);