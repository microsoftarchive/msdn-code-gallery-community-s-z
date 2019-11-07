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
 this.CopyMembersListRequest = function (sourceListId, targetListId) {
  ///<summary>
  /// Contains the data that is needed to copy the members from the source list to the target list without creating duplicates. 
  ///</summary>
  ///<param name="sourceListId"  type="String">
  /// Sets the ID of the source list. Required. 
  ///</param>
  ///<param name="targetListId"  type="String">
  /// Sets the ID of the target list. Required. 
  ///</param>
  if (!(this instanceof Sdk.CopyMembersListRequest)) {
   return new Sdk.CopyMembersListRequest(sourceListId, targetListId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _sourceListId = null;
  var _targetListId = null;

  // internal validation functions

  function _setValidSourceListId(value) {
   if (Sdk.Util.isGuid(value)) {
    _sourceListId = value;
   }
   else {
    throw new Error("Sdk.CopyMembersListRequest SourceListId property is required and must be a String.")
   }
  }

  function _setValidTargetListId(value) {
   if (Sdk.Util.isGuid(value)) {
    _targetListId = value;
   }
   else {
    throw new Error("Sdk.CopyMembersListRequest TargetListId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof sourceListId != "undefined") {
   _setValidSourceListId(sourceListId);
  }
  if (typeof targetListId != "undefined") {
   _setValidTargetListId(targetListId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SourceListId</b:key>",
              (_sourceListId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _sourceListId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>TargetListId</b:key>",
              (_targetListId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _targetListId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CopyMembersList</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CopyMembersListResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setSourceListId = function (value) {
   ///<summary>
   /// Sets the ID of the source list. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the source list.
   ///</param>
   _setValidSourceListId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTargetListId = function (value) {
   ///<summary>
   /// Sets the ID of the target list. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the target list.
   ///</param>
   _setValidTargetListId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CopyMembersListRequest.__class = true;

 this.CopyMembersListResponse = function (responseXml) {
  ///<summary>
  /// Response to CopyMembersListRequest
  ///</summary>
  if (!(this instanceof Sdk.CopyMembersListResponse)) {
   return new Sdk.CopyMembersListResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values
 }
 this.CopyMembersListResponse.__class = true;
}).call(Sdk)

Sdk.CopyMembersListRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CopyMembersListResponse.prototype = new Sdk.OrganizationResponse();
