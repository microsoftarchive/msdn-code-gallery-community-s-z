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
 this.RemoveSolutionComponentRequest = function (componentId, componentType, solutionUniqueName) {
  ///<summary>
  /// Contains the data that is needed to  remove a component from an unmanaged solution. 
  ///</summary>
  ///<param name="componentId"  type="String">
  /// Sets the ID of the solution component. Required.
  ///</param>
  ///<param name="componentType"  type="Number">
  /// Sets the value that represents the solution component that you want to add. Required.
  ///</param>
  ///<param name="solutionUniqueName"  type="String">
  /// Sets the value of the Solution.UniqueName attribute of the solution for which you want to add the solution component. Required.
  ///</param>
  if (!(this instanceof Sdk.RemoveSolutionComponentRequest)) {
   return new Sdk.RemoveSolutionComponentRequest(componentId, componentType, solutionUniqueName);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _componentId = null;
  var _componentType = null;
  var _solutionUniqueName = null;

  // internal validation functions

  function _setValidComponentId(value) {
   if (Sdk.Util.isGuid(value)) {
    _componentId = value;
   }
   else {
    throw new Error("Sdk.RemoveSolutionComponentRequest ComponentId property is required and must be a String.")
   }
  }

  function _setValidComponentType(value) {
   if (typeof value == "number") {
    _componentType = value;
   }
   else {
    throw new Error("Sdk.RemoveSolutionComponentRequest ComponentType property is required and must be a Number.")
   }
  }

  function _setValidSolutionUniqueName(value) {
   if (typeof value == "string") {
    _solutionUniqueName = value;
   }
   else {
    throw new Error("Sdk.RemoveSolutionComponentRequest SolutionUniqueName property is required and must be a String.")
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

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RemoveSolutionComponent</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RemoveSolutionComponentResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setComponentId = function (value) {
   ///<summary>
   /// Sets the ID of the solution component. Required.
   ///</summary>
   ///<param name="value" type="String">
   ///The ID of the solution component.
   ///</param>
   _setValidComponentId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setComponentType = function (value) {
   ///<summary>
   /// Sets the value that represents the solution component that you want to add. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The value that represents the solution component that you want to add.
   ///</param>
   _setValidComponentType(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSolutionUniqueName = function (value) {
   ///<summary>
   /// Sets the value of the Solution.UniqueName attribute of the solution for which you want to add the solution component. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The value of the Solution.UniqueName attribute of the solution for which you want to add the solution component.
   ///</param>
   _setValidSolutionUniqueName(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RemoveSolutionComponentRequest.__class = true;

 this.RemoveSolutionComponentResponse = function (responseXml) {
  ///<summary>
  /// Response to RemoveSolutionComponentRequest
  ///</summary>
  if (!(this instanceof Sdk.RemoveSolutionComponentResponse)) {
   return new Sdk.RemoveSolutionComponentResponse(responseXml);
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
   /// Gets the ID value of the solution component that was removed.
   ///</summary>
   ///<returns type="String">
   /// The ID value of the solution component that was removed.
   ///</returns>
   return _id;
  }

  //Set property values from responseXml constructor parameter
  _setId(responseXml);
 }
 this.RemoveSolutionComponentResponse.__class = true;
}).call(Sdk)

Sdk.RemoveSolutionComponentRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RemoveSolutionComponentResponse.prototype = new Sdk.OrganizationResponse();
