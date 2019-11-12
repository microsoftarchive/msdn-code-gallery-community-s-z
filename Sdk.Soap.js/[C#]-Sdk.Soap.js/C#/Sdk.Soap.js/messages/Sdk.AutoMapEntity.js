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
this.AutoMapEntityRequest = function (entityMapId)
{
///<summary>
 /// Contains the data that is needed to generate a new set of attribute mappings based on the metadata. 
///</summary>
///<param name="entityMapId"  type="String">
 /// Sets the ID of the entity map to overwrite when the automated mapping is performed. 
///</param>
if (!(this instanceof Sdk.AutoMapEntityRequest)) {
return new Sdk.AutoMapEntityRequest(entityMapId);
}
Sdk.OrganizationRequest.call(this);

  // Internal properties
var _entityMapId = null;

// internal validation functions

function _setValidEntityMapId(value) {
 if (Sdk.Util.isGuid(value)) {
  _entityMapId = value;
 }
 else {
  throw new Error("Sdk.AutoMapEntityRequest EntityMapId property is required and must be a String.")
 }
}

//Set internal properties from constructor parameters
  if (typeof entityMapId != "undefined") {
   _setValidEntityMapId(entityMapId);
  }

  function getRequestXml() {
return ["<d:request>",
        "<a:Parameters>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>EntityMapId</b:key>",
           (_entityMapId == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"e:guid\">", _entityMapId, "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

        "</a:Parameters>",
        "<a:RequestId i:nil=\"true\" />",
        "<a:RequestName>AutoMapEntity</a:RequestName>",
      "</d:request>"].join("");
  }

  this.setResponseType(Sdk.AutoMapEntityResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setEntityMapId = function (value) {
  ///<summary>
   /// Sets the ID of the entity map to overwrite when the automated mapping is performed. Required. 
  ///</summary>
  ///<param name="value" type="String">
   /// The ID of the entity map to overwrite when the automated mapping is performed.
  ///</param>
   _setValidEntityMapId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.AutoMapEntityRequest.__class = true;

this.AutoMapEntityResponse = function (responseXml) {
  ///<summary>
  /// Response to AutoMapEntityRequest
  ///</summary>
  if (!(this instanceof Sdk.AutoMapEntityResponse)) {
   return new Sdk.AutoMapEntityResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // This message returns no values

 }
 this.AutoMapEntityResponse.__class = true;
}).call(Sdk)

Sdk.AutoMapEntityRequest.prototype = new Sdk.OrganizationRequest();
Sdk.AutoMapEntityResponse.prototype = new Sdk.OrganizationResponse();
