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
 this.CopySystemFormRequest = function (target, sourceId) {
  ///<summary>
  /// Contains the data that is needed to create a new entity form that is based on an existing entity form. 
  ///</summary>
  ///<param name="target" optional="true" type="Sdk.Entity">
  /// Sets the SystemForm that the original system form should be copied to. Optional. 
  ///</param>
  ///<param name="sourceId"  type="String">
  /// Sets the ID value of the form to copy. Required. 
  ///</param>
  if (!(this instanceof Sdk.CopySystemFormRequest)) {
   return new Sdk.CopySystemFormRequest(target, sourceId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _sourceId = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value == null || value instanceof Sdk.Entity) {
    _target = value;
   }
   else {
    throw new Error("Sdk.CopySystemFormRequest Target property must be a Sdk.Entity or null.")
   }
  }

  function _setValidSourceId(value) {
   if (Sdk.Util.isGuid(value)) {
    _sourceId = value;
   }
   else {
    throw new Error("Sdk.CopySystemFormRequest SourceId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof sourceId != "undefined") {
   _setValidSourceId(sourceId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Target</b:key>",
              (_target == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:Entity\">", _target.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SourceId</b:key>",
              (_sourceId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _sourceId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CopySystemForm</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CopySystemFormResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the SystemForm that the original system form should be copied to. Optional. 
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The SystemForm that the original system form should be copied to. 
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSourceId = function (value) {
   ///<summary>
   /// Sets the ID value of the form to copy. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID value of the form to copy.
   ///</param>
   _setValidSourceId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CopySystemFormRequest.__class = true;

 this.CopySystemFormResponse = function (responseXml) {
  ///<summary>
  /// Response to CopySystemFormRequest
  ///</summary>
  if (!(this instanceof Sdk.CopySystemFormResponse)) {
   return new Sdk.CopySystemFormResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _id = null;

  // Internal property setter functions

  function _setId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Id']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _id = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getId = function () {
   ///<summary>
   /// Gets the ID of the system form that the original was copied to. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the system form that the original was copied to. 
   ///</returns>
   return _id;
  }

  //Set property values from responseXml constructor parameter
  _setId(responseXml);
 }
 this.CopySystemFormResponse.__class = true;
}).call(Sdk)

Sdk.CopySystemFormRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CopySystemFormResponse.prototype = new Sdk.OrganizationResponse();
