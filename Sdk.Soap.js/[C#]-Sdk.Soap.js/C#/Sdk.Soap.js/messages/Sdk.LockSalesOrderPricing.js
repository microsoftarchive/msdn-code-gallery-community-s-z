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
 this.LockSalesOrderPricingRequest = function (salesOrderId) {
  ///<summary>
  /// Contains the data that is needed to  lock the total price of products and services that are specified in the sales order (order).
  ///</summary>
  ///<param name="salesOrderId"  type="String">
  /// Sets the ID of the sales order.
  ///</param>
  if (!(this instanceof Sdk.LockSalesOrderPricingRequest)) {
   return new Sdk.LockSalesOrderPricingRequest(salesOrderId);
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
    throw new Error("Sdk.LockSalesOrderPricingRequest SalesOrderId property is required and must be a String.")
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
           "<a:RequestName>LockSalesOrderPricing</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.LockSalesOrderPricingResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setSalesOrderId = function (value) {
   ///<summary>
   /// Sets the ID of the sales order.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the sales order.
   ///</param>
   _setValidSalesOrderId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.LockSalesOrderPricingRequest.__class = true;

 this.LockSalesOrderPricingResponse = function (responseXml) {
  ///<summary>
  /// Response to LockSalesOrderPricingRequest
  ///</summary>
  if (!(this instanceof Sdk.LockSalesOrderPricingResponse)) {
   return new Sdk.LockSalesOrderPricingResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.LockSalesOrderPricingResponse.__class = true;
}).call(Sdk)

Sdk.LockSalesOrderPricingRequest.prototype = new Sdk.OrganizationRequest();
Sdk.LockSalesOrderPricingResponse.prototype = new Sdk.OrganizationResponse();
