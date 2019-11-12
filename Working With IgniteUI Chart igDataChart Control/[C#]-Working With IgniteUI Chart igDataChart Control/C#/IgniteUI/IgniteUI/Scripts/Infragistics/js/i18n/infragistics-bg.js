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
			    invalidDataSource: "Подаденият източник на данни е невалиден.",
			    unknownDataSource: "Типът на източника на данни не може да бъде определен. Моля дефинирайте дали данните са в JSON или XML формат.",
			    errorParsingArrays: "Грешка при парсирането на масива от данни и при прилагането на дефинираната schema: ",
			    errorParsingJson: "Грешка при парсирането на JSON обекта от данни и при прилагането на дефинираната schema: ",
			    errorParsingXml: "Грешка при парсирането на XML обекта от данни и при прилагането на дефинираната schema: ",
			    errorParsingHtmlTable: "Грешка при извличането на данни от HTML таблицата и при прилагането на дефинираната schema: ",
			    errorExpectedTbodyParameter: "Очакваният параметър трябва да е от тип table или tbody.",
			    errorTableWithIdNotFound: "Не е намерена HTML таблица с ID: ",
			    errorParsingHtmlTableNoSchema: "Грешка при парсиране на табличния DOM: ",
			    errorParsingJsonNoSchema: "Грешка при парсиране на JSON string: ",
			    errorParsingXmlNoSchema: "Грешка при парсиране на XML string: ",
			    errorXmlSourceWithoutSchema: "Подаденият източник на данни е XML документ, но няма дефинирана schema за данните ($.IgDataSchema).",
			    errorUnrecognizedFilterCondition: "Неразпознато условие за филтриране: ",
			    errorRemoteRequest: "Неуспешно завършено външно поискване на данни: ",
			    errorSchemaMismatch: "Входните данни не отговарят на подадената schema; съответното поле не може да бъде попълнено успешно: ",
			    errorSchemaFieldCountMismatch: "Входните данни не отговарят на подадената схема като брой полета. ",
			    errorUnrecognizedResponseType: "Типът на доставените данни не е деклариран правилно или не е било възможно типът да бъде определен автоматично. Моля попълнете settings.responseDataType и/или settings.responseContentType.",
			    hierarchicalTablesNotSupported: "Таблици не се поддържат от HierarchicalSchema",
			    cannotBuildTemplate: "Шаблонът не може да бъде построен. Източника на данни няма записи и не са дефинирани колони.",
			    unrecognizedCondition: "Неразпознато условие за филтриране: ",
			    fieldMismatch: "Изразът съдържа невалидно поле или условие за филтриране: ",
			    noSortingFields: "Моля задайте поне едно поле при извикване на sort().",
			    filteringNoSchema: "Нямате зададени schema / fields. Нужно е да зададете schema с field дефиниция и типове, за да можете да филтрирате източника на данни.",
			    noSaveChanges: "Запазването на промените беше неуспешно. Сървърът не върна обект Success или върна Success:false.",
			    errorUnexpectedCustomFilterFunction: "Беше подадена неочаквана стойност за създадената от потребителя функция за филтриране Очаква се функция или низ."
		    }
	    });

    }
})(jQuery);

/*
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
			    seriesName: "трябва да попълните series name в зададените от вас опции.",
			    axisName: "трябва да попълните axis name в зададените от вас опции.",
			    invalidLabelBinding: "Не съществува такава стойност, с която да се обвържат етикетите.",
			    invalidSeriesAxisCombination: "Невалидна комбинация от серия ос и тип: ",
			    close: "Затвори",
			    overview: "Преглед",
			    zoomOut: "Отдалечи",
			    zoomIn: "Увеличи",
			    resetZoom: "Рестартирай увеличението",
			    seriesUnsupportedOption: "Конкретния тип серия не поддържа опцията: ",
			    seriesTypeNotLoaded: "JavaScript файла, който съдържа заявената тип серия не е бил зареден или типа серия не е валиден: ",
			    axisTypeNotLoaded: "JavaScript файла, който съдържа заявената тип ос не е бил зареден или типа ос не е валиден: ",
			    axisUnsupportedOption: "Конкретния тип ос не поддържа опцията: "
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
			    undefinedArgument: 'Грешка при опит да се вземе стойността на следното свойство от източника на данни: '
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
			    aILength: "AI трябва да се състои от поне 2 цифри.",
			    badFormedUCCValue: "Данните за UCC баркода не са зададени коректно. Трябва да имат следния формат: (AI)GTIN.",
			    code39_NonNumericError: "Символът '{0}' не е валиден за CODE39 данни. Валидните символи са: {1}",
			    countryError: "Грешка при конвертирането на кода на страната. Трябва да е числова стойност.",
			    emptyValueMsg: "Стойността на Data е празна.",
			    encodingError: "Грешка при конвертирането. Направете справка в документацията за валидните стойности на свойствата.",
			    errorMessageText: "Невалидна стойност! Направете справка в документацията за валидната структура на данните за баркода.",
			    gS1ExMaxAlphanumNumber: "GS1 DataBar Expanded семейството може да кодира до 41 буквено-цифрови знаци.",
			    gS1ExMaxNumericNumber: "GS1 DataBar Expanded семейството може да кодира до 74 цифрови знаци.",
			    gS1Length: "Data свойството на GS1 DataBar се използва за GTIN - 8, 12, 13, 14 и дължината му трябва да бъде 7, 11, 12 or 13. Последната цифра е резервирана за контролна сума.",
			    gS1LimitedFirstChar: "Първата цифра на GS1 DataBar Limited трябва да е 0 или 1. При кодиране на GTIN-14 Data Structures със стойност на Indicator по-голяма от 1, трябва да се използва един от следните типове баркод: Omnidirectional, Stacked, Stacked Omnidirectional или Truncated.",
			    i25Length: "Interleaved2of5 баркодът трябва да има четен брой цифри. Може да се сложи 0 в началото, ако броят им е нечетен.",
			    intelligentMailLength: "Дължината на данните на Intelligent Mail баркода трябва да е 20, 25, 29 или 31 знака - 20 цифри за кода за проследяване (2 за баркод идентификатор, 3 за идентификатор на типа на услугата, 6 или 9 за идентификатор на системата за изпращане и 9 или 6 за сериен номер) и 0, 5, 9 или 11 пощенски код символи.",
			    intelligentMailSecondDigit: "Втората цифра трябва да е между 0 и 4 включително.",
			    invalidAI: "Невалидни низове за елементите на Application Identifier. Проверете дали низът от данни е правилно форматиран.",
			    invalidCharacter: "Знакът '{0}' е невалиден за текущия тип баркод. Валидните символи са: {1}",
			    invalidDimension: "Размерите на баркода не могат да бъдат определени поради невалидна комбинация на стойностите на Stretch, BarsFillMode и XDimension свойствата.",
			    invalidHeight: "Даденият брой редове на баркод мрежата ({0}) не могат да се поместят в дадената височина ({1} пиксели).",
			    invalidLength: "В Data на баркода трябва да има {0} цифри.",
			    invalidPostalCode: "Невалидна стойност на PostalCode - в режим 2 могат да бъдат кодирани пощенски кодове с максимум 9 цифри (пощенски кодове от САЩ), докато в режим 3 могат да се кодират максимум 6 буквено-цифрови знака.",
			    invalidPropertyValue: "Стойността на свойството {0} трябва да е между {1} и {2} включително.",
			    invalidVersion: "Числото, зададено в SizeVersion не позволява да се генерират достатъчно клетки, за да се кодират данните с текущия режим на кодиране и ниво на корекция на грешките.",
			    invalidWidth: "Даденият брой колони на баркод мрежата ({0}) не могат да се поместят в дадената широчина ({1} пиксели). Провери стойността на свойствата XDimension и/или WidthToHeightRatio.",
			    invalidXDimensionValue: "Стойността на XDimension трябва да е от {0} до {1} за текущия тип баркод.",
			    maxLength: "Дължината {0} на текста надхвърля максималното допустимо за кодиране при текущия тип баркод. Може да кодира мсксимум {1} знака.",
			    notSupportedEncoding: "Кодирането съответстващо на {0} {1} не се поддържа.",
			    pDF417InvalidRowsColumnsCombination: "Думите за кодиране (данни и корекция на грешки) надвишават допустимото количество, което може да бъде кодирано със символна матрица {0}x{1}.",
			    primaryMessageError: "Невъзможно е да се извлече основното съобщение от стойността в Data. Направете справка в документацията за правилната структура.",
			    serviceClassError: "Грешка при конвертиране на сървис класа. Трябва да е числова стойност.",
			    smallSize: "Невъзможно е да се вмести мрежа със Size({0}, {1}) при зададените Stretch настройки.",
			    unencodableCharacter: "Знакът '{0}' не може да бъде кодиран.",
			    uPCEFirstDigit: "Първата UPCE цифра трябва винаги да бъде нула според спецификацията.",
			    warningString: "Баркод предупреждение: ",
			    wrongCompactionMode: "Съобщението в Data не може да бъде уплътнено в режим {0}.",
                notLoadedEncoding: "Кодирането {0} не е заредено."
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
		        noMatchFoundText: 'Няма намерени резултати',
		        dropDownButtonTitle: 'Покажи падащото меню',
		        clearButtonTitle: 'Изчисти стойността',
		        placeHolder: 'изберете...',
		        notSuported: 'Операцията не се поддържа.',
		        errorNoSupportedTextsType: "Необходим е различен филтър текст. Подайте стойност, която е или низ или масив от низове.",
		        errorUnrecognizedHighlightMatchesMode: 'Необходим е друг highlight matches режим.  Изберете стойност измежду "multi", "contains", "startsWith", "full" и "null".',
		        errorIncorrectGroupingKey: "Ключът за групиране не е правилен."
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
			    closeButtonTitle: "Затвори",
			    minimizeButtonTitle: "Минимизирай",
			    maximizeButtonTitle: "Максимизирай",
			    pinButtonTitle: "Закачи",
			    unpinButtonTitle: "Откачи",
			    restoreButtonTitle: "Възстанови"
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
                invalidBaseElement: " не се поддържа като основен елемент. Използвай DIV вместо това."
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
			    spinUpperTitle: 'Инкрементирай',
			    spinLowerTitle: 'Декрементирай',
			    buttonTitle: 'Покажи списъка',
			    clearTitle: 'Изчисти стойността',
			    ariaTextEditorFieldLabel: 'Текстов редактор',
			    ariaNumericEditorFieldLabel: 'Числов редактор',
			    ariaCurrencyEditorFieldLabel: 'Редактор на валута',
			    ariaPercentEditorFieldLabel: 'Редактор на проценти',
			    ariaMaskEditorFieldLabel: 'Редактор на маски',
			    ariaDateEditorFieldLabel: 'Редактор на дати',
			    ariaDatePickerFieldLabel: 'Извличане на дата',
			    ariaSpinUpButton: 'Завъртане нагоре',
			    ariaSpinDownButton: 'Завъртане надолу',
			    ariaDropDownButton: 'Падащо меню',
			    ariaClearButton: 'Изчистване',
			    ariaCalendarButton: 'Календар',
			    datePickerButtonTitle: 'Покажи календара',
			    updateModeUnsupportedValue: 'Опцията updateMode поддържа две възможни стойности - "onChange" и "immediate"',
			    updateModeNotSupported: 'Свойството updateMode поддържа само свойството "onchange" на igMaskEditor, igDateEditor и раширенията igDatePicker.',
			    renderErrMsg: "Базовият редактор не може да бъде инстанцииран веднага. Опитайте с текстов, числов, едитор на дни или друг едитор.",
			    multilineErrMsg: 'textArea изисква различна конфигурация. textMode трябва да бъде зададен като "multiline".',
			    targetNotSupported: "Този целеви елемент не е поддържан.",
			    placeHolderNotSupported: "Този елемент контейнер не е поддържан от Вашия браузър.",
			    allowedValuesMsg: "Изберете стойност от падащото меню",
			    maxLengthErrMsg: "Входните данни са твърде дълги, за това бяха съкратени до {0} символа.",
			    maxLengthWarningMsg: "Входните данни за това поле достигнаха максимум дължината от {0}.",
			    minLengthErrMsg: "Трябва да бъдат въведени поне {0} знака.",
			    maxValErrMsg: "Входните данни достигнаха максималната стойност от {0} за това поле.",
			    minValErrMsg: "Входните данни достигнаха минималната стойност от {0} за това поле.",
			    maxValExceedRevertErrMsg: "Входните данни надхвърлиха максималната стойност от {0} и бяха върнат към предишната им стойност.",
			    minValExceedRevertErrMsg: "Входните данни бяха по-малки от минималната стойност от {0} и бяха върнати към предишната им стойност.",
			    maxValExceedSetErrMsg: "Entry exceeded the maximum value of {0} and was set to the maximum value",
			    minValExceedSetErrMsg: "Entry exceeded the minimum value of {0} and was set to the minimum value",
			    maxValExceededWrappedAroundErrMsg: "Входните данни надхвърлиха максималната стойност от {0} и бяха върнати към най-ниската им позволена такава.",
			    minValExceededWrappedAroundErrMsg: "Входните данни бяха по-малки от минималната стойност от {0} и бяха върнати към предишната им стойност.",
			    btnValueNotSupported: 'Необходима е различна стойност на бутона. Изберете една от следните стойности: "dropdown", "clear" или "spin".',
			    scientificFormatErrMsg: 'Необходим е различен scientificFormat. Изберете една от следните стойности: "E", "e", "E+" или "e+".',
			    spinDeltaIsOfTypeNumber: "Необходим е различен тип на spinDelta. Трябва да бъде въведено положително число.",
			    spinDeltaCouldntBeNegative: "Опцията spinDelta не може да бъде негативна. Трябва да бъде въведено положително число.",
			    spinDeltaContainsExceedsMaxDecimals: "Максимъмът позволени части на spinDelta е {0}. Променете MaxDecimals или намалете стойността.",
			    spinDeltaIncorrectFloatingPoint: 'spinDelta с плаваща запетая изисква различна конфигурация. Настройте dataMode на редактора, на "double" или "float", или  настройте spinDelta на integer.',
			    notEditableOptionByInit: "Тази опция не може да бъде променяна след инициализиране. Стойността ѝ да бъде настроена по време на инициализацията.",
			    numericEditorNoSuchMethod: "Числовият едитор не поддържа този метод.",
			    numericEditorNoSuchOption: "Числовият редактор не поддържа тази опция.",
			    displayFactorIsOfTypeNumber: "displayFactor изисква различна стойност. Стойността му трябва да бъде 1 или 100. ",
			    displayFactorAllowedValue: "displayFactor изисква различна стойност. Стойността му трябва да бъде 1 или 100. ",
			    instantiateCheckBoxErrMsg: "igCheckboxEditor изисква различен елемент. Използвайте  INPUT, SPAN или DIV елемент.",
			    cannotParseNonBoolValue: "igCheckboxEditor изисква различен елемент. Трябва да бъде подадена булева стойност.",
			    cannotSetNonBoolValue: "igCheckboxEditor изисква различен елемент. Трябва да бъде подадена булева стойност.",
			    maskEditorNoSuchMethod: "Редакторът на маски не поддържа този метод.",
			    datePickerEditorNoSuchMethod: "Редакторът на дати не поддържа този метод.",
			    datePickerNoSuchMethodDropDownContainer: "Редакторът на дати не поддържа този метод. Вместо него използвайте 'getCalendar'.",
			    buttonTypeIsDropDownOnly: "Datepicker позволява само dropdown и чисти стойности за опцията buttonType.",
			    dateEditorMinValue: "Опцията MinValue не може да бъде настроена по време на изпълнение.",
			    dateEditorMaxValue: "Опцията MaxValue не може да бъде настроена по време на изпълнение.",
			    cannotSetRuntime: "Тази опцията не може да бъде настроена по време на изпълнение.",
			    invalidDate: "Невалидна дата",
			    maskMessage: 'Всички задължителни позиции трябва да бъдат попълнени.',
			    dateMessage: 'Трябва да бъде въведена валидна дата.',
			    centuryThresholdValidValues: "Свойството centuryThreshold трябва да е между 0 и 99. Стойността беше върната към началната си стойност. ",
			    noListItemsNoButton: "Брояча или падащия бутон са рендирани понеже няма listitems."
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
            noSuchWidget: "{featureName} не е разпознато. Уверете се, че съществува такава функция, и че е правилно изписана.",
            autoGenerateColumnsNoRecords: "autoGenerateColumns е включено, но няма записи в източника на данни. Заредете източник на данни със записи за да може да бъдат определени колоните.",
            optionChangeNotSupported: "{optionName} не може да бъде променяно след инициализиране. Трябва да бъде настроено по време на инициализацията.",
            optionChangeNotScrollingGrid: "{optionName} не може да бъде променяно след инициализация защото първоначално в мрежата не е възможно скролиране и има необходимост от пълно повторно рендиране. Тази опция трябва да бъде настроена по време на инициализацията.",
            widthChangeFromPixelsToPercentagesNotSupported: "Cannot change dynamically option width of the grid from pixels to percentages.",
            widthChangeFromPercentagesToPixelsNotSupported: "Cannot change dynamically option width of the grid from percentages to pixels.",
            noPrimaryKeyDefined: "Няма дефиниран primaryKey за мрежата. primaryKey трябва да бъде дефиниран за да може да бъдат използвани функционалности като GridEditing.",
            indexOutOfRange: "Индексът на ред, който сте въвели, е извън големината на колекцията. Индексът на ред трябва да бъде в границите между {0} и {max}.",
            noSuchColumnDefined: "Зададеният ключ за колоната не е валиден. Трябва да бъде подаден ключ, който съвпада с ключа на една от дефинираните колони на мрежата.",
            columnIndexOutOfRange: "Индексът на колоната, който сте въвели, е извън големината на колекцията. Индексът на колона трябва да бъде в границите между {0} и {max}.",
            recordNotFound: "Записът с id {id} не може да бъде намерен в колекцията от данни: Проверете ключа използван за търсенето и го променете ако е необходимо.",
            columnNotFound: "Не е намерена колона с ключ {key}. Проверете ключа използван за търсенето и го променете ако е необходимо.",
            colPrefix: "Колона ",
            columnVirtualizationRequiresWidth: "Виртуализация и columnVirtualization изискват ширината на мрежата или колоните ѝ да бъде настроена. Задайте стойност за ширината на мрежата, defaultColumnWidth или ширината на всяка колона.",
            virtualizationRequiresHeight: "Виртуализацията изисква височината на мрежата да бъде настроена. Трябва да бъде подадена стойност за височината на мрежата.",
            colVirtualizationDenied: 'columnVirtualization изисква различна настройка на virtualizationMode. virtualizationMode трябва да бъде зададен като "fixed".',
            noColumnsButAutoGenerateTrue: "autoGenerateColumns не е включено и няма колони, които да са дефинирани за мрежата. Включете autoGenerateColumns или задайте колони ръчно.",
            noPrimaryKey: "igHierarchicalGrid изисква primaryKey да бъде дефиниран. Опцията primaryKey на мрежата трябва да бъде настроена.",
            //templatingEnabledButNoTemplate: "You have jQueryTemplating set to true, but there is no rowTemplate defined.",
            expandTooltip: "Отвори реда",
            collapseTooltip: "Затвори реда",
            featureChooserTooltip: "Избор на функции",
            movingNotAllowedOrIncompatible: "Зададената колона не може да бъде премахната. Уверете се, че такава колона съществува, и че крайната ѝ позиция няма да наруши оформлението на колоните.",
            allColumnsHiddenOnInitialization: "Всички колони не могат да бъдат скрити по време на инициализация. Поне една колона трябва да бъде настроена като видима.",
            columnVirtualizationNotSupportedWithPercentageWidth: "Виртуализацията изисква конфигурация за ширината на колоната различна от '*'. Ширината на колоната трябва да бъде зададена като число в пиксели.",
            mixedWidthsNotSupported: "ColumnVirtualization изисква различна настройка на ширината на мрежата. Ширината на колоната трябва да бъде зададена като число в пиксели.",
            virtualizationNotSupportedWithAutoSizeCols: "Ширината на всички колони трябва да бъде зададена по един и същи начин. Задайте ширините на колоните като проценти или като числов пиксели.",
            multiRowLayoutColumnError: "Колона с ключ: {key1} не може да бъде добавена към multi-row-layout защото мястото ѝ в оформлението вече е заето от колона с ключ: {key2}.",
            multiRowLayoutNotComplete: "multi-row-layout не е завършен. Дефинирането на колона създава оформление, което има празни интервали и не може да бъде рендирано правилно.",
            multiRowLayoutMixedWidths: "В Multi-Row Layout не се поддържат смесени ширини (проценти и пиксели). Задайте всички ширини на колоните или в пиксели, или в проценти.",
            scrollableGridAreaNotVisible: "Фиксираните горен колонтитул и долен колонтитул са по-големи от наличната височина на мрежата. Зоната, която може да се превърта, не е видима. Задайте по-голяма височина на мрежата."
        }
    });

    $.ig.GridFiltering = $.ig.GridFiltering || {};

    $.extend($.ig.GridFiltering, {
        locale: {
            startsWithNullText: "Започва с...",
            endsWithNullText: "Завършва на...",
            containsNullText: "Съдържа...",
            doesNotContainNullText: "Не съдържа...",
            equalsNullText: "Равно на...",
            doesNotEqualNullText: "Не е равно на...",
            greaterThanNullText: "По-голямо от...",
            lessThanNullText: "По-малко от...",
            greaterThanOrEqualToNullText: "По-голямо или равно на...",
            lessThanOrEqualToNullText: "По-малко или равно на...",
            onNullText: "На...",
            notOnNullText: "Не на...",
            afterNullText: "След",
            beforeNullText: "Преди",
            emptyNullText: "Празно",
            notEmptyNullText: "Не е празно",
            nullNullText: "Null",
            notNullNullText: "Не е null",
            startsWithLabel: "Започва с",
            endsWithLabel: "Завършва на",
            containsLabel: "Съдържа",
            doesNotContainLabel: "Не съдържа",
            equalsLabel: "Равно на",
            doesNotEqualLabel: "Не е равно на",
            greaterThanLabel: "По-голямо от",
            lessThanLabel: "По-малко от",
            greaterThanOrEqualToLabel: "По-голямо или равно на",
            lessThanOrEqualToLabel: "По-малко или равно на",
            trueLabel: "True",
            falseLabel: "False",
            afterLabel: "След",
            beforeLabel: "Преди",
            todayLabel: "Днес",
            yesterdayLabel: "Вчера",
            thisMonthLabel: "Този месец",
            lastMonthLabel: "Миналият месец",
            nextMonthLabel: "Следващият месец",
            thisYearLabel: "Тази година",
            lastYearLabel: "Миналата година",
            nextYearLabel: "Следващата година",
            clearLabel: "Изчисти филтърът",
            noFilterLabel: "Не",
            onLabel: "На",
            notOnLabel: "Не на",
            advancedButtonLabel: "Подробно",
            filterDialogCaptionLabel: "Подробен филтър",
            filterDialogConditionLabel1: "Покажи записите отговарящи на ",
            filterDialogConditionLabel2: " от следните критерий",
            filterDialogConditionDropDownLabel: "Условие за филтриране",
            filterDialogOkLabel: "Търси",
            filterDialogCancelLabel: "Отказ",
            filterDialogAnyLabel: "Който и да е",
            filterDialogAllLabel: "Всички",
            filterDialogAddLabel: "Прибави",
            filterDialogErrorLabel: "Беше достигнат максималния брой на поддържани филтри.",
            filterDialogCloseLabel: "Затваряне на диалога за филтриране",
            filterSummaryTitleLabel: "Резултати от търсенето",
            filterSummaryTemplate: "${matches} отговарящи записи",
            filterDialogClearAllLabel: "Изчисти всички филтри",
            tooltipTemplate: "${condition} филтър приложен",
            // M.H. 13 Oct. 2011 Fix for bug #91007
            featureChooserText: "Скрий филтъра",
            featureChooserTextHide: "Покажи филтъра",
            // M.H. 17 Oct. 2011 Fix for bug #91007
            featureChooserTextAdvancedFilter: "Подробен филтър",
            virtualizationSimpleFilteringNotAllowed: 'ColumnVirtualization изисква различен тип на филтрацията. Настройте режима на филтриране на "advanced" или изключете advancedModeEditorsVisible.',
            multiRowLayoutSimpleFilteringNotAllowed: "Multi-row-layout изисква различен тип на филтриране. Задайте режима на филтриране на 'подробен'.",
            featureChooserNotReferenced: "Липсва референция към FeatureChooser. Реферирайте infragistics.ui.grid.featurechooser.js във Вашия проект, използвайте зареждаща служебна програма (loader) или един от комбинираните скриптови файлове.",
            conditionListLengthCannotBeZero: "Масивът conditionList в columnSettings е празен. Трябва да бъде подаден подходящ масив за conditionList.",
            conditionNotValidForColumnType: "Условието '{0}' не е подходящо за конкретната конфигурация. Трябва да бъде заменено с условие подходящо за колона тип {1}.",
            defaultConditionContainsInvalidCondition: "defaultExpression за колона '{0}' съдържа условие, което не е позволено. Трябва да бъде заменено с условие подходящо за колона тип {0}."
        }
    });

    $.ig.GridGroupBy = $.ig.GridGroupBy || {};

    $.extend($.ig.GridGroupBy, {
        locale: {
            emptyGroupByAreaContent: "Издърпайте колона до тук или {0} за да групирате",
            emptyGroupByAreaContentSelectColumns: "изберете колони",
            emptyGroupByAreaContentSelectColumnsCaption: "изберете колони",
            expandTooltip: "Отвори групирания ред",
            collapseTooltip: "Затвори групирания ред",
            removeButtonTooltip: "Премахни групирането по тази колона",
            modalDialogCaptionButtonDesc: "Сортиране във възходящ ред",
            modalDialogCaptionButtonAsc: "Сортиране във низходящ ред",
            modalDialogCaptionButtonUngroup: "Премахване на групирането",
            modalDialogGroupByButtonText: "Групирай",
            modalDialogCaptionText: 'Прибави към групирането',
            modalDialogDropDownLabel: 'Показване:',
            modalDialogClearAllButtonLabel: 'изчисти всички',
            modalDialogRootLevelHierarchicalGrid: 'Най-горно ниво',
            modalDialogDropDownButtonCaption: "Покажи/Скрий",
            modalDialogButtonApplyText: 'Приложи',
            modalDialogButtonCancelText: 'Отказ',
            fixedVirualizationNotSupported: 'GroupBy изисква още една виртуализационна настройка. virtualizationMode трябва да бъде зададен като "continuous".',
            summaryRowTitle: 'Групиране на сумарния ред'
        }
    });

    $.ig.GridHiding = $.ig.GridHiding || {};

    $.extend($.ig.GridHiding, {
        locale: {
            columnChooserDisplayText: "Избиране на колони",
            hiddenColumnIndicatorTooltipText: "Скрита колона/колони",
            columnHideText: "Скрий",
            columnChooserCaptionLabel: "Избиране на колони",
            columnChooserCheckboxesHeader: "покажи",
            columnChooserColumnsHeader: "колона",
            columnChooserCloseButtonTooltip: "Затвори",
            hideColumnIconTooltip: "Скрий",
            featureChooserNotReferenced: "Липсва референция към FeatureChooser. Реферирайте infragistics.ui.grid.featurechooser.js във Вашия проект или един от комбинираните скриптови файлове.",
            columnChooserShowText: "Покажи",
            columnChooserHideText: "Скрий",
            columnChooserResetButtonLabel: "върни към начално състояние",
            columnChooserButtonApplyText: 'Приложи',
            columnChooserButtonCancelText: 'Отказ'
        }
    });

        $.ig.GridResizing = $.ig.GridResizing || {};

        $.extend($.ig.GridResizing, {
            locale: {
                noSuchVisibleColumn: "Не съществува видима колона със зададения ключ. Методът showColumn() трябва да бъде използван върху колоната преди да се опитате да промените размерите ѝ.",
            	resizingAndFixedVirtualizationNotSupported: 'Оразмеряването на колоните изисква различни настройки на виртуализация. Използвайте rowVirtualization и настройте virtualizationMode на "continuous".'
            }
        });

    $.ig.GridPaging = $.ig.GridPaging || {};

    $.extend($.ig.GridPaging, {

        locale: {
            pageSizeDropDownLabel: "Покажи ",
            pageSizeDropDownTrailingLabel: "записи",
            //pageSizeDropDownTemplate: "Show ${dropdown} records",
            nextPageLabelText: "следваща",
            prevPageLabelText: "предишна",
            firstPageLabelText: "",
            lastPageLabelText: "",
            currentPageDropDownLeadingLabel: "Страница",
            currentPageDropDownTrailingLabel: "от ${count}",
            //currentPageDropDownTemplate: "Pg ${dropdown} of ${count}",
            currentPageDropDownTooltip: "Избиране на страница",
            pageSizeDropDownTooltip: "Избиране на брой записи на страница",
            pagerRecordsLabelTooltip: "Граници на показаните записи",
            prevPageTooltip: "Предишна страница",
            nextPageTooltip: "Следваща страница",
            firstPageTooltip: "Първа страница",
            lastPageTooltip: "Последна Страница",
            pageTooltipFormat: "страница ${index}",
                pagerRecordsLabelTemplate: "${startRecord} - ${endRecord} от ${recordCount} записа",
                invalidPageIndex: "Зададеният индекс на страница е невалиден. Задайте индекс на страница, който е по-голя или равен на 0 или по-малък от общия брой страници."
        }
    });

    $.ig.GridSelection = $.ig.GridSelection || {};

    $.extend($.ig.GridSelection, {
        locale: {
            persistenceImpossible: "Избора на състояние изисква различна конфигурация. Опцията primaryKey на мрежата трябва да бъде настроена."
        }
    });

    $.ig.GridRowSelectors = $.ig.GridRowSelectors || {};

    $.extend($.ig.GridRowSelectors, {

        locale: {
            selectionNotLoaded: "igGridSelection не е бил инициализиран. Селектирането трябва да бъде включено за мрежата.",
            columnVirtualizationEnabled: 'RowSelectors изисква различна настройка на виртуализацията. Използвайте rowVirtualization и настройте virtualizationMode на "continuous".',
            selectedRecordsText: "Вие избрахте ${checked} записи.",
            deselectedRecordsText: "Вие отмаркирахте ${checked} записи.",
            selectAllText: "Избор на всички ${totalRecordsCount} записи",
            deselectAllText: "Отмаркиране на всички ${totalRecordsCount} записи",
            requireSelectionWithCheckboxes: "Необходима е селекция когато квадратчетата за отметка са включени."
        }
    });

    $.ig.GridSorting = $.ig.GridSorting || {};

    $.extend($.ig.GridSorting, {
        locale: {
            sortedColumnTooltipFormat: 'сортирано ${direction}',
            unsortedColumnTooltip: 'Сортиране на колона',
            ascending: 'възходящ ред',
            descending: 'низходящ ред',
            modalDialogSortByButtonText: 'сортирай по',
            modalDialogResetButton: "върни към начално състояние",
            modalDialogCaptionButtonDesc: "Натиснете, за да сортирате в низходящ ред",
            modalDialogCaptionButtonAsc: "Натиснете, за да сортирате във възходящ ред",
            modalDialogCaptionButtonUnsort: "Натиснете, за да премахнете сортирането",
            featureChooserText: "Сортиране",
            modalDialogCaptionText: "Сортиране по множество колони",
            modalDialogButtonApplyText: 'Приложи',
            modalDialogButtonCancelText: 'Отказ',
            sortingHiddenColumnNotSupport: 'Зададената колона не може да бъде сортирана защото е скрита. Използвайте метода showColumn() преди да се опитате да я сортирате.',
            featureChooserSortAsc: 'Сортиране във възходящ ред',
            featureChooserSortDesc: 'Сортиране във низходящ ред'
            //modalDialogButtonSlideCaption: "Click to show/hide sorted columns"
        }
    });

    $.ig.GridSummaries = $.ig.GridSummaries || {};

    $.extend($.ig.GridSummaries, {
        locale: {
            featureChooserText: "Скрий обобщение",
            featureChooserTextHide: "Покажи обобщение",
            dialogButtonOKText: 'OK',
            dialogButtonCancelText: 'Отказ',
            emptyCellText: '',
            summariesHeaderButtonTooltip: 'Покажи/Скрий обобщените стойности',
            // M.H. 13 Oct. 2011 Fix for bug 91008
            defaultSummaryRowDisplayLabelCount: 'Брой',
            defaultSummaryRowDisplayLabelMin: 'Минимум',
            defaultSummaryRowDisplayLabelMax: 'Максимум',
            defaultSummaryRowDisplayLabelSum: 'Сума',
            defaultSummaryRowDisplayLabelAvg: 'Осреднено',
            defaultSummaryRowDisplayLabelCustom: '',
            calculateSummaryColumnKeyNotSpecified: "Липсва ключа на колоната. Трябва да бъде подаден ключ на колона за да се изчислят обобщените стойности.",
            featureChooserNotReferenced: "Липсва референция към FeatureChooser. Реферирайте infragistics.ui.grid.featurechooser.js във Вашия проект или един от комбинираните скриптови файлове."
        }
    });

    $.ig.GridUpdating = $.ig.GridUpdating || {};

    $.extend($.ig.GridUpdating, {
        locale: {
            doneLabel: 'Готово',
            doneTooltip: 'Излез и запази промените',
            cancelLabel: 'Отказ',
            cancelTooltip: 'Излез без да запазваш промените',
            addRowLabel: 'Пробави нов ред',
            addRowTooltip: 'Започни добавянето на нови редове',
            deleteRowLabel: 'Изтрий реда',
            deleteRowTooltip: 'Изтрий реда',
            igTextEditorException: 'В момента не е възможно актуализирането на низовите колони в мрежата. Първо трябва да бъде зареден ui.igTextEditor.',
            igNumericEditorException: 'В момента не е възможно актуализирането на числовите колони в мрежата. Първо трябва да бъде зареден ui.igNumericEditor.',
            igCheckboxEditorException: 'В момента не е възможно актуализирането на чекбокс колони в мрежата. Първо трябва да бъде зареден ui.igCheckboxEditor.',
            igCurrencyEditorException: 'В момента не е възможно актуализирането на числовите колони в мрежата с валутен формат. Първо трябва да бъде зареден ui.igCurrencyEditor.',
            igPercentEditorException: 'В момента не е възможно актуализирането на числовите колони в мрежата с валутен формат. Първо трябва да бъде зареден ui.igPercentEditor.',
            igDateEditorException: 'В момента не е възможно актуализирането на дата колони в мрежата. Първо трябва да бъде зареден ui.igDateEditor.',
            igDatePickerException: 'В момента не е възможно актуализирането на дата колони в мрежата. Първо трябва да бъде зареден ui.igDatePicker.',
            igComboException: 'В момента не е възможно използването на combo в мрежата. ui.igCombo трябва да бъде зареден първо.',
            igRatingException: 'В момента не е възможно използването на igRating като редактор в мрежата. ui.igRating трябва да бъде зареден първо.',
            igValidatorException: 'В момента не възможно поддържането на валидиране с опциите дефинирани в igGridUpdating. ui.igValidator трябва да бъде зареден първо.',
            editorTypeCannotBeDetermined: 'Обновяването нямаше достатъчно информация за да определи типа на редактора, който да използва за колона: ',
            noPrimaryKeyException: 'Операциите за обновяване изискват различна конфигурация. Опцията primaryKey на мрежата трябва да бъде настроена.',
            hiddenColumnValidationException: 'Не е възможно редактирането на ред със скрита колона и включена валидация. Използвайте метода showColumn() или изключете валидацията на колоната преди да се опитате да редактирате реда.',
            dataDirtyException: 'Мрежата има неизпълнени транзакции, което може да доведе до рендирането на информацията ѝ. Включете опцията "autoCommit" на igGrid или обработете събитието "dataDirty", което връща false. Докато обработвате това събитие може по избор да извикате метода commit().',
            recordOrPropertyNotFoundException: 'Зададеният запис или свойство не е намерено. Проверете критериите за търсене и ги променете ако е необходимо.',
            rowEditDialogCaptionLabel: 'Редактирай данните в реда',
            excelNavigationNotSupportedWithCurrentEditMode: 'ExcelNavigation изисква различна конфигурация. editMode трябва да бъде зададен като "cell" или "row".',
            columnNotFound: "Зададения ключ на колона не беше намерен във видимата колекция от колони или зададеният индекс е бил извън границите.",
            rowOrColumnSpecifiedOutOfView: "В момента не е възможна промяната на зададения ред или колона. Те трябва да бъдат видими на конкретната страница и във виртуализационната рамка.",
            editingInProgress: "В момента се променя ред или клетка. Не може да се започне нова процедура по промяна ако сегашната не е завършена.",
            undefinedCellValue: 'Недефинирани не могат да бъдат зададени като стойност на клетка.',
            addChildTooltip: 'Добави нов подред',
            multiRowGridNotSupportedWithCurrentEditMode: "Когато мрежата има включен multi-row-layout се поддържа единствено режим на редактиране на диалози."
        }
    });

    $.ig.ColumnMoving = $.ig.ColumnMoving || {};

    $.extend($.ig.ColumnMoving, {
        locale: {
            movingDialogButtonApplyText: 'Приложи',
            movingDialogButtonCancelText: 'Отказ',
            movingDialogCaptionButtonDesc: 'Премести надолу',
            movingDialogCaptionButtonAsc: 'Премести нагоре',
            movingDialogCaptionText: 'Премести колоните',
            movingDialogDisplayText: 'Премести колоните',
            movingDialogDropTooltipText: 'Премести тук',
            movingDialogCloseButtonTitle: 'Затваряне на движещия се диалог',
            dropDownMoveLeftText: 'Премести наляво',
            dropDownMoveRightText: 'Премести надясно',
            dropDownMoveFirstText: 'Премести в началото',
            dropDownMoveLastText: 'Премести в края',
            featureChooserNotReferenced: 'Липсва референция към FeatureChooser. Реферирайте infragistics.ui.grid.featurechooser.js във Вашия проект или един от комбинираните скриптови файлове.',
            movingToolTipMove: 'Премести',
            featureChooserSubmenuText: 'Премести'
        }
    });

    $.ig.ColumnFixing = $.ig.ColumnFixing || {};

    $.extend($.ig.ColumnFixing, {
        locale: {
            headerFixButtonText: 'Фиксирай колоната',
            headerUnfixButtonText: 'Освободи колоната',
            featureChooserTextFixedColumn: 'Фиксирай колоната',
            featureChooserTextUnfixedColumn: 'Освободи колоната',
            groupByNotSupported: 'ColumnFixing изисква различна конфигурация. Функцията GroupBy трябва да бъде изключена.',
            virtualizationNotSupported: 'ColumnFixing изисква различни настройки на виртуализация. Вместо това трябва да се използва rowVirtualization.',
            columnVirtualizationNotSupported: 'ColumnFixing изисква различни настройки на виртуализация. columnVirtualization трябва да се изключи.',
            columnMovingNotSupported: 'ColumnFixing изисква различна конфигурация. ColumnMoving трябва да бъде изключено.',
            hidingNotSupported: 'ColumnFixing изисква различна конфигурация. Функцията Hiding трябва да бъде изключена.',
            hierarchicalGridNotSupported: 'igHierarchicalGrid не поддържа ColumnFixing. ColumnFixing трябва да бъде изключено.',
            responsiveNotSupported: 'ColumnFixing изисква различна конфигурация. Функцията Responsive трябва да бъде изключена.',
            noGridWidthNotSupported: 'Фиксирането на колони изисква различна конфигурация. Ширината на мрежата трябва да бъде зададена като проценти или като число в пиксели.',
            gridHeightInPercentageNotSupported: 'Фиксирането на колони изисква различна конфигурация. Ширината на мрежата трябва да бъде зададена в пиксели.',
            defaultColumnWidthInPercentageNotSupported: "ColumnFixing изисква различна конфигурация. Стандартната ширина на колоната трябва да бъде зададена като число в пиксели.",
            columnsWidthShouldBeSetInPixels: 'ColumnFixing изисква други настройки на ширината на колоната. Ширината на колоната с ключ {key} трябва да бъде зададена в пиксели.',
            unboundColumnsNotSupported: 'ColumnFixing изисква различна конфигурация. UnboundColumns трябва да бъде изключено.',
            excelNavigationNotSupportedWithCurrentEditMode: "Режима Excel Navigation се поддържа само за режимите Cell Edit и Row Edit. За да избегнете тази грешка или изключете excelNavigationMode, или настройте editMode на клетки или редове.",
            initialFixingNotApplied: 'Първоначалното фиксиране не може да бъде приложено за колoна с ключ: {0}. Причина: {1}', // {0} is placeholder for columnKey, {1} error message
            setOptionGridWidthException: 'Невалидна стойност за опцията за размера на ширината на мрежата. Когато има фиксирани колони ширината на видимата зона на нефиксираните колони/нефиксираната колона трябва да бъде по-голяма или равна на стойността на minimalVisibleAreaWidth.',
            internalErrors: {
                none: 'Вие успешно конфигурирахте мрежата!',
                notValidIdentifier: 'Зададеният ключ за колоната не е валиден. Подайте ключ за колоната, който а съвпада с един от ключовете на дефинираната колона в мрежата.',
                fixingRefused: 'Фиксирането на тази колона в момента не се поддържа. Освободете друга видима колона или първо използвайте метода showColumn() върху всяка една скрита свободна колона.',
                fixingRefusedMinVisibleAreaWidth: 'Тази колона неможе да бъде фиксирана. Ширината ѝ надхвърля наличното място за фиксиране на колона в мрежата.',
                alreadyHidden: 'В момента не е възможно фиксирането/освобождаването на тази колона. Методът showColumn() трябва първо да бъде използван върху колоната.',
                alreadyUnfixed: 'Тази колона е вече свободна.',
                alreadyFixed: 'Тази колона е вече фиксирана.',
                unfixingRefused: 'В момента не е възможно освобождаването на тази колона. Методът showColumn() трябва първо да бъде използван върху някоя скрита, фиксирана колоната.',
                targetNotFound: 'Не е намерена целевата колона с ключ {key}. Проверете ключа използван за тъсенете и го променете ако е необходимо.'
            }
        }
    });

    $.ig.GridAppendRowsOnDemand = $.ig.GridAppendRowsOnDemand || {};

    $.extend($.ig.GridAppendRowsOnDemand, {
        locale: {
            loadMoreDataButtonText: 'Зареди още данни',
            appendRowsOnDemandRequiresHeight: 'AppendRowsOnDemand изисква различна конфигурация. Височината на мрежата трябва да бъде зададена.',
            groupByNotSupported: 'AppendRowsOnDemand изисква различна конфигурация. GroupBy трябва да бъде изключено.',
            pagingNotSupported: 'AppendRowsOnDemand изисква различна конфигурация. Paging трябва да бъде изключено.',
            cellMergingNotSupported: 'AppendRowsOnDemand изисква различна конфигурация. CellMerging трябва да бъде изключено.',
            virtualizationNotSupported: 'AppendRowsOnDemand изисква различна конфигурация. Virtualization трябва да бъде изключено.'
        }
    });

    $.ig.igGridResponsive = $.ig.igGridResponsive || {};

    $.extend($.ig.igGridResponsive, {
    	locale: {
    	    fixedVirualizationNotSupported: 'Функцията Responsive изисква различна настройка на виртуализацията. virtualizationMode трябва да бъде зададен като "continuous".'
    	}
    });

    $.ig.igGridMultiColumnHeaders = $.ig.igGridMultiColumnHeaders || {};

    $.extend($.ig.igGridMultiColumnHeaders, {
    	locale: {
    	    multiColumnHeadersNotSupportedWithColumnVirtualization: 'Multi-column headers изисква различна конфигурация. columnVirtualization трябва да бъде изключен.'
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
			boldButtonTitle: 'Получер',
			italicButtonTitle: 'Курсив',
			underlineButtonTitle: 'Подчертано',
			strikethroughButtonTitle: 'Зачеркнат',
			increaseFontSizeButtonTitle: 'Увеличи размера на шрифта',
			decreaseFontSizeButtonTitle: 'Намали размера на шрифта',
			alignTextLeftButtonTitle: 'Подравняване на текст отляво',
			alignTextRightButtonTitle: 'Подравняване на текст отдясно',
			alignTextCenterButtonTitle: 'Центрирано',
			justifyButtonTitle: 'Двустранно подравняване',
			bulletsButtonTitle: 'Водещи символи',
			numberingButtonTitle: 'Номериране',
			decreaseIndentButtonTitle: 'Намали отстъпа',
			increaseIndentButtonTitle: 'Увеличи отстъпа',
			insertPictureButtonTitle: 'Вмъкване на картина',
			fontColorButtonTitle: 'Цвят на шрифт',
			textHighlightButtonTitle: 'Цвят на осветяване на текст',
			insertLinkButtonTitle: 'Вмъкване на хипервръзка',
			insertTableButtonTitle: 'Таблица',
			addRowButtonTitle: 'Прибави ред',
			removeRowButtonTitle: 'Премахни ред',
			addColumnButtonTitle: 'Прибави колона',
			removeColumnButtonTitle: 'Премахни колона',
			inserHRButtonTitle: 'Insert Horizontal Rule',
			viewSourceButtonTitle: 'Покажи сорс кода',
			cutButtonTitle: 'Изрежи',
			copyButtonTitle: 'Копирай',
			pasteButtonTitle: 'Постави',
			undoButtonTitle: 'Undo',
			redoButtonTitle: 'Redo',
			imageUrlDialogText: 'URL на картината:',
			imageAlternativeTextDialogText: 'Алтернативен текст:',
			imageWidthDialogText: 'Широчина на изображението:',
			imageHeihgtDialogText: 'Височина на изображението:',
			linkNavigateToUrlDialogText: 'Навигирай към URL:',
			linkDisplayTextDialogText: 'Текст:',
			linkOpenInDialogText: 'Отвори във:',
			linkTargetNewWindowDialogText: 'Нов прозорец',
			linkTargetSameWindowDialogText: 'Съшият прозорец',
			linkTargetParentWindowDialogText: 'Майчиният прозорец',
			linkTargetTopmostWindowDialogText: 'Най-горният прозорец',
			applyButtonTitle: 'Изпълни',
			cancelButtonTitle: 'Отказ',
			defaultToolbars: {
			    textToolbar: "лентата с инструменти за манипулация на текст",
			    formattingToolbar: "лентата с инструменти за форматиране на текст",
			    insertObjectToolbar: "лентата с инструменти за вмъкване на обекти",
			    copyPasteToolbar: "лентата с инструменти за копиране/поставяне"
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
					{ text: "h1", value: "Заглавие 1" },
					{ text: "h2", value: "Заглавие 2" },
					{ text: "h3", value: "Заглавие 3" },
					{ text: "h4", value: "Заглавие 4" },
					{ text: "h5", value: "Заглавие 5" },
					{ text: "h6", value: "Заглавие 6" },
                    { text: "p", value: "Нормално" }
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
			successMsg: "Успех",
			errorMsg: "Грешка",
			warningMsg: "Внимание"
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
                invalidDataSource: "Подаденият източник на данни е или нулев, или не се поддържа.",
                measureList: "Мерки",
                ok: "ОК",
                cancel: "Отказ",
                addToMeasures: "Добави към мерките",
                addToFilters: "Добави към филтрите",
                addToColumns: "Добави към колоните",
                addToRows: "Добави към редовете"
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
                invalidBaseElement: " не се поддържа като основен елемент. Използвай DIV вместо това.",
                catalog: "Каталог",
                cube: "Куб",
                measureGroup: "Група от мерки",
                measureGroupAll: "(Всичко)",
                rows: "Редове",
                columns: "Колони",
                measures: "Мерки",
                filters: "Филтри",
                deferUpdate: "Отложи актуализацията",
                updateLayout: "Актуализирай оформлението",
                selectAll: "Избери всичко"
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
                filtersHeader: "Пусни филтърните полета тук",
                measuresHeader: "Пусни данните тук",
                rowsHeader: "Пусни полетата за редове тук",
                columnsHeader: "Пусни полетата за колони тук",
                disabledFiltersHeader: "Полета за филтриране",
                disabledMeasuresHeader: "Данни",
                disabledRowsHeader: "Полета за редове",
                disabledColumnsHeader: "Полета за колони",
                noSuchAxis: "Няма такава ос"
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
			popoverOptionChangeNotSupported: "Промяната на следната опция след инициализация на igPopover не се поддържа:",
			popoverShowMethodWithoutTarget: "Целевият параметър на функцията show е задължителен, когато се използва опцията за селектори."
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
			    setOptionError: 'Стойността на следната опция не може да бъде променяна след инициализация: '
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
		        errorPanels: 'Броят на панелите не може да надвишава два.',
		        errorSettingOption: 'Грешка в настройката на опцията.'
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
		    renderDataError: "Извличането или парсирането на данните е неуспешно.",
		    setOptionItemsLengthError: "Дължината на подадената items конфигурация не отговаря на броя на плочките."
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
			collapseButtonTitle: 'Прибери',
			expandButtonTitle: 'Отвори'
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
			    invalidArgumentType: 'Подаденият аргумент е от невалиден тип.',
			    errorOnRequest: 'Проблем при извличане на данните: ',
			    noDataSourceUrl: 'igTree изисква опцията dataSourceUrl да бъде попълнена, за да се оправят заявки за данни.',
			    incorrectPath: 'Връх със следната пътека не беше намерен: ',
			    incorrectNodeObject: 'Подаденият аргумент не е jQuery елемент.',
			    setOptionError: 'Стойността на следната опция не може да бъде променяна след инициализация: ',
			    moveTo: '<strong>Премести върху</strong> {0}',
			    moveBetween: '<strong>Премести между</strong> {0} и {1}',
			    moveAfter: '<strong>Премести след</strong> {0}',
			    moveBefore: '<strong>Премести преди</strong> {0}',
			    copyTo: '<strong>Копирай върху</strong> {0}',
			    copyBetween: '<strong>Копирай между</strong> {0} и {1}',
			    copyAfter: '<strong>Копирай след</strong> {0}',
			    copyBefore: '<strong>Копирай преди</strong> {0}',
			    and: 'и'
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
                fixedVirtualizationNotSupported: 'RowVirtualization изисква различна virtualizationMode настройка, virtualizationMode трябва да бъде зададен като "continuous".'
            }
        });

        $.ig.TreeGridPaging = $.ig.TreeGridPaging || {};

        $.extend($.ig.TreeGridPaging, {
            locale: {
                contextRowLoadingText: "Зарежда...",
                contextRowRootText: "Най-горно ниво",
                columnFixingWithContextRowNotSupported: 'ColumnFixing изисква различна настройка на contextRowMode. За да включите ColumnFixing contextRowMode трябва да бъде зададен като "none".'
            }
        });

        $.ig.TreeGridFiltering = $.ig.TreeGridFiltering || {};

        $.extend($.ig.TreeGridFiltering, {
            locale: {
                filterSummaryInPagerTemplate: "${currentPageMatches} от ${totalMatches} съвпадащи записи"
            }
        });

        $.ig.TreeGridRowSelectors = $.ig.TreeGridRowSelectors || {};

        $.extend($.ig.TreeGridRowSelectors, {
        	locale: {
        	    multipleSelectionWithTriStateCheckboxesNotSupported: "Множественото селектиране изисква различна настройка на checkBoxMode. checkBoxMode трябва да бъде зададен като biState. "
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
			    labelUploadButton: "Качи файл",
			    labelAddButton: "Прибави",
			    labelClearAllButton: "Изчисти качените",
			    // M.H. 13 May 2011 - fix bug 75042
			    labelSummaryTemplate: "{0} от {1} качени",
			    labelSummaryProgressBarTemplate: "{0}/{1}",
			    labelShowDetails: "Покажи детайлите",
			    labelHideDetails: "Скрий детайлите",
			    labelSummaryProgressButtonCancel: "Отказ",
			    // M.H. 1 June 2011 Fix bug #77532
			    labelSummaryProgressButtonContinue: "Качи",
			    labelSummaryProgressButtonDone: "Готово",
			    labelProgressBarFileNameContinue: "...",

			    //error messages
			    errorMessageFileSizeExceeded: "Максималната големина на файла е надхвърлена.",
			    errorMessageGetFileStatus: "Състоянието на файла не може да бъде взето! Вероятно е връзката да е прекъснала.",
			    errorMessageCancelUpload: "Командата за отмяна на качването е неуспешно изпратена! Вероятно е връзката да е прекъснала.",
			    errorMessageNoSuchFile: "Файлът не може да бъде намерен. Вероятно файлът е твърде голям.",
			    errorMessageOther: "Грешка при качването на файла. Код на грешката: {0}.",
			    errorMessageValidatingFileExtension: "Неуспешно валидиране на разширението на файла.",
			    errorMessageAJAXRequestFileSize: "Грешка в AJAX заявката при опит да се вземе големината на файла.",
			    errorMessageMaxUploadedFiles: "Надхвърлен е максималният брой на качените файлове.",
			    errorMessageMaxSimultaneousFiles: "Стойността на опцията maxSimultaneousFilesUploads е невалидна. Трябва да е по-голяма от 0 или null.",
			    errorMessageTryToRemoveNonExistingFile: "Опитвате премахване на несъществуващ файл с id {0}.",
			    errorMessageTryToStartNonExistingFile: "Опитвате стартиране на качване на несъществуващ файл с id {0}.",
			    errorMessageDropMultipleFilesWhenSingleModel: "Не е позволено пускането на повече от 1 файл когато режимът е single",

			    // M.H. 12 May 2011 - fix bug 74763: add title to all buttons
			    // title attributes            
			    titleUploadFileButtonInit: "Качи файл",
			    titleAddFileButton: "Прибави",
			    titleCancelUploadButton: "Отказ",
			    // M.H. 1 June 2011 Fix bug #77532
			    titleSummaryProgressButtonContinue: "Качи",
			    titleClearUploaded: "Изчисти качените",
			    titleShowDetailsButton: "Покажи детайлите",
			    titleHideDetailsButton: "Скрий детайлите",
			    titleSummaryProgressButtonCancel: "Отказ",
			    titleSummaryProgressButtonDone: "Готово",
			    // M.H. 1 June 2011 Fix bug #77532
			    titleSingleUploadButtonContinue: "Качи",
			    titleClearAllButton: "Изчисти качените"
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
		        defaultMessage: 'Обърнете внимание на това поле',
		        selectMessage: 'Трябва да бъде избрана стойност.',
		        rangeSelectMessage: 'Поне {0}, но не повече от {1} е елемента трябва да бъдат избрани.',
		        minSelectMessage: 'Поне {0} елемента трябва да бъдат избрани.',
		        maxSelectMessage: 'Не повече от {0} трябва да бъдат избрани',
		        rangeLengthMessage: 'Входните данни трябва да са дълги между {0} и {1} знака',
		        minLengthMessage: 'Входните данни трябва да са дълги поне {0} знака.',
		        maxLengthMessage: 'Входните данни не трябва да са дълги повече от {0} знака.',
			    requiredMessage: 'Това поле е задължително',
			    patternMessage: 'Въведените данни не спазват зададения образец.',
			    maskMessage: 'Всички задължителни позиции трябва да бъдат попълнени.',
			    dateFieldsMessage: 'Трябва да бъдат въведени стойности от полето за дата',
			    invalidDayMessage: 'Трябва да бъде въведен валиден ден от месеца.',
			    dateMessage: 'Трябва да бъде въведена валидна дата.',
			    numberMessage: 'Трябва да бъде въведено валидно число.',
			    rangeValueMessage: 'Моля попълнете стойност между {0} и {1}',
			    minValueMessage: 'Моля попълнете стойност по-голяма или равна на {0}',
			    maxValueMessage: 'Моля попълнете стойност по-малка или равна на {0}',
			    emailMessage: 'Трябва да бъде въведен валиден имейл адрес.',
			    equalToMessage: 'Двете стойности не съвпадат.',
			    optionalString: '(незадължително)'
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
			    liveStream: "Видео на живо",
			    live: "На живо",
			    paused: "Паузирано",
			    playing: "В прогрес",
			    play: 'Пусни',
			    volume: "Сила на звука",
			    unsupportedVideoSource: "Подадените видео източници не съдържат формат поддържан от вашия браузър.",
			    missingVideoSource: "Липсват видео източници.",
			    progressLabelLongFormat: "$currentTime$ / $duration$",
			    progressLabelShortFormat: "$currentTime$",
			    enterFullscreen: "Цял екран",
			    exitFullscreen: "Излез от цял екран",
			    skipTo: "Отиди до",
			    unsupportedBrowser: "Вашият браузър не поддържа HTML5 видео. <br/>Моля обновете до някоя от следните версии:",
			    currentBrowser: "Вашият браузър: {0}",
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
			    buffering: 'Буфериране...',
			    adMessage: 'Реклама: Видеото ще продължи след $duration$ секунди.',
			    adMessageLong: 'Реклама: Видеото ще продължи след $duration$.',
			    adMessageNoDuration: 'Реклама: Видеото ще продължи след рекламите.',
			    adNewWindowTip: 'Реклама: Натиснете тук, за да отворите съдържанието в нов прозорец.',
			    nonDivException: 'Infragistics HTML5 Video Player може да бъде инстанциран само на DIV елемент.',
			    relatedVideos: 'Подобни видея',
			    replayButton: 'Започни отначало',
			    replayTooltip: 'Натиснете тук, за да пуснете видеото отначало.'
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
	            zoombarTargetNotSpecified: "igZoombar изисква валидна цел, към която да се прикрепи!",
	            zoombarTypeNotSupported: "Видът на компонента, към който igZoombar се опитва да се прикрепи не се поддържа!",
	            optionChangeNotSupported: "Промяната на следната опция след инициализация на igZoombar не се поддържа:"
		    }
	    });

    }
})(jQuery);
/*
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
			    unsupportedBrowser: "Браузърът ви не поддържа HTML5 canvas елемент. <br/>Моля обновете до някоя от следните версии:",
			    currentBrowser: "Вашият браузър: {0}",
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

