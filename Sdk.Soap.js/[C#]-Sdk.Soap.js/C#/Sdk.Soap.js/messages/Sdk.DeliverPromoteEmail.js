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
 this.DeliverPromoteEmailRequest = function (emailId, messageId, subject, from, to, cc, bcc, receivedOn, submittedBy, importance, body, attachments, extraProperties) {
  ///<summary>
  /// Contains the data that is needed to create an email activity record from the specified email message (Track in CRM). 
  ///</summary>
  ///<param name="emailId"  type="String">
  ///  Sets the ID of the email from which to create the email. Required. 
  ///</param>
  ///<param name="messageId"  type="String">
  /// Sets the ID of the email message stored in the email header. Required. 
  ///</param>
  ///<param name="subject" optional="true" type="String">
  /// Sets the subject line for the email message. Optional. 
  ///</param>
  ///<param name="from"  type="String">
  ///  Sets the from address for the email message. Required. 
  ///</param>
  ///<param name="to"  type="String">
  /// Sets the addresses of the recipients of the email message. Required. 
  ///</param>
  ///<param name="cc"  type="String">
  /// Sets the addresses of the carbon copy (Cc) recipients for the email message. Required. 
  ///</param>
  ///<param name="bcc"  type="String">
  /// Sets the addresses of the blind carbon copy (Bcc) recipients for the email message. Required. 
  ///</param>
  ///<param name="receivedOn"  type="Date">
  /// Sets the time the message was received on. Required. 
  ///</param>
  ///<param name="submittedBy"  type="String">
  /// Sets the email address of the account that is creating the email activity instance. Required. 
  ///</param>
  ///<param name="importance"  type="String">
  /// Sets the level of importance for the email message. Required. 
  ///</param>
  ///<param name="body"  type="String">
  /// Sets the message body for the email. Required. 
  ///</param>
  ///<param name="attachments"  type="Sdk.EntityCollection">
  /// Sets a collection of activity mime attachment (email attachment) records to attach to the email message. Required. 
  ///</param>
  ///<param name="extraProperties" optional="true" type="Sdk.Entity">
  /// Sets the extra properties for the email. Optional. 
  ///</param>
  if (!(this instanceof Sdk.DeliverPromoteEmailRequest)) {
   return new Sdk.DeliverPromoteEmailRequest(emailId, messageId, subject, from, to, cc, bcc, receivedOn, submittedBy, importance, body, attachments, extraProperties);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _emailId = null;
  var _messageId = null;
  var _subject = null;
  var _from = null;
  var _to = null;
  var _cc = null;
  var _bcc = null;
  var _receivedOn = null;
  var _submittedBy = null;
  var _importance = null;
  var _body = null;
  var _attachments = null;
  var _extraProperties = null;

  // internal validation functions

  function _setValidEmailId(value) {
   if (Sdk.Util.isGuid(value)) {
    _emailId = value;
   }
   else {
    throw new Error("Sdk.DeliverPromoteEmailRequest EmailId property is required and must be a String.")
   }
  }

  function _setValidMessageId(value) {
   if (typeof value == "string") {
    _messageId = value;
   }
   else {
    throw new Error("Sdk.DeliverPromoteEmailRequest MessageId property is required and must be a String.")
   }
  }

  function _setValidSubject(value) {
   if (value == null || typeof value == "string") {
    _subject = value;
   }
   else {
    throw new Error("Sdk.DeliverPromoteEmailRequest Subject property must be a String or null.")
   }
  }

  function _setValidFrom(value) {
   if (typeof value == "string") {
    _from = value;
   }
   else {
    throw new Error("Sdk.DeliverPromoteEmailRequest From property is required and must be a String.")
   }
  }

  function _setValidTo(value) {
   if (typeof value == "string") {
    _to = value;
   }
   else {
    throw new Error("Sdk.DeliverPromoteEmailRequest To property is required and must be a String.")
   }
  }

  function _setValidCc(value) {
   if (typeof value == "string") {
    _cc = value;
   }
   else {
    throw new Error("Sdk.DeliverPromoteEmailRequest Cc property is required and must be a String.")
   }
  }

  function _setValidBcc(value) {
   if (typeof value == "string") {
    _bcc = value;
   }
   else {
    throw new Error("Sdk.DeliverPromoteEmailRequest Bcc property is required and must be a String.")
   }
  }

  function _setValidReceivedOn(value) {
   if (value instanceof Date) {
    _receivedOn = value;
   }
   else {
    throw new Error("Sdk.DeliverPromoteEmailRequest ReceivedOn property is required and must be a Date.")
   }
  }

  function _setValidSubmittedBy(value) {
   if (typeof value == "string") {
    _submittedBy = value;
   }
   else {
    throw new Error("Sdk.DeliverPromoteEmailRequest SubmittedBy property is required and must be a String.")
   }
  }

  function _setValidImportance(value) {
   if (typeof value == "string") {
    _importance = value;
   }
   else {
    throw new Error("Sdk.DeliverPromoteEmailRequest Importance property is required and must be a String.")
   }
  }

  function _setValidBody(value) {
   if (typeof value == "string") {
    _body = value;
   }
   else {
    throw new Error("Sdk.DeliverPromoteEmailRequest Body property is required and must be a String.")
   }
  }

  function _setValidAttachments(value) {
   if (value instanceof Sdk.EntityCollection) {
    _attachments = value;
   }
   else {
    throw new Error("Sdk.DeliverPromoteEmailRequest Attachments property is required and must be a Sdk.EntityCollection.")
   }
  }

  function _setValidExtraProperties(value) {
   if (value == null || value instanceof Sdk.Entity) {
    _extraProperties = value;
   }
   else {
    throw new Error("Sdk.DeliverPromoteEmailRequest ExtraProperties property must be a Sdk.Entity or null.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof emailId != "undefined") {
   _setValidEmailId(emailId);
  }
  if (typeof messageId != "undefined") {
   _setValidMessageId(messageId);
  }
  if (typeof subject != "undefined") {
   _setValidSubject(subject);
  }
  if (typeof from != "undefined") {
   _setValidFrom(from);
  }
  if (typeof to != "undefined") {
   _setValidTo(to);
  }
  if (typeof cc != "undefined") {
   _setValidCc(cc);
  }
  if (typeof bcc != "undefined") {
   _setValidBcc(bcc);
  }
  if (typeof receivedOn != "undefined") {
   _setValidReceivedOn(receivedOn);
  }
  if (typeof submittedBy != "undefined") {
   _setValidSubmittedBy(submittedBy);
  }
  if (typeof importance != "undefined") {
   _setValidImportance(importance);
  }
  if (typeof body != "undefined") {
   _setValidBody(body);
  }
  if (typeof attachments != "undefined") {
   _setValidAttachments(attachments);
  }
  if (typeof extraProperties != "undefined") {
   _setValidExtraProperties(extraProperties);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EmailId</b:key>",
              (_emailId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _emailId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>MessageId</b:key>",
              (_messageId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _messageId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Subject</b:key>",
              (_subject == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _subject, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>From</b:key>",
              (_from == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _from, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>To</b:key>",
              (_to == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _to, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Cc</b:key>",
              (_cc == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _cc, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Bcc</b:key>",
              (_bcc == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _bcc, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ReceivedOn</b:key>",
              (_receivedOn == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:dateTime\">", _receivedOn.toISOString(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SubmittedBy</b:key>",
              (_submittedBy == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _submittedBy, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Importance</b:key>",
              (_importance == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _importance, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Body</b:key>",
              (_body == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _body, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Attachments</b:key>",
              (_attachments == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityCollection\">", _attachments.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ExtraProperties</b:key>",
              (_extraProperties == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:Entity\">", _extraProperties.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>DeliverPromoteEmail</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.DeliverPromoteEmailResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEmailId = function (value) {
   ///<summary>
   /// Sets the ID of the email from which to create the email. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the email from which to create the email. 
   ///</param>
   _setValidEmailId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setMessageId = function (value) {
   ///<summary>
   /// Sets the ID of the email message stored in the email header. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the email message stored in the email header. 
   ///</param>
   _setValidMessageId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSubject = function (value) {
   ///<summary>
   /// Sets the subject line for the email message. Optional. 
   ///</summary>
   ///<param name="value" type="String">
   /// The subject line for the email message. 
   ///</param>
   _setValidSubject(value);
   this.setRequestXml(getRequestXml());
  }

  this.setFrom = function (value) {
   ///<summary>
   /// Sets the from address for the email message. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The from address for the email message. 
   ///</param>
   _setValidFrom(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTo = function (value) {
   ///<summary>
   /// Sets the addresses of the recipients of the email message. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The addresses of the recipients of the email message.
   ///</param>
   _setValidTo(value);
   this.setRequestXml(getRequestXml());
  }

  this.setCc = function (value) {
   ///<summary>
   /// Sets the addresses of the carbon copy (Cc) recipients for the email message. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The addresses of the carbon copy (Cc) recipients for the email message. 
   ///</param>
   _setValidCc(value);
   this.setRequestXml(getRequestXml());
  }

  this.setBcc = function (value) {
   ///<summary>
   /// Sets the addresses of the blind carbon copy (Bcc) recipients for the email message. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The addresses of the blind carbon copy (Bcc) recipients for the email message. 
   ///</param>
   _setValidBcc(value);
   this.setRequestXml(getRequestXml());
  }

  this.setReceivedOn = function (value) {
   ///<summary>
   /// Sets the time the message was received on. Required. 
   ///</summary>
   ///<param name="value" type="Date">
   /// The time the message was received on. 
   ///</param>
   _setValidReceivedOn(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSubmittedBy = function (value) {
   ///<summary>
   /// Sets the email address of the account that is creating the email activity instance. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The email address of the account that is creating the email activity instance. 
   ///</param>
   _setValidSubmittedBy(value);
   this.setRequestXml(getRequestXml());
  }

  this.setImportance = function (value) {
   ///<summary>
   /// Sets the level of importance for the email message. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The level of importance for the email message. 
   ///</param>
   _setValidImportance(value);
   this.setRequestXml(getRequestXml());
  }

  this.setBody = function (value) {
   ///<summary>
   /// Sets the message body for the email. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The message body for the email. 
   ///</param>
   _setValidBody(value);
   this.setRequestXml(getRequestXml());
  }

  this.setAttachments = function (value) {
   ///<summary>
   /// Sets a collection of activity mime attachment (email attachment) records to attach to the email message. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityCollection">
   /// A collection of activity mime attachment (email attachment) records to attach to the email message.
   ///</param>
   _setValidAttachments(value);
   this.setRequestXml(getRequestXml());
  }

  this.setExtraProperties = function (value) {
   ///<summary>
   /// Sets the extra properties for the email. Optional. 
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The extra properties for the email. 
   ///</param>
   _setValidExtraProperties(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.DeliverPromoteEmailRequest.__class = true;

 this.DeliverPromoteEmailResponse = function (responseXml) {
  ///<summary>
  /// Response to DeliverPromoteEmailRequest
  ///</summary>
  if (!(this instanceof Sdk.DeliverPromoteEmailResponse)) {
   return new Sdk.DeliverPromoteEmailResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _emailId = null;

  // Internal property setter functions

  function _setEmailId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='EmailId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _emailId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEmailId = function () {
   ///<summary>
   /// Gets the ID of the newly created email activity. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the newly created email activity. 
   ///</returns>
   return _emailId;
  }

  //Set property values from responseXml constructor parameter
  _setEmailId(responseXml);
 }
 this.DeliverPromoteEmailResponse.__class = true;
}).call(Sdk)

Sdk.DeliverPromoteEmailRequest.prototype = new Sdk.OrganizationRequest();
Sdk.DeliverPromoteEmailResponse.prototype = new Sdk.OrganizationResponse();
