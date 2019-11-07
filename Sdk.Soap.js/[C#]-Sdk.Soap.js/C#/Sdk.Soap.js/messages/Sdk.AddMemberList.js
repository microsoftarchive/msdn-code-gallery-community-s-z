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
 this.AddMemberListRequest = function (listId, entityId) {
  ///<summary>
  /// Contains the data that is needed to add a member to a list (marketing list). 
  ///</summary>
  ///<param name="listId"  type="String">
  /// Sets the ID of the list.
  ///</param>
  ///<param name="entityId"  type="String">
  /// Sets the ID of the member you want to add to the list. 
  ///</param>
  if (!(this instanceof Sdk.AddMemberListRequest)) {
   return new Sdk.AddMemberListRequest(listId, entityId);
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
    throw new Error("Sdk.AddMemberListRequest ListId property is required and must be a String.")
   }
  }

  function _setValidEntityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _entityId = value;
   }
   else {
    throw new Error("Sdk.AddMemberListRequest EntityId property is required and must be a String.")
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
           "<a:RequestName>AddMemberList</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.AddMemberListResponse);
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
   /// Sets the ID of the member you want to add to the list. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the member you want to add to the list. 
   ///</param>
   _setValidEntityId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.AddMemberListRequest.__class = true;

 this.AddMemberListResponse = function (responseXml) {
  ///<summary>
  /// Response to AddMemberListRequest
  ///</summary>
  if (!(this instanceof Sdk.AddMemberListResponse)) {
   return new Sdk.AddMemberListResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _id = null;

  // Internal property setter functions

  function _setId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Id']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _id = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getId = function () {
   ///<summary>
   /// Gets the ID of the resulting list member. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the resulting list member. 
   ///</returns>
   return _id;
  }

  //Set property values from responseXml constructor parameter
  _setId(responseXml);
 }
 this.AddMemberListResponse.__class = true;
}).call(Sdk)

Sdk.AddMemberListRequest.prototype = new Sdk.OrganizationRequest();
Sdk.AddMemberListResponse.prototype = new Sdk.OrganizationResponse();
