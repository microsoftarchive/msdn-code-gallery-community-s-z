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
 this.CopyCampaignRequest = function (baseCampaign, saveAsTemplate) {
  ///<summary>
  /// Contains the data that is needed to copy a campaign. 
  ///</summary>
  ///<param name="baseCampaign"  type="String">
  /// Sets the ID of the base campaign to copy from. Required. 
  ///</param>
  ///<param name="saveAsTemplate"  type="Boolean">
  /// Sets a value that indicates whether to save the campaign as a template. Required. 
  ///</param>
  if (!(this instanceof Sdk.CopyCampaignRequest)) {
   return new Sdk.CopyCampaignRequest(baseCampaign, saveAsTemplate);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _baseCampaign = null;
  var _saveAsTemplate = null;

  // internal validation functions

  function _setValidBaseCampaign(value) {
   if (Sdk.Util.isGuid(value)) {
    _baseCampaign = value;
   }
   else {
    throw new Error("Sdk.CopyCampaignRequest BaseCampaign property is required and must be a String.")
   }
  }

  function _setValidSaveAsTemplate(value) {
   if (typeof value == "boolean") {
    _saveAsTemplate = value;
   }
   else {
    throw new Error("Sdk.CopyCampaignRequest SaveAsTemplate property is required and must be a Boolean.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof baseCampaign != "undefined") {
   _setValidBaseCampaign(baseCampaign);
  }
  if (typeof saveAsTemplate != "undefined") {
   _setValidSaveAsTemplate(saveAsTemplate);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>BaseCampaign</b:key>",
              (_baseCampaign == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _baseCampaign, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SaveAsTemplate</b:key>",
              (_saveAsTemplate == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _saveAsTemplate, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CopyCampaign</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CopyCampaignResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setBaseCampaign = function (value) {
   ///<summary>
   /// Sets the ID of the base campaign to copy from. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the base campaign to copy from.
   ///</param>
   _setValidBaseCampaign(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSaveAsTemplate = function (value) {
   ///<summary>
   /// Sets a value that indicates whether to save the campaign as a template. Required. 
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether to save the campaign as a template.
   ///</param>
   _setValidSaveAsTemplate(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CopyCampaignRequest.__class = true;

 this.CopyCampaignResponse = function (responseXml) {
  ///<summary>
  /// Response to CopyCampaignRequest
  ///</summary>
  if (!(this instanceof Sdk.CopyCampaignResponse)) {
   return new Sdk.CopyCampaignResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _campaignCopyId = null;

  // Internal property setter functions

  function _setCampaignCopyId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='CampaignCopyId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _campaignCopyId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getCampaignCopyId = function () {
   ///<summary>
   /// Gets the ID of the newly created campaign. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the newly created campaign. 
   ///</returns>
   return _campaignCopyId;
  }

  //Set property values from responseXml constructor parameter
  _setCampaignCopyId(responseXml);
 }
 this.CopyCampaignResponse.__class = true;
}).call(Sdk)

Sdk.CopyCampaignRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CopyCampaignResponse.prototype = new Sdk.OrganizationResponse();
