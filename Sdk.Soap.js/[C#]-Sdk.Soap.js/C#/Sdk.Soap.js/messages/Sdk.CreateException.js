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
 this.CreateExceptionRequest = function (target, originalStartDate, isDeleted) {
  ///<summary>
  /// Contains the data that is needed to create an exception for the recurring appointment instance. 
  ///</summary>
  ///<param name="target"  type="Sdk.Entity">
  /// Sets the target appointment for the exception. 
  ///</param>
  ///<param name="originalStartDate"  type="Date">
  /// Sets the original start date of the recurring appointment. 
  ///</param>
  ///<param name="isDeleted"  type="Boolean">
  /// Sets whether the appointment instance is deleted. 
  ///</param>
  if (!(this instanceof Sdk.CreateExceptionRequest)) {
   return new Sdk.CreateExceptionRequest(target, originalStartDate, isDeleted);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _originalStartDate = null;
  var _isDeleted = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.Entity) {
    _target = value;
   }
   else {
    throw new Error("Sdk.CreateExceptionRequest Target property is required and must be a Sdk.Entity.")
   }
  }

  function _setValidOriginalStartDate(value) {
   if (value instanceof Date) {
    _originalStartDate = value;
   }
   else {
    throw new Error("Sdk.CreateExceptionRequest OriginalStartDate property is required and must be a Date.")
   }
  }

  function _setValidIsDeleted(value) {
   if (typeof value == "boolean") {
    _isDeleted = value;
   }
   else {
    throw new Error("Sdk.CreateExceptionRequest IsDeleted property is required and must be a Boolean.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof originalStartDate != "undefined") {
   _setValidOriginalStartDate(originalStartDate);
  }
  if (typeof isDeleted != "undefined") {
   _setValidIsDeleted(isDeleted);
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
               "<b:key>OriginalStartDate</b:key>",
              (_originalStartDate == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:dateTime\">", _originalStartDate.toISOString(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>IsDeleted</b:key>",
              (_isDeleted == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _isDeleted, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>CreateException</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.CreateExceptionResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target appointment for the exception. 
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The target appointment for the exception.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setOriginalStartDate = function (value) {
   ///<summary>
   /// Sets the original start date of the recurring appointment. 
   ///</summary>
   ///<param name="value" type="Date">
   /// The original start date of the recurring appointment. 
   ///</param>
   _setValidOriginalStartDate(value);
   this.setRequestXml(getRequestXml());
  }

  this.setIsDeleted = function (value) {
   ///<summary>
   /// Sets whether the appointment instance is deleted. 
   ///</summary>
   ///<param name="value" type="Boolean">
   /// Whether the appointment instance is deleted. 
   ///</param>
   _setValidIsDeleted(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.CreateExceptionRequest.__class = true;

 this.CreateExceptionResponse = function (responseXml) {
  ///<summary>
  /// Response to CreateExceptionRequest
  ///</summary>
  if (!(this instanceof Sdk.CreateExceptionResponse)) {
   return new Sdk.CreateExceptionResponse(responseXml);
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
   /// Gets the ID of the exception appointment. 
   ///</summary>
   ///<returns type="String">
   /// The ID of the exception appointment. 
   ///</returns>
   return _id;
  }

  //Set property values from responseXml constructor parameter
  _setId(responseXml);
 }
 this.CreateExceptionResponse.__class = true;
}).call(Sdk)

Sdk.CreateExceptionRequest.prototype = new Sdk.OrganizationRequest();
Sdk.CreateExceptionResponse.prototype = new Sdk.OrganizationResponse();
