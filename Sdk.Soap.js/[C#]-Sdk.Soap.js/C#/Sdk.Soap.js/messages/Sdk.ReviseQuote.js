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
 this.ReviseQuoteRequest = function (quoteId, columnSet) {
  ///<summary>
  /// Contains the data that is needed to set the state of a quote to Draft.
  ///</summary>
  ///<param name="quoteId"  type="String">
  /// Sets the ID of the original quote. Required.
  ///</param>
  ///<param name="columnSet"  type="Sdk.ColumnSet">
  /// Sets the collection of attributes to retrieve in the revised quote. Required.
  ///</param>
  if (!(this instanceof Sdk.ReviseQuoteRequest)) {
   return new Sdk.ReviseQuoteRequest(quoteId, columnSet);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _quoteId = null;
  var _columnSet = null;

  // internal validation functions

  function _setValidQuoteId(value) {
   if (Sdk.Util.isGuid(value)) {
    _quoteId = value;
   }
   else {
    throw new Error("Sdk.ReviseQuoteRequest QuoteId property is required and must be a String.")
   }
  }

  function _setValidColumnSet(value) {
   if (value instanceof Sdk.ColumnSet) {
    _columnSet = value;
   }
   else {
    throw new Error("Sdk.ReviseQuoteRequest ColumnSet property is required and must be a Sdk.ColumnSet.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof quoteId != "undefined") {
   _setValidQuoteId(quoteId);
  }
  if (typeof columnSet != "undefined") {
   _setValidColumnSet(columnSet);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>QuoteId</b:key>",
              (_quoteId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _quoteId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ColumnSet</b:key>",
              (_columnSet == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:ColumnSet\">", _columnSet.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ReviseQuote</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ReviseQuoteResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setQuoteId = function (value) {
   ///<summary>
   /// Sets the ID of the original quote. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the original quote.
   ///</param>
   _setValidQuoteId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setColumnSet = function (value) {
   ///<summary>
   /// Sets the collection of attributes to retrieve in the revised quote. Required.
   ///</summary>
   ///<param name="value" type="Sdk.ColumnSet">
   /// The collection of attributes to retrieve in the revised quote.
   ///</param>
   _setValidColumnSet(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ReviseQuoteRequest.__class = true;

 this.ReviseQuoteResponse = function (responseXml) {
  ///<summary>
  /// Response to ReviseQuoteRequest
  ///</summary>
  if (!(this instanceof Sdk.ReviseQuoteResponse)) {
   return new Sdk.ReviseQuoteResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _entity = null;

  // Internal property setter functions

  function _setEntity(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Entity']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _entity = Sdk.Util.createEntityFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEntity = function () {
   ///<summary>
   /// Gets the revised quote.
   ///</summary>
   ///<returns type="Sdk.Entity">
   /// The revised quote.
   ///</returns>
   return _entity;
  }

  //Set property values from responseXml constructor parameter
  _setEntity(responseXml);
 }
 this.ReviseQuoteResponse.__class = true;
}).call(Sdk)

Sdk.ReviseQuoteRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ReviseQuoteResponse.prototype = new Sdk.OrganizationResponse();
