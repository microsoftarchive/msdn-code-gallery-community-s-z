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
this.ReassignObjectsSystemUserRequest = function (userId,reassignPrincipal){
///<summary>
/// Contains the data that is needed to reassign all records that are owned by a specified user to another security principal (user or team).
///</summary>
///<param name="userId"  type="String">
/// Sets the ID of the user for which you want to reassign all records.
///</param>
///<param name="reassignPrincipal"  type="Sdk.EntityReference">
/// Sets the security principal (user or team) that is the new owner for the records.
///</param>
if (!(this instanceof Sdk.ReassignObjectsSystemUserRequest)) {
return new Sdk.ReassignObjectsSystemUserRequest(userId, reassignPrincipal);
}
Sdk.OrganizationRequest.call(this);

  // Internal properties
var _userId = null;
var _reassignPrincipal = null;

// internal validation functions

function _setValidUserId(value) {
 if (Sdk.Util.isGuid(value)) {
  _userId = value;
 }
 else {
  throw new Error("Sdk.ReassignObjectsSystemUserRequest UserId property is required and must be a String.")
 }
}

function _setValidReassignPrincipal(value) {
 if (value instanceof Sdk.EntityReference) {
  _reassignPrincipal = value;
 }
 else {
  throw new Error("Sdk.ReassignObjectsSystemUserRequest ReassignPrincipal property is required and must be a Sdk.EntityReference.")
 }
}

//Set internal properties from constructor parameters
  if (typeof userId != "undefined") {
   _setValidUserId(userId);
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
            "<b:key>ReassignPrincipal</b:key>",
           (_reassignPrincipal == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"a:EntityReference\">", _reassignPrincipal.toValueXml(), "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

        "</a:Parameters>",
        "<a:RequestId i:nil=\"true\" />",
        "<a:RequestName>ReassignObjectsSystemUser</a:RequestName>",
      "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ReassignObjectsSystemUserResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setUserId = function (value) {
  ///<summary>
  /// Sets the ID of the user for which you want to reassign all records.
  ///</summary>
  ///<param name="value" type="String">
  /// The ID of the user for which you want to reassign all records.
  ///</param>
   _setValidUserId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setReassignPrincipal = function (value) {
  ///<summary>
  /// Sets the security principal (user or team) that is the new owner for the records.
  ///</summary>
  ///<param name="value" type="Sdk.EntityReference">
  /// The security principal (user or team) that is the new owner for the records.
  ///</param>
   _setValidReassignPrincipal(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ReassignObjectsSystemUserRequest.__class = true;

this.ReassignObjectsSystemUserResponse = function (responseXml) {
  ///<summary>
  /// Response to ReassignObjectsSystemUserRequest
  ///</summary>
  if (!(this instanceof Sdk.ReassignObjectsSystemUserResponse)) {
   return new Sdk.ReassignObjectsSystemUserResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.ReassignObjectsSystemUserResponse.__class = true;
}).call(Sdk)

Sdk.ReassignObjectsSystemUserRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ReassignObjectsSystemUserResponse.prototype = new Sdk.OrganizationResponse();
