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
 this.RetrieveRecordWallRequest = function (entity, pageNumber, pageSize, commentsPerPost, startDate, endDate, type, source) {
  ///<summary>
  /// Contains the data that is needed to  retrieve pages of posts, including comments for each post, for a specified record. 
  ///</summary>
  ///<param name="entity"  type="Sdk.EntityReference">
  /// Sets the record for which to retrieve the wall. Required.
  ///</param>
  ///<param name="pageNumber"  type="Number">
  /// Sets, for retrieval, a specific page of posts that is designated by its page number. Required.
  ///</param>
  ///<param name="pageSize"  type="Number">
  /// Sets, for retrieval, the number of posts per page. Required.
  ///</param>
  ///<param name="commentsPerPost"  type="Number">
  /// Sets, for retrieval, the number of comments per post. Required.
  ///</param>
  ///<param name="startDate" optional="true" type="Date">
  /// Sets the start date and time of the posts that you want to retrieve. Optional.
  ///</param>
  ///<param name="endDate" optional="true" type="Date">
  /// Sets the end date and time of the posts that you want to retrieve. Optional.
  ///</param>
  ///<param name="type" optional="true" type="Number">
  /// Reserved for future use. 
  ///</param>
  ///<param name="source" optional="true" type="Number">
  /// Sets a value that specifies the source of the post. Optional.
  ///</param>
  if (!(this instanceof Sdk.RetrieveRecordWallRequest)) {
   return new Sdk.RetrieveRecordWallRequest(entity, pageNumber, pageSize, commentsPerPost, startDate, endDate, type, source);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _entity = null;
  var _pageNumber = null;
  var _pageSize = null;
  var _commentsPerPost = null;
  var _startDate = null;
  var _endDate = null;
  var _type = null;
  var _source = null;

  // internal validation functions

  function _setValidEntity(value) {
   if (value instanceof Sdk.EntityReference) {
    _entity = value;
   }
   else {
    throw new Error("Sdk.RetrieveRecordWallRequest Entity property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidPageNumber(value) {
   if (typeof value == "number") {
    _pageNumber = value;
   }
   else {
    throw new Error("Sdk.RetrieveRecordWallRequest PageNumber property is required and must be a Number.")
   }
  }

  function _setValidPageSize(value) {
   if (typeof value == "number") {
    _pageSize = value;
   }
   else {
    throw new Error("Sdk.RetrieveRecordWallRequest PageSize property is required and must be a Number.")
   }
  }

  function _setValidCommentsPerPost(value) {
   if (typeof value == "number") {
    _commentsPerPost = value;
   }
   else {
    throw new Error("Sdk.RetrieveRecordWallRequest CommentsPerPost property is required and must be a Number.")
   }
  }

  function _setValidStartDate(value) {
   if (value == null || value instanceof Date) {
    _startDate = value;
   }
   else {
    throw new Error("Sdk.RetrieveRecordWallRequest StartDate property must be a Date or null.")
   }
  }

  function _setValidEndDate(value) {
   if (value == null || value instanceof Date) {
    _endDate = value;
   }
   else {
    throw new Error("Sdk.RetrieveRecordWallRequest EndDate property must be a Date or null.")
   }
  }

  function _setValidType(value) {
   if (value == null || typeof value == "number") {
    _type = value;
   }
   else {
    throw new Error("Sdk.RetrieveRecordWallRequest Type property must be a Number or null.")
   }
  }

  function _setValidSource(value) {
   if (value == null || typeof value == "number") {
    _source = value;
   }
   else {
    throw new Error("Sdk.RetrieveRecordWallRequest Source property must be a Number or null.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof entity != "undefined") {
   _setValidEntity(entity);
  }
  if (typeof pageNumber != "undefined") {
   _setValidPageNumber(pageNumber);
  }
  if (typeof pageSize != "undefined") {
   _setValidPageSize(pageSize);
  }
  if (typeof commentsPerPost != "undefined") {
   _setValidCommentsPerPost(commentsPerPost);
  }
  if (typeof startDate != "undefined") {
   _setValidStartDate(startDate);
  }
  if (typeof endDate != "undefined") {
   _setValidEndDate(endDate);
  }
  if (typeof type != "undefined") {
   _setValidType(type);
  }
  if (typeof source != "undefined") {
   _setValidSource(source);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Entity</b:key>",
              (_entity == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _entity.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>PageNumber</b:key>",
              (_pageNumber == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _pageNumber, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>PageSize</b:key>",
              (_pageSize == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _pageSize, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>CommentsPerPost</b:key>",
              (_commentsPerPost == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:int\">", _commentsPerPost, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>StartDate</b:key>",
              (_startDate == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:dateTime\">", _startDate.toISOString(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EndDate</b:key>",
              (_endDate == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:dateTime\">", _endDate.toISOString(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Type</b:key>",
              (_type == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:OptionSetValue\">",
               "<a:Value>", _type, "</a:Value>",
              "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Source</b:key>",
              (_source == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:OptionSetValue\">",
               "<a:Value>", _source, "</a:Value>",
              "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveRecordWall</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveRecordWallResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntity = function (value) {
   ///<summary>
   /// Sets the record for which to retrieve the wall. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The record for which to retrieve the wall.
   ///</param>
   _setValidEntity(value);
   this.setRequestXml(getRequestXml());
  }

  this.setPageNumber = function (value) {
   ///<summary>
   /// Sets, for retrieval, a specific page of posts that is designated by its page number. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// A specific page of posts that is designated by its page number.
   ///</param>
   _setValidPageNumber(value);
   this.setRequestXml(getRequestXml());
  }

  this.setPageSize = function (value) {
   ///<summary>
   /// Sets, for retrieval, the number of posts per page. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The number of posts per page.
   ///</param>
   _setValidPageSize(value);
   this.setRequestXml(getRequestXml());
  }

  this.setCommentsPerPost = function (value) {
   ///<summary>
   /// Sets, for retrieval, the number of comments per post. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The number of comments per post.
   ///</param>
   _setValidCommentsPerPost(value);
   this.setRequestXml(getRequestXml());
  }

  this.setStartDate = function (value) {
   ///<summary>
   /// Sets the start date and time of the posts that you want to retrieve. Optional.
   ///</summary>
   ///<param name="value" type="Date">
   /// The start date and time of the posts that you want to retrieve.
   ///</param>
   _setValidStartDate(value);
   this.setRequestXml(getRequestXml());
  }

  this.setEndDate = function (value) {
   ///<summary>
   /// Sets the end date and time of the posts that you want to retrieve. Optional.
   ///</summary>
   ///<param name="value" type="Date">
   /// The end date and time of the posts that you want to retrieve.
   ///</param>
   _setValidEndDate(value);
   this.setRequestXml(getRequestXml());
  }

  this.setType = function (value) {
   ///<summary>
   /// Reserved for future use. 
   ///</summary>
   ///<param name="value" type="Number">
   /// Reserved for future use. 
   ///</param>
   _setValidType(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSource = function (value) {
   ///<summary>
   /// Sets a value that specifies the source of the post. Optional.
   ///</summary>
   ///<param name="value" type="Number">
   /// A value that specifies the source of the post.
   ///</param>
   _setValidSource(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveRecordWallRequest.__class = true;

 this.RetrieveRecordWallResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveRecordWallRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveRecordWallResponse)) {
   return new Sdk.RetrieveRecordWallResponse(responseXml);
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
   /// Gets the collection of posts with their associated comments and the calculated attribute values.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The collection of posts with their associated comments and the calculated attribute values.
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.RetrieveRecordWallResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveRecordWallRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveRecordWallResponse.prototype = new Sdk.OrganizationResponse();
