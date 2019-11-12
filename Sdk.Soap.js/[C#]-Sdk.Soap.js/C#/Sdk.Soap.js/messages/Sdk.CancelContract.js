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
 this.CancelContractRequest = function (contractId, cancelDate, status) {
  ///<summary>
  /// Contains the data that is needed to cancel a contract. 
  ///</summary>
  ///<param name="contractId"  type="String">
  /// Sets the ID of the contract. Required. 
  ///</param>
  ///<param name="cancelDate"  type="Date">
  /// Sets the contract cancellation date. Required. 
  ///</param>
  ///<param name="status"  type="Number">
  /// Sets the status of the contract. Required. 
  ///</param>
  if (!(this instanceof Sdk.CancelContractRequest)) {
   return new Sdk.CancelContractRequest(contractId, cancelDate, status);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _contractId = null;
  var _cancelDate = null;
  var _status = null;

  // internal validation functions

  function _setValidContractId(value) {
   if (Sdk.Util.isGuid(value)) {
    _contractId = value;
   }
   else {
    throw new Error("Sdk.CancelContractRequest ContractId property is required and must be a String.")
   }
  }

  function _setValidCancelDate(value) {
   if (value instanceof Date) {
    _cancelDate = value;
   }
   else {
    throw new Error("Sdk.CancelContractRequest CancelDate property is required and must be a Date.")
   }
  }

  function _setValidStatus(value) {
   if (typeof value == "number") {
    _status = value;
   }
   else {
    throw new Error("Sdk.CancelContractRequest Status property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof contractId != "undefined") {
   _setValidContractId(contractId);
  }
  if (typeof cancelDate != "undefined") {
   _setValidCancelDate(cancelDate);
  }
  if (typeof status != "undefined") {
   _setValidStatus(status);
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
               "<b:key>CancelDate</b:key>",
              (_cancelDate == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:dateTime\">", _cancelDate.toISOString(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Status</b:key>",
              (_status == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:OptionSetValue\">",
               "<a:Value>", _status, "</a:Value>",
              "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CancelContract</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CancelContractResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setContractId = function (value) {
   ///<summary>
   /// Sets the ID of the contract. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the contract.
   ///</param>
   _setValidContractId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setCancelDate = function (value) {
   ///<summary>
   /// Sets the contract cancellation date. Required. 
   ///</summary>
   ///<param name="value" type="Date">
   /// The contract cancellation date.
   ///</param>
   _setValidCancelDate(value);
   this.setRequestXml(getRequestXml());
  }

  this.setStatus = function (value) {
   ///<summary>
   /// Sets the status of the contract. Required. 
   ///</summary>
   ///<param name="value" type="Number">
   ///  The status of the contract.
   ///</param>
   _setValidStatus(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CancelContractRequest.__class = true;

 this.CancelContractResponse = function (responseXml) {
  ///<summary>
  /// Response to CancelContractRequest
  ///</summary>
  if (!(this instanceof Sdk.CancelContractResponse)) {
   return new Sdk.CancelContractResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.CancelContractResponse.__class = true;
}).call(Sdk)

Sdk.CancelContractRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CancelContractResponse.prototype = new Sdk.OrganizationResponse();
