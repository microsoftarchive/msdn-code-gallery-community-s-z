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
(function () {
 this.ConvertOwnerTeamToAccessTeamRequest = function (teamId) {
  ///<summary>
  /// Contains the data that is needed to convert a team of type owner to a team of type access. 
  ///</summary>
  ///<param name="teamId"  type="String">
  /// Sets the ID of the owner team to be converted. Required. 
  ///</param>
  if (!(this instanceof Sdk.ConvertOwnerTeamToAccessTeamRequest)) {
   return new Sdk.ConvertOwnerTeamToAccessTeamRequest(teamId);
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
    throw new Error("Sdk.ConvertOwnerTeamToAccessTeamRequest TeamId property is required and must be a String.")
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
           "<a:RequestName>ConvertOwnerTeamToAccessTeam</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ConvertOwnerTeamToAccessTeamResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTeamId = function (value) {
   ///<summary>
   /// Sets the ID of the owner team to be converted. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the owner team to be converted.
   ///</param>
   _setValidTeamId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ConvertOwnerTeamToAccessTeamRequest.__class = true;

 this.ConvertOwnerTeamToAccessTeamResponse = function (responseXml) {
  ///<summary>
  /// Response to ConvertOwnerTeamToAccessTeamRequest
  ///</summary>
  if (!(this instanceof Sdk.ConvertOwnerTeamToAccessTeamResponse)) {
   return new Sdk.ConvertOwnerTeamToAccessTeamResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values
 }
 this.ConvertOwnerTeamToAccessTeamResponse.__class = true;
}).call(Sdk)

Sdk.ConvertOwnerTeamToAccessTeamRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ConvertOwnerTeamToAccessTeamResponse.prototype = new Sdk.OrganizationResponse();
