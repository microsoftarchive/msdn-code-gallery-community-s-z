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
 this.UpdateRequest = function (target) {
  ///<summary>
  /// Contains the data that is needed to update an existing record. 
  ///</summary>
  ///<param name="target" type="Sdk.Entity">
  /// Sets an instance of an entity that is used to update a record. Required. 
  ///</param>
  if (!(this instanceof Sdk.UpdateRequest)) {
   return new Sdk.UpdateRequest(target);
  }
  Sdk.OrganizationRequest.call(this);

  var _target;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.Entity) {
    _target = value;
   }
   else {
    throw new Error("Sdk.UpdateRequest Target property is required and must be a Sdk.Entity.")
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
           ["<b:value i:type=\"a:Entity\">",
            _target.toValueXml("update"), //This is what makes this message special
            "</b:value>"].join(""),
    "</a:KeyValuePairOfstringanyType>",
  "</a:Parameters>",
  "<a:RequestId i:nil=\"true\" />",
  "<a:RequestName>Update</a:RequestName>",
"</d:request>"].join("");
  }

  this.setResponseType(Sdk.UpdateResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets an instance of an entity that is used to update a record. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// An instance of an entity that is used to update a record. 
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.UpdateRequest.__class = true;
 this.UpdateResponse = function () {
  ///<summary>
  /// Response to UpdateRequest
  ///</summary>
  if (!(this instanceof Sdk.UpdateResponse)) {
   return new Sdk.UpdateResponse();
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.UpdateResponse.__class = true;
}).call(Sdk)
Sdk.UpdateRequest.prototype = new Sdk.OrganizationRequest();
Sdk.UpdateResponse.prototype = new Sdk.OrganizationResponse();

