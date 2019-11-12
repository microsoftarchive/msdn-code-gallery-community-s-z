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
 this.DeleteRequest = function (target) {
  ///<summary>
  /// Contains the data that is needed to delete a record. 
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the reference to the record that you want to delete. Required. 
  ///</param>
  if (!(this instanceof Sdk.DeleteRequest)) {
   return new Sdk.DeleteRequest(target);
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
    throw new Error("Sdk.DeleteRequest Target property is required and must be a Sdk.EntityReference.")
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
           "<a:RequestName>Delete</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.DeleteResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the reference to the record that you want to delete. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The reference to the record that you want to delete. 
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.DeleteRequest.__class = true;

 this.DeleteResponse = function (responseXml) {
  ///<summary>
  /// Response to DeleteRequest
  ///</summary>
  if (!(this instanceof Sdk.DeleteResponse)) {
   return new Sdk.DeleteResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.DeleteResponse.__class = true;
}).call(Sdk)

Sdk.DeleteRequest.prototype = new Sdk.OrganizationRequest();
Sdk.DeleteResponse.prototype = new Sdk.OrganizationResponse();
