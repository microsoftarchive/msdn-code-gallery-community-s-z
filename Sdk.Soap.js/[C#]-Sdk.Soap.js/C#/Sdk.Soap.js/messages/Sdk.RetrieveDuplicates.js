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
 this.RetrieveDuplicatesRequest = function (businessEntity, matchingEntityName, pagingInfo) {
  ///<summary>
  /// Contains the data that is needed to  detect and retrieve duplicates for a specified record.
  ///</summary>
  ///<param name="businessEntity"  type="Sdk.Entity">
  /// Sets a record for which the duplicates are retrieved. Required.
  ///</param>
  ///<param name="matchingEntityName"  type="String">
  /// Sets a name of the matching entity type. Required.
  ///</param>
  ///<param name="pagingInfo"  type="Sdk.Query.PagingInfo">
  /// Sets a paging information for the retrieved duplicates. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveDuplicatesRequest)) {
   return new Sdk.RetrieveDuplicatesRequest(businessEntity, matchingEntityName, pagingInfo);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _businessEntity = null;
  var _matchingEntityName = null;
  var _pagingInfo = null;

  // internal validation functions

  function _setValidBusinessEntity(value) {
   if (value instanceof Sdk.Entity) {
    _businessEntity = value;
   }
   else {
    throw new Error("Sdk.RetrieveDuplicatesRequest BusinessEntity property is required and must be a Sdk.Entity.")
   }
  }

  function _setValidMatchingEntityName(value) {
   if (typeof value == "string") {
    _matchingEntityName = value;
   }
   else {
    throw new Error("Sdk.RetrieveDuplicatesRequest MatchingEntityName property is required and must be a String.")
   }
  }

  function _setValidPagingInfo(value) {
   if (value instanceof Sdk.Query.PagingInfo) {
    _pagingInfo = value;
   }
   else {
    throw new Error("Sdk.RetrieveDuplicatesRequest PagingInfo property is required and must be a Sdk.Query.PagingInfo.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof businessEntity != "undefined") {
   _setValidBusinessEntity(businessEntity);
  }
  if (typeof matchingEntityName != "undefined") {
   _setValidMatchingEntityName(matchingEntityName);
  }
  if (typeof pagingInfo != "undefined") {
   _setValidPagingInfo(pagingInfo);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>BusinessEntity</b:key>",
              (_businessEntity == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:Entity\">", _businessEntity.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>MatchingEntityName</b:key>",
              (_matchingEntityName == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _matchingEntityName, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>PagingInfo</b:key>",
              (_pagingInfo == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:PagingInfo\">", _pagingInfo.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveDuplicates</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveDuplicatesResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setBusinessEntity = function (value) {
   ///<summary>
   /// Sets a record for which the duplicates are retrieved. Required.
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// A record for which the duplicates are retrieved.
   ///</param>
   _setValidBusinessEntity(value);
   this.setRequestXml(getRequestXml());
  }

  this.setMatchingEntityName = function (value) {
   ///<summary>
   /// Sets a name of the matching entity type. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// A name of the matching entity type.
   ///</param>
   _setValidMatchingEntityName(value);
   this.setRequestXml(getRequestXml());
  }

  this.setPagingInfo = function (value) {
   ///<summary>
   /// Sets a paging information for the retrieved duplicates. Required.
   ///</summary>
   ///<param name="value" type="Sdk.Query.PagingInfo">
   /// A paging information for the retrieved duplicates.
   ///</param>
   _setValidPagingInfo(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveDuplicatesRequest.__class = true;

 this.RetrieveDuplicatesResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveDuplicatesRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveDuplicatesResponse)) {
   return new Sdk.RetrieveDuplicatesResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _duplicateCollection = null;

  // Internal property setter functions

  function _setDuplicateCollection(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='DuplicateCollection']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _duplicateCollection = Sdk.Util.createEntityCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getDuplicateCollection = function () {
   ///<summary>
   /// Gets a collection of duplicate entity instances.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// A collection of duplicate entity instances.
   ///</returns>
   return _duplicateCollection;
  }

  //Set property values from responseXml constructor parameter
  _setDuplicateCollection(responseXml);
 }
 this.RetrieveDuplicatesResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveDuplicatesRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveDuplicatesResponse.prototype = new Sdk.OrganizationResponse();
