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
 this.RemoveParentRequest = function (target) {
  ///<summary>
  /// Contains the data that is needed to  remove the parent for a system user (user) record.
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target systemuser (user) record for the operation.
  ///</param>
  if (!(this instanceof Sdk.RemoveParentRequest)) {
   return new Sdk.RemoveParentRequest(target);
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
    throw new Error("Sdk.RemoveParentRequest Target property is required and must be a Sdk.EntityReference.")
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
           "<a:RequestName>RemoveParent</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RemoveParentResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target systemuser (user) record for the operation.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target systemuser (user) record for the operation.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RemoveParentRequest.__class = true;

 this.RemoveParentResponse = function (responseXml) {
  ///<summary>
  /// Response to RemoveParentRequest
  ///</summary>
  if (!(this instanceof Sdk.RemoveParentResponse)) {
   return new Sdk.RemoveParentResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.RemoveParentResponse.__class = true;
}).call(Sdk)

Sdk.RemoveParentRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RemoveParentResponse.prototype = new Sdk.OrganizationResponse();
