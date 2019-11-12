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
 this.ValidateRequest = function (activities) {
  ///<summary>
  /// Contains the data that is needed to verify that an appointment or service appointment (service activity) has valid available resources for the activity, duration, and site, as appropriate.
  ///</summary>
  ///<param name="activities"  type="Sdk.EntityCollection">
  /// Sets the activities to validate.
  ///</param>
  if (!(this instanceof Sdk.ValidateRequest)) {
   return new Sdk.ValidateRequest(activities);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _activities = null;

  // internal validation functions

  function _setValidActivities(value) {
   if (value instanceof Sdk.EntityCollection) {
    _activities = value;
   }
   else {
    throw new Error("Sdk.ValidateRequest Activities property is required and must be a Sdk.EntityCollection.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof activities != "undefined") {
   _setValidActivities(activities);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Activities</b:key>",
              (_activities == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityCollection\">", _activities.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>Validate</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ValidateResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setActivities = function (value) {
   ///<summary>
   /// Sets the activities to validate.
   ///</summary>
   ///<param name="value" type="Sdk.EntityCollection">
   /// The activities to validate.
   ///</param>
   _setValidActivities(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ValidateRequest.__class = true;

 this.ValidateResponse = function (responseXml) {
  ///<summary>
  /// Response to ValidateRequest
  ///</summary>
  if (!(this instanceof Sdk.ValidateResponse)) {
   return new Sdk.ValidateResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _result = null;

  // Internal property setter functions

  function _setResult(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Result']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _result = Sdk.Util.createValidationResultCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getResult = function () {
   ///<summary>
   /// Gets the results of the validate operation.
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// The results of the validate operation.
   ///</returns>
   return _result;
  }

  //Set property values from responseXml constructor parameter
  _setResult(responseXml);
 }
 this.ValidateResponse.__class = true;
}).call(Sdk)

Sdk.ValidateRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ValidateResponse.prototype = new Sdk.OrganizationResponse();
