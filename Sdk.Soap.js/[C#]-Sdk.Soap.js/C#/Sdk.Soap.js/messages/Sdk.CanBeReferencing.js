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
 this.CanBeReferencingRequest = function (entityName) {
  ///<summary>
  /// Contains the data that is needed to check whether an entity can be the referencing entity in a one-to-many relationship. 
  ///</summary>
  ///<param name="entityName"  type="String">
  /// Sets the logical entity name. Required. 
  ///</param>
  if (!(this instanceof Sdk.CanBeReferencingRequest)) {
   return new Sdk.CanBeReferencingRequest(entityName);
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
    throw new Error("Sdk.CanBeReferencingRequest EntityName property is required and must be a String.")
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
           "<a:RequestName>CanBeReferencing</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CanBeReferencingResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntityName = function (value) {
   ///<summary>
   /// Sets the logical entity name. Required
   ///</summary>
   ///<param name="value" type="String">
   /// The logical entity name.
   ///</param>
   _setValidEntityName(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CanBeReferencingRequest.__class = true;

 this.CanBeReferencingResponse = function (responseXml) {
  ///<summary>
  /// Response to CanBeReferencingRequest
  ///</summary>
  if (!(this instanceof Sdk.CanBeReferencingResponse)) {
   return new Sdk.CanBeReferencingResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _canBeReferencing = null;

  // Internal property setter functions

  function _setCanBeReferencing(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='CanBeReferencing']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _canBeReferencing = (Sdk.Xml.getNodeText(valueNode) == "true") ? true : false;
   }
  }
  //Public Methods to retrieve properties
  this.getCanBeReferencing = function () {
   ///<summary>
   /// Gets the result of the request to see whether the entity can be the referencing entity (many) in a one-to-many relationship. 
   ///</summary>
   ///<returns type="Boolean">
   /// The result of the request to see whether the entity can be the referencing entity (many) in a one-to-many relationship. 
   ///</returns>
   return _canBeReferencing;
  }

  //Set property values from responseXml constructor parameter
  _setCanBeReferencing(responseXml);
 }
 this.CanBeReferencingResponse.__class = true;
}).call(Sdk)

Sdk.CanBeReferencingRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CanBeReferencingResponse.prototype = new Sdk.OrganizationResponse();
