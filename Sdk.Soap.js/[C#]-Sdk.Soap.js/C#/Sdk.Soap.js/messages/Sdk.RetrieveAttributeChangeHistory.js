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
 this.RetrieveAttributeChangeHistoryRequest = function (target, attributeLogicalName, pagingInfo) {
  ///<summary>
  /// Contains the data that is needed to  retrieve all metadata changes to a specific attribute.
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target audit record for which to retrieve attribute change history. Required.
  ///</param>
  ///<param name="attributeLogicalName"  type="String">
  /// Sets the attribute’s logical (schema) name. Required.
  ///</param>
  ///<param name="pagingInfo" optional="true" type="Sdk.Query.PagingInfo">
  /// Sets the paging information. Optional.
  ///</param>
  if (!(this instanceof Sdk.RetrieveAttributeChangeHistoryRequest)) {
   return new Sdk.RetrieveAttributeChangeHistoryRequest(target, attributeLogicalName, pagingInfo);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _attributeLogicalName = null;
  var _pagingInfo = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.EntityReference) {
    _target = value;
   }
   else {
    throw new Error("Sdk.RetrieveAttributeChangeHistoryRequest Target property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidAttributeLogicalName(value) {
   if (typeof value == "string") {
    _attributeLogicalName = value;
   }
   else {
    throw new Error("Sdk.RetrieveAttributeChangeHistoryRequest AttributeLogicalName property is required and must be a String.")
   }
  }

  function _setValidPagingInfo(value) {
   if (value == null || value instanceof Sdk.Query.PagingInfo) {
    _pagingInfo = value;
   }
   else {
    throw new Error("Sdk.RetrieveAttributeChangeHistoryRequest PagingInfo property must be a Sdk.Query.PagingInfo or null.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof attributeLogicalName != "undefined") {
   _setValidAttributeLogicalName(attributeLogicalName);
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
               "<b:key>AttributeLogicalName</b:key>",
              (_attributeLogicalName == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _attributeLogicalName, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>PagingInfo</b:key>",
              (_pagingInfo == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:PagingInfo\">", _pagingInfo.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveAttributeChangeHistory</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveAttributeChangeHistoryResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target audit record for which to retrieve attribute change history. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target audit record for which to retrieve attribute change history.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setAttributeLogicalName = function (value) {
   ///<summary>
   /// Sets the attribute’s logical (schema) name. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The attribute’s logical (schema) name.
   ///</param>
   _setValidAttributeLogicalName(value);
   this.setRequestXml(getRequestXml());
  }

  this.setPagingInfo = function (value) {
   ///<summary>
   /// Sets the paging information. Optional.
   ///</summary>
   ///<param name="value" type="Sdk.Query.PagingInfo">
   /// The paging information.
   ///</param>
   _setValidPagingInfo(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveAttributeChangeHistoryRequest.__class = true;

 this.RetrieveAttributeChangeHistoryResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveAttributeChangeHistoryRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveAttributeChangeHistoryResponse)) {
   return new Sdk.RetrieveAttributeChangeHistoryResponse(responseXml);
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
   /// Gets the attribute change history that results in a collection of audit details.
   ///</summary>
   ///<returns type="Sdk.AuditDetailCollection">
   /// The attribute change history that results in a collection of audit details.
   ///</returns>
   return _auditDetailCollection;
  }

  //Set property values from responseXml constructor parameter
  _setAuditDetailCollection(responseXml);
 }
 this.RetrieveAttributeChangeHistoryResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveAttributeChangeHistoryRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveAttributeChangeHistoryResponse.prototype = new Sdk.OrganizationResponse();
