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
 this.UninstallSampleDataRequest = function () {
  ///<summary>
  /// 
  ///</summary>
  if (!(this instanceof Sdk.UninstallSampleDataRequest)) {
   return new Sdk.UninstallSampleDataRequest();
  }
  Sdk.OrganizationRequest.call(this);



  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters />",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>UninstallSampleData</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.UninstallSampleDataResponse);
  this.setRequestXml(getRequestXml());


 }
 this.UninstallSampleDataRequest.__class = true;

 this.UninstallSampleDataResponse = function (responseXml) {
  ///<summary>
  /// Response to UninstallSampleDataRequest
  ///</summary>
  if (!(this instanceof Sdk.UninstallSampleDataResponse)) {
   return new Sdk.UninstallSampleDataResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values
 }
 this.UninstallSampleDataResponse.__class = true;
}).call(Sdk)

Sdk.UninstallSampleDataRequest.prototype = new Sdk.OrganizationRequest();
Sdk.UninstallSampleDataResponse.prototype = new Sdk.OrganizationResponse();
