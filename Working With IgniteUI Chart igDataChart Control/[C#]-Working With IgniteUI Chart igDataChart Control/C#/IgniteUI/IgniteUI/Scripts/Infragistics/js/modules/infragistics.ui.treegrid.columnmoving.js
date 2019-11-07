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
 *	infragistics.ui.grid.columnmoving.js
 */
if(typeof jQuery!=="function"){throw new Error("jQuery is undefined")}(function($){$.widget("ui.igTreeGridColumnMoving",$.ui.igGridColumnMoving,{_create:function(){this.element.data($.ui.igGridColumnMoving.prototype.widgetName,this.element.data($.ui.igTreeGridColumnMoving.prototype.widgetName));$.ui.igGridColumnMoving.prototype._create.apply(this,arguments)},destroy:function(){$.ui.igGridColumnMoving.prototype.destroy.apply(this,arguments);this.element.removeData($.ui.igGridColumnMoving.prototype.widgetName)},_injectGrid:function(grid,isRebind){$.ui.igGridColumnMoving.prototype._injectGrid.apply(this,arguments);this._unregisterEvents();this._registerEvents()},_updateLayout:function(){var cols,self=this,firstRowChanged=false;if(this._colsSave){firstRowChanged=this._colsSave[0].key!==this.grid._visibleColumns()[0].key}if(firstRowChanged&&!this.options.renderExpansionIndicatorColumn){this.grid._renderRecords();if(this.grid.element.data("igTreeGridSorting")){this.grid.element.data("igTreeGridSorting")._initDefaultSettings()}this.grid._fireInternalEvent("_dataRendered")}if(!this._gridReady()){setTimeout(function(){self._updateLayout()},50);return}if(this.grid._oldCols){cols=$.grep(this.grid._oldCols,this.grid._columnVisible)}else{cols=this.grid._visibleColumns()}this._hscroller=this.grid._hscrollbarcontent();this._hscroller=this._hscroller.length>0?this._hscroller:this.grid.scrollContainer();this._cache.columns={};this._cache.siblings={};this._cache.fixedSiblings={};this._updateLayoutPerLevel(cols,true);this._createMovingOptions();delete this._movingDirty},_registerEvents:function(){this.grid.element.bind("igtreegridheadercellrendered",this._headerCellRenderedHandler);this.grid.element.bind("igtreegridheaderrendering",this._headerRenderingHandler);this.grid.element.bind("igtreegridheaderrendered",this._headerRenderedHandler);this.grid.element.bind("igtreegridrendered",this._gridFullyRenderedHandler);this.grid.element.bind("igtreegridresizingcolumnresized",this._columnStateChanged);this.grid.element.bind("igtreegridcolumnscollectionmodified",this._columnStateChanged);this.grid.element.bind("igtreegridpagingpagingdropdownrendered",this._columnStateChanged);this.grid.element.bind("igtreegrid_columnsmoved",this._columnStateChanged)},_unregisterEvents:function(){this.grid.element.unbind("igtreegridheadercellrendered",this._headerCellRenderedHandler);this.grid.element.unbind("igtreegridheaderrendering",this._headerRenderingHandler);this.grid.element.unbind("igtreegridheaderrendered",this._headerRenderedHandler);this.grid.element.unbind("igtreegridrendered",this._gridFullyRenderedHandler);this.grid.element.unbind("igtreegridresizingcolumnresized",this._columnStateChanged);this.grid.element.unbind("igtreegridcolumnscollectionmodified",this._columnStateChanged);this.grid.element.unbind("igtreegridpagingpagingdropdownrendered",this._columnStateChanged);this.grid.element.unbind("igtreegrid_columnsmoved",this._columnStateChanged);this.grid.headersTable().find("th").unbind("moving")}});$.extend($.ui.igTreeGridColumnMoving,{version:"16.1.20161.2052"})})(jQuery);