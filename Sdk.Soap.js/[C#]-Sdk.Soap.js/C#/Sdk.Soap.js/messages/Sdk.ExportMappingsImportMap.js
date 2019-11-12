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
 this.ExportMappingsImportMapRequest = function (importMapId, exportIds) {
  ///<summary>
  /// Contains the data that is needed to export a data map as an XML formatted data. 
  ///</summary>
  ///<param name="importMapId"  type="String">
  /// Sets the ID of the import map (data map) to export. Required. 
  ///</param>
  ///<param name="exportIds" optional="true" type="Boolean">
  /// Sets a value that indicates whether to export the entity record IDs contained in the data map. Required. 
  ///</param>
  if (!(this instanceof Sdk.ExportMappingsImportMapRequest)) {
   return new Sdk.ExportMappingsImportMapRequest(importMapId, exportIds);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _importMapId = null;
  var _exportIds = null;

  // internal validation functions

  function _setValidImportMapId(value) {
   if (Sdk.Util.isGuid(value)) {
    _importMapId = value;
   }
   else {
    throw new Error("Sdk.ExportMappingsImportMapRequest ImportMapId property is required and must be a String.")
   }
  }

  function _setValidExportIds(value) {
   if (value == null || typeof value == "boolean") {
    _exportIds = value;
   }
   else {
    throw new Error("Sdk.ExportMappingsImportMapRequest ExportIds property must be a Boolean or null.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof importMapId != "undefined") {
   _setValidImportMapId(importMapId);
  }
  if (typeof exportIds != "undefined") {
   _setValidExportIds(exportIds);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ImportMapId</b:key>",
              (_importMapId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _importMapId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ExportIds</b:key>",
              (_exportIds == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _exportIds, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ExportMappingsImportMap</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ExportMappingsImportMapResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setImportMapId = function (value) {
   ///<summary>
   /// Sets the ID of the import map (data map) to export. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the import map (data map) to export. 
   ///</param>
   _setValidImportMapId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setExportIds = function (value) {
   ///<summary>
   /// Sets a value that indicates whether to export the entity record IDs contained in the data map. Required. 
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether to export the entity record IDs contained in the data map. 
   ///</param>
   _setValidExportIds(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ExportMappingsImportMapRequest.__class = true;

 this.ExportMappingsImportMapResponse = function (responseXml) {
  ///<summary>
  /// Response to ExportMappingsImportMapRequest
  ///</summary>
  if (!(this instanceof Sdk.ExportMappingsImportMapResponse)) {
   return new Sdk.ExportMappingsImportMapResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _mappingsXml = null;

  // Internal property setter functions

  function _setMappingsXml(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='MappingsXml']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _mappingsXml = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getMappingsXml = function () {
   ///<summary>
   /// Gets the XML representation of the exported data map. 
   ///</summary>
   ///<returns type="String">
   /// The XML representation of the exported data map. 
   ///</returns>
   return _mappingsXml;
  }

  //Set property values from responseXml constructor parameter
  _setMappingsXml(responseXml);
 }
 this.ExportMappingsImportMapResponse.__class = true;
}).call(Sdk)

Sdk.ExportMappingsImportMapRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ExportMappingsImportMapResponse.prototype = new Sdk.OrganizationResponse();
