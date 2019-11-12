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
 this.RetrieveByResourcesServiceRequest = function (resourceIds, query) {
  ///<summary>
  /// Contains the data that is needed to retrieve the collection of services that are related to the specified set of resources.
  ///</summary>
  ///<param name="resourceIds"  type="Sdk.Collection">
  /// Sets an array of IDs for the specified set of services.
  ///</param>
  ///<param name="query"  type="Sdk.QueryBase">
  /// Sets the query for the operation.
  ///</param>
  if (!(this instanceof Sdk.RetrieveByResourcesServiceRequest)) {
   return new Sdk.RetrieveByResourcesServiceRequest(resourceIds, query);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _resourceIds = null;
  var _query = null;

  // internal validation functions

  function _setValidResourceIds(value) {
   if (Sdk.Util.isCollectionOf(value, String)) {
    _resourceIds = value;
   }
   else {
    throw new Error("Sdk.RetrieveByResourcesServiceRequest ResourceIds property is required and must be a Sdk.Collection.")
   }
  }

  function _setValidQuery(value) {
   if (value instanceof Sdk.Query.QueryBase) {
    _query = value;
   }
   else {
    throw new Error("Sdk.RetrieveByResourcesServiceRequest Query property is required and must be a Sdk.QueryBase.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof resourceIds != "undefined") {
   _setValidResourceIds(resourceIds);
  }
  if (typeof query != "undefined") {
   _setValidQuery(query);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ResourceIds</b:key>",
              (_resourceIds == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"f:ArrayOfguid\">", _resourceIds.toArrayOfValueXml("f:guid"), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Query</b:key>",
              (_query == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:" + _query.getQueryType() + "\">", _query.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveByResourcesService</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveByResourcesServiceResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setResourceIds = function (value) {
   ///<summary>
   /// Sets an array of IDs for the specified set of services.
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// A collection of IDs for the specified set of services.
   ///</param>
   _setValidResourceIds(value);
   this.setRequestXml(getRequestXml());
  }

  this.setQuery = function (value) {
   ///<summary>
   /// Sets the query for the operation.
   ///</summary>
   ///<param name="value" type="Sdk.QueryBase">
   /// The query for the operation.
   ///</param>
   _setValidQuery(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveByResourcesServiceRequest.__class = true;

 this.RetrieveByResourcesServiceResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveByResourcesServiceRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveByResourcesServiceResponse)) {
   return new Sdk.RetrieveByResourcesServiceResponse(responseXml);
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
   /// Gets the resulting collection of all related services for the specified set of services.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The resulting collection of all related services for the specified set of services.
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.RetrieveByResourcesServiceResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveByResourcesServiceRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveByResourcesServiceResponse.prototype = new Sdk.OrganizationResponse();
