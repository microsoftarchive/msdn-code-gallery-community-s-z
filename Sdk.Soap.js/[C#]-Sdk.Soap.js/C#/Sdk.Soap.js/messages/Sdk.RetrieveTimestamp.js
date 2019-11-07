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
 this.RetrieveTimestampRequest = function () {
  ///<summary>
  /// Contains the data that is needed to retrieves a time stamp for the metadata. 
  ///</summary>
  if (!(this instanceof Sdk.RetrieveTimestampRequest)) {
   return new Sdk.RetrieveTimestampRequest();
  }
  Sdk.OrganizationRequest.call(this);

  // This message has no parameters

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters />",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveTimestamp</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveTimestampResponse);
  this.setRequestXml(getRequestXml());


 }
 this.RetrieveTimestampRequest.__class = true;

 this.RetrieveTimestampResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveTimestampRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveTimestampResponse)) {
   return new Sdk.RetrieveTimestampResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _timestamp = null;

  // Internal property setter functions

  function _setTimestamp(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='Timestamp']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _timestamp = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getTimestamp = function () {
   ///<summary>
   /// Gets the time stamp of the metadata. 
   ///</summary>
   ///<returns type="String">
   /// The time stamp of the metadata. 
   ///</returns>
   return _timestamp;
  }

  //Set property values from responseXml constructor parameter
  _setTimestamp(responseXml);
 }
 this.RetrieveTimestampResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveTimestampRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveTimestampResponse.prototype = new Sdk.OrganizationResponse();
