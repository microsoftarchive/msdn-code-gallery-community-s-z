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
 this.PublishXmlRequest = function (parameterXml) {
  ///<summary>
  /// Contains the data that is needed to  publish specified solution components. 
  ///</summary>
  ///<param name="parameterXml"  type="String">
  /// Sets the XML that defines which solution components to publish in this request. Required.
  ///</param>
  if (!(this instanceof Sdk.PublishXmlRequest)) {
   return new Sdk.PublishXmlRequest(parameterXml);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _parameterXml = null;

  // internal validation functions

  function _setValidParameterXml(value) {
   if (typeof value == "string") {
    _parameterXml = value;
   }
   else {
    throw new Error("Sdk.PublishXmlRequest ParameterXml property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof parameterXml != "undefined") {
   _setValidParameterXml(parameterXml);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>ParameterXml</b:key>",
              (_parameterXml == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _parameterXml, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>PublishXml</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.PublishXmlResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setParameterXml = function (value) {
   ///<summary>
   /// Sets the XML that defines which solution components to publish in this request. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The XML that defines which solution components to publish in this request. Required.
   ///</param>
   _setValidParameterXml(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.PublishXmlRequest.__class = true;

 this.PublishXmlResponse = function (responseXml) {
  ///<summary>
  /// Response to PublishXmlRequest
  ///</summary>
  if (!(this instanceof Sdk.PublishXmlResponse)) {
   return new Sdk.PublishXmlResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.PublishXmlResponse.__class = true;
}).call(Sdk)

Sdk.PublishXmlRequest.prototype = new Sdk.OrganizationRequest();
Sdk.PublishXmlResponse.prototype = new Sdk.OrganizationResponse();
