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
 this.RetrieveSharedPrincipalsAndAccessRequest = function (target) {
  ///<summary>
  /// Contains the data that is needed to retrieve all security principals (users or teams) that have access to, and access rights for, the specified record.
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target record for which you want to retrieve security principals (users and teams) and their access rights. 
  ///</param>
  if (!(this instanceof Sdk.RetrieveSharedPrincipalsAndAccessRequest)) {
   return new Sdk.RetrieveSharedPrincipalsAndAccessRequest(target);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.EntityReference) {
    _target = value;
   }
   else {
    throw new Error("Sdk.RetrieveSharedPrincipalsAndAccessRequest Target property is required and must be a Sdk.EntityReference.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Target</b:key>",
              (_target == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _target.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveSharedPrincipalsAndAccess</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveSharedPrincipalsAndAccessResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target record for which you want to retrieve security principals (users and teams) and their access rights. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target record for which you want to retrieve security principals (users and teams) and their access rights. 
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveSharedPrincipalsAndAccessRequest.__class = true;

 this.RetrieveSharedPrincipalsAndAccessResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveSharedPrincipalsAndAccessRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveSharedPrincipalsAndAccessResponse)) {
   return new Sdk.RetrieveSharedPrincipalsAndAccessResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _principalAccesses = null;

  // Internal property setter functions

  function _setPrincipalAccesses(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='PrincipalAccesses']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _principalAccesses = Sdk.Util.createPrincipleAccessCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getPrincipalAccesses = function () {
   ///<summary>
   /// Gets the requested security principals (teams and users) for the specified record.
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// The requested security principals (teams and users) for the specified record.
   ///</returns>
   return _principalAccesses;
  }

  //Set property values from responseXml constructor parameter
  _setPrincipalAccesses(responseXml);
 }
 this.RetrieveSharedPrincipalsAndAccessResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveSharedPrincipalsAndAccessRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveSharedPrincipalsAndAccessResponse.prototype = new Sdk.OrganizationResponse();
