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
this.GenerateInvoiceFromOpportunityRequest = function (
opportunityId,
columnSet
)
{
///<summary>
/// No Description set
///</summary>
///<param name="opportunityId"  type="String">
/// [Add Description]
///</param>
///<param name="columnSet"  type="Sdk.ColumnSet">
/// [Add Description]
///</param>
if (!(this instanceof Sdk.GenerateInvoiceFromOpportunityRequest)) {
return new Sdk.GenerateInvoiceFromOpportunityRequest(opportunityId, columnSet);
}
Sdk.OrganizationRequest.call(this);

  // Internal properties
var _opportunityId = null;
var _columnSet = null;

// internal validation functions

function _setValidOpportunityId(value) {
 if (Sdk.Util.isGuid(value)) {
  _opportunityId = value;
 }
 else {
  throw new Error("Sdk.GenerateInvoiceFromOpportunityRequest OpportunityId property is required and must be a String.")
 }
}

function _setValidColumnSet(value) {
 if (value instanceof Sdk.ColumnSet) {
  _columnSet = value;
 }
 else {
  throw new Error("Sdk.GenerateInvoiceFromOpportunityRequest ColumnSet property is required and must be a Sdk.ColumnSet.")
 }
}

//Set internal properties from constructor parameters
  if (typeof opportunityId != "undefined") {
   _setValidOpportunityId(opportunityId);
  }
  if (typeof columnSet != "undefined") {
   _setValidColumnSet(columnSet);
  }

  function getRequestXml() {
return ["<d:request>",
        "<a:Parameters>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>OpportunityId</b:key>",
           (_opportunityId == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"e:guid\">", _opportunityId, "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>ColumnSet</b:key>",
           (_columnSet == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"a:ColumnSet\">", _columnSet.toValueXml(), "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

        "</a:Parameters>",
        "<a:RequestId i:nil=\"true\" />",
        "<a:RequestName>GenerateInvoiceFromOpportunity</a:RequestName>",
      "</d:request>"].join("");
  }

  this.setResponseType(Sdk.GenerateInvoiceFromOpportunityResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setOpportunityId = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="String">
  /// [Add Description]
  ///</param>
   _setValidOpportunityId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setColumnSet = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="Sdk.ColumnSet">
  /// [Add Description]
  ///</param>
   _setValidColumnSet(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.GenerateInvoiceFromOpportunityRequest.__class = true;

this.GenerateInvoiceFromOpportunityResponse = function (responseXml) {
  ///<summary>
  /// Response to GenerateInvoiceFromOpportunityRequest
  ///</summary>
  if (!(this instanceof Sdk.GenerateInvoiceFromOpportunityResponse)) {
   return new Sdk.GenerateInvoiceFromOpportunityResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _entity = null;

  // Internal property setter functions

  function _setEntity(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Entity']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _entity = Sdk.Util.createEntityFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEntity = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="Sdk.Entity">
  /// [Add Description]
  ///</returns>
   return _entity;
  }

  //Set property values from responseXml constructor parameter
  _setEntity(responseXml);
 }
 this.GenerateInvoiceFromOpportunityResponse.__class = true;
}).call(Sdk)

Sdk.GenerateInvoiceFromOpportunityRequest.prototype = new Sdk.OrganizationRequest();
Sdk.GenerateInvoiceFromOpportunityResponse.prototype = new Sdk.OrganizationResponse();
