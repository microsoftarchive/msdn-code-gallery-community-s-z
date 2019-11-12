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
 this.LocalTimeFromUtcTimeRequest = function (timeZoneCode, utcTime) {
  ///<summary>
  /// Contains the data that is needed to  retrieve the local time for the specified Coordinated Universal Time (UTC).
  ///</summary>
  ///<param name="timeZoneCode"  type="Number">
  /// Sets the time zone code.
  ///</param>
  ///<param name="utcTime"  type="Date">
  /// Sets the Coordinated Universal Time (UTC).
  ///</param>
  if (!(this instanceof Sdk.LocalTimeFromUtcTimeRequest)) {
   return new Sdk.LocalTimeFromUtcTimeRequest(timeZoneCode, utcTime);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _timeZoneCode = null;
  var _utcTime = null;

  // internal validation functions

  function _setValidTimeZoneCode(value) {
   if (typeof value == "number") {
    _timeZoneCode = value;
   }
   else {
    throw new Error("Sdk.LocalTimeFromUtcTimeRequest TimeZoneCode property is required and must be a Number.")
   }
  }

  function _setValidUtcTime(value) {
   if (value instanceof Date) {
    _utcTime = value;
   }
   else {
    throw new Error("Sdk.LocalTimeFromUtcTimeRequest UtcTime property is required and must be a Date.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof timeZoneCode != "undefined") {
   _setValidTimeZoneCode(timeZoneCode);
  }
  if (typeof utcTime != "undefined") {
   _setValidUtcTime(utcTime);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>TimeZoneCode</b:key>",
              (_timeZoneCode == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _timeZoneCode, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>UtcTime</b:key>",
              (_utcTime == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:dateTime\">", _utcTime.toISOString(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>LocalTimeFromUtcTime</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.LocalTimeFromUtcTimeResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTimeZoneCode = function (value) {
   ///<summary>
   /// Sets the time zone code.
   ///</summary>
   ///<param name="value" type="Number">
   /// The time zone code.
   ///</param>
   _setValidTimeZoneCode(value);
   this.setRequestXml(getRequestXml());
  }

  this.setUtcTime = function (value) {
   ///<summary>
   /// Sets the Coordinated Universal Time (UTC).
   ///</summary>
   ///<param name="value" type="Date">
   /// The Coordinated Universal Time (UTC).
   ///</param>
   _setValidUtcTime(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.LocalTimeFromUtcTimeRequest.__class = true;

 this.LocalTimeFromUtcTimeResponse = function (responseXml) {
  ///<summary>
  /// Response to LocalTimeFromUtcTimeRequest
  ///</summary>
  if (!(this instanceof Sdk.LocalTimeFromUtcTimeResponse)) {
   return new Sdk.LocalTimeFromUtcTimeResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _localTime = null;

  // Internal property setter functions

  function _setLocalTime(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='LocalTime']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _localTime = new Date(Sdk.Xml.getNodeText(valueNode));
   }
  }
  //Public Methods to retrieve properties
  this.getLocalTime = function () {
   ///<summary>
   /// Gets the time that is represented as local time.
   ///</summary>
   ///<returns type="Date">
   /// The time that is represented as local time.
   ///</returns>
   return _localTime;
  }

  //Set property values from responseXml constructor parameter
  _setLocalTime(responseXml);
 }
 this.LocalTimeFromUtcTimeResponse.__class = true;
}).call(Sdk)

Sdk.LocalTimeFromUtcTimeRequest.prototype = new Sdk.OrganizationRequest();
Sdk.LocalTimeFromUtcTimeResponse.prototype = new Sdk.OrganizationResponse();
