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
 *	infragistics.ui.grid.resizing.js
 */
if(typeof jQuery!=="function"){throw new Error("jQuery is undefined")}(function($){$.widget("ui.igTreeGridResizing",$.ui.igGridResizing,{css:{},_create:function(){this.element.data($.ui.igGridResizing.prototype.widgetName,this.element.data($.ui.igTreeGridResizing.prototype.widgetName));$.ui.igGridResizing.prototype._create.apply(this,arguments)},destroy:function(){$.ui.igGridResizing.prototype.destroy.apply(this,arguments);this.element.removeData($.ui.igGridResizing.prototype.widgetName)}});$.extend($.ui.igTreeGridResizing,{version:"16.1.20161.2052"})})(jQuery);