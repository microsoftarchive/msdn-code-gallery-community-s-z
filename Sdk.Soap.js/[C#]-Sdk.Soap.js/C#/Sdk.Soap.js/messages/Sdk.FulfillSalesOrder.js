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
 this.FulfillSalesOrderRequest = function (orderClose, status) {
  ///<summary>
  /// Contains the data that is needed to fulfill the sales order (order). 
  ///</summary>
  ///<param name="orderClose"  type="Sdk.Entity">
  /// Sets the order close activity associated with the sales order (order) to be fulfilled. Required. 
  ///</param>
  ///<param name="status"  type="Number">
  /// Sets a status of the sales order (order). Required. 
  ///</param>
  if (!(this instanceof Sdk.FulfillSalesOrderRequest)) {
   return new Sdk.FulfillSalesOrderRequest(orderClose, status);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _orderClose = null;
  var _status = null;

  // internal validation functions

  function _setValidOrderClose(value) {
   if (value instanceof Sdk.Entity) {
    _orderClose = value;
   }
   else {
    throw new Error("Sdk.FulfillSalesOrderRequest OrderClose property is required and must be a Sdk.Entity.")
   }
  }

  function _setValidStatus(value) {
   if (typeof value == "number") {
    _status = value;
   }
   else {
    throw new Error("Sdk.FulfillSalesOrderRequest Status property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof orderClose != "undefined") {
   _setValidOrderClose(orderClose);
  }
  if (typeof status != "undefined") {
   _setValidStatus(status);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>OrderClose</b:key>",
              (_orderClose == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:Entity\">", _orderClose.toValueXml(), "</b:value>"].join(""),
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
           "<a:RequestName>FulfillSalesOrder</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.FulfillSalesOrderResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setOrderClose = function (value) {
   ///<summary>
   /// Sets the order close activity associated with the sales order (order) to be fulfilled. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The order close activity associated with the sales order (order) to be fulfilled. 
   ///</param>
   _setValidOrderClose(value);
   this.setRequestXml(getRequestXml());
  }

  this.setStatus = function (value) {
   ///<summary>
   ///  Sets a status of the sales order (order). Required. 
   ///</summary>
   ///<param name="value" type="Number">
   ///  A status of the sales order (order). 
   ///</param>
   _setValidStatus(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.FulfillSalesOrderRequest.__class = true;

 this.FulfillSalesOrderResponse = function (responseXml) {
  ///<summary>
  /// Response to FulfillSalesOrderRequest
  ///</summary>
  if (!(this instanceof Sdk.FulfillSalesOrderResponse)) {
   return new Sdk.FulfillSalesOrderResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values
 }
 this.FulfillSalesOrderResponse.__class = true;
}).call(Sdk)

Sdk.FulfillSalesOrderRequest.prototype = new Sdk.OrganizationRequest();
Sdk.FulfillSalesOrderResponse.prototype = new Sdk.OrganizationResponse();
