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
 this.RollupRequest = function (target, query, rollupType) {
  ///<summary>
  /// Contains the data that is needed to  retrieve all the entity records that are related to the specified record. 
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target record for the rollup operation. Required.
  ///</param>
  ///<param name="query"  type="Sdk.QueryBase">
  /// Sets the query criteria for the rollup operation. Required.
  ///</param>
  ///<param name="rollupType"  type="Sdk.RollupType">
  /// Sets the rollup type. Required.
  ///</param>
  if (!(this instanceof Sdk.RollupRequest)) {
   return new Sdk.RollupRequest(target, query, rollupType);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _query = null;
  var _rollupType = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.EntityReference) {
    _target = value;
   }
   else {
    throw new Error("Sdk.RollupRequest Target property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidQuery(value) {
   if (value instanceof Sdk.Query.QueryBase) {
    _query = value;
   }
   else {
    throw new Error("Sdk.RollupRequest Query property is required and must be a Sdk.QueryBase.")
   }
  }

  function _setValidRollupType(value) {
   if ((typeof value == "string") && (value == "Extended" || value == "None" || value == "Related")) {
    _rollupType = value;
   }
   else {
    throw new Error("Sdk.RollupRequest RollupType property is required and must be a Sdk.RollupType.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof query != "undefined") {
   _setValidQuery(query);
  }
  if (typeof rollupType != "undefined") {
   _setValidRollupType(rollupType);
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
               "<b:key>Query</b:key>",
              (_query == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:" + _query.getQueryType() + "\">", _query.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>RollupType</b:key>",
              (_rollupType == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"g:RollupType\">", _rollupType, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>Rollup</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RollupResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target record for the rollup operation. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target record for the rollup operation.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setQuery = function (value) {
   ///<summary>
   /// Sets the query criteria for the rollup operation. Required.
   ///</summary>
   ///<param name="value" type="Sdk.QueryBase">
   /// The query criteria for the rollup operation.
   ///</param>
   _setValidQuery(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRollupType = function (value) {
   ///<summary>
   /// Sets the rollup type. Required.
   ///</summary>
   ///<param name="value" type="Sdk.RollupType">
   /// The rollup type.
   ///</param>
   _setValidRollupType(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RollupRequest.__class = true;

 this.RollupResponse = function (responseXml) {
  ///<summary>
  /// Response to RollupRequest
  ///</summary>
  if (!(this instanceof Sdk.RollupResponse)) {
   return new Sdk.RollupResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _entityCollection = null;

  // Internal property setter functions

  function _setEntityCollection(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='EntityCollection']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _entityCollection = Sdk.Util.createEntityCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEntityCollection = function () {
   ///<summary>
   /// Gets the collection of records that are related to the specified record.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The collection of records that are related to the specified record.
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.RollupResponse.__class = true;
}).call(Sdk)

Sdk.RollupRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RollupResponse.prototype = new Sdk.OrganizationResponse();
