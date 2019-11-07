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
 this.AddItemCampaignActivityRequest = function (campaignActivityId, itemId, entityName) {
  ///<summary>
  /// Contains the data that is needed to add an item to a campaign activity. 
  ///</summary>
  ///<param name="campaignActivityId"  type="String">
  /// Sets the ID of the campaign activity
  ///</param>
  ///<param name="itemId"  type="String">
  /// Sets the ID of the item to be added to the campaign activity
  ///</param>
  ///<param name="entityName"  type="String">
  /// Sets the name of the entity type that is used in the operation
  ///</param>
  if (!(this instanceof Sdk.AddItemCampaignActivityRequest)) {
   return new Sdk.AddItemCampaignActivityRequest(campaignActivityId, itemId, entityName);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _campaignActivityId = null;
  var _itemId = null;
  var _entityName = null;

  // internal validation functions

  function _setValidCampaignActivityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _campaignActivityId = value;
   }
   else {
    throw new Error("Sdk.AddItemCampaignActivityRequest CampaignActivityId property is required and must be a String.")
   }
  }

  function _setValidItemId(value) {
   if (Sdk.Util.isGuid(value)) {
    _itemId = value;
   }
   else {
    throw new Error("Sdk.AddItemCampaignActivityRequest ItemId property is required and must be a String.")
   }
  }

  function _setValidEntityName(value) {
   if (typeof value == "string") {
    _entityName = value;
   }
   else {
    throw new Error("Sdk.AddItemCampaignActivityRequest EntityName property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof campaignActivityId != "undefined") {
   _setValidCampaignActivityId(campaignActivityId);
  }
  if (typeof itemId != "undefined") {
   _setValidItemId(itemId);
  }
  if (typeof entityName != "undefined") {
   _setValidEntityName(entityName);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>CampaignActivityId</b:key>",
              (_campaignActivityId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _campaignActivityId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ItemId</b:key>",
              (_itemId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _itemId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EntityName</b:key>",
              (_entityName == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _entityName, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>AddItemCampaignActivity</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.AddItemCampaignActivityResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setCampaignActivityId = function (value) {
   ///<summary>
   /// Sets the ID of the campaign activity. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the campaign activity. 
   ///</param>
   _setValidCampaignActivityId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setItemId = function (value) {
   ///<summary>
   /// Sets the ID of the item to be added to the campaign activity. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the item to be added to the campaign activity. 
   ///</param>
   _setValidItemId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setEntityName = function (value) {
   ///<summary>
   /// Sets the name of the entity type that is used in the operation. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The name of the entity type that is used in the operation. 
   ///</param>
   _setValidEntityName(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.AddItemCampaignActivityRequest.__class = true;

 this.AddItemCampaignActivityResponse = function (responseXml) {
  ///<summary>
  /// Response to AddItemCampaignActivityRequest
  ///</summary>
  if (!(this instanceof Sdk.AddItemCampaignActivityResponse)) {
   return new Sdk.AddItemCampaignActivityResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _campaignActivityItemId = null;

  // Internal property setter functions

  function _setCampaignActivityItemId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='CampaignActivityItemId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _campaignActivityItemId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getCampaignActivityItemId = function () {
   ///<summary>
   /// Gets the ID of the resulting campaign activity item. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the resulting campaign activity item. 
   ///</returns>
   return _campaignActivityItemId;
  }

  //Set property values from responseXml constructor parameter
  _setCampaignActivityItemId(responseXml);
 }
 this.AddItemCampaignActivityResponse.__class = true;
}).call(Sdk)

Sdk.AddItemCampaignActivityRequest.prototype = new Sdk.OrganizationRequest();
Sdk.AddItemCampaignActivityResponse.prototype = new Sdk.OrganizationResponse();
