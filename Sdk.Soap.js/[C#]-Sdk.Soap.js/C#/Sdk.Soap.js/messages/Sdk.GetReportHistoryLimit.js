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
 this.GetReportHistoryLimitRequest = function (reportId) {
  ///<summary>
  /// Contains the data that is needed to  retrieve the history limit for a report.
  ///</summary>
  ///<param name="reportId"  type="String">
  /// Sets the ID of the report. Required.
  ///</param>
  if (!(this instanceof Sdk.GetReportHistoryLimitRequest)) {
   return new Sdk.GetReportHistoryLimitRequest(reportId);
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
    throw new Error("Sdk.GetReportHistoryLimitRequest ReportId property is required and must be a String.")
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
           "<a:RequestName>GetReportHistoryLimit</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.GetReportHistoryLimitResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setReportId = function (value) {
   ///<summary>
   /// Sets the ID of the report. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// Sets the ID of the report.
   ///</param>
   _setValidReportId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.GetReportHistoryLimitRequest.__class = true;

 this.GetReportHistoryLimitResponse = function (responseXml) {
  ///<summary>
  /// Response to GetReportHistoryLimitRequest
  ///</summary>
  if (!(this instanceof Sdk.GetReportHistoryLimitResponse)) {
   return new Sdk.GetReportHistoryLimitResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _historyLimit = null;

  // Internal property setter functions

  function _setHistoryLimit(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='HistoryLimit']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _historyLimit = parseInt(Sdk.Xml.getNodeText(valueNode), 10);
   }
  }
  //Public Methods to retrieve properties
  this.getHistoryLimit = function () {
   ///<summary>
   /// Gets the history limit for a report.
   ///</summary>
   ///<returns type="Number">
   /// The history limit for a report.
   ///</returns>
   return _historyLimit;
  }

  //Set property values from responseXml constructor parameter
  _setHistoryLimit(responseXml);
 }
 this.GetReportHistoryLimitResponse.__class = true;
}).call(Sdk)

Sdk.GetReportHistoryLimitRequest.prototype = new Sdk.OrganizationRequest();
Sdk.GetReportHistoryLimitResponse.prototype = new Sdk.OrganizationResponse();
