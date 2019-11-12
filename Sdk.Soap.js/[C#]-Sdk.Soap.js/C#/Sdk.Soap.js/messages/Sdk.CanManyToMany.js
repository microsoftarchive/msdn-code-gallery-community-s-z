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
 this.CanManyToManyRequest = function (entityName) {
  ///<summary>
  /// Contains the data that is needed to check whether an entity can participate in a many-to-many relationship. 
  ///</summary>
  ///<param name="entityName"  type="String">
  /// Sets the logical entity name. Required 
  ///</param>
  if (!(this instanceof Sdk.CanManyToManyRequest)) {
   return new Sdk.CanManyToManyRequest(entityName);
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
    throw new Error("Sdk.CanManyToManyRequest EntityName property is required and must be a String.")
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
           "<a:RequestName>CanManyToMany</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CanManyToManyResponse);
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
 this.CanManyToManyRequest.__class = true;

 this.CanManyToManyResponse = function (responseXml) {
  ///<summary>
  /// Response to CanManyToManyRequest
  ///</summary>
  if (!(this instanceof Sdk.CanManyToManyResponse)) {
   return new Sdk.CanManyToManyResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _canManyToMany = null;

  // Internal property setter functions

  function _setCanManyToMany(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='CanManyToMany']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _canManyToMany = (Sdk.Xml.getNodeText(valueNode) == "true") ? true : false;
   }
  }
  //Public Methods to retrieve properties
  this.getCanManyToMany = function () {
   ///<summary>
   /// Gets the result of the request to see whether the entity can participate in a many-to-many relationship. 
   ///</summary>
   ///<returns type="Boolean">
   /// The result of the request to see whether the entity can participate in a many-to-many relationship. 
   ///</returns>
   return _canManyToMany;
  }

  //Set property values from responseXml constructor parameter
  _setCanManyToMany(responseXml);
 }
 this.CanManyToManyResponse.__class = true;
}).call(Sdk)

Sdk.CanManyToManyRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CanManyToManyResponse.prototype = new Sdk.OrganizationResponse();
