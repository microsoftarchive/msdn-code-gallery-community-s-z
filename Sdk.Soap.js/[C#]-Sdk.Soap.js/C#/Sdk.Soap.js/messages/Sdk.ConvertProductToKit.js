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
 this.ConvertProductToKitRequest = function (productId) {
  ///<summary>
  /// Contains the data that is needed to convert a product to a kit. 
  ///</summary>
  ///<param name="productId"  type="String">
  /// Sets the ID of the product. Required. 
  ///</param>
  if (!(this instanceof Sdk.ConvertProductToKitRequest)) {
   return new Sdk.ConvertProductToKitRequest(productId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _productId = null;

  // internal validation functions

  function _setValidProductId(value) {
   if (Sdk.Util.isGuid(value)) {
    _productId = value;
   }
   else {
    throw new Error("Sdk.ConvertProductToKitRequest ProductId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof productId != "undefined") {
   _setValidProductId(productId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ProductId</b:key>",
              (_productId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _productId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ConvertProductToKit</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ConvertProductToKitResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
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

 }
 this.ConvertProductToKitRequest.__class = true;

 this.ConvertProductToKitResponse = function (responseXml) {
  ///<summary>
  /// Response to ConvertProductToKitRequest
  ///</summary>
  if (!(this instanceof Sdk.ConvertProductToKitResponse)) {
   return new Sdk.ConvertProductToKitResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values
 }
 this.ConvertProductToKitResponse.__class = true;
}).call(Sdk)

Sdk.ConvertProductToKitRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ConvertProductToKitResponse.prototype = new Sdk.OrganizationResponse();
