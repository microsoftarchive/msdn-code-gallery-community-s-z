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
 this.RetrieveByTopIncidentProductKbArticleRequest = function (productId) {
  ///<summary>
  /// Contains the data that is needed to  retrieve the top-ten articles about a specified product from the knowledge base of articles for your organization.
  ///</summary>
  ///<param name="productId"  type="String">
  /// Sets the ID of the product. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveByTopIncidentProductKbArticleRequest)) {
   return new Sdk.RetrieveByTopIncidentProductKbArticleRequest(productId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _productId = null;

  // internal validation functions

  function _setValidProductId(value) {
   if (Sdk.Util.isGuid(value)) {
    _productId = value;
   }
   else {
    throw new Error("Sdk.RetrieveByTopIncidentProductKbArticleRequest ProductId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof productId != "undefined") {
   _setValidProductId(productId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ProductId</b:key>",
              (_productId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _productId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveByTopIncidentProductKbArticle</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveByTopIncidentProductKbArticleResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setProductId = function (value) {
   ///<summary>
   /// Sets the ID of the product. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the product.
   ///</param>
   _setValidProductId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveByTopIncidentProductKbArticleRequest.__class = true;

 this.RetrieveByTopIncidentProductKbArticleResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveByTopIncidentProductKbArticleRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveByTopIncidentProductKbArticleResponse)) {
   return new Sdk.RetrieveByTopIncidentProductKbArticleResponse(responseXml);
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
   /// Gets the resulting collection of articles about the specified product from the knowledge base of articles for your organization.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The resulting collection of articles about the specified product from the knowledge base of articles for your organization.
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.RetrieveByTopIncidentProductKbArticleResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveByTopIncidentProductKbArticleRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveByTopIncidentProductKbArticleResponse.prototype = new Sdk.OrganizationResponse();
