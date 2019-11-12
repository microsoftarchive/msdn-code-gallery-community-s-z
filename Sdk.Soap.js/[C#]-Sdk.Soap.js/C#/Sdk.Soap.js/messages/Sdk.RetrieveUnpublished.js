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
 this.RetrieveUnpublishedRequest = function (target, columnSet) {
  ///<summary>
  /// Contains the data that is needed to  retrieve an unpublished record. 
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target record for the operation. Required.
  ///</param>
  ///<param name="columnSet"  type="Sdk.ColumnSet">
  /// Sets the collection of attributes for which non-null values are returned from a query. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveUnpublishedRequest)) {
   return new Sdk.RetrieveUnpublishedRequest(target, columnSet);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;
  var _columnSet = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.EntityReference) {
    _target = value;
   }
   else {
    throw new Error("Sdk.RetrieveUnpublishedRequest Target property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidColumnSet(value) {
   if (value instanceof Sdk.ColumnSet) {
    _columnSet = value;
   }
   else {
    throw new Error("Sdk.RetrieveUnpublishedRequest ColumnSet property is required and must be a Sdk.ColumnSet.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof columnSet != "undefined") {
   _setValidColumnSet(columnSet);
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

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveUnpublished</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveUnpublishedResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target record for the operation. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target record for the operation.
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

 }
 this.RetrieveUnpublishedRequest.__class = true;

 this.RetrieveUnpublishedResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveUnpublishedRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveUnpublishedResponse)) {
   return new Sdk.RetrieveUnpublishedResponse(responseXml);
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
   /// Gets the unpublished record that is specified in the request.
   ///</summary>
   ///<returns type="Sdk.Entity">
   /// The unpublished record that is specified in the request.
   ///</returns>
   return _entity;
  }

  //Set property values from responseXml constructor parameter
  _setEntity(responseXml);
 }
 this.RetrieveUnpublishedResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveUnpublishedRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveUnpublishedResponse.prototype = new Sdk.OrganizationResponse();
