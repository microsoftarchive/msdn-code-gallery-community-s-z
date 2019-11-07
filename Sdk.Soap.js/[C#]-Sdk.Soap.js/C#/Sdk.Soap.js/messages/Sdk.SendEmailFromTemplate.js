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
 this.SendEmailFromTemplateRequest = function (templateId, regardingType, regardingId, target) {
  ///<summary>
  /// Contains the data that is needed to send an email message using a template.
  ///</summary>
  ///<param name="templateId"  type="String">
  /// Sets the ID of the email template to use for the email.
  ///</param>
  ///<param name="regardingType"  type="String">
  /// Sets the type of the record with which the email message is associated.
  ///</param>
  ///<param name="regardingId"  type="String">
  /// Sets the ID of the record with which the email message is associated.
  ///</param>
  ///<param name="target"  type="Sdk.Entity">
  /// Sets the email record to send.
  ///</param>
  if (!(this instanceof Sdk.SendEmailFromTemplateRequest)) {
   return new Sdk.SendEmailFromTemplateRequest(templateId, regardingType, regardingId, target);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _templateId = null;
  var _regardingType = null;
  var _regardingId = null;
  var _target = null;

  // internal validation functions

  function _setValidTemplateId(value) {
   if (Sdk.Util.isGuid(value)) {
    _templateId = value;
   }
   else {
    throw new Error("Sdk.SendEmailFromTemplateRequest TemplateId property is required and must be a String.")
   }
  }

  function _setValidRegardingType(value) {
   if (typeof value == "string") {
    _regardingType = value;
   }
   else {
    throw new Error("Sdk.SendEmailFromTemplateRequest RegardingType property is required and must be a String.")
   }
  }

  function _setValidRegardingId(value) {
   if (Sdk.Util.isGuid(value)) {
    _regardingId = value;
   }
   else {
    throw new Error("Sdk.SendEmailFromTemplateRequest RegardingId property is required and must be a String.")
   }
  }

  function _setValidTarget(value) {
   if (value instanceof Sdk.Entity) {
    _target = value;
   }
   else {
    throw new Error("Sdk.SendEmailFromTemplateRequest Target property is required and must be a Sdk.Entity.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof templateId != "undefined") {
   _setValidTemplateId(templateId);
  }
  if (typeof regardingType != "undefined") {
   _setValidRegardingType(regardingType);
  }
  if (typeof regardingId != "undefined") {
   _setValidRegardingId(regardingId);
  }
  if (typeof target != "undefined") {
   _setValidTarget(target);
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
               "<b:key>RegardingType</b:key>",
              (_regardingType == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _regardingType, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>RegardingId</b:key>",
              (_regardingId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _regardingId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Target</b:key>",
              (_target == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:Entity\">", _target.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>SendEmailFromTemplate</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SendEmailFromTemplateResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTemplateId = function (value) {
   ///<summary>
   /// Sets the ID of the email template to use for the email.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the email template to use for the email.
   ///</param>
   _setValidTemplateId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRegardingType = function (value) {
   ///<summary>
   /// Sets the type of the record with which the email message is associated.
   ///</summary>
   ///<param name="value" type="String">
   /// The type of the record with which the email message is associated.
   ///</param>
   _setValidRegardingType(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRegardingId = function (value) {
   ///<summary>
   /// Sets the ID of the record with which the email message is associated.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the record with which the email message is associated.
   ///</param>
   _setValidRegardingId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTarget = function (value) {
   ///<summary>
   /// Sets the email record to send.
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The email record to send.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SendEmailFromTemplateRequest.__class = true;

 this.SendEmailFromTemplateResponse = function (responseXml) {
  ///<summary>
  /// Response to SendEmailFromTemplateRequest
  ///</summary>
  if (!(this instanceof Sdk.SendEmailFromTemplateResponse)) {
   return new Sdk.SendEmailFromTemplateResponse(responseXml);
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
   /// Gets the ID of the email record that was sent.
   ///</summary>
   ///<returns type="String">
   /// The ID of the email record that was sent.
   ///</returns>
   return _id;
  }

  //Set property values from responseXml constructor parameter
  _setId(responseXml);
 }
 this.SendEmailFromTemplateResponse.__class = true;
}).call(Sdk)

Sdk.SendEmailFromTemplateRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SendEmailFromTemplateResponse.prototype = new Sdk.OrganizationResponse();
