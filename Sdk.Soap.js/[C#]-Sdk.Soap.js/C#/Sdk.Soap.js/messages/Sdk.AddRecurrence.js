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
 this.AddRecurrenceRequest = function (target, appointmentId) {
  ///<summary>
  /// Contains the data that is needed to add recurrence information to an existing appointment. 
  ///</summary>
  ///<param name="target"  type="Sdk.Entity">
  /// Sets the target, which is a recurring appointment master record to which the appointment is converted.
  ///</param>
  ///<param name="appointmentId"  type="String">
  /// Sets the ID of the appointment that needs to be converted into a recurring appointment.
  ///</param>
  if (!(this instanceof Sdk.AddRecurrenceRequest)) {
   return new Sdk.AddRecurrenceRequest(target, appointmentId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _appointmentId = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.Entity) {
    _target = value;
   }
   else {
    throw new Error("Sdk.AddRecurrenceRequest Target property is required and must be a Sdk.Entity.")
   }
  }

  function _setValidAppointmentId(value) {
   if (Sdk.Util.isGuid(value)) {
    _appointmentId = value;
   }
   else {
    throw new Error("Sdk.AddRecurrenceRequest AppointmentId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof appointmentId != "undefined") {
   _setValidAppointmentId(appointmentId);
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
               "<b:key>AppointmentId</b:key>",
              (_appointmentId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _appointmentId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>AddRecurrence</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.AddRecurrenceResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target, which is a recurring appointment master record to which the appointment is converted. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The target, which is a recurring appointment master record to which the appointment is converted. 
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setAppointmentId = function (value) {
   ///<summary>
   /// Sets the ID of the appointment that needs to be converted into a recurring appointment. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the appointment that needs to be converted into a recurring appointment. 
   ///</param>
   _setValidAppointmentId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.AddRecurrenceRequest.__class = true;

 this.AddRecurrenceResponse = function (responseXml) {
  ///<summary>
  /// Response to AddRecurrenceRequest
  ///</summary>
  if (!(this instanceof Sdk.AddRecurrenceResponse)) {
   return new Sdk.AddRecurrenceResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _id = null;

  // Internal property setter functions

  function _setId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='id']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _id = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getId = function () {
   ///<summary>
   /// Gets the ID of the newly created recurring appointment. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the newly created recurring appointment. 
   ///</returns>
   return _id;
  }

  //Set property values from responseXml constructor parameter
  _setId(responseXml);
 }
 this.AddRecurrenceResponse.__class = true;
}).call(Sdk)

Sdk.AddRecurrenceRequest.prototype = new Sdk.OrganizationRequest();
Sdk.AddRecurrenceResponse.prototype = new Sdk.OrganizationResponse();
