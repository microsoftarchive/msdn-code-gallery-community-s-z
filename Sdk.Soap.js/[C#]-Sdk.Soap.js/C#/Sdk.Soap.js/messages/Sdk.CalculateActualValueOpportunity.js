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
 this.CalculateActualValueOpportunityRequest = function (opportunityId) {
  ///<summary>
  /// Contains the data that is needed to calculate the value of an opportunity that is in the "Won" state. 
  ///</summary>
  ///<param name="opportunityId"  type="String">
  /// Sets the ID of the opportunity.
  ///</param>
  if (!(this instanceof Sdk.CalculateActualValueOpportunityRequest)) {
   return new Sdk.CalculateActualValueOpportunityRequest(opportunityId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _opportunityId = null;

  // internal validation functions

  function _setValidOpportunityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _opportunityId = value;
   }
   else {
    throw new Error("Sdk.CalculateActualValueOpportunityRequest OpportunityId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof opportunityId != "undefined") {
   _setValidOpportunityId(opportunityId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>OpportunityId</b:key>",
              (_opportunityId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _opportunityId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CalculateActualValueOpportunity</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CalculateActualValueOpportunityResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setOpportunityId = function (value) {
   ///<summary>
   /// Sets the ID of the opportunity. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the opportunity.
   ///</param>
   _setValidOpportunityId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CalculateActualValueOpportunityRequest.__class = true;

 this.CalculateActualValueOpportunityResponse = function (responseXml) {
  ///<summary>
  /// Response to CalculateActualValueOpportunityRequest
  ///</summary>
  if (!(this instanceof Sdk.CalculateActualValueOpportunityResponse)) {
   return new Sdk.CalculateActualValueOpportunityResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _value = null;

  // Internal property setter functions

  function _setValue(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Value']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _value = parseFloat(Sdk.Xml.getNodeText(valueNode));
   }
  }
  //Public Methods to retrieve properties
  this.getValue = function () {
   ///<summary>
   /// Gets the actual value of an opportunity. 
   ///</summary>
   ///<returns type="Number">
   /// The actual value of an opportunity. 
   ///</returns>
   return _value;
  }

  //Set property values from responseXml constructor parameter
  _setValue(responseXml);
 }
 this.CalculateActualValueOpportunityResponse.__class = true;
}).call(Sdk)

Sdk.CalculateActualValueOpportunityRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CalculateActualValueOpportunityResponse.prototype = new Sdk.OrganizationResponse();
