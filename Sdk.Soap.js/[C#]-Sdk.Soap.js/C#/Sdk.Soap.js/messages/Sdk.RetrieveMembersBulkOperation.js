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
 this.RetrieveMembersBulkOperationRequest = function (bulkOperationId, bulkOperationSource, entitySource, query) {
  ///<summary>
  /// Contains the data that is needed to retrieve the members of a bulk operation.
  ///</summary>
  ///<param name="bulkOperationId"  type="String">
  /// Sets the ID of the bulk operation. Required.
  ///</param>
  ///<param name="bulkOperationSource"  type="Number">
  /// Sets the source for a bulk operation. Required.
  ///</param>
  ///<param name="entitySource"  type="Number">
  /// Sets which  members of a bulk operation to retrieve. Required.
  ///</param>
  ///<param name="query"  type="Sdk.QueryBase">
  /// Sets the query for the retrieve operation that can be used to break up large data sets into pages. Optional.
  ///</param>
  if (!(this instanceof Sdk.RetrieveMembersBulkOperationRequest)) {
   return new Sdk.RetrieveMembersBulkOperationRequest(bulkOperationId, bulkOperationSource, entitySource, query);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _bulkOperationId = null;
  var _bulkOperationSource = null;
  var _entitySource = null;
  var _query = null;

  // internal validation functions

  function _setValidBulkOperationId(value) {
   if (Sdk.Util.isGuid(value)) {
    _bulkOperationId = value;
   }
   else {
    throw new Error("Sdk.RetrieveMembersBulkOperationRequest BulkOperationId property is required and must be a String.")
   }
  }

  function _setValidBulkOperationSource(value) {
   if (typeof value == "number") {
    _bulkOperationSource = value;
   }
   else {
    throw new Error("Sdk.RetrieveMembersBulkOperationRequest BulkOperationSource property is required and must be a Number.")
   }
  }

  function _setValidEntitySource(value) {
   if (typeof value == "number") {
    _entitySource = value;
   }
   else {
    throw new Error("Sdk.RetrieveMembersBulkOperationRequest EntitySource property is required and must be a Number.")
   }
  }

  function _setValidQuery(value) {
   if (value instanceof Sdk.Query.QueryBase) {
    _query = value;
   }
   else {
    throw new Error("Sdk.RetrieveMembersBulkOperationRequest Query property is required and must be a Sdk.QueryBase.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof bulkOperationId != "undefined") {
   _setValidBulkOperationId(bulkOperationId);
  }
  if (typeof bulkOperationSource != "undefined") {
   _setValidBulkOperationSource(bulkOperationSource);
  }
  if (typeof entitySource != "undefined") {
   _setValidEntitySource(entitySource);
  }
  if (typeof query != "undefined") {
   _setValidQuery(query);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>BulkOperationId</b:key>",
              (_bulkOperationId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _bulkOperationId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>BulkOperationSource</b:key>",
              (_bulkOperationSource == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _bulkOperationSource, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EntitySource</b:key>",
              (_entitySource == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _entitySource, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Query</b:key>",
              (_query == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:" + _query.getQueryType() + "\">", _query.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveMembersBulkOperation</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveMembersBulkOperationResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setBulkOperationId = function (value) {
   ///<summary>
   /// Sets the ID of the bulk operation. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the bulk operation.
   ///</param>
   _setValidBulkOperationId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setBulkOperationSource = function (value) {
   ///<summary>
   /// Sets the source for a bulk operation. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The source for a bulk operation.
   ///</param>
   _setValidBulkOperationSource(value);
   this.setRequestXml(getRequestXml());
  }

  this.setEntitySource = function (value) {
   ///<summary>
   /// Sets which  members of a bulk operation to retrieve. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// Which members of a bulk operation to retrieve.
   ///</param>
   _setValidEntitySource(value);
   this.setRequestXml(getRequestXml());
  }

  this.setQuery = function (value) {
   ///<summary>
   /// Sets the query for the retrieve operation that can be used to break up large data sets into pages. Optional.
   ///</summary>
   ///<param name="value" type="Sdk.QueryBase">
   /// The query for the retrieve operation that can be used to break up large data sets into pages.
   ///</param>
   _setValidQuery(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveMembersBulkOperationRequest.__class = true;

 this.RetrieveMembersBulkOperationResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveMembersBulkOperationRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveMembersBulkOperationResponse)) {
   return new Sdk.RetrieveMembersBulkOperationResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _entityCollection = null;

  // Internal property setter functions

  function _setEntityCollection(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='EntityCollection']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _entityCollection = Sdk.Util.createEntityCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEntityCollection = function () {
   ///<summary>
   /// Gets the collection of members of a bulk operation. 
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The collection of members of a bulk operation. 
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.RetrieveMembersBulkOperationResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveMembersBulkOperationRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveMembersBulkOperationResponse.prototype = new Sdk.OrganizationResponse();
