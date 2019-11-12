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
 this.RetrieveProvisionedLanguagesRequest = function () {
  ///<summary>
  /// Contains the data that is needed to  retrieve the list of provisioned languages. 
  ///</summary>
  if (!(this instanceof Sdk.RetrieveProvisionedLanguagesRequest)) {
   return new Sdk.RetrieveProvisionedLanguagesRequest();
  }
  Sdk.OrganizationRequest.call(this);

  // This message has no parameters

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters />",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveProvisionedLanguages</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveProvisionedLanguagesResponse);
  this.setRequestXml(getRequestXml());


 }
 this.RetrieveProvisionedLanguagesRequest.__class = true;

 this.RetrieveProvisionedLanguagesResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveProvisionedLanguagesRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveProvisionedLanguagesResponse)) {
   return new Sdk.RetrieveProvisionedLanguagesResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _retrieveProvisionedLanguages = null;

  // Internal property setter functions

  function _setRetrieveProvisionedLanguages(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='RetrieveProvisionedLanguages']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _retrieveProvisionedLanguages = Sdk.Util.createIntegerCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getRetrieveProvisionedLanguages = function () {
   ///<summary>
   /// Gets a collection of locale ID values that represent the provisioned languages.
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// A collection of locale ID values that represent the provisioned languages.
   ///</returns>
   return _retrieveProvisionedLanguages;
  }

  //Set property values from responseXml constructor parameter
  _setRetrieveProvisionedLanguages(responseXml);
 }
 this.RetrieveProvisionedLanguagesResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveProvisionedLanguagesRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveProvisionedLanguagesResponse.prototype = new Sdk.OrganizationResponse();
