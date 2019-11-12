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
 this.LockInvoicePricingRequest = function (invoiceId) {
  ///<summary>
  /// Contains the data that is needed to  lock the total price of products and services that are specified in the invoice.
  ///</summary>
  ///<param name="invoiceId"  type="String">
  /// Sets the ID of the invoice.
  ///</param>
  if (!(this instanceof Sdk.LockInvoicePricingRequest)) {
   return new Sdk.LockInvoicePricingRequest(invoiceId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _invoiceId = null;

  // internal validation functions

  function _setValidInvoiceId(value) {
   if (Sdk.Util.isGuid(value)) {
    _invoiceId = value;
   }
   else {
    throw new Error("Sdk.LockInvoicePricingRequest InvoiceId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof invoiceId != "undefined") {
   _setValidInvoiceId(invoiceId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>InvoiceId</b:key>",
              (_invoiceId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _invoiceId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>LockInvoicePricing</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.LockInvoicePricingResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setInvoiceId = function (value) {
   ///<summary>
   /// Sets the ID of the invoice.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the invoice.
   ///</param>
   _setValidInvoiceId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.LockInvoicePricingRequest.__class = true;

 this.LockInvoicePricingResponse = function (responseXml) {
  ///<summary>
  /// Response to LockInvoicePricingRequest
  ///</summary>
  if (!(this instanceof Sdk.LockInvoicePricingResponse)) {
   return new Sdk.LockInvoicePricingResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.LockInvoicePricingResponse.__class = true;
}).call(Sdk)

Sdk.LockInvoicePricingRequest.prototype = new Sdk.OrganizationRequest();
Sdk.LockInvoicePricingResponse.prototype = new Sdk.OrganizationResponse();
