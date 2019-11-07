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
 this.TransformImportRequest = function (importId) {
  ///<summary>
  /// Contains the data that is needed to  submit an asynchronous job that transforms the parsed data.
  ///</summary>
  ///<param name="importId"  type="String">
  /// Sets the ID of the import (data import) that is associated with the asynchronous job that transforms the imported data. Required.
  ///</param>
  if (!(this instanceof Sdk.TransformImportRequest)) {
   return new Sdk.TransformImportRequest(importId);
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
    throw new Error("Sdk.TransformImportRequest ImportId property is required and must be a String.")
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
           "<a:RequestName>TransformImport</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.TransformImportResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setImportId = function (value) {
   ///<summary>
   /// Sets the ID of the import (data import) that is associated with the asynchronous job that transforms the imported data. Required.
   ///</summary>
   ///<param name="value" type="String">
   ///The ID of the import (data import) that is associated with the asynchronous job that transforms the imported data.
   ///</param>
   _setValidImportId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.TransformImportRequest.__class = true;

 this.TransformImportResponse = function (responseXml) {
  ///<summary>
  /// Response to TransformImportRequest
  ///</summary>
  if (!(this instanceof Sdk.TransformImportResponse)) {
   return new Sdk.TransformImportResponse(responseXml);
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
   /// Gets the ID of the asynchronous job that transforms the parsed data for this import.
   ///</summary>
   ///<returns type="String">
   /// The ID of the asynchronous job that transforms the parsed data for this import.
   ///</returns>
   return _asyncOperationId;
  }

  //Set property values from responseXml constructor parameter
  _setAsyncOperationId(responseXml);
 }
 this.TransformImportResponse.__class = true;
}).call(Sdk)

Sdk.TransformImportRequest.prototype = new Sdk.OrganizationRequest();
Sdk.TransformImportResponse.prototype = new Sdk.OrganizationResponse();
