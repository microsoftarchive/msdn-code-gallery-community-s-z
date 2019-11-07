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
 this.RetrieveByResourceResourceGroupRequest = function (resourceId, query) {
  ///<summary>
  /// Contains the data that is needed to retrieve the resource groups (scheduling groups) that contain the specified resource.
  ///</summary>
  ///<param name="resourceId"  type="String">
  /// Sets the ID of the resource.
  ///</param>
  ///<param name="query"  type="Sdk.QueryBase">
  /// Sets the query for the operation.
  ///</param>
  if (!(this instanceof Sdk.RetrieveByResourceResourceGroupRequest)) {
   return new Sdk.RetrieveByResourceResourceGroupRequest(resourceId, query);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _resourceId = null;
  var _query = null;

  // internal validation functions

  function _setValidResourceId(value) {
   if (Sdk.Util.isGuid(value)) {
    _resourceId = value;
   }
   else {
    throw new Error("Sdk.RetrieveByResourceResourceGroupRequest ResourceId property is required and must be a String.")
   }
  }

  function _setValidQuery(value) {
   if (value instanceof Sdk.Query.QueryBase) {
    _query = value;
   }
   else {
    throw new Error("Sdk.RetrieveByResourceResourceGroupRequest Query property is required and must be a Sdk.QueryBase.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof resourceId != "undefined") {
   _setValidResourceId(resourceId);
  }
  if (typeof query != "undefined") {
   _setValidQuery(query);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ResourceId</b:key>",
              (_resourceId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _resourceId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Query</b:key>",
              (_query == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:" + _query.getQueryType() + "\">", _query.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveByResourceResourceGroup</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveByResourceResourceGroupResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setResourceId = function (value) {
   ///<summary>
   /// Sets the ID of the resource.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the resource.
   ///</param>
   _setValidResourceId(value);
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
 this.RetrieveByResourceResourceGroupRequest.__class = true;

 this.RetrieveByResourceResourceGroupResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveByResourceResourceGroupRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveByResourceResourceGroupResponse)) {
   return new Sdk.RetrieveByResourceResourceGroupResponse(responseXml);
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
   /// Gets the resulting collection of all resource groups (scheduling groups) that contain the specified resource.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The resulting collection of all resource groups (scheduling groups) that contain the specified resource.
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.RetrieveByResourceResourceGroupResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveByResourceResourceGroupRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveByResourceResourceGroupResponse.prototype = new Sdk.OrganizationResponse();
