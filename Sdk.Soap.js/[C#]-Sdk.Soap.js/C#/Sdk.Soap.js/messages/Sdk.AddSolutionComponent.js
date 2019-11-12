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
 this.AddSolutionComponentRequest = function (componentId, componentType, solutionUniqueName, addRequiredComponents) {
  ///<summary>
  /// Contains the data that is needed to add a solution component to an unmanaged solution. 
  ///</summary>
  ///<param name="componentId"  type="String">
  /// Sets the ID of the solution component.
  ///</param>
  ///<param name="componentType"  type="Number">
  /// Sets the value that represents the solution component that you are adding
  ///</param>
  ///<param name="solutionUniqueName"  type="String">
  /// Sets the unique name of the solution you are adding the solution component to. 
  ///</param>
  ///<param name="addRequiredComponents"  type="Boolean">
  /// Sets a value that indicates whether other solution components that are required by the solution component that you are adding should also be added to the unmanaged solution. Required. 
  ///</param>
  if (!(this instanceof Sdk.AddSolutionComponentRequest)) {
   return new Sdk.AddSolutionComponentRequest(componentId, componentType, solutionUniqueName, addRequiredComponents);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _componentId = null;
  var _componentType = null;
  var _solutionUniqueName = null;
  var _addRequiredComponents = null;

  // internal validation functions

  function _setValidComponentId(value) {
   if (Sdk.Util.isGuid(value)) {
    _componentId = value;
   }
   else {
    throw new Error("Sdk.AddSolutionComponentRequest ComponentId property is required and must be a String.")
   }
  }

  function _setValidComponentType(value) {
   if (typeof value == "number") {
    _componentType = value;
   }
   else {
    throw new Error("Sdk.AddSolutionComponentRequest ComponentType property is required and must be a Number.")
   }
  }

  function _setValidSolutionUniqueName(value) {
   if (typeof value == "string") {
    _solutionUniqueName = value;
   }
   else {
    throw new Error("Sdk.AddSolutionComponentRequest SolutionUniqueName property is required and must be a String.")
   }
  }

  function _setValidAddRequiredComponents(value) {
   if (typeof value == "boolean") {
    _addRequiredComponents = value;
   }
   else {
    throw new Error("Sdk.AddSolutionComponentRequest AddRequiredComponents property is required and must be a Boolean.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof componentId != "undefined") {
   _setValidComponentId(componentId);
  }
  if (typeof componentType != "undefined") {
   _setValidComponentType(componentType);
  }
  if (typeof solutionUniqueName != "undefined") {
   _setValidSolutionUniqueName(solutionUniqueName);
  }
  if (typeof addRequiredComponents != "undefined") {
   _setValidAddRequiredComponents(addRequiredComponents);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ComponentId</b:key>",
              (_componentId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _componentId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ComponentType</b:key>",
              (_componentType == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _componentType, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SolutionUniqueName</b:key>",
              (_solutionUniqueName == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _solutionUniqueName, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>AddRequiredComponents</b:key>",
              (_addRequiredComponents == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _addRequiredComponents, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>AddSolutionComponent</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.AddSolutionComponentResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setComponentId = function (value) {
   ///<summary>
   /// Sets the ID of the solution component. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the solution component. 
   ///</param>
   _setValidComponentId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setComponentType = function (value) {
   ///<summary>
   /// Sets the value that represents the solution component that you are adding. Required. 
   ///</summary>
   ///<param name="value" type="Number">
   /// The value that represents the solution component that you are adding. 
   ///</param>
   _setValidComponentType(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSolutionUniqueName = function (value) {
   ///<summary>
   /// Sets the unique name of the solution you are adding the solution component to. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The unique name of the solution you are adding the solution component to. 
   ///</param>
   _setValidSolutionUniqueName(value);
   this.setRequestXml(getRequestXml());
  }

  this.setAddRequiredComponents = function (value) {
   ///<summary>
   /// Sets a value that indicates whether other solution components that are required by the solution component that you are adding should also be added to the unmanaged solution. Required. 
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether other solution components that are required by the solution component that you are adding should also be added to the unmanaged solution. 
   ///</param>
   _setValidAddRequiredComponents(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.AddSolutionComponentRequest.__class = true;

 this.AddSolutionComponentResponse = function (responseXml) {
  ///<summary>
  /// Response to AddSolutionComponentRequest
  ///</summary>
  if (!(this instanceof Sdk.AddSolutionComponentResponse)) {
   return new Sdk.AddSolutionComponentResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _id = null;

  // Internal property setter functions

  function _setId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='id']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _id = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getId = function () {
   ///<summary>
   /// Returns the ID of the new solution component record. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the new solution component record. 
   ///</returns>
   return _id;
  }

  //Set property values from responseXml constructor parameter
  _setId(responseXml);
 }
 this.AddSolutionComponentResponse.__class = true;
}).call(Sdk)

Sdk.AddSolutionComponentRequest.prototype = new Sdk.OrganizationRequest();
Sdk.AddSolutionComponentResponse.prototype = new Sdk.OrganizationResponse();
