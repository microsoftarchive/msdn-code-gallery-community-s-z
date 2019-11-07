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
 this.SetBusinessEquipmentRequest = function (equipmentId, businessUnitId) {
  ///<summary>
  /// Contains the data that is needed to  assign equipment (facility/equipment) to a specific business unit.
  ///</summary>
  ///<param name="equipmentId"  type="String">
  /// Sets the ID of the equipment (facility/equipment).
  ///</param>
  ///<param name="businessUnitId"  type="String">
  /// Sets the ID of the business unit.
  ///</param>
  if (!(this instanceof Sdk.SetBusinessEquipmentRequest)) {
   return new Sdk.SetBusinessEquipmentRequest(equipmentId, businessUnitId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _equipmentId = null;
  var _businessUnitId = null;

  // internal validation functions

  function _setValidEquipmentId(value) {
   if (Sdk.Util.isGuid(value)) {
    _equipmentId = value;
   }
   else {
    throw new Error("Sdk.SetBusinessEquipmentRequest EquipmentId property is required and must be a String.")
   }
  }

  function _setValidBusinessUnitId(value) {
   if (Sdk.Util.isGuid(value)) {
    _businessUnitId = value;
   }
   else {
    throw new Error("Sdk.SetBusinessEquipmentRequest BusinessUnitId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof equipmentId != "undefined") {
   _setValidEquipmentId(equipmentId);
  }
  if (typeof businessUnitId != "undefined") {
   _setValidBusinessUnitId(businessUnitId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EquipmentId</b:key>",
              (_equipmentId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _equipmentId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>BusinessUnitId</b:key>",
              (_businessUnitId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _businessUnitId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>SetBusinessEquipment</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SetBusinessEquipmentResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEquipmentId = function (value) {
   ///<summary>
   /// Sets the ID of the equipment (facility/equipment).
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the equipment (facility/equipment).
   ///</param>
   _setValidEquipmentId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setBusinessUnitId = function (value) {
   ///<summary>
   /// Sets the ID of the business unit.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the business unit.
   ///</param>
   _setValidBusinessUnitId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SetBusinessEquipmentRequest.__class = true;

 this.SetBusinessEquipmentResponse = function (responseXml) {
  ///<summary>
  /// Response to SetBusinessEquipmentRequest
  ///</summary>
  if (!(this instanceof Sdk.SetBusinessEquipmentResponse)) {
   return new Sdk.SetBusinessEquipmentResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values






 }
 this.SetBusinessEquipmentResponse.__class = true;
}).call(Sdk)

Sdk.SetBusinessEquipmentRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SetBusinessEquipmentResponse.prototype = new Sdk.OrganizationResponse();
