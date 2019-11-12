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
 this.BulkDeleteRequest = function (querySet, jobName, sendEmailNotification, toRecipients, cCRecipients, recurrencePattern, startDateTime, sourceImportId) {
  ///<summary>
  /// Contains the data that is needed to submit a bulk delete job that deletes selected records in bulk. This job runs asynchronously in the background without blocking other activities. 
  ///</summary>
  ///<param name="querySet"  type="Sdk.Collection">
  /// Sets an array of queries for a bulk delete job. 
  ///</param>
  ///<param name="jobName"  type="String">
  /// Sets the name of an asynchronous bulk delete job. 
  ///</param>
  ///<param name="sendEmailNotification"  type="Boolean">
  ///  Sets a value that indicates whether an email notification is sent after the bulk delete job has finished running.
  ///</param>
  ///<param name="toRecipients"  type="Sdk.Collection">
  /// Sets a collection of IDs for the system users (users) who are listed in the To box of an email notification. 
  ///</param>
  ///<param name="cCRecipients"  type="Sdk.Collection">
  /// Sets a collection of IDs for the system users (users) who are listed in the Cc box of the email notification.
  ///</param>
  ///<param name="recurrencePattern"  type="String">
  /// Sets the recurrence pattern for the bulk delete job. 
  ///</param>
  ///<param name="startDateTime"  type="Date">
  /// Sets the start date and time to run a bulk delete job. 
  ///</param>
  ///<param name="sourceImportId" optional="true" type="Sdk.Collection">
  /// Sets the ID of the data import job. 
  ///</param>
  if (!(this instanceof Sdk.BulkDeleteRequest)) {
   return new Sdk.BulkDeleteRequest(querySet, jobName, sendEmailNotification, toRecipients, cCRecipients, recurrencePattern, startDateTime, sourceImportId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _querySet = null;
  var _jobName = null;
  var _sendEmailNotification = null;
  var _toRecipients = null;
  var _cCRecipients = null;
  var _recurrencePattern = null;
  var _startDateTime = null;
  var _sourceImportId = null;

  // internal validation functions

  function _setValidQuerySet(value) {
   if (Sdk.Util.isCollectionOf(value, Sdk.Query.QueryExpression)) {
    _querySet = value;
   }
   else {
    throw new Error("Sdk.BulkDeleteRequest QuerySet property is required and must be a Sdk.Collection.")
   }
  }

  function _setValidJobName(value) {
   if (typeof value == "string") {
    _jobName = value;
   }
   else {
    throw new Error("Sdk.BulkDeleteRequest JobName property is required and must be a String.")
   }
  }

  function _setValidSendEmailNotification(value) {
   if (typeof value == "boolean") {
    _sendEmailNotification = value;
   }
   else {
    throw new Error("Sdk.BulkDeleteRequest SendEmailNotification property is required and must be a Boolean.")
   }
  }

  function _setValidToRecipients(value) {
   if (Sdk.Util.isCollectionOf(value, String)) {
    _toRecipients = value;
   }
   else {
    throw new Error("Sdk.BulkDeleteRequest ToRecipients property is required and must be a Sdk.Collection.")
   }
  }

  function _setValidCCRecipients(value) {
   if (Sdk.Util.isCollectionOf(value, String)) {
    _cCRecipients = value;
   }
   else {
    throw new Error("Sdk.BulkDeleteRequest CCRecipients property is required and must be a Sdk.Collection.")
   }
  }

  function _setValidRecurrencePattern(value) {
   if (typeof value == "string") {
    _recurrencePattern = value;
   }
   else {
    throw new Error("Sdk.BulkDeleteRequest RecurrencePattern property is required and must be a String.")
   }
  }

  function _setValidStartDateTime(value) {
   if (value instanceof Date) {
    _startDateTime = value;
   }
   else {
    throw new Error("Sdk.BulkDeleteRequest StartDateTime property is required and must be a Date.")
   }
  }

  function _setValidSourceImportId(value) {
   if (value == null || Sdk.Util.isCollectionOf(value, String)) {
    _sourceImportId = value;
   }
   else {
    throw new Error("Sdk.BulkDeleteRequest SourceImportId property must be a Sdk.Collection or null.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof querySet != "undefined") {
   _setValidQuerySet(querySet);
  }
  if (typeof jobName != "undefined") {
   _setValidJobName(jobName);
  }
  if (typeof sendEmailNotification != "undefined") {
   _setValidSendEmailNotification(sendEmailNotification);
  }
  if (typeof toRecipients != "undefined") {
   _setValidToRecipients(toRecipients);
  }
  if (typeof cCRecipients != "undefined") {
   _setValidCCRecipients(cCRecipients);
  }
  if (typeof recurrencePattern != "undefined") {
   _setValidRecurrencePattern(recurrencePattern);
  }
  if (typeof startDateTime != "undefined") {
   _setValidStartDateTime(startDateTime);
  }
  if (typeof sourceImportId != "undefined") {
   _setValidSourceImportId(sourceImportId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>QuerySet</b:key>",
              (_querySet == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:ArrayOfQueryExpression\">", _querySet.toArrayOfValueXml("a:QueryExpression"), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>JobName</b:key>",
              (_jobName == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _jobName, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SendEmailNotification</b:key>",
              (_sendEmailNotification == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _sendEmailNotification, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ToRecipients</b:key>",
              (_toRecipients == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"f:ArrayOfguid\">", _toRecipients.toArrayOfValueXml("f:guid"), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>CCRecipients</b:key>",
              (_cCRecipients == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"f:ArrayOfguid\">", _cCRecipients.toArrayOfValueXml("f:guid"), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>RecurrencePattern</b:key>",
              (_recurrencePattern == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _recurrencePattern, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>StartDateTime</b:key>",
              (_startDateTime == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:dateTime\">", _startDateTime.toISOString(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SourceImportId</b:key>",
              (_sourceImportId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"f:ArrayOfguid\">", _sourceImportId.toArrayOfValueXml("f:guid"), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>BulkDelete</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.BulkDeleteResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setQuerySet = function (value) {
   ///<summary>
   /// Sets a collection of queries for a bulk delete job. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// A collection of queries for a bulk delete job.
   ///</param>
   _setValidQuerySet(value);
   this.setRequestXml(getRequestXml());
  }

  this.setJobName = function (value) {
   ///<summary>
   /// Sets the name of an asynchronous bulk delete job. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The name of an asynchronous bulk delete job.
   ///</param>
   _setValidJobName(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSendEmailNotification = function (value) {
   ///<summary>
   /// Sets a value that indicates whether an email notification is sent after the bulk delete job has finished running. Required. 
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether an email notification is sent after the bulk delete job has finished running.
   ///</param>
   _setValidSendEmailNotification(value);
   this.setRequestXml(getRequestXml());
  }

  this.setToRecipients = function (value) {
   ///<summary>
   /// Sets a collection of IDs for the system users (users) who are listed in the To box of an email notification. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// A collection of IDs for the system users (users) who are listed in the To box of an email notification.
   ///</param>
   _setValidToRecipients(value);
   this.setRequestXml(getRequestXml());
  }

  this.setCCRecipients = function (value) {
   ///<summary>
   /// Sets a collection of IDs for the system users (users) who are listed in the Cc box of the email notification. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// A collection of IDs for the system users (users) who are listed in the Cc box of the email notification.
   ///</param>
   _setValidCCRecipients(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRecurrencePattern = function (value) {
   ///<summary>
   /// Sets the recurrence pattern for the bulk delete job. Optional. 
   ///</summary>
   ///<param name="value" type="String">
   /// The recurrence pattern for the bulk delete job.
   ///</param>
   _setValidRecurrencePattern(value);
   this.setRequestXml(getRequestXml());
  }

  this.setStartDateTime = function (value) {
   ///<summary>
   /// Sets the start date and time to run a bulk delete job. Optional. 
   ///</summary>
   ///<param name="value" type="Date">
   /// The start date and time to run a bulk delete job.
   ///</param>
   _setValidStartDateTime(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSourceImportId = function (value) {
   ///<summary>
   /// Sets the ID of the data import job. Optional. 
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// The ID of the data import job.
   ///</param>
   _setValidSourceImportId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.BulkDeleteRequest.__class = true;

 this.BulkDeleteResponse = function (responseXml) {
  ///<summary>
  /// Response to BulkDeleteRequest
  ///</summary>
  if (!(this instanceof Sdk.BulkDeleteResponse)) {
   return new Sdk.BulkDeleteResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _jobId = null;

  // Internal property setter functions

  function _setJobId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='JobId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _jobId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getJobId = function () {
   ///<summary>
   /// Gets the ID of an asynchronous bulk delete job that performs a bulk deletion. 
   ///</summary>
   ///<returns type="String">
   /// The ID of an asynchronous bulk delete job that performs a bulk deletion. 
   ///</returns>
   return _jobId;
  }

  //Set property values from responseXml constructor parameter
  _setJobId(responseXml);
 }
 this.BulkDeleteResponse.__class = true;
}).call(Sdk)

Sdk.BulkDeleteRequest.prototype = new Sdk.OrganizationRequest();
Sdk.BulkDeleteResponse.prototype = new Sdk.OrganizationResponse();
