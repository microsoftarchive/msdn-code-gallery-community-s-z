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
 this.QualifyMemberListRequest = function (listId, membersId, overrideorRemove) {
  ///<summary>
  /// Contains the data that is needed to  qualify the specified list and either override the list members or remove them according to the specified option.
  ///</summary>
  ///<param name="listId"  type="String">
  /// Sets the ID of the list to qualify. Required.
  ///</param>
  ///<param name="membersId"  type="Sdk.Collection">
  /// Sets an array of IDs of the members to qualify. Required.
  ///</param>
  ///<param name="overrideorRemove"  type="Boolean">
  /// Sets a value that indicates whether to override or remove the members from the list. Required.
  ///</param>
  if (!(this instanceof Sdk.QualifyMemberListRequest)) {
   return new Sdk.QualifyMemberListRequest(listId, membersId, overrideorRemove);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _listId = null;
  var _membersId = null;
  var _overrideorRemove = null;

  // internal validation functions

  function _setValidListId(value) {
   if (Sdk.Util.isGuid(value)) {
    _listId = value;
   }
   else {
    throw new Error("Sdk.QualifyMemberListRequest ListId property is required and must be a String.")
   }
  }

  function _setValidMembersId(value) {
   if (Sdk.Util.isCollectionOf(value, String)) {
    _membersId = value;
   }
   else {
    throw new Error("Sdk.QualifyMemberListRequest MembersId property is required and must be a Sdk.Collection.")
   }
  }

  function _setValidOverrideorRemove(value) {
   if (typeof value == "boolean") {
    _overrideorRemove = value;
   }
   else {
    throw new Error("Sdk.QualifyMemberListRequest OverrideorRemove property is required and must be a Boolean.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof listId != "undefined") {
   _setValidListId(listId);
  }
  if (typeof membersId != "undefined") {
   _setValidMembersId(membersId);
  }
  if (typeof overrideorRemove != "undefined") {
   _setValidOverrideorRemove(overrideorRemove);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ListId</b:key>",
              (_listId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _listId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>MembersId</b:key>",
              (_membersId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"f:ArrayOfguid\">", _membersId.toArrayOfValueXml("f:guid"), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>OverrideorRemove</b:key>",
              (_overrideorRemove == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _overrideorRemove, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>QualifyMemberList</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.QualifyMemberListResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setListId = function (value) {
   ///<summary>
   /// Sets the ID of the list to qualify. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the list to qualify.
   ///</param>
   _setValidListId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setMembersId = function (value) {
   ///<summary>
   /// Sets an array of IDs of the members to qualify. Required.
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// An array of IDs of the members to qualify.
   ///</param>
   _setValidMembersId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setOverrideorRemove = function (value) {
   ///<summary>
   /// Sets a value that indicates whether to override or remove the members from the list. Required.
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether to override or remove the members from the list.
   ///</param>
   _setValidOverrideorRemove(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.QualifyMemberListRequest.__class = true;

 this.QualifyMemberListResponse = function (responseXml) {
  ///<summary>
  /// Response to QualifyMemberListRequest
  ///</summary>
  if (!(this instanceof Sdk.QualifyMemberListResponse)) {
   return new Sdk.QualifyMemberListResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.QualifyMemberListResponse.__class = true;
}).call(Sdk)

Sdk.QualifyMemberListRequest.prototype = new Sdk.OrganizationRequest();
Sdk.QualifyMemberListResponse.prototype = new Sdk.OrganizationResponse();
