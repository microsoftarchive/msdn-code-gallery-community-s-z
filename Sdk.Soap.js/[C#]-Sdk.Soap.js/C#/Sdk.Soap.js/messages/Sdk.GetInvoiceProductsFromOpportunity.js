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
 this.GetInvoiceProductsFromOpportunityRequest = function (opportunityId, invoiceId) {
  ///<summary>
  /// Contains the data that is needed to retrieve the products from an opportunity and copy them to the invoice. 
  ///</summary>
  ///<param name="opportunityId"  type="String">
  /// Sets the ID of the opportunity. 
  ///</param>
  ///<param name="invoiceId"  type="String">
  /// Sets the ID of the invoice. 
  ///</param>
  if (!(this instanceof Sdk.GetInvoiceProductsFromOpportunityRequest)) {
   return new Sdk.GetInvoiceProductsFromOpportunityRequest(opportunityId, invoiceId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _opportunityId = null;
  var _invoiceId = null;

  // internal validation functions

  function _setValidOpportunityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _opportunityId = value;
   }
   else {
    throw new Error("Sdk.GetInvoiceProductsFromOpportunityRequest OpportunityId property is required and must be a String.")
   }
  }

  function _setValidInvoiceId(value) {
   if (Sdk.Util.isGuid(value)) {
    _invoiceId = value;
   }
   else {
    throw new Error("Sdk.GetInvoiceProductsFromOpportunityRequest InvoiceId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof opportunityId != "undefined") {
   _setValidOpportunityId(opportunityId);
  }
  if (typeof invoiceId != "undefined") {
   _setValidInvoiceId(invoiceId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>OpportunityId</b:key>",
              (_opportunityId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _opportunityId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>InvoiceId</b:key>",
              (_invoiceId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _invoiceId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>GetInvoiceProductsFromOpportunity</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.GetInvoiceProductsFromOpportunityResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setOpportunityId = function (value) {
   ///<summary>
   /// Sets the ID of the opportunity. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the opportunity. 
   ///</param>
   _setValidOpportunityId(value);
   this.setRequestXml(getRequestXml());
  }

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
 this.GetInvoiceProductsFromOpportunityRequest.__class = true;

 this.GetInvoiceProductsFromOpportunityResponse = function (responseXml) {
  ///<summary>
  /// Response to GetInvoiceProductsFromOpportunityRequest
  ///</summary>
  if (!(this instanceof Sdk.GetInvoiceProductsFromOpportunityResponse)) {
   return new Sdk.GetInvoiceProductsFromOpportunityResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.GetInvoiceProductsFromOpportunityResponse.__class = true;
}).call(Sdk)

Sdk.GetInvoiceProductsFromOpportunityRequest.prototype = new Sdk.OrganizationRequest();
Sdk.GetInvoiceProductsFromOpportunityResponse.prototype = new Sdk.OrganizationResponse();
