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
 this.RetrieveInstalledLanguagePacksRequest = function () {
  ///<summary>
  /// Contains the data that is needed to  retrieve the list of language packs that are installed on the server.
  ///</summary>
  if (!(this instanceof Sdk.RetrieveInstalledLanguagePacksRequest)) {
   return new Sdk.RetrieveInstalledLanguagePacksRequest();
  }
  Sdk.OrganizationRequest.call(this);

  // This message has no parameters

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters />",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveInstalledLanguagePacks</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveInstalledLanguagePacksResponse);
  this.setRequestXml(getRequestXml());


 }
 this.RetrieveInstalledLanguagePacksRequest.__class = true;

 this.RetrieveInstalledLanguagePacksResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveInstalledLanguagePacksRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveInstalledLanguagePacksResponse)) {
   return new Sdk.RetrieveInstalledLanguagePacksResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _retrieveInstalledLanguagePacks = null;

  // Internal property setter functions

  function _setRetrieveInstalledLanguagePacks(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='RetrieveInstalledLanguagePacks']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _retrieveInstalledLanguagePacks = Sdk.Util.createIntegerCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getRetrieveInstalledLanguagePacks = function () {
   ///<summary>
   /// Gets a collection of locale ID values that represent the installed language packs.
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// A collection of locale ID values that represent the installed language packs.
   ///</returns>
   return _retrieveInstalledLanguagePacks;
  }

  //Set property values from responseXml constructor parameter
  _setRetrieveInstalledLanguagePacks(responseXml);
 }
 this.RetrieveInstalledLanguagePacksResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveInstalledLanguagePacksRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveInstalledLanguagePacksResponse.prototype = new Sdk.OrganizationResponse();
