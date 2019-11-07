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
 this.SetBusinessSystemUserRequest = function (userId, businessId, reassignPrincipal) {
  ///<summary>
  /// Contains the data that is needed to  move a system user (user) to a different business unit.
  ///</summary>
  ///<param name="userId"  type="String">
  /// Sets the ID of the user. Required.
  ///</param>
  ///<param name="businessId"  type="String">
  /// Sets the ID of the business unit to which the user is moved. Required.
  ///</param>
  ///<param name="reassignPrincipal"  type="Sdk.EntityReference">
  /// Sets the target security principal (user) to which the instances of entities previously owned by the user are to be assigned. Required.
  ///</param>
  if (!(this instanceof Sdk.SetBusinessSystemUserRequest)) {
   return new Sdk.SetBusinessSystemUserRequest(userId, businessId, reassignPrincipal);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _userId = null;
  var _businessId = null;
  var _reassignPrincipal = null;

  // internal validation functions

  function _setValidUserId(value) {
   if (Sdk.Util.isGuid(value)) {
    _userId = value;
   }
   else {
    throw new Error("Sdk.SetBusinessSystemUserRequest UserId property is required and must be a String.")
   }
  }

  function _setValidBusinessId(value) {
   if (Sdk.Util.isGuid(value)) {
    _businessId = value;
   }
   else {
    throw new Error("Sdk.SetBusinessSystemUserRequest BusinessId property is required and must be a String.")
   }
  }

  function _setValidReassignPrincipal(value) {
   if (value instanceof Sdk.EntityReference) {
    _reassignPrincipal = value;
   }
   else {
    throw new Error("Sdk.SetBusinessSystemUserRequest ReassignPrincipal property is required and must be a Sdk.EntityReference.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof userId != "undefined") {
   _setValidUserId(userId);
  }
  if (typeof businessId != "undefined") {
   _setValidBusinessId(businessId);
  }
  if (typeof reassignPrincipal != "undefined") {
   _setValidReassignPrincipal(reassignPrincipal);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>UserId</b:key>",
              (_userId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _userId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>BusinessId</b:key>",
              (_businessId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _businessId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ReassignPrincipal</b:key>",
              (_reassignPrincipal == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _reassignPrincipal.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>SetBusinessSystemUser</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SetBusinessSystemUserResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setUserId = function (value) {
   ///<summary>
   /// Sets the ID of the user. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the user.
   ///</param>
   _setValidUserId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setBusinessId = function (value) {
   ///<summary>
   /// Sets the ID of the business unit to which the user is moved. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the business unit to which the user is moved.
   ///</param>
   _setValidBusinessId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setReassignPrincipal = function (value) {
   ///<summary>
   /// Sets the target security principal (user) to which the instances of entities previously owned by the user are to be assigned. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target security principal (user) to which the instances of entities previously owned by the user are to be assigned.
   ///</param>
   _setValidReassignPrincipal(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SetBusinessSystemUserRequest.__class = true;

 this.SetBusinessSystemUserResponse = function (responseXml) {
  ///<summary>
  /// Response to SetBusinessSystemUserRequest
  ///</summary>
  if (!(this instanceof Sdk.SetBusinessSystemUserResponse)) {
   return new Sdk.SetBusinessSystemUserResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.SetBusinessSystemUserResponse.__class = true;
}).call(Sdk)

Sdk.SetBusinessSystemUserRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SetBusinessSystemUserResponse.prototype = new Sdk.OrganizationResponse();
