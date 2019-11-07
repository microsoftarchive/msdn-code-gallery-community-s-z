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
 this.CreateWorkflowFromTemplateRequest = function (workflowName, workflowTemplateId) {
  ///<summary>
  /// Contains the data that is needed to create a workflow (process) from a workflow template. 
  ///</summary>
  ///<param name="workflowName"  type="String">
  /// Sets the name of the new workflow. Required. 
  ///</param>
  ///<param name="workflowTemplateId"  type="String">
  /// Sets the ID of the workflow template. Required. 
  ///</param>
  if (!(this instanceof Sdk.CreateWorkflowFromTemplateRequest)) {
   return new Sdk.CreateWorkflowFromTemplateRequest(workflowName, workflowTemplateId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _workflowName = null;
  var _workflowTemplateId = null;

  // internal validation functions

  function _setValidWorkflowName(value) {
   if (typeof value == "string") {
    _workflowName = value;
   }
   else {
    throw new Error("Sdk.CreateWorkflowFromTemplateRequest WorkflowName property is required and must be a String.")
   }
  }

  function _setValidWorkflowTemplateId(value) {
   if (Sdk.Util.isGuid(value)) {
    _workflowTemplateId = value;
   }
   else {
    throw new Error("Sdk.CreateWorkflowFromTemplateRequest WorkflowTemplateId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof workflowName != "undefined") {
   _setValidWorkflowName(workflowName);
  }
  if (typeof workflowTemplateId != "undefined") {
   _setValidWorkflowTemplateId(workflowTemplateId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>WorkflowName</b:key>",
              (_workflowName == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _workflowName, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>WorkflowTemplateId</b:key>",
              (_workflowTemplateId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _workflowTemplateId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CreateWorkflowFromTemplate</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CreateWorkflowFromTemplateResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setWorkflowName = function (value) {
   ///<summary>
   /// Sets the name of the new workflow. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The name of the new workflow.
   ///</param>
   _setValidWorkflowName(value);
   this.setRequestXml(getRequestXml());
  }

  this.setWorkflowTemplateId = function (value) {
   ///<summary>
   /// Sets the ID of the workflow template. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the workflow template. 
   ///</param>
   _setValidWorkflowTemplateId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CreateWorkflowFromTemplateRequest.__class = true;

 this.CreateWorkflowFromTemplateResponse = function (responseXml) {
  ///<summary>
  /// Response to CreateWorkflowFromTemplateRequest
  ///</summary>
  if (!(this instanceof Sdk.CreateWorkflowFromTemplateResponse)) {
   return new Sdk.CreateWorkflowFromTemplateResponse(responseXml);
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
   /// Gets the ID of the new workflow. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the new workflow. 
   ///</returns>
   return _id;
  }

  //Set property values from responseXml constructor parameter
  _setId(responseXml);
 }
 this.CreateWorkflowFromTemplateResponse.__class = true;
}).call(Sdk)

Sdk.CreateWorkflowFromTemplateRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CreateWorkflowFromTemplateResponse.prototype = new Sdk.OrganizationResponse();
