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
 this.RetrieveDeprovisionedLanguagesRequest = function () {
  ///<summary>
  /// Contains the data that is needed to  retrieve a list of language packs that are installed on the server that have been disabled.
  ///</summary>
  if (!(this instanceof Sdk.RetrieveDeprovisionedLanguagesRequest)) {
   return new Sdk.RetrieveDeprovisionedLanguagesRequest();
  }
  Sdk.OrganizationRequest.call(this);

  // This message has no parameters

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters />",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveDeprovisionedLanguages</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveDeprovisionedLanguagesResponse);
  this.setRequestXml(getRequestXml());


 }
 this.RetrieveDeprovisionedLanguagesRequest.__class = true;

 this.RetrieveDeprovisionedLanguagesResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveDeprovisionedLanguagesRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveDeprovisionedLanguagesResponse)) {
   return new Sdk.RetrieveDeprovisionedLanguagesResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _retrieveDeprovisionedLanguages = null;

  // Internal property setter functions

  function _setRetrieveDeprovisionedLanguages(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='RetrieveDeprovisionedLanguages']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _retrieveDeprovisionedLanguages = Sdk.Util.createIntegerCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getRetrieveDeprovisionedLanguages = function () {
   ///<summary>
   /// Gets a collection of locale ID values representing disabled language packs that are installed on the server.
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// A collection of locale ID values representing disabled language packs that are installed on the server.
   ///</returns>
   return _retrieveDeprovisionedLanguages;
  }

  //Set property values from responseXml constructor parameter
  _setRetrieveDeprovisionedLanguages(responseXml);
 }
 this.RetrieveDeprovisionedLanguagesResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveDeprovisionedLanguagesRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveDeprovisionedLanguagesResponse.prototype = new Sdk.OrganizationResponse();
