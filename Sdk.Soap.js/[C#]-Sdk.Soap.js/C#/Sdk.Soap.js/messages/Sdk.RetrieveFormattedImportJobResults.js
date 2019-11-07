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
 this.RetrieveFormattedImportJobResultsRequest = function (importJobId) {
  ///<summary>
  /// Contains the data that is needed to  retrieve the formatted results from an import job.
  ///</summary>
  ///<param name="importJobId"  type="String">
  /// Sets the GUID of an import job. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveFormattedImportJobResultsRequest)) {
   return new Sdk.RetrieveFormattedImportJobResultsRequest(importJobId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _importJobId = null;

  // internal validation functions

  function _setValidImportJobId(value) {
   if (Sdk.Util.isGuid(value)) {
    _importJobId = value;
   }
   else {
    throw new Error("Sdk.RetrieveFormattedImportJobResultsRequest ImportJobId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof importJobId != "undefined") {
   _setValidImportJobId(importJobId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ImportJobId</b:key>",
              (_importJobId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _importJobId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveFormattedImportJobResults</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveFormattedImportJobResultsResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setImportJobId = function (value) {
   ///<summary>
   /// Sets the GUID of an import job. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The GUID of an import job.
   ///</param>
   _setValidImportJobId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveFormattedImportJobResultsRequest.__class = true;

 this.RetrieveFormattedImportJobResultsResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveFormattedImportJobResultsRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveFormattedImportJobResultsResponse)) {
   return new Sdk.RetrieveFormattedImportJobResultsResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _formattedResults = null;

  // Internal property setter functions

  function _setFormattedResults(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='FormattedResults']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _formattedResults = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getFormattedResults = function () {
   ///<summary>
   /// Gets the formatted results of the import job.
   ///</summary>
   ///<returns type="String">
   /// The formatted results of the import job.
   ///</returns>
   return _formattedResults;
  }

  //Set property values from responseXml constructor parameter
  _setFormattedResults(responseXml);
 }
 this.RetrieveFormattedImportJobResultsResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveFormattedImportJobResultsRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveFormattedImportJobResultsResponse.prototype = new Sdk.OrganizationResponse();
