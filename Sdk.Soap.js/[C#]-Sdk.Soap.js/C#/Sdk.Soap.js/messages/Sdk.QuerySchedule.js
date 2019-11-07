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
 this.QueryScheduleRequest = function (resourceId, start, end, timeCodes) {
  ///<summary>
  /// Contains the data that is needed to  search the specified resource for an available time block that matches the specified parameters.
  ///</summary>
  ///<param name="resourceId"  type="String">
  /// Sets the ID of the resource.
  ///</param>
  ///<param name="start"  type="Date">
  /// Sets the start of the time slot.
  ///</param>
  ///<param name="end"  type="Date">
  /// Sets the end of the time slot.
  ///</param>
  ///<param name="timeCodes"  type="Sdk.Collection">
  /// Sets the time codes to look for: Available, Busy, Unavailable, or Filter.
  ///</param>
  if (!(this instanceof Sdk.QueryScheduleRequest)) {
   return new Sdk.QueryScheduleRequest(resourceId, start, end, timeCodes);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _resourceId = null;
  var _start = null;
  var _end = null;
  var _timeCodes = null;

  // internal validation functions

  function _setValidResourceId(value) {
   if (Sdk.Util.isGuid(value)) {
    _resourceId = value;
   }
   else {
    throw new Error("Sdk.QueryScheduleRequest ResourceId property is required and must be a String.")
   }
  }

  function _setValidStart(value) {
   if (value instanceof Date) {
    _start = value;
   }
   else {
    throw new Error("Sdk.QueryScheduleRequest Start property is required and must be a Date.")
   }
  }

  function _setValidEnd(value) {
   if (value instanceof Date) {
    _end = value;
   }
   else {
    throw new Error("Sdk.QueryScheduleRequest End property is required and must be a Date.")
   }
  }

  function _setValidTimeCodes(value) {
   if (Sdk.Util.isCollectionOf(value, String)) {
    _timeCodes = value;
   }
   else {
    throw new Error("Sdk.QueryScheduleRequest TimeCodes property is required and must be a Sdk.Collection.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof resourceId != "undefined") {
   _setValidResourceId(resourceId);
  }
  if (typeof start != "undefined") {
   _setValidStart(start);
  }
  if (typeof end != "undefined") {
   _setValidEnd(end);
  }
  if (typeof timeCodes != "undefined") {
   _setValidTimeCodes(timeCodes);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ResourceId</b:key>",
              (_resourceId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _resourceId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Start</b:key>",
              (_start == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:dateTime\">", _start.toISOString(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>End</b:key>",
              (_end == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:dateTime\">", _end.toISOString(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>TimeCodes</b:key>",
              (_timeCodes == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:ArrayOfTimeCode\">", _timeCodes.toArrayOfValueXml("g:TimeCode"), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>QuerySchedule</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.QueryScheduleResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setResourceId = function (value) {
   ///<summary>
   /// Sets the ID of the resource.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the resource.
   ///</param>
   _setValidResourceId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setStart = function (value) {
   ///<summary>
   /// Sets the start of the time slot.
   ///</summary>
   ///<param name="value" type="Date">
   /// The start of the time slot.
   ///</param>
   _setValidStart(value);
   this.setRequestXml(getRequestXml());
  }

  this.setEnd = function (value) {
   ///<summary>
   /// Sets the end of the time slot.
   ///</summary>
   ///<param name="value" type="Date">
   /// The end of the time slot.
   ///</param>
   _setValidEnd(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTimeCodes = function (value) {
   ///<summary>
   /// Sets the time codes to look for: Available, Busy, Unavailable, or Filter.
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// The time codes to look for: Available, Busy, Unavailable, or Filter.
   ///</param>
   _setValidTimeCodes(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.QueryScheduleRequest.__class = true;

 this.QueryScheduleResponse = function (responseXml) {
  ///<summary>
  /// Response to QueryScheduleRequest
  ///</summary>
  if (!(this instanceof Sdk.QueryScheduleResponse)) {
   return new Sdk.QueryScheduleResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _timeInfos = null;

  // Internal property setter functions

  function _setTimeInfos(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='TimeInfos']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _timeInfos = Sdk.Util.createTimeInfoCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getTimeInfos = function () {
   ///<summary>
   /// Gets the results of the search, a set of possible time slots for the resource.
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// The results of the search, a set of possible time slots for the resource.
   ///</returns>
   return _timeInfos;
  }

  //Set property values from responseXml constructor parameter
  _setTimeInfos(responseXml);
 }
 this.QueryScheduleResponse.__class = true;
}).call(Sdk)

Sdk.QueryScheduleRequest.prototype = new Sdk.OrganizationRequest();
Sdk.QueryScheduleResponse.prototype = new Sdk.OrganizationResponse();
