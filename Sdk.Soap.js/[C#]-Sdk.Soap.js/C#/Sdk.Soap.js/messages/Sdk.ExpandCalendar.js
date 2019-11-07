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
 this.ExpandCalendarRequest = function (calendarId, start, end) {
  ///<summary>
  /// Contains the data that is needed to convert the calendar rules to an array of available time blocks for the specified period. 
  ///</summary>
  ///<param name="calendarId"  type="String">
  /// Sets the ID of the calendar. 
  ///</param>
  ///<param name="start"  type="Date">
  /// Sets the start of the period to expand. 
  ///</param>
  ///<param name="end"  type="Date">
  /// Sets the end of the time period to expand. 
  ///</param>
  if (!(this instanceof Sdk.ExpandCalendarRequest)) {
   return new Sdk.ExpandCalendarRequest(calendarId, start, end);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _calendarId = null;
  var _start = null;
  var _end = null;

  // internal validation functions

  function _setValidCalendarId(value) {
   if (Sdk.Util.isGuid(value)) {
    _calendarId = value;
   }
   else {
    throw new Error("Sdk.ExpandCalendarRequest CalendarId property is required and must be a String.")
   }
  }

  function _setValidStart(value) {
   if (value instanceof Date) {
    _start = value;
   }
   else {
    throw new Error("Sdk.ExpandCalendarRequest Start property is required and must be a Date.")
   }
  }

  function _setValidEnd(value) {
   if (value instanceof Date) {
    _end = value;
   }
   else {
    throw new Error("Sdk.ExpandCalendarRequest End property is required and must be a Date.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof calendarId != "undefined") {
   _setValidCalendarId(calendarId);
  }
  if (typeof start != "undefined") {
   _setValidStart(start);
  }
  if (typeof end != "undefined") {
   _setValidEnd(end);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>CalendarId</b:key>",
              (_calendarId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _calendarId, "</b:value>"].join(""),
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

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ExpandCalendar</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ExpandCalendarResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setCalendarId = function (value) {
   ///<summary>
   /// Sets the ID of the calendar. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the calendar. 
   ///</param>
   _setValidCalendarId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setStart = function (value) {
   ///<summary>
   /// Sets the start of the period to expand. 
   ///</summary>
   ///<param name="value" type="Date">
   /// The start of the period to expand. 
   ///</param>
   _setValidStart(value);
   this.setRequestXml(getRequestXml());
  }

  this.setEnd = function (value) {
   ///<summary>
   /// Sets the end of the time period to expand. 
   ///</summary>
   ///<param name="value" type="Date">
   /// The end of the time period to expand. 
   ///</param>
   _setValidEnd(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ExpandCalendarRequest.__class = true;

 this.ExpandCalendarResponse = function (responseXml) {
  ///<summary>
  /// Response to ExpandCalendarRequest
  ///</summary>
  if (!(this instanceof Sdk.ExpandCalendarResponse)) {
   return new Sdk.ExpandCalendarResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _result = null;

  // Internal property setter functions

  function _setResult(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='result']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _result = Sdk.Util.createTimeInfoCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getResult = function () {
   ///<summary>
   /// Gets a set of time blocks with appointment information. 
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// A collection of time blocks with appointment information. 
   ///</returns>
   return _result;
  }

  //Set property values from responseXml constructor parameter
  _setResult(responseXml);
 }
 this.ExpandCalendarResponse.__class = true;
}).call(Sdk)

Sdk.ExpandCalendarRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ExpandCalendarResponse.prototype = new Sdk.OrganizationResponse();
