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
 this.RetrieveDataEncryptionKeyRequest = function () {
  ///<summary>
  /// Contains the data that is needed to retrieve the data encryption key value. 
  ///</summary>
  if (!(this instanceof Sdk.RetrieveDataEncryptionKeyRequest)) {
   return new Sdk.RetrieveDataEncryptionKeyRequest();
  }
  Sdk.OrganizationRequest.call(this);

  // This message has no parameters

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters />",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveDataEncryptionKey</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveDataEncryptionKeyResponse);
  this.setRequestXml(getRequestXml());


 }
 this.RetrieveDataEncryptionKeyRequest.__class = true;

 this.RetrieveDataEncryptionKeyResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveDataEncryptionKeyRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveDataEncryptionKeyResponse)) {
   return new Sdk.RetrieveDataEncryptionKeyResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _encryptionKey = null;

  // Internal property setter functions

  function _setEncryptionKey(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='EncryptionKey']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _encryptionKey = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEncryptionKey = function () {
   ///<summary>
   /// Gets the encryption key. 
   ///</summary>
   ///<returns type="String">
   /// The encryption key. 
   ///</returns>
   return _encryptionKey;
  }

  //Set property values from responseXml constructor parameter
  _setEncryptionKey(responseXml);
 }
 this.RetrieveDataEncryptionKeyResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveDataEncryptionKeyRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveDataEncryptionKeyResponse.prototype = new Sdk.OrganizationResponse();
