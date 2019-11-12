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
 this.DeleteOpenInstancesRequest = function (target, seriesEndDate, stateOfPastInstances) {
  ///<summary>
  /// Contains the data that is needed to delete instances of a recurring appointment master that have an “Open” state. 
  ///</summary>
  ///<param name="target"  type="Sdk.Entity">
  /// Sets the target record for the operation. Required. 
  ///</param>
  ///<param name="seriesEndDate"  type="Date">
  /// Sets the end date for the recurring appointment series. Required. 
  ///</param>
  ///<param name="stateOfPastInstances"  type="Number">
  /// Sets the value to be used to set the status of appointment instances that have already passed. Required. 
  ///</param>
  if (!(this instanceof Sdk.DeleteOpenInstancesRequest)) {
   return new Sdk.DeleteOpenInstancesRequest(target, seriesEndDate, stateOfPastInstances);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _seriesEndDate = null;
  var _stateOfPastInstances = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.Entity) {
    _target = value;
   }
   else {
    throw new Error("Sdk.DeleteOpenInstancesRequest Target property is required and must be a Sdk.Entity.")
   }
  }

  function _setValidSeriesEndDate(value) {
   if (value instanceof Date) {
    _seriesEndDate = value;
   }
   else {
    throw new Error("Sdk.DeleteOpenInstancesRequest SeriesEndDate property is required and must be a Date.")
   }
  }

  function _setValidStateOfPastInstances(value) {
   if (typeof value == "number") {
    _stateOfPastInstances = value;
   }
   else {
    throw new Error("Sdk.DeleteOpenInstancesRequest StateOfPastInstances property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof seriesEndDate != "undefined") {
   _setValidSeriesEndDate(seriesEndDate);
  }
  if (typeof stateOfPastInstances != "undefined") {
   _setValidStateOfPastInstances(stateOfPastInstances);
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
               "<b:key>SeriesEndDate</b:key>",
              (_seriesEndDate == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:dateTime\">", _seriesEndDate.toISOString(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>StateOfPastInstances</b:key>",
              (_stateOfPastInstances == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _stateOfPastInstances, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>DeleteOpenInstances</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.DeleteOpenInstancesResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target record for the operation. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The target record for the operation.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSeriesEndDate = function (value) {
   ///<summary>
   /// Sets the end date for the recurring appointment series. Required. 
   ///</summary>
   ///<param name="value" type="Date">
   /// The end date for the recurring appointment series.
   ///</param>
   _setValidSeriesEndDate(value);
   this.setRequestXml(getRequestXml());
  }

  this.setStateOfPastInstances = function (value) {
   ///<summary>
   /// Sets the value to be used to set the status of appointment instances that have already passed. Required. 
   ///</summary>
   ///<param name="value" type="Number">
   /// The value to be used to set the status of appointment instances that have already passed.
   ///</param>
   _setValidStateOfPastInstances(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.DeleteOpenInstancesRequest.__class = true;

 this.DeleteOpenInstancesResponse = function (responseXml) {
  ///<summary>
  /// Response to DeleteOpenInstancesRequest
  ///</summary>
  if (!(this instanceof Sdk.DeleteOpenInstancesResponse)) {
   return new Sdk.DeleteOpenInstancesResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.DeleteOpenInstancesResponse.__class = true;
}).call(Sdk)

Sdk.DeleteOpenInstancesRequest.prototype = new Sdk.OrganizationRequest();
Sdk.DeleteOpenInstancesResponse.prototype = new Sdk.OrganizationResponse();
