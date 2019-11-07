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
 this.AssociateRequest = function (target, relationship, relatedEntities) {
  ///<summary>
  /// Contains the data that is needed to create a link between records. 
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target that is the record to which the related records are associated.
  ///</param>
  ///<param name="relationship"  type="String">
  /// Sets the relationship name to be used for an association. 
  ///</param>
  ///<param name="relatedEntities"  type="Sdk.EntityReferenceCollection">
  /// Sets the collection of entity references (references to records) to be associated. 
  ///</param>
  if (!(this instanceof Sdk.AssociateRequest)) {
   return new Sdk.AssociateRequest(target, relationship, relatedEntities);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _relationship = null;
  var _relatedEntities = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.EntityReference) {
    _target = value;
   }
   else {
    throw new Error("Sdk.AssociateRequest Target property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidRelationship(value) {
   if (typeof value == "string") {
    _relationship = value;
   }
   else {
    throw new Error("Sdk.AssociateRequest Relationship property is required and must be a String.")
   }
  }

  function _setValidRelatedEntities(value) {
   if (value instanceof Sdk.EntityReferenceCollection) {
    _relatedEntities = value;
   }
   else {
    throw new Error("Sdk.AssociateRequest RelatedEntities property is required and must be a Sdk.EntityReferenceCollection.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof relationship != "undefined") {
   _setValidRelationship(relationship);
  }
  if (typeof relatedEntities != "undefined") {
   _setValidRelatedEntities(relatedEntities);
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
               "<b:key>Relationship</b:key>",
              (_relationship == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:Relationship\">",
              "<a:PrimaryEntityRole i:nil=\"true\" />",
              "<a:SchemaName>", _relationship, "</a:SchemaName>",
              "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>RelatedEntities</b:key>",
              (_relatedEntities == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReferenceCollection\">", _relatedEntities.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>Associate</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.AssociateResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target that is the record to which the related records are associated. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target that is the record to which the related records are associated.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRelationship = function (value) {
   ///<summary>
   /// Sets the relationship name to be used for an association. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The relationship name to be used for an association.
   ///</param>
   _setValidRelationship(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRelatedEntities = function (value) {
   ///<summary>
   /// Sets the collection of entity references (references to records) to be associated. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReferenceCollection">
   /// The collection of entity references (references to records) to be associated.
   ///</param>
   _setValidRelatedEntities(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.AssociateRequest.__class = true;

 this.AssociateResponse = function (responseXml) {
  ///<summary>
  /// Response to AssociateRequest
  ///</summary>
  if (!(this instanceof Sdk.AssociateResponse)) {
   return new Sdk.AssociateResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values






 }
 this.AssociateResponse.__class = true;
}).call(Sdk)

Sdk.AssociateRequest.prototype = new Sdk.OrganizationRequest();
Sdk.AssociateResponse.prototype = new Sdk.OrganizationResponse();
