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
 this.RetrieveUserPrivilegesRequest = function (userId) {
  ///<summary>
  /// Contains the data needed to retrieve the privileges a system user (user) has through his or her roles in the specified business unit.
  ///</summary>
  ///<param name="userId"  type="String">
  /// Sets the user to retrieve privileges for.
  ///</param>
  if (!(this instanceof Sdk.RetrieveUserPrivilegesRequest)) {
   return new Sdk.RetrieveUserPrivilegesRequest(userId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _userId = null;

  // internal validation functions

  function _setValidUserId(value) {
   if (Sdk.Util.isGuid(value)) {
    _userId = value;
   }
   else {
    throw new Error("Sdk.RetrieveUserPrivilegesRequest UserId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof userId != "undefined") {
   _setValidUserId(userId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>UserId</b:key>",
              (_userId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _userId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveUserPrivileges</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveUserPrivilegesResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setUserId = function (value) {
   ///<summary>
   /// Sets the user to retrieve privileges for.
   ///</summary>
   ///<param name="value" type="String">
   /// The user to retrieve privileges for.
   ///</param>
   _setValidUserId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveUserPrivilegesRequest.__class = true;

 this.RetrieveUserPrivilegesResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveUserPrivilegesRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveUserPrivilegesResponse)) {
   return new Sdk.RetrieveUserPrivilegesResponse(responseXml);
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
   /// Gets a collection of privileges that the user holds.
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// A collection of privileges that the user holds.
   ///</returns>
   return _rolePrivileges;
  }

  //Set property values from responseXml constructor parameter
  _setRolePrivileges(responseXml);
 }
 this.RetrieveUserPrivilegesResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveUserPrivilegesRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveUserPrivilegesResponse.prototype = new Sdk.OrganizationResponse();
