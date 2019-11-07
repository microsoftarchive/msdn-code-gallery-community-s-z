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
 this.RetrieveDeploymentLicenseTypeRequest = function () {
  ///<summary>
  /// Contains the data that is needed to  retrieve the type of license for a deployment of pn_microsoftcrm.
  ///</summary>
  if (!(this instanceof Sdk.RetrieveDeploymentLicenseTypeRequest)) {
   return new Sdk.RetrieveDeploymentLicenseTypeRequest();
  }
  Sdk.OrganizationRequest.call(this);

  // This message has no parameters

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters />",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveDeploymentLicenseType</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveDeploymentLicenseTypeResponse);
  this.setRequestXml(getRequestXml());


 }
 this.RetrieveDeploymentLicenseTypeRequest.__class = true;

 this.RetrieveDeploymentLicenseTypeResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveDeploymentLicenseTypeRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveDeploymentLicenseTypeResponse)) {
   return new Sdk.RetrieveDeploymentLicenseTypeResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _licenseType = null;

  // Internal property setter functions

  function _setLicenseType(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='licenseType']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _licenseType = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getLicenseType = function () {
   ///<summary>
   /// Gets the license type.
   ///</summary>
   ///<returns type="String">
   /// The license type.
   ///</returns>
   return _licenseType;
  }

  //Set property values from responseXml constructor parameter
  _setLicenseType(responseXml);
 }
 this.RetrieveDeploymentLicenseTypeResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveDeploymentLicenseTypeRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveDeploymentLicenseTypeResponse.prototype = new Sdk.OrganizationResponse();
