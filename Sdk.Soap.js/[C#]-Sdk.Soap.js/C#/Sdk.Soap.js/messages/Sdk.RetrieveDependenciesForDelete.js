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
 this.RetrieveDependenciesForDeleteRequest = function (objectId, componentType) {
  ///<summary>
  /// Contains the data that is needed to  retrieve a collection of dependency records that describe any solution components that would prevent a solution component from being deleted. 
  ///</summary>
  ///<param name="objectId"  type="String">
  /// Sets the ID of the solution component that you want to delete. Required.
  ///</param>
  ///<param name="componentType"  type="Number">
  /// Sets the value for the component type that you want to delete. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveDependenciesForDeleteRequest)) {
   return new Sdk.RetrieveDependenciesForDeleteRequest(objectId, componentType);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _objectId = null;
  var _componentType = null;

  // internal validation functions

  function _setValidObjectId(value) {
   if (Sdk.Util.isGuid(value)) {
    _objectId = value;
   }
   else {
    throw new Error("Sdk.RetrieveDependenciesForDeleteRequest ObjectId property is required and must be a String.")
   }
  }

  function _setValidComponentType(value) {
   if (typeof value == "number") {
    _componentType = value;
   }
   else {
    throw new Error("Sdk.RetrieveDependenciesForDeleteRequest ComponentType property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof objectId != "undefined") {
   _setValidObjectId(objectId);
  }
  if (typeof componentType != "undefined") {
   _setValidComponentType(componentType);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ObjectId</b:key>",
              (_objectId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _objectId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ComponentType</b:key>",
              (_componentType == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _componentType, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveDependenciesForDelete</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveDependenciesForDeleteResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setObjectId = function (value) {
   ///<summary>
   /// Sets the ID of the solution component that you want to delete. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the solution component that you want to delete.
   ///</param>
   _setValidObjectId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setComponentType = function (value) {
   ///<summary>
   /// Sets the value for the component type that you want to delete. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The value for the component type that you want to delete.
   ///</param>
   _setValidComponentType(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveDependenciesForDeleteRequest.__class = true;

 this.RetrieveDependenciesForDeleteResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveDependenciesForDeleteRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveDependenciesForDeleteResponse)) {
   return new Sdk.RetrieveDependenciesForDeleteResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _entityCollection = null;

  // Internal property setter functions

  function _setEntityCollection(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='EntityCollection']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _entityCollection = Sdk.Util.createEntityCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEntityCollection = function () {
   ///<summary>
   /// Gets a collection of Dependency records where the DependentComponentObjectId and DependentComponentType attributes represent those components that can prevent the solution component from being deleted.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// A collection of Dependency records where the DependentComponentObjectId and DependentComponentType attributes represent those components that can prevent the solution component from being deleted.
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.RetrieveDependenciesForDeleteResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveDependenciesForDeleteRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveDependenciesForDeleteResponse.prototype = new Sdk.OrganizationResponse();
