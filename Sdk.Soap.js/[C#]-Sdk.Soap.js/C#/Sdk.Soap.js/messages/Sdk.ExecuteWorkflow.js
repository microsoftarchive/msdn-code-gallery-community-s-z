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
 this.ExecuteWorkflowRequest = function (entityId, workflowId) {
  ///<summary>
  /// Contains the data that is needed to execute a workflow. 
  ///</summary>
  ///<param name="entityId"  type="String">
  /// Sets the ID of the record on which the workflow executes. Required. 
  ///</param>
  ///<param name="workflowId"  type="String">
  /// Sets the ID of the workflow to execute. Required. 
  ///</param>
  if (!(this instanceof Sdk.ExecuteWorkflowRequest)) {
   return new Sdk.ExecuteWorkflowRequest(entityId, workflowId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _entityId = null;
  var _workflowId = null;

  // internal validation functions

  function _setValidEntityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _entityId = value;
   }
   else {
    throw new Error("Sdk.ExecuteWorkflowRequest EntityId property is required and must be a String.")
   }
  }

  function _setValidWorkflowId(value) {
   if (Sdk.Util.isGuid(value)) {
    _workflowId = value;
   }
   else {
    throw new Error("Sdk.ExecuteWorkflowRequest WorkflowId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof entityId != "undefined") {
   _setValidEntityId(entityId);
  }
  if (typeof workflowId != "undefined") {
   _setValidWorkflowId(workflowId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EntityId</b:key>",
              (_entityId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _entityId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>WorkflowId</b:key>",
              (_workflowId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _workflowId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ExecuteWorkflow</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ExecuteWorkflowResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntityId = function (value) {
   ///<summary>
   /// Sets the ID of the record on which the workflow executes. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the record on which the workflow executes. 
   ///</param>
   _setValidEntityId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setWorkflowId = function (value) {
   ///<summary>
   /// Sets the ID of the workflow to execute. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the workflow to execute. 
   ///</param>
   _setValidWorkflowId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ExecuteWorkflowRequest.__class = true;

 this.ExecuteWorkflowResponse = function (responseXml) {
  ///<summary>
  /// Response to ExecuteWorkflowRequest
  ///</summary>
  if (!(this instanceof Sdk.ExecuteWorkflowResponse)) {
   return new Sdk.ExecuteWorkflowResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _id = null;

  // Internal property setter functions

  function _setId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Id']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _id = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getId = function () {
   ///<summary>
   /// Gets the ID of the asynchronous operation (system job) that was created. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the asynchronous operation (system job) that was created. 
   ///</returns>
   return _id;
  }

  //Set property values from responseXml constructor parameter
  _setId(responseXml);
 }
 this.ExecuteWorkflowResponse.__class = true;
}).call(Sdk)

Sdk.ExecuteWorkflowRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ExecuteWorkflowResponse.prototype = new Sdk.OrganizationResponse();
