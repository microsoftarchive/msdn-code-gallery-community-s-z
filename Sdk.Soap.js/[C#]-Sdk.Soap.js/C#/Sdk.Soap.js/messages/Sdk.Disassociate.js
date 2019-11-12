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
 this.DisassociateRequest = function (target, relationship, relatedEntities) {
  ///<summary>
  /// Contains the data that is needed to delete a link between records. 
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target, which is the record from which the related records will be disassociated. Required. 
  ///</param>
  ///<param name="relationship"  type="String">
  /// Sets the name of the relationship to be used for the disassociation. Required. 
  ///</param>
  ///<param name="relatedEntities"  type="Sdk.EntityReferenceCollection">
  /// Sets the collection of entity references (references to records) to be disassociated. Required. 
  ///</param>
  if (!(this instanceof Sdk.DisassociateRequest)) {
   return new Sdk.DisassociateRequest(target, relationship, relatedEntities);
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
    throw new Error("Sdk.DisassociateRequest Target property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidRelationship(value) {
   if (typeof value == "string") {
    _relationship = value;
   }
   else {
    throw new Error("Sdk.DisassociateRequest Relationship property is required and must be a String.")
   }
  }

  function _setValidRelatedEntities(value) {
   if (value instanceof Sdk.EntityReferenceCollection) {
    _relatedEntities = value;
   }
   else {
    throw new Error("Sdk.DisassociateRequest RelatedEntities property is required and must be a Sdk.EntityReferenceCollection.")
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
           "<a:RequestName>Disassociate</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.DisassociateResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target, which is the record from which the related records will be disassociated. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target, which is the record from which the related records will be disassociated. 
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRelationship = function (value) {
   ///<summary>
   /// Sets the name of the relationship to be used for the disassociation. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The name of the relationship to be used for the disassociation. 
   ///</param>
   _setValidRelationship(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRelatedEntities = function (value) {
   ///<summary>
   /// Sets the collection of entity references (references to records) to be disassociated. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReferenceCollection">
   /// The collection of entity references (references to records) to be disassociated. 
   ///</param>
   _setValidRelatedEntities(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.DisassociateRequest.__class = true;

 this.DisassociateResponse = function (responseXml) {
  ///<summary>
  /// Response to DisassociateRequest
  ///</summary>
  if (!(this instanceof Sdk.DisassociateResponse)) {
   return new Sdk.DisassociateResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values
 }
 this.DisassociateResponse.__class = true;
}).call(Sdk)

Sdk.DisassociateRequest.prototype = new Sdk.OrganizationRequest();
Sdk.DisassociateResponse.prototype = new Sdk.OrganizationResponse();
