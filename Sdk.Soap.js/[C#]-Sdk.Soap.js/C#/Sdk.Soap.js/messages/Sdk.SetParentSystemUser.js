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
 this.SetParentSystemUserRequest = function (userId, parentId, keepChildUsers) {
  ///<summary>
  /// Contains the data needed to set a new parent system user (user) for the specified user.
  ///</summary>
  ///<param name="userId"  type="String">
  /// Sets the ID of the user. Required.
  ///</param>
  ///<param name="parentId"  type="String">
  /// Sets the ID of the new parent user. Required.
  ///</param>
  ///<param name="keepChildUsers"  type="Boolean">
  /// Sets whether the child users are to be retained. Required.
  ///</param>
  if (!(this instanceof Sdk.SetParentSystemUserRequest)) {
   return new Sdk.SetParentSystemUserRequest(userId, parentId, keepChildUsers);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _userId = null;
  var _parentId = null;
  var _keepChildUsers = null;

  // internal validation functions

  function _setValidUserId(value) {
   if (Sdk.Util.isGuid(value)) {
    _userId = value;
   }
   else {
    throw new Error("Sdk.SetParentSystemUserRequest UserId property is required and must be a String.")
   }
  }

  function _setValidParentId(value) {
   if (Sdk.Util.isGuid(value)) {
    _parentId = value;
   }
   else {
    throw new Error("Sdk.SetParentSystemUserRequest ParentId property is required and must be a String.")
   }
  }

  function _setValidKeepChildUsers(value) {
   if (typeof value == "boolean") {
    _keepChildUsers = value;
   }
   else {
    throw new Error("Sdk.SetParentSystemUserRequest KeepChildUsers property is required and must be a Boolean.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof userId != "undefined") {
   _setValidUserId(userId);
  }
  if (typeof parentId != "undefined") {
   _setValidParentId(parentId);
  }
  if (typeof keepChildUsers != "undefined") {
   _setValidKeepChildUsers(keepChildUsers);
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
               "<b:key>ParentId</b:key>",
              (_parentId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _parentId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>KeepChildUsers</b:key>",
              (_keepChildUsers == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _keepChildUsers, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>SetParentSystemUser</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SetParentSystemUserResponse);
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

  this.setParentId = function (value) {
   ///<summary>
   /// Sets the ID of the new parent user. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the new parent user.
   ///</param>
   _setValidParentId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setKeepChildUsers = function (value) {
   ///<summary>
   /// Sets whether the child users are to be retained. Required.
   ///</summary>
   ///<param name="value" type="Boolean">
   /// Whether the child users are to be retained.
   ///</param>
   _setValidKeepChildUsers(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SetParentSystemUserRequest.__class = true;

 this.SetParentSystemUserResponse = function (responseXml) {
  ///<summary>
  /// Response to SetParentSystemUserRequest
  ///</summary>
  if (!(this instanceof Sdk.SetParentSystemUserResponse)) {
   return new Sdk.SetParentSystemUserResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values
 }
 this.SetParentSystemUserResponse.__class = true;
}).call(Sdk)

Sdk.SetParentSystemUserRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SetParentSystemUserResponse.prototype = new Sdk.OrganizationResponse();
