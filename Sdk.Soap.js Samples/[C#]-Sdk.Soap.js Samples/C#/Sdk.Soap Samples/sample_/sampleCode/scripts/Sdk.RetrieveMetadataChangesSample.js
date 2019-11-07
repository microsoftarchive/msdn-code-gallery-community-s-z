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
/// <reference path="../../vsdoc/Sdk.Soap.vsdoc.js" />
/// <reference path="../../vsdoc/messages/Sdk.RetrieveMetadataChanges.vsdoc.js" />

function demoRetrieveMetadataChangesRequestSample() {
 //Clear results from any previous run of the sample
  document.getElementById("messages").innerHTML = "";


 //Set aliases for less typing
 var mdq = Sdk.Mdq;
 var semp = Sdk.Mdq.SearchableEntityMetadataProperties;
 var samp = Sdk.Mdq.SearchableAttributeMetadataProperties;
 var srmp = Sdk.Mdq.SearchableRelationshipMetadataProperties
 var emp = Sdk.Mdq.EntityMetadataProperties;
 var amp = Sdk.Mdq.AttributeMetadataProperties;
 var rmp = Sdk.Mdq.RelationshipMetadataProperties;
 var ve = Sdk.Mdq.ValueEnums;

 //Set entity filter to return only the account entity
 var entityFilter = new mdq.MetadataFilterExpression(mdq.LogicalOperator.And);
 entityFilter.addCondition(semp.SchemaName, mdq.MetadataConditionOperator.Equals, "Account");

 //Set entity properties to only return attributes and the primaryIdAttribute
 var entityProperties = new mdq.MetadataPropertiesExpression(false, [emp.Attributes, emp.PrimaryIdAttribute]);

 //Set attribute filter to not include virtual attributes
 var attributeFilter = new mdq.MetadataFilterExpression(mdq.LogicalOperator.And);
 attributeFilter.addCondition(samp.AttributeType, mdq.MetadataConditionOperator.NotEquals, ve.AttributeTypeCode.Virtual);
 //Set attribute properties to only include the attribute type and schema name
 var attributeProperties = new mdq.MetadataPropertiesExpression(false, [amp.AttributeType, amp.SchemaName]);

 //Instantiate entity query
 var query = new mdq.EntityQueryExpression(
  entityFilter,
  entityProperties,
  new mdq.AttributeQueryExpression(attributeFilter, attributeProperties));

 //Execute the request
 Sdk.Async.execute(new Sdk.RetrieveMetadataChangesRequest(query),
  function (response) {
   //Get the entity collection
   var entities = response.getEntityMetadata();
   //get the attributes for the account entity
   var attributes = entities[0].Attributes;
   //sort the attributes
   attributes.sort(function (a, b) {
    if (a.SchemaName < b.SchemaName)
     return -1;
    if (a.SchemaName > b.SchemaName)
     return 1;
    return 0;
   })
   //Display the attributes
   for (var i = 0; i < attributes.length; i++) {
    var attribute = attributes[i];
    writeToPage(attribute.SchemaName + " : " + attribute.AttributeType);
   }

  },
  function (error) {
   alert(error.message);
  });

}

function writeToPage(message) {
 var messagesList = document.getElementById("messages");
 if (typeof message == "string") {
  var listItem = document.createElement("li");
  listItem.appendChild(document.createTextNode(message));
  messagesList.appendChild(listItem);
  return;
 }
 if (typeof message == "object" &&
  message != null &&
  message.nodeType == 1 &&
  typeof message.nodeName == "string") {
  messagesList.appendChild(message);
  return;
 }
 throw new Error("message parameter to writeToPage is not a string or DOM element");

}