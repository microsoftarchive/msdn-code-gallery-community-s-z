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
 this.ReplacePrivilegesRoleRequest = function (roleId, privileges) {
  ///<summary>
  /// Contains the data that is needed to  replace the privilege set of an existing role.
  ///</summary>
  ///<param name="roleId"  type="String">
  /// Sets the ID of the role for which the privileges are to be replaced.
  ///</param>
  ///<param name="privileges"  type="Sdk.Collection">
  /// Sets an array that contains the IDs and depths of the privileges that replace the existing privileges.
  ///</param>
  if (!(this instanceof Sdk.ReplacePrivilegesRoleRequest)) {
   return new Sdk.ReplacePrivilegesRoleRequest(roleId, privileges);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _roleId = null;
  var _privileges = null;

  // internal validation functions

  function _setValidRoleId(value) {
   if (Sdk.Util.isGuid(value)) {
    _roleId = value;
   }
   else {
    throw new Error("Sdk.ReplacePrivilegesRoleRequest RoleId property is required and must be a String.")
   }
  }

  function _setValidPrivileges(value) {
   if (Sdk.Util.isCollectionOf(value, Sdk.RolePrivilege)) {
    _privileges = value;
   }
   else {
    throw new Error("Sdk.ReplacePrivilegesRoleRequest Privileges property is required and must be a Sdk.Collection.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof roleId != "undefined") {
   _setValidRoleId(roleId);
  }
  if (typeof privileges != "undefined") {
   _setValidPrivileges(privileges);
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
               "<b:key>Privileges</b:key>",
              (_privileges == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"g:ArrayOfRolePrivilege\">", _privileges.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ReplacePrivilegesRole</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ReplacePrivilegesRoleResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setRoleId = function (value) {
   ///<summary>
   /// Sets the ID of the role for which the privileges are to be replaced.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the role for which the privileges are to be replaced.
   ///</param>
   _setValidRoleId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setPrivileges = function (value) {
   ///<summary>
   /// Sets an array that contains the IDs and depths of the privileges that replace the existing privileges.
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// An array that contains the IDs and depths of the privileges that replace the existing privileges.
   ///</param>
   _setValidPrivileges(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ReplacePrivilegesRoleRequest.__class = true;

 this.ReplacePrivilegesRoleResponse = function (responseXml) {
  ///<summary>
  /// Response to ReplacePrivilegesRoleRequest
  ///</summary>
  if (!(this instanceof Sdk.ReplacePrivilegesRoleResponse)) {
   return new Sdk.ReplacePrivilegesRoleResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.ReplacePrivilegesRoleResponse.__class = true;
}).call(Sdk)

Sdk.ReplacePrivilegesRoleRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ReplacePrivilegesRoleResponse.prototype = new Sdk.OrganizationResponse();
