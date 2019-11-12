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
 this.InstantiateFiltersRequest = function (templateCollection, userId) {
  ///<summary>
  /// Contains the data that is needed to  instantiate a set of filters for pn_crm_for_outlook_short for the specified user.
  ///</summary>
  ///<param name="templateCollection"  type="Sdk.EntityReferenceCollection">
  /// Sets the set of filters to instantiate for the user.
  ///</param>
  ///<param name="userId"  type="String">
  /// Sets the ID of the user that will own the user query records created.
  ///</param>
  if (!(this instanceof Sdk.InstantiateFiltersRequest)) {
   return new Sdk.InstantiateFiltersRequest(templateCollection, userId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _templateCollection = null;
  var _userId = null;

  // internal validation functions

  function _setValidTemplateCollection(value) {
   if (value instanceof Sdk.EntityReferenceCollection) {
    _templateCollection = value;
   }
   else {
    throw new Error("Sdk.InstantiateFiltersRequest TemplateCollection property is required and must be a Sdk.EntityReferenceCollection.")
   }
  }

  function _setValidUserId(value) {
   if (Sdk.Util.isGuid(value)) {
    _userId = value;
   }
   else {
    throw new Error("Sdk.InstantiateFiltersRequest UserId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof templateCollection != "undefined") {
   _setValidTemplateCollection(templateCollection);
  }
  if (typeof userId != "undefined") {
   _setValidUserId(userId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>TemplateCollection</b:key>",
              (_templateCollection == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReferenceCollection\">", _templateCollection.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>UserId</b:key>",
              (_userId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _userId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>InstantiateFilters</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.InstantiateFiltersResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTemplateCollection = function (value) {
   ///<summary>
   /// Sets the set of filters to instantiate for the user.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReferenceCollection">
   /// The set of filters to instantiate for the user.
   ///</param>
   _setValidTemplateCollection(value);
   this.setRequestXml(getRequestXml());
  }

  this.setUserId = function (value) {
   ///<summary>
   /// Sets the ID of the user that will own the user query records created.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the user that will own the user query records created.
   ///</param>
   _setValidUserId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.InstantiateFiltersRequest.__class = true;

 this.InstantiateFiltersResponse = function (responseXml) {
  ///<summary>
  /// Response to InstantiateFiltersRequest
  ///</summary>
  if (!(this instanceof Sdk.InstantiateFiltersResponse)) {
   return new Sdk.InstantiateFiltersResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.InstantiateFiltersResponse.__class = true;
}).call(Sdk)

Sdk.InstantiateFiltersRequest.prototype = new Sdk.OrganizationRequest();
Sdk.InstantiateFiltersResponse.prototype = new Sdk.OrganizationResponse();
