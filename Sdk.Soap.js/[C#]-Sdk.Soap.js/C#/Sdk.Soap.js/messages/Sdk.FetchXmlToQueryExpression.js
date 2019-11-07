// =====================================================================
//  This file is part of the Microsoft Dynamics CRM SDK code samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
// =====================================================================
"use strict";
(function () {
 this.FetchXmlToQueryExpressionRequest = function (fetchXml) {
  ///<summary>
  /// Contains the data that is needed to convert a query in FetchXML to a QueryExpression. 
  ///</summary>
  ///<param name="fetchXml"  type="String">
  /// Sets the query to convert. 
  ///</param>
  if (!(this instanceof Sdk.FetchXmlToQueryExpressionRequest)) {
   return new Sdk.FetchXmlToQueryExpressionRequest(fetchXml);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _fetchXml = null;

  // internal validation functions

  function _setValidFetchXml(value) {
   if (typeof value == "string") {
    _fetchXml = value;
   }
   else {
    throw new Error("Sdk.FetchXmlToQueryExpressionRequest FetchXml property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof fetchXml != "undefined") {
   _setValidFetchXml(fetchXml);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>FetchXml</b:key>",
              (_fetchXml == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", Sdk.Xml.xmlEncode(_fetchXml), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>FetchXmlToQueryExpression</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.FetchXmlToQueryExpressionResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setFetchXml = function (value) {
   ///<summary>
   /// Sets the query to convert. 
   ///</summary>
   ///<param name="value" type="String">
   /// The query to convert. 
   ///</param>
   _setValidFetchXml(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.FetchXmlToQueryExpressionRequest.__class = true;

 this.FetchXmlToQueryExpressionResponse = function (responseXml) {
  ///<summary>
  /// Response to FetchXmlToQueryExpressionRequest
  ///</summary>
  if (!(this instanceof Sdk.FetchXmlToQueryExpressionResponse)) {
   return new Sdk.FetchXmlToQueryExpressionResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _query = null;

  // Internal property setter functions

  function _setQuery(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Query']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _query = createQueryExpressionFromNode(valueNode);
   }
  }

  function createQueryExpressionFromNode(node) {

   var rv = new Sdk.Query.QueryExpression(Sdk.Xml.selectSingleNodeText(node, "a:EntityName"));

   rv.setColumnSet(createColumnSetFromNode(Sdk.Xml.selectSingleNode(node, "a:ColumnSet")));

   var criteriaNode = Sdk.Xml.selectSingleNode(node, "a:Criteria");
   rv.setCriteria(createFilterExpressionFromNode(criteriaNode));

   rv.setDistinct((Sdk.Xml.selectSingleNodeText(node, "a:Distinct") == "true") ? true : false);

   var linkEntityNode = Sdk.Xml.selectSingleNode(node, "a:LinkEntities");
   for (var i = 0; i < linkEntityNode.childNodes.length; i++) {
    rv.addLink(createLinkEntityFromNode(linkEntityNode.childNodes[i]));
   }

   rv.setNoLock((Sdk.Xml.selectSingleNodeText(node, "a:NoLock") == "true") ? true : false)

   var ordersNode = Sdk.Xml.selectSingleNode(node, "a:Orders");
   for (var i = 0; i < ordersNode.childNodes.length; i++) {
    rv.getOrders().add(createOrderExpressionFromNode(ordersNode.childNodes[i]));
   }

   var pageInfoNode = Sdk.Xml.selectSingleNode(node, "a:PageInfo");
   if (pageInfoNode != null) {
    rv.setPageInfo(createPageInfoFromNode(pageInfoNode));
   }
   var topCountNode = Sdk.Xml.selectSingleNode(node, "a:TopCount");
   if (topCountNode != null) {
    rv.setTopCount(parseInt(Sdk.Xml.getNodeText(topCountNode), 10));
   }

   return rv;
  }

  function createFilterExpressionFromNode(node) {
   var filterOperator = Sdk.Xml.selectSingleNodeText(node, "a:FilterOperator");
   var rv = new Sdk.Query.FilterExpression(filterOperator);
   var conditionsNode = Sdk.Xml.selectSingleNode(node, "a:Conditions");
   for (var i = 0; i < conditionsNode.childNodes.length; i++) {
    rv.addCondition(createConditionExpressionFromNode(conditionsNode.childNodes[i]));
   }
   var filtersNode = Sdk.Xml.selectSingleNode(node, "a:Filters");
   for (var i = 0; i < filtersNode.childNodes.length; i++) {
    rv.addFilter(createFilterExpressionFromNode(filtersNode.childNodes[i]));
   }

   rv.setIsQuickFindFilter((Sdk.Xml.selectSingleNodeText(node, "IsQuickFindFilter ") == "true") ? true : false);


   return rv;

  }

  function createConditionExpressionFromNode(node) {
   var entityName = Sdk.Xml.selectSingleNodeText(node, "a:EntityName");
   var attributeName = Sdk.Xml.selectSingleNodeText(node, "a:AttributeName");
   var operator = Sdk.Xml.selectSingleNodeText(node, "a:Operator");
   var values = returnTypedValues(Sdk.Xml.selectSingleNode(node, "a:Values"))
   var rv = new Sdk.Query.ConditionExpression(entityName, attributeName, operator, values);
   return rv;

  }

  function returnTypedValues(node) {
   var rv;
   if (Sdk.Xml.isNodeNull(node) || node.childNodes.length == 0) {
    rv = null;
   }
   else {
    var type = Sdk.Xml.getNodeText(node.firstChild.attributes.getNamedItem("i:type")).split(":")[1];
    switch (type) {
     case "boolean":
      var booleanValues = [];
      for (var i = 0; i < node.childNodes.length; i++) {
       booleanValues.push((Sdk.Xml.getNodeText(node.childNodes[i]) == "true") ? true : false);
      }
      rv = new Sdk.Query.Booleans(booleanValues);

      break;
     case "booleanManagedProperty":
      var booleanValues = [];
      for (var i = 0; i < node.childNodes.length; i++) {
       booleanValues.push((Sdk.Xml.getNodeText(node.childNodes[i]) == "true") ? true : false);
      }
      rv = new Sdk.Query.BooleanManagedProperties(booleanValues);
      break;
     case "dateTime":
      var dates = [];
      for (var i = 0; i < node.childNodes.length; i++) {
       dates.push(new Date(Sdk.Xml.getNodeText(node.childNodes[i])));
      }
      rv = new Sdk.Query.Dates(dates);
      break;
     case "decimal":
      var decimals = [];
      for (var i = 0; i < node.childNodes.length; i++) {
       decimals.push(parseFloat(Sdk.Xml.getNodeText(node.childNodes[i])));
      }
      rv = new Sdk.Query.Decimals(decimals);
      break;
     case "double":
      var doubles = [];
      for (var i = 0; i < node.childNodes.length; i++) {
       doubles.push(parseFloat(Sdk.Xml.getNodeText(node.childNodes[i])));
      }
      rv = new Sdk.Query.Doubles(doubles);
      break;
     case "entityCollection":
      throw new Error("FetchXmlToQueryExpressionResponse EntityCollection values not implemented.")
      break;
     case "entityReference":

      var entityReferences = [];
      for (var i = 0; i < node.childNodes.length; i++) {
       var valueNode = node.childNodes[i];
       var _type = Sdk.Xml.selectSingleNodeText(valueNode, "a:LogicalName");
       var _id = Sdk.Xml.selectSingleNodeText(valueNode, "a:Id");
       var _name = Sdk.Xml.selectSingleNodeText(valueNode, "a:Name");
       entityReferences.push(new Sdk.EntityReference(_type, _id, _name));
      }
      rv = new Sdk.Query.EntityReferences(entityReferences);
      break;
     case "guid":
      var guids = [];
      for (var i = 0; i < node.childNodes.length; i++) {
       guids.push(Sdk.Xml.getNodeText(node.childNodes[i]));
      }
      rv = new Sdk.Query.Guids(guids);
      break;
     case "int":
      var ints = [];
      for (var i = 0; i < node.childNodes.length; i++) {
       ints.push(parseInt(Sdk.Xml.getNodeText(node.childNodes[i]), 10));
      }
      rv = new Sdk.Query.Ints(ints);
      break;
     case "long":
      var longs = [];
      for (var i = 0; i < node.childNodes.length; i++) {
       longs.push(parseInt(Sdk.Xml.getNodeText(node.childNodes[i]), 10));
      }
      rv = new Sdk.Query.Longs(longs);
      break;
     case "money":
      var monies = [];
      for (var i = 0; i < node.childNodes.length; i++) {
       monies.push(parseFloat(Sdk.Xml.getNodeText(node.childNodes[i])));
      }
      rv = new Sdk.Query.Money(monies);
      break;
     case "optionSet":
      var ints = [];
      for (var i = 0; i < node.childNodes.length; i++) {
       ints.push(parseInt(Sdk.Xml.getNodeText(node.childNodes[i]), 10));
      }
      rv = new Sdk.Query.OptionSets(ints);
      break;
     case "string":
      var strings = [];
      for (var i = 0; i < node.childNodes.length; i++) {
       strings.push(Sdk.Xml.getNodeText(node.childNodes[i]));
      }
      rv = new Sdk.Query.Strings(strings);
      break;
     default:
      throw new Error("FetchXmlToQueryExpressionResponse unexpected value type: '" + type + "'.")
      break;
    }
   }

   return rv;
  }

  function createLinkEntityFromNode(node) {
   var linkFromEntityName = Sdk.Xml.selectSingleNodeText(node, "a:LinkFromEntityName");
   var linkToEntityName = Sdk.Xml.selectSingleNodeText(node, "a:LinkToEntityName");
   var linkFromAttributeName = Sdk.Xml.selectSingleNodeText(node, "a:LinkFromAttributeName");
   var linkToAttributeName = Sdk.Xml.selectSingleNodeText(node, "a:LinkToAttributeName");
   var joinOperator = Sdk.Xml.selectSingleNodeText(node, "a:JoinOperator");
   var entityAliasNode = Sdk.Xml.selectSingleNode(node, "a:EntityAlias");
   var entityAlias = null;
   if (!Sdk.Xml.isNodeNull(entityAliasNode)) {
    entityAlias = Sdk.Xml.getNodeText(entityAliasNode);
   }

   var rv = new Sdk.Query.LinkEntity(
    linkFromEntityName,
    linkToEntityName,
    linkFromAttributeName,
    linkToAttributeName,
    joinOperator,
    entityAlias);

   rv.setColumns(createColumnSetFromNode(Sdk.Xml.selectSingleNode(node, "a:Columns")));

   rv.setLinkCriteria(createFilterExpressionFromNode(Sdk.Xml.selectSingleNode(node, "a:LinkCriteria")));

   var linkEntitiesNode = Sdk.Xml.selectSingleNode(node, "a:LinkEntities");
   if (!Sdk.Xml.isNodeNull(linkEntitiesNode)) {
    for (var i = 0; i < linkEntitiesNode.childNodes.length; i++) {
     rv.addLink(createLinkEntityFromNode(linkEntitiesNode.childNodes[i]));
    }
   }

   return rv;
  }

  function createColumnSetFromNode(node) {
   var rv = new Sdk.ColumnSet();
   var allColumns = (Sdk.Xml.selectSingleNodeText(node, "a:AllColumns") == "true") ? true : false;
   rv.setAllColumns(allColumns);
   if (!allColumns) {
    var columnNode = Sdk.Xml.selectSingleNode(node, "./a:Columns");
    for (var i = 0; i < columnNode.childNodes.length; i++) {
     rv.addColumn(Sdk.Xml.getNodeText(columnNode.childNodes[i]));
    }
   }
   return rv;
  }

  function createOrderExpressionFromNode(node) {
   var attributeName = Sdk.Xml.selectSingleNodeText(node, "a:AttributeName");
   var orderType = null;
   var orderTypeNode = Sdk.Xml.selectSingleNode(node, "a:OrderType");
   if (!Sdk.Xml.isNodeNull(orderTypeNode)) {
    orderType = Sdk.Xml.getNodeText(orderTypeNode);
   }
   var rv = new Sdk.Query.OrderExpression(attributeName, orderType);


   return rv;

  }

  function createPageInfoFromNode(node) {
   var rv = new Sdk.Query.PagingInfo();
   rv.setCount(parseInt(Sdk.Xml.selectSingleNodeText(node, "a:Count"), 10));
   rv.setPageNumber(parseInt(Sdk.Xml.selectSingleNodeText(node, "a:PageNumber"), 10));
   var pagingCookieNode = Sdk.Xml.selectSingleNode(node, "a:PagingCookie");
   if (!Sdk.Xml.isNodeNull(pagingCookieNode)) {
    rv.setPagingCookie(Sdk.Xml.getNodeText(pagingCookieNode));
   }
   rv.setReturnTotalRecordCount((Sdk.Xml.selectSingleNodeText(node, "a:ReturnTotalRecordCount") == "true") ? true : false);

   return rv;

  }


  //Public Methods to retrieve properties
  this.getQuery = function () {
   ///<summary>
   /// Gets the results of the query conversion. 
   ///</summary>
   ///<returns type="Sdk.Query.QueryExpression">
   /// The results of the query conversion. 
   ///</returns>
   return _query;
  }

  //Set property values from responseXml constructor parameter
  _setQuery(responseXml);
 }
 this.FetchXmlToQueryExpressionResponse.__class = true;
}).call(Sdk)

Sdk.FetchXmlToQueryExpressionRequest.prototype = new Sdk.OrganizationRequest();
Sdk.FetchXmlToQueryExpressionResponse.prototype = new Sdk.OrganizationResponse();
