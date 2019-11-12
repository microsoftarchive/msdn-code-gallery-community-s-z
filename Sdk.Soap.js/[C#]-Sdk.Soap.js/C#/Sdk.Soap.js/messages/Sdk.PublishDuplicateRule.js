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
this.PublishDuplicateRuleRequest = function (duplicateRuleId){
///<summary>
/// Contains the data that is needed to  submit an asynchronous job to publish a duplicate rule.
///</summary>
///<param name="duplicateRuleId"  type="String">
/// Sets the ID of the duplicate rule to be published. Required.
///</param>
if (!(this instanceof Sdk.PublishDuplicateRuleRequest)) {
return new Sdk.PublishDuplicateRuleRequest(duplicateRuleId);
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
  throw new Error("Sdk.PublishDuplicateRuleRequest DuplicateRuleId property is required and must be a String.")
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
        "<a:RequestName>PublishDuplicateRule</a:RequestName>",
      "</d:request>"].join("");
  }

  this.setResponseType(Sdk.PublishDuplicateRuleResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setDuplicateRuleId = function (value) {
  ///<summary>
  /// Sets the ID of the duplicate rule to be published. Required.
  ///</summary>
  ///<param name="value" type="String">
  /// The ID of the duplicate rule to be published. Required.
  ///</param>
   _setValidDuplicateRuleId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.PublishDuplicateRuleRequest.__class = true;

this.PublishDuplicateRuleResponse = function (responseXml) {
  ///<summary>
  /// Response to PublishDuplicateRuleRequest
  ///</summary>
  if (!(this instanceof Sdk.PublishDuplicateRuleResponse)) {
   return new Sdk.PublishDuplicateRuleResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _jobId = null;

  // Internal property setter functions

  function _setJobId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='JobId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _jobId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getJobId = function () {
  ///<summary>
  /// Gets the ID of the asynchronous job for publishing a duplicate detection rule.
  ///</summary>
  ///<returns type="String">
  /// The ID of the asynchronous job for publishing a duplicate detection rule.
  ///</returns>
   return _jobId;
  }

  //Set property values from responseXml constructor parameter
  _setJobId(responseXml);
 }
 this.PublishDuplicateRuleResponse.__class = true;
}).call(Sdk)

Sdk.PublishDuplicateRuleRequest.prototype = new Sdk.OrganizationRequest();
Sdk.PublishDuplicateRuleResponse.prototype = new Sdk.OrganizationResponse();
