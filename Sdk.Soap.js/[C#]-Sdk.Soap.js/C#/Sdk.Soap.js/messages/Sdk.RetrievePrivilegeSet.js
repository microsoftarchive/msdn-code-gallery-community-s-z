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
 this.RetrievePrivilegeSetRequest = function () {
  ///<summary>
  /// Contains the data needed to retrieve the set of privileges defined in the system.
  ///</summary>
  if (!(this instanceof Sdk.RetrievePrivilegeSetRequest)) {
   return new Sdk.RetrievePrivilegeSetRequest();
  }
  Sdk.OrganizationRequest.call(this);

  // This message has no parameters

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters />",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrievePrivilegeSet</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrievePrivilegeSetResponse);
  this.setRequestXml(getRequestXml());


 }
 this.RetrievePrivilegeSetRequest.__class = true;

 this.RetrievePrivilegeSetResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrievePrivilegeSetRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrievePrivilegeSetResponse)) {
   return new Sdk.RetrievePrivilegeSetResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _entityCollection = null;

  // Internal property setter functions

  function _setEntityCollection(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='EntityCollection']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _entityCollection = Sdk.Util.createEntityCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEntityCollection = function () {
   ///<summary>
   /// Gets the resulting collection of privileges.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// The resulting collection of privileges.
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.RetrievePrivilegeSetResponse.__class = true;
}).call(Sdk)

Sdk.RetrievePrivilegeSetRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrievePrivilegeSetResponse.prototype = new Sdk.OrganizationResponse();
