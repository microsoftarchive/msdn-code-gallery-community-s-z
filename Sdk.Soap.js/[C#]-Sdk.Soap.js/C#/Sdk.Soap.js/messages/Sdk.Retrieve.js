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
 this.RetrieveRequest = function (target, columnSet, relatedEntitiesQuery, returnNotifications) {
  ///<summary>
  /// Contains the data that is needed to retrieve a record. 
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target, which is the record to be retrieved. Required. 
  ///</param>
  ///<param name="columnSet"  type="Sdk.ColumnSet">
  /// Sets the collection of attributes for which non-null values are returned from a query. Required. 
  ///</param>
  ///<param name="relatedEntitiesQuery" optional="true" type="Sdk.RelationshipQueryCollection">
  /// Sets the query that describes the related records to be retrieved. Optional. 
  ///</param>
  ///<param name="returnNotifications" optional="true" type="Boolean">
  /// [Add Description]
  ///</param>
  if (!(this instanceof Sdk.RetrieveRequest)) {
   return new Sdk.RetrieveRequest(target, columnSet, relatedEntitiesQuery, returnNotifications);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _columnSet = null;
  var _relatedEntitiesQuery = null;
  var _returnNotifications = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.EntityReference) {
    _target = value;
   }
   else {
    throw new Error("Sdk.RetrieveRequest Target property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidColumnSet(value) {
   if (value instanceof Sdk.ColumnSet) {
    _columnSet = value;
   }
   else {
    throw new Error("Sdk.RetrieveRequest ColumnSet property is required and must be a Sdk.ColumnSet.")
   }
  }

  function _setValidRelatedEntitiesQuery(value) {
   if (value == null || value instanceof Sdk.RelationshipQueryCollection) {
    _relatedEntitiesQuery = value;
   }
   else {
    throw new Error("Sdk.RetrieveRequest RelatedEntitiesQuery property must be a Sdk.RelationshipQueryCollection or null.")
   }
  }

  function _setValidReturnNotifications(value) {
   if (value == null || typeof value == "boolean") {
    _returnNotifications = value;
   }
   else {
    throw new Error("Sdk.RetrieveRequest ReturnNotifications property must be a Boolean or null.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof columnSet != "undefined") {
   _setValidColumnSet(columnSet);
  }
  if (typeof relatedEntitiesQuery != "undefined") {
   _setValidRelatedEntitiesQuery(relatedEntitiesQuery);
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
              ["<b:value i:type=\"a:EntityReference\">", _target.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ColumnSet</b:key>",
              (_columnSet == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:ColumnSet\">", _columnSet.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>RelatedEntitiesQuery</b:key>",
              (_relatedEntitiesQuery == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:RelationshipQueryCollection\">", _relatedEntitiesQuery.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ReturnNotifications</b:key>",
              (_returnNotifications == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _returnNotifications, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>Retrieve</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target, which is the record to be retrieved. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target, which is the record to be retrieved. 
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setColumnSet = function (value) {
   ///<summary>
   /// Sets the collection of attributes for which non-null values are returned from a query. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.ColumnSet">
   /// The collection of attributes for which non-null values are returned from a query. 
   ///</param>
   _setValidColumnSet(value);
   this.setRequestXml(getRequestXml());
  }

  this.setRelatedEntitiesQuery = function (value) {
   ///<summary>
   /// Sets the query that describes the related records to be retrieved. Optional. 
   ///</summary>
   ///<param name="value" type="Sdk.RelationshipQueryCollection">
   /// The query that describes the related records to be retrieved. 
   ///</param>
   _setValidRelatedEntitiesQuery(value);
   this.setRequestXml(getRequestXml());
  }

  this.setReturnNotifications = function (value) {
   ///<summary>
   /// [Add Description]
   ///</summary>
   ///<param name="value" type="Boolean">
   /// [Add Description]
   ///</param>
   _setValidReturnNotifications(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveRequest.__class = true;

 this.RetrieveResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveResponse)) {
   return new Sdk.RetrieveResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _entity = null;
  var _notifications = null;

  // Internal property setter functions

  function _setEntity(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Entity']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _entity = Sdk.Util.createEntityFromNode(valueNode);
   }
  }
  function _setNotifications(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Notifications']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _notifications = valueNode;
   }
  }
  //Public Methods to retrieve properties
  this.getEntity = function () {
   ///<summary>
   /// Gets the specified record from the request. 
   ///</summary>
   ///<returns type="Sdk.Entity">
   /// The specified record from the request. 
   ///</returns>
   return _entity;
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
  _setEntity(responseXml);
  _setNotifications(responseXml);
 }
 this.RetrieveResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveResponse.prototype = new Sdk.OrganizationResponse();
