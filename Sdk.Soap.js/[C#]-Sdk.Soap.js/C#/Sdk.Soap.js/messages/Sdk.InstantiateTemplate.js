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
 this.InstantiateTemplateRequest = function (templateId, objectType, objectId) {
  ///<summary>
  /// Contains the parameters that are needed to create an email message from a template (email template).
  ///</summary>
  ///<param name="templateId"  type="String">
  /// Sets the ID of the template. Required.
  ///</param>
  ///<param name="objectType"  type="String">
  /// Sets the type of entity that is represented by the  property. Required.
  ///</param>
  ///<param name="objectId"  type="String">
  /// Sets the ID of the record that the email is regarding. Required.
  ///</param>
  if (!(this instanceof Sdk.InstantiateTemplateRequest)) {
   return new Sdk.InstantiateTemplateRequest(templateId, objectType, objectId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _templateId = null;
  var _objectType = null;
  var _objectId = null;

  // internal validation functions

  function _setValidTemplateId(value) {
   if (Sdk.Util.isGuid(value)) {
    _templateId = value;
   }
   else {
    throw new Error("Sdk.InstantiateTemplateRequest TemplateId property is required and must be a String.")
   }
  }

  function _setValidObjectType(value) {
   if (typeof value == "string") {
    _objectType = value;
   }
   else {
    throw new Error("Sdk.InstantiateTemplateRequest ObjectType property is required and must be a String.")
   }
  }

  function _setValidObjectId(value) {
   if (Sdk.Util.isGuid(value)) {
    _objectId = value;
   }
   else {
    throw new Error("Sdk.InstantiateTemplateRequest ObjectId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof templateId != "undefined") {
   _setValidTemplateId(templateId);
  }
  if (typeof objectType != "undefined") {
   _setValidObjectType(objectType);
  }
  if (typeof objectId != "undefined") {
   _setValidObjectId(objectId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>TemplateId</b:key>",
              (_templateId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _templateId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ObjectType</b:key>",
              (_objectType == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _objectType, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ObjectId</b:key>",
              (_objectId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _objectId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>InstantiateTemplate</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.InstantiateTemplateResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTemplateId = function (value) {
   ///<summary>
   /// Sets the ID of the template. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the template.
   ///</param>
   _setValidTemplateId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setObjectType = function (value) {
   ///<summary>
   /// Sets the type of entity that is represented by the  property. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The type of entity that is represented by the  property.
   ///</param>
   _setValidObjectType(value);
   this.setRequestXml(getRequestXml());
  }

  this.setObjectId = function (value) {
   ///<summary>
   /// Sets the ID of the record that the email is regarding. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the record that the email is regarding.
   ///</param>
   _setValidObjectId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.InstantiateTemplateRequest.__class = true;

 this.InstantiateTemplateResponse = function (responseXml) {
  ///<summary>
  /// Response to InstantiateTemplateRequest
  ///</summary>
  if (!(this instanceof Sdk.InstantiateTemplateResponse)) {
   return new Sdk.InstantiateTemplateResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _entityCollection = null;

  // Internal property setter functions

  function _setEntityCollection(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='EntityCollection']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _entityCollection = Sdk.Util.createEntityCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEntityCollection = function () {
   ///<summary>
   /// Gets the instantiated email records.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The instantiated email records.
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.InstantiateTemplateResponse.__class = true;
}).call(Sdk)

Sdk.InstantiateTemplateRequest.prototype = new Sdk.OrganizationRequest();
Sdk.InstantiateTemplateResponse.prototype = new Sdk.OrganizationResponse();
