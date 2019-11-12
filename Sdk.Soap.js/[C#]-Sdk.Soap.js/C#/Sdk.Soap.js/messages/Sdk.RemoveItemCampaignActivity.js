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
 this.RemoveItemCampaignActivityRequest = function (campaignActivityId, itemId) {
  ///<summary>
  /// Contains the data that is needed to  remove an item from a campaign activity.
  ///</summary>
  ///<param name="campaignActivityId"  type="String">
  /// Sets the ID of the campaign activity. Required.
  ///</param>
  ///<param name="itemId"  type="String">
  /// Sets the ID of the item to be removed from the campaign activity. Required.
  ///</param>
  if (!(this instanceof Sdk.RemoveItemCampaignActivityRequest)) {
   return new Sdk.RemoveItemCampaignActivityRequest(campaignActivityId, itemId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _campaignActivityId = null;
  var _itemId = null;

  // internal validation functions

  function _setValidCampaignActivityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _campaignActivityId = value;
   }
   else {
    throw new Error("Sdk.RemoveItemCampaignActivityRequest CampaignActivityId property is required and must be a String.")
   }
  }

  function _setValidItemId(value) {
   if (Sdk.Util.isGuid(value)) {
    _itemId = value;
   }
   else {
    throw new Error("Sdk.RemoveItemCampaignActivityRequest ItemId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof campaignActivityId != "undefined") {
   _setValidCampaignActivityId(campaignActivityId);
  }
  if (typeof itemId != "undefined") {
   _setValidItemId(itemId);
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

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RemoveItemCampaignActivity</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RemoveItemCampaignActivityResponse);
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
   /// Sets the ID of the item to be removed from the campaign activity. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the item to be removed from the campaign activity.
   ///</param>
   _setValidItemId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RemoveItemCampaignActivityRequest.__class = true;

 this.RemoveItemCampaignActivityResponse = function (responseXml) {
  ///<summary>
  /// Response to RemoveItemCampaignActivityRequest
  ///</summary>
  if (!(this instanceof Sdk.RemoveItemCampaignActivityResponse)) {
   return new Sdk.RemoveItemCampaignActivityResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.RemoveItemCampaignActivityResponse.__class = true;
}).call(Sdk)

Sdk.RemoveItemCampaignActivityRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RemoveItemCampaignActivityResponse.prototype = new Sdk.OrganizationResponse();
