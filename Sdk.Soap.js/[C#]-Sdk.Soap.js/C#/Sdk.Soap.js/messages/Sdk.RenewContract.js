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
 this.RenewContractRequest = function (contractId, status, includeCanceledLines) {
  ///<summary>
  /// Contains the data that is needed to renew a contract and create the contract details for a new contract.
  ///</summary>
  ///<param name="contractId"  type="String">
  /// Sets the ID of the contract to be renewed. Required.
  ///</param>
  ///<param name="status"  type="Number">
  /// Sets the status of the contract.
  ///</param>
  ///<param name="includeCanceledLines"  type="Boolean">
  /// Sets a value that indicates whether the canceled line items of the original contract should be included in the renewed contract. Required.
  ///</param>
  if (!(this instanceof Sdk.RenewContractRequest)) {
   return new Sdk.RenewContractRequest(contractId, status, includeCanceledLines);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _contractId = null;
  var _status = null;
  var _includeCanceledLines = null;

  // internal validation functions

  function _setValidContractId(value) {
   if (Sdk.Util.isGuid(value)) {
    _contractId = value;
   }
   else {
    throw new Error("Sdk.RenewContractRequest ContractId property is required and must be a String.")
   }
  }

  function _setValidStatus(value) {
   if (typeof value == "number") {
    _status = value;
   }
   else {
    throw new Error("Sdk.RenewContractRequest Status property is required and must be a Number.")
   }
  }

  function _setValidIncludeCanceledLines(value) {
   if (typeof value == "boolean") {
    _includeCanceledLines = value;
   }
   else {
    throw new Error("Sdk.RenewContractRequest IncludeCanceledLines property is required and must be a Boolean.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof contractId != "undefined") {
   _setValidContractId(contractId);
  }
  if (typeof status != "undefined") {
   _setValidStatus(status);
  }
  if (typeof includeCanceledLines != "undefined") {
   _setValidIncludeCanceledLines(includeCanceledLines);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ContractId</b:key>",
              (_contractId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _contractId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Status</b:key>",
              (_status == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _status, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>IncludeCanceledLines</b:key>",
              (_includeCanceledLines == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _includeCanceledLines, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RenewContract</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RenewContractResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setContractId = function (value) {
   ///<summary>
   /// Sets the ID of the contract to be renewed. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the contract to be renewed.
   ///</param>
   _setValidContractId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setStatus = function (value) {
   ///<summary>
   /// Sets the status of the contract.
   ///</summary>
   ///<param name="value" type="Number">
   /// The status of the contract.
   ///</param>
   _setValidStatus(value);
   this.setRequestXml(getRequestXml());
  }

  this.setIncludeCanceledLines = function (value) {
   ///<summary>
   /// Sets a value that indicates whether the canceled line items of the original contract should be included in the renewed contract. Required.
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether the canceled line items of the original contract should be included in the renewed contract.
   ///</param>
   _setValidIncludeCanceledLines(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RenewContractRequest.__class = true;

 this.RenewContractResponse = function (responseXml) {
  ///<summary>
  /// Response to RenewContractRequest
  ///</summary>
  if (!(this instanceof Sdk.RenewContractResponse)) {
   return new Sdk.RenewContractResponse(responseXml);
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
   /// Gets the resulting contract.
   ///</summary>
   ///<returns type="Sdk.Entity">
   /// The resulting contract.
   ///</returns>
   return _entity;
  }

  //Set property values from responseXml constructor parameter
  _setEntity(responseXml);
 }
 this.RenewContractResponse.__class = true;
}).call(Sdk)

Sdk.RenewContractRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RenewContractResponse.prototype = new Sdk.OrganizationResponse();
