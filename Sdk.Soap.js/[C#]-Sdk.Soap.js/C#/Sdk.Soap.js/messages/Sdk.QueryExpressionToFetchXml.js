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
(function ()
{
 this.QueryExpressionToFetchXmlRequest = function (query) {
  ///<summary>
  /// Contains the data that is needed to  convert a query, which is represented as a QueryExpression class, to its equivalent query, which is represented as FetchXML.
  ///</summary>
  ///<param name="query"  type="Sdk.QueryBase">
  /// Sets the query to convert.
  ///</param>
  if (!(this instanceof Sdk.QueryExpressionToFetchXmlRequest)) {
   return new Sdk.QueryExpressionToFetchXmlRequest(query);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _query = null;

  // internal validation functions

  function _setValidQuery(value) {
   if (value instanceof Sdk.Query.QueryBase) {
    _query = value;
   }
   else {
    throw new Error("Sdk.QueryExpressionToFetchXmlRequest Query property is required and must be a Sdk.QueryBase.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof query != "undefined") {
   _setValidQuery(query);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Query</b:key>",
              (_query == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:" + _query.getQueryType() + "\">", _query.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>QueryExpressionToFetchXml</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.QueryExpressionToFetchXmlResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setQuery = function (value) {
   ///<summary>
   /// Sets the query to convert.
   ///</summary>
   ///<param name="value" type="Sdk.QueryBase">
   /// The query to convert.
   ///</param>
   _setValidQuery(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.QueryExpressionToFetchXmlRequest.__class = true;

 this.QueryExpressionToFetchXmlResponse = function (responseXml) {
  ///<summary>
  /// Response to QueryExpressionToFetchXmlRequest
  ///</summary>
  if (!(this instanceof Sdk.QueryExpressionToFetchXmlResponse)) {
   return new Sdk.QueryExpressionToFetchXmlResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _fetchXml = null;

  // Internal property setter functions

  function _setFetchXml(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='FetchXml']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _fetchXml = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getFetchXml = function () {
   ///<summary>
   /// Gets the results of the query conversion.
   ///</summary>
   ///<returns type="String">
   /// The results of the query conversion.
   ///</returns>
   return _fetchXml;
  }

  //Set property values from responseXml constructor parameter
  _setFetchXml(responseXml);
 }
 this.QueryExpressionToFetchXmlResponse.__class = true;
}).call(Sdk)

Sdk.QueryExpressionToFetchXmlRequest.prototype = new Sdk.OrganizationRequest();
Sdk.QueryExpressionToFetchXmlResponse.prototype = new Sdk.OrganizationResponse();
