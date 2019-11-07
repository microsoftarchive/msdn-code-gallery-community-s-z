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
 this.AddUserToRecordTeamRequest = function (record, teamTemplateId, systemUserId) {
  ///<summary>
  /// Contains the data that is needed to add a user to the auto created access team for the specified record. 
  ///</summary>
  ///<param name="record"  type="Sdk.EntityReference">
  /// Sets the record for which the access team is auto created.
  ///</param>
  ///<param name="teamTemplateId"  type="String">
  /// Sets the ID of team template which is used to create the access team.
  ///</param>
  ///<param name="systemUserId"  type="String">
  /// Sets the ID of system user (user) to add to the auto created access team. 
  ///</param>
  if (!(this instanceof Sdk.AddUserToRecordTeamRequest)) {
   return new Sdk.AddUserToRecordTeamRequest(record, teamTemplateId, systemUserId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _record = null;
  var _teamTemplateId = null;
  var _systemUserId = null;

  // internal validation functions

  function _setValidRecord(value) {
   if (value instanceof Sdk.EntityReference) {
    _record = value;
   }
   else {
    throw new Error("Sdk.AddUserToRecordTeamRequest Record property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidTeamTemplateId(value) {
   if (Sdk.Util.isGuid(value)) {
    _teamTemplateId = value;
   }
   else {
    throw new Error("Sdk.AddUserToRecordTeamRequest TeamTemplateId property is required and must be a String.")
   }
  }

  function _setValidSystemUserId(value) {
   if (Sdk.Util.isGuid(value)) {
    _systemUserId = value;
   }
   else {
    throw new Error("Sdk.AddUserToRecordTeamRequest SystemUserId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof record != "undefined") {
   _setValidRecord(record);
  }
  if (typeof teamTemplateId != "undefined") {
   _setValidTeamTemplateId(teamTemplateId);
  }
  if (typeof systemUserId != "undefined") {
   _setValidSystemUserId(systemUserId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Record</b:key>",
              (_record == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _record.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>TeamTemplateId</b:key>",
              (_teamTemplateId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _teamTemplateId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SystemUserId</b:key>",
              (_systemUserId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _systemUserId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>AddUserToRecordTeam</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.AddUserToRecordTeamResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setRecord = function (value) {
   ///<summary>
   /// Sets the record for which the access team is auto created. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The record for which the access team is auto created.
   ///</param>
   _setValidRecord(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTeamTemplateId = function (value) {
   ///<summary>
   /// Sets the ID of team template which is used to create the access team. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of team template which is used to create the access team.
   ///</param>
   _setValidTeamTemplateId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSystemUserId = function (value) {
   ///<summary>
   /// Sets the ID of system user (user) to add to the auto created access team. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of system user (user) to add to the auto created access team.
   ///</param>
   _setValidSystemUserId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.AddUserToRecordTeamRequest.__class = true;

 this.AddUserToRecordTeamResponse = function (responseXml) {
  ///<summary>
  /// Response to AddUserToRecordTeamRequest
  ///</summary>
  if (!(this instanceof Sdk.AddUserToRecordTeamResponse)) {
   return new Sdk.AddUserToRecordTeamResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _accessTeamId = null;

  // Internal property setter functions

  function _setAccessTeamId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='AccessTeamId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _accessTeamId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getAccessTeamId = function () {
   ///<summary>
   /// Gets the ID of the auto created access team. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the auto created access team. 
   ///</returns>
   return _accessTeamId;
  }

  //Set property values from responseXml constructor parameter
  _setAccessTeamId(responseXml);
 }
 this.AddUserToRecordTeamResponse.__class = true;
}).call(Sdk)

Sdk.AddUserToRecordTeamRequest.prototype = new Sdk.OrganizationRequest();
Sdk.AddUserToRecordTeamResponse.prototype = new Sdk.OrganizationResponse();
