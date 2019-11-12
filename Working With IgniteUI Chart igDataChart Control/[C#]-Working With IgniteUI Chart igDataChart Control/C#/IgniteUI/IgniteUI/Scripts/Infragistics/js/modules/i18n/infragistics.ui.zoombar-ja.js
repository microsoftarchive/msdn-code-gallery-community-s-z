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