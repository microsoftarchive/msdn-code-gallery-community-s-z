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
 this.BookRequest = function (target, returnNotifications) {
  ///<summary>
  /// Contains the data that is needed to schedule or “book” an appointment, recurring appointment, or service appointment (service activity). 
  ///</summary>
  ///<param name="target"  type="Sdk.Entity">
  /// Sets the record that is the target of the book operation.
  ///</param>
  ///<param name="returnNotifications" optional="true" type="Boolean">
  /// Internal use only
  ///</param>
  if (!(this instanceof Sdk.BookRequest)) {
   return new Sdk.BookRequest(target, returnNotifications);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _returnNotifications = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.Entity) {
    _target = value;
   }
   else {
    throw new Error("Sdk.BookRequest Target property is required and must be a Sdk.Entity.")
   }
  }

  function _setValidReturnNotifications(value) {
   if (value == null || typeof value == "boolean") {
    _returnNotifications = value;
   }
   else {
    throw new Error("Sdk.BookRequest ReturnNotifications property must be a Boolean or null.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof returnNotifications != "undefined") {
   _setValidReturnNotifications(returnNotifications);
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
               "<b:key>ReturnNotifications</b:key>",
              (_returnNotifications == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _returnNotifications, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>Book</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.BookResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the record that is the target of the book operation. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The record that is the target of the book operation.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setReturnNotifications = function (value) {
   ///<summary>
   /// Internal use only.
   ///</summary>
   ///<param name="value" type="Boolean" />
   _setValidReturnNotifications(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.BookRequest.__class = true;

 this.BookResponse = function (responseXml) {
  ///<summary>
  /// Response to BookRequest
  ///</summary>
  if (!(this instanceof Sdk.BookResponse)) {
   return new Sdk.BookResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _validationResult = null;
  var _notifications = null;

  // Internal property setter functions

  function _setValidationResult(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='ValidationResult']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _validationResult = Sdk.Util.createValidationResultFromNode(valueNode);
   }
  }
  function _setNotifications(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Notifications']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _notifications = valueNode;
   }
  }
  //Public Methods to retrieve properties
  this.getValidationResult = function () {
   ///<summary>
   /// [Add Description]
   ///</summary>
   ///<returns type="Sdk.ValidationResult">
   /// [Add Description]
   ///</returns>
   return _validationResult;
  }
  this.getNotifications = function () {
   ///<summary>
   /// [Add Description]
   ///</summary>
   ///<returns type="XML">
   /// [Add Description]
   ///</returns>
   return _notifications;
  }

  //Set property values from responseXml constructor parameter
  _setValidationResult(responseXml);
  _setNotifications(responseXml);
 }
 this.BookResponse.__class = true;
}).call(Sdk)

Sdk.BookRequest.prototype = new Sdk.OrganizationRequest();
Sdk.BookResponse.prototype = new Sdk.OrganizationResponse();
