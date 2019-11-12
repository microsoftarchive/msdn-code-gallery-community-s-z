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
			    invalidDataSource: "指定したデータ ソースは無効です。スカラーです。",
			    unknownDataSource: "データ ソース型を決定できません。JSON または XML データであるかどうかを指定してください。",
			    errorParsingArrays: "配列データを解析して定義したデータ スキーマを適用したときにエラーが発生しました。 ",
			    errorParsingJson: "JSON データを解析して定義したデータ スキーマを適用したときにエラーが発生しました。 ",
			    errorParsingXml: "XML データを解析して定義したデータ スキーマを適用したときにエラーが発生しました。 ",
			    errorParsingHtmlTable: "HTML テーブルからデータを展開してスキーマを適用したときにエラーが発生しました。 ",
			    errorExpectedTbodyParameter: "パラメーターは tbody または table である必要があります。",
			    errorTableWithIdNotFound: "この ID を持つ HTML テーブルが見つかりませんでした:  ",
			    errorParsingHtmlTableNoSchema: "テーブルの DOM の分析でエラーが発生しました:  ",
			    errorParsingJsonNoSchema: "JSON 文字列の分析または評価でエラーが発生しました: ",
			    errorParsingXmlNoSchema: "XML 文字列の分析でエラーが発生しました: ",
			    errorXmlSourceWithoutSchema: "指定したデータ ソースは XML ドキュメントですが、データ スキーマ ($.IgDataSchema) が定義されていません。 ",
			    errorUnrecognizedFilterCondition: "渡されたフィルター条件は無効です。 ",
			    errorRemoteRequest: "データを取得するリモート要求に失敗しました。 ",
			    errorSchemaMismatch: "入力データがスキーマと一致しません。このフィールドをマップできませんでした:  ",
			    errorSchemaFieldCountMismatch: "入力のデータがスキーマと一致しません。フィールド数が無効です。 ",
			    errorUnrecognizedResponseType: "応答型が正しく設定されなかったか、自動的に検出できませんでした。settings.responseDataType または settings.responseContentType を設定してください。",
			    hierarchicalTablesNotSupported: "HierarchicalSchema でテーブルをサポートしません。",
			    cannotBuildTemplate: "jQuery テンプレートをビルドできませんでした。データ ソースでレコードがないし、列が定義されていません。",
			    unrecognizedCondition: "この式で無効なフィルター条件があります:  ",
			    fieldMismatch: "この式で無効なフィールドまたはフィルター条件があります:  ",
			    noSortingFields: "フィールドが指定されていません。sort() を呼び出すときに、並べ替えるフィールドを 1 つ以上を指定する必要があります。",
			    filteringNoSchema: "スキーマまたはフィールドが指定されていません。データ ソースをフィルターするには、フィールド定義および型を含むスキーマを指定する必要があります。",
			    noSaveChanges: "変更の保存に失敗しました。サーバーが Success オブジェクトを返さなかったか Success:false を返しました。",
			    errorUnexpectedCustomFilterFunction: "カスタム フィルター関数で予期しない値が提供されました。関数または文字列が必要です。"
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
			    seriesName: "オプションを設定するときに、シリーズ名のオプションを指定する必要があります。",
			    axisName: "オプションを設定するときに、軸名のオプションを指定する必要があります。",
			    invalidLabelBinding: "ラベルにバインドする値はありません。",
			    invalidSeriesAxisCombination: "シリーズおよび軸型の組み合わせは無効です: ",
			    close: "閉じる",
			    overview: "概要",
			    zoomOut: "ズームアウト",
			    zoomIn: "ズームイン",
			    resetZoom: "ズームのリセット",
			    seriesUnsupportedOption: "現在のシリーズ タイプで次のオプションはサポートされません: ",
			    seriesTypeNotLoaded: "要求されたシリーズ タイプを含む JavaScript ファイルが読み込まれていない、またはシリーズ タイプが無効です: ",
			    axisTypeNotLoaded: "要求された軸タイプを含む JavaScript ファイルが読み込まれていない、または軸タイプが無効です: ",
			    axisUnsupportedOption: "現在の軸タイプで次のオプションはサポートされません: "
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
		    undefinedArgument: 'データ ソース プロパティを取得する際にエラーが発生しました: '
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
			    aILength: "AI は 2 つのディジット以上にする必要があります。",
			    badFormedUCCValue: "UCC バーコードの Data プロパティが有効な値に設定されていません。(AI)GTIN の書式に設定してください。",
			    code39_NonNumericError: "文字 '{0}' は CODE39 の Data プロパティで無効です。有効な文字は {1} です。",
			    countryError: "国コードの変換に失敗しました。数値にする必要があります。",
			    emptyValueMsg: "Data 値は空です。",
			    encodingError: "変換でエラーが発生しました。有効なプロパティ値についてはヘルプを参照してください。",
			    errorMessageText: "無効な値です。ヘルプを参照して、バーコードの有効な Data 値を確認してください。",
			    gS1ExMaxAlphanumNumber: "GS1 DataBar Expanded のバーコードは 41 英数字以下の文字をエンコードできます。",
			    gS1ExMaxNumericNumber: "GS1 DataBar Expanded のバーコードは 74 数字以下の文字をエンコードできます。",
			    gS1Length: "GS1 DataBar の Data プロパティは GTIN のために使用されます。長さは 7、11、12、または 13 に設定する必要があります。最後の数字はチェックサムです。",
			    gS1LimitedFirstChar: "GS1 DataBar Limited のバーコードの最初の数字は 0 または 1 に設定する必要があります。1 より大きい Indicator 値を持つ GTIN-14 データをエンコードするときに、バーコードのタイプは Omnidirectional、Stacked、Stacked Omnidirectional、または Truncated に設定する必要があります。",
			    i25Length: "Interleaved2of5 バーコードは偶数の数字を持つ必要があります。奇数の場合、0 を数字の最初に追加します。",
			    intelligentMailLength: "Intelligent Mail バーコードの Data プロパティの長さは 20、25、29、または 31 桁に設定する必要があります。トラック コードは 20 桁 (バーコードの ID は 2 数字、サービス タイプの ID は 3 数字、メーラーの ID は 6 または 9 数字、シリアル数は 9 または 6 数字) に設定して、郵便番号は 0、5、9、または 11 桁に設定します。",
			    intelligentMailSecondDigit: "2 番目の数字は 0～4 の範囲に設定する必要があります。",
			    invalidAI: "アプリケーション識別子要素の文字列は無効です。データの AI 文字列を有効な文字列に設定してください。",
			    invalidCharacter: "'{0}' の文字が現在のバーコードのタイプで無効です。有効な文字は {1} です。",
			    invalidDimension: "Stretch、BarsFillMode と XDimension のプロパティ値の組み合わせが無効なため、バーコードの寸法は確定できません。",
			    invalidHeight: "バーコード グリッドの {0} 行は {1} ピクセルの高さに設定できません。",
			    invalidLength: "バーコードの Data プロパティは、{0} 桁である必要があります。",
			    invalidPostalCode: "無効な PostalCode 値 - モード 2 は、5 桁または 9 桁の米国の郵便番号をエンコードします。モード 3 は 6 文字 (英数字) コード以下をエンコードします。",
			    invalidPropertyValue: "{0} プロパティ値は {1} ～ {2} の範囲内に設定する必要があります。",
			    invalidVersion: "現在のエンコード モードおよびエラーの修正レベルでは、SizeVersion 数はデータをエンコードするために十分なセルを生成しません。",
			    invalidWidth: "バーコード グリッドの {0} 列は {1} ピクセルの幅に設定できません。XDimension と WidthToHeightRatio の両方、またはそのいずれかのプロパティ値をチェックしてください。",
			    invalidXDimensionValue: "現在のバーコード タイプは XDimension 値が {0} から {1} の範囲内である必要があります。",
			    maxLength: "{0} は現在のバーコード タイプでエンコードできる最大長を超えています。エンコード可能な最大長は {1} 文字です。",
			    notSupportedEncoding: "{0} {1} に対するエンコード化はサポートされていません。",
			    pDF417InvalidRowsColumnsCombination: "(Data およびエラー修正の) コードワードの長さが行列 {0} x {1} の記号でエンコード可能な最大値を超えています。",
			    primaryMessageError: "最初のメッセージ データを Data 値から取得できません。構造についてはヘルプを参照してください。",
			    serviceClassError: "サービス クラスの変換に失敗しました。数値にする必要があります。",
			    smallSize: "定義された Stretch 設定の場合、グリッドを Size({0}, {1}) に合わせません。",
			    unencodableCharacter: "'{0}' の文字はエンコードできません。",
			    uPCEFirstDigit: "UPCE の最初の数字は 0 に設定する必要があります。",
			    warningString: "Barcode 警告: ",
			    wrongCompactionMode: "Data メッセージを {0} モードで圧縮することはできません。",
			    notLoadedEncoding: "{0} エンコードは読み込まれません。"
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
		        noMatchFoundText: '検索結果はありません',
		        dropDownButtonTitle: 'ドロップダウンの表示',
		        clearButtonTitle: '値をクリア',
		        placeHolder: '項目を選択',
		        notSuported: 'この操作はサポートされません',
		        errorNoSupportedTextsType: "異なるフィルター テキストを使用してください。文字列または文字列の配列を使用してください。",
		        errorUnrecognizedHighlightMatchesMode: '他の強調表示一致モードを使用してください。"multi"、"contains"、"startsWith"、"full" または "null" のいずれかを選択してください。',
		        errorIncorrectGroupingKey: "グループ化キーは無効です。"
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
			    closeButtonTitle: "閉じる",
			    minimizeButtonTitle: "最小化",
			    maximizeButtonTitle: "最大化",
			    pinButtonTitle: "ピン固定",
			    unpinButtonTitle: "ピン固定の解除",
			    restoreButtonTitle: "元に戻す"
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
                invalidBaseElement: " はベース要素としてサポートされていません。代わりに DIV を使用してください。"
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
			    spinUpperTitle: '増やす',
			    spinLowerTitle: '減らす',
			    buttonTitle: 'リストの表示',
			    clearTitle: '値をクリア',
			    ariaTextEditorFieldLabel: 'テキスト エディター',
			    ariaNumericEditorFieldLabel: '数値エディター',
			    ariaCurrencyEditorFieldLabel: '通貨エディター',
			    ariaPercentEditorFieldLabel: 'パーセント エディター',
			    ariaMaskEditorFieldLabel: 'マスク エディター',
			    ariaDateEditorFieldLabel: '日付エディター',
			    ariaDatePickerFieldLabel: '日付ピッカー',
			    ariaSpinUpButton: 'スピン アップ',
			    ariaSpinDownButton: 'スピン ダウン',
			    ariaDropDownButton: 'ドロップダウン',
			    ariaClearButton: 'クリア',
			    ariaCalendarButton: 'カレンダー',
			    datePickerButtonTitle: 'カレンダーの表示',
			    updateModeUnsupportedValue: 'updateMode に異なる構成を使用してください。値 "onChange" または "immediate" を選択してください。',
			    updateModeNotSupported: 'updateMode プロパティは、igMaskEditor、igDateEditor、および igDatePicker 拡張機能で "onchange" モードのみをサポートします。',
			    renderErrMsg: "ベース エディターは直接インスタンスを作成できません。テキスト、数値、日付、または他のエディターを試してください。",
			    multilineErrMsg: "textArea に異なる構成を使用してください。textMode は 'multiline' に設定してください。",
			    targetNotSupported: "ターゲット要素はサポートされていません。",
			    placeHolderNotSupported: "placeholder 属性はブラウザーでサポートされていません。",
			    allowedValuesMsg: "ドロップダウン リストから値を選択してください。",
			    maxLengthErrMsg: "入力は長すぎるため、{0} 文字にトリムされます。",
			    maxLengthWarningMsg: "入力値がこのフィールドの最大長さである {0} に達しました。",
			    minLengthErrMsg: "{0} 文字以上を入力する必要があります",
			    maxValErrMsg: "入力値がこのフィールドの最大値である {0} に達しました。",
			    minValErrMsg: "入力値がこのフィールドの最小値である {0} に達しました。",
			    maxValExceedRevertErrMsg: "入力値が最大値である {0} を超えたため、以前の値に戻されました。",
			    minValExceedRevertErrMsg: "入力値が最小値である {0} より小さいため、以前の値に戻されました。",
			    maxValExceedSetErrMsg: "入力値が最大値である {0} を超えたため、最大値に設定されました。",
			    minValExceedSetErrMsg: "入力値が最小値である {0} より小さいため、最小値に設定されました。",
			    maxValExceededWrappedAroundErrMsg: "入力値が最大値である {0} を超えたため、許可された最小値に設定されました。",
			    minValExceededWrappedAroundErrMsg: "入力値が最小値である {0} より小さいため、許可された最大値に設定されました。",
			    btnValueNotSupported: '異なるボタン値が必要です。値 "dropdown"、"clear"、または "spin" を選択してください。',
			    scientificFormatErrMsg: '異なる scientificFormat が必要です。"E"、"e"、"E+"、または "e+" のいずれかを選択してください。',
			    spinDeltaIsOfTypeNumber: "異なる spinDelta タイプが必要です。正の数を入力してください。",
			    spinDeltaCouldntBeNegative: "指定した spinDelta オプションは負数にできません。正の数を入力してください。",
			    spinDeltaContainsExceedsMaxDecimals: "spinDelta に使用可能な最大フラクションは {0} に設定されています。MaxDecimals を変更するか値を小さくしてください。",
			    spinDeltaIncorrectFloatingPoint: '浮動小数点 spinDelta に異なる構成を使用してください。エディターの dataMode を "double" または "float" に設定するか、spinDelta を integer に設定してください。',
			    notEditableOptionByInit: "このオプションは初期化の後は編集できません。値は初期化後に設定してください。",
			    numericEditorNoSuchMethod: "数値エディターはこのメソッドをサポートしません。",
			    numericEditorNoSuchOption: "数値エディターはこのオプションをサポートしません。",
			    displayFactorIsOfTypeNumber: "displayFactor に異なる値を使用してください。値は数値として 1 または 100 に設定する必要があります。",
			    displayFactorAllowedValue: "displayFactor に異なる値を使用してください。値は数値として 1 または 100 に設定する必要があります。",
			    instantiateCheckBoxErrMsg: "igCheckboxEditor を指定した要素にインスタンス化できません。INPUT、SPAN、または DIV 要素を使用してください。",
			    cannotParseNonBoolValue: "igCheckboxEditor には異なる値を使用してください。ブール値を使用してください。",
			    cannotSetNonBoolValue: "igCheckboxEditor には異なる値を使用してください。ブール値を使用してください。",
			    maskEditorNoSuchMethod: "マスク エディターはこのメソッドをサポートしません。",
			    datePickerEditorNoSuchMethod: "日付エディターはこのメソッドをサポートしません。",
			    datePickerNoSuchMethodDropDownContainer: "日付エディターはこのメソッドをサポートしません。'getCalendar' メソッドを使用してください。",
			    buttonTypeIsDropDownOnly: "Datepicker の buttonType オプションの有効な値は dropdown および clear 値のみです。",
			    dateEditorMinValue: "MinValue オプションはランタイムに設定できません。",
			    dateEditorMaxValue: "MaxValue オプションはランタイムに設定できません。",
			    cannotSetRuntime: "このオプションはランタイムに設定できません。",
			    invalidDate: "無効な日付",
			    maskMessage: 'すべての必須文字を入力してください',
			    dateMessage: '有効な日付を入力してください',
			    centuryThresholdValidValues: "centuryThreshold プロパティは 0 ~ 99 である必要があります。値はデフォルトに戻されました。",
			    noListItemsNoButton: "リスト項目がないため、スピンまたはドロップダウン ボタンは描画されません。"
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
		        noSuchWidget: "{featureName} は認識されませんでした。その機能が存在し、スペルミスがないことを確認してください。",
		        autoGenerateColumnsNoRecords: "autoGenerateColumns は有効ですが、データ ソースにレコードがありません。列を決定するには、レコードを持つデータ ソースを読み込んでください。",
		        optionChangeNotSupported: "{optionName} は初期化後に編集できません。値は初期化後に設定してください。 ",
		        optionChangeNotScrollingGrid: "{optionName} を初期化後に編集できません。グリッドが初めにスクロールしないため、完全に再描画する必要があります。このオプションを初期化で設定してください。",
		        widthChangeFromPixelsToPercentagesNotSupported: "グリッドの width オプションをピクセルからパーセンテージへ動的に変更できません。",
		        widthChangeFromPercentagesToPixelsNotSupported: "グリッドの width オプションをパーセンテージからピクセルへ動的に変更できません。",
		        noPrimaryKeyDefined: "グリッドに primaryKey が定義されていません。GridEditing などの機能を使用するには、primaryKey を構成してください。",
		        indexOutOfRange: "指定した行インデックスが範囲外です。{0} および {max} の間の行インデックスを提供してください。",
		        noSuchColumnDefined: "指定した列キーは有効ではありません。定義されたグリッド列のキーと一致する列キーを提供してください。",
		        columnIndexOutOfRange: "指定した列インデックスが範囲外です。{0} および {max} の間の列インデックスを入力してください。",
		        recordNotFound: "ID {id} のレコードがデータ ビューで見つかりませんでした。検索で ID が使用されることを確認し、必要に応じて変更してください。",
		        columnNotFound: "キー {key} の列が見つかりませんでした。検索でキーが使用されることを確認し、必要に応じて変更してください。",
			    colPrefix: "列 ",
			    columnVirtualizationRequiresWidth: "仮想化および columnVirtualization にグリッドの幅または列の幅を設定してください。グリッドの幅、defaultColumnWidth、または各列の幅に値を入力してください。",
			    virtualizationRequiresHeight: "仮想化のグリッドの高さを設定してください。グリッドの高さに値を入力してください。",
			    colVirtualizationDenied: "columnVirtualization に異なる virtualizationMode 設定を使用してください。virtualizationMode は 'fixed' に設定してください。",
			    noColumnsButAutoGenerateTrue: "autoGenerateColumns は無効で、グリッドに列が定義されていません。autoGenerateColumns を有効にするか、手動的に列を指定してください。",
			    noPrimaryKey: "igHierarchicalGrid に primaryKey を定義してください。グリッドの primaryKey オプションを構成してください。",
			    templatingEnabledButNoTemplate: "jQueryTemplating の有効化は、テンプレートを定義してください。テンプレートは rowTemplate オプションで設定してください。",
			    expandTooltip: "行の展開",
			    collapseTooltip: "行の縮小",
			    featureChooserTooltip: "機能セレクター",
			    movingNotAllowedOrIncompatible: "指定した列は移動できません。列が存在し、その終了位置が列のレイアウトを崩さないかを確認してください。",
			    allColumnsHiddenOnInitialization: "すべての列を初期化で非表示にすることはできません。少なくとも 1 列は表示するよう設定してしてください。",
			    virtualizationNotSupportedWithAutoSizeCols: "仮想化には '*' 以外の列幅を設定してください。列幅をピクセル単位の数値で設定してください。",
			    columnVirtualizationNotSupportedWithPercentageWidth: "仮想化には '*' 以外の列幅を設定してください。列幅をピクセル単位の数値で設定してください。",
			    mixedWidthsNotSupported: "すべての列の幅は同じ方法で設定します。すべての列幅をパーセンテージまたはピクセル数で設定します。",
			    multiRowLayoutColumnError: "{key1} のキーを持つ列を複数行レイアウトに追加できません。レイアウトの指定した位置に {key2} のキーを持つ列は配置されています。",
			    multiRowLayoutNotComplete: "複数行レイアウトは完了ではありません。列定義は、空スペースを持つレイアウトを作成するため、正しく描画できません。",
			    multiRowLayoutMixedWidths: "混合幅 (パーセンテージおよびピクセル単位) は複数行レイアウトでサポートされていません。すべての列幅をピクセル単位またはパーセンテージで定義してください。 ",
			    scrollableGridAreaNotVisible: "固定ヘッダーおよび固定フッター領域は利用可能なグリッドの高さより大きくなります。スクロール可能な領域が表示されていません。グリッドの高さをより大きく設定してください。"
		    }
	    });

	    $.ig.GridFiltering = $.ig.GridFiltering || {};

	    $.extend($.ig.GridFiltering, {

		    locale: {
			    startsWithNullText: "～で始まる",
			    endsWithNullText: "～で終わる",
			    containsNullText: "～を含む",
			    doesNotContainNullText: "～を含まない",
			    equalsNullText: "～に等しい",
			    doesNotEqualNullText: "～に等しくない",
			    greaterThanNullText: "～より大きい",
			    lessThanNullText: "～より小さい",
			    greaterThanOrEqualToNullText: "以上",
			    lessThanOrEqualToNullText: "以下",
			    onNullText: "指定日",
			    notOnNullText: "指定日以外",
			    afterNullText: "～の後",
			    beforeNullText: "～の前",
			    emptyNullText: "空",
			    notEmptyNullText: "空以外",
			    nullNullText: "null 値",
			    notNullNullText: "null 値以外",
			    startsWithLabel: "～で始まる",
			    endsWithLabel: "～で終わる",
			    containsLabel: "～を含む",
			    doesNotContainLabel: "～を含まない",
			    equalsLabel: "～に等しい",
			    doesNotEqualLabel: "～に等しくない",
			    greaterThanLabel: "～より大きい",
			    lessThanLabel: "～より小さい",
			    greaterThanOrEqualToLabel: "以上",
			    lessThanOrEqualToLabel: "以下",
			    trueLabel: "True",
			    falseLabel: "False",
			    afterLabel: "～の後",
			    beforeLabel: "～の前",
			    todayLabel: "今日",
			    yesterdayLabel: "昨日",
			    thisMonthLabel: "今月",
			    lastMonthLabel: "先月",
			    nextMonthLabel: "翌月",
			    thisYearLabel: "今年",
			    lastYearLabel: "昨年",
			    nextYearLabel: "来年",
			    clearLabel: "フィルターをクリア",
			    noFilterLabel: "なし",
			    onLabel: "指定日",
			    notOnLabel: "指定日以外",
			    advancedButtonLabel: "詳細",
			    filterDialogCaptionLabel: "高度なフィルター",
			    filterDialogConditionLabel1: "以下の条件の",
			    filterDialogConditionLabel2: "と一致するレコードを表示",
			    filterDialogConditionDropDownLabel: "フィルター条件",
			    filterDialogOkLabel: "OK",
			    filterDialogCancelLabel: "キャンセル",
			    filterDialogAnyLabel: "いずれか",
			    filterDialogAllLabel: "すべて",
			    filterDialogAddLabel: "追加",
			    filterDialogErrorLabel: "サポートされるフィルター数の最大値に達しました。",
			    filterDialogCloseLabel: "フィルター ダイアログを閉じる",
			    filterSummaryTitleLabel: "検索結果",
			    filterSummaryTemplate: "一致するレコード: ${matches}",
			    filterDialogClearAllLabel: "すべてクリア",
			    tooltipTemplate: "適用済みのフィルター: ${condition}",
			    featureChooserText: "フィルターの非表示",
			    featureChooserTextHide: "フィルターの表示",
			    featureChooserTextAdvancedFilter: "フィルター",
			    virtualizationSimpleFilteringNotAllowed: "ColumnVirtualization には他のフィルター タイプを設定してください。フィルター モードを 'advanced' に設定、または advancedModeEditorsVisible を無効にしてください。",
			    multiRowLayoutSimpleFilteringNotAllowed: "複数行レイアウトには他のフィルター タイプを設定してください。フィルター モードを 'advanced' に設定してください。",
			    featureChooserNotReferenced: "FeatureChooser への参照がありません。プロジェクトに infragistics.ui.grid.featurechooser.js を含めるか、ローダーまたは結合スクリプト ファイルを使用してください。",
			    conditionListLengthCannotBeZero: "columnSettings の conditionList 配列が空です。conditionList に適切な配列を使用してください。",
			    conditionNotValidForColumnType: "条件 '{0}' は現在の構成に有効ではありません。{1} 列タイプに適切な条件で置き換えてください。",
			    defaultConditionContainsInvalidCondition: "'{0}' 列の defaultExpression に無効な条件が含まれています。{0} 列タイプに適切な条件で置き換えてください。"
		    }
	    });

	    $.ig.GridGroupBy = $.ig.GridGroupBy || {};

	    $.extend($.ig.GridGroupBy, {

		    locale: {
			    emptyGroupByAreaContent: "グループ化するには、列をここへドラッグするか、{0}します。",
			    emptyGroupByAreaContentSelectColumns: "列を選択",
			    emptyGroupByAreaContentSelectColumnsCaption: "列を選択",
			    expandTooltip: "グループ化された行を展開する",
			    collapseTooltip: "グループ化された行を縮小する",
			    removeButtonTooltip: "列のグループ化を解除する",
			    modalDialogCaptionButtonDesc: "昇順に並べ替え",
			    modalDialogCaptionButtonAsc: "降順に並べ替え",
			    modalDialogCaptionButtonUngroup: "グループ化解除",
			    modalDialogGroupByButtonText: "グループ化",
			    modalDialogCaptionText: 'グループ化に追加する',
			    modalDialogDropDownLabel: '表示: ',
			    modalDialogClearAllButtonLabel: 'すべてクリア',
			    modalDialogRootLevelHierarchicalGrid: 'ルート',
			    modalDialogDropDownButtonCaption: "表示／非表示",
			    modalDialogButtonApplyText: '適用',
			    modalDialogButtonCancelText: 'キャンセル',
			    fixedVirualizationNotSupported: 'GroupBy に他の仮想化設定を使用してください。virtualizationMode は "continuous" に設定してください。',
			    summaryRowTitle: 'グループ化された集計行'
		    }
	    });

	    $.ig.GridHiding = $.ig.GridHiding || {};

	    $.extend($.ig.GridHiding, {
		    locale: {
			    columnChooserDisplayText: "列の選択",
			    hiddenColumnIndicatorTooltipText: "非表示列",
			    columnHideText: "非表示",
			    columnChooserCaptionLabel: "列の選択",
			    columnChooserCheckboxesHeader: "ビュー",
			    columnChooserColumnsHeader: "列",
			    columnChooserCloseButtonTooltip: "閉じる",
			    hideColumnIconTooltip: "非表示",
			    featureChooserNotReferenced: "FeatureChooser への参照がありません。プロジェクトに infragistics.ui.grid.featurechooser.js を含めるか、結合スクリプト ファイルのいずれかを使用してください。",
			    columnChooserShowText: "表示",
			    columnChooserHideText: "非表示",
			    columnChooserResetButtonLabel: "リセット",
			    columnChooserButtonApplyText: '適用',
			    columnChooserButtonCancelText: 'キャンセル'
		    }
	    });

		$.ig.GridResizing = $.ig.GridResizing || {};

		$.extend($.ig.GridResizing, {
			locale: {
			    noSuchVisibleColumn: "指定したキーの表示列はありません。showColumn() メソッドは、サイズ変更する前の列に使用してください。",
			    resizingAndFixedVirtualizationNotSupported: "列のサイズ変更に異なる仮想化設定が必要です。rowVirtualization を使用し、virtualizationMode を continuous に設定してください。 "
			}
		});

	    $.ig.GridPaging = $.ig.GridPaging || {};

	    $.extend($.ig.GridPaging, {

		    locale: {
			    pageSizeDropDownLabel: "表示: ",
			    pageSizeDropDownTrailingLabel: "レコード",
			    //pageSizeDropDownTemplate: "${dropdown} レコードの表示",
			    nextPageLabelText: "次へ",
			    prevPageLabelText: "前へ",
			    firstPageLabelText: "",
			    lastPageLabelText: "",
			    currentPageDropDownLeadingLabel: "ページ",
			    currentPageDropDownTrailingLabel: " / ${count}",
			    //currentPageDropDownTemplate: "ページ ${dropdown} / ${count}",
			    currentPageDropDownTooltip: "ページ インデックスの選択",
			    pageSizeDropDownTooltip: "ページのレコード数の選択",
			    pagerRecordsLabelTooltip: "現在のレコード範囲",
			    prevPageTooltip: "前のページ",
			    nextPageTooltip: "次のページ",
			    firstPageTooltip: "最初のページ",
			    lastPageTooltip: "最後のページ",
			    pageTooltipFormat: "ページ ${index}",
			    pagerRecordsLabelTemplate: "${startRecord} - ${endRecord} / ${recordCount} レコード",
			    invalidPageIndex: "指定したページ インデックスが無効です。0 以上およびページ総数未満のページ インデックスを使用してください。"
		    }
	    });

    $.ig.GridSelection = $.ig.GridSelection || {};

    $.extend($.ig.GridSelection, {
        locale: {
            persistenceImpossible: "選択の永続化に異なる構成を使用してください。グリッドの primaryKey オプションを構成してください。"
        }
    });

	    $.ig.GridRowSelectors = $.ig.GridRowSelectors || {};

	    $.extend($.ig.GridRowSelectors, {

		    locale: {
		        selectionNotLoaded: "igGridSelection は初期化されていません。選択をグリッドで有効にしてください。",
		        columnVirtualizationEnabled: "RowSelectors に異なる仮想化設定を使用してください。rowVirtualization を使用し、virtualizationMode を continuous に設定してください。",
		        selectedRecordsText: "${checked} レコードを選択しました。",
		        deselectedRecordsText: "${unchecked} レコードを選択解除しました。",
		        selectAllText: "${totalRecordsCount} レコードをすべて選択",
		        deselectAllText: "${totalRecordsCount} レコードをすべて選択解除",
		        requireSelectionWithCheckboxes: "チェックボックスが有効な場合、選択動作が必要です。"
		    }
	    });

	    $.ig.GridSorting = $.ig.GridSorting || {};

	    $.extend($.ig.GridSorting, {

		    locale: {
			    sortedColumnTooltipFormat: '${direction}で並べ替え済み',
			    unsortedColumnTooltip: '列の並べ替え',
			    ascending: '昇順',
			    descending: '降順',
			    modalDialogSortByButtonText: '並べ替える',
			    modalDialogResetButton: "リセット",
			    modalDialogCaptionButtonDesc: "クリックして降順に並べ替える",
			    modalDialogCaptionButtonAsc: "クリックして昇順に並べ替える",
			    modalDialogCaptionButtonUnsort: "クリックして並べ替えを解除する",
			    featureChooserText: "並べ替え",
			    modalDialogCaptionText: "複数列の並べ替え",
			    modalDialogButtonApplyText: '適用',
			    modalDialogButtonCancelText: 'キャンセル',
			    sortingHiddenColumnNotSupport: '指定した列が非表示のため並べ替えできません。並べ替えの前に showColumn() メソッドを使用してください。',
			    featureChooserSortAsc: '昇順',
			    featureChooserSortDesc: '降順'
			    //modalDialogButtonSlideCaption: "クリックして並べ替えた列の表示状態を切り替える"
		    }
	    });

	    $.ig.GridSummaries = $.ig.GridSummaries || {};

	    $.extend($.ig.GridSummaries, {
		    locale: {
			    featureChooserText: "集計非表示",
			    featureChooserTextHide: "集計の表示",
			    dialogButtonOKText: 'OK',
			    dialogButtonCancelText: 'キャンセル',
			    emptyCellText: '',
			    summariesHeaderButtonTooltip: '集計の表示/非表示',
			    defaultSummaryRowDisplayLabelCount: 'カウント',
			    defaultSummaryRowDisplayLabelMin: '最小値',
			    defaultSummaryRowDisplayLabelMax: '最大値',
			    defaultSummaryRowDisplayLabelSum: '合計',
			    defaultSummaryRowDisplayLabelAvg: '平均',
			    defaultSummaryRowDisplayLabelCustom: 'カスタム',
			    calculateSummaryColumnKeyNotSpecified: "列キーがありません。集計の計算に列キーを指定してください。",
			    featureChooserNotReferenced: "FeatureChooser への参照がありません。プロジェクトに infragistics.ui.grid.featurechooser.js を含めるか、結合スクリプト ファイルのいずれかを使用してください。"
		    }
	    });

	    $.ig.GridUpdating = $.ig.GridUpdating || {};

	    $.extend($.ig.GridUpdating, {
		    locale: {
			    doneLabel: 'OK',
			    doneTooltip: '編集を終了して更新します',
			    cancelLabel: 'キャンセル',
			    cancelTooltip: '更新せずに編集を終了します',
			    addRowLabel: '新規行の追加',
			    addRowTooltip: '新しい行を追加',
			    deleteRowLabel: '行の削除',
			    deleteRowTooltip: '行の削除',
			    igTextEditorException: 'グリッドの文字列型の列を更新できません。最初に ui.igTextEditor を読み込んでください。',
			    igNumericEditorException: 'グリッドの数値型の列を更新できません。最初に ui.igNumericEditor を読み込んでください。',
			    igCheckboxEditorException: 'グリッドのチェックボックス型の列を更新できません。最初に ui.igCheckboxEditor を読み込んでください。',
			    igCurrencyEditorException: 'グリッドの通貨書式の数値型の列を更新できません。最初に ui.igCurrencyEditor を読み込んでください。',
			    igPercentEditorException: 'グリッドのパーセンテージ書式の数値型の列を更新できません。最初に ui.igPercentEditor を読み込んでください。',
			    igDateEditorException: 'グリッドの日付型の列を更新できません。最初に ui.igDateEditor を読み込んでください。',
			    igDatePickerException: 'グリッドの日付型の列を更新できません。最初に ui.igDatePicker を読み込んでください。',
			    igComboException: 'グリッドにコンボを使用できません。最初に ui.igCombo を読み込んでください。',
			    igRatingException: 'グリッドにエディターとして igRating を使用できません。最初に ui.igRating を読み込んでください。',
			    igValidatorException: 'igGridUpdating で定義されるオプションと検証をサポートできません。最初に ui.igValidator を読み込んでください。',
			    editorTypeCannotBeDetermined: '更新操作には異なる構成が必要です。グリッドの primaryKey オプションを構成してください。',
			    noPrimaryKeyException: '更新操作には異なる構成が必要です。グリッドの primaryKey オプションを構成してください。',
			    hiddenColumnValidationException: '非表示の列および有効にした検証の行を編集できません。行編集の前に showColumn() メソッドを使用するか列の検証を無効にしてください。',
			    dataDirtyException: 'グリッドに保留中のトランザクションがあるため、データの描画に影響する可能性があります。igGrid の autoCommit オプションを有効にするか、dataDirty イベントで false を返す処理をしてください。このイベントの処理中にオプションで commit() メソッドを呼び出すこともできます。',
			    recordOrPropertyNotFoundException: '指定したレコードまたはプロパティが見つかりませんでした。検索の条件を確認して必要に応じて調整してください。',
			rowEditDialogCaptionLabel: '行データの編集',
			excelNavigationNotSupportedWithCurrentEditMode: "ExcelNavigation に異なる構成を使用してください。editMode は cell または row に設定してください。",
			columnNotFound: "指定した列キーが表示列コレクションで見つからないか、指定したインデックスが範囲外です。",
			rowOrColumnSpecifiedOutOfView: "行または列が表示範囲外のため、指定した行または列の編集を開始できません。行または列がその他のページにあるか、その他の仮想化フレームにあります。",
			editingInProgress: "行またはセルは現在編集中です。他の更新プロシージャは、現在の編集が終了するまで開始できません。",
			undefinedCellValue: 'undefined はセルの値に設定できません。',
			addChildTooltip: '子行の追加',
			multiRowGridNotSupportedWithCurrentEditMode: "グリッドで複数行レイアウトが有効の場合、ダイアログ編集モードのみサポートされます。"
		    }
	    });

        $.ig.ColumnMoving = $.ig.ColumnMoving || {};

        $.extend($.ig.ColumnMoving, {
            locale: {
                movingDialogButtonApplyText: '適用',
                movingDialogButtonCancelText: 'キャンセル',
                movingDialogCaptionButtonDesc: '下へ移動',
                movingDialogCaptionButtonAsc: '上へ移動',
                movingDialogCaptionText: '列の移動',
                movingDialogDisplayText: '列の移動',
                movingDialogDropTooltipText: "ここへ移動",
                movingDialogCloseButtonTitle: '「列の移動」ダイアログを閉じる',
                dropDownMoveLeftText: '左へ移動',
                dropDownMoveRightText: '右へ移動',
                dropDownMoveFirstText: '最初へ移動',
                dropDownMoveLastText: '最後へ移動',
                featureChooserNotReferenced: "FeatureChooser への参照がありません。プロジェクトに infragistics.ui.grid.featurechooser.js を含めるか、結合スクリプト ファイルのいずれかを使用してください。",
                movingToolTipMove: '移動',
                featureChooserSubmenuText: '移動'
            }
        });

        $.ig.ColumnFixing = $.ig.ColumnFixing || {};

        $.extend($.ig.ColumnFixing, {
            locale: {
                headerFixButtonText: 'この列を固定',
                headerUnfixButtonText: 'この列の固定解除',
                featureChooserTextFixedColumn: '列の固定',
                featureChooserTextUnfixedColumn: '列の固定解除',
                groupByNotSupported: 'ColumnFixing に異なる構成を使用してください。GroupBy 機能を無効にしてください。',
                virtualizationNotSupported: 'ColumnFixing の仮想化設定に rowVirtualization を使用してください。',
                columnVirtualizationNotSupported: 'ColumnFixing の仮想化設定で columnVirtualization を無効にしてください。',
                columnMovingNotSupported: 'ColumnFixing に異なる構成を使用してください。ColumnMoving を無効にしてください。',
                hidingNotSupported: 'ColumnFixing に異なる構成を使用してください。Hiding 機能を無効にしてください。',
                hierarchicalGridNotSupported: 'igHierarchicalGrid で ColumnFixing はサポートされません。ColumnFixing を無効にしてください。',
                responsiveNotSupported: 'ColumnFixing に異なる構成を使用してください。Responsive 機能を無効にしてください。',
                noGridWidthNotSupported: '列固定に他の構成を使用してください。グリッド幅にパーセンテージまたはピクセル単位の数値を設定してください。',
                gridHeightInPercentageNotSupported: '列固定に他の構成を使用してください。グリッドの高さはピクセルで設定してください。',
                defaultColumnWidthInPercentageNotSupported: "ColumnFixing に異なる構成を使用してください。デフォルトの列幅はピクセル単位の数値で設定してください。",
                columnsWidthShouldBeSetInPixels: 'ColumnFixing の列幅を変更してください。キー {key} のある列幅はピクセルで設定してください。',
                unboundColumnsNotSupported: 'ColumnFixing に異なる構成を使用してください。UnboundColumns を無効にしてください。',
                excelNavigationNotSupportedWithCurrentEditMode: "ExcelNavigation に異なる構成を使用してください。editMode は cell または row に設定してください。",
                initialFixingNotApplied: '初期化の固定設定を {0} キーの列に適用できませんでした。理由: {1}', // {0} is placeholder for columnKey, {1} error message
                setOptionGridWidthException: 'グリッドの幅の値が無効です。固定列がある場合、固定されていない列の表示可能な領域の幅を minimalVisibleAreaWidth の値以上に設定する必要があります。',
                internalErrors: {
                    none: 'グリッドが正しく構成されました。',
                    notValidIdentifier: '指定した列キーは有効ではありません。定義済みグリッド列のいずれかのキーと一致する列キーを使用してください。',
                    fixingRefused: 'この列の固定は現在サポートされていません。他の表示列の固定解除または非表示の固定解除列で最初に showColumn() メソッドを使用してください。 ',
                    fixingRefusedMinVisibleAreaWidth: 'この列は固定できません。グリッドの幅が列を固定するための利用可能なスペースを超えています。',
                    alreadyHidden: 'この列の固定または固定解除は現在できません。showColumn() メソッドは、最初に列に使用してください。',
                    alreadyUnfixed: 'この列はすでに固定解除されています。',
                    alreadyFixed: 'この列はすでに固定されています。',
                    unfixingRefused: '現在この列の固定解除はできません。showColumn() メソッドは、最初に非表示の固定列に使用してください。',
                    targetNotFound: 'キー {key} のあるターゲット列がありません。検索でキーが使用されることを確認し、必要に応じて変更してください。'
                }
            }
        });

    $.ig.GridAppendRowsOnDemand = $.ig.GridAppendRowsOnDemand || {};

    $.extend($.ig.GridAppendRowsOnDemand, {
    	    locale: {
    	        loadMoreDataButtonText: 'その他のデータを読み込む',
    	        appendRowsOnDemandRequiresHeight: 'AppendRowsOnDemand に他の構成を使用してください。グリッドの高さを設定してください。',
    	        groupByNotSupported: 'AppendRowsOnDemand に他の構成を使用してください。GroupBy を無効にしてください。',
    	        pagingNotSupported: 'AppendRowsOnDemand に他の構成を使用してください。ページングを無効にしてください。',
    	        cellMergingNotSupported: 'AppendRowsOnDemand に他の構成を使用してください。CellMerging を無効にしてください。',
    	        virtualizationNotSupported: 'AppendRowsOnDemand に他の構成を使用してください。仮想化を無効にしてください。'
    	    }
        });


    $.ig.igGridResponsive = $.ig.igGridResponsive || {};

    $.extend($.ig.igGridResponsive, {
    	locale: {
    	    fixedVirualizationNotSupported: 'レスポンシブ機能の仮想化設定で virtualizationMode を continuous に設定してください。'
    	}
    });

    $.ig.igGridMultiColumnHeaders = $.ig.igGridMultiColumnHeaders || {};

    $.extend($.ig.igGridMultiColumnHeaders, {
    	locale: {
    	    multiColumnHeadersNotSupportedWithColumnVirtualization: '複数列ヘッダーの構成で columnVirtualization を無効にしてください。'
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
			boldButtonTitle: '太字',
			italicButtonTitle: 'イタリック',
			underlineButtonTitle: '下線',
			strikethroughButtonTitle: '取り消し線',
			increaseFontSizeButtonTitle: 'フォント サイズを大きくする',
			decreaseFontSizeButtonTitle: 'フォント サイズを小さくする',
			alignTextLeftButtonTitle: '文字列を左に揃える',
			alignTextRightButtonTitle: '文字列を右に揃える',
			alignTextCenterButtonTitle: '中央揃え',
			justifyButtonTitle: '両端揃え',
			bulletsButtonTitle: '箇条書き',
			numberingButtonTitle: '段落番号',
			decreaseIndentButtonTitle: 'インデントを減らす',
			increaseIndentButtonTitle: 'インデントを増やす',
			insertPictureButtonTitle: '画像を挿入する',
			fontColorButtonTitle: 'フォント色',
			textHighlightButtonTitle: '強調表示色',
			insertLinkButtonTitle: 'ハイパーリンクを挿入する',
			insertTableButtonTitle: '表',
			addRowButtonTitle: '行を追加する',
			removeRowButtonTitle: '行を削除する',
			addColumnButtonTitle: '列を追加する',
			removeColumnButtonTitle: '列を削除する',
			inserHRButtonTitle: '横罫線を挿入する',
			viewSourceButtonTitle: 'ソースを表示する',
			cutButtonTitle: '切り取り',
			copyButtonTitle: 'コピー',
			pasteButtonTitle: '貼り付け',
			undoButtonTitle: '元に戻す',
			redoButtonTitle: 'やり直し',
			imageUrlDialogText: '画像 URL:',
			imageAlternativeTextDialogText: '代替テキスト:',
			imageWidthDialogText: '画像の幅:',
			imageHeihgtDialogText: '画像の高さ:',
			linkNavigateToUrlDialogText: 'URL:',
			linkDisplayTextDialogText: '表示テキスト:',
			linkOpenInDialogText: 'ウィンドウ オプション:',
			linkTargetNewWindowDialogText: '新しいウィンドウで開く',
			linkTargetSameWindowDialogText: 'このウィンドウで開く',
			linkTargetParentWindowDialogText: '親ウィンドウで開く',
			linkTargetTopmostWindowDialogText: '最上位のウィンドウで開く',
			applyButtonTitle: '適用',
			cancelButtonTitle: 'キャンセル',
			defaultToolbars: {
			    textToolbar: "テキスト操作ツールバー",
			    formattingToolbar: "テキスト書式設定ツールバー",
			    insertObjectToolbar: "オブジェクト挿入ツールバー",
			    copyPasteToolbar: "コピー/貼り付けツールバー"
			},
			fontNames: {
				win: [
                    { text: "メイリオ", value: "Meiryo" },
                    { text: "MSゴシック", value: "MS Gothic" },
                    { text: "MS明朝", value: "MS Mincho" },
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
				{ text: "h1", value: "見出し 1" },
				{ text: "h2", value: "見出し 2" },
				{ text: "h3", value: "見出し 3" },
				{ text: "h4", value: "見出し 4" },
				{ text: "h5", value: "見出し 5" },
				{ text: "h6", value: "見出し 6" },
                { text: "p", value: "標準" }
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
		    successMsg: "成功",
		    errorMsg: "エラー",
		    warningMsg: "警告"
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
                invalidDataSource: "渡されたデータ ソースが null 値またはサポートされていません。",
                measureList: "メジャー",
                ok: "OK",
                cancel: "キャンセル",
                addToMeasures: "メジャーに追加",
                addToFilters: "フィルターに追加",
                addToColumns: "列に追加",
                addToRows: "行に追加"
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
                invalidBaseElement: " はベース要素としてサポートされていません。代わりに DIV を使用してください。",
                catalog: "カタログ",
                cube: "キューブ",
                measureGroup: "メジャー グループ",
                measureGroupAll: "(すべて)",
                rows: "行",
                columns: "列",
                measures: "メジャー",
                filters: "フィルター",
                deferUpdate: "更新を遅延する",
                updateLayout: "レイアウトの更新",
                selectAll: "すべて選択"
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
                filtersHeader: "フィルター フィールドをここにドロップ",
                measuresHeader: "データ項目をここにドロップ",
                rowsHeader: "行フィールドをここにドロップ",
                columnsHeader: "列フィールドをここにドロップ",
                disabledFiltersHeader: "フィルター フィールド",
                disabledMeasuresHeader: "データ項目",
                disabledRowsHeader: "行フィールド",
                disabledColumnsHeader: "列フィールド",
                noSuchAxis: "指定した軸はありません。"
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
			popoverOptionChangeNotSupported: "igPopover が初期化された後のこのオプションの変更はサポートされません:",
			popoverShowMethodWithoutTarget: "selectors オプションが使用される場合、show 関数の target パラメーターは必要です。"
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
			    setOptionError: '次のオプションはランタイムで変更できません: '
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
		    errorPanels: 'パネルの最大数は 2 です。',
		    errorSettingOption: 'オプションの設定でエラーが発生しました。'
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
		    renderDataError: "データが正しく取得されないか、解析されませんでした。",
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
			collapseButtonTitle: '縮小:',
			expandButtonTitle: '展開:'
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
			    invalidArgumentType: '提供された引数のタイプは無効です。',
			    errorOnRequest: 'データを取得するときにエラーが発生しました: ',
			    noDataSourceUrl: 'igTree コントロールは、その URL にデータの要求を送信するために dataSourceUrl を提供する必要があります。',
			    incorrectPath: '指定したパスにノードが見つかりませんでした: ',
			    incorrectNodeObject: '指定した引数は jQuery ノード要素ではありません。',
			    setOptionError: '次のオプションはランタイムで変更できません: ',
			    moveTo: '{0} <strong>へ移動</strong>',
			    moveBetween: '{0} および {1} <strong>の間へ移動</strong>',
			    moveAfter: '{0} <strong>の後へ移動</strong>',
			    moveBefore: '{0} <strong>の前へ移動</strong>',
			    copyTo: '{0} <strong>へコピー</strong>',
			    copyBetween: '{0} および {1} <strong>の間へコピー</strong>',
			    copyAfter: '{0} <strong>の後へコピー</strong>',
			    copyBefore: '{0} <strong>の前へコピー</strong>',
			    and: 'および'
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
				fixedVirtualizationNotSupported: 'RowVirtualization に異なる virtualizationMode 設定を使用してください。virtualizationMode を "continuous" に設定してください。'
			}
		});

		$.ig.TreeGridPaging = $.ig.TreeGridPaging || {};

		$.extend($.ig.TreeGridPaging, {
			locale: {
				contextRowLoadingText: "読み込んでいます",
				contextRowRootText: "ルート",
				columnFixingWithContextRowNotSupported: "ColumnFixing に異なる contextRowMode 設定を使用してください。contextRowMode で ColumnFixing を有効にするために none に設定してください。"
			}
		});

		$.ig.TreeGridFiltering = $.ig.TreeGridFiltering || {};

		$.extend($.ig.TreeGridFiltering, {
			locale: {
				filterSummaryInPagerTemplate: "一致するレコード ${currentPageMatches} / ${totalMatches}"
			}
		});

		$.ig.TreeGridRowSelectors = $.ig.TreeGridRowSelectors || {};

		$.extend($.ig.TreeGridRowSelectors, {
			locale: {
			    multipleSelectionWithTriStateCheckboxesNotSupported: "複数セクションに他の checkBoxMode 設定を使用してください。checkBoxMode の複数セクションを有効にするために biState に設定してください。"
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
			    labelUploadButton: "ファイルのアップロード",
			    labelAddButton: "追加",
			    labelClearAllButton: "すべてクリア",
			    labelSummaryTemplate: "{0} / {1} ファイルがアップロードされました",
			    labelSummaryProgressBarTemplate: "{0} / {1}",
			    labelShowDetails: "詳細の表示",
			    labelHideDetails: "詳細の非表示",
			    labelSummaryProgressButtonCancel: "キャンセル",
			    labelSummaryProgressButtonContinue: "アップロード",
			    labelSummaryProgressButtonDone: "完了",
			    labelProgressBarFileNameContinue: "...",

			    //error messages
			    errorMessageFileSizeExceeded: "最大ファイル サイズを超えています。",
			    errorMessageGetFileStatus: "現在のファイルの状態を取得できませんでした。接続されていない可能性があります。",
			    errorMessageCancelUpload: "サーバーにアップロードをキャンセルするコマンドを送信できませんでした。接続されていない可能性があります。",
			    errorMessageNoSuchFile: "要求されたファイルが見つかりませんでした。ファイル サイズが大きすぎる可能性があります。",
			    errorMessageOther: "ファイルのアップロードで内部エラーが発生しました。エラー コード : {0}。",
			    errorMessageValidatingFileExtension: "ファイル拡張子の検証が失敗しました。",
			    errorMessageAJAXRequestFileSize: "ファイル サイズの取得中に AJAX エラーが発生しました。",
			    errorMessageMaxUploadedFiles: "アップロードするファイルの最大数を超えました。",
			    errorMessageMaxSimultaneousFiles: "maxSimultaneousFilesUploads の値は無効です。0 より大きい値または null 値に設定する必要があります。",
			    errorMessageTryToRemoveNonExistingFile: "削除する ID {0} のファイルが存在しません。",
			    errorMessageTryToStartNonExistingFile: "開始する ID {0} のファイルが存在しません。",
			    errorMessageDropMultipleFilesWhenSingleModel: "mode が single の場合、2 ファイル以上のドロップは許可されません。",

			    // title attributes
			    titleUploadFileButtonInit: "ファイルのアップロード",
			    titleAddFileButton: "追加",
			    titleCancelUploadButton: "キャンセル",
			    titleSummaryProgressButtonContinue: "アップロード",
			    titleClearUploaded: "すべてクリア",
			    titleShowDetailsButton: "詳細の表示",
			    titleHideDetailsButton: "詳細の非表示",
			    titleSummaryProgressButtonCancel: "キャンセル",
			    titleSummaryProgressButtonDone: "完了",
			    titleSingleUploadButtonContinue: "アップロード",
			    titleClearAllButton: "すべてクリア"
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
		        defaultMessage: "このフィールドは無効です",
		        selectMessage: "値を選択してください",
		        rangeSelectMessage: "{0} 以上で {1} 以下の項目を選択してください。",
		        minSelectMessage: "{0} 項目以上を選択してください",
		        maxSelectMessage: "{0} 項目以下を選択してください",
		        rangeLengthMessage: "入力の長さは {0} ～ {1} の間の文字数である必要があります",
		        minLengthMessage: "入力の長さは少なくとも {0} 文字である必要があります",
		        maxLengthMessage: "入力の長さは {0} 文字以下である必要があります",
			    requiredMessage: "このフィールドは必須フィールドです。",
			    patternMessage: '入力が所定のパターンに一致しません',
			    maskMessage: "すべての必須な文字を入力してください",
			    dateFieldsMessage: "日付のフィールド値を入力してください",
			    invalidDayMessage: "月の有効な日を入力してください",
			    dateMessage: "有効な日付を入力してください",
			    numberMessage: "有効な数値を入力してください",
			    rangeValueMessage: "{0} ~ {1} の値を入力してください",
			    minValueMessage: "{0} 以上の値を入力してください",
			    maxValueMessage: "{0} 以下の値を入力してください",
			    emailMessage: '有効なメール アドレスを入力してください',
			    equalToMessage: '2 つの値は一致しません',
			    optionalString: '(オプション)'
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
			    liveStream: "ライブ ビデオ",
			    live: "ライブ",
			    paused: "一時停止",
			    playing: "再生している",
			    play: '再生',
			    volume: "音量",
			    unsupportedVideoSource: "現在のビデオ ソースにはブラウザーでサポートされる書式が含まれていません。",
			    missingVideoSource: "互換性のあるビデオ ソースがありません。",
			    progressLabelLongFormat: "$currentTime$ / $duration$",
			    progressLabelShortFormat: "$currentTime$",
			    enterFullscreen: "全画面表示の開始",
			    exitFullscreen: "全画面表示の終了",
			    skipTo: "指定の位置に移動",
			    unsupportedBrowser: "現在のブラウザーは HTML5 ビデオをサポートしません。<br/>以下のバージョンにアップグレードしてください。",
			    currentBrowser: "現在のブラウザー: {0}",
			    ie9: "Microsoft Internet Explorer 9+",
			    chrome8: "Google Chrome 8+",
			    firefox36: "Mozilla Firefox 3.6+",
			    safari5: "Apple Safari 5+",
			    opera11: "Opera 11+",
			    ieDownload: "http://www.microsoft.com/japan/windows/internet-explorer/default.aspx",
			    operaDownload: "http://www.opera.com/download/",
			    chromeDownload: "http://www.google.co.jp/chrome/intl/ja/landing_ff.html?hl=ja",
			    firefoxDownload: "http://www.mozilla.com/",
			    safariDownload: "http://www.apple.com/jp/safari/download/",
			    buffering: '読み込んでいます',
			    adMessage: '広告: ビデオは $duration$ 秒後に再開します。', // Use also $timeString$ for MM:SS format.
			    adMessageLong: '広告: ビデオは $duration$ 後に再開します。',
			    adMessageNoDuration: '広告: ビデオはコマーシャルの後に再開します。',
			    adNewWindowTip: '広告: クリックすると、広告コンテンツを新しいウィンドウで開きます。',
			    nonDivException: 'Infragistics HTML5 ビデオ プレーヤーは DIV タグのみにインスタンス化できます。',
			    relatedVideos: '関連ビデオ',
			    replayButton: '再生',
			    replayTooltip: 'クリックすると、前回再生したビデオを再生します'
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
	        zoombarTargetNotSpecified: "igZoombar を有効なターゲットにアタッチする必要があります。",
		    zoombarTypeNotSupported: "ズームバーにアタッチするウィジェット タイプはサポートされません。",
		    optionChangeNotSupported: "igZoombar が作成された後のこのオプションの変更はサポートされません:"
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
			    unsupportedBrowser: "現在のブラウザーは HTML5 ビデオをサポートしません。<br/>以下のバージョンにアップグレードしてください。",
			    currentBrowser: "現在のブラウザー: {0}",
			    ie9: "Microsoft Internet Explorer 9+",
			    chrome8: "Google Chrome 8+",
			    firefox36: "Mozilla Firefox 3.6+",
			    safari5: "Apple Safari 5+",
			    opera11: "Opera 11+",
			    ieDownload: "http://www.microsoft.com/japan/windows/internet-explorer/default.aspx",
			    operaDownload: "http://www.opera.com/download/",
			    chromeDownload: "http://www.google.co.jp/chrome/intl/ja/landing_ff.html?hl=ja",
			    firefoxDownload: "http://www.mozilla.com/",
			    safariDownload: "http://www.apple.com/jp/safari/download/"
		    }
	    });

    }
})(jQuery);

