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
 this.GetQuantityDecimalRequest = function (target, productId, uoMId) {
  ///<summary>
  /// Contains the data that is needed to get the quantity decimal value of a product for the specified entity in the target. 
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target record for this request. Required. 
  ///</param>
  ///<param name="productId"  type="String">
  /// Sets the ID of the product. Required. 
  ///</param>
  ///<param name="uoMId"  type="String">
  /// Sets the ID of the unit of measure (unit). Required. 
  ///</param>
  if (!(this instanceof Sdk.GetQuantityDecimalRequest)) {
   return new Sdk.GetQuantityDecimalRequest(target, productId, uoMId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _productId = null;
  var _uoMId = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.EntityReference) {
    _target = value;
   }
   else {
    throw new Error("Sdk.GetQuantityDecimalRequest Target property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidProductId(value) {
   if (Sdk.Util.isGuid(value)) {
    _productId = value;
   }
   else {
    throw new Error("Sdk.GetQuantityDecimalRequest ProductId property is required and must be a String.")
   }
  }

  function _setValidUoMId(value) {
   if (Sdk.Util.isGuid(value)) {
    _uoMId = value;
   }
   else {
    throw new Error("Sdk.GetQuantityDecimalRequest UoMId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof productId != "undefined") {
   _setValidProductId(productId);
  }
  if (typeof uoMId != "undefined") {
   _setValidUoMId(uoMId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Target</b:key>",
              (_target == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _target.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ProductId</b:key>",
              (_productId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _productId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>UoMId</b:key>",
              (_uoMId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _uoMId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>GetQuantityDecimal</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.GetQuantityDecimalResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target record for this request. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target record for this request. 
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setProductId = function (value) {
   ///<summary>
   /// Sets the ID of the product. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the product. 
   ///</param>
   _setValidProductId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setUoMId = function (value) {
   ///<summary>
   /// Sets the ID of the unit of measure (unit). Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the unit of measure (unit).
   ///</param>
   _setValidUoMId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.GetQuantityDecimalRequest.__class = true;

 this.GetQuantityDecimalResponse = function (responseXml) {
  ///<summary>
  /// Response to GetQuantityDecimalRequest
  ///</summary>
  if (!(this instanceof Sdk.GetQuantityDecimalResponse)) {
   return new Sdk.GetQuantityDecimalResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _quantity = null;

  // Internal property setter functions

  function _setQuantity(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Quantity']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _quantity = parseInt(Sdk.Xml.getNodeText(valueNode), 10);
   }
  }
  //Public Methods to retrieve properties
  this.getQuantity = function () {
   ///<summary>
   /// Gets the quantity decimal value for a product. 
   ///</summary>
   ///<returns type="Number">
   /// The quantity decimal value for a product. 
   ///</returns>
   return _quantity;
  }

  //Set property values from responseXml constructor parameter
  _setQuantity(responseXml);
 }
 this.GetQuantityDecimalResponse.__class = true;
}).call(Sdk)

Sdk.GetQuantityDecimalRequest.prototype = new Sdk.OrganizationRequest();
Sdk.GetQuantityDecimalResponse.prototype = new Sdk.OrganizationResponse();
