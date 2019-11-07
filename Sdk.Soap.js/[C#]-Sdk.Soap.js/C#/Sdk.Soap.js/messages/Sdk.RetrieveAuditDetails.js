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
 this.RetrieveAuditDetailsRequest = function (auditId) {
  ///<summary>
  /// Contains the data that is needed to retrieve the full audit details from an Audit record. 
  ///</summary>
  ///<param name="auditId"  type="String">
  /// Sets the ID of the Audit record to retrieve.
  ///</param>
  if (!(this instanceof Sdk.RetrieveAuditDetailsRequest)) {
   return new Sdk.RetrieveAuditDetailsRequest(auditId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _auditId = null;

  // internal validation functions

  function _setValidAuditId(value) {
   if (Sdk.Util.isGuid(value)) {
    _auditId = value;
   }
   else {
    throw new Error("Sdk.RetrieveAuditDetailsRequest AuditId property is required and must be a String representation of a Guid value.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof auditId != "undefined") {
   _setValidAuditId(auditId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>AuditId</b:key>",
              (_auditId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _auditId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveAuditDetails</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveAuditDetailsResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setAuditId = function (value) {
   ///<summary>
   /// Sets the ID of the Audit record to retrieve. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the Audit record to retrieve.
   ///</param>
   _setValidAuditId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveAuditDetailsRequest.__class = true;

 this.RetrieveAuditDetailsResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveAuditDetailsRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveAuditDetailsResponse)) {
   return new Sdk.RetrieveAuditDetailsResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _auditDetail = null;

  // Internal property setter functions

  function _setAuditDetail(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='AuditDetail']/b:value");
   _auditDetail = Sdk.Util.createAuditDetailFromNode(valueNode);
  }
  //Public Methods to retrieve properties
  this.getAuditDetail = function () {
   ///<summary>
   /// Gets the details of the audited data changes. 
   ///</summary>
   ///<returns type="Sdk.AuditDetail">
   /// <para>The details of the audited data changes.</para>
   /// <para>The value will be one of the classes that inherit from Sdk.AuditDetail: </para>
   /// <para>- Sdk.AttributeAuditDetail</para>
   /// <para>- Sdk.RelationshipAuditDetail</para>
   /// <para>- Sdk.RolePrivilegeAuditDetail</para>
   /// <para>- Sdk.ShareAuditDetail</para>
   ///</returns>
   return _auditDetail;
  }

  //Set property values from responseXml constructor parameter
  _setAuditDetail(responseXml);
 }
 this.RetrieveAuditDetailsResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveAuditDetailsRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveAuditDetailsResponse.prototype = new Sdk.OrganizationResponse();
