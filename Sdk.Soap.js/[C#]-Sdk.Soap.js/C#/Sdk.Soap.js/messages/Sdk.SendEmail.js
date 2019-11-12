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
 this.SendEmailRequest = function (emailId, issueSend, trackingToken) {
  ///<summary>
  /// Contains the data that is needed to send an email message.
  ///</summary>
  ///<param name="emailId"  type="String">
  /// Sets the ID of the email to send.
  ///</param>
  ///<param name="issueSend"  type="Boolean">
  /// Sets whether to send the email, or to just record it as sent.
  ///</param>
  ///<param name="trackingToken" optional="true" type="String">
  /// Sets the tracking token.
  ///</param>
  if (!(this instanceof Sdk.SendEmailRequest)) {
   return new Sdk.SendEmailRequest(emailId, issueSend, trackingToken);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _emailId = null;
  var _issueSend = null;
  var _trackingToken = null;

  // internal validation functions

  function _setValidEmailId(value) {
   if (Sdk.Util.isGuid(value)) {
    _emailId = value;
   }
   else {
    throw new Error("Sdk.SendEmailRequest EmailId property is required and must be a String.")
   }
  }

  function _setValidIssueSend(value) {
   if (typeof value == "boolean") {
    _issueSend = value;
   }
   else {
    throw new Error("Sdk.SendEmailRequest IssueSend property is required and must be a Boolean.")
   }
  }

  function _setValidTrackingToken(value) {
   if (value == null || typeof value == "string") {
    _trackingToken = value;
   }
   else {
    throw new Error("Sdk.SendEmailRequest TrackingToken property must be a String or null.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof emailId != "undefined") {
   _setValidEmailId(emailId);
  }
  if (typeof issueSend != "undefined") {
   _setValidIssueSend(issueSend);
  }
  if (typeof trackingToken != "undefined") {
   _setValidTrackingToken(trackingToken);
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
               "<b:key>IssueSend</b:key>",
              (_issueSend == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _issueSend, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>TrackingToken</b:key>",
              (_trackingToken == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _trackingToken, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>SendEmail</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SendEmailResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEmailId = function (value) {
   ///<summary>
   /// Sets the ID of the email to send.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the email to send.
   ///</param>
   _setValidEmailId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setIssueSend = function (value) {
   ///<summary>
   /// Sets whether to send the email, or to just record it as sent.
   ///</summary>
   ///<param name="value" type="Boolean">
   /// Whether to send the email, or to just record it as sent.
   ///</param>
   _setValidIssueSend(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTrackingToken = function (value) {
   ///<summary>
   /// Sets the tracking token.
   ///</summary>
   ///<param name="value" type="String">
   /// The tracking token.
   ///</param>
   _setValidTrackingToken(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SendEmailRequest.__class = true;

 this.SendEmailResponse = function (responseXml) {
  ///<summary>
  /// Response to SendEmailRequest
  ///</summary>
  if (!(this instanceof Sdk.SendEmailResponse)) {
   return new Sdk.SendEmailResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _subject = null;

  // Internal property setter functions

  function _setSubject(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Subject']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _subject = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getSubject = function () {
   ///<summary>
   /// Gets the subject line for the email message.
   ///</summary>
   ///<returns type="String">
   /// The subject line for the email message.
   ///</returns>
   return _subject;
  }

  //Set property values from responseXml constructor parameter
  _setSubject(responseXml);
 }
 this.SendEmailResponse.__class = true;
}).call(Sdk)

Sdk.SendEmailRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SendEmailResponse.prototype = new Sdk.OrganizationResponse();
