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
 this.AddListMembersListRequest = function (listId, memberIds) {
  ///<summary>
  /// Contains the data that is needed to add members to the list. 
  ///</summary>
  ///<param name="listId"  type="String">
  /// Sets the ID of the list.
  ///</param>
  ///<param name="memberIds"  type="Sdk.Collection">
  /// Sets an array of IDs of the members that you want to add to the list
  ///</param>
  if (!(this instanceof Sdk.AddListMembersListRequest)) {
   return new Sdk.AddListMembersListRequest(listId, memberIds);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _listId = null;
  var _memberIds = null;

  // internal validation functions

  function _setValidListId(value) {
   if (Sdk.Util.isGuid(value)) {
    _listId = value;
   }
   else {
    throw new Error("Sdk.AddListMembersListRequest ListId property is required and must be a String.")
   }
  }

  function _setValidMemberIds(value) {
   if (Sdk.Util.isCollectionOf(value, String)) {
    _memberIds = value;
   }
   else {
    throw new Error("Sdk.AddListMembersListRequest MemberIds property is required and must be a Sdk.Collection.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof listId != "undefined") {
   _setValidListId(listId);
  }
  if (typeof memberIds != "undefined") {
   _setValidMemberIds(memberIds);
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
               "<b:key>MemberIds</b:key>",
              (_memberIds == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"f:ArrayOfguid\">", _memberIds.toArrayOfValueXml("f:guid"), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>AddListMembersList</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.AddListMembersListResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setListId = function (value) {
   ///<summary>
   /// Sets the ID of the list. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the list. 
   ///</param>
   _setValidListId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setMemberIds = function (value) {
   ///<summary>
   /// Sets a collection of IDs of the members that you want to add to the list. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// A collection of IDs of the members that you want to add to the list. 
   ///</param>
   _setValidMemberIds(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.AddListMembersListRequest.__class = true;

 this.AddListMembersListResponse = function (responseXml) {
  ///<summary>
  /// Response to AddListMembersListRequest
  ///</summary>
  if (!(this instanceof Sdk.AddListMembersListResponse)) {
   return new Sdk.AddListMembersListResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.AddListMembersListResponse.__class = true;
}).call(Sdk)

Sdk.AddListMembersListRequest.prototype = new Sdk.OrganizationRequest();
Sdk.AddListMembersListResponse.prototype = new Sdk.OrganizationResponse();
