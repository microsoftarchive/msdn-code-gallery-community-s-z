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
 this.ReassignObjectsOwnerRequest = function (fromPrincipal, toPrincipal) {
  ///<summary>
  /// Contains the data that is needed to  reassign all records that are owned by the security principal (user or team) to another security principal (user or team).
  ///</summary>
  ///<param name="fromPrincipal"  type="Sdk.EntityReference">
  /// Sets the security principal (user or team) for which to reassign all records.
  ///</param>
  ///<param name="toPrincipal"  type="Sdk.EntityReference">
  /// Sets the security principal (user or team) that will be the new owner for the records.
  ///</param>
  if (!(this instanceof Sdk.ReassignObjectsOwnerRequest)) {
   return new Sdk.ReassignObjectsOwnerRequest(fromPrincipal, toPrincipal);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _fromPrincipal = null;
  var _toPrincipal = null;

  // internal validation functions

  function _setValidFromPrincipal(value) {
   if (value instanceof Sdk.EntityReference) {
    _fromPrincipal = value;
   }
   else {
    throw new Error("Sdk.ReassignObjectsOwnerRequest FromPrincipal property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidToPrincipal(value) {
   if (value instanceof Sdk.EntityReference) {
    _toPrincipal = value;
   }
   else {
    throw new Error("Sdk.ReassignObjectsOwnerRequest ToPrincipal property is required and must be a Sdk.EntityReference.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof fromPrincipal != "undefined") {
   _setValidFromPrincipal(fromPrincipal);
  }
  if (typeof toPrincipal != "undefined") {
   _setValidToPrincipal(toPrincipal);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>FromPrincipal</b:key>",
              (_fromPrincipal == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _fromPrincipal.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ToPrincipal</b:key>",
              (_toPrincipal == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _toPrincipal.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ReassignObjectsOwner</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ReassignObjectsOwnerResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setFromPrincipal = function (value) {
   ///<summary>
   /// Sets the security principal (user or team) for which to reassign all records.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   ///The security principal (user or team) for which to reassign all records.
   ///</param>
   _setValidFromPrincipal(value);
   this.setRequestXml(getRequestXml());
  }

  this.setToPrincipal = function (value) {
   ///<summary>
   /// Sets the security principal (user or team) that will be the new owner for the records.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The security principal (user or team) that will be the new owner for the records.
   ///</param>
   _setValidToPrincipal(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ReassignObjectsOwnerRequest.__class = true;

 this.ReassignObjectsOwnerResponse = function (responseXml) {
  ///<summary>
  /// Response to ReassignObjectsOwnerRequest
  ///</summary>
  if (!(this instanceof Sdk.ReassignObjectsOwnerResponse)) {
   return new Sdk.ReassignObjectsOwnerResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.ReassignObjectsOwnerResponse.__class = true;
}).call(Sdk)

Sdk.ReassignObjectsOwnerRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ReassignObjectsOwnerResponse.prototype = new Sdk.OrganizationResponse();
