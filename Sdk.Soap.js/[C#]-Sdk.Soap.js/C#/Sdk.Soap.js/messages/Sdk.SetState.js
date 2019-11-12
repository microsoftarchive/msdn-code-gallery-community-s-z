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
 this.SetStateRequest = function (entityMoniker, state, status) {
  ///<summary>
  /// Contains the data that is needed to set the state of an entity record.
  ///</summary>
  ///<param name="entityMoniker"  type="Sdk.EntityReference">
  /// Sets the entity. Required.
  ///</param>
  ///<param name="state"  type="Number">
  /// Sets the state of the entity record. Required.
  ///</param>
  ///<param name="status"  type="Number">
  /// Sets the status that corresponds to the State property. Required.
  ///</param>
  if (!(this instanceof Sdk.SetStateRequest)) {
   return new Sdk.SetStateRequest(entityMoniker, state, status);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _entityMoniker = null;
  var _state = null;
  var _status = null;

  // internal validation functions

  function _setValidEntityMoniker(value) {
   if (value instanceof Sdk.EntityReference) {
    _entityMoniker = value;
   }
   else {
    throw new Error("Sdk.SetStateRequest EntityMoniker property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidState(value) {
   if (typeof value == "number") {
    _state = value;
   }
   else {
    throw new Error("Sdk.SetStateRequest State property is required and must be a Number.")
   }
  }

  function _setValidStatus(value) {
   if (typeof value == "number") {
    _status = value;
   }
   else {
    throw new Error("Sdk.SetStateRequest Status property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof entityMoniker != "undefined") {
   _setValidEntityMoniker(entityMoniker);
  }
  if (typeof state != "undefined") {
   _setValidState(state);
  }
  if (typeof status != "undefined") {
   _setValidStatus(status);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EntityMoniker</b:key>",
              (_entityMoniker == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _entityMoniker.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>State</b:key>",
              (_state == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:OptionSetValue\">",
               "<a:Value>", _state, "</a:Value>",
              "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Status</b:key>",
              (_status == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:OptionSetValue\">",
               "<a:Value>", _status, "</a:Value>",
              "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>SetState</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SetStateResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntityMoniker = function (value) {
   ///<summary>
   /// Sets the entity. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The entity.
   ///</param>
   _setValidEntityMoniker(value);
   this.setRequestXml(getRequestXml());
  }

  this.setState = function (value) {
   ///<summary>
   /// Sets the state of the entity record. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The state of the entity record.
   ///</param>
   _setValidState(value);
   this.setRequestXml(getRequestXml());
  }

  this.setStatus = function (value) {
   ///<summary>
   /// Sets the status that corresponds to the State property. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The status that corresponds to the State property.
   ///</param>
   _setValidStatus(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SetStateRequest.__class = true;

 this.SetStateResponse = function (responseXml) {
  ///<summary>
  /// Response to SetStateRequest
  ///</summary>
  if (!(this instanceof Sdk.SetStateResponse)) {
   return new Sdk.SetStateResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.SetStateResponse.__class = true;
}).call(Sdk)

Sdk.SetStateRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SetStateResponse.prototype = new Sdk.OrganizationResponse();
