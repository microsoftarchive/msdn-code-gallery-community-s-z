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
 this.ParseImportRequest = function (importId) {
  ///<summary>
  /// Contains the data that is needed to  submit an asynchronous job that parses all import files that are associated with the specified import (data import). 
  ///</summary>
  ///<param name="importId"  type="String">
  /// Sets the ID of the import (data import) that is associated with the asynchronous job that parses all import files for this import. Required.
  ///</param>
  if (!(this instanceof Sdk.ParseImportRequest)) {
   return new Sdk.ParseImportRequest(importId);
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
    throw new Error("Sdk.ParseImportRequest ImportId property is required and must be a String.")
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
           "<a:RequestName>ParseImport</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ParseImportResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setImportId = function (value) {
   ///<summary>
   /// Sets the ID of the import (data import) that is associated with the asynchronous job that parses all import files for this import. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the import (data import) that is associated with the asynchronous job that parses all import files for this import.
   ///</param>
   _setValidImportId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ParseImportRequest.__class = true;

 this.ParseImportResponse = function (responseXml) {
  ///<summary>
  /// Response to ParseImportRequest
  ///</summary>
  if (!(this instanceof Sdk.ParseImportResponse)) {
   return new Sdk.ParseImportResponse(responseXml);
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
   /// Gets an ID of the asynchronous job that parses the import files for this import.
   ///</summary>
   ///<returns type="String">
   /// An ID of the asynchronous job that parses the import files for this import.
   ///</returns>
   return _asyncOperationId;
  }

  //Set property values from responseXml constructor parameter
  _setAsyncOperationId(responseXml);
 }
 this.ParseImportResponse.__class = true;
}).call(Sdk)

Sdk.ParseImportRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ParseImportResponse.prototype = new Sdk.OrganizationResponse();
