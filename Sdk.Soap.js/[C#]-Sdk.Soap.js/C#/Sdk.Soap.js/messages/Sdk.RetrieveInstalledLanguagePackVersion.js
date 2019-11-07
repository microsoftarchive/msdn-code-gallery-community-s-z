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
 this.RetrieveInstalledLanguagePackVersionRequest = function (language) {
  ///<summary>
  /// Contains the data that is needed to  retrieve the version of an installed language pack.
  ///</summary>
  ///<param name="language"  type="Number">
  /// Sets the value that represents the locale ID for the language pack. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveInstalledLanguagePackVersionRequest)) {
   return new Sdk.RetrieveInstalledLanguagePackVersionRequest(language);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _language = null;

  // internal validation functions

  function _setValidLanguage(value) {
   if (typeof value == "number") {
    _language = value;
   }
   else {
    throw new Error("Sdk.RetrieveInstalledLanguagePackVersionRequest Language property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof language != "undefined") {
   _setValidLanguage(language);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Language</b:key>",
              (_language == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _language, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveInstalledLanguagePackVersion</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveInstalledLanguagePackVersionResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setLanguage = function (value) {
   ///<summary>
   /// Sets the value that represents the locale ID for the language pack. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The value that represents the locale ID for the language pack.
   ///</param>
   _setValidLanguage(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveInstalledLanguagePackVersionRequest.__class = true;

 this.RetrieveInstalledLanguagePackVersionResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveInstalledLanguagePackVersionRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveInstalledLanguagePackVersionResponse)) {
   return new Sdk.RetrieveInstalledLanguagePackVersionResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _version = null;

  // Internal property setter functions

  function _setVersion(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Version']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _version = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getVersion = function () {
   ///<summary>
   /// Gets the version number of the installed language pack.
   ///</summary>
   ///<returns type="String">
   /// The version number of the installed language pack.
   ///</returns>
   return _version;
  }

  //Set property values from responseXml constructor parameter
  _setVersion(responseXml);
 }
 this.RetrieveInstalledLanguagePackVersionResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveInstalledLanguagePackVersionRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveInstalledLanguagePackVersionResponse.prototype = new Sdk.OrganizationResponse();
