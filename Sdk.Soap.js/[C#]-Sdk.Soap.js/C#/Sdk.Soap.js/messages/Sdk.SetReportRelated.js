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
 this.SetReportRelatedRequest = function (reportId, entities, categories, visibility) {
  ///<summary>
  /// Contains the data needed to link an instance of a report entity to related entities.
  ///</summary>
  ///<param name="reportId"  type="String">
  /// Sets the ID of the report. Required.
  ///</param>
  ///<param name="entities"  type="Sdk.Collection">
  /// Sets an array of entity type codes for the related entities. Required.
  ///</param>
  ///<param name="categories"  type="Sdk.Collection">
  /// Sets an array of report category codes. Required.
  ///</param>
  ///<param name="visibility"  type="Sdk.Collection">
  /// Sets an array of report visibility codes. Required.
  ///</param>
  if (!(this instanceof Sdk.SetReportRelatedRequest)) {
   return new Sdk.SetReportRelatedRequest(reportId, entities, categories, visibility);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _reportId = null;
  var _entities = null;
  var _categories = null;
  var _visibility = null;

  // internal validation functions

  function _setValidReportId(value) {
   if (Sdk.Util.isGuid(value)) {
    _reportId = value;
   }
   else {
    throw new Error("Sdk.SetReportRelatedRequest ReportId property is required and must be a String.")
   }
  }

  function _setValidEntities(value) {
   if (Sdk.Util.isCollectionOf(value, Number)) {
    _entities = value;
   }
   else {
    throw new Error("Sdk.SetReportRelatedRequest Entities property is required and must be a Sdk.Collection.")
   }
  }

  function _setValidCategories(value) {
   if (Sdk.Util.isCollectionOf(value, Number)) {
    _categories = value;
   }
   else {
    throw new Error("Sdk.SetReportRelatedRequest Categories property is required and must be a Sdk.Collection.")
   }
  }

  function _setValidVisibility(value) {
   if (Sdk.Util.isCollectionOf(value, Number)) {
    _visibility = value;
   }
   else {
    throw new Error("Sdk.SetReportRelatedRequest Visibility property is required and must be a Sdk.Collection.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof reportId != "undefined") {
   _setValidReportId(reportId);
  }
  if (typeof entities != "undefined") {
   _setValidEntities(entities);
  }
  if (typeof categories != "undefined") {
   _setValidCategories(categories);
  }
  if (typeof visibility != "undefined") {
   _setValidVisibility(visibility);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ReportId</b:key>",
              (_reportId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _reportId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Entities</b:key>",
              (_entities == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"f:ArrayOfint\">", _entities.toArrayOfValueXml("f:int"), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Categories</b:key>",
              (_categories == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"f:ArrayOfint\">", _categories.toArrayOfValueXml("f:int"), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Visibility</b:key>",
              (_visibility == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"f:ArrayOfint\">", _visibility.toArrayOfValueXml("f:int"), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>SetReportRelated</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SetReportRelatedResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setReportId = function (value) {
   ///<summary>
   /// Sets the ID of the report. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the report.
   ///</param>
   _setValidReportId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setEntities = function (value) {
   ///<summary>
   /// Sets a collection of entity type codes for the related entities. Required.
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// A collection of entity type codes for the related entities.
   ///</param>
   _setValidEntities(value);
   this.setRequestXml(getRequestXml());
  }

  this.setCategories = function (value) {
   ///<summary>
   /// Sets a collection  of report category codes. Required.
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// A collection of report category codes.
   ///</param>
   _setValidCategories(value);
   this.setRequestXml(getRequestXml());
  }

  this.setVisibility = function (value) {
   ///<summary>
   /// Sets a collection  of report visibility codes. Required.
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// A collection  of report visibility codes.
   ///</param>
   _setValidVisibility(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SetReportRelatedRequest.__class = true;

 this.SetReportRelatedResponse = function (responseXml) {
  ///<summary>
  /// Response to SetReportRelatedRequest
  ///</summary>
  if (!(this instanceof Sdk.SetReportRelatedResponse)) {
   return new Sdk.SetReportRelatedResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.SetReportRelatedResponse.__class = true;
}).call(Sdk)

Sdk.SetReportRelatedRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SetReportRelatedResponse.prototype = new Sdk.OrganizationResponse();
