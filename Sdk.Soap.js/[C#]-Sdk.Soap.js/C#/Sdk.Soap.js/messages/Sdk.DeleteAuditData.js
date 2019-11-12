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
 this.DeleteAuditDataRequest = function (endDate) {
  ///<summary>
  /// Contains the data that is needed to delete all audit data records up until a specified end date. 
  ///</summary>
  ///<param name="endDate"  type="Date">
  /// Sets the end date and time. Required. 
  ///</param>
  if (!(this instanceof Sdk.DeleteAuditDataRequest)) {
   return new Sdk.DeleteAuditDataRequest(endDate);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _endDate = null;

  // internal validation functions

  function _setValidEndDate(value) {
   if (value instanceof Date) {
    _endDate = value;
   }
   else {
    throw new Error("Sdk.DeleteAuditDataRequest EndDate property is required and must be a Date.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof endDate != "undefined") {
   _setValidEndDate(endDate);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EndDate</b:key>",
              (_endDate == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:dateTime\">", _endDate.toISOString(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>DeleteAuditData</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.DeleteAuditDataResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEndDate = function (value) {
   ///<summary>
   /// Sets the end date and time. Required. 
   ///</summary>
   ///<param name="value" type="Date">
   /// The end date and time. 
   ///</param>
   _setValidEndDate(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.DeleteAuditDataRequest.__class = true;

 this.DeleteAuditDataResponse = function (responseXml) {
  ///<summary>
  /// Response to DeleteAuditDataRequest
  ///</summary>
  if (!(this instanceof Sdk.DeleteAuditDataResponse)) {
   return new Sdk.DeleteAuditDataResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _partitionsDeleted = null;

  // Internal property setter functions

  function _setPartitionsDeleted(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='PartitionsDeleted']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _partitionsDeleted = parseInt(Sdk.Xml.getNodeText(valueNode), 10);
   }
  }
  //Public Methods to retrieve properties
  this.getPartitionsDeleted = function () {
   ///<summary>
   /// Gets the number of deleted audit partitions or the number of deleted Audit records. 
   ///</summary>
   ///<returns type="Number">
   /// The number of deleted audit partitions or the number of deleted Audit records. 
   ///</returns>
   return _partitionsDeleted;
  }

  //Set property values from responseXml constructor parameter
  _setPartitionsDeleted(responseXml);
 }
 this.DeleteAuditDataResponse.__class = true;
}).call(Sdk)

Sdk.DeleteAuditDataRequest.prototype = new Sdk.OrganizationRequest();
Sdk.DeleteAuditDataResponse.prototype = new Sdk.OrganizationResponse();
