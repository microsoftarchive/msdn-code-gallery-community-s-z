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
 this.GetAllTimeZonesWithDisplayNameRequest = function (localeId) {
  ///<summary>
  /// Contains the data that is needed to retrieve all the time zone definitions for the specified locale and to return only the display name attribute. 
  ///</summary>
  ///<param name="localeId"  type="Number">
  /// Sets the locale ID. Required. 
  ///</param>
  if (!(this instanceof Sdk.GetAllTimeZonesWithDisplayNameRequest)) {
   return new Sdk.GetAllTimeZonesWithDisplayNameRequest(localeId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _localeId = null;

  // internal validation functions

  function _setValidLocaleId(value) {
   if (typeof value == "number") {
    _localeId = value;
   }
   else {
    throw new Error("Sdk.GetAllTimeZonesWithDisplayNameRequest LocaleId property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof localeId != "undefined") {
   _setValidLocaleId(localeId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>LocaleId</b:key>",
              (_localeId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _localeId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>GetAllTimeZonesWithDisplayName</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.GetAllTimeZonesWithDisplayNameResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setLocaleId = function (value) {
   ///<summary>
   /// Sets the locale ID. Required. 
   ///</summary>
   ///<param name="value" type="Number">
   /// The locale ID. Required. 
   ///</param>
   _setValidLocaleId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.GetAllTimeZonesWithDisplayNameRequest.__class = true;

 this.GetAllTimeZonesWithDisplayNameResponse = function (responseXml) {
  ///<summary>
  /// Response to GetAllTimeZonesWithDisplayNameRequest
  ///</summary>
  if (!(this instanceof Sdk.GetAllTimeZonesWithDisplayNameResponse)) {
   return new Sdk.GetAllTimeZonesWithDisplayNameResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _entityCollection = null;

  // Internal property setter functions

  function _setEntityCollection(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='EntityCollection']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _entityCollection = Sdk.Util.createEntityCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEntityCollection = function () {
   ///<summary>
   /// Gets the collection of the time zone definition (TimeZoneDefinition) records. 
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The collection of the time zone definition (TimeZoneDefinition) records. 
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.GetAllTimeZonesWithDisplayNameResponse.__class = true;
}).call(Sdk)

Sdk.GetAllTimeZonesWithDisplayNameRequest.prototype = new Sdk.OrganizationRequest();
Sdk.GetAllTimeZonesWithDisplayNameResponse.prototype = new Sdk.OrganizationResponse();
