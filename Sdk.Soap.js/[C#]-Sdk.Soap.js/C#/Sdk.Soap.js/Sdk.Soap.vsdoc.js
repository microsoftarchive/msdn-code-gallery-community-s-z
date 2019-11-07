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

var Sdk = window.Sdk || { __namespace: true };
Sdk.Query = Sdk.Query || { __namespace: true };
Sdk.Async = Sdk.Async || { __namespace: true };
Sdk.Q = Sdk.Q || { __namespace: true };
Sdk.jQ = Sdk.jQ || { __namespace: true };
Sdk.Sync = Sdk.Sync || { __namespace: true };
Sdk.Util = Sdk.Util || { __namespace: true };
Sdk.Xml = Sdk.Xml || { __namespace: true };

var constructorNotImplementedError = "Constructor not implemented this is a static enum.";



(function ()
{
 
 //Namespaces used
 // Rather than the seemingly random assignment of namespace aliases you see in the SOAPLogger tool,
 // This library always uses these specific aliases
 //Additional namespaces can be added to this list
 var ns = {
  "s": "http://schemas.xmlsoap.org/soap/envelope/",
  "a": "http://schemas.microsoft.com/xrm/2011/Contracts",
  "i": "http://www.w3.org/2001/XMLSchema-instance",
  "b": "http://schemas.datacontract.org/2004/07/System.Collections.Generic",
  "c": "http://www.w3.org/2001/XMLSchema",
  "d": "http://schemas.microsoft.com/xrm/2011/Contracts/Services",
  "e": "http://schemas.microsoft.com/2003/10/Serialization/",
  "f": "http://schemas.microsoft.com/2003/10/Serialization/Arrays",
  "g": "http://schemas.microsoft.com/crm/2011/Contracts",
  "h": "http://schemas.microsoft.com/xrm/2011/Metadata",
  "j": "http://schemas.microsoft.com/xrm/2011/Metadata/Query",
  "k": "http://schemas.microsoft.com/xrm/2013/Metadata",
  "l": "http://schemas.microsoft.com/xrm/2012/Contracts"
 };

 this.getEnvelopeHeader = function () {

  var _envelopeHeader = ["<s:Envelope "];
  for (var i in ns) {
   _envelopeHeader.push(" xmlns:" + i + "=\"" + ns[i] + "\"")
  }
  _envelopeHeader.push("><s:Header><a:SdkClientVersion>6.0</a:SdkClientVersion></s:Header>");
  return _envelopeHeader.join("");

 };

 this.setSelectionNamespaces = function (doc) {
  ///<summary>
  /// Sets the namespaces to be used when querying the document
  ///</summary>
  ///<param name="doc" type="XMLDocument" optional='false'>
  /// <para>The XML Document</para>
  ///</param>
  if (typeof doc.setProperty != "undefined") {
   var namespaces = [];
   for (var i in ns) {
    namespaces.push("xmlns:" + i + "='" + ns[i] + "'");
   }
   doc.setProperty("SelectionNamespaces", namespaces.join(" "));
  }

 }

 this.NSResolver = function (prefix) {
  ///<summary>
  /// Resolves the namespaces to be used when querying the document
  ///</summary>
  ///<param name="prefix" type="String" optional='false'>
  /// <para>The prefix representing the namespace</para>
  ///</param>
  return ns[prefix] || null;
 }

 this.selectNodes = function (node, xPath) {
  ///<summary>
  /// Returns the nodes from the node as defined by the xPath
  ///</summary>
  ///<param name="node" type="Object" optional='false'>
  /// <para>The Xml Document or Node containing the nodes</para>
  ///</param>
  ///<param name="xPath" type="String" optional='false'>
  /// <para>The XPath expression specifying the nodes</para>
  ///</param>
  if (typeof (node.selectNodes) != "undefined") {
   return node.selectNodes(xPath);
  }
  else {
   var output = [];
   var XPathResults = node.evaluate(xPath, node, Sdk.Xml.NSResolver, XPathResult.ANY_TYPE, null);
   var result = XPathResults.iterateNext();
   while (result) {
    output.push(result);
    result = XPathResults.iterateNext();
   }
   return output;
  }
 }

 this.selectSingleNode = function (node, xPath) {
  ///<summary>
  /// Returns the node from the node as defined by the xPath
  ///</summary>
  ///<param name="node" type="Object" optional='false'>
  /// <para>The Xml Document or Node containing the node</para>
  ///</param>
  ///<param name="xPath" type="String" optional='false'>
  /// <para>The XPath expression specifying the node</para>
  ///</param>
  if (typeof (node.selectSingleNode) != "undefined") {
   return node.selectSingleNode(xPath);
  }
  else {
   var xpe = new XPathEvaluator();
   var xPathNode = xpe.evaluate(xPath, node, Sdk.Xml.NSResolver, XPathResult.FIRST_ORDERED_NODE_TYPE, null);
   return (xPathNode != null) ? xPathNode.singleNodeValue : null;
  }

 }

 this.selectSingleNodeText = function (node, xPath) {
  ///<summary>
  /// Returns the text of the node from the node as defined by the xPath
  ///</summary>
  ///<param name="node" type="Object" optional='false'>
  /// <para>The Xml Document or Node containing the node with the text</para>
  ///</param>
  ///<param name="xPath" type="String" optional='false'>
  /// <para>The XPath expression specifying the node</para>
  ///</param>
  var x = Sdk.Xml.selectSingleNode(node, xPath);
  if (Sdk.Xml.isNodeNull(x))
  { return null; }
  if (typeof (x.text) != "undefined") {
   return x.text;
  }
  else {
   return x.textContent;
  }
 }

 this.getNodeText = function (node) {
  ///<summary>
  /// Returns the text of the node
  ///</summary>
  ///<param name="node" type="Object" optional='false'>
  /// <para>The node containing  the text</para>
  ///</param>
  if (Sdk.Xml.isNodeNull(node))
  { return null; }
  if (typeof (node.text) != "undefined") {
   return node.text;
  }
  else {
   return node.textContent;
  }
 }

 this.isNodeNull = function (node) {
  ///<summary>
  /// Returns whether the node is null
  ///</summary>
  ///<param name="node" type="Object" optional='false'>
  /// <para>The node</para>
  ///</param>
  if (node == null)
  { return true; }
  if (
   (node.attributes != null) &&
   (node.attributes.getNamedItem("i:nil") != null) &&
   (node.attributes.getNamedItem("i:nil").value == "true")
   )
  { return true; }
  return false;
 }

 this.getNodeName = function (node) {
  ///<summary>
  /// Returns the name of the node
  ///</summary>
  ///<param name="node" type="Object" optional='false'>
  /// <para>The node</para>
  ///</param>
  if (typeof (node.baseName) != "undefined") {
   return node.baseName;
  }
  else {
   return node.localName;
  }
 }

 this.xmlEncode = function (strInput) {
  ///<summary>
  /// Encodes a string of XML
  ///</summary>
  ///<param name="strInput" type="String" optional='false'>
  /// <para>The string of XML to be encoded</para>
  ///</param>
  var c;
  var XmlEncode = '';
  if (strInput == null) {
   return null;
  }
  if (strInput == '') {
   return '';
  }
  for (var cnt = 0; cnt < strInput.length; cnt++) {
   c = strInput.charCodeAt(cnt);
   if (((c > 96) && (c < 123)) ||
   ((c > 64) && (c < 91)) ||
   (c == 32) ||
   ((c > 47) && (c < 58)) ||
   (c == 46) ||
   (c == 44) ||
   (c == 45) ||
   (c == 95)) {
    XmlEncode = XmlEncode + String.fromCharCode(c);
   }
   else {
    XmlEncode = XmlEncode + '&#' + c + ';';
   }
  }
  return XmlEncode;
 }

 this.serializeXmlNode = function (node) {
  ///<summary>
  /// returns a string representation of an XML node
  ///</summary>
  ///<param name="node" type="Object" optional='false'>
  /// <para>The string of XML to be encoded</para>
  ///</param>
  ///<param type="String" >
  /// The string representing the XML Node
  ///</param>
  if (typeof node.xml != "undefined") {
   return node.xml;
  }
  else {
   return (new XMLSerializer()).serializeToString(node);
  }

 }


}).call(Sdk.Xml);

(function ()
{
 
 //Sdk.AccessRights START
 this.AccessRights = function () {
  /// <summary>Sdk.AccessRights enum summary</summary>
  /// <field name="None" type="String" static="true">None</field>
  /// <field name="ReadAccess" type="String" static="true">ReadAccess</field>
  /// <field name="WriteAccess" type="String" static="true">WriteAccess</field>
  /// <field name="ShareAccess" type="String" static="true">ShareAccess</field>
  /// <field name="AssignAccess" type="String" static="true">AssignAccess</field>
  /// <field name="AppendAccess" type="String" static="true">AppendAccess</field>
  /// <field name="AppendToAccess" type="String" static="true">AppendToAccess</field>
  /// <field name="CreateAccess" type="String" static="true">CreateAccess</field>
  /// <field name="DeleteAccess" type="String" static="true">DeleteAccess</field>
  /// <field name="All" type="String" static="true">All</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.AccessRights END
 //--------------------------------------------------------------------
 //Sdk.Attribute START

 this.AttributeBase = function () {
  ///<summary>
  /// Internal Use Only
  ///</summary>
  if (!(this instanceof Sdk.AttributeBase)) {
   return new Sdk.AttributeBase();
  }

  var _name, _type;
  var _value = null;
  var _isChanged = false;
  var _isValueSet = false;


  function _setValidName(value) {
   if (typeof value == "string") {
    _name = value;
   }
   else {
    throw new Error("Sdk.AttributeBase Name property must be a string.");
   }

  }
  function _setValidValue(value) {
   if (typeof value == "undefined") {
    throw new Error("Sdk.AttributeBase Value property must not be undefined.");
   }

   //Dates require special handling for comparing
   if (value instanceof Date && _value instanceof Date) {
    if (value.toISOString() == _value.toISOString()) {
     //Don't set the value if it is not different.
     return;
    }

   }
   else {
    if (value == _value) {
     //Don't set the value if it is not different.
     return;
    }
   }
   _value = value;
   _isChanged = true;
   _isValueSet = true;


  }
  function _setValidType(value) {
   for (var i in Sdk.ValueType) {
    if (value == i) {
     _type = value;
     return;
    }
   }
   throw new Error("Sdk.AttributeBase Type property must be an Sdk.ValueType.");
  }
  function _setValidIsChanged(value) {
   if (typeof value == "boolean") {
    _isChanged = value;
   }
   else {
    throw new Error("Sdk.AttributeBase IsChanged property must be a Boolean.");
   }
  }
  this.getIsChanged = function () {
   ///<summary>
   /// Gets whether the value of the attribute has changed.
   ///</summary>
   ///<returns type="Boolean" />
   return _isChanged;
  }
  this.getName = function () {
   ///<summary>
   /// Gets the logical name of the attribute.
   ///</summary>
   ///<returns type="String">
   /// The logical name of the attribute.
   ///</returns>
   return _name;
  }
  this.getType = function () {
   ///<summary>
   /// Gets the value type of the attribute.
   ///</summary>
   ///<returns type="Sdk.ValueType">
   /// The value type of the attribute.
   ///</returns>
   return _type;
  }
  this.getValue = function () {
   ///<summary>
   /// <para>Gets the value of the attribute.</para>
   /// <para>The type of value depends on the type of attribute</para>
   ///</summary>
   ///<returns type="Object">
   /// The value of the attribute.
   ///</returns>
   return _value;
  }
  this.isValueSet = function () {
   ///<summary>
   /// Whether the value of the attribute is set.
   ///</summary>
   ///<returns type="Boolean" />
   return _isValueSet;
  }
  this.setIsChanged = function (isChanged) {
   ///<summary>
   /// Sets whether the value of the attribute has changed.
   ///</summary>
   ///<para name="isChanged" type="Boolean" optional="false" mayBeNull="false">
   /// Whether the value of the attribute has changed.
   ///</para>
   _setValidIsChanged(isChanged);
  }
  this.setName = function (name) {
   ///<summary>
   /// Sets the name of the attribute
   ///</summary>
   ///<para name="name" type="String" optional="false" mayBeNull="false">
   /// The name of the attribute.
   ///</para>
   _setValidName(name);
  }
  this.setType = function (type) {
   ///<summary>
   /// For internal use only.
   ///</summary>
   ///<para name="type" type="Sdk.ValueType" optional="false" mayBeNull="false">
   /// The type of the attribute.
   ///</para>
   _setValidType(type);
  }
  this.setValidValue = function (value) {
   ///<summary>
   /// Internal Use Only
   ///</summary>
   _setValidValue(value);
  }


 }

 this.Boolean = function (name, value) {
  ///<summary>
  /// A Boolean Attribute
  ///</summary>
  ///<param name="name" type="String" optional="false" mayBeNull="false">
  /// The logical name of the attribute
  ///</param>
  ///<param name="value" type="Boolean" optional="true" mayBeNull="false">
  /// The value of the attribute
  ///</param>
  if (!(this instanceof Sdk.Boolean)) {
   return new Sdk.Boolean(name, value);
  }
  Sdk.AttributeBase.call(this);
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value of a Boolean attribute
   ///</summary>
   ///<param name="value" type="Boolean" optional='false' mayBeNull='false'>
   /// The value to set
   ///</param>
   if (typeof value == "boolean") {
    this.setValidValue(value);
   }
   else {
    throw new Error("Sdk.Boolean value property must be a Boolean.");
   }
  }
  //Set internal properties from constructor parameters
  this.setName(name);
  this.setType(Sdk.ValueType.boolean);
  if (typeof value != "undefined") {
   this.setValue(value);
  }

 }
 this.Boolean.__class = true;

 this.BooleanManagedProperty = function (name, value) {
  ///<summary>
  /// A BooleanManagedProperty Attribute
  ///</summary>
  ///<param name="name" type="String" optional="false" mayBeNull="false">
  /// The logical name of the attribute
  ///</param>
  ///<param name="value" type="Sdk.BooleanManagedPropertyValue" optional="false" mayBeNull="false">
  /// The value of the managed property.
  ///</param>


  if (!(this instanceof Sdk.BooleanManagedProperty)) {
   return new Sdk.BooleanManagedProperty(name, value);
  }
  Sdk.AttributeBase.call(this);
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value of a BooleanManagedProperty attribute
   ///</summary>
   ///<param name="value" type="Sdk.BooleanManagedPropertyValue" optional='false' mayBeNull='false'>
   /// The value to set
   ///</param>
   if (value instanceof Sdk.BooleanManagedPropertyValue) {
    this.setValidValue(value);
   }
   else {
    throw new Error("Sdk.BooleanManagedProperty value property must be a Sdk.BooleanManagedPropertyValue.");
   }
  }
  //Set internal properties from constructor parameters
  this.setName(name);
  this.setType(Sdk.ValueType.booleanManagedProperty);
  if (typeof value != "undefined") {
   this.setValue(value);
  }

 };
 this.BooleanManagedProperty.__class = true;

 this.DateTime = function (name, value) {
  ///<summary>
  /// A DateTime Attribute
  ///</summary>
  ///<param name="name" type="String" optional="false" mayBeNull="false">
  /// The logical name of the attribute
  ///</param>
  ///<param name="value" type="Date" optional="true" mayBeNull="true">
  /// The value of the attribute
  ///</param>
  if (!(this instanceof Sdk.DateTime)) {
   return new Sdk.DateTime(name, value);
  }
  Sdk.AttributeBase.call(this);
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value of a DateTime attribute
   ///</summary>
   ///<param name="value" type="Date" optional='false' mayBeNull='true'>
   /// The value to set
   ///</param>
   if (value == null || typeof value.getMonth == 'function') {
    this.setValidValue(value);
   }
   else {
    throw new Error("Sdk.DateTime value property must be a Date.");
   }
  }
  //Set internal properties from constructor parameters
  this.setName(name);
  this.setType(Sdk.ValueType.dateTime);
  if (typeof value != "undefined") {
   this.setValue(value);
  }
 }
 this.DateTime.__class = true;

 this.Decimal = function (name, value) {
  ///<summary>
  /// A Decimal Attribute
  ///</summary>
  ///<param name="name" type="String" optional="false" mayBeNull="false">
  /// The logical name of the attribute
  ///</param>
  ///<param name="value" type="Number" optional="true" mayBeNull="true">
  /// The value of the attribute
  ///</param>
  if (!(this instanceof Sdk.Decimal)) {
   return new Sdk.Decimal(name, value);
  }
  Sdk.AttributeBase.call(this);
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value of a Decimal attribute
   ///</summary>
   ///<param name="value" type="Number" optional='false' mayBeNull='true'>
   /// The value to set
   ///</param>
   if (value == null || typeof value == "number") {
    this.setValidValue(value);
   }
   else {
    throw new Error("Sdk.Decimal value property must be a Number.");
   }
  }
  //Set internal properties from constructor parameters
  this.setName(name);
  this.setType(Sdk.ValueType.decimal);
  if (typeof value != "undefined") {
   this.setValue(value);
  }
 }
 this.Decimal.__class = true;

 this.Double = function (name, value) {
  ///<summary>
  /// A Double Attribute
  ///</summary>
  ///<param name="name" type="String" optional="false" mayBeNull="false">
  /// The logical name of the attribute
  ///</param>
  ///<param name="value" type="Number" optional="true" mayBeNull="true">
  /// The value of the attribute
  ///</param>
  if (!(this instanceof Sdk.Double)) {
   return new Sdk.Double(name, value);
  }
  Sdk.AttributeBase.call(this);
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value of a Double attribute
   ///</summary>
   ///<param name="value" type="Number" optional='false' mayBeNull='true'>
   /// The value to set
   ///</param>
   if (value == null || typeof value == "number") {
    this.setValidValue(value);
   }
   else {
    throw new Error("Sdk.Double value property must be a Number.");
   }
  }
  //Set internal properties from constructor parameters
  this.setName(name);
  this.setType(Sdk.ValueType.double);
  if (typeof value != "undefined") {
   this.setValue(value);
  }
 }
 this.Double.__class = true;

 this.Guid = function (name, value) {
  ///<summary>
  /// A Guid Attribute
  ///</summary>
  ///<param name="name" type="String" optional="false" mayBeNull="false">
  /// The logical name of the attribute
  ///</param>
  ///<param name="value" type="String" optional="true" mayBeNull="true">
  /// The value of the attribute
  ///</param>
  if (!(this instanceof Sdk.Guid)) {
   return new Sdk.Guid(name, value);
  }
  Sdk.AttributeBase.call(this);
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value of a Guid attribute
   ///</summary>
   ///<param name="value" type="String" optional='false' mayBeNull='true'>
   /// The value to set
   ///</param>
   if (Sdk.Util.isGuidOrNull(value)) {
    this.setValidValue(value);
   }
   else {
    throw new Error("Sdk.Guid value property must be a String representation of a Guid value.");
   }
  }

  //Set internal properties from constructor parameters
  this.setName(name);
  this.setType(Sdk.ValueType.guid);
  if (typeof value != "undefined") {
   this.setValue(value);
  }
 }
 this.Guid.__class = true;

 this.Int = function (name, value) {
  ///<summary>
  /// A Integer Attribute
  ///</summary>
  ///<param name="name" type="String" optional="false" mayBeNull="false">
  /// The logical name of the attribute
  ///</param>
  ///<param name="value" type="Number" optional="true" mayBeNull="true">
  /// The value of the attribute
  ///</param>
  if (!(this instanceof Sdk.Int)) {
   return new Sdk.Int(name, value);
  }
  Sdk.AttributeBase.call(this);
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value of a Integer attribute
   ///</summary>
   ///<param name="value" type="Number" optional='false' mayBeNull='true'>
   /// The value to set
   ///</param>
   if (value == null || typeof value == "number") {
    this.setValidValue(parseInt(value, 10));
   }
   else {
    throw new Error("Sdk.Int value property must be a Number.");
   }
  }
  //Set internal properties from constructor parameters
  this.setName(name);
  this.setType(Sdk.ValueType.int);
  if (typeof value != "undefined") {
   this.setValue(value);
  }
 }
 this.Int.__class = true;

 this.Long = function (name, value) {
  ///<summary>
  /// A Long Attribute
  ///</summary>
  ///<param name="name" type="String" optional="false" mayBeNull="false">
  /// The logical name of the attribute
  ///</param>
  ///<param name="value" type="Number" optional="true" mayBeNull="true">
  /// The value of the attribute
  ///</param>
  if (!(this instanceof Sdk.Long)) {
   return new Sdk.Long(name, value);
  }
  Sdk.AttributeBase.call(this);
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value of a Long attribute
   ///</summary>
   ///<param name="value" type="Number" optional='false' mayBeNull='true'>
   /// The value to set
   ///</param>
   if (value == null || typeof value == "number") {
    this.setValidValue(value);
   }
   else {
    throw new Error("Sdk.Long value property must be a Number.");
   }
  }
  //Set internal properties from constructor parameters
  this.setName(name);
  this.setType(Sdk.ValueType.long);
  if (typeof value != "undefined") {
   this.setValue(value);
  }
 }
 this.Long.__class = true;

 this.Lookup = function (name, value) {
  ///<summary>
  /// A Lookup Attribute
  ///</summary>
  ///<param name="name" type="String" optional="false" mayBeNull="false">
  /// The logical name of the attribute
  ///</param>
  ///<param name="value" type="Sdk.EntityReference" optional="true" mayBeNull="false">
  /// The value of the attribute
  ///</param>
  if (!(this instanceof Sdk.Lookup)) {
   return new Sdk.Lookup(name, value);
  }
  Sdk.AttributeBase.call(this);
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value of a Lookup attribute
   ///</summary>
   ///<param name="value" type="Sdk.EntityReference" optional='false' mayBeNull='true'>
   /// The value to set
   ///</param>
   if (value == null || value instanceof Sdk.EntityReference) {
    this.setValidValue(value);
   }
   else {
    throw new Error("Sdk.Lookup value property must be a Sdk.EntityReference.");
   }
  }
  //Set internal properties from constructor parameters
  this.setName(name);
  this.setType(Sdk.ValueType.entityReference);
  if (typeof value != "undefined") {
   this.setValue(value);
  }

 }
 this.Lookup.__class = true;

 this.Money = function (name, value) {
  ///<summary>
  /// A Money Attribute
  ///</summary>
  ///<param name="name" type="String" optional="false" mayBeNull="false">
  /// The logical name of the attribute
  ///</param>
  ///<param name="value" type="Number" optional="true" mayBeNull="true">
  /// The value of the attribute
  ///</param>
  if (!(this instanceof Sdk.Money)) {
   return new Sdk.Money(name, value);
  }
  Sdk.AttributeBase.call(this);
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value of a Money attribute
   ///</summary>
   ///<param name="value" type="Number" optional='false' mayBeNull='true'>
   /// The value to set
   ///</param>
   if (value == null || typeof value == "number") {
    this.setValidValue(value);
   }
   else {
    throw new Error("Sdk.Money value property must be a Number.");
   }
  }
  //Set internal properties from constructor parameters
  this.setName(name);
  this.setType(Sdk.ValueType.money);
  if (typeof value != "undefined") {
   this.setValue(value);
  }
 }
 this.Money.__class = true;

 this.OptionSet = function (name, value) {
  ///<summary>
  /// An OptionSet Attribute
  ///</summary>
  ///<param name="name" type="String" optional="false" mayBeNull="false">
  /// The logical name of the attribute
  ///</param>
  ///<param name="value" type="Sdk.OptionSetValue" optional="true" mayBeNull="true">
  /// The value of the attribute
  ///</param>
  if (!(this instanceof Sdk.OptionSet)) {
   return new Sdk.OptionSet(name, value);
  }
  Sdk.AttributeBase.call(this);
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value of a OptionSet attribute
   ///</summary>
   ///<param name="value" type="Number" optional='false' mayBeNull='true'>
   /// The value to set
   ///</param>
   if (value == null || typeof value == "number") {
    this.setValidValue(value);
   }
   else {
    throw new Error("Sdk.OptionSet value property must be a Number.");
   }
  }
  //Set internal properties from constructor parameters
  this.setName(name);
  this.setType(Sdk.ValueType.optionSet);
  if (typeof value != "undefined") {
   this.setValue(value);
  }

 }
 this.OptionSet.__class = true;

 this.PartyList = function (name, value) {
  ///<summary>
  /// A PartyList Attribute
  ///</summary>
  ///<param name="name" type="String" optional="false" mayBeNull="false">
  /// The logical name of the attribute
  ///</param>
  ///<param name="value" type="Sdk.EntityCollection" optional="true" mayBeNull="true">
  /// The value of the attribute
  ///</param>
  if (!(this instanceof Sdk.PartyList)) {
   return new Sdk.PartyList(name, value);
  }
  Sdk.AttributeBase.call(this);
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value of a PartyList attribute
   ///</summary>
   ///<param name="value" type="PartyList" optional='false' mayBeNull='true'>
   /// The value to set
   ///</param>
   if (value == null || value instanceof Sdk.EntityCollection) {
    this.setValidValue(value);
   }
   else {
    throw new Error("Sdk.PartyList value property must be a Sdk.EntityCollection.");
   }
  }
  //Set internal properties from constructor parameters
  this.setName(name);
  this.setType(Sdk.ValueType.entityCollection);
  if (typeof value != "undefined") {
   this.setValue(value);
  }

 }
 this.PartyList.__class = true;

 this.String = function (name, value) {
  ///<summary>
  /// A String Attribute
  ///</summary>
  ///<param name="name" type="String" optional="false" mayBeNull="false">
  /// The logical name of the attribute
  ///</param>
  ///<param name="value" type="String" optional="true" mayBeNull="true">
  /// The value of the attribute
  ///</param>
  if (!(this instanceof Sdk.String)) {
   return new Sdk.String(name, value);
  }
  Sdk.AttributeBase.call(this);
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value of a String attribute
   ///</summary>
   ///<param name="value" type="String" optional='false' mayBeNull='true'>
   /// The value to set
   ///</param>
   if (value == null || typeof value == "string") {
    this.setValidValue(value);
   }
   else {
    throw new Error("Sdk.String value property must be a String.");
   }
  }
  //Set internal properties from constructor parameters
  this.setName(name);
  this.setType(Sdk.ValueType.string);
  if (typeof value != "undefined") {
   this.setValue(value);
  }

 }
 this.String.__class = true;


 this.BooleanManagedPropertyValue = function (canBeChanged, value, managedPropertyLogicalName) {
  ///<summary>
  /// A value for a BooleanManagedProperty attribute 
  ///</summary>
  ///<param name="canBeChanged" type="Boolean" optional="false" mayBeNull="false">
  /// Whether the managed property value can be changed.
  ///</param>
  ///<param name="value" type="Boolean" optional="false" mayBeNull="false">
  /// The value of the managed property.
  ///</param>
  ///<param name="managedPropertyLogicalName" type="String" optional="true" mayBeNull="true">
  /// The logical name for the managed property.
  ///</param>

  if (!(this instanceof Sdk.BooleanManagedPropertyValue)) {
   return new Sdk.BooleanManagedPropertyValue(canBeChanged, value, managedPropertyLogicalName);
  }

  var _canBeChanged = null;
  var _managedPropertyLogicalName = null;
  var _value = null;



  function _setValidCanBeChanged(value) {
   if (typeof value == "boolean") {
    _canBeChanged = value;
   }
   else { throw new Error("Sdk.BooleanManagedPropertyValue CanBeChanged property must be an Boolean.") }
  }
  function _setValidValue(value) {
   if (typeof value == "boolean") {
    _value = value;
   }
   else { throw new Error("Sdk.BooleanManagedPropertyValue Value property must be a Boolean.") }
  }
  function _setValidManagedPropertyLogicalName(value) {
   if (typeof value == "string" || value == null) {
    _managedPropertyLogicalName = value;
   }
   else { throw new Error("Sdk.BooleanManagedPropertyValue ManagedPropertyLogicalName property must be a String.") }
  }


  //Set internal properties from constructor parameters
  if (typeof canBeChanged != "undefined") {
   _setValidCanBeChanged(canBeChanged);
  }
  if (typeof managedPropertyLogicalName != "undefined") {
   _setValidManagedPropertyLogicalName(managedPropertyLogicalName);
  }
  if (typeof value != "undefined") {
   _setValidValue(value);
  }
  //public methods
  this.getCanBeChanged = function () {
   ///<summary>
   /// Gets the CanBeChanged value
   ///</summary>
   ///<returns type="Boolean">
   /// The CanBeChanged value.
   ///</returns>
   return _canBeChanged;
  };
  this.setCanBeChanged = function (canBeChanged) {
   ///<summary>
   /// Sets the CanBeChanged value
   ///</summary>
   ///<param name="canBeChanged" type="Boolean">
   /// The CanBeChanged value.
   ///</param>
   _setValidCanBeChanged(canBeChanged);
  };
  this.getManagedPropertyLogicalName = function () {
   ///<summary>
   /// Gets the ManagedPropertyLogicalName value
   ///</summary>
   ///<returns type="Sting">
   /// The ManagedPropertyLogicalName value.
   ///</returns>
   return _managedPropertyLogicalName;
  };
  this.setManagedPropertyLogicalName = function (managedPropertyLogicalName) {
   ///<summary>
   /// Sets the ManagedPropertyLogicalName value
   ///</summary>
   ///<param name="managedPropertyLogicalName" type="String">
   /// The ManagedPropertyLogicalName value.
   ///</param>
   _setValidManagedPropertyLogicalName(managedPropertyLogicalName);
  };
  this.getValue = function () {
   ///<summary>
   /// Gets the Value value.
   ///</summary>
   ///<returns type="Boolean">
   /// The Value value.
   ///</returns>
   return _value;
  };
  this.setValue = function (value) {
   ///<summary>
   /// Sets the Value value.
   ///</summary>
   ///<param name="value" type="Boolean">
   /// The Value value.
   ///</param>
   _setValidValue(value);
  };
 };
 this.BooleanManagedPropertyValue.__class = true;

 this.ValueType = function () {
  /// <summary>Sdk.ValueType  enum summary</summary>
  /// <field name="boolean" type="String" static="true"></field>
  /// <field name="booleanManagedProperty" type="String" static="true"></field>
  /// <field name="dateTime" type="String" static="true"></field>
  /// <field name="decimal" type="String" static="true"></field>
  /// <field name="double" type="String" static="true"></field>
  /// <field name="entityCollection" type="String" static="true"></field>
  /// <field name="entityReference" type="String" static="true"></field>
  /// <field name="guid" type="String" static="true"></field>
  /// <field name="int" type="String" static="true"></field>
  /// <field name="long" type="String" static="true"></field>
  /// <field name="money" type="String" static="true"></field>
  /// <field name="optionSet" type="String" static="true"></field>
  /// <field name="string" type="String" static="true"></field>
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.Attribute END
 //--------------------------------------------------------------------
 //Sdk.AttributeCollection START
 this.AttributeCollection = function () {
  ///<summary>
  /// A collection of Sdk.AttributeBase
  ///</summary>
  if (!(this instanceof Sdk.AttributeCollection)) {
   return new Sdk.AttributeCollection();
  }

  var _attributeCollection = new Sdk.Collection(Sdk.AttributeBase);


  function _attributeExists(name) {
   var rv = false;
   _attributeCollection.forEach(function (att, i) {
    if (att.getName() == name) {
     rv = true;
     return;
    }
   })
   return rv;
  }
  function _add(attribute, isChanged) {
   var changeValue = true;
   if (isChanged != null && typeof isChanged != "undefined" && typeof isChanged == "boolean") {
    changeValue = isChanged;
   }
   else {
    changeValue = attribute.getIsChanged();
   }
   if (attribute instanceof Sdk.AttributeBase) {
    if (_attributeExists(attribute.getName())) {

     var existingAtt;
     _attributeCollection.forEach(function (a, i) {
      if (a.getName() == attribute.getName()) {
       existingAtt = a;
      }
     });

     if (existingAtt.getType() == attribute.getType()) {
      if (attribute.isValueSet()) {
       if (existingAtt.getValue() != attribute.getValue()) {
        existingAtt.setValue(attribute.getValue());
       }

      }
     }
     else {
      _attributeCollection.remove(existingAtt);
      attribute.setIsChanged(changeValue);
      _attributeCollection.add(attribute);
     }

    }
    else {
     attribute.setIsChanged(changeValue);
     _attributeCollection.add(attribute);
    }
   }
   else {
    throw new Error("Sdk.AttributeCollection add method requires an Sdk.AttributeBase parameter");
   }
  }
  this.add = function (attribute, isChanged) {
   ///<summary>
   /// Adds an attribute to the Attribute Collection.
   ///</summary>
   ///<param name="attribute" type="Sdk.AttributeBase" optional="false" mayBeNull="False">
   /// The attribute to add.
   ///</param>
   ///<param name="isChanged" type="Boolean" optional="true" mayBeNull="true" >
   /// Override the the attribute IsChanged value.
   ///</param>
   _add(attribute, isChanged);

  }
  this.getAttributes = function () {
   ///<summary>
   /// Gets the attributes in the collection
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of Sdk.AttributeBase
   ///</returns>
   return _attributeCollection;
  }



 }
 this.AttributeCollection.__class = true;
 //Sdk.AttributeCollection END

 //--------------------------------------------------------------------
 //Sdk.AuditDetail START
 this.AuditDetail = function (auditRecord) {
  ///<summary>
  /// Provides a base class for storing the details of data changes. 
  ///</summary>
  ///<param name="auditRecord" type="Sdk.Entity" optional="true" mayBeNull="false">
  /// Sets the related Audit record that contains the change details. 
  ///</param>

  if (!(this instanceof Sdk.AuditDetail)) {
   return new Sdk.AuditDetail(auditRecord);
  }

  var _auditRecord = null;

  function _setValidAuditRecord(value) {
   if (value instanceof Sdk.Entity)
   { _auditRecord = value; }
   else
   {
    throw new Error("Sdk.AuditDetail AuditRecord property must be an Sdk.Entity.");
   }
  }


  //Set internal properties from constructor parameters
  if (typeof auditRecord != "undefined") {
   _setValidAuditRecord(auditRecord);
  }

  this.getAuditRecord = function () {
   ///<summary>
   /// gets the related Audit record that contains the change details. 
   ///</summary>
   /// <returns type="Sdk.Entity">
   /// The related Audit record that contains the change details. 
   ///</returns>
   return _auditRecord;
  }

  this.setAuditRecord = function (auditRecord) {
   ///<summary>
   /// Sets the related Audit record that contains the change details. 
   ///</summary>
   /// <param name="auditRecord" type="Sdk.Entity">
   /// The related Audit record that contains the change details. 
   ///</param>
   _setValidAuditRecord(auditRecord);
  }
 }
 this.AuditDetail.__class = true;

 this.AttributeAuditDetail = function (auditRecord) {
  ///<summary>
  /// Contains the details of changes to entity attributes. 
  ///</summary>
  ///<param name="auditRecord" type="Sdk.Entity" optional="true" mayBeNull="false">
  /// Sets the related Audit record that contains the change details. 
  ///</param>

  if (!(this instanceof Sdk.AttributeAuditDetail)) {
   return new Sdk.AttributeAuditDetail(auditRecord);
  }
  Sdk.AuditDetail.call(this, auditRecord);
  /*
  TODO: Document this
  The InvalidNewValueAttributes property is not implemented because I could not
  set an invalid property value and view how the results are returned in the XML.
  The platform prevents entry of invalid values, so I'm not clear about what this 
  property is supposed to capture.
  */
  // var _invalidNewValueAttributes = new Sdk.Collection(String);
  var _newValue = null;
  var _oldValue = null;

  //function _setValidInvalidNewValueAttributes(value) {
  // if (Sdk.Util.isCollectionOf(value,String))
  // { _invalidNewValueAttributes = value; }
  // else
  // {
  //  throw new Error("Sdk.AttributeAuditDetail InvalidNewValueAttributes property must be an Sdk.Collection of String values.");
  // }
  //}

  function _setValidNewValue(value) {
   if (value == null || value instanceof Sdk.Entity)
   { _newValue = value; }
   else
   {
    throw new Error("Sdk.AttributeAuditDetail NewValue property must be an Sdk.Entity or null.");
   }
  }

  function _setValidOldValue(value) {
   if (value == null || value instanceof Sdk.Entity)
   { _oldValue = value; }
   else
   {
    throw new Error("Sdk.AttributeAuditDetail OldValue property must be an Sdk.Entity or null.");
   }
  }



  //this.getInvalidNewValueAttributes = function () {
  // ///<summary>
  // /// Gets a collection of attempted attribute changes that are not valid. 
  // ///</summary>
  // /// <returns type="Sdk.Collection">
  // /// A collection of attempted attribute changes that are not valid. 
  // ///</returns>
  // return _invalidNewValueAttributes;
  //}
  this.getNewValue = function () {
   ///<summary>
   /// Gets a collection of new values for an entity attribute. 
   ///</summary>
   /// <returns type="Sdk.Entity">
   /// A collection of new values for an entity attribute. 
   ///</returns>
   return _newValue;
  }
  this.getOldValue = function () {
   ///<summary>
   /// Gets a collection of former values for an entity attribute. 
   ///</summary>
   /// <returns type="Sdk.Entity">
   /// A collection of former values for an entity attribute. 
   ///</returns>
   return _oldValue;
  }

  //this.setInvalidNewValueAttributes = function (invalidNewValueAttributes) {
  // ///<summary>
  // /// sets a collection of attempted attribute changes that are not valid. 
  // ///</summary>
  // /// <param name="invalidNewValueAttributes" type="Sdk.Collection">
  // /// A collection of attempted attribute changes that are not valid. 
  // ///</param>
  // _setValidInvalidNewValueAttributes(invalidNewValueAttributes);
  //}
  this.setNewValue = function (newValue) {
   ///<summary>
   /// Sets a collection of new values for an entity attribute. 
   ///</summary>
   /// <param name="newValue" type="Sdk.Entity">
   /// A collection of new values for an entity attribute. 
   ///</param>
   _setValidNewValue(newValue);
  }
  this.setOldValue = function (oldValue) {
   ///<summary>
   /// Sets a collection of former values for an entity attribute. 
   ///</summary>
   /// <param name="oldValue" type="Sdk.Entity">
   /// A collection of former values for an entity attribute. 
   ///</param>
   _setValidOldValue(oldValue);
  }

 }
 this.AttributeAuditDetail.__class = true;

 this.RelationshipAuditDetail = function (auditRecord) {
  ///<summary>
  /// Contains the audited details of a change in a relationship. 
  ///</summary>
  ///<param name="auditRecord" type="Sdk.Entity" optional="true" mayBeNull="false">
  /// Sets the related Audit record that contains the change details. 
  ///</param>

  if (!(this instanceof Sdk.RelationshipAuditDetail)) {
   return new Sdk.RelationshipAuditDetail(auditRecord);
  }
  Sdk.AuditDetail.call(this, auditRecord);

  var _relationshipName = null;
  var _targetRecords = new Sdk.Collection(Sdk.EntityReference);

  function _setValidRelationshipName(value) {
   if (typeof value == "string")
   { _relationshipName = value; }
   else
   {
    throw new Error("Sdk.RelationshipAuditDetail RelationshipName property must be an String.");
   }
  }

  function _setValidTargetRecords(value) {
   if (Sdk.Util.isCollectionOf(value, Sdk.EntityReference))
   { _targetRecords = value; }
   else
   {
    throw new Error("Sdk.RelationshipAuditDetail TargetRecords property must be an Sdk.Collection of Sdk.EntityReference.");
   }
  }


  this.getRelationshipName = function () {
   ///<summary>
   /// Gets the relationship name before the change occurs. 
   ///</summary>
   /// <returns type="String">
   /// The relationship name before the change occurs. 
   ///</returns>
   return _relationshipName;
  }
  this.getTargetRecords = function () {
   ///<summary>
   /// Gets the collection of relationship records that were added or removed. 
   ///</summary>
   /// <returns type="Sdk.Collection">
   /// The collection of relationship records that were added or removed. 
   ///</returns>
   return _targetRecords;
  }
  this.setRelationshipName = function (relationshipName) {
   ///<summary>
   /// Sets the relationship name before the change occurs. 
   ///</summary>
   /// <param name="relationshipName" type="String">
   /// The relationship name before the change occurs. 
   ///</param>
   _setValidRelationshipName(relationshipName);
  }
  this.setTargetRecords = function (targetRecords) {
   ///<summary>
   /// Sets the collection of relationship records that were added or removed. 
   ///</summary>
   /// <param name="targetRecords" type="Sdk.Collection">
   /// The collection of relationship records that were added or removed. 
   ///</param>
   _setValidTargetRecords(targetRecords);
  }
 }
 this.RelationshipAuditDetail.__class = true;


 this.RolePrivilegeAuditDetail = function (auditRecord) {
  ///<summary>
  /// Represents audited changes to the privileges of a security role. 
  ///</summary>
  ///<param name="auditRecord" type="Sdk.Entity" optional="true" mayBeNull="false">
  /// Sets the related Audit record that contains the change details. 
  ///</param>

  if (!(this instanceof Sdk.RolePrivilegeAuditDetail)) {
   return new Sdk.RolePrivilegeAuditDetail(auditRecord);
  }
  Sdk.AuditDetail.call(this, auditRecord);
  /*
TODO: Document this
The InvalidNewPrivileges property is not implemented because I could not
set an invalid privilege value and view how the results are returned in the XML.
The platform prevents entry of invalid values, so I'm not clear about what this 
property is supposed to capture.
*/
  // var _invalidNewPrivileges = new Sdk.Collection(String);
  var _newRolePrivileges = new Sdk.Collection(Sdk.RolePrivilege);
  var _oldRolePrivileges = new Sdk.Collection(Sdk.RolePrivilege);

  //function _setValidInvalidNewPrivileges(value) {
  // if (Sdk.Util.isCollectionOf(value,String))
  // { _invalidNewPrivileges = value; }
  // else
  // {
  //  throw new Error("Sdk.RolePrivilegeAuditDetail InvalidNewPrivileges property must be an Sdk.Collection of String.");
  // }
  //}
  function _setValidNewRolePrivileges(value) {
   if (Sdk.Util.isCollectionOf(value, Sdk.RolePrivilege))
   { _newRolePrivileges = value; }
   else
   {
    throw new Error("Sdk.RolePrivilegeAuditDetail NewRolePrivileges property must be an Sdk.Collection of Sdk.RolePrivilege.");
   }
  }
  function _setValidOldRolePrivileges(value) {
   if (Sdk.Util.isCollectionOf(value, Sdk.RolePrivilege))
   { _oldRolePrivileges = value; }
   else
   {
    throw new Error("Sdk.RolePrivilegeAuditDetail OldRolePrivileges property must be an Sdk.Collection of Sdk.RolePrivilege.");
   }
  }


  //this.getInvalidNewPrivileges = function () {
  // ///<summary>
  // /// Gets the collection of invalid privileges for the role. 
  // ///</summary>
  // /// <returns type="Sdk.Collection">
  // /// The collection of invalid privileges for the role. 
  // ///</returns>
  // return _invalidNewPrivileges;
  //}

  this.getNewRolePrivileges = function () {
   ///<summary>
   /// Gets the role’s new privileges. 
   ///</summary>
   /// <returns type="Sdk.Collection">
   /// The role’s new privileges. 
   ///</returns>
   return _newRolePrivileges;
  }

  this.getOldRolePrivileges = function () {
   ///<summary>
   /// Gets the role’s old privileges. 
   ///</summary>
   /// <returns type="Sdk.Collection">
   /// The role’s old privileges. 
   ///</returns>
   return _oldRolePrivileges;
  }

  //this.setInvalidNewPrivileges = function (invalidNewPrivileges) {
  // ///<summary>
  // /// Sets the collection of invalid privileges for the role. 
  // ///</summary>
  // /// <param name="invalidNewPrivileges" type="Sdk.Collection">
  // /// The collection of invalid privileges for the role. 
  // ///</param>
  // _setValidInvalidNewPrivileges(invalidNewPrivileges);
  //}

  this.setNewRolePrivileges = function (newRolePrivileges) {
   ///<summary>
   /// Sets the role’s new privileges. 
   ///</summary>
   /// <param name="newRolePrivileges" type="Sdk.Collection">
   /// The role’s new privileges. 
   ///</param>
   _setValidNewRolePrivileges(newRolePrivileges);
  }

  this.setOldRolePrivileges = function (oldRolePrivileges) {
   ///<summary>
   /// Sets the role’s old privileges. 
   ///</summary>
   /// <param name="oldRolePrivileges" type="Sdk.Collection">
   /// The role’s old privileges. 
   ///</param>
   _setValidOldRolePrivileges(oldRolePrivileges);
  }
 }
 this.RolePrivilegeAuditDetail.__class = true;

 this.ShareAuditDetail = function (auditRecord) {
  ///<summary>
  /// Represents a shared audit detail record. 
  ///</summary>
  ///<param name="auditRecord" type="Sdk.Entity" optional="true" mayBeNull="false">
  /// Sets the related Audit record that contains the change details. 
  ///</param>

  if (!(this instanceof Sdk.ShareAuditDetail)) {
   return new Sdk.ShareAuditDetail(auditRecord);
  }
  Sdk.AuditDetail.call(this, auditRecord);

  var _newPrivileges = null;
  var _oldPrivileges = null;
  var _principal = null;

  function _setValidNewPrivileges(value) {
   if (typeof value == "string")
   { _newPrivileges = value; }
   else
   {
    throw new Error("Sdk.ShareAuditDetail NewPrivileges  property must be a String.");
   }
  }

  function _setValidOldPrivileges(value) {
   if (typeof value == "string")
   { _oldPrivileges = value; }
   else
   {
    throw new Error("Sdk.ShareAuditDetail OldPrivileges  property must be a String.");
   }
  }

  function _setValidPrincipal(value) {
   if (value instanceof Sdk.EntityReference)
   { _principal = value; }
   else
   {
    throw new Error("Sdk.ShareAuditDetail Principal property must be an Sdk.EntityReference.");
   }
  }


  this.getNewPrivileges = function () {
   ///<summary>
   /// Gets the privileges of the user after a change. 
   ///</summary>
   /// <returns type="String">
   /// The privileges of the user after a change.
   ///</returns>
   return _newPrivileges;
  }
  this.getOldPrivileges = function () {
   ///<summary>
   /// Gets the privileges of the user before a change. 
   ///</summary>
   /// <returns type="String">
   /// The privileges of the user before a change. 
   ///</returns>
   return _oldPrivileges;
  }
  this.getPrincipal = function () {
   ///<summary>
   /// Gets the security principal (user or team) that shares the audit detail record. 
   ///</summary>
   /// <returns type="Sdk.EntityReference">
   /// The security principal (user or team) that shares the audit detail record. 
   ///</returns>
   return _principal;
  }

  this.setNewPrivileges = function (newPrivileges) {
   ///<summary>
   /// Sets the privileges of the user after a change. 
   ///</summary>
   /// <param name="newPrivileges" type="Sdk.AccessRights">
   /// The privileges of the user after a change.
   ///</param>
   _setValidNewPrivileges(newPrivileges);
  }
  this.setOldPrivileges = function (oldPrivileges) {
   ///<summary>
   /// Sets the privileges of the user before a change. 
   ///</summary>
   /// <param name="oldPrivileges" type="Sdk.AccessRights">
   /// The privileges of the user before a change. 
   ///</param>
   _setValidOldPrivileges(oldPrivileges);
  }
  this.setPrincipal = function (principal) {
   ///<summary>
   /// Sets the security principal (user or team) that shares the audit detail record. 
   ///</summary>
   /// <param name="principal" type="Sdk.EntityReference">
   /// The security principal (user or team) that shares the audit detail record. 
   ///</param>
   _setValidPrincipal(principal);
  }
 }
 this.ShareAuditDetail.__class = true;

 //Sdk.AuditDetail END
 //--------------------------------------------------------------------
 //Sdk.AuditDetailCollection START
 this.AuditDetailCollection = function () {
  ///<summary>
  /// Contains a collection of AuditDetail objects. 
  ///</summary>

  if (!(this instanceof Sdk.AuditDetailCollection)) {
   return new Sdk.AuditDetailCollection();
  }

  var _auditDetails = new Sdk.Collection(Sdk.AuditDetail);
  var _moreRecords = null;
  var _pagingCookie = null;
  var _totalRecordCount = null;

  function _setValidAuditDetails(value) {
   if (Sdk.Util.isCollectionOf(value, Sdk.AuditDetail))
   { _auditDetails = value; }
   else
   {
    throw new Error("Sdk.AuditDetailCollection AuditDetails property must be an Sdk.Collection of Sdk.AuditDetail.");
   }
  }
  function _setValidMoreRecords(value) {
   if (typeof value == "boolean") {
    _moreRecords = value;
   }
   else {
    throw new Error("Sdk.AuditDetailCollection MoreRecords property must be a Boolean.");
   }

  }
  function _setValidPagingCookie(value) {
   if (typeof value == "string" || value == null) {
    _pagingCookie = value;
   }
   else {
    throw new Error("Sdk.AuditDetailCollection PagingCookie property must be an String");
   }
  }
  function _setValidTotalRecordCount(value) {
   if (typeof value == "number") {
    _totalRecordCount = value;
   }
   else {
    throw new Error("Sdk.AuditDetailCollection TotalRecordCount property must be an Number");
   }
  }

  this.getAuditDetails = function () {
   ///<summary>
   /// Gets the AuditDetail collection. 
   ///</summary>
   /// <returns type="Sdk.Collection">
   /// The AuditDetail collection. 
   ///</returns>
   return _auditDetails;
  }

  this.getMoreRecords = function () {
   ///<summary>
   /// Indicates whether more records exist. 
   ///</summary>
   /// <returns type="Boolean">
   /// Whether more records exist. 
   ///</returns>
   return _moreRecords;
  }
  this.getPagingCookie = function () {
   ///<summary>
   /// Gets or sets a paging cookie. 
   ///</summary>
   /// <returns type="String">
   /// A paging cookie. 
   ///</returns>
   return _pagingCookie;
  }
  this.getTotalRecordCount = function () {
   ///<summary>
   /// Gets or sets the total record count in the collection. 
   ///</summary>
   /// <returns type="Number">
   /// The total record count in the collection. 
   ///</returns>
   return _totalRecordCount;
  }


  this.setAuditRecord = function (auditDetails) {
   ///<summary>
   /// Sets the AuditDetail collection.  
   ///</summary>
   /// <param name="auditRecord" type="Sdk.Collection">
   /// The AuditDetail collection. 
   ///</param>
   _setValidAuditDetails(auditDetails);
  }

  this.setMoreRecords = function (moreRecords) {
   ///<summary>
   /// Sets whether more records exist.  
   ///</summary>
   /// <param name="moreRecords" type="Boolean">
   /// whether more records exist.  
   ///</param>
   _setValidMoreRecords(moreRecords);
  }
  this.setPagingCookie = function (pagingCookie) {
   ///<summary>
   /// Sets a paging cookie. 
   ///</summary>
   /// <param name="pagingCookie" type="String">
   /// A paging cookie. 
   ///</param>
   _setValidPagingCookie(pagingCookie);
  }
  this.setTotalRecordCount = function (totalRecordCount) {
   ///<summary>
   /// Sets the total record count in the collection. 
   ///</summary>
   /// <param name="totalRecordCount" type="Number">
   /// The total record count in the collection. 
   ///</param>
   _setValidTotalRecordCount(totalRecordCount);
  }

 }
 this.AuditDetailCollection.__class = true;
 //Sdk.AuditDetailCollection END
 //--------------------------------------------------------------------
 //Sdk.Collection START
 this.Collection = function (type, list) {
  ///<summary>
  /// A Collection for a specified type;
  ///</summary>
  ///<param name="type" type="Function" optional='false'>
  /// The function that specifies the type
  ///</param>
  ///<param name="list" type="Array" optional='true'>
  /// An array of items to add to the collection
  ///</param>
  if (!(this instanceof Sdk.Collection)) {
   return new Sdk.Collection(type, list);
  }
  if (typeof type != "function") {
   throw new Error("Sdk.Collection type parameter is required and must be a function.")
  }
  // list parameter will be checked by the use of the addRange function when the collection is initialized
  var _type = type;
  var _typeErrorMessage = "The value being added to the Sdk.Collection is not the expected type. The expected type is " + _type.toString();
  var _objects = [];
  var _count = 0;

  this.getType = function () {
   ///<summary>
   /// Gets the type defined for the collection
   ///</summary>
   ///<returns type="Function">
   /// The function that specifies the type
   ///</returns>
   return _type;
  }
  this.add = function (item) {
   ///<summary>
   /// Adds an item to the collection.
   ///</summary>
   ///<param name="item" type="Object">
   /// The type of item must match the type defined for the collection.
   ///</param>
   if (_type == String) {
    if (typeof item == "string") {
     _objects.push(item);
     _count++;
     return;
    }
    else {
     throw new Error(_typeErrorMessage)
    }
   }
   if (_type == Number) {
    if (typeof item == "number") {
     _objects.push(item);
     _count++;
     return;
    }
    else {
     throw new Error(_typeErrorMessage)
    }
   }
   if (_type == Boolean) {
    if (typeof item == "boolean") {
     _objects.push(item);
     _count++;
     return;
    }
    else {
     throw new Error(_typeErrorMessage)
    }
   }
   else {
    if (item instanceof _type) {
     _objects.push(item);
     _count++;
     return;
    }
    else { throw new Error(_typeErrorMessage) }
   }
  };
  this.addRange = function (items) {
   ///<summary>
   /// Adds an array of objects to the collection
   ///</summary>
   ///<param name="items" type="Array">
   /// Each item in the array must be the expected type for the collection.
   ///</param>
   var errorMessage = "Sdk.Collection.addRange requires an array parameter.";
   if (items != null) {
    if (typeof items.push != "undefined")//Verify it is an array
    {
     for (var i = 0; i < items.length; i++) {
      this.add(items[i]);
     }
    }
    else {
     throw new Error(errorMessage);
    }
   }
   else {
    throw new Error(errorMessage);
   }

  };
  this.clear = function () {
   ///<summary>
   /// Removes all items from the collection
   ///</summary>
   _objects.length = 0;
   _count = 0;
  };
  this.contains = function (item) {
   ///<summary>
   /// Returns whether an object exists within the collection.
   ///</summary>
   ///<param name="item" type="Object">
   ///  The item must be a reference to the same object.
   ///</param>
   for (var i = 0; i < _objects.length; i++) {
    if (item === _objects[i]) {
     return true;
    }
   }
   return false;
  };
  this.forEach = function (fn) {
   ///<summary>
   /// Applies the action contained within a delegate function.
   ///</summary>
   ///<param name="fn" type="Function">
   /// Delegate function with parameters for item and index.
   ///</param>
   for (var i = 0; i < _objects.length; i++) {
    fn(_objects[i], i);
   }
  };
  this.getByIndex = function (index) {
   ///<summary>
   /// Gets the item in the collection at the specified index
   ///</summary>
   ///<param name="index" type="Number" optional="false" mayBeNull="false">
   /// The index of the item to return
   ///</param>
   ///<returns type="Object">
   /// The object at the specified index
   ///</returns>
   if (typeof index == "number") {
    if (index >= _count) {
     throw new Error("Out of range. Sdk.Collection.getByIndex index parameter must be within the number of items in the collection.")
    }
    else {
     return _objects[index];
    }

   }
   throw new Error("Sdk.Collection.getByIndex index parameter must be a Number.")

  };
  this.remove = function (item) {
   ///<summary>
   /// Removes an item from the collection
   ///</summary>
   ///<param name="item" type="Object" mayBeNull="false">
   /// The item must be a reference to the same object.
   ///</param>
   if ((item != null) && (typeof item != "undefined")) {
    for (var i = 0; i < _objects.length; i++) {
     if (item === _objects[i]) {
      _objects.splice(i, 1);
      _count--;
      return;
     }
    }
    throw new Error(Sdk.Util.format("Item {0} not found.", [item.toString()]));
   }
   else {
    throw new Error("Sdk.Collection.remove item parameter must not be null or undefined.")
   }

  };
  this.toArray = function () {
   ///<summary>
   /// Gets a copy of the array of items in the collection
   ///</summary>
   ///<returns type="Array">
   /// A copy of items in the collection
   ///</returns>
   return _objects.slice(0);
  };
  this.getCount = function () {
   ///<summary>
   /// Returns the number of items in the collection
   ///</summary>
   ///<returns type="Number">
   /// The number of items
   ///</returns>
   return _count;
  }

  if (list != null) {
   this.addRange(list);
  }

 };
 this.Collection.__class = true;
 //Sdk.Collection END
 //--------------------------------------------------------------------
 //Sdk.ColumnSet START
 this.ColumnSet = function () {
  ///<summary>
  /// <para>Specifies the attributes for which non-null values are returned from a query.</para>
  ///</summary>
  ///<param name="args" type="Object">
  /// <para>Three possible arguments:</para>
  /// <para>  Comma separated string values for attribute logical names</para>
  /// <para>  An Array of string values</para>
  /// <para>  If Boolean true value is passed as the first parameter all columns will be included. (Not recommended for production code)</para>
  ///</param>

  var _invalidParameterMessage = "Sdk.ColumnSet constructor parameter can accept a boolean value as the first parameter, an array of strings, or a series of string values.";


  if (!(this instanceof Sdk.ColumnSet)) {
   if (arguments.length > 0) {
    // if the first parameter is boolean or an array, pass it through
    if (typeof arguments[0] == "boolean" || typeof arguments[0].push != "undefined") {
     return new Sdk.ColumnSet(arguments[0]);
    }
    if (typeof arguments[0] == "string") {
     //Convert the arguments into an array which is also an acceptable parameter
     return new Sdk.ColumnSet(Array.prototype.slice.call(arguments));
    }
    else {
     throw new Error(_invalidParameterMessage);
    }
   }
   else {
    return new Sdk.ColumnSet();
   }

  }

  // inner property
  var _columns = new Sdk.Collection(String);
  var _allColumns = false;


  function _setValidAllColumns(value) {
   if (typeof value == "boolean") {
    _allColumns = value;
   }
   else {
    throw new Error("Sdk.ColumnSet AllColumns must be a boolean.");
   }
  }

  function _setValidColumn(value) {
   if (typeof value == "string") {
    _columns.add(value);
   }
   else {
    throw new Error("Sdk.ColumnSet columns must be strings");
   }
  }

  //Set internal properties from constructor parameters
  if (arguments.length > 0) {
   if (typeof arguments[0] == "boolean") {
    if (arguments[0]) {
     _allColumns = true;
    }
    else {
     throw new Error(_invalidParameterMessage);
    }

   }
   else {
    if (typeof arguments[0].push != "undefined") {
     for (var i = 0; i < arguments[0].length; i++) {
      if (typeof arguments[0][i] == "string") {
       _setValidColumn(arguments[0][i].toLowerCase());
      }
      else {
       throw new Error("Sdk.ColumnSet constructor parameter can accept an Array of string values.");
      }

     }

    }
    else {
     for (var i = 0; i < arguments.length; i++) {
      if (typeof arguments[i] != "string") {
       throw new Error("Sdk.ColumnSet constructor parameter can accept a series of string values.")
      }
      else {
       _setValidColumn(arguments[i].toLowerCase());
      }
     }
    }

   }
  }

  this.getColumns = function () {
   ///<summary>
   /// Gets the collection of column names.
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// The collection of column names.
   ///</returns>
   return _columns;
  };
  this.addColumn = function (column) {
   ///<summary>
   /// Adds a column to the collection
   ///</summary>
   ///<param name="column" type="String">
   /// The logical name of the attribute to add
   ///</param>
   _setValidColumn(column);
  };
  this.addColumns = function (columns) {
   ///<summary>
   /// Adds a string array of column names
   ///</summary>
   ///<param name="value" type="Array">
   /// A string array of column names
   ///</param>

   if (columns instanceof Array) {
    for (var i = 0; i < columns.length; i++) {
     _setValidColumn(columns[i]);
    }
   }

  };
  this.setAllColumns = function (allColumns) {
   ///<summary>
   /// Sets the AllColumns property
   ///</summary>
   ///<param name="allColumns" type="Boolean">
   /// A boolean value
   ///</param>
   _setValidAllColumns(allColumns);
  }
  this.getAllColumns = function () {
   ///<summary>
   /// Gets the AllColumns property
   ///</summary>
   ///<returns type="Boolean">
   /// Whether all columns will be returned
   ///</returns>
   return _allColumns;
  }
  this.getCount = function () {
   ///<summary>
   /// Gets the number of columns
   ///</summary>
   ///<returns type="Number">
   /// The number of columns
   ///</returns>
   return _columns.getCount();
  }

 };
 this.ColumnSet.__class = true;
 //Sdk.ColumnSet END
 //--------------------------------------------------------------------
 //Sdk.Entity START
 this.Entity = function (type) {
  ///<summary>
  /// Represents an instance of an entity (a record).
  ///</summary>
  ///<param name="type" type="String">
  /// The logical name of the entity
  ///</param>

  if (!(this instanceof Sdk.Entity)) {
   return new Sdk.Entity(type);
  }

  // inner properties
  var _attributes = new Sdk.AttributeCollection();
  var _entityState = null;
  var _formattedValues = new Sdk.FormattedValueCollection();
  var _id = null;
  var _logicalName = null;
  var _relatedEntities = new Sdk.RelatedEntitiesCollection();



  //internal setter functions
  function _setValidAttributes(value) {
   if (value instanceof Sdk.AttributeCollection) {
    _attributes = value;
   }
   else {
    throw new Error("Sdk.Entity Attributes property must be an Sdk.AttributeCollection");
   }
  }
  function _setValidEntityState(value) {
   if (value == null ||
			value == Sdk.EntityState.Changed ||
			value == Sdk.EntityState.Created ||
			value == Sdk.EntityState.Unchanged) {
    _entityState = value;
   }
   else {
    throw new Error("Sdk.Entity EntityState property must be an Sdk.EntityState value or null.");
   }
  }
  function _setValidFormattedValues(value) {
   if (value instanceof Sdk.FormattedValueCollection)
   { _formattedValues = value; }
   else
   { throw new Error("Sdk.Entity FormattedValues property must be an Sdk.FormattedValueCollection"); }
  }
  function _setValidId(value, override) {
   if (_id == null || override) {
    if (value != null && Sdk.Util.isGuidOrNull(value)) {
     _id = value;
    }
    else {
     throw new Error("Sdk.Entity Id property must be an string representation of a GUID value");
    }
   }
   else {
    if (value != _id) {
     throw new Error("Sdk.Entity Id cannot be changed once it is set without explicitly setting the override parameter.");
    }
   }


  }
  function _setValidType(value) {
   if (typeof value == "string") {
    _logicalName = value;
   }
   else {
    throw new Error("Sdk.Entity Type property must be an String");
   }
  }
  function _setValidRelatedEntities(value) {
   if (value instanceof Sdk.RelatedEntitiesCollection) {
    _relatedEntities = value;
   }
   else {
    throw new Error("Sdk.Entity RelatedEntities property must be an Sdk.RelatedEntitiesCollection");
   }
  }



  //Set internal properties from constructor parameters
  if (typeof type != "undefined" || type != null) {
   _setValidType(type);
  }

  //public methods
  this.getAttributes = function (args) {
   ///<summary>
   /// Gets the collection of attributes for the entity. 
   ///</summary>
   ///<param name="args" type="Object">
   /// <para>If null all attributes are returned</para>
   /// <para>If String the attribute with matching name is returned.</para>
   /// <para>If Number the attribute with matching index is returned.</para>
   ///</param>
   /// <returns type="Sdk.AttributeCollection">
   /// The collection of attributes for the entity. 
   /// </returns>
   if (args == null) {
    return _attributes;
   }
   if (typeof args == "string" || typeof args == "number") {
    return _attributes.get(args);

   }
   else
   {
    throw new Error("Invalid argument: Sdk.Entity getAttributes method args parameter must be either null, a string or a number.")
   }


  };
  this.setAttributes = function (attributes) {
   ///<summary>
   /// Sets the collection of attributes for the entity. 
   ///</summary>
   ///<param name="attributes" type="Sdk.AttributeCollection">
   /// The collection of attributes for the entity. 
   ///</param>
   _setValidAttributes(attributes);
  };
  this.getEntityState = function () {
   ///<summary>
   /// Gets the state of the entity. 
   ///</summary>
   /// <returns type="Sdk.EntityState">
   /// The state of the entity. 
   /// </returns>
   return _entityState;
  };
  this.setEntityState = function (state) {
   ///<summary>
   /// Sets the state of the entity. 
   ///</summary>
   ///<param name="state" type="Sdk.EntityState">
   /// The state of the entity. 
   ///</param>
   _setValidEntityState(state);
  };
  this.getFormattedValues = function () {
   ///<summary>
   /// Gets the collection of formatted values for the entity attributes. 
   ///</summary>
   /// <returns type="Sdk.FormattedValueCollection">
   /// The collection of formatted values for the entity attributes. 
   /// </returns>
   return _formattedValues;
  };
  this.setFormattedValues = function (values) {
   ///<summary>
   /// Sets the collection of formatted values for the entity attributes. 
   ///</summary>
   ///<param name="values" type="Sdk.FormattedValueCollection">
   /// The collection of formatted values for the entity attributes. 
   ///</param>
   _setValidFormattedValues(values);
  };
  this.getId = function () {
   ///<summary>
   /// Gets the Id of the record represented by this entity instance. 
   ///</summary>
   /// <returns type="String">
   /// The Id of the record represented by this entity instance. 
   /// </returns>
   return _id;
  };
  this.setId = function (id, override) {
   ///<summary>
   /// Sets the Id of the record represented by this entity instance. 
   ///</summary>
   ///<param name="id" type="String" optional="false" mayBeNull="false">
   /// The Id of the record represented by this entity instance. 
   ///</param>
   ///<param name="override" type="Boolean" optional="true" mayBeNull="false">
   /// Allow setting the Id property, for example when creating a new record from an existing one.
   ///</param>
   _setValidId(id, override);
  };
  this.getType = function () {
   ///<summary>
   /// Gets the logical name of the entity. 
   ///</summary>
   /// <returns type="String">
   /// The Id of the record represented by this entity instance. 
   /// </returns>
   return _logicalName;
  };
  this.setType = function (type) {
   ///<summary>
   /// Sets the logical name of the entity. 
   ///</summary>
   ///<param name="type" type="String">
   /// The logical name of the entity. 
   ///</param>
   _setValidType(type);
  };
  this.getRelatedEntities = function () {
   ///<summary>
   /// Gets a collection of related entities.
   ///</summary>
   /// <returns type="Sdk.RelatedEntitiesCollection">
   /// A collection of related entities. 
   /// </returns>
   return _relatedEntities;
  };
  this.setRelatedEntities = function (relatedEntities) {
   ///<summary>
   /// Sets a collection of related entities.
   ///</summary>
   ///<param name="relatedEntities" type="Sdk.RelatedEntitiesCollection">
   /// A collection of related entities.  
   ///</param>
   _setValidRelatedEntities(relatedEntities);
  };

 };
 this.Entity.__class = true;

 //Sdk.Entity END
 //--------------------------------------------------------------------
 //Sdk.EntityCollection START
 this.EntityCollection = function (entities) {
  ///<summary>
  /// Contains a collection of entity instances.
  ///</summary>
  ///<param name="entities" type="Sdk.Collection">
  /// Initializes a new instance of the EntityCollection class setting the Sdk.Collection of Sdk.Entity objects.
  ///</param>

  if (!(this instanceof Sdk.EntityCollection)) {
   return new Sdk.EntityCollection(entities);
  }

  // inner properties
  var _entities = new Sdk.Collection(Sdk.Entity);
  var _entityName = null;
  var _minActiveRowVersion = null;
  var _moreRecords = false;
  var _pagingCookie = null;
  var _totalRecordCount = 0;
  var _totalRecordCountExceeded = false;



  //internal setter functions
  function _setValidEntities(value) {
   if (value instanceof Sdk.Collection && value.getType() == Sdk.Entity) {
    _entities = value;
   }
   else {
    throw new Error("Sdk.EntityCollection entities property must be an Sdk.Collection of Sdk.Entity");
   }

  }

  function _setValidEntityName(value) {
   if (typeof value == "string") {
    _entityName = value;
   }
   else {
    throw new Error("Sdk.EntityCollection entityName property must be an String");
   }
  }

  function _setValidMinActiveRowVersion(value) {
   if (typeof value == "string") {
    _minActiveRowVersion = value;
   }
   else {
    throw new Error("Sdk.EntityCollection minActiveRowVersion property must be an String");
   }
  }

  function _setValidMoreRecords(value) {
   if (typeof value == "boolean") {
    _moreRecords = value;
   }
   else {
    throw new Error("Sdk.EntityCollection moreRecords property must be an Boolean");
   }
  }

  function _setValidPagingCookie(value) {
   if (typeof value == "string" || value == null) {
    _pagingCookie = value;
   }
   else {
    throw new Error("Sdk.EntityCollection pagingCookie property must be an String");
   }
  }

  function _setValidTotalRecordCount(value) {
   if (typeof value == "number") {
    _totalRecordCount = value;
   }
   else {
    throw new Error("Sdk.EntityCollection totalRecordCount property must be an Number");
   }
  }

  function _setValidTotalRecordCountLimitExceeded(value) {
   if (typeof value == "boolean") {
    _totalRecordCountExceeded = value;
   }
   else {
    throw new Error("Sdk.EntityCollection totalRecordCountExeeded property must be an Boolean");
   }
  }



  //Set internal properties from constructor parameters
  if (typeof entities != "undefined" || entities != null) {
   _setValidEntities(entities);
  }

  //public methods
  this.addEntity = function (entity) {
   ///<summary>
   /// Adds an entity to the collection.
   ///</summary>
   ///<param name="entity" type="Sdk.Entity" optional="false" mayBeNull="false">
   /// The entity to add.
   ///</param>
   _entities.add(entity);
  }
  this.getEntities = function () {
   ///<summary>
   /// Gets the collection of entities. 
   ///</summary>
   ///<returns type="Sdk.Collection">The entities</returns>
   return _entities;
  };

  this.getEntity = function (indexOrId) {
   ///<summary>
   /// Gets an entity in the collection. 
   ///</summary>
   ///<param name="indexOrId" type="Object">
   /// The index or Id of the entity in the collection
   ///</param>
   ///<returns type="Sdk.Entity">An entity from the collection</returns>
   var invalidParameterError = "Sdk.EntityCollection getEntity method indexOrId parameter must be a number or an string value";
   if (typeof indexOrId == "undefined" || indexOrId == null) {
    throw new Error(invalidParameterError);
   }
   if (typeof indexOrId == 'number') {
    try {
     return _entities.getByIndex(indexOrId);
    }
    catch (e) {
     throw new Error("Index outside of range. The entities collection contains " + _entities.getCount() + " entities");
    }
   }
   else {

    if (Sdk.Util.isGuidOrNull(indexOrId)) {
     var entityToReturn = null;
     _entities.forEach(function (entity, i) {
      if (entity.getId() == indexOrId) {
       entityToReturn = entity;
      }
     });
     return entityToReturn;
    }
    else { throw new Error(invalidParameterError); }


   }
  };
  this.setEntity = function (indexOrId, value) {
   ///<summary>
   /// Sets an item in the collection. 
   ///</summary>
   ///<param name="indexOrId" type="Object">
   /// The index or Sdk.Guid id of the entity in the collection
   ///</param>
   ///<param name="value" type="Sdk.Entity">
   /// The Sdk.Entity value to set
   ///</param>
   var invalidParameterError = "Sdk.EntityCollection setEntity method indexOrId parameter must be a number or an string value";
   if (typeof indexOrId == "undefined" || indexOrId == null) {
    throw new Error(invalidParameterError);
   }

   if (value instanceof Sdk.Entity) {
    if (typeof indexOrId == "number") {
     if (indexOrId <= (_entities.getCount() - 1)) {
      _entities.forEach(function (entity, i) {
       if (i == indexOrId)
       { entity = value }
      });
     }
     else {
      throw new Error("Index outside of range. The entities collection contains " + _entities.getCount() + " entities");
     }
    }
    else {
     if (Sdk.Util.isGuidOrNull(indexOrId)) {
      var bFound = false;
      _entities.forEach(function (entity, i) {
       if (entity.getId() == indexOrId) {
        bFound = true;
        entity = value;
       }
      });
      if (!bFound) {
       throw new Error("There is no Sdk.Entity in the Sdk.EntityCollection with the Id '" + indexOrId + "'");
      }
     }
     else { throw new Error("Sdk.EntityCollection setEntity method indexOrId parameter must be a number or an string"); }
    }
   }
   else {
    throw new Error("Items in the collection must be Sdk.Entity instances.");
   }
  };

  this.getEntityName = function () {
   ///<summary>
   /// Gets the logical name of the entity.
   ///</summary>
   ///<returns type="String">The logical name of the entity</returns>
   return _entityName;
  };

  this.setEntityName = function (name) {
   ///<summary>
   /// Sets the logical name of the entity.
   ///</summary>
   ///<param name="name" type="String">
   /// The logical name of the entity.
   ///</param>
   _setValidEntityName(name);
  };

  this.getMinActiveRowVersion = function () {
   ///<summary>
   /// Gets the lowest active row version value. 
   ///</summary>
   ///<returns type="String" >The lowest active row version value. </returns>
   return _minActiveRowVersion;
  };
  this.setMinActiveRowVersion = function (minActiveRowVersion) {
   ///<summary>
   /// Sets the lowest active row version value. 
   ///</summary>
   ///<param name="minActiveRowVersion" type="String">
   /// The lowest active row version value.
   ///</param>
   _setValidMinActiveRowVersion(minActiveRowVersion);
  };

  this.getMoreRecords = function () {
   ///<summary>
   /// Gets whether there are more records available. 
   ///</summary>
   ///<returns type="Boolean" >Whether there are more records available. </returns>
   return _moreRecords;
  };
  this.setMoreRecords = function (moreRecords) {
   ///<summary>
   /// Sets whether there are more records available. 
   ///</summary>
   ///<param name="moreRecords" type="Boolean">
   /// Whether there are more records available. 
   ///</param>
   _setValidMoreRecords(moreRecords);
  };

  this.getPagingCookie = function () {
   ///<summary>
   /// Gets the current paging information. 
   ///</summary>
   ///<returns type="String" >The current paging information. </returns>
   return _pagingCookie;
  };
  this.setPagingCookie = function (pagingCookie) {
   ///<summary>
   /// Sets the current paging information. 
   ///</summary>
   ///<param name="pagingCookie" type="String">
   /// The current paging information. 
   ///</param>
   _setValidPagingCookie(pagingCookie);
  };

  this.getTotalRecordCount = function () {
   ///<summary>
   /// Gets the total number of records in the collection if ReturnTotalRecordCount was true when the query was executed. 
   ///</summary>
   ///<returns type="Number" >The total number of records in the collection if ReturnTotalRecordCount was true when the query was executed. </returns>
   return _totalRecordCount;
  };

  this.setTotalRecordCount = function (totalRecordCount) {
   ///<summary>
   /// Sets the total number of records in the collection if ReturnTotalRecordCount was true when the query was executed. 
   ///</summary>
   ///<param name="totalRecordCount" type="Number">
   /// The total number of records in the collection if ReturnTotalRecordCount was true when the query was executed.
   ///</param>
   if (typeof totalRecordCount == "number") {
    _totalRecordCount = totalRecordCount;
   }
  };

  this.getTotalRecordCountLimitExceeded = function () {
   ///<summary>
   /// Gets whether the results of the query exceeds the total record count. 
   ///</summary>
   /// <returns type="Boolean">Whether the results of the query exceeds the total record count.</returns>
   return _totalRecordCountExceeded;
  };
  this.setTotalRecordCountLimitExceeded = function (totalRecordCountLimitExceeded) {
   ///<summary>
   /// Sets whether the results of the query exceeds the total record count. 
   ///</summary>
   ///<param name="totalRecordCountLimitExceeded" type="Boolean">
   /// Whether the results of the query exceeds the total record count. 
   ///</param>
   _setValidTotalRecordCountLimitExceeded(totalRecordCountLimitExceeded);
  };


 };
 this.EntityCollection.__class = true;

 //Sdk.EntityCollection END
 //--------------------------------------------------------------------
 //Sdk.EntityReference START
 this.EntityReference = function (logicalName, id, name) {
  ///<summary>
  /// Identifies a record. 
  ///</summary>
  ///<param name="logicalName" type="String" optional="false" mayBeNull="false">
  /// The logical name of the entity
  ///</param>
  ///<param name="id" type="String" optional="false" mayBeNull="false">
  /// The id of the record
  ///</param>
  ///<param name="name" type="String" optional="true" mayBeNull="true">
  /// <para>The value of the primary attribute of the entity instance</para>
  /// <para>This property can contain a value or null. This property is not automatically populated unless the EntityReference object has been retrieved from the server.</para>
  ///</param>


  if (!(this instanceof Sdk.EntityReference)) {
   return new Sdk.EntityReference(logicalName, id, name);
  }

  var _logicalName, _id, _name = null;

  function _setValidLogicalName(value) {
   if (typeof value == "string")
   { _logicalName = value; }
   else
   {
    throw new Error("Sdk.EntityReference constructor logicalName parameter is required and must be a String.");
   }
  }
  function _setValidId(value) {
   if (value != null && Sdk.Util.isGuidOrNull(value)) {
    _id = value;
   }
   else {
    throw new Error("Sdk.EntityReference constructor id value property is required and must be a String representation of a GUID value.");
   }

  }
  function _setValidName(value) {
   if (typeof value == "string")
   { _name = value; }
   else
   {
    throw new Error("Sdk.EntityReference constructor name parameter must be a String.");
   }
  }

  //Set internal properties from constructor parameters
  _setValidLogicalName(logicalName);
  _setValidId(id);
  if (name != null && typeof name != "undefined") {
   _setValidName(name);
  }

  this.getType = function () {
   ///<summary>
   /// Gets the logicalName representing the type of referenced entity
   ///</summary>
   /// <returns type="String">
   /// The logicalName representing the type of referenced entity
   ///</returns>
   return _logicalName;
  }
  this.getId = function () {
   ///<summary>
   /// Gets the Id value of the referenced entity
   ///</summary>
   /// <returns type="String">
   /// The Id value of the referenced entity
   ///</returns>
   return _id;
  }
  this.getName = function () {
   ///<summary>
   /// Gets the primary attribute value of the referenced entity
   ///</summary>
   /// <returns type="String">
   /// The primary attribute value of the referenced entity
   ///</returns>
   return _name;
  }
  this.setType = function (type) {
   ///<summary>
   /// Sets the logicalName representing the type of referenced entity
   ///</summary>
   /// <param name="type" type="String">
   /// The logicalName representing the type of  referenced entity
   ///</param>
   _setValidLogicalName(type);
  }
  this.setId = function (id) {
   ///<summary>
   ///  Sets the Id value of the entity
   ///</summary>
   /// <param name="id" type="String">
   /// The Id value of the entity
   ///</param>
   _setValidId(id);
  }
  this.setName = function (name) {
   ///<summary>
   ///  Sets the primary attribute value of the referenced entity
   ///</summary>
   /// <param name="name" type="String">
   /// The primary attribute value of the referenced entity
   ///</param>
   _setValidName(name);
  }

 }
 this.EntityReference.__class = true;



 //Sdk.EntityReference END
 //--------------------------------------------------------------------
 //Sdk.EntityReferenceCollection START
 this.EntityReferenceCollection = function (entityReferences) {
  ///<summary>
  /// Contains a collection of EntityReference instances.
  ///</summary>
  ///<param name="entityReferences" type="Sdk.Collection" optional="true">
  /// Initializes a new instance of the EntityReferenceCollection class setting the Sdk.Collection of Sdk.EntityReference objects.
  ///</param>

  if (!(this instanceof Sdk.EntityReferenceCollection)) {
   return new Sdk.EntityReferenceCollection(entityReferences);
  }

  // inner property
  var _entityReferences = Sdk.Collection(Sdk.EntityReference);

  //internal setter functions
  function _setValidEntityReferences(value) {
   if (value instanceof Sdk.Collection && value.getType() == Sdk.EntityReference) {
    _entityReferences = value;
   }
   else {
    throw new Error("Sdk.EntityReferenceCollection EntityReferences property must be an Sdk.Collection of SdkEntityReference");

   }
  }
  //Set internal properties from constructor parameters
  if (typeof entityReferences != "undefined" || entityReferences != null) {
   _setValidEntityReferences(entityReferences);
  }

  //public methods
  this.getEntityReferences = function () {
   ///<summary>
   /// Gets the collection of entity references
   ///</summary>
   ///<returns type="Sdk.Collection">The entity references</returns>
   return _entityReferences;
  };
  this.setEntityReferences = function (entityReferences) {
   ///<summary>
   /// Sets the collection of entity references
   ///</summary>
   ///<param name="entityReferences" optional="false" mayBeNull="false" type="Sdk.Collection">The entity references</param>
   _setValidEntityReferences(entityReferences);
  }

 };
 this.EntityReferenceCollection.__class = true;
 //Sdk.EntityReferenceCollection END
 //--------------------------------------------------------------------

 //Sdk.EntityState START
 this.EntityState = function () {
  /// <summary>Sdk.EntityState enum summary</summary>
  /// <field name="Changed" type="String" static="true">The entity was changed since the last call to SaveChanges. Value = 2</field>
  /// <field name="Created" type="String" static="true">The entity was created since the last call to SaveChanges. Value = 1</field>
  /// <field name="Unchanged" type="String" static="true">The entity is unchanged since the last call to SaveChanges. Value = 0</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };

 //Sdk.EntityState END
 //--------------------------------------------------------------------
 //Sdk.FormattedValue START
 this.FormattedValue = function (name, value) {
  ///<summary>
  /// Defines a formatted value that can be set or retrieved.
  ///</summary>
  ///<param name="name" type="String">
  /// The name of the attribute
  ///</param>
  ///<param name="value" type="String">
  /// The formatted value
  ///</param>

  if (!(this instanceof Sdk.FormattedValue)) {
   return new Sdk.FormattedValue(name, value);
  }

  var _name = null;
  var _value = null;


  function _setValidName(value) {
   if (typeof value == "string") {
    _name = value;
   }
   else {
    throw new Error("Sdk.FormattedValue Name property must be a string.");
   }

  }
  function _setValidValue(value) {
   if (typeof value == "string") {
    _value = value;
   } else {
    throw new Error("Sdk.FormattedValue Value property must be a string.");
   }
  }

  _setValidName(name);
  _setValidValue(value);


  this.getName = function () {
   ///<summary>
   ///  Gets the name in the FormattedValue.
   ///</summary>
   ///<returns type="String">
   /// The name in the FormattedValue.
   ///</returns>

   return _name;
  };
  this.setName = function (name) {
   ///<summary>
   ///  Sets the name in the FormattedValue.
   ///</summary>
   ///<param name="name" type="String">
   /// The name in the FormattedValue.
   ///</param>

   _setValidName(name);
  };
  this.getValue = function () {
   ///<summary>
   /// Gets the value in the FormattedValue.
   ///</summary>
   ///<returns type="Object">
   /// The value in the FormattedValue.
   ///</returns>
   return _value;
  };
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value in the key/value pair.
   ///</summary>
   ///<param name="value" type="Object">
   /// The value in the FormattedValue.
   ///</param>
   _setValidValue(value);
  };




 };
 this.FormattedValue.__class = true;
 //Sdk.FormattedValue END
 //--------------------------------------------------------------------
 //Sdk.FormattedValueCollection START
 this.FormattedValueCollection = function () {
  ///<summary>
  /// Contains a collection of formatted values for the attributes for an entity. 
  ///</summary>
  if (!(this instanceof Sdk.FormattedValueCollection)) {
   return new Sdk.FormattedValueCollection();
  }
  var _fvCollection = new Sdk.Collection(Sdk.FormattedValue);

  function _itemExists(name) {
   var rv = false;
   _fvCollection.forEach(function (fv, i) {
    if (fv.getName() == name) {
     rv = true;
     return;
    }
   })
   return rv;
  }

  function _getItem(name) {
   var value;
   _fvCollection.forEach(function (fv, i) {
    if (fv.getName() == name) {
     value = fv;
    }
   });
   return value;
  }

  function _setItem(name, value) {
   if (_itemExists(name)) {
    _fvCollection.forEach(function (fv, i) {
     if (fv.getName() == name) {
      fv.setValue(value);
     }
    });
   }
   else {
    throw new Error(Sdk.Util.format("Sdk.FormattedValueCollection error: An item with the name '{0}' does not exist in the collection.", [name]));
   }
  }

  function _add(item) {
   if (item instanceof Sdk.FormattedValue) {
    if (_itemExists(item.getName())) {
     throw new Error("An item with the name '" + item.getName() + "' already exists in the collection.");
    }
    else {
     _fvCollection.add(item);
    }
   }
   else {
    throw new Error("Sdk.FormattedValueCollection add method requires an Sdk.FormattedValue parameter");
   }
  }

  function _addRange(items) {
   if ((typeof items != "undefined") && (typeof items.push != "undefined")) {
    for (var i = 0; i < items.length; i++) {

     if (items[i] instanceof Sdk.FormattedValue) {
      _add(items[i]);
     }
     else {
      throw new Error("The Sdk.FormattedValueCollection addRange method requires all the items in the items parameter are Sdk.FormattedValue.");
     }
    }
   }
   else {
    throw new Error("The Sdk.FormattedValueCollection addRange method requires an Array of Sdk.FormattedValue.");
   }
  }


  this.add = function (item) {
   ///<summary>
   /// Adds an item to the FormattedValueCollection.
   ///</summary>
   ///<param name="item" type="Sdk.FormattedValue">
   /// The item to add.
   ///</param>
   _add(item);

  };
  this.addRange = function (items) {
   ///<summary>
   /// Adds an array of FormattedValue to the FormattedValueCollection
   ///</summary>
   ///<param name="items" type="Array">
   /// Each item in the array must be an Sdk.FormattedValue.
   ///</param>
   _addRange(items);


  };
  this.containsName = function (name) {
   ///<summary>
   /// Determines whether the Sdk.FormattedValueCollection contains a specific name value.
   ///</summary>
   ///<param name="name" type="String">
   /// The name
   ///</param>
   return _itemExists(name);
  };
  this.getCollection = function () {
   ///<summary
   /// Gets the collection of formatted values.
   /// </summary>
   /// <returns type="Sdk.Collection">
   /// The item from the formatted value collection
   /// </returns>
   return _fvCollection;
  };
  this.getItem = function (name) {
   ///<summary
   /// Gets an item from the formatted value collection by name
   /// </summary>
   /// <param name="name" type="String">
   /// The name of a formatted value in the collection
   /// </param>
   /// <returns type="Sdk.FormattedValue">
   /// The item from the formatted value collection
   /// </returns>

   if (_itemExists(name)) {
    return _getItem(name);
   }
   else {
    throw new Error(Sdk.Util.format("An item with the name '{0}' does not exist in the collection.", [name]));
   }
  };
  this.setItem = function (name, value) {
   ///<summary
   /// Sets the value of an item in the formatted value collection
   /// </summary>
   /// <param name="name" type="String">
   /// The name of a formatted value in the collection
   /// </param>
   /// <param name="value" type="String">
   /// The formatted value
   /// </param>
   _setItem(name, value);
  };



 };
 this.FormattedValueCollection.__class = true;
 //Sdk.FormattedValueCollection END
 //--------------------------------------------------------------------
 //Sdk.OrganizationRequest START
 this.OrganizationRequest = function () {
  // All Requests must inherit from this

  var _responseType;
  var _requestXml;

  function _setValidResponseType(value) {
   if (value.prototype.type == "Sdk.OrganizationResponse" && typeof value == "function") {
    _responseType = value;
   }
   else {
    throw new Error("Sdk.OrganizationRequest ResponseType property must be a Sdk.OrganizationResponse).");
   }
  }
  function _setValidRequestXml(value) {
   if (typeof value == "string") {
    _requestXml = value;
   }
   else {
    throw new Error("Sdk.OrganizationRequest RequestXml property must be a String.");
   }
  }

  this.setRequestXml = function (xml) {
   ///<summary>
   /// Sets the request XML
   ///</summary>
   ///<param name="xml" type="String">
   /// The request XML
   ///</param>
   _setValidRequestXml(xml);
  }
  this.getRequestXml = function () {
   ///<summary>
   /// Gets the request XML
   ///</summary>
   ///<returns type="String">
   /// The request XML
   ///</returns>
   return _requestXml;
  }
  this.setResponseType = function (type) {
   ///<summary>
   /// Sets the response type
   ///</summary>
   ///<param name="type" type="Sdk.OrganizationResponse">
   /// A class that inherits from Sdk.OrganizationResponse
   ///</param>
   _setValidResponseType(type);
  }
  this.getResponseType = function () {
   ///<summary>
   /// Gets the response type
   ///</summary>
   ///<returns type="Sdk.OrganizationResponse">
   /// A class that inherits from Sdk.OrganizationResponse
   ///</returns>
   return _responseType;
  }

 }
 this.OrganizationRequest.__class = true;
 this.OrganizationResponse = function () {
  // All Responses must inherit from this
  this.type = "Sdk.OrganizationResponse";
 }
 this.OrganizationResponse.__class = true;
 //Sdk.OrganizationRequest END
 //--------------------------------------------------------------------
 //Sdk.PrincipalAccess START
 this.PrincipalAccess = function (accessMask, principal) {
  ///<summary>
  /// Contains access rights information for the security principal (user or team). 
  ///</summary>
  ///<param name="accessMask" type="Number">
  /// The access rights of the security principal (user or team) expressed using the Sdk.AccessRights enumeration.
  ///</param>
  ///<param name="principal" type="Sdk.EntityReference">
  /// The security principal (user or team). 
  ///</param>

  if (!(this instanceof Sdk.PrincipalAccess)) {
   return new Sdk.PrincipalAccess();
  }
  // inner property
  var _accessMask = Sdk.AccessRights.None;
  var _principal = null;

  //internal setter functions
  function _setValidAccessMask(value) {
   if ((typeof value == "number") && (value >= 0) && (value <= 255)) {
    _accessMask = value;
   }
   else {
    throw new Error("Sdk.PrincipalAccess AccessMask property must be a number represented by the Sdk.AccessRights enumeration.");
   }
  }
  function _setValidPrincipal(value) {
   if ((value instanceof Sdk.EntityReference) &&
    (value.getType() == "systemuser" || value.getType() == "team")) {
    _principal = value;
   }
   else {
    throw new Error("Sdk.PrincipalAccess Principal property must be a Sdk.EntityReference for a systemuser or team entity instance.");
   }
  }

  //Set internal properties from constructor parameters
  if (typeof accessMask != "undefined") {
   _setValidAccessMask(accessMask);
  }
  if (typeof principal != "undefined") {
   _setValidPrincipal(principal);
  }

  //public methods
  this.getAccessMaskAsNumber = function () {
   ///<summary>
   /// Gets access rights of the security principal (user or team) expressed as a number.
   ///</summary>
   ///<returns  type="Number">
   /// The access rights of the security principal (user or team) expressed as a number.
   ///</returns>
   return _accessMask;
  }
  this.getAccessMaskAsString = function () {
   ///<summary>
   /// Gets access rights of the security principal (user or team) expressed as a string. 
   ///</summary>
   ///<returns type="String">
   /// The access rights of the security principal (user or team) expressed as a string.
   ///</returns>
   return Sdk.Util.convertAccessRightsToString(_accessMask);
  }
  this.getPrincipal = function () {
   ///<summary>
   /// Gets the security principal (user or team). 
   ///</summary>
   ///<returns  type="Sdk.EntityReference">
   /// The security principal (user or team). 
   ///</returns>
   return _principal;
  }
  this.setAccessMask = function (accessMask) {
   ///<summary>
   /// Sets access rights information for the security principal (user or team). 
   ///</summary>
   ///<param name="accessMask" type="Number">
   /// The access rights of the security principal (user or team) expressed using the Sdk.AccessRights enumeration.
   ///</param>
   _setValidAccessMask(accessMask);
  }
  this.setPrincipal = function (principal) {
   ///<summary>
   /// Sets the security principal (user or team). 
   ///</summary>
   ///<param name="principal" type="Sdk.EntityReference">
   /// The security principal (user or team). 
   ///</param>
   _setValidPrincipal(principal);
  }
 }
 this.PrincipalAccess.__class = true;
 //Sdk.PrincipalAccess END
 //--------------------------------------------------------------------
 //Sdk.PrivilegeDepth START
 this.PrivilegeDepth = function () {
  /// <summary>Sdk.PrivilegeDepth  enum summary</summary>
  /// <field name="Basic" type="String" static="true">Indicates basic privileges. Users who have basic privileges can only use privileges to perform actions on objects that are owned by, or shared with, the user. </field>
  /// <field name="Deep" type="String" static="true">Indicates deep privileges. Users who have deep privileges can perform actions on all objects in the user's current business units and all objects down the hierarchy of business units.</field>
  /// <field name="Global" type="String" static="true">Indicates global privileges. Users who have global privileges can perform actions on data and objects anywhere within the organization regardless of the business unit or user to which it belongs. </field>
  /// <field name="Local" type="String" static="true">Indicates local privileges. Users who have local privileges can only use privileges to perform actions on data and objects that are in the user's current business unit.</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.PrivilegeDepth END
 //--------------------------------------------------------------------
 //Sdk.PropagationOwnershipOptions START
 this.PropagationOwnershipOptions = function () {
  /// <summary>Sdk.PropagationOwnershipOptions enum summary</summary>
  /// <field name="Caller" type="String" static="true">All created activities are assigned to the caller of the API.</field>
  /// <field name="ListMemberOwner" type="String" static="true">Created activities are assigned to respective owners of target members.</field>
  /// <field name="None" type="String" static="true">There is no change in ownership for the created activities.</field>

  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.PropagationOwnershipOptions END
 //--------------------------------------------------------------------
 //Sdk.RelatedEntitiesCollection START
 this.RelatedEntitiesCollection = function () {
  ///<summary>
  /// Represents a collection of Sdk.RelationshipEntityCollection
  ///</summary>
  if (!(this instanceof Sdk.RelatedEntitiesCollection)) {
   return new Sdk.RelatedEntitiesCollection();
  }

  var _relationshipEntities = new Sdk.Collection(Sdk.RelationshipEntityCollection);
  var _isChanged = false;

  this.getRelationshipEntities = function () {
   /// <summary>
   /// Gets the collection of relationship entity collections
   /// </summary>
   /// <returns type="Sdk.Collection">
   /// A Sdk.Collection of Sdk.RelationshipEntityCollection
   /// </returns>
   return _relationshipEntities;
  }
  this.getIsChanged = function () {
   /// <summary>
   /// Gets whether any of the entities in the collection have changed
   /// </summary>
   /// <returns type="Boolean">
   /// Whether any of the entities in the collection have changed
   /// </returns>
   return _isChanged;
  }
  this.setIsChanged = function (isChanged) {
   /// <summary>
   /// Sets whether any of the entities in the collection have changed
   /// </summary>
   /// <param name="isChanged" optional="false" mayBeNull="false" type="Boolean">
   /// Whether any of the entities in the collection have changed
   /// </param>
   if (typeof isChanged == "boolean") {
    _isChanged = isChanged;
   }
   else {
    throw new Error("Sdk.RelatedEntitiesCollection setIsChanged method isChanged parameter must be a boolean value.");
   }
  }
 }
 this.RelatedEntitiesCollection.__class = true;
 //Sdk.RelatedEntitiesCollection END
 //--------------------------------------------------------------------
 //Sdk.RelationshipEntityCollection START
 this.RelationshipEntityCollection = function (relationshipSchemaName) {
  ///<summary>
  /// Represents a collection of entities with the same relationship
  ///</summary>
  ///<param name="relationshipSchemaName" type="String"  optional="false" mayBeNull="false">
  /// The relationship SchemaName
  ///</param>
  if (!(this instanceof Sdk.RelationshipEntityCollection)) {
   return new Sdk.RelationshipEntityCollection(relationshipSchemaName);
  }


  var _relationshipName, _entities = new Sdk.EntityCollection();

  function _setValidEntityCollection(value) {
   if (value instanceof Sdk.EntityCollection) {
    _entities = value;
   }
   else {
    throw new Error("Sdk.RelationshipEntityCollection Entities property must be an Sdk.EntityCollection.");
   }
  }

  this.getEntityCollection = function () {
   /// <summary>
   /// Gets the entities
   /// </summary>
   /// <returns type="Sdk.EntityCollection" />
   return _entities;
  }

  this.getRelationship = function () {
   /// <summary>
   /// Gets the name of the relationship
   /// </summary>
   /// <returns type="String" />
   return _relationshipName;
  }

  this.setEntityCollection = function (entityCollection) {
   /// <summary>
   /// Sets the entity collection.
   /// </summary>
   /// <param name="entityCollection" optional="false" mayBeNull="false" type="Sdk.EntityCollection" />
   _setValidEntityCollection(entityCollection);

  }

  //Set properties based on constructor arguments.
  if (relationshipSchemaName != null && typeof relationshipSchemaName == "string") {
   _relationshipName = relationshipSchemaName;
  }
  else {
   throw new Error("Sdk.RelationshipEntityCollection constructor relationshipSchemaName parameter is required and must be a string.");
  }


 }
 this.RelationshipEntityCollection.__class = true;
 //Sdk.RelationshipEntityCollection END
 //--------------------------------------------------------------------
 //Sdk.RelationshipQuery START
 this.RelationshipQuery = function (relationshipName, query) {
  ///<summary>
  /// Represents a query to be added to an Sdk.RelationshipQueryCollection
  ///</summary>
  ///<param name="relationshipName" type="String" optional="false" mayBeNull="false">
  /// The schema name of the relationship.
  ///</param>
  ///<param name="query" type="Sdk.Query.QueryBase" optional="false" mayBeNull="false">
  /// A query to be applied to the entities in the relationship
  ///</param>

  if (!(this instanceof Sdk.RelationshipQuery)) {
   return new Sdk.RelationshipQuery(relationshipName, query);
  }

  var _relationshipName = null;
  var _query = null;

  function _setValidRelationshipName(value) {
   if (typeof value == "string") {
    _relationshipName = value;
   }
   else {
    throw new Error("Sdk.RelationshipQuery RelationshipName must be a string.");
   }
  }
  function _setValidQuery(value) {
   if (value instanceof Sdk.Query.QueryBase) {
    _query = value;
   }
   else {
    throw new Error("Sdk.RelationshipQuery Query must be a class that inherits from Sdk.Query.QueryBase.");
   }
  }

  //Set values from the constructor
  _setValidRelationshipName(relationshipName);
  _setValidQuery(query);

  this.getQuery = function () {
   /// <summary>
   /// Gets the query to apply
   /// </summary>
   /// <returns type="Sdk.Query.QueryBase">
   /// The query to apply
   /// </returns>
   return _query;
  }
  this.getRelationshipName = function () {
   /// <summary>
   /// Gets the name of the relationship
   /// </summary>
   /// <returns type="String">
   /// The name of the relationship
   /// </returns>
   return _relationshipName;
  }
  this.setQuery = function (query) {
   /// <summary>
   /// Sets the query to apply
   /// </summary>
   /// <param name="query" optional="false" mayBeNull="false" type="Sdk.Query.QueryBase">
   /// The query to apply
   /// </param>
   _setValidQuery(query);
  }
  this.setRelationshipName = function (relationshipName) {
   /// <summary>
   /// Sets the name of the relationship
   /// </summary>
   /// <param type="String" name="relationshipName" optional="false" mayBeNull="false" >
   /// The name of the relationship
   /// </param>
   _setValidRelationshipName(relationshipName);
  }



 }
 this.RelationshipQuery.__class = true;
 //Sdk.RelationshipQuery END
 //--------------------------------------------------------------------
 //Sdk.RelationshipQueryCollection START
 this.RelationshipQueryCollection = function (relationshipQueries) {
  ///<summary>
  /// Contains a collection of Sdk.RelationshipQuery 
  ///</summary>
  ///<param name="relationshipQueries" type="Sdk.Collection" optional="true" mayBeNull="false">
  /// Initializes a new instance of the RelationshipQueryCollection class setting the Sdk.Collection of Sdk.RelationshipQuery objects.
  ///</param>

  if (!(this instanceof Sdk.RelationshipQueryCollection)) {
   return new Sdk.RelationshipQueryCollection(relationshipQueries);
  }

  var _invalidRelationshipQueriesMessage = "Sdk.RelationshipQueryCollection RelationshipQueries must be an Sdk.Collection of Sdk.RelationshipQuery objects."

  // inner property
  var _relationshipQueries = new Sdk.Collection(Sdk.RelationshipQuery);


  function _setValidRelationshipQueries(value) {
   if (value instanceof Sdk.Collection) {
    value.forEach(function (rq, i) {
     if (!(rq instanceof Sdk.RelationshipQuery)) {
      throw new Error(_invalidRelationshipQueriesMessage);
     }
    });
   }
   else {
    throw new Error(_invalidRelationshipQueriesMessage);
   }
  }

  //Set internal properties from constructor parameters
  if (typeof relationshipQueries != "undefined") {
   _setValidRelationshipQueries(relationshipQueries);
  }
  this.getRelationshipQueries = function () {
   ///<summary>
   /// Gets a collection of relationship queries
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// A Sdk.Collection of Sdk.RelationshipQuery
   ///</returns>
   return _relationshipQueries;
  }
  this.setRelationshipQueries = function (relationshipQueries) {
   ///<summary>
   /// Sets a collection of relationship queries
   ///</summary>
   ///<param name="relationshipQueries" type="Sdk.Collection" optional="true" mayBeNull="false">
   /// A Sdk.Collection of Sdk.RelationshipQuery
   ///</param>
   _setValidRelationshipQueries(relationshipQueries);
  }

 }
 this.RelationshipQueryCollection.__class = true;
 //Sdk.RelationshipQueryCollection END
 //--------------------------------------------------------------------
 //Sdk.RolePrivilege START
 this.RolePrivilege = function (depth, privilegeId, businessId) {
  ///<summary>
  /// Contains information about a privilege. 
  ///</summary>
  ///<param name="depth" type="String" optional="false" mayBeNull="false">
  /// The depth of the privilege.
  ///</param>
  ///<param name="privilegeId" type="String" optional="false" mayBeNull="false">
  /// The ID of the privilege.
  ///</param>
  ///<param name="businessId" type="String" optional="false" mayBeNull="false">
  /// The ID of the business unit.
  ///</param>

  if (!(this instanceof Sdk.RolePrivilege)) {
   return new Sdk.RolePrivilege(depth, privilegeId, businessId);
  }

  var _depth = null;
  var _privilegeId = null;
  var _businessId = null

  function _setValidDepth(value) {
   //Check for valid Sdk.PrivilegeDepth 
   if (value == "Basic" || value == "Deep" || value == "Global" || value == "Local") {
    _depth = value;
   }
   else {
    throw new Error("Sdk.RolePrivilege Depth must be a Sdk.PrivilegeDepth value.");
   }
  }

  function _setValidPrivilegeId(value) {
   if (Sdk.Util.isGuid(value)) {
    _privilegeId = value;
   }
   else {
    throw new Error("Sdk.RolePrivilege PrivilegeId must be a string representation of a guid value.");
   }
  }

  function _setValidBusinessId(value) {
   if (Sdk.Util.isGuid(value)) {
    _businessId = value;
   }
   else {
    throw new Error("Sdk.RolePrivilege BusinessId must be a string representation of a guid value.");
   }
  }

  //Set values from the constructor
  _setValidDepth(depth);
  _setValidPrivilegeId(privilegeId);
  _setValidBusinessId(businessId);

  this.getBusinessId = function () {
   /// <summary>
   /// Gets the ID of the business unit.
   /// </summary>
   /// <returns type="String">
   /// The ID of the business unit.
   /// </returns>
   return _businessId;
  }
  this.setBusinessId = function (businessId) {
   /// <summary>
   /// Sets the ID of the business unit.
   /// </summary>
   /// <param name="businessId" optional="false" mayBeNull="false" type="String">
   /// The ID of the business unit.
   /// </param>
   _setValidBusinessId(businessId);
  }


  this.getDepth = function () {
   /// <summary>
   /// Gets the depth of the privilege.
   /// </summary>
   /// <returns type="String">
   /// The depth of the privilege.
   /// </returns>
   return _depth;
  }
  this.setDepth = function (depth) {
   /// <summary>
   /// Sets the depth of the privilege.
   /// </summary>
   /// <param name="depth" optional="false" mayBeNull="false" type="String">
   /// The depth of the privilege.
   /// </param>
   _setValidDepth(depth);
  }

  this.getPrivilegeId = function () {
   /// <summary>
   /// Gets the ID of the privilege.
   /// </summary>
   /// <returns type="String">
   /// The ID of the business unit.
   /// </returns>
   return _privilegeId;
  }
  this.setPrivilegeId = function (privilegeId) {
   /// <summary>
   /// Sets the ID of the privilege.
   /// </summary>
   /// <param name="privilegeId" optional="false" mayBeNull="false" type="String">
   /// The ID of the privilege
   /// </param>
   _setValidPrivilegeId(privilegeId);
  }

 }
 this.RolePrivilege.__class = true;

 //Sdk.RolePrivilege End
 //--------------------------------------------------------------------
 //Sdk.RollupType START
 this.RollupType = function () {
  /// <summary>Sdk.RollupType enum summary</summary>
  /// <field name="Extended" type="String" static="true">A rollup record that is directly related to a parent record and to any descendent record of a parent record, for example, children, grandchildren, and great-grandchildren records.</field>
  /// <field name="None" type="String" static="true">A rollup record is not requested. This member only retrieves the records that are directly related to a parent record. </field>
  /// <field name="Related" type="String" static="true">A rollup record that is directly related to a parent record and to any direct child of a parent record.</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.RollupType END
 //--------------------------------------------------------------------
 //Sdk.TargetFieldType START
 this.TargetFieldType = function () {
  /// <summary>Sdk.TargetFieldType enum summary</summary>
  /// <field name="All" type="String" static="true">Initialize all possible attribute values. Value = 0</field>
  /// <field name="ValidForCreate" type="String" static="true">Initialize the attribute values that are valid for create. Value = 1</field>
  /// <field name="ValidForRead" type="String" static="true">Initialize the attribute values that are valid for read. Value = 3.</field>
  /// <field name="ValidForUpdate" type="String" static="true">initialize the attribute values that are valid for update. Value = 2.</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.TargetFieldType END
 //--------------------------------------------------------------------
 //Sdk.TimeInfo START
 this.TimeInfo = function () {
  ///<summary>
  /// Specifies a set of time blocks with appointment information. 
  ///</summary>

  if (!(this instanceof Sdk.TimeInfo)) {
   return new Sdk.TimeInfo();
  }

  var _activityStatusCode = null;
  var _calendarId = null;
  var _displayText = null;
  var _effort = null;
  var _end = null;
  var _isActivity = null;
  var _sourceId = null;
  var _sourceTypeCode = null;
  var _start = null;
  var _subCode = null;
  var _timeCode = null;

  function _setValidActivityStatusCode(value) {
   if (typeof value == "number") {
    _activityStatusCode = value;
   }
   else {
    throw new Error("Sdk.TimeInfo ActivityStatusCode  must be a Number.");
   }
  }
  function _setValidCalendarId(value) {
   if (Sdk.Util.isGuid(value)) {
    _calendarId = value;
   }
   else {
    throw new Error("Sdk.TimeInfo CalendarId must be a String representation of a Guid value.");
   }
  }
  function _setValidDisplayText(value) {
   if (typeof value == "string") {
    _displayText = value;
   }
   else {
    throw new Error("Sdk.TimeInfo DisplayText must be a String.");
   }
  }
  function _setValidEffort(value) {
   if (typeof value == "number") {
    _effort = value;
   }
   else {
    throw new Error("Sdk.TimeInfo Effort must be a Number.");
   }
  }
  function _setValidEnd(value) {
   if (value == null || value instanceof Date) {
    _end = value;
   }
   else {
    throw new Error("Sdk.TimeInfo End must be null or a Date .");
   }
  }
  function _setValidIsActivity(value) {
   if (typeof value == "boolean") {
    _isActivity = value;
   }
   else {
    throw new Error("Sdk.TimeInfo IsActivity must be a Boolean.");
   }
  }
  function _setValidSourceId(value) {
   if (Sdk.Util.isGuid(value)) {

    _sourceId = value;
   }
   else {
    throw new Error("Sdk.TimeInfo SourceId must be a String representation of a Guid value.");
   }
  }
  function _setValidSourceTypeCode(value) {
   if (typeof value == "number") {
    _sourceTypeCode = value;
   }
   else {
    throw new Error("Sdk.TimeInfo SourceTypeCode must be a Number.");
   }
  }
  function _setValidStart(value) {
   if (value == null || value instanceof Date) {
    _start = value;
   }
   else {
    throw new Error("Sdk.TimeInfo Start must be null or a Date.");
   }
  }
  function _setValidSubCode(value) {
   if (Sdk.Util.isValidEnumValue(Sdk.SubCode, value)) {
    _subCode = value;
   }
   else {
    throw new Error("Sdk.TimeInfo SubCode must be an Sdk.SubCode value.");
   }
  }
  function _setValidTimeCode(value) {
   if (Sdk.Util.isValidEnumValue(Sdk.TimeCode, value)) {
    _timeCode = value;
   }
   else {
    throw new Error("Sdk.TimeInfo TimeCode must be an Sdk.TimeCode value.");
   }
  }

  this.getActivityStatusCode = function () {
   /// <summary>
   /// Gets the status of the activity. 
   /// </summary>
   /// <returns type="Number">
   /// The status of the activity. 
   /// </returns>
   return _activityStatusCode;
  }
  this.getCalendarId = function () {
   /// <summary>
   /// Gets the ID of the calendar for this block of time. 
   /// </summary>
   /// <returns type="String">
   /// The ID of the calendar for this block of time. 
   /// </returns>
   return _calendarId;
  }
  this.getDisplayText = function () {
   /// <summary>
   /// Gets the display text shown in the calendar for the time block. 
   /// </summary>
   /// <returns type="String">
   /// The display text shown in the calendar for the time block. 
   /// </returns>
   return _displayText;
  }
  this.getEffort = function () {
   /// <summary>
   /// Gets the amount of effort required for this block of time. 
   /// </summary>
   /// <returns type="Number">
   /// The amount of effort required for this block of time. 
   /// </returns>
   return _effort;
  }
  this.getEnd = function () {
   /// <summary>
   /// Gets the end time for the block. 
   /// </summary>
   /// <returns type="Date">
   /// The end time for the block.
   /// </returns>
   return _end;
  }
  this.getIsActivity = function () {
   /// <summary>
   /// Gets the value that indicates whether the block of time refers to an activity. 
   /// </summary>
   /// <returns type="Boolean">
   /// The value that indicates whether the block of time refers to an activity. 
   /// </returns>
   return _isActivity;
  }
  this.getSourceId = function () {
   /// <summary>
   /// Gets the ID of the record referred to in the time block. 
   /// </summary>
   /// <returns type="String">
   /// The ID of the record referred to in the time block. 
   /// </returns>
   return _sourceId;
  }
  this.getSourceTypeCode = function () {
   /// <summary>
   /// Gets the type of entity referred to in the time block. 
   /// </summary>
   /// <returns type="Number">
   /// The type of entity referred to in the time block. 
   /// </returns>
   return _sourceTypeCode;
  }
  this.getStart = function () {
   /// <summary>
   /// Gets the start time for the block. 
   /// </summary>
   /// <returns type="Date">
   /// The start time for the block. 
   /// </returns>
   return _start;
  }
  this.getSubCode = function () {
   /// <summary>
   /// Gets information about the time block such as whether it is an appointment, break, or holiday. 
   /// </summary>
   /// <returns type="Sdk.SubCode">
   /// Information about the time block such as whether it is an appointment, break, or holiday. 
   /// </returns>
   return _subCode;
  }
  this.getTimeCode = function () {
   /// <summary>
   /// Gets the value that indicates whether the time block is available, busy, filtered or unavailable. 
   /// </summary>
   /// <returns type="Sdk.TimeCode">
   /// The value that indicates whether the time block is available, busy, filtered or unavailable. 
   /// </returns>
   return _timeCode;
  }
  this.setActivityStatusCode = function (activityStatusCode) {
   /// <summary>
   /// Sets the status of the activity. 
   /// </summary>
   /// <param name="activityStatusCode" optional="false" mayBeNull="false" type="Number">
   /// The status of the activity.
   /// </param>
   _setValidActivityStatusCode(activityStatusCode);
  }
  this.setCalendarId = function (calendarId) {
   /// <summary>
   /// Sets the ID of the calendar for this block of time. 
   /// </summary>
   /// <param name="calendarId" optional="false" mayBeNull="false" type="String">
   /// The ID of the calendar for this block of time. 
   /// </param>
   _setValidCalendarId(calendarId);
  }
  this.setDisplayText = function (displayText) {
   /// <summary>
   /// Sets the display text shown in the calendar for the time block. 
   /// </summary>
   /// <param name="displayText" optional="false" mayBeNull="false" type="String">
   /// The display text shown in the calendar for the time block. 
   /// </param>
   _setValidDisplayText(displayText);
  }
  this.setEffort = function (effort) {
   /// <summary>
   /// Sets the amount of effort required for this block of time.
   /// </summary>
   /// <param name="effort" optional="false" mayBeNull="false" type="Number">
   /// The amount of effort required for this block of time.
   /// </param>
   _setValidEffort(effort);
  }
  this.setEnd = function (end) {
   /// <summary>
   /// Sets the end time for the block. 
   /// </summary>
   /// <param name="end" optional="false" mayBeNull="false" type="Date">
   /// The end time for the block. 
   /// </param>
   _setValidEnd(end);
  }
  this.setIsActivity = function (isActivity) {
   /// <summary>
   /// Sets the value that indicates whether the block of time refers to an activity. 
   /// </summary>
   /// <param name="isActivity" optional="false" mayBeNull="false" type="Boolean">
   /// The value that indicates whether the block of time refers to an activity. 
   /// </param>
   _setValidIsActivity(isActivity);
  }
  this.setSourceId = function (sourceId) {
   /// <summary>
   /// Sets the ID of the record referred to in the time block. 
   /// </summary>
   /// <param name="sourceId" optional="false" mayBeNull="false" type="String">
   /// The ID of the record referred to in the time block. 
   /// </param>
   _setValidSourceId(sourceId);
  }
  this.setSourceTypeCode = function (sourceTypeCode) {
   /// <summary>
   /// Sets the type of entity referred to in the time block. 
   /// </summary>
   /// <param name="sourceTypeCode" optional="false" mayBeNull="false" type="Number">
   /// The type of entity referred to in the time block. 
   /// </param>
   _setValidSourceTypeCode(sourceTypeCode);
  }
  this.setStart = function (start) {
   /// <summary>
   /// Sets the start time for the block. 
   /// </summary>
   /// <param name="start" optional="false" mayBeNull="false" type="Date">
   /// The start time for the block. 
   /// </param>
   _setValidStart(start);
  }
  this.setSubCode = function (subCode) {
   /// <summary>
   /// Sets information about the time block such as whether it is an appointment, break, or holiday. 
   /// </summary>
   /// <param name="subCode" optional="false" mayBeNull="false" type="Sdk.SubCode">
   /// Information about the time block such as whether it is an appointment, break, or holiday.  
   /// </param>
   _setValidSubCode(subCode);
  }
  this.setTimeCode = function (timeCode) {
   /// <summary>
   /// Sets the value that indicates whether the time block is available, busy, filtered or unavailable. 
   /// </summary>
   /// <param name="timeCode" optional="false" mayBeNull="false" type="Sdk.TimeCode">
   /// The value that indicates whether the time block is available, busy, filtered or unavailable. 
   /// </param>
   _setValidTimeCode(timeCode);
  }



 }
 this.TimeInfo.__class = true;

 this.SubCode = function () {
  /// <summary>Sdk.SubCode enum summary</summary>
  /// <field name="Appointment" type="String" static="true">A block of time that is already scheduled for an appointment.</field>
  /// <field name="Break" type="String" static="true">A block of time that cannot be committed due to a scheduled break.</field>
  /// <field name="Committed" type="String" static="true">A block of time that is committed to perform an action</field>
  /// <field name="Holiday" type="String" static="true">A block of time that cannot be scheduled due to a scheduled holiday. </field>
  /// <field name="ResourceCapacity" type="String" static="true">Specifies the capacity of a resource for the specified time interval.</field>
  /// <field name="ResourceServiceRestriction" type="String" static="true">A restriction for a resource for the specified service. </field>
  /// <field name="ResourceStartTime" type="String" static="true">Specifies to filter a resource start time. </field>
  /// <field name="Schedulable" type="String" static="true">A schedulable block of time.</field>
  /// <field name="ServiceCost" type="String" static="true">An override to the service cost for the specified time block.</field>
  /// <field name="ServiceRestriction" type="String" static="true">Specifies that a service is restricted during the specified block of time.</field>
  /// <field name="Uncommitted" type="String" static="true">A block of time that is tentatively scheduled but not committed.</field>
  /// <field name="Unspecified" type="String" static="true">Specifies free time with no specified restrictions.</field>
  /// <field name="Vacation" type="String" static="true">A block of time that cannot be scheduled due to a scheduled vacation.</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };

 this.TimeCode = function () {
  /// <summary>Sdk.TimeCode enum summary</summary>
  /// <field name="Available" type="String" static="true">The time is available within the working hours of the resource.</field>
  /// <field name="Busy" type="String" static="true">The time is committed to an activity.</field>
  /// <field name="Filter" type="String" static="true">Use additional filters for the time block such as service cost or service start time.</field>
  /// <field name="Unavailable" type="String" static="true">The time is unavailable.</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.TimeInfo END
 //--------------------------------------------------------------------
 //Sdk.TraceInfo START
 this.TraceInfo = function () {
  ///<summary>
  /// Specifies the results of a scheduling operation using the Validate, Book, Reschedule, or Search messages. 
  ///</summary>

  if (!(this instanceof Sdk.TraceInfo)) {
   return new Sdk.TraceInfo();
  }

  var _errorInfoList = new Sdk.Collection(Sdk.ErrorInfo);

  function _setValidErrorInfoList(value) {
   if (Sdk.Util.isCollectionOf(value, Sdk.ErrorInfo)) {
    _errorInfoList = value;
   }
   else {
    throw new Error("Sdk.TraceInfo ErrorInfoList must be a Sdk.Collection of Sdk.ErrorInfo.");
   }
  }
  this.getErrorInfoList = function () {
   /// <summary>
   /// Gets the list of error information for the scheduling operation. 
   /// </summary>
   /// <returns type="String">
   /// The list of error information for the scheduling operation. 
   /// </returns>
   return _errorInfoList;
  }
  this.setErrorInfoList = function (errorInfoList) {
   /// <summary>
   /// Sets the list of error information for the scheduling operation. 
   /// </summary>
   /// <param name="errorInfoList" optional="false" mayBeNull="false" type="Sdk.Collection">
   /// The list of error information for the scheduling operation. 
   /// </param>
   _setValidErrorInfoList(errorInfoList);
  }
 }
 this.TraceInfo.__class = true;

 this.ErrorInfo = function () {
  ///<summary>
  /// Specifies the results of a scheduling operation using the Validate, Book, or Reschedule message. 
  ///</summary>


  if (!(this instanceof Sdk.ErrorInfo)) {
   return new Sdk.ErrorInfo();
  }

  var _errorCode = null;
  var _resourceList = new Sdk.Collection(Sdk.ResourceInfo);

  function _setValidErrorCode(value) {
   if (typeof value == "string") {
    _errorCode = value;
   }
   else {
    throw new Error("Sdk.ErrorInfo ErrorCode must be a String.");
   }
  }

  function _setValidResourceList(value) {
   if (Sdk.Util.isCollectionOf(value, Sdk.ResourceInfo)) {
    _resourceList = value;
   }
   else {
    throw new Error("Sdk.ErrorInfo ResourceList must be an Sdk.Collection of Sdk.ResourceInfo.");
   }
  }



  this.getErrorCode = function () {
   /// <summary>
   /// Gets the reason for a scheduling failure.
   /// </summary>
   /// <returns type="String">
   /// The reason for a scheduling failure.
   /// </returns>
   return _errorCode;
  }

  this.getResourceList = function () {
   /// <summary>
   /// Gets the collection of information about a resource that has a scheduling problem for an appointment.
   /// </summary>
   /// <returns type="Sdk.Collection">
   /// The collection of information about a resource that has a scheduling problem for an appointment.
   /// </returns>
   return _resourceList;
  }

  this.setErrorCode = function (errorcode) {
   /// <summary>
   /// Sets the reason for a scheduling failure.
   /// </summary>
   /// <param name="errorcode" optional="false" mayBeNull="false" type="String">
   /// The reason for a scheduling failure.
   /// </param>
   _setValidErrorCode(errorcode);
  }

  this.setResourceList = function (resourceList) {
   /// <summary>
   /// Sets the collection of information about a resource that has a scheduling problem for an appointment.
   /// </summary>
   /// <param name="resourceList" optional="false" mayBeNull="false" type="Sdk.Collection">
   /// The collection of information about a resource that has a scheduling problem for an appointment.
   /// </param>
   _setValidResourceList(resourceList);
  }



 }
 this.ErrorInfo.__class = true;

 this.ResourceInfo = function () {
  ///<summary>
  /// Contains information about a resource that has a scheduling problem for an appointment. 
  ///</summary>


  if (!(this instanceof Sdk.ResourceInfo)) {
   return new Sdk.ResourceInfo();
  }

  var _displayName = null;
  var _entityName = null;
  var _id = null;

  function _setValidDisplayName(value) {
   if (typeof value == "string") {
    _displayName = value;
   }
   else {
    throw new Error("Sdk.ResourceInfo DisplayName property must be a String.");
   }
  }

  function _setValidEntityName(value) {
   if (typeof value == "string") {
    _entityName = value;
   }
   else {
    throw new Error("Sdk.ResourceInfo EntityName property must be a String.");
   }
  }

  function _setValidId(value) {
   if (Sdk.Util.isGuid(value)) {
    _id = value;
   }
   else {
    throw new Error("Sdk.ResourceInfo Id property must be a String.");
   }
  }

  this.getDisplayName = function () {
   /// <summary>
   /// Gets the display name for the resource.
   /// </summary>
   /// <returns type="String">
   /// The display name for the resource.
   /// </returns>
   return _displayName;
  }
  this.getEntityName = function () {
   /// <summary>
   /// Gets the logical name of the entity.
   /// </summary>
   /// <returns type="String">
   /// The logical name of the entity.
   /// </returns>
   return _entityName;
  }
  this.getId = function () {
   /// <summary>
   /// Gets the ID of the record that has a scheduling problem.
   /// </summary>
   /// <returns type="String">
   /// The ID of the record that has a scheduling problem.
   /// </returns>
   return _id;
  }


  this.setDisplayName = function (displayName) {
   /// <summary>
   /// Sets the display name for the resource.
   /// </summary>
   /// <param name="displayName" optional="false" mayBeNull="false" type="String">
   /// The display name for the resource.
   /// </param>
   _setValidDisplayName(displayName);
  }

  this.setEntityName = function (entityName) {
   /// <summary>
   /// Sets the logical name of the entity.
   /// </summary>
   /// <param name="entityName" optional="false" mayBeNull="false" type="String">
   /// The logical name of the entity.
   /// </param>
   _setValidEntityName(entityName);
  }

  this.setId = function (id) {
   /// <summary>
   /// Sets the ID of the record that has a scheduling problem.
   /// </summary>
   /// <param name="id" optional="false" mayBeNull="false" type="String">
   /// The ID of the record that has a scheduling problem.
   /// </param>
   _setValidId(id);
  }
 }
 this.ResourceInfo.__class = true;
 //Sdk.TraceInfo END
 //--------------------------------------------------------------------
 //Sdk.ValidationResult START
 this.ValidationResult = function () {
  ///<summary>
  /// Contains the result from the ValidateRequest, BookRequest, or RescheduleRequest messages. 
  ///</summary>

  if (!(this instanceof Sdk.ValidationResult)) {
   return new Sdk.ValidationResult();
  }

  var _activityId = null;
  var _traceInfo = null;
  var _validationSuccess = null;

  function _setValidActivityId(value) {
   if (Sdk.Util.isGuid(value)) {
    _activityId = value;
   }
   else {
    throw new Error("Sdk.ValidationResult ActivityId  property must be a String representation of a Guid Value.");
   }
  }

  function _setValidTraceInfo(value) {
   if (value instanceof Sdk.TraceInfo) {
    _traceInfo = value;
   }
   else {
    throw new Error("Sdk.ValidationResult TraceInfo  property must be a Sdk.TraceInfo.");
   }
  }

  function _setValidValidationSuccess(value) {
   if (typeof value == "boolean") {
    _validationSuccess = value;
   }
   else {
    throw new Error("Sdk.ValidationResult ValidationSuccess  property must be a Boolean.");
   }
  }

  this.getActivityId = function () {
   /// <summary>
   /// Gets the ID of the validated activity. 
   /// </summary>
   /// <returns type="String">
   /// The ID of the validated activity. 
   /// </returns>
   return _activityId;
  }

  this.getTraceInfo = function () {
   /// <summary>
   /// Gets the reasons for any scheduling failures. 
   /// </summary>
   /// <returns type="Sdk.TraceInfo">
   /// The reasons for any scheduling failures. 
   /// </returns>
   return _traceInfo;
  }

  this.getValidationSuccess = function () {
   /// <summary>
   /// Gets the value that indicates whether the appointment or service appointment was validated successfully. 
   /// </summary>
   /// <returns type="Boolean">
   /// The value that indicates whether the appointment or service appointment was validated successfully. 
   /// </returns>
   return _validationSuccess;
  }


  this.setActivityId = function (activityId) {
   /// <summary>
   /// Sets the ID of the validated activity. 
   /// </summary>
   /// <param name="activityId" optional="false" mayBeNull="false" type="String">
   /// The ID of the validated activity. 
   /// </param>
   _setValidActivityId(activityId);
  }

  this.setTraceInfo = function (traceInfo) {
   /// <summary>
   /// Sets the reasons for any scheduling failures. 
   /// </summary>
   /// <param name="traceInfo" optional="false" mayBeNull="false" type="Sdk.TraceInfo">
   /// The reasons for any scheduling failures. 
   /// </param>
   _setValidTraceInfo(traceInfo);
  }
  this.setValidationSuccess = function (validationSuccess) {
   /// <summary>
   /// Sets the value that indicates whether the appointment or service appointment was validated successfully. 
   /// </summary>
   /// <param name="validationSuccess" optional="false" mayBeNull="false" type="Boolean">
   /// The value that indicates whether the appointment or service appointment was validated successfully. 
   /// </param>
   _setValidValidationSuccess(validationSuccess);
  }

 }
 this.ValidationResult.__class = true;
 //Sdk.ValidationResult END

}).call(Sdk);

(function ()
{
 

 var _clientUrl = null;
 this.isGuid = function (value) {
  ///<summary>
  /// Verifies the parameter is a string formatted as a GUID
  ///</summary>
  ///<param name="value" type="String" optional="false" mayBeNull="false">
  /// The value to check
  ///</param>
  if (typeof value == "string") {
   if (/^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$/.test(value)) {
    return true;
   }
   return false;
  }
  else {
   throw new Error("Sdk.Util.isGuid value parameter must be a string.");
  }
 }
 this.isGuidOrNull = function (value) {
  ///<summary>
  /// Verifies the parameter is a string formatted as a GUID or null
  ///</summary>
  ///<param name="value" type="String" optional="false" mayBeNull="true">
  /// The value to check
  ///</param>
  if (value == null || typeof value == "string") {
   if (value == null) {
    return true;
   }
   else {
    return Sdk.Util.isGuid(value);
   }
  }
  else {
   throw new Error("Sdk.Util.isGuidOrNull value parameter must be a string or null.");
  }
 }

 this.isValidEnumValue = function (enumeration, value) {
  for (var i in enumeration) {
   if (value == i) {
    return true;
   }
  }
  return false;
 }


 this.getEmptyGuid = function () {
  return "00000000-0000-0000-0000-000000000000";
 }

 //Rather than override String to add a format method, this approach should not break or be broken by others using a different style of string format.
 this.format = function (string, args) {
  ///<summary>
  /// Formats a string with the arguments from an array
  ///</summary>
  ///<param name="string" type="String" optional="false" mayBeNull="false">
  /// The string containing placeholders for items in the array
  ///</param>
  ///<param name="args" type="Array" optional="false" mayBeNull="false">
  /// An array of strings to replace the placeholders
  ///</param>
  if (typeof string != "string") {
   throw new Error("Sdk.Util.format string parameter is required and must be a string.");
  }
  var invalidArgsMessage = "Sdk.Util.format args parameter is required and must be an array of strings.";
  if (typeof args == "undefined" || args == null) {
   throw new Error(invalidArgsMessage);
  }
  if (typeof args.push != "function") {
   throw new Error(invalidArgsMessage);
  }
  else {
   for (var i = 0; i < args.length; i++) {
    if (typeof args[i] != "string") {
     throw new Error(invalidArgsMessage);
    }
   }
  }

  return string.replace(/\{\{|\}\}|\{(\w+)\}/g, function (a, b) {
   if (a == "{{") { return "{"; }
   if (a == "}}") { return "}"; }
   return args[b];
  });

 }

 this.getError = function (resp) {

  //Error descriptions come from http://support.microsoft.com/kb/193625
  if (resp.status == 12029)
  { return new Error("The attempt to connect to the server failed."); }
  if (resp.status == 12007)
  { return new Error("The server name could not be resolved."); }

  var errorMessage = "Unknown Error (Unable to parse the fault)";

  var faultXML = resp.responseXML;
  if (faultXML != null &&
   typeof faultXML.firstChild != "undefined" &&
   faultXML.firstChild != null &&
   typeof faultXML.firstChild.firstChild != "undefined" &&
   faultXML.firstChild.firstChild != null) {
   try {
    var bodyNode = faultXML.firstChild.firstChild;
    //Retrieve the fault node
    for (var i = 0; i < bodyNode.childNodes.length; i++) {
     var node = bodyNode.childNodes[i];
     //NOTE: This comparison does not handle the case where the XML namespace changes
     if ("s:Fault" == node.nodeName) {
      for (var j = 0; j < node.childNodes.length; j++) {
       var faultStringNode = node.childNodes[j];
       if ("faultstring" == faultStringNode.nodeName) {
        errorMessage = Sdk.Xml.getNodeText(faultStringNode);
        break;
       }
      }
      break;
     }
    }
   }
   catch (e)
   {
    //The following may be helpful for debugging.
    //if (typeof console != "undefined") {
    // //console.log("error message:" + e.message);
    // var faultString = "Not able to get fault XML";
    // if (window.XMLSerializer) {
    //  var serializer = new XMLSerializer();
    //  try {
    //   faultString = serializer.serializeToString(faultXML);
    //  }
    //  catch (e) {
    //   try {
    //    faultString = faultXML.xml;
    //   }
    //   catch (e) { }
    //  };
    // }
    // //console.log("faultXML:" + faultString);
    //}
   }

  }
  else {
   errorMessage = "status: " + resp.status + ": " + resp.statusText;
   //if (typeof console != "undefined") {
   // console.log(errorMessage);
   //}
  }
  return new Error(errorMessage);
 };
 this.getClientUrl = function () {
  if (_clientUrl != null)
  { return _clientUrl; }
  else
  {
   try {
    return GetGlobalContext().getClientUrl();
   }
   catch (e) {
    try {
     return Xrm.Page.context.getClientUrl();
    }
    catch (e) {
     throw new Error("Sdk.Util.getClientUrl Unable to get clientUrl. Context not available.");
    }
   }
  }
 };
 this.setClientUrl = function (url) {
  ///<summary>
  /// Provides a way to override the client Url when a client-side context is not available
  ///</summary>
  ///<param name="url" type="String">
  /// The client URL to use instead of the default.
  ///</param>
  if (typeof url == "string") {
   _clientUrl = url;
  }
  else {
   throw new Error("Sdk.Util.setClientUrl 'url' parameter must be a string.");
  }
 }
 this.getXMLHttpRequest = function (action, async) {
  var req = new XMLHttpRequest();
  req.open("POST", Sdk.Util.getClientUrl() + "/XRMServices/2011/Organization.svc/web", async)
  try { req.responseType = 'msxml-document' } catch (e) { }
  req.setRequestHeader("Accept", "application/xml, text/xml, */*");
  req.setRequestHeader("Content-Type", "text/xml; charset=utf-8");
  req.setRequestHeader("SOAPAction", "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/" + action);
  return req;
 }

 this.convertAccessRightsToString = function (enumValue) {
  ///<summary>
  /// Internal use only.
  ///</summary>
  ///<param name="enumValue" optional="false" type="Number" mayBeNull="false">
  /// The Number representing the enum values to apply
  ///</param>
  ///<returns type="String">
  /// The String describing access rights
  ///</returns>
  var returnValue = "None";
  if (enumValue != null) {
   var valueArray = [];
   if ((1 & enumValue) == 1) {
    valueArray.push("ReadAccess");
   }
   if ((2 & enumValue) == 2) {
    valueArray.push("WriteAccess");
   }
   if ((4 & enumValue) == 4) {
    valueArray.push("ShareAccess");
   }
   if ((8 & enumValue) == 8) {
    valueArray.push("AssignAccess");
   }
   if ((16 & enumValue) == 16) {
    valueArray.push("AppendAccess");
   }
   if ((32 & enumValue) == 32) {
    valueArray.push("AppendToAccess");
   }
   if ((64 & enumValue) == 64) {
    valueArray.push("CreateAccess");
   }
   if ((128 & enumValue) == 128) {
    valueArray.push("DeleteAccess");
   }
   returnValue = valueArray.join(" ");
  }
  return returnValue;
 }

 this.convertAccessRightsFromString = function (stringValue) {
  ///<summary>
  /// Internal use only.
  ///</summary>
  ///<param name="stringValue" optional="false" type="String" mayBeNull="false">
  /// The string describing access rights
  ///</param>
  ///<returns type="Number">
  /// The Number describing access rights
  ///</returns>
  var returnValue = {};
  returnValue.Text = stringValue;
  returnValue.ReadAccess = (stringValue.indexOf("ReadAccess") > -1);
  returnValue.WriteAccess = (stringValue.indexOf("WriteAccess") > -1);
  returnValue.ShareAccess = (stringValue.indexOf("ShareAccess") > -1);
  returnValue.AssignAccess = (stringValue.indexOf("AssignAccess") > -1);
  returnValue.AppendAccess = (stringValue.indexOf("AppendAccess") > -1);
  returnValue.AppendToAccess = (stringValue.indexOf("AppendToAccess") > -1);
  returnValue.CreateAccess = (stringValue.indexOf("CreateAccess") > -1);
  returnValue.DeleteAccess = (stringValue.indexOf("DeleteAccess") > -1);
  returnValue.Value = 0;
  if (returnValue.ReadAccess)
  { returnValue.Value = returnValue.Value + 1; }
  if (returnValue.WriteAccess)
  { returnValue.Value = returnValue.Value + 2; }
  if (returnValue.ShareAccess)
  { returnValue.Value = returnValue.Value + 4; }
  if (returnValue.AssignAccess)
  { returnValue.Value = returnValue.Value + 8; }
  if (returnValue.AppendAccess)
  { returnValue.Value = returnValue.Value + 16; }
  if (returnValue.AppendToAccess)
  { returnValue.Value = returnValue.Value + 32; }
  if (returnValue.CreateAccess)
  { returnValue.Value = returnValue.Value + 64; }
  if (returnValue.DeleteAccess)
  { returnValue.Value = returnValue.Value + 128; }
  return returnValue;
 }

 this.createEntityFromNode = function (node) {
  ///<summary>
  /// Creates an entity from XML
  ///</summary>
  ///<param name="node" type="XMLNode">
  /// The serialized entity returned from the SOAP service as XML
  ///</param>
  /// <returns type="Sdk.Entity">
  /// An entity instance
  /// </returns>
  if (Sdk.Xml.isNodeNull(node))
  { return null; }
  var entity = new Sdk.Entity();
  var attributesNode = Sdk.Xml.selectSingleNode(node, "a:Attributes");
  for (var i = 0; i < attributesNode.childNodes.length; i++) {
   entity.getAttributes().add(createAttributeFromNode(attributesNode.childNodes[i]), false);
  }
  entity.setEntityState(Sdk.Xml.selectSingleNodeText(node, "a:EntityState"));
  var formattedValuesNode = Sdk.Xml.selectSingleNode(node, "a:FormattedValues");
  for (var i = 0; i < formattedValuesNode.childNodes.length; i++) {
   entity.getFormattedValues().add(createFormattedValueFromNode(formattedValuesNode.childNodes[i]));
  }
  entity.setId(Sdk.Xml.selectSingleNodeText(node, "a:Id"));
  entity.setType(Sdk.Xml.selectSingleNodeText(node, "a:LogicalName"));
  //Set entity children so that they won't get saved again.
  entity.setIsChanged(false);
  var relatedEntities = createRelatedEntitiesFromNode(Sdk.Xml.selectSingleNode(node, "a:RelatedEntities"));
  entity.setRelatedEntities(relatedEntities);

  return entity;
 }

 function createRelatedEntitiesFromNode(node) {
  ///<summary>
  /// Creates a related entities collection from XML
  ///</summary>
  ///<param name="node" type="XMLNode">
  /// The serialized related entities collection for an entity returned from the SOAP service as XML
  ///</param>
  /// <returns type="Sdk.RelatedEntitiesCollection">
  /// A related entities collection for an entity.
  /// </returns>
  var relatedEntities = new Sdk.RelatedEntitiesCollection();

  for (var i = 0; i < node.childNodes.length; i++) {
   var rec = createRelationshipEntityCollectionFromNode(node.childNodes[i]);
   relatedEntities.addRelationshipEntityCollection(rec);
  }
  return relatedEntities;
 }

 function createRelationshipEntityCollectionFromNode(node) {
  ///<summary>
  /// Creates a set of related entities for a specific relationship from XML
  ///</summary>
  ///<param name="node" type="XMLNode">
  /// The serialized related entities for a specific relationship to an entity returned from the SOAP service as XML
  ///</param>
  /// <returns type="Sdk.RelationshipEntityCollection">
  /// A related entities for a specific relationship for an entity.
  /// </returns>
  var schemaName = Sdk.Xml.selectSingleNodeText(node, "b:key/a:SchemaName");
  var rec = new Sdk.RelationshipEntityCollection(schemaName);
  var entityCollection = Sdk.Util.createEntityCollectionFromNode(Sdk.Xml.selectSingleNode(node, "b:value"));
  rec.setEntityCollection(entityCollection);
  return rec;
 }

 function createAttributeFromNode(node) {
  ///<summary>
  /// Creates an attribute from XML
  ///</summary>
  ///<param name="node" type="XMLNode">
  /// The serialized attribute returned from the SOAP service as XML
  ///</param>
  /// <returns type="Sdk.AttributeBase">
  /// An instance of one of the attributes classes that inherit from Sdk.AttributeBase
  /// </returns>
  var logicalName = Sdk.Xml.selectSingleNodeText(node, "b:key");
  var attribute = null;
  var valueNode = Sdk.Xml.selectSingleNode(node, "b:value");
  var valueType = Sdk.Xml.getNodeText(valueNode.attributes.getNamedItem("i:type"));
  attribute = getTypedValue(logicalName, node, valueNode, valueType);
  attribute.setIsChanged(false);
  return attribute;
 }

 function getTypedValue(logicalName, node, valueNode, type) {
  ///<summary>
  /// Creates a typed attribute value
  ///</summary>
  ///<param name="logicalName" type="String">
  /// The logical name of the attribute
  ///</param>
  ///<param name="node" type="XMLNode">
  /// The serialized attribute returned from the SOAP service as XML
  ///</param>
  ///<param name="valueNode" type="String">
  /// The value nodes of the serialized attribute returned from the SOAP service as XML
  ///</param>
  ///<param name="type" type="String">
  /// The type of the attribute
  ///</param>
  /// <returns type="Sdk.AttributeBase">
  /// An instance of one of the attributes classes that inherit from Sdk.AttributeBase
  /// </returns>

  var typeString = type.split(":")[1];
  switch (typeString) {
   case "string":
    return new Sdk.String(logicalName, Sdk.Xml.selectSingleNodeText(node, "b:value"));
    break;
   case "guid":
    return new Sdk.Guid(logicalName, Sdk.Xml.selectSingleNodeText(node, "b:value"));
    break;
   case "Money":
    return new Sdk.Money(logicalName, parseFloat(Sdk.Xml.getNodeText(valueNode)));
    break;
   case "long":
    return new Sdk.Long(logicalName, parseInt(Sdk.Xml.getNodeText(valueNode), 10));
    break;
   case "decimal":
    return new Sdk.Decimal(logicalName, parseFloat(Sdk.Xml.getNodeText(valueNode)));
    break;
   case "double":
    return new Sdk.Double(logicalName, parseFloat(Sdk.Xml.getNodeText(valueNode)));
    break;
   case "int":
    return new Sdk.Int(logicalName, parseInt(Sdk.Xml.getNodeText(valueNode), 10));
    break;
   case "OptionSetValue":
    return new Sdk.OptionSet(logicalName, parseInt(Sdk.Xml.selectSingleNodeText(valueNode, "a:Value"), 10));
    break;
   case "boolean":
    return new Sdk.Boolean(logicalName, (Sdk.Xml.selectSingleNodeText(node, "b:value") == "true") ? true : false);
    break;
   case "dateTime":
    return new Sdk.DateTime(logicalName, new Date(Sdk.Xml.selectSingleNodeText(node, "b:value")));
    break;
   case "EntityReference":
    var _type, _id, _name;
    _type = Sdk.Xml.selectSingleNodeText(valueNode, "a:LogicalName");
    _id = Sdk.Xml.selectSingleNodeText(valueNode, "a:Id");
    _name = Sdk.Xml.selectSingleNodeText(valueNode, "a:Name");
    return new Sdk.Lookup(logicalName, new Sdk.EntityReference(_type, _id, _name));
    break;
   case "BooleanManagedProperty":
    var _canBeChanged, _managedPropertyLogicalName, _bmpValue;
    _canBeChanged = (Sdk.Xml.selectSingleNodeText(valueNode, "a:CanBeChanged") == "true") ? true : false;
    _managedPropertyLogicalName = Sdk.Xml.selectSingleNodeText(valueNode, "a:ManagedPropertyLogicalName");
    _bmpValue = (Sdk.Xml.selectSingleNodeText(valueNode, "a:Value") == "true") ? true : false;
    return new Sdk.BooleanManagedProperty(logicalName, new Sdk.BooleanManagedPropertyValue(_canBeChanged, _bmpValue, _managedPropertyLogicalName));
    break;
   case "EntityCollection":
    return new Sdk.PartyList(logicalName, Sdk.Util.createEntityCollectionFromNode(valueNode));
    break;
   case "AliasedValue":
    var value;
    var aliasedValueNode = Sdk.Xml.selectSingleNode(valueNode, "a:Value ");
    var aliasedValueNodeType = Sdk.Xml.getNodeText(aliasedValueNode.attributes.getNamedItem("i:type"));
    var aliasedValueNodeTypeString = aliasedValueNodeType.split(":")[1];
    switch (aliasedValueNodeTypeString) {
     case "string":
      return new Sdk.String(logicalName, Sdk.Xml.getNodeText(aliasedValueNode));
      break;
     case "guid":
      return new Sdk.Guid(logicalName, Sdk.Xml.getNodeText(aliasedValueNode));
      break;
     case "Money":
      return new Sdk.Money(logicalName, parseFloat(Sdk.Xml.getNodeText(aliasedValueNode)));
      break;
     case "long":
      return new Sdk.Long(logicalName, parseInt(Sdk.Xml.getNodeText(aliasedValueNode), 10));
      break;
     case "decimal":
      return new Sdk.Decimal(logicalName, parseFloat(Sdk.Xml.getNodeText(aliasedValueNode)));
      break;
     case "double":
      return new Sdk.Double(logicalName, parseInt(Sdk.Xml.getNodeText(aliasedValueNode), 10));
      break;
     case "int":
      return new Sdk.Int(logicalName, parseInt(Sdk.Xml.getNodeText(aliasedValueNode), 10));
      break;
     case "OptionSetValue":
      return new Sdk.OptionSet(logicalName, parseInt(Sdk.Xml.getNodeText(aliasedValueNode), 10));
      break;
     case "boolean":
      return new Sdk.Boolean(logicalName, (Sdk.Xml.getNodeText(aliasedValueNode) == "true") ? true : false);
      break;
     case "dateTime":
      return new Sdk.DateTime(logicalName, new Date(Sdk.Xml.getNodeText(aliasedValueNode)));
      break;
     case "EntityReference":
      var _aType, _aId, _aName;
      _aType = Sdk.Xml.selectSingleNodeText(aliasedValueNode, "a:LogicalName");
      _aId = Sdk.Xml.selectSingleNodeText(aliasedValueNode, "a:Id");
      _aName = Sdk.Xml.selectSingleNodeText(aliasedValueNode, "a:Name");
      return new Sdk.Lookup(logicalName, new Sdk.EntityReference(_aType, _aId, _aName));
      break;
     case "BooleanManagedProperty":
      var _aCanBeChanged, _aManagedPropertyLogicalName, _aBmpValue;
      _aCanBeChanged = (Sdk.Xml.selectSingleNodeText(aliasedValueNode, "a:CanBeChanged") == "true") ? true : false;
      _aManagedPropertyLogicalName = Sdk.Xml.selectSingleNodeText(aliasedValueNode, "a:ManagedPropertyLogicalName");
      _aBmpValue = (Sdk.Xml.selectSingleNodeText(aliasedValueNode, "a:Value") == "true") ? true : false;
      return new Sdk.BooleanManagedProperty(logicalName, new Sdk.BooleanManagedPropertyValue(_aCanBeChanged, _aBmpValue, _aManagedPropertyLogicalName ));
      break;
     case "EntityCollection":
      return new Sdk.PartyList(logicalName, Sdk.Util.createEntityCollectionFromNode(aliasedValueNode));
      break;
     default:
      throw new Error("Sdk unimplemented AliasedValue type found in getTypedValue function");
    }
    break;
   default:
    throw new Error("Sdk unimplemented type found in getTypedValue function");
  }
 }

 function createFormattedValueFromNode(node) {
  ///<summary>
  /// Creates an formatted value from XML
  ///</summary>
  ///<param name="node" type="XMLNode">
  /// The serialized formatted value returned from the SOAP service as XML
  ///</param>
  /// <returns type="Sdk.FormattedValue">
  /// An Formatted value
  /// </returns>
  var key = Sdk.Xml.selectSingleNodeText(node, "b:key");
  var value = Sdk.Xml.selectSingleNodeText(node, "b:value");
  return new Sdk.FormattedValue(key, value);
 }

 this.createEntityCollectionFromNode = function (node) {
  ///<summary>
  /// Creates an entity collection from serialized entity returned from the SOAP service as XML
  ///</summary>
  ///<param name="node" type="XMLNode>
  /// The serialized entity collection returned from the SOAP service as XML
  ///</param>
  ///<returns  type="Sdk.EntityCollection">
  /// The entity collection.
  ///</returns>
  var ec = new Sdk.EntityCollection();
  ec.setEntityName(Sdk.Xml.selectSingleNodeText(node, "a:EntityName"));
  ec.setMinActiveRowVersion(Sdk.Xml.selectSingleNodeText(node, "a:MinActiveRowVersion"));
  ec.setMoreRecords((Sdk.Xml.selectSingleNodeText(node, "a:MoreRecords") == 'true') ? true : false);
  ec.setPagingCookie(Sdk.Xml.selectSingleNodeText(node, "a:PagingCookie"));
  ec.setTotalRecordCount(parseInt(Sdk.Xml.selectSingleNodeText(node, "a:TotalRecordCount")));
  ec.setTotalRecordCountLimitExceeded((Sdk.Xml.selectSingleNodeText(node, "a:TotalRecordCountLimitExceeded") == 'true') ? true : false);
  var entitiesNode = Sdk.Xml.selectSingleNode(node, "a:Entities");
  for (var i = 0; i < entitiesNode.childNodes.length; i++) {
   ec.getEntities().add(Sdk.Util.createEntityFromNode(entitiesNode.childNodes[i]));
  }
  return ec;
 }

 this.createEntityReferenceFromNode = function (node) {
  ///<summary>
  /// Creates an entity reference from serialized entity returned from the SOAP service as XML
  ///</summary>
  ///<param name="node" type="XMLNode>
  /// The serialized entity collection returned from the SOAP service as XML
  ///</param>
  ///<returns  type="Sdk.EntityReference">
  /// The entity collection.
  ///</returns>
  var logicalName, id, name;
  logicalName = Sdk.Xml.selectSingleNodeText(node, "a:LogicalName");
  id = Sdk.Xml.selectSingleNodeText(node, "a:Id");
  name = Sdk.Xml.selectSingleNodeText(node, "a:Name");
  return new Sdk.EntityReference(logicalName, id, name);
 }

 this.createEntityReferenceCollectionFromNode = function (node) {
  ///<summary>
  /// Creates an entity reference collection from serialized entity returned from the SOAP service as XML
  ///</summary>
  ///<param name="node" type="XMLNode>
  /// The serialized entity reference collection returned from the SOAP service as XML
  ///</param>
  ///<returns  type="Sdk.EntityReferenceCollection">
  /// The entity reference collection.
  ///</returns>
  var erc = new Sdk.Collection(Sdk.EntityReference);
  for (var i = 0; i < node.childNodes.length; i++) {
   erc.add(Sdk.Util.createEntityReferenceFromNode(node.childNodes[i]));
  }
  return new Sdk.EntityReferenceCollection(erc);
 }

 this.createPrincipleAccessCollectionFromNode = function (node) {
  ///<summary>
  /// Creates an principal access collection from serialized entity returned from the SOAP service as XML
  ///</summary>
  ///<param name="node" type="XMLNode>
  /// The serialized array of  principal access returned from the SOAP service as XML
  ///</param>
  ///<returns  type="Sdk.Collection">
  /// A collection of Sdk.PrincipalAccess
  ///</returns>
  var pac = new Sdk.Collection(Sdk.PrincipalAccess);
  for (var i = 0; i < node.childNodes.length; i++) {
   pac.add(createPrincipalAccessFromNode(node.childNodes[i]));
  }
  return pac;
 }

 function createPrincipalAccessFromNode(node) {
  ///<summary>
  /// Creates a PrincipalAccess from XML
  ///</summary>
  ///<param name="node" type="XMLNode">
  /// The PrincipalAccess value returned from the SOAP service as XML
  ///</param>
  /// <returns type="Sdk.PrincipalAccess">
  /// A PrincipalAccess value
  /// </returns>
  var accessMask = Sdk.Util.convertAccessRightsFromString(Sdk.Xml.selectSingleNodeText(node, "g:AccessMask")).Value;
  var principal = Sdk.Util.createEntityReferenceFromNode(Sdk.Xml.selectSingleNode(node, "g:Principal"));
  return new Sdk.PrincipalAccess(accessMask, principal);

 }

 this.createRolePrivilegeCollectionFromNode = function (node) {
  ///<summary>
  /// Creates a RolePrivilege collection from serialized entity returned from the SOAP service as XML
  ///</summary>
  ///<param name="node" type="XMLNode>
  /// The serialized array of RolePrivilege returned from the SOAP service as XML
  ///</param>
  ///<returns  type="Sdk.Collection">
  /// A collection of Sdk.RolePrivilege
  ///</returns>
  var rpc = new Sdk.Collection(Sdk.RolePrivilege);
  for (var i = 0; i < node.childNodes.length; i++) {
   rpc.add(createRolePrivilegeFromNode(node.childNodes[i]));
  }
  return rpc;
 }

 function createRolePrivilegeFromNode(node) {
  ///<summary>
  /// Creates a RolePrivilege from XML
  ///</summary>
  ///<param name="node" type="XMLNode">
  /// The RolePrivilege value returned from the SOAP service as XML
  ///</param>
  /// <returns type="Sdk.RolePrivilege">
  /// A RolePrivilege value
  /// </returns>
  var businessUnitId = Sdk.Xml.selectSingleNodeText(node, "g:BusinessUnitId");
  var depth = Sdk.Xml.selectSingleNodeText(node, "g:Depth");
  var privilegeId = Sdk.Xml.selectSingleNodeText(node, "g:PrivilegeId");
  return new Sdk.RolePrivilege(depth, privilegeId, businessUnitId);

 }

 this.createIntegerCollectionFromNode = function (node) {
  ///<summary>
  /// Creates a Integer collection from serialized entity returned from the SOAP service as XML
  ///</summary>
  ///<param name="node" type="XMLNode>
  /// The serialized array of integers returned from the SOAP service as XML
  ///</param>
  ///<returns  type="Sdk.Collection">
  /// A collection of Integers
  ///</returns>
  var ic = new Sdk.Collection(Number);
  for (var i = 0; i < node.childNodes.length; i++) {
   ic.add(parseInt((Sdk.Xml.getNodeText(node.childNodes[i]))), 10);
  }
  return ic;
 }


 this.createBooleanCollectionFromNode = function (node) {
  ///<summary>
  /// Creates a Boolean collection from serialized entity returned from the SOAP service as XML
  ///</summary>
  ///<param name="node" type="XMLNode>
  /// The serialized array of Boolean values returned from the SOAP service as XML
  ///</param>
  ///<returns  type="Sdk.Collection">
  /// A collection of Boolean values
  ///</returns>
  var bc = new Sdk.Collection(Boolean);
  for (var i = 0; i < node.childNodes.length; i++) {
   bc.add(((Sdk.Xml.getNodeText(node.childNodes[i])) == "true") ? true : false);
  }
  return bc;
 }


 this.createCollectionOfTimeInfoCollectionFromNode = function (node) {
  ///<summary>
  /// Creates a collection of TimeInfo collections from serialized entity returned from the SOAP service as XML
  ///</summary>
  ///<param name="node" type="XMLNode>
  /// The serialized array of TimeInfo arrays returned from the SOAP service as XML
  ///</param>
  ///<returns  type="Sdk.Collection">
  /// A collection of TimeInfo collections
  ///</returns>
  var ticc = new Sdk.Collection(Sdk.Collection);
  for (var i = 0; i < node.childNodes.length; i++) {
   ticc.add(Sdk.Util.createTimeInfoCollectionFromNode(node.childNodes[i]));
  }
  return ticc;

 }
 this.createTimeInfoCollectionFromNode = function (node) {
  ///<summary>
  /// Creates a TimeInfo collection from serialized entity returned from the SOAP service as XML
  ///</summary>
  ///<param name="node" type="XMLNode>
  /// The serialized array of TimeInfo returned from the SOAP service as XML
  ///</param>
  ///<returns  type="Sdk.Collection">
  /// A collection of TimeInfo
  ///</returns>
  var tic = new Sdk.Collection(Sdk.TimeInfo);
  for (var i = 0; i < node.childNodes.length; i++) {
   tic.add(createTimeInfoFromNode(node.childNodes[i]));
  }
  return tic;
 }

 function createTimeInfoFromNode(node) {
  var activityStatusCode = parseInt(Sdk.Xml.getNodeText(node, "g:ActivityStatusCode"), 10);
  var calendarId = Sdk.Xml.selectSingleNodeText(node, "g:CalendarId");
  var displayText = Sdk.Xml.selectSingleNodeText(node, "g:DisplayText");
  var effort = parseFloat(Sdk.Xml.selectSingleNodeText(node, "g:Effort"));;
  var end = null;
  var testEndDate;
  try {
   testEndDate = new Date(Sdk.Xml.selectSingleNodeText(node, "g:End"));
   end = testEndDate;
  }
  catch (e) { }
  var isActivity = (Sdk.Xml.selectSingleNodeText(node, "g:ActivityStatusCode") == "true") ? true : false;
  var sourceId = Sdk.Xml.selectSingleNodeText(node, "g:SourceId");
  var sourceTypeCode = parseInt(Sdk.Xml.selectSingleNodeText(node, "g:SourceTypeCode"), 10);;
  var start = null;
  try {
   testStartDate = new Date(Sdk.Xml.selectSingleNodeText(node, "g:Start"));
   start = testStartDate;
  }
  catch (e) { }
  var subCode = Sdk.Xml.selectSingleNodeText(node, "g:SubCode");
  var timeCode = Sdk.Xml.selectSingleNodeText(node, "g:TimeCode");



  var rv = new Sdk.TimeInfo();
  if (activityStatusCode != null) {
   rv.setActivityStatusCode(activityStatusCode);
  }
  if (calendarId != null) {
   rv.setCalendarId(calendarId);
  }
  if (displayText != null) {
   rv.setDisplayText(displayText);
  }
  if (effort != null) {
   rv.setEffort(effort);
  }
  //End can be null
  rv.setEnd(end);
  if (isActivity != null) {
   rv.setIsActivity(isActivity);
  }
  if (sourceId != null) {
   rv.setSourceId(sourceId);
  }
  if (sourceTypeCode != null) {
   rv.setSourceTypeCode(sourceTypeCode);
  }
  //Start can be null
  rv.setStart(start);
  if (subCode != null) {
   rv.setSubCode(subCode);
  }
  if (timeCode != null) {
   rv.setTimeCode(timeCode);
  }


  return rv;

 }

 this.createValidationResultCollectionFromNode = function (node) {
  ///<summary>
  /// Creates a ValidationResult collection from serialized entity returned from the SOAP service as XML
  ///</summary>
  ///<param name="node" type="XMLNode>
  /// The serialized array of ValidationResult returned from the SOAP service as XML
  ///</param>
  ///<returns  type="Sdk.Collection">
  /// A collection of ValidationResult
  ///</returns>
  var vrc = new Sdk.Collection(Sdk.ValidationResult);
  for (var i = 0; i < node.childNodes.length; i++) {
   vrc.add(Sdk.Util.createValidationResultFromNode(node.childNodes[i]));
  }
  return vrc;
 }

 this.createValidationResultFromNode = function (node) {
  ///<summary>
  /// Creates a ValidationResult from XML
  ///</summary>
  ///<param name="node" type="XMLNode">
  /// The ValidationResult value returned from the SOAP service as XML
  ///</param>
  /// <returns type="Sdk.ValidationResult">
  /// A ValidationResult instance
  /// </returns>
  var rv = new Sdk.ValidationResult();
  rv.setActivityId(Sdk.Xml.selectSingleNodeText(node, "g:ActivityId"));
  rv.setTraceInfo(Sdk.Util.createTraceInfoFromNode(node));
  rv.setValidationSuccess((Sdk.Xml.selectSingleNodeText(node, "g:ValidationSuccess") == "true") ? true : false);
  return rv;
 }

 this.createTraceInfoFromNode = function (node) {
  var rv = new Sdk.TraceInfo();
  var errorInfoList = new Sdk.Collection(Sdk.ErrorInfo);

  var errorInfoListNode = Sdk.Xml.selectSingleNode(node, "g:TraceInfo/g:ErrorInfoList");
  for (var i = 0; i < errorInfoListNode.childNodes.length; i++) {
   errorInfoList.add(createErrorInfoFromNode(errorInfoListNode.childNodes[i]));
  }

  rv.setErrorInfoList(errorInfoList);
  return rv;
 }

 this.createAuditDetailCollectionFromNode = function (node) {
  var rv = new Sdk.AuditDetailCollection();

  rv.setMoreRecords((Sdk.Xml.selectSingleNodeText(node, "g:MoreRecords") == "true") ? true : false);
  rv.setTotalRecordCount(parseInt(Sdk.Xml.selectSingleNodeText(node, "g:TotalRecordCount"), 10));
  rv.setPagingCookie(Sdk.Xml.selectSingleNodeText(node, "g:PagingCookie"));

  var auditDetailsNode = Sdk.Xml.selectSingleNode(node, "g:AuditDetails");
  for (var i = 0; i < auditDetailsNode.childNodes.length; i++) {
   rv.add(Sdk.Util.createAuditDetailFromNode(auditDetailsNode.childNodes[i]));
  }

  return rv;
 }

 this.createAuditDetailFromNode = function (node) {
  if (!Sdk.Xml.isNodeNull(node)) {

   if (node.attributes.getNamedItem("i:type") == null) {
    var ad = new Sdk.AuditDetail();
    var auditRecord = Sdk.Util.createEntityFromNode(Sdk.Xml.selectSingleNode(node, "g:AuditRecord"));
    ad.setAuditRecord(auditRecord);
    return ad;
   }
   var type = node.attributes.getNamedItem("i:type").nodeValue.split(":")[1];
   switch (type) {
    case "AttributeAuditDetail":
     var aad = new Sdk.AttributeAuditDetail();
     var auditRecord = Sdk.Util.createEntityFromNode(Sdk.Xml.selectSingleNode(node, "g:AuditRecord"));
     aad.setAuditRecord(auditRecord);
     var _newValue = Sdk.Util.createEntityFromNode(Sdk.Xml.selectSingleNode(node, "g:NewValue"));
     aad.setNewValue(_newValue);
     var _oldValue = Sdk.Util.createEntityFromNode(Sdk.Xml.selectSingleNode(node, "g:OldValue"));
     aad.setOldValue(_oldValue);
     return aad;
     break;
    case "RelationshipAuditDetail":
     //TODO: Document this as an issue
     //This *should* work but I have no data for testing. Can't apply a change that makes this get logged in the Audit table.
     try {
      var rad = new Sdk.RelationshipAuditDetail();
      var auditRecord = Sdk.Util.createEntityFromNode(Sdk.Xml.selectSingleNode(node, "g:AuditRecord"));

      _relationshipName = Sdk.Xml.selectSingleNodeText(node, "g:RelationshipName");
      rad.setRelationshipName(_relationshipName);

      _targetRecordsNode = Sdk.Xml.selectSingleNode(node, "g:TargetRecords");
      _targetRecordsCollection = new Sdk.Collection(Sdk.EntityReference);
      for (var i = 0; i < _targetRecordsNode.childNodes.length; i++) {
       _targetRecordsCollection.add(Sdk.Util.createEntityReferenceFromNode(_targetRecordsNode.childNodes[i]));
      }
      rad.setTargetRecords(_targetRecordsCollection);
      return rad;
     }
     catch (e) {
      throw new Error("Sdk.Util.createAuditDetailFromNode not tested for RelationshipAuditDetail class.")
     }
     break;
    case "RolePrivilegeAuditDetail":
     var rpad = new Sdk.RolePrivilegeAuditDetail();
     var auditRecord = Sdk.Util.createEntityFromNode(Sdk.Xml.selectSingleNode(node, "g:AuditRecord"));
     rpad.setAuditRecord(auditRecord);

     var _newRolePrivilegesNode = Sdk.Xml.selectSingleNode(node, "g:NewRolePrivileges");
     var _newRolePrivilegesCollection = new Sdk.Collection(Sdk.RolePrivilege);
     for (var i = 0; i < _newRolePrivilegesNode.childNodes.length; i++) {
      if (!Sdk.Xml.isNodeNull(_newRolePrivilegesNode.childNodes[i])) {
       var depth = Sdk.Xml.selectSingleNodeText(_newRolePrivilegesNode.childNodes[i], "g:Depth");
       var privilegeId = Sdk.Xml.selectSingleNodeText(_newRolePrivilegesNode.childNodes[i], "g:PrivilegeId");
       var businessid = Sdk.Xml.selectSingleNodeText(_newRolePrivilegesNode.childNodes[i], "g:BusinessUnitId");
       _newRolePrivilegesCollection.add(new Sdk.RolePrivilege(depth, privilegeId, businessid));
      }
     }
     rpad.setNewRolePrivileges(_newRolePrivilegesCollection);

     var _oldRolePrivilegesNode = Sdk.Xml.selectSingleNode(node, "g:OldRolePrivileges");
     var _oldRolePrivilegesCollection = new Sdk.Collection(Sdk.RolePrivilege);
     for (var i = 0; i < _oldRolePrivilegesNode.childNodes.length; i++) {
      if (!Sdk.Xml.isNodeNull(_oldRolePrivilegesNode.childNodes[i])) {
       var depth = Sdk.Xml.selectSingleNodeText(_oldRolePrivilegesNode.childNodes[i], "g:Depth");
       var privilegeId = Sdk.Xml.selectSingleNodeText(_oldRolePrivilegesNode.childNodes[i], "g:PrivilegeId");
       var businessid = Sdk.Xml.selectSingleNodeText(_oldRolePrivilegesNode.childNodes[i], "g:BusinessUnitId");
       _oldRolePrivilegesCollection.add(new Sdk.RolePrivilege(depth, privilegeId, businessid));
      }
     }
     rpad.setOldRolePrivileges(_oldRolePrivilegesCollection);
     return rpad;


     break;
    case "ShareAuditDetail":
     var sad = new Sdk.ShareAuditDetail();
     var auditRecord = Sdk.Util.createEntityFromNode(Sdk.Xml.selectSingleNode(node, "g:AuditRecord"));
     sad.setAuditRecord(auditRecord);

     var _newPrivileges = Sdk.Xml.selectSingleNodeText(node, "g:NewPrivileges");
     sad.setNewPrivileges(_newPrivileges);

     var _oldPrivileges = Sdk.Xml.selectSingleNodeText(node, "g:OldPrivileges");
     sad.setOldPrivileges(_oldPrivileges);

     var _principal = Sdk.Util.createEntityReferenceFromNode(Sdk.Xml.selectSingleNode(node, "g:Principal"));
     sad.setPrincipal(_principal);
     return sad;
     break;
    default:
     throw new Error("RetrieveAuditDetailsResponse unexpected return value");
     break;
   }
  }
 }

 function createErrorInfoFromNode(node) {
  var rv = new Sdk.ErrorInfo()

  rv.setErrorCode(Sdk.Xml.selectSingleNodeText(node, "g:ErrorCode"));

  var rl = new Sdk.Collection(Sdk.ResourceInfo);
  var rlNode = Sdk.Xml.selectSingleNode(node, "g:ResourceList");
  for (var i = 0; i < rlNode.childNodes.length; i++) {
   rl.add(createResourceInfoFromNode(rlNode.childNodes[i]));
  }
  rv.setResourceList(rl);
  return rv;
 }

 function createResourceInfoFromNode(node) {
  var rv = new Sdk.ResourceInfo();

  rv.setDisplayName(Sdk.Xml.selectSingleNodeText(node, "g:DisplayName"));
  rv.setEntityName(Sdk.Xml.selectSingleNodeText(node, "g:EntityName"));
  rv.setId(Sdk.Xml.selectSingleNodeText(node, "g:Id"));

  return rv;
 }

 this.isCollectionOf = function (collection, type) {
  if (collection instanceof Sdk.Collection) {
   if (typeof type == "function") {
    if (collection.getType() == type)
    { return true; }
   }
   else {
    throw new Error("Sdk.Util.isCollectionOf type parameter must be a Function.");
   }
  }
  else {
   throw new Error("Sdk.Util.isCollectionOf collection parameter must be an Sdk.Collection.");
  }
  return false;
 }

}).call(Sdk.Util);

(function ()
{
 
 //Sdk.Query.ConditionExpression START
 this.ConditionExpression = function (entityName, attributeName, operator, values) {
  ///<summary>
  /// Contains a condition expression used to filter the results of the query.
  ///</summary>
  ///<param name="entityName" type="String" optional="false" mayBeNull="true">
  /// The logical name of the entity in the condition expression.
  ///</param>
  ///<param name="attributeName" type="String" optional="false" mayBeNull="false">
  /// The logical name of the attribute in the condition expression.
  ///</param>
  ///<param name="operator" type="Sdk.Query.ConditionOperator" optional="false" mayBeNull="false">
  /// The condition operator.
  ///</param>
  ///<param name="values" type="Sdk.Query.ValueBase" optional="true" mayBeNull="true">
  /// <para>The value(s) to compare</para>
  /// <para>Use one of the following classes that inherit from Sdk.Query.ValueBase: </para>
  /// <para> - Sdk.Query.Booleans </para>
  /// <para> - Sdk.Query.BooleanManagedProperties </para>
  /// <para> - Sdk.Query.Dates </para>
  /// <para> - Sdk.Query.Decimals </para>
  /// <para> - Sdk.Query.Doubles </para>
  /// <para> - Sdk.Query.EntityReferences </para>
  /// <para> - Sdk.Query.Guids </para>
  /// <para> - Sdk.Query.Ints </para>
  /// <para> - Sdk.Query.Longs </para>
  /// <para> - Sdk.Query.Money </para>
  /// <para> - Sdk.Query.OptionSets </para>
  /// <para> - Sdk.Query.Strings </para>
  ///</param>


  if (!(this instanceof Sdk.Query.ConditionExpression)) {
   return new Sdk.Query.ConditionExpression(entityName, attributeName, operator, values);
  }

  // inner property
  var _entityName = null;
  var _attributeName = null;
  var _attributeValueType = null;
  var _operator = null;
  var _values = null;


  //internal setter functions
  function _setValidEntityName(value) {
   if (typeof value == "string" || value == null) {
    _entityName = value;
   }
   else {
    throw new Error("Sdk.Query.ConditionExpression EntityName property must be a String or null");
   }
  }

  function _setValidAttributeName(value) {
   if (typeof value == "string") {
    _attributeName = value;
   }
   else {
    throw new Error("Sdk.Query.ConditionExpression AttributeName property is required and must be a String");
   }
  }

  function _setValidOperator(value) {
   if (Sdk.Util.isValidEnumValue(Sdk.Query.ConditionOperator, value)) {
    _operator = value;
    switch (_operator) {
     //The values are not used, so clear out what might be there
     case "Null":
     case "NotNull":
     case "EqualUserLanguage":
     case "Yesterday":
     case "Today":
     case "Tomorrow":
     case "Last7Days":
     case "Next7Days":
     case "LastWeek":
     case "ThisWeek":
     case "NextWeek":
     case "LastMonth":
     case "ThisMonth":
     case "NextMonth":
     case "LastYear":
     case "ThisYear":
     case "NextYear":
     case "ThisFiscalYear":
     case "ThisFiscalPeriod":
     case "NextFiscalYear":
     case "NextFiscalPeriod":
     case "LastFiscalYear":
     case "LastFiscalPeriod":
      _values = null;
      break;
     default:
      break;
    }
   }
   else {
    throw new Error("Sdk.Query.ConditionExpression operator property must be an Sdk.Query.ConditionOperator");
   }
  }

  function _setValidValues(value) {
   if (value instanceof Sdk.Query.ValueBase || value == null) {
    _values = value;
   }
   else {
    throw new Error("Sdk.Query.ConditionExpression Values property must inherit from Sdk.Query.ValueBase");
   }
  }

  //Set internal properties from constructor parameters - START
  if (typeof entityName != "undefined" || entityName != null) {
   _setValidEntityName(entityName);
  }

  if (typeof attributeName != "undefined" || attributeName != null) {
   _setValidAttributeName(attributeName);
  }

  if (typeof operator != "undefined" || operator != null) {
   _setValidOperator(operator);
  }
  if (typeof values != "undefined") {
   _setValidValues(values);
  }

  //Set internal properties from constructor parameters - END



  //public methods

  this.getEntityName = function () {
   ///<summary>
   /// Gets the logical name of the entity in the condition expression.
   ///</summary>
   ///<returns type="String">
   /// The logical name of the entity in the condition expression.
   ///</returns>
   return _entityName;
  };
  this.setEntityName = function (name) {
   ///<summary>
   /// Sets the logical name of the entity in the condition expression.
   ///</summary>
   ///<param name="name" type="String" mayBeNull="true">
   /// The logical name of the entity in the condition expression.
   ///</param>
   _setValidEntityName(name);
  };

  this.getAttributeName = function () {
   ///<summary>
   /// Gets the logical name of the attribute in the condition expression.
   ///</summary>
   ///<returns type="String">
   /// The logical name of the attribute in the condition expression.
   ///</returns>
   return _attributeName;
  };
  this.setAttributeName = function (name) {
   ///<summary>
   /// Sets the logical name of the attribute in the condition expression.
   ///</summary>
   ///<param name="name" type="String" mayBeNull="false">
   /// The logical name of the attribute in the condition expression.
   ///</param>
   _setValidAttributeName(name);
  };

  this.getOperator = function () {
   ///<summary>
   /// Gets the condition operator.
   ///</summary>
   ///<returns type="Sdk.Query.ConditionOperator">
   /// The condition operator.
   ///</returns>
   return _operator;
  };
  this.setOperator = function (operator) {
   ///<summary>
   /// Sets the condition operator.
   ///</summary>
   ///<param name="operator" type="Sdk.Query.ConditionOperator" mayBeNull="false">
   /// The condition operator.
   ///</param>
   _setValidOperator(operator);
  };

  this.getValues = function () {
   ///<summary>
   /// Gets the values for the attribute.
   ///</summary>
   ///<returns type="Sdk.Query.ValueBase">
   /// The value(s) for the attribute.
   ///</returns>
   return _values;
  };
  this.setValues = function (values) {
   ///<summary>
   /// Sets the values for the attribute.
   ///</summary>
   ///<param name="values" type="Sdk.Query.ValueBase">
   /// <para>The value(s) to compare</para>
   /// <para>Use one of the following classes that inherit from Sdk.Query.ValueBase: </para>
   /// <para> - Sdk.Query.Booleans </para>
   /// <para> - Sdk.Query.BooleanManagedProperties </para>
   /// <para> - Sdk.Query.Dates </para>
   /// <para> - Sdk.Query.Decimals </para>
   /// <para> - Sdk.Query.Doubles </para>
   /// <para> - Sdk.Query.EntityReferences </para>
   /// <para> - Sdk.Query.Guids </para>
   /// <para> - Sdk.Query.Ints </para>
   /// <para> - Sdk.Query.Longs </para>
   /// <para> - Sdk.Query.Money </para>
   /// <para> - Sdk.Query.OptionSets </para>
   /// <para> - Sdk.Query.Strings </para>
   ///</param>
   _setValidValues(values);
  };
 };
 this.ConditionExpression.__class = true;
 //Sdk.Query.ConditionExpression END
 //--------------------------------------------------------------------
 //Sdk.Query.ConditionOperator START
 this.ConditionOperator = function () {
  /// <summary>Sdk.Query.ConditionOperator enum summary</summary>
  /// <field name="Equal" type="String" static="true">The values are compared for equality</field>
  /// <field name="NotEqual" type="String" static="true">The two values are not equal</field>
  /// <field name="GreaterThan" type="String" static="true">The value is greater than the compared value</field>
  /// <field name="LessThan" type="String" static="true">The value is less than the compared value</field>
  /// <field name="GreaterEqual" type="String" static="true">The value is greater than or equal to the compared value.</field>
  /// <field name="LessEqual" type="String" static="true">The value is less than or equal to the compared value. </field>
  /// <field name="Like" type="String" static="true">The character string is matched to the specified pattern.</field>
  /// <field name="NotLike" type="String" static="true">The character string does not match the specified pattern.</field>
  /// <field name="In" type="String" static="true">The value exists in a list of values. </field>
  /// <field name="NotIn" type="String" static="true">The given value is not matched to a value in a subquery or a list.</field>
  /// <field name="Between" type="String" static="true">The value is between two values. </field>
  /// <field name="NotBetween" type="String" static="true">The value is not between two values.</field>
  /// <field name="Null" type="String" static="true">The value is null. </field>
  /// <field name="NotNull" type="String" static="true">The value is not null. </field>
  /// <field name="Yesterday" type="String" static="true">The value equals yesterday’s date.</field>
  /// <field name="Today" type="String" static="true">The value equals today’s date.</field>
  /// <field name="Tomorrow" type="String" static="true">The value equals tomorrow’s date.</field>
  /// <field name="Last7Days" type="String" static="true">The value is within the last seven days including today.</field>
  /// <field name="Next7Days" type="String" static="true">The value is within the next seven days.</field>
  /// <field name="LastWeek" type="String" static="true">The value is within the previous week including Sunday through Saturday.</field>
  /// <field name="ThisWeek" type="String" static="true">The value is within the current week.</field>
  /// <field name="NextWeek" type="String" static="true">The value is within the next week.</field>
  /// <field name="LastMonth" type="String" static="true">The value is within the last month including first day of the last month and last day of the last month.</field>
  /// <field name="ThisMonth" type="String" static="true">The value is within the current month.</field>
  /// <field name="NextMonth" type="String" static="true">The value is within the next month.</field>
  /// <field name="On" type="String" static="true">The value is on a specified date. </field>
  /// <field name="OnOrBefore" type="String" static="true">The value is on or before a specified date.</field>
  /// <field name="OnOrAfter" type="String" static="true">The value is on or after a specified date.</field>
  /// <field name="LastYear" type="String" static="true">The value is within the previous year. </field>
  /// <field name="ThisYear" type="String" static="true">The value is within the current year.</field>
  /// <field name="NextYear" type="String" static="true">The value is within the next year.</field>
  /// <field name="LastXHours" type="String" static="true">The value is within the last X (specified value) hours.</field>
  /// <field name="NextXHours" type="String" static="true">The value is within the next X (specified value) hours.</field>
  /// <field name="LastXDays" type="String" static="true">The value is within last X days.</field>
  /// <field name="NextXDays" type="String" static="true">The value is within the next X (specified value) days.</field>
  /// <field name="LastXWeeks" type="String" static="true">The value is within the last X (specified value) weeks. </field>
  /// <field name="NextXWeeks" type="String" static="true">The value is within the next X weeks.</field>
  /// <field name="LastXMonths" type="String" static="true">The value is within the last X months.</field>
  /// <field name="NextXMonths" type="String" static="true">The value is within the next X months.</field>
  /// <field name="LastXYears" type="String" static="true">The value is within the last X years.</field>
  /// <field name="NextXYears" type="String" static="true">The value is within the next X years.</field>
  /// <field name="EqualUserId" type="String" static="true">The value is equal to the specified user ID</field>
  /// <field name="NotEqualUserId" type="String" static="true">The value is not equal to the specified user ID</field>
  /// <field name="EqualBusinessId" type="String" static="true">The value is equal to the specified business ID</field>
  /// <field name="NotEqualBusinessId" type="String" static="true">The value is not equal to the specified business ID</field>
  /// <field name="Mask" type="String" static="true">The value is found in the specified bit-mask value</field>
  /// <field name="NotMask" type="String" static="true">The value is not found in the specified bit-mask value</field>
  /// <field name="Contains" type="String" static="true">The string contains another string</field>
  /// <field name="DoesNotContain" type="String" static="true">The string does not contain another string</field>
  /// <field name="EqualUserLanguage" type="String" static="true">The value is equal to the language for the user</field>
  /// <field name="NotOn" type="String" static="true">The value is not on the specified date</field>
  /// <field name="OlderThanXMonths" type="String" static="true">The value is older than the specified number of months</field>
  /// <field name="BeginsWith" type="String" static="true">The string occurs at the beginning of another string</field>
  /// <field name="DoesNotBeginWith" type="String" static="true">The string does not begin with another string</field>
  /// <field name="EndsWith" type="String" static="true">The string ends with another string</field>
  /// <field name="DoesNotEndWith" type="String" static="true">The string does not end with another string</field>
  /// <field name="ThisFiscalYear" type="String" static="true">The value is within the current fiscal year</field>
  /// <field name="ThisFiscalPeriod" type="String" static="true">The value is within the current fiscal period</field>
  /// <field name="NextFiscalYear" type="String" static="true">The value is within the next fiscal year</field>
  /// <field name="NextFiscalPeriod" type="String" static="true">The value is within the next fiscal period</field>
  /// <field name="LastFiscalYear" type="String" static="true">The value is within the last fiscal year</field>
  /// <field name="LastFiscalPeriod" type="String" static="true">The value is within the last fiscal period</field>
  /// <field name="LastXFiscalYears" type="String" static="true">The value is within the last X (specified value) fiscal years</field>
  /// <field name="LastXFiscalPeriods" type="String" static="true">The value is within the last X (specified value) fiscal periods</field>
  /// <field name="NextXFiscalYears" type="String" static="true">The value is within the next X (specified value) fiscal years</field>
  /// <field name="NextXFiscalPeriods" type="String" static="true">The value is within the next X (specified value) fiscal periods</field>
  /// <field name="InFiscalYear" type="String" static="true">The value is within the specified year</field>
  /// <field name="InFiscalPeriod" type="String" static="true">The value is within the specified period</field>
  /// <field name="InFiscalPeriodAndYear" type="String" static="true">The value is within the specified fiscal period and year</field>
  /// <field name="InOrBeforeFiscalPeriodAndYear" type="String" static="true">The value is within or before the specified fiscal period and year</field>
  /// <field name="InOrAfterFiscalPeriodAndYear" type="String" static="true">The value is within or after the specified fiscal period and year</field>
  /// <field name="EqualUserOrUserTeams" type="String" static="true">The record is owned by a user or teams that the user is a member of.</field>
  /// <field name="EqualUserTeams" type="String" static="true">The record is owned by teams that the user is a member of</field>

  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.Query.ConditionOperator END
 //--------------------------------------------------------------------
 //Sdk.Query.FetchExpression START
 this.FetchExpression = function (fetchXml) {
  ///<summary>
  /// Specifies the FetchXml to be used in a query. 
  ///</summary>
  ///<param name="fetchXml" type="String">
  /// The fetchXml
  ///</param>

  if (!(this instanceof Sdk.Query.FetchExpression)) {
   return new Sdk.Query.FetchExpression(fetchXml);
  }
  Sdk.Query.QueryBase.call(this, "FetchExpression");
  // inner properties
  var _fetchXml;


  //internal setter functions START
  function _setValidFetchXml(value) {
   if (typeof value == "string") {
    _fetchXml = value;
   }
   else {
    throw new Error("Sdk.Query.FetchExpression FetchXml property is required and must be a String.");
   }
  }
  //internal setter functions END

  //Set internal properties from constructor parameters
  _setValidFetchXml(fetchXml);

  //this.setQueryType("FetchExpression");

  //public methods
  this.getFetchXml = function () {
   ///<summary>
   /// Gets the FetchXml to be used in a query. 
   ///</summary>
   ///<returns type="String">
   /// The FetchXml to be used in a query. 
   ///</returns>
   return _fetchXml;
  }
  this.setFetchXml = function (fetchXml) {
   ///<summary>
   /// Sets the FetchXml to be used in a query. 
   ///</summary>
   ///<param name="fetchXml" type="String">
   /// The FetchXml to be used in a query. 
   ///</param>
   _setValidFetchXml(fetchXml);
  }


 };
 this.FetchExpression.__class = true;
 //Sdk.Query.FetchExpression END
 //--------------------------------------------------------------------
 //Sdk.Query.FilterExpression START
 this.FilterExpression = function (logicalOperator) {
  ///<summary>
  /// Specifies complex condition and logical filter expressions used for filtering the results of the query. 
  ///</summary>
  ///<param name="logicalOperator" type="Sdk.Query.LogicalOperator">
  /// The filter operator.
  ///</param>

  if (!(this instanceof Sdk.Query.FilterExpression)) {
   return new Sdk.Query.FilterExpression(logicalOperator);
  }

  // inner properties
  var _conditions = new Sdk.Collection(Sdk.Query.ConditionExpression);
  var _filterOperator = Sdk.Query.LogicalOperator.And; //Default value
  var _filters = new Sdk.Collection(Sdk.Query.FilterExpression);
  var _isQuickfindFilter = false;




  //internal setter functions START
  function _setValidCondition(value) {
   if (value instanceof Sdk.Query.ConditionExpression) {
    _conditions.add(value);
   }
   else {
    throw new Error("An Sdk.Query.FilterExpression condition must be an Sdk.Query.ConditionExpression");
   }
  }
  function _setValidFilterOperator(value) {
   if (Sdk.Query.LogicalOperator.And == value || Sdk.Query.LogicalOperator.Or == value)
   { _filterOperator = value; }
   else
   {
    throw new Error("An Sdk.Query.FilterExpression condition must be an Sdk.Query.LogicalOperator");
   }
  }
  function _setValidFilter(value) {
   if (value instanceof Sdk.Query.FilterExpression) {
    _filters.add(value);
   }
   else {
    throw new Error("An Sdk.Query.FilterExpression filter must be an Sdk.Query.FilterExpression");
   }
  }
  function _setValidIsQuickfindFilter(value) {
   if (typeof value == "boolean")
   { _isQuickfindFilter = value; }
   else
   {
    throw new Error("An Sdk.Query.FilterExpression IsQuickfindFilter must be an Boolean Value");
   }
  }
  //internal setter functions END

  //Set internal properties from constructor parameters
  if (typeof logicalOperator != "undefined" || logicalOperator != null) {
   _setValidFilterOperator(logicalOperator);

  }

  //public methods
  this.addCondition = function (firstParam, attributeName, conditionOperator, values) {
   ///<summary>
   /// Adds a condition to the filter expression setting the attribute name, condition operator, and values.
   ///</summary>
   ///<param name="firstParam" type="Object">
   /// If Sdk.Query.ConditionExpression, will set the condition. If string it is the entityName and a new ConditionExpression will be instantiated using the other parameters.
   ///</param>
   ///<param name="attributeName" type="String">
   /// The attribute name to use in the condition expression
   ///</param>
   ///<param name="conditionOperator" type="Sdk.Query.ConditionOperator">
   /// The condition operator if the first parameter is a string
   ///</param>
   ///<param name="values" type="Sdk.Query.ValueBase" optional="true" mayBeNull="true">
   /// <para>The value(s) to compare</para>
   /// <para>Use one of the following classes that inherit from Sdk.Query.ValueBase: </para>
   /// <para> - Sdk.Query.Booleans </para>
   /// <para> - Sdk.Query.BooleanManagedProperties </para>
   /// <para> - Sdk.Query.Dates </para>
   /// <para> - Sdk.Query.Decimals </para>
   /// <para> - Sdk.Query.Doubles </para>
   /// <para> - Sdk.Query.EntityReferences </para>
   /// <para> - Sdk.Query.Guids </para>
   /// <para> - Sdk.Query.Ints </para>
   /// <para> - Sdk.Query.Longs </para>
   /// <para> - Sdk.Query.Money </para>
   /// <para> - Sdk.Query.OptionSets </para>
   /// <para> - Sdk.Query.Strings </para>
   ///</param>
   if (firstParam instanceof Sdk.Query.ConditionExpression) {
    _setValidCondition(firstParam);
   }
   else {
    _setValidCondition(new Sdk.Query.ConditionExpression(firstParam, attributeName, conditionOperator, values));
   }

  };
  this.addFilter = function (filter) {
   ///<summary>
   /// Adds a child filter to the filter expression. 
   ///</summary>
   ///<param name="filter" type="Object">
   /// if Sdk.Query.FilterExpression, adds filter. If Sdk.Query.LogicalOperator, creates new FilterExpression and adds it
   ///</param>
   if (filter instanceof Sdk.Query.FilterExpression) {
    _setValidFilter(filter);
   }
   else {
    if (filter == Sdk.Query.LogicalOperator.And || filter == Sdk.Query.LogicalOperator.Or) {
     _setValidFilter(new Sdk.Query.FilterExpression(filter));
    }
    else {
     throw new Error("An Sdk.Query.FilterExpression addFilter method parameter must be an  must be an Sdk.Query.FilterExpression or an Sdk.Query.LogicalOperator");
    }
   }

  };
  this.getConditions = function () {
   ///<summary>
   /// Gets a collection of Sdk.Query.ConditionExpression values
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// A collection of Sdk.Query.ConditionExpression values
   ///</returns>
   return _conditions;
  };
  this.getFilterOperator = function () {
   ///<summary>
   /// Gets the logical AND/OR filter operator. 
   ///</summary>
   ///<returns type="Sdk.Query.LogicalOperator">
   /// The filter operator
   /// </returns>

   return _filterOperator;
  }
  this.getFilters = function () {
   ///<summary>
   /// Gets an Sdk.Collection of Sdk.Query.FilterExpression 
   ///</summary>
   /// <returns type="Sdk.Collection">
   /// An Sdk.Collection of Sdk.Query.FilterExpression 
   /// </returns>
   return _filters;
  };
  this.getIsQuickFindFilter = function () {
   ///<summary>
   /// Gets whether the expression is part of a quick find query. 
   ///</summary>
   /// <returns type="Boolean">
   /// Whether the expression is part of a quick find query. 
   /// </returns>

   return _isQuickfindFilter;
  }
  this.setFilterOperator = function (filterOperator) {
   ///<summary>
   /// Sets the filter operator. 
   ///</summary>
   ///<param name="filterOperator" type="Sdk.Query.LogicalOperator">
   /// The filter operator. 
   ///</param>		
   _setValidFilterOperator(filterOperator);
  }
  this.setIsQuickFindFilter = function (isQuickFind) {
   ///<summary>
   /// Sets whether the expression is part of a quick find query. 
   ///</summary>
   ///<param name="isQuickFind" type="Boolean">
   /// true if the filter is part of a quick find query; otherwise, false. 
   ///</param>
   _setValidIsQuickfindFilter(isQuickFind);
  }


 };
 this.FilterExpression.__class = true;
 //Sdk.Query.FilterExpression END
 //--------------------------------------------------------------------
 //Sdk.Query.JoinOperator START
 this.JoinOperator = function () {
  /// <summary>Sdk.Query.JoinOperator enum summary</summary>
  /// <field name="Inner" type="String" static="true">The values in the attributes being joined are compared using a comparison operator</field>
  /// <field name="LeftOuter" type="String" static="true">All instances of the entity in the FROM clause are returned if they meet WHERE or HAVING search conditions.</field>
  /// <field name="Natural" type="String" static="true">Only one value of the two joined attributes is returned if an equal-join operation is performed and the two values are identical.</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.Query.JoinOperator END
 //--------------------------------------------------------------------
 //Sdk.Query.LinkEntity START
 this.LinkEntity = function (linkFromEntityName, linkToEntityName, linkFromAttributeName, linkToAttributeName, joinOperator, entityAlias) {
  ///<summary>
  /// Initializes a new instance of the Sdk.Query.LinkEntity class setting the required properties. 
  ///</summary>
  ///<param name="linkFromEntityName" type="String">
  /// The logical name of the entity to link from.
  ///</param>
  ///<param name="linkToEntityName" type="String">
  /// The logical name of the entity to link to.
  ///</param>
  ///<param name="linkFromAttributeName" type="String">
  /// The name of the attribute to link from.
  ///</param>
  ///<param name="linkToAttributeName" type="String">
  /// The name of the attribute to link to.
  ///</param>
  ///<param name="joinOperator" type="Sdk.Query.JoinOperator">
  /// The join operator.
  ///</param>
  ///<param name="entityAlias" type="String">
  /// The string representing an alias for the linkToEntityName
  ///</param>

  if (!(this instanceof Sdk.Query.LinkEntity)) {
   return new Sdk.Query.LinkEntity(linkFromEntityName, linkToEntityName, linkFromAttributeName, linkToAttributeName, joinOperator, entityAlias);
  }

  // internal properties
  var _columns = new Sdk.ColumnSet();
  var _entityAlias = null;
  var _joinOperator = null;
  var _linkCriteria = null;
  var _linkEntities = new Sdk.Collection(Sdk.Query.LinkEntity);
  var _linkFromAttributeName = null;
  var _linkFromEntityName = null;
  var _linkToAttributeName = null;
  var _linkToEntityName = null;



  //internal setter functions
  function _setValidColumns(value) {
   if (value instanceof Sdk.ColumnSet) {
    _columns = value;
   }
   else {
    throw new Error("Sdk.Query.LinkEntity Columns property must be an Sdk.ColumnSet");
   }
  }
  function _setValidEntityAlias(value) {
   if (typeof value == "string") {
    _entityAlias = value;
   }
   else {
    throw new Error("Sdk.Query.LinkEntity EntityAlias property must be an String");
   }
  }
  function _setValidJoinOperator(value) {
   if (value == Sdk.Query.JoinOperator.Inner || value == Sdk.Query.JoinOperator.LeftOuter || value == Sdk.Query.JoinOperator.Natural) {
    _joinOperator = value;
   }
   else {
    throw new Error("Sdk.Query.LinkEntity JoinOperator  property must be an Sdk.Query.JoinOperator value");
   }
  }
  function _setValidLinkCriteria(value) {
   if (value instanceof Sdk.Query.FilterExpression) {
    _linkCriteria = value;
   }
   else {
    throw new Error("Sdk.Query.LinkEntity LinkCriteria property must be an Sdk.Query.FilterExpression");
   }
  }
  function _setValidLinkFromAttributeName(value) {
   if (typeof value == "string") {
    _linkFromAttributeName = value;
   }
   else {
    throw new Error("Sdk.Query.LinkEntity LinkFromAttributeName property must be an String");
   }
  }
  function _setValidLinkFromEntityName(value) {
   if (typeof value == "string") {
    _linkFromEntityName = value;
   }
   else {
    throw new Error("Sdk.Query.LinkEntity LinkFromEntityName property must be an String");
   }
  }
  function _setValidLinkToAttributeName(value) {
   if (typeof value == "string") {
    _linkToAttributeName = value;
   }
   else {
    throw new Error("Sdk.Query.LinkEntity LinkToAttributeName property must be an String");
   }
  }
  function _setValidLinkToEntityName(value) {
   if (typeof value == "string") {
    _linkToEntityName = value;
   }
   else {
    throw new Error("Sdk.Query.LinkEntity LinkToEntityName property must be an String");
   }
  }



  //Set internal properties from constructor parameters
  if (typeof linkFromEntityName != "undefined" || linkFromEntityName != null) {
   _setValidLinkFromEntityName(linkFromEntityName);
  }
  if (typeof linkToEntityName != "undefined" || linkToEntityName != null) {
   _setValidLinkToEntityName(linkToEntityName);
  }
  if (typeof linkFromAttributeName != "undefined" || linkFromAttributeName != null) {
   _setValidLinkFromAttributeName(linkFromAttributeName);
  }
  if (typeof linkToAttributeName != "undefined" || linkToAttributeName != null) {
   _setValidLinkToAttributeName(linkToAttributeName);
  }
  if (typeof joinOperator != "undefined" || joinOperator != null) {
   _setValidJoinOperator(joinOperator);
  }
  if (typeof entityAlias != "undefined" || entityAlias != null) {
   _setValidEntityAlias(entityAlias);
  }


  //public methods
  this.addLink = function (linkEntity) {
   ///<summary>
   /// Adds a linked entity
   ///</summary>
   ///<param name="linkEntity" type="Sdk.Query.LinkEntity">
   /// An Sdk.Query.LinkEntity to add;
   ///</param>
   this.getLinkEntities().add(linkEntity);
  };

  this.getColumns = function () {
   ///<summary>
   /// Gets the column set. 
   ///</summary>
   ///<returns type="Sdk.ColumnSet">
   /// The column set. 
   /// </returns>
   return _columns;
  };
  this.setColumns = function (columns) {
   ///<summary>
   /// Sets the columns to include.
   ///</summary>
   ///<param name="columns" type="Object">
   /// <para>Three Options</para>
   /// <para> An Sdk.ColumnSet instance</para>
   /// <para> An Array of attribute logical names for the columns to return.</para>
   /// <para> Pass each attribute logical name as an argument</para>
   ///</param>
   if (columns instanceof Sdk.ColumnSet) {
    _setValidColumns(columns);
   }
   else {
    if (typeof columns != "undefined" && typeof columns.push != "undefined") {
     _setValidColumns(new Sdk.ColumnSet(columns));
    }
    else {
     if (arguments.length > 0) {
      var attributes = [];
      for (var i = 0; i < arguments.length; i++) {
       if (typeof arguments[i] == "string") {
        attributes.push(arguments[i]);
       }
      }
      _setValidColumns(new Sdk.ColumnSet(attributes));
     }
    }
   }
  };

  this.getEntityAlias = function () {
   ///<summary>
   /// Gets the alias for the entity. 
   ///</summary>
   ///<returns type="String">
   /// The alias for the entity. 
   /// </returns>
   return _entityAlias;
  };
  this.setEntityAlias = function (alias) {
   ///<summary>
   /// Sets the alias for the entity. 
   ///</summary>
   ///<param name="alias" type="String">
   /// The alias for the entity. 
   ///</param>
   _setValidEntityAlias(alias);
  };

  this.getJoinOperator = function () {
   ///<summary>
   /// Gets the join operator. 
   ///</summary>
   ///<returns type="Sdk.Query.JoinOperator">
   /// The join operator.
   /// </returns>
   return _joinOperator;
  };
  this.setJoinOperator = function (operator) {
   ///<summary>
   /// Sets the join operator. 
   ///</summary>
   ///<param name="operator" type="Sdk.Query.JoinOperator">
   /// The join operator. 
   ///</param>
   _setValidJoinOperator(operator);
  };

  this.getLinkCriteria = function () {
   ///<summary>
   /// Gets the complex condition and logical filter expressions that filter the results of the query. 
   ///</summary>
   ///<returns type="Sdk.Query.FilterExpression">
   /// The complex condition and logical filter expressions that filter the results of the query. 
   /// </returns>
   return _linkCriteria;
  };
  this.setLinkCriteria = function (criteria) {
   ///<summary>
   /// Sets the complex condition and logical filter expressions that filter the results of the query. 
   ///</summary>
   ///<param name="criteria" type="Sdk.Query.FilterExpression">
   /// The complex condition and logical filter expressions that filter the results of the query. 
   ///</param>
   _setValidLinkCriteria(criteria);
  };

  this.getLinkEntities = function () {
   ///<summary>
   /// Gets the collection of Sdk.Query.LinkEntity that define links between multiple entity types.
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// The  collection of Sdk.Query.LinkEntity that define links between multiple entity types.
   /// </returns>
   return _linkEntities;
  };

  this.getLinkFromAttributeName = function () {
   ///<summary>
   /// Gets the logical name of the attribute of the entity that you are linking from. 
   ///</summary>
   ///<returns type="String">
   /// The logical name of the attribute of the entity that you are linking from. 
   /// </returns>
   return _linkFromAttributeName;
  };
  this.setLinkFromAttributeName = function (name) {
   ///<summary>
   /// Sets the logical name of the attribute of the entity that you are linking from. 
   ///</summary>
   ///<param name="name" type="String">
   /// The logical name of the attribute of the entity that you are linking from. 
   ///</param>
   _setValidLinkFromAttributeName(name);
  };

  this.getLinkFromEntityName = function () {
   ///<summary>
   /// Gets the logical name of the entity that you are linking from. 
   ///</summary>
   ///<returns type="String">
   /// The the logical name of the entity that you are linking from. 
   /// </returns>
   return _linkFromEntityName;
  };
  this.setLinkFromEntityName = function (name) {
   ///<summary>
   /// Sets the logical name of the entity that you are linking from. 
   ///</summary>
   ///<param name="name" type="String">
   /// The logical name of the entity that you are linking from. 
   ///</param>
   _setValidLinkFromEntityName(name);
  };

  this.getLinkToAttributeName = function () {
   ///<summary>
   /// Gets the logical name of the attribute of the entity that you are linking to. 
   ///</summary>
   ///<returns type="String">
   /// The logical name of the attribute of the entity that you are linking to. 
   /// </returns>
   return _linkToAttributeName;
  };
  this.setLinkToAttributeName = function (name) {
   ///<summary>
   /// Sets the logical name of the attribute of the entity that you are linking to. 
   ///</summary>
   ///<param name="name" type="String">
   /// The logical name of the attribute of the entity that you are linking to. 
   ///</param>
   _setValidLinkToAttributeName(name);
  };

  this.getLinkToEntityName = function () {
   ///<summary>
   /// Gets the logical name of the entity that you are linking to. 
   ///</summary>
   ///<returns type="String">
   /// The logical name of the entity that you are linking to. 
   /// </returns>
   return _linkToEntityName;
  };
  this.setLinkToEntityName = function (name) {
   ///<summary>
   /// Sets the logical name of the entity that you are linking to. 
   ///</summary>
   ///<param name="name" type="String">
   /// The logical name of the entity that you are linking to. 
   ///</param>
   _setValidLinkToEntityName(name);
  };

 };
 this.LinkEntity.__class = true;
 //Sdk.Query.LinkEntity END
 //--------------------------------------------------------------------
 //Sdk.Query.LogicalOperator START
 this.LogicalOperator = function () {
  /// <summary>Sdk.Query.LogicalOperator enum summary</summary>
  /// <field name="And" type="String" static="true">A logical AND operation is performed</field>
  /// <field name="Or" type="String" static="true">A logical OR operation is performed</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };

 //Sdk.Query.LogicalOperator END
 //--------------------------------------------------------------------
 //Sdk.Query.OrderExpression START
 this.OrderExpression = function (attributeName, orderType) {
  ///<summary>
  /// Initializes a new instance of the OrderExpression class setting the attribute name and the order type. 
  ///</summary>
  ///<param name="attributeName" type="String">
  /// The name of the attribute.
  ///</param>
  ///<param name="orderType" type="Sdk.Query.OrderType" optional="true">
  /// The order, ascending or descending. Ascending is the default if not specified.
  ///</param>

  if (!(this instanceof Sdk.Query.OrderExpression)) {
   return new Sdk.Query.OrderExpression(attributeName, orderType);
  }

  // inner properties
  var _attributeName = null;
  var _orderType = Sdk.Query.OrderType.Ascending; //default





  //internal setter function
  function _setValidAttributeName(value) {
   if (typeof value == "string") {
    _attributeName = value;
   }
   else {
    throw new Error("Sdk.Query.OrderExpression AttributeName property must be an String");
   }
  }

  function _setValidOrderType(value) {
   if (value == Sdk.Query.OrderType.Ascending || value == Sdk.Query.OrderType.Descending) {
    _orderType = value;
   }
   else {
    throw new Error("Sdk.Query.OrderExpression OrderType property must be an Sdk.Query.OrderType");
   }
  }



  //Set internal properties from constructor parameters
  if ((typeof attributeName != "undefined" || attributeName != null) && (typeof orderType != "undefined" || orderType != null)) {
   try {
    _setValidAttributeName(attributeName);
    _setValidOrderType(orderType);
   }
   catch (e)
   { throw e; }
  }
  else {
   if (typeof attributeName != "undefined" || attributeName != null) {
    _setValidAttributeName(attributeName);
    //Accept the default Ascending value
   }
  }

  //public methods
  this.getAttributeName = function () {
   ///<summary>
   /// Gets the logical name of the attribute to order by
   ///</summary>
   ///<returns type="String">
   /// The logical name of the attribute to order by
   ///</returns>

   return _attributeName;
  };
  this.setAttributeName = function (name) {
   ///<summary>
   /// Sets the logical name of the attribute to order by
   ///</summary>
   ///<param name="name" type="String">
   ///  The logical name of the attribute to order by
   ///</param>
   _setValidAttributeName(name);
  };

  this.getOrderType = function () {
   ///<summary>
   /// Gets the order type
   ///</summary>
   ///<returns type="Sdk.Query.OrderType">
   /// The order type
   ///</returns>

   return _orderType;
  };
  this.setOrderType = function (type) {
   ///<summary>
   /// Sets the order type
   ///</summary>
   ///<param name="type" type="Sdk.Query.OrderType">
   /// The order type
   ///</param>
   _setValidOrderType(type)
  };


 };
 this.OrderExpression.__class = true;

 this.OrderType = function () {
  /// <summary>Sdk.Query.OrderType  enum summary</summary>
  /// <field name="Ascending" type="String" static="true">The values of the specified attribute should be sorted in ascending order, from lowest to highest. </field>
  /// <field name="Descending" type="String" static="true">The values of the specified attribute should be sorted in descending order, from highest to lowest</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.Query.OrderExpression END
 //--------------------------------------------------------------------
 //Sdk.Query.PagingInfo START
 this.PagingInfo = function () {
  ///<summary>
  /// Initializes a new instance of the PagingInfo class. 
  ///</summary>

  if (!(this instanceof Sdk.Query.PagingInfo)) {
   return new Sdk.Query.PagingInfo();
  }

  // inner properties
  var _count = 0;
  var _pageNumber = 0;
  var _pagingCookie = null;
  var _returnTotalRecordCount = false;


  //internal setter function
  function _setValidCount(value) {
   if (typeof value == "number") {
    _count = value;
   }
   else {
    throw new Error("Sdk.Query.PagingInfo Count property must be an Number");
   }
  }

  function _setValidPageNumber(value) {
   if (typeof value == "number") {
    _pageNumber = value;
   }
   else {
    throw new Error("Sdk.Query.PagingInfo PageNumber property must be an Number");
   }
  }

  function _setValidPagingCookie(value) {
   if (typeof value == "string") {
    _pagingCookie = value;
   }
   else {
    throw new Error("Sdk.Query.PagingInfo PagingCookie property must be an String");
   }
  }

  function _setValidReturnTotalRecordCount(value) {
   if (typeof value == "boolean") {
    _returnTotalRecordCount = value;
   }
   else {
    throw new Error("Sdk.Query.PagingInfo ReturnTotalRecordCount property must be an Boolean");
   }
  }

  //public methods
  this.getCount = function () {
   ///<summary>
   /// Gets the number of entity instances returned per page.
   ///</summary>
   ///<returns type="Number">
   /// The number of entity instances returned per page.
   ///</returns>
   return _count;
  };
  this.setCount = function (count) {
   ///<summary>
   /// Sets the number of entity instances returned per page.
   ///</summary>
   ///<param name="count" type="Number">
   /// The number of entity instances returned per page.
   ///</param>
   _setValidCount(count);
  };

  this.getPageNumber = function () {
   ///<summary>
   /// Gets the number of pages returned from the query. 
   ///</summary>
   ///<returns type="Number">
   /// The number of pages returned from the query
   ///</returns>
   return _pageNumber;
  };
  this.setPageNumber = function (pages) {
   ///<summary>
   ///  Sets the number of pages returned from the query. 
   ///</summary>
   ///<param name="pages" type="Number">
   ///  The number of pages returned from the query. 
   ///</param>
   _setValidPageNumber(pages);
  };

  this.getPagingCookie = function () {
   ///<summary>
   /// Gets the info used to page large result sets. 
   ///</summary>
   ///<returns type="String">
   /// The info used to page large result sets.
   ///</returns>
   return _pagingCookie;
  };
  this.setPagingCookie = function (cookie) {
   ///<summary>
   /// Sets the info used to page large result sets. 
   ///</summary>
   ///<param name="cookie" type="String">
   ///  The info used to page large result sets.
   ///</param>
   _setValidPagingCookie(cookie);
  };

  this.getReturnTotalRecordCount = function () {
   ///<summary>
   /// Gets whether the total number of records should be returned from the query. 
   ///</summary>
   ///<returns type="Boolean">
   /// true if the TotalRecordCount should be set when the query is executed; otherwise, false. 
   ///</returns>
   return _returnTotalRecordCount;
  };
  this.setReturnTotalRecordCount = function (returnTotalRecordsCount) {
   ///<summary>
   ///  Sets whether the total number of records should be returned from the query. 
   ///</summary>
   ///<param name="returnTotalRecordsCount" type="Boolean">
   ///  true if the TotalRecordCount should be set when the query is executed; otherwise, false. 
   ///</param>
   _setValidReturnTotalRecordCount(returnTotalRecordsCount);

  };


 };
 this.PagingInfo.__class = true;
 //Sdk.Query.PagingInfo END
 //--------------------------------------------------------------------
 //Sdk.Query.QueryBase START
 this.QueryBase = function (type) {
  ///<summary>
  /// <para>Internal Use Only</para>
  /// <para>An Abstract class for different query classes to inherit from</para>
  ///</summary>
  ///<para type="String" name="type" />

  if (!(this instanceof Sdk.Query.QueryBase)) {
   return new Sdk.Query.QueryBase(type);
  }
  var _type;

  function _setValidType(value) {
   if ((typeof value == "string" && (value == "QueryExpression" || value == "FetchExpression" || value == "QueryByAttribute"))) {
    _type = value;
   }
   else {
    throw new Error("Sdk.Query.QueryBase Type value must be a string value of either: 'QueryExpression','FetchExpression', or 'QueryByAttribute'");
   }

  }

  this.getQueryType = function () {
   return _type;
  }


  _setValidType(type);


 }
 //Sdk.Query.QueryBase END
 //--------------------------------------------------------------------
 //Sdk.Query.QueryByAttribute START
 this.QueryByAttribute = function (entityName) {
  ///<summary>
  /// Initializes a new instance of the QueryByAttribute class setting the entity name.
  ///</summary>
  ///<param name="entityName" type="String" optional="true">
  /// The name of the entity. 
  ///</param>

  if (!(this instanceof Sdk.Query.QueryByAttribute)) {
   return new Sdk.Query.QueryByAttribute(entityName);
  }
  Sdk.Query.QueryBase.call(this, "QueryByAttribute");
  // inner properties
  var _attributeValues = new Sdk.Collection(Sdk.AttributeBase);
  var _columnSet = new Sdk.ColumnSet();
  var _entityName = null;
  var _orders = new Sdk.Collection(Sdk.Query.OrderExpression);
  var _pageInfo = new Sdk.Query.PagingInfo();
  var _topCount = null;
  //A query can contain either PageInfo or TopCount property values. If both are specified, an error will be thrown.



  //internal setter functions
  function _setValidColumnSet(value) {
   if (value instanceof Sdk.ColumnSet) {
    _columnSet = value;
   }
   else {
    throw new Error("Sdk.Query.QueryByAttribute ColumnSet property must be an Sdk.ColumnSet");
   }
  };
  function _setValidOrders(value) {
   if ((value instanceof Sdk.Collection) && (value.getType() == Sdk.Query.OrderExpression)) {
    _orders = value;
   }
   else {
    throw new Error("Sdk.Query.QueryByAttribute Oerders property must be an Sdk.Collection of Sdk.Query.OrderExpression instances.");
   }
  }
  function _setValidEntityName(value) {
   if (typeof value == "string") {
    _entityName = value;
   }
   else {
    throw new Error("Sdk.Query.QueryByAttribute EntityName property must be an String");
   }
  }
  function _setValidPageInfo(value) {
   if (value instanceof Sdk.Query.PagingInfo) {
    _pageInfo = value;
   }
   else {
    throw new Error("Sdk.Query.QueryByAttribute PageInfo property must be an Sdk.Query.PagingInfo");
   }
  };
  function _setValidTopCount(value) {
   if (typeof value == "number") {
    _topCount = value;
   }
   else {
    throw new Error("Sdk.Query.QueryByAttribute TopCount property must be an Number");
   }
  };


  //Set internal properties from constructor parameters
  if (typeof entityName != "undefined" || entityName != null) {
   _setValidEntityName(entityName);
  }

  //this.setQueryType("QueryByAttribute");

  //public methods
  this.getColumnSet = function () {
   ///<summary>
   /// Gets the columns to include.
   ///</summary>
   ///<returns type="Sdk.ColumnSet">
   /// The columns to include.
   ///</returns>
   return _columnSet;
  };
  this.setColumnSet = function (columns) {
   ///<summary>
   /// Sets the columns to include.
   ///</summary>
   ///<param name="columns" type="Object">
   /// <para>Three Options</para>
   /// <para> An Sdk.ColumnSet instance.</para>
   /// <para> An Array of attribute logical names for the columns to return.</para>
   /// <para> Pass each attribute logical name as an argument</para>
   ///</param>
   if (columns instanceof Sdk.ColumnSet) {
    _setValidColumnSet(columns);
   }
   else {
    if (typeof columns != "undefined" && typeof columns.push != "undefined") {
     _setValidColumnSet(new Sdk.ColumnSet(columns));
    }
    else {
     if (arguments.length > 0) {
      var attributes = [];
      for (var i = 0; i < arguments.length; i++) {
       if (typeof arguments[i] == "string") {
        attributes.push(arguments[i]);
       }
      }
      _setValidColumnSet(new Sdk.ColumnSet(attributes));
     }
    }
   }
  };

  this.getEntityName = function () {
   ///<summary>
   /// Gets the logical name of the entity.
   ///</summary>
   ///<returns type="String">
   /// The logical name of the entity
   ///</returns>
   return _entityName;
  };
  this.setEntityName = function (name) {
   ///<summary>
   /// Sets the logical name of the entity.
   ///</summary>
   ///<param name="name" type="String">
   /// The logical name of the entity
   ///</param>
   _setValidEntityName(name);
  };

  this.getAttributeValues = function () {
   ///<summary>
   /// Gets the attribute values
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of Sdk.AttributeBase attributes
   ///</returns>
   return _attributeValues;
  }

  this.getOrders = function () {
   ///<summary>
   /// Gets an Sdk.Collection of Sdk.Query.OrderExpression instances that define the order in which the entity instances are returned from the query. 
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of Sdk.Query.OrderExpression instances that define the order in which the entity instances are returned from the query. 
   ///</returns>
   return _orders;
  };
  this.setOrders = function (orders) {
   ///<summary>
   /// Sets an Sdk.Collection of Sdk.Query.OrderExpression instances that define the order in which the entity instances are returned from the query. 
   ///</summary>
   ///<param name="orders" type="Sdk.Collection">
   /// An Sdk.Collection of Sdk.Query.OrderExpression instances that define the order in which the entity instances are returned from the query. 
   ///</param>
   _setValidOrders(orders);
  }

  this.getPageInfo = function () {
   ///<summary>
   /// Gets the number of pages and the number of entity instances per page returned from the query. 
   ///</summary>
   ///<returns type="Sdk.Query.PagingInfo">
   /// The number of pages and the number of entity instances per page returned from the query.
   ///</returns>

   return _pageInfo;
  };
  this.setPageInfo = function (pageInfo) {
   ///<summary>
   /// Sets the number of pages and the number of entity instances per page returned from the query. 
   ///</summary>
   ///<param name="pageInfo" type="Sdk.Query.PagingInfo">
   /// The number of pages and the number of entity instances per page returned from the query. 
   ///</param>
   _setValidPageInfo(pageInfo);
   _topCount = null;
  };

  this.getTopCount = function () {
   ///<summary>
   /// Gets the number of rows to be returned. 
   ///</summary>
   ///<returns type="Number">
   /// The number of rows to be returned. 
   ///</returns>

   return _topCount;
  };
  this.setTopCount = function (count) {
   ///<summary>
   /// Sets the number of rows to be returned. 
   ///</summary>
   ///<param name="count" type="Number">
   /// The number of rows to be returned. 
   ///</param>
   _setValidTopCount(count);
   _pageInfo = null;
  };

 };
 this.QueryByAttribute.__class = true;
 //Sdk.Query.QueryByAttribute END
 //--------------------------------------------------------------------
 //Sdk.Query.QueryExpression START
 this.QueryExpression = function (entityName) {
  ///<summary>
  /// Initializes a new instance of the QueryExpression class setting the entity name.
  ///</summary>
  ///<param name="entityName" type="String" optional="true">
  /// The name of the entity. 
  ///</param>

  if (!(this instanceof Sdk.Query.QueryExpression)) {
   return new Sdk.Query.QueryExpression(entityName);
  }
  Sdk.Query.QueryBase.call(this, "QueryExpression");
  // inner properties
  var _columnSet = new Sdk.ColumnSet();
  var _criteria = new Sdk.Query.FilterExpression(Sdk.Query.LogicalOperator.And);
  var _distinct = false;
  var _entityName = null;
  var _linkEntities = new Sdk.Collection(Sdk.Query.LinkEntity);
  var _noLock = false;
  var _orders = new Sdk.Collection(Sdk.Query.OrderExpression);
  var _pageInfo = new Sdk.Query.PagingInfo();
  var _topCount = null;
  //A query can contain either PageInfo or TopCount property values. If both are specified, an error will be thrown.



  //internal setter function
  function _setValidColumnSet(value) {
   if (value instanceof Sdk.ColumnSet) {
    _columnSet = value;
   }
   else {
    throw new Error("Sdk.Query.QueryExpression ColumnSet property must be an Sdk.ColumnSet");
   }
  };
  function _setValidCriteria(value) {
   if (value instanceof Sdk.Query.FilterExpression) {
    _criteria = value;
   }
   else { throw new Error("Sdk.Query.QueryExpression Criteria property must be an Sdk.Query.FilterExpression"); }
  };
  function _setValidDistinct(value) {
   if (typeof value == "boolean") {
    _distinct = value;
   }
   else {
    throw new Error("Sdk.Query.QueryExpression Distinct property must be an Boolean");
   }
  };
  function _setValidEntityName(value) {
   if (typeof value == "string") {
    _entityName = value;
   }
   else {
    throw new Error("Sdk.Query.QueryExpression EntityName property must be an String");
   }
  }
  function _setValidNoLock(value) {

   if (typeof value == "boolean") {
    _noLock = value;
   }
   else {
    throw new Error("Sdk.Query.QueryExpression NoLock property must be an Boolean");
   }
  };
  function _setValidPageInfo(value) {
   if (value instanceof Sdk.Query.PagingInfo) {
    _pageInfo = value;
   }
   else {
    throw new Error("Sdk.Query.QueryExpression PageInfo property must be an Sdk.Query.PagingInfo");
   }
  };
  function _setValidTopCount(value) {
   if (typeof value == "number") {
    _topCount = value;
   }
   else {
    throw new Error("Sdk.Query.QueryExpression TopCount property must be an Number");
   }
  };


  //Set internal properties from constructor parameters
  if (typeof entityName != "undefined" || entityName != null) {
   _setValidEntityName(entityName);
  }

 // this.setQueryType("QueryExpression");

  //public methods
  this.getColumnSet = function () {
   ///<summary>
   /// Gets the columns to include.
   ///</summary>
   ///<returns type="Sdk.ColumnSet">
   /// The columns to include.
   ///</returns>
   return _columnSet;
  };
  this.setColumnSet = function (columns) {
   ///<summary>
   /// Sets the columns to include.
   ///</summary>
   ///<param name="columns" type="Object">
   /// <para>Three Options</para>
   /// <para> An Sdk.ColumnSet instance.</para>
   /// <para> An Array of attribute logical names for the columns to return.</para>
   /// <para> Pass each attribute logical name as an argument</para>
   ///</param>
   if (columns instanceof Sdk.ColumnSet) {
    _setValidColumnSet(columns);
   }
   else {
    if (typeof columns != "undefined" && typeof columns.push != "undefined") {
     _setValidColumnSet(new Sdk.ColumnSet(columns));
    }
    else {
     if (arguments.length > 0) {
      var attributes = [];
      for (var i = 0; i < arguments.length; i++) {
       if (typeof arguments[i] == "string") {
        attributes.push(arguments[i]);
       }
      }
      _setValidColumnSet(new Sdk.ColumnSet(attributes));
     }
    }
   }
  };

  this.getCriteria = function () {
   ///<summary>
   /// Gets the complex condition and logical filter expressions that filter the results of the query. 
   ///</summary>
   ///<returns type="SQK.Query.FilterExpression">
   ///  The query condition and filter criteria. 
   ///</returns>

   return _criteria;
  };
  this.setCriteria = function (criteria) {
   ///<summary>
   /// Sets the complex condition and logical filter expressions that filter the results of the query. 
   ///</summary>
   ///<param name="criteria" type="SQK.Query.FilterExpression">
   /// The query condition and filter criteria. 
   ///</param>
   _setValidCriteria(criteria);
  };

  this.getDistinct = function () {
   ///<summary>
   /// Gets whether the results of the query contain duplicate entity instances. 
   ///</summary>
   ///<returns type="Boolean">
   /// true if the results of the query contain duplicate entity instances; otherwise, false. 
   ///</returns>

   return _distinct;
  };
  this.setDistinct = function (isDistinct) {
   ///<summary>
   /// Sets whether the results of the query contain duplicate entity instances. 
   ///</summary>
   ///<param name="isDistinct" type="Boolean">
   /// true if the results of the query contain duplicate entity instances; otherwise, false. 
   ///</param>
   _setValidDistinct(isDistinct);
  };

  this.getEntityName = function () {
   ///<summary>
   /// Gets the logical name of the entity.
   ///</summary>
   ///<returns type="String">
   /// The logical name of the entity
   ///</returns>
   return _entityName;
  };
  this.setEntityName = function (name) {
   ///<summary>
   /// Sets the logical name of the entity.
   ///</summary>
   ///<param name="name" type="String">
   /// The logical name of the entity
   ///</param>
   _setValidEntityName(name);
  };

  this.getLinkEntities = function () {
   ///<summary>
   /// Gets an Sdk.Collection of Sdk.Query.LinkEntity instances 
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of Sdk.Query.LinkEntity instances
   ///</returns>

   return _linkEntities;
  };

  this.getNoLock = function () {
   ///<summary>
   /// Gets a value that indicates that no shared locks are issued against the data that would prohibit other transactions from modifying the data in the records returned from the query. 
   ///</summary>
   ///<returns type="Boolean">
   /// true if there are no shared locks are issued against the data that would prohibit other transactions from modifying the data in the records returned from the query; otherwise, false. 
   ///</returns>

   return _noLock;
  };
  this.setNoLock = function (isNoLock) {
   ///<summary>
   /// Sets a value that indicates that no shared locks are issued against the data that would prohibit other transactions from modifying the data in the records returned from the query. 
   ///</summary>
   ///<param name="isNoLock" type="Boolean">
   /// true if there are no shared locks are issued against the data that would prohibit other transactions from modifying the data in the records returned from the query; otherwise, false. 
   ///</param>
   _setValidNoLock(isNoLock);
  };

  this.getOrders = function () {
   ///<summary>
   /// Gets an Sdk.Collection of Sdk.Query.OrderExpression instances that define the order in which the entity instances are returned from the query. 
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of Sdk.Query.OrderExpression instances that define the order in which the entity instances are returned from the query. 
   ///</returns>
   return _orders;
  };

  this.getPageInfo = function () {
   ///<summary>
   /// Gets the number of pages and the number of entity instances per page returned from the query. 
   ///</summary>
   ///<returns type="Sdk.Query.PagingInfo">
   /// The number of pages and the number of entity instances per page returned from the query.
   ///</returns>

   return _pageInfo;
  };
  this.setPageInfo = function (pageInfo) {
   ///<summary>
   /// Sets the number of pages and the number of entity instances per page returned from the query. 
   ///</summary>
   ///<param name="pageInfo" type="Sdk.Query.PagingInfo">
   /// The number of pages and the number of entity instances per page returned from the query. 
   ///</param>
   _setValidPageInfo(pageInfo);
   _topCount = null;
  };

  this.getTopCount = function () {
   ///<summary>
   /// Gets the number of rows to be returned. 
   ///</summary>
   ///<returns type="Number">
   /// The number of rows to be returned. 
   ///</returns>

   return _topCount;
  };
  this.setTopCount = function (topCount) {
   ///<summary>
   /// Sets the number of rows to be returned. 
   ///</summary>
   ///<param name="topCount" type="Number">
   /// The number of rows to be returned. 
   ///</param>
   _setValidTopCount(topCount);
   _pageInfo = null;
  };

 };
 this.QueryExpression.__class = true;
 //Sdk.Query.QueryExpression END

 //--------------------------------------------------------------------
 //Sdk.Query.ValueBase START
 this.ValueBase = function () {
  ///<summary>
  /// A base class for typed values to be used with Sdk.Query.ConditionExpression
  ///</summary>
  if (!(this instanceof Sdk.Query.ValueBase)) {
   return new Sdk.Query.ValueBase();
  }
 }

 this.Booleans = function (args) {
  ///<summary>
  /// Specifies Boolean values to be compared in the query.
  ///</summary>
  ///<param name="args" type="Array">
  /// <para>  An Array of Boolean values</para>
  ///</param>
  if (!(this instanceof Sdk.Query.Booleans)) {
   return new Sdk.Query.Booleans(args);
  }
  Sdk.Query.ValueBase.call(this);

  var _values = new Sdk.Collection(Boolean);
  function _setValidValues(value) {
   var errorMessage = "Sdk.Query.Booleans Values property must be an Array of Boolean values.";
   if (typeof value.push == "function") {
    try {
     _values = new Sdk.Collection(Boolean, value);
    }
    catch (e) {
     throw new Error(errorMessage);
    }
   }
   else {
    throw new Error(errorMessage);
   }
  }

  //Set internal properties from constructor parameters
  if (typeof args != "undefined") {
   _setValidValues(args);
  }

  this.getValues = function () {
   ///<summary>
   /// Gets the value
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection with a single boolean value;
   ///</returns>
   return _values;
  }
  this.getType = function () {
   ///<summary>
   /// Gets the type
   ///</summary>
   ///<returns type="String">
   /// The type of value with namespace prefix;
   ///</returns>
   return "c:boolean";
  }
  this.setValues = function (setValueArgs) {
   ///<summary>
   /// Specifies a Boolean value to be compared in the query.
   ///</summary>
   ///<param name="setValueArgs" type="Array">
   /// <para>  An Array of Boolean values</para>
   ///</param>
   _setValidValues(setValueArgs);
  }

 }
 this.Booleans.__class = true;

 this.BooleanManagedProperties = function (args) {
  ///<summary>
  /// Specifies BooleanManagedProperty values to be compared in the query.
  ///</summary>
  ///<param name="args" type="Array">
  /// <para>  An Array of Boolean values</para>
  ///</param>

  if (!(this instanceof Sdk.Query.BooleanManagedProperties)) {
   return new Sdk.Query.BooleanManagedProperties(args);
  }
  Sdk.Query.ValueBase.call(this);
  var _values = new Sdk.Collection(Boolean);

  function _setValidValues(value) {
   var errorMessage = "Sdk.Query.BooleanManagedProperties Values property must be an Array of Boolean values."
   if (typeof value.push == "function") {
    try {
     _values = new Sdk.Collection(Boolean, value);
    }
    catch (e) {
     throw new Error(errorMessage);
    }
   }
   else {
    throw new Error(errorMessage);
   }
  }



  //Set internal properties from constructor parameters
  if (typeof args != "undefined") {
   _setValidValues(args);
  }



  this.getValues = function () {
   ///<summary>
   /// Gets the value
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection with a single boolean value;
   ///</returns>
   return _values;
  }
  this.getType = function () {
   ///<summary>
   /// Gets the type
   ///</summary>
   ///<returns type="String">
   /// The type of value with namespace prefix;
   ///</returns>
   return "c:boolean";
  }
  this.setValues = function (setValueArgs) {
   ///<summary>
   /// Specifies BooleanManagedProperty values to be compared in the query.
   ///</summary>
   ///<param name="setValueArgs" type="Array">
   /// <para>  An Array of Boolean values</para>
   ///</param>
   _setValidValues(setValueArgs);
  }

 }
 this.BooleanManagedProperties.__class = true;

 this.Dates = function (args) {
  ///<summary>
  /// Specifies the Date values to be compared in the query.
  ///</summary>
  ///<param name="args" type="Array">
  /// <para>  An Array of Date values</para>
  ///</param>
  if (!(this instanceof Sdk.Query.Dates)) {
   return new Sdk.Query.Dates(args);
  }
  Sdk.Query.ValueBase.call(this);

  var _values = new Sdk.Collection(Date);
  function _setValidValues(value) {
   var errorMessage = "Sdk.Query.Dates Values property must be an Array of Date values.";
   if (typeof value.push == "function") {
    try {
     _values = new Sdk.Collection(Date, value);
    }
    catch (e) {
     throw new Error(errorMessage);
    }
   }
   else {
    throw new Error(errorMessage);
   }
  }

  //Set values collection data from constructor parameters  
  if (typeof args != "undefined") {
   _setValidValues(args);
  }

  this.getValues = function () {
   ///<summary>
   /// Gets the value
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of Date values
   ///</returns>
   return _values;
  }
  this.getType = function () {
   ///<summary>
   /// Gets the type
   ///</summary>
   ///<returns type="String">
   /// The type of value with namespace prefix;
   ///</returns>
   return "c:dateTime";
  }
  this.setValues = function (setValueArgs) {
   ///<summary>
   /// Specifies the Date values to be compared in the query.
   ///</summary>
   ///<param name="setValueArgs" type="Array">
   /// <para>  An Array of Date values</para>
   ///</param>
   _setValidValues(setValueArgs);
  }

 }
 this.Dates.__class = true;

 this.Decimals = function (args) {
  ///<summary>
  /// Specifies the Decimal values to be compared in the query.
  ///</summary>
  ///<param name="args" type="Array">
  /// <para>  An Array of Number values</para>
  ///</param>
  if (!(this instanceof Sdk.Query.Decimals)) {
   return new Sdk.Query.Decimals(args);
  }
  Sdk.Query.ValueBase.call(this);

  var _values = new Sdk.Collection(Number);
  function _setValidValues(value) {
   var errorMessage = "Sdk.Query.Decimals Values property must be an Array of Number values.";
   if (typeof value.push == "function") {
    try {
     _values = new Sdk.Collection(Number, value);
    }
    catch (e) {
     throw new Error(errorMessage);
    }
   }
   else {
    throw new Error(errorMessage);
   }
  }

  //Set values collection data from constructor parameters  
  if (typeof args != "undefined") {
   _setValidValues(args);
  }

  this.getValues = function () {
   ///<summary>
   /// Gets the value
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of Number values
   ///</returns>
   return _values;
  }
  this.getType = function () {
   ///<summary>
   /// Gets the type
   ///</summary>
   ///<returns type="String">
   /// The type of value with namespace prefix;
   ///</returns>
   return "c:decimal";
  }
  this.setValues = function (setValueArgs) {
   ///<summary>
   /// Specifies the Decimal values to be compared in the query.
   ///</summary>
   ///<param name="setValueArgs" type="Array">
   /// <para>  An Array of Number values</para>
   ///</param>
   _setValidValues(setValueArgs);
  }

 }
 this.Decimals.__class = true;

 this.Doubles = function (args) {
  ///<summary>
  /// Specifies the Double values to be compared in the query.
  ///</summary>
  ///<param name="args" type="Array">
  /// <para>  An Array of Number values</para>
  ///</param>
  if (!(this instanceof Sdk.Query.Doubles)) {
   return new Sdk.Query.Doubles(args);
  }
  Sdk.Query.ValueBase.call(this);

  var _values = new Sdk.Collection(Number);
  function _setValidValues(value) {
   var errorMessage = "Sdk.Query.Doubles Values property must be an Array of Number values.";
   if (typeof value.push == "function") {
    try {
     _values = new Sdk.Collection(Number, value);
    }
    catch (e) {
     throw new Error(errorMessage);
    }
   }
   else {
    throw new Error(errorMessage);
   }
  }

  //Set values collection data from constructor parameters  
  if (typeof args != "undefined") {
   _setValidValues(args);
  }

  this.getValues = function () {
   ///<summary>
   /// Gets the value
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of Number values
   ///</returns>
   return _values;
  }
  this.getType = function () {
   ///<summary>
   /// Gets the type
   ///</summary>
   ///<returns type="String">
   /// The type of value with namespace prefix;
   ///</returns>
   return "c:double";
  }
  this.setValues = function (setValueArgs) {
   ///<summary>
   /// Specifies the Double values to be compared in the query.
   ///</summary>
   ///<param name="setValueArgs" type="Array">
   /// <para>  An Array of Number values</para>
   ///</param>
   _setValidValues(setValueArgs);
  }

 }
 this.Doubles.__class = true;

 this.EntityReferences = function (args) {
  ///<summary>
  /// Specifies the Sdk.EntityReference values to be compared in the query.
  ///</summary>
  ///<param name="args" type="Array">
  /// <para>  An Array of Sdk.EntityReference values</para>
  ///</param>
  if (!(this instanceof Sdk.Query.EntityReferences)) {
   return new Sdk.Query.EntityReferences(args);
  }
  Sdk.Query.ValueBase.call(this);

  var _values = new Sdk.Collection(Sdk.EntityReference);
  function _setValidValues(value) {
   var errorMessage = "Sdk.Query.EntityReferences Values property can be an Array of Sdk.EntityReference values.";
   if (typeof value.push == "function") {
    try {
     _values = new Sdk.Collection(Sdk.EntityReference, value);
    }
    catch (e) {
     throw new Error(errorMessage);
    }
   }
   else {
    throw new Error(errorMessage);
   }
  }

  //Set values collection data from constructor parameters  
  if (typeof args != "undefined") {
   _setValidValues(args);
  }

  this.getValues = function () {
   ///<summary>
   /// Gets the value
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of Sdk.EntityReference values
   ///</returns>
   return _values;
  }
  this.getType = function () {
   ///<summary>
   /// Gets the type
   ///</summary>
   ///<returns type="String">
   /// The type of value with namespace prefix;
   ///</returns>
   return "e:guid";
  }
  this.setValues = function (setValueArgs) {
   ///<summary>
   /// Specifies the Sdk.EntityReference values to be compared in the query.
   ///</summary>
   ///<param name="setValueArgs" type="Array">
   /// <para>  An Array of Sdk.EntityReference values</para>
   ///</param>
   _setValidValues(setValueArgs);
  }

 }
 this.EntityReferences.__class = true;

 this.Guids = function (args) {
  ///<summary>
  /// Specifies the Guid values to be compared in the query.
  ///</summary>
  ///<param name="args" type="Array">
  /// <para>  An Array of String values</para>
  ///</param>
  if (!(this instanceof Sdk.Query.Guids)) {
   return new Sdk.Query.Guids(args);
  }
  Sdk.Query.ValueBase.call(this);

  var _values = new Sdk.Collection(String);
  function _setValidValues(value) {
   var errorMessage = "Sdk.Query.Guids values must be an Array of String values.";
   if (typeof value.push == "function") {
    for (var i = 0; i < value.length; i++) {
     if (!Sdk.Util.isGuid(value[i])) {
      throw new Error("Sdk.Query.Guids values must be String representations of Guid values.");
     }
    }
    _values = new Sdk.Collection(String, value)
   }
   else {
    throw new Error(errorMessage);
   }
  }

  //Set values collection data from constructor parameters  
  if (typeof args != "undefined") {
   _setValidValues(args);
  }
  this.getValues = function () {
   ///<summary>
   /// Gets the value
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of String values
   ///</returns>
   return _values;
  }
  this.getType = function () {
   ///<summary>
   /// Gets the type
   ///</summary>
   ///<returns type="String">
   /// The type of value with namespace prefix;
   ///</returns>
   return "e:guid";
  }
  this.setValues = function (setValueArgs) {
   ///<summary>
   /// Specifies the Guid values to be compared in the query.
   ///</summary>
   ///<param name="setValueArgs" type="Array">
   /// <para>  An Array of String values</para>
   ///</param>
   _setValidValues(setValueArgs);
  }

 }
 this.Guids.__class = true;

 this.Ints = function (args) {
  ///<summary>
  /// Specifies the Int values to be compared in the query.
  ///</summary>
  ///<param name="args" type="Array">
  /// <para>  An Array of Number values</para>
  ///</param>
  if (!(this instanceof Sdk.Query.Ints)) {
   return new Sdk.Query.Ints(args);
  }
  Sdk.Query.ValueBase.call(this);

  var _values = new Sdk.Collection(Number);
  function _setValidValues(value) {
   var errorMessage = "Sdk.Query.Ints Values property must be an Array of Number values.";
   if (typeof value.push == "function") {
    try {
     _values = new Sdk.Collection(Number, value);
    }
    catch (e) {
     throw new Error(errorMessage);
    }
   }
   else {
    throw new Error(errorMessage);
   }
  }

  //Set values collection data from constructor parameters  
  if (typeof args != "undefined") {
   _setValidValues(args);
  }

  this.getValues = function () {
   ///<summary>
   /// Gets the value
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of Number values
   ///</returns>
   return _values;
  }
  this.getType = function () {
   ///<summary>
   /// Gets the type
   ///</summary>
   ///<returns type="String">
   /// The type of value with namespace prefix;
   ///</returns>
   return "c:int";
  }
  this.setValues = function (setValueArgs) {
   ///<summary>
   /// Specifies the Int values to be compared in the query.
   ///</summary>
   ///<param name="setValueArgs" type="Array">
   /// <para>  An Array of Number values</para>
   ///</param>
   _setValidValues(setValueArgs);
  }

 }
 this.Ints.__class = true;

 this.Longs = function (args) {
  ///<summary>
  /// Specifies the Long values to be compared in the query.
  ///</summary>
  ///<param name="args" type="Array">
  /// <para>  An Array of Number values</para>
  ///</param>
  if (!(this instanceof Sdk.Query.Longs)) {
   return new Sdk.Query.Longs(args);
  }
  Sdk.Query.ValueBase.call(this);

  var _values = new Sdk.Collection(Number);
  function _setValidValues(value) {
   var errorMessage = "Sdk.Query.Longs Values property can be an Array of Number values.";
   if (typeof value.push == "function") {
    try {
     _values = new Sdk.Collection(Number, value);
    }
    catch (e) {
     throw new Error(errorMessage);
    }
   }
   else {
    throw new Error(errorMessage);
   }
  }

  //Set values collection data from constructor parameters  
  if (typeof args != "undefined") {
   _setValidValues(args);
  }

  this.getValues = function () {
   ///<summary>
   /// Gets the value
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of Number values
   ///</returns>
   return _values;
  }
  this.getType = function () {
   ///<summary>
   /// Gets the type
   ///</summary>
   ///<returns type="String">
   /// The type of value with namespace prefix;
   ///</returns>
   return "c:long";
  }
  this.setValues = function (setValueArgs) {
   ///<summary>
   /// Specifies the Long values to be compared in the query.
   ///</summary>
   ///<param name="setValueArgs" type="Array">
   /// <para>  An Array of Number values</para>
   ///</param>
   _setValidValues(setValueArgs);
  }

 }
 this.Longs.__class = true;

 this.Money = function (args) {
  ///<summary>
  /// Specifies the Money values to be compared in the query.
  ///</summary>
  ///<param name="args" type="Array">
  /// <para>  An Array of Number values</para>
  ///</param>
  if (!(this instanceof Sdk.Query.Money)) {
   return new Sdk.Query.Money(args);
  }
  Sdk.Query.ValueBase.call(this);

  var _values = new Sdk.Collection(Number);
  function _setValidValues(value) {
   var errorMessage = "Sdk.Query.Money Values property must be an Array of Number values.";
   if (typeof value.push == "function") {
    try {
     _values = new Sdk.Collection(Number, value);
    }
    catch (e) {
     throw new Error(errorMessage);
    }
   }
   else {
    throw new Error(errorMessage);
   }
  }

  //Set values collection data from constructor parameters  
  if (typeof args != "undefined") {
   _setValidValues(args);
  }

  this.getValues = function () {
   ///<summary>
   /// Gets the value
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of Number values
   ///</returns>
   return _values;
  }
  this.getType = function () {
   ///<summary>
   /// Gets the type
   ///</summary>
   ///<returns type="String">
   /// The type of value with namespace prefix;
   ///</returns>
   return "c:decimal";
  }
  this.setValues = function (setValueArgs) {
   ///<summary>
   /// Specifies the Money values to be compared in the query.
   ///</summary>
   ///<param name="setValueArgs" type="Array">
   /// <para>  An Array of Number values</para>
   ///</param>
   _setValidValues(setValueArgs);
  }

 }
 this.Money.__class = true;

 this.OptionSets = function (args) {
  ///<summary>
  /// Specifies the OptionSet values to be compared in the query.
  ///</summary>
  ///<param name="args" type="Array">
  /// <para>  An Array of Number values</para>
  ///</param>
  if (!(this instanceof Sdk.Query.OptionSets)) {
   return new Sdk.Query.OptionSets(args);
  }
  Sdk.Query.ValueBase.call(this);

  var _values = new Sdk.Collection(Number);
  function _setValidValues(value) {
   var errorMessage = "Sdk.Query.OptionSets Values property must be an Array of Number values.";
   if (typeof value.push == "function") {
    try {
     _values = new Sdk.Collection(Number, value);
    }
    catch (e) {
     throw new Error(errorMessage);
    }
   }
   else {
    throw new Error(errorMessage);
   }
  }

  //Set values collection data from constructor parameters  
  if (typeof args != "undefined") {
   _setValidValues(args);
  }

  this.getValues = function () {
   ///<summary>
   /// Gets the value
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of Number values
   ///</returns>
   return _values;
  }
  this.getType = function () {
   ///<summary>
   /// Gets the type
   ///</summary>
   ///<returns type="String">
   /// The type of value with namespace prefix;
   ///</returns>
   return "c:int";
  }
  this.setValues = function (setValueArgs) {
   ///<summary>
   /// Specifies the OptionSet values to be compared in the query.
   ///</summary>
   ///<param name="setValueArgs" type="Array">
   /// <para>  An Array of Number values</para>
   ///</param>
   _setValidValues(setValueArgs);
  }

 }
 this.OptionSets.__class = true;

 this.Strings = function (args) {
  ///<summary>
  /// Specifies the String values to be compared in the query.
  ///</summary>
  ///<param name="args" type="Array">
  /// <para>  An Array of String values</para>
  ///</param>
  if (!(this instanceof Sdk.Query.Strings)) {
   return new Sdk.Query.Strings(args);
  }
  Sdk.Query.ValueBase.call(this);

  var _values = new Sdk.Collection(String);
  function _setValidValues(value) {
   var errorMessage = "Sdk.Query.Strings Values property must be an Array of String values.";
   if (typeof value.push == "function") {
    try {
     _values = new Sdk.Collection(String, value);
    }
    catch (e) {
     throw new Error(errorMessage);
    }
   }
   else {
    throw new Error(errorMessage);
   }
  }

  //Set values collection data from constructor parameters  
  if (typeof args != "undefined") {
   _setValidValues(args);
  }

  this.getValues = function () {
   ///<summary>
   /// Gets the value
   ///</summary>
   ///<returns type="Sdk.Collection">
   /// An Sdk.Collection of String values
   ///</returns>
   return _values;
  }
  this.getType = function () {
   ///<summary>
   /// Gets the type
   ///</summary>
   ///<returns type="String">
   /// The type of value with namespace prefix;
   ///</returns>
   return "c:string";
  }
  this.setValues = function (setValueArgs) {
   ///<summary>
   /// Specifies the String values to be compared in the query.
   ///</summary>
   ///<param name="setValueArgs" type="Object">
   /// <para>  An Array of String values</para>
   ///</param>
   _setValidValues(setValueArgs);
  }

 }
 this.Strings.__class = true;

 //Sdk.Query.ValueBase END

}).call(Sdk.Query);

(function ()
{
 
 this.associate = function (entityName, entityId, relationship, relatedEntities, successCallBack, errorCallBack, passThruObj) {
  ///<summary>
  /// Creates a link between records. 
  ///</summary>
  ///<param name="entityName" type="String" optional='false' mayBeNull='false'>
  /// The logical name of the entity that is specified in the entityId parameter.
  ///</param>
  ///<param name="entityId" type="String" optional='false' mayBeNull='false'>
  /// The ID of the record to which the related records are associated.
  ///</param>
  ///<param name="relationship" type="String" optional='false' mayBeNull='false'>
  /// The name of the relationship to be used to create the link. 
  ///</param>
  ///<param name="relatedEntities" type="Sdk.Collection" optional='false' mayBeNull='false'>
  /// A collection of Sdk.EntityReference objects to be associated.
  ///</param>
  ///<param name="successCallBack" type="Function" optional="true">
  /// The function to call if the operation is successful. No parameter is passed.
  ///</param>
  ///<param name="errorCallBack" type="Function" optional="true">
  /// The function to call if the operation is unsuccessful. This function should accept an Error object as the first parameter.
  ///</param>
  ///<param name="passThruObj" type="Object" optional="true">
  /// An optional parameter to pass through as the first parameter to the successCallBack or second parameter of the errorCallBack
  ///</param>
  if (typeof entityName != "string") {
   throw new Error("Sdk.Async.associate entityName parameter is required and must be a String.");
  }
  if (typeof entityId != "string" || (!Sdk.Util.isGuidOrNull(entityId))) {
   throw new Error("Sdk.Async.associate entityId parameter is required and must be an string representation of a GUID value.");
  }
  if (typeof relationship != "string") {
   throw new Error("Sdk.Async.associate relationship parameter is required and must be a String.");
  }
  if (!(relatedEntities instanceof Sdk.Collection)) {
   throw new Error("Sdk.Async.associate relatedEntities parameter is required and must be an Sdk.Collection.");
  }
  if (relatedEntities.getCount() <= 0) {
   throw new Error("Sdk.Async.associate relatedEntities parameter must contain entity references to associate.");
  }
  relatedEntities.forEach(function (er, i) {
   if (!(er instanceof Sdk.EntityReference)) {
    throw new Error("Sdk.Async.associate relatedEntities parameter must contain only Sdk.EntityReference objects.");
   }
  });

  if ((successCallBack != null) && (typeof successCallBack != "function")) {
   throw new Error("Sdk.Async.associate successCallBack parameter must be null or a function.");
  }

  if ((errorCallBack != null) && (typeof errorCallBack != "function")) {
   throw new Error("Sdk.Async.associate errorCallBack parameter must be null or a function.");
  }

  var relatedEntitiesXml = [];
  relatedEntities.forEach(function (er, i) {
   relatedEntitiesXml.push(er.toXml());
  })

  var requestXml = [
   Sdk.Xml.getEnvelopeHeader(),
    "<s:Body>",
      "<d:Associate>",
        "<d:entityName>", entityName.toLowerCase(), "</d:entityName>",
        "<d:entityId>", entityId, "</d:entityId>",
        "<d:relationship>",
          "<a:PrimaryEntityRole i:nil=\"true\" />",
          "<a:SchemaName>", relationship, "</a:SchemaName>",
        "</d:relationship>",
        "<d:relatedEntities>",
          relatedEntitiesXml.join(""),
        "</d:relatedEntities>",
      "</d:Associate>",
     "</s:Body>",
    "</s:Envelope>"].join("");

  var req = Sdk.Util.getXMLHttpRequest("Associate", true);
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     if (successCallBack) {
      successCallBack(passThruObj);
     }
    }
    else {
     if (errorCallBack) {
      errorCallBack(Sdk.Util.getError(this), passThruObj);
     }
    }
   }
  };
  req.send(requestXml);
  req = null;


 }
 this.create = function (entity, successCallBack, errorCallBack, passThruObj) {
  ///<summary>
  /// Creates an entity record
  ///</summary>
  ///<param name="entity" type="Sdk.Entity" optional="false">
  /// An entity instance
  ///</param>
  ///<param name="successCallBack" type="Function" optional="true">
  /// The function to call if the operation is successful. This function should accept an string representation of a GUID value as the first parameter.
  ///</param>
  ///<param name="errorCallBack" type="Function" optional="true">
  /// The function to call if the operation is unsuccessful. This function should accept an Error object as the first parameter.
  ///</param>
  ///<param name="passThruObj" type="Object" optional="true">
  /// An optional parameter to pass through to the successCallBack or errorCallBack as the second parameter
  ///</param>
  if (!(entity instanceof Sdk.Entity)) {
   throw new Error("Sdk.Async.create entity parameter is required and must be an Sdk.Entity instance");
  }

  if ((successCallBack != null) && (typeof successCallBack != "function")) {
   throw new Error("Sdk.Async.create successCallBack parameter must be null or a function.");
  }

  if ((errorCallBack != null) && (typeof errorCallBack != "function")) {
   throw new Error("Sdk.Async.create errorCallBack parameter must be null or a function.");
  }

  var requestXml = [
   Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
    "<d:Create>",
     entity.toXml("create"),
    "</d:Create>",
   "</s:Body>",
  "</s:Envelope>"].join("");

  var req = Sdk.Util.getXMLHttpRequest("Create", true);
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     var doc = this.responseXML;
     Sdk.Xml.setSelectionNamespaces(doc);
     var id = Sdk.Xml.selectSingleNodeText(doc, "s:Envelope/s:Body/d:CreateResponse/d:CreateResult")
     entity.setId(id, true);
     //Set entity children so that they won't get saved again.
     entity.setIsChanged(false);
     if (successCallBack) {
      successCallBack(id, passThruObj);
     }
    }
    else {
     if (errorCallBack) {
      errorCallBack(Sdk.Util.getError(this), passThruObj);
     }
    }
   }
  };
  req.send(requestXml);
  req = null;

 }
 this.del = function (entityName, id, successCallBack, errorCallBack, passThruObj) {
  ///<summary>
  /// Deletes an entity record
  ///</summary>
  ///<param name="entityName" type="String" optional="false">
  /// The LogicalName of the entity to delete
  ///</param>
  ///<param name="id" type="String" optional="false">
  /// An ID of the record to delete
  ///</param>
  ///<param name="successCallBack" type="Function" optional="true">
  /// The function to call if the operation is successful. No parameter is passed.
  ///</param>
  ///<param name="errorCallBack" type="Function" optional="true">
  /// The function to call if the operation is unsuccessful. This function should accept an Error object as the first parameter.
  ///</param>
  ///<param name="passThruObj" type="Object" optional="true">
  /// An optional parameter to pass through as the first parameter to the successCallBack or the second parameter to the errorCallBack.
  ///</param>
  if (typeof entityName != "string") {
   throw new Error("Sdk.Async.del entityName parameter is required and must be a String.");
  }
  if (typeof id != "string" || (!Sdk.Util.isGuidOrNull(id))) {
   throw new Error("Sdk.Async.del id is required and must be a string representation of a GUID value.");
  }

  if ((successCallBack != null) && (typeof successCallBack != "function")) {
   throw new Error("Sdk.Async.del successCallBack parameter must be null or a function.");
  }

  if ((errorCallBack != null) && (typeof errorCallBack != "function")) {
   throw new Error("Sdk.Async.del errorCallBack parameter must be null or a function.");
  }

  var requestXml = [
  Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
   "<d:Delete>",
    "<d:entityName>", entityName, "</d:entityName>",
      "<d:id>", id, "</d:id>",
   "</d:Delete>",
  "</s:Body>",
 "</s:Envelope>"].join("");

  var req = Sdk.Util.getXMLHttpRequest("Delete", true);
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     if (successCallBack) {
      successCallBack(passThruObj);
     }
    }
    else {
     if (errorCallBack) {
      errorCallBack(Sdk.Util.getError(this), passThruObj);
     }
    }
   }
  };
  req.send(requestXml);
  req = null;
 }
 this.disassociate = function (entityName, entityId, relationship, relatedEntities, successCallBack, errorCallBack, passThruObj) {
  ///<summary>
  /// Removes a link between records. 
  ///</summary>
  ///<param name="entityName" type="String" optional='false' mayBeNull='false'>
  /// The logical name of the entity that is specified in the entityId parameter.
  ///</param>
  ///<param name="entityId" type="string" optional='false' mayBeNull='false'>
  /// The ID of the record to which the related records are disassociated.
  ///</param>
  ///<param name="relationship" type="String" optional='false' mayBeNull='false'>
  /// The name of the relationship to be used to remove the link. 
  ///</param>
  ///<param name="relatedEntities" type="Sdk.Collection" optional='false' mayBeNull='false'>
  /// A collection of Sdk.EntityReference objects to be disassociated.
  ///</param>
  ///<param name="successCallBack" type="Function" optional="true">
  /// The function to call if the operation is successful. No parameter is passed.
  ///</param>
  ///<param name="errorCallBack" type="Function" optional="true">
  /// The function to call if the operation is unsuccessful. This function should accept an Error object as the first parameter.
  ///</param>
  ///<param name="passThruObj" type="Object" optional="true">
  /// An optional parameter to pass through as the first parameter to the successCallBack or second parameter of the errorCallBack
  ///</param>
  if (typeof entityName != "string") {
   throw new Error("Sdk.Async.disassociate entityName parameter is required and must be a String.");
  }
  if (typeof entityId != "string" || (!Sdk.Util.isGuidOrNull(entityId))) {
   throw new Error("Sdk.Async.disassociate entityId parameter is required and must be an string representation of a GUID value.");
  }
  if (typeof relationship != "string") {
   throw new Error("Sdk.Async.disassociate relationship parameter is required and must be a String.");
  }
  if (!(relatedEntities instanceof Sdk.Collection)) {
   throw new Error("Sdk.Async.disassociate relatedEntities parameter is required and must be an Sdk.Collection.");
  }
  if (relatedEntities.getCount() <= 0) {
   throw new Error("Sdk.Async.disassociate relatedEntities parameter must contain entity references to Dissassociate.");
  }
  relatedEntities.forEach(function (er, i) {
   if (!(er instanceof Sdk.EntityReference)) {
    throw new Error("Sdk.Async.disassociate relatedEntities parameter must contain only Sdk.EntityReference objects.");
   }
  });

  if ((successCallBack != null) && (typeof successCallBack != "function")) {
   throw new Error("Sdk.Async.disassociate successCallBack parameter must be null or a function.");
  }

  if ((errorCallBack != null) && (typeof errorCallBack != "function")) {
   throw new Error("Sdk.Async.disassociate errorCallBack parameter must be null or a function.");
  }

  var relatedEntitiesXml = [];
  relatedEntities.forEach(function (er, i) {
   relatedEntitiesXml.push(er.toXml());
  });

  var requestXml = [
  Sdk.Xml.getEnvelopeHeader(),
    "<s:Body>",
      "<d:Disassociate>",
        "<d:entityName>", entityName.toLowerCase(), "</d:entityName>",
        "<d:entityId>", entityId, "</d:entityId>",
        "<d:relationship>",
          "<a:PrimaryEntityRole i:nil=\"true\" />",
          "<a:SchemaName>", relationship, "</a:SchemaName>",
        "</d:relationship>",
      "<d:relatedEntities>",
       relatedEntitiesXml.join(""),
      "</d:relatedEntities>",
     "</d:Disassociate>",
    "</s:Body>",
   "</s:Envelope>"].join("");

  var req = Sdk.Util.getXMLHttpRequest("Disassociate", true);
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     if (successCallBack) {
      successCallBack(passThruObj);
     }
    }
    else {
     if (errorCallBack) {
      errorCallBack(Sdk.Util.getError(this), passThruObj);
     }
    }
   }
  };
  req.send(requestXml);
  req = null;
 }
 this.execute = function (request, successCallBack, errorCallBack, passThruObj) {
  ///<summary>
  /// Executes a SOAP Request using the SOAPAction Execute
  ///</summary>
  ///<param name="request" type="Sdk.OrganizationRequest">
  /// Required. A request object
  ///</param>
  ///<param name="successCallBack" type="Function">
  /// <para>A function to process a successful response. </para>
  ///</param>
  ///<param name="errorCallBack" type="Function">
  /// <para>A function to process an unsuccessful response. </para>
  /// <para>An error object is passed as the parameter</para>
  ///</param>
  ///<param name="passThruObj" type="Object">
  /// An object to be passed through as the second parameter to the successCallBack and the errorCallBack;
  ///</param>

  if (!(request instanceof Sdk.OrganizationRequest)) {
   throw new Error("Sdk.Async.execute request parameter must be an Sdk.OrganizationRequest .");
  }

  if ((successCallBack != null) && (typeof successCallBack != "function")) {
   throw new Error("Sdk.Async.execute successCallBack parameter must be null or a function.");
  }

  if ((errorCallBack != null) && (typeof errorCallBack != "function")) {
   throw new Error("Sdk.Async.execute errorCallBack parameter must be null or a function.");
  }

  var executeXml = [
Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
    "<d:Execute>",
     request.getRequestXml(),
    "</d:Execute>",
  "</s:Body>",
"</s:Envelope>"].join("");

  var req = Sdk.Util.getXMLHttpRequest("Execute", true)
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     if (successCallBack) {
      var doc = this.responseXML;
      Sdk.Xml.setSelectionNamespaces(doc);
      successCallBack(new request.getResponseType()(doc), passThruObj);
     }
    }
    else {
     if (errorCallBack) {
      errorCallBack(Sdk.Util.getError(this), passThruObj);
     }
    }
   }
  };

  req.send(executeXml);
  req = null;
 };
 this.retrieve = function (entityName, id, columnSet, successCallBack, errorCallBack, passThruObj) {
  ///<summary>
  /// Retrieves an entity instance
  ///</summary>
  ///<param name="entityName" type="String" optional="false">
  /// The logical name of the entity to retrieve
  ///</param>
  ///<param name="id" type="String" optional="false">
  /// The id of the entity to retrieve
  ///</param>
  ///<param name="columnSet" type="Sdk.ColumnSet" optional="false">
  /// The columns of the entity to retrieve
  ///</param>
  ///<param name="successCallBack" type="Function" optional="false">
  /// The function to call if the operation is successful. This function should accept an Sdk.Entity as the first parameter.
  ///</param>
  ///<param name="errorCallBack" type="Function" optional="true">
  /// The function to call if the operation is unsuccessful. This function should accept an Error object as the first parameter.
  ///</param>
  ///<param name="passThruObj" type="Object" optional="true">
  /// An optional parameter to pass through to the successCallBack or errorCallBack as the second parameter
  ///</param>
  if (typeof entityName != "string") {
   throw new Error("Sdk.Async.retrieve entityName parameter is required and must be a string.");
  }
  if (id == null || !(Sdk.Util.isGuidOrNull(id))) {
   throw new Error("Sdk.Async.retrieve id parameter is required and must be a string representation of a GUID.");
  }
  if (!(columnSet instanceof Sdk.ColumnSet)) {
   throw new Error("Sdk.Async.retrieve columnSet parameter is required and must be a Sdk.ColumnSet.");
  }
  if (typeof successCallBack != "function") {
   throw new Error("Sdk.Async.retrieve successCallBack parameter must be null or a function.");
  }
  if ((errorCallBack != null) && (typeof errorCallBack != "function")) {
   throw new Error("Sdk.Async.retrieve errorCallBack parameter must be null or a function.");
  }

  var requestXml = [
 Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
    "<d:Retrieve>",
      "<d:entityName>", entityName, "</d:entityName>",
      "<d:id>", id, "</d:id>",
      columnSet.toXml(),
    "</d:Retrieve>",
  "</s:Body>",
"</s:Envelope>"].join("");

  var req = Sdk.Util.getXMLHttpRequest("Retrieve", true)
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     var doc = this.responseXML;
     Sdk.Xml.setSelectionNamespaces(doc);
     var entity = Sdk.Util.createEntityFromNode(Sdk.Xml.selectSingleNode(doc, "s:Envelope/s:Body/d:RetrieveResponse/d:RetrieveResult"));
     if (successCallBack) {
      successCallBack(entity, passThruObj);
     }
    }
    else {
     if (errorCallBack) {
      errorCallBack(Sdk.Util.getError(this), passThruObj);
     }
    }
   }
  };
  req.send(requestXml);
  req = null;
 }
 this.retrieveMultiple = function (query, successCallBack, errorCallBack, passThruObj) {
  ///<summary>
  /// Retrieves the results of a query
  ///</summary>
  ///<param name="query" type="Sdk.Query.QueryBase">
  /// Either an Sdk.Query.FetchExpression, Sdk.Query.QueryByAttribute, or Sdk.Query.QueryExpression query
  ///</param>
  ///<param name="successCallBack" type="Function" optional="false">
  /// The function to call if the operation is successful. This function should accept an Sdk.EntityCollection as the first parameter.
  ///</param>
  ///<param name="errorCallBack" type="Function" optional="true">
  /// The function to call if the operation is unsuccessful. This function should accept an Error object as the first parameter.
  ///</param>
  ///<param name="passThruObj" type="Object" optional="true">
  /// An optional parameter to pass through to the successCallBack or errorCallBack as the second parameter
  ///</param>
  var _queryType = null;

  if (query instanceof Sdk.Query.QueryBase) {
   if (query instanceof Sdk.Query.FetchExpression) {
    _queryType = "FetchExpression";
   }
   if (query instanceof Sdk.Query.QueryExpression) {
    _queryType = "QueryExpression";
   }
   if (query instanceof Sdk.Query.QueryByAttribute) {
    _queryType = "QueryByAttribute";
   }
  }
  else {
   throw new Error("Sdk.Async.retrieveMultiple constructor query parameter is required and must be either an Sdk.Query.FetchExpression, Sdk.Query.QueryByAttribute, or an Sdk.Query.QueryExpression.")
  }

  if (typeof successCallBack != "function") {
   throw new Error("Sdk.Async.retrieveMultiple successCallBack parameter must be null or a Function.");
  }
  if ((errorCallBack != null) && (typeof errorCallBack != "function")) {
   throw new Error("Sdk.Async.retrieveMultiple errorCallBack parameter must be null or a Function.");
  }

  var requestXml = [Sdk.Xml.getEnvelopeHeader(),
    "<s:Body>",
    "<d:RetrieveMultiple>",
     "<d:query i:type=\"a:", _queryType, "\">",
       query.toValueXml(),
     "</d:query>",
    "</d:RetrieveMultiple>",
   "</s:Body>",
  "</s:Envelope>"].join("");

  var req = Sdk.Util.getXMLHttpRequest("RetrieveMultiple", true);
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     var doc = this.responseXML;
     Sdk.Xml.setSelectionNamespaces(doc);
     var ec = Sdk.Util.createEntityCollectionFromNode(Sdk.Xml.selectSingleNode(doc, "s:Envelope/s:Body/d:RetrieveMultipleResponse/d:RetrieveMultipleResult"));
     if (successCallBack) {
      successCallBack(ec, passThruObj);
     }
    }
    else {
     if (errorCallBack) {
      errorCallBack(Sdk.Util.getError(this), passThruObj);
     }
    }
   }
  };
  req.send(requestXml);
  req = null;

 }
 this.update = function (entity, successCallBack, errorCallBack, passThruObj) {
  ///<summary>
  /// Updates an entity instance
  ///</summary>
  ///<param name="entity" type="Sdk.Entity" optional="false">
  /// An entity instance to update
  ///</param>
  ///<param name="successCallBack" type="Function" optional="true">
  /// The function to call if the operation is successful. Boolean parameter is passed to indicate if any values were changed and saved.
  ///</param>
  ///<param name="errorCallBack" type="Function" optional="true">
  /// The function to call if the operation is unsuccessful. This function should accept an Error object as the first parameter.
  ///</param>
  ///<param name="passThruObj" type="Object" optional="true">
  /// An optional parameter to pass through as the second parameter to the successCallBack or the errorCallBack
  ///</param>
  if (!(entity instanceof Sdk.Entity)) {
   throw new Error("Sdk.Async.update entity parameter is required and must be an Sdk.Entity instance");
  }

  if ((successCallBack != null) && (typeof successCallBack != "function")) {
   throw new Error("Sdk.Async.update successCallBack parameter must be null or a function.");
  }

  if ((errorCallBack != null) && (typeof errorCallBack != "function")) {
   throw new Error("Sdk.Async.update errorCallBack parameter must be null or a function.");
  }
  //Don't apply the update if nothing has changed
  if (!entity.getIsChanged()) {
   successCallBack(false, passThruObj);
  }
  else {
   var requestXml = [
  Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
    "<d:Update>",
     entity.toXml("update"),
    "</d:Update>",
   "</s:Body>",
  "</s:Envelope>"].join("");

   var req = Sdk.Util.getXMLHttpRequest("Update", true);
   req.onreadystatechange = function () {
    if (this.readyState == 4) {
     this.onreadystatechange = null;
     if (this.status == 200) {
      //Set entity children so that they won't get saved again.
      entity.setIsChanged(false);
      if (successCallBack) {
       successCallBack(true, passThruObj);
      }
     }
     else {
      if (errorCallBack) {
       errorCallBack(Sdk.Util.getError(this), passThruObj);
      }
     }
    }
   };
   req.send(requestXml);
   req = null;
  }
 }
}).call(Sdk.Async);

(function ()
{
 
 this.associate = function (entityName, entityId, relationship, relatedEntities) {
  ///<summary>
  /// Creates a link between records. 
  ///</summary>
  ///<param name="entityName" type="String" optional='false' mayBeNull='false'>
  /// The logical name of the entity that is specified in the entityId parameter.
  ///</param>
  ///<param name="entityId" type="String" optional='false' mayBeNull='false'>
  /// The ID of the record to which the related records are associated.
  ///</param>
  ///<param name="relationship" type="String" optional='false' mayBeNull='false'>
  /// The name of the relationship to be used to create the link. 
  ///</param>
  ///<param name="relatedEntities" type="Sdk.Collection" optional='false' mayBeNull='false'>
  /// A collection of Sdk.EntityReference objects to be associated.
  ///</param>
  if (typeof entityName != "string") {
   throw new Error("Sdk.jQ.associate entityName parameter is required and must be a String.");
  }
  if (typeof entityId != "string" || (!Sdk.Util.isGuidOrNull(entityId))) {
   throw new Error("Sdk.jQ.associate entityId parameter is required and must be an string representation of a GUID value.");
  }
  if (typeof relationship != "string") {
   throw new Error("Sdk.jQ.associate relationship parameter is required and must be a String.");
  }
  if (!(relatedEntities instanceof Sdk.Collection)) {
   throw new Error("Sdk.jQ.associate relatedEntities parameter is required and must be an Sdk.Collection.");
  }
  if (relatedEntities.getCount() <= 0) {
   throw new Error("Sdk.jQ.associate relatedEntities parameter must contain entity references to associate.");
  }
  relatedEntities.forEach(function (er, i) {
   if (!(er instanceof Sdk.EntityReference)) {
    throw new Error("Sdk.jQ.associate relatedEntities parameter must contain only Sdk.EntityReference objects.");
   }
  });

  var relatedEntitiesXml = [];

  relatedEntities.forEach(function (er, i) {
   relatedEntitiesXml.push(er.toXml());
  });

  var requestXml = [
   Sdk.Xml.getEnvelopeHeader(),
    "<s:Body>",
     "<d:Associate>",
      "<d:entityName>", entityName.toLowerCase(), "</d:entityName>",
      "<d:entityId>", entityId, "</d:entityId>",
      "<d:relationship>",
       "<a:PrimaryEntityRole i:nil=\"true\" />",
       "<a:SchemaName>", relationship, "</a:SchemaName>",
      "</d:relationship>",
      "<d:relatedEntities>",
       relatedEntitiesXml.join(""),
      "</d:relatedEntities>",
     "</d:Associate>",
    "</s:Body>",
   "</s:Envelope>"].join("");

  checkForjQuery("associate");
  var deferred = _jq.Deferred();

  var req = Sdk.Util.getXMLHttpRequest("Associate", true);
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     deferred.resolve();
    }
    else {
     deferred.reject(Sdk.Util.getError(this));
    }
   }
  };
  req.send(requestXml);
  req = null;
  return deferred.promise();
 }
 this.create = function (entity) {
  ///<summary>
  /// Creates an entity record
  ///</summary>
  ///<param name="entity" type="Sdk.Entity" optional="false">
  /// An entity instance
  ///</param>
  ///<returns type="String" >
  /// A string representation of the GUID value that is the Id of the created entity.
  ///</returns>
  if (!(entity instanceof Sdk.Entity)) {
   throw new Error("Sdk.jQ.create entity parameter is required and must be an Sdk.Entity instance");
  }
  var requestXml = [
 Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
   "<d:Create>",
     entity.toXml("create"),
   "</d:Create>",
  "</s:Body>",
 "</s:Envelope>"].join("");

  checkForjQuery("create");
  var deferred = _jq.Deferred();

  var req = Sdk.Util.getXMLHttpRequest("Create", true);

  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     var doc = this.responseXML;
     Sdk.Xml.setSelectionNamespaces(doc);
     var id = Sdk.Xml.selectSingleNodeText(doc, "s:Envelope/s:Body/d:CreateResponse/d:CreateResult")
     entity.setId(id, true);
     //Set entity children so that they won't get saved again.
     entity.setIsChanged(false);
     deferred.resolve(id);
    }
    else {
     deferred.reject(Sdk.Util.getError(this))
    }
   }
  };
  req.send(requestXml);
  req = null;
  return deferred.promise();
 }
 this.del = function (entityName, id) {
  ///<summary>
  /// Deletes an entity record
  ///</summary>
  ///<param name="entityName" type="String" optional="false">
  /// The LogicalName of the entity to delete
  ///</param>
  ///<param name="id" type="String" optional="false">
  /// An ID of the record to delete
  ///</param>
  if (typeof entityName != "string") {
   throw new Error("Sdk.jQ.del entityName parameter is required and must be a String.");
  }
  if (typeof id != "string" || (!Sdk.Util.isGuidOrNull(id))) {
   throw new Error("Sdk.jQ.del id is required and must be a string representation of a GUID value.");
  }
  var requestXml = [
  Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
   "<d:Delete>",
    "<d:entityName>", entityName, "</d:entityName>",
    "<d:id>", id, "</d:id>",
   "</d:Delete>",
  "</s:Body>",
 "</s:Envelope>"].join("");

  checkForjQuery("delete");
  var deferred = _jq.Deferred();

  var req = Sdk.Util.getXMLHttpRequest("Delete", true);
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     deferred.resolve();
    }
    else {
     deferred.reject(Sdk.Util.getError(this));
    }
   }
  };
  req.send(requestXml);
  req = null;
  return deferred.promise();
 }
 this.disassociate = function (entityName, entityId, relationship, relatedEntities) {
  ///<summary>
  /// Removes a link between records. 
  ///</summary>
  ///<param name="entityName" type="String" optional='false' mayBeNull='false'>
  /// The logical name of the entity that is specified in the entityId parameter.
  ///</param>
  ///<param name="entityId" type="string" optional='false' mayBeNull='false'>
  /// The ID of the record to which the related records are disassociated.
  ///</param>
  ///<param name="relationship" type="String" optional='false' mayBeNull='false'>
  /// The name of the relationship to be used to remove the link. 
  ///</param>
  ///<param name="relatedEntities" type="Sdk.Collection" optional='false' mayBeNull='false'>
  /// A collection of Sdk.EntityReference objects to be disassociated.
  ///</param>

  if (typeof entityName != "string") {
   throw new Error("Sdk.jQ.disassociate entityName parameter is required and must be a String.");
  }
  if (typeof entityId != "string" || (!Sdk.Util.isGuidOrNull(entityId))) {
   throw new Error("Sdk.jQ.disassociate entityId parameter is required and must be an string representation of a GUID value.");
  }
  if (typeof relationship != "string") {
   throw new Error("Sdk.jQ.disassociate relationship parameter is required and must be a String.");
  }
  if (!(relatedEntities instanceof Sdk.Collection)) {
   throw new Error("Sdk.jQ.disassociate relatedEntities parameter is required and must be an Sdk.Collection.");
  }
  if (relatedEntities.getCount() <= 0) {
   throw new Error("Sdk.jQ.disassociate relatedEntities parameter must contain entity references to Dissassociate.");
  }
  relatedEntities.forEach(function (er, i) {
   if (!(er instanceof Sdk.EntityReference)) {
    throw new Error("Sdk.jQ.disassociate relatedEntities parameter must contain only Sdk.EntityReference objects.");
   }
  });

  var relatedEntitiesXml = [];
  relatedEntities.forEach(function (er, i) {
   relatedEntitiesXml.push(er.toXml());
  });

  var requestXml = [
  Sdk.Xml.getEnvelopeHeader(),
    "<s:Body>",
     "<d:Disassociate>",
      "<d:entityName>", entityName.toLowerCase(), "</d:entityName>",
      "<d:entityId>", entityId, "</d:entityId>",
      "<d:relationship>",
       "<a:PrimaryEntityRole i:nil=\"true\" />",
       "<a:SchemaName>", relationship, "</a:SchemaName>",
      "</d:relationship>",
      "<d:relatedEntities>",
        relatedEntitiesXml.join(""),
      "</d:relatedEntities>",
     "</d:Disassociate>",
    "</s:Body>",
   "</s:Envelope>"].join("");

  checkForjQuery("disassociate");
  var deferred = _jq.Deferred();

  var req = Sdk.Util.getXMLHttpRequest("Disassociate", true);
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     deferred.resolve();
    }
    else {
     deferred.reject(Sdk.Util.getError(this));
    }
   }
  };
  req.send(requestXml);
  req = null;
  return deferred.promise();
 }
 this.execute = function (request) {
  ///<summary>
  /// Executes a SOAP Request using the SOAPAction Execute
  ///</summary>
  ///<param name="request" type="Sdk.OrganizationRequest">
  /// Required. A request object
  ///</param>
  if (!(request instanceof Sdk.OrganizationRequest)) {
   throw new Error("Sdk.jQ.execute request parameter must be an Sdk.OrganizationRequest .");
  }
  var executeXml = [
 Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
   "<d:Execute>",
  request.getRequestXml(),
   "</d:Execute>",
  "</s:Body>",
 "</s:Envelope>"].join("");

  checkForjQuery("execute");
  var deferred = _jq.Deferred();
  var req = Sdk.Util.getXMLHttpRequest("Execute", true);
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     var doc = this.responseXML;
     Sdk.Xml.setSelectionNamespaces(doc);
     deferred.resolve(new request.getResponseType()(doc));
    }
    else {
     deferred.reject(Sdk.Util.getError(this));
    }
   }
  };
  req.send(executeXml);
  req = null;
  return deferred.promise();
 };
 this.retrieve = function (entityName, id, columnSet) {
  ///<summary>
  /// Retrieves an entity instance
  ///</summary>
  ///<param name="entityName" type="String" optional="false">
  /// The logical name of the entity to retrieve
  ///</param>
  ///<param name="id" type="String" optional="false">
  /// The id of the entity to retrieve
  ///</param>
  ///<param name="columnSet" type="Sdk.ColumnSet" optional="false">
  /// The columns of the entities to retrieve
  ///</param>
  if (typeof entityName != "string") {
   throw new Error("Sdk.jQ.retrieve entityName parameter is required and must be a string.");
  }
  if (id == null || !(Sdk.Util.isGuidOrNull(id))) {
   throw new Error("Sdk.jQ.retrieve id parameter is required and must be a string representation of a GUID.");
  }
  if (!(columnSet instanceof Sdk.ColumnSet)) {
   throw new Error("Sdk.jQ.retrieve columnSet parameter is required and must be a Sdk.ColumnSet.");
  }
  var requestXml = [
 Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
   "<d:Retrieve>",
    "<d:entityName>", entityName, "</d:entityName>",
    "<d:id>", id, "</d:id>",
    columnSet.toXml(),
   "</d:Retrieve>",
  "</s:Body>",
 "</s:Envelope>"].join("");

  checkForjQuery("retrieve");
  var deferred = _jq.Deferred();

  var req = Sdk.Util.getXMLHttpRequest("Retrieve", true);
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     var doc = this.responseXML;
     Sdk.Xml.setSelectionNamespaces(doc);
     var entity = Sdk.Util.createEntityFromNode(Sdk.Xml.selectSingleNode(doc, "s:Envelope/s:Body/d:RetrieveResponse/d:RetrieveResult"));
     deferred.resolve(entity);
    }
    else {
     deferred.reject(Sdk.Util.getError(this));
    }
   }
  };
  req.send(requestXml);
  req = null;
  return deferred.promise();
 }
 this.retrieveMultiple = function (query) {
  ///<summary>
  /// Retrieves the results of a query
  ///</summary>
  ///<param name="query" type="Sdk.Query.QueryBase">
  /// Either an Sdk.Query.FetchExpression or Sdk.Query.QueryExpression query
  ///</param>
  var _queryType = null;

  if (query instanceof Sdk.Query.QueryBase) {
   if (query instanceof Sdk.Query.FetchExpression) {
    _queryType = "FetchExpression";
   }
   if (query instanceof Sdk.Query.QueryExpression) {
    _queryType = "QueryExpression";
   }
   if (query instanceof Sdk.Query.QueryByAttribute) {
    _queryType = "QueryByAttribute";
   }
  }
  else {
   throw new Error("Sdk.jQ.retrieveMultiple constructor query parameter is required and must be either an Sdk.Query.FetchExpression, Sdk.Query.QueryByAttribute, or an Sdk.Query.QueryExpression.")
  }

  var requestXml = [Sdk.Xml.getEnvelopeHeader(),
    "<s:Body>",
    "<d:RetrieveMultiple>",
     "<d:query i:type=\"a:", _queryType, "\">",
       query.toValueXml(),
     "</d:query>",
    "</d:RetrieveMultiple>",
   "</s:Body>",
  "</s:Envelope>"].join("");

  checkForjQuery("retrieveMultiple");
  var deferred = _jq.Deferred();
  var req = Sdk.Util.getXMLHttpRequest("RetrieveMultiple", true);
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     var doc = this.responseXML;
     Sdk.Xml.setSelectionNamespaces(doc);
     var ec = Sdk.Util.createEntityCollectionFromNode(Sdk.Xml.selectSingleNode(doc, "s:Envelope/s:Body/d:RetrieveMultipleResponse/d:RetrieveMultipleResult"));
     deferred.resolve(ec);
    }
    else {
     deferred.reject(Sdk.Util.getError(this));
    }
   }
  };
  req.send(requestXml);
  req = null;
  return deferred.promise();
 }
 this.setJQueryVariable = function (jQueryReference) {
  ///<summary>
  /// Sets the global jQuery variable to use
  ///</summary>
  ///<param name="jQueryReference" type="jQuery">
  /// A reference to the global jQuery instance
  ///</param>
  if (typeof jQueryReference.support != "undefined")
  { _jq = jQueryReference; }
  else
  { throw new Error("The variable passed to Sdk.jQ.setJQueryVariable is not a valid global jQuery object."); }
 }
 this.update = function (entity) {
  ///<summary>
  /// Updates an entity instance
  ///</summary>
  ///<param name="entity" type="Sdk.Entity" optional="false">
  /// An entity instance to update
  ///</param>
  if (!(entity instanceof Sdk.Entity)) {
   throw new Error("Sdk.jQ.update entity parameter is required and must be an Sdk.Entity instance");
  }
  checkForjQuery("update");
  var deferred = _jq.Deferred();
  //Don't apply the update if nothing has changed
  if (!entity.getIsChanged()) {
   deferred.resolve(false);
   return deferred.promise();
  }
  else {
   var requestXml = [
Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
   "<d:Update>",
      entity.toXml("update"),
   "</d:Update>",
  "</s:Body>",
 "</s:Envelope>"].join("");

   var req = Sdk.Util.getXMLHttpRequest("Update", true);

   req.onreadystatechange = function () {
    if (this.readyState == 4) {
     this.onreadystatechange = null;
     if (this.status == 200) {
      //Set entity children so that they won't get saved again.
      entity.setIsChanged(false);
      deferred.resolve(true);
     }
     else {
      deferred.reject(Sdk.Util.getError(this));
     }
    }
   };
   req.send(requestXml);
   req = null;
   return deferred.promise();
  }
 }
 function checkForjQuery(methodName) {
  if (typeof _jq == "undefined") {
   throw new Error(Sdk.Util.format("Sdk.jQ.{0} requires a specific jQuery variable set using Sdk.jQ.setJQueryVariable.", [methodName]));
  }
 }
 var _jq;

}).call(Sdk.jQ);

(function () {
 
 this.associate = function (entityName, entityId, relationship, relatedEntities) {
  ///<summary>
  /// Creates a link between records. 
  ///</summary>
  ///<param name="entityName" type="String" optional='false' mayBeNull='false'>
  /// The logical name of the entity that is specified in the entityId parameter.
  ///</param>
  ///<param name="entityId" type="String" optional='false' mayBeNull='false'>
  /// The ID of the record to which the related records are associated.
  ///</param>
  ///<param name="relationship" type="String" optional='false' mayBeNull='false'>
  /// The name of the relationship to be used to create the link. 
  ///</param>
  ///<param name="relatedEntities" type="Sdk.Collection" optional='false' mayBeNull='false'>
  /// A collection of Sdk.EntityReference objects to be associated.
  ///</param>
  if (typeof entityName != "string") {
   throw new Error("Sdk.Q.associate entityName parameter is required and must be a String.");
  }
  if (typeof entityId != "string" || (!Sdk.Util.isGuidOrNull(entityId))) {
   throw new Error("Sdk.Q.associate entityId parameter is required and must be an string representation of a GUID value.");
  }
  if (typeof relationship != "string") {
   throw new Error("Sdk.Q.associate relationship parameter is required and must be a String.");
  }
  if (!(relatedEntities instanceof Sdk.Collection)) {
   throw new Error("Sdk.Q.associate relatedEntities parameter is required and must be an Sdk.Collection.");
  }
  if (relatedEntities.getCount() <= 0) {
   throw new Error("Sdk.Q.associate relatedEntities parameter must contain entity references to associate.");
  }
  relatedEntities.forEach(function (er, i) {
   if (!(er instanceof Sdk.EntityReference)) {
    throw new Error("Sdk.Q.associate relatedEntities parameter must contain only Sdk.EntityReference objects.");
   }
  });

  var relatedEntitiesXml = [];
  relatedEntities.forEach(function (er, i) {
   relatedEntitiesXml.push(er.toXml());
  });


  var requestXml = [
   Sdk.Xml.getEnvelopeHeader(),
    "<s:Body>",
     "<d:Associate>",
      "<d:entityName>", entityName.toLowerCase(), "</d:entityName>",
      "<d:entityId>", entityId, "</d:entityId>",
      "<d:relationship>",
       "<a:PrimaryEntityRole i:nil=\"true\" />",
       "<a:SchemaName>", relationship, "</a:SchemaName>",
      "</d:relationship>",
      "<d:relatedEntities>",
       relatedEntitiesXml.join(""),
      "</d:relatedEntities>",
     "</d:Associate>",
    "</s:Body>",
   "</s:Envelope>"].join("");

  checkForQ("associate");
  var deferred = Q.defer();
  var req = Sdk.Util.getXMLHttpRequest("Associate", true);

  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     deferred.resolve();
    }
    else {
     deferred.reject(Sdk.Util.getError(this));
    }
   }
  };
  req.send(requestXml);
  req = null;
  return deferred.promise;
 }
 this.create = function (entity) {
  ///<summary>
  /// Creates an entity record
  ///</summary>
  ///<param name="entity" type="Sdk.Entity" optional="false">
  /// An entity instance
  ///</param>
  ///<returns type="String" >
  /// A string representation of the GUID value that is the Id of the created entity.
  ///</returns>
  if (!(entity instanceof Sdk.Entity)) {
   throw new Error("Sdk.Q.create entity parameter is required and must be an Sdk.Entity instance");
  }
  var requestXml = [
  Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
   "<d:Create>",
     entity.toXml("create"),
   "</d:Create>",
  "</s:Body>",
 "</s:Envelope>"].join("");

  checkForQ("create");
  var deferred = Q.defer();
  var req = Sdk.Util.getXMLHttpRequest("Create", true);

  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     var doc = this.responseXML;
     Sdk.Xml.setSelectionNamespaces(doc);
     var id = Sdk.Xml.selectSingleNodeText(doc, "s:Envelope/s:Body/d:CreateResponse/d:CreateResult")
     entity.setId(id, true);
     //Set entity children so that they won't get saved again.
     entity.setIsChanged(false);
     deferred.resolve(id);
    }
    else {
     deferred.reject(Sdk.Util.getError(this))
    }
   }
  };
  req.send(requestXml);
  req = null;
  return deferred.promise;
 }
 this.del = function (entityName, id) {
  ///<summary>
  /// Deletes an entity record
  ///</summary>
  ///<param name="entityName" type="String" optional="false">
  /// The LogicalName of the entity to delete
  ///</param>
  ///<param name="id" type="String" optional="false">
  /// An ID of the record to delete
  ///</param>
  if (typeof entityName != "string") {
   throw new Error("Sdk.Q.del entityName parameter is required and must be a String.");
  }
  if (typeof id != "string" || (!Sdk.Util.isGuidOrNull(id))) {
   throw new Error("Sdk.Q.del id is required and must be a string representation of a GUID value.");
  }
  var requestXml = [
  Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
    "<d:Delete>",
      "<d:entityName>", entityName, "</d:entityName>",
      "<d:id>", id, "</d:id>",
    "</d:Delete>",
  "</s:Body>",
"</s:Envelope>"].join("");

  checkForQ("delete");
  var deferred = Q.defer();

  var req = Sdk.Util.getXMLHttpRequest("Delete", true);

  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     deferred.resolve();
    }
    else {
     deferred.reject(Sdk.Util.getError(this));
    }
   }
  };
  req.send(requestXml);
  req = null;
  return deferred.promise;
 }
 this.disassociate = function (entityName, entityId, relationship, relatedEntities) {
  ///<summary>
  /// Removes a link between records. 
  ///</summary>
  ///<param name="entityName" type="String" optional='false' mayBeNull='false'>
  /// The logical name of the entity that is specified in the entityId parameter.
  ///</param>
  ///<param name="entityId" type="string" optional='false' mayBeNull='false'>
  /// The ID of the record to which the related records are disassociated.
  ///</param>
  ///<param name="relationship" type="String" optional='false' mayBeNull='false'>
  /// The name of the relationship to be used to remove the link. 
  ///</param>
  ///<param name="relatedEntities" type="Sdk.Collection" optional='false' mayBeNull='false'>
  /// A collection of Sdk.EntityReference objects to be disassociated.
  ///</param>

  if (typeof entityName != "string") {
   throw new Error("Sdk.Q.disassociate entityName parameter is required and must be a String.");
  }
  if (typeof entityId != "string" || (!Sdk.Util.isGuidOrNull(entityId))) {
   throw new Error("Sdk.Q.disassociate entityId parameter is required and must be an string representation of a GUID value.");
  }
  if (typeof relationship != "string") {
   throw new Error("Sdk.Q.disassociate relationship parameter is required and must be a String.");
  }
  if (!(relatedEntities instanceof Sdk.Collection)) {
   throw new Error("Sdk.Q.disassociate relatedEntities parameter is required and must be an Sdk.Collection.");
  }
  if (relatedEntities.getCount() <= 0) {
   throw new Error("Sdk.Q.disassociate relatedEntities parameter must contain entity references to Dissassociate.");
  }
  relatedEntities.forEach(function (er, i) {
   if (!(er instanceof Sdk.EntityReference)) {
    throw new Error("Sdk.Q.disassociate relatedEntities parameter must contain only Sdk.EntityReference objects.");
   }
  });

  var relatedEntitiesXml = [];
  relatedEntities.forEach(function (er, i) {
   relatedEntitiesXml.push(er.toXml());
  });

  var requestXml = [
  Sdk.Xml.getEnvelopeHeader(),
    "<s:Body>",
     "<d:Disassociate>",
      "<d:entityName>", entityName.toLowerCase(), "</d:entityName>",
      "<d:entityId>", entityId, "</d:entityId>",
      "<d:relationship>",
       "<a:PrimaryEntityRole i:nil=\"true\" />",
       "<a:SchemaName>", relationship, "</a:SchemaName>",
      "</d:relationship>",
      "<d:relatedEntities>",
       relatedEntitiesXml.join(""),
      "</d:relatedEntities>",
     "</d:Disassociate>",
    "</s:Body>",
   "</s:Envelope>"].join("");

  checkForQ("disassociate");
  var deferred = Q.defer();

  var req = Sdk.Util.getXMLHttpRequest("Disassociate", true);
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     deferred.resolve();
    }
    else {
     deferred.reject(Sdk.Util.getError(this));
    }
   }
  };
  req.send(requestXml);
  req = null;
  return deferred.promise;
 }
 this.execute = function (request) {
  ///<summary>
  /// Executes a SOAP Request using the SOAPAction Execute
  ///</summary>
  ///<param name="request" type="Sdk.OrganizationRequest">
  /// Required. A request object
  ///</param>
  if (!(request instanceof Sdk.OrganizationRequest)) {
   throw new Error("Sdk.Q.execute request parameter must be an Sdk.OrganizationRequest.");
  }
  var executeXml = [
 Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
   "<d:Execute>",
    request.getRequestXml(),
   "</d:Execute>",
  "</s:Body>",
 "</s:Envelope>"].join("");

  checkForQ("execute");
  var deferred = Q.defer();

  var req = Sdk.Util.getXMLHttpRequest("Execute", true);

  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     var doc = this.responseXML;
     Sdk.Xml.setSelectionNamespaces(doc);
     deferred.resolve(new request.getResponseType()(doc));
    }
    else {
     deferred.reject(Sdk.Util.getError(this));
    }
   }
  };
  req.send(executeXml);
  req = null;
  return deferred.promise;
 };
 this.retrieve = function (entityName, id, columnSet) {
  ///<summary>
  /// Retrieves an entity instance
  ///</summary>
  ///<param name="entityName" type="String" optional="false">
  /// The logical name of the entity to retrieve
  ///</param>
  ///<param name="id" type="String" optional="false">
  /// The id of the entity to retrieve
  ///</param>
  ///<param name="columnSet" type="Sdk.ColumnSet" optional="false">
  /// The columns of the entities to retrieve
  ///</param>
  if (typeof entityName != "string") {
   throw new Error("Sdk.Q.retrieve entityName parameter is required and must be a string.");
  }
  if (id == null || !(Sdk.Util.isGuidOrNull(id))) {
   throw new Error("Sdk.Q.retrieve id parameter is required and must be a string representation of a GUID.");
  }
  if (!(columnSet instanceof Sdk.ColumnSet)) {
   throw new Error("Sdk.Q.retrieve columnSet parameter is required and must be a Sdk.ColumnSet.");
  }
  var requestXml = [
 Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
   "<d:Retrieve>",
    "<d:entityName>", entityName, "</d:entityName>",
    "<d:id>", id, "</d:id>",
    columnSet.toXml(),
   "</d:Retrieve>",
  "</s:Body>",
 "</s:Envelope>"].join("");

  checkForQ("retrieve");
  var deferred = Q.defer();
  var req = Sdk.Util.getXMLHttpRequest("Retrieve", true);
  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     var doc = this.responseXML;
     Sdk.Xml.setSelectionNamespaces(doc);
     var entity = Sdk.Util.createEntityFromNode(Sdk.Xml.selectSingleNode(doc, "s:Envelope/s:Body/d:RetrieveResponse/d:RetrieveResult"));
     deferred.resolve(entity);
    }
    else {
     deferred.reject(Sdk.Util.getError(this));
    }
   }
  };
  req.send(requestXml);
  req = null;
  return deferred.promise;
 }
 this.retrieveMultiple = function (query) {
  ///<summary>
  /// Retrieves the results of a query
  ///</summary>
  ///<param name="query" type="Sdk.Query.QueryBase">
  /// Either an Sdk.Query.FetchExpression or Sdk.Query.QueryExpression query
  ///</param>
  var _queryType = null;

  if (query instanceof Sdk.Query.QueryBase) {
   if (query instanceof Sdk.Query.FetchExpression) {
    _queryType = "FetchExpression";
   }
   if (query instanceof Sdk.Query.QueryExpression) {
    _queryType = "QueryExpression";
   }
   if (query instanceof Sdk.Query.QueryByAttribute) {
    _queryType = "QueryByAttribute";
   }
  }
  else {
   throw new Error("Sdk.Q.retrieveMultiple constructor query parameter is required and must be either an Sdk.Query.FetchExpression, Sdk.Query.QueryByAttribute, or an Sdk.Query.QueryExpression.")
  }

  var requestXml = [
   Sdk.Xml.getEnvelopeHeader(),
    "<s:Body>",
    "<d:RetrieveMultiple>",
     "<d:query i:type=\"a:", _queryType, "\">",
       query.toValueXml(),
     "</d:query>",
    "</d:RetrieveMultiple>",
   "</s:Body>",
  "</s:Envelope>"].join("");
  checkForQ("retrieveMultiple");
  var deferred = Q.defer();

  var req = Sdk.Util.getXMLHttpRequest("RetrieveMultiple", true);

  req.onreadystatechange = function () {
   if (this.readyState == 4) {
    this.onreadystatechange = null;
    if (this.status == 200) {
     var doc = this.responseXML;
     Sdk.Xml.setSelectionNamespaces(doc);
     var ec = Sdk.Util.createEntityCollectionFromNode(Sdk.Xml.selectSingleNode(doc, "s:Envelope/s:Body/d:RetrieveMultipleResponse/d:RetrieveMultipleResult"));
     deferred.resolve(ec);
    }
    else {
     deferred.reject(Sdk.Util.getError(this));
    }
   }
  };
  req.send(requestXml);
  req = null;
  return deferred.promise;
 }
 this.update = function (entity) {
  ///<summary>
  /// Updates an entity instance
  ///</summary>
  ///<param name="entity" type="Sdk.Entity" optional="false">
  /// An entity instance to update
  ///</param>
  if (!(entity instanceof Sdk.Entity)) {
   throw new Error("Sdk.Q.update entity parameter is required and must be an Sdk.Entity instance");
  }
  checkForQ("update");
  var deferred = Q.defer();
  //Don't apply the update if nothing has changed
  if (!entity.getIsChanged()) {
   deferred.resolve(false);
   return deferred.promise;
  }
  else {
   var requestXml = [
Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
   "<d:Update>",
    entity.toXml("update"),
   "</d:Update>",
  "</s:Body>",
 "</s:Envelope>"].join("");

   var req = Sdk.Util.getXMLHttpRequest("Update", true);
   req.onreadystatechange = function () {
    if (this.readyState == 4) {
     this.onreadystatechange = null;
     if (this.status == 200) {
      //Set entity children so that they won't get saved again.
      entity.setIsChanged(false);
      deferred.resolve(true);
     }
     else {
      deferred.reject(Sdk.Util.getError(this));
     }
    }
   };
   req.send(requestXml);
   req = null;
   return deferred.promise;
  }
 }
 function checkForQ(methodName) {
  if (typeof Q == "undefined") {
   throw new Error(Sdk.Util.format("Sdk.Q.{0} requires the Q.js library to define the global Q object.", [methodName]));
  }
 }
}).call(Sdk.Q);

(function ()
{
 
 this.associate = function (entityName, entityId, relationship, relatedEntities) {
  ///<summary>
  /// Creates a link between records. 
  ///</summary>
  ///<param name="entityName" type="String" optional='false' mayBeNull='false'>
  /// The logical name of the entity that is specified in the entityId parameter.
  ///</param>
  ///<param name="entityId" type="String" optional='false' mayBeNull='false'>
  /// The ID of the record to which the related records are associated.
  ///</param>
  ///<param name="relationship" type="String" optional='false' mayBeNull='false'>
  /// The name of the relationship to be used to create the link. 
  ///</param>
  ///<param name="relatedEntities" type="Sdk.Collection" optional='false' mayBeNull='false'>
  /// A collection of Sdk.EntityReference objects to be associated.
  ///</param>

  if (typeof entityName != "string") {
   throw new Error("Sdk.Sync.associate entityName parameter is required and must be a String.");
  }
  if (typeof entityId != "string" || (!Sdk.Util.isGuidOrNull(entityId))) {
   throw new Error("Sdk.Sync.associate entityId parameter is required and must be an string representation of a GUID value.");
  }
  if (typeof relationship != "string") {
   throw new Error("Sdk.Sync.associate relationship parameter is required and must be a String.");
  }
  if (!(relatedEntities instanceof Sdk.Collection)) {
   throw new Error("Sdk.Sync.associate relatedEntities parameter is required and must be an Sdk.Collection.");
  }
  if (relatedEntities.getCount() <= 0) {
   throw new Error("Sdk.Sync.associate relatedEntities parameter must contain entity references to associate.");
  }
  relatedEntities.forEach(function (er, i) {
   if (!(er instanceof Sdk.EntityReference)) {
    throw new Error("Sdk.Sync.associate relatedEntities parameter must contain only Sdk.EntityReference objects.");
   }
  });

  var relatedEntitiesXml = [];
  relatedEntities.forEach(function (er, i) {
   relatedEntitiesXml.push(er.toXml());
  });

  var requestXml = [
   Sdk.Xml.getEnvelopeHeader(),
    "<s:Body>",
     "<d:Associate>",
      "<d:entityName>", entityName.toLowerCase(), "</d:entityName>",
      "<d:entityId>", entityId, "</d:entityId>",
      "<d:relationship>",
       "<a:PrimaryEntityRole i:nil=\"true\" />",
       "<a:SchemaName>", relationship, "</a:SchemaName>",
      "</d:relationship>",
      "<d:relatedEntities>",
       relatedEntitiesXml.join(""),
      "</d:relatedEntities>",
     "</d:Associate>",
    "</s:Body>",
   "</s:Envelope>"].join("");

  var req = Sdk.Util.getXMLHttpRequest("Associate", false);
  req.send(requestXml);
  if (req.status != 200) {
   throw new Error("Sdk.Sync.associate " + Sdk.Util.getError(req));
  }
  req = null;
 }
 this.create = function (entity) {
  ///<summary>
  /// Creates an entity record
  ///</summary>
  ///<param name="entity" type="Sdk.Entity" optional="false">
  /// An entity instance
  ///</param>
  ///<returns type="String" >
  /// A string representation of the GUID value that is the Id of the created entity.
  ///</returns>
  if (!(entity instanceof Sdk.Entity)) {
   throw new Error("Sdk.Sync.create entity parameter is required and must be an Sdk.Entity instance");
  }

  var requestXml = [
  Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
   "<d:Create>",
    entity.toXml("create"),
   "</d:Create>",
  "</s:Body>",
 "</s:Envelope>"].join("");

  var req = Sdk.Util.getXMLHttpRequest("Create", false);
  req.send(requestXml);
  if (req.status == 200) {
   var doc = req.responseXML;
   Sdk.Xml.setSelectionNamespaces(doc);
   var id = Sdk.Xml.selectSingleNodeText(doc, "s:Envelope/s:Body/d:CreateResponse/d:CreateResult")
   entity.setId(id, true);
   //Set entity children so that they won't get saved again.
   entity.setIsChanged(false);
   return id;
  }
  else {
   throw new Error("Sdk.Sync.create " + Sdk.Util.getError(req));
  }
  req = null;
 }
 this.del = function (entityName, id) {
  ///<summary>
  /// Deletes an entity record
  ///</summary>
  ///<param name="entityName" type="String" optional="false">
  /// The LogicalName of the entity to delete
  ///</param>
  ///<param name="id" type="String" optional="false">
  /// An ID of the record to delete
  ///</param>

  if (typeof entityName != "string") {
   throw new Error("Sdk.Sync.del entityName parameter is required and must be a String.");
  }
  if (typeof id != "string" || (!Sdk.Util.isGuidOrNull(id))) {
   throw new Error("Sdk.Sync.del id is required and must be a string representation of a GUID value.");
  }

  var requestXml = [
  Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
   "<d:Delete>",
    "<d:entityName>", entityName, "</d:entityName>",
    "<d:id>", id, "</d:id>",
   "</d:Delete>",
  "</s:Body>",
 "</s:Envelope>"].join("");

  var req = Sdk.Util.getXMLHttpRequest("Delete", false);
  req.send(requestXml);
  if (req.status != 200) {

   throw new Error("Sdk.Sync.del " + Sdk.Util.getError(req));
  }
  req = null;
 }
 this.disassociate = function (entityName, entityId, relationship, relatedEntities) {
  ///<summary>
  /// Removes a link between records. 
  ///</summary>
  ///<param name="entityName" type="String" optional='false' mayBeNull='false'>
  /// The logical name of the entity that is specified in the entityId parameter.
  ///</param>
  ///<param name="entityId" type="string" optional='false' mayBeNull='false'>
  /// The ID of the record to which the related records are disassociated.
  ///</param>
  ///<param name="relationship" type="String" optional='false' mayBeNull='false'>
  /// The name of the relationship to be used to remove the link. 
  ///</param>
  ///<param name="relatedEntities" type="Sdk.Collection" optional='false' mayBeNull='false'>
  /// A collection of Sdk.EntityReference objects to be disassociated.
  ///</param>

  if (typeof entityName != "string") {
   throw new Error("Sdk.Sync.disassociate entityName parameter is required and must be a String.");
  }
  if (typeof entityId != "string" || (!Sdk.Util.isGuidOrNull(entityId))) {
   throw new Error("Sdk.Sync.disassociate entityId parameter is required and must be an string representation of a GUID value.");
  }
  if (typeof relationship != "string") {
   throw new Error("Sdk.Sync.disassociate relationship parameter is required and must be a String.");
  }
  if (!(relatedEntities instanceof Sdk.Collection)) {
   throw new Error("Sdk.Sync.disassociate relatedEntities parameter is required and must be an Sdk.Collection.");
  }
  if (relatedEntities.getCount() <= 0) {
   throw new Error("Sdk.Sync.disassociate relatedEntities parameter must contain entity references to Dissassociate.");
  }
  relatedEntities.forEach(function (er, i) {
   if (!(er instanceof Sdk.EntityReference)) {
    throw new Error("Sdk.Sync.disassociate relatedEntities parameter must contain only Sdk.EntityReference objects.");
   }
  });

  var relatedEntitiesXml = [];
  relatedEntities.forEach(function (er, i) {
   relatedEntitiesXml.push(er.toXml());
  });

  var requestXml = [
  Sdk.Xml.getEnvelopeHeader(),
    "<s:Body>",
      "<d:Disassociate>",
       "<d:entityName>", entityName.toLowerCase(), "</d:entityName>",
       "<d:entityId>", entityId, "</d:entityId>",
       "<d:relationship>",
        "<a:PrimaryEntityRole i:nil=\"true\" />",
        "<a:SchemaName>", relationship, "</a:SchemaName>",
      "</d:relationship>",
      "<d:relatedEntities>",
       relatedEntitiesXml.join(""),
      "</d:relatedEntities>",
     "</d:Disassociate>",
    "</s:Body>",
   "</s:Envelope>"].join("");

  var req = Sdk.Util.getXMLHttpRequest("Disassociate", false);
  req.send(requestXml);
  if (req.status != 200) {
   throw new Error("Sdk.DisassociateSync " + Sdk.Util.getError(req));
  }
  req = null;
 }
 this.execute = function (request) {
  ///<summary>
  /// Executes a SOAP Request using the SOAPAction Execute
  ///</summary>
  ///<param name="request" type="Sdk.OrganizationRequest" optional="false" mayBeNull="false">
  /// Required. A request object
  ///</param>
  ///<returns type="Sdk.OrganizationResponse">
  /// The response to the request.
  ///</returns>
  if (!(request instanceof Sdk.OrganizationRequest)) {
   throw new Error("Sdk.Sync.execute request parameter must be an Sdk.OrganizationRequest .");
  }

  var executeXml = [
   Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
   "<d:Execute>",
    request.getRequestXml(),
   "</d:Execute>",
  "</s:Body>",
 "</s:Envelope>"].join("");

  var req = Sdk.Util.getXMLHttpRequest("Execute", false);
  req.send(executeXml);
  if (req.status == 200) {
   var doc = req.responseXML;
   Sdk.Xml.setSelectionNamespaces(doc);
   return new request.getResponseType()(doc);
  }
  else {
   throw new Error("Sdk.Sync.execute " + Sdk.Util.getError(req));
  }
  req = null;
 };
 this.retrieve = function (entityName, id, columnSet) {
  ///<summary>
  /// Retrieves an entity instance
  ///</summary>
  ///<param name="entityName" type="String" optional="false">
  /// The logical name of the entity to retrieve
  ///</param>
  ///<param name="id" type="String" optional="false">
  /// The id of the entity to retrieve
  ///</param>
  ///<param name="columnSet" type="Sdk.ColumnSet" optional="false">
  /// The columns of the entities to retrieve
  ///</param>

  if (typeof entityName != "string") {
   throw new Error("Sdk.Sync.retrieve entityName parameter is required and must be a string.");
  }
  if (id == null || !(Sdk.Util.isGuidOrNull(id))) {
   throw new Error("Sdk.Sync.retrieve id parameter is required and must be a string representation of a GUID.");
  }
  if (!(columnSet instanceof Sdk.ColumnSet)) {
   throw new Error("Sdk.Sync.retrieve columnSet parameter is required and must be a Sdk.ColumnSet.");
  }

  var requestXml = [
 Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
    "<d:Retrieve>",
      "<d:entityName>", entityName, "</d:entityName>",
      "<d:id>", id, "</d:id>",
      columnSet.toXml(),
    "</d:Retrieve>",
  "</s:Body>",
"</s:Envelope>"].join("");

  var req = Sdk.Util.getXMLHttpRequest("Retrieve", false);

  req.send(requestXml);

  if (req.status == 200) {
   var doc = req.responseXML;
   Sdk.Xml.setSelectionNamespaces(doc);
   var entity = Sdk.Util.createEntityFromNode(Sdk.Xml.selectSingleNode(doc, "s:Envelope/s:Body/d:RetrieveResponse/d:RetrieveResult"));

   return entity;
  }
  else {
   throw new Error("Sdk.Sync.retrieve" + Sdk.Util.getError(req));
  }
  req = null;
 }
 this.retrieveMultiple = function (query) {
  ///<summary>
  /// Retrieves the results of a query
  ///</summary>
  ///<param name="query" type="Sdk.Query.QueryBase">
  /// Either an Sdk.Query.FetchExpression or Sdk.Query.QueryExpression query
  ///</param>
  var _queryType = null;

  if (query instanceof Sdk.Query.QueryBase) {
   if (query instanceof Sdk.Query.FetchExpression) {
    _queryType = "FetchExpression";
   }
   if (query instanceof Sdk.Query.QueryExpression) {
    _queryType = "QueryExpression";
   }
   if (query instanceof Sdk.Query.QueryByAttribute) {
    _queryType = "QueryByAttribute";
   }
  }
  else {
   throw new Error("Sdk.Sync.retrieveMultiple constructor query parameter is required and must be either an Sdk.Query.FetchExpression, Sdk.Query.QueryByAttribute, or an Sdk.Query.QueryExpression.")
  }


  var requestXml = [
 Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
    "<d:RetrieveMultiple>",
     "<d:query i:type=\"a:", _queryType, "\">",
       query.toValueXml(),
     "</d:query>",
    "</d:RetrieveMultiple>",
   "</s:Body>",
  "</s:Envelope>"].join("");

  var req = Sdk.Util.getXMLHttpRequest("RetrieveMultiple", false);
  req.send(requestXml);

  if (req.status == 200) {
   var doc = req.responseXML;
   Sdk.Xml.setSelectionNamespaces(doc);
   var ec = Sdk.Util.createEntityCollectionFromNode(Sdk.Xml.selectSingleNode(doc, "s:Envelope/s:Body/d:RetrieveMultipleResponse/d:RetrieveMultipleResult"));
   return ec;
  }
  else {

   throw new Error("Sdk.Sync.retrieveMultiple" + Sdk.Util.getError(req));
  }
  req = null;
 }
 this.update = function (entity) {
  ///<summary>
  /// Updates an entity instance
  ///</summary>
  ///<param name="entity" type="Sdk.Entity" optional="false">
  /// An entity instance to update
  ///</param>

  if (!(entity instanceof Sdk.Entity)) {
   throw new Error("Sdk.Sync.update entity parameter is required and must be an Sdk.Entity instance");
  }

  //Don't apply the update if nothing has changed
  if (!entity.getIsChanged()) {
   return false;
  }
  else {
   var requestXml = [
Sdk.Xml.getEnvelopeHeader(),
  "<s:Body>",
   "<d:Update>",
    entity.toXml("update"),
   "</d:Update>",
  "</s:Body>",
 "</s:Envelope>"].join("");

   var req = Sdk.Util.getXMLHttpRequest("Update", false);
   req.send(requestXml);
   if (req.status == 200) {
    //Set entity children so that they won't get saved again.
    entity.setIsChanged(false);
    return true;
   }
   else {
    throw new Error("Sdk.Sync.update" + Sdk.Util.getError(req));
   }
   req = null;
  }
 }
}).call(Sdk.Sync);


//Sdk.AccessRights.prototype Start
Sdk.AccessRights.prototype = {
 None: 0,
 ReadAccess: 1,
 WriteAccess: 2,
 ShareAccess: 4,
 AssignAccess: 8,
 AppendAccess: 16,
 AppendToAccess: 32,
 CreateAccess: 64,
 DeleteAccess: 128,
 All: 255
};
Sdk.AccessRights.None = 0;
Sdk.AccessRights.ReadAccess = 1;
Sdk.AccessRights.WriteAccess = 2;
Sdk.AccessRights.ShareAccess = 4;
Sdk.AccessRights.AssignAccess = 8;
Sdk.AccessRights.AppendAccess = 16;
Sdk.AccessRights.AppendToAccess = 32;
Sdk.AccessRights.CreateAccess = 64;
Sdk.AccessRights.DeleteAccess = 128;
Sdk.AccessRights.All = 255;
Sdk.AccessRights.__enum = true;
Sdk.AccessRights.__flags = true;
//Sdk.AccessRights.prototype End
//--------------------------------------------------------------------

//Sdk.Attribute.prototype Start



Sdk.Boolean.prototype = new Sdk.AttributeBase();
Sdk.BooleanManagedProperty.prototype = new Sdk.AttributeBase();
Sdk.DateTime.prototype = new Sdk.AttributeBase();
Sdk.Decimal.prototype = new Sdk.AttributeBase();
Sdk.Double.prototype = new Sdk.AttributeBase();
Sdk.Guid.prototype = new Sdk.AttributeBase();
Sdk.Int.prototype = new Sdk.AttributeBase();
Sdk.Long.prototype = new Sdk.AttributeBase();
Sdk.Lookup.prototype = new Sdk.AttributeBase();
Sdk.Money.prototype = new Sdk.AttributeBase();
Sdk.OptionSet.prototype = new Sdk.AttributeBase();
Sdk.PartyList.prototype = new Sdk.AttributeBase();
Sdk.String.prototype = new Sdk.AttributeBase();

Sdk.Boolean.prototype.toValueXml = function () {
 ///<summary>
 /// XML node for boolean attribute value
 ///</summary>
 // <returns type="String" />
 var _valueNode = "<b:value i:nil=\"true\" />";
 if (this.getValue() != null) {
  _valueNode = "<b:value i:type=\"c:" + this.getType() + "\">" + this.getValue() + "</b:value>";
 }
 return _valueNode;
}

Sdk.BooleanManagedProperty.prototype.toValueXml = function () {
 ///<summary>
 /// XML node for boolean managed property attribute value
 ///</summary>
 // <returns type="String" />
 var _valueNode = "<b:value i:nil=\"true\" />";
 if (this.getValue() != null) {
  var xml = [];
  xml.push("<b:value i:type=\"a:BooleanManagedProperty\">");
  xml.push("<a:CanBeChanged>" + this.getValue().getCanBeChanged() + "</a:CanBeChanged>");
  if (this.getValue().getManagedPropertyLogicalName() == null) {
   xml.push("<a:ManagedPropertyLogicalName i:nil=\"true\" />");
  }
  else {
   xml.push("<a:ManagedPropertyLogicalName>" + this.getValue().getManagedPropertyLogicalName() + "</a:ManagedPropertyLogicalName>");
  }
  xml.push("<a:Value>" + this.getValue().getValue() + "</a:Value>");
  xml.push("</b:value>");
  _valueNode = xml.join("");
 }
 return _valueNode;
}

Sdk.DateTime.prototype.toValueXml = function () {
 ///<summary>
 /// XML node for DateTime attribute value
 ///</summary>
 // <returns type="String" />
 var _valueNode = "<b:value i:nil=\"true\" />";
 if (this.getValue() != null) {
  _valueNode = "<b:value i:type=\"c:dateTime\">" + this.getValue().toISOString() + "</b:value>";
 }
 return _valueNode;
}

Sdk.Decimal.prototype.toValueXml = function () {
 ///<summary>
 /// XML node for Decimal attribute value
 ///</summary>
 // <returns type="String" />
 var _valueNode = "<b:value i:nil=\"true\" />";
 if (this.getValue() != null) {
  _valueNode = "<b:value i:type=\"c:" + this.getType() + "\">" + this.getValue() + "</b:value>";
 }
 return _valueNode;
}

Sdk.Double.prototype.toValueXml = function () {
 ///<summary>
 /// XML node for Double attribute value
 ///</summary>
 // <returns type="String" />
 var _valueNode = "<b:value i:nil=\"true\" />";
 if (this.getValue() != null) {
  _valueNode = "<b:value i:type=\"c:" + this.getType() + "\">" + this.getValue() + "</b:value>";
 }
 return _valueNode;
}

Sdk.Guid.prototype.toValueXml = function () {
 ///<summary>
 /// XML node for Guid attribute value
 ///</summary>
 // <returns type="String" />
 var _valueNode = "<b:value i:nil=\"true\" />";
 if (this.getValue() != null) {
  _valueNode = "<b:value i:type=\"e:guid\">" + this.getValue() + "</b:value>";
 }
 return _valueNode;
}

Sdk.Int.prototype.toValueXml = function () {
 ///<summary>
 /// XML node for Int attribute value
 ///</summary>
 // <returns type="String" />
 var _valueNode = "<b:value i:nil=\"true\" />";
 if (this.getValue() != null) {
  _valueNode = "<b:value i:type=\"c:" + this.getType() + "\">" + this.getValue() + "</b:value>";
 }
 return _valueNode;
}

Sdk.Long.prototype.toValueXml = function () {
 ///<summary>
 /// XML node for Long attribute value
 ///</summary>
 // <returns type="String" />
 var _valueNode = "<b:value i:nil=\"true\" />";
 if (this.getValue() != null) {
  _valueNode = "<b:value i:type=\"c:" + this.getType() + "\">" + this.getValue() + "</b:value>";
 }
 return _valueNode;
}

Sdk.Lookup.prototype.toValueXml = function () {
 ///<summary>
 /// XML node for Lookup attribute value
 ///</summary>
 // <returns type="String" />
 var _valueNode = "<b:value i:nil=\"true\" />";
 if (this.getValue() != null) {
  var xml = [];
  xml.push("<b:value i:type=\"a:EntityReference\">");
  xml.push("<a:Id>" + this.getValue().getId() + "</a:Id>");
  xml.push("<a:LogicalName>" + this.getValue().getType() + "</a:LogicalName>");
  if (this.getValue().getName() == null) {
   xml.push("<a:Name i:nil=\"true\" />");
  }
  else {
   xml.push("<a:Name>" + this.getValue().getName() + "</a:Name>");
  }

  xml.push("</b:value>");
  _valueNode = xml.join("");
 }
 return _valueNode;
}

Sdk.Money.prototype.toValueXml = function () {
 ///<summary>
 /// XML node for Money attribute value
 ///</summary>
 // <returns type="String" />
 var _valueNode = "<b:value i:nil=\"true\" />";
 if (this.getValue() != null) {
  var xml = [];
  xml.push("<b:value i:type=\"a:Money\">");
  xml.push("<a:Value>" + this.getValue() + "</a:Value>");
  xml.push("</b:value>");
  _valueNode = xml.join("");
 }
 return _valueNode;
}

Sdk.OptionSet.prototype.toValueXml = function () {
 ///<summary>
 /// XML node for OptionSet attribute value
 ///</summary>
 // <returns type="String" />
 var _valueNode = "<b:value i:nil=\"true\" />";
 if (this.getValue() != null) {
  var xml = [];
  xml.push("<b:value i:type=\"a:OptionSetValue\">");
  xml.push("<a:Value>" + this.getValue() + "</a:Value>");
  xml.push("</b:value>");
  _valueNode = xml.join("");
 }
 return _valueNode;
}

Sdk.PartyList.prototype.toValueXml = function () {
 ///<summary>
 /// XML node for PartyList attribute value
 ///</summary>
 // <returns type="String" />
 var _valueNode = "<b:value i:nil=\"true\" />";
 if (this.getValue() != null) {
  var xml = [];
  xml.push("<b:value i:type=\"a:EntityCollection\">");
  xml.push(this.getValue().toValueXml());
  xml.push("</b:value>");
  _valueNode = xml.join("")
 }
 return _valueNode;
}

Sdk.String.prototype.toValueXml = function () {
 ///<summary>
 /// XML node for String attribute value
 ///</summary>
 // <returns type="String" />
 var _valueNode = "<b:value i:nil=\"true\" />";
 if (this.getValue() != null) {
  _valueNode = "<b:value i:type=\"c:" + this.getType() + "\">" + Sdk.Xml.xmlEncode(this.getValue()) + "</b:value>";
 }
 return _valueNode;
}

Sdk.AttributeBase.prototype.toXml = function (action) {
 ///<summary>
 /// XML node for Attribute
 ///</summary>
 // <returns type="String" />
 var actionType;
 if (typeof action == "string") {
  if (action == "create")
  { actionType = action; }
  if (action == "update")
  { actionType = action; }
 }

 var valueNode, type;
 if (actionType == "update") {
  //Don't return unchanged values
  if (!(this.getIsChanged())) {
   return "";
  }
 }
 if (actionType == "create") {
  //Don't create records with null values
  if (this.getValue() == null) {
   return "";
  }
 }
 if (typeof actionType == "undefined") {
  //Don't send xml that for values not set
  if (!(this.isValueSet())) {
   return "";
  }
 }
 valueNode = this.toValueXml();

 return [
  "<a:KeyValuePairOfstringanyType>",
   "<b:key>" + this.getName() + "</b:key>",
    valueNode,
  "</a:KeyValuePairOfstringanyType>"
 ].join("");
}

//Sdk.ValueType
Sdk.ValueType.prototype = {
 boolean: "boolean",
 booleanManagedProperty: "booleanManagedProperty",
 dateTime: "dateTime",
 decimal: "decimal",
 double: "double",
 entityCollection: "entityCollection",
 entityReference: "entityReference",
 guid: "guid",
 int: "int",
 long: "long",
 money: "money",
 optionSet: "optionSet",
 string: "string"
};

Sdk.ValueType.boolean = "boolean";
Sdk.ValueType.booleanManagedProperty = "booleanManagedProperty";
Sdk.ValueType.dateTime = "dateTime";
Sdk.ValueType.decimal = "decimal";
Sdk.ValueType.double = "double";
Sdk.ValueType.entityCollection = "entityCollection";
Sdk.ValueType.entityReference = "entityReference";
Sdk.ValueType.guid = "guid";
Sdk.ValueType.int = "int";
Sdk.ValueType.long = "long";
Sdk.ValueType.money = "money";
Sdk.ValueType.optionSet = "optionSet";
Sdk.ValueType.string = "string";
Sdk.ValueType.__enum = true;
Sdk.ValueType.__flags = true;
//Sdk.Attribute.prototype End
//--------------------------------------------------------------------
//Sdk.AttributeCollection.prototype Start

Sdk.AttributeCollection.prototype.forEach = function (fn) {
 ///<summary>
 /// Allows for a delegate function to be applied to each attribute in the collection
 ///</summary>
 ///<param name="fn" type="function">
 /// The function to be applied. Function should have parameters for the attribute and the iterator i.e.: '(att,i)'
 ///</param>
 this.getAttributes().forEach(fn);
}

Sdk.AttributeCollection.prototype.get = function (args) {
 ///<summary>
 /// Gets the collection of attributes for the entity filtered by arguments
 ///</summary>
 ///<param name="args" type="Object">
 /// <para>If null all attributes are returned</para>
 /// <para>If String the attribute with matching name is returned.</para>
 /// <para>If Number the attribute with matching index is returned.</para>
 ///</param>
 if (args == null) {
  return this.getAttributes();
 }
 if (typeof args == "string") {
  return this.getAttributeByName(args);
 }
 if (typeof args == "number") {
  return this.getAttributeByIndex(args);
 }
 throw new Error("Sdk.AttributeCollection.get expects the args parameter to be Null, a String, or a Number");
}

Sdk.AttributeCollection.prototype.getAttributeByIndex = function (index) {
 ///<summary>
 /// Gets an attribute at a given index
 ///</summary>
 /// <param type="Number" name="index" optional="false" mayBeNull="false">
 /// The index
 /// </param>
 /// <returns type="Sdk.AttributeBase">
 /// The attribute at the index
 /// </returns>
 var returnValue = null;
 this.getAttributes().forEach(function (att, i) {
  if (index == i) {
   returnValue == att;
   return;
  }
 });
 if (returnValue != null) {
  return returnValue;
 }
 else {
  throw new Error(Sdk.Util.format("Out of Range exception. There is no attribute at the index: {0}.", [index]));
 }
}

Sdk.AttributeCollection.prototype.getAttributeByName = function (name) {
 ///<summary>
 /// Gets an attribute with a given name
 ///</summary>
 /// <param type="String" name="number" optional="false" mayBeNull="false">
 /// The Logical name of the attribute
 /// </param>
 /// <returns type="Sdk.AttributeBase">
 /// The attribute with the given name
 /// </returns>
 var returnValue = null;
 this.getAttributes().forEach(function (att, i) {
  if (att.getName() == name.toLowerCase()) {
   returnValue = att;
   return;
  }
 });
 if (returnValue != null) {
  return returnValue;
 }
 else {
  throw new Error(Sdk.Util.format("An attribute named {0} does not exist in this entity.", [name]));
 }

}

Sdk.AttributeCollection.prototype.getCount = function () {
 ///<summary>
 /// Gets the number of attributes in the collection
 ///</summary>
 /// <returns type="Number">
 /// The number of attributes in the collection
 /// </returns>
 return this.getAttributes().getCount();
}

Sdk.AttributeCollection.prototype.getNames = function () {
 ///<summary>
 /// Gets an array of the names of attributes in a collection
 ///</summary>
 /// <returns type="Array">
 /// The names of attributes in a collection
 /// </returns>
 var _names = [];
 this.forEach(function (a, i) {
  _names.push(a.getName());
 });
 return _names;
}

Sdk.AttributeCollection.prototype.toValueXml = function (action) {
 ///<summary>
 /// For internal use only
 ///</summary>
 // <returns type="String" />
 var _xml = [];
 this.forEach(function (att, i) {
  _xml.push(att.toXml(action));
 });
 return _xml.join("");
}

Sdk.AttributeCollection.prototype.toXml = function (action) {
 ///<summary>
 /// The XML for an attribute collection
 ///</summary>
 // <returns type="String" />
 var _xml = ["<a:Attributes>"];
 _xml.push(this.toValueXml(action));
 _xml.push("</a:Attributes>")
 return _xml.join("");
}


//Sdk.AttributeCollection.prototype End
//--------------------------------------------------------------------
//Sdk.AuditDetail.prototype Start
Sdk.AttributeAuditDetail.prototype = new Sdk.AuditDetail();
Sdk.RelationshipAuditDetail.prototype = new Sdk.AuditDetail();
Sdk.RolePrivilegeAuditDetail.prototype = new Sdk.AuditDetail();
Sdk.ShareAuditDetail.prototype = new Sdk.AuditDetail();
//Sdk.AuditDetail.prototype End
//--------------------------------------------------------------------
//Sdk.AuditDetailCollection.prototype Start
Sdk.AuditDetailCollection.prototype.getCount = function () {
 ///<summary>
 /// Indicates the number of elements in the AuditDetails collection. 
 ///</summary>
 /// <returns type="Number">
 /// The number of elements in the AuditDetails collection. 
 ///</returns>
 return this.getAuditDetails().getCount();

}
Sdk.AuditDetailCollection.prototype.getItem = function (index) {
 ///<summary>
 /// Gets the Sdk.AuditDetail at the specified index. 
 ///</summary>
 /// <returns type="Sdk.AuditDetail">
 /// The Sdk.AuditDetail at the specified index. 
 ///</returns>
 return this.getAuditDetails().getByIndex(index);

}

Sdk.AuditDetailCollection.prototype.add = function (auditDetail) {
 ///<summary>
 /// Adds an item to the AuditDetails collection. 
 ///</summary>
 /// <param name="auditDetail" type="Sdk.AuditDetail">
 /// The Sdk.AuditDetail to add
 ///</param>
 this.getAuditDetails().add(auditDetail);

}
//Sdk.AuditDetailCollection.prototype End
//--------------------------------------------------------------------
//Sdk.Collection.prototype Start
Sdk.Collection.prototype.toValueXml = function () {
 ///<summary>
 /// Returns the XML representing the items in the collection
 ///</summary>
 ///<returns type=String>
 /// The XML representing the items in the collection
 ///</returns>
 var returnValue = [];
 this.forEach(function (a, i) {
  try {
   returnValue.push(a.toXml());
  }
  catch (e) {
   throw new Error("Sdk.Collection.toValueXml error: " + e.message)
  }

 });
 return returnValue.join("");
}

Sdk.Collection.prototype.toArrayOfValueXml = function (type) {
 ///<summary>
 /// Returns the XML representing the items in the collection
 ///</summary>
 ///<param type=String>
 /// The XML tag to wrap the primitive values in.
 ///</param>
 ///<returns type=String>
 /// The XML representing the items in the collection
 ///</returns>
 var returnValue = [];
 this.forEach(function (a, i) {
  try {
   if (typeof a.toValueXml == "function") {
    returnValue.push(["<", type, ">", a.toValueXml(), "</", type, ">"].join(""));
   }
   else {
    returnValue.push(["<", type, ">", a, "</", type, ">"].join(""));
   }

  }
  catch (e) {
   throw new Error("Sdk.Collection.toArrayOfValueXml error: " + e.message)
  }

 });
 return returnValue.join("");
}
//Sdk.Collection.prototype End
//--------------------------------------------------------------------
//Sdk.ColumnSet.prototype Start
Sdk.ColumnSet.prototype.removeColumn = function (columnName, errorIfNotFound) {
 ///<summary>
 /// Removes a column from the ColumnSet
 ///</summary>
 ///<param name="columnName" type="String"  optional="false"   mayBeNull="false">
 /// The logical name of an attribute to be removed from the ColumnSet
 ///</param>
 ///<param name="errorIfNotFound"  optional="true" type="Boolean">
 /// Whether to throw an error when the column to remove is not found. The default is false
 ///</param>
 if (typeof columnName == "string") {
  var columnToRemove, columnFound = false;
  this.getColumns().forEach(function (c, i) {
   if (c == columnName) {
    columnToRemove = c;
    columnFound = true;
   }
  });
  if (columnFound) {
   this.getColumns().remove(columnToRemove);
  }
  else {
   if ((typeof errorIfNotFound == "boolean") && (errorIfNotFound)) {
    throw new Error(Sdk.Util.format("A column named {0} was not found in the collection.", [columnName]));
   }
  }
 }
 else {
  throw new Error("Sdk.ColumnSet.removeColumn method columnName parameter must be a string.")
 }


}

Sdk.ColumnSet.prototype.toXml = function () {
 ///<summary>
 /// The XML node with "<d:columnSet>" as the root element
 ///</summary>
 // <returns type="String" />
 var _xml = [];
 _xml.push("<d:columnSet>");
 _xml.push(this.toValueXml());
 _xml.push("</d:columnSet>");
 return _xml.join("");

}

Sdk.ColumnSet.prototype.toValueXml = function () {
 ///<summary>
 /// XML nodes for columnSet properties
 ///</summary>
 // <returns type="String" />
 var _xml = [];
 _xml.push("<a:AllColumns>" + this.getAllColumns() + "</a:AllColumns>")
 if (this.getCount() == 0) {
  _xml.push("<a:Columns />");
 }
 else {
  _xml.push("<a:Columns>");
  this.getColumns().forEach(function (c, i) {
   _xml.push("<f:string>" + c + "</f:string>");
  });
  _xml.push("</a:Columns>");
 }

 return _xml.join("");
}
//Sdk.ColumnSet.prototype End
//--------------------------------------------------------------------
//Sdk.Entity.prototype Start
Sdk.Entity.prototype.addAttribute = function (attribute, isChanged) {
 ///<summary>
 /// Adds an attribute with an optional value to a newly instantiated Sdk.Entity
 ///</summary>
 ///<param name="attribute" type="Sdk.AttributeBase" optional="false" mayBeNull="false">
 /// The attribute to add
 ///</param>
 ///<param name="isChanged" type="Boolean" optional="true" mayBeNull="true" >
 /// Whether the attribute should be considered changed, the default is true
 ///</param>
 this.getAttributes().add(attribute, isChanged);
}

Sdk.Entity.prototype.addRelatedEntity = function (relationshipSchemaName, entity) {
 ///<summary>
 /// Adds an entity to the related entities
 ///</summary>
 ///<param name="relationshipSchemaName" type="String"  optional="false" mayBeNull="false">
 /// The relationship SchemaName
 ///</param>
 ///<param name="entity" type="Sdk.Entity"  optional="false" mayBeNull="false">
 /// The entity to add
 ///</param>

 this.getRelatedEntities().add(relationshipSchemaName, entity);
}

Sdk.Entity.prototype.getIsChanged = function () {
 ///<summary>
 /// Gets the value to indicate whether data for the entity has changed.
 ///</summary>
 ///<returns type="Boolean">
 /// The value to indicate whether data for the entity has changed.
 ///</returns>
 var changed = false;
 this.getAttributes().forEach(function (att, i) {
  if (att.getIsChanged()) {
   changed = true;
  }
 });
 if (changed) {
  return true;
 }
 if (this.getRelatedEntities().getIsChanged()) {
  return true;
 }

 this.getRelatedEntities().getRelationshipEntities().forEach(function (r, i) {
  r.getEntityCollection().getEntities().forEach(function (e, i) {
   if (e.getIsChanged()) {
    changed = true;
   }
  });
 });

 return changed;
}

Sdk.Entity.prototype.setIsChanged = function (isChanged) {
 ///<summary>
 /// Sets the value to indicate whether data for the entity has changed.
 ///</summary>
 ///<param name="isChanged" type="Boolean">
 /// The value to indicate whether data for the entity has changed.
 ///</param>
 this.getAttributes().forEach(function (att, i) {
  att.setIsChanged(isChanged);
 });
 this.getRelatedEntities().setIsChanged(isChanged);

 this.getRelatedEntities().getRelationshipEntities().forEach(function (r, i) {
  r.getEntityCollection().getEntities().forEach(function (e, i) {
   e.setIsChanged(isChanged);
  });
 });
}

Sdk.Entity.prototype.getValue = function (logicalName) {
 ///<summary>
 /// Gets the value of the specified attribute
 ///</summary>
 ///<param name="logicalName" type="String" optional="false">
 /// The logical name of the attribute
 ///</param>
 if (typeof logicalName != "string") {
  throw new Error("Sdk.Entity.getValue logicalName parameter is required and must be a string.");
 }
 var returnValue = null;
 try {
  returnValue = this.getAttributes(logicalName).getValue();
 }
 catch (e) {
  throw e;
 }
 return returnValue;
}

Sdk.Entity.prototype.initializeSubClass = function (metadata) {
 ///<summary>
 /// Generates properties for the entity based on metadata
 ///</summary>

 for (var i in metadata) {
  var attribute;
  try {
   attribute = this.getAttributes().get(i.toLowerCase());
  } catch (e) {
   attribute = new metadata[i].AttributeType(i.toLowerCase());
   this.addAttribute(attribute, false);
  }
  this[i] = attribute;

 }

}

Sdk.Entity.prototype.setValue = function (logicalName, value) {
 ///<summary>
 /// Sets the value of the specified attribute
 ///</summary>
 ///<param name="logicalName" type="String" optional="false" mayBeNull="false">
 /// The logical name of the attribute
 ///</param>
 ///<param name="value" type="Object" optional="false" mayBeNull="true">
 /// <para>The value for the attribute</para>
 /// <para>Simple JavaScript types may be used for most attribute types</para>
 /// <para>Sdk.EntityReference, Sdk.EntityCollection, and Sdk.BooleanManagedPropertyValue cannot use simple JavaScript types.</para>
 ///</param>

 if (typeof logicalName != "string") {
  throw new Error("Sdk.Entity.setValue logicalName parameter is required and must be a string.");
 }
 if (typeof value == "undefined") {
  throw new Error("Sdk.Entity.setValue value parameter is required.");
 }
 try {
  var att;
  att = this.getAttributes(logicalName);
  att.setValue(value);
 }
 catch (e) {
  throw e;
 }


}

Sdk.Entity.prototype.toEntityReference = function () {
 ///<summary>
 /// Generates an entity reference
 ///</summary>
 // <returns type="Sdk.EntityReference" />
 if (this.getId() != null) {
  return new Sdk.EntityReference(this.getType(), this.getId());
 }
 else {
  throw new Error("Sdk.Entity.toEntityReference cannot be used on an entity that has not been saved.");
 }
}

Sdk.Entity.prototype.toString = function () {
 ///<summary>
 /// Overrides the default toString method.
 ///</summary>
 // <returns type="String" />
 return "[object Sdk.Entity " + this.getType() + "]";
}

Sdk.Entity.prototype.toValueXml = function (action) {
 ///<summary>
 /// XML definition of an the child nodes of an entity
 ///</summary>
 // <returns type="String" />
 var _xml = [];
 _xml.push(this.getAttributes().toXml(action));
 _xml.push(["<a:EntityState i:nil=\"true\" />",
         "<a:FormattedValues />"].join("")); //formatted values always empty b/c they are never saved
 if (this.getId() == null) {
  _xml.push("<a:Id>00000000-0000-0000-0000-000000000000</a:Id>");
 }
 else {
  _xml.push("<a:Id>" + this.getId() + "</a:Id>");
 }
 _xml.push("<a:LogicalName>" + this.getType() + "</a:LogicalName>");
 _xml.push(this.getRelatedEntities().toXml());
 return _xml.join("");
}

Sdk.Entity.prototype.toXml = function (action) {
 ///<summary>
 /// XML definition of an entity where the root node is &lt;d:entity&gt;
 ///</summary>
 // <returns type="String" />
 var _xml = ["<d:entity>"];
 _xml.push(this.toValueXml(action));
 _xml.push("</d:entity>");
 return _xml.join("");

}

Sdk.Entity.prototype.view = function () {
 ///<summary>
 /// Returns a view of the data in an entity instance
 ///</summary>
 // <returns type="Object" />
 var _attributes = {};
 var formattedValues = this.getFormattedValues();
 this.getAttributes().forEach(function (att, i) {
  var formattedValue;
  var name = att.getName();
  var value;
  var type = att.getType();
  switch (type) {
   case "boolean":
   case "dateTime":
   case "guid":
   case "string":
   case "money":
   case "long":
   case "decimal":
   case "double":
   case "int":
   case "optionSet":
    value = att.getValue();
    break;
   case "booleanManagedProperty":
    value = {
     "canBeChanged": att.getValue().getCanBeChanged(),
     "managedPropertyLogicalName": att.getValue().getManagedPropertyLogicalName(),
     "value": att.getValue().getValue()
    };
    break;
   case "entityReference":
    if (att.getValue() == null) {
     value = null;
     formattedValue = null;
    }
    else {
     value =
      att.getValue().view()
     //{
     //id: att.getValue().getId(),
     //logicalName: att.getValue().getType(),
     //name: att.getValue().getName()
     //}

     formattedValue = att.getValue().getName();
    }

    break;
   case "entityCollection":
    value = att.getValue().view();

    formattedValue = "";
    for (var i = 0; i < att.getValue().view().entities.length; i++) {
     var entity = att.getValue().view().entities[i];

     try {
      formattedValue += "{" + entity.attributes.partyid.fValue + "}";
     }
     catch (e) {
      formattedValue += "{" + entity.logicalName + " id:" + entity.id + "}";
     }

    }

    break;
   default:
    throw new Error("Missing type " + type + " in Sdk.Entity.view");
    break;
  }
  if (typeof formattedValue == "undefined") {
   try {
    var fv = formattedValues.getItem(name);
    formattedValue = fv.getValue();
   }
   catch (e) {
    formattedValue = value;
   };
  }

  _attributes[name] = { "value": value, "type": type, "fValue": formattedValue }
 });

 return {
  attributes: _attributes,
  entityState: this.getEntityState(),
  id: (this.getId() == null) ? null : this.getId(),
  logicalName: this.getType(),
  relatedEntities: this.getRelatedEntities().view()

 }


}
//Sdk.Entity.prototype End
//--------------------------------------------------------------------
//Sdk.EntityCollection.prototype Start
Sdk.EntityCollection.prototype.getCount = function () {
 ///<summary>
 /// Returns the number of entities in the collection.
 ///</summary>
 ///<returns  type="Number">
 /// The number of entitites in the collection.
 ///</returns>
 return this.getEntities().getCount();
}
Sdk.EntityCollection.prototype.toValueXml = function () {
 ///<summary>
 /// XML definition of an the child nodes of an entity
 ///</summary>
 // <returns type="String" />
 var _xml = [];
 _xml.push("<a:Entities>");
 this.getEntities().forEach(function (ent, i) {
  _xml.push(["<a:Entity>", ent.toValueXml(), "</a:Entity>"].join(""));
 });
 _xml.push("</a:Entities>");
 if (this.getEntityName() == null)
 { _xml.push("<a:EntityName i:nil=\"true\" />"); }
 else
 {
  _xml.push("<a:EntityName>");
  _xml.push(this.getEntityName());
  _xml.push("</a:EntityName>");
 }

 if (this.getMinActiveRowVersion() == null) {
  _xml.push("<a:MinActiveRowVersion i:nil=\"true\" />");
 }
 else {
  _xml.push("<a:MinActiveRowVersion>");
  _xml.push(this.getMinActiveRowVersion());
  _xml.push("</a:MinActiveRowVersion>");
 }

 _xml.push("<a:MoreRecords>" + this.getMoreRecords() + "</a:MoreRecords>");
 if (this.getPagingCookie() == null) {
  _xml.push("<a:PagingCookie i:nil=\"true\" />");
 }
 else {
  _xml.push("<a:PagingCookie>");
  _xml.push(this.getPagingCookie());
  _xml.push("</a:PagingCookie>");
 }
 if (this.getTotalRecordCount() == null) {
  _xml.push("<a:TotalRecordCount i:nil=\"true\" />");
 }
 else {
  _xml.push("<a:TotalRecordCount>" + this.getTotalRecordCount() + "</a:TotalRecordCount>");
 }
 if (this.getTotalRecordCountLimitExceeded() == null) {
  _xml.push("<a:TotalRecordCountLimitExceeded i:nil=\"true\" />");
 }
 else {
  _xml.push("<a:TotalRecordCountLimitExceeded>" + this.getTotalRecordCountLimitExceeded() + "</a:TotalRecordCountLimitExceeded>");
 }
 return _xml.join("");
}
Sdk.EntityCollection.prototype.view = function () {
 ///<summary>
 /// Returns a view of the entity collection
 ///</summary>
 /// <returns type="Object">
 /// An object with properties representing the data from the Sdk.EntityCollection.
 /// </returns>

 var _entities = [];
 this.getEntities().forEach(function (entity, i) {
  _entities.push(entity.view());
 });
 return {
  entityName: this.getEntityName(),
  entities: _entities,
  minActiveRowVersion: this.getMinActiveRowVersion(),
  moreRecords: this.getMoreRecords(),
  pagingCookie: this.getPagingCookie(),
  totalRecordCount: this.getTotalRecordCount(),
  totalRecordCountLimitExceeded: this.getTotalRecordCountLimitExceeded()
 }
}
//Sdk.EntityCollection.prototype End
//--------------------------------------------------------------------
//Sdk.EntityReference.prototype Start
Sdk.EntityReference.prototype.toXml = function () {
 ///<summary>
 ///  Returns a serialized entity reference where the root element is &lt;a:EntityReference&gt;
 ///</summary>
 /// <returns type="String" />
 var rv = [];
 rv.push("<a:EntityReference>");
 rv.push(this.toValueXml());
 rv.push("</a:EntityReference>")
 return rv.join("");
}

Sdk.EntityReference.prototype.toValueXml = function () {
 ///<summary>
 ///  Returns the values of serialized entity reference as XML nodes
 ///</summary>
 /// <returns type="String" />
 var rv = [];
 rv.push("<a:Id>" + this.getId() + "</a:Id>");
 rv.push("<a:LogicalName>" + this.getType() + "</a:LogicalName>");
 if (this.getName() == null) {
  rv.push("<a:Name i:nil=\"true\" />");
 }
 else {
  rv.push("<a:Name>" + this.getName() + "</a:Name>")
 }
 return rv.join("");
}

Sdk.EntityReference.prototype.view = function () {
 ///<summary>
 /// Returns a view of the data in an EntityReference
 ///</summary>
 // <returns type="Object" />
 var rv = {};
 rv.Id = this.getId();
 rv.Type = this.getType();
 rv.Name = this.getName();
 return rv;

}
//Sdk.EntityReference.prototype End
//--------------------------------------------------------------------
//Sdk.EntityReferenceCollection.prototype Start
Sdk.EntityReferenceCollection.prototype.add = function (entityReference) {
 ///<summary>
 ///  Adds an entity reference to the collection
 ///</summary>
 /// <param name="entityReference" type="Sdk.EntityReference" optional="false" mayBeNull="false">
 /// The entity reference to add.
 /// </param>
 this.getEntityReferences().add(entityReference);

}

Sdk.EntityReferenceCollection.prototype.remove = function (entityReference) {
 ///<summary>
 ///  Removes an entity reference to the collection
 ///</summary>
 /// <param  name="entityReference"  type="Sdk.EntityReference" optional="false" mayBeNull="false">
 /// The entity reference to remove.
 /// </param>
 var erToRemove = null;
 this.getEntityReferences().forEach(function (er, i) {
  if ((er.getId() == entityReference.getId()) &&
   (er.getType() == entityReference.getType())) {
   erToRemove = er;
  }
 });
 if (erToRemove != null) {
  this.getEntityReferences().remove(erToRemove);
 }
}

Sdk.EntityReferenceCollection.prototype.view = function () {
 ///<summary>
 ///  Returns a view of the data in an entity reference collection instance.
 ///</summary>
 /// <returns type="Object" />
 var rv = [];
 this.getEntityReferences().forEach(function (er, i) {
  rv.push(er.view());
 });
 return rv;
}

Sdk.EntityReferenceCollection.prototype.toValueXml = function () {
 ///<summary>
 ///  Returns the values of serialized entity reference collection as XML nodes
 ///</summary>
 /// <returns type="String" />
 var rv = [];
 this.getEntityReferences().forEach(function (er, i) {
  rv.push(er.toXml());
 });
 return rv.join("");
}
//Sdk.EntityReferenceCollection.prototype End
//--------------------------------------------------------------------
//Sdk.EntityState.prototype Start
Sdk.EntityState.prototype = {
 Changed: "Changed",
 Created: "Created",
 Unchanged: "Unchanged"
};
Sdk.EntityState.Changed = "Changed";
Sdk.EntityState.Created = "Created";
Sdk.EntityState.Unchanged = "Unchanged";
Sdk.EntityState.__enum = true;
Sdk.EntityState.__flags = true;
//Sdk.EntityState.prototype End
//--------------------------------------------------------------------
//Sdk.FormattedValueCollection.prototype Start
Sdk.FormattedValueCollection.prototype.getCount = function () {
 ///<summary
 /// Gets the number of formatted values in the collection
 /// </summary>
 /// <returns type="Number">
 /// The number of formatted values in the collection
 /// </returns>
 return this.getCollection().getCount();
}
Sdk.FormattedValueCollection.prototype.getItemByIndex = function (index) {
 ///<summary
 /// Gets an item from the formatted value collection by index
 /// </summary>
 /// <param name="index" type="Number">
 /// The index of a formatted value in the collection
 /// </param>
 /// <returns type="Sdk.FormattedValue">
 /// The item from the formatted value collection
 /// </returns>
 return this.getCollection().getByIndex(index);
}
Sdk.FormattedValueCollection.prototype.getNames = function () {
 ///<summary
 /// Gets the names of the formatted values in the collection
 /// </summary>
 /// <returns type="Array">
 /// An array of strings containing the names of the formatted values in the collection
 /// </returns>
 var names = [];
 this.getCollection().forEach(function (fv, i) {
  names.push(fv.getName());
 });
 return names;
}
Sdk.FormattedValueCollection.prototype.getValues = function () {
 ///<summary
 /// Gets the values of the formatted values in the collection
 /// </summary>
 /// <returns type="Array">
 /// An array of strings containing the values of the formatted values in the collection
 /// </returns>
 var values = [];
 this.getCollection().forEach(function (fv, i) {
  values.push(fv.getValue());
 });
 return values;

}
Sdk.FormattedValueCollection.prototype.contains = function (item) {
 ///<summary>
 /// Returns whether an Sdk.FormattedValue exists within the FormattedValueCollection.
 ///</summary>
 ///<param name="item" type="Sdk.FormattedValue">
 ///  The item must have the same name and value values.
 ///</param>			
 this.getCollection().forEach(function (fv, i) {
  if ((item.getName() == fv.getName()) && (item.getValue() == fv.getValue()) && (item.getValueType() == fv.getValueType())) {
   return true;
  }
 });
 return false;

}
Sdk.FormattedValueCollection.prototype.remove = function (name) {
 ///<summary>
 /// Removes an item from the FormattedValueCollection
 ///</summary>
 ///<param name="name" type="String">
 /// The name of the item to remove
 ///</param>
 var itemToRemove = null;
 this.getCollection().forEach(function (fv, i) {
  if (fv.getName() == name) {
   itemToRemove = fv;
  }
 });
 if (itemToRemove != null) {
  this.getFormattedValues().remove(itemToRemove);
 }

}
Sdk.FormattedValueCollection.prototype.clear = function () {
 ///<summary>
 /// Removes all items from the FormattedValueCollection
 ///</summary>
 this.getCollection().clear();
}
Sdk.FormattedValueCollection.prototype.forEach = function (fn) {
 ///<summary>
 /// Applies the action contained within a delegate function.
 ///</summary>
 ///<param name="fn" type="Function">
 /// Delegate function with parameters for item and index.
 ///</param>
 this.getCollection().forEach(fn);
}

//Sdk.FormattedValueCollection.prototype End
//--------------------------------------------------------------------
//Sdk.PrincipalAccess.prototype Start
Sdk.PrincipalAccess.prototype.toValueXml = function () {
 if (this.getPrincipal() == null) {
  throw new Error("Sdk.PrincipalAccess.toValueXml cannot be used when the Principal property is null.")
 }
 return ["<g:AccessMask>", this.getAccessMaskAsString(), "</g:AccessMask>",
         "<g:Principal>",
         this.getPrincipal().toValueXml(),
         "</g:Principal>"].join("");
}
//Sdk.PrincipalAccess.prototype End
//--------------------------------------------------------------------
//Sdk.PrivilegeDepth.prototype Start
Sdk.PrivilegeDepth.prototype = {
 Basic: "Basic",
 Deep: "Deep",
 Global: "Global",
 Local: "Local"
};
Sdk.PrivilegeDepth.Basic = "Basic";
Sdk.PrivilegeDepth.Deep = "Deep";
Sdk.PrivilegeDepth.Global = "Global";
Sdk.PrivilegeDepth.Local = "Local";
Sdk.PrivilegeDepth.__enum = true;
Sdk.PrivilegeDepth.__flags = true;
//Sdk.PrivilegeDepth.prototype End
//--------------------------------------------------------------------
//Sdk.Query.PropagationOwnershipOptions.prototype Start
Sdk.PropagationOwnershipOptions.prototype = {
 Caller: "Caller",
 ListMemberOwner: "ListMemberOwner",
 None: "None"
};
Sdk.PropagationOwnershipOptions.Caller = "Caller";
Sdk.PropagationOwnershipOptions.ListMemberOwner = "ListMemberOwner";
Sdk.PropagationOwnershipOptions.None = "None";
Sdk.PropagationOwnershipOptions.__enum = true;
Sdk.PropagationOwnershipOptions.__flags = true;
//Sdk.Query.PropagationOwnershipOptions.prototype End
//--------------------------------------------------------------------
//Sdk.Query.ConditionExpression.prototype Start
Sdk.Query.ConditionExpression.prototype.toXml = function () {
 ///<summary>
 ///  Returns a serialized condition expression where the root element is &lt;a:ConditionExpression&gt;
 ///</summary>
 /// <returns type="String" />
 return ["<a:ConditionExpression>",
          this.toValueXml(),
        "</a:ConditionExpression>"].join("");
}
Sdk.Query.ConditionExpression.prototype.toValueXml = function () {
 ///<summary>
 ///  Returns the values of serialized condition expression as XML nodes
 ///</summary>
 /// <returns type="String" />

 var attributeName = this.getAttributeName();
 if (attributeName == null) {
  throw new Error("Sdk.Query.ConditionExpression AttributeName property must be set before a query can be performed.");
 }

 var operator = this.getOperator()
 if (operator == null) {
  throw new Error("Sdk.Query.ConditionExpression Operator property must be set before a query can be performed.");
 }

 var valueString;
 var valuesProperty = this.getValues();
 if (valuesProperty == null) {
  valueString = "<a:Values />";
 }
 else {
  var values = valuesProperty.getValues();
  var valuesAreDates = (valuesProperty instanceof Sdk.Query.Dates);
  var valuesAreEntityReferences = (valuesProperty instanceof Sdk.Query.EntityReferences)
  var type = this.getValues().getType();
  var valuesArray = [];
  values.forEach(function (v, i) {
   var value;
   if (valuesAreDates) {
    value = v.toISOString();
   }
   else {
    if (valuesAreEntityReferences) {
     value = v.getId();
    }
    else {
     value = v.toString();
    }
   }
   valuesArray.push(Sdk.Util.format("<f:anyType i:type=\"{0}\">{1}</f:anyType>", [type, value]));
  });
  valueString = ["<a:Values>",
               valuesArray.join(""),
                "</a:Values>"].join("");
 }

 var entityName = this.getEntityName();

 return ["<a:AttributeName>" + attributeName + "</a:AttributeName>",
          "<a:Operator>" + operator + "</a:Operator>",
           valueString,
 (entityName == null) ? "<a:EntityName i:nil=\"true\" />" : "<a:EntityName>" + entityName + "</a:EntityName>"].join("");

}
//Sdk.Query.ConditionExpression.prototype End
//--------------------------------------------------------------------
//Sdk.Query.ConditionOperator.prototype Start
Sdk.Query.ConditionOperator.prototype = {
 Equal: "Equal",
 NotEqual: "NotEqual",
 GreaterThan: "GreaterThan",
 LessThan: "LessThan",
 GreaterEqual: "GreaterEqual",
 LessEqual: "LessEqual",
 Like: "Like",
 NotLike: "NotLike",
 In: "In",
 NotIn: "NotIn",
 Between: "Between",
 NotBetween: "NotBetween",
 Null: "Null",
 NotNull: "NotNull",
 Yesterday: "Yesterday",
 Today: "Today",
 Tomorrow: "Tomorrow",
 Last7Days: "Last7Days",
 Next7Days: "Next7Days",
 LastWeek: "LastWeek",
 ThisWeek: "ThisWeek",
 NextWeek: "NextWeek",
 LastMonth: "LastMonth",
 ThisMonth: "ThisMonth",
 NextMonth: "NextMonth",
 On: "On",
 OnOrBefore: "OnOrBefore",
 OnOrAfter: "OnOrAfter",
 LastYear: "LastYear",
 ThisYear: "ThisYear",
 NextYear: "NextYear",
 LastXHours: "LastXHours",
 NextXHours: "NextXHours",
 LastXDays: "LastXDays",
 NextXDays: "NextXDays",
 LastXWeeks: "LastXWeeks",
 NextXWeeks: "NextXWeeks",
 LastXMonths: "LastXMonths",
 NextXMonths: "NextXMonths",
 LastXYears: "LastXYears",
 NextXYears: "NextXYears",
 EqualUserId: "EqualUserId",
 NotEqualUserId: "NotEqualUserId",
 EqualBusinessId: "EqualBusinessId",
 NotEqualBusinessId: "NotEqualBusinessId",
 Mask: "Mask",
 NotMask: "NotMask",
 Contains: "Contains",
 DoesNotContain: "DoesNotContain",
 EqualUserLanguage: "EqualUserLanguage",
 NotOn: "NotOn",
 OlderThanXMonths: "OlderThanXMonths",
 BeginsWith: "BeginsWith",
 DoesNotBeginWith: "DoesNotBeginWith",
 EndsWith: "EndsWith",
 DoesNotEndWith: "DoesNotEndWith",
 ThisFiscalYear: "ThisFiscalYear",
 ThisFiscalPeriod: "ThisFiscalPeriod",
 NextFiscalYear: "NextFiscalYear",
 NextFiscalPeriod: "NextFiscalPeriod",
 LastFiscalYear: "LastFiscalYear",
 LastFiscalPeriod: "LastFiscalPeriod",
 LastXFiscalYears: "LastXFiscalYears",
 LastXFiscalPeriods: "LastXFiscalPeriods",
 NextXFiscalYears: "NextXFiscalYears",
 NextXFiscalPeriods: "NextXFiscalPeriods",
 InFiscalYear: "InFiscalYear",
 InFiscalPeriod: "InFiscalPeriod",
 InFiscalPeriodAndYear: "InFiscalPeriodAndYear",
 InOrBeforeFiscalPeriodAndYear: "InOrBeforeFiscalPeriodAndYear",
 InOrAfterFiscalPeriodAndYear: "InOrAfterFiscalPeriodAndYear",
 EqualUserOrUserTeams: "EqualUserOrUserTeams",
 EqualUserTeams: "EqualUserTeams"
};
Sdk.Query.ConditionOperator.Equal = "Equal";
Sdk.Query.ConditionOperator.NotEqual = "NotEqual";
Sdk.Query.ConditionOperator.GreaterThan = "GreaterThan";
Sdk.Query.ConditionOperator.LessThan = "LessThan";
Sdk.Query.ConditionOperator.GreaterEqual = "GreaterEqual";
Sdk.Query.ConditionOperator.LessEqual = "LessEqual";
Sdk.Query.ConditionOperator.Like = "Like";
Sdk.Query.ConditionOperator.NotLike = "NotLike";
Sdk.Query.ConditionOperator.In = "In";
Sdk.Query.ConditionOperator.NotIn = "NotIn";
Sdk.Query.ConditionOperator.Between = "Between";
Sdk.Query.ConditionOperator.NotBetween = "NotBetween";
Sdk.Query.ConditionOperator.Null = "Null";
Sdk.Query.ConditionOperator.NotNull = "NotNull";
Sdk.Query.ConditionOperator.Yesterday = "Yesterday";
Sdk.Query.ConditionOperator.Today = "Today";
Sdk.Query.ConditionOperator.Tomorrow = "Tomorrow";
Sdk.Query.ConditionOperator.Last7Days = "Last7Days";
Sdk.Query.ConditionOperator.Next7Days = "Next7Days";
Sdk.Query.ConditionOperator.LastWeek = "LastWeek";
Sdk.Query.ConditionOperator.ThisWeek = "ThisWeek";
Sdk.Query.ConditionOperator.NextWeek = "NextWeek";
Sdk.Query.ConditionOperator.LastMonth = "LastMonth";
Sdk.Query.ConditionOperator.ThisMonth = "ThisMonth";
Sdk.Query.ConditionOperator.NextMonth = "NextMonth";
Sdk.Query.ConditionOperator.On = "On";
Sdk.Query.ConditionOperator.OnOrBefore = "OnOrBefore";
Sdk.Query.ConditionOperator.OnOrAfter = "OnOrAfter";
Sdk.Query.ConditionOperator.LastYear = "LastYear";
Sdk.Query.ConditionOperator.ThisYear = "ThisYear";
Sdk.Query.ConditionOperator.NextYear = "NextYear";
Sdk.Query.ConditionOperator.LastXHours = "LastXHours";
Sdk.Query.ConditionOperator.NextXHours = "NextXHours";
Sdk.Query.ConditionOperator.LastXDays = "LastXDays";
Sdk.Query.ConditionOperator.NextXDays = "NextXDays";
Sdk.Query.ConditionOperator.LastXWeeks = "LastXWeeks";
Sdk.Query.ConditionOperator.NextXWeeks = "NextXWeeks";
Sdk.Query.ConditionOperator.LastXMonths = "LastXMonths";
Sdk.Query.ConditionOperator.NextXMonths = "NextXMonths";
Sdk.Query.ConditionOperator.LastXYears = "LastXYears";
Sdk.Query.ConditionOperator.NextXYears = "NextXYears";
Sdk.Query.ConditionOperator.EqualUserId = "EqualUserId";
Sdk.Query.ConditionOperator.NotEqualUserId = "NotEqualUserId";
Sdk.Query.ConditionOperator.EqualBusinessId = "EqualBusinessId";
Sdk.Query.ConditionOperator.NotEqualBusinessId = "NotEqualBusinessId";
Sdk.Query.ConditionOperator.Mask = "Mask";
Sdk.Query.ConditionOperator.NotMask = "NotMask";
Sdk.Query.ConditionOperator.Contains = "Contains";
Sdk.Query.ConditionOperator.DoesNotContain = "DoesNotContain";
Sdk.Query.ConditionOperator.EqualUserLanguage = "EqualUserLanguage";
Sdk.Query.ConditionOperator.NotOn = "NotOn";
Sdk.Query.ConditionOperator.OlderThanXMonths = "OlderThanXMonths";
Sdk.Query.ConditionOperator.BeginsWith = "BeginsWith";
Sdk.Query.ConditionOperator.DoesNotBeginWith = "DoesNotBeginWith";
Sdk.Query.ConditionOperator.EndsWith = "EndsWith";
Sdk.Query.ConditionOperator.DoesNotEndWith = "DoesNotEndWith";
Sdk.Query.ConditionOperator.ThisFiscalYear = "ThisFiscalYear";
Sdk.Query.ConditionOperator.ThisFiscalPeriod = "ThisFiscalPeriod";
Sdk.Query.ConditionOperator.NextFiscalYear = "NextFiscalYear";
Sdk.Query.ConditionOperator.NextFiscalPeriod = "NextFiscalPeriod";
Sdk.Query.ConditionOperator.LastFiscalYear = "LastFiscalYear";
Sdk.Query.ConditionOperator.LastFiscalPeriod = "LastFiscalPeriod";
Sdk.Query.ConditionOperator.LastXFiscalYears = "LastXFiscalYears";
Sdk.Query.ConditionOperator.LastXFiscalPeriods = "LastXFiscalPeriods";
Sdk.Query.ConditionOperator.NextXFiscalYears = "NextXFiscalYears";
Sdk.Query.ConditionOperator.NextXFiscalPeriods = "NextXFiscalPeriods";
Sdk.Query.ConditionOperator.InFiscalYear = "InFiscalYear";
Sdk.Query.ConditionOperator.InFiscalPeriod = "InFiscalPeriod";
Sdk.Query.ConditionOperator.InFiscalPeriodAndYear = "InFiscalPeriodAndYear";
Sdk.Query.ConditionOperator.InOrBeforeFiscalPeriodAndYear = "InOrBeforeFiscalPeriodAndYear";
Sdk.Query.ConditionOperator.InOrAfterFiscalPeriodAndYear = "InOrAfterFiscalPeriodAndYear";
Sdk.Query.ConditionOperator.EqualUserOrUserTeams = "EqualUserOrUserTeams";
Sdk.Query.ConditionOperator.EqualUserTeams = "EqualUserTeams";
Sdk.Query.ConditionOperator.__enum = true;
Sdk.Query.ConditionOperator.__flags = true;
//Sdk.Query.ConditionOperator.prototype End
//--------------------------------------------------------------------
//Sdk.Query.FetchExpression.prototype Start
Sdk.Query.FetchExpression.prototype = new Sdk.Query.QueryBase('FetchExpression');
Sdk.Query.FetchExpression.prototype.toValueXml = function () {
 ///<summary>
 /// Gets the serialized fetch expression
 ///</summary>
 ///<returns type="String">
 /// The serialized fetch expression 
 ///</returns>
 return "<a:Query>" + Sdk.Xml.xmlEncode(this.getFetchXml()) + "</a:Query>";

}
//Sdk.Query.FetchExpression.prototype End
//--------------------------------------------------------------------
//Sdk.Query.FilterExpression.prototype Start
Sdk.Query.FilterExpression.prototype.toXml = function () {
 ///<summary>
 /// Gets the serialized filter expression
 ///</summary>
 ///<returns type="String">
 /// The serialized filter expression 
 ///</returns>
 return ["<a:FilterExpression>",
        this.toValueXml(),
        "</a:FilterExpression>"].join("");
};
Sdk.Query.FilterExpression.prototype.toValueXml = function () {
 ///<summary>
 /// Gets the serialized filter expression values
 ///</summary>
 ///<returns type="String">
 /// The serialized filter expression values
 ///</returns>
 var conditionString = "";
 if (this.getConditions().getCount() == 0) {
  conditionString = "<a:Conditions />";
 }
 else {
  var conditions = [];
  this.getConditions().forEach(function (ce, i) { conditions.push(ce.toXml()) });
  conditionString = ["<a:Conditions>",
            conditions.join(""),
            "</a:Conditions>"].join("");
 }

 var filtersString = "";
 if (this.getFilters().getCount() == 0) {
  filtersString = "<a:Filters />";
 }
 else {
  var filters = [];
  this.getFilters().forEach(function (fe, i) { filters.push(fe.toXml()) });
  filtersString = ["<a:Filters>",
            filters.join(""),
            "</a:Filters>"].join("");
 }

 var isQuickFindFilterString = "";
 if (this.getIsQuickFindFilter()) {
  isQuickFindFilterString = "<a:IsQuickFindFilter>true</a:IsQuickFindFilter>";
 }

 return [conditionString,
         "<a:FilterOperator>" + this.getFilterOperator() + "</a:FilterOperator>",
         filtersString,
         isQuickFindFilterString].join("");

};
//Sdk.Query.FilterExpression.prototype End
//--------------------------------------------------------------------
//Sdk.Query.JoinOperator.prototype Start
Sdk.Query.JoinOperator.prototype = {
 Inner: "Inner",
 LeftOuter: "LeftOuter",
 Natural: "Natural"
};
Sdk.Query.JoinOperator.Inner = "Inner";
Sdk.Query.JoinOperator.LeftOuter = "LeftOuter";
Sdk.Query.JoinOperator.Natural = "Natural";
Sdk.Query.JoinOperator.__enum = true;
Sdk.Query.JoinOperator.__flags = true;
//Sdk.Query.JoinOperator.prototype End
//--------------------------------------------------------------------
//Sdk.Query.LinkEntity.prototype Start
Sdk.Query.LinkEntity.prototype.toXml = function () {
 ///<summary>
 /// Gets the serialized  link entity 
 ///</summary>
 ///<returns type="String">
 /// The serialized  link entity 
 ///</returns>
 return ["<a:LinkEntity>",
            this.toValueXml(),
           "</a:LinkEntity>"].join("");

};
Sdk.Query.LinkEntity.prototype.toValueXml = function () {
 ///<summary>
 /// Gets the serialized link entity values
 ///</summary>
 ///<returns type="String">
 /// The serialized link entity values
 ///</returns>

 var columnsString;

 if (this.getColumns().getCount() == 0) {
  columnsString = "<a:Columns />";
 }
 else {
  columnsString = ["<a:Columns>",
  this.getColumns().toValueXml(),
  "</a:Columns>"].join("");
 }

 var linkCriteriaString = "<a:LinkCriteria />";

 if (this.getLinkCriteria() != null) {
  var conditionString = "";
  if (this.getLinkCriteria().getConditions().getCount() == 0) {
   conditionString = "<a:Conditions />";
  }
  else {
   var conditions = [];
   this.getLinkCriteria().getConditions().forEach(function (ce, i) { conditions.push(ce.toXml()) });
   conditionString = ["<a:Conditions>",
             conditions.join(""),
             "</a:Conditions>"].join("");
  }

  var filtersString = "";
  if (this.getLinkCriteria().getFilters().getCount() == 0) {
   filtersString = "<a:Filters />";
  }
  else {
   var filters = [];
   this.getLinkCriteria().getFilters().forEach(function (fe, i) { filters.push(fe.toXml()) });
   filtersString = ["<a:Filters>",
             filters.join(""),
             "</a:Filters>"].join("");
  }

  linkCriteriaString = ["<a:LinkCriteria>",
           conditionString,
           "<a:FilterOperator>" + this.getLinkCriteria().getFilterOperator() + "</a:FilterOperator>",
           filtersString,
          "</a:LinkCriteria>"].join("");

 }



 var linkEntitiesString = "<a:LinkEntities />";
 if (this.getLinkEntities().getCount() > 0) {
  var linkEntities = [];
  this.getLinkEntities().forEach(function (le, i) { linkEntities.push(le.toXml()) });
  linkEntitiesString = ["<a:LinkEntities>",
  linkEntities.join(""),
  "</a:LinkEntities>"].join("");
 }

 return [columnsString,
             (this.getEntityAlias() == null) ? "<a:EntityAlias i:nil=\"true\" />" : "<a:EntityAlias>" + this.getEntityAlias() + "</a:EntityAlias>",
             "<a:JoinOperator>" + this.getJoinOperator() + "</a:JoinOperator>",
             linkCriteriaString,
             linkEntitiesString,
             "<a:LinkFromAttributeName>" + this.getLinkFromAttributeName() + "</a:LinkFromAttributeName>",
													"<a:LinkFromEntityName>" + this.getLinkFromEntityName() + "</a:LinkFromEntityName>",
													"<a:LinkToAttributeName>" + this.getLinkToAttributeName() + "</a:LinkToAttributeName>",
													"<a:LinkToEntityName>" + this.getLinkToEntityName() + "</a:LinkToEntityName>"
 ].join("");

};
//Sdk.Query.LinkEntity.prototype End
//--------------------------------------------------------------------
//Sdk.Query.LogicalOperator.prototype Start
Sdk.Query.LogicalOperator.prototype = {
 And: "And",
 Or: "Or"
};
Sdk.Query.LogicalOperator.And = "And";
Sdk.Query.LogicalOperator.Or = "Or";
Sdk.Query.LogicalOperator.__enum = true;
Sdk.Query.LogicalOperator.__flags = true;
//Sdk.Query.LogicalOperator.prototype End
//--------------------------------------------------------------------
//Sdk.Query.OrderExpression.prototype Start
Sdk.Query.OrderExpression.prototype.toXml = function () {
 ///<summary>
 /// Gets the serialized order expression 
 ///</summary>
 ///<returns type="String">
 /// The serialized order expression 
 ///</returns>
 return ["<a:OrderExpression>",
          this.toValueXml(),
         "</a:OrderExpression>"].join("");
}
Sdk.Query.OrderExpression.prototype.toValueXml = function () {
 ///<summary>
 /// Gets the serialized order expression values
 ///</summary>
 ///<returns type="String">
 /// The serialized order expression values
 ///</returns>
 return ["<a:AttributeName>" + this.getAttributeName() + "</a:AttributeName>",
         "<a:OrderType>" + this.getOrderType() + "</a:OrderType>"].join("");
}

//Sdk.Query.OrderType 
Sdk.Query.OrderType.prototype = {
 Ascending: "Ascending",
 Descending: "Descending"
};

Sdk.Query.OrderType.Ascending = "Ascending"; // Value = 0
Sdk.Query.OrderType.Descending = "Descending"; // Value = 1
Sdk.Query.OrderType.__enum = true;
Sdk.Query.OrderType.__flags = true;
//Sdk.Query.OrderExpression.prototype End
//--------------------------------------------------------------------
//Sdk.Query.PagingInfo.prototype Start
Sdk.Query.PagingInfo.prototype.toXml = function () {
 ///<summary>
 /// Gets the serialized paging info
 ///</summary>
 ///<returns type="String">
 /// The serialized paging info
 ///</returns>
 return ["<a:PageInfo>",
 this.toValueXml(),
"</a:PageInfo>"].join("");
}
Sdk.Query.PagingInfo.prototype.toValueXml = function () {
 ///<summary>
 /// Gets the serialized paging info values
 ///</summary>
 ///<returns type="String">
 /// The serialized paging info values
 ///</returns>
 return ["<a:Count>" + this.getCount() + "</a:Count>",
  "<a:PageNumber>" + this.getPageNumber() + "</a:PageNumber>",
  (this.getPagingCookie() == null) ? "<a:PagingCookie i:nil=\"true\" />" : "<a:PagingCookie>" + this.getPagingCookie() + "</a:PagingCookie>",
  "<a:ReturnTotalRecordCount>" + this.getReturnTotalRecordCount() + "</a:ReturnTotalRecordCount>"].join("");

}
//Sdk.Query.PagingInfo.prototype End
//--------------------------------------------------------------------
//Sdk.Query.QueryByAttribute.prototype Start
Sdk.Query.QueryByAttribute.prototype = new Sdk.Query.QueryBase('QueryByAttribute');

Sdk.Query.QueryByAttribute.prototype.addAttributeValue = function (attributeValue) {
 ///<summary>
 /// Adds the attribute with values to include in the query
 ///</summary>
 ///<param name="attributeValue" type="Sdk.AttributeBase">
 /// One of the classes that inherit from Sdk.AttributeBase including the value to use as criteria.
 ///</param>
 if (attributeValue instanceof Sdk.AttributeBase) {
  this.getAttributeValues().add(attributeValue);
 }
 else {
  throw new Error("Sdk.Query.QueryByAttribute addAttributeValue method attributeValue parameter must be an Sdk.AttributeBase.")
 }

}

Sdk.Query.QueryByAttribute.prototype.addColumn = function (columnName) {
 ///<summary>
 /// Adds a column to the ColumnSet used by the query
 ///</summary>
 ///<param name="columnName" type="String">
 /// The logical name of an attribute to be returned by the query
 ///</param>
 var _methodName = "Sdk.Query.QueryByAttribute addColumn ";

 if (typeof columnName == "string") {
  try {
   this.getColumnSet().getColumns().add(columnName);
  }
  catch (e) {
   throw new Error(_methodName + "Error: " + e.message);
  }
 }
 else {
  throw new Error(_methodName + "columnName parameter must be a String.");
 }

}

Sdk.Query.QueryByAttribute.prototype.addOrder = function (order) {
 ///<summary>
 /// Adds an order to apply to the results of the query
 ///</summary>
 ///<param name="order" type="Sdk.Query.OrderExpression">
 /// An order expression
 ///</param>
 if (order instanceof Sdk.Query.OrderExpression) {
  this.getOrders().add(order);
 }
 else {
  throw new Error("Sdk.Query.QueryByAttribute addOrder method order parameter must be an Sdk.Query.OrderExpression.");
 }
}

Sdk.Query.QueryByAttribute.prototype.removeAttributeValue = function (attributeValue, errorIfNotFound) {
 ///<summary>
 /// Removes an attribute with values to include in the query
 ///</summary>
 ///<param name="attributeValue" type="Sdk.AttributeBase">
 /// One of the classes that inherit from Sdk.AttributeBase including the value to use as criteria.
 ///</param>
 ///<param name="errorIfNotFound"  optional="true" type="Boolean">
 /// Whether to throw an error when the attribute to remove is not found. The default is false
 ///</param>
 if (attributeValue instanceof Sdk.AttributeBase) {
  var attributeToRemove, attributeFound = false;
  this.getAttributeValues().forEach(function (a, i) {
   if ((a.getName() == attributeValue.getName()) && (a.getType() == attributeValue.getType())) {
    attributeToRemove = a;
    attributeFound = true;
   }
  });
  if (attributeFound) {
   this.getAttributeValues().remove(attributeToRemove);
  }
  else {
   if ((typeof errorIfNotFound == "boolean") && (errorIfNotFound)) {
    throw new Error(Sdk.Util.format("An attribute named {0} of type {1} was not found in the collection.", [attributeValue.getName(), attributeValue.getType()]));
   }
  }

 }
 else {
  throw new Error("Sdk.Query.QueryByAttribute.removeAttributeValue method attributeValue parameter must be one of the classes that inherit from Sdk.AttributeBase. ");
 }
}

Sdk.Query.QueryByAttribute.prototype.removeColumn = function (columnName, errorIfNotFound) {
 ///<summary>
 /// Removes a column from the ColumnSet used by the query
 ///</summary>
 ///<param name="columnName" type="String">
 /// The logical name of an attribute to be removed from the ColumnSet
 ///</param>
 ///<param name="errorIfNotFound"  optional="true" type="Boolean">
 /// Whether to throw an error when the column to remove is not found. The default is false
 ///</param>
 this.getColumnSet().removeColumn(columnName, errorIfNotFound);

}

Sdk.Query.QueryByAttribute.prototype.toXml = function () {
 ///<summary>
 /// Gets the serialized QueryByAttribute
 ///</summary>
 ///<returns type="String">
 /// The serialized QueryByAttribute
 ///</returns>

 return ["<query i:type=\"a:QueryByAttribute\">",
this.toValueXml(),
"</query>"].join("");

}

Sdk.Query.QueryByAttribute.prototype.toValueXml = function () {
 ///<summary>
 /// Gets the serialized QueryByAttribute values
 ///</summary>
 ///<returns type="String">
 /// The serialized QueryByAttribute values
 ///</returns>

 var ordersString = "";
 if (this.getOrders().getCount() == 0) {
  ordersString = "<a:Orders />";
 }
 else {
  var orders = [];
  this.getOrders().forEach(function (or, i) { orders.push(or.toXml()) });
  ordersString = ["<a:Orders>",
        orders.join(""),
        "</a:Orders>"].join("");
 }

 var attributesString = "";
 if (this.getAttributeValues().getCount() == 0) {
  attributesString = "<a:Attributes />"
 }
 else {
  var attributes = ["<a:Attributes>"];
  this.getAttributeValues().forEach(function (a, i) {
   attributes.push("<f:string>" + a.getName() + "</f:string>")
  });
  attributes.push("</a:Attributes>")
  attributesString = attributes.join("");
 }

 var valuesString = "";
 if (this.getAttributeValues().getCount() == 0) {
  valuesString = "<a:Values />"
 }
 else {
  var values = ["<a:Values>"];
  this.getAttributeValues().forEach(function (a, i) {
   var type = a.getType()
   var typeToSend = type;
   var namespace = "c";
   var value = a.getValue();
   if (value == null) {
    values.push("<f:anyType i:nil=\"true\" />");
   }
   else {
    switch (type) {
     case "boolean":
     case "decimal":
     case "double":
     case "int":
     case "long":
     case "string":
      break;
     case "booleanManagedProperty":
      typeToSend = "boolean";
      value = value.getValue();
      break;
     case "dateTime":
      value = value.toISOString();
      break;
     case "entityCollection":
      //This doesn't work with managed code either
      throw new error("Entity Collection type not implemented in Sdk.Query.QueryByAttribute")
      break;
     case "entityReference":
      //Just use the Guid value
      typeToSend = "guid";
      namespace = "e";
      value = value.getId();
      break;
     case "guid":
      namespace = "e";
      break;
     case "money":
      typeToSend = "decimal";
      break;
     case "optionSet":
      typeToSend = "int";
      break;
     default:
      throw new Error("Unexpected type found in Sdk.Query.QueryByAttribute.toValueXml")
      break;
    }

    values.push(Sdk.Util.format("<f:anyType i:type=\"{0}:{1}\">{2}</f:anyType>", [namespace, typeToSend, value.toString()]));
   }




  });
  values.push("</a:Values>")
  valuesString = values.join("");
 }

 var columnSetString = "<a:ColumnSet i:nil=\"true\" />";
 if (this.getColumnSet().getCount() > 0) {
  columnSetString = ["<a:ColumnSet>",
  this.getColumnSet().toValueXml(),
  "</a:ColumnSet>"].join("");

 }

 return [attributesString,
  columnSetString,
  "<a:EntityName>" + this.getEntityName() + "</a:EntityName>",
  ordersString,
  valuesString,
  (this.getPageInfo() == null) ? "" : this.getPageInfo().toXml(),
  (this.getTopCount() == null) ? "" : "<a:TopCount>" + this.getTopCount() + "</a:TopCount>"].join("");

}
//Sdk.Query.QueryByAttribute.prototype End
//--------------------------------------------------------------------
//Sdk.Query.QueryExpression.prototype Start
Sdk.Query.QueryExpression.prototype = new Sdk.Query.QueryBase('QueryExpression');

Sdk.Query.QueryExpression.prototype.addColumn = function (columnName) {
 ///<summary>
 /// Adds the specified column to the column set
 ///</summary>
 ///<param name="columnName" type="String">
 /// The logical name of the column to add
 ///</param>
 if (typeof columnName == "string") {
  try {
   this.getColumnSet().addColumn(columnName);
  }
  catch (e) {
   throw new Error("Sdk.Query.QueryExpression addColumn error: " + e.message);
  }
 }
 else {
  throw new Error("Sdk.Query.QueryExpression addColumn method columnName parameter must be a String.");
 }

}

Sdk.Query.QueryExpression.prototype.addCondition = function (entityName, attributeName, conditionOperator, values) {
 ///<summary>
 /// Contains a condition expression used to filter the results of the query.
 ///</summary>
 ///<param name="entityName" type="String" optional="false" mayBeNull="true">
 /// The logical name of the entity in the condition expression.
 ///</param>
 ///<param name="attributeName" type="String" optional="false" mayBeNull="false">
 /// The logical name of the attribute in the condition expression.
 ///</param>
 ///<param name="operator" type="Sdk.Query.ConditionOperator" optional="false" mayBeNull="false">
 /// The condition operator.
 ///</param>
 ///<param name="values" type="Sdk.Query.ValueBase" optional="true" mayBeNull="true">
 /// <para>The value(s) to compare</para>
 /// <para>Use one of the following classes that inherit from Sdk.Query.ValueBase: </para>
 /// <para> - Sdk.Query.Booleans </para>
 /// <para> - Sdk.Query.BooleanManagedProperties</para>
 /// <para> - Sdk.Query.Dates </para>
 /// <para> - Sdk.Query.Decimals </para>
 /// <para> - Sdk.Query.Doubles </para>
 /// <para> - Sdk.Query.EntityReferences </para>
 /// <para> - Sdk.Query.Guids </para>
 /// <para> - Sdk.Query.Ints </para>
 /// <para> - Sdk.Query.Longs </para>
 /// <para> - Sdk.Query.Money </para>
 /// <para> - Sdk.Query.OptionSets </para>
 /// <para> - Sdk.Query.Strings </para>
 ///</param>
 this.getCriteria().addCondition(entityName, attributeName, conditionOperator, values);
}

Sdk.Query.QueryExpression.prototype.addLink = function (firstParam, linkFromAttributeName, linkToAttributeName, joinOperator) {
 ///<summary>
 /// Adds the specified link to the query expression setting the entity name to link to, the attribute name to link from and the attribute name to link to. 
 ///</summary>
 ///<param name="firstParam" type="Object">
 /// <para>Either:</para>
 /// <para>An Sdk.Query.LinkEntity instance. No other parameters are required.</para>
 /// <para>Or</para>
 /// <para>The name of entity to link from. The remaining parameters are required.</para>
 ///</param>
 ///<param name="linkFromAttributeName" type="String">
 /// The name of the attribute to link from.
 ///</param>
 ///<param name="linkToAttributeName" type="String">
 /// The name of the attribute to link to.
 ///</param>
 ///<param name="joinOperator" type="Sdk.Query.JoinOperator" optional="true">
 /// The join operator. The default value is Inner
 ///</param>

 if (firstParam instanceof Sdk.Query.LinkEntity) {
  this.getLinkEntities().add(firstParam);
 }
 else {
  if (typeof firstParam == "string" && typeof linkFromAttributeName == "string" && typeof linkToAttributeName == "string") {
   if (joinOperator == null) {
    this.getLinkEntities().add(new Sdk.Query.LinkEntity(this.getEntityName(), firstParam, linkFromAttributeName, linkToAttributeName, Sdk.Query.JoinOperator.Inner))

   }
   else {
    if (joinOperator == Sdk.Query.JoinOperator.Inner || Sdk.Query.JoinOperator.LeftOuter || Sdk.Query.JoinOperator.Natural) {
     this.getLinkEntities().add(new Sdk.Query.LinkEntity(this.getEntityName(), firstParam, linkFromAttributeName, linkToAttributeName, joinOperator))
    }
    else {
     throw new Error("Sdk.Query.QueryExpression addLink method requires that the joinOperator parameter is an Sdk.Query.JoinOperator value");
    }
   }
  }
  else {
   throw new Error("Sdk.Query.QueryExpression addLink method requires that the linkToEntityName, linkFromAttributeName, and linkToAttributeName parameters are string values");
  }
 }
};

Sdk.Query.QueryExpression.prototype.addOrder = function (attributeName, orderType) {
 ///<summary>
 /// Adds the specified order expression to the query expression. 
 ///</summary>
 ///<param name="attributeName" type="String">
 /// The name of the attribute.
 ///</param>
 ///<param name="orderType" type="Sdk.Query.OrderType" optional="true">
 /// The order, ascending or descending. Ascending is the default if not specified.
 ///</param>
 if (typeof attributeName == "string") {
  if (orderType == null) {
   this.getOrders().add(new Sdk.Query.OrderExpression(attributeName));
  }
  else {
   if (orderType == Sdk.Query.OrderType.Ascending || orderType == Sdk.Query.OrderType.Descending) {
    this.getOrders().add(new Sdk.Query.OrderExpression(attributeName, orderType));
   }
   else {
    throw new Error("Sdk.Query.QueryExpression addOrder method requires that the orderType parameter is an Sdk.Query.OrderType value");
   }
  }
 }
 else {
  throw new Error("Sdk.Query.QueryExpression addOrder method requires that the attributeName parameter is a string value");
 }


};

Sdk.Query.QueryExpression.prototype.toXml = function () {
 ///<summary>
 /// Gets the serialized QueryExpression
 ///</summary>
 ///<returns type="String">
 /// The serialized QueryExpression
 ///</returns>
 return ["<query i:type=\"a:QueryExpression\">",
this.toValueXml(),
"</query>"].join("");
}

Sdk.Query.QueryExpression.prototype.toValueXml = function () {
 ///<summary>
 /// Gets the serialized QueryExpression values
 ///</summary>
 ///<returns type="String">
 /// The serialized QueryExpression values
 ///</returns>

 var linkEntitiesString = "";
 if (this.getLinkEntities().getCount() == 0) {
  linkEntitiesString = "<a:LinkEntities />"
 }
 else {
  var linkEntities = [];
  this.getLinkEntities().forEach(function (le, i) { linkEntities.push(le.toXml()) });
  linkEntitiesString = ["<a:LinkEntities>",
        linkEntities.join(""),
        "</a:LinkEntities>"].join("");
 }

 var ordersString = "";
 if (this.getOrders().getCount() == 0) {
  ordersString = "<a:Orders />";
 }
 else {
  var orders = [];
  this.getOrders().forEach(function (or, i) { orders.push(or.toXml()) });
  ordersString = ["<a:Orders>",
        orders.join(""),
        "</a:Orders>"].join("");
 }


 return ["<a:ColumnSet>", this.getColumnSet().toValueXml(), "</a:ColumnSet>",
["<a:Criteria>",
this.getCriteria().toValueXml(),
"</a:Criteria>"].join(""),
"<a:Distinct>" + this.getDistinct() + "</a:Distinct>",
"<a:EntityName>" + this.getEntityName() + "</a:EntityName>",
linkEntitiesString,
ordersString,
(this.getPageInfo() == null) ? "" : this.getPageInfo().toXml(),
"<a:NoLock>" + this.getNoLock() + "</a:NoLock>",
(this.getTopCount() == null) ? "" : "<a:TopCount>" + this.getTopCount() + "</a:TopCount>"].join("");
}
//Sdk.Query.QueryExpression.prototype End

//--------------------------------------------------------------------
//Sdk.Query.ValueBase.prototype Start
Sdk.Query.Booleans.prototype = new Sdk.Query.ValueBase();
Sdk.Query.BooleanManagedProperties.prototype = new Sdk.Query.ValueBase();
Sdk.Query.Dates.prototype = new Sdk.Query.ValueBase();
Sdk.Query.Decimals.prototype = new Sdk.Query.ValueBase();
Sdk.Query.Doubles.prototype = new Sdk.Query.ValueBase();
Sdk.Query.EntityReferences.prototype = new Sdk.Query.ValueBase();
Sdk.Query.Guids.prototype = new Sdk.Query.ValueBase();
Sdk.Query.Ints.prototype = new Sdk.Query.ValueBase();
Sdk.Query.Longs.prototype = new Sdk.Query.ValueBase();
Sdk.Query.Money.prototype = new Sdk.Query.ValueBase();
Sdk.Query.OptionSets.prototype = new Sdk.Query.ValueBase();
Sdk.Query.Strings.prototype = new Sdk.Query.ValueBase();

//Sdk.Query.ValueBase.prototype End
//--------------------------------------------------------------------
//Sdk.RelatedEntitiesCollection.prototype Start
Sdk.RelatedEntitiesCollection.prototype.add = function (relationshipSchemaName, entity) {
 ///<summary>
 /// Adds an entity to the related entities
 ///</summary>
 ///<param name="relationshipSchemaName" type="String"  optional="false" mayBeNull="false">
 /// The relationship SchemaName
 ///</param>
 ///<param name="entity" type="Sdk.Entity"  optional="false" mayBeNull="false">
 /// The entity to add
 ///</param>
 if (relationshipSchemaName == null || typeof relationshipSchemaName != "string") {
  throw new Error("Sdk.RelatedEntitiesCollection add method relationshipSchemaName parameter is required and must be a string.");
 }
 if (entity == null || !(entity instanceof Sdk.Entity)) {
  throw new Error("Sdk.RelatedEntitiesCollection add method entity parameter is required and must be an Sdk.Entity.");
 }

 var relationshipExists = false;
 var thisREC = this; //'this' was becoming window somehow in the loop..
 this.getRelationshipEntities().forEach(function (rec, i) {
  if (rec.getRelationship() == relationshipSchemaName) {
   relationshipExists = true;
   rec.getEntityCollection().addEntity(entity);
   //flag that something changed
   thisREC.setIsChanged(true);
  }
 });
 if (!relationshipExists) {
  var rec = new Sdk.RelationshipEntityCollection(relationshipSchemaName);
  rec.getEntityCollection().addEntity(entity);
  this.getRelationshipEntities().add(rec);
  //flag that something changed
  this.setIsChanged(true);
 }

}
Sdk.RelatedEntitiesCollection.prototype.addRelationship = function (relationshipSchemaName) {
 ///<summary>
 /// Adds a relationship
 ///</summary>
 ///<param name="relationshipSchemaName" type="String"  optional="false" mayBeNull="false">
 /// The relationship SchemaName
 ///</param>
 if (typeof relationshipSchemaName == "string") {
  this.getRelationshipEntities().add(new Sdk.RelationshipEntityCollection(relationshipSchemaName));
  //flag that something changed
  this.setIsChanged(true);
 }
 else {
  throw new Error("Sdk.RelatedEntitiesCollection.addRelationship method relationshipSchemaName parameter must be a string.")
 }

}
Sdk.RelatedEntitiesCollection.prototype.addRelationshipEntityCollection = function (relationshipEntityCollection) {
 ///<summary>
 /// Adds a RelationshipEntityCollection to the related entities
 ///</summary>
 ///<param name="relationshipEntityCollection" type="Sdk.RelationshipEntityCollection"  optional="false" mayBeNull="false">
 /// The RelationshipEntityCollection
 ///</param>
 if (!(relationshipEntityCollection instanceof Sdk.RelationshipEntityCollection)) {
  throw new Error("Sdk.RelatedEntitiesCollection addRelationshipEntityCollection method relationshipEntityCollection parameter is required and must be an Sdk.RelationshipEntityCollection.");
 }
 var relationshipExists = false;
 this.getRelationshipEntities().forEach(function (rec, i) {
  if (rec.getRelationship() == relationshipEntityCollection.getRelationship()) {
   relationshipExists = true;

   relationshipEntityCollection.getEntityCollection().forEach(function (a, i) {
    rec.getEntityCollection().add(a);
    //flag that something changed
    this.setIsChanged(true);
   });
  }
 });

 if (!relationshipExists) {
  this.getRelationshipEntities().add(relationshipEntityCollection);
  //flag that something changed
  this.setIsChanged(true);
 }

}
Sdk.RelatedEntitiesCollection.prototype.clear = function () {
 ///<summary>
 /// Clears all related entities.
 ///</summary>
 this.getRelationshipEntities().clear();
 //flag that something changed
 this.setIsChanged(true);
}
Sdk.RelatedEntitiesCollection.prototype.removeRelationship = function (relationshipSchemaName) {
 ///<summary>
 /// Removes an entity relationship.
 ///</summary>
 ///<param name="relationshipSchemaName" type="String" optional="false" mayBeNull="false">
 /// The schema name of the entity relatinoship to remove.
 ///</param>
 if (typeof relationshipSchemaName == "string") {
  var relationshipToRemove = null;
  this.getRelationshipEntities().forEach(function (r, i) {
   if (r.getRelationship() == relationshipSchemaName) {
    relationshipToRemove = r;
   }
  });

  if (relationshipToRemove != null) {
   this.getRelationshipEntities().remove(relationshipToRemove);
   //flag that something changed
   this.setIsChanged(true);
  }
 }
 else {
  throw new Error("Sdk.RelatedEntitiesCollection.removeRelationship method relationshipSchemaName parameter must be a string.")
 }
}
Sdk.RelatedEntitiesCollection.prototype.toXml = function () {
 ///<summary>
 /// Gets the serialized RelatedEntitiesCollection
 ///</summary>
 ///<returns type="String">
 /// The serialized RelatedEntitiesCollection
 ///</returns>
 if (this.getRelationshipEntities().getCount() == 0) {
  return "<a:RelatedEntities />";
 }
 else {
  var _xml = ["<a:RelatedEntities>"];

  this.getRelationshipEntities().forEach(function (rec, i) {
   _xml.push(rec.toXml());
  });
  _xml.push("</a:RelatedEntities>");
  return _xml.join("");
 }
}
Sdk.RelatedEntitiesCollection.prototype.view = function () {
 ///<summary>
 /// Returns a view of the data in an RelatedEntitiesCollection
 ///</summary>
 // <returns type="Object" />
 var relatedEntities = {};
 this.getRelationshipEntities().forEach(function (re, i) {
  relatedEntities[re.getRelationship()] = re.getEntityCollection().view();
 });
 return relatedEntities;
}
Sdk.RelatedEntitiesCollection.prototype.getRelatedEntitiesByRelationshipName = function (relationshipSchemaName) {
 ///<summary>
 /// Adds an entity to the related entities
 ///</summary>
 ///<param name="relationshipSchemaName" type="String"  optional="false" mayBeNull="false">
 /// The relationship SchemaName
 ///</param>
 ///<returns type="Sdk.EntityCollection">
 /// The related entities 
 ///</returns>

 if (typeof relationshipSchemaName == "string") {
  var returnValue = new Sdk.EntityCollection();
  this.getRelationshipEntities().forEach(function (re, i) {
   if (re.getRelationship() == relationshipSchemaName) {
    returnValue = re.getEntityCollection();
   }
  });
  return returnValue
 }
 else {
  throw new Error("Sdk.RelatedEntitiesCollection.getRelatedEntitiesByRelationshipName method relationshipSchemaName parameter must be a string.")
 }
}
//Sdk.RelatedEntitiesCollection.prototype End
//--------------------------------------------------------------------
//Sdk.RelationshipEntityCollection.prototype Start
Sdk.RelationshipEntityCollection.prototype.toXml = function () {
 ///<summary>
 /// Gets the serialized RelationshipEntityCollection
 ///</summary>
 ///<returns type="String">
 /// The serialized RelationshipEntityCollection
 ///</returns>
 var _xml = [
 "<a:KeyValuePairOfRelationshipEntityCollectionX_PsK4FkN>",
  "<b:key>",
   "<a:PrimaryEntityRole i:nil=\"true\" />",
   "<a:SchemaName>", this.getRelationship(), "</a:SchemaName>",
  "</b:key>",
  "<b:value>",
   this.getEntityCollection().toValueXml(),
  "</b:value>",
 "</a:KeyValuePairOfRelationshipEntityCollectionX_PsK4FkN>"];
 return _xml.join("");
}
//Sdk.RelationshipEntityCollection.prototype End
//--------------------------------------------------------------------
//Sdk.RelationshipQuery.prototype Start
Sdk.RelationshipQuery.prototype.toXml = function () {
 ///<summary>
 /// Gets the serialized RelationshipQuery
 ///</summary>
 ///<returns type="String">
 /// The serialized RelationshipQuery
 ///</returns>
 var _xml = ["<a:KeyValuePairOfRelationshipQueryBaseX_PsK4FkN>",
 this.toValueXml(),
 "</a:KeyValuePairOfRelationshipQueryBaseX_PsK4FkN>"];

 return _xml.join("");
}
Sdk.RelationshipQuery.prototype.toValueXml = function () {
 ///<summary>
 /// Gets the serialized RelationshipQuery values
 ///</summary>
 ///<returns type="String">
 /// The serialized RelationshipQuery values
 ///</returns>
 var type = "QueryExpression";
 if (this.getQuery() instanceof Sdk.Query.FetchExpression) {
  type = "FetchExpression";
 }
 if (this.getQuery() instanceof Sdk.Query.QueryByAttribute) {
  type = "QueryByAttribute";
 }

 return [
  "<b:key>",
     "<a:PrimaryEntityRole i:nil=\"true\" />",
     "<a:SchemaName>", this.getRelationshipName(), "</a:SchemaName>",
   "</b:key>",
   "<b:value i:type=\"a:", type, "\">",
    this.getQuery().toValueXml(),
  "</b:value>"].join("");

}
//Sdk.RelationshipQuery.prototype End
//--------------------------------------------------------------------
//Sdk.RelationshipQueryCollection.prototype Start
Sdk.RelationshipQueryCollection.prototype.add = function (relationshipQuery) {
 ///<summary>
 /// Adds a Sdk.RelationshipQuery to the collection
 ///</summary>
 ///<param name="relationshipQuery" type="Sdk.RelationshipQuery" optional="false" mayBeNull="false">
 /// The Sdk.RelationshipQuery to add to the collection.
 ///</param>
 this.getRelationshipQueries().add(relationshipQuery);
}
Sdk.RelationshipQueryCollection.prototype.toValueXml = function () {
 ///<summary>
 /// Gets the serialized RelationshipQueryCollection values
 ///</summary>
 ///<returns type="String">
 /// The serialized RelationshipQueryCollection values
 ///</returns>
 var _xml = [];
 this.getRelationshipQueries().forEach(function (rq, i) {
  _xml.push(rq.toXml());
 });
 return _xml.join("");
}
//Sdk.RelationshipQueryCollection.prototype End

//--------------------------------------------------------------------
//Sdk.RolePrivilege.prototype Start

Sdk.RolePrivilege.prototype.toXml = function () {
 return ["<g:RolePrivilege>", this.toValueXml(), "</g:RolePrivilege>"].join("");
}
Sdk.RolePrivilege.prototype.toValueXml = function () {
 return ["<g:BusinessUnitId>", this.getBusinessId(), "</g:BusinessUnitId>",
        "<g:Depth>", this.getDepth(), "</g:Depth>",
        "<g:PrivilegeId>", this.getPrivilegeId(), "</g:PrivilegeId>"].join("");
}
Sdk.RolePrivilege.prototype.view = function () {
 var rv = {};
 rv.BusinessId = this.getBusinessId();
 rv.Depth = this.getDepth();
 rv.PrivilegeId = this.getPrivilegeId();
 return rv;
}
//Sdk.RolePrivilege.prototype End
//--------------------------------------------------------------------
//Sdk.RollupType.prototype Start
Sdk.RollupType.prototype = {
 Extended: "Extended",
 None: "None",
 Related: "Related"
};
Sdk.RollupType.All = "All";
Sdk.RollupType.Extended = "Extended";
Sdk.RollupType.None = "None";
Sdk.RollupType.Related = "Related";
Sdk.RollupType.__enum = true;
Sdk.RollupType.__flags = true;
//Sdk.RollupType.prototype End
//--------------------------------------------------------------------
//Sdk.TargetFieldType.prototype Start
Sdk.TargetFieldType.prototype = {
 All: "All",
 ValidForCreate: "ValidForCreate",
 ValidForRead: "ValidForRead",
 ValidForUpdate: "ValidForUpdate"
};
Sdk.TargetFieldType.All = "All";
Sdk.TargetFieldType.ValidForCreate = "ValidForCreate";
Sdk.TargetFieldType.ValidForRead = "ValidForRead";
Sdk.TargetFieldType.ValidForUpdate = "ValidForUpdate";
Sdk.TargetFieldType.__enum = true;
Sdk.TargetFieldType.__flags = true;
//Sdk.TargetFieldType.prototype End

//--------------------------------------------------------------------
//Sdk.TimeInfo.prototype Start
Sdk.TimeInfo.prototype.view = function () {
 ///<summary>
 /// Returns a view of the data in an TimeInfo
 ///</summary>
 // <returns type="Object" />
 var rv = {};
 rv.ActivityStatusCode = this.getActivityStatusCode();
 rv.CalendarId = this.getCalendarId();
 rv.DisplayText = this.getDisplayText();
 rv.Effort = this.getEffort();
 rv.End = this.getEnd();
 rv.IsActivity = this.getIsActivity();
 rv.SourceId = this.getSourceId();
 rv.SourceTypeCode = this.getSourceTypeCode();
 rv.Start = this.getStart();
 rv.SubCode = this.getSubCode();
 rv.TimeCode = this.getTimeCode();
 return rv;
}

Sdk.SubCode.prototype = {
 Appointment: "Appointment",
 Break: "Break",
 Committed: "Committed",
 Holiday: "Holiday",
 ResourceCapacity: "ResourceCapacity",
 ResourceServiceRestriction: "ResourceServiceRestriction",
 ResourceStartTime: "ResourceStartTime",
 Schedulable: "Schedulable",
 ServiceCost: "ServiceCost",
 ServiceRestriction: "ServiceRestriction",
 Uncommitted: "Uncommitted",
 Unspecified: "Unspecified",
 Vacation: "Vacation"

};
Sdk.SubCode.Appointment = "Appointment";
Sdk.SubCode.Break = "Break";
Sdk.SubCode.Committed = "Committed";
Sdk.SubCode.Holiday = "Holiday";
Sdk.SubCode.ResourceCapacity = "ResourceCapacity";
Sdk.SubCode.ResourceServiceRestriction = "ResourceServiceRestriction";
Sdk.SubCode.ResourceStartTime = "ResourceStartTime";
Sdk.SubCode.Schedulable = "Schedulable";
Sdk.SubCode.ServiceCost = "ServiceCost";
Sdk.SubCode.ServiceRestriction = "ServiceRestriction";
Sdk.SubCode.Uncommitted = "Uncommitted";
Sdk.SubCode.Unspecified = "Unspecified";
Sdk.SubCode.Vacation = "Vacation";
Sdk.SubCode.__enum = true;
Sdk.SubCode.__flags = true;


Sdk.TimeCode.prototype = {
 Available: "Available",
 Busy: "Busy",
 Filter: "Filter",
 Unavailable: "Unavailable"
};
Sdk.TimeCode.Available = "Available";
Sdk.TimeCode.Busy = "Busy";
Sdk.TimeCode.Filter = "Filter";
Sdk.TimeCode.Unavailable = "Unavailable";
Sdk.TimeCode.__enum = true;
Sdk.TimeCode.__flags = true;



//Sdk.TimeInfo.prototype End
//--------------------------------------------------------------------
//Sdk.TraceInfo.prototype Start

Sdk.TraceInfo.prototype.view = function () {
 ///<summary>
 /// Returns a view of the data in an TraceInfo instance
 ///</summary>
 // <returns type="Object" />
 var rv = {}
 rv.ErrorInfoList = [];
 this.getErrorInfoList().forEach(function (e, i) {
  rv.ErrorInfoList.push(e.view());
 });
 return rv;
}

Sdk.ErrorInfo.prototype.view = function () {
 ///<summary>
 /// Returns a view of the data in an ErrorInfo instance
 ///</summary>
 // <returns type="Object" />
 var rv = {}
 rv.ErrorCode = this.getErrorCode();
 rv.ResourceList = [];
 this.getResourceList().forEach(function (r, i) {
  rv.ResourceList.push(r.view());
 });
 return rv;
}

Sdk.ResourceInfo.prototype.view = function () {
 ///<summary>
 /// Returns a view of the data in an ResourceInfo instance
 ///</summary>
 // <returns type="Object" />
 var rv = {}
 rv.DisplayName = this.getDisplayName()
 rv.EntityName = this.getEntityName()
 rv.Id = this.getId();
 return rv;
}
//Sdk.TraceInfo.prototype End
//--------------------------------------------------------------------
//Sdk.ValidationResult.prototype Start

Sdk.ValidationResult.prototype.view = function () {
 ///<summary>
 /// Returns a view of the data in an ValidationResult instance
 ///</summary>
 // <returns type="Object" />
 var rv = {};
 rv.ActivityId = this.getActivityId();
 var testTraceInfo = this.getTraceInfo();
 rv.TraceInfo = (testTraceInfo == null) ? null : testTraceInfo.view();
 rv.ValidationSuccess = this.getValidationSuccess();

 return rv;

}
//Sdk.ValidationResult.prototype End

//IE 8 Date doesn't provide toISOString
if (!Date.prototype.toISOString) {
 (function () {

  function pad(number) {
   if (number < 10) {
    return '0' + number;
   }
   return number;
  }

  Date.prototype.toISOString = function () {
   return [this.getUTCFullYear(),
     '-', pad(this.getUTCMonth() + 1),
     '-', pad(this.getUTCDate()),
     'T', pad(this.getUTCHours()),
     ':', pad(this.getUTCMinutes()),
     ':', pad(this.getUTCSeconds()),
     '.', (this.getUTCMilliseconds() / 1000).toFixed(3).slice(2, 5),
     'Z'].join("");
  };

 }());
}

//End library