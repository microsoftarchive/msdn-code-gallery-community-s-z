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
 this.ExecuteByIdSavedQueryRequest = function (entityId) {
  ///<summary>
  /// Contains the data that is needed to execute a saved query (view) that has the specified ID. 
  ///</summary>
  ///<param name="entityId"  type="String">
  /// Sets the ID of the saved query (view) to execute. 
  ///</param>
  if (!(this instanceof Sdk.ExecuteByIdSavedQueryRequest)) {
   return new Sdk.ExecuteByIdSavedQueryRequest(entityId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _entityId = null;

  // internal validation functions

  function _setValidEntityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _entityId = value;
   }
   else {
    throw new Error("Sdk.ExecuteByIdSavedQueryRequest EntityId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof entityId != "undefined") {
   _setValidEntityId(entityId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EntityId</b:key>",
              (_entityId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _entityId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ExecuteByIdSavedQuery</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ExecuteByIdSavedQueryResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntityId = function (value) {
   ///<summary>
   /// Sets the ID of the saved query (view) to execute. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the saved query (view) to execute. 
   ///</param>
   _setValidEntityId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ExecuteByIdSavedQueryRequest.__class = true;

 this.ExecuteByIdSavedQueryResponse = function (responseXml) {
  ///<summary>
  /// Response to ExecuteByIdSavedQueryRequest
  ///</summary>
  if (!(this instanceof Sdk.ExecuteByIdSavedQueryResponse)) {
   return new Sdk.ExecuteByIdSavedQueryResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _string = null;

  // Internal property setter functions

  function _setString(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='String']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _string = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getString = function () {
   ///<summary>
   /// Gets the results of the saved query (view). 
   ///</summary>
   ///<returns type="String">
   /// The results of the saved query (view). 
   ///</returns>
   return _string;
  }

  //Set property values from responseXml constructor parameter
  _setString(responseXml);
 }
 this.ExecuteByIdSavedQueryResponse.__class = true;
}).call(Sdk)

Sdk.ExecuteByIdSavedQueryRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ExecuteByIdSavedQueryResponse.prototype = new Sdk.OrganizationResponse();
