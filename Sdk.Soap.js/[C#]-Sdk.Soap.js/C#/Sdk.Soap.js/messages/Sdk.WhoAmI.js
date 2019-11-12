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
 this.WhoAmIRequest = function () {
  ///<summary>
  /// Contains the data that is needed to  retrieve the system user ID for the currently logged on user or the user under whose context the code is running.
  ///</summary>
  if (!(this instanceof Sdk.WhoAmIRequest)) {
   return new Sdk.WhoAmIRequest();
  }
  Sdk.OrganizationRequest.call(this);

  // This message has no parameters

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters />",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>WhoAmI</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.WhoAmIResponse);
  this.setRequestXml(getRequestXml());


 }
 this.WhoAmIRequest.__class = true;

 this.WhoAmIResponse = function (responseXml) {
  ///<summary>
  /// Response to WhoAmIRequest
  ///</summary>
  if (!(this instanceof Sdk.WhoAmIResponse)) {
   return new Sdk.WhoAmIResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _userId = null;
  var _businessUnitId = null;
  var _organizationId = null;

  // Internal property setter functions

  function _setUserId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='UserId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _userId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  function _setBusinessUnitId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='BusinessUnitId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _businessUnitId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  function _setOrganizationId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='OrganizationId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _organizationId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getUserId = function () {
   ///<summary>
   /// Gets the ID of the user who is logged on.
   ///</summary>
   ///<returns type="String">
   /// The ID of the user who is logged on.
   ///</returns>
   return _userId;
  }
  this.getBusinessUnitId = function () {
   ///<summary>
   /// Gets the ID of the business to which the logged on user belongs.
   ///</summary>
   ///<returns type="String">
   /// The ID of the business to which the logged on user belongs.
   ///</returns>
   return _businessUnitId;
  }
  this.getOrganizationId = function () {
   ///<summary>
   /// Gets the ID of the organization that the user belongs to.
   ///</summary>
   ///<returns type="String">
   /// The ID of the organization that the user belongs to.
   ///</returns>
   return _organizationId;
  }

  //Set property values from responseXml constructor parameter
  _setUserId(responseXml);
  _setBusinessUnitId(responseXml);
  _setOrganizationId(responseXml);
 }
 this.WhoAmIResponse.__class = true;
}).call(Sdk)

Sdk.WhoAmIRequest.prototype = new Sdk.OrganizationRequest();
Sdk.WhoAmIResponse.prototype = new Sdk.OrganizationResponse();
