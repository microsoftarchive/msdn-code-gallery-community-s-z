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
 this.RemoveItemCampaignRequest = function (campaignId, entityId) {
  ///<summary>
  /// Contains the data that is needed to  remove an item from a campaign.
  ///</summary>
  ///<param name="campaignId"  type="String">
  /// Sets the ID of the campaign. Required.
  ///</param>
  ///<param name="entityId"  type="String">
  /// Sets the ID of the item to be removed from the campaign. Required.
  ///</param>
  if (!(this instanceof Sdk.RemoveItemCampaignRequest)) {
   return new Sdk.RemoveItemCampaignRequest(campaignId, entityId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _campaignId = null;
  var _entityId = null;

  // internal validation functions

  function _setValidCampaignId(value) {
   if (Sdk.Util.isGuid(value)) {
    _campaignId = value;
   }
   else {
    throw new Error("Sdk.RemoveItemCampaignRequest CampaignId property is required and must be a String.")
   }
  }

  function _setValidEntityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _entityId = value;
   }
   else {
    throw new Error("Sdk.RemoveItemCampaignRequest EntityId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof campaignId != "undefined") {
   _setValidCampaignId(campaignId);
  }
  if (typeof entityId != "undefined") {
   _setValidEntityId(entityId);
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

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RemoveItemCampaign</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RemoveItemCampaignResponse);
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
   /// Sets the ID of the item to be removed from the campaign. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the item to be removed from the campaign.
   ///</param>
   _setValidEntityId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RemoveItemCampaignRequest.__class = true;

 this.RemoveItemCampaignResponse = function (responseXml) {
  ///<summary>
  /// Response to RemoveItemCampaignRequest
  ///</summary>
  if (!(this instanceof Sdk.RemoveItemCampaignResponse)) {
   return new Sdk.RemoveItemCampaignResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.RemoveItemCampaignResponse.__class = true;
}).call(Sdk)

Sdk.RemoveItemCampaignRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RemoveItemCampaignResponse.prototype = new Sdk.OrganizationResponse();
