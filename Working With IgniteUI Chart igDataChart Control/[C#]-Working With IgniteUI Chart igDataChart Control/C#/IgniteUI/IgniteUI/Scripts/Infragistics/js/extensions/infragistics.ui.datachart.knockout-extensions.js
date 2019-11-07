/*!@license
	* Infragistics.Web.ClientUI igDataChart KnockoutJS extension 16.1.20161.2052
	*
	* Copyright (c) 2011-2016 Infragistics Inc.
	*
	* http://www.infragistics.com/
	*
	* Depends on:
	*  jquery-1.7.*.js
	*	jquery.ui.core.js
	*	jquery.ui.widget.js
	*	infragistics.util.js
	*	infragistics.ui.chart.js
	*	infragistics.dv.core.js
	*	infragistics.chart_piechart.js
	*	infragistics.chart_categorychart.js
	*	infragistics.chart_financialchart.js
	*	infragistics.chart_polarchart.js
	*	infragistics.chart_radialchart.js
	*	infragistics.chart_rangecategorychart.js
	*	infragistics.chart_scatterchart.js
	*	infragistics.dvcommonwidget.js
	*	infragistics.dataSource.js
	*	infragistics.util.js
	*/
(function($){ko.bindingHandlers.igDataChart={init:function(element,valueAccessor){var options=$.extend(true,{},ko.utils.unwrapObservable(valueAccessor())),ds,i,addHandler,deleteHandler,rootItem,current;addHandler=function(data,index){var ds=options.dataSource,rootElem,current;rootElem=$(element).find("#rootElem");current=$("<li><ul></ul></li>");if(index===0){rootElem.prepend(current)}else if(index===ds.length-1){rootElem.append(current)}else{$($(rootElem).children()[index]).before(current)}$(element).igDataChart("notifyInsertItem",options.dataSource,index,data);ko.applyBindingsToNode(current[0],{igDataChartRecord:{value:ds[index],chartInstance:$(element),dataSourceInstance:ds}},ds[i])};deleteHandler=function(data,index){var ds=options.dataSource,rootElem;rootElem=$(element).find("#rootElem");if(index===0){$(rootElem).children().first().remove()}else if(index===ds.length){$(rootElem).children().last().remove()}else{$($(rootElem).children()[index]).remove()}$(element).igDataChart("notifyRemoveItem",options.dataSource,index,data)};if(ko.isObservable(options.dataSource)){ds=options.dataSource();options.dataSource.subscribeArrayChanged(addHandler,deleteHandler);options.dataSource=ko.utils.unwrapObservable(options.dataSource)}else{ds=options.dataSource}if(options.expectFunctions!==true){options.expectFunctions=true}$(element).igDataChart(options);rootItem=$("<ul id='rootElem'></ul>");$("<div style='display: none !important'></div>").appendTo(element).append(rootItem);for(i=0;i<ds.length;i++){current=$("<li><ul></ul></li>");rootItem.append(current);ko.applyBindingsToNode(current[0],{igDataChartRecord:{value:ds[i],chartInstance:$(element),dataSourceInstance:ds}},ds[i])}ko.utils.domNodeDisposal.addDisposeCallback(element,function(){$(element).igDataChart("destroy")})}};ko.bindingHandlers.igDataChartRecord={init:function(element,valueAccessor){var options=valueAccessor(),key,currItem,record=options.value;for(key in record){if(record.hasOwnProperty(key)&&ko.isObservable(record[key])){currItem=$("<li class='property'></li>");$(element).find("ul").append(currItem);ko.applyBindingsToNode(currItem[0],{igDataChartItem:{value:record[key],chartInstance:valueAccessor().chartInstance,dataSourceInstance:valueAccessor().dataSourceInstance}},record[key])}}}};ko.bindingHandlers.igDataChartItem={update:function(element,valueAccessor){var chart,ds,item,index;index=$(element).parent().parent().index();ds=valueAccessor().dataSourceInstance;chart=valueAccessor().chartInstance;item=ds[index];$(chart).igDataChart("notifySetItem",ds,index,item,item)}};ko.observableArray.fn.subscribeArrayChanged=function(addCallback,deleteCallback){var previousValue=null;this.subscribe(function(_previousValue){if(previousValue===null){previousValue=_previousValue.slice(0)}},undefined,"beforeChange");this.subscribe(function(latestValue){var delta=ko.utils.compareArrays(previousValue,latestValue,true),i;for(i=0;i<delta.length;i++){switch(delta[i].status){case"retained":break;case"deleted":if(deleteCallback){deleteCallback(delta[i].value,delta[i].index);previousValue.splice(delta[i].index,1)}break;case"added":if(addCallback){addCallback(latestValue[i],delta[i].index);previousValue.splice(delta[i].index,0,latestValue[i])}break}}})}})(jQuery);