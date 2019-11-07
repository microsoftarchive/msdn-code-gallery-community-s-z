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
 this.GetTimeZoneCodeByLocalizedNameRequest = function (localizedStandardName, localeId) {
  ///<summary>
  /// Contains the data that is needed to  retrieve the time zone code for the specified localized time zone name.
  ///</summary>
  ///<param name="localizedStandardName"  type="String">
  /// Sets the localized name to search for.
  ///</param>
  ///<param name="localeId"  type="Number">
  /// Sets the locale ID.
  ///</param>
  if (!(this instanceof Sdk.GetTimeZoneCodeByLocalizedNameRequest)) {
   return new Sdk.GetTimeZoneCodeByLocalizedNameRequest(localizedStandardName, localeId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _localizedStandardName = null;
  var _localeId = null;

  // internal validation functions

  function _setValidLocalizedStandardName(value) {
   if (typeof value == "string") {
    _localizedStandardName = value;
   }
   else {
    throw new Error("Sdk.GetTimeZoneCodeByLocalizedNameRequest LocalizedStandardName property is required and must be a String.")
   }
  }

  function _setValidLocaleId(value) {
   if (typeof value == "number") {
    _localeId = value;
   }
   else {
    throw new Error("Sdk.GetTimeZoneCodeByLocalizedNameRequest LocaleId property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof localizedStandardName != "undefined") {
   _setValidLocalizedStandardName(localizedStandardName);
  }
  if (typeof localeId != "undefined") {
   _setValidLocaleId(localeId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>LocalizedStandardName</b:key>",
              (_localizedStandardName == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _localizedStandardName, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>LocaleId</b:key>",
              (_localeId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _localeId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>GetTimeZoneCodeByLocalizedName</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.GetTimeZoneCodeByLocalizedNameResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setLocalizedStandardName = function (value) {
   ///<summary>
   /// Sets the localized name to search for.
   ///</summary>
   ///<param name="value" type="String">
   /// The localized name to search for.
   ///</param>
   _setValidLocalizedStandardName(value);
   this.setRequestXml(getRequestXml());
  }

  this.setLocaleId = function (value) {
   ///<summary>
   /// Sets the locale ID.
   ///</summary>
   ///<param name="value" type="Number">
   /// The locale ID.
   ///</param>
   _setValidLocaleId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.GetTimeZoneCodeByLocalizedNameRequest.__class = true;

 this.GetTimeZoneCodeByLocalizedNameResponse = function (responseXml) {
  ///<summary>
  /// Response to GetTimeZoneCodeByLocalizedNameRequest
  ///</summary>
  if (!(this instanceof Sdk.GetTimeZoneCodeByLocalizedNameResponse)) {
   return new Sdk.GetTimeZoneCodeByLocalizedNameResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _timeZoneCode = null;

  // Internal property setter functions

  function _setTimeZoneCode(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='TimeZoneCode']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _timeZoneCode = parseInt(Sdk.Xml.getNodeText(valueNode), 10);
   }
  }
  //Public Methods to retrieve properties
  this.getTimeZoneCode = function () {
   ///<summary>
   /// Gets the time zone code that has the requested localized name.
   ///</summary>
   ///<returns type="Number">
   /// The time zone code that has the requested localized name.
   ///</returns>
   return _timeZoneCode;
  }

  //Set property values from responseXml constructor parameter
  _setTimeZoneCode(responseXml);
 }
 this.GetTimeZoneCodeByLocalizedNameResponse.__class = true;
}).call(Sdk)

Sdk.GetTimeZoneCodeByLocalizedNameRequest.prototype = new Sdk.OrganizationRequest();
Sdk.GetTimeZoneCodeByLocalizedNameResponse.prototype = new Sdk.OrganizationResponse();
