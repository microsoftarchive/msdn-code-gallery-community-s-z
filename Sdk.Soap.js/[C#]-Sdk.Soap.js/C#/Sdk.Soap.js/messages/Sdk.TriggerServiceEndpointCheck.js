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
 this.TriggerServiceEndpointCheckRequest = function (entity) {
  ///<summary>
  /// Contains the data that is needed to  validate the configuration of a windows Azure service bus solution’s service endpoint.
  ///</summary>
  ///<param name="entity"  type="Sdk.EntityReference">
  /// Sets the ServiceEndpoint record that contains the configuration. Required.
  ///</param>
  if (!(this instanceof Sdk.TriggerServiceEndpointCheckRequest)) {
   return new Sdk.TriggerServiceEndpointCheckRequest(entity);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _entity = null;

  // internal validation functions

  function _setValidEntity(value) {
   if (value instanceof Sdk.EntityReference) {
    _entity = value;
   }
   else {
    throw new Error("Sdk.TriggerServiceEndpointCheckRequest Entity property is required and must be a Sdk.EntityReference.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof entity != "undefined") {
   _setValidEntity(entity);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Entity</b:key>",
              (_entity == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _entity.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>TriggerServiceEndpointCheck</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.TriggerServiceEndpointCheckResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntity = function (value) {
   ///<summary>
   /// Sets the ServiceEndpoint record that contains the configuration. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The ServiceEndpoint record that contains the configuration.
   ///</param>
   _setValidEntity(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.TriggerServiceEndpointCheckRequest.__class = true;

 this.TriggerServiceEndpointCheckResponse = function (responseXml) {
  ///<summary>
  /// Response to TriggerServiceEndpointCheckRequest
  ///</summary>
  if (!(this instanceof Sdk.TriggerServiceEndpointCheckResponse)) {
   return new Sdk.TriggerServiceEndpointCheckResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.TriggerServiceEndpointCheckResponse.__class = true;
}).call(Sdk)

Sdk.TriggerServiceEndpointCheckRequest.prototype = new Sdk.OrganizationRequest();
Sdk.TriggerServiceEndpointCheckResponse.prototype = new Sdk.OrganizationResponse();
