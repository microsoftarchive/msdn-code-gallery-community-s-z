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
Sdk.Mdq = Sdk.Mdq || { __namespace: true };
Sdk.Mdq.ValueEnums = Sdk.Mdq.ValueEnums || { __namespace: true };

(function () {


 this.RetrieveMetadataChangesRequest = function (query, clientVersionStamp, deletedMetadataFilters) {
  ///<summary>
  /// Request to retrieve metadata and metadata changes
  ///</summary>
  ///<param name="query" type="Sdk.Mdq.EntityQueryExpression">
  /// The Sdk.Mdq.EntityQueryExpression that defines the query
  ///</param>
  ///<param name="clientVersionStamp" optional="true"  type="String">
  /// The Sdk.Mdq.RetrieveMetadataChangesResponse.ServerVersionStamp value from a previous request.
  /// When included only the metadata changes since the previous request will be returned.
  ///</param>
  ///<param name="deletedMetadataFilters" optional="true"  type="Number">
  /// An Sdk.Mdq.DeletedMetadataFilters enumeration value.
  /// When included the deleted metadata changes will be limited to the types defined by the enumeration.
  ///</param>
  if (!(this instanceof Sdk.RetrieveMetadataChangesRequest)) {
   return new Sdk.RetrieveMetadataChangesRequest(query, clientVersionStamp, deletedMetadataFilters);
  }
  Sdk.OrganizationRequest.call(this);

  var _query = null;
  var _clientVersionStamp = null;
  var _deletedMetadataFilters = null;

  function _setValidQuery(value) {
   if (value instanceof Sdk.Mdq.EntityQueryExpression) {
    _query = value;
   }
   else {
    throw new Error("Sdk.RetrieveMetadataChangesRequest.Query requires a Sdk.Mdq.EntityQueryExpression.");
   }
  }

  function _setValidClientVersionStamp(value) {
   if (value == null) {
    _clientVersionStamp = value;
   }
   else {
    if (typeof value == "string") {
     _clientVersionStamp = value;
    }
    else {
     throw new Error("Sdk.RetrieveMetadataChangesRequest ClientVersionStamp requires a string value or a null value.");
    }
   }
  }

  function _setValidDeletedMetadataFilters(value) {
   if (value == null) {
    _deletedMetadataFilters = value;
   }
   else {
    if (value >= 1 && value <= 31) //All
    {
     _deletedMetadataFilters = value;
    }
    else {
     throw new Error("Sdk.RetrieveMetadataChangesRequest DeletedMetadataFilters must be null or a number between 1 and 31.")
    }
   }

  }

  function _getDeletedMetadataFiltersXml() {
   var deletedMetadataFiltersString = "Entity"; //Default

   if (_deletedMetadataFilters != null) {
    var deletedMetadataArray = [];
    if ((1 & _deletedMetadataFilters) == 1) {
     deletedMetadataArray.push("Entity");
    }
    if ((2 & _deletedMetadataFilters) == 2) {
     deletedMetadataArray.push("Attribute");
    }
    if ((4 & _deletedMetadataFilters) == 4) {
     deletedMetadataArray.push("Relationship");
    }
    if ((8 & _deletedMetadataFilters) == 8) {
     deletedMetadataArray.push("Label");
    }
    if ((16 & _deletedMetadataFilters) == 16) {
     deletedMetadataArray.push("OptionSet");
    }
    deletedMetadataFiltersString = deletedMetadataArray.join(" ");
   }

   var deletedMetadataFiltersXML = "";
   if (_clientVersionStamp != null && _deletedMetadataFilters != null) {
    deletedMetadataFiltersXML = ["<a:KeyValuePairOfstringanyType>",
            "<b:key>DeletedMetadataFilters</b:key>",
            "<b:value i:type=\"j:DeletedMetadataFilters\">",
             deletedMetadataFiltersString,
             "</b:value>",
          "</a:KeyValuePairOfstringanyType>"].join("");
   }

   return deletedMetadataFiltersXML;

  }

  function _getClientVersionStampXml() {

   return (_clientVersionStamp == null) ? "" : ["<a:KeyValuePairOfstringanyType>",
             "<b:key>ClientVersionStamp</b:key>",
            "<b:value i:type=\"c:string\" >" + _clientVersionStamp + "</b:value>",
           "</a:KeyValuePairOfstringanyType>"].join("");
  }

  //Set internal properties from constructor parameters
  if (typeof query != "undefined") {
   _setValidQuery(query);
  }

  if (typeof clientVersionStamp != "undefined") {
   _setValidClientVersionStamp(clientVersionStamp);
  }

  if (typeof deletedMetadataFilters != "undefined") {
   _setValidDeletedMetadataFilters(deletedMetadataFilters);
  }

  function getRequestXml() {
   return ["<d:request i:type=\"a:RetrieveMetadataChangesRequest\">",
        "<a:Parameters>",
          "<a:KeyValuePairOfstringanyType>",
            "<b:key>Query</b:key>",
             _query.toXml(),
          "</a:KeyValuePairOfstringanyType>",
            _getClientVersionStampXml(),
          _getDeletedMetadataFiltersXml(),
        "</a:Parameters>",
        "<a:RequestId i:nil=\"true\" />",
        "<a:RequestName>RetrieveMetadataChanges</a:RequestName>",
      "</d:request>"].join("");
  };

  this.setResponseType(Sdk.RetrieveMetadataChangesResponse);
  this.setRequestXml(getRequestXml());


  this.setQuery = function (value) {
   _setValidQuery(value);
   this.setRequestXml(getRequestXml());
  }

  this.setClientVersionStamp = function (value) {
   _setValidClientVersionStamp(value);
   this.setRequestXml(getRequestXml());
  }

  this.setDeletedMetadataFilters = function (value) {
   _setValidDeletedMetadataFilters(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveMetadataChangesRequest.__class = true;

 this.RetrieveMetadataChangesResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveMetadataChangesRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveMetadataChangesResponse)) {
   return new Sdk.RetrieveMetadataChangesResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)
  //Internal methods and properties

  var _entityMetadata = null;
  var _serverVersionStamp = null;
  var _deletedMetadata = null;

  var _arrayElements = ["Attributes",
    "ManyToManyRelationships",
    "ManyToOneRelationships",
    "OneToManyRelationships",
    "Privileges",
    "LocalizedLabels",
    "Options",
    "Targets"];

  function _isMetadataArray(elementName) {
   for (var i = 0; i < _arrayElements.length; i++) {
    if (elementName == _arrayElements[i]) {
     return true;
    }
   }
   return false;
  };
  function _objectifyNode(node) {
   //Check for null
   if (node.attributes != null && node.attributes.length == 1) {

    if (node.attributes.getNamedItem("i:nil") != null && node.attributes.getNamedItem("i:nil").nodeValue == "true") {
     return null;
    }
   }

   //Check if it is a value
   if ((node.firstChild != null) && (node.firstChild.nodeType == 3)) {
    var nodeName = Sdk.Xml.getNodeName(node);

    switch (nodeName) {
     //Integer Values 
     case "ActivityTypeMask":
     case "ColumnNumber":
     case "DefaultFormValue":
     case "LanguageCode":
     case "MaxLength":
     case "MaxValue":
     case "MinValue":
     case "MobileClientAccessLevelMask":
     case "ObjectTypeCode":
     case "Order":
     case "Precision":
     case "PrecisionSource":
      return parseInt(node.firstChild.nodeValue, 10);
      // Boolean values
     case "AutoCreateAccessTeams":
     case "AutoRouteToOwnerQueue":
     case "CanBeBasic":
     case "CanBeChanged":
     case "CanBeDeep":
     case "CanBeGlobal":
     case "CanBeLocal":
     case "CanBeSecuredForCreate":
     case "CanBeSecuredForRead":
     case "CanBeSecuredForUpdate":
     case "CanTriggerWorkflow":
     case "IsActivity":
     case "IsActivityParty":
     case "IsAIRUpdated":
     case "IsAvailableOffline":
     case "IsBusinessProcessEnabled":
     case "IsChildEntity":
     case "IsCustomAttribute":
     case "IsCustomEntity":
     case "IsCustomOptionSet":
     case "IsCustomRelationship":
     case "IsDocumentManagementEnabled":
     case "IsEnabledForCharts":
     case "IsEnabledForTrace":
     case "IsGlobal":
     case "IsImportable":
     case "IsIntersect":
     case "IsManaged":
     case "IsManaged":
     case "IsPrimaryId":
     case "IsPrimaryName":
     case "IsQuickCreateEnabled":
     case "IsReadingPaneEnabled":
     case "IsSecured":
     case "IsValidForAdvancedFind":
     case "IsValidForCreate":
     case "IsValidForRead":
     case "IsValidForUpdate":
     case "IsVisibleInMobileClient":
      return (node.firstChild.nodeValue == "true") ? true : false;
      //OptionMetadata.Value and BooleanManagedProperty.Value and AttributeRequiredLevelManagedProperty.Value
     case "Value":
      //BooleanManagedProperty.Value
      if ((node.firstChild.nodeValue == "true") || (node.firstChild.nodeValue == "false")) {
       return (node.firstChild.nodeValue == "true") ? true : false;
      }
      //AttributeRequiredLevelManagedProperty.Value
      if (
   (node.firstChild.nodeValue == "ApplicationRequired") ||
   (node.firstChild.nodeValue == "None") ||
   (node.firstChild.nodeValue == "Recommended") ||
   (node.firstChild.nodeValue == "SystemRequired")
   ) {
       return node.firstChild.nodeValue;
      }
      var numberValue = parseInt(node.firstChild.nodeValue, 10);
      if (isNaN(numberValue)) {
       //FormatName.Value
       return node.firstChild.nodeValue;
      }
      else {
       //OptionMetadata.Value
       return numberValue;
      }
      break;
      //String values 
     default:
      return node.firstChild.nodeValue;
    }

   }

   //Check if it is a known array
   if (_isMetadataArray(Sdk.Xml.getNodeName(node))) {
    var arrayValue = [];

    for (var i = 0; i < node.childNodes.length; i++) {
     var objectTypeName;
     if ((node.childNodes[i].attributes != null) && (node.childNodes[i].attributes.getNamedItem("i:type") != null)) {
      objectTypeName = node.childNodes[i].attributes.getNamedItem("i:type").nodeValue.split(":")[1];
     }
     else {

      objectTypeName = Sdk.Xml.getNodeName(node.childNodes[i]);
     }

     var b = _objectifyNode(node.childNodes[i]);
     if (typeof b != "string" && typeof b != "number")
     {
      b._type = objectTypeName;
     }
      

    
     arrayValue.push(b);

    }

    return arrayValue;
   }

   //Null entity description labels are returned as <label/> - not using i:nil = true;
   if (node.childNodes.length == 0) {
    return null;
   }


   //Otherwise return an object
   var c = {};
   if (node.attributes.getNamedItem("i:type") != null) {
    c._type = node.attributes.getNamedItem("i:type").nodeValue.split(":")[1];
   }
   for (var i = 0; i < node.childNodes.length; i++) {
    if (node.childNodes[i].nodeType == 3) {
     c[Sdk.Xml.getNodeName(node.childNodes[i])] = node.childNodes[i].nodeValue;
    }
    else {
     c[Sdk.Xml.getNodeName(node.childNodes[i])] = _objectifyNode(node.childNodes[i]);
    }

   }
   return c;
  };

  function _setEntityMetadata(xml) {
   var _entityMetadataCollection = [];

   var emNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='EntityMetadata']/b:value");


   for (var i = 0; i < emNode.childNodes.length; i++) {
    var a = _objectifyNode(emNode.childNodes[i]);
    a._type = "EntityMetadata";
    _entityMetadataCollection.push(a);
   }
   _entityMetadata = _entityMetadataCollection;
  }
  function _setServerVersionStamp(xml) {

   _serverVersionStamp = Sdk.Xml.selectSingleNodeText(xml, "//a:KeyValuePairOfstringanyType[b:key='ServerVersionStamp']/b:value");

  }
  function _setDeletedMetadata(xml) {
   var _deletedMetadataCollection = {};

   var dmNode = Sdk.Xml.selectSingleNode(responseXml, "//a:KeyValuePairOfstringanyType[b:key='DeletedMetadata']/b:value");

   if (dmNode != null) {
    for (var i = 0; i < dmNode.childNodes.length; i++) {
     var typeNode = dmNode.childNodes[i].firstChild;

     _deletedMetadataCollection[_getNodeText(typeNode)] = [];
     for (var n = 0; n < typeNode.nextSibling.childNodes.length; n++) {

      var guidText = _getNodeText(typeNode.nextSibling.childNodes[n]);

      _deletedMetadataCollection[_getNodeText(typeNode)].push(guidText);
     }
    }
   }
   _deletedMetadata = _deletedMetadataCollection;
  }


  //Public Methods
  this.getEntityMetadata = function () {
   return _entityMetadata;
  }
  this.getServerVersionStamp = function () {
   return _serverVersionStamp
  }
  this.getDeletedMetadata = function () {
   return _deletedMetadata;
  }

  //set property values from responseXml constructor parameter
  _setEntityMetadata(responseXml);
  _setServerVersionStamp(responseXml);
  _setDeletedMetadata(responseXml);


 }
 this.RetrieveMetadataChangesResponse.__class = true;


}).call(Sdk);

(function () {
 //Sdk.Mdq.AttributeMetadataProperties START
 this.AttributeMetadataProperties = function () {
  /// <summary>Sdk.Mdq..AttributeMetadataProperties enum summary</summary>
  /// <field name="AttributeOf" type="String" static="true">enum field summary for AttributeOf</field>	
  /// <field name="AttributeType" type="String" static="true">enum field summary for AttributeType</field>	
  /// <field name="AttributeTypeName" type="String" static="true">enum field summary for AttributeTypeName</field>	
  /// <field name="CalculationOf" type="String" static="true">enum field summary for CalculationOf</field>	
  /// <field name="CanBeSecuredForCreate" type="String" static="true">enum field summary for CanBeSecuredForCreate</field>	
  /// <field name="CanBeSecuredForRead" type="String" static="true">enum field summary for CanBeSecuredForRead</field>	
  /// <field name="CanBeSecuredForUpdate" type="String" static="true">enum field summary for CanBeSecuredForUpdate</field>	
  /// <field name="CanModifyAdditionalSettings" type="String" static="true">enum field summary for CanModifyAdditionalSettings</field>	
  /// <field name="ColumnNumber" type="String" static="true">enum field summary for ColumnNumber</field>	
  /// <field name="DefaultFormValue" type="String" static="true">enum field summary for DefaultFormValue</field>	
  /// <field name="DefaultValue" type="String" static="true">enum field summary for DefaultValue</field>
  /// <field name="DeprecatedVersion" type="String" static="true">enum field summary for DeprecatedVersion</field>	
  /// <field name="Description" type="String" static="true">enum field summary for Description</field>	
  /// <field name="DisplayName" type="String" static="true">enum field summary for DisplayName</field>	
  /// <field name="EntityLogicalName" type="String" static="true">enum field summary for EntityLogicalName</field>	
  /// <field name="Format" type="String" static="true">enum field summary for Format</field>	
  /// <field name="FormatName" type="String" static="true">enum field summary for FormatName</field>	
  /// <field name="ImeMode" type="String" static="true">enum field summary for ImeMode</field>	
  /// <field name="IntroducedVersion" type="String" static="true">enum field summary for IntroducedVersion</field>	
  /// <field name="IsAuditEnabled" type="String" static="true">enum field summary for IsAuditEnabled</field>	
  /// <field name="IsCustomAttribute" type="String" static="true">enum field summary for IsCustomAttribute</field>	
  /// <field name="IsCustomizable" type="String" static="true">enum field summary for IsCustomizable</field>	
  /// <field name="IsManaged" type="String" static="true">enum field summary for IsManaged</field>
  /// <field name="IsPrimaryId" type="String" static="true">enum field summary for IsPrimaryId</field>	
  /// <field name="IsPrimaryName" type="String" static="true">enum field summary for IsPrimaryName</field>	
  /// <field name="IsRenameable" type="String" static="true">enum field summary for IsRenameable</field>	
  /// <field name="IsSecured" type="String" static="true">enum field summary for IsSecured</field>	
  /// <field name="IsValidForAdvancedFind" type="String" static="true">enum field summary for IsValidForAdvancedFind</field>	
  /// <field name="IsValidForCreate" type="String" static="true">enum field summary for IsValidForCreate</field>	
  /// <field name="IsValidForRead" type="String" static="true">enum field summary for IsValidForRead</field>	
  /// <field name="IsValidForUpdate" type="String" static="true">enum field summary for IsValidForUpdate</field>	
  /// <field name="LinkedAttributeId" type="String" static="true">enum field summary for LinkedAttributeId</field>	
  /// <field name="LogicalName" type="String" static="true">enum field summary for LogicalName</field>
  /// <field name="MaxLength" type="String" static="true">enum field summary for MaxLength</field>	
  /// <field name="MaxValue" type="String" static="true">enum field summary for MaxValue</field>	
  /// <field name="MetadataId" type="String" static="true">enum field summary for MetadataId</field>	
  /// <field name="MinValue" type="String" static="true">enum field summary for MinValue</field>	
  /// <field name="OptionSet" type="String" static="true">enum field summary for OptionSet</field>	
  /// <field name="Precision" type="String" static="true">enum field summary for Precision</field>	
  /// <field name="PrecisionSource" type="String" static="true">enum field summary for PrecisionSource</field>	
  /// <field name="RequiredLevel" type="String" static="true">enum field summary for RequiredLevel</field>	
  /// <field name="SchemaName" type="String" static="true">enum field summary for SchemaName</field>	
  /// <field name="Targets" type="String" static="true">enum field summary for Targets</field>
  /// <field name="YomiOf" type="String" static="true">enum field summary for YomiOf</field>	
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.Mdq.AttributeMetadataProperties END
 //--------------------------------------------------------------------
 //Sdk.Mdq.AttributeQueryExpression START
 this.AttributeQueryExpression = function (criteria, properties) {
  ///<summary>
  /// Defines a complex query to retrieve attribute metadata for entities retrieved using an Sdk.Mdq.EntityQueryExpression
  ///</summary>
  ///<param name="criteria" type="Sdk.Mdq.MetadataFilterExpression">
  /// The filter criteria for the metadata query
  ///</param>
  ///<param name="properties" type="Sdk.Mdq.MetadataPropertiesExpression">
  /// The properties to be returned by the query
  ///</param>
  if (!(this instanceof Sdk.Mdq.AttributeQueryExpression)) {
   return new Sdk.Mdq.AttributeQueryExpression(criteria, properties);
  }
  Sdk.Mdq.MetadataQueryExpression.call(this, criteria, properties);

 };
 this.AttributeQueryExpression.__class = true;
 //Sdk.Mdq.AttributeQueryExpression END
 //--------------------------------------------------------------------
 //Sdk.Mdq.DeletedMetadataFilters START
 this.DeletedMetadataFilters = function () {
  /// <summary>An enumeration that specifies the type of deleted metadata to retrieve.</summary>
  /// <field name="All" type="Number" static="true">All deleted metadata</field>		
  /// <field name="Attribute" type="Number" static="true">Deleted Attribute metadata</field>
  /// <field name="Default" type="Number" static="true">The value used if not set. Equals Entity</field>
  /// <field name="Entity" type="Number" static="true">Deleted Entity metadata</field>
  /// <field name="Label" type="Number" static="true">Deleted Label metadata</field>
  /// <field name="OptionSet" type="Number" static="true">Deleted OptionSet metadata</field>
  /// <field name="Relationship" type="Number" static="true">Deleted Relationship metadata</field>



  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.Mdq.DeletedMetadataFilters END
 //--------------------------------------------------------------------
 //Sdk.Mdq.EntityMetadataProperties START
 this.EntityMetadataProperties = function () {
  /// <summary>Sdk.Mdq.EntityMetadataProperties enum summary</summary>
  /// <field name="ActivityTypeMask" type="String" static="true">enum field summary for ActivityTypeMask</field>	
  /// <field name="AutoCreateAccessTeams" type="String" static="true">enum field summary for AutoCreateAccessTeams</field>	
  /// <field name="Attributes" type="String" static="true">enum field summary for Attributes</field>	
  /// <field name="AutoRouteToOwnerQueue" type="String" static="true">enum field summary for AutoRouteToOwnerQueue</field>	
  /// <field name="CanBeInManyToMany" type="String" static="true">enum field summary for CanBeInManyToMany</field>	
  /// <field name="CanBePrimaryEntityInRelationship" type="String" static="true">enum field summary for CanBePrimaryEntityInRelationship</field>	
  /// <field name="CanBeRelatedEntityInRelationship" type="String" static="true">enum field summary for CanBeRelatedEntityInRelationship</field>	
  /// <field name="CanCreateAttributes" type="String" static="true">enum field summary for CanCreateAttributes</field>	
  /// <field name="CanCreateCharts" type="String" static="true">enum field summary for CanCreateCharts</field>	
  /// <field name="CanCreateForms" type="String" static="true">enum field summary for CanCreateForms</field>	
  /// <field name="CanCreateViews" type="String" static="true">enum field summary for CanCreateViews</field>
  /// <field name="CanModifyAdditionalSettings" type="String" static="true">enum field summary for CanModifyAdditionalSettings</field>	
  /// <field name="CanTriggerWorkflow" type="String" static="true">enum field summary for CanTriggerWorkflow</field>	
  /// <field name="Description" type="String" static="true">enum field summary for Description</field>	
  /// <field name="DisplayCollectionName" type="String" static="true">enum field summary for DisplayCollectionName</field>	
  /// <field name="DisplayName" type="String" static="true">enum field summary for DisplayName</field>	
  /// <field name="IconLargeName" type="String" static="true">enum field summary for IconLargeName</field>	
  /// <field name="IconMediumName" type="String" static="true">enum field summary for IconMediumName</field>	
  /// <field name="IconSmallName" type="String" static="true">enum field summary for IconSmallName</field>	
  /// <field name="IntroducedVersion" type="String" static="true">enum field summary for IntroducedVersion</field>	
  /// <field name="IsActivity" type="String" static="true">enum field summary for IsActivity</field>	
  /// <field name="IsActivityParty" type="String" static="true">enum field summary for IsActivityParty</field>	
  /// <field name="IsAIRUpdated" type="String" static="true">enum field summary for IsAIRUpdated</field>	
  /// <field name="IsAuditEnabled" type="String" static="true">enum field summary for IsAuditEnabled</field>	
  /// <field name="IsAvailableOffline" type="String" static="true">enum field summary for IsAvailableOffline</field>
  /// <field name="IsBusinessProcessEnabled" type="String" static="true">enum field summary for IsBusinessProcessEnabled</field>
  /// <field name="IsChildEntity" type="String" static="true">enum field summary for IsChildEntity</field>	
  /// <field name="IsConnectionsEnabled" type="String" static="true">enum field summary for IsConnectionsEnabled</field>	
  /// <field name="IsCustomEntity" type="String" static="true">enum field summary for IsCustomEntity</field>	
  /// <field name="IsCustomizable" type="String" static="true">enum field summary for IsCustomizable</field>	
  /// <field name="IsDocumentManagementEnabled" type="String" static="true">enum field summary for IsDocumentManagementEnabled</field>	
  /// <field name="IsDuplicateDetectionEnabled" type="String" static="true">enum field summary for IsDuplicateDetectionEnabled</field>	
  /// <field name="IsEnabledForCharts" type="String" static="true">enum field summary for IsEnabledForCharts</field>	
  /// <field name="IsImportable" type="String" static="true">enum field summary for IsImportable</field>
  /// <field name="IsIntersect" type="String" static="true">enum field summary for IsIntersect</field>	
  /// <field name="IsMailMergeEnabled" type="String" static="true">enum field summary for IsMailMergeEnabled</field>	
  /// <field name="IsManaged" type="String" static="true">enum field summary for IsManaged</field>	
  /// <field name="IsMappable" type="String" static="true">enum field summary for IsMappable</field>
  /// <field name="IsQuickCreateEnabled" type="String" static="true">enum field summary for IsQuickCreateEnabled</field>
  /// <field name="IsReadingPaneEnabled" type="String" static="true">enum field summary for IsReadingPaneEnabled</field>	
  /// <field name="IsRenameable" type="String" static="true">enum field summary for IsRenameable</field>	
  /// <field name="IsValidForAdvancedFind" type="String" static="true">enum field summary for IsValidForAdvancedFind</field>	
  /// <field name="IsValidForQueue" type="String" static="true">enum field summary for IsValidForQueue</field>	
  /// <field name="IsVisibleInMobile" type="String" static="true">enum field summary for IsVisibleInMobile</field>	
  /// <field name="IsVisibleInMobileClient" type="String" static="true">enum field summary for IsVisibleInMobileClient</field>	
  /// <field name="LogicalName" type="String" static="true">enum field summary for LogicalName</field>	
  /// <field name="MetadataId" type="String" static="true">enum field summary for MetadataId</field>	
  /// <field name="ObjectTypeCode" type="String" static="true">enum field summary for ObjectTypeCode</field>	
  /// <field name="OneToManyRelationships" type="String" static="true">enum field summary for OneToManyRelationships</field>	
  /// <field name="OwnershipType" type="String" static="true">enum field summary for OwnershipType</field>	
  /// <field name="PrimaryIdAttribute" type="String" static="true">enum field summary for PrimaryIdAttribute</field>
  /// <field name="PrimaryImageAttribute" type="String" static="true">enum field summary for PrimaryImageAttribute</field>
  /// <field name="PrimaryNameAttribute" type="String" static="true">enum field summary for PrimaryNameAttribute</field>	
  /// <field name="Privileges" type="String" static="true">enum field summary for Privileges</field>	
  /// <field name="RecurrenceBaseEntityLogicalName" type="String" static="true">enum field summary for RecurrenceBaseEntityLogicalName</field>
  /// <field name="ReportViewName" type="String" static="true">enum field summary for ReportViewName</field>	
  /// <field name="SchemaName" type="String" static="true">enum field summary for SchemaName</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.Mdq.EntityMetadataProperties END
 //--------------------------------------------------------------------
 //Sdk.Mdq.EntityQueryExpression START
 this.EntityQueryExpression = function (criteria, properties, attributeQuery, relationshipQuery, labelQuery) {
  ///<summary>
  /// Defines a complex query to retrieve entity metadata. 
  ///</summary>
  ///<param name="criteria" type="Sdk.Mdq.MetadataFilterExpression">
  /// The filter criteria for the metadata query
  ///</param>
  ///<param name="properties" type="Sdk.Mdq.MetadataPropertiesExpression">
  /// The properties to be returned by the query
  ///</param>
  ///<param name="attributeQuery" type="Sdk.Mdq.AttributeQueryExpression">
  /// A query expression for the entity attribute metadata to return.
  ///</param>
  ///<param name="relationshipQuery" type="Sdk.Mdq.RelationshipQueryExpression ">
  /// A query expression for the entity relationship metadata to return
  ///</param>
  ///<param name="labelQuery" type="Sdk.Mdq.LabelQueryExpression ">
  /// A query expression for the labels to return.
  ///</param>
  if (!(this instanceof Sdk.Mdq.EntityQueryExpression)) {
   return new Sdk.Mdq.EntityQueryExpression(criteria, properties, attributeQuery, relationshipQuery, labelQuery);
  }
  Sdk.Mdq.MetadataQueryExpression.call(this, criteria, properties);
  //Properties
  var _attributeQuery = null;
  var _relationshipQuery = null;
  var _labelQuery = null;

  // Internal functions

  function _setValidAttributeQuery(value) {
   if (value == null)
   { _attributeQuery = null; }
   else
   {
    if (value instanceof Sdk.Mdq.AttributeQueryExpression)
    { _attributeQuery = value; }
    else {
     throw new Error("Sdk.Mdq.EntityQueryExpression attributeQuery must be an Sdk.Mdq.AttributeQueryExpression");
    }
   }
  }
  function _setValidRelationshipQuery(value) {
   if (value == null)
   { _relationshipQuery = null; }
   else
   {
    if (value instanceof Sdk.Mdq.RelationshipQueryExpression)
    { _relationshipQuery = value; }
    else {
     throw new Error("Sdk.Mdq.EntityQueryExpression relationshipQuery must be an Sdk.Mdq.RelationshipQueryExpression");
    }
   }
  }
  function _setValidLabelQuery(value) {
   if (value == null)
   { _labelQuery = null }
   else
   {
    if (value instanceof Sdk.Mdq.LabelQueryExpression)
    { _labelQuery = value; }
    else {
     throw new Error("Sdk.Mdq.EntityQueryExpression labelQuery must be an Sdk.Mdq.LabelQueryExpression");
    }
   }
  }

  //Set parameter values

  //Criteria and Properties are set by Sdk.Mdq.MetadataQueryExpression

  if (typeof attributeQuery != "undefined") {
   _setValidAttributeQuery(attributeQuery);
  }

  if (typeof relationshipQuery != "undefined") {
   _setValidRelationshipQuery(relationshipQuery);
  }

  if (typeof labelQuery != "undefined") {
   _setValidLabelQuery(labelQuery);
  }


  this.getAttributeQuery = function () {
   ///<summary>
   /// Gets the Sdk.Mdq.AttributeQueryExpression used in this Sdk.Mdq.EntityQueryExpression instance.
   ///</summary>
   return _attributeQuery;
  };
  this.setAttributeQuery = function (value) {
   ///<summary>
   /// Sets the Sdk.Mdq.AttributeQueryExpression used in this Sdk.Mdq.EntityQueryExpression instance.
   ///</summary>
   ///<param name="value" type="Sdk.Mdq.AttributeQueryExpression">
   /// Describes which entity attributes and what properties of those attributes to return.
   ///</param>
   _setValidAttributeQuery(value);
  };
  this.getRelationshipQuery = function () {
   ///<summary>
   /// Gets the Sdk.Mdq.RelationshipQueryExpression  used in this Sdk.Mdq.EntityQueryExpression instance.
   ///</summary>
   return _relationshipQuery;
  };
  this.setRelationshipQuery = function (value) {
   ///<summary>
   /// Sets the Sdk.Mdq.RelationshipQueryExpression  used in this Sdk.Mdq.EntityQueryExpression instance.
   ///</summary>
   ///<param name="value" type="Sdk.Mdq.RelationshipQueryExpression">
   /// Describes which entity relationships and what properties of those relationships to return.
   ///</param>
   _setValidRelationshipQuery(value);
  };
  this.getLabelQuery = function () {
   ///<summary>
   /// Gets the Sdk.Mdq.LabelQueryExpression   used in this Sdk.Mdq.EntityQueryExpression instance.
   ///</summary>
   ///<returns></returns>
   return _labelQuery;
  };
  this.setLabelQuery = function (value) {
   ///<summary>
   /// Gets the Sdk.Mdq.LabelQueryExpression used in this Sdk.Mdq.EntityQueryExpression instance.
   ///</summary>
   ///<param name="value" type="Sdk.Mdq.LabelQueryExpression">
   /// The definition of the language for labels to be returned.
   ///</param>
   _setValidLabelQuery(value);
  };

 };
 this.EntityQueryExpression.__class = true;
 //Sdk.Mdq.EntityQueryExpression END
 //--------------------------------------------------------------------
 //Sdk.Mdq.GuidValue START
 this.GuidValue = function (stringValue) {
  ///<summary>
  /// Required to use when setting a condition value that is a GUID
  ///</summary>
  ///<param name="stringValue" type="String">
  /// A string representation of a GUID value such as 'EF9894C9-44B1-49E9-95F2-856B78C7B4A4'
  ///</param>
  if (!(this instanceof Sdk.Metadata.Query.GuidValue)) {
   return new Sdk.Metadata.Query.GuidValue(stringValue);
  }
  var _value = null;
  if (/^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$/.test(stringValue)) {
   _value = stringValue;
  }
  else {
   throw new Error("Value passed as a Guid Value is not a valid Guid.");
  }

  this.value = _value;

 };
 this.GuidValue.__class = true;
 //Sdk.Mdq.GuidValue END
 //--------------------------------------------------------------------
 //Sdk.Mdq.LabelQueryExpression START
 this.LabelQueryExpression = function (languages) {
  ///<summary>
  /// Defines the languages for the labels to be retrieved for metadata items that have labels. 
  ///</summary>
  ///<param name="languages" type="Array" optional="true" mayBeNull="false">
  /// An array of LCID number values
  ///</param>

  if (!(this instanceof Sdk.Mdq.LabelQueryExpression)) {
   return new Sdk.Mdq.LabelQueryExpression(languages);
  }

  var _filterLanguages = new Sdk.Collection(Number);

  function _addValidLanguage(value) {
   if (typeof value != "undefined" && typeof value == "number") {
    _filterLanguages.add(value);
   }
   else {
    throw new Error("Sdk.Mdq.LabelQueryExpression language must be a number.");
   }
  }
  function _addValidLanguages(value) {
   var errorMessage = "Sdk.Mdq.LabelQueryExpression languages must be an array of numbers.";
   if (typeof value != "undefined" && typeof value.push == "function") {
    for (var i = 0; i < value.length; i++) {
     if (typeof value[i] != "number") {
      throw new Error(errorMessage);
     }
    }
    _filterLanguages.addRange(value);
   }
   else {
    throw new Error(errorMessage);
   }
  }
  function _removeLanguage(value) {
   if (typeof value == "number") {
    _filterLanguages.remove(value);
   }
   else {
    throw new Error("Sdk.Mdq.LabelQueryExpression languages must be LCID number values.");
   }
  }
  // set constructor parameters
  if (typeof languages != "undefined") {
   _addValidLanguages(languages);
  }
  //public methods
  this.getLanguages = function () {
   ///<summary>
   /// Returns the languages
   ///</summary>
   ///<returns name="language" type="Sdk.Collection">
   /// An Sdk.Collection of LCID number values.
   ///</returns >
   return _filterLanguages;
  }
  this.addLanguage = function (language) {
   ///<summary>
   /// Adds a language value.
   ///</summary>
   ///<param name="language" type="Number" optional="false" mayBeNull="false">
   /// An LCID number value.
   ///</param>
   _addValidLanguage(language);
  }
  this.addLanguages = function (languages) {
   ///<summary>
   /// Adds an array of language values.
   ///</summary>
   ///<param name="languages" type="Array" optional="false" mayBeNull="false">
   /// An array of LCID number values
   ///</param>
   _addValidLanguages(languages);
  }
  this.removeLanguage = function (language) {
   ///<summary>
   /// Removes a language value.
   ///</summary>
   ///<param name="language" type="Number" optional="false" mayBeNull="false">
   /// An LCID number value.
   ///</param>
   _removeLanguage(language);
  }

 };
 this.LabelQueryExpression.__class = true;
 //Sdk.Mdq.LabelQueryExpression END
 //--------------------------------------------------------------------
 //Sdk.Mdq.LogicalOperator START
 this.LogicalOperator = function () {
  /// <summary>Sdk.Mdq.LogicalOperator enum summary</summary>
  /// <field name="And" type="String" static="true">enum field summary for And</field>
  /// <field name="Or" type="String" static="true">enum field summary for Or</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.Mdq.LogicalOperator END
 //--------------------------------------------------------------------
 //Sdk.Mdq.MetadataConditionExpression START
 this.MetadataConditionExpression = function (propertyName, conditionOperator, value) {
  ///<summary>
  /// Contains a condition expression used to filter the results of the metadata query. 
  ///</summary>
  ///<param name="propertyName" type="String">
  /// <para>The metadata property to evaluate</para>
  /// <para>Optional: Use one of the following enumerations depending on the type of metadata item:</para>
  /// <para> Entity: Sdk.Mdq.SearchableEntityMetadataProperties</para>
  /// <para> Attribute: Sdk.Mdq.SearchableAttributeMetadataProperties</para>
  /// <para> Relationship: Sdk.Mdq.SearchableRelationshipMetadataProperties</para>
  ///</param>
  ///<param name="conditionOperator" type="Sdk.Mdq.MetadataConditionOperator">
  /// The condition operator
  ///</param>
  ///<param name="value" type="String">
  /// <para>The metadata value to evaluate</para>
  /// <para>If the value is a GUID you must use Sdk.Mdq.GuidValue</para>
  /// <para>Optional: Use one of the Sdk.Mdq.ValueEnums enumerations depending on the type of metadata item:</para>
  /// <para> Entity.OwnershipType: Sdk.Mdq.ValueEnums.OwnershipType</para>
  /// <para> Attribute.AttributeType : Sdk.Mdq.ValueEnums.AttributeTypeCode</para>
  /// <para> Attribute.RequiredLevel : Sdk.Mdq.ValueEnums.AttributeRequiredLevel</para>
  /// <para> DateTimeAttributeMetadata.Format Sdk.Mdq.ValueEnums.DateTimeFormat</para>
  /// <para> IntegerAttributeMetadata.Format Sdk.Mdq.ValueEnums.IntegerFormat</para>
  /// <para> StringAttributeMetadata.Format Sdk.Mdq.ValueEnums.StringFormat</para>
  /// <para> Attribute.ImeMode Sdk.Mdq.ValueEnums.ImeMode</para>
  /// <para> Relationship.SecurityTypes: Sdk.Mdq.ValueEnums.SecurityTypes</para>
  ///</param>
  if (!(this instanceof Sdk.Mdq.MetadataConditionExpression)) {
   return new Sdk.Mdq.MetadataConditionExpression(propertyName, conditionOperator, value);
  }
  //Properties
  var _conditionOperator = null;
  var _propertyName = null;
  var _value = null;
  var _valueType = null;
  var _valueIsArray = false;
  var _valueNamespaces = {
   Serialization: "e", //"xmlns:e=\"http://schemas.microsoft.com/2003/10/Serialization/\"",
   Arrays: "f", //"xmlns:f=\"http://schemas.microsoft.com/2003/10/Serialization/Arrays\"",
   Metadata: "h", //"xmlns:h=\"http://schemas.microsoft.com/xrm/2011/Metadata\"",
   XMLSchema: "c" //"xmlns:c=\"http://www.w3.org/2001/XMLSchema\""
  }
  var _valueNamespace = null;

  //Messages

  var _invalidPropertyNameMessage = "The propertyName parameter value must be a string.";
  var _invalidConditionOperatorMessage = "The conditionOperator parameter value must be an Sdk.Mdq.MetadataConditionOperator";
  var _invalidValueMessage = "The value parameter must be either an array, a string, a number, a boolean value, or null. If an array, it must have at least one item.";
  var _propertyMustBeKnownToSetValueMessage = "The MetadataConditionExpression property name must be known to validate the MetadataConditionExpression value.";

  //Internal Functions
  function _getValueType(value) {
   if (_propertyName == null)
    throw new Error(_propertyMustBeKnownToSetValueMessage);

   var isMetadataEnum = false;
   var metadataEnumPropertyValues = ["AttributeType", "OwnershipType", "RequiredLevel", "Format", "ImeMode", "SecurityTypes"];
   for (var i = 0; i < metadataEnumPropertyValues.length; i++) {
    if (_propertyName == metadataEnumPropertyValues[i]) {
     isMetadataEnum = true;
     _valueNamespace = _valueNamespaces.Metadata;
     break;
    }
   }
   if (isMetadataEnum) {
    switch (_propertyName) {
     case "AttributeType":
      _valueType = "AttributeTypeCode";
      break;
     case "OwnershipType":
      _valueType = "OwnershipTypes";
      break;
     case "RequiredLevel":
      _valueType = "AttributeRequiredLevel";
      break;
     case "Format":

      var isDatetime = false;
      var isInteger = false;
      var isString = false;
      //Without knowing what type of attribute, we can only determine the correct valueString by looking at the values.
      //DateTimeFormat is only valid for DateTime attributes
      for (var i in Sdk.Mdq.ValueEnums.DateTimeFormat) {
       if (_value == i) {
        _valueType = "DateTimeFormat";
        isDatetime = true;
        break;
       }
      }
      //IntegerFormat is only valid for Integer attributes.
      if (!isDatetime) {
       for (var i in Sdk.Mdq.ValueEnums.IntegerFormat) {
        if (_value == i) {
         isInteger = true;
         _valueType = "IntegerFormat";
         break;
        }
       }
      }
      //StringFormat is only valid for String attributes.
      if (!isDatetime && !isInteger) {
       for (var i in Sdk.Mdq.ValueEnums.StringFormat) {
        if (_value == i) {
         isString = true;
         _valueType = "StringFormat";
         break;
        }
       }
      }
      if (!isDatetime && !isInteger && !isString) {
       throw new Error("Unexpected attribute Format metadata enumeration."); //Should not happen, but...
      }
      break;
     case "ImeMode":
      _valueType = "ImeMode";
      break;
     case "SecurityTypes":
      _valueType = "SecurityTypes";
      break;
    }
   }
   else {

    if (typeof value == "string" || typeof value == "number" || typeof value == "boolean") {
     if (typeof value == "number")
     { _valueType = "int" }
     else {
      _valueType = typeof value;
     }
    }

   }

   _valueIsArray = (typeof value == "object" && typeof value.push == 'function');
   if (_valueIsArray && !isMetadataEnum) {
    _valueNamespace = _valueNamespaces.Arrays;

    if (value.length > 0) {
     var firstItemType = typeof value[0];

     if (firstItemType == "string" || firstItemType == "number" || firstItemType == "boolean") {
      if (firstItemType == "number")
      { _valueType = "int" }
      else {
       _valueType = firstItemType;
      }
     }
     else { throw new Error("Cannot determine the type of items in an array passed as a value to a Sdk.Mdq.MetadataConditionExpression."); }

    }
    else {
     //This shouldn't happen because _setValidValue tests whether an array has no items;
     throw new Error(_invalidValueMessage);
    }

   }
   if (!_valueIsArray && !isMetadataEnum) {
    _valueNamespace = _valueNamespaces.XMLSchema;
   }
  }

  function _setValidPropertyName(value) {
   if (typeof value == "string") {
    _propertyName = value;
    if (_value != null) {
     _getValueType(_value); //Value variables have a dependency on _propertyName
    }

   }
   else {
    throw new Error(_invalidPropertyNameMessage);
   }
  }

  function _isValidConditionOperator(value) {
   for (var property in Sdk.Mdq.MetadataConditionOperator) {
    if (value == property)
     return true;
   }
   return false;
  }

  function _setValidConditionOperator(value) {
   if (value == null) {
    _conditionOperator = value;
   }
   else {
    if (_isValidConditionOperator(value)) {
     _conditionOperator = value;
    }
    else {
     throw new Error(_invalidConditionOperatorMessage);
    }
   }
  }

  function _setValidValue(value) {
   if (value == null) {
    _value = null;
    _valueType = "null";
   }
   else {
    if (value instanceof Sdk.Mdq.GuidValue) {
     _value = value.value;
     _valueType = "guid";
     _valueNamespace = _valueNamespaces.Serialization;
    }

    else {

     if ((typeof value == "undefined" || value == null) ||
    (typeof value != "string" && typeof value != "number" && typeof value != "boolean" && typeof value != "object") ||
    (typeof value == "object" && typeof value.push == "undefined") ||
    (typeof value == "object" && typeof value.push == "function" && value.length == 0)) {

      throw new Error(_invalidValueMessage);
     }

     _getValueType(value);
     _value = value;
    }
   }
  }

  //Set parameter values
  if (typeof propertyName != undefined)
   _setValidPropertyName(propertyName);
  if (typeof conditionOperator != undefined)
   _setValidConditionOperator(conditionOperator);
  if (typeof value != undefined)
   _setValidValue(value);

  //Public Methods
  this.getConditionOperator = function () {
   ///<summary>
   /// Gets the Sdk.Mdq.MetadataConditionOperator used in this Sdk.Mdq.MetadataConditionExpression  instance.
   ///</summary>
   return _conditionOperator;
  };
  this.setConditionOperator = function (value) {
   ///<summary>
   /// Sets the Sdk.Mdq.MetadataConditionOperator used in this Sdk.Mdq.MetadataConditionExpression  instance.
   ///</summary>
   ///<param name="value" type="Sdk.Mdq.MetadataConditionOperator">
   /// Describes the type of comparison for two values in a metadata condition expression. 
   ///</param>
   _setValidConditionOperator(value);
  };
  this.getPropertyName = function () {
   ///<summary>
   /// Gets the name of the metadata property in the condition expression. 
   ///</summary>
   return _propertyName;
  };
  this.setPropertyName = function (value) {
   ///<summary>
   /// Sets the name of the metadata property in the condition expression. 
   ///</summary>
   ///<param name="value" type="String">
   /// <para>The metadata property to evaluate</para>
   /// <para>Optional: Use one of the following enumerations depending on the type of metadata item:</para>
   /// <para> Entity: Sdk.Mdq.SearchableEntityMetadataProperties</para>
   /// <para> Attribute: Sdk.Mdq.SearchableAttributeMetadataProperties</para>
   /// <para> Relationship: Sdk.Mdq.SearchableRelationshipMetadataProperties</para>
   ///</param>
   _setValidPropertyName(value);
  };
  this.getValue = function () {
   ///<summary>
   /// Gets the value to compare.
   ///</summary>

   return _value;
  };
  this.setValue = function (value) {
   ///<summary>
   /// Sets the value to compare.
   ///</summary>
   ///<param name="value" type="String">
   /// <para>The metadata value to evaluate</para>
   /// <para>If the value is a GUID you must use Sdk.Mdq.GuidValue</para>
   /// <para>Optional: Use one of the Sdk.Mdq.ValueEnums enumerations depending on the type of metadata item:</para>
   /// <para> Entity.OwnershipType: Sdk.Mdq.ValueEnums.OwnershipType</para>
   /// <para> Attribute.AttributeType : Sdk.Mdq.ValueEnums.AttributeTypeCode</para>
   /// <para> Attribute.RequiredLevel : Sdk.Mdq.ValueEnums.AttributeRequiredLevel</para>
   /// <para> DateTimeAttributeMetadata.Format Sdk.Mdq.ValueEnums.DateTimeFormat</para>
   /// <para> IntegerAttributeMetadata.Format Sdk.Mdq.ValueEnums.IntegerFormat</para>
   /// <para> StringAttributeMetadata.Format Sdk.Mdq.ValueEnums.StringFormat</para>
   /// <para> Attribute.ImeMode Sdk.Mdq.ValueEnums.ImeMode</para>
   /// <para> Relationship.SecurityTypes: Sdk.Mdq.ValueEnums.SecurityTypes</para>
   ///</param>
   _setValidValue(value);
  };
  this.getValueType = function () {
   ///<summary>
   /// For internal use only.
   ///</summary>
   return _valueType;
  }
  this.getValueIsArray = function () {
   ///<summary>
   /// For internal use only.
   ///</summary>
   return _valueIsArray;
  }
  this.getValueNamespace = function () {
   ///<summary>
   /// For internal use only.
   ///</summary>
   return _valueNamespace;
  }

 }
 this.MetadataConditionExpression.__class = true;
 //Sdk.Mdq.MetadataConditionExpression END
 //--------------------------------------------------------------------
 //Sdk.Mdq.MetadataConditionOperator START
 this.MetadataConditionOperator = function () {
  /// <summary>Sdk.Mdq.MetadataConditionOperator enum summary</summary>
  /// <field name="Equals" type="String" static="true">enum field summary for Equals</field>	
  /// <field name="NotEquals" type="String" static="true">enum field summary for NotEquals</field>	
  /// <field name="In" type="String" static="true">enum field summary for In</field>	
  /// <field name="NotIn" type="String" static="true">enum field summary for NotIn</field>	
  /// <field name="GreaterThan" type="String" static="true">enum field summary for GreaterThan</field>	
  /// <field name="LessThan" type="String" static="true">enum field summary for LessThan</field>	
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.Mdq.MetadataConditionOperator END
 //--------------------------------------------------------------------
 //Sdk.Mdq.MetadataFilterExpression START
 this.MetadataFilterExpression = function (filterOperator) {
  ///<summary>
  /// Specifies complex condition and logical filter expressions used for filtering the results of a metadata query. 
  ///</summary>
  ///<param name="filterOperator" type="Sdk.Mdq.LogicalOperator">
  /// The logical AND/OR filter operator.
  ///</param>

  if (!(this instanceof Sdk.Mdq.MetadataFilterExpression)) {
   return new Sdk.Mdq.MetadataFilterExpression(filterOperator);
  }

  var _filterOperator = Sdk.Mdq.LogicalOperator.And; //Default value
  var _conditionExpressions = new Sdk.Collection(Sdk.Mdq.MetadataConditionExpression);
  var _filterExpressions = new Sdk.Collection(Sdk.Mdq.MetadataFilterExpression);


  function _setValidConditions(value) {
   if (value instanceof Sdk.Mdq.MetadataConditionExpressionCollection) {
    _conditionExpressions = value;
   }
   else {
    throw new Error("Sdk.Mdq.MetadataFilterExpression Conditions requires a Sdk.Mdq.MetadataConditionExpressionCollection.");
   }

  }

  function _setValidFilterOperator(value) {
   if ((value != null) && (value == "Or" || value == "And")) {
    _filterOperator = value;
   }
   else {
    throw new Error("Sdk.Mdq.MetadataFilterExpression FilterOperator requires a Sdk.Mdq.LogicalOperator.");
   }

  }

  function _addValidCondition(value) {
   _conditionExpressions.add(value);
  }
  function _addValidConditions(value) {
   _conditionExpressions.addRange(conditions);
  }
  function _addValidFilter(value) {
   if (!(filter instanceof Sdk.Mdq.MetadataFilterExpression)) {
    throw new Error("Sdk.Mdq.MetadataFilterExpression addFilter filter parameter requires a Sdk.Mdq.MetadataFilterExpression)");
   }
   _filterExpressions.add(filter);
  }

  //Set parameter values
  if (typeof filterOperator != "undefined") {
   _setValidFilterOperator(filterOperator);
  }


  this.addCondition = function (propertyName, conditionOperator, value) {
   ///<summary>
   /// <para>Adds a condition. This method accepts either the properties to create a new Sdk.Mdq.MetadataConditionExpression </para>
   /// <para>or a Sdk.Mdq.MetadataConditionExpression as the first argument.</para>
   ///</summary>
   ///<param name="propertyName" type="String">
   /// <para>The metadata property to evaluate</para>
   /// <para>Optional: Use one of the following enumerations depending on the type of metadata item:</para>
   /// <para> Entity: Sdk.Mdq.SearchableEntityMetadataProperties</para>
   /// <para> Attribute: Sdk.Mdq.SearchableAttributeMetadataProperties</para>
   /// <para> Relationship: Sdk.Mdq.SearchableRelationshipMetadataProperties</para>
   ///</param>
   ///<param name="conditionOperator" type="Sdk.Mdq.MetadataConditionOperator">
   /// The condition operator
   ///</param>
   ///<param name="value" type="Object">
   /// <para>The metadata value to evaluate</para>
   /// <para>If the value is a GUID you must use Sdk.Mdq.GuidValue</para>
   /// <para>Optional: Use one of the Sdk.Mdq.ValueEnums enumerations depending on the type of metadata item:</para>
   /// <para> Entity.OwnershipType: Sdk.Mdq.ValueEnums.OwnershipType</para>
   /// <para> Attribute.AttributeType : Sdk.Mdq.ValueEnums.AttributeTypeCode</para>
   /// <para> Attribute.RequiredLevel : Sdk.Mdq.ValueEnums.AttributeRequiredLevel</para>
   /// <para> DateTimeAttributeMetadata.Format Sdk.Mdq.ValueEnums.DateTimeFormat</para>
   /// <para> IntegerAttributeMetadata.Format Sdk.Mdq.ValueEnums.IntegerFormat</para>
   /// <para> StringAttributeMetadata.Format Sdk.Mdq.ValueEnums.StringFormat</para>
   /// <para> Attribute.ImeMode Sdk.Mdq.ValueEnums.ImeMode</para>
   /// <para> Relationship.SecurityTypes: Sdk.Mdq.ValueEnums.SecurityTypes</para>
   ///</param>
   if ((propertyName instanceof Sdk.Mdq.MetadataConditionExpression)) {
    _addValidCondition(propertyName);
   }
   else {
    _addValidCondition(new Sdk.Mdq.MetadataConditionExpression(propertyName, conditionOperator, value));
   }

  }
  this.addConditions = function (conditions) {
   ///<summary>
   /// Adds an array of conditions.
   ///</summary>
   ///<param name="conditions" type="Array">
   /// An Array of Sdk.Mdq.MetadataConditionExpression objects
   ///</param>
   _addValidConditions(conditions);
  }
  this.addFilter = function (filter) {
   ///<summary>
   /// Adds a filter
   ///</summary>
   ///<param name="filter" type="Sdk.Mdq.MetadataFilterExpression">
   /// The condition to add.
   ///</param>
   _addValidFilter(filter);
  }


  this.getConditions = function () {
   ///<summary>
   /// Gets the Sdk.Collection of Sdk.Mdq.MetadataConditionExpression instances.
   ///</summary>
   return _conditionExpressions;
  };
  //Note: setConditions is included for consistency since it is a get/set property.
  // But for normal usage people should use "getConditions().add(..." to add or remove  conditions.
  // Use setConditions only to overwrite the existing Sdk.Collection
  this.setConditions = function (value) {
   ///<summary>
   /// Sets the Sdk.Collection of Sdk.Mdq.MetadataConditionExpression instances.
   ///</summary>
   ///<param name="value" type="Sdk.Collection">
   /// <para>Sets the Sdk.Collection of Sdk.Mdq.MetadataConditionExpression instances.</para>
   /// <para>Recommend you use getConditions().add(.. or getConditions().remove(.. to change the contitions.</para>
   ///</param>
   _setValidConditions(value);
  };
  this.getFilterOperator = function () {
   ///<summary>
   /// Gets the Sdk.Mdq.LogicalOperator representing the FilterOperator for this Sdk.Mdq.MetadataFilterExpression.
   ///</summary>

   return _filterOperator;
  };
  this.setFilterOperator = function (value) {
   ///<summary>
   /// Sets the Sdk.Mdq.LogicalOperator representing the FilterOperator for this Sdk.Mdq.MetadataFilterExpression.
   ///</summary>
   ///<param name="value" type="Sdk.Mdq.LogicalOperator">
   /// The Sdk.Mdq.LogicalOperator representing the FilterOperator for this Sdk.Mdq.MetadataFilterExpression.
   ///</param>
   _setValidFilterOperator(value);
  };

  this.getFilters = function () {
   ///<summary>
   /// Gets the Sdk.Mdq.MetadataFilterExpression objects used as filters in this Sdk.Mdq.MetadataFilterExpression
   ///</summary>
   return _filterExpressions;
  };

 };
 this.MetadataFilterExpression.__class = true;
 //Sdk.Mdq.MetadataFilterExpression END
 //--------------------------------------------------------------------
 //Sdk.Mdq.MetadataPropertiesExpression START
 this.MetadataPropertiesExpression = function (allProperties, propertyNames) {
  ///<summary>
  /// Specifies the properties for which non-null values are returned from a query. 
  ///</summary>
  ///<param name="allProperties" type="Boolean">
  /// Whether to retrieve all the properties of a metadata object.
  ///</param>
  ///<param name="propertyNames" type="Array">
  /// <para>An array of strings representing the metadata properties to retrieve.</para>
  /// <para>Optional: Use one of the following enumerations depending on the metadata item:</para>
  /// <para> Entity: Sdk.Mdq.EntityMetadataProperties</para>
  /// <para> Attribute: Sdk.Mdq.AttributeMetadataProperties</para>
  /// <para> Relationship: Sdk.Mdq.RelationshipMetadataProperties</para>
  ///</param>
  if (!(this instanceof Sdk.Mdq.MetadataPropertiesExpression)) {
   return new Sdk.Mdq.MetadataPropertiesExpression(allProperties, propertyNames);
  }
  //Properties
  var _allProperties = true;
  var _propertyNames = new Sdk.Collection(String);



  //Internal Functions
  function _setValidAllProperties(value) {
   if (typeof value == "boolean") {
    _allProperties = value;
   }
   else {
    throw new Error("The Sdk.Mdq.MetadataPropertiesExpression allProperties  must be an Boolean value.");
   }
  }
  function _setValidPropertyNames(value) {
   if (typeof value.push != "undefined") //check if it is an array
   {
    _propertyNames = new Sdk.Collection(String, value);
   }
   else {
    throw new Error("The Sdk.Mdq.MetadataPropertiesExpression propertyNames  must be an Array.");
   }
  }

  //Set parameter values
  if (typeof allProperties != "undefined") {
   _setValidAllProperties(allProperties);
  }
  if (typeof propertyNames != "undefined") {
   _setValidPropertyNames(propertyNames);
  }

  //Public Methods
  this.addProperty = function (propertyName) {
   ///<summary>
   /// Adds the property name to the properties to return.
   ///</summary>
   ///<param name="propertyName" type="String">
   ///<para> Use one of the following enumerations to set the property value:</para>
   ///<para>Sdk.Mdq.EntityMetadataProperties</para>
   ///<para>Sdk.Mdq.AttributeMetadataProperties</para>
   ///<para>Sdk.Mdq.RelationshipMetadataProperties</para>
   ///</param>
   _propertyNames.add(propertyName);
  };
  this.addProperties = function (propertyNames) {
   ///<summary>
   /// Adds an array of properties
   ///</summary>
   ///<param name="propertyNames" type="Array">
   ///<para> Use one of the following enumerations to set string values in this array:</para>
   ///<para>Sdk.Mdq.EntityMetadataProperties</para>
   ///<para>Sdk.Mdq.AttributeMetadataProperties</para>
   ///<para>Sdk.Mdq.RelationshipMetadataProperties</para>
   ///</param>
   _propertyNames.addRange(propertyNames);
  };
  this.getAllProperties = function () {
   ///<summary>
   /// Gets the boolean value indicating if all properties should be returned.
   ///</summary>

   return _allProperties;
  };
  this.setAllProperties = function (value) {
   ///<summary>
   /// Sets the value indicating if all properties should be returned.
   ///</summary>
   ///<param name="value" type="Boolean">
   /// The value indicating if all properties should be returned.
   ///</param>
   _setValidAllProperties(value);
  };
  this.getPropertyNames = function () {
   ///<summary>
   /// Gets the Collection of property names to be returned.
   ///</summary>

   return _propertyNames;
  };
  this.setPropertyNames = function (value) {
   ///<summary>
   /// Sets the properties to be returned.
   ///</summary>
   ///<param name="value" type="Array">
   /// An array of string values fore the properties to be returned.
   ///</param>
   _setValidPropertyNames(value);
  };




 };
 this.MetadataPropertiesExpression.__class = true;
 //Sdk.Mdq.MetadataPropertiesExpression END
 //--------------------------------------------------------------------
 //Sdk.Mdq.MetadataQueryExpression START
 this.MetadataQueryExpression = function (criteria, properties) {
  ///<summary>
  /// For internal use only.
  ///</summary>
  if (!(this instanceof Sdk.Mdq.MetadataQueryExpression)) {
   return new Sdk.Mdq.MetadataQueryExpression(criteria, properties);
  }

  var _criteria = new Sdk.Mdq.MetadataFilterExpression();
  var _properties = new Sdk.Mdq.MetadataPropertiesExpression();

  function _setValidCriteria(value) {
   if (value instanceof Sdk.Mdq.MetadataFilterExpression)
   { _criteria = value; }
   else
   { throw new Error("Sdk.Mdq.MetadataQueryExpression Criteria  must be an Sdk.Mdq.MetadataFilterExpression"); }


  }
  function _setValidProperties(value) {
   if (value instanceof Sdk.Mdq.MetadataPropertiesExpression)
   { _properties = value; }
   else
   { throw new Error("Sdk.Mdq.MetadataQueryExpression Properties  must be an Sdk.Mdq.MetadataPropertiesExpression"); }
  }

  //Set parameter values
  if (typeof criteria != "undefined") {
   _setValidCriteria(criteria);
  }
  if (typeof properties != "undefined") {
   _setValidProperties(properties);
  }



  this.getCriteria = function () {
   ///<summary>
   /// Gets the criteria to be used in the query.
   ///</summary>
   ///<returns type="Sdk.Mdq.MetadataFilterExpression">
   /// The criteria to be used in the query.
   ///</returns>

   return _criteria;
  };
  this.setCriteria = function (value) {
   ///<summary>
   /// Sets the criteria to be used in the query.
   ///</summary>
   ///<param name="value" type="Sdk.Mdq.MetadataFilterExpression">
   /// The criteria to be used in the query.
   ///</param>
   _setValidCriteria(value);
  };
  this.getProperties = function () {
   ///<summary>
   /// Gets the properties to be returned by the query.
   ///</summary>
   ///<returns type="Sdk.Mdq.MetadataPropertiesExpressionn">
   /// The properties to be returned by the query.
   ///</returns>

   return _properties;
  };
  this.setProperties = function (value) {
   ///<summary>
   /// Sets the properties to be returned by the query.
   ///</summary>
   ///<param name="value" type="Sdk.Mdq.MetadataPropertiesExpressionn">
   /// The properties to be returned by the query.
   ///</param>
   _setValidProperties(value);
  };


 };
 this.MetadataQueryExpression.__class = true;
 //Sdk.Mdq.MetadataQueryExpression END
 //--------------------------------------------------------------------
 //Sdk.Mdq.RelationshipMetadataProperties START
 this.RelationshipMetadataProperties = function () {
  /// <summary>Sdk.Mdq.RelationshipMetadataProperties enum summary</summary>
  /// <field name="AssociatedMenuConfiguration" type="String" static="true">enum field summary for AssociatedMenuConfiguration</field>	
  /// <field name="CascadeConfiguration" type="String" static="true">enum field summary for CascadeConfiguration</field>	
  /// <field name="HasChanged" type="String" static="true">enum field summary for HasChanged</field>	
  /// <field name="Entity1AssociatedMenuConfiguration" type="String" static="true">enum field summary for Entity1AssociatedMenuConfiguration</field>	
  /// <field name="Entity1IntersectAttribute" type="String" static="true">enum field summary for Entity1IntersectAttribute</field>
  /// <field name="Entity1LogicalName" type="String" static="true">enum field summary for Entity1LogicalName</field>	
  /// <field name="Entity2AssociatedMenuConfiguration" type="String" static="true">enum field summary for Entity2AssociatedMenuConfiguration</field>	
  /// <field name="Entity2IntersectAttribute" type="String" static="true">enum field summary for Entity2IntersectAttribute</field>	
  /// <field name="Entity2LogicalName" type="String" static="true">enum field summary for Entity2LogicalName</field>
  /// <field name="IntersectEntityName" type="String" static="true">enum field summary for IntersectEntityName</field>	
  /// <field name="IntroducedVersion" type="String" static="true">enum field summary for IntroducedVersion</field>	
  /// <field name="IsCustomizable" type="String" static="true">enum field summary for IsCustomizable</field>
  /// <field name="IsCustomRelationship" type="String" static="true">enum field summary for IsCustomRelationship</field>	
  /// <field name="IsManaged" type="String" static="true">enum field summary for IsManaged</field>	
  /// <field name="IsValidForAdvancedFind" type="String" static="true">enum field summary for IsValidForAdvancedFind</field>	
  /// <field name="MetadataId" type="String" static="true">enum field summary for MetadataId</field>
  /// <field name="ReferencedAttribute" type="String" static="true">enum field summary for ReferencedAttribute</field>	
  /// <field name="ReferencedEntity" type="String" static="true">enum field summary for ReferencedEntity</field>	
  /// <field name="ReferencingAttribute" type="String" static="true">enum field summary for ReferencingAttribute</field>	
  /// <field name="ReferencingEntity" type="String" static="true">enum field summary for ReferencingEntity</field>
  /// <field name="SchemaName" type="String" static="true">enum field summary for SchemaName</field>	
  /// <field name="SecurityTypes" type="String" static="true">enum field summary for SecurityTypes</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.Mdq.RelationshipMetadataProperties END
 //--------------------------------------------------------------------
 //Sdk.Mdq.RelationshipQueryExpression START
 this.RelationshipQueryExpression = function (criteria, properties) {
  ///<summary>
  /// Defines a complex query to retrieve entity relationship metadata for entities retrieved using an EntityQueryExpression
  ///</summary>
  ///<param name="criteria" type="Sdk.Mdq.MetadataFilterExpression">
  /// The filter criteria for the metadata query
  ///</param>
  ///<param name="properties" type="Sdk.Mdq.MetadataPropertiesExpression">
  /// The properties to be returned by the query
  ///</param>
  if (!(this instanceof Sdk.Mdq.RelationshipQueryExpression)) {
   return new Sdk.Mdq.RelationshipQueryExpression(criteria, properties);
  }
  Sdk.Mdq.MetadataQueryExpression.call(this, criteria, properties);

 };
 this.RelationshipQueryExpression.__class = true;
 //Sdk.Mdq.RelationshipQueryExpression END
 //--------------------------------------------------------------------
 //Sdk.Mdq.SearchableAttributeMetadataProperties START
 this.SearchableAttributeMetadataProperties = function () {
  /// <summary>Sdk.Mdq.SearchableAttributeMetadataProperties enum summary</summary>
  /// <field name="AttributeOf" type="String" static="true">enum field summary for AttributeOf</field>	
  /// <field name="AttributeType" type="String" static="true">enum field summary for AttributeType</field>	
  /// <field name="CalculationOf" type="String" static="true">enum field summary for CalculationOf</field>	
  /// <field name="CanBeSecuredForCreate" type="String" static="true">enum field summary for CanBeSecuredForCreate</field>	
  /// <field name="CanBeSecuredForRead" type="String" static="true">enum field summary for CanBeSecuredForRead</field>	
  /// <field name="CanBeSecuredForUpdate" type="String" static="true">enum field summary for CanBeSecuredForUpdate</field>	
  /// <field name="CanModifyAdditionalSettings" type="String" static="true">enum field summary for CanModifyAdditionalSettings</field>	
  /// <field name="ColumnNumber" type="String" static="true">enum field summary for ColumnNumber</field>	
  /// <field name="DefaultFormValue" type="String" static="true">enum field summary for DefaultFormValue</field>	
  /// <field name="DefaultValue" type="String" static="true">enum field summary for DefaultValue</field>	
  /// <field name="DeprecatedVersion" type="String" static="true">enum field summary for DeprecatedVersion</field>	
  /// <field name="EntityLogicalName" type="String" static="true">enum field summary for EntityLogicalName</field>	
  /// <field name="Format" type="String" static="true">enum field summary for Format</field>	
  /// <field name="FormatName" type="String" static="true">enum field summary for FormatName</field>	
  /// <field name="ImeMode" type="String" static="true">enum field summary for ImeMode</field>	
  /// <field name="IntroducedVersion" type="String" static="true">enum field summary for IntroducedVersion</field>	
  /// <field name="IsAuditEnabled" type="String" static="true">enum field summary for IsAuditEnabled</field>	
  /// <field name="IsCustomAttribute" type="String" static="true">enum field summary for IsCustomAttribute</field>	
  /// <field name="IsCustomizable" type="String" static="true">enum field summary for IsCustomizable</field>	
  /// <field name="IsManaged" type="String" static="true">enum field summary for IsManaged</field>	
  /// <field name="IsPrimaryId" type="String" static="true">enum field summary for IsPrimaryId</field>	
  /// <field name="IsPrimaryName" type="String" static="true">enum field summary for IsPrimaryName</field>
  /// <field name="IsRenameable" type="String" static="true">enum field summary for IsRenameable</field>	
  /// <field name="IsSecured" type="String" static="true">enum field summary for IsSecured</field>	
  /// <field name="IsValidForAdvancedFind" type="String" static="true">enum field summary for IsValidForAdvancedFind</field>	
  /// <field name="IsValidForCreate" type="String" static="true">enum field summary for IsValidForCreate</field>	
  /// <field name="IsValidForRead" type="String" static="true">enum field summary for IsValidForRead</field>	
  /// <field name="IsValidForUpdate" type="String" static="true">enum field summary for IsValidForUpdate</field>	
  /// <field name="LinkedAttributeId" type="String" static="true">enum field summary for LinkedAttributeId</field>	
  /// <field name="LogicalName" type="String" static="true">enum field summary for LogicalName</field>	
  /// <field name="MaxLength" type="String" static="true">enum field summary for MaxLength</field>	
  /// <field name="MaxValue" type="String" static="true">enum field summary for MaxValue</field>
  /// <field name="MetadataId" type="String" static="true">enum field summary for MetadataId</field>	
  /// <field name="MinValue" type="String" static="true">enum field summary for MinValue</field>	
  /// <field name="Precision" type="String" static="true">enum field summary for Precision</field>	
  /// <field name="PrecisionSource" type="String" static="true">enum field summary for PrecisionSource</field>	
  /// <field name="RequiredLevel" type="String" static="true">enum field summary for RequiredLevel</field>	
  /// <field name="SchemaName" type="String" static="true">enum field summary for SchemaName</field>	
  /// <field name="YomiOf" type="String" static="true">enum field summary for YomiOf</field>	
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.Mdq.SearchableAttributeMetadataProperties END
 //--------------------------------------------------------------------
 //Sdk.Mdq.SearchableEntityMetadataProperties START
 this.SearchableEntityMetadataProperties = function () {
  /// <summary>Sdk.Mdq.SearchableEntityMetadataProperties enum summary</summary>
  /// <field name="ActivityTypeMask" type="String" static="true">enum field summary for ActivityTypeMask</field>	
  /// <field name="AutoCreateAccessTeams" type="String" static="true">enum field summary for AutoCreateAccessTeams</field>	
  /// <field name="AutoRouteToOwnerQueue" type="String" static="true">enum field summary for AutoRouteToOwnerQueue</field>	
  /// <field name="CanBeInManyToMany" type="String" static="true">enum field summary for CanBeInManyToMany</field>	
  /// <field name="CanBePrimaryEntityInRelationship" type="String" static="true">enum field summary for CanBePrimaryEntityInRelationship</field>	
  /// <field name="CanBeRelatedEntityInRelationship" type="String" static="true">enum field summary for CanBeRelatedEntityInRelationship</field>	
  /// <field name="CanCreateAttributes" type="String" static="true">enum field summary for CanCreateAttributes</field>	
  /// <field name="CanCreateCharts" type="String" static="true">enum field summary for CanCreateCharts</field>	
  /// <field name="CanCreateForms" type="String" static="true">enum field summary for CanCreateForms</field>
  /// <field name="CanCreateViews" type="String" static="true">enum field summary for CanCreateViews</field>	
  /// <field name="CanModifyAdditionalSettings" type="String" static="true">enum field summary for CanModifyAdditionalSettings</field>
  /// <field name="CanTriggerWorkflow" type="String" static="true">enum field summary for CanTriggerWorkflow</field>	
  /// <field name="IconLargeName" type="String" static="true">enum field summary for IconLargeName</field>	
  /// <field name="IconMediumName" type="String" static="true">enum field summary for IconMediumName</field>	
  /// <field name="IconSmallName" type="String" static="true">enum field summary for IconSmallName</field>	
  /// <field name="IntroducedVersion" type="String" static="true">enum field summary for IntroducedVersion</field>	
  /// <field name="IsActivity" type="String" static="true">enum field summary for IsActivity</field>	
  /// <field name="IsActivityParty" type="String" static="true">enum field summary for IsActivityParty</field>	
  /// <field name="IsAIRUpdated" type="String" static="true">enum field summary for IsAIRUpdated</field>	
  /// <field name="IsAuditEnabled" type="String" static="true">enum field summary for IsAuditEnabled</field>	
  /// <field name="IsAvailableOffline" type="String" static="true">enum field summary for IsAvailableOffline</field>
  /// <field name="IsBusinessProcessEnabled" type="String" static="true">enum field summary for IsBusinessProcessEnabled</field>
  /// <field name="IsChildEntity" type="String" static="true">enum field summary for IsChildEntity</field>	
  /// <field name="IsConnectionsEnabled" type="String" static="true">enum field summary for IsConnectionsEnabled</field>
  /// <field name="IsCustomEntity" type="String" static="true">enum field summary for IsCustomEntity</field>	
  /// <field name="IsCustomizable" type="String" static="true">enum field summary for IsCustomizable</field>	
  /// <field name="IsDocumentManagementEnabled" type="String" static="true">enum field summary for IsDocumentManagementEnabled</field>	
  /// <field name="IsDuplicateDetectionEnabled" type="String" static="true">enum field summary for IsDuplicateDetectionEnabled</field>	
  /// <field name="IsEnabledForCharts" type="String" static="true">enum field summary for IsEnabledForCharts</field>	
  /// <field name="IsImportable" type="String" static="true">enum field summary for IsImportable</field>	
  /// <field name="IsIntersect" type="String" static="true">enum field summary for IsIntersect</field>	
  /// <field name="IsMailMergeEnabled" type="String" static="true">enum field summary for IsMailMergeEnabled</field>
  /// <field name="IsManaged" type="String" static="true">enum field summary for IsManaged</field>	
  /// <field name="IsMappable" type="String" static="true">enum field summary for IsMappable</field>
  /// <field name="IsQuickCreateEnabled" type="String" static="true">enum field summary for IsQuickCreateEnabled</field>
  /// <field name="IsReadingPaneEnabled" type="String" static="true">enum field summary for IsReadingPaneEnabled</field>	
  /// <field name="IsRenameable" type="String" static="true">enum field summary for IsRenameable</field>	
  /// <field name="IsValidForAdvancedFind" type="String" static="true">enum field summary for IsValidForAdvancedFind</field>	
  /// <field name="IsValidForQueue" type="String" static="true">enum field summary for IsValidForQueue</field>	
  /// <field name="IsVisibleInMobile" type="String" static="true">enum field summary for IsVisibleInMobile</field>	
  /// <field name="IsVisibleInMobileClient" type="String" static="true">enum field summary for IsVisibleInMobileClient</field>	
  /// <field name="LogicalName" type="String" static="true">enum field summary for LogicalName</field>	
  /// <field name="MetadataId" type="String" static="true">enum field summary for MetadataId</field>	
  /// <field name="ObjectTypeCode" type="String" static="true">enum field summary for ObjectTypeCode</field>
  /// <field name="OwnershipType" type="String" static="true">enum field summary for OwnershipType</field>	
  /// <field name="PrimaryIdAttribute" type="String" static="true">enum field summary for PrimaryIdAttribute</field>
  /// <field name="PrimaryImageAttribute" type="String" static="true">enum field summary for PrimaryImageAttribute</field>
  /// <field name="PrimaryNameAttribute" type="String" static="true">enum field summary for PrimaryNameAttribute</field>	
  /// <field name="RecurrenceBaseEntityLogicalName" type="String" static="true">enum field summary for RecurrenceBaseEntityLogicalName</field>
  /// <field name="ReportViewName" type="String" static="true">enum field summary for ReportViewName</field>	
  /// <field name="SchemaName" type="String" static="true">enum field summary for SchemaName</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.Mdq.SearchableEntityMetadataProperties END
 //--------------------------------------------------------------------
 //Sdk.Mdq.SearchableRelationshipMetadataProperties START
 this.SearchableRelationshipMetadataProperties = function () {
  /// <summary>Sdk.Mdq.SearchableRelationshipMetadataProperties enum summary</summary>
  /// <field name="HasChanged" type="String" static="true">enum field summary for HasChanged</field>	
  /// <field name="Entity1IntersectAttribute" type="String" static="true">enum field summary for Entity1IntersectAttribute</field>	
  /// <field name="Entity1LogicalName" type="String" static="true">enum field summary for Entity1LogicalName</field>	
  /// <field name="Entity2IntersectAttribute" type="String" static="true">enum field summary for Entity2IntersectAttribute</field>	
  /// <field name="Entity2LogicalName" type="String" static="true">enum field summary for Entity2LogicalName</field>	
  /// <field name="IntersectEntityName" type="String" static="true">enum field summary for IntersectEntityName</field>	
  /// <field name="IntroducedVersion" type="String" static="true">enum field summary for IntroducedVersion</field>	
  /// <field name="IsCustomizable" type="String" static="true">enum field summary for IsCustomizable</field>	
  /// <field name="IsCustomRelationship" type="String" static="true">enum field summary for IsCustomRelationship</field>	
  /// <field name="IsManaged" type="String" static="true">enum field summary for IsManaged</field>
  /// <field name="IsValidForAdvancedFind" type="String" static="true">enum field summary for IsValidForAdvancedFind</field>	
  /// <field name="MetadataId" type="String" static="true">enum field summary for MetadataId</field>	
  /// <field name="ReferencedAttribute" type="String" static="true">enum field summary for ReferencedAttribute</field>	
  /// <field name="ReferencedEntity" type="String" static="true">enum field summary for ReferencedEntity</field>	
  /// <field name="ReferencingAttribute" type="String" static="true">enum field summary for ReferencingAttribute</field>	
  /// <field name="ReferencingEntity" type="String" static="true">enum field summary for ReferencingEntity</field>	
  /// <field name="SchemaName" type="String" static="true">enum field summary for SchemaName</field>	
  /// <field name="SecurityTypes" type="String" static="true">enum field summary for SecurityTypes</field>
  throw new Error("Constructor not implemented this is a static enum.");
 };
 //Sdk.Mdq.SearchableRelationshipMetadataProperties END


}).call(Sdk.Mdq);

//Sdk.Mdq.ValueEnums START
(function () {

 this.OwnershipType = function () {
  /// <summary>Sdk.Mdq.ValueEnums.OwnershipType enum summary</summary>
  /// <field name="None" type="String" static="true">enum field summary for None</field>
  /// <field name="OrganizationOwned" type="String" static="true">enum field summary for OrganizationOwned</field>
  /// <field name="TeamOwned" type="String" static="true">enum field summary for TeamOwned</field>
  /// <field name="UserOwned" type="String" static="true">enum field summary for UserOwned</field>
  throw new Error("Constructor not implemented this is a static enum.");
 }
 this.AttributeTypeCode = function () {
  /// <summary>Sdk.Mdq.ValueEnums.AttributeTypeCode enum summary</summary>
  /// <field name="BigInt" type="String" static="true">enum field summary for BigInt</field>
  /// <field name="Boolean" type="String" static="true">enum field summary for Boolean</field>
  /// <field name="CalendarRules" type="String" static="true">enum field summary for CalendarRules</field>
  /// <field name="Customer" type="String" static="true">enum field summary for Customer</field>
  /// <field name="DateTime" type="String" static="true">enum field summary for DateTime</field>
  /// <field name="Decimal" type="String" static="true">enum field summary for Decimal</field>
  /// <field name="Double" type="String" static="true">enum field summary for Double</field>
  /// <field name="EntityName" type="String" static="true">enum field summary for EntityName</field>
  /// <field name="Integer" type="String" static="true">enum field summary for Integer</field>
  /// <field name="Lookup" type="String" static="true">enum field summary for Lookup</field>
  /// <field name="ManagedProperty" type="String" static="true">enum field summary for ManagedProperty</field>
  /// <field name="Memo" type="String" static="true">enum field summary for Memo</field>
  /// <field name="Money" type="String" static="true">enum field summary for Money</field>
  /// <field name="Owner" type="String" static="true">enum field summary for Owner</field>
  /// <field name="PartyList" type="String" static="true">enum field summary for PartyList</field>
  /// <field name="Picklist" type="String" static="true">enum field summary for Picklist</field>
  /// <field name="State" type="String" static="true">enum field summary for State</field>
  /// <field name="Status" type="String" static="true">enum field summary for Status</field>
  /// <field name="String" type="String" static="true">enum field summary for String</field>
  /// <field name="Uniqueidentifier" type="String" static="true">enum field summary for Uniqueidentifier</field>
  /// <field name="Virtual" type="String" static="true">enum field summary for Virtual</field>

  throw new Error("Constructor not implemented this is a static enum.");
 }
 this.AttributeRequiredLevel = function () {
  /// <summary>Sdk.Mdq.ValueEnums.AttributeRequiredLevel enum summary</summary>
  /// <field name="ApplicationRequired" type="String" static="true">enum field summary for ApplicationRequired</field>
  /// <field name="None" type="String" static="true">enum field summary for None</field>
  /// <field name="Recommended" type="String" static="true">enum field summary for Recommended</field>
  /// <field name="SystemRequired" type="String" static="true">enum field summary for SystemRequired</field>    
  throw new Error("Constructor not implemented this is a static enum.");
 }
 this.DateTimeFormat = function () {
  /// <summary>Sdk.Mdq.ValueEnums.DateTimeFormat enum summary</summary>
  /// <field name="DateAndTime" type="String" static="true">enum field summary for DateAndTime</field>
  /// <field name="DateOnly" type="String" static="true">enum field summary for DateOnly</field>  
  throw new Error("Constructor not implemented this is a static enum.");
 }
 this.ImeMode = function () {
  /// <summary>Sdk.Mdq.ValueEnums.ImeMode enum summary</summary>
  /// <field name="Active" type="String" static="true">enum field summary for Active</field>
  /// <field name="Auto" type="String" static="true">enum field summary for Auto</field>
  /// <field name="Disabled" type="String" static="true">enum field summary for Disabled</field>
  /// <field name="Inactive" type="String" static="true">enum field summary for Inactive</field>
  throw new Error("Constructor not implemented this is a static enum.");
 }
 this.IntegerFormat = function () {
  /// <summary>Sdk.Mdq.ValueEnums.IntegerFormat enum summary</summary>
  /// <field name="Duration" type="String" static="true">enum field summary for Duration</field>
  /// <field name="Language" type="String" static="true">enum field summary for Language</field>
  /// <field name="Locale" type="String" static="true">enum field summary for Locale</field>
  /// <field name="None" type="String" static="true">enum field summary for None</field>
  /// <field name="TimeZone" type="String" static="true">enum field summary for TimeZone</field>
  throw new Error("Constructor not implemented this is a static enum.");
 }
 this.SecurityTypes = function () {
  /// <summary>Sdk.Mdq.ValueEnums.SecurityTypes enum summary</summary>
  /// <field name="Append" type="String" static="true">enum field summary for Append</field>
  /// <field name="Inheritance" type="String" static="true">enum field summary for Inheritance</field>
  /// <field name="None" type="String" static="true">enum field summary for None</field>
  /// <field name="ParentChild" type="String" static="true">enum field summary for ParentChild</field>
  /// <field name="Pointer" type="String" static="true">enum field summary for Pointer</field>
  throw new Error("Constructor not implemented this is a static enum.");
 }
 this.StringFormat = function () {
  /// <summary>Sdk.Mdq.ValueEnums.StringFormat enum summary</summary>
  /// <field name="Email" type="String" static="true">enum field summary for Email</field>
  /// <field name="PhoneticGuide" type="String" static="true">enum field summary for PhoneticGuide</field>
  /// <field name="Text" type="String" static="true">enum field summary for Text</field>
  /// <field name="TextArea" type="String" static="true">enum field summary for TextArea</field>
  /// <field name="TickerSymbol" type="String" static="true">enum field summary for TickerSymbol</field>
  /// <field name="Url" type="String" static="true">enum field summary for Url</field>
  /// <field name="VersionNumber" type="String" static="true">enum field summary for VersionNumber</field>
  throw new Error("Constructor not implemented this is a static enum.");
 }

}).call(Sdk.Mdq.ValueEnums);
//Sdk.Mdq.ValueEnums END





//Prototypes
Sdk.RetrieveMetadataChangesRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveMetadataChangesResponse.prototype = new Sdk.OrganizationResponse();



//Sdk.Mdq.AttributeMetadataProperties.prototype START
Sdk.Mdq.AttributeMetadataProperties.prototype = {
 AttributeOf: "AttributeOf",
 AttributeType: "AttributeType",
 AttributeTypeName: "AttributeTypeName", //new
 CalculationOf: "CalculationOf",
 CanBeSecuredForCreate: "CanBeSecuredForCreate",
 CanBeSecuredForRead: "CanBeSecuredForRead",
 CanBeSecuredForUpdate: "CanBeSecuredForUpdate",
 CanModifyAdditionalSettings: "CanModifyAdditionalSettings",
 ColumnNumber: "ColumnNumber",
 DefaultFormValue: "DefaultFormValue",
 DefaultValue: "DefaultValue",
 DeprecatedVersion: "DeprecatedVersion",
 Description: "Description",
 DisplayName: "DisplayName",
 EntityLogicalName: "EntityLogicalName",
 Format: "Format",
 FormatName: "FormatName", //new
 ImeMode: "ImeMode",
 IntroducedVersion: "IntroducedVersion", //new
 IsAuditEnabled: "IsAuditEnabled",
 IsCustomAttribute: "IsCustomAttribute",
 IsCustomizable: "IsCustomizable",
 IsManaged: "IsManaged",
 IsPrimaryId: "IsPrimaryId",
 IsPrimaryName: "IsPrimaryName",
 IsRenameable: "IsRenameable",
 IsSecured: "IsSecured",
 IsValidForAdvancedFind: "IsValidForAdvancedFind",
 IsValidForCreate: "IsValidForCreate",
 IsValidForRead: "IsValidForRead",
 IsValidForUpdate: "IsValidForUpdate",
 LinkedAttributeId: "LinkedAttributeId",
 LogicalName: "LogicalName",
 MaxLength: "MaxLength",
 MaxValue: "MaxValue",
 MetadataId: "MetadataId",
 MinValue: "MinValue",
 OptionSet: "OptionSet",
 Precision: "Precision",
 PrecisionSource: "PrecisionSource",
 RequiredLevel: "RequiredLevel",
 SchemaName: "SchemaName",
 Targets: "Targets",
 YomiOf: "YomiOf"
};
Sdk.Mdq.AttributeMetadataProperties.AttributeOf = "AttributeOf";
Sdk.Mdq.AttributeMetadataProperties.AttributeType = "AttributeType";
Sdk.Mdq.AttributeMetadataProperties.AttributeTypeName = "AttributeTypeName";
Sdk.Mdq.AttributeMetadataProperties.CalculationOf = "CalculationOf";
Sdk.Mdq.AttributeMetadataProperties.CanBeSecuredForCreate = "CanBeSecuredForCreate";
Sdk.Mdq.AttributeMetadataProperties.CanBeSecuredForRead = "CanBeSecuredForRead";
Sdk.Mdq.AttributeMetadataProperties.CanBeSecuredForUpdate = "CanBeSecuredForUpdate";
Sdk.Mdq.AttributeMetadataProperties.CanModifyAdditionalSettings = "CanModifyAdditionalSettings";
Sdk.Mdq.AttributeMetadataProperties.ColumnNumber = "ColumnNumber";
Sdk.Mdq.AttributeMetadataProperties.DefaultFormValue = "DefaultFormValue";
Sdk.Mdq.AttributeMetadataProperties.DefaultValue = "DefaultValue";
Sdk.Mdq.AttributeMetadataProperties.DeprecatedVersion = "DeprecatedVersion";
Sdk.Mdq.AttributeMetadataProperties.Description = "Description";
Sdk.Mdq.AttributeMetadataProperties.DisplayName = "DisplayName";
Sdk.Mdq.AttributeMetadataProperties.EntityLogicalName = "EntityLogicalName";
Sdk.Mdq.AttributeMetadataProperties.Format = "Format";
Sdk.Mdq.AttributeMetadataProperties.FormatName = "FormatName";
Sdk.Mdq.AttributeMetadataProperties.ImeMode = "ImeMode";
Sdk.Mdq.AttributeMetadataProperties.IntroducedVersion = "IntroducedVersion";
Sdk.Mdq.AttributeMetadataProperties.IsAuditEnabled = "IsAuditEnabled";
Sdk.Mdq.AttributeMetadataProperties.IsCustomAttribute = "IsCustomAttribute";
Sdk.Mdq.AttributeMetadataProperties.IsCustomizable = "IsCustomizable";
Sdk.Mdq.AttributeMetadataProperties.IsManaged = "IsManaged";
Sdk.Mdq.AttributeMetadataProperties.IsPrimaryId = "IsPrimaryId";
Sdk.Mdq.AttributeMetadataProperties.IsPrimaryName = "IsPrimaryName";
Sdk.Mdq.AttributeMetadataProperties.IsRenameable = "IsRenameable";
Sdk.Mdq.AttributeMetadataProperties.IsSecured = "IsSecured";
Sdk.Mdq.AttributeMetadataProperties.IsValidForAdvancedFind = "IsValidForAdvancedFind";
Sdk.Mdq.AttributeMetadataProperties.IsValidForCreate = "IsValidForCreate";
Sdk.Mdq.AttributeMetadataProperties.IsValidForRead = "IsValidForRead";
Sdk.Mdq.AttributeMetadataProperties.IsValidForUpdate = "IsValidForUpdate";
Sdk.Mdq.AttributeMetadataProperties.LinkedAttributeId = "LinkedAttributeId";
Sdk.Mdq.AttributeMetadataProperties.LogicalName = "LogicalName";
Sdk.Mdq.AttributeMetadataProperties.MaxLength = "MaxLength";
Sdk.Mdq.AttributeMetadataProperties.MaxValue = "MaxValue";
Sdk.Mdq.AttributeMetadataProperties.MetadataId = "MetadataId";
Sdk.Mdq.AttributeMetadataProperties.MinValue = "MinValue";
Sdk.Mdq.AttributeMetadataProperties.OptionSet = "OptionSet";
Sdk.Mdq.AttributeMetadataProperties.Precision = "Precision";
Sdk.Mdq.AttributeMetadataProperties.PrecisionSource = "PrecisionSource";
Sdk.Mdq.AttributeMetadataProperties.RequiredLevel = "RequiredLevel";
Sdk.Mdq.AttributeMetadataProperties.SchemaName = "SchemaName";
Sdk.Mdq.AttributeMetadataProperties.Targets = "Targets";
Sdk.Mdq.AttributeMetadataProperties.YomiOf = "YomiOf";
Sdk.Mdq.AttributeMetadataProperties.__enum = true;
Sdk.Mdq.AttributeMetadataProperties.__flags = true;
//Sdk.Mdq.AttributeMetadataProperties.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.AttributeQueryExpression.prototype START
Sdk.Mdq.AttributeQueryExpression.prototype = new Sdk.Mdq.MetadataQueryExpression();

Sdk.Mdq.AttributeQueryExpression.prototype.toXml = function () {

 if ((this.getCriteria().getConditions().getCount() == 0) &&
  (this.getProperties().getPropertyNames().getCount() == 0) &&
  (this.getProperties().getAllProperties() == false)) {
  return "<j:AttributeQuery i:nil=\"true\" />";
 }
 else {
  return ["<j:AttributeQuery>",
                   this.toValueXml(),
                 "</j:AttributeQuery>"].join("");
 }
}
//Sdk.Mdq.AttributeQueryExpression.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.DeletedMetadataFilters.prototype START
Sdk.Mdq.DeletedMetadataFilters.prototype = {
 Default: 1,
 Entity: 1,
 Attribute: 2,
 Relationship: 4,
 Label: 8,
 OptionSet: 16,
 All: 31
};
Sdk.Mdq.DeletedMetadataFilters.Default = 1;
Sdk.Mdq.DeletedMetadataFilters.Entity = 1;
Sdk.Mdq.DeletedMetadataFilters.Attribute = 2;
Sdk.Mdq.DeletedMetadataFilters.Relationship = 4;
Sdk.Mdq.DeletedMetadataFilters.Label = 8;
Sdk.Mdq.DeletedMetadataFilters.OptionSet = 16;
Sdk.Mdq.DeletedMetadataFilters.All = 31;
Sdk.Mdq.DeletedMetadataFilters.__enum = true;
Sdk.Mdq.DeletedMetadataFilters.__flags = true;

//Sdk.Mdq.DeletedMetadataFilters.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.EntityMetadataProperties.prototype START
Sdk.Mdq.EntityMetadataProperties.prototype = {
 ActivityTypeMask: "ActivityTypeMask",
 Attributes: "Attributes",
 AutoCreateAccessTeams: "AutoCreateAccessTeams", //new
 AutoRouteToOwnerQueue: "AutoRouteToOwnerQueue",
 CanBeInManyToMany: "CanBeInManyToMany",
 CanBePrimaryEntityInRelationship: "CanBePrimaryEntityInRelationship",
 CanBeRelatedEntityInRelationship: "CanBeRelatedEntityInRelationship",
 CanCreateAttributes: "CanCreateAttributes",
 CanCreateCharts: "CanCreateCharts",
 CanCreateForms: "CanCreateForms",
 CanCreateViews: "CanCreateViews",
 CanModifyAdditionalSettings: "CanModifyAdditionalSettings",
 CanTriggerWorkflow: "CanTriggerWorkflow",
 Description: "Description",
 DisplayCollectionName: "DisplayCollectionName",
 DisplayName: "DisplayName",
 IconLargeName: "IconLargeName",
 IconMediumName: "IconMediumName",
 IconSmallName: "IconSmallName",
 IntroducedVersion: "IntroducedVersion", //new
 IsActivity: "IsActivity",
 IsActivityParty: "IsActivityParty",
 IsAIRUpdated: "IsAIRUpdated", //new
 IsAuditEnabled: "IsAuditEnabled",
 IsAvailableOffline: "IsAvailableOffline",
 IsBusinessProcessEnabled: "IsBusinessProcessEnabled", //new
 IsChildEntity: "IsChildEntity",
 IsConnectionsEnabled: "IsConnectionsEnabled",
 IsCustomEntity: "IsCustomEntity",
 IsCustomizable: "IsCustomizable",
 IsDocumentManagementEnabled: "IsDocumentManagementEnabled",
 IsDuplicateDetectionEnabled: "IsDuplicateDetectionEnabled",
 IsEnabledForCharts: "IsEnabledForCharts",
 IsImportable: "IsImportable",
 IsIntersect: "IsIntersect",
 IsMailMergeEnabled: "IsMailMergeEnabled",
 IsManaged: "IsManaged",
 IsMappable: "IsMappable",
 IsQuickCreateEnabled: "IsQuickCreateEnabled", //new
 IsReadingPaneEnabled: "IsReadingPaneEnabled",
 IsRenameable: "IsRenameable",
 IsValidForAdvancedFind: "IsValidForAdvancedFind",
 IsValidForQueue: "IsValidForQueue",
 IsVisibleInMobile: "IsVisibleInMobile",
 IsVisibleInMobileClient: "IsVisibleInMobileClient", //new
 LogicalName: "LogicalName",
 ManyToManyRelationships: "ManyToManyRelationships",
 ManyToOneRelationships: "ManyToOneRelationships",
 MetadataId: "MetadataId",
 ObjectTypeCode: "ObjectTypeCode",
 OneToManyRelationships: "OneToManyRelationships",
 OwnershipType: "OwnershipType",
 PrimaryIdAttribute: "PrimaryIdAttribute",
 PrimaryImageAttribute: "PrimaryImageAttribute", //new
 PrimaryNameAttribute: "PrimaryNameAttribute",
 Privileges: "Privileges",
 RecurrenceBaseEntityLogicalName: "RecurrenceBaseEntityLogicalName",
 ReportViewName: "ReportViewName",
 SchemaName: "SchemaName"
};
Sdk.Mdq.EntityMetadataProperties.ActivityTypeMask = "ActivityTypeMask";
Sdk.Mdq.EntityMetadataProperties.Attributes = "Attributes";
Sdk.Mdq.EntityMetadataProperties.AutoCreateAccessTeams = "AutoCreateAccessTeams";
Sdk.Mdq.EntityMetadataProperties.AutoRouteToOwnerQueue = "AutoRouteToOwnerQueue";
Sdk.Mdq.EntityMetadataProperties.CanBeInManyToMany = "CanBeInManyToMany";
Sdk.Mdq.EntityMetadataProperties.CanBePrimaryEntityInRelationship = "CanBePrimaryEntityInRelationship";
Sdk.Mdq.EntityMetadataProperties.CanBeRelatedEntityInRelationship = "CanBeRelatedEntityInRelationship";
Sdk.Mdq.EntityMetadataProperties.CanCreateAttributes = "CanCreateAttributes";
Sdk.Mdq.EntityMetadataProperties.CanCreateCharts = "CanCreateCharts";
Sdk.Mdq.EntityMetadataProperties.CanCreateForms = "CanCreateForms";
Sdk.Mdq.EntityMetadataProperties.CanCreateViews = "CanCreateViews";
Sdk.Mdq.EntityMetadataProperties.CanModifyAdditionalSettings = "CanModifyAdditionalSettings";
Sdk.Mdq.EntityMetadataProperties.CanTriggerWorkflow = "CanTriggerWorkflow";
Sdk.Mdq.EntityMetadataProperties.Description = "Description";
Sdk.Mdq.EntityMetadataProperties.DisplayCollectionName = "DisplayCollectionName";
Sdk.Mdq.EntityMetadataProperties.DisplayName = "DisplayName";
Sdk.Mdq.EntityMetadataProperties.IconLargeName = "IconLargeName";
Sdk.Mdq.EntityMetadataProperties.IconMediumName = "IconMediumName";
Sdk.Mdq.EntityMetadataProperties.IconSmallName = "IconSmallName";
Sdk.Mdq.EntityMetadataProperties.IntroducedVersion = "IntroducedVersion";
Sdk.Mdq.EntityMetadataProperties.IsActivity = "IsActivity";
Sdk.Mdq.EntityMetadataProperties.IsActivityParty = "IsActivityParty";
Sdk.Mdq.EntityMetadataProperties.IsAIRUpdated = "IsAIRUpdated";
Sdk.Mdq.EntityMetadataProperties.IsAuditEnabled = "IsAuditEnabled";
Sdk.Mdq.EntityMetadataProperties.IsAvailableOffline = "IsAvailableOffline";
Sdk.Mdq.EntityMetadataProperties.IsBusinessProcessEnabled = "IsBusinessProcessEnabled";
Sdk.Mdq.EntityMetadataProperties.IsChildEntity = "IsChildEntity";
Sdk.Mdq.EntityMetadataProperties.IsConnectionsEnabled = "IsConnectionsEnabled";
Sdk.Mdq.EntityMetadataProperties.IsCustomEntity = "IsCustomEntity";
Sdk.Mdq.EntityMetadataProperties.IsCustomizable = "IsCustomizable";
Sdk.Mdq.EntityMetadataProperties.IsDocumentManagementEnabled = "IsDocumentManagementEnabled";
Sdk.Mdq.EntityMetadataProperties.IsDuplicateDetectionEnabled = "IsDuplicateDetectionEnabled";
Sdk.Mdq.EntityMetadataProperties.IsEnabledForCharts = "IsEnabledForCharts";
Sdk.Mdq.EntityMetadataProperties.IsImportable = "IsImportable";
Sdk.Mdq.EntityMetadataProperties.IsIntersect = "IsIntersect";
Sdk.Mdq.EntityMetadataProperties.IsMailMergeEnabled = "IsMailMergeEnabled";
Sdk.Mdq.EntityMetadataProperties.IsManaged = "IsManaged";
Sdk.Mdq.EntityMetadataProperties.IsMappable = "IsMappable";
Sdk.Mdq.EntityMetadataProperties.IsQuickCreateEnabled = "IsQuickCreateEnabled";
Sdk.Mdq.EntityMetadataProperties.IsReadingPaneEnabled = "IsReadingPaneEnabled";
Sdk.Mdq.EntityMetadataProperties.IsRenameable = "IsRenameable";
Sdk.Mdq.EntityMetadataProperties.IsValidForAdvancedFind = "IsValidForAdvancedFind";
Sdk.Mdq.EntityMetadataProperties.IsValidForQueue = "IsValidForQueue";
Sdk.Mdq.EntityMetadataProperties.IsVisibleInMobile = "IsVisibleInMobile";
Sdk.Mdq.EntityMetadataProperties.IsVisibleInMobileClient = "IsVisibleInMobileClient";
Sdk.Mdq.EntityMetadataProperties.LogicalName = "LogicalName";
Sdk.Mdq.EntityMetadataProperties.ManyToManyRelationships = "ManyToManyRelationships";
Sdk.Mdq.EntityMetadataProperties.ManyToOneRelationships = "ManyToOneRelationships";
Sdk.Mdq.EntityMetadataProperties.MetadataId = "MetadataId";
Sdk.Mdq.EntityMetadataProperties.ObjectTypeCode = "ObjectTypeCode";
Sdk.Mdq.EntityMetadataProperties.OneToManyRelationships = "OneToManyRelationships";
Sdk.Mdq.EntityMetadataProperties.OwnershipType = "OwnershipType";
Sdk.Mdq.EntityMetadataProperties.PrimaryIdAttribute = "PrimaryIdAttribute";
Sdk.Mdq.EntityMetadataProperties.PrimaryImageAttribute = "PrimaryImageAttribute";
Sdk.Mdq.EntityMetadataProperties.PrimaryNameAttribute = "PrimaryNameAttribute";
Sdk.Mdq.EntityMetadataProperties.Privileges = "Privileges";
Sdk.Mdq.EntityMetadataProperties.RecurrenceBaseEntityLogicalName = "RecurrenceBaseEntityLogicalName";
Sdk.Mdq.EntityMetadataProperties.ReportViewName = "ReportViewName";
Sdk.Mdq.EntityMetadataProperties.SchemaName = "SchemaName";
Sdk.Mdq.EntityMetadataProperties.__enum = true;
Sdk.Mdq.EntityMetadataProperties.__flags = true;
//Sdk.Mdq.EntityMetadataProperties.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.EntityQueryExpression.prototype START
Sdk.Mdq.EntityQueryExpression.prototype = new Sdk.Mdq.MetadataQueryExpression();

Sdk.Mdq.EntityQueryExpression.prototype.toXml = function () {

 var attributeQueryXml = (this.getAttributeQuery() == null) ? "<j:AttributeQuery i:nil=\"true\" />" : this.getAttributeQuery().toXml();
 var labelQueryXml = (this.getLabelQuery() == null) ? "<j:LabelQuery i:nil=\"true\" />" : this.getLabelQuery().toXml();
 var relationshipQueryXml = (this.getRelationshipQuery() == null) ? "<j:RelationshipQuery i:nil=\"true\" />" : this.getRelationshipQuery().toXml();

 return ["<b:value i:type=\"j:EntityQueryExpression\">",
        this.toValueXml(),
        attributeQueryXml,
        labelQueryXml,
        relationshipQueryXml,
        "</b:value>"].join("");
}
//Sdk.Mdq.EntityQueryExpression.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.LabelQueryExpression.prototype START

Sdk.Mdq.LabelQueryExpression.prototype.toXml = function () {
 ///<summary>
 /// For internal use only.
 ///</summary>
 if (this.getLanguages().getCount() == 0) {
  return "<j:LabelQuery i:nil=\"true\" />";
 }
 else {
  return ["<j:LabelQuery>",
          this.toValueXml(),
          "</j:LabelQuery>"].join("");
 }
}

Sdk.Mdq.LabelQueryExpression.prototype.toValueXml = function () {
 ///<summary>
 /// For internal use only.
 ///</summary>
 var _xml = ["<j:FilterLanguages>"];
 this.getLanguages().forEach(function (ln, i) {
  _xml.push("<d:int>" + ln + "</d:int>");
 })
 _xml.push("</j:FilterLanguages>");
 return _xml.join("");
}

//Sdk.Mdq.LabelQueryExpression.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.LogicalOperator.prototype START
Sdk.Mdq.LogicalOperator.prototype = { And: "And", Or: "Or" };
Sdk.Mdq.LogicalOperator.And = "And";
Sdk.Mdq.LogicalOperator.Or = "Or";
Sdk.Mdq.LogicalOperator.__enum = true;
Sdk.Mdq.LogicalOperator.__flags = true;
//Sdk.Mdq.LogicalOperator.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.MetadataConditionExpression.prototype START

Sdk.Mdq.MetadataConditionExpression.prototype.toXml = function () {

 if (this.getConditionOperator() == null ||
  this.getPropertyName() == null ||
  this.getValueType() == null) {
  throw new Error("A Sdk.Mdq.MetadataConditionExpression has properties that are null.");
 }

 var valueString;
 if (this.getValueType() == "null") {
  valueString = "<j:Value i:nil=\"true\" />";
 }
 else {
  if (this.getValueIsArray()) {
   var _xml = ["<j:Value i:type=\"",
    this.getValueNamespace(),
    ":ArrayOf",
    this.getValueType(),
    "\" >"];

   for (var i = 0; i < this.getValue().length; i++) {
    _xml.push(["<",
     this.getValueNamespace(),
     ":",
     this.getValueType(),
     ">",
     this.getValue()[i],
     "</",
     this.getValueNamespace(),
     ":",
     this.getValueType(),
     ">"].join(""));
   }
   _xml.push("</j:Value>");
   valueString = _xml.join("");
  }
  else {
   valueString = ["<j:Value i:type=\"",
     this.getValueNamespace(),
     ":",
     this.getValueType(),
     "\" >",
     this.getValue(),
     "</j:Value>"].join("");
  }

 }

 return ["<j:MetadataConditionExpression>",
"<j:ConditionOperator>" + this.getConditionOperator() + "</j:ConditionOperator>",
"<j:PropertyName>" + this.getPropertyName() + "</j:PropertyName>",
valueString,
"</j:MetadataConditionExpression>"].join("");
}
//Sdk.Mdq.MetadataConditionExpression.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.MetadataConditionOperator.prototype START
Sdk.Mdq.MetadataConditionOperator.prototype = {
 Equals: "Equals",
 NotEquals: "NotEquals",
 In: "In",
 NotIn: "NotIn",
 GreaterThan: "GreaterThan",
 LessThan: "LessThan"
};
Sdk.Mdq.MetadataConditionOperator.Equals = "Equals";
Sdk.Mdq.MetadataConditionOperator.NotEquals = "NotEquals";
Sdk.Mdq.MetadataConditionOperator.In = "In";
Sdk.Mdq.MetadataConditionOperator.NotIn = "NotIn";
Sdk.Mdq.MetadataConditionOperator.GreaterThan = "GreaterThan";
Sdk.Mdq.MetadataConditionOperator.LessThan = "LessThan";
Sdk.Mdq.MetadataConditionOperator.__enum = true;
Sdk.Mdq.MetadataConditionOperator.__flags = true;
//Sdk.Mdq.MetadataConditionOperator.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.MetadataFilterExpression.prototype START

Sdk.Mdq.MetadataFilterExpression.prototype.toValueXml = function () {
 var conditionsXML = "<j:Conditions />";
 if (this.getConditions().getCount() > 0) {
  var _xml = ["<j:Conditions>"];
  this.getConditions().forEach(function (mce, i) {
   _xml.push(mce.toXml());
  });
  _xml.push("</j:Conditions>");
  conditionsXML = _xml.join("");
 }

 var filtersXML = "<j:Filters />";

 if (this.getFilters().getCount() > 0) {
  var _xml = ["<j:Filters>"];
  this.getFilters().forEach(function (fltr, i) {
   _xml.push(fltr.toXml());
  });
  _xml.push("</j:Filters>");
  filtersXML = _xml.join("");
 }

 return [conditionsXML,
         "<j:FilterOperator>" + this.getFilterOperator() + "</j:FilterOperator>",
         filtersXML
 ].join("");
}
//Sdk.Mdq.MetadataFilterExpression.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.MetadataPropertiesExpression.prototype START

Sdk.Mdq.MetadataPropertiesExpression.prototype.toXml = function () {

 var allPropertiesXml = ["<j:AllProperties>", this.getAllProperties(), "</j:AllProperties>"].join("");

 var properties = [];
 this.getPropertyNames().forEach(function (pn, i) {
  properties.push("<f:string>" + pn + "</f:string>");
 })

 var propertyNamesXml = (properties.length == 0) ? "<j:PropertyNames />" : ["<j:PropertyNames>", properties.join(""), "</j:PropertyNames>"].join("");


 return [allPropertiesXml,
         propertyNamesXml].join("");
}
//Sdk.Mdq.MetadataPropertiesExpression.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.MetadataQueryExpression.prototype START
Sdk.Mdq.MetadataQueryExpression.prototype.toValueXml = function () {

 var _xml = ["<j:Criteria>"]
 _xml.push(this.getCriteria().toValueXml());
 _xml.push("</j:Criteria>");
 _xml.push("<j:Properties>");
 _xml.push(this.getProperties().toXml());
 _xml.push("</j:Properties>");

 return _xml.join("");
}
//Sdk.Mdq.MetadataQueryExpression.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.RelationshipMetadataProperties.prototype START

Sdk.Mdq.RelationshipMetadataProperties.prototype = {
 AssociatedMenuConfiguration: "AssociatedMenuConfiguration",
 CascadeConfiguration: "CascadeConfiguration",
 HasChanged: "HasChanged", //new
 Entity1AssociatedMenuConfiguration: "Entity1AssociatedMenuConfiguration",
 Entity1IntersectAttribute: "Entity1IntersectAttribute",
 Entity1LogicalName: "Entity1LogicalName",
 Entity2AssociatedMenuConfiguration: "Entity2AssociatedMenuConfiguration",
 Entity2IntersectAttribute: "Entity2IntersectAttribute",
 Entity2LogicalName: "Entity2LogicalName",
 IntersectEntityName: "IntersectEntityName",
 IntroducedVersion: "IntroducedVersion", //new
 IsCustomizable: "IsCustomizable",
 IsCustomRelationship: "IsCustomRelationship",
 IsManaged: "IsManaged",
 IsValidForAdvancedFind: "IsValidForAdvancedFind",
 MetadataId: "MetadataId",
 ReferencedAttribute: "ReferencedAttribute",
 ReferencedEntity: "ReferencedEntity",
 ReferencingAttribute: "ReferencingAttribute",
 ReferencingEntity: "ReferencingEntity",
 RelationshipType: "RelationshipType",
 SchemaName: "SchemaName",
 SecurityTypes: "SecurityTypes"
};
Sdk.Mdq.RelationshipMetadataProperties.AssociatedMenuConfiguration = "AssociatedMenuConfiguration";
Sdk.Mdq.RelationshipMetadataProperties.CascadeConfiguration = "CascadeConfiguration";
Sdk.Mdq.RelationshipMetadataProperties.HasChanged = "HasChanged";
Sdk.Mdq.RelationshipMetadataProperties.Entity1AssociatedMenuConfiguration = "Entity1AssociatedMenuConfiguration";
Sdk.Mdq.RelationshipMetadataProperties.Entity1IntersectAttribute = "Entity1IntersectAttribute";
Sdk.Mdq.RelationshipMetadataProperties.Entity1LogicalName = "Entity1LogicalName";
Sdk.Mdq.RelationshipMetadataProperties.Entity2AssociatedMenuConfiguration = "Entity2AssociatedMenuConfiguration";
Sdk.Mdq.RelationshipMetadataProperties.Entity2IntersectAttribute = "Entity2IntersectAttribute";
Sdk.Mdq.RelationshipMetadataProperties.Entity2LogicalName = "Entity2LogicalName";
Sdk.Mdq.RelationshipMetadataProperties.IntersectEntityName = "IntersectEntityName";
Sdk.Mdq.RelationshipMetadataProperties.IsCustomizable = "IsCustomizable";
Sdk.Mdq.RelationshipMetadataProperties.IntroducedVersion = "IntroducedVersion";
Sdk.Mdq.RelationshipMetadataProperties.IsCustomRelationship = "IsCustomRelationship";
Sdk.Mdq.RelationshipMetadataProperties.IsManaged = "IsManaged";
Sdk.Mdq.RelationshipMetadataProperties.IsValidForAdvancedFind = "IsValidForAdvancedFind";
Sdk.Mdq.RelationshipMetadataProperties.MetadataId = "MetadataId";
Sdk.Mdq.RelationshipMetadataProperties.ReferencedAttribute = "ReferencedAttribute";
Sdk.Mdq.RelationshipMetadataProperties.ReferencedEntity = "ReferencedEntity";
Sdk.Mdq.RelationshipMetadataProperties.ReferencingAttribute = "ReferencingAttribute";
Sdk.Mdq.RelationshipMetadataProperties.ReferencingEntity = "ReferencingEntity";
Sdk.Mdq.RelationshipMetadataProperties.RelationshipType = "RelationshipType";
Sdk.Mdq.RelationshipMetadataProperties.SchemaName = "SchemaName";
Sdk.Mdq.RelationshipMetadataProperties.SecurityTypes = "SecurityTypes";
Sdk.Mdq.RelationshipMetadataProperties.__enum = true;
Sdk.Mdq.RelationshipMetadataProperties.__flags = true;
//Sdk.Mdq.RelationshipMetadataProperties.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.RelationshipQueryExpression.prototype START

Sdk.Mdq.RelationshipQueryExpression.prototype = new Sdk.Mdq.MetadataQueryExpression();

Sdk.Mdq.RelationshipQueryExpression.prototype.toXml = function () {

 if ((this.getCriteria().getConditions().getCount() == 0) &&
  (this.getProperties().getProperties().getCount() == 0) &&
  (this.getProperties().getAllProperties() == false)) {
  return "<j:RelationshipQuery i:nil=\"true\" />";
 }
 else {
  return ["<j:RelationshipQuery>",
                   this.toValueXml(),
                 "</j:RelationshipQuery>"].join("");
 }
}
//Sdk.Mdq.RelationshipQueryExpression.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.SearchableAttributeMetadataProperties.prototype START

Sdk.Mdq.SearchableAttributeMetadataProperties.prototype = {
 AttributeOf: "AttributeOf",
 AttributeType: "AttributeType",
 //AttributeTypeName: "AttributeTypeName", not searchable
 CalculationOf: "CalculationOf",
 CanBeSecuredForCreate: "CanBeSecuredForCreate",
 CanBeSecuredForRead: "CanBeSecuredForRead",
 CanBeSecuredForUpdate: "CanBeSecuredForUpdate",
 CanModifyAdditionalSettings: "CanModifyAdditionalSettings",
 ColumnNumber: "ColumnNumber",
 DefaultFormValue: "DefaultFormValue",
 DefaultValue: "DefaultValue",
 DeprecatedVersion: "DeprecatedVersion",
 EntityLogicalName: "EntityLogicalName",
 Format: "Format",
 FormatName: "FormatName", //new
 ImeMode: "ImeMode",
 IntroducedVersion: "IntroducedVersion", //new
 IsAuditEnabled: "IsAuditEnabled",
 IsCustomAttribute: "IsCustomAttribute",
 IsCustomizable: "IsCustomizable",
 IsManaged: "IsManaged",
 IsPrimaryId: "IsPrimaryId",
 IsPrimaryName: "IsPrimaryName",
 IsRenameable: "IsRenameable",
 IsSecured: "IsSecured",
 IsValidForAdvancedFind: "IsValidForAdvancedFind",
 IsValidForCreate: "IsValidForCreate",
 IsValidForRead: "IsValidForRead",
 IsValidForUpdate: "IsValidForUpdate",
 LinkedAttributeId: "LinkedAttributeId",
 LogicalName: "LogicalName",
 MaxLength: "MaxLength",
 MaxValue: "MaxValue",
 MetadataId: "MetadataId",
 MinValue: "MinValue",
 Precision: "Precision",
 PrecisionSource: "PrecisionSource",
 RequiredLevel: "RequiredLevel",
 SchemaName: "SchemaName",
 YomiOf: "YomiOf"
};
Sdk.Mdq.SearchableAttributeMetadataProperties.AttributeOf = "AttributeOf";
Sdk.Mdq.SearchableAttributeMetadataProperties.AttributeType = "AttributeType";
//Sdk.Mdq.SearchableAttributeMetadataProperties.AttributeTypeName = "AttributeTypeName"; not searchable
Sdk.Mdq.SearchableAttributeMetadataProperties.CalculationOf = "CalculationOf";
Sdk.Mdq.SearchableAttributeMetadataProperties.CanBeSecuredForCreate = "CanBeSecuredForCreate";
Sdk.Mdq.SearchableAttributeMetadataProperties.CanBeSecuredForRead = "CanBeSecuredForRead";
Sdk.Mdq.SearchableAttributeMetadataProperties.CanBeSecuredForUpdate = "CanBeSecuredForUpdate";
Sdk.Mdq.SearchableAttributeMetadataProperties.CanModifyAdditionalSettings = "CanModifyAdditionalSettings";
Sdk.Mdq.SearchableAttributeMetadataProperties.ColumnNumber = "ColumnNumber";
Sdk.Mdq.SearchableAttributeMetadataProperties.DefaultFormValue = "DefaultFormValue";
Sdk.Mdq.SearchableAttributeMetadataProperties.DefaultValue = "DefaultValue";
Sdk.Mdq.SearchableAttributeMetadataProperties.DeprecatedVersion = "DeprecatedVersion";
Sdk.Mdq.SearchableAttributeMetadataProperties.EntityLogicalName = "EntityLogicalName";
Sdk.Mdq.SearchableAttributeMetadataProperties.Format = "Format";
Sdk.Mdq.SearchableAttributeMetadataProperties.FormatName = "FormatName";
Sdk.Mdq.SearchableAttributeMetadataProperties.ImeMode = "ImeMode";
Sdk.Mdq.SearchableAttributeMetadataProperties.IntroducedVersion = "IntroducedVersion";
Sdk.Mdq.SearchableAttributeMetadataProperties.IsAuditEnabled = "IsAuditEnabled";
Sdk.Mdq.SearchableAttributeMetadataProperties.IsCustomAttribute = "IsCustomAttribute";
Sdk.Mdq.SearchableAttributeMetadataProperties.IsCustomizable = "IsCustomizable";
Sdk.Mdq.SearchableAttributeMetadataProperties.IsManaged = "IsManaged";
Sdk.Mdq.SearchableAttributeMetadataProperties.IsPrimaryId = "IsPrimaryId";
Sdk.Mdq.SearchableAttributeMetadataProperties.IsPrimaryName = "IsPrimaryName";
Sdk.Mdq.SearchableAttributeMetadataProperties.IsRenameable = "IsRenameable";
Sdk.Mdq.SearchableAttributeMetadataProperties.IsSecured = "IsSecured";
Sdk.Mdq.SearchableAttributeMetadataProperties.IsValidForAdvancedFind = "IsValidForAdvancedFind";
Sdk.Mdq.SearchableAttributeMetadataProperties.IsValidForCreate = "IsValidForCreate";
Sdk.Mdq.SearchableAttributeMetadataProperties.IsValidForRead = "IsValidForRead";
Sdk.Mdq.SearchableAttributeMetadataProperties.IsValidForUpdate = "IsValidForUpdate";
Sdk.Mdq.SearchableAttributeMetadataProperties.LinkedAttributeId = "LinkedAttributeId";
Sdk.Mdq.SearchableAttributeMetadataProperties.LogicalName = "LogicalName";
Sdk.Mdq.SearchableAttributeMetadataProperties.MaxLength = "MaxLength";
Sdk.Mdq.SearchableAttributeMetadataProperties.MaxValue = "MaxValue";
Sdk.Mdq.SearchableAttributeMetadataProperties.MetadataId = "MetadataId";
Sdk.Mdq.SearchableAttributeMetadataProperties.MinValue = "MinValue";
Sdk.Mdq.SearchableAttributeMetadataProperties.Precision = "Precision";
Sdk.Mdq.SearchableAttributeMetadataProperties.PrecisionSource = "PrecisionSource";
Sdk.Mdq.SearchableAttributeMetadataProperties.RequiredLevel = "RequiredLevel";
Sdk.Mdq.SearchableAttributeMetadataProperties.SchemaName = "SchemaName";
Sdk.Mdq.SearchableAttributeMetadataProperties.YomiOf = "YomiOf";
Sdk.Mdq.SearchableAttributeMetadataProperties.__enum = true;
Sdk.Mdq.SearchableAttributeMetadataProperties.__flags = true;
//Sdk.Mdq.SearchableAttributeMetadataProperties.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.SearchableEntityMetadataProperties.prototype START

Sdk.Mdq.SearchableEntityMetadataProperties.prototype = {
 ActivityTypeMask: "ActivityTypeMask",
 //Attributes not searchable
 AutoCreateAccessTeams: "AutoCreateAccessTeams", //new
 AutoRouteToOwnerQueue: "AutoRouteToOwnerQueue",
 CanBeInManyToMany: "CanBeInManyToMany",
 CanBePrimaryEntityInRelationship: "CanBePrimaryEntityInRelationship",
 CanBeRelatedEntityInRelationship: "CanBeRelatedEntityInRelationship",
 CanCreateAttributes: "CanCreateAttributes",
 CanCreateCharts: "CanCreateCharts",
 CanCreateForms: "CanCreateForms",
 CanCreateViews: "CanCreateViews",
 CanModifyAdditionalSettings: "CanModifyAdditionalSettings",
 CanTriggerWorkflow: "CanTriggerWorkflow",
 // Description
 // DisplayCollectionName
 // DisplayName
 // HasChanged
 IconLargeName: "IconLargeName",
 IconMediumName: "IconMediumName",
 IconSmallName: "IconSmallName",
 IntroducedVersion: "IntroducedVersion", //new
 IsActivity: "IsActivity",
 IsActivityParty: "IsActivityParty",
 IsAIRUpdated: "IsAIRUpdated", //new
 IsAuditEnabled: "IsAuditEnabled",
 IsAvailableOffline: "IsAvailableOffline",
 IsBusinessProcessEnabled: "IsBusinessProcessEnabled", //new
 IsChildEntity: "IsChildEntity",
 IsConnectionsEnabled: "IsConnectionsEnabled",
 IsCustomEntity: "IsCustomEntity",
 IsCustomizable: "IsCustomizable",
 IsDocumentManagementEnabled: "IsDocumentManagementEnabled",
 IsDuplicateDetectionEnabled: "IsDuplicateDetectionEnabled",
 IsEnabledForCharts: "IsEnabledForCharts",
 IsImportable: "IsImportable",
 IsIntersect: "IsIntersect",
 IsMailMergeEnabled: "IsMailMergeEnabled",
 IsManaged: "IsManaged",
 IsMappable: "IsMappable",
 IsQuickCreateEnabled: "IsQuickCreateEnabled", //new
 IsReadingPaneEnabled: "IsReadingPaneEnabled",
 IsRenameable: "IsRenameable",
 IsValidForAdvancedFind: "IsValidForAdvancedFind",
 IsValidForQueue: "IsValidForQueue",
 IsVisibleInMobile: "IsVisibleInMobile",
 IsVisibleInMobileClient: "IsVisibleInMobileClient", //new
 LogicalName: "LogicalName",
 //ManyToManyRelationships
 //ManyToOneRelationships
 MetadataId: "MetadataId",
 ObjectTypeCode: "ObjectTypeCode",
 //OneToManyRelationships
 OwnershipType: "OwnershipType",
 PrimaryIdAttribute: "PrimaryIdAttribute",
 PrimaryImageAttribute: "PrimaryImageAttribute", //new
 PrimaryNameAttribute: "PrimaryNameAttribute",
 //Privileges
 RecurrenceBaseEntityLogicalName: "RecurrenceBaseEntityLogicalName",
 ReportViewName: "ReportViewName",
 SchemaName: "SchemaName"
};
Sdk.Mdq.SearchableEntityMetadataProperties.ActivityTypeMask = "ActivityTypeMask";
Sdk.Mdq.SearchableEntityMetadataProperties.AutoCreateAccessTeams = "AutoCreateAccessTeams";
Sdk.Mdq.SearchableEntityMetadataProperties.AutoRouteToOwnerQueue = "AutoRouteToOwnerQueue";
Sdk.Mdq.SearchableEntityMetadataProperties.CanBeInManyToMany = "CanBeInManyToMany";
Sdk.Mdq.SearchableEntityMetadataProperties.CanBePrimaryEntityInRelationship = "CanBePrimaryEntityInRelationship";
Sdk.Mdq.SearchableEntityMetadataProperties.CanBeRelatedEntityInRelationship = "CanBeRelatedEntityInRelationship";
Sdk.Mdq.SearchableEntityMetadataProperties.CanCreateAttributes = "CanCreateAttributes";
Sdk.Mdq.SearchableEntityMetadataProperties.CanCreateCharts = "CanCreateCharts";
Sdk.Mdq.SearchableEntityMetadataProperties.CanCreateForms = "CanCreateForms";
Sdk.Mdq.SearchableEntityMetadataProperties.CanCreateViews = "CanCreateViews";
Sdk.Mdq.SearchableEntityMetadataProperties.CanModifyAdditionalSettings = "CanModifyAdditionalSettings";
Sdk.Mdq.SearchableEntityMetadataProperties.CanTriggerWorkflow = "CanTriggerWorkflow";
Sdk.Mdq.SearchableEntityMetadataProperties.IconLargeName = "IconLargeName";
Sdk.Mdq.SearchableEntityMetadataProperties.IconMediumName = "IconMediumName";
Sdk.Mdq.SearchableEntityMetadataProperties.IconSmallName = "IconSmallName";
Sdk.Mdq.SearchableEntityMetadataProperties.IntroducedVersion = "IntroducedVersion";
Sdk.Mdq.SearchableEntityMetadataProperties.IsActivity = "IsActivity";
Sdk.Mdq.SearchableEntityMetadataProperties.IsActivityParty = "IsActivityParty";
Sdk.Mdq.SearchableEntityMetadataProperties.IsAIRUpdated = "IsAIRUpdated";
Sdk.Mdq.SearchableEntityMetadataProperties.IsAuditEnabled = "IsAuditEnabled";
Sdk.Mdq.SearchableEntityMetadataProperties.IsAvailableOffline = "IsAvailableOffline";
Sdk.Mdq.SearchableEntityMetadataProperties.IsBusinessProcessEnabled = "IsBusinessProcessEnabled";
Sdk.Mdq.SearchableEntityMetadataProperties.IsChildEntity = "IsChildEntity";
Sdk.Mdq.SearchableEntityMetadataProperties.IsConnectionsEnabled = "IsConnectionsEnabled";
Sdk.Mdq.SearchableEntityMetadataProperties.IsCustomEntity = "IsCustomEntity";
Sdk.Mdq.SearchableEntityMetadataProperties.IsCustomizable = "IsCustomizable";
Sdk.Mdq.SearchableEntityMetadataProperties.IsDocumentManagementEnabled = "IsDocumentManagementEnabled";
Sdk.Mdq.SearchableEntityMetadataProperties.IsDuplicateDetectionEnabled = "IsDuplicateDetectionEnabled";
Sdk.Mdq.SearchableEntityMetadataProperties.IsEnabledForCharts = "IsEnabledForCharts";
Sdk.Mdq.SearchableEntityMetadataProperties.IsImportable = "IsImportable";
Sdk.Mdq.SearchableEntityMetadataProperties.IsIntersect = "IsIntersect";
Sdk.Mdq.SearchableEntityMetadataProperties.IsMailMergeEnabled = "IsMailMergeEnabled";
Sdk.Mdq.SearchableEntityMetadataProperties.IsManaged = "IsManaged";
Sdk.Mdq.SearchableEntityMetadataProperties.IsMappable = "IsMappable";
Sdk.Mdq.SearchableEntityMetadataProperties.IsQuickCreateEnabled = "IsQuickCreateEnabled";
Sdk.Mdq.SearchableEntityMetadataProperties.IsReadingPaneEnabled = "IsReadingPaneEnabled";
Sdk.Mdq.SearchableEntityMetadataProperties.IsRenameable = "IsRenameable";
Sdk.Mdq.SearchableEntityMetadataProperties.IsValidForAdvancedFind = "IsValidForAdvancedFind";
Sdk.Mdq.SearchableEntityMetadataProperties.IsValidForQueue = "IsValidForQueue";
Sdk.Mdq.SearchableEntityMetadataProperties.IsVisibleInMobile = "IsVisibleInMobile";
Sdk.Mdq.SearchableEntityMetadataProperties.IsVisibleInMobileClient = "IsVisibleInMobileClient";
Sdk.Mdq.SearchableEntityMetadataProperties.LogicalName = "LogicalName";
Sdk.Mdq.SearchableEntityMetadataProperties.MetadataId = "MetadataId";
Sdk.Mdq.SearchableEntityMetadataProperties.ObjectTypeCode = "ObjectTypeCode";
Sdk.Mdq.SearchableEntityMetadataProperties.OwnershipType = "OwnershipType";
Sdk.Mdq.SearchableEntityMetadataProperties.PrimaryIdAttribute = "PrimaryIdAttribute";
Sdk.Mdq.SearchableEntityMetadataProperties.PrimaryImageAttribute = "PrimaryImageAttribute";
Sdk.Mdq.SearchableEntityMetadataProperties.PrimaryNameAttribute = "PrimaryNameAttribute";
Sdk.Mdq.SearchableEntityMetadataProperties.RecurrenceBaseEntityLogicalName = "RecurrenceBaseEntityLogicalName";
Sdk.Mdq.SearchableEntityMetadataProperties.ReportViewName = "ReportViewName";
Sdk.Mdq.SearchableEntityMetadataProperties.SchemaName = "SchemaName";
Sdk.Mdq.SearchableEntityMetadataProperties.__enum = true;
Sdk.Mdq.SearchableEntityMetadataProperties.__flags = true;

//Sdk.Mdq.SearchableEntityMetadataProperties.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.SearchableRelationshipMetadataProperties.prototype START

Sdk.Mdq.SearchableRelationshipMetadataProperties.prototype = {
 Entity1IntersectAttribute: "Entity1IntersectAttribute",
 Entity1LogicalName: "Entity1LogicalName",
 Entity2IntersectAttribute: "Entity2IntersectAttribute",
 Entity2LogicalName: "Entity2LogicalName",
 IntersectEntityName: "IntersectEntityName",
 IntroducedVersion: "IntroducedVersion", //new
 IsCustomizable: "IsCustomizable",
 IsCustomRelationship: "IsCustomRelationship",
 IsManaged: "IsManaged",
 IsValidForAdvancedFind: "IsValidForAdvancedFind",
 MetadataId: "MetadataId",
 ReferencedAttribute: "ReferencedAttribute",
 ReferencedEntity: "ReferencedEntity",
 ReferencingAttribute: "ReferencingAttribute",
 ReferencingEntity: "ReferencingEntity",
 RelationshipType: "RelationshipType",
 SchemaName: "SchemaName",
 SecurityTypes: "SecurityTypes"
};
Sdk.Mdq.SearchableRelationshipMetadataProperties.HasChanged = "HasChanged";
Sdk.Mdq.SearchableRelationshipMetadataProperties.Entity1IntersectAttribute = "Entity1IntersectAttribute";
Sdk.Mdq.SearchableRelationshipMetadataProperties.Entity1LogicalName = "Entity1LogicalName";
Sdk.Mdq.SearchableRelationshipMetadataProperties.Entity2IntersectAttribute = "Entity2IntersectAttribute";
Sdk.Mdq.SearchableRelationshipMetadataProperties.Entity2LogicalName = "Entity2LogicalName";
Sdk.Mdq.SearchableRelationshipMetadataProperties.IntersectEntityName = "IntersectEntityName";
Sdk.Mdq.SearchableRelationshipMetadataProperties.IsCustomizable = "IsCustomizable";
Sdk.Mdq.SearchableRelationshipMetadataProperties.IntroducedVersion = "IntroducedVersion";
Sdk.Mdq.SearchableRelationshipMetadataProperties.IsCustomRelationship = "IsCustomRelationship";
Sdk.Mdq.SearchableRelationshipMetadataProperties.IsManaged = "IsManaged";
Sdk.Mdq.SearchableRelationshipMetadataProperties.IsValidForAdvancedFind = "IsValidForAdvancedFind";
Sdk.Mdq.SearchableRelationshipMetadataProperties.MetadataId = "MetadataId";
Sdk.Mdq.SearchableRelationshipMetadataProperties.ReferencedAttribute = "ReferencedAttribute";
Sdk.Mdq.SearchableRelationshipMetadataProperties.ReferencedEntity = "ReferencedEntity";
Sdk.Mdq.SearchableRelationshipMetadataProperties.ReferencingAttribute = "ReferencingAttribute";
Sdk.Mdq.SearchableRelationshipMetadataProperties.ReferencingEntity = "ReferencingEntity";
Sdk.Mdq.SearchableRelationshipMetadataProperties.RelationshipType = "RelationshipType";
Sdk.Mdq.SearchableRelationshipMetadataProperties.SchemaName = "SchemaName";
Sdk.Mdq.SearchableRelationshipMetadataProperties.SecurityTypes = "SecurityTypes";
Sdk.Mdq.SearchableRelationshipMetadataProperties.__enum = true;
Sdk.Mdq.SearchableRelationshipMetadataProperties.__flags = true;
//Sdk.Mdq.SearchableRelationshipMetadataProperties.prototype END
//--------------------------------------------------------------------
//Sdk.Mdq.ValueEnums.prototype START

//	Sdk.Mdq.ValueEnums.OwnershipType
Sdk.Mdq.ValueEnums.OwnershipType.prototype = {
 None: "None",
 OrganizationOwned: "OrganizationOwned",
 TeamOwned: "TeamOwned",
 UserOwned: "UserOwned"
};
Sdk.Mdq.ValueEnums.OwnershipType.None = "None";
Sdk.Mdq.ValueEnums.OwnershipType.OrganizationOwned = "OrganizationOwned";
Sdk.Mdq.ValueEnums.OwnershipType.TeamOwned = "TeamOwned";
Sdk.Mdq.ValueEnums.OwnershipType.UserOwned = "UserOwned";
Sdk.Mdq.ValueEnums.OwnershipType.__enum = true;
Sdk.Mdq.ValueEnums.OwnershipType.__flags = true;

//	Sdk.Mdq.ValueEnums.AttributeTypeCode
Sdk.Mdq.ValueEnums.AttributeTypeCode.prototype = {
 BigInt: "BigInt",
 Boolean: "Boolean",
 CalendarRules: "CalendarRules",
 Customer: "Customer",
 DateTime: "DateTime",
 Decimal: "Decimal",
 Double: "Double",
 EntityName: "EntityName",
 Integer: "Integer",
 Lookup: "Lookup",
 ManagedProperty: "ManagedProperty",
 Memo: "Memo",
 Money: "Money",
 Owner: "Owner",
 PartyList: "PartyList",
 Picklist: "Picklist",
 State: "State",
 Status: "Status",
 String: "String",
 Uniqueidentifier: "Uniqueidentifier",
 Virtual: "Virtual"
};
Sdk.Mdq.ValueEnums.AttributeTypeCode.BigInt = "BigInt";
Sdk.Mdq.ValueEnums.AttributeTypeCode.Boolean = "Boolean";
Sdk.Mdq.ValueEnums.AttributeTypeCode.CalendarRules = "CalendarRules";
Sdk.Mdq.ValueEnums.AttributeTypeCode.Customer = "Customer";
Sdk.Mdq.ValueEnums.AttributeTypeCode.DateTime = "DateTime";
Sdk.Mdq.ValueEnums.AttributeTypeCode.Decimal = "Decimal";
Sdk.Mdq.ValueEnums.AttributeTypeCode.Double = "Double";
Sdk.Mdq.ValueEnums.AttributeTypeCode.EntityName = "EntityName";
Sdk.Mdq.ValueEnums.AttributeTypeCode.Integer = "Integer";
Sdk.Mdq.ValueEnums.AttributeTypeCode.Lookup = "Lookup";
Sdk.Mdq.ValueEnums.AttributeTypeCode.ManagedProperty = "ManagedProperty";
Sdk.Mdq.ValueEnums.AttributeTypeCode.Memo = "Memo";
Sdk.Mdq.ValueEnums.AttributeTypeCode.Money = "Money";
Sdk.Mdq.ValueEnums.AttributeTypeCode.Owner = "Owner";
Sdk.Mdq.ValueEnums.AttributeTypeCode.PartyList = "PartyList";
Sdk.Mdq.ValueEnums.AttributeTypeCode.Picklist = "Picklist";
Sdk.Mdq.ValueEnums.AttributeTypeCode.State = "State";
Sdk.Mdq.ValueEnums.AttributeTypeCode.Status = "Status";
Sdk.Mdq.ValueEnums.AttributeTypeCode.String = "String";
Sdk.Mdq.ValueEnums.AttributeTypeCode.Uniqueidentifier = "Uniqueidentifier";
Sdk.Mdq.ValueEnums.AttributeTypeCode.Virtual = "Virtual";
Sdk.Mdq.ValueEnums.AttributeTypeCode.__enum = true;
Sdk.Mdq.ValueEnums.AttributeTypeCode.__flags = true;

//Sdk.Mdq.ValueEnums.AttributeRequiredLevel
Sdk.Mdq.ValueEnums.AttributeRequiredLevel.prototype = {
 ApplicationRequired: "ApplicationRequired",
 None: "None",
 Recommended: "Recommended",
 SystemRequired: "SystemRequired"
};
Sdk.Mdq.ValueEnums.AttributeRequiredLevel.ApplicationRequired = "ApplicationRequired";
Sdk.Mdq.ValueEnums.AttributeRequiredLevel.None = "None";
Sdk.Mdq.ValueEnums.AttributeRequiredLevel.Recommended = "Recommended";
Sdk.Mdq.ValueEnums.AttributeRequiredLevel.SystemRequired = "SystemRequired";
Sdk.Mdq.ValueEnums.AttributeRequiredLevel.__enum = true;
Sdk.Mdq.ValueEnums.AttributeRequiredLevel.__flags = true;

//Sdk.Mdq.ValueEnums.DateTimeFormat
Sdk.Mdq.ValueEnums.DateTimeFormat.prototype = {
 DateAndTime: "DateAndTime",
 DateOnly: "DateOnly"
};
Sdk.Mdq.ValueEnums.DateTimeFormat.DateAndTime = "DateAndTime";
Sdk.Mdq.ValueEnums.DateTimeFormat.DateOnly = "DateOnly";
Sdk.Mdq.ValueEnums.DateTimeFormat.__enum = true;
Sdk.Mdq.ValueEnums.DateTimeFormat.__flags = true;

//Sdk.Mdq.ValueEnums.ImeMode
Sdk.Mdq.ValueEnums.ImeMode.prototype = {
 Active: "Active",
 Auto: "Auto",
 Disabled: "Disabled",
 Inactive: "Inactive"
};
Sdk.Mdq.ValueEnums.ImeMode.Active = "Active";
Sdk.Mdq.ValueEnums.ImeMode.Auto = "Auto";
Sdk.Mdq.ValueEnums.ImeMode.Disabled = "Disabled";
Sdk.Mdq.ValueEnums.ImeMode.Inactive = "Inactive";
Sdk.Mdq.ValueEnums.ImeMode.__enum = true;
Sdk.Mdq.ValueEnums.ImeMode.__flags = true;


//Sdk.Mdq.ValueEnums.IntegerFormat
Sdk.Mdq.ValueEnums.IntegerFormat.prototype = {
 Duration: "Duration",
 Language: "Language",
 Locale: "Locale",
 None: "None",
 TimeZone: "TimeZone"
};
Sdk.Mdq.ValueEnums.IntegerFormat.Duration = "Duration";
Sdk.Mdq.ValueEnums.IntegerFormat.Language = "Language";
Sdk.Mdq.ValueEnums.IntegerFormat.Locale = "Locale";
Sdk.Mdq.ValueEnums.IntegerFormat.None = "None";
Sdk.Mdq.ValueEnums.IntegerFormat.TimeZone = "TimeZone";
Sdk.Mdq.ValueEnums.IntegerFormat.__enum = true;
Sdk.Mdq.ValueEnums.IntegerFormat.__flags = true;


//Sdk.Mdq.ValueEnums.SecurityTypes
Sdk.Mdq.ValueEnums.SecurityTypes.prototype = {
 Append: "Append",
 Inheritance: "Inheritance",
 None: "None",
 ParentChild: "ParentChild",
 Pointer: "Pointer"
};
Sdk.Mdq.ValueEnums.SecurityTypes.Append = "Append";
Sdk.Mdq.ValueEnums.SecurityTypes.Inheritance = "Inheritance";
Sdk.Mdq.ValueEnums.SecurityTypes.None = "None";
Sdk.Mdq.ValueEnums.SecurityTypes.ParentChild = "ParentChild";
Sdk.Mdq.ValueEnums.SecurityTypes.Pointer = "Pointer";
Sdk.Mdq.ValueEnums.SecurityTypes.__enum = true;
Sdk.Mdq.ValueEnums.SecurityTypes.__flags = true;

//Sdk.Mdq.ValueEnums.StringFormat
Sdk.Mdq.ValueEnums.StringFormat.prototype = {
 Email: "Email",
 PhoneticGuide: "PhoneticGuide",
 Text: "Text",
 TextArea: "TextArea",
 TickerSymbol: "TickerSymbol",
 Url: "Url",
 VersionNumber: "VersionNumber"
};
Sdk.Mdq.ValueEnums.StringFormat.Email = "Email";
Sdk.Mdq.ValueEnums.StringFormat.PhoneticGuide = "PhoneticGuide";
Sdk.Mdq.ValueEnums.StringFormat.Text = "Text";
Sdk.Mdq.ValueEnums.StringFormat.TextArea = "TextArea";
Sdk.Mdq.ValueEnums.StringFormat.TickerSymbol = "TickerSymbol";
Sdk.Mdq.ValueEnums.StringFormat.Url = "Url";
Sdk.Mdq.ValueEnums.StringFormat.VersionNumber = "VersionNumber";
Sdk.Mdq.ValueEnums.StringFormat.__enum = true;
Sdk.Mdq.ValueEnums.StringFormat.__flags = true;
//Sdk.Mdq.ValueEnums.prototype END

// End Library
