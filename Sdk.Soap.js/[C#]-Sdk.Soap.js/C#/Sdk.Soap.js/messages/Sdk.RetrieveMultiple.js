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
 this.RetrieveMultipleRequest = function (query) {
  ///<summary>
  /// Request to retrieve records that match the query expression
  ///</summary>
  ///<param name="query" type="Sdk.Query.QueryBase">
  /// Either an Sdk.Query.FetchExpression or Sdk.Query.QueryExpression query
  ///</param>


  if (!(this instanceof Sdk.RetrieveMultipleRequest)) {
   return new Sdk.RetrieveMultipleRequest(query);
  }
  Sdk.OrganizationRequest.call(this);

  var _query = null;
  var _queryType = null;

  function _setValidQuery(value) {
   if (value instanceof Sdk.Query.QueryBase) {
    if (value instanceof Sdk.Query.FetchExpression) {
     _queryType = "FetchExpression";
    }
    if (value instanceof Sdk.Query.QueryExpression) {
     _queryType = "QueryExpression";
    }
    _query = value;
   }
   else {
    throw new Error("Sdk.RetrieveMultipleRequest constructor query parameter is required and must be either Sdk.Query.FetchExpression or Sdk.Query.QueryExpression.")
   }
  }

  //Set internal properties from constructor parameters
  _setValidQuery(query);

  function getRequestXml() {
   return [
      "<d:request>",
        "<a:Parameters>",
          "<a:KeyValuePairOfstringanyType>",
            "<b:key>Query</b:key>",
              (_query == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"a:", _queryType, "\">",
            _query.toValueXml(),
            "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",
        "</a:Parameters>",
        "<a:RequestId i:nil=\"true\" />",
        "<a:RequestName>RetrieveMultiple</a:RequestName>",
       "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveMultipleResponse);
  this.setRequestXml(getRequestXml());


  this.setQuery = function (value) {
   ///<summary>
   /// Sets the query
   ///</summary>
   ///<param name="value" type="Sdk.Query.QueryBase">
   /// Either an Sdk.Query.FetchExpression, Sdk.Query.QueryByAttribute, or Sdk.Query.QueryExpression query
   ///</param>
   _setValidQuery(value);
   this.setRequestXml(_requestXml);
  }

 }
 this.RetrieveMultipleRequest.__class = true;
 this.RetrieveMultipleResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveMultipleRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveMultipleResponse)) {
   return new Sdk.RetrieveMultipleResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)
  // Internal property
  var _entityCollection;
  // Internal property setter function
  function _setEntityCollection(xml) {
   _entityCollection = Sdk.Util.createEntityCollectionFromNode(Sdk.Xml.selectSingleNode(xml, "//a:Results/a:KeyValuePairOfstringanyType/b:value"));
  }
  //Public Methods to retrieve properties
  this.getEntityCollection = function () {
   ///<summary>
   /// Gets the collection of entities returned by the query.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The collection of entities returned by the query.
   ///</param>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.RetrieveMultipleResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveMultipleRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveMultipleResponse.prototype = new Sdk.OrganizationResponse();
