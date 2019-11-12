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
 this.AssignRequest = function (target,assignee) {
  ///<summary>
  /// Contains the data that is needed to assign the specified record to a new owner (user or team) by changing the OwnerId attribute of the record. 
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target record to assign to another user or team. 
  ///</param>
  ///<param name="assignee"  type="Sdk.EntityReference">
  /// Sets the user or team for which you want to assign a record.
  ///</param>
  if (!(this instanceof Sdk.AssignRequest)) {
   return new Sdk.AssignRequest(target, assignee);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _assignee = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.EntityReference) {
    _target = value;
   }
   else {
    throw new Error("Sdk.AssignRequest Target property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidAssignee(value) {
   if (value instanceof Sdk.EntityReference) {
    _assignee = value;
   }
   else {
    throw new Error("Sdk.AssignRequest Assignee property is required and must be a Sdk.EntityReference.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof assignee != "undefined") {
   _setValidAssignee(assignee);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Target</b:key>",
              (_target == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _target.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Assignee</b:key>",
              (_assignee == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _assignee.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>Assign</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.AssignResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target record to assign to another user or team. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target record to assign to another user or team.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setAssignee = function (value) {
   ///<summary>
   /// Sets the user or team for which you want to assign a record. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The user or team for which you want to assign a record.
   ///</param>
   _setValidAssignee(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.AssignRequest.__class = true;

 this.AssignResponse = function (responseXml) {
  ///<summary>
  /// Response to AssignRequest
  ///</summary>
  if (!(this instanceof Sdk.AssignResponse)) {
   return new Sdk.AssignResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.AssignResponse.__class = true;
}).call(Sdk)

Sdk.AssignRequest.prototype = new Sdk.OrganizationRequest();
Sdk.AssignResponse.prototype = new Sdk.OrganizationResponse();
