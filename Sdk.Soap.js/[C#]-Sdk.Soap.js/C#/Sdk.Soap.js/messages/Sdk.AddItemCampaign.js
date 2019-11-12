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
 this.AddItemCampaignRequest = function (campaignId, entityId, entityName) {
  ///<summary>
  /// Contains the data that is needed to add an item to a campaign. 
  ///</summary>
  ///<param name="campaignId"  type="String">
  /// Sets the ID of the campaign
  ///</param>
  ///<param name="entityId"  type="String">
  /// Sets the ID of the record to be added to the campaign
  ///</param>
  ///<param name="entityName"  type="String">
  /// Sets the name of the type of entity that is used in the operation
  ///</param>
  if (!(this instanceof Sdk.AddItemCampaignRequest)) {
   return new Sdk.AddItemCampaignRequest(campaignId, entityId, entityName);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _campaignId = null;
  var _entityId = null;
  var _entityName = null;

  // internal validation functions

  function _setValidCampaignId(value) {
   if (Sdk.Util.isGuid(value)) {
    _campaignId = value;
   }
   else {
    throw new Error("Sdk.AddItemCampaignRequest CampaignId property is required and must be a String.")
   }
  }

  function _setValidEntityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _entityId = value;
   }
   else {
    throw new Error("Sdk.AddItemCampaignRequest EntityId property is required and must be a String.")
   }
  }

  function _setValidEntityName(value) {
   if (typeof value == "string") {
    _entityName = value;
   }
   else {
    throw new Error("Sdk.AddItemCampaignRequest EntityName property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof campaignId != "undefined") {
   _setValidCampaignId(campaignId);
  }
  if (typeof entityId != "undefined") {
   _setValidEntityId(entityId);
  }
  if (typeof entityName != "undefined") {
   _setValidEntityName(entityName);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>CampaignId</b:key>",
              (_campaignId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _campaignId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EntityId</b:key>",
              (_entityId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _entityId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EntityName</b:key>",
              (_entityName == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _entityName, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>AddItemCampaign</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.AddItemCampaignResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setCampaignId = function (value) {
   ///<summary>
   /// Sets the ID of the campaign. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the campaign. 
   ///</param>
   _setValidCampaignId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setEntityId = function (value) {
   ///<summary>
   /// Sets the ID of the record to be added to the campaign. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the record to be added to the campaign. 
   ///</param>
   _setValidEntityId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setEntityName = function (value) {
   ///<summary>
   /// Sets the name of the type of entity that is used in the operation. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The name of the type of entity that is used in the operation. 
   ///</param>
   _setValidEntityName(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.AddItemCampaignRequest.__class = true;

 this.AddItemCampaignResponse = function (responseXml) {
  ///<summary>
  /// Response to AddItemCampaignRequest
  ///</summary>
  if (!(this instanceof Sdk.AddItemCampaignResponse)) {
   return new Sdk.AddItemCampaignResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _campaignItemId = null;

  // Internal property setter functions

  function _setCampaignItemId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='CampaignItemId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _campaignItemId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getCampaignItemId = function () {
   ///<summary>
   /// Gets the ID of the resulting campaign item. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the resulting campaign item. 
   ///</returns>
   return _campaignItemId;
  }

  //Set property values from responseXml constructor parameter
  _setCampaignItemId(responseXml);
 }
 this.AddItemCampaignResponse.__class = true;
}).call(Sdk)

Sdk.AddItemCampaignRequest.prototype = new Sdk.OrganizationRequest();
Sdk.AddItemCampaignResponse.prototype = new Sdk.OrganizationResponse();
