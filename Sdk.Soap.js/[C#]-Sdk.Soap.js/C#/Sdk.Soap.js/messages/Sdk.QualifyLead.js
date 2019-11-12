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
 this.QualifyLeadRequest = function (leadId, createAccount, createContact, createOpportunity, opportunityCurrencyId, opportunityCustomerId, sourceCampaignId, status) {
  ///<summary>
  /// Contains the data that is needed to qualify a lead and create account, contact, and opportunity records that are linked to the originating lead record.
  ///</summary>
  ///<param name="leadId"  type="Sdk.EntityReference">
  /// Sets the ID of the lead that is qualified. Required.
  ///</param>
  ///<param name="createAccount"  type="Boolean">
  /// Sets a value that indicates whether to create an account from the originating lead. Required.
  ///</param>
  ///<param name="createContact"  type="Boolean">
  /// Sets a value that indicates whether to create a contact from the originating lead. Required.
  ///</param>
  ///<param name="createOpportunity"  type="Boolean">
  /// Sets a value that indicates whether to create an opportunity from the originating lead. Required.
  ///</param>
  ///<param name="opportunityCurrencyId" optional="true" type="Sdk.EntityReference">
  /// Sets the currency to use for this opportunity. Required.
  ///</param>
  ///<param name="opportunityCustomerId" optional="true" type="Sdk.EntityReference">
  /// Gets or set the account or contact that is associated with the opportunity. Required.
  ///</param>
  ///<param name="sourceCampaignId" optional="true" type="Sdk.EntityReference">
  /// Sets the source campaign that is associated with the opportunity. Required.
  ///</param>
  ///<param name="status" optional="true" type="Number">
  /// Sets the status of the lead. Required.
  ///</param>
  if (!(this instanceof Sdk.QualifyLeadRequest)) {
   return new Sdk.QualifyLeadRequest(leadId, createAccount, createContact, createOpportunity, opportunityCurrencyId, opportunityCustomerId, sourceCampaignId, status);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _leadId = null;
  var _createAccount = null;
  var _createContact = null;
  var _createOpportunity = null;
  var _opportunityCurrencyId = null;
  var _opportunityCustomerId = null;
  var _sourceCampaignId = null;
  var _status = null;

  // internal validation functions

  function _setValidLeadId(value) {
   if (value instanceof Sdk.EntityReference) {
    _leadId = value;
   }
   else {
    throw new Error("Sdk.QualifyLeadRequest LeadId property is required and must be a Sdk.EntityReference.")
   }
  }

  function _setValidCreateAccount(value) {
   if (typeof value == "boolean") {
    _createAccount = value;
   }
   else {
    throw new Error("Sdk.QualifyLeadRequest CreateAccount property is required and must be a Boolean.")
   }
  }

  function _setValidCreateContact(value) {
   if (typeof value == "boolean") {
    _createContact = value;
   }
   else {
    throw new Error("Sdk.QualifyLeadRequest CreateContact property is required and must be a Boolean.")
   }
  }

  function _setValidCreateOpportunity(value) {
   if (typeof value == "boolean") {
    _createOpportunity = value;
   }
   else {
    throw new Error("Sdk.QualifyLeadRequest CreateOpportunity property is required and must be a Boolean.")
   }
  }

  function _setValidOpportunityCurrencyId(value) {
   if (value == null || value instanceof Sdk.EntityReference) {
    _opportunityCurrencyId = value;
   }
   else {
    throw new Error("Sdk.QualifyLeadRequest OpportunityCurrencyId property must be a Sdk.EntityReference or null.")
   }
  }

  function _setValidOpportunityCustomerId(value) {
   if (value == null || value instanceof Sdk.EntityReference) {
    _opportunityCustomerId = value;
   }
   else {
    throw new Error("Sdk.QualifyLeadRequest OpportunityCustomerId property must be a Sdk.EntityReference or null.")
   }
  }

  function _setValidSourceCampaignId(value) {
   if (value == null || value instanceof Sdk.EntityReference) {
    _sourceCampaignId = value;
   }
   else {
    throw new Error("Sdk.QualifyLeadRequest SourceCampaignId property must be a Sdk.EntityReference or null.")
   }
  }

  function _setValidStatus(value) {
   if (value == null || typeof value == "number") {
    _status = value;
   }
   else {
    throw new Error("Sdk.QualifyLeadRequest Status property must be a Number or null.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof leadId != "undefined") {
   _setValidLeadId(leadId);
  }
  if (typeof createAccount != "undefined") {
   _setValidCreateAccount(createAccount);
  }
  if (typeof createContact != "undefined") {
   _setValidCreateContact(createContact);
  }
  if (typeof createOpportunity != "undefined") {
   _setValidCreateOpportunity(createOpportunity);
  }
  if (typeof opportunityCurrencyId != "undefined") {
   _setValidOpportunityCurrencyId(opportunityCurrencyId);
  }
  if (typeof opportunityCustomerId != "undefined") {
   _setValidOpportunityCustomerId(opportunityCustomerId);
  }
  if (typeof sourceCampaignId != "undefined") {
   _setValidSourceCampaignId(sourceCampaignId);
  }
  if (typeof status != "undefined") {
   _setValidStatus(status);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>LeadId</b:key>",
              (_leadId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _leadId.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>CreateAccount</b:key>",
              (_createAccount == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _createAccount, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>CreateContact</b:key>",
              (_createContact == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _createContact, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>CreateOpportunity</b:key>",
              (_createOpportunity == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _createOpportunity, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>OpportunityCurrencyId</b:key>",
              (_opportunityCurrencyId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _opportunityCurrencyId.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>OpportunityCustomerId</b:key>",
              (_opportunityCustomerId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _opportunityCustomerId.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SourceCampaignId</b:key>",
              (_sourceCampaignId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:EntityReference\">", _sourceCampaignId.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>Status</b:key>",
              (_status == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"a:OptionSetValue\">",
               "<a:Value>", _status, "</a:Value>",
              "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>QualifyLead</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.QualifyLeadResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setLeadId = function (value) {
   ///<summary>
   /// Sets the ID of the lead that is qualified. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The ID of the lead that is qualified.
   ///</param>
   _setValidLeadId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setCreateAccount = function (value) {
   ///<summary>
   /// Sets a value that indicates whether to create an account from the originating lead. Required.
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether to create an account from the originating lead.
   ///</param>
   _setValidCreateAccount(value);
   this.setRequestXml(getRequestXml());
  }

  this.setCreateContact = function (value) {
   ///<summary>
   /// Sets a value that indicates whether to create a contact from the originating lead. Required.
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether to create a contact from the originating lead.
   ///</param>
   _setValidCreateContact(value);
   this.setRequestXml(getRequestXml());
  }

  this.setCreateOpportunity = function (value) {
   ///<summary>
   /// Sets a value that indicates whether to create an opportunity from the originating lead. Required.
   ///</summary>
   ///<param name="value" type="Boolean">
   /// A value that indicates whether to create an opportunity from the originating lead.
   ///</param>
   _setValidCreateOpportunity(value);
   this.setRequestXml(getRequestXml());
  }

  this.setOpportunityCurrencyId = function (value) {
   ///<summary>
   /// Sets the currency to use for this opportunity. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The currency to use for this opportunity.
   ///</param>
   _setValidOpportunityCurrencyId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setOpportunityCustomerId = function (value) {
   ///<summary>
   /// Gets or set the account or contact that is associated with the opportunity. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The account or contact that is associated with the opportunity.
   ///</param>
   _setValidOpportunityCustomerId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSourceCampaignId = function (value) {
   ///<summary>
   /// Sets the source campaign that is associated with the opportunity. Required.
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference">
   /// The source campaign that is associated with the opportunity.
   ///</param>
   _setValidSourceCampaignId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setStatus = function (value) {
   ///<summary>
   /// Sets the status of the lead. Required.
   ///</summary>
   ///<param name="value" type="Number">
   /// The status of the lead.
   ///</param>
   _setValidStatus(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.QualifyLeadRequest.__class = true;

 this.QualifyLeadResponse = function (responseXml) {
  ///<summary>
  /// Response to QualifyLeadRequest
  ///</summary>
  if (!(this instanceof Sdk.QualifyLeadResponse)) {
   return new Sdk.QualifyLeadResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _createdEntities = null;

  // Internal property setter functions

  function _setCreatedEntities(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='CreatedEntities']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _createdEntities = Sdk.Util.createEntityReferenceCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getCreatedEntities = function () {
   ///<summary>
   /// Gets the collection of references to the newly created account, contact, and opportunity records. 
   ///</summary>
   ///<returns type="Sdk.EntityReferenceCollection">
   /// The collection of references to the newly created account, contact, and opportunity records. 
   ///</returns>
   return _createdEntities;
  }

  //Set property values from responseXml constructor parameter
  _setCreatedEntities(responseXml);
 }
 this.QualifyLeadResponse.__class = true;
}).call(Sdk)

Sdk.QualifyLeadRequest.prototype = new Sdk.OrganizationRequest();
Sdk.QualifyLeadResponse.prototype = new Sdk.OrganizationResponse();
