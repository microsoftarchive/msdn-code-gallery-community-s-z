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
(function () {
 this.AddToQueueRequest = function (target, sourceQueueId, destinationQueueId, queueItemProperties)
{
///<summary>
 /// Contains the data that is needed to move an entity record from a source queue to a destination queue. 
///</summary>
///<param name="target"  type="Sdk.EntityReference">
 /// Sets the target record to add to the destination queue.
///</param>
///<param name="sourceQueueId" optional="true" type="String">
 /// Sets the properties that are needed to create a queue item in the destination queue.
///</param>
///<param name="destinationQueueId"  type="String">
 /// Sets the ID of the destination queue. 
///</param>
///<param name="queueItemProperties" optional="true" type="Sdk.Entity">
 /// Sets the properties that are needed to create a queue item in the destination queue.
///</param>
if (!(this instanceof Sdk.AddToQueueRequest)) {
return new Sdk.AddToQueueRequest(target, sourceQueueId, destinationQueueId, queueItemProperties);
}
Sdk.OrganizationRequest.call(this);

  // Internal properties
var _target = null;
var _sourceQueueId = null;
var _destinationQueueId = null;
var _queueItemProperties = null;

// internal validation functions

function _setValidTarget(value) {
 if (value instanceof Sdk.EntityReference) {
  _target = value;
 }
 else {
  throw new Error("Sdk.AddToQueueRequest Target property is required and must be a Sdk.EntityReference.")
 }
}

function _setValidSourceQueueId(value) {
 if (value == null || Sdk.Util.isGuid(value)) {
  _sourceQueueId = value;
 }
 else {
  throw new Error("Sdk.AddToQueueRequest SourceQueueId property must be a String or null.")
 }
}

function _setValidDestinationQueueId(value) {
 if (Sdk.Util.isGuid(value)) {
  _destinationQueueId = value;
 }
 else {
  throw new Error("Sdk.AddToQueueRequest DestinationQueueId property is required and must be a String.")
 }
}

function _setValidQueueItemProperties(value) {
 if (value == null || value instanceof Sdk.Entity) {
  _queueItemProperties = value;
 }
 else {
  throw new Error("Sdk.AddToQueueRequest QueueItemProperties property must be a Sdk.Entity or null.")
 }
}

//Set internal properties from constructor parameters
  if (typeof target != "undefined") {
   _setValidTarget(target);
  }
  if (typeof sourceQueueId != "undefined") {
   _setValidSourceQueueId(sourceQueueId);
  }
  if (typeof destinationQueueId != "undefined") {
   _setValidDestinationQueueId(destinationQueueId);
  }
  if (typeof queueItemProperties != "undefined") {
   _setValidQueueItemProperties(queueItemProperties);
  }

  function getRequestXml() {
return ["<d:request>",
        "<a:Parameters>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>Target</b:key>",
           (_target == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"a:EntityReference\">", _target.toValueXml(), "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>SourceQueueId</b:key>",
           (_sourceQueueId == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"e:guid\">", _sourceQueueId, "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>DestinationQueueId</b:key>",
           (_destinationQueueId == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"e:guid\">", _destinationQueueId, "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>QueueItemProperties</b:key>",
           (_queueItemProperties == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"a:Entity\">", _queueItemProperties.toValueXml(), "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

        "</a:Parameters>",
        "<a:RequestId i:nil=\"true\" />",
        "<a:RequestName>AddToQueue</a:RequestName>",
      "</d:request>"].join("");
  }

  this.setResponseType(Sdk.AddToQueueResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTarget = function (value) {
  ///<summary>
   /// Sets the target record to add to the destination queue. Required. 
  ///</summary>
  ///<param name="value" type="Sdk.EntityReference">
   /// The target record to add to the destination queue.
  ///</param>
   _setValidTarget(value);
   this.setRequestXml(getRequestXml());
  }

  this.setSourceQueueId = function (value) {
  ///<summary>
   /// Sets the ID of the source queue. Optional. 
  ///</summary>
  ///<param name="value" type="String">
   /// The ID of the source queue
  ///</param>
   _setValidSourceQueueId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setDestinationQueueId = function (value) {
  ///<summary>
   /// Sets the ID of the destination queue. Required. 
  ///</summary>
  ///<param name="value" type="String">
   /// The ID of the destination queue.
  ///</param>
   _setValidDestinationQueueId(value);
   this.setRequestXml(getRequestXml());
  }

  this.setQueueItemProperties = function (value) {
  ///<summary>
   /// Sets the properties that are needed to create a queue item in the destination queue. Optional. 
  ///</summary>
  ///<param name="value" type="Sdk.Entity">
   /// The properties that are needed to create a queue item in the destination queue.
  ///</param>
   _setValidQueueItemProperties(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.AddToQueueRequest.__class = true;

this.AddToQueueResponse = function (responseXml) {
  ///<summary>
 /// Contains the response from the AddToQueueRequest class. 
  ///</summary>
  if (!(this instanceof Sdk.AddToQueueResponse)) {
   return new Sdk.AddToQueueResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _queueItemId = null;

  // Internal property setter functions

  function _setQueueItemId(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='QueueItemId']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _queueItemId = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getQueueItemId = function () {
  ///<summary>
   /// Gets the ID of the queue item that is created in the destination queue. 
  ///</summary>
  ///<returns type="String">
   /// The ID of the queue item that is created in the destination queue. 
  ///</returns>
   return _queueItemId;
  }

  //Set property values from responseXml constructor parameter
  _setQueueItemId(responseXml);
 }
 this.AddToQueueResponse.__class = true;
}).call(Sdk)

Sdk.AddToQueueRequest.prototype = new Sdk.OrganizationRequest();
Sdk.AddToQueueResponse.prototype = new Sdk.OrganizationResponse();
