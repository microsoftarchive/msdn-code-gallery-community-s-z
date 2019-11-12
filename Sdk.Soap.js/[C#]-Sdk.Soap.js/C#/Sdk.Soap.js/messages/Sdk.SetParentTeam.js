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
 this.SetParentTeamRequest = function (teamId, businessId) {
  ///<summary>
  /// Contains the data needed to set the parent business unit of a team.
  ///</summary>
  ///<param name="teamId"  type="String">
  /// Sets the ID of the team. Required.
  ///</param>
  ///<param name="businessId"  type="String">
  /// Sets the ID of the business unit to which to move the team. Required.
  ///</param>
  if (!(this instanceof Sdk.SetParentTeamRequest)) {
   return new Sdk.SetParentTeamRequest(teamId, businessId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _teamId = null;
  var _businessId = null;

  // internal validation functions

  function _setValidTeamId(value) {
   if (Sdk.Util.isGuid(value)) {
    _teamId = value;
   }
   else {
    throw new Error("Sdk.SetParentTeamRequest TeamId property is required and must be a String.")
   }
  }

  function _setValidBusinessId(value) {
   if (Sdk.Util.isGuid(value)) {
    _businessId = value;
   }
   else {
    throw new Error("Sdk.SetParentTeamRequest BusinessId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof teamId != "undefined") {
   _setValidTeamId(teamId);
  }
  if (typeof businessId != "undefined") {
   _setValidBusinessId(businessId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>TeamId</b:key>",
              (_teamId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _teamId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>BusinessId</b:key>",
              (_businessId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _businessId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>SetParentTeam</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SetParentTeamResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTeamId = function (value) {
   ///<summary>
   /// Sets the ID of the team. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the team.
   ///</param>
   _setValidTeamId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setBusinessId = function (value) {
   ///<summary>
   /// Sets the ID of the business unit to which to move the team. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the business unit to which to move the team.
   ///</param>
   _setValidBusinessId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SetParentTeamRequest.__class = true;

 this.SetParentTeamResponse = function (responseXml) {
  ///<summary>
  /// Response to SetParentTeamRequest
  ///</summary>
  if (!(this instanceof Sdk.SetParentTeamResponse)) {
   return new Sdk.SetParentTeamResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.SetParentTeamResponse.__class = true;
}).call(Sdk)

Sdk.SetParentTeamRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SetParentTeamResponse.prototype = new Sdk.OrganizationResponse();
