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
 this.CompoundUpdateDuplicateDetectionRuleRequest = function (entity, childEntities) {
  ///<summary>
  /// Contains the data that is needed to update a duplicate rule (duplicate detection rule) and its related duplicate rule conditions. 
  ///</summary>
  ///<param name="entity"  type="Sdk.Entity">
  /// Sets the duplicate rule that you want updated. Required. 
  ///</param>
  ///<param name="childEntities"  type="Sdk.EntityCollection">
  /// Sets a collection of the duplicate rule conditions that you want updated. Required. 
  ///</param>
  if (!(this instanceof Sdk.CompoundUpdateDuplicateDetectionRuleRequest)) {
   return new Sdk.CompoundUpdateDuplicateDetectionRuleRequest(entity, childEntities);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _entity = null;
  var _childEntities = null;

  // internal validation functions

  function _setValidEntity(value) {
   if (value instanceof Sdk.Entity) {
    _entity = value;
   }
   else {
    throw new Error("Sdk.CompoundUpdateDuplicateDetectionRuleRequest Entity property is required and must be a Sdk.Entity.")
   }
  }

  function _setValidChildEntities(value) {
   if (value instanceof Sdk.EntityCollection) {
    _childEntities = value;
   }
   else {
    throw new Error("Sdk.CompoundUpdateDuplicateDetectionRuleRequest ChildEntities property is required and must be a Sdk.EntityCollection.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof entity != "undefined") {
   _setValidEntity(entity);
  }
  if (typeof childEntities != "undefined") {
   _setValidChildEntities(childEntities);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Entity</b:key>",
              (_entity == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:Entity\">", _entity.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ChildEntities</b:key>",
              (_childEntities == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityCollection\">", _childEntities.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CompoundUpdateDuplicateDetectionRule</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CompoundUpdateDuplicateDetectionRuleResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntity = function (value) {
   ///<summary>
   /// Sets the duplicate rule that you want updated. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The duplicate rule that you want updated.
   ///</param>
   _setValidEntity(value);
   this.setRequestXml(getRequestXml());
  }

  this.setChildEntities = function (value) {
   ///<summary>
   /// Sets a collection of the duplicate rule conditions that you want updated. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityCollection">
   /// A collection of the duplicate rule conditions that you want updated.
   ///</param>
   _setValidChildEntities(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CompoundUpdateDuplicateDetectionRuleRequest.__class = true;

 this.CompoundUpdateDuplicateDetectionRuleResponse = function (responseXml) {
  ///<summary>
  /// Response to CompoundUpdateDuplicateDetectionRuleRequest
  ///</summary>
  if (!(this instanceof Sdk.CompoundUpdateDuplicateDetectionRuleResponse)) {
   return new Sdk.CompoundUpdateDuplicateDetectionRuleResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values
 }
 this.CompoundUpdateDuplicateDetectionRuleResponse.__class = true;
}).call(Sdk)

Sdk.CompoundUpdateDuplicateDetectionRuleRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CompoundUpdateDuplicateDetectionRuleResponse.prototype = new Sdk.OrganizationResponse();
