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
 this.BackgroundSendEmailRequest = function (
 query
 ) {
  ///<summary>
  /// Contains the data that is needed to send email messages asynchronously. 
  ///</summary>
  ///<param name="query"  type="Sdk.QueryBase">
  /// Sets the query to find the email activities to send. 
  ///</param>
  if (!(this instanceof Sdk.BackgroundSendEmailRequest)) {
   return new Sdk.BackgroundSendEmailRequest(query);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _query = null;

  // internal validation functions

  function _setValidQuery(value) {
   if (value instanceof Sdk.Query.QueryBase) {
    _query = value;
   }
   else {
    throw new Error("Sdk.BackgroundSendEmailRequest Query property is required and must be a Sdk.QueryBase.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof query != "undefined") {
   _setValidQuery(query);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Query</b:key>",
              (_query == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:" + _query.getQueryType() + "\">", _query.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>BackgroundSendEmail</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.BackgroundSendEmailResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setQuery = function (value) {
   ///<summary>
   /// Sets the query to find the email activities to send. 
   ///</summary>
   ///<param name="value" type="Sdk.QueryBase">
   /// The query to find the email activities to send. 
   ///</param>
   _setValidQuery(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.BackgroundSendEmailRequest.__class = true;

 this.BackgroundSendEmailResponse = function (responseXml) {
  ///<summary>
  /// Response to BackgroundSendEmailRequest
  ///</summary>
  if (!(this instanceof Sdk.BackgroundSendEmailResponse)) {
   return new Sdk.BackgroundSendEmailResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _entityCollection = null;
  var _hasAttachments = null;

  // Internal property setter functions

  function _setEntityCollection(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='EntityCollection']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _entityCollection = Sdk.Util.createEntityCollectionFromNode(valueNode);
   }
  }
  function _setHasAttachments(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='HasAttachments']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _hasAttachments = Sdk.Util.createBooleanCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEntityCollection = function () {
   ///<summary>
   /// Gets the resulting emails.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The resulting emails.
   ///</returns>
   return _entityCollection;
  }
  this.getHasAttachments = function () {
   ///<summary>
   /// Gets a value that indicates whether the email has attachments.
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// A value that indicates whether the email has attachments.
   ///</returns>
   return _hasAttachments;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
  _setHasAttachments(responseXml);
 }
 this.BackgroundSendEmailResponse.__class = true;
}).call(Sdk)

Sdk.BackgroundSendEmailRequest.prototype = new Sdk.OrganizationRequest();
Sdk.BackgroundSendEmailResponse.prototype = new Sdk.OrganizationResponse();
