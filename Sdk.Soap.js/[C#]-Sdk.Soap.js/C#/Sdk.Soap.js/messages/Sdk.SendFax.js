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
 this.SendFaxRequest = function (faxId, issueSend) {
  ///<summary>
  /// Contains the data that is needed to send a fax.
  ///</summary>
  ///<param name="faxId"  type="String">
  /// Sets the ID of the fax to send.
  ///</param>
  ///<param name="issueSend"  type="Boolean">
  /// Sets whether to send the e-mail, or to just record it as sent.
  ///</param>
  if (!(this instanceof Sdk.SendFaxRequest)) {
   return new Sdk.SendFaxRequest(faxId, issueSend);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _faxId = null;
  var _issueSend = null;

  // internal validation functions

  function _setValidFaxId(value) {
   if (Sdk.Util.isGuid(value)) {
    _faxId = value;
   }
   else {
    throw new Error("Sdk.SendFaxRequest FaxId property is required and must be a String.")
   }
  }

  function _setValidIssueSend(value) {
   if (typeof value == "boolean") {
    _issueSend = value;
   }
   else {
    throw new Error("Sdk.SendFaxRequest IssueSend property is required and must be a Boolean.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof faxId != "undefined") {
   _setValidFaxId(faxId);
  }
  if (typeof issueSend != "undefined") {
   _setValidIssueSend(issueSend);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>FaxId</b:key>",
              (_faxId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _faxId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>IssueSend</b:key>",
              (_issueSend == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _issueSend, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>SendFax</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SendFaxResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setFaxId = function (value) {
   ///<summary>
   /// Sets the ID of the fax to send.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the fax to send.
   ///</param>
   _setValidFaxId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setIssueSend = function (value) {
   ///<summary>
   /// Sets whether to send the e-mail, or to just record it as sent.
   ///</summary>
   ///<param name="value" type="Boolean">
   /// Whether to send the e-mail, or to just record it as sent.
   ///</param>
   _setValidIssueSend(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SendFaxRequest.__class = true;

 this.SendFaxResponse = function (responseXml) {
  ///<summary>
  /// Response to SendFaxRequest
  ///</summary>
  if (!(this instanceof Sdk.SendFaxResponse)) {
   return new Sdk.SendFaxResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.SendFaxResponse.__class = true;
}).call(Sdk)

Sdk.SendFaxRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SendFaxResponse.prototype = new Sdk.OrganizationResponse();
