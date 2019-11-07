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
 this.CloseIncidentRequest = function (incidentResolution, status) {
  ///<summary>
  /// Contains the data that is needed to close an incident (case). 
  ///</summary>
  ///<param name="incidentResolution"  type="Sdk.Entity">
  /// Sets the incident resolution (case resolution) that is associated with the incident (case) to be closed. Required. 
  ///</param>
  ///<param name="status"  type="Number">
  /// Sets a status of the incident. Required. 
  ///</param>
  if (!(this instanceof Sdk.CloseIncidentRequest)) {
   return new Sdk.CloseIncidentRequest(incidentResolution, status);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _incidentResolution = null;
  var _status = null;

  // internal validation functions

  function _setValidIncidentResolution(value) {
   if (value instanceof Sdk.Entity) {
    _incidentResolution = value;
   }
   else {
    throw new Error("Sdk.CloseIncidentRequest IncidentResolution property is required and must be a Sdk.Entity.")
   }
  }

  function _setValidStatus(value) {
   if (typeof value == "number") {
    _status = value;
   }
   else {
    throw new Error("Sdk.CloseIncidentRequest Status property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof incidentResolution != "undefined") {
   _setValidIncidentResolution(incidentResolution);
  }
  if (typeof status != "undefined") {
   _setValidStatus(status);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>IncidentResolution</b:key>",
              (_incidentResolution == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:Entity\">", _incidentResolution.toValueXml(), "</b:value>"].join(""),
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
           "<a:RequestName>CloseIncident</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CloseIncidentResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setIncidentResolution = function (value) {
   ///<summary>
   /// Sets the incident resolution (case resolution) that is associated with the incident (case) to be closed. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The incident resolution (case resolution) that is associated with the incident (case) to be closed.
   ///</param>
   _setValidIncidentResolution(value);
   this.setRequestXml(getRequestXml());
  }

  this.setStatus = function (value) {
   ///<summary>
   /// Sets a status of the incident. Required. 
   ///</summary>
   ///<param name="value" type="Number">
   /// A status of the incident.
   ///</param>
   _setValidStatus(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CloseIncidentRequest.__class = true;

 this.CloseIncidentResponse = function (responseXml) {
  ///<summary>
  /// Response to CloseIncidentRequest
  ///</summary>
  if (!(this instanceof Sdk.CloseIncidentResponse)) {
   return new Sdk.CloseIncidentResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.CloseIncidentResponse.__class = true;
}).call(Sdk)

Sdk.CloseIncidentRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CloseIncidentResponse.prototype = new Sdk.OrganizationResponse();
