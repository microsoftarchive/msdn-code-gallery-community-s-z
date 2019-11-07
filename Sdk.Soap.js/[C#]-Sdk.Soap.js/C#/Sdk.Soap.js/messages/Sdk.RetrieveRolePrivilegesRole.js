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
 this.RetrieveRolePrivilegesRoleRequest = function (roleId) {
  ///<summary>
  /// Contains the data that is needed to retrieve the privileges that are assigned to the specified role.
  ///</summary>
  ///<param name="roleId"  type="String">
  /// Sets the ID of the role for which the privileges are to be retrieved.
  ///</param>
  if (!(this instanceof Sdk.RetrieveRolePrivilegesRoleRequest)) {
   return new Sdk.RetrieveRolePrivilegesRoleRequest(roleId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _roleId = null;

  // internal validation functions

  function _setValidRoleId(value) {
   if (Sdk.Util.isGuid(value)) {
    _roleId = value;
   }
   else {
    throw new Error("Sdk.RetrieveRolePrivilegesRoleRequest RoleId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof roleId != "undefined") {
   _setValidRoleId(roleId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>RoleId</b:key>",
              (_roleId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _roleId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveRolePrivilegesRole</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveRolePrivilegesRoleResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setRoleId = function (value) {
   ///<summary>
   /// Sets the ID of the role for which the privileges are to be retrieved.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the role for which the privileges are to be retrieved.
   ///</param>
   _setValidRoleId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveRolePrivilegesRoleRequest.__class = true;

 this.RetrieveRolePrivilegesRoleResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveRolePrivilegesRoleRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveRolePrivilegesRoleResponse)) {
   return new Sdk.RetrieveRolePrivilegesRoleResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _rolePrivileges = null;

  // Internal property setter functions

  function _setRolePrivileges(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='RolePrivileges']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _rolePrivileges = Sdk.Util.createRolePrivilegeCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getRolePrivileges = function () {
   ///<summary>
   /// Gets a collection that contains the IDs and depths of the privileges that are held by the specified role.
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// A collection that contains the IDs and depths of the privileges that are held by the specified role.
   ///</returns>
   return _rolePrivileges;
  }

  //Set property values from responseXml constructor parameter
  _setRolePrivileges(responseXml);
 }
 this.RetrieveRolePrivilegesRoleResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveRolePrivilegesRoleRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveRolePrivilegesRoleResponse.prototype = new Sdk.OrganizationResponse();
