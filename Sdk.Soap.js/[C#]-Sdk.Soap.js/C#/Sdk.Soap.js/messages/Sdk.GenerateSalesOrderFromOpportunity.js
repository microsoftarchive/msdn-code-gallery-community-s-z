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
 this.GenerateSalesOrderFromOpportunityRequest = function (opportunityId, columnSet) {
  ///<summary>
  /// Contains the data that is needed to generate a sales order (order) from an opportunity. 
  ///</summary>
  ///<param name="opportunityId"  type="String">
  /// Sets the ID of the opportunity to be used as the basis for the new sales order (order). Required. 
  ///</param>
  ///<param name="columnSet"  type="Sdk.ColumnSet">
  /// Sets the collection of attributes to retrieve from the resulting sales order (order). Required. 
  ///</param>
  if (!(this instanceof Sdk.GenerateSalesOrderFromOpportunityRequest)) {
   return new Sdk.GenerateSalesOrderFromOpportunityRequest(opportunityId, columnSet);
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
    throw new Error("Sdk.GenerateSalesOrderFromOpportunityRequest OpportunityId property is required and must be a String.")
   }
  }

  function _setValidColumnSet(value) {
   if (value instanceof Sdk.ColumnSet) {
    _columnSet = value;
   }
   else {
    throw new Error("Sdk.GenerateSalesOrderFromOpportunityRequest ColumnSet property is required and must be a Sdk.ColumnSet.")
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
           "<a:RequestName>GenerateSalesOrderFromOpportunity</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.GenerateSalesOrderFromOpportunityResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setOpportunityId = function (value) {
   ///<summary>
   /// Sets the ID of the opportunity to be used as the basis for the new sales order (order). Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the opportunity to be used as the basis for the new sales order (order). 
   ///</param>
   _setValidOpportunityId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setColumnSet = function (value) {
   ///<summary>
   /// Sets the collection of attributes to retrieve from the resulting sales order (order). Required. 
   ///</summary>
   ///<param name="value" type="Sdk.ColumnSet">
   /// The collection of attributes to retrieve from the resulting sales order (order). 
   ///</param>
   _setValidColumnSet(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.GenerateSalesOrderFromOpportunityRequest.__class = true;

 this.GenerateSalesOrderFromOpportunityResponse = function (responseXml) {
  ///<summary>
  /// Response to GenerateSalesOrderFromOpportunityRequest
  ///</summary>
  if (!(this instanceof Sdk.GenerateSalesOrderFromOpportunityResponse)) {
   return new Sdk.GenerateSalesOrderFromOpportunityResponse(responseXml);
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
   /// Gets the resulting sales order (order). 
   ///</summary>
   ///<returns type="Sdk.Entity">
   /// The resulting sales order (order). 
   ///</returns>
   return _entity;
  }

  //Set property values from responseXml constructor parameter
  _setEntity(responseXml);
 }
 this.GenerateSalesOrderFromOpportunityResponse.__class = true;
}).call(Sdk)

Sdk.GenerateSalesOrderFromOpportunityRequest.prototype = new Sdk.OrganizationRequest();
Sdk.GenerateSalesOrderFromOpportunityResponse.prototype = new Sdk.OrganizationResponse();
