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
 this.RetrievePrincipalAccessRequest = function (target, principal) {
  ///<summary>
  /// Contains the data that is needed to retrieve the access rights of the specified security principal (team or user) to the specified record.
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target record for which to retrieve access rights.
  ///</param>
  ///<param name="principal"  type="Sdk.EntityReference">
  /// Sets the security principal (team or user) for which to return the access rights to the specified record.
  ///</param>
  if (!(this instanceof Sdk.RetrievePrincipalAccessRequest)) {
   return new Sdk.RetrievePrincipalAccessRequest(target, principal);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _principal = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.EntityReference) {
    _target = value;
   }
   else {
    throw new Error("Sdk.RetrievePrincipalAccessRequest Target property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidPrincipal(value) {
   if (value instanceof Sdk.EntityReference) {
    _principal = value;
   }
   else {
    throw new Error("Sdk.RetrievePrincipalAccessRequest Principal property is required and must be a Sdk.EntityReference.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof principal != "undefined") {
   _setValidPrincipal(principal);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Target</b:key>",
              (_target == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _target.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Principal</b:key>",
              (_principal == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _principal.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrievePrincipalAccess</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrievePrincipalAccessResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target record for which to retrieve access rights.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target record for which to retrieve access rights.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setPrincipal = function (value) {
   ///<summary>
   /// Sets the security principal (team or user) for which to return the access rights to the specified record.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The security principal (team or user) for which to return the access rights to the specified record.
   ///</param>
   _setValidPrincipal(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrievePrincipalAccessRequest.__class = true;

 this.RetrievePrincipalAccessResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrievePrincipalAccessRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrievePrincipalAccessResponse)) {
   return new Sdk.RetrievePrincipalAccessResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _accessRights = null;

  // Internal property setter functions

  function _setAccessRights(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='AccessRights']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _accessRights = Sdk.Util.convertAccessRightsFromString(Sdk.Xml.getNodeText(valueNode));
   }
  }
  //Public Methods to retrieve properties
  this.getAccessRights = function () {
   ///<summary>
   /// Gets the access rights that the security principal (team or user) has to the specified record.
   ///</summary>
   ///<returns type="Object">
   /// The access rights that the security principal (team or user) has to the specified record.
   ///</returns>
   return _accessRights;
  }

  //Set property values from responseXml constructor parameter
  _setAccessRights(responseXml);
 }
 this.RetrievePrincipalAccessResponse.__class = true;
}).call(Sdk)

Sdk.RetrievePrincipalAccessRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrievePrincipalAccessResponse.prototype = new Sdk.OrganizationResponse();
