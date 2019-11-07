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
this.new_TestActionRequest = function (
testBoolean,
testDateTime,
testDecimal,
testEntity,
testEntityCollection,
testEntityReference,
testFloat,
testInteger,
testMoney,
testPicklist,
testString
)
{
///<summary>
/// This is the Description for the Process Test Action
///</summary>
///<param name="testBoolean"  type="Boolean">
/// [Add Description]
///</param>
///<param name="testDateTime" optional="true" type="Date">
/// [Add Description]
///</param>
///<param name="testDecimal" optional="true" type="Number">
/// [Add Description]
///</param>
///<param name="testEntity" optional="true" type="Sdk.Entity">
/// [Add Description]
///</param>
///<param name="testEntityCollection" optional="true" type="Sdk.EntityCollection">
/// [Add Description]
///</param>
///<param name="testEntityReference" optional="true" type="Sdk.EntityReference">
/// [Add Description]
///</param>
///<param name="testFloat" optional="true" type="Number">
/// [Add Description]
///</param>
///<param name="testInteger" optional="true" type="Number">
/// [Add Description]
///</param>
///<param name="testMoney" optional="true" type="Number">
/// [Add Description]
///</param>
///<param name="testPicklist" optional="true" type="Number">
/// [Add Description]
///</param>
///<param name="testString"  type="String">
/// [Add Description]
///</param>
if (!(this instanceof Sdk.new_TestActionRequest)) {
return new Sdk.new_TestActionRequest(testBoolean, testDateTime, testDecimal, testEntity, testEntityCollection, testEntityReference, testFloat, testInteger, testMoney, testPicklist, testString);
}
Sdk.OrganizationRequest.call(this);

  // Internal properties
var _testBoolean = null;
var _testDateTime = null;
var _testDecimal = null;
var _testEntity = null;
var _testEntityCollection = null;
var _testEntityReference = null;
var _testFloat = null;
var _testInteger = null;
var _testMoney = null;
var _testPicklist = null;
var _testString = null;

// internal validation functions

function _setValidTestBoolean(value) {
 if (typeof value == "boolean") {
  _testBoolean = value;
 }
 else {
  throw new Error("Sdk.new_TestActionRequest TestBoolean property is required and must be a Boolean.")
 }
}

function _setValidTestDateTime(value) {
 if (value == null || value instanceof Date) {
  _testDateTime = value;
 }
 else {
  throw new Error("Sdk.new_TestActionRequest TestDateTime property must be a Date or null.")
 }
}

function _setValidTestDecimal(value) {
 if (value == null || typeof value == "number") {
  _testDecimal = value;
 }
 else {
  throw new Error("Sdk.new_TestActionRequest TestDecimal property must be a Number or null.")
 }
}

function _setValidTestEntity(value) {
 if (value == null || value instanceof Sdk.Entity) {
  _testEntity = value;
 }
 else {
  throw new Error("Sdk.new_TestActionRequest TestEntity property must be a Sdk.Entity or null.")
 }
}

function _setValidTestEntityCollection(value) {
 if (value == null || value instanceof Sdk.EntityCollection) {
  _testEntityCollection = value;
 }
 else {
  throw new Error("Sdk.new_TestActionRequest TestEntityCollection property must be a Sdk.EntityCollection or null.")
 }
}

function _setValidTestEntityReference(value) {
 if (value == null || value instanceof Sdk.EntityReference) {
  _testEntityReference = value;
 }
 else {
  throw new Error("Sdk.new_TestActionRequest TestEntityReference property must be a Sdk.EntityReference or null.")
 }
}

function _setValidTestFloat(value) {
 if (value == null || typeof value == "number") {
  _testFloat = value;
 }
 else {
  throw new Error("Sdk.new_TestActionRequest TestFloat property must be a Number or null.")
 }
}

function _setValidTestInteger(value) {
 if (value == null || typeof value == "number") {
  _testInteger = value;
 }
 else {
  throw new Error("Sdk.new_TestActionRequest TestInteger property must be a Number or null.")
 }
}

function _setValidTestMoney(value) {
 if (value == null || typeof value == "number") {
  _testMoney = value;
 }
 else {
  throw new Error("Sdk.new_TestActionRequest TestMoney property must be a Number or null.")
 }
}

function _setValidTestPicklist(value) {
 if (value == null || typeof value == "number") {
  _testPicklist = value;
 }
 else {
  throw new Error("Sdk.new_TestActionRequest TestPicklist property must be a Number or null.")
 }
}

function _setValidTestString(value) {
 if (typeof value == "string") {
  _testString = value;
 }
 else {
  throw new Error("Sdk.new_TestActionRequest TestString property is required and must be a String.")
 }
}

//Set internal properties from constructor parameters
  if (typeof testBoolean != "undefined") {
   _setValidTestBoolean(testBoolean);
  }
  if (typeof testDateTime != "undefined") {
   _setValidTestDateTime(testDateTime);
  }
  if (typeof testDecimal != "undefined") {
   _setValidTestDecimal(testDecimal);
  }
  if (typeof testEntity != "undefined") {
   _setValidTestEntity(testEntity);
  }
  if (typeof testEntityCollection != "undefined") {
   _setValidTestEntityCollection(testEntityCollection);
  }
  if (typeof testEntityReference != "undefined") {
   _setValidTestEntityReference(testEntityReference);
  }
  if (typeof testFloat != "undefined") {
   _setValidTestFloat(testFloat);
  }
  if (typeof testInteger != "undefined") {
   _setValidTestInteger(testInteger);
  }
  if (typeof testMoney != "undefined") {
   _setValidTestMoney(testMoney);
  }
  if (typeof testPicklist != "undefined") {
   _setValidTestPicklist(testPicklist);
  }
  if (typeof testString != "undefined") {
   _setValidTestString(testString);
  }

  function getRequestXml() {
return ["<d:request>",
        "<a:Parameters>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>testBoolean</b:key>",
           (_testBoolean == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"c:boolean\">", _testBoolean, "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>testDateTime</b:key>",
           (_testDateTime == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"c:dateTime\">", _testDateTime.toISOString(), "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>testDecimal</b:key>",
           (_testDecimal == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"c:decimal\">", _testDecimal, "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>testEntity</b:key>",
           (_testEntity == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"a:Entity\">", _testEntity.toValueXml(), "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>testEntityCollection</b:key>",
           (_testEntityCollection == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"a:EntityCollection\">", _testEntityCollection.toValueXml(), "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>testEntityReference</b:key>",
           (_testEntityReference == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"a:EntityReference\">", _testEntityReference.toValueXml(), "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>testFloat</b:key>",
           (_testFloat == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"c:double\">", _testFloat, "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>testInteger</b:key>",
           (_testInteger == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"c:int\">", _testInteger, "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>testMoney</b:key>",
           (_testMoney == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"a:Money\">",
            "<a:Value>",_testMoney,"</a:Value>",
           "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>testPicklist</b:key>",
           (_testPicklist == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"a:OptionSetValue\">",
            "<a:Value>",_testPicklist,"</a:Value>",
           "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

          "<a:KeyValuePairOfstringanyType>",
            "<b:key>testString</b:key>",
           (_testString == null) ? "<b:value i:nil=\"true\" />" :
           ["<b:value i:type=\"c:string\">", _testString, "</b:value>"].join(""),
          "</a:KeyValuePairOfstringanyType>",

        "</a:Parameters>",
        "<a:RequestId i:nil=\"true\" />",
        "<a:RequestName>new_TestAction</a:RequestName>",
      "</d:request>"].join("");
  }

  this.setResponseType(Sdk.new_TestActionResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTestBoolean = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="Boolean">
  /// [Add Description]
  ///</param>
   _setValidTestBoolean(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTestDateTime = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="Date">
  /// [Add Description]
  ///</param>
   _setValidTestDateTime(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTestDecimal = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="Number">
  /// [Add Description]
  ///</param>
   _setValidTestDecimal(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTestEntity = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="Sdk.Entity">
  /// [Add Description]
  ///</param>
   _setValidTestEntity(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTestEntityCollection = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="Sdk.EntityCollection">
  /// [Add Description]
  ///</param>
   _setValidTestEntityCollection(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTestEntityReference = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="Sdk.EntityReference">
  /// [Add Description]
  ///</param>
   _setValidTestEntityReference(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTestFloat = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="Number">
  /// [Add Description]
  ///</param>
   _setValidTestFloat(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTestInteger = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="Number">
  /// [Add Description]
  ///</param>
   _setValidTestInteger(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTestMoney = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="Number">
  /// [Add Description]
  ///</param>
   _setValidTestMoney(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTestPicklist = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="Number">
  /// [Add Description]
  ///</param>
   _setValidTestPicklist(value);
   this.setRequestXml(getRequestXml());
  }

  this.setTestString = function (value) {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<param name="value" type="String">
  /// [Add Description]
  ///</param>
   _setValidTestString(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.new_TestActionRequest.__class = true;

this.new_TestActionResponse = function (responseXml) {
  ///<summary>
  /// Response to new_TestActionRequest
  ///</summary>
  if (!(this instanceof Sdk.new_TestActionResponse)) {
   return new Sdk.new_TestActionResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _testBooleanOut = null;
  var _testDateTimeOut = null;
  var _testDecimalOut = null;
  var _testEntityOut = null;
  var _testEntityCollectionOut = null;
  var _testEntityReferenceOut = null;
  var _testFloatOut = null;
  var _testIntegerOut = null;
  var _testMoneyOut = null;
  var _testPicklistOut = null;
  var _testStringOut = null;

  // Internal property setter functions

  function _setTestBooleanOut(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='testBooleanOut']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _testBooleanOut = (Sdk.Xml.getNodeText(valueNode) == "true") ? true : false;
   }
  }
  function _setTestDateTimeOut(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='testDateTimeOut']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _testDateTimeOut = new Date(Sdk.Xml.getNodeText(valueNode));
   }
  }
  function _setTestDecimalOut(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='testDecimalOut']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _testDecimalOut = parseFloat(Sdk.Xml.getNodeText(valueNode));
   }
  }
  function _setTestEntityOut(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='testEntityOut']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _testEntityOut = Sdk.Util.createEntityFromNode(valueNode);
   }
  }
  function _setTestEntityCollectionOut(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='testEntityCollectionOut']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _testEntityCollectionOut = Sdk.Util.createEntityCollectionFromNode(valueNode);
   }
  }
  function _setTestEntityReferenceOut(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='testEntityReferenceOut']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _testEntityReferenceOut = Sdk.Util.createEntityReferenceFromNode(valueNode);
   }
  }
  function _setTestFloatOut(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='testFloatOut']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _testFloatOut = parseFloat(Sdk.Xml.getNodeText(valueNode));
   }
  }
  function _setTestIntegerOut(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='testIntegerOut']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _testIntegerOut = parseInt(Sdk.Xml.getNodeText(valueNode), 10);
   }
  }
  function _setTestMoneyOut(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='testMoneyOut']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _testMoneyOut = parseFloat(Sdk.Xml.getNodeText(valueNode));
   }
  }
  function _setTestPicklistOut(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='testPicklistOut']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _testPicklistOut = parseInt(Sdk.Xml.getNodeText(valueNode), 10);
   }
  }
  function _setTestStringOut(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='testStringOut']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _testStringOut = Sdk.Xml.getNodeText(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getTestBooleanOut = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="Boolean">
  /// [Add Description]
  ///</returns>
   return _testBooleanOut;
  }
  this.getTestDateTimeOut = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="Date">
  /// [Add Description]
  ///</returns>
   return _testDateTimeOut;
  }
  this.getTestDecimalOut = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="Number">
  /// [Add Description]
  ///</returns>
   return _testDecimalOut;
  }
  this.getTestEntityOut = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="Sdk.Entity">
  /// [Add Description]
  ///</returns>
   return _testEntityOut;
  }
  this.getTestEntityCollectionOut = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="Sdk.EntityCollection">
  /// [Add Description]
  ///</returns>
   return _testEntityCollectionOut;
  }
  this.getTestEntityReferenceOut = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="Sdk.EntityReference">
  /// [Add Description]
  ///</returns>
   return _testEntityReferenceOut;
  }
  this.getTestFloatOut = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="Number">
  /// [Add Description]
  ///</returns>
   return _testFloatOut;
  }
  this.getTestIntegerOut = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="Number">
  /// [Add Description]
  ///</returns>
   return _testIntegerOut;
  }
  this.getTestMoneyOut = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="Number">
  /// [Add Description]
  ///</returns>
   return _testMoneyOut;
  }
  this.getTestPicklistOut = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="Number">
  /// [Add Description]
  ///</returns>
   return _testPicklistOut;
  }
  this.getTestStringOut = function () {
  ///<summary>
  /// [Add Description]
  ///</summary>
  ///<returns type="String">
  /// [Add Description]
  ///</returns>
   return _testStringOut;
  }

  //Set property values from responseXml constructor parameter
  _setTestBooleanOut(responseXml);
  _setTestDateTimeOut(responseXml);
  _setTestDecimalOut(responseXml);
  _setTestEntityOut(responseXml);
  _setTestEntityCollectionOut(responseXml);
  _setTestEntityReferenceOut(responseXml);
  _setTestFloatOut(responseXml);
  _setTestIntegerOut(responseXml);
  _setTestMoneyOut(responseXml);
  _setTestPicklistOut(responseXml);
  _setTestStringOut(responseXml);
 }
 this.new_TestActionResponse.__class = true;
}).call(Sdk)

Sdk.new_TestActionRequest.prototype = new Sdk.OrganizationRequest();
Sdk.new_TestActionResponse.prototype = new Sdk.OrganizationResponse();
