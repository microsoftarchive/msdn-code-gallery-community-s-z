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
 this.ValidateRecurrenceRuleRequest = function (target) {
  ///<summary>
  /// Contains the data that is needed to  validate a rule for a recurring appointment.
  ///</summary>
  ///<param name="target"  type="Sdk.Entity">
  /// Sets the recurrence rule record to validate.
  ///</param>
  if (!(this instanceof Sdk.ValidateRecurrenceRuleRequest)) {
   return new Sdk.ValidateRecurrenceRuleRequest(target);
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
    throw new Error("Sdk.ValidateRecurrenceRuleRequest Target property is required and must be a Sdk.Entity.")
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
              ["<b:value i:type=\"a:Entity\">", _target.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ValidateRecurrenceRule</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ValidateRecurrenceRuleResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the recurrence rule record to validate.
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// The recurrence rule record to validate.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ValidateRecurrenceRuleRequest.__class = true;

 this.ValidateRecurrenceRuleResponse = function (responseXml) {
  ///<summary>
  /// Response to ValidateRecurrenceRuleRequest
  ///</summary>
  if (!(this instanceof Sdk.ValidateRecurrenceRuleResponse)) {
   return new Sdk.ValidateRecurrenceRuleResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _description = null;

  // Internal property setter functions

  function _setDescription(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Description']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _description = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getDescription = function () {
   ///<summary>
   /// Gets the description.
   ///</summary>
   ///<returns type="String">
   /// The description.
   ///</returns>
   return _description;
  }

  //Set property values from responseXml constructor parameter
  _setDescription(responseXml);
 }
 this.ValidateRecurrenceRuleResponse.__class = true;
}).call(Sdk)

Sdk.ValidateRecurrenceRuleRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ValidateRecurrenceRuleResponse.prototype = new Sdk.OrganizationResponse();
