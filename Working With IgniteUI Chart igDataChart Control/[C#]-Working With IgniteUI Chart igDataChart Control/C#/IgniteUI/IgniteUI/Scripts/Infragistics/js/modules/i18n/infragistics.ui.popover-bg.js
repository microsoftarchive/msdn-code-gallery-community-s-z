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