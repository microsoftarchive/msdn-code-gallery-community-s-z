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
 this.RemovePrivilegeRoleRequest = function (roleId, privilegeId) {
  ///<summary>
  /// Contains the data that is needed to  remove a privilege from an existing role.
  ///</summary>
  ///<param name="roleId"  type="String">
  /// Sets the ID of the role from which the privilege is to be removed.
  ///</param>
  ///<param name="privilegeId"  type="String">
  /// Sets the ID of the privilege that is to be removed from the existing role.
  ///</param>
  if (!(this instanceof Sdk.RemovePrivilegeRoleRequest)) {
   return new Sdk.RemovePrivilegeRoleRequest(roleId, privilegeId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _roleId = null;
  var _privilegeId = null;

  // internal validation functions

  function _setValidRoleId(value) {
   if (Sdk.Util.isGuid(value)) {
    _roleId = value;
   }
   else {
    throw new Error("Sdk.RemovePrivilegeRoleRequest RoleId property is required and must be a String.")
   }
  }

  function _setValidPrivilegeId(value) {
   if (Sdk.Util.isGuid(value)) {
    _privilegeId = value;
   }
   else {
    throw new Error("Sdk.RemovePrivilegeRoleRequest PrivilegeId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof roleId != "undefined") {
   _setValidRoleId(roleId);
  }
  if (typeof privilegeId != "undefined") {
   _setValidPrivilegeId(privilegeId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>RoleId</b:key>",
              (_roleId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _roleId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>PrivilegeId</b:key>",
              (_privilegeId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _privilegeId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RemovePrivilegeRole</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RemovePrivilegeRoleResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setRoleId = function (value) {
   ///<summary>
   /// Sets the ID of the role from which the privilege is to be removed.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the role from which the privilege is to be removed.
   ///</param>
   _setValidRoleId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setPrivilegeId = function (value) {
   ///<summary>
   /// Sets the ID of the privilege that is to be removed from the existing role.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the privilege that is to be removed from the existing role.
   ///</param>
   _setValidPrivilegeId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RemovePrivilegeRoleRequest.__class = true;

 this.RemovePrivilegeRoleResponse = function (responseXml) {
  ///<summary>
  /// Response to RemovePrivilegeRoleRequest
  ///</summary>
  if (!(this instanceof Sdk.RemovePrivilegeRoleResponse)) {
   return new Sdk.RemovePrivilegeRoleResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.RemovePrivilegeRoleResponse.__class = true;
}).call(Sdk)

Sdk.RemovePrivilegeRoleRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RemovePrivilegeRoleResponse.prototype = new Sdk.OrganizationResponse();
