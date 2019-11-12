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
 this.CanBeReferencedRequest = function (entityName) {
  ///<summary>
  /// Contains the data that is needed to check whether the specified entity can be the primary entity (one) in a one-to-many relationship. 
  ///</summary>
  ///<param name="entityName"  type="String">
  /// Sets the logical entity name to check whether it can be the primary entity in a one-to-many relationship. Required. 
  ///</param>
  if (!(this instanceof Sdk.CanBeReferencedRequest)) {
   return new Sdk.CanBeReferencedRequest(entityName);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _entityName = null;

  // internal validation functions

  function _setValidEntityName(value) {
   if (typeof value == "string") {
    _entityName = value;
   }
   else {
    throw new Error("Sdk.CanBeReferencedRequest EntityName property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof entityName != "undefined") {
   _setValidEntityName(entityName);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EntityName</b:key>",
              (_entityName == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _entityName, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CanBeReferenced</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CanBeReferencedResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntityName = function (value) {
   ///<summary>
   ///  Sets the logical entity name to check whether it can be the primary entity in a one-to-many relationship. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The logical entity name to check whether it can be the primary entity in a one-to-many relationship.
   ///</param>
   _setValidEntityName(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CanBeReferencedRequest.__class = true;

 this.CanBeReferencedResponse = function (responseXml) {
  ///<summary>
  /// Response to CanBeReferencedRequest
  ///</summary>
  if (!(this instanceof Sdk.CanBeReferencedResponse)) {
   return new Sdk.CanBeReferencedResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _canBeReferenced = null;

  // Internal property setter functions

  function _setCanBeReferenced(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='CanBeReferenced']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _canBeReferenced = (Sdk.Xml.getNodeText(valueNode) == "true") ? true : false;
   }
  }
  //Public Methods to retrieve properties
  this.getCanBeReferenced = function () {
   ///<summary>
   /// Gets the result of the request to see whether the entity can be the primary entity (one) in a one-to-many relationship. 
   ///</summary>
   ///<returns type="Boolean">
   /// The result of the request to see whether the entity can be the primary entity (one) in a one-to-many relationship. 
   ///</returns>
   return _canBeReferenced;
  }

  //Set property values from responseXml constructor parameter
  _setCanBeReferenced(responseXml);
 }
 this.CanBeReferencedResponse.__class = true;
}).call(Sdk)

Sdk.CanBeReferencedRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CanBeReferencedResponse.prototype = new Sdk.OrganizationResponse();
