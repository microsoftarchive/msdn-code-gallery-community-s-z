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
 this.RetrieveAbsoluteAndSiteCollectionUrlRequest = function (target) {
  ///<summary>
  /// Contains the data that is needed to retrieve the absolute URL and the site collection URL for a pn_SharePoint_short location record in pn_microsoftcrm.
  ///</summary>
  ///<param name="target"  type="Sdk.EntityReference">
  /// Sets the target for which the data is to be retrieved. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveAbsoluteAndSiteCollectionUrlRequest)) {
   return new Sdk.RetrieveAbsoluteAndSiteCollectionUrlRequest(target);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _target = null;

  // internal validation functions

  function _setValidTarget(value) {
   if (value instanceof Sdk.EntityReference) {
    _target = value;
   }
   else {
    throw new Error("Sdk.RetrieveAbsoluteAndSiteCollectionUrlRequest Target property is required and must be a Sdk.EntityReference.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Target</b:key>",
              (_target == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _target.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveAbsoluteAndSiteCollectionUrl</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveAbsoluteAndSiteCollectionUrlResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
   ///<summary>
   /// Sets the target for which the data is to be retrieved. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The target for which the data is to be retrieved.
   ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveAbsoluteAndSiteCollectionUrlRequest.__class = true;

 this.RetrieveAbsoluteAndSiteCollectionUrlResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveAbsoluteAndSiteCollectionUrlRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveAbsoluteAndSiteCollectionUrlResponse)) {
   return new Sdk.RetrieveAbsoluteAndSiteCollectionUrlResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _absoluteUrl = null;
  var _siteCollectionUrl = null;

  // Internal property setter functions

  function _setAbsoluteUrl(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='AbsoluteUrl']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _absoluteUrl = Sdk.Xml.getNodeText(valueNode);
   }
  }
  function _setSiteCollectionUrl(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='SiteCollectionUrl']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _siteCollectionUrl = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getAbsoluteUrl = function () {
   ///<summary>
   /// Gets the absolute URL of the object that is specified in the request.
   ///</summary>
   ///<returns type="String">
   /// The absolute URL of the object that is specified in the request.
   ///</returns>
   return _absoluteUrl;
  }
  this.getSiteCollectionUrl = function () {
   ///<summary>
   /// Gets the pn_SharePoint_short site collection URL of the object that is specified in the request.
   ///</summary>
   ///<returns type="String">
   /// The SharePoint site collection URL of the object that is specified in the request.
   ///</returns>
   return _siteCollectionUrl;
  }

  //Set property values from responseXml constructor parameter
  _setAbsoluteUrl(responseXml);
  _setSiteCollectionUrl(responseXml);
 }
 this.RetrieveAbsoluteAndSiteCollectionUrlResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveAbsoluteAndSiteCollectionUrlRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveAbsoluteAndSiteCollectionUrlResponse.prototype = new Sdk.OrganizationResponse();
