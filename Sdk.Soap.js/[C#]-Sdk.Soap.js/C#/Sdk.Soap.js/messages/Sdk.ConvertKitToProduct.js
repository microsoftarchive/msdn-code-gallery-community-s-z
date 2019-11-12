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
 this.ConvertKitToProductRequest = function (kitId) {
  ///<summary>
  /// Contains the data that is needed to convert a kit to a product. 
  ///</summary>
  ///<param name="kitId"  type="String">
  /// Sets the ID of the kit. Required. 
  ///</param>
  if (!(this instanceof Sdk.ConvertKitToProductRequest)) {
   return new Sdk.ConvertKitToProductRequest(kitId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _kitId = null;

  // internal validation functions

  function _setValidKitId(value) {
   if (Sdk.Util.isGuid(value)) {
    _kitId = value;
   }
   else {
    throw new Error("Sdk.ConvertKitToProductRequest KitId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof kitId != "undefined") {
   _setValidKitId(kitId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>KitId</b:key>",
              (_kitId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _kitId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ConvertKitToProduct</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ConvertKitToProductResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setKitId = function (value) {
   ///<summary>
   /// Sets the ID of the kit. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the kit.
   ///</param>
   _setValidKitId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ConvertKitToProductRequest.__class = true;

 this.ConvertKitToProductResponse = function (responseXml) {
  ///<summary>
  /// Response to ConvertKitToProductRequest
  ///</summary>
  if (!(this instanceof Sdk.ConvertKitToProductResponse)) {
   return new Sdk.ConvertKitToProductResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values
 }
 this.ConvertKitToProductResponse.__class = true;
}).call(Sdk)

Sdk.ConvertKitToProductRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ConvertKitToProductResponse.prototype = new Sdk.OrganizationResponse();
