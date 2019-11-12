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
 this.WinOpportunityRequest = function (opportunityClose, status) {
  ///<summary>
  /// Contains the data that is needed to set the state of an opportunity to Won.
  ///</summary>
  ///<param name="opportunityClose"  type="Sdk.Entity">
  /// Sets the opportunity close activity associated with this state change. Required.
  ///</param>
  ///<param name="status"  type="Number">
  /// Sets a new status of the opportunity. Required.
  ///</param>
  if (!(this instanceof Sdk.WinOpportunityRequest)) {
   return new Sdk.WinOpportunityRequest(opportunityClose, status);
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
    throw new Error("Sdk.WinOpportunityRequest OpportunityClose property is required and must be a Sdk.Entity.")
   }
  }

  function _setValidStatus(value) {
   if (typeof value == "number") {
    _status = value;
   }
   else {
    throw new Error("Sdk.WinOpportunityRequest Status property is required and must be a Number.")
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
           "<a:RequestName>WinOpportunity</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.WinOpportunityResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setOpportunityClose = function (value) {
   ///<summary>
   /// Sets the opportunity close activity associated with this state change. Required.
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The opportunity close activity associated with this state change.
   ///</param>
   _setValidOpportunityClose(value);
   this.setRequestXml(getRequestXml());
  }

  this.setStatus = function (value) {
   ///<summary>
   /// Sets a new status of the opportunity. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// A new status of the opportunity.
   ///</param>
   _setValidStatus(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.WinOpportunityRequest.__class = true;

 this.WinOpportunityResponse = function (responseXml) {
  ///<summary>
  /// Response to WinOpportunityRequest
  ///</summary>
  if (!(this instanceof Sdk.WinOpportunityResponse)) {
   return new Sdk.WinOpportunityResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.WinOpportunityResponse.__class = true;
}).call(Sdk)

Sdk.WinOpportunityRequest.prototype = new Sdk.OrganizationRequest();
Sdk.WinOpportunityResponse.prototype = new Sdk.OrganizationResponse();
