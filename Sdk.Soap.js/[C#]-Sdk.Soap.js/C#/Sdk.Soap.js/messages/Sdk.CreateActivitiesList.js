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
 this.CreateActivitiesListRequest = function (listId, friendlyName, activity, templateId, propagate, ownershipOptions, owner, sendEmail, postWorkflowEvent, queueId) {
  ///<summary>
  /// Contains the data that is needed to create a quick campaign to distribute an activity to members of a list (marketing list). 
  ///</summary>
  ///<param name="listId"  type="String">
  /// Sets the ID of the list. Required. 
  ///</param>
  ///<param name="friendlyName"  type="String">
  /// Sets a display name for the campaign. Required. 
  ///</param>
  ///<param name="activity"  type="Sdk.Entity">
  /// Sets the activity to be distributed. Required. 
  ///</param>
  ///<param name="templateId"  type="String">
  /// Sets the ID of the email template. Required. 
  ///</param>
  ///<param name="propagate"  type="Boolean">
  /// Sets a value that indicates whether the activity is both created and executed. Required. 
  ///</param>
  ///<param name="ownershipOptions"  type="Sdk.PropagationOwnershipOptions">
  /// Sets the propagation ownership options. Required. 
  ///</param>
  ///<param name="owner"  type="Sdk.EntityReference">
  /// Sets the owner for the activity. Required. 
  ///</param>
  ///<param name="sendEmail"  type="Boolean">
  /// Sets a value that indicates whether to send an email about the new activity. Required. 
  ///</param>
  ///<param name="postWorkflowEvent"  type="Boolean">
  /// Sets a value that indicates whether an asynchronous job is used to distribute an activity, such as an email, fax, or letter, to the members of a list. Required. 
  ///</param>
  ///<param name="queueId" optional="true" type="String">
  /// Sets the ID of the queue to which the created activities are added. Required. 
  ///</param>
  if (!(this instanceof Sdk.CreateActivitiesListRequest)) {
   return new Sdk.CreateActivitiesListRequest(listId, friendlyName, activity, templateId, propagate, ownershipOptions, owner, sendEmail, postWorkflowEvent, queueId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _listId = null;
  var _friendlyName = null;
  var _activity = null;
  var _templateId = null;
  var _propagate = null;
  var _ownershipOptions = null;
  var _owner = null;
  var _sendEmail = null;
  var _postWorkflowEvent = null;
  var _queueId = null;

  // internal validation functions

  function _setValidListId(value) {
   if (Sdk.Util.isGuid(value)) {
    _listId = value;
   }
   else {
    throw new Error("Sdk.CreateActivitiesListRequest ListId property is required and must be a String.")
   }
  }

  function _setValidFriendlyName(value) {
   if (typeof value == "string") {
    _friendlyName = value;
   }
   else {
    throw new Error("Sdk.CreateActivitiesListRequest FriendlyName property is required and must be a String.")
   }
  }

  function _setValidActivity(value) {
   if (value instanceof Sdk.Entity) {
    _activity = value;
   }
   else {
    throw new Error("Sdk.CreateActivitiesListRequest Activity property is required and must be a Sdk.Entity.")
   }
  }

  function _setValidTemplateId(value) {
   if (Sdk.Util.isGuid(value)) {
    _templateId = value;
   }
   else {
    throw new Error("Sdk.CreateActivitiesListRequest TemplateId property is required and must be a String.")
   }
  }

  function _setValidPropagate(value) {
   if (typeof value == "boolean") {
    _propagate = value;
   }
   else {
    throw new Error("Sdk.CreateActivitiesListRequest Propagate property is required and must be a Boolean.")
   }
  }

  function _setValidOwnershipOptions(value) {
   if ((typeof value == "string") && (value == "Caller" || value == "ListMemberOwner" || value == "None")) {
    _ownershipOptions = value;
   }
   else {
    throw new Error("Sdk.CreateActivitiesListRequest OwnershipOptions property is required and must be a Sdk.PropagationOwnershipOptions.")
   }
  }

  function _setValidOwner(value) {
   if (value instanceof Sdk.EntityReference) {
    _owner = value;
   }
   else {
    throw new Error("Sdk.CreateActivitiesListRequest Owner property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidSendEmail(value) {
   if (typeof value == "boolean") {
    _sendEmail = value;
   }
   else {
    throw new Error("Sdk.CreateActivitiesListRequest SendEmail property is required and must be a Boolean.")
   }
  }

  function _setValidPostWorkflowEvent(value) {
   if (typeof value == "boolean") {
    _postWorkflowEvent = value;
   }
   else {
    throw new Error("Sdk.CreateActivitiesListRequest PostWorkflowEvent property is required and must be a Boolean.")
   }
  }

  function _setValidQueueId(value) {
   if (value == null || Sdk.Util.isGuid(value)) {
    _queueId = value;
   }
   else {
    throw new Error("Sdk.CreateActivitiesListRequest QueueId property must be a String or null.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof listId != "undefined") {
   _setValidListId(listId);
  }
  if (typeof friendlyName != "undefined") {
   _setValidFriendlyName(friendlyName);
  }
  if (typeof activity != "undefined") {
   _setValidActivity(activity);
  }
  if (typeof templateId != "undefined") {
   _setValidTemplateId(templateId);
  }
  if (typeof propagate != "undefined") {
   _setValidPropagate(propagate);
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
  if (typeof postWorkflowEvent != "undefined") {
   _setValidPostWorkflowEvent(postWorkflowEvent);
  }
  if (typeof queueId != "undefined") {
   _setValidQueueId(queueId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ListId</b:key>",
              (_listId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _listId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>FriendlyName</b:key>",
              (_friendlyName == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _friendlyName, "</b:value>"].join(""),
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
               "<b:key>Propagate</b:key>",
              (_propagate == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _propagate, "</b:value>"].join(""),
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
               "<b:key>sendEmail</b:key>",
              (_sendEmail == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _sendEmail, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>PostWorkflowEvent</b:key>",
              (_postWorkflowEvent == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _postWorkflowEvent, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>QueueId</b:key>",
              (_queueId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _queueId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CreateActivitiesList</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CreateActivitiesListResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setListId = function (value) {
   ///<summary>
   /// Sets the ID of the list. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the list.
   ///</param>
   _setValidListId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setFriendlyName = function (value) {
   ///<summary>
   /// Sets a display name for the campaign. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// A display name for the campaign.
   ///</param>
   _setValidFriendlyName(value);
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

  this.setPropagate = function (value) {
   ///<summary>
   /// Sets a value that indicates whether the activity is both created and executed. Required. 
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether the activity is both created and executed.
   ///</param>
   _setValidPropagate(value);
   this.setRequestXml(getRequestXml());
  }

  this.setOwnershipOptions = function (value) {
   ///<summary>
   /// Sets the propagation ownership options. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.PropagationOwnershipOptions">
   /// The propagation ownership options.
   ///</param>
   _setValidOwnershipOptions(value);
   this.setRequestXml(getRequestXml());
  }

  this.setOwner = function (value) {
   ///<summary>
   /// Sets the owner for the activity. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The owner for the activity.
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

  this.setPostWorkflowEvent = function (value) {
   ///<summary>
   /// Sets a value that indicates whether an asynchronous job is used to distribute an activity, such as an email, fax, or letter, to the members of a list. Required. 
   ///</summary>
   ///<param name="value" type="Boolean">
   ///  A value that indicates whether an asynchronous job is used to distribute an activity, such as an email, fax, or letter, to the members of a list.
   ///</param>
   _setValidPostWorkflowEvent(value);
   this.setRequestXml(getRequestXml());
  }

  this.setQueueId = function (value) {
   ///<summary>
   /// Sets the ID of the queue to which the created activities are added. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the queue to which the created activities are added.
   ///</param>
   _setValidQueueId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CreateActivitiesListRequest.__class = true;

 this.CreateActivitiesListResponse = function (responseXml) {
  ///<summary>
  /// Response to CreateActivitiesListRequest
  ///</summary>
  if (!(this instanceof Sdk.CreateActivitiesListResponse)) {
   return new Sdk.CreateActivitiesListResponse(responseXml);
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
   /// Gets the ID of the bulk operation created to distribute the campaign activity. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the bulk operation created to distribute the campaign activity. 
   ///</returns>
   return _bulkOperationId;
  }

  //Set property values from responseXml constructor parameter
  _setBulkOperationId(responseXml);
 }
 this.CreateActivitiesListResponse.__class = true;
}).call(Sdk)

Sdk.CreateActivitiesListRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CreateActivitiesListResponse.prototype = new Sdk.OrganizationResponse();
