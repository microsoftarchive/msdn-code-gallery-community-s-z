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
 this.DownloadReportDefinitionRequest = function (reportId) {
  ///<summary>
  /// Contains the data that is needed to download a report definition. 
  ///</summary>
  ///<param name="reportId"  type="String">
  /// Sets the ID of the report to download. 
  ///</param>
  if (!(this instanceof Sdk.DownloadReportDefinitionRequest)) {
   return new Sdk.DownloadReportDefinitionRequest(reportId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _reportId = null;

  // internal validation functions

  function _setValidReportId(value) {
   if (Sdk.Util.isGuid(value)) {
    _reportId = value;
   }
   else {
    throw new Error("Sdk.DownloadReportDefinitionRequest ReportId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof reportId != "undefined") {
   _setValidReportId(reportId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ReportId</b:key>",
              (_reportId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _reportId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>DownloadReportDefinition</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.DownloadReportDefinitionResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setReportId = function (value) {
   ///<summary>
   /// Sets the ID of the report to download. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the report to download. 
   ///</param>
   _setValidReportId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.DownloadReportDefinitionRequest.__class = true;

 this.DownloadReportDefinitionResponse = function (responseXml) {
  ///<summary>
  /// Response to DownloadReportDefinitionRequest
  ///</summary>
  if (!(this instanceof Sdk.DownloadReportDefinitionResponse)) {
   return new Sdk.DownloadReportDefinitionResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _bodyText = null;

  // Internal property setter functions

  function _setBodyText(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='BodyText']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _bodyText = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getBodyText = function () {
   ///<summary>
   /// Gets the report definition. 
   ///</summary>
   ///<returns type="String">
   /// The report definition. 
   ///</returns>
   return _bodyText;
  }

  //Set property values from responseXml constructor parameter
  _setBodyText(responseXml);
 }
 this.DownloadReportDefinitionResponse.__class = true;
}).call(Sdk)

Sdk.DownloadReportDefinitionRequest.prototype = new Sdk.OrganizationRequest();
Sdk.DownloadReportDefinitionResponse.prototype = new Sdk.OrganizationResponse();
