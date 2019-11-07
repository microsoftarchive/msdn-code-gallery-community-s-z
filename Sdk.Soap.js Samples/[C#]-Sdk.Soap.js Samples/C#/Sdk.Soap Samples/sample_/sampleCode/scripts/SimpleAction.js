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
/// <reference path="../../vsdoc/actions/Sdk.sample_SimpleAction.vsdoc.js" />
function simpleActionSample() {

 var request = new Sdk.sample_SimpleActionRequest("Test String");
 Sdk.Async.execute(request,
  function (response) {
   var stringOut = response.getStringOut();
   writeToPage("Action sample_SimpleAction Output: '" + stringOut + "'");
  },
  function (error) {
   writeToPage(error.message);
  });
}
/*
Because of a bug that doesn't currently allow for including the Action within the solution,
You must manually create an action in your organization to match the one that the 
Sdk.sample_SimpleAction.min.js library was generated from...
The verifyValidSimpleActionMessage executes a query to verify that an action exists
and that it matches the signature of the Action.

It also provides an example of a complex Sdk.Query.QueryExpression.
*/
function verifyValidSimpleActionMessage() {
 writeToPage("Verifying that a valid, active Action named 'sample_SimpleAction' exists");
 var simpleActionQuery = new Sdk.Query.QueryExpression("sdkmessage");
 simpleActionQuery.setColumnSet("isactive", "template");

 var simpleActionQueryCriteria = new Sdk.Query.FilterExpression(Sdk.Query.LogicalOperator.And);
 simpleActionQueryCriteria.addCondition("sdkmessage",
  "name",
  Sdk.Query.ConditionOperator.Equal,
  new Sdk.Query.Strings(["sample_SimpleAction"]));
 simpleActionQuery.setCriteria(simpleActionQueryCriteria);

 var sdkMessagePairLink = new Sdk.Query.LinkEntity("sdkmessage",
  "sdkmessagepair",
  "sdkmessageid",
  "sdkmessageid",
  Sdk.Query.JoinOperator.Inner,
  "smp");

 var sdkMessageRequestLink = new Sdk.Query.LinkEntity("sdkmessage",
  "sdkmessagerequest",
  "sdkmessagepairid",
  "sdkmessagepairid",
  Sdk.Query.JoinOperator.Inner,
  "smreq");

 var sdkmessagerequestfieldLink = new Sdk.Query.LinkEntity("sdkmessage",
  "sdkmessagerequestfield",
  "sdkmessagerequestid",
  "sdkmessagerequestid",
  Sdk.Query.JoinOperator.Inner, "smreqfld");
 sdkmessagerequestfieldLink.setColumns("clrparser", "parser", "position", "optional");


 var sdkmessagerequestfieldLinkCriteria = new Sdk.Query.FilterExpression(Sdk.Query.LogicalOperator.And);
 sdkmessagerequestfieldLinkCriteria.addCondition("sdkmessagerequestfield",
  "name",
  Sdk.Query.ConditionOperator.Equal,
  new Sdk.Query.Strings(["StringIn"]));

 sdkmessagerequestfieldLink.setLinkCriteria(sdkmessagerequestfieldLinkCriteria);

 var sdkmessageresponseLink = new Sdk.Query.LinkEntity("sdkmessage",
  "sdkmessageresponse",
  "sdkmessagerequestid",
  "sdkmessagerequestid",
  Sdk.Query.JoinOperator.Inner,
  "smresp");

 var sdkmessageresponsefieldLink = new Sdk.Query.LinkEntity("sdkmessage",
  "sdkmessageresponsefield",
  "sdkmessageresponseid",
  "sdkmessageresponseid",
  Sdk.Query.JoinOperator.Inner,
  "smrespfld");

 sdkmessageresponsefieldLink.setColumns("position", "clrformatter", "formatter");


 var sdkmessageresponsefieldLinkCriteria = new Sdk.Query.FilterExpression(Sdk.Query.LogicalOperator.And);
 sdkmessageresponsefieldLinkCriteria.addCondition("sdkmessageresponsefield",
  "name",
  Sdk.Query.ConditionOperator.Equal,
 new Sdk.Query.Strings(["StringOut"]));

 sdkmessageresponsefieldLink.setLinkCriteria(sdkmessageresponsefieldLinkCriteria);

 sdkmessageresponseLink.addLink(sdkmessageresponsefieldLink);
 sdkMessageRequestLink.addLink(sdkmessagerequestfieldLink);
 sdkMessageRequestLink.addLink(sdkmessageresponseLink)
 sdkMessagePairLink.addLink(sdkMessageRequestLink);
 simpleActionQuery.addLink(sdkMessagePairLink)

 

 Sdk.Async.retrieveMultiple(simpleActionQuery,
  function (ec) {
   var entitiesReturned = ec.getEntities();
   if (entitiesReturned.getCount() >= 1)
   {
    var firstEntity = entitiesReturned.getByIndex(0);
    writeToPage("Action named 'sample_SimpleAction' found");
  

    //Validate that the Action is configured as expected
    var isActive = firstEntity.getValue("isactive");
    var requestFieldClrParser = firstEntity.getValue("smreqfld.clrparser");
    var requestFieldParser = firstEntity.getValue("smreqfld.parser");
    var requestFieldOptional = firstEntity.getValue("smreqfld.optional");
    var requestFieldPosition = firstEntity.getValue("smreqfld.position");
    var responseFieldClrFormatter = firstEntity.getValue("smrespfld.clrformatter");
    var responseFieldFormatter = firstEntity.getValue("smrespfld.formatter");
    var responseFieldPosition = firstEntity.getValue("smrespfld.position");
    
    if (!requestFieldClrParser.substring(0, "System.String".length) == "System.String" ||
     !requestFieldParser.substring(0, "System.String".length) == "System.String")
    {
     writeToPage("The 'StringIn' Input parameter must be a string.");
     return;
    }
    if (requestFieldOptional)
    {
     writeToPage("The 'StringIn' Input parameter must be required.");
     return;
    }
    if (requestFieldPosition != 0)
    {
     writeToPage("The 'StringIn' Input parameter must be the first and only input parameter.");
     return;
    }

    if (!responseFieldClrFormatter.substring(0, "System.String".length) == "System.String" ||
     !responseFieldFormatter.substring(0, "System.String".length) == "System.String") {
     writeToPage("The 'StringOut' Output parameter must be a string.");
     return;
    }

    if (responseFieldPosition != 0) {
     writeToPage("The 'StringOut' Output parameter must be the first and only output parameter.");
     return;
    }
    writeToPage("'sample_SimpleAction' validated");
    //Finally run the action
    simpleActionSample();

   }
   else
   {
    writeToPage("No valid Action named 'sample_SimpleAction' found");
   }
  },
  function (error) {
   writeToPage(error.message);
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
