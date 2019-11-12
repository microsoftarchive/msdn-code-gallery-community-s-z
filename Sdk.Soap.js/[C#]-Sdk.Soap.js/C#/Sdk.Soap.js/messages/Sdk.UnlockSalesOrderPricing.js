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
 this.UnlockSalesOrderPricingRequest = function (salesOrderId) {
  ///<summary>
  /// Contains the data that is needed to  unlock pricing for a sales order (order).
  ///</summary>
  ///<param name="salesOrderId"  type="String">
  /// Sets the ID of the sales order (order).
  ///</param>
  if (!(this instanceof Sdk.UnlockSalesOrderPricingRequest)) {
   return new Sdk.UnlockSalesOrderPricingRequest(salesOrderId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _salesOrderId = null;

  // internal validation functions

  function _setValidSalesOrderId(value) {
   if (Sdk.Util.isGuid(value)) {
    _salesOrderId = value;
   }
   else {
    throw new Error("Sdk.UnlockSalesOrderPricingRequest SalesOrderId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof salesOrderId != "undefined") {
   _setValidSalesOrderId(salesOrderId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SalesOrderId</b:key>",
              (_salesOrderId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _salesOrderId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>UnlockSalesOrderPricing</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.UnlockSalesOrderPricingResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setSalesOrderId = function (value) {
   ///<summary>
   /// Sets the ID of the sales order (order).
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the sales order (order).
   ///</param>
   _setValidSalesOrderId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.UnlockSalesOrderPricingRequest.__class = true;

 this.UnlockSalesOrderPricingResponse = function (responseXml) {
  ///<summary>
  /// Response to UnlockSalesOrderPricingRequest
  ///</summary>
  if (!(this instanceof Sdk.UnlockSalesOrderPricingResponse)) {
   return new Sdk.UnlockSalesOrderPricingResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.UnlockSalesOrderPricingResponse.__class = true;
}).call(Sdk)

Sdk.UnlockSalesOrderPricingRequest.prototype = new Sdk.OrganizationRequest();
Sdk.UnlockSalesOrderPricingResponse.prototype = new Sdk.OrganizationResponse();
