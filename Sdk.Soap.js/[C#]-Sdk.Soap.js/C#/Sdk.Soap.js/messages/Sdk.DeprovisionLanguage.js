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
 this.DeprovisionLanguageRequest = function (language) {
  ///<summary>
  /// Contains the data that is needed to deprovision a language. 
  ///</summary>
  ///<param name="language"  type="Number">
  /// Sets the language to deprovision. Required. 
  ///</param>
  if (!(this instanceof Sdk.DeprovisionLanguageRequest)) {
   return new Sdk.DeprovisionLanguageRequest(language);
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
    throw new Error("Sdk.DeprovisionLanguageRequest Language property is required and must be a Number.")
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
           "<a:RequestName>DeprovisionLanguage</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.DeprovisionLanguageResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setLanguage = function (value) {
   ///<summary>
   /// Sets the language to deprovision. Required. 
   ///</summary>
   ///<param name="value" type="Number">
   /// The language to deprovision. 
   ///</param>
   _setValidLanguage(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.DeprovisionLanguageRequest.__class = true;

 this.DeprovisionLanguageResponse = function (responseXml) {
  ///<summary>
  /// Response to DeprovisionLanguageRequest
  ///</summary>
  if (!(this instanceof Sdk.DeprovisionLanguageResponse)) {
   return new Sdk.DeprovisionLanguageResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.DeprovisionLanguageResponse.__class = true;
}).call(Sdk)

Sdk.DeprovisionLanguageRequest.prototype = new Sdk.OrganizationRequest();
Sdk.DeprovisionLanguageResponse.prototype = new Sdk.OrganizationResponse();
