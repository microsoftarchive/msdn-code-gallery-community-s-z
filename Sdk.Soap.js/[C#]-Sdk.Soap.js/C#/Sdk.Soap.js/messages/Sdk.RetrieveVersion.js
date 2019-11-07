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
 this.RetrieveVersionRequest = function () {
  ///<summary>
  /// Contains the data that is needed to  retrieve the version number of the pn_microsoftcrm_server.
  ///</summary>
  if (!(this instanceof Sdk.RetrieveVersionRequest)) {
   return new Sdk.RetrieveVersionRequest();
  }
  Sdk.OrganizationRequest.call(this);

  // This message has no parameters

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters />",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveVersion</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveVersionResponse);
  this.setRequestXml(getRequestXml());
 }
 this.RetrieveVersionRequest.__class = true;

 this.RetrieveVersionResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveVersionRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveVersionResponse)) {
   return new Sdk.RetrieveVersionResponse(responseXml);
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
   /// Gets the version number of the pn_microsoftcrm_server.
   ///</summary>
   ///<returns type="String">
   /// The version number of the pn_microsoftcrm_server.
   ///</returns>
   return _version;
  }

  //Set property values from responseXml constructor parameter
  _setVersion(responseXml);
 }
 this.RetrieveVersionResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveVersionRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveVersionResponse.prototype = new Sdk.OrganizationResponse();
