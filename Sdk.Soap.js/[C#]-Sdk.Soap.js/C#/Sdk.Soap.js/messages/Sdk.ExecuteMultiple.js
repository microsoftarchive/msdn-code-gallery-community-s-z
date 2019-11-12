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

 this.ExecuteMultipleSettings = function (continueOnError, returnResponses) {
  ///<summary>
  /// Defines the execution behavior of Sdk.ExecuteMultipleRequest. 
  ///</summary>
  ///<param name="continueOnError"  type="Boolean">
  /// Sets a value indicating whether further execution of message requests in the Requests collection should continue if a fault is returned for the current request being processed. 
  ///</param>
  ///<param name="returnResponses"  type="Boolean">
  /// Sets a value indicating if a response for each message request processed should be returned. 
  ///</param>
  if (!(this instanceof Sdk.ExecuteMultipleSettings)) {
   return new Sdk.ExecuteMultipleSettings(continueOnError, returnResponses);
  }

  var _continueOnError = true;
  var _returnResponses = true;

  function _setValidContinueOnError(value) {
   if (typeof value == "boolean") {
    _continueOnError = value;
   }
   else {
    throw new Error("Sdk.ExecuteMultipleSettings ContinueOnError property must be a Boolean.")
   }
  }

  function _setValidReturnResponses(value) {
   if (typeof value == "boolean") {
    _returnResponses = value;
   }
   else {
    throw new Error("Sdk.ExecuteMultipleSettings ReturnResponses  property must be a Boolean.")
   }
  }

  if (typeof continueOnError != "undefined") {
   _setValidContinueOnError(continueOnError);
  }
  if (typeof returnResponses != "undefined") {
   _setValidReturnResponses(returnResponses);
  }

  this.getContinueOnError = function () {
   ///<summary>
   /// Gets a value indicating whether further execution of message requests in the Requests collection should continue if a fault is returned for the current request being processed. 
   ///</summary>
   ///<returns type="Boolean">
   /// A value indicating whether further execution of message requests in the Requests collection should continue if a fault is returned for the current request being processed. 
   ///</returns>
   return _continueOnError;
  }
  this.getReturnResponses = function () {
   ///<summary>
   /// Gets a value indicating if a response for each message request processed should be returned. 
   ///</summary>
   ///<returns type="Boolean">
   /// A value indicating if a response for each message request processed should be returned. 
   ///</returns>
   return _returnResponses;
  }

  this.setContinueOnError = function (continueOnError) {
   ///<summary>
   /// Sets a value indicating whether further execution of message requests in the Requests collection should continue if a fault is returned for the current request being processed. 
   ///</summary>
   ///<param name="continueOnError"  type="Boolean">
   /// A value indicating whether further execution of message requests in the Requests collection should continue if a fault is returned for the current request being processed. 
   ///</param>
   _setValidContinueOnError(continueOnError);
  }

  this.setReturnResponses = function (returnResponses) {
   ///<summary>
   /// Sets a value indicating if a response for each message request processed should be returned. 
   ///</summary>
   ///<param name="returnResponses"  type="Boolean">
   /// A value indicating if a response for each message request processed should be returned. 
   ///</param>
   _setValidReturnResponses(returnResponses);
  }


 }
 this.ExecuteMultipleSettings.__class = true;

 this.ExecuteMultipleResponseItem = function () {
  ///<summary>
  /// Contains the response or fault from execution of a message request. 
  ///</summary>
  if (!(this instanceof Sdk.ExecuteMultipleResponseItem)) {
   return new Sdk.ExecuteMultipleResponseItem();
  }

  var _fault = null;
  var _requestIndex = null;
  var _response = null;

  function _setValidFault(value) {
   if (value instanceof Sdk.ExecuteMultipleFault) {
    _fault = value;
   }
   else {
    throw new Error("Sdk.ExecuteMultipleResponseItem Fault must be a Sdk.ExecuteMultipleFault.");
   }
  }

  function _setValidRequestIndex(value) {
   if (typeof value == "number") {
    _requestIndex = value;
   }
   else {
    throw new Error("Sdk.ExecuteMultipleResponseItem RequestIndex must be a Number.");
   }
  }

  function _setValidResponse(value) {
   if (value instanceof Sdk.OrganizationResponse) {
    _response = value;
   }
   else {
    throw new Error("Sdk.ExecuteMultipleResponseItem ResponseXml must be an Sdk.OrganizationResponse.");
   }
  }

  this.getFault = function () {
   ///<summary>
   /// Gets information about the organization service fault that occurred when a message request was executed.
   ///</summary>
   ///<returns type="Sdk.ExecuteMultipleFault">
   /// Information about the organization service fault that occurred when a message request was executed.
   ///</returns>
   return _fault;
  }

  this.getRequestIndex = function () {
   ///<summary>
   /// Gets the numerical position of a message request in a request collection.
   ///</summary>
   ///<returns type="Number">
   /// The numerical position of a message request in a request collection.
   ///</returns>
   return _requestIndex;
  }

  this.getResponse = function () {
   ///<summary>
   /// Gets the response that is returned from executing a message request.
   ///</summary>
   ///<returns type="Sdk.OrganizationResponse">
   /// The response that is returned from executing a message request.
   ///</returns>
   return _response;
  }

  this.setFault = function (fault) {
   ///<summary>
   /// Sets information about the organization service fault that occurred when a message request was executed.
   ///</summary>
   ///<param name="fault"  type="Sdk.ExecuteMultipleFault">
   /// Information about the organization service fault that occurred when a message request was executed.
   ///</param>
   _setValidFault(fault);
  }

  this.setRequestIndex = function (requestIndex) {
   ///<summary>
   /// Sets the numerical position of a message request in a request collection.
   ///</summary>
   ///<param name="requestIndex"  type="Number">
   /// The numerical position of a message request in a request collection.
   ///</param>
   _setValidRequestIndex(requestIndex);
  }

  this.setResponse = function (response) {
   ///<summary>
   /// Sets the response that is returned from executing a message request.
   ///</summary>
   ///<param name="response"  type="Sdk.OrganizationResponse">
   /// The response that is returned from executing a message request.
   ///</param>
   _setValidResponse(response);
  }


 }
 this.ExecuteMultipleResponseItem.__class = true;

 this.ExecuteMultipleFault = function (faultXml) {
  ///<summary>
  /// An object to contain fault information
  ///</summary>
  if (!(this instanceof Sdk.ExecuteMultipleFault)) {
   return new Sdk.ExecuteMultipleFault(faultXml);
  }

  var _errorCode = null;
  var _errorDetails = null;
  var _message = null;
  var _timestamp = null;
  var _innerFault = null;
  var _traceText = null;

  if (typeof faultXml != "undefined") {
   _errorCode = parseInt(Sdk.Xml.selectSingleNodeText(faultXml, "a:ErrorCode"), 10);
   _errorDetails = Sdk.Xml.selectSingleNodeText(faultXml, "a:ErrorDetails");
   _message = Sdk.Xml.selectSingleNodeText(faultXml, "a:Message");
   _timestamp = new Date(Sdk.Xml.selectSingleNodeText(faultXml, "a:Timestamp"));
   _innerFault = Sdk.Xml.selectSingleNodeText(faultXml, "a:InnerFault");
   _traceText = Sdk.Xml.selectSingleNodeText(faultXml, "a:TraceText");

  }

  this.getErrorCode = function () {
   ///<summary>
   /// Gets the error code
   ///</summary>
   ///<returns type="Number" />
   return _errorCode;
  }
  this.getErrorDetails = function () {
   ///<summary>
   /// Gets the error details
   ///</summary>
   ///<returns type="String" />
   return _errorDetails;
  }
  this.getMessage = function () {
   ///<summary>
   /// Gets the error message
   ///</summary>
   ///<returns type="String" />
   return _message;
  }
  this.getTimestamp = function () {
   ///<summary>
   /// Gets the error time
   ///</summary>
   ///<returns type="Date" />
   return _timestamp;
  }
  this.getInnerFault = function () {
   ///<summary>
   /// Gets the error inner fault
   ///</summary>
   ///<returns type="String" />
   return _innerFault;
  }
  this.getTraceText = function () {
   ///<summary>
   /// Gets the error trace text
   ///</summary>
   ///<returns type="String" />
   return _traceText;
  }

 }
 this.ExecuteMultipleFault.__class = true;

 this.ExecuteMultipleRequest = function (requests, settings) {
  ///<summary>
  /// Contains the data that is needed to execute one or more message requests as a single batch operation, and optionally return a collection of results. 
  ///</summary>
  ///<param name="requests"  type="Sdk.Collection">
  /// Sets the collection of message requests to execute.
  ///</param>
  ///<param name="settings"  type="Sdk.ExecuteMultipleSettings">
  /// Sets the settings that define whether execution should continue if an error occurs and if responses for each message request processed are to be returned. 
  ///</param>
  if (!(this instanceof Sdk.ExecuteMultipleRequest)) {
   return new Sdk.ExecuteMultipleRequest(requests, settings);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _requests = new Sdk.Collection(Sdk.OrganizationRequest);
  var _settings = new Sdk.ExecuteMultipleSettings();

  // internal validation functions

  function _setValidRequests(value) {
   if (Sdk.Util.isCollectionOf(value, Sdk.OrganizationRequest)) {
    _requests = value;
   }
   else {
    throw new Error("Sdk.ExecuteMultipleRequest Requests property  must be an Sdk.Collection of Sdk.OrganizationRequest.")
   }
  }

  function _setValidSettings(value) {
   if (value instanceof Sdk.ExecuteMultipleSettings) {
    _settings = value;
   }
   else {
    throw new Error("Sdk.ExecuteMultipleRequest Settings property  must be an Sdk.ExecuteMultipleSettings.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof requests != "undefined") {
   _setValidRequests(requests);
  }
  if (typeof settings != "undefined") {
   _setValidSettings(settings);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Requests</b:key>",
              (_requests == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"l:OrganizationRequestCollection\">", _serializeRequests(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Settings</b:key>",
              (_settings == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"l:ExecuteMultipleSettings\">", _serializeSettings(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ExecuteMultiple</a:RequestName>",
         "</d:request>"].join("");
  }

  function _serializeRequests() {
   var rv = [];
   _requests.forEach(function (r, i) {
    var requestXml = r.getRequestXml();
    //Need to replace the <request> root tag with <OrganizationRequest>
    requestXml = requestXml.substring("<d:request>".length);
    requestXml = requestXml.substring(0, requestXml.length - "</d:request>".length);
    requestXml = ["<l:OrganizationRequest>", requestXml, "</l:OrganizationRequest>"].join("");
    rv.push(requestXml);
   });
   return rv.join("");
  }

  function _serializeSettings() {
   return ["<l:ContinueOnError>", _settings.getContinueOnError(), "</l:ContinueOnError>",
   "<l:ReturnResponses>", _settings.getReturnResponses(), "</l:ReturnResponses>"].join("");
  }

  this.setResponseType(Sdk.ExecuteMultipleResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setRequests = function (value) {
   ///<summary>
   /// Sets the collection of message requests to execute. 
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// The collection of message requests to execute. 
   ///</param>
   _setValidRequests(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSettings = function (value) {
   ///<summary>
   /// Sets the settings that define whether execution should continue if an error occurs and if responses for each message request processed are to be returned.
   ///</summary>
   ///<param name="value" type="Sdk.ExecuteMultipleSettings">
   /// The settings that define whether execution should continue if an error occurs and if responses for each message request processed are to be returned.
   ///</param>
   _setValidSettings(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ExecuteMultipleRequest.__class = true;

 this.ExecuteMultipleResponse = function (responseXml) {
  ///<summary>
  /// Response to ExecuteMultipleRequest
  ///</summary>
  if (!(this instanceof Sdk.ExecuteMultipleResponse)) {
   return new Sdk.ExecuteMultipleResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _isFaulted = null;
  var _responses = null;

  // Internal property setter functions

  function _setIsFaulted(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='IsFaulted']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _isFaulted = (Sdk.Xml.getNodeText(valueNode) == "true") ? true : false;
   }
  }
  function _setResponses(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Responses']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _responses = parseResponses(valueNode);
   }
  }

  function parseResponses(xml) {
   //Using Sdk.Collection rather than create a new class for Microsoft.Xrm.Sdk.ExecuteMultipleResponseItemCollection
   var rv = new Sdk.Collection(Sdk.ExecuteMultipleResponseItem);
   for (var i = 0; i < xml.childNodes.length; i++) {
    var emri = new Sdk.ExecuteMultipleResponseItem();

    emri.setRequestIndex(parseInt(Sdk.Xml.selectSingleNodeText(xml.childNodes[i], "l:RequestIndex"), 10));

    var faultNode = Sdk.Xml.selectSingleNode(xml.childNodes[i], "l:Fault");
    if (!Sdk.Xml.isNodeNull(faultNode)) {
     emri.setFault(new Sdk.ExecuteMultipleFault(faultNode));
    }
    else {
     var responseName = Sdk.Xml.selectSingleNodeText(xml.childNodes[i], "l:Response/a:ResponseName") + "Response";
     var responseXml = Sdk.Xml.selectSingleNode(xml.childNodes[i], "l:Response/a:Results");
     emri.setResponse(new Sdk[responseName](responseXml));
    }
    rv.add(emri);
   }
   return rv;
  }

  //Public Methods to retrieve properties
  this.getIsFaulted = function () {
   ///<summary>
   /// Gets a value that indicates if processing at least one of the individual message requests resulted in a fault. 
   ///</summary>
   ///<returns type="Boolean">
   /// A value that indicates if processing at least one of the individual message requests resulted in a fault. 
   ///</returns>
   return _isFaulted;
  }
  this.getResponses = function () {
   ///<summary>
   /// Gets the collection of responses. 
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// The collection of ExecuteMultipleResponseItems. 
   ///</returns>
   return _responses;
  }

  //Set property values from responseXml constructor parameter
  _setIsFaulted(responseXml);
  _setResponses(responseXml);
 }
 this.ExecuteMultipleResponse.__class = true;
}).call(Sdk)

Sdk.ExecuteMultipleRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ExecuteMultipleResponse.prototype = new Sdk.OrganizationResponse();
