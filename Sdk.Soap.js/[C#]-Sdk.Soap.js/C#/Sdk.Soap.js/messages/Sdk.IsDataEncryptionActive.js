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
this.IsDataEncryptionActiveRequest = function (){
///<summary>
/// 
///</summary>
if (!(this instanceof Sdk.IsDataEncryptionActiveRequest)) {
return new Sdk.IsDataEncryptionActiveRequest();
}
Sdk.OrganizationRequest.call(this);

  // This message has no parameters

  function getRequestXml() {
return ["<d:request>",
        "<a:Parameters />",
        "<a:RequestId i:nil=\"true\" />",
        "<a:RequestName>IsDataEncryptionActive</a:RequestName>",
      "</d:request>"].join("");
  }

  this.setResponseType(Sdk.IsDataEncryptionActiveResponse);
  this.setRequestXml(getRequestXml());


 }
 this.IsDataEncryptionActiveRequest.__class = true;

this.IsDataEncryptionActiveResponse = function (responseXml) {
  ///<summary>
  /// Response to IsDataEncryptionActiveRequest
  ///</summary>
  if (!(this instanceof Sdk.IsDataEncryptionActiveResponse)) {
   return new Sdk.IsDataEncryptionActiveResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _isActive = null;

  // Internal property setter functions

  function _setIsActive(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='IsActive']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _isActive = (Sdk.Xml.getNodeText(valueNode) == "true") ? true : false;
   }
  }
  //Public Methods to retrieve properties
  this.getIsActive = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="Boolean">
  /// [Add Description]
  ///</returns>
   return _isActive;
  }

  //Set property values from responseXml constructor parameter
  _setIsActive(responseXml);
 }
 this.IsDataEncryptionActiveResponse.__class = true;
}).call(Sdk)

Sdk.IsDataEncryptionActiveRequest.prototype = new Sdk.OrganizationRequest();
Sdk.IsDataEncryptionActiveResponse.prototype = new Sdk.OrganizationResponse();
