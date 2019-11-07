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
 this.SendBulkMailRequest = function (sender, templateId, regardingType, regardingId, query) {
  ///<summary>
  /// Contains the data that is needed to send bulk email messages.
  ///</summary>
  ///<param name="sender"  type="Sdk.EntityReference">
  /// Sets the sender of the email messages.
  ///</param>
  ///<param name="templateId"  type="String">
  /// Sets the ID of the email template to use.
  ///</param>
  ///<param name="regardingType"  type="String">
  /// Sets the type of the record with which the email messages are associated.
  ///</param>
  ///<param name="regardingId"  type="String">
  /// Sets the ID of the record with which the email messages are associated.
  ///</param>
  ///<param name="query"  type="Sdk.QueryBase">
  /// Sets the query to retrieve the recipients for the email messages.
  ///</param>
  if (!(this instanceof Sdk.SendBulkMailRequest)) {
   return new Sdk.SendBulkMailRequest(sender, templateId, regardingType, regardingId, query);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _sender = null;
  var _templateId = null;
  var _regardingType = null;
  var _regardingId = null;
  var _query = null;

  // internal validation functions

  function _setValidSender(value) {
   if (value instanceof Sdk.EntityReference) {
    _sender = value;
   }
   else {
    throw new Error("Sdk.SendBulkMailRequest Sender property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidTemplateId(value) {
   if (Sdk.Util.isGuid(value)) {
    _templateId = value;
   }
   else {
    throw new Error("Sdk.SendBulkMailRequest TemplateId property is required and must be a String.")
   }
  }

  function _setValidRegardingType(value) {
   if (typeof value == "string") {
    _regardingType = value;
   }
   else {
    throw new Error("Sdk.SendBulkMailRequest RegardingType property is required and must be a String.")
   }
  }

  function _setValidRegardingId(value) {
   if (Sdk.Util.isGuid(value)) {
    _regardingId = value;
   }
   else {
    throw new Error("Sdk.SendBulkMailRequest RegardingId property is required and must be a String.")
   }
  }

  function _setValidQuery(value) {
   if (value instanceof Sdk.Query.QueryBase) {
    _query = value;
   }
   else {
    throw new Error("Sdk.SendBulkMailRequest Query property is required and must be a Sdk.QueryBase.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof sender != "undefined") {
   _setValidSender(sender);
  }
  if (typeof templateId != "undefined") {
   _setValidTemplateId(templateId);
  }
  if (typeof regardingType != "undefined") {
   _setValidRegardingType(regardingType);
  }
  if (typeof regardingId != "undefined") {
   _setValidRegardingId(regardingId);
  }
  if (typeof query != "undefined") {
   _setValidQuery(query);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Sender</b:key>",
              (_sender == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _sender.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

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
               "<b:key>Query</b:key>",
              (_query == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:" + _query.getQueryType() + "\">", _query.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>SendBulkMail</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SendBulkMailResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setSender = function (value) {
   ///<summary>
   /// Sets the sender of the email messages.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The sender of the email messages.
   ///</param>
   _setValidSender(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTemplateId = function (value) {
   ///<summary>
   /// Sets the ID of the email template to use.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the email template to use.
   ///</param>
   _setValidTemplateId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRegardingType = function (value) {
   ///<summary>
   /// Sets the type of the record with which the email messages are associated.
   ///</summary>
   ///<param name="value" type="String">
   /// The type of the record with which the email messages are associated.
   ///</param>
   _setValidRegardingType(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRegardingId = function (value) {
   ///<summary>
   /// Sets the ID of the record with which the email messages are associated.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the record with which the email messages are associated.
   ///</param>
   _setValidRegardingId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setQuery = function (value) {
   ///<summary>
   /// Sets the query to retrieve the recipients for the email messages.
   ///</summary>
   ///<param name="value" type="Sdk.QueryBase">
   /// The query to retrieve the recipients for the email messages.
   ///</param>
   _setValidQuery(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SendBulkMailRequest.__class = true;

 this.SendBulkMailResponse = function (responseXml) {
  ///<summary>
  /// Response to SendBulkMailRequest
  ///</summary>
  if (!(this instanceof Sdk.SendBulkMailResponse)) {
   return new Sdk.SendBulkMailResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values
 }
 this.SendBulkMailResponse.__class = true;
}).call(Sdk)

Sdk.SendBulkMailRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SendBulkMailResponse.prototype = new Sdk.OrganizationResponse();
