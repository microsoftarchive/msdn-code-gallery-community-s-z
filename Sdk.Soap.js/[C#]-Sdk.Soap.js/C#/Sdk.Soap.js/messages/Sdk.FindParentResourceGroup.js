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
 this.FindParentResourceGroupRequest = function (parentId, childrenIds) {
  ///<summary>
  /// Contains the data that is needed to find a parent resource group (scheduling group) for the specified resource groups (scheduling groups). 
  ///</summary>
  ///<param name="parentId"  type="String">
  /// Sets the ID of the parent resource group. 
  ///</param>
  ///<param name="childrenIds"  type="Sdk.Collection">
  /// Sets a collection of IDs of the children resource groups. 
  ///</param>
  if (!(this instanceof Sdk.FindParentResourceGroupRequest)) {
   return new Sdk.FindParentResourceGroupRequest(parentId, childrenIds);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _parentId = null;
  var _childrenIds = null;

  // internal validation functions

  function _setValidParentId(value) {
   if (Sdk.Util.isGuid(value)) {
    _parentId = value;
   }
   else {
    throw new Error("Sdk.FindParentResourceGroupRequest ParentId property is required and must be a String.")
   }
  }

  function _setValidChildrenIds(value) {
   if (Sdk.Util.isCollectionOf(value, String)) {
    _childrenIds = value;
   }
   else {
    throw new Error("Sdk.FindParentResourceGroupRequest ChildrenIds property is required and must be a Sdk.Collection.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof parentId != "undefined") {
   _setValidParentId(parentId);
  }
  if (typeof childrenIds != "undefined") {
   _setValidChildrenIds(childrenIds);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ParentId</b:key>",
              (_parentId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _parentId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ChildrenIds</b:key>",
              (_childrenIds == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"f:ArrayOfguid\">", _childrenIds.toArrayOfValueXml("f:guid"), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>FindParentResourceGroup</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.FindParentResourceGroupResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setParentId = function (value) {
   ///<summary>
   /// Sets the ID of the parent resource group. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the parent resource group. 
   ///</param>
   _setValidParentId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setChildrenIds = function (value) {
   ///<summary>
   /// Sets a collection of IDs of the children resource groups. 
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// A collection of IDs of the children resource groups. 
   ///</param>
   _setValidChildrenIds(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.FindParentResourceGroupRequest.__class = true;

 this.FindParentResourceGroupResponse = function (responseXml) {
  ///<summary>
  /// Response to FindParentResourceGroupRequest
  ///</summary>
  if (!(this instanceof Sdk.FindParentResourceGroupResponse)) {
   return new Sdk.FindParentResourceGroupResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _result = null;

  // Internal property setter functions

  function _setResult(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='result']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _result = (Sdk.Xml.getNodeText(valueNode) == "true") ? true : false;
   }
  }
  //Public Methods to retrieve properties
  this.getResult = function () {
   ///<summary>
   /// Gets a value that indicates whether the parent resource group was found. 
   ///</summary>
   ///<returns type="Boolean">
   /// A value that indicates whether the parent resource group was found. 
   ///</returns>
   return _result;
  }

  //Set property values from responseXml constructor parameter
  _setResult(responseXml);
 }
 this.FindParentResourceGroupResponse.__class = true;
}).call(Sdk)

Sdk.FindParentResourceGroupRequest.prototype = new Sdk.OrganizationRequest();
Sdk.FindParentResourceGroupResponse.prototype = new Sdk.OrganizationResponse();
