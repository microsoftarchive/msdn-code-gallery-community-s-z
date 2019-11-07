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
 this.IsComponentCustomizableRequest = function (componentId, componentType) {
  ///<summary>
  /// Contains the data that is needed to  determine whether a solution component is customizable. 
  ///</summary>
  ///<param name="componentId"  type="String">
  /// Sets the ID of the solution component. Required.
  ///</param>
  ///<param name="componentType"  type="Number">
  /// Sets the value that represents the solution component. Required.
  ///</param>
  if (!(this instanceof Sdk.IsComponentCustomizableRequest)) {
   return new Sdk.IsComponentCustomizableRequest(componentId, componentType);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _componentId = null;
  var _componentType = null;

  // internal validation functions

  function _setValidComponentId(value) {
   if (Sdk.Util.isGuid(value)) {
    _componentId = value;
   }
   else {
    throw new Error("Sdk.IsComponentCustomizableRequest ComponentId property is required and must be a String.")
   }
  }

  function _setValidComponentType(value) {
   if (typeof value == "number") {
    _componentType = value;
   }
   else {
    throw new Error("Sdk.IsComponentCustomizableRequest ComponentType property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof componentId != "undefined") {
   _setValidComponentId(componentId);
  }
  if (typeof componentType != "undefined") {
   _setValidComponentType(componentType);
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

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>IsComponentCustomizable</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.IsComponentCustomizableResponse);
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
   /// Sets the value that represents the solution component. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The value that represents the solution component.
   ///</param>
   _setValidComponentType(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.IsComponentCustomizableRequest.__class = true;

 this.IsComponentCustomizableResponse = function (responseXml) {
  ///<summary>
  /// Response to IsComponentCustomizableRequest
  ///</summary>
  if (!(this instanceof Sdk.IsComponentCustomizableResponse)) {
   return new Sdk.IsComponentCustomizableResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _isComponentCustomizable = null;

  // Internal property setter functions

  function _setIsComponentCustomizable(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='IsComponentCustomizable']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _isComponentCustomizable = (Sdk.Xml.getNodeText(valueNode) == "true") ? true : false;
   }
  }
  //Public Methods to retrieve properties
  this.getIsComponentCustomizable = function () {
   ///<summary>
   /// Gets the value that indicates whether a solution component is customizable.
   ///</summary>
   ///<returns type="Boolean">
   /// The value that indicates whether a solution component is customizable.
   ///</returns>
   return _isComponentCustomizable;
  }

  //Set property values from responseXml constructor parameter
  _setIsComponentCustomizable(responseXml);
 }
 this.IsComponentCustomizableResponse.__class = true;
}).call(Sdk)

Sdk.IsComponentCustomizableRequest.prototype = new Sdk.OrganizationRequest();
Sdk.IsComponentCustomizableResponse.prototype = new Sdk.OrganizationResponse();
