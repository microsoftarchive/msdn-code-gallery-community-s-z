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
 this.ImportMappingsImportMapRequest = function (mappingsXml, replaceIds) {
  ///<summary>
  /// Contains the data that is needed to  import the XML representation of a data map and create an import map (data map) based on this data.
  ///</summary>
  ///<param name="mappingsXml"  type="String">
  /// Sets an XML representation of the data map. Required.
  ///</param>
  ///<param name="replaceIds"  type="Boolean">
  /// Sets a value that indicates whether to import the entity record IDs contained in the XML representation of the data map. Required. 
  ///</param>
  if (!(this instanceof Sdk.ImportMappingsImportMapRequest)) {
   return new Sdk.ImportMappingsImportMapRequest(mappingsXml, replaceIds);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _mappingsXml = null;
  var _replaceIds = null;

  // internal validation functions

  function _setValidMappingsXml(value) {
   if (typeof value == "string") {
    _mappingsXml = value;
   }
   else {
    throw new Error("Sdk.ImportMappingsImportMapRequest MappingsXml property is required and must be a String.")
   }
  }

  function _setValidReplaceIds(value) {
   if (typeof value == "boolean") {
    _replaceIds = value;
   }
   else {
    throw new Error("Sdk.ImportMappingsImportMapRequest ReplaceIds property is required and must be a Boolean.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof mappingsXml != "undefined") {
   _setValidMappingsXml(mappingsXml);
  }
  if (typeof replaceIds != "undefined") {
   _setValidReplaceIds(replaceIds);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>MappingsXml</b:key>",
              (_mappingsXml == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _mappingsXml, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ReplaceIds</b:key>",
              (_replaceIds == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _replaceIds, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>ImportMappingsImportMap</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.ImportMappingsImportMapResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setMappingsXml = function (value) {
   ///<summary>
   /// Sets an XML representation of the data map. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// An XML representation of the data map.
   ///</param>
   _setValidMappingsXml(value);
   this.setRequestXml(getRequestXml());
  }

  this.setReplaceIds = function (value) {
   ///<summary>
   /// Sets a value that indicates whether to import the entity record IDs contained in the XML representation of the data map. Required. 
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether to import the entity record IDs contained in the XML representation of the data map. 
   ///</param>
   _setValidReplaceIds(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.ImportMappingsImportMapRequest.__class = true;

 this.ImportMappingsImportMapResponse = function (responseXml) {
  ///<summary>
  /// Response to ImportMappingsImportMapRequest
  ///</summary>
  if (!(this instanceof Sdk.ImportMappingsImportMapResponse)) {
   return new Sdk.ImportMappingsImportMapResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _importMapId = null;

  // Internal property setter functions

  function _setImportMapId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='ImportMapId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _importMapId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getImportMapId = function () {
   ///<summary>
   ///  Gets the ID of the newly created import map (data map).
   ///</summary>
   ///<returns type="String">
   ///  The ID of the newly created import map (data map).
   ///</returns>
   return _importMapId;
  }

  //Set property values from responseXml constructor parameter
  _setImportMapId(responseXml);
 }
 this.ImportMappingsImportMapResponse.__class = true;
}).call(Sdk)

Sdk.ImportMappingsImportMapRequest.prototype = new Sdk.OrganizationRequest();
Sdk.ImportMappingsImportMapResponse.prototype = new Sdk.OrganizationResponse();
