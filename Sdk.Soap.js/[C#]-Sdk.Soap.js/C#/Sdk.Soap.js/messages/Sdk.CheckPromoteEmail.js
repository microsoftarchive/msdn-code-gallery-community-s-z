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
 this.CheckPromoteEmailRequest = function (messageId, subject, directionCode) {
  ///<summary>
  /// Contains the data that is needed to check whether the incoming email message should be promoted to the Microsoft Dynamics CRM system. 
  ///</summary>
  ///<param name="messageId"  type="String">
  /// Sets the message ID that is contained in the email header. Required. 
  ///</param>
  ///<param name="subject" optional="true" type="String">
  /// Sets the subject of the message. Optional. 
  ///</param>
  ///<param name="directionCode" optional="true" type="Number">
  /// Provides the direction of a mail checked for promotion for uniqueness. 
  ///</param>
  if (!(this instanceof Sdk.CheckPromoteEmailRequest)) {
   return new Sdk.CheckPromoteEmailRequest(messageId, subject, directionCode);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _messageId = null;
  var _subject = null;
  var _directionCode = null;

  // internal validation functions

  function _setValidMessageId(value) {
   if (typeof value == "string") {
    _messageId = value;
   }
   else {
    throw new Error("Sdk.CheckPromoteEmailRequest MessageId property is required and must be a String.")
   }
  }

  function _setValidSubject(value) {
   if (value == null || typeof value == "string") {
    _subject = value;
   }
   else {
    throw new Error("Sdk.CheckPromoteEmailRequest Subject property must be a String or null.")
   }
  }

  function _setValidDirectionCode(value) {
   if (value == null || typeof value == "number") {
    _directionCode = value;
   }
   else {
    throw new Error("Sdk.CheckPromoteEmailRequest DirectionCode property must be a Number or null.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof messageId != "undefined") {
   _setValidMessageId(messageId);
  }
  if (typeof subject != "undefined") {
   _setValidSubject(subject);
  }
  if (typeof directionCode != "undefined") {
   _setValidDirectionCode(directionCode);
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
               "<b:key>DirectionCode</b:key>",
              (_directionCode == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _directionCode, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CheckPromoteEmail</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CheckPromoteEmailResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setMessageId = function (value) {
   ///<summary>
   /// Sets the message ID that is contained in the email header. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The message ID that is contained in the email header. 
   ///</param>
   _setValidMessageId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSubject = function (value) {
   ///<summary>
   /// Sets the subject of the message. Optional. 
   ///</summary>
   ///<param name="value" type="String">
   /// The subject of the message.
   ///</param>
   _setValidSubject(value);
   this.setRequestXml(getRequestXml());
  }

  this.setDirectionCode = function (value) {
   ///<summary>
   /// Provides the direction of a mail checked for promotion for uniqueness. 
   ///</summary>
   ///<param name="value" type="Number">
   /// Provides the direction of a mail checked for promotion for uniqueness. 
   ///</param>
   _setValidDirectionCode(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CheckPromoteEmailRequest.__class = true;

 this.CheckPromoteEmailResponse = function (responseXml) {
  ///<summary>
  /// Response to CheckPromoteEmailRequest
  ///</summary>
  if (!(this instanceof Sdk.CheckPromoteEmailResponse)) {
   return new Sdk.CheckPromoteEmailResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _shouldPromote = null;
  var _reasonCode = null;

  // Internal property setter functions

  function _setShouldPromote(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='ShouldPromote']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _shouldPromote = (Sdk.Xml.getNodeText(valueNode) == "true") ? true : false;
   }
  }
  function _setReasonCode(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='ReasonCode']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _reasonCode = parseInt(Sdk.Xml.getNodeText(valueNode), 10);
   }
  }
  //Public Methods to retrieve properties
  this.getShouldPromote = function () {
   ///<summary>
   /// Gets a value that indicates whether the message should be promoted to Microsoft Dynamics CRM. 
   ///</summary>
   ///<returns type="Boolean">
   /// A value that indicates whether the message should be promoted to Microsoft Dynamics CRM. 
   ///</returns>
   return _shouldPromote;
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
  _setShouldPromote(responseXml);
  _setReasonCode(responseXml);
 }
 this.CheckPromoteEmailResponse.__class = true;
}).call(Sdk)

Sdk.CheckPromoteEmailRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CheckPromoteEmailResponse.prototype = new Sdk.OrganizationResponse();
