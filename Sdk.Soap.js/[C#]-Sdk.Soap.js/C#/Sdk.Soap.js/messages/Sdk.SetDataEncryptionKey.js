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
 this.SetDataEncryptionKeyRequest = function (encryptionKey, changeEncryptionKey) {
  ///<summary>
  /// Contains the data that is needed to set or restore the data encryption key. 
  ///</summary>
  ///<param name="encryptionKey"  type="String">
  /// Sets the value of the data encryption key. 
  ///</param>
  ///<param name="changeEncryptionKey"  type="Boolean">
  /// <para>Sets the operation to perform with the data encryption key.</para>
  /// <para>true indicates to set (change) the data encryption key; otherwise, false indicates to restore the data encryption key. </para>
  ///</param>
  if (!(this instanceof Sdk.SetDataEncryptionKeyRequest)) {
   return new Sdk.SetDataEncryptionKeyRequest(encryptionKey, changeEncryptionKey);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _encryptionKey = null;
  var _changeEncryptionKey = null;

  // internal validation functions

  function _setValidEncryptionKey(value) {
   if (typeof value == "string") {
    _encryptionKey = value;
   }
   else {
    throw new Error("Sdk.SetDataEncryptionKeyRequest EncryptionKey property is required and must be a String.")
   }
  }

  function _setValidChangeEncryptionKey(value) {
   if (typeof value == "boolean") {
    _changeEncryptionKey = value;
   }
   else {
    throw new Error("Sdk.SetDataEncryptionKeyRequest ChangeEncryptionKey property is required and must be a Boolean.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof encryptionKey != "undefined") {
   _setValidEncryptionKey(encryptionKey);
  }
  if (typeof changeEncryptionKey != "undefined") {
   _setValidChangeEncryptionKey(changeEncryptionKey);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>EncryptionKey</b:key>",
              (_encryptionKey == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _encryptionKey, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ChangeEncryptionKey</b:key>",
              (_changeEncryptionKey == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:boolean\">", _changeEncryptionKey, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>SetDataEncryptionKey</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SetDataEncryptionKeyResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEncryptionKey = function (value) {
   ///<summary>
   /// Sets the value of the data encryption key. 
   ///</summary>
   ///<param name="value" type="String">
   /// The value of the data encryption key. 
   ///</param>
   _setValidEncryptionKey(value);
   this.setRequestXml(getRequestXml());
  }

  this.setChangeEncryptionKey = function (value) {
   ///<summary>
   /// Sets the operation to perform with the data encryption key. 
   ///</summary>
   ///<param name="value" type="Boolean">
   /// <para>Sets the operation to perform with the data encryption key.</para>
   /// <para>true indicates to set (change) the data encryption key; otherwise, false indicates to restore the data encryption key. </para>
   ///</param>
   _setValidChangeEncryptionKey(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SetDataEncryptionKeyRequest.__class = true;

 this.SetDataEncryptionKeyResponse = function (responseXml) {
  ///<summary>
  /// Response to SetDataEncryptionKeyRequest
  ///</summary>
  if (!(this instanceof Sdk.SetDataEncryptionKeyResponse)) {
   return new Sdk.SetDataEncryptionKeyResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.SetDataEncryptionKeyResponse.__class = true;
}).call(Sdk)

Sdk.SetDataEncryptionKeyRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SetDataEncryptionKeyResponse.prototype = new Sdk.OrganizationResponse();
