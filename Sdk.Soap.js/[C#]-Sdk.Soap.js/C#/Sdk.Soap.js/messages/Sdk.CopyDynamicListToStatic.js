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
 this.CopyDynamicListToStaticRequest = function (listId) {
  ///<summary>
  /// Contains the data that is needed to create a static list from the specified dynamic list and add the members that satisfy the dynamic list query criteria to the static list. 
  ///</summary>
  ///<param name="listId"  type="String">
  /// Sets the ID of the dynamic list. Required. 
  ///</param>
  if (!(this instanceof Sdk.CopyDynamicListToStaticRequest)) {
   return new Sdk.CopyDynamicListToStaticRequest(listId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _listId = null;

  // internal validation functions

  function _setValidListId(value) {
   if (Sdk.Util.isGuid(value)) {
    _listId = value;
   }
   else {
    throw new Error("Sdk.CopyDynamicListToStaticRequest ListId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof listId != "undefined") {
   _setValidListId(listId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ListId</b:key>",
              (_listId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _listId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CopyDynamicListToStatic</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CopyDynamicListToStaticResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setListId = function (value) {
   ///<summary>
   /// Sets the ID of the dynamic list. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the dynamic list.
   ///</param>
   _setValidListId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CopyDynamicListToStaticRequest.__class = true;

 this.CopyDynamicListToStaticResponse = function (responseXml) {
  ///<summary>
  /// Response to CopyDynamicListToStaticRequest
  ///</summary>
  if (!(this instanceof Sdk.CopyDynamicListToStaticResponse)) {
   return new Sdk.CopyDynamicListToStaticResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _staticListId = null;

  // Internal property setter functions

  function _setStaticListId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='StaticListId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _staticListId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getStaticListId = function () {
   ///<summary>
   /// Gets the ID of the created static list. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the created static list. 
   ///</returns>
   return _staticListId;
  }

  //Set property values from responseXml constructor parameter
  _setStaticListId(responseXml);
 }
 this.CopyDynamicListToStaticResponse.__class = true;
}).call(Sdk)

Sdk.CopyDynamicListToStaticRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CopyDynamicListToStaticResponse.prototype = new Sdk.OrganizationResponse();
