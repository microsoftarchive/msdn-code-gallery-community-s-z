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
this.SendTemplateRequest = function (templateId,sender,recipientType,recipientIds,regardingType,regardingId,deliveryPriorityCode){
///<summary>
/// Contains the data that is needed to send a bulk email message that is created from a template.
///</summary>
///<param name="templateId"  type="String">
/// Sets the ID of the template to be used for the email. Required.
///</param>
///<param name="sender"  type="Sdk.EntityReference">
/// Sets the sender of the email.
///</param>
///<param name="recipientType"  type="String">
/// Sets the type of entity that is represented by the list of recipients. Required.
///</param>
///<param name="recipientIds"  type="Sdk.Collection">
/// Sets the array that contains the list of recipients for the email. Required.
///</param>
///<param name="regardingType"  type="String">
/// Sets the type of entity that is represented by the regarding ID. Required.
///</param>
///<param name="regardingId"  type="String">
/// Sets the ID of a record that the email is regarding. Required.
///</param>
///<param name="deliveryPriorityCode" optional="true" type="Number">
/// [Add Description]
///</param>
if (!(this instanceof Sdk.SendTemplateRequest)) {
return new Sdk.SendTemplateRequest(templateId, sender, recipientType, recipientIds, regardingType, regardingId, deliveryPriorityCode);
}
Sdk.OrganizationRequest.call(this);

  // Internal properties
var _templateId = null;
var _sender = null;
var _recipientType = null;
var _recipientIds = null;
var _regardingType = null;
var _regardingId = null;
var _deliveryPriorityCode = null;

// internal validation functions

function _setValidTemplateId(value) {
 if (Sdk.Util.isGuid(value)) {
  _templateId = value;
 }
 else {
  throw new Error("Sdk.SendTemplateRequest TemplateId property is required and must be a String.")
 }
}

function _setValidSender(value) {
 if (value instanceof Sdk.EntityReference) {
  _sender = value;
 }
 else {
  throw new Error("Sdk.SendTemplateRequest Sender property is required and must be a Sdk.EntityReference.")
 }
}

function _setValidRecipientType(value) {
 if (typeof value == "string") {
  _recipientType = value;
 }
 else {
  throw new Error("Sdk.SendTemplateRequest RecipientType property is required and must be a String.")
 }
}

function _setValidRecipientIds(value) {
 if (Sdk.Util.isCollectionOf(value,String)) {
  _recipientIds = value;
 }
 else {
  throw new Error("Sdk.SendTemplateRequest RecipientIds property is required and must be a Sdk.Collection.")
 }
}

function _setValidRegardingType(value) {
 if (typeof value == "string") {
  _regardingType = value;
 }
 else {
  throw new Error("Sdk.SendTemplateRequest RegardingType property is required and must be a String.")
 }
}

function _setValidRegardingId(value) {
 if (Sdk.Util.isGuid(value)) {
  _regardingId = value;
 }
 else {
  throw new Error("Sdk.SendTemplateRequest RegardingId property is required and must be a String.")
 }
}

function _setValidDeliveryPriorityCode(value) {
 if (value == null || typeof value == "number") {
  _deliveryPriorityCode = value;
 }
 else {
  throw new Error("Sdk.SendTemplateRequest DeliveryPriorityCode property must be a Number or null.")
 }
}

//Set internal properties from constructor parameters
  if (typeof templateId != "undefined") {
   _setValidTemplateId(templateId);
  }
  if (typeof sender != "undefined") {
   _setValidSender(sender);
  }
  if (typeof recipientType != "undefined") {
   _setValidRecipientType(recipientType);
  }
  if (typeof recipientIds != "undefined") {
   _setValidRecipientIds(recipientIds);
  }
  if (typeof regardingType != "undefined") {
   _setValidRegardingType(regardingType);
  }
  if (typeof regardingId != "undefined") {
   _setValidRegardingId(regardingId);
  }
  if (typeof deliveryPriorityCode != "undefined") {
   _setValidDeliveryPriorityCode(deliveryPriorityCode);
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
            "<b:key>Sender</b:key>",
           (_sender == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"a:EntityReference\">", _sender.toValueXml(), "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>RecipientType</b:key>",
           (_recipientType == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"c:string\">", _recipientType, "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>RecipientIds</b:key>",
           (_recipientIds == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"f:ArrayOfguid\">", _recipientIds.toArrayOfValueXml("f:guid"), "</b:value>"].join(""),
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
            "<b:key>DeliveryPriorityCode</b:key>",
           (_deliveryPriorityCode == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"a:OptionSetValue\">",
            "<a:Value>",_deliveryPriorityCode,"</a:Value>",
           "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

        "</a:Parameters>",
        "<a:RequestId i:nil=\"true\" />",
        "<a:RequestName>SendTemplate</a:RequestName>",
      "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SendTemplateResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTemplateId = function (value) {
  ///<summary>
  /// Sets the ID of the template to be used for the email. Required.
  ///</summary>
  ///<param name="value" type="String">
  /// The ID of the template to be used for the email.
  ///</param>
   _setValidTemplateId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSender = function (value) {
  ///<summary>
  /// Sets the sender of the email.
  ///</summary>
  ///<param name="value" type="Sdk.EntityReference">
  /// The sender of the email.
  ///</param>
   _setValidSender(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRecipientType = function (value) {
  ///<summary>
  /// Sets the type of entity that is represented by the list of recipients. Required.
  ///</summary>
  ///<param name="value" type="String">
  /// The type of entity that is represented by the list of recipients.
  ///</param>
   _setValidRecipientType(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRecipientIds = function (value) {
  ///<summary>
  /// Sets the array that contains the list of recipients for the email.
  ///</summary>
  ///<param name="value" type="Sdk.Collection">
  /// The array that contains the list of recipients for the email.
  ///</param>
   _setValidRecipientIds(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRegardingType = function (value) {
  ///<summary>
  /// Sets the type of entity that is represented by the regarding ID.
  ///</summary>
  ///<param name="value" type="String">
  /// The type of entity that is represented by the regarding ID.
  ///</param>
   _setValidRegardingType(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRegardingId = function (value) {
  ///<summary>
  /// Sets the ID of a record that the email is regarding.
  ///</summary>
  ///<param name="value" type="String">
  /// The ID of a record that the email is regarding.
  ///</param>
   _setValidRegardingId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setDeliveryPriorityCode = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="Number">
  /// [Add Description]
  ///</param>
   _setValidDeliveryPriorityCode(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SendTemplateRequest.__class = true;

this.SendTemplateResponse = function (responseXml) {
  ///<summary>
  /// Response to SendTemplateRequest
  ///</summary>
  if (!(this instanceof Sdk.SendTemplateResponse)) {
   return new Sdk.SendTemplateResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values






 }
 this.SendTemplateResponse.__class = true;
}).call(Sdk)

Sdk.SendTemplateRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SendTemplateResponse.prototype = new Sdk.OrganizationResponse();
