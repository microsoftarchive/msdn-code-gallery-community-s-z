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
 this.RetrieveParentGroupsResourceGroupRequest = function (resourceGroupId, query) {
  ///<summary>
  /// Contains the data needed to retrieve the collection of the parent resource groups of the specified resource group (scheduling group).
  ///</summary>
  ///<param name="resourceGroupId"  type="String">
  /// Sets the ID of the resource group.
  ///</param>
  ///<param name="query"  type="Sdk.QueryBase">
  /// Sets the query for the operation.
  ///</param>
  if (!(this instanceof Sdk.RetrieveParentGroupsResourceGroupRequest)) {
   return new Sdk.RetrieveParentGroupsResourceGroupRequest(resourceGroupId, query);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _resourceGroupId = null;
  var _query = null;

  // internal validation functions

  function _setValidResourceGroupId(value) {
   if (Sdk.Util.isGuid(value)) {
    _resourceGroupId = value;
   }
   else {
    throw new Error("Sdk.RetrieveParentGroupsResourceGroupRequest ResourceGroupId property is required and must be a String.")
   }
  }

  function _setValidQuery(value) {
   if (value instanceof Sdk.Query.QueryBase) {
    _query = value;
   }
   else {
    throw new Error("Sdk.RetrieveParentGroupsResourceGroupRequest Query property is required and must be a Sdk.QueryBase.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof resourceGroupId != "undefined") {
   _setValidResourceGroupId(resourceGroupId);
  }
  if (typeof query != "undefined") {
   _setValidQuery(query);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ResourceGroupId</b:key>",
              (_resourceGroupId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _resourceGroupId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Query</b:key>",
              (_query == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:" + _query.getQueryType() + "\">", _query.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveParentGroupsResourceGroup</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveParentGroupsResourceGroupResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setResourceGroupId = function (value) {
   ///<summary>
   /// Sets the ID of the resource group.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the resource group.
   ///</param>
   _setValidResourceGroupId(value);
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
 this.RetrieveParentGroupsResourceGroupRequest.__class = true;

 this.RetrieveParentGroupsResourceGroupResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveParentGroupsResourceGroupRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveParentGroupsResourceGroupResponse)) {
   return new Sdk.RetrieveParentGroupsResourceGroupResponse(responseXml);
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
   /// Gets the resulting collection of parent resource groups for the specified resource group (scheduling group).
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The resulting collection of parent resource groups for the specified resource group (scheduling group).
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.RetrieveParentGroupsResourceGroupResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveParentGroupsResourceGroupRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveParentGroupsResourceGroupResponse.prototype = new Sdk.OrganizationResponse();
