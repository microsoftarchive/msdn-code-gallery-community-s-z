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
 this.CalculateTotalTimeIncidentRequest = function (incidentId) {
  ///<summary>
  /// Contains the data that is needed to calculate the total time, in minutes, that you used while you worked on an incident (case). 
  ///</summary>
  ///<param name="incidentId"  type="String">
  /// Sets the ID of the incident (case). Required. 
  ///</param>
  if (!(this instanceof Sdk.CalculateTotalTimeIncidentRequest)) {
   return new Sdk.CalculateTotalTimeIncidentRequest(incidentId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _incidentId = null;

  // internal validation functions

  function _setValidIncidentId(value) {
   if (Sdk.Util.isGuid(value)) {
    _incidentId = value;
   }
   else {
    throw new Error("Sdk.CalculateTotalTimeIncidentRequest IncidentId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof incidentId != "undefined") {
   _setValidIncidentId(incidentId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>IncidentId</b:key>",
              (_incidentId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _incidentId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CalculateTotalTimeIncident</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CalculateTotalTimeIncidentResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setIncidentId = function (value) {
   ///<summary>
   /// Sets the ID of the incident (case). Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the incident (case).
   ///</param>
   _setValidIncidentId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CalculateTotalTimeIncidentRequest.__class = true;

 this.CalculateTotalTimeIncidentResponse = function (responseXml) {
  ///<summary>
  /// Response to CalculateTotalTimeIncidentRequest
  ///</summary>
  if (!(this instanceof Sdk.CalculateTotalTimeIncidentResponse)) {
   return new Sdk.CalculateTotalTimeIncidentResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _totalTime = null;

  // Internal property setter functions

  function _setTotalTime(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='TotalTime']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _totalTime = parseInt(Sdk.Xml.getNodeText(valueNode), 10);
   }
  }
  //Public Methods to retrieve properties
  this.getTotalTime = function () {
   ///<summary>
   /// Gets the total time, in minutes that you use when you work on an incident (case). 
   ///</summary>
   ///<returns type="Number">
   /// The total time, in minutes that you use when you work on an incident (case). 
   ///</returns>
   return _totalTime;
  }

  //Set property values from responseXml constructor parameter
  _setTotalTime(responseXml);
 }
 this.CalculateTotalTimeIncidentResponse.__class = true;
}).call(Sdk)

Sdk.CalculateTotalTimeIncidentRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CalculateTotalTimeIncidentResponse.prototype = new Sdk.OrganizationResponse();
