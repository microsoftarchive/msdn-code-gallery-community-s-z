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
 this.GetTrackingTokenEmailRequest = function (subject) {
  ///<summary>
  /// Contains the data that is needed to  return a tracking token that can then be passed as a parameter to the  message.
  ///</summary>
  ///<param name="subject" optional="true" type="String">
  /// Sets the context of the email. Required.
  ///</param>
  if (!(this instanceof Sdk.GetTrackingTokenEmailRequest)) {
   return new Sdk.GetTrackingTokenEmailRequest(subject);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _subject = null;

  // internal validation functions

  function _setValidSubject(value) {
   if (value == null || typeof value == "string") {
    _subject = value;
   }
   else {
    throw new Error("Sdk.GetTrackingTokenEmailRequest Subject property must be a String or null.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof subject != "undefined") {
   _setValidSubject(subject);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Subject</b:key>",
              (_subject == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _subject, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>GetTrackingTokenEmail</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.GetTrackingTokenEmailResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setSubject = function (value) {
   ///<summary>
   /// Sets the context of the email. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The context of the email.
   ///</param>
   _setValidSubject(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.GetTrackingTokenEmailRequest.__class = true;

 this.GetTrackingTokenEmailResponse = function (responseXml) {
  ///<summary>
  /// Response to GetTrackingTokenEmailRequest
  ///</summary>
  if (!(this instanceof Sdk.GetTrackingTokenEmailResponse)) {
   return new Sdk.GetTrackingTokenEmailResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _trackingToken = null;

  // Internal property setter functions

  function _setTrackingToken(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='TrackingToken']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _trackingToken = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getTrackingToken = function () {
   ///<summary>
   /// Gets the requested tracking token.
   ///</summary>
   ///<returns type="String">
   /// The requested tracking token.
   ///</returns>
   return _trackingToken;
  }

  //Set property values from responseXml constructor parameter
  _setTrackingToken(responseXml);
 }
 this.GetTrackingTokenEmailResponse.__class = true;
}).call(Sdk)

Sdk.GetTrackingTokenEmailRequest.prototype = new Sdk.OrganizationRequest();
Sdk.GetTrackingTokenEmailResponse.prototype = new Sdk.OrganizationResponse();
