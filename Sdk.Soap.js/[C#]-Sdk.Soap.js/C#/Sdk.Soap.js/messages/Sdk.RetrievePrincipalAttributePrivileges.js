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
(function () {
 this.RetrievePrincipalAttributePrivilegesRequest = function (principal) {
  ///<summary>
  /// Contains the data that is needed to retrieves all the secured attribute privileges a user or team has through direct or indirect (through team membership) associations with the FieldSecurityProfile entity. 
  ///</summary>
  ///<param name="principal"  type="Sdk.EntityReference">
  /// Sets the security principal (user or team) for which to retrieve attribute privileges. Required. 
  ///</param>
  if (!(this instanceof Sdk.RetrievePrincipalAttributePrivilegesRequest)) {
   return new Sdk.RetrievePrincipalAttributePrivilegesRequest(principal);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _principal = null;

  // internal validation functions

  function _setValidPrincipal(value) {
   if (value instanceof Sdk.EntityReference) {
    _principal = value;
   }
   else {
    throw new Error("Sdk.RetrievePrincipalAttributePrivilegesRequest Principal property is required and must be a Sdk.EntityReference.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof principal != "undefined") {
   _setValidPrincipal(principal);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Principal</b:key>",
              (_principal == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _principal.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrievePrincipalAttributePrivileges</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrievePrincipalAttributePrivilegesResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setPrincipal = function (value) {
   ///<summary>
   /// Sets the security principal (user or team) for which to retrieve attribute privileges. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The security principal (user or team) for which to retrieve attribute privileges. 
   ///</param>
   _setValidPrincipal(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrievePrincipalAttributePrivilegesRequest.__class = true;

 this.RetrievePrincipalAttributePrivilegesResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrievePrincipalAttributePrivilegesRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrievePrincipalAttributePrivilegesResponse)) {
   return new Sdk.RetrievePrincipalAttributePrivilegesResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _attributePrivileges = null;

  // Internal property setter functions

  function _setAttributePrivileges(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='AttributePrivileges']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _attributePrivileges = getAttributePrivilegesFromNode(valueNode);
   }
  }

  function getAttributePrivilegesFromNode(node) {
   var aps = [];
   var attributePrivileges = Sdk.Xml.selectNodes(node, "a:AttributePrivilege");
   for (var i = 0; i < attributePrivileges.length; i++) {
    var apNode = attributePrivileges[i];
    var ap = {};
    ap.AttributeId = Sdk.Xml.selectSingleNodeText(apNode, "a:AttributeId");
    ap.CanCreate = (Sdk.Xml.selectSingleNodeText(apNode, "a:CanCreate") == "0") ? false : true;
    ap.CanRead = (Sdk.Xml.selectSingleNodeText(apNode, "a:CanRead") == "0") ? false : true;
    ap.CanUpdate = (Sdk.Xml.selectSingleNodeText(apNode, "a:CanUpdate") == "0") ? false : true;
    aps.push(ap);
   }

   return aps;


  }
  //Public Methods to retrieve properties
  this.getAttributePrivileges = function () {
   ///<summary>
   /// Gets the collection of attribute privileges for the security principal (user or team). 
   ///</summary>
   ///<returns type="Object">
   /// The collection of attribute privileges for the security principal (user or team). 
   ///</returns>
   return _attributePrivileges;
  }

  //Set property values from responseXml constructor parameter
  _setAttributePrivileges(responseXml);
 }
 this.RetrievePrincipalAttributePrivilegesResponse.__class = true;
}).call(Sdk)

Sdk.RetrievePrincipalAttributePrivilegesRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrievePrincipalAttributePrivilegesResponse.prototype = new Sdk.OrganizationResponse();
