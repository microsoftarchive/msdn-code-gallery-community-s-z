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
 this.RetrieveLicenseInfoRequest = function (accessMode) {
  ///<summary>
  /// Contains the data that is needed to retrieve the number of used and available licenses for a deployment of pn_microsoftcrm.
  ///</summary>
  ///<param name="accessMode"  type="Number">
  /// Sets the access mode for retrieving the license information.
  ///</param>
  if (!(this instanceof Sdk.RetrieveLicenseInfoRequest)) {
   return new Sdk.RetrieveLicenseInfoRequest(accessMode);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _accessMode = null;

  // internal validation functions

  function _setValidAccessMode(value) {
   if (typeof value == "number") {
    _accessMode = value;
   }
   else {
    throw new Error("Sdk.RetrieveLicenseInfoRequest AccessMode property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof accessMode != "undefined") {
   _setValidAccessMode(accessMode);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>AccessMode</b:key>",
              (_accessMode == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _accessMode, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveLicenseInfo</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveLicenseInfoResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setAccessMode = function (value) {
   ///<summary>
   /// Sets the access mode for retrieving the license information.
   ///</summary>
   ///<param name="value" type="Number">
   /// The access mode for retrieving the license information.
   ///</param>
   _setValidAccessMode(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveLicenseInfoRequest.__class = true;

 this.RetrieveLicenseInfoResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveLicenseInfoRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveLicenseInfoResponse)) {
   return new Sdk.RetrieveLicenseInfoResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _availableCount = null;
  var _grantedLicenseCount = null;

  // Internal property setter functions

  function _setAvailableCount(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='AvailableCount']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _availableCount = parseInt(Sdk.Xml.getNodeText(valueNode), 10);
   }
  }
  function _setGrantedLicenseCount(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='GrantedLicenseCount']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _grantedLicenseCount = parseInt(Sdk.Xml.getNodeText(valueNode), 10);
   }
  }
  //Public Methods to retrieve properties
  this.getAvailableCount = function () {
   ///<summary>
   /// Gets the number of unused licenses.
   ///</summary>
   ///<returns type="Number">
   /// The number of unused licenses.
   ///</returns>
   return _availableCount;
  }
  this.getGrantedLicenseCount = function () {
   ///<summary>
   /// Gets the number of licenses that have been granted to users.
   ///</summary>
   ///<returns type="Number">
   /// The number of licenses that have been granted to users.
   ///</returns>
   return _grantedLicenseCount;
  }

  //Set property values from responseXml constructor parameter
  _setAvailableCount(responseXml);
  _setGrantedLicenseCount(responseXml);
 }
 this.RetrieveLicenseInfoResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveLicenseInfoRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveLicenseInfoResponse.prototype = new Sdk.OrganizationResponse();
