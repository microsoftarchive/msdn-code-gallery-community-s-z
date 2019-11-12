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
 this.RetrieveLocLabelsRequest = function (entityMoniker, attributeName, includeUnpublished) {
  ///<summary>
  /// Contains the data that is needed to retrieve localized labels for a limited set of entity attributes. 
  ///</summary>
  ///<param name="entityMoniker"  type="Sdk.EntityReference">
  /// Sets the entity. Required. 
  ///</param>
  ///<param name="attributeName"  type="String">
  /// Sets the name of the attribute for which to retrieve the localized labels. Required. 
  ///</param>
  ///<param name="includeUnpublished"  type="Boolean">
  /// Sets whether to include unpublished labels. Required. 
  ///</param>
  if (!(this instanceof Sdk.RetrieveLocLabelsRequest)) {
   return new Sdk.RetrieveLocLabelsRequest(entityMoniker, attributeName, includeUnpublished);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _entityMoniker = null;
  var _attributeName = null;
  var _includeUnpublished = null;

  // internal validation functions

  function _setValidEntityMoniker(value) {
   if (value instanceof Sdk.EntityReference) {
    _entityMoniker = value;
   }
   else {
    throw new Error("Sdk.RetrieveLocLabelsRequest EntityMoniker property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidAttributeName(value) {
   if (typeof value == "string") {
    _attributeName = value;
   }
   else {
    throw new Error("Sdk.RetrieveLocLabelsRequest AttributeName property is required and must be a String.")
   }
  }

  function _setValidIncludeUnpublished(value) {
   if (typeof value == "boolean") {
    _includeUnpublished = value;
   }
   else {
    throw new Error("Sdk.RetrieveLocLabelsRequest IncludeUnpublished property is required and must be a Boolean.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof entityMoniker != "undefined") {
   _setValidEntityMoniker(entityMoniker);
  }
  if (typeof attributeName != "undefined") {
   _setValidAttributeName(attributeName);
  }
  if (typeof includeUnpublished != "undefined") {
   _setValidIncludeUnpublished(includeUnpublished);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EntityMoniker</b:key>",
              (_entityMoniker == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _entityMoniker.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>AttributeName</b:key>",
              (_attributeName == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _attributeName, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>IncludeUnpublished</b:key>",
              (_includeUnpublished == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _includeUnpublished, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveLocLabels</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveLocLabelsResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntityMoniker = function (value) {
   ///<summary>
   ///  Sets the entity. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   ///  The entity. 
   ///</param>
   _setValidEntityMoniker(value);
   this.setRequestXml(getRequestXml());
  }

  this.setAttributeName = function (value) {
   ///<summary>
   /// Sets the name of the attribute for which to retrieve the localized labels. Required. 
   ///</summary>
   ///<param name="value" type="String">
   /// The name of the attribute for which to retrieve the localized labels. 
   ///</param>
   _setValidAttributeName(value);
   this.setRequestXml(getRequestXml());
  }

  this.setIncludeUnpublished = function (value) {
   ///<summary>
   /// Sets whether to include unpublished labels. Required. 
   ///</summary>
   ///<param name="value" type="Boolean">
   /// Whether to include unpublished labels. 
   ///</param>
   _setValidIncludeUnpublished(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveLocLabelsRequest.__class = true;

 this.RetrieveLocLabelsResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveLocLabelsRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveLocLabelsResponse)) {
   return new Sdk.RetrieveLocLabelsResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _label = null;

  // Internal property setter functions

  function _setLabel(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Label']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _label = getLabelObject(valueNode);
   }
  }

  function getLabelObject(node) {
   var rv = {};

   rv.LocalizedLabels = [];
   var locLabels = Sdk.Xml.selectSingleNode(node, "a:LocalizedLabels");
   for (var i = 0; i < locLabels.childNodes.length; i++) {

    var label = {};
    label.Label = Sdk.Xml.selectSingleNodeText(locLabels.childNodes[i], "a:Label");
    label.LanguageCode = parseInt(Sdk.Xml.selectSingleNodeText(locLabels.childNodes[i], "a:LanguageCode"), 10);
    rv.LocalizedLabels.push(label);
   }
   var userLocalizedLabel = Sdk.Xml.selectSingleNode(node, "a:UserLocalizedLabel");
   rv.UserLocalizedLabel = {};
   rv.UserLocalizedLabel.Label = Sdk.Xml.selectSingleNodeText(userLocalizedLabel, "a:Label");
   rv.UserLocalizedLabel.LanguageCode = parseInt(Sdk.Xml.selectSingleNodeText(userLocalizedLabel, "a:LanguageCode"), 10);
   return rv;

  }
  //Public Methods to retrieve properties
  this.getLabel = function () {
   ///<summary>
   /// Gets the label for the requested entity attribute. 
   ///</summary>
   ///<returns type="Object">
   /// The label for the requested entity attribute. 
   ///</returns>
   return _label;
  }

  //Set property values from responseXml constructor parameter
  _setLabel(responseXml);
 }
 this.RetrieveLocLabelsResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveLocLabelsRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveLocLabelsResponse.prototype = new Sdk.OrganizationResponse();
