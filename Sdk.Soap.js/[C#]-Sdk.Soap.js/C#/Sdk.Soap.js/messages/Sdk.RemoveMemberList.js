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
 this.RemoveMemberListRequest = function (listId, entityId) {
  ///<summary>
  /// Contains the data that is needed to  remove a member from a list (marketing list).
  ///</summary>
  ///<param name="listId"  type="String">
  /// Sets the ID of the list. Required.
  ///</param>
  ///<param name="entityId"  type="String">
  /// Sets the ID of the member to be removed from the list. Required.
  ///</param>
  if (!(this instanceof Sdk.RemoveMemberListRequest)) {
   return new Sdk.RemoveMemberListRequest(listId, entityId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _listId = null;
  var _entityId = null;

  // internal validation functions

  function _setValidListId(value) {
   if (Sdk.Util.isGuid(value)) {
    _listId = value;
   }
   else {
    throw new Error("Sdk.RemoveMemberListRequest ListId property is required and must be a String.")
   }
  }

  function _setValidEntityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _entityId = value;
   }
   else {
    throw new Error("Sdk.RemoveMemberListRequest EntityId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof listId != "undefined") {
   _setValidListId(listId);
  }
  if (typeof entityId != "undefined") {
   _setValidEntityId(entityId);
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
               "<b:key>EntityId</b:key>",
              (_entityId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _entityId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RemoveMemberList</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RemoveMemberListResponse);
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

  this.setEntityId = function (value) {
   ///<summary>
   /// Sets the ID of the member to be removed from the list. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the member to be removed from the list.
   ///</param>
   _setValidEntityId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RemoveMemberListRequest.__class = true;

 this.RemoveMemberListResponse = function (responseXml) {
  ///<summary>
  /// Response to RemoveMemberListRequest
  ///</summary>
  if (!(this instanceof Sdk.RemoveMemberListResponse)) {
   return new Sdk.RemoveMemberListResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.RemoveMemberListResponse.__class = true;
}).call(Sdk)

Sdk.RemoveMemberListRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RemoveMemberListResponse.prototype = new Sdk.OrganizationResponse();
