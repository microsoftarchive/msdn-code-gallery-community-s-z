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
 this.CreateRequest = function (target) {
  ///<summary>
  ///  Request to save record
  ///</summary>
  ///<param name="target"  type="Sdk.Entity">
  /// Sets an instance of an entity that you can use to create a new record. Required. 
  ///</param>
  if (!(this instanceof Sdk.CreateRequest)) {
   return new Sdk.CreateRequest(target);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.Entity) {
    _target = value;
   }
   else {
    throw new Error("Sdk.CreateRequest Target property is required and must be a Sdk.Entity.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Target</b:key>",
              (_target == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:Entity\">",
               _target.toValueXml("create"), //This is what makes this message special
               "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>Create</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CreateResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets an instance of an entity that you can use to create a new record. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// An instance of an entity that you can use to create a new record.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CreateRequest.__class = true;

 this.CreateResponse = function (responseXml) {
  ///<summary>
  /// Response to CreateRequest
  ///</summary>
  if (!(this instanceof Sdk.CreateResponse)) {
   return new Sdk.CreateResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _id = null;

  // Internal property setter functions

  function _setId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='id']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _id = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getId = function () {
   ///<summary>
   /// Gets the ID of the newly created record. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the newly created record. 
   ///</returns>
   return _id;
  }

  //Set property values from responseXml constructor parameter
  _setId(responseXml);
 }
 this.CreateResponse.__class = true;
}).call(Sdk)

Sdk.CreateRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CreateResponse.prototype = new Sdk.OrganizationResponse();
