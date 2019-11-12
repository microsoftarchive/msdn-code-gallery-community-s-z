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
 this.UnpublishDuplicateRuleRequest = function (duplicateRuleId) {
  ///<summary>
  /// Contains the data that is needed to  submit an asynchronous job to unpublish a duplicate rule.
  ///</summary>
  ///<param name="duplicateRuleId"  type="String">
  /// Sets the ID of the duplicate rule to be unpublished. Required.
  ///</param>
  if (!(this instanceof Sdk.UnpublishDuplicateRuleRequest)) {
   return new Sdk.UnpublishDuplicateRuleRequest(duplicateRuleId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _duplicateRuleId = null;

  // internal validation functions

  function _setValidDuplicateRuleId(value) {
   if (Sdk.Util.isGuid(value)) {
    _duplicateRuleId = value;
   }
   else {
    throw new Error("Sdk.UnpublishDuplicateRuleRequest DuplicateRuleId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof duplicateRuleId != "undefined") {
   _setValidDuplicateRuleId(duplicateRuleId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>DuplicateRuleId</b:key>",
              (_duplicateRuleId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _duplicateRuleId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>UnpublishDuplicateRule</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.UnpublishDuplicateRuleResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setDuplicateRuleId = function (value) {
   ///<summary>
   /// Sets the ID of the duplicate rule to be unpublished. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the duplicate rule to be unpublished.
   ///</param>
   _setValidDuplicateRuleId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.UnpublishDuplicateRuleRequest.__class = true;

 this.UnpublishDuplicateRuleResponse = function (responseXml) {
  ///<summary>
  /// Response to UnpublishDuplicateRuleRequest
  ///</summary>
  if (!(this instanceof Sdk.UnpublishDuplicateRuleResponse)) {
   return new Sdk.UnpublishDuplicateRuleResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.UnpublishDuplicateRuleResponse.__class = true;
}).call(Sdk)

Sdk.UnpublishDuplicateRuleRequest.prototype = new Sdk.OrganizationRequest();
Sdk.UnpublishDuplicateRuleResponse.prototype = new Sdk.OrganizationResponse();
