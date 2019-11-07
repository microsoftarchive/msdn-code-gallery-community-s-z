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
this.PublishAllXmlRequest = function (){
///<summary>
/// Contains the data that is needed to  publish all changes to solution components. 
///</summary>
if (!(this instanceof Sdk.PublishAllXmlRequest)) {
return new Sdk.PublishAllXmlRequest();
}
Sdk.OrganizationRequest.call(this);

  // This message has no parameters

  function getRequestXml() {
return ["<d:request>",
        "<a:Parameters />",

        "<a:RequestId i:nil=\"true\" />",
        "<a:RequestName>PublishAllXml</a:RequestName>",
      "</d:request>"].join("");
  }

  this.setResponseType(Sdk.PublishAllXmlResponse);
  this.setRequestXml(getRequestXml());


 }
 this.PublishAllXmlRequest.__class = true;

this.PublishAllXmlResponse = function (responseXml) {
  ///<summary>
  /// Response to PublishAllXmlRequest
  ///</summary>
  if (!(this instanceof Sdk.PublishAllXmlResponse)) {
   return new Sdk.PublishAllXmlResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.PublishAllXmlResponse.__class = true;
}).call(Sdk)

Sdk.PublishAllXmlRequest.prototype = new Sdk.OrganizationRequest();
Sdk.PublishAllXmlResponse.prototype = new Sdk.OrganizationResponse();
