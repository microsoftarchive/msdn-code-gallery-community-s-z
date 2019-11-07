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
/// <reference path="../../vsdoc/actions/Sdk.new_TestAction.vsdoc.js" />
/// <reference path="../../vsdoc/messages/Sdk.SetState.vsdoc.js" />

var testActionId;

function verifyNew_TestAction() {

 var testActionQuery = new Sdk.Query.QueryExpression("sdkmessage");
 testActionQuery.setColumnSet("sdkmessageid");

 var testActionQueryCriteria = new Sdk.Query.FilterExpression(Sdk.Query.LogicalOperator.And);
 testActionQueryCriteria.addCondition("sdkmessage",
  "name",
  Sdk.Query.ConditionOperator.Equal,
  new Sdk.Query.Strings(["new_TestAction"]));
 testActionQuery.setCriteria(testActionQueryCriteria);

 var workflowLink = new Sdk.Query.LinkEntity("sdkmessage",
 "workflow",
 "sdkmessageid",
 "sdkmessageid",
 Sdk.Query.JoinOperator.Inner,
 "wkflw");
 workflowLink.setColumns("workflowid");

 testActionQuery.addLink(workflowLink);

 Sdk.Async.retrieveMultiple(testActionQuery,
 function (ec) {
  var entitiesReturned = ec.getEntities();
  if (entitiesReturned.getCount() >= 1) {
   var firstEntity = entitiesReturned.getByIndex(0);
   testActionId = firstEntity.getValue("wkflw.workflowid");
   writeToPage("testActionId: " + testActionId);
   writeToPage("Action named 'new_TestAction' found");
   testActionSample();
  }
  else {
   writeToPage("No valid Action named 'new_TestAction' found");
   createNew_TestAction();
  }
 },
 function (error) {
  writeToPage(error.message);
 });

}

function createNew_TestAction() {

 writeToPage("Creating Action named 'new_TestAction'");
 var new_TestAction = new Sdk.Entity("workflow");
 new_TestAction.addAttribute(new Sdk.String("name", "new_TestAction"));
 new_TestAction.addAttribute(new Sdk.String("uniquename", "TestAction"));
 new_TestAction.addAttribute(new Sdk.String("description", "This is the Description for the Process Test Action"));
 new_TestAction.addAttribute(new Sdk.OptionSet("category", 3));
 new_TestAction.addAttribute(new Sdk.OptionSet("type", 1));
 new_TestAction.addAttribute(new Sdk.Boolean("istransacted", true));
 new_TestAction.addAttribute(new Sdk.OptionSet("mode", 0));
 new_TestAction.addAttribute(new Sdk.Boolean("ondemand", true));
 new_TestAction.addAttribute(new Sdk.String("primaryentity", "none"));
 new_TestAction.addAttribute(new Sdk.OptionSet("runas", 1));
 new_TestAction.addAttribute(new Sdk.OptionSet("scope", 4));
 new_TestAction.addAttribute(new Sdk.Boolean("syncworkflowlogonfailure", true));
 new_TestAction.addAttribute(new Sdk.Boolean("triggeroncreate", false));
 new_TestAction.addAttribute(new Sdk.Boolean("triggerondelete", false));
 new_TestAction.addAttribute(new Sdk.String("xaml", actionXaml));

 Sdk.Async.create(new_TestAction,
  function (id) {
   testActionId = id;
   writeToPage(Sdk.Util.format("Workflow ID '{0}' created.", [id]));

   var setStateRequest = new Sdk.SetStateRequest(new Sdk.EntityReference("workflow", id), 1, 2);

   Sdk.Async.execute(setStateRequest,
    function (setStateResponse) {
     writeToPage("Action new_TestAction activated.");
     testActionSample();
    },
    function (error) {
     writeToPage(error.message);
    });


  },
  function (error) {
   writeToPage(error.message);
  });

}

function testActionSample() {

 var testAccount = new Sdk.Entity("account");
 testAccount.addAttribute(new Sdk.String("name", "Test Account"));

 var task1 = new Sdk.Entity("task");
 task1.addAttribute(new Sdk.String("subject", "Task 1"));

 var task2 = new Sdk.Entity("task");
 task2.addAttribute(new Sdk.String("subject", "Task 2"));

 var testCollection = new Sdk.EntityCollection();
 testCollection.addEntity(task1);
 testCollection.addEntity(task2);

 var testActionRequest = new Sdk.new_TestActionRequest(
  true,
  new Date("2/22/2014"),
  10.000,
  testAccount,
  testCollection,
  new Sdk.EntityReference("account", "4a3feb6a-9427-e311-a01e-00155d01681c"),
  10.000,
  12,
  100.05,
  1,
  "Test String");

 Sdk.Async.execute(testActionRequest,
   function (response) {
    writeToPage("Showing output from 'new_TestAction':");
    var testBooleanOut = response.getTestBooleanOut();
    var testDateTimeOut = response.getTestDateTimeOut();
    var testDecimalOut = response.getTestDecimalOut();
    var testEntityCollectionOut = response.getTestEntityCollectionOut();
    var testEntityOut = response.getTestEntityOut();
    var testEntityReferenceOut = response.getTestEntityReferenceOut();
    var testFloatOut = response.getTestFloatOut();
    var testIntegerOut = response.getTestIntegerOut();
    var testMoneyOut = response.getTestMoneyOut();
    var testPicklistOut = response.getTestPicklistOut();
    var testStringOut = response.getTestStringOut();

    writeToPage(Sdk.Util.format(" - testBooleanOut: {0}", [testBooleanOut.toString()]));
    writeToPage(Sdk.Util.format(" - testDateTimeOut: {0}", [testDateTimeOut.toString()]));
    writeToPage(Sdk.Util.format(" - testDecimalOut: {0}", [testDecimalOut.toString()]));
    writeToPage(Sdk.Util.format(" - testEntityCollectionOut: {0}", [(testEntityCollectionOut == null) ? "null" : "not null"]));
    writeToPage(Sdk.Util.format(" - testEntityOut: {0}", [(testEntityOut == null) ? "null" : "not null"]));
    writeToPage(Sdk.Util.format(" - testEntityReferenceOut: {0}", [(testEntityReferenceOut == null) ? "null" : "not null"]));
    writeToPage(Sdk.Util.format(" - testFloatOut: {0}", [testFloatOut.toString()]));
    writeToPage(Sdk.Util.format(" - testIntegerOut: {0}", [testIntegerOut.toString()]));
    writeToPage(Sdk.Util.format(" - testMoneyOut: {0}", [testMoneyOut.toString()]));
    writeToPage(Sdk.Util.format(" - testPicklistOut: {0}", [testPicklistOut.toString()]));
    writeToPage(Sdk.Util.format(" - testStringOut: {0}", [testStringOut]));

    var deactivateRequest = new Sdk.SetStateRequest(new Sdk.EntityReference("workflow", testActionId), 0, 1);
    Sdk.Async.execute(deactivateRequest,
     function () {
      writeToPage("TestAction Action deactivated.");
      Sdk.Async.del("workflow",
       testActionId,
       function () {
        writeToPage("TestAction Action deleted.");
       },
       function (error) {
        writeToPage(error.message);
       });
     },
     function (error) {
      writeToPage(error.message);
     });

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


var actionXaml = ["<?xml version=\"1.0\" encoding=\"utf-16\"?>",
"<Activity x:Class=\"XrmWorkflow5e2c285eed274c71a4f7b693ae50e993\"",
" xmlns=\"http://schemas.microsoft.com/netfx/2009/xaml/activities\"",
" xmlns:mva=\"clr-namespace:Microsoft.VisualBasic.Activities;assembly=System.Activities, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
" xmlns:mxs=\"clr-namespace:Microsoft.Xrm.Sdk;assembly=Microsoft.Xrm.Sdk, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
" xmlns:mxsw=\"clr-namespace:Microsoft.Xrm.Sdk.Workflow;assembly=Microsoft.Xrm.Sdk.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
" xmlns:mxswa=\"clr-namespace:Microsoft.Xrm.Sdk.Workflow.Activities;assembly=Microsoft.Xrm.Sdk.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
" xmlns:s=\"clr-namespace:System;assembly=mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\"",
" xmlns:scg=\"clr-namespace:System.Collections.Generic;assembly=mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\"",
" xmlns:srs=\"clr-namespace:System.Runtime.Serialization;assembly=System.Runtime.Serialization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\"",
" xmlns:this=\"clr-namespace:\"",
" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">",
"<x:Members>",
  "<x:Property Name=\"InputEntities\"",
" Type=\"InArgument(scg:IDictionary(x:String, mxs:Entity))\" />",
"<x:Property Name=\"CreatedEntities\"",
" Type=\"InArgument(scg:IDictionary(x:String, mxs:Entity))\" />",
"<x:Property Name=\"testBoolean\"",
" Type=\"InArgument(x:Boolean)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"True\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test Boolean Input Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Input\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testDateTime\"",
" Type=\"InArgument(s:DateTime)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test DateTime Input Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Input\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testDecimal\"",
" Type=\"InArgument(x:Decimal)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test Decimal Input Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Input\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testEntity\"",
" Type=\"InArgument(mxs:Entity)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test Entity Input Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Input\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testEntityCollection\"",
" Type=\"InArgument(mxs:EntityCollection)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test EntityCollection Input Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Input\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testEntityReference\"",
" Type=\"InArgument(mxs:EntityReference)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test EntityReference Input Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Input\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testFloat\"",
" Type=\"InArgument(x:Double)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test Float Input  Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Input\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testInteger\"",
" Type=\"InArgument(x:Int32)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test Integer Input  Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Input\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testMoney\"",
" Type=\"InArgument(mxs:Money)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test Money Input Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Input\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testPicklist\"",
" Type=\"InArgument(mxs:OptionSetValue)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test Picklist Input Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Input\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testString\"",
" Type=\"InArgument(x:String)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"True\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test String Input  Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Input\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testBooleanOut\"",
" Type=\"OutArgument(x:Boolean)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"True\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test Boolean Out Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Output\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testDateTimeOut\"",
" Type=\"OutArgument(s:DateTime)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test DateTime Out Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Output\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testDecimalOut\"",
" Type=\"OutArgument(x:Decimal)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test Decimal Out Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Output\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testEntityOut\"",
" Type=\"OutArgument(mxs:Entity)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test Entity Out Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Output\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testEntityCollectionOut\"",
" Type=\"OutArgument(mxs:EntityCollection)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test EntityCollection Out Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Output\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testEntityReferenceOut\"",
" Type=\"OutArgument(mxs:EntityReference)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test EntityReference Out Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Output\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testFloatOut\"",
" Type=\"OutArgument(x:Double)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test Float Out Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Output\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testIntegerOut\"",
" Type=\"OutArgument(x:Int32)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test Integer Out Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Output\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testMoneyOut\"",
" Type=\"OutArgument(mxs:Money)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test Money Out Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Output\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testPicklistOut\"",
" Type=\"OutArgument(mxs:OptionSetValue)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"False\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test Picklist Out Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Output\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"testStringOut\"",
" Type=\"OutArgument(x:String)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"True\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"False\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Test String Out Description\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Output\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"\" />",
"</x:Property.Attributes>",
"</x:Property>",
"<x:Property Name=\"Target\"",
" Type=\"InArgument(mxs:EntityReference)\">",
"<x:Property.Attributes>",
  "<mxsw:ArgumentRequiredAttribute Value=\"True\" />",
  "<mxsw:ArgumentTargetAttribute Value=\"True\" />",
  "<mxsw:ArgumentDescriptionAttribute Value=\"Target Argument\" />",
  "<mxsw:ArgumentDirectionAttribute Value=\"Input\" />",
  "<mxsw:ArgumentEntityAttribute Value=\"none\" />",
"</x:Property.Attributes>",
"</x:Property>",
"</x:Members>",
"<this:XrmWorkflow5e2c285eed274c71a4f7b693ae50e993.InputEntities>",
  "<InArgument x:TypeArguments=\"scg:IDictionary(x:String, mxs:Entity)\" />",
"</this:XrmWorkflow5e2c285eed274c71a4f7b693ae50e993.InputEntities>",
"<this:XrmWorkflow5e2c285eed274c71a4f7b693ae50e993.CreatedEntities>",
  "<InArgument x:TypeArguments=\"scg:IDictionary(x:String, mxs:Entity)\" />",
"</this:XrmWorkflow5e2c285eed274c71a4f7b693ae50e993.CreatedEntities>",
"<this:XrmWorkflow5e2c285eed274c71a4f7b693ae50e993.Target>",
  "<InArgument x:TypeArguments=\"mxs:EntityReference\" />",
"</this:XrmWorkflow5e2c285eed274c71a4f7b693ae50e993.Target>",
"<mva:VisualBasic.Settings>Assembly references and imported namespaces for internal implementation</mva:VisualBasic.Settings>",
"<mxswa:Workflow>",
  "<Sequence DisplayName=\"AssignOutputArgumentStep1: Pass Boolean through\">",
    "<Sequence.Variables>",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep1_1\" />",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep1_2\" />",
      "<Variable x:TypeArguments=\"x:String\"",
                " Default=\"System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\"",
                " Name=\"TypeName\" />",
    "</Sequence.Variables>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">CustomOperationArguments</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { testBoolean }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"x:Boolean\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep1_2]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">SelectFirstNonNull</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { AssignOutputArgumentStep1_2 }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"x:Boolean\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep1_1]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<Assign x:TypeArguments=\"x:Boolean\"",
            " To=\"[testBooleanOut]\"",
            " Value=\"[CBool(AssignOutputArgumentStep1_1)]\" />",
  "</Sequence>",
  "<Sequence DisplayName=\"AssignOutputArgumentStep2: Set Output date to one day in the future of the input date\">",
    "<Sequence.Variables>",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep2_1\" />",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep2_2\" />",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep2_3\" />",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep2_4\" />",
      "<Variable x:TypeArguments=\"mxsw:XrmTimeSpan\"",
                " Name=\"AssignOutputArgumentStep2_5\">",
        "<Variable.Default>",
          "<Literal x:TypeArguments=\"mxsw:XrmTimeSpan\">",
            "<mxsw:XrmTimeSpan Days=\"1\"",
                              " Hours=\"0\"",
                              " Minutes=\"0\"",
                              " Months=\"0\"",
                              " Years=\"0\" />",
          "</Literal>",
        "</Variable.Default>",
      "</Variable>",
      "<Variable x:TypeArguments=\"x:String\"",
                " Default=\"System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\"",
                " Name=\"TypeName\" />",
    "</Sequence.Variables>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">CustomOperationArguments</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { testDateTime }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"s:DateTime\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep2_4]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">SelectFirstNonNull</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { AssignOutputArgumentStep2_4 }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"s:DateTime\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep2_3]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">Add</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { AssignOutputArgumentStep2_3, AssignOutputArgumentStep2_5 }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"s:DateTime\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep2_2]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">SelectFirstNonNull</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { AssignOutputArgumentStep2_2 }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"s:DateTime\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep2_1]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<Assign x:TypeArguments=\"s:DateTime\"",
            " To=\"[testDateTimeOut]\"",
            " Value=\"[CDate(AssignOutputArgumentStep2_1)]\" />",
  "</Sequence>",
  "<Sequence DisplayName=\"AssignOutputArgumentStep3: Set testDecimalOut to testDecimal\">",
    "<Sequence.Variables>",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep3_1\" />",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep3_2\" />",
      "<Variable x:TypeArguments=\"x:String\"",
                " Default=\"System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\"",
                " Name=\"TypeName\" />",
    "</Sequence.Variables>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">CustomOperationArguments</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { testDecimal }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"x:Decimal\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep3_2]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">SelectFirstNonNull</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { AssignOutputArgumentStep3_2 }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"x:Decimal\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep3_1]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<Assign x:TypeArguments=\"x:Decimal\"",
            " To=\"[testDecimalOut]\"",
            " Value=\"[DirectCast(AssignOutputArgumentStep3_1,System.Decimal)]\" />",
  "</Sequence>",
  "<Sequence DisplayName=\"AssignOutputArgumentStep4: Set TestFloatOut to testFloat\">",
    "<Sequence.Variables>",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep4_1\" />",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep4_2\" />",
      "<Variable x:TypeArguments=\"x:String\"",
                " Default=\"System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\"",
                " Name=\"TypeName\" />",
    "</Sequence.Variables>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">CustomOperationArguments</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { testFloat }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"x:Double\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep4_2]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">SelectFirstNonNull</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { AssignOutputArgumentStep4_2 }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"x:Double\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep4_1]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<Assign x:TypeArguments=\"x:Double\"",
            " To=\"[testFloatOut]\"",
            " Value=\"[CDbl(AssignOutputArgumentStep4_1)]\" />",
  "</Sequence>",
  "<Sequence DisplayName=\"AssignOutputArgumentStep5: Set testIntegerOut to testInteger\">",
    "<Sequence.Variables>",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep5_1\" />",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep5_2\" />",
      "<Variable x:TypeArguments=\"x:String\"",
                " Default=\"System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\"",
                " Name=\"TypeName\" />",
    "</Sequence.Variables>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">CustomOperationArguments</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { testInteger }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"x:Int32\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep5_2]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">SelectFirstNonNull</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { AssignOutputArgumentStep5_2 }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"x:Int32\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep5_1]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<Assign x:TypeArguments=\"x:Int32\"",
            " To=\"[testIntegerOut]\"",
            " Value=\"[CInt(AssignOutputArgumentStep5_1)]\" />",
  "</Sequence>",
  "<Sequence DisplayName=\"AssignOutputArgumentStep6: Set testMoneyOut to testMoney\">",
    "<Sequence.Variables>",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep6_1\" />",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep6_2\" />",
      "<Variable x:TypeArguments=\"x:String\"",
                " Default=\"Microsoft.Xrm.Sdk.Money, Microsoft.Xrm.Sdk, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                " Name=\"TypeName\" />",
    "</Sequence.Variables>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">CustomOperationArguments</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { testMoney }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"mxs:Money\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep6_2]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">SelectFirstNonNull</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { AssignOutputArgumentStep6_2 }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"mxs:Money\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep6_1]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<Assign x:TypeArguments=\"mxs:Money\"",
            " To=\"[testMoneyOut]\"",
            " Value=\"[DirectCast(AssignOutputArgumentStep6_1,Microsoft.Xrm.Sdk.Money)]\" />",
  "</Sequence>",
  "<Sequence DisplayName=\"AssignOutputArgumentStep7: Set testPicklistOut to testPicklist\">",
    "<Sequence.Variables>",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep7_1\" />",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep7_2\" />",
      "<Variable x:TypeArguments=\"x:String\"",
                " Default=\"Microsoft.Xrm.Sdk.OptionSetValue, Microsoft.Xrm.Sdk, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                " Name=\"TypeName\" />",
    "</Sequence.Variables>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">CustomOperationArguments</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { testPicklist }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"mxs:OptionSetValue\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep7_2]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">SelectFirstNonNull</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { AssignOutputArgumentStep7_2 }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"mxs:OptionSetValue\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep7_1]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<Assign x:TypeArguments=\"mxs:OptionSetValue\"",
            " To=\"[testPicklistOut]\"",
            " Value=\"[DirectCast(AssignOutputArgumentStep7_1,Microsoft.Xrm.Sdk.OptionSetValue)]\" />",
  "</Sequence>",
  "<Sequence DisplayName=\"AssignOutputArgumentStep8: Set testStringOut to testString\">",
    "<Sequence.Variables>",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep8_1\" />",
      "<Variable x:TypeArguments=\"x:Object\"",
                " Name=\"AssignOutputArgumentStep8_2\" />",
      "<Variable x:TypeArguments=\"x:String\"",
                " Default=\"System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\"",
                " Name=\"TypeName\" />",
    "</Sequence.Variables>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">CustomOperationArguments</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { testString }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"x:String\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep8_2]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<mxswa:ActivityReference AssemblyQualifiedName=\"Microsoft.Crm.Workflow.Activities.EvaluateExpression, Microsoft.Crm.Workflow, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\"",
                             " DisplayName=\"EvaluateExpression\">",
      "<mxswa:ActivityReference.Arguments>",
        "<InArgument x:TypeArguments=\"x:String\"",
 " x:Key=\"ExpressionOperator\">SelectFirstNonNull</InArgument>",
        "<InArgument x:TypeArguments=\"s:Object[]\"",
 " x:Key=\"Parameters\">[New Object() { AssignOutputArgumentStep8_2 }]</InArgument>",
        "<InArgument x:TypeArguments=\"s:Type\"",
 " x:Key=\"TargetType\">",
          "<mxswa:ReferenceLiteral x:TypeArguments=\"s:Type\"",
                                  " Value=\"x:String\" />",
        "</InArgument>",
        "<OutArgument x:TypeArguments=\"x:Object\"",
 " x:Key=\"Result\">[AssignOutputArgumentStep8_1]</OutArgument>",
      "</mxswa:ActivityReference.Arguments>",
    "</mxswa:ActivityReference>",
    "<Assign x:TypeArguments=\"x:String\"",
            " To=\"[testStringOut]\"",
            " Value=\"[AssignOutputArgumentStep8_1.ToString()]\" />",
  "</Sequence>",
"</mxswa:Workflow>",
"</Activity>"].join("");