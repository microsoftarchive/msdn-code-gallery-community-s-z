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
 this.RemoveMembersTeamRequest = function (teamId, memberIds) {
  ///<summary>
  /// Contains the data that is needed to  remove members from a team.
  ///</summary>
  ///<param name="teamId"  type="String">
  /// Sets the ID of the team.
  ///</param>
  ///<param name="memberIds"  type="Sdk.Collection">
  /// Sets an array of IDs of the users to be removed from the team.
  ///</param>
  if (!(this instanceof Sdk.RemoveMembersTeamRequest)) {
   return new Sdk.RemoveMembersTeamRequest(teamId, memberIds);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _teamId = null;
  var _memberIds = null;

  // internal validation functions

  function _setValidTeamId(value) {
   if (Sdk.Util.isGuid(value)) {
    _teamId = value;
   }
   else {
    throw new Error("Sdk.RemoveMembersTeamRequest TeamId property is required and must be a String.")
   }
  }

  function _setValidMemberIds(value) {
   if (Sdk.Util.isCollectionOf(value, String)) {
    _memberIds = value;
   }
   else {
    throw new Error("Sdk.RemoveMembersTeamRequest MemberIds property is required and must be a Sdk.Collection.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof teamId != "undefined") {
   _setValidTeamId(teamId);
  }
  if (typeof memberIds != "undefined") {
   _setValidMemberIds(memberIds);
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
               "<b:key>MemberIds</b:key>",
              (_memberIds == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"f:ArrayOfguid\">", _memberIds.toArrayOfValueXml("f:guid"), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RemoveMembersTeam</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RemoveMembersTeamResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTeamId = function (value) {
   ///<summary>
   /// Sets the ID of the team.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the team.
   ///</param>
   _setValidTeamId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setMemberIds = function (value) {
   ///<summary>
   /// Sets an array of IDs of the users to be removed from the team.
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// Sn array of IDs of the users to be removed from the team.
   ///</param>
   _setValidMemberIds(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RemoveMembersTeamRequest.__class = true;

 this.RemoveMembersTeamResponse = function (responseXml) {
  ///<summary>
  /// Response to RemoveMembersTeamRequest
  ///</summary>
  if (!(this instanceof Sdk.RemoveMembersTeamResponse)) {
   return new Sdk.RemoveMembersTeamResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.RemoveMembersTeamResponse.__class = true;
}).call(Sdk)

Sdk.RemoveMembersTeamRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RemoveMembersTeamResponse.prototype = new Sdk.OrganizationResponse();
