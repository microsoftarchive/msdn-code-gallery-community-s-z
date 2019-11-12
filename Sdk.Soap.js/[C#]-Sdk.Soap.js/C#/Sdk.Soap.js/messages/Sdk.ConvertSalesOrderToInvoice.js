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
 this.ConvertSalesOrderToInvoiceRequest = function (salesOrderId, columnSet) {
  ///<summary>
  /// Contains the data that is needed to convert a sales order to an invoice. 
  ///</summary>
  ///<param name="salesOrderId"  type="String">
  /// Sets the ID of the sales order (order) to convert. Required. 
  ///</param>
  ///<param name="columnSet"  type="Sdk.ColumnSet">
  /// Sets the collection of attributes to retrieve from the resulting invoice. Required. 
  ///</param>
  if (!(this instanceof Sdk.ConvertSalesOrderToInvoiceRequest)) {
   return new Sdk.ConvertSalesOrderToInvoiceRequest(salesOrderId, columnSet);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _salesOrderId = null;
  var _columnSet = null;

  // internal validation functions

  function _setValidSalesOrderId(value) {
   if (Sdk.Util.isGuid(value)) {
    _salesOrderId = value;
   }
   else {
    throw new Error("Sdk.ConvertSalesOrderToInvoiceRequest SalesOrderId property is required and must be a String.")
   }
  }

  function _setValidColumnSet(value) {
   if (value instanceof Sdk.ColumnSet) {
    _columnSet = value;
   }
   else {
    throw new Error("Sdk.ConvertSalesOrderToInvoiceRequest ColumnSet property is required and must be a Sdk.ColumnSet.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof salesOrderId != "undefined") {
   _setValidSalesOrderId(salesOrderId);
  }
  if (typeof columnSet != "undefined") {
   _setValidColumnSet(columnSet);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SalesOrderId</b:key>",
              (_salesOrderId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _salesOrderId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ColumnSet</b:key>",
              (_columnSet == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:ColumnSet\">", _columnSet.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ConvertSalesOrderToInvoice</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ConvertSalesOrderToInvoiceResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setSalesOrderId = function (value) {
   ///<summary>
   /// Sets the ID of the sales order (order) to convert. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the sales order (order) to convert.
   ///</param>
   _setValidSalesOrderId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setColumnSet = function (value) {
   ///<summary>
   /// Sets the collection of attributes to retrieve from the resulting invoice. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.ColumnSet">
   /// The collection of attributes to retrieve from the resulting invoice.
   ///</param>
   _setValidColumnSet(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ConvertSalesOrderToInvoiceRequest.__class = true;

 this.ConvertSalesOrderToInvoiceResponse = function (responseXml) {
  ///<summary>
  /// Response to ConvertSalesOrderToInvoiceRequest
  ///</summary>
  if (!(this instanceof Sdk.ConvertSalesOrderToInvoiceResponse)) {
   return new Sdk.ConvertSalesOrderToInvoiceResponse(responseXml);
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
   /// Gets the resulting invoice. 
   ///</summary>
   ///<returns type="Sdk.Entity">
   /// The resulting invoice. 
   ///</returns>
   return _entity;
  }

  //Set property values from responseXml constructor parameter
  _setEntity(responseXml);
 }
 this.ConvertSalesOrderToInvoiceResponse.__class = true;
}).call(Sdk)

Sdk.ConvertSalesOrderToInvoiceRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ConvertSalesOrderToInvoiceResponse.prototype = new Sdk.OrganizationResponse();
