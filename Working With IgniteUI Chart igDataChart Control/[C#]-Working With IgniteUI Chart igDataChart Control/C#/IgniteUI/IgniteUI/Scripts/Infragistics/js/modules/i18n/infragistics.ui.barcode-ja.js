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