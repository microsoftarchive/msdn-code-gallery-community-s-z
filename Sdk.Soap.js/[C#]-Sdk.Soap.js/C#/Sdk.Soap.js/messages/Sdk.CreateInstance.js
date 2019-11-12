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
 this.CreateInstanceRequest = function (target, count) {
  ///<summary>
  /// Contains the data that is needed to create future unexpanded instances for the recurring appointment master. 
  ///</summary>
  ///<param name="target"  type="Sdk.Entity">
  /// Sets the target appointment instance to create. Required. 
  ///</param>
  ///<param name="count"  type="Number">
  /// Sets the number of instances to be created. Required. 
  ///</param>
  if (!(this instanceof Sdk.CreateInstanceRequest)) {
   return new Sdk.CreateInstanceRequest(target, count);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _count = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.Entity) {
    _target = value;
   }
   else {
    throw new Error("Sdk.CreateInstanceRequest Target property is required and must be a Sdk.Entity.")
   }
  }

  function _setValidCount(value) {
   if (typeof value == "number") {
    _count = value;
   }
   else {
    throw new Error("Sdk.CreateInstanceRequest Count property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof count != "undefined") {
   _setValidCount(count);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Target</b:key>",
              (_target == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:Entity\">", _target.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Count</b:key>",
              (_count == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _count, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CreateInstance</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CreateInstanceResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target appointment instance to create. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The target appointment instance to create. 
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setCount = function (value) {
   ///<summary>
   /// Sets the number of instances to be created. Required. 
   ///</summary>
   ///<param name="value" type="Number">
   /// The number of instances to be created. 
   ///</param>
   _setValidCount(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CreateInstanceRequest.__class = true;

 this.CreateInstanceResponse = function (responseXml) {
  ///<summary>
  /// Response to CreateInstanceRequest
  ///</summary>
  if (!(this instanceof Sdk.CreateInstanceResponse)) {
   return new Sdk.CreateInstanceResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _seriesCanBeExpanded = null;

  // Internal property setter functions

  function _setSeriesCanBeExpanded(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='SeriesCanBeExpanded']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _seriesCanBeExpanded = (Sdk.Xml.getNodeText(valueNode) == "true") ? true : false;
   }
  }
  //Public Methods to retrieve properties
  this.getSeriesCanBeExpanded = function () {
   ///<summary>
   /// Gets whether the series can be expanded. 
   ///</summary>
   ///<returns type="Boolean">
   /// Whether the series can be expanded. 
   ///</returns>
   return _seriesCanBeExpanded;
  }

  //Set property values from responseXml constructor parameter
  _setSeriesCanBeExpanded(responseXml);
 }
 this.CreateInstanceResponse.__class = true;
}).call(Sdk)

Sdk.CreateInstanceRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CreateInstanceResponse.prototype = new Sdk.OrganizationResponse();
