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
 this.SearchByBodyKbArticleRequest = function (searchText, subjectId, useInflection, queryExpression) {
  ///<summary>
  /// Contains the data that is needed to  search for knowledge base articles that contain the specified body text.
  ///</summary>
  ///<param name="searchText"  type="String">
  /// Sets the text contained in the body of the article. Required.
  ///</param>
  ///<param name="subjectId"  type="String">
  /// Sets the ID of the knowledge base article subject. Required.
  ///</param>
  ///<param name="useInflection"  type="Boolean">
  /// Sets a value that indicates whether to use inflectional stem matching when searching for knowledge base articles with a specified body text. Required.
  ///</param>
  ///<param name="queryExpression"  type="Sdk.QueryBase">
  /// Sets the query criteria to find knowledge base articles with specified body text. Required. 
  ///</param>
  if (!(this instanceof Sdk.SearchByBodyKbArticleRequest)) {
   return new Sdk.SearchByBodyKbArticleRequest(searchText, subjectId, useInflection, queryExpression);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _searchText = null;
  var _subjectId = null;
  var _useInflection = null;
  var _queryExpression = null;

  // internal validation functions

  function _setValidSearchText(value) {
   if (typeof value == "string") {
    _searchText = value;
   }
   else {
    throw new Error("Sdk.SearchByBodyKbArticleRequest SearchText property is required and must be a String.")
   }
  }

  function _setValidSubjectId(value) {
   if (Sdk.Util.isGuid(value)) {
    _subjectId = value;
   }
   else {
    throw new Error("Sdk.SearchByBodyKbArticleRequest SubjectId property is required and must be a String.")
   }
  }

  function _setValidUseInflection(value) {
   if (typeof value == "boolean") {
    _useInflection = value;
   }
   else {
    throw new Error("Sdk.SearchByBodyKbArticleRequest UseInflection property is required and must be a Boolean.")
   }
  }

  function _setValidQueryExpression(value) {
   if (value instanceof Sdk.Query.QueryBase) {
    _queryExpression = value;
   }
   else {
    throw new Error("Sdk.SearchByBodyKbArticleRequest QueryExpression property is required and must be a Sdk.QueryBase.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof searchText != "undefined") {
   _setValidSearchText(searchText);
  }
  if (typeof subjectId != "undefined") {
   _setValidSubjectId(subjectId);
  }
  if (typeof useInflection != "undefined") {
   _setValidUseInflection(useInflection);
  }
  if (typeof queryExpression != "undefined") {
   _setValidQueryExpression(queryExpression);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SearchText</b:key>",
              (_searchText == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _searchText, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SubjectId</b:key>",
              (_subjectId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _subjectId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>UseInflection</b:key>",
              (_useInflection == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _useInflection, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>QueryExpression</b:key>",
              (_queryExpression == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:" + _query.getQueryType() + "\">", _queryExpression.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>SearchByBodyKbArticle</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SearchByBodyKbArticleResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setSearchText = function (value) {
   ///<summary>
   /// Sets the text contained in the body of the article. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The text contained in the body of the article.
   ///</param>
   _setValidSearchText(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSubjectId = function (value) {
   ///<summary>
   /// Sets the ID of the knowledge base article subject. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the knowledge base article subject.
   ///</param>
   _setValidSubjectId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setUseInflection = function (value) {
   ///<summary>
   /// Sets a value that indicates whether to use inflectional stem matching when searching for knowledge base articles with a specified body text. Required.
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether to use inflectional stem matching when searching for knowledge base articles with a specified body text.
   ///</param>
   _setValidUseInflection(value);
   this.setRequestXml(getRequestXml());
  }

  this.setQueryExpression = function (value) {
   ///<summary>
   /// Sets the query criteria to find knowledge base articles with specified body text. Required. 
   ///</summary>
   ///<param name="value" type="Sdk.QueryBase">
   ///The query criteria to find knowledge base articles with specified body text. 
   ///</param>
   _setValidQueryExpression(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SearchByBodyKbArticleRequest.__class = true;

 this.SearchByBodyKbArticleResponse = function (responseXml) {
  ///<summary>
  /// Response to SearchByBodyKbArticleRequest
  ///</summary>
  if (!(this instanceof Sdk.SearchByBodyKbArticleResponse)) {
   return new Sdk.SearchByBodyKbArticleResponse(responseXml);
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
   /// Gets the collection of knowledge base articles that contain the specified body text.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The collection of knowledge base articles that contain the specified body text.
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.SearchByBodyKbArticleResponse.__class = true;
}).call(Sdk)

Sdk.SearchByBodyKbArticleRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SearchByBodyKbArticleResponse.prototype = new Sdk.OrganizationResponse();
