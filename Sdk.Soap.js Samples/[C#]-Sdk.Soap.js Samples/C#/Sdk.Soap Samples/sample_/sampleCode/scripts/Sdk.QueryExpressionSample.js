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
/// <reference path="../../vsdoc/messages/Sdk.Retrieve.vsdoc.js" />

var createdAccountId, taskQueryExpression, relatedTasksQuery;

function startQueryExpressionSample() {

 Sdk.jQ.setJQueryVariable($);

 var account = initEntity(new Sdk.Entity("account"), accountColumns);
 account.setValue("name", "Sample Account 001");
 account.setValue("creditonhold", false);
 account.setValue("address1_latitude", 47.638197);
 account.setValue("address1_longitude", -122.131378);
 account.setValue("numberofemployees", 100000);
 account.setValue("description", "This is a description. \n It has several lines. \n This is the third line.");
 account.setValue("creditlimit", 2000000.00);
 account.setValue("accountcategorycode", 1); //Preferred Customer
 account.setValue("sharesoutstanding", 200);
 account.setValue("revenue", 3000000.00);
 account.setValue("industrycode", 6); //Business Services
 account.setValue("accountnumber", "ABC123");
 account.setValue("address1_city", "Redmond");

 var task1 = new Sdk.Entity("task");
 task1.addAttribute(new Sdk.String("subject", "Task 1"));
 task1.addAttribute(new Sdk.OptionSet("prioritycode", 0)); //Low
 account.addRelatedEntity("Account_Tasks", task1);

 var task2 = new Sdk.Entity("task");
 task2.addAttribute(new Sdk.String("subject", "Task 2"));
 task2.addAttribute(new Sdk.OptionSet("prioritycode", 1)); //Normal
 account.addRelatedEntity("Account_Tasks", task2);

 var task3 = new Sdk.Entity("task");
 task3.addAttribute(new Sdk.String("subject", "Task 3"));
 task3.addAttribute(new Sdk.OptionSet("prioritycode", 2)); //High
 account.addRelatedEntity("Account_Tasks", task3);

 Sdk.jQ.create(account)
  .then(
  function (id) {
   createdAccountId = id;
   writeToPage("Created account with id: " + createdAccountId + " and three associated tasks.")
   //------------------------------
   var taskQuery = new Sdk.Query.QueryExpression("task");
   taskQuery.addColumn("subject");
   taskQuery.addColumn("prioritycode");
   taskQuery.addColumn("activityid");
   taskQuery.addColumn("createdon");

   var values = new Sdk.Query.Guids([createdAccountId]);
   taskQuery.addCondition(
    "task",//entityName
    "regardingobjectid",//attributeName
    Sdk.Query.ConditionOperator.Equal,//conditionOperator
    values //values
    );



   var linkToAccount = new Sdk.Query.LinkEntity(
    "task", //linkFromEntityName
    "account", //linkToEntityName
    "regardingobjectid", //linkFromAttributeName
    "accountid", ///linkToAttributeName
    Sdk.Query.JoinOperator.Inner, //joinOperator
    "acct"//entityAlias
    );
   linkToAccount.setColumns("name", "createdon", "accountcategorycode");

   taskQuery.addLink(linkToAccount);
   taskQueryExpression = taskQuery;
   return Sdk.jQ.retrieveMultiple(taskQuery);
  },
  new ErrorHandler("Creating Account").getError
  )
  .then(
  function (ec) {
   writeToPage("These are the tasks retrieved using Sdk.jQ.retrieveMultiple with an Sdk.Query.QueryExpression:");
   showQueryExpressionResultValues(ec, taskQueryExpression);
   //------------------------------
   //Retrieve related records with retrieveRequest
   relatedTasksQuery = new Sdk.Query.QueryExpression("task");
   relatedTasksQuery.addColumn("subject");
   relatedTasksQuery.addColumn("prioritycode");
   relatedTasksQuery.addColumn("activityid");
   relatedTasksQuery.addColumn("createdon");

   var rtq = new Sdk.RelationshipQuery("Account_Tasks", relatedTasksQuery);

   var rqc = new Sdk.RelationshipQueryCollection();
   rqc.add(rtq);

   var req = new Sdk.RetrieveRequest(
    new Sdk.EntityReference("account", createdAccountId),//target
    new Sdk.ColumnSet("name"),//columnSet
    rqc//relatedEntitiesQuery
    );

   return Sdk.jQ.execute(req);
  },
  new ErrorHandler("Retrieving Tasks: ").getError
  )
 .then(
 function (resp) {
  writeToPage("Retrieved account with related tasks using Sdk.jQ.execute with an Sdk.RetrieveRequest and a related entities query.");
  var account = resp.getEntity();
  var taskCollection = account.getRelatedEntities().getRelatedEntitiesByRelationshipName("Account_Tasks");
  showQueryExpressionResultValues(taskCollection, relatedTasksQuery);

  //------------------------------
  writeToPage("Ending sample by deleting account and associated tasks.")
  return Sdk.jQ.del("account", createdAccountId);
 },
 new ErrorHandler("Retrieving account with related tasks: ").getError
 )
.done(
function () {
 writeToPage("End of sample");
}
).fail(new ErrorHandler("Deleting Account: ").getError)

}

//This dictionary of columns is used by 
// the initEntity and getColumnSet functions
// with 'late-binding' style.
var accountColumns = {
 "creditonhold": Sdk.Boolean,
 "address1_latitude": Sdk.Double,
 "address1_longitude": Sdk.Double,
 "numberofemployees": Sdk.Int,
 "description": Sdk.String,
 "name": Sdk.String,
 "creditlimit": Sdk.Money,
 "accountcategorycode": Sdk.OptionSet,
 "versionnumber": Sdk.Long,
 "donotbulkemail": Sdk.Boolean,
 "createdon": Sdk.DateTime,
 "createdby": Sdk.Lookup,
 "exchangerate": Sdk.Decimal,
 "sharesoutstanding": Sdk.Int,
 "owninguser": Sdk.Lookup,
 "revenue": Sdk.Money,
 "ownerid": Sdk.Lookup,
 "industrycode": Sdk.OptionSet,
 "statecode": Sdk.OptionSet,
 "statuscode": Sdk.OptionSet,
 "accountnumber": Sdk.String,
 "address1_addressid": Sdk.Guid,
 "address1_city": Sdk.String,
 "accountid": Sdk.Guid
};


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
  //This is different from the others
  //need to return a promise to stop the chain
  return $.Deferred().promise();
 };
}

function showQueryExpressionResultValues(ec, qe) {
 var table = document.createElement("table");
 var columns = qe.getColumnSet().getColumns().toArray();
 var linkEntities = qe.getLinkEntities();
 linkEntities.forEach(function (le, i) {
  var alias = le.getEntityAlias();
  if (alias != null)
  { alias = alias + "."; }
  else
  { alias = ""; }
  le.getColumns().getColumns().forEach(function (c, n) {
   columns.push(alias + c);
  });
 });

 addRowToTable("th", columns);


 ec.getEntities().forEach(function (e, i) {
  var values = [];
  for (var i = 0; i < columns.length; i++) {
   values.push(e.view().attributes[columns[i]].fValue);
  }
  addRowToTable("td", values);
 });

 writeToPage(table);



 function addRowToTable(tagName, values) {
  var row = document.createElement("tr");
  for (var i = 0; i < values.length; i++) {
   var cell = document.createElement(tagName);
   cell.appendChild(document.createTextNode(values[i]));
   row.appendChild(cell);
  }
  table.appendChild(row);
 }
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
