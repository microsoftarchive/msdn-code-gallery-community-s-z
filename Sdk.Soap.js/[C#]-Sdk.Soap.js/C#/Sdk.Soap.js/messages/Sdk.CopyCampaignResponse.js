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
 this.CopyCampaignResponseRequest = function (campaignResponseId) {
  ///<summary>
  /// Contains the data that is needed to create a copy of the campaign response. 
  ///</summary>
  ///<param name="campaignResponseId"  type="Sdk.EntityReference">
  /// Sets the campaign response to copy from. Required. 
  ///</param>
  if (!(this instanceof Sdk.CopyCampaignResponseRequest)) {
   return new Sdk.CopyCampaignResponseRequest(campaignResponseId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _campaignResponseId = null;

  // internal validation functions

  function _setValidCampaignResponseId(value) {
   if (value instanceof Sdk.EntityReference) {
    _campaignResponseId = value;
   }
   else {
    throw new Error("Sdk.CopyCampaignResponseRequest CampaignResponseId property is required and must be a Sdk.EntityReference.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof campaignResponseId != "undefined") {
   _setValidCampaignResponseId(campaignResponseId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>CampaignResponseId</b:key>",
              (_campaignResponseId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _campaignResponseId.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CopyCampaignResponse</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CopyCampaignResponseResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setCampaignResponseId = function (value) {
   ///<summary>
   /// Sets the campaign response to copy from. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The campaign response to copy from. 
   ///</param>
   _setValidCampaignResponseId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CopyCampaignResponseRequest.__class = true;

 this.CopyCampaignResponseResponse = function (responseXml) {
  ///<summary>
  /// Response to CopyCampaignResponseRequest
  ///</summary>
  if (!(this instanceof Sdk.CopyCampaignResponseResponse)) {
   return new Sdk.CopyCampaignResponseResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _campaignResponseId = null;

  // Internal property setter functions

  function _setCampaignResponseId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='CampaignResponseId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _campaignResponseId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getCampaignResponseId = function () {
   ///<summary>
   /// Gets the ID of the newly created campaign response. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the newly created campaign response. 
   ///</returns>
   return _campaignResponseId;
  }

  //Set property values from responseXml constructor parameter
  _setCampaignResponseId(responseXml);
 }
 this.CopyCampaignResponseResponse.__class = true;
}).call(Sdk)

Sdk.CopyCampaignResponseRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CopyCampaignResponseResponse.prototype = new Sdk.OrganizationResponse();
