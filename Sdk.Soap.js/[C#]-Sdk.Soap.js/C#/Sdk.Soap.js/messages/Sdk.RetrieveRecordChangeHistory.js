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
 this.RetrieveRecordChangeHistoryRequest = function (target, pagingInfo) {
  ///<summary>
  /// Contains the data that is needed to retrieve all attribute data changes for a specific entity.
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target audit record. Required.
  ///</param>
  ///<param name="pagingInfo" optional="true" type="Sdk.Query.PagingInfo">
  /// Sets the paging information for the retrieved data. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveRecordChangeHistoryRequest)) {
   return new Sdk.RetrieveRecordChangeHistoryRequest(target, pagingInfo);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _pagingInfo = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.EntityReference) {
    _target = value;
   }
   else {
    throw new Error("Sdk.RetrieveRecordChangeHistoryRequest Target property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidPagingInfo(value) {
   if (value == null || value instanceof Sdk.Query.PagingInfo) {
    _pagingInfo = value;
   }
   else {
    throw new Error("Sdk.RetrieveRecordChangeHistoryRequest PagingInfo property must be a Sdk.Query.PagingInfo or null.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof pagingInfo != "undefined") {
   _setValidPagingInfo(pagingInfo);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Target</b:key>",
              (_target == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _target.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>PagingInfo</b:key>",
              (_pagingInfo == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:PagingInfo\">", _pagingInfo.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveRecordChangeHistory</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveRecordChangeHistoryResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target audit record. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target audit record.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setPagingInfo = function (value) {
   ///<summary>
   /// Sets the paging information for the retrieved data. Required.
   ///</summary>
   ///<param name="value" type="Sdk.Query.PagingInfo">
   /// The paging information for the retrieved data.
   ///</param>
   _setValidPagingInfo(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveRecordChangeHistoryRequest.__class = true;

 this.RetrieveRecordChangeHistoryResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveRecordChangeHistoryRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveRecordChangeHistoryResponse)) {
   return new Sdk.RetrieveRecordChangeHistoryResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _auditDetailCollection = null;

  // Internal property setter functions

  function _setAuditDetailCollection(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='AuditDetailCollection']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _auditDetailCollection = Sdk.Util.createAuditDetailCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getAuditDetailCollection = function () {
   ///<summary>
   /// Contains the history of data changes for the target entity. 
   ///</summary>
   ///<returns type="Sdk.AuditDetailCollection">
   /// The history of data changes for the target entity. 
   ///</returns>
   return _auditDetailCollection;
  }

  //Set property values from responseXml constructor parameter
  _setAuditDetailCollection(responseXml);
 }
 this.RetrieveRecordChangeHistoryResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveRecordChangeHistoryRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveRecordChangeHistoryResponse.prototype = new Sdk.OrganizationResponse();
