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
this.RescheduleRequest = function (target,returnNotifications){
///<summary>
/// Contains the data that is needed to reschedule an appointment, recurring appointment, or service appointment (service activity).
///</summary>
///<param name="target"  type="Sdk.Entity">
/// Sets the target of the reschedule operation.
///</param>
///<param name="returnNotifications" optional="true" type="Boolean">
/// [Add Description]
///</param>
if (!(this instanceof Sdk.RescheduleRequest)) {
return new Sdk.RescheduleRequest(target, returnNotifications);
}
Sdk.OrganizationRequest.call(this);

  // Internal properties
var _target = null;
var _returnNotifications = null;

// internal validation functions

function _setValidTarget(value) {
 if (value instanceof Sdk.Entity) {
  _target = value;
 }
 else {
  throw new Error("Sdk.RescheduleRequest Target property is required and must be a Sdk.Entity.")
 }
}

function _setValidReturnNotifications(value) {
 if (value == null || typeof value == "boolean") {
  _returnNotifications = value;
 }
 else {
  throw new Error("Sdk.RescheduleRequest ReturnNotifications property must be a Boolean or null.")
 }
}

//Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof returnNotifications != "undefined") {
   _setValidReturnNotifications(returnNotifications);
  }

  function getRequestXml() {
return ["<d:request>",
        "<a:Parameters>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>Target</b:key>",
           (_target == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"a:Entity\">", _target.toValueXml(), "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>ReturnNotifications</b:key>",
           (_returnNotifications == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"c:boolean\">", _returnNotifications, "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

        "</a:Parameters>",
        "<a:RequestId i:nil=\"true\" />",
        "<a:RequestName>Reschedule</a:RequestName>",
      "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RescheduleResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
  ///<summary>
  /// Sets the target of the reschedule operation.
  ///</summary>
  ///<param name="value" type="Sdk.Entity">
  /// The target of the reschedule operation.
  ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setReturnNotifications = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="Boolean">
  /// [Add Description]
  ///</param>
   _setValidReturnNotifications(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RescheduleRequest.__class = true;

this.RescheduleResponse = function (responseXml) {
  ///<summary>
  /// Response to RescheduleRequest
  ///</summary>
  if (!(this instanceof Sdk.RescheduleResponse)) {
   return new Sdk.RescheduleResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _validationResult = null;
  var _notifications = null;

  // Internal property setter functions

  function _setValidationResult(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='ValidationResult']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _validationResult = Sdk.Util.createValidationResultFromNode(valueNode);
   }
  }
  function _setNotifications(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Notifications']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _notifications = valueNode;
   }
  }
  //Public Methods to retrieve properties
  this.getValidationResult = function () {
  ///<summary>
  /// Gets the validation results for the appointment, recurring appointment master, or service appointment (service activity).
  ///</summary>
  ///<returns type="Sdk.ValidationResult">
  /// The validation results for the appointment, recurring appointment master, or service appointment (service activity).
  ///</returns>
   return _validationResult;
  }
  this.getNotifications = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="XML">
  /// [Add Description]
  ///</returns>
   return _notifications;
  }

  //Set property values from responseXml constructor parameter
  _setValidationResult(responseXml);
  _setNotifications(responseXml);
 }
 this.RescheduleResponse.__class = true;
}).call(Sdk)

Sdk.RescheduleRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RescheduleResponse.prototype = new Sdk.OrganizationResponse();
