/*!@license
 * Infragistics.Web.ClientUI Tree Grid 16.1.20161.2052
 *
 * Copyright (c) 2011-2016 Infragistics Inc.
 *
 * http://www.infragistics.com/
 *
 * Depends on:
 *	jquery-1.4.4.js
 *	jquery.ui.core.js
 *	jquery.ui.widget.js
 *	infragistics.dataSource.js
 *	infragistics.ui.shared.js
 *	infragistics.ui.treegrid.js
 *	infragistics.util.js
 *	infragistics.ui.grid.framework.js
 *	infragistics.ui.grid.tooltips.js
 */
if(typeof jQuery!=="function"){throw new Error("jQuery is undefined")}(function($){$.widget("ui.igTreeGridTooltips",$.ui.igGridTooltips,{_create:function(){this.element.data($.ui.igGridTooltips.prototype.widgetName,this.element.data($.ui.igTreeGridTooltips.prototype.widgetName));$.ui.igGridTooltips.prototype._create.apply(this,arguments)},_getDataView:function(){return this.grid.dataSource.flatDataView()},_getRowIndex:function(element,row){return element.closest("tbody").children("tr:visible:not([data-container='true'],"+"[data-grouprow='true'],"+"[data-new-row='true'])").index(row)},destroy:function(){$.ui.igGridTooltips.prototype.destroy.apply(this,arguments);this.element.removeData($.ui.igGridTooltips.prototype.widgetName)}});$.extend($.ui.igTreeGridTooltips,{version:"16.1.20161.2052"})})(jQuery);