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
 this.DistributeCampaignActivityRequest = function (campaignActivityId, propagate, activity, templateId, ownershipOptions, owner, sendEmail, queueId, postWorkflowEvent) {
  ///<summary>
  /// Contains the data that is needed to create a bulk operation that distributes a campaign activity. The appropriate activities, such as a phone call or fax, are created for the members of the list that is associated with the specified campaign activity. 
  ///</summary>
  ///<param name="campaignActivityId"  type="String">
  /// Sets the ID of the campaign activity for which the activity is distributed. Required.
  ///</param>
  ///<param name="propagate"  type="Boolean">
  /// Sets a value that indicates whether the activity is both created and executed. Required.
  ///</param>
  ///<param name="activity"  type="Sdk.Entity">
  /// Sets the activity to be distributed. Required.
  ///</param>
  ///<param name="templateId"  type="String">
  /// Sets the ID of the email template. Required.
  ///</param>
  ///<param name="ownershipOptions"  type="Sdk.PropagationOwnershipOptions">
  ///  Sets the ownership options for the activity. Required.
  ///</param>
  ///<param name="owner"  type="Sdk.EntityReference">
  /// Sets the owner for the newly created activity. Required.
  ///</param>
  ///<param name="sendEmail"  type="Boolean">
  /// Sets a value that indicates whether to send an email about the new activity. Required.
  ///</param>
  ///<param name="queueId" optional="true" type="String">
  /// Sets the ID of the queue to which the created activity is added. Optional.
  ///</param>
  ///<param name="postWorkflowEvent"  type="Boolean">
  /// Sets a value that indicates whether an asynchronous job is used to distribute activities, such as an email, fax, or letter, to the members of a list. Required.
  ///</param>
  if (!(this instanceof Sdk.DistributeCampaignActivityRequest)) {
   return new Sdk.DistributeCampaignActivityRequest(campaignActivityId, propagate, activity, templateId, ownershipOptions, owner, sendEmail, queueId, postWorkflowEvent);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _campaignActivityId = null;
  var _propagate = null;
  var _activity = null;
  var _templateId = null;
  var _ownershipOptions = null;
  var _owner = null;
  var _sendEmail = null;
  var _queueId = null;
  var _postWorkflowEvent = null;

  // internal validation functions

  function _setValidCampaignActivityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _campaignActivityId = value;
   }
   else {
    throw new Error("Sdk.DistributeCampaignActivityRequest CampaignActivityId property is required and must be a String.")
   }
  }

  function _setValidPropagate(value) {
   if (typeof value == "boolean") {
    _propagate = value;
   }
   else {
    throw new Error("Sdk.DistributeCampaignActivityRequest Propagate property is required and must be a Boolean.")
   }
  }

  function _setValidActivity(value) {
   if (value instanceof Sdk.Entity) {
    _activity = value;
   }
   else {
    throw new Error("Sdk.DistributeCampaignActivityRequest Activity property is required and must be a Sdk.Entity.")
   }
  }

  function _setValidTemplateId(value) {
   if (Sdk.Util.isGuid(value)) {
    _templateId = value;
   }
   else {
    throw new Error("Sdk.DistributeCampaignActivityRequest TemplateId property is required and must be a String.")
   }
  }

  function _setValidOwnershipOptions(value) {
   if ((typeof value == "string") && (value == "Caller" || value == "ListMemberOwner" || value == "None")) {
    _ownershipOptions = value;
   }
   else {
    throw new Error("Sdk.DistributeCampaignActivityRequest OwnershipOptions property is required and must be a Sdk.PropagationOwnershipOptions.")
   }
  }

  function _setValidOwner(value) {
   if (value instanceof Sdk.EntityReference) {
    _owner = value;
   }
   else {
    throw new Error("Sdk.DistributeCampaignActivityRequest Owner property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidSendEmail(value) {
   if (typeof value == "boolean") {
    _sendEmail = value;
   }
   else {
    throw new Error("Sdk.DistributeCampaignActivityRequest SendEmail property is required and must be a Boolean.")
   }
  }

  function _setValidQueueId(value) {
   if (value == null || Sdk.Util.isGuid(value)) {
    _queueId = value;
   }
   else {
    throw new Error("Sdk.DistributeCampaignActivityRequest QueueId property must be a String or null.")
   }
  }

  function _setValidPostWorkflowEvent(value) {
   if (typeof value == "boolean") {
    _postWorkflowEvent = value;
   }
   else {
    throw new Error("Sdk.DistributeCampaignActivityRequest PostWorkflowEvent property is required and must be a Boolean.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof campaignActivityId != "undefined") {
   _setValidCampaignActivityId(campaignActivityId);
  }
  if (typeof propagate != "undefined") {
   _setValidPropagate(propagate);
  }
  if (typeof activity != "undefined") {
   _setValidActivity(activity);
  }
  if (typeof templateId != "undefined") {
   _setValidTemplateId(templateId);
  }
  if (typeof ownershipOptions != "undefined") {
   _setValidOwnershipOptions(ownershipOptions);
  }
  if (typeof owner != "undefined") {
   _setValidOwner(owner);
  }
  if (typeof sendEmail != "undefined") {
   _setValidSendEmail(sendEmail);
  }
  if (typeof queueId != "undefined") {
   _setValidQueueId(queueId);
  }
  if (typeof postWorkflowEvent != "undefined") {
   _setValidPostWorkflowEvent(postWorkflowEvent);
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
               "<b:key>Propagate</b:key>",
              (_propagate == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _propagate, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Activity</b:key>",
              (_activity == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:Entity\">", _activity.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>TemplateId</b:key>",
              (_templateId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _templateId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>OwnershipOptions</b:key>",
              (_ownershipOptions == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"g:PropagationOwnershipOptions\">", _ownershipOptions, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Owner</b:key>",
              (_owner == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _owner.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SendEmail</b:key>",
              (_sendEmail == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _sendEmail, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>QueueId</b:key>",
              (_queueId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _queueId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>PostWorkflowEvent</b:key>",
              (_postWorkflowEvent == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _postWorkflowEvent, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>DistributeCampaignActivity</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.DistributeCampaignActivityResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setCampaignActivityId = function (value) {
   ///<summary>
   /// Sets the ID of the campaign activity for which the activity is distributed. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the campaign activity for which the activity is distributed.
   ///</param>
   _setValidCampaignActivityId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setPropagate = function (value) {
   ///<summary>
   ///  Sets a value that indicates whether the activity is both created and executed. Required.
   ///</summary>
   ///<param name="value" type="Boolean">
   ///  A value that indicates whether the activity is both created and executed.
   ///</param>
   _setValidPropagate(value);
   this.setRequestXml(getRequestXml());
  }

  this.setActivity = function (value) {
   ///<summary>
   /// Sets the activity to be distributed. Required.
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The activity to be distributed.
   ///</param>
   _setValidActivity(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTemplateId = function (value) {
   ///<summary>
   /// Sets the ID of the email template. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the email template.
   ///</param>
   _setValidTemplateId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setOwnershipOptions = function (value) {
   ///<summary>
   /// Sets the ownership options for the activity. Required.
   ///</summary>
   ///<param name="value" type="Sdk.PropagationOwnershipOptions">
   /// The ownership options for the activity.
   ///</param>
   _setValidOwnershipOptions(value);
   this.setRequestXml(getRequestXml());
  }

  this.setOwner = function (value) {
   ///<summary>
   /// Sets the owner for the newly created activity. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The owner for the newly created activity.
   ///</param>
   _setValidOwner(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSendEmail = function (value) {
   ///<summary>
   /// Sets a value that indicates whether to send an email about the new activity. Required.
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether to send an email about the new activity.
   ///</param>
   _setValidSendEmail(value);
   this.setRequestXml(getRequestXml());
  }

  this.setQueueId = function (value) {
   ///<summary>
   /// Sets the ID of the queue to which the created activity is added. Optional.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the queue to which the created activity is added.
   ///</param>
   _setValidQueueId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setPostWorkflowEvent = function (value) {
   ///<summary>
   /// Sets a value that indicates whether an asynchronous job is used to distribute activities, such as an email, fax, or letter, to the members of a list. Required.
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether an asynchronous job is used to distribute activities, such as an email, fax, or letter, to the members of a list.
   ///</param>
   _setValidPostWorkflowEvent(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.DistributeCampaignActivityRequest.__class = true;

 this.DistributeCampaignActivityResponse = function (responseXml) {
  ///<summary>
  /// Response to DistributeCampaignActivityRequest
  ///</summary>
  if (!(this instanceof Sdk.DistributeCampaignActivityResponse)) {
   return new Sdk.DistributeCampaignActivityResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _bulkOperationId = null;

  // Internal property setter functions

  function _setBulkOperationId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='BulkOperationId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _bulkOperationId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getBulkOperationId = function () {
   ///<summary>
   /// Gets the ID of the bulk operation that is used to distribute the campaign activity. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the bulk operation that is used to distribute the campaign activity. 
   ///</returns>
   return _bulkOperationId;
  }

  //Set property values from responseXml constructor parameter
  _setBulkOperationId(responseXml);
 }
 this.DistributeCampaignActivityResponse.__class = true;
}).call(Sdk)

Sdk.DistributeCampaignActivityRequest.prototype = new Sdk.OrganizationRequest();
Sdk.DistributeCampaignActivityResponse.prototype = new Sdk.OrganizationResponse();
