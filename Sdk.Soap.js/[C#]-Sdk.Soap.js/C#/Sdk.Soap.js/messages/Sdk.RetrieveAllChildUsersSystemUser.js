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
 this.RetrieveAllChildUsersSystemUserRequest = function (entityId, columnSet) {
  ///<summary>
  /// Contains the data that is needed to retrieve the collection of users that report to the specified system user (user).
  ///</summary>
  ///<param name="entityId"  type="String">
  /// Sets the ID of the system user (user).
  ///</param>
  ///<param name="columnSet"  type="Sdk.ColumnSet">
  /// Sets the set of attributes to retrieve. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveAllChildUsersSystemUserRequest)) {
   return new Sdk.RetrieveAllChildUsersSystemUserRequest(entityId, columnSet);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _entityId = null;
  var _columnSet = null;

  // internal validation functions

  function _setValidEntityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _entityId = value;
   }
   else {
    throw new Error("Sdk.RetrieveAllChildUsersSystemUserRequest EntityId property is required and must be a String.")
   }
  }

  function _setValidColumnSet(value) {
   if (value instanceof Sdk.ColumnSet) {
    _columnSet = value;
   }
   else {
    throw new Error("Sdk.RetrieveAllChildUsersSystemUserRequest ColumnSet property is required and must be a Sdk.ColumnSet.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof entityId != "undefined") {
   _setValidEntityId(entityId);
  }
  if (typeof columnSet != "undefined") {
   _setValidColumnSet(columnSet);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EntityId</b:key>",
              (_entityId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _entityId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ColumnSet</b:key>",
              (_columnSet == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:ColumnSet\">", _columnSet.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveAllChildUsersSystemUser</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveAllChildUsersSystemUserResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntityId = function (value) {
   ///<summary>
   /// Sets the ID of the system user (user).
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the system user (user).
   ///</param>
   _setValidEntityId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setColumnSet = function (value) {
   ///<summary>
   /// Sets the set of attributes to retrieve. Required.
   ///</summary>
   ///<param name="value" type="Sdk.ColumnSet">
   /// The set of attributes to retrieve.
   ///</param>
   _setValidColumnSet(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveAllChildUsersSystemUserRequest.__class = true;

 this.RetrieveAllChildUsersSystemUserResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveAllChildUsersSystemUserRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveAllChildUsersSystemUserResponse)) {
   return new Sdk.RetrieveAllChildUsersSystemUserResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _entityCollection = null;

  // Internal property setter functions

  function _setEntityCollection(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='EntityCollection']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _entityCollection = Sdk.Util.createEntityCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEntityCollection = function () {
   ///<summary>
   /// Gets the resulting collection of all users that report to the specified system user.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The resulting collection of all users that report to the specified system user.
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.RetrieveAllChildUsersSystemUserResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveAllChildUsersSystemUserRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveAllChildUsersSystemUserResponse.prototype = new Sdk.OrganizationResponse();
