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
 this.SetParentBusinessUnitRequest = function (businessUnitId, parentId) {
  ///<summary>
  /// Contains the data that is needed to  set the parent business unit for a business unit. 
  ///</summary>
  ///<param name="businessUnitId"  type="String">
  /// Sets the ID of the business unit.
  ///</param>
  ///<param name="parentId"  type="String">
  /// Sets the ID of the new parent business unit.
  ///</param>
  if (!(this instanceof Sdk.SetParentBusinessUnitRequest)) {
   return new Sdk.SetParentBusinessUnitRequest(businessUnitId, parentId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _businessUnitId = null;
  var _parentId = null;

  // internal validation functions

  function _setValidBusinessUnitId(value) {
   if (Sdk.Util.isGuid(value)) {
    _businessUnitId = value;
   }
   else {
    throw new Error("Sdk.SetParentBusinessUnitRequest BusinessUnitId property is required and must be a String.")
   }
  }

  function _setValidParentId(value) {
   if (Sdk.Util.isGuid(value)) {
    _parentId = value;
   }
   else {
    throw new Error("Sdk.SetParentBusinessUnitRequest ParentId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof businessUnitId != "undefined") {
   _setValidBusinessUnitId(businessUnitId);
  }
  if (typeof parentId != "undefined") {
   _setValidParentId(parentId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>BusinessUnitId</b:key>",
              (_businessUnitId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _businessUnitId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ParentId</b:key>",
              (_parentId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _parentId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>SetParentBusinessUnit</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SetParentBusinessUnitResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setBusinessUnitId = function (value) {
   ///<summary>
   /// Sets the ID of the business unit.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the business unit.
   ///</param>
   _setValidBusinessUnitId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setParentId = function (value) {
   ///<summary>
   /// Sets the ID of the new parent business unit.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the new parent business unit.
   ///</param>
   _setValidParentId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SetParentBusinessUnitRequest.__class = true;

 this.SetParentBusinessUnitResponse = function (responseXml) {
  ///<summary>
  /// Response to SetParentBusinessUnitRequest
  ///</summary>
  if (!(this instanceof Sdk.SetParentBusinessUnitResponse)) {
   return new Sdk.SetParentBusinessUnitResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.SetParentBusinessUnitResponse.__class = true;
}).call(Sdk)

Sdk.SetParentBusinessUnitRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SetParentBusinessUnitResponse.prototype = new Sdk.OrganizationResponse();
