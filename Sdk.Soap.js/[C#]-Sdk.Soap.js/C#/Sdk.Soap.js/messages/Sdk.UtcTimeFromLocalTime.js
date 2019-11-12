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
 this.UtcTimeFromLocalTimeRequest = function (timeZoneCode, localTime) {
  ///<summary>
  /// Contains the data that is needed to  retrieve the Coordinated Universal Time (UTC) for the specified local time.
  ///</summary>
  ///<param name="timeZoneCode"  type="Number">
  /// Sets the time zone code. Required.
  ///</param>
  ///<param name="localTime"  type="Date">
  /// Sets the local time. Required.
  ///</param>
  if (!(this instanceof Sdk.UtcTimeFromLocalTimeRequest)) {
   return new Sdk.UtcTimeFromLocalTimeRequest(timeZoneCode, localTime);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _timeZoneCode = null;
  var _localTime = null;

  // internal validation functions

  function _setValidTimeZoneCode(value) {
   if (typeof value == "number") {
    _timeZoneCode = value;
   }
   else {
    throw new Error("Sdk.UtcTimeFromLocalTimeRequest TimeZoneCode property is required and must be a Number.")
   }
  }

  function _setValidLocalTime(value) {
   if (value instanceof Date) {
    _localTime = value;
   }
   else {
    throw new Error("Sdk.UtcTimeFromLocalTimeRequest LocalTime property is required and must be a Date.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof timeZoneCode != "undefined") {
   _setValidTimeZoneCode(timeZoneCode);
  }
  if (typeof localTime != "undefined") {
   _setValidLocalTime(localTime);
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
               "<b:key>LocalTime</b:key>",
              (_localTime == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:dateTime\">", _localTime.toISOString(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>UtcTimeFromLocalTime</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.UtcTimeFromLocalTimeResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTimeZoneCode = function (value) {
   ///<summary>
   /// Sets the time zone code. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The time zone code.
   ///</param>
   _setValidTimeZoneCode(value);
   this.setRequestXml(getRequestXml());
  }

  this.setLocalTime = function (value) {
   ///<summary>
   /// Sets the local time. Required.
   ///</summary>
   ///<param name="value" type="Date">
   /// The local time.
   ///</param>
   _setValidLocalTime(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.UtcTimeFromLocalTimeRequest.__class = true;

 this.UtcTimeFromLocalTimeResponse = function (responseXml) {
  ///<summary>
  /// Response to UtcTimeFromLocalTimeRequest
  ///</summary>
  if (!(this instanceof Sdk.UtcTimeFromLocalTimeResponse)) {
   return new Sdk.UtcTimeFromLocalTimeResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _utcTime = null;

  // Internal property setter functions

  function _setUtcTime(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='UtcTime']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _utcTime = new Date(Sdk.Xml.getNodeText(valueNode));
   }
  }
  //Public Methods to retrieve properties
  this.getUtcTime = function () {
   ///<summary>
   /// Gets the local time and expresses it in Coordinated Universal Time (UTC) time.
   ///</summary>
   ///<returns type="Date">
   /// The local time and expresses it in Coordinated Universal Time (UTC) time.
   ///</returns>
   return _utcTime;
  }

  //Set property values from responseXml constructor parameter
  _setUtcTime(responseXml);
 }
 this.UtcTimeFromLocalTimeResponse.__class = true;
}).call(Sdk)

Sdk.UtcTimeFromLocalTimeRequest.prototype = new Sdk.OrganizationRequest();
Sdk.UtcTimeFromLocalTimeResponse.prototype = new Sdk.OrganizationResponse();
