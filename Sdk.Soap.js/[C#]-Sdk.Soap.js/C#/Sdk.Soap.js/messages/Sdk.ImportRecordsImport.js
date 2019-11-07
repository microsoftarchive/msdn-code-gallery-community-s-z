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
 this.ImportRecordsImportRequest = function (importId) {
  ///<summary>
  /// Contains the data that is needed to  submit an asynchronous job that uploads the transformed data into pn_microsoftcrm.
  ///</summary>
  ///<param name="importId"  type="String">
  /// Sets the ID of the data import (import) that is associated with the asynchronous import records job. Required.
  ///</param>
  if (!(this instanceof Sdk.ImportRecordsImportRequest)) {
   return new Sdk.ImportRecordsImportRequest(importId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _importId = null;

  // internal validation functions

  function _setValidImportId(value) {
   if (Sdk.Util.isGuid(value)) {
    _importId = value;
   }
   else {
    throw new Error("Sdk.ImportRecordsImportRequest ImportId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof importId != "undefined") {
   _setValidImportId(importId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ImportId</b:key>",
              (_importId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _importId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ImportRecordsImport</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ImportRecordsImportResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setImportId = function (value) {
   ///<summary>
   /// Sets the ID of the data import (import) that is associated with the asynchronous import records job. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the data import (import) that is associated with the asynchronous import records job.
   ///</param>
   _setValidImportId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ImportRecordsImportRequest.__class = true;

 this.ImportRecordsImportResponse = function (responseXml) {
  ///<summary>
  /// Response to ImportRecordsImportRequest
  ///</summary>
  if (!(this instanceof Sdk.ImportRecordsImportResponse)) {
   return new Sdk.ImportRecordsImportResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _asyncOperationId = null;

  // Internal property setter functions

  function _setAsyncOperationId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='AsyncOperationId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _asyncOperationId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getAsyncOperationId = function () {
   ///<summary>
   /// Gets the ID of the asynchronous import records job.
   ///</summary>
   ///<returns type="String">
   /// The ID of the asynchronous import records job.
   ///</returns>
   return _asyncOperationId;
  }

  //Set property values from responseXml constructor parameter
  _setAsyncOperationId(responseXml);
 }
 this.ImportRecordsImportResponse.__class = true;
}).call(Sdk)

Sdk.ImportRecordsImportRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ImportRecordsImportResponse.prototype = new Sdk.OrganizationResponse();
