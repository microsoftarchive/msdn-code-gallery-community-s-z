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
 this.ValidateSavedQueryRequest = function (fetchXml, queryType) {
  ///<summary>
  /// Contains the data that is needed to  validate a saved query (view).
  ///</summary>
  ///<param name="fetchXml"  type="String">
  /// Sets the FetchXML query string to be validated.
  ///</param>
  ///<param name="queryType"  type="Number">
  /// Sets the type of the query.
  ///</param>
  if (!(this instanceof Sdk.ValidateSavedQueryRequest)) {
   return new Sdk.ValidateSavedQueryRequest(fetchXml, queryType);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _fetchXml = null;
  var _queryType = null;

  // internal validation functions

  function _setValidFetchXml(value) {
   if (typeof value == "string") {
    _fetchXml = value;
   }
   else {
    throw new Error("Sdk.ValidateSavedQueryRequest FetchXml property is required and must be a String.")
   }
  }

  function _setValidQueryType(value) {
   if (typeof value == "number") {
    _queryType = value;
   }
   else {
    throw new Error("Sdk.ValidateSavedQueryRequest QueryType property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof fetchXml != "undefined") {
   _setValidFetchXml(fetchXml);
  }
  if (typeof queryType != "undefined") {
   _setValidQueryType(queryType);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>FetchXml</b:key>",
              (_fetchXml == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _fetchXml, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>QueryType</b:key>",
              (_queryType == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _queryType, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ValidateSavedQuery</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ValidateSavedQueryResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setFetchXml = function (value) {
   ///<summary>
   /// Sets the FetchXML query string to be validated.
   ///</summary>
   ///<param name="value" type="String">
   /// The FetchXML query string to be validated.
   ///</param>
   _setValidFetchXml(value);
   this.setRequestXml(getRequestXml());
  }

  this.setQueryType = function (value) {
   ///<summary>
   /// Sets the type of the query.
   ///</summary>
   ///<param name="value" type="Number">
   /// The type of the query.
   ///</param>
   _setValidQueryType(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ValidateSavedQueryRequest.__class = true;

 this.ValidateSavedQueryResponse = function (responseXml) {
  ///<summary>
  /// Response to ValidateSavedQueryRequest
  ///</summary>
  if (!(this instanceof Sdk.ValidateSavedQueryResponse)) {
   return new Sdk.ValidateSavedQueryResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.ValidateSavedQueryResponse.__class = true;
}).call(Sdk)

Sdk.ValidateSavedQueryRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ValidateSavedQueryResponse.prototype = new Sdk.OrganizationResponse();
