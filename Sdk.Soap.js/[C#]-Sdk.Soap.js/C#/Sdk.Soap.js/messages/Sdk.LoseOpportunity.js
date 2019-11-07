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
 this.LoseOpportunityRequest = function (opportunityClose, status) {
  ///<summary>
  /// Contains the data that is needed to set the state of an opportunity to Lost.
  ///</summary>
  ///<param name="opportunityClose"  type="Sdk.Entity">
  /// Sets the opportunity close activity. Required.
  ///</param>
  ///<param name="status"  type="Number">
  /// Sets a status of the opportunity. Required.
  ///</param>
  if (!(this instanceof Sdk.LoseOpportunityRequest)) {
   return new Sdk.LoseOpportunityRequest(opportunityClose, status);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _opportunityClose = null;
  var _status = null;

  // internal validation functions

  function _setValidOpportunityClose(value) {
   if (value instanceof Sdk.Entity) {
    _opportunityClose = value;
   }
   else {
    throw new Error("Sdk.LoseOpportunityRequest OpportunityClose property is required and must be a Sdk.Entity.")
   }
  }

  function _setValidStatus(value) {
   if (typeof value == "number") {
    _status = value;
   }
   else {
    throw new Error("Sdk.LoseOpportunityRequest Status property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof opportunityClose != "undefined") {
   _setValidOpportunityClose(opportunityClose);
  }
  if (typeof status != "undefined") {
   _setValidStatus(status);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>OpportunityClose</b:key>",
              (_opportunityClose == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:Entity\">", _opportunityClose.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Status</b:key>",
              (_status == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:OptionSetValue\">",
               "<a:Value>", _status, "</a:Value>",
              "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>LoseOpportunity</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.LoseOpportunityResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setOpportunityClose = function (value) {
   ///<summary>
   /// Sets the opportunity close activity. Required.
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The opportunity close activity.
   ///</param>
   _setValidOpportunityClose(value);
   this.setRequestXml(getRequestXml());
  }

  this.setStatus = function (value) {
   ///<summary>
   /// Sets a status of the opportunity. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// A status of the opportunity.
   ///</param>
   _setValidStatus(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.LoseOpportunityRequest.__class = true;

 this.LoseOpportunityResponse = function (responseXml) {
  ///<summary>
  /// Response to LoseOpportunityRequest
  ///</summary>
  if (!(this instanceof Sdk.LoseOpportunityResponse)) {
   return new Sdk.LoseOpportunityResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.LoseOpportunityResponse.__class = true;
}).call(Sdk)

Sdk.LoseOpportunityRequest.prototype = new Sdk.OrganizationRequest();
Sdk.LoseOpportunityResponse.prototype = new Sdk.OrganizationResponse();
