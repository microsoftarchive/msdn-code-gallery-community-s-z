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
 this.ProvisionLanguageRequest = function (language) {
  ///<summary>
  /// Contains the data that is needed to  provision a new language.
  ///</summary>
  ///<param name="language"  type="Number">
  /// Sets the language to provision. Required.
  ///</param>
  if (!(this instanceof Sdk.ProvisionLanguageRequest)) {
   return new Sdk.ProvisionLanguageRequest(language);
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
    throw new Error("Sdk.ProvisionLanguageRequest Language property is required and must be a Number.")
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
           "<a:RequestName>ProvisionLanguage</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ProvisionLanguageResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setLanguage = function (value) {
   ///<summary>
   /// Sets the language to provision. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The language to provision.
   ///</param>
   _setValidLanguage(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ProvisionLanguageRequest.__class = true;

 this.ProvisionLanguageResponse = function (responseXml) {
  ///<summary>
  /// Response to ProvisionLanguageRequest
  ///</summary>
  if (!(this instanceof Sdk.ProvisionLanguageResponse)) {
   return new Sdk.ProvisionLanguageResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.ProvisionLanguageResponse.__class = true;
}).call(Sdk)

Sdk.ProvisionLanguageRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ProvisionLanguageResponse.prototype = new Sdk.OrganizationResponse();
