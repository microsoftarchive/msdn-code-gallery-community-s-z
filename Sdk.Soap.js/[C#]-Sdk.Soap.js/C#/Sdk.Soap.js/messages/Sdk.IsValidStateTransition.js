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
 this.IsValidStateTransitionRequest = function (entity, newState, newStatus) {
  ///<summary>
  /// Contains the data that is needed to validate the state transition.
  ///</summary>
  ///<param name="entity"  type="Sdk.EntityReference">
  /// Sets the entity reference for the record whose transition state is validated.
  ///</param>
  ///<param name="newState"  type="String">
  /// Sets the proposed new state for the record.
  ///</param>
  ///<param name="newStatus"  type="Number">
  /// Sets the proposed new status for the record.
  ///</param>
  if (!(this instanceof Sdk.IsValidStateTransitionRequest)) {
   return new Sdk.IsValidStateTransitionRequest(entity, newState, newStatus);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _entity = null;
  var _newState = null;
  var _newStatus = null;

  // internal validation functions

  function _setValidEntity(value) {
   if (value instanceof Sdk.EntityReference) {
    _entity = value;
   }
   else {
    throw new Error("Sdk.IsValidStateTransitionRequest Entity property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidNewState(value) {
   if (typeof value == "string") {
    _newState = value;
   }
   else {
    throw new Error("Sdk.IsValidStateTransitionRequest NewState property is required and must be a String.")
   }
  }

  function _setValidNewStatus(value) {
   if (typeof value == "number") {
    _newStatus = value;
   }
   else {
    throw new Error("Sdk.IsValidStateTransitionRequest NewStatus property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof entity != "undefined") {
   _setValidEntity(entity);
  }
  if (typeof newState != "undefined") {
   _setValidNewState(newState);
  }
  if (typeof newStatus != "undefined") {
   _setValidNewStatus(newStatus);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Entity</b:key>",
              (_entity == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _entity.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>NewState</b:key>",
              (_newState == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _newState, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>NewStatus</b:key>",
              (_newStatus == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _newStatus, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>IsValidStateTransition</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.IsValidStateTransitionResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntity = function (value) {
   ///<summary>
   /// Sets the entity reference for the record whose transition state is validated.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The entity reference for the record whose transition state is validated.
   ///</param>
   _setValidEntity(value);
   this.setRequestXml(getRequestXml());
  }

  this.setNewState = function (value) {
   ///<summary>
   /// Sets the proposed new state for the record.
   ///</summary>
   ///<param name="value" type="String">
   /// The proposed new state for the record.
   ///</param>
   _setValidNewState(value);
   this.setRequestXml(getRequestXml());
  }

  this.setNewStatus = function (value) {
   ///<summary>
   /// Sets the proposed new status for the record.
   ///</summary>
   ///<param name="value" type="Number">
   /// The proposed new status for the record.
   ///</param>
   _setValidNewStatus(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.IsValidStateTransitionRequest.__class = true;

 this.IsValidStateTransitionResponse = function (responseXml) {
  ///<summary>
  /// Response to IsValidStateTransitionRequest
  ///</summary>
  if (!(this instanceof Sdk.IsValidStateTransitionResponse)) {
   return new Sdk.IsValidStateTransitionResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _isValid = null;

  // Internal property setter functions

  function _setIsValid(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='IsValid']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _isValid = (Sdk.Xml.getNodeText(valueNode) == "true") ? true : false;
   }
  }
  //Public Methods to retrieve properties
  this.getIsValid = function () {
   ///<summary>
   /// Gets the value that indicates whether the state transition is valid.
   ///</summary>
   ///<returns type="Boolean">
   /// The value that indicates whether the state transition is valid.
   ///</returns>
   return _isValid;
  }

  //Set property values from responseXml constructor parameter
  _setIsValid(responseXml);
 }
 this.IsValidStateTransitionResponse.__class = true;
}).call(Sdk)

Sdk.IsValidStateTransitionRequest.prototype = new Sdk.OrganizationRequest();
Sdk.IsValidStateTransitionResponse.prototype = new Sdk.OrganizationResponse();
