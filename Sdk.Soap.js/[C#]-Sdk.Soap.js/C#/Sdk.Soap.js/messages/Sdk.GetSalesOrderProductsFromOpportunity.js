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
 this.GetSalesOrderProductsFromOpportunityRequest = function (opportunityId, salesOrderId) {
  ///<summary>
  /// Contains the data that is needed to  retrieve the products from an opportunity and copy them to the sales order (order).
  ///</summary>
  ///<param name="opportunityId"  type="String">
  /// Sets the ID of the opportunity.
  ///</param>
  ///<param name="salesOrderId"  type="String">
  /// Sets the ID of the sales order (order).
  ///</param>
  if (!(this instanceof Sdk.GetSalesOrderProductsFromOpportunityRequest)) {
   return new Sdk.GetSalesOrderProductsFromOpportunityRequest(opportunityId, salesOrderId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _opportunityId = null;
  var _salesOrderId = null;

  // internal validation functions

  function _setValidOpportunityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _opportunityId = value;
   }
   else {
    throw new Error("Sdk.GetSalesOrderProductsFromOpportunityRequest OpportunityId property is required and must be a String.")
   }
  }

  function _setValidSalesOrderId(value) {
   if (Sdk.Util.isGuid(value)) {
    _salesOrderId = value;
   }
   else {
    throw new Error("Sdk.GetSalesOrderProductsFromOpportunityRequest SalesOrderId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof opportunityId != "undefined") {
   _setValidOpportunityId(opportunityId);
  }
  if (typeof salesOrderId != "undefined") {
   _setValidSalesOrderId(salesOrderId);
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
               "<b:key>SalesOrderId</b:key>",
              (_salesOrderId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _salesOrderId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>GetSalesOrderProductsFromOpportunity</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.GetSalesOrderProductsFromOpportunityResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setOpportunityId = function (value) {
   ///<summary>
   /// Sets the ID of the opportunity.
   ///</summary>
   ///<param name="value" type="String">
   /// Sets the ID of the opportunity.
   ///</param>
   _setValidOpportunityId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSalesOrderId = function (value) {
   ///<summary>
   /// Sets the ID of the sales order (order).
   ///</summary>
   ///<param name="value" type="String">
   /// Sets the ID of the sales order (order).
   ///</param>
   _setValidSalesOrderId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.GetSalesOrderProductsFromOpportunityRequest.__class = true;

 this.GetSalesOrderProductsFromOpportunityResponse = function (responseXml) {
  ///<summary>
  /// Response to GetSalesOrderProductsFromOpportunityRequest
  ///</summary>
  if (!(this instanceof Sdk.GetSalesOrderProductsFromOpportunityResponse)) {
   return new Sdk.GetSalesOrderProductsFromOpportunityResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values






 }
 this.GetSalesOrderProductsFromOpportunityResponse.__class = true;
}).call(Sdk)

Sdk.GetSalesOrderProductsFromOpportunityRequest.prototype = new Sdk.OrganizationRequest();
Sdk.GetSalesOrderProductsFromOpportunityResponse.prototype = new Sdk.OrganizationResponse();
