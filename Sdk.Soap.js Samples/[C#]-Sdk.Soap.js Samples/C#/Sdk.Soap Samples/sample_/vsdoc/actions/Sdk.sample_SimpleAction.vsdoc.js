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
(function () {
this.sample_SimpleActionRequest = function (
stringIn
)
{
///<summary>
/// 
///</summary>
///<param name="stringIn"  type="String">
/// [Add Description]
///</param>
if (!(this instanceof Sdk.sample_SimpleActionRequest)) {
return new Sdk.sample_SimpleActionRequest(stringIn);
}
Sdk.OrganizationRequest.call(this);

  // Internal properties
var _StringIn = null;

// internal validation functions

function _setValidStringIn(value) {
 if (typeof value == "string") {
  _StringIn = value;
 }
 else {
  throw new Error("Sdk.sample_SimpleActionRequest StringIn property is required and must be a String.")
 }
}

//Set internal properties from constructor parameters
  if (typeof stringIn != "undefined") {
   _setValidStringIn(stringIn);
  }

  function getRequestXml() {
return ["<d:request>",
        "<a:Parameters>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>StringIn</b:key>",
           (_StringIn == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"c:string\">", _StringIn, "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

        "</a:Parameters>",
        "<a:RequestId i:nil=\"true\" />",
        "<a:RequestName>sample_SimpleAction</a:RequestName>",
      "</d:request>"].join("");
  }

  this.setResponseType(Sdk.sample_SimpleActionResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setStringIn = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="String">
  /// [Add Description]
  ///</param>
   _setValidStringIn(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.sample_SimpleActionRequest.__class = true;

this.sample_SimpleActionResponse = function (responseXml) {
  ///<summary>
  /// Response to sample_SimpleActionRequest
  ///</summary>
  if (!(this instanceof Sdk.sample_SimpleActionResponse)) {
   return new Sdk.sample_SimpleActionResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _stringOut = null;

  // Internal property setter functions

  function _setStringOut(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='StringOut']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _stringOut = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getStringOut = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="String">
  /// [Add Description]
  ///</returns>
   return _stringOut;
  }

  //Set property values from responseXml constructor parameter
  _setStringOut(responseXml);
 }
 this.sample_SimpleActionResponse.__class = true;
}).call(Sdk)

Sdk.sample_SimpleActionRequest.prototype = new Sdk.OrganizationRequest();
Sdk.sample_SimpleActionResponse.prototype = new Sdk.OrganizationResponse();
