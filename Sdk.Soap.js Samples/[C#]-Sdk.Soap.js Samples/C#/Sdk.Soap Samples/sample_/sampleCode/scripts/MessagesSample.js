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
/// <reference path="../../vsdoc/jquery_1.9.1_vsdoc.js" />
/// <reference path="../../vsdoc/messages/Sdk.AddToQueue.vsdoc.js" />
/// <reference path="../../vsdoc/messages/Sdk.WhoAmI.vsdoc.js" />



var userId = null;
var sourceQueueId = null;
var destinationQueueId = null;
var letterId = null;
var queueItemId = null;
var salesManagerUserId = null;

function startAddToQueueMessageSample() {

 Sdk.jQ.setJQueryVariable($);

 Sdk.jQ.execute(new Sdk.WhoAmIRequest())
  .then(
  function (whoAmIResponse) {
   userId = whoAmIResponse.getUserId();

   //------------------------------

   //get active, licenced user with Sales Manager role
   var systemUserRolesQuery = new Sdk.Query.QueryExpression("systemuserroles");
   systemUserRolesQuery.addColumn("systemuserid")

   var linkToRoles = new Sdk.Query.LinkEntity("systemuserroles", "role", "roleid", "roleid", Sdk.Query.JoinOperator.Inner, "sur");
   linkToRoles.setColumns("name", "roleid");

   var salesManagerFilter = new Sdk.Query.FilterExpression(Sdk.Query.LogicalOperator.And);
   salesManagerFilter.addCondition("role", "name", Sdk.Query.ConditionOperator.Equal, new Sdk.Query.Strings(["Sales Manager"]));
   linkToRoles.setLinkCriteria(salesManagerFilter);

   var linkToSystemUser = new Sdk.Query.LinkEntity("systemuserroles", "systemuser", "systemuserid", "systemuserid", Sdk.Query.JoinOperator.Inner, "su");
   linkToSystemUser.setColumns("fullname");

   var userFilter = new Sdk.Query.FilterExpression(Sdk.Query.LogicalOperator.And);
   userFilter.addCondition("systemuser", "isdisabled", Sdk.Query.ConditionOperator.Equal, new Sdk.Query.Booleans([false]));
   userFilter.addCondition("systemuser", "islicensed", Sdk.Query.ConditionOperator.Equal, new Sdk.Query.Booleans([false]));

   systemUserRolesQuery.addLink(linkToRoles);
   systemUserRolesQuery.addLink(linkToSystemUser);
   return Sdk.jQ.retrieveMultiple(systemUserRolesQuery);//It is important to return this after the first call
  },
  new ErrorHandler("WhoAmIRequest: ").getError
  )
  .done(
    function (ec) {
     if (ec.getEntities().getCount() >= 1) {
      var salesManagerUser = ec.getEntities().getByIndex(0);
      salesManagerUserId = salesManagerUser.getValue("systemuserid");
      writeToPage("Retrieved sales manager: " + salesManagerUser.getValue("su.fullname"));
      createRequiredRecords();
     }
     else {
      writeToPage("This sample requires that at least one licenced, active user has the 'Sales Manager' security role");
     }
    }
  ).fail(new ErrorHandler("Retrieving Sales Manager: ").getError)
}

function createRequiredRecords() {
 var sourceQueue = new Sdk.Entity("queue");
 sourceQueue.addAttribute(new Sdk.String("name", "Example Queue 1"));
 sourceQueue.addAttribute(new Sdk.String("description", "This is the source queue."));
 Sdk.jQ.create(sourceQueue)
 .then(
    function (id) {
     sourceQueueId = id;
     writeToPage("Source Queue created");
     ///----------------
     var destinationQueue = new Sdk.Entity("queue");
     destinationQueue.addAttribute(new Sdk.String("name", "Example Queue 2"));
     destinationQueue.addAttribute(new Sdk.String("description", "This is the destination queue."));
     return Sdk.jQ.create(destinationQueue);

    },
  new ErrorHandler("Create Source Queue: ").getError
 )
  .then(
   function (id) {
    destinationQueueId = id;
    writeToPage("Destination Queue created");
    //---
    var letter = new Sdk.Entity("letter");
    letter.addAttribute(new Sdk.String("subject", "Example Letter for sample"));
    letter.addAttribute(new Sdk.String("description", "Example Letter description for sample"));
    return Sdk.jQ.create(letter);
   },
    function (error) {
     writeToPage("Create Destination Queue Error: " + error.message);
     deleteRequiredRecords();
    }
  )
  .then(
  function (id) {
   letterId = id;
   writeToPage("Letter created");
   ///---------
   // add letter to source queue

   var queueItem = new Sdk.Entity("queueitem");
   queueItem.addAttribute(new Sdk.Lookup("workerid", new Sdk.EntityReference("systemuser", userId)));
   queueItem.addAttribute(new Sdk.Lookup("queueid", new Sdk.EntityReference("queue", sourceQueueId)));
   queueItem.addAttribute(new Sdk.Lookup("objectid", new Sdk.EntityReference("letter", letterId)));

   return Sdk.jQ.create(queueItem);

  },
   function (error) {
    writeToPage("Create Letter Error: " + error.message);
    deleteRequiredRecords();
   }
  )
 .done(
 function (id) {
  queueItemId = id;
  writeToPage("Example letter added to source queue");
  addToQueueSample() //proceed with the sample.
 }

 ).fail(
    function (error) {
     writeToPage("Add Letter to Source Queue Error: " + error.message);
     deleteRequiredRecords();
    }
 )
}

function addToQueueSample() {
 var queueItemProperties = new Sdk.Entity("queueitem");
 queueItemProperties.addAttribute(new Sdk.Lookup("workerid", new Sdk.EntityReference("systemuser", salesManagerUserId)));

 var routeRequest = new Sdk.AddToQueueRequest(
  new Sdk.EntityReference("letter", letterId),
  sourceQueueId,
  destinationQueueId,
  queueItemProperties
  );

 Sdk.jQ.execute(routeRequest)
 .done(
 function () {
  writeToPage("The letter has been moved to a new queue");
  deleteRequiredRecords();
 }
 ).fail(function (error) {
  writeToPage("Route Request Error: " + error.message);
  deleteRequiredRecords();
 });
}

function deleteRequiredRecords() {

 writeToPage("Deleting any records created by this sample:");
 //Make sure the queueItem is deleted first

 if (queueItemId != null) {
  Sdk.jQ.del("queueitem", queueItemId).done(
   function () {
    writeToPage("QueueItem deleted");
    deleteLetter();
    deleteSourceQueue();
    deleteDestinationQueue();
   }
   ).fail(new ErrorHandler("Deleting QueueItem: ").getError)
 }
 else {
  deleteLetter();
  deleteSourceQueue();
  deleteDestinationQueue();
 }
}

function deleteLetter() {
 if (letterId != null) {
  Sdk.Async.del("letter",
   letterId,
   function () {
    letterId = null;
    writeToPage("Letter deleted");
   },
   function (error) {
    writeToPage("Error deleteing Letter: " + error.message);
   }
   );
 }
}

function deleteDestinationQueue() {
 if (destinationQueueId != null) {
  //Adding a timeout seems to stop the generic SQL Errors that occasionally occurred
  // only when deleteing queues.
  setTimeout(function () {
   Sdk.Async.del("queue",
 destinationQueueId,
 function () {
  destinationQueueId = null;
  writeToPage("Destination Queue deleted");
 },
 function (error) {
  writeToPage("Error deleteing Destination Queue: " + error.message);
 }
 );
  }, 500);
 }
}

function deleteSourceQueue() {
 if (sourceQueueId != null) {
  //Adding a timeout seems to stop the generic SQL Errors that occasionally occurred
  // only when deleteing queues.
  setTimeout(function () {
   Sdk.Async.del("queue",
 sourceQueueId,
 function () {
  sourceQueueId = null;
  writeToPage("Source Queue deleted");
  writeToPage("Sample completed.");
 },
 function (error) {
  writeToPage("Error deleteing Source queue: " + error.message);
 }
 );
  }, 1000);
 }
}




function initEntity(entity, columns) {
 for (var i in columns) {
  entity.addAttribute(new columns[i](i));
 }
 return entity;
}

function getColumnSet(entityColumns) {
 var attributeNames = [];
 for (var i in entityColumns) {
  attributeNames.push(i);
 }
 //Sdk.ColumnSet accepts an array of strings as the parameter.
 return new Sdk.ColumnSet(attributeNames);
}

function ErrorHandler(errorContext) {
 var _ec = errorContext;
 this.getError = function (error) {
  writeToPage(_ec + error);
  //This is different from the other error handlers
  //need to return a promise to stop the chain
  return $.Deferred().promise();
 };
}


function writeToPage(message) {
 var messagesList = $("#messages");
 if (typeof message == "string") {
  messagesList.append(["<li>", message, "</li>"].join(""));
  return;
 }
 if (message instanceof jQuery) {
  messagesList.append(message);
  return;
 }
 throw new Error("message parameter to writeToPage is not a string or jQuery element");
}
