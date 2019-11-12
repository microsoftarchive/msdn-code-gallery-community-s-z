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
 this.CheckIncomingEmailRequest = function (messageId, subject, from, to, cc, bcc, extraProperties) {
  ///<summary>
  /// Contains the data that is needed to check whether the incoming email message is relevant to the Microsoft Dynamics CRM system. 
  ///</summary>
  ///<param name="messageId"  type="String">
  /// Sets the ID of the email message stored in the email header. Required. 
  ///</param>
  ///<param name="subject" optional="true" type="String">
  /// Sets the subject line for the email message. Optional. 
  ///</param>
  ///<param name="from"  type="String">
  /// Sets the from address for the email message. 
  ///</param>
  ///<param name="to"  type="String">
  /// Sets the addresses of the recipients of the email message. 
  ///</param>
  ///<param name="cc"  type="String">
  /// Sets the addresses of the carbon copy (Cc) recipients for the email message. 
  ///</param>
  ///<param name="bcc"  type="String">
  /// Sets the addresses of the blind carbon copy (Bcc) recipients for the email message. 
  ///</param>
  ///<param name="extraProperties" optional="true" type="Sdk.Entity">
  /// [Add Description]
  ///</param>
  if (!(this instanceof Sdk.CheckIncomingEmailRequest)) {
   return new Sdk.CheckIncomingEmailRequest(messageId, subject, from, to, cc, bcc, extraProperties);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _messageId = null;
  var _subject = null;
  var _from = null;
  var _to = null;
  var _cc = null;
  var _bcc = null;
  var _extraProperties = null;

  // internal validation functions

  function _setValidMessageId(value) {
   if (typeof value == "string") {
    _messageId = value;
   }
   else {
    throw new Error("Sdk.CheckIncomingEmailRequest MessageId property is required and must be a String.")
   }
  }

  function _setValidSubject(value) {
   if (value == null || typeof value == "string") {
    _subject = value;
   }
   else {
    throw new Error("Sdk.CheckIncomingEmailRequest Subject property must be a String or null.")
   }
  }

  function _setValidFrom(value) {
   if (typeof value == "string") {
    _from = value;
   }
   else {
    throw new Error("Sdk.CheckIncomingEmailRequest From property is required and must be a String.")
   }
  }

  function _setValidTo(value) {
   if (typeof value == "string") {
    _to = value;
   }
   else {
    throw new Error("Sdk.CheckIncomingEmailRequest To property is required and must be a String.")
   }
  }

  function _setValidCc(value) {
   if (typeof value == "string") {
    _cc = value;
   }
   else {
    throw new Error("Sdk.CheckIncomingEmailRequest Cc property is required and must be a String.")
   }
  }

  function _setValidBcc(value) {
   if (typeof value == "string") {
    _bcc = value;
   }
   else {
    throw new Error("Sdk.CheckIncomingEmailRequest Bcc property is required and must be a String.")
   }
  }

  function _setValidExtraProperties(value) {
   if (value == null || value instanceof Sdk.Entity) {
    _extraProperties = value;
   }
   else {
    throw new Error("Sdk.CheckIncomingEmailRequest ExtraProperties property must be a Sdk.Entity or null.")
   }
  }

  //Set internal properties from constructor parameters
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
  if (typeof extraProperties != "undefined") {
   _setValidExtraProperties(extraProperties);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

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
               "<b:key>ExtraProperties</b:key>",
              (_extraProperties == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:Entity\">", _extraProperties.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CheckIncomingEmail</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CheckIncomingEmailResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setMessageId = function (value) {
   ///<summary>
   /// Sets the ID of the email message stored in the email header. Required. 
   ///</summary>
   ///<param name="value" type="String">
   ///  The ID of the email message stored in the email header. 
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
   /// Sets the from address for the email message. 
   ///</summary>
   ///<param name="value" type="String">
   /// The from address for the email message. 
   ///</param>
   _setValidFrom(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTo = function (value) {
   ///<summary>
   /// Sets the addresses of the recipients of the email message. 
   ///</summary>
   ///<param name="value" type="String">
   /// The addresses of the recipients of the email message. 
   ///</param>
   _setValidTo(value);
   this.setRequestXml(getRequestXml());
  }

  this.setCc = function (value) {
   ///<summary>
   /// Sets the addresses of the carbon copy (Cc) recipients for the email message. 
   ///</summary>
   ///<param name="value" type="String">
   /// The addresses of the carbon copy (Cc) recipients for the email message. 
   ///</param>
   _setValidCc(value);
   this.setRequestXml(getRequestXml());
  }

  this.setBcc = function (value) {
   ///<summary>
   /// Sets the addresses of the blind carbon copy (Bcc) recipients for the email message. 
   ///</summary>
   ///<param name="value" type="String">
   /// The addresses of the blind carbon copy (Bcc) recipients for the email message. 
   ///</param>
   _setValidBcc(value);
   this.setRequestXml(getRequestXml());
  }

  this.setExtraProperties = function (value) {
   ///<summary>
   /// [Add Description]
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// [Add Description]
   ///</param>
   _setValidExtraProperties(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CheckIncomingEmailRequest.__class = true;

 this.CheckIncomingEmailResponse = function (responseXml) {
  ///<summary>
  /// Response to CheckIncomingEmailRequest
  ///</summary>
  if (!(this instanceof Sdk.CheckIncomingEmailResponse)) {
   return new Sdk.CheckIncomingEmailResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _shouldDeliver = null;
  var _reasonCode = null;

  // Internal property setter functions

  function _setShouldDeliver(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='ShouldDeliver']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _shouldDeliver = (Sdk.Xml.getNodeText(valueNode) == "true") ? true : false;
   }
  }
  function _setReasonCode(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='ReasonCode']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _reasonCode = parseInt(Sdk.Xml.getNodeText(valueNode), 10);
   }
  }
  //Public Methods to retrieve properties
  this.getShouldDeliver = function () {
   ///<summary>
   /// Gets a value that indicates whether the message should be delivered to Microsoft Dynamics CRM. 
   ///</summary>
   ///<returns type="Boolean">
   /// A value that indicates whether the message should be delivered to Microsoft Dynamics CRM. 
   ///</returns>
   return _shouldDeliver;
  }
  this.getReasonCode = function () {
   ///<summary>
   /// Gets the reason for the result in the ShouldDeliver property. 
   ///</summary>
   ///<returns type="Number">
   /// The reason for the result in the ShouldDeliver property. 
   ///</returns>
   return _reasonCode;
  }

  //Set property values from responseXml constructor parameter
  _setShouldDeliver(responseXml);
  _setReasonCode(responseXml);
 }
 this.CheckIncomingEmailResponse.__class = true;
}).call(Sdk)

Sdk.CheckIncomingEmailRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CheckIncomingEmailResponse.prototype = new Sdk.OrganizationResponse();
