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
 this.InstallSampleDataRequest = function () {
  ///<summary>
  /// Contains the data that is needed to  install the sample data.
  ///</summary>
  if (!(this instanceof Sdk.InstallSampleDataRequest)) {
   return new Sdk.InstallSampleDataRequest();
  }
  Sdk.OrganizationRequest.call(this);

  // This message has no parameters

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters />",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>InstallSampleData</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.InstallSampleDataResponse);
  this.setRequestXml(getRequestXml());


 }
 this.InstallSampleDataRequest.__class = true;

 this.InstallSampleDataResponse = function (responseXml) {
  ///<summary>
  /// Response to InstallSampleDataRequest
  ///</summary>
  if (!(this instanceof Sdk.InstallSampleDataResponse)) {
   return new Sdk.InstallSampleDataResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.InstallSampleDataResponse.__class = true;
}).call(Sdk)

Sdk.InstallSampleDataRequest.prototype = new Sdk.OrganizationRequest();
Sdk.InstallSampleDataResponse.prototype = new Sdk.OrganizationResponse();
