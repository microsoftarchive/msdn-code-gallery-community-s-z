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
 this.RetrieveFilteredFormsRequest = function (entityLogicalName, formType, systemUserId) {
  ///<summary>
  /// Contains the data that is needed to retrieve the entity forms that are available for a specified user. 
  ///</summary>
  ///<param name="entityLogicalName"  type="String">
  /// Sets the logical name for the entity. Required.
  ///</param>
  ///<param name="formType"  type="Number">
  /// Sets the type of form. Required.
  ///</param>
  ///<param name="systemUserId"  type="String">
  /// Sets the ID of the user. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveFilteredFormsRequest)) {
   return new Sdk.RetrieveFilteredFormsRequest(entityLogicalName, formType, systemUserId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _entityLogicalName = null;
  var _formType = null;
  var _systemUserId = null;

  // internal validation functions

  function _setValidEntityLogicalName(value) {
   if (typeof value == "string") {
    _entityLogicalName = value;
   }
   else {
    throw new Error("Sdk.RetrieveFilteredFormsRequest EntityLogicalName property is required and must be a String.")
   }
  }

  function _setValidFormType(value) {
   if (typeof value == "number") {
    _formType = value;
   }
   else {
    throw new Error("Sdk.RetrieveFilteredFormsRequest FormType property is required and must be a Number.")
   }
  }

  function _setValidSystemUserId(value) {
   if (Sdk.Util.isGuid(value)) {
    _systemUserId = value;
   }
   else {
    throw new Error("Sdk.RetrieveFilteredFormsRequest SystemUserId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof entityLogicalName != "undefined") {
   _setValidEntityLogicalName(entityLogicalName);
  }
  if (typeof formType != "undefined") {
   _setValidFormType(formType);
  }
  if (typeof systemUserId != "undefined") {
   _setValidSystemUserId(systemUserId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EntityLogicalName</b:key>",
              (_entityLogicalName == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _entityLogicalName, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>FormType</b:key>",
              (_formType == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:OptionSetValue\">",
               "<a:Value>", _formType, "</a:Value>",
              "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SystemUserId</b:key>",
              (_systemUserId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _systemUserId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveFilteredForms</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveFilteredFormsResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntityLogicalName = function (value) {
   ///<summary>
   /// Sets the logical name for the entity. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The logical name for the entity.
   ///</param>
   _setValidEntityLogicalName(value);
   this.setRequestXml(getRequestXml());
  }

  this.setFormType = function (value) {
   ///<summary>
   /// Sets the type of form. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The type of form.
   ///</param>
   _setValidFormType(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSystemUserId = function (value) {
   ///<summary>
   /// Sets the ID of the user. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the user.
   ///</param>
   _setValidSystemUserId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveFilteredFormsRequest.__class = true;

 this.RetrieveFilteredFormsResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveFilteredFormsRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveFilteredFormsResponse)) {
   return new Sdk.RetrieveFilteredFormsResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _systemForms = null;

  // Internal property setter functions

  function _setSystemForms(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='SystemForms']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _systemForms = Sdk.Util.createEntityReferenceCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getSystemForms = function () {
   ///<summary>
   /// Gets a collection of SystemForm entity references.
   ///</summary>
   ///<returns type="Sdk.EntityReferenceCollection">
   /// A collection of SystemForm entity references.
   ///</returns>
   return _systemForms;
  }

  //Set property values from responseXml constructor parameter
  _setSystemForms(responseXml);
 }
 this.RetrieveFilteredFormsResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveFilteredFormsRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveFilteredFormsResponse.prototype = new Sdk.OrganizationResponse();
