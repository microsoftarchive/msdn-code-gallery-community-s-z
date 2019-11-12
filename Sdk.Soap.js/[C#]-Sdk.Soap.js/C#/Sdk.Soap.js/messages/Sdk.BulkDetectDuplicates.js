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
 this.BulkDetectDuplicatesRequest = function (query, jobName, sendEmailNotification, templateId, toRecipients, cCRecipients, recurrencePattern, recurrenceStartTime) {
  ///<summary>
  /// Contains the data that is needed to submit an asynchronous system job that detects and logs multiple duplicate records. 
  ///</summary>
  ///<param name="query"  type="Sdk.QueryBase">
  /// Sets a queries to detect multiple duplicate records. 
  ///</param>
  ///<param name="jobName"  type="String">
  /// Sets the name of the asynchronous system job that detects and logs multiple duplicate records.
  ///</param>
  ///<param name="sendEmailNotification"  type="Boolean">
  /// Sets a value that indicates whether an email notification is sent after the asynchronous system job that detects multiple duplicate records finishes running.
  ///</param>
  ///<param name="templateId"  type="String">
  /// Sets the ID of the template (email template) that is used for the email notification. 
  ///</param>
  ///<param name="toRecipients"  type="Sdk.Collection">
  /// Sets an array of IDs for the system users (users) who are listed in the To box of the email notification. 
  ///</param>
  ///<param name="cCRecipients"  type="Sdk.Collection">
  /// Sets an array of IDs for the system users (users) who are listed in the Cc box of the email notification. 
  ///</param>
  ///<param name="recurrencePattern"  type="String">
  /// Sets the recurrence pattern for the asynchronous system job that detects multiple duplicate records. 
  ///</param>
  ///<param name="recurrenceStartTime"  type="Date">
  /// Sets the start date and time of an asynchronous system job that detects and logs multiple duplicate records.
  ///</param>
  if (!(this instanceof Sdk.BulkDetectDuplicatesRequest)) {
   return new Sdk.BulkDetectDuplicatesRequest(query, jobName, sendEmailNotification, templateId, toRecipients, cCRecipients, recurrencePattern, recurrenceStartTime);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _query = null;
  var _jobName = null;
  var _sendEmailNotification = null;
  var _templateId = null;
  var _toRecipients = null;
  var _cCRecipients = null;
  var _recurrencePattern = null;
  var _recurrenceStartTime = null;

  // internal validation functions

  function _setValidQuery(value) {
   if (value instanceof Sdk.Query.QueryBase) {
    _query = value;
   }
   else {
    throw new Error("Sdk.BulkDetectDuplicatesRequest Query property is required and must be a Sdk.QueryBase.")
   }
  }

  function _setValidJobName(value) {
   if (typeof value == "string") {
    _jobName = value;
   }
   else {
    throw new Error("Sdk.BulkDetectDuplicatesRequest JobName property is required and must be a String.")
   }
  }

  function _setValidSendEmailNotification(value) {
   if (typeof value == "boolean") {
    _sendEmailNotification = value;
   }
   else {
    throw new Error("Sdk.BulkDetectDuplicatesRequest SendEmailNotification property is required and must be a Boolean.")
   }
  }

  function _setValidTemplateId(value) {
   if (Sdk.Util.isGuid(value)) {
    _templateId = value;
   }
   else {
    throw new Error("Sdk.BulkDetectDuplicatesRequest TemplateId property is required and must be a String.")
   }
  }

  function _setValidToRecipients(value) {
   if (Sdk.Util.isCollectionOf(value, String)) {
    _toRecipients = value;
   }
   else {
    throw new Error("Sdk.BulkDetectDuplicatesRequest ToRecipients property is required and must be a Sdk.Collection.")
   }
  }

  function _setValidCCRecipients(value) {
   if (Sdk.Util.isCollectionOf(value, String)) {
    _cCRecipients = value;
   }
   else {
    throw new Error("Sdk.BulkDetectDuplicatesRequest CCRecipients property is required and must be a Sdk.Collection.")
   }
  }

  function _setValidRecurrencePattern(value) {
   if (typeof value == "string") {
    _recurrencePattern = value;
   }
   else {
    throw new Error("Sdk.BulkDetectDuplicatesRequest RecurrencePattern property is required and must be a String.")
   }
  }

  function _setValidRecurrenceStartTime(value) {
   if (value instanceof Date) {
    _recurrenceStartTime = value;
   }
   else {
    throw new Error("Sdk.BulkDetectDuplicatesRequest RecurrenceStartTime property is required and must be a Date.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof query != "undefined") {
   _setValidQuery(query);
  }
  if (typeof jobName != "undefined") {
   _setValidJobName(jobName);
  }
  if (typeof sendEmailNotification != "undefined") {
   _setValidSendEmailNotification(sendEmailNotification);
  }
  if (typeof templateId != "undefined") {
   _setValidTemplateId(templateId);
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
  if (typeof recurrenceStartTime != "undefined") {
   _setValidRecurrenceStartTime(recurrenceStartTime);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Query</b:key>",
              (_query == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:" + _query.getQueryType() + "\">", _query.toValueXml(), "</b:value>"].join(""),
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
               "<b:key>TemplateId</b:key>",
              (_templateId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _templateId, "</b:value>"].join(""),
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
               "<b:key>RecurrenceStartTime</b:key>",
              (_recurrenceStartTime == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:dateTime\">", _recurrenceStartTime.toISOString(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>BulkDetectDuplicates</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.BulkDetectDuplicatesResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setQuery = function (value) {
   ///<summary>
   /// Sets a query to detect multiple duplicate records. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.QueryBase">
   /// A query to detect multiple duplicate records.
   ///</param>
   _setValidQuery(value);
   this.setRequestXml(getRequestXml());
  }

  this.setJobName = function (value) {
   ///<summary>
   /// Sets the name of the asynchronous system job that detects and logs multiple duplicate records. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// the name of the asynchronous system job that detects and logs multiple duplicate records.
   ///</param>
   _setValidJobName(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSendEmailNotification = function (value) {
   ///<summary>
   /// Sets a value that indicates whether an email notification is sent after the asynchronous system job that detects multiple duplicate records finishes running. Required. 
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether an email notification is sent after the asynchronous system job that detects multiple duplicate records finishes running.
   ///</param>
   _setValidSendEmailNotification(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTemplateId = function (value) {
   ///<summary>
   /// Sets the ID of the template (email template) that is used for the email notification. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the template (email template) that is used for the email notification. 
   ///</param>
   _setValidTemplateId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setToRecipients = function (value) {
   ///<summary>
   /// Sets a collection of IDs for the system users (users) who are listed in the To box of the email notification. 
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// A collection of IDs for the system users (users) who are listed in the To box of the email notification. 
   ///</param>
   _setValidToRecipients(value);
   this.setRequestXml(getRequestXml());
  }

  this.setCCRecipients = function (value) {
   ///<summary>
   /// Sets a collection of IDs for the system users (users) who are listed in the Cc box of the email notification. 
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// A collection of IDs for the system users (users) who are listed in the Cc box of the email notification. 
   ///</param>
   _setValidCCRecipients(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRecurrencePattern = function (value) {
   ///<summary>
   /// Sets the recurrence pattern for the asynchronous system job that detects multiple duplicate records. Optional. 
   ///</summary>
   ///<param name="value" type="String">
   /// The recurrence pattern for the asynchronous system job that detects multiple duplicate records.
   ///</param>
   _setValidRecurrencePattern(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRecurrenceStartTime = function (value) {
   ///<summary>
   /// Sets the start date and time of an asynchronous system job that detects and logs multiple duplicate records. Optional. 
   ///</summary>
   ///<param name="value" type="Date">
   /// The start date and time of an asynchronous system job that detects and logs multiple duplicate records.
   ///</param>
   _setValidRecurrenceStartTime(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.BulkDetectDuplicatesRequest.__class = true;

 this.BulkDetectDuplicatesResponse = function (responseXml) {
  ///<summary>
  /// Response to BulkDetectDuplicatesRequest
  ///</summary>
  if (!(this instanceof Sdk.BulkDetectDuplicatesResponse)) {
   return new Sdk.BulkDetectDuplicatesResponse(responseXml);
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
   /// Gets the ID of an asynchronous bulk detect duplicates job that detects and logs duplicate records. 
   ///</summary>
   ///<returns type="String">
   /// The ID of an asynchronous bulk detect duplicates job that detects and logs duplicate records. 
   ///</returns>
   return _jobId;
  }

  //Set property values from responseXml constructor parameter
  _setJobId(responseXml);
 }
 this.BulkDetectDuplicatesResponse.__class = true;
}).call(Sdk)

Sdk.BulkDetectDuplicatesRequest.prototype = new Sdk.OrganizationRequest();
Sdk.BulkDetectDuplicatesResponse.prototype = new Sdk.OrganizationResponse();
