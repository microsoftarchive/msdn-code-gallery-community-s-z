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
 this.ResetUserFiltersRequest = function (queryType) {
  ///<summary>
  /// Contains the data that is needed to  reset the offline data filters for the calling user to the default filters for the organization.
  ///</summary>
  ///<param name="queryType"  type="Number">
  /// Sets the type of filters to set. Required.
  ///</param>
  if (!(this instanceof Sdk.ResetUserFiltersRequest)) {
   return new Sdk.ResetUserFiltersRequest(queryType);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _queryType = null;

  // internal validation functions

  function _setValidQueryType(value) {
   if (typeof value == "number") {
    _queryType = value;
   }
   else {
    throw new Error("Sdk.ResetUserFiltersRequest QueryType property is required and must be a Number.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof queryType != "undefined") {
   _setValidQueryType(queryType);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>QueryType</b:key>",
              (_queryType == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _queryType, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ResetUserFilters</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ResetUserFiltersResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setQueryType = function (value) {
   ///<summary>
   /// Sets the type of filters to set. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The type of filters to set.
   ///</param>
   _setValidQueryType(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ResetUserFiltersRequest.__class = true;

 this.ResetUserFiltersResponse = function (responseXml) {
  ///<summary>
  /// Response to ResetUserFiltersRequest
  ///</summary>
  if (!(this instanceof Sdk.ResetUserFiltersResponse)) {
   return new Sdk.ResetUserFiltersResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.ResetUserFiltersResponse.__class = true;
}).call(Sdk)

Sdk.ResetUserFiltersRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ResetUserFiltersResponse.prototype = new Sdk.OrganizationResponse();
