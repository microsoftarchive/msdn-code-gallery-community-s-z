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
 this.RevokeAccessRequest = function (target, revokee) {
  ///<summary>
  /// Contains the data that is needed to replace the access rights on the target record for the specified security principal (user or team).
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target record for which you want to revoke access.  Required.
  ///</param>
  ///<param name="revokee"  type="Sdk.EntityReference">
  /// Sets a security principal (team or user) whose access you want to revoke. Required.
  ///</param>
  if (!(this instanceof Sdk.RevokeAccessRequest)) {
   return new Sdk.RevokeAccessRequest(target, revokee);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _revokee = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.EntityReference) {
    _target = value;
   }
   else {
    throw new Error("Sdk.RevokeAccessRequest Target property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidRevokee(value) {
   if (value instanceof Sdk.EntityReference) {
    _revokee = value;
   }
   else {
    throw new Error("Sdk.RevokeAccessRequest Revokee property is required and must be a Sdk.EntityReference.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof revokee != "undefined") {
   _setValidRevokee(revokee);
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
               "<b:key>Revokee</b:key>",
              (_revokee == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _revokee.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RevokeAccess</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RevokeAccessResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target record for which you want to revoke access.  Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target record for which you want to revoke access.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRevokee = function (value) {
   ///<summary>
   /// Sets a security principal (team or user) whose access you want to revoke. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// A security principal (team or user) whose access you want to revoke.
   ///</param>
   _setValidRevokee(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RevokeAccessRequest.__class = true;

 this.RevokeAccessResponse = function (responseXml) {
  ///<summary>
  /// Response to RevokeAccessRequest
  ///</summary>
  if (!(this instanceof Sdk.RevokeAccessResponse)) {
   return new Sdk.RevokeAccessResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.RevokeAccessResponse.__class = true;
}).call(Sdk)

Sdk.RevokeAccessRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RevokeAccessResponse.prototype = new Sdk.OrganizationResponse();
