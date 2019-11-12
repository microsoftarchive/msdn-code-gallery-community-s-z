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
this.ProcessInboundEmailRequest = function (inboundEmailActivity){
///<summary>
/// Contains the data that is needed to process the email responses from a marketing campaign.
///</summary>
///<param name="inboundEmailActivity"  type="String">
 /// Sets the ID of the inbound email activity.
///</param>
if (!(this instanceof Sdk.ProcessInboundEmailRequest)) {
return new Sdk.ProcessInboundEmailRequest(inboundEmailActivity);
}
Sdk.OrganizationRequest.call(this);

  // Internal properties
var _inboundEmailActivity = null;

// internal validation functions

function _setValidInboundEmailActivity(value) {
 if (Sdk.Util.isGuid(value)) {
  _inboundEmailActivity = value;
 }
 else {
  throw new Error("Sdk.ProcessInboundEmailRequest InboundEmailActivity property is required and must be a String.")
 }
}

//Set internal properties from constructor parameters
  if (typeof inboundEmailActivity != "undefined") {
   _setValidInboundEmailActivity(inboundEmailActivity);
  }

  function getRequestXml() {
return ["<d:request>",
        "<a:Parameters>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>InboundEmailActivity</b:key>",
           (_inboundEmailActivity == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"e:guid\">", _inboundEmailActivity, "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

        "</a:Parameters>",
        "<a:RequestId i:nil=\"true\" />",
        "<a:RequestName>ProcessInboundEmail</a:RequestName>",
      "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ProcessInboundEmailResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setInboundEmailActivity = function (value) {
  ///<summary>
   /// Sets the ID of the inbound email activity.
  ///</summary>
  ///<param name="value" type="String">
  /// The ID of the inbound email activity.
  ///</param>
   _setValidInboundEmailActivity(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ProcessInboundEmailRequest.__class = true;

this.ProcessInboundEmailResponse = function (responseXml) {
  ///<summary>
  /// Response to ProcessInboundEmailRequest
  ///</summary>
  if (!(this instanceof Sdk.ProcessInboundEmailResponse)) {
   return new Sdk.ProcessInboundEmailResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.ProcessInboundEmailResponse.__class = true;
}).call(Sdk)

Sdk.ProcessInboundEmailRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ProcessInboundEmailResponse.prototype = new Sdk.OrganizationResponse();
