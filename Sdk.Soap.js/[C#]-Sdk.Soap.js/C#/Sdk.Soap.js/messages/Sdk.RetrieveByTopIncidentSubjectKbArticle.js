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
 this.RetrieveByTopIncidentSubjectKbArticleRequest = function (subjectId) {
  ///<summary>
  /// Contains the data that is needed to  retrieve the top-ten articles about a specified subject from the knowledge base of articles for your organization.
  ///</summary>
  ///<param name="subjectId"  type="String">
  /// Sets the ID of the subject. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveByTopIncidentSubjectKbArticleRequest)) {
   return new Sdk.RetrieveByTopIncidentSubjectKbArticleRequest(subjectId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _subjectId = null;

  // internal validation functions

  function _setValidSubjectId(value) {
   if (Sdk.Util.isGuid(value)) {
    _subjectId = value;
   }
   else {
    throw new Error("Sdk.RetrieveByTopIncidentSubjectKbArticleRequest SubjectId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof subjectId != "undefined") {
   _setValidSubjectId(subjectId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SubjectId</b:key>",
              (_subjectId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _subjectId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveByTopIncidentSubjectKbArticle</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveByTopIncidentSubjectKbArticleResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setSubjectId = function (value) {
   ///<summary>
   /// Sets the ID of the subject. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the subject.
   ///</param>
   _setValidSubjectId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveByTopIncidentSubjectKbArticleRequest.__class = true;

 this.RetrieveByTopIncidentSubjectKbArticleResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveByTopIncidentSubjectKbArticleRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveByTopIncidentSubjectKbArticleResponse)) {
   return new Sdk.RetrieveByTopIncidentSubjectKbArticleResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _entityCollection = null;

  // Internal property setter functions

  function _setEntityCollection(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='EntityCollection']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _entityCollection = Sdk.Util.createEntityCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEntityCollection = function () {
   ///<summary>
   /// Gets the resulting collection of knowledge base articles about the specified subject.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The resulting collection of knowledge base articles about the specified subject.
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.RetrieveByTopIncidentSubjectKbArticleResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveByTopIncidentSubjectKbArticleRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveByTopIncidentSubjectKbArticleResponse.prototype = new Sdk.OrganizationResponse();
