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
 this.MergeRequest = function (target, subordinateId, updateContent, performParentingChecks) {
  ///<summary>
  /// Contains the data that is needed to  merge the information from two entity records of the same type.
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target of the merge operation. Required.
  ///</param>
  ///<param name="subordinateId"  type="String">
  /// Sets the ID of the entity record from which to merge data. Required.
  ///</param>
  ///<param name="updateContent"  type="Sdk.Entity">
  /// Sets additional entity attributes to be set during the merge operation. Optional.
  ///</param>
  ///<param name="performParentingChecks"  type="Boolean">
  /// Sets a value that indicates whether to check if the parent information is different for the two entity records. Required.
  ///</param>
  if (!(this instanceof Sdk.MergeRequest)) {
   return new Sdk.MergeRequest(target, subordinateId, updateContent, performParentingChecks);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _subordinateId = null;
  var _updateContent = null;
  var _performParentingChecks = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.EntityReference) {
    _target = value;
   }
   else {
    throw new Error("Sdk.MergeRequest Target property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidSubordinateId(value) {
   if (Sdk.Util.isGuid(value)) {
    _subordinateId = value;
   }
   else {
    throw new Error("Sdk.MergeRequest SubordinateId property is required and must be a String.")
   }
  }

  function _setValidUpdateContent(value) {
   if (value instanceof Sdk.Entity) {
    _updateContent = value;
   }
   else {
    throw new Error("Sdk.MergeRequest UpdateContent property is required and must be a Sdk.Entity.")
   }
  }

  function _setValidPerformParentingChecks(value) {
   if (typeof value == "boolean") {
    _performParentingChecks = value;
   }
   else {
    throw new Error("Sdk.MergeRequest PerformParentingChecks property is required and must be a Boolean.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof subordinateId != "undefined") {
   _setValidSubordinateId(subordinateId);
  }
  if (typeof updateContent != "undefined") {
   _setValidUpdateContent(updateContent);
  }
  if (typeof performParentingChecks != "undefined") {
   _setValidPerformParentingChecks(performParentingChecks);
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
               "<b:key>SubordinateId</b:key>",
              (_subordinateId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _subordinateId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>UpdateContent</b:key>",
              (_updateContent == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:Entity\">", _updateContent.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>PerformParentingChecks</b:key>",
              (_performParentingChecks == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _performParentingChecks, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>Merge</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.MergeResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target of the merge operation. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target of the merge operation.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSubordinateId = function (value) {
   ///<summary>
   /// Sets the ID of the entity record from which to merge data. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the entity record from which to merge data.
   ///</param>
   _setValidSubordinateId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setUpdateContent = function (value) {
   ///<summary>
   /// Sets additional entity attributes to be set during the merge operation. Optional.
   ///</summary>
   ///<param name="value" type="Sdk.Entity">
   /// Additional entity attributes to be set during the merge operation. Optional.
   ///</param>
   _setValidUpdateContent(value);
   this.setRequestXml(getRequestXml());
  }

  this.setPerformParentingChecks = function (value) {
   ///<summary>
   /// Sets a value that indicates whether to check if the parent information is different for the two entity records. Required.
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether to check if the parent information is different for the two entity records.
   ///</param>
   _setValidPerformParentingChecks(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.MergeRequest.__class = true;

 this.MergeResponse = function (responseXml) {
  ///<summary>
  /// Response to MergeRequest
  ///</summary>
  if (!(this instanceof Sdk.MergeResponse)) {
   return new Sdk.MergeResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.MergeResponse.__class = true;
}).call(Sdk)

Sdk.MergeRequest.prototype = new Sdk.OrganizationRequest();
Sdk.MergeResponse.prototype = new Sdk.OrganizationResponse();
