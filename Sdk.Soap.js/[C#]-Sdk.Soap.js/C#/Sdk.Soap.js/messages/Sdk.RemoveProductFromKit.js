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
 this.RemoveProductFromKitRequest = function (kitId, productId) {
  ///<summary>
  /// Contains the data that is needed to  remove a product from a kit.
  ///</summary>
  ///<param name="kitId"  type="String">
  /// Sets the ID of the kit from which the product is to be removed.
  ///</param>
  ///<param name="productId"  type="String">
  /// Sets the ID of the product being removed from the kit.
  ///</param>
  if (!(this instanceof Sdk.RemoveProductFromKitRequest)) {
   return new Sdk.RemoveProductFromKitRequest(kitId, productId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _kitId = null;
  var _productId = null;

  // internal validation functions

  function _setValidKitId(value) {
   if (Sdk.Util.isGuid(value)) {
    _kitId = value;
   }
   else {
    throw new Error("Sdk.RemoveProductFromKitRequest KitId property is required and must be a String.")
   }
  }

  function _setValidProductId(value) {
   if (Sdk.Util.isGuid(value)) {
    _productId = value;
   }
   else {
    throw new Error("Sdk.RemoveProductFromKitRequest ProductId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof kitId != "undefined") {
   _setValidKitId(kitId);
  }
  if (typeof productId != "undefined") {
   _setValidProductId(productId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>KitId</b:key>",
              (_kitId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _kitId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ProductId</b:key>",
              (_productId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _productId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RemoveProductFromKit</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RemoveProductFromKitResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setKitId = function (value) {
   ///<summary>
   /// Sets the ID of the kit from which the product is to be removed.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the kit from which the product is to be removed.
   ///</param>
   _setValidKitId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setProductId = function (value) {
   ///<summary>
   /// Sets the ID of the product being removed from the kit.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the product being removed from the kit.
   ///</param>
   _setValidProductId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RemoveProductFromKitRequest.__class = true;

 this.RemoveProductFromKitResponse = function (responseXml) {
  ///<summary>
  /// Response to RemoveProductFromKitRequest
  ///</summary>
  if (!(this instanceof Sdk.RemoveProductFromKitResponse)) {
   return new Sdk.RemoveProductFromKitResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.RemoveProductFromKitResponse.__class = true;
}).call(Sdk)

Sdk.RemoveProductFromKitRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RemoveProductFromKitResponse.prototype = new Sdk.OrganizationResponse();
