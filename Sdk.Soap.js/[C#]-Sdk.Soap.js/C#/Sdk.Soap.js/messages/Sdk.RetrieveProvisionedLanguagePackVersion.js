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
 this.RetrieveProvisionedLanguagePackVersionRequest = function (language) {
  ///<summary>
  /// Contains the data that is needed to  retrieve the version of a provisioned language pack. 
  ///</summary>
  ///<param name="language"  type="Number">
  /// Sets the Locale Id for the language. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveProvisionedLanguagePackVersionRequest)) {
   return new Sdk.RetrieveProvisionedLanguagePackVersionRequest(language);
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
    throw new Error("Sdk.RetrieveProvisionedLanguagePackVersionRequest Language property is required and must be a Number.")
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
           "<a:RequestName>RetrieveProvisionedLanguagePackVersion</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveProvisionedLanguagePackVersionResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setLanguage = function (value) {
   ///<summary>
   /// Sets the Locale Id for the language. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The Locale Id for the language.
   ///</param>
   _setValidLanguage(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveProvisionedLanguagePackVersionRequest.__class = true;

 this.RetrieveProvisionedLanguagePackVersionResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveProvisionedLanguagePackVersionRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveProvisionedLanguagePackVersionResponse)) {
   return new Sdk.RetrieveProvisionedLanguagePackVersionResponse(responseXml);
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
 this.RetrieveProvisionedLanguagePackVersionResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveProvisionedLanguagePackVersionRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveProvisionedLanguagePackVersionResponse.prototype = new Sdk.OrganizationResponse();
