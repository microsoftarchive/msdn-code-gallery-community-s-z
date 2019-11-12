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
 this.RetrieveAvailableLanguagesRequest = function () {
  ///<summary>
  /// Contains the data that is needed to retrieve the list of language packs that are installed and enabled on the server.
  ///</summary>
  if (!(this instanceof Sdk.RetrieveAvailableLanguagesRequest)) {
   return new Sdk.RetrieveAvailableLanguagesRequest();
  }
  Sdk.OrganizationRequest.call(this);

  // This message has no parameters

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters />",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveAvailableLanguages</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveAvailableLanguagesResponse);
  this.setRequestXml(getRequestXml());


 }
 this.RetrieveAvailableLanguagesRequest.__class = true;

 this.RetrieveAvailableLanguagesResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveAvailableLanguagesRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveAvailableLanguagesResponse)) {
   return new Sdk.RetrieveAvailableLanguagesResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _localeIds = null;

  // Internal property setter functions

  function _setLocaleIds(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='LocaleIds']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _localeIds = Sdk.Util.createIntegerCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getLocaleIds = function () {
   ///<summary>
   /// Gets an array of locale ID values representing the language packs that are installed on the server.
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// A collection of locale ID values representing the language packs that are installed on the server.
   ///</returns>
   return _localeIds;
  }

  //Set property values from responseXml constructor parameter
  _setLocaleIds(responseXml);
 }
 this.RetrieveAvailableLanguagesResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveAvailableLanguagesRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveAvailableLanguagesResponse.prototype = new Sdk.OrganizationResponse();
