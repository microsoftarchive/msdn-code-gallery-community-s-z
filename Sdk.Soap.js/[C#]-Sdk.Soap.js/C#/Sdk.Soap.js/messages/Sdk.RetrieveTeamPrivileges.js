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
 this.RetrieveTeamPrivilegesRequest = function (teamId) {
  ///<summary>
  /// Contains the data that is needed to retrieve the privileges for a team.
  ///</summary>
  ///<param name="teamId"  type="String">
  /// Sets the team for which you want to retrieve privileges.
  ///</param>
  if (!(this instanceof Sdk.RetrieveTeamPrivilegesRequest)) {
   return new Sdk.RetrieveTeamPrivilegesRequest(teamId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _teamId = null;

  // internal validation functions

  function _setValidTeamId(value) {
   if (Sdk.Util.isGuid(value)) {
    _teamId = value;
   }
   else {
    throw new Error("Sdk.RetrieveTeamPrivilegesRequest TeamId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof teamId != "undefined") {
   _setValidTeamId(teamId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>TeamId</b:key>",
              (_teamId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _teamId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveTeamPrivileges</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveTeamPrivilegesResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTeamId = function (value) {
   ///<summary>
   /// Sets the team for which you want to retrieve privileges.
   ///</summary>
   ///<param name="value" type="String">
   /// The team for which you want to retrieve privileges.
   ///</param>
   _setValidTeamId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveTeamPrivilegesRequest.__class = true;

 this.RetrieveTeamPrivilegesResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveTeamPrivilegesRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveTeamPrivilegesResponse)) {
   return new Sdk.RetrieveTeamPrivilegesResponse(responseXml);
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
   /// Gets the list of privileges that the team holds for a record.
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// The list of privileges that the team holds for a record.
   ///</returns>
   return _rolePrivileges;
  }

  //Set property values from responseXml constructor parameter
  _setRolePrivileges(responseXml);
 }
 this.RetrieveTeamPrivilegesResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveTeamPrivilegesRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveTeamPrivilegesResponse.prototype = new Sdk.OrganizationResponse();
