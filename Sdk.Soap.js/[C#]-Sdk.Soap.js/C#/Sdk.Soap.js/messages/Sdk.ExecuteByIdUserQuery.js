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
 this.ExecuteByIdUserQueryRequest = function (entityId) {
  ///<summary>
  /// Contains the data that is needed to execute the user query (saved view) that has the specified ID. 
  ///</summary>
  ///<param name="entityId"  type="Sdk.EntityReference">
  /// Sets the ID of the user query (saved view) record to be executed. 
  ///</param>
  if (!(this instanceof Sdk.ExecuteByIdUserQueryRequest)) {
   return new Sdk.ExecuteByIdUserQueryRequest(entityId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _entityId = null;

  // internal validation functions

  function _setValidEntityId(value) {
   if (value instanceof Sdk.EntityReference) {
    _entityId = value;
   }
   else {
    throw new Error("Sdk.ExecuteByIdUserQueryRequest EntityId property is required and must be a Sdk.EntityReference.")
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
              ["<b:value i:type=\"a:EntityReference\">", _entityId.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ExecuteByIdUserQuery</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ExecuteByIdUserQueryResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntityId = function (value) {
   ///<summary>
   /// Sets the ID of the user query (saved view) record to be executed. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The ID of the user query (saved view) record to be executed. 
   ///</param>
   _setValidEntityId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ExecuteByIdUserQueryRequest.__class = true;

 this.ExecuteByIdUserQueryResponse = function (responseXml) {
  ///<summary>
  /// Response to ExecuteByIdUserQueryRequest
  ///</summary>
  if (!(this instanceof Sdk.ExecuteByIdUserQueryResponse)) {
   return new Sdk.ExecuteByIdUserQueryResponse(responseXml);
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
   /// Gets the results of the user query (saved view). 
   ///</summary>
   ///<returns type="String">
   /// The results of the user query (saved view). 
   ///</returns>
   return _string;
  }

  //Set property values from responseXml constructor parameter
  _setString(responseXml);
 }
 this.ExecuteByIdUserQueryResponse.__class = true;
}).call(Sdk)

Sdk.ExecuteByIdUserQueryRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ExecuteByIdUserQueryResponse.prototype = new Sdk.OrganizationResponse();
