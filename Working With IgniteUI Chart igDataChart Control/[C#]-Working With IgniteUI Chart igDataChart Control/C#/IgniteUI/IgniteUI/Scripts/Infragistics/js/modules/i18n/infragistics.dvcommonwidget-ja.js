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