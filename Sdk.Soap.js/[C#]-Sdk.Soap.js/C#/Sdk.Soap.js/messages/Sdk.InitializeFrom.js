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
 this.InitializeFromRequest = function (entityMoniker, targetEntityName, targetFieldType) {
  ///<summary>
  /// Contains the data that is needed to  initialize a new record from an existing record.
  ///</summary>
  ///<param name="entityMoniker"  type="Sdk.EntityReference">
  /// Sets the record that is the source for initializing.
  ///</param>
  ///<param name="targetEntityName"  type="String">
  /// Sets the logical name of the target entity.
  ///</param>
  ///<param name="targetFieldType"  type="Sdk.TargetFieldType">
  /// Sets which attributes are to be initialized in the initialized instance.
  ///</param>
  if (!(this instanceof Sdk.InitializeFromRequest)) {
   return new Sdk.InitializeFromRequest(entityMoniker, targetEntityName, targetFieldType);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _entityMoniker = null;
  var _targetEntityName = null;
  var _targetFieldType = null;

  // internal validation functions

  function _setValidEntityMoniker(value) {
   if (value instanceof Sdk.EntityReference) {
    _entityMoniker = value;
   }
   else {
    throw new Error("Sdk.InitializeFromRequest EntityMoniker property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidTargetEntityName(value) {
   if (typeof value == "string") {
    _targetEntityName = value;
   }
   else {
    throw new Error("Sdk.InitializeFromRequest TargetEntityName property is required and must be a String.")
   }
  }

  function _setValidTargetFieldType(value) {
   if ((typeof value == "string") && (value == "All" || value == "ValidForCreate" || value == "ValidForRead" || value == "ValidForUpdate")) {
    _targetFieldType = value;
   }
   else {
    throw new Error("Sdk.InitializeFromRequest TargetFieldType property is required and must be a Sdk.TargetFieldType.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof entityMoniker != "undefined") {
   _setValidEntityMoniker(entityMoniker);
  }
  if (typeof targetEntityName != "undefined") {
   _setValidTargetEntityName(targetEntityName);
  }
  if (typeof targetFieldType != "undefined") {
   _setValidTargetFieldType(targetFieldType);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EntityMoniker</b:key>",
              (_entityMoniker == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _entityMoniker.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>TargetEntityName</b:key>",
              (_targetEntityName == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _targetEntityName, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>TargetFieldType</b:key>",
              (_targetFieldType == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"g:TargetFieldType\">", _targetFieldType, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>InitializeFrom</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.InitializeFromResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntityMoniker = function (value) {
   ///<summary>
   /// Sets the record that is the source for initializing.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The record that is the source for initializing.
   ///</param>
   _setValidEntityMoniker(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTargetEntityName = function (value) {
   ///<summary>
   /// Sets the logical name of the target entity.
   ///</summary>
   ///<param name="value" type="String">
   /// The logical name of the target entity.
   ///</param>
   _setValidTargetEntityName(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTargetFieldType = function (value) {
   ///<summary>
   /// Sets which attributes are to be initialized in the initialized instance.
   ///</summary>
   ///<param name="value" type="Sdk.TargetFieldType">
   /// Which attributes are to be initialized in the initialized instance.
   ///</param>
   _setValidTargetFieldType(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.InitializeFromRequest.__class = true;

 this.InitializeFromResponse = function (responseXml) {
  ///<summary>
  /// Response to InitializeFromRequest
  ///</summary>
  if (!(this instanceof Sdk.InitializeFromResponse)) {
   return new Sdk.InitializeFromResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _entity = null;

  // Internal property setter functions

  function _setEntity(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Entity']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _entity = Sdk.Util.createEntityFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEntity = function () {
   ///<summary>
   /// Gets the initialized instance.
   ///</summary>
   ///<returns type="Sdk.Entity">
   /// The initialized instance.
   ///</returns>
   return _entity;
  }

  //Set property values from responseXml constructor parameter
  _setEntity(responseXml);
 }
 this.InitializeFromResponse.__class = true;
}).call(Sdk)

Sdk.InitializeFromRequest.prototype = new Sdk.OrganizationRequest();
Sdk.InitializeFromResponse.prototype = new Sdk.OrganizationResponse();
