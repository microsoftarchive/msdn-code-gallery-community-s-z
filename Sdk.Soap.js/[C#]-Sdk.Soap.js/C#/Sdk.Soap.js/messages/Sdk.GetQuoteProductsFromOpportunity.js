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
 this.GetQuoteProductsFromOpportunityRequest = function (opportunityId, quoteId) {
  ///<summary>
  /// Contains the data that is needed to  retrieve the products from an opportunity and copy them to the quote.
  ///</summary>
  ///<param name="opportunityId"  type="String">
  /// Sets the ID of the opportunity.
  ///</param>
  ///<param name="quoteId"  type="String">
  /// Sets the ID of the quote.
  ///</param>
  if (!(this instanceof Sdk.GetQuoteProductsFromOpportunityRequest)) {
   return new Sdk.GetQuoteProductsFromOpportunityRequest(opportunityId, quoteId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _opportunityId = null;
  var _quoteId = null;

  // internal validation functions

  function _setValidOpportunityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _opportunityId = value;
   }
   else {
    throw new Error("Sdk.GetQuoteProductsFromOpportunityRequest OpportunityId property is required and must be a String.")
   }
  }

  function _setValidQuoteId(value) {
   if (Sdk.Util.isGuid(value)) {
    _quoteId = value;
   }
   else {
    throw new Error("Sdk.GetQuoteProductsFromOpportunityRequest QuoteId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof opportunityId != "undefined") {
   _setValidOpportunityId(opportunityId);
  }
  if (typeof quoteId != "undefined") {
   _setValidQuoteId(quoteId);
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
               "<b:key>QuoteId</b:key>",
              (_quoteId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _quoteId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>GetQuoteProductsFromOpportunity</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.GetQuoteProductsFromOpportunityResponse);
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

  this.setQuoteId = function (value) {
   ///<summary>
   /// Sets the ID of the quote.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the quote.
   ///</param>
   _setValidQuoteId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.GetQuoteProductsFromOpportunityRequest.__class = true;

 this.GetQuoteProductsFromOpportunityResponse = function (responseXml) {
  ///<summary>
  /// Response to GetQuoteProductsFromOpportunityRequest
  ///</summary>
  if (!(this instanceof Sdk.GetQuoteProductsFromOpportunityResponse)) {
   return new Sdk.GetQuoteProductsFromOpportunityResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values






 }
 this.GetQuoteProductsFromOpportunityResponse.__class = true;
}).call(Sdk)

Sdk.GetQuoteProductsFromOpportunityRequest.prototype = new Sdk.OrganizationRequest();
Sdk.GetQuoteProductsFromOpportunityResponse.prototype = new Sdk.OrganizationResponse();
