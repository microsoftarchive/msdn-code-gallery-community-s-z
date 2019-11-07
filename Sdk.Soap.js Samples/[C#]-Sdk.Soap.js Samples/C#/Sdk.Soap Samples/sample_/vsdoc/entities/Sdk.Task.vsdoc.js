/*

IMPORTANT: Use this file at design time for IntelliSense support ONLY.
Use the corresponding Sdk.Task.min.js in your project

*/
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

Sdk = window.Sdk || { __namespace: true };
(function () {
this.Task = function (entity) {
///<summary>
/// Generic activity representing work needed to be done.
///</summary>
/// <param name='entity' type='Sdk.Entity' mayBeNull='true' optional='true'>
/// Optional. Use only to convert an Sdk.Entity into an Sdk.Task
///</param>
  if (!(this instanceof Sdk.Task)) {
   return new Sdk.Task();
  }
  Sdk.Entity.call(this);
  this.setType("task");
  if (typeof entity != "undefined" && entity != null) {
   if (entity instanceof Sdk.Entity) {
    if (entity.getType() == this.getType()) {
     this.setAttributes(entity.getAttributes());
     this.setFormattedValues(entity.getFormattedValues());
     this.setRelatedEntities(entity.getRelatedEntities());
     if (entity.getId() != null) {
      this.setId(entity.getId());
     }
    }
    else {
     throw new Error("Invalid type Sdk.Task entity constructor parameter must be an Sdk.Entity of Type task");
    }
   }
   else {
    throw new Error("Invalid argument Sdk.Task entity constructor parameter must be an Sdk.Entity");
   }
  }

// ActivityId START --------------------------------------------------------------
var ActivityId = new Sdk.Guid("activityid");
this.addAttribute(ActivityId, false);
 /// <field name='ActivityId' type='Sdk.Guid'>Task : Unique identifier of the task.</field>
this.ActivityId = {};
this.ActivityId.setValue = function (value) {
 ///<summary><para>Sets the ActivityId (Task) value</para>
 /// <para>RequiredLevel: SystemRequired</para>
 ///</summary>
 /// <param name="value" type="String" mayBeNull="true" optional="false">Unique identifier of the task.</param>
ActivityId.setValue(value);
};
this.ActivityId.getValue = function () {
 ///<summary>Gets the ActivityId value</summary>
 /// <returns type="String" mayBeNull="true">Unique identifier of the task.</returns>
return ActivityId.getValue();
}
// ActivityId END --------------------------------------------------------------


// ActivityTypeCode START --------------------------------------------------------------
//Not Implemented
// ActivityTypeCode END --------------------------------------------------------------


// ActualDurationMinutes START --------------------------------------------------------------
var ActualDurationMinutes = new Sdk.Int("actualdurationminutes");
this.addAttribute(ActualDurationMinutes, false);
/// <field name='ActualDurationMinutes' type='Sdk.Int'>Duration : Type the number of minutes spent on the task. The duration is used in reporting.</field>
this.ActualDurationMinutes = {};
this.ActualDurationMinutes.setValue = function (value) {
 ///<summary>Sets the ActualDurationMinutes value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Duration : Type the number of minutes spent on the task. The duration is used in reporting.</para>
 /// <para>MaxValue: 2147483647</para>
 /// <para>MinValue: -2147483648</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 ActualDurationMinutes.setValue(value);
};
this.ActualDurationMinutes.getValue = function () {
 ///<summary>
 /// Gets the ActualDurationMinutes value
 ///</summary>
 /// <returns type="Number">Type the number of minutes spent on the task. The duration is used in reporting.</returns>
 return ActualDurationMinutes.getValue();
}
// ActualDurationMinutes END --------------------------------------------------------------


// ActualEnd START --------------------------------------------------------------
var ActualEnd = new Sdk.DateTime("actualend");
this.addAttribute(ActualEnd, false);
/// <field name='ActualEnd' type='Sdk.DateTime'>Actual End : Enter the actual end date and time of the task. By default, it displays when the activity was completed or canceled.</field>
this.ActualEnd = {};
this.ActualEnd.setValue = function (value) {
 ///<summary><para>Sets the ActualEnd (Actual End) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="Date" optional="false">Enter the actual end date and time of the task. By default, it displays when the activity was completed or canceled.</param>
 ActualEnd.setValue(value);
};
this.ActualEnd.getValue = function () {
 ///<summary>
 /// Gets the ActualEnd value
 ///</summary>
 /// <returns type="Date">Enter the actual end date and time of the task. By default, it displays when the activity was completed or canceled.</returns>
 return ActualEnd.getValue();
}
// ActualEnd END --------------------------------------------------------------


// ActualStart START --------------------------------------------------------------
var ActualStart = new Sdk.DateTime("actualstart");
this.addAttribute(ActualStart, false);
/// <field name='ActualStart' type='Sdk.DateTime'>Actual Start : Enter the actual start date and time for the task. By default, it displays when the task was created.</field>
this.ActualStart = {};
this.ActualStart.setValue = function (value) {
 ///<summary><para>Sets the ActualStart (Actual Start) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="Date" optional="false">Enter the actual start date and time for the task. By default, it displays when the task was created.</param>
 ActualStart.setValue(value);
};
this.ActualStart.getValue = function () {
 ///<summary>
 /// Gets the ActualStart value
 ///</summary>
 /// <returns type="Date">Enter the actual start date and time for the task. By default, it displays when the task was created.</returns>
 return ActualStart.getValue();
}
// ActualStart END --------------------------------------------------------------


// Category START --------------------------------------------------------------
  var Category = new Sdk.String("category");
  this.addAttribute(Category, false);
  /// <field name='Category' type='Sdk.String'>Category : Type a category to identify the task type, such as lead gathering or customer follow up, to tie the task to a business group or function.</field>
this.Category = {};
  this.Category.setValue = function (value) {
   ///<summary>Sets the Category value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Category : Type a category to identify the task type, such as lead gathering or customer follow up, to tie the task to a business group or function.</para>
   /// <para>MaxLength: 250</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Category.setValue(value);
  };
  this.Category.getValue = function () {
   ///<summary>
   /// Gets the Category value
   ///</summary>
   /// <returns type="String">Type a category to identify the task type, such as lead gathering or customer follow up, to tie the task to a business group or function.</returns>
   return Category.getValue();
  }
// Category END --------------------------------------------------------------


// CreatedBy START --------------------------------------------------------------
var CreatedBy = new Sdk.Lookup("createdby");
this.addAttribute(CreatedBy, false);
/// <field name='CreatedBy' type='Sdk.Lookup'>Created By : Shows who created the record.</field>
this.CreatedBy = {};
this.CreatedBy.getValue = function () {
 ///<summary>
 /// Gets the CreatedBy value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Shows who created the record.</returns>
 return CreatedBy.getValue();
}
// CreatedBy END --------------------------------------------------------------


// CreatedOn START --------------------------------------------------------------
var CreatedOn = new Sdk.DateTime("createdon");
this.addAttribute(CreatedOn, false);
/// <field name='CreatedOn' type='Sdk.DateTime'>Created On : Shows the date and time when the record was created. The date and time are displayed in the time zone selected in Microsoft Dynamics CRM options.</field>
this.CreatedOn = {};
this.CreatedOn.getValue = function () {
 ///<summary>
 /// Gets the CreatedOn value
 ///</summary>
 /// <returns type="Date">Shows the date and time when the record was created. The date and time are displayed in the time zone selected in Microsoft Dynamics CRM options.</returns>
 return CreatedOn.getValue();
}
// CreatedOn END --------------------------------------------------------------


// CreatedOnBehalfBy START --------------------------------------------------------------
var CreatedOnBehalfBy = new Sdk.Lookup("createdonbehalfby");
this.addAttribute(CreatedOnBehalfBy, false);
/// <field name='CreatedOnBehalfBy' type='Sdk.Lookup'>Created By (Delegate) : Shows who created the record on behalf of another user.</field>
this.CreatedOnBehalfBy = {};
this.CreatedOnBehalfBy.getValue = function () {
 ///<summary>
 /// Gets the CreatedOnBehalfBy value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Shows who created the record on behalf of another user.</returns>
 return CreatedOnBehalfBy.getValue();
}
// CreatedOnBehalfBy END --------------------------------------------------------------


// Description START --------------------------------------------------------------
  var Description = new Sdk.String("description");
  this.addAttribute(Description, false);
  /// <field name='Description' type='Sdk.String'>Description : Type additional information to describe the task.</field>
this.Description = {};
  this.Description.setValue = function (value) {
   ///<summary>Sets the Description value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Description : Type additional information to describe the task.</para>
   /// <para>MaxLength: 2000</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Description.setValue(value);
  };
  this.Description.getValue = function () {
   ///<summary>
   /// Gets the Description value
   ///</summary>
   /// <returns type="String">Type additional information to describe the task.</returns>
   return Description.getValue();
  }
// Description END --------------------------------------------------------------


// ExchangeRate START --------------------------------------------------------------
var ExchangeRate = new Sdk.Decimal("exchangerate");
this.addAttribute(ExchangeRate, false);
/// <field name='ExchangeRate' type='Sdk.Decimal'>Exchange Rate : Shows the conversion rate of the record's currency. The exchange rate is used to convert all money fields in the record from the local currency to the system's default currency.</field>
this.ExchangeRate = {};
this.ExchangeRate.getValue = function () {
 ///<summary>
 /// Gets the ExchangeRate value
 ///</summary>
 /// <returns type="Number">Shows the conversion rate of the record's currency. The exchange rate is used to convert all money fields in the record from the local currency to the system's default currency.</returns>
 return ExchangeRate.getValue();
}
// ExchangeRate END --------------------------------------------------------------


// ImportSequenceNumber START --------------------------------------------------------------
var ImportSequenceNumber = new Sdk.Int("importsequencenumber");
this.addAttribute(ImportSequenceNumber, false);
/// <field name='ImportSequenceNumber' type='Sdk.Int'>Import Sequence Number : Unique identifier of the data import or data migration that created this record.</field>
this.ImportSequenceNumber = {};
this.ImportSequenceNumber.setValue = function (value) {
 ///<summary>Sets the ImportSequenceNumber value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Import Sequence Number : Unique identifier of the data import or data migration that created this record.</para>
 /// <para>MaxValue: 2147483647</para>
 /// <para>MinValue: -2147483648</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 ImportSequenceNumber.setValue(value);
};
this.ImportSequenceNumber.getValue = function () {
 ///<summary>
 /// Gets the ImportSequenceNumber value
 ///</summary>
 /// <returns type="Number">Unique identifier of the data import or data migration that created this record.</returns>
 return ImportSequenceNumber.getValue();
}
// ImportSequenceNumber END --------------------------------------------------------------


// IsBilled START --------------------------------------------------------------
var IsBilled = new Sdk.Boolean("isbilled");
this.addAttribute(IsBilled, false);
/// <field name='IsBilled' type='Sdk.String'>Is Billed : Information which specifies whether the task was billed as part of resolving a case. </field>
this.IsBilled = {};
this.IsBilled.setValue = function (value) {
 ///<summary>Sets the IsBilled value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Is Billed  : Information which specifies whether the task was billed as part of resolving a case. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: Yes</para>
 /// <para>False Label: No</para>
 /// </param>
IsBilled.setValue(value);
};
this.IsBilled.getValue = function () {
 ///<summary>
 /// Gets the IsBilled value
 ///</summary>
 /// <returns type="Boolean">Information which specifies whether the task was billed as part of resolving a case.</returns>
return IsBilled.getValue();
}
// IsBilled END --------------------------------------------------------------


// IsRegularActivity START --------------------------------------------------------------
var IsRegularActivity = new Sdk.Boolean("isregularactivity");
this.addAttribute(IsRegularActivity, false);
/// <field name='IsRegularActivity' type='Sdk.String'>Is Regular Activity : Information regarding whether the activity is a regular activity type or event type. </field>
this.IsRegularActivity = {};
this.IsRegularActivity.getValue = function () {
 ///<summary>
 /// Gets the IsRegularActivity value
 ///</summary>
 /// <returns type="Boolean">Information regarding whether the activity is a regular activity type or event type.</returns>
return IsRegularActivity.getValue();
}
// IsRegularActivity END --------------------------------------------------------------


// IsWorkflowCreated START --------------------------------------------------------------
var IsWorkflowCreated = new Sdk.Boolean("isworkflowcreated");
this.addAttribute(IsWorkflowCreated, false);
/// <field name='IsWorkflowCreated' type='Sdk.String'>Is Workflow Created : Information which specifies if the task was created from a workflow rule. </field>
this.IsWorkflowCreated = {};
this.IsWorkflowCreated.setValue = function (value) {
 ///<summary>Sets the IsWorkflowCreated value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Is Workflow Created  : Information which specifies if the task was created from a workflow rule. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: Yes</para>
 /// <para>False Label: No</para>
 /// </param>
IsWorkflowCreated.setValue(value);
};
this.IsWorkflowCreated.getValue = function () {
 ///<summary>
 /// Gets the IsWorkflowCreated value
 ///</summary>
 /// <returns type="Boolean">Information which specifies if the task was created from a workflow rule.</returns>
return IsWorkflowCreated.getValue();
}
// IsWorkflowCreated END --------------------------------------------------------------


// ModifiedBy START --------------------------------------------------------------
var ModifiedBy = new Sdk.Lookup("modifiedby");
this.addAttribute(ModifiedBy, false);
/// <field name='ModifiedBy' type='Sdk.Lookup'>Modified By : Shows who last updated the record.</field>
this.ModifiedBy = {};
this.ModifiedBy.getValue = function () {
 ///<summary>
 /// Gets the ModifiedBy value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Shows who last updated the record.</returns>
 return ModifiedBy.getValue();
}
// ModifiedBy END --------------------------------------------------------------


// ModifiedOn START --------------------------------------------------------------
var ModifiedOn = new Sdk.DateTime("modifiedon");
this.addAttribute(ModifiedOn, false);
/// <field name='ModifiedOn' type='Sdk.DateTime'>Modified On : Shows the date and time when the record was last updated. The date and time are displayed in the time zone selected in Microsoft Dynamics CRM options.</field>
this.ModifiedOn = {};
this.ModifiedOn.getValue = function () {
 ///<summary>
 /// Gets the ModifiedOn value
 ///</summary>
 /// <returns type="Date">Shows the date and time when the record was last updated. The date and time are displayed in the time zone selected in Microsoft Dynamics CRM options.</returns>
 return ModifiedOn.getValue();
}
// ModifiedOn END --------------------------------------------------------------


// ModifiedOnBehalfBy START --------------------------------------------------------------
var ModifiedOnBehalfBy = new Sdk.Lookup("modifiedonbehalfby");
this.addAttribute(ModifiedOnBehalfBy, false);
/// <field name='ModifiedOnBehalfBy' type='Sdk.Lookup'>Modified By (Delegate) : Shows who last updated the record on behalf of another user.</field>
this.ModifiedOnBehalfBy = {};
this.ModifiedOnBehalfBy.getValue = function () {
 ///<summary>
 /// Gets the ModifiedOnBehalfBy value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Shows who last updated the record on behalf of another user.</returns>
 return ModifiedOnBehalfBy.getValue();
}
// ModifiedOnBehalfBy END --------------------------------------------------------------


// OverriddenCreatedOn START --------------------------------------------------------------
var OverriddenCreatedOn = new Sdk.DateTime("overriddencreatedon");
this.addAttribute(OverriddenCreatedOn, false);
/// <field name='OverriddenCreatedOn' type='Sdk.DateTime'>Record Created On : Date and time that the record was migrated.</field>
this.OverriddenCreatedOn = {};
this.OverriddenCreatedOn.setValue = function (value) {
 ///<summary><para>Sets the OverriddenCreatedOn (Record Created On) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="Date" optional="false">Date and time that the record was migrated.</param>
 OverriddenCreatedOn.setValue(value);
};
this.OverriddenCreatedOn.getValue = function () {
 ///<summary>
 /// Gets the OverriddenCreatedOn value
 ///</summary>
 /// <returns type="Date">Date and time that the record was migrated.</returns>
 return OverriddenCreatedOn.getValue();
}
// OverriddenCreatedOn END --------------------------------------------------------------


// OwnerId START --------------------------------------------------------------
var OwnerId = new Sdk.Lookup("ownerid");
this.addAttribute(OwnerId, false);
/// <field name='OwnerId' type='Sdk.Lookup'>Owner : Enter the user or team who is assigned to manage the record. This field is updated every time the record is assigned to a different user.</field>
this.OwnerId = {};
this.OwnerId.setValue = function (value) {
///<summary><para>Sets the OwnerId value</para>
/// <para>Display Name: Owner</para>
/// <para>Targets: systemuser,team</para>
/// <para>RequiredLevel: SystemRequired</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Enter the user or team who is assigned to manage the record. This field is updated every time the record is assigned to a different user.</param>
 OwnerId.setValue(value);
};
this.OwnerId.getValue = function () {
 ///<summary>
 /// Gets the OwnerId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Enter the user or team who is assigned to manage the record. This field is updated every time the record is assigned to a different user.</returns>
 return OwnerId.getValue();
}
// OwnerId END --------------------------------------------------------------


// OwningBusinessUnit START --------------------------------------------------------------
var OwningBusinessUnit = new Sdk.Lookup("owningbusinessunit");
this.addAttribute(OwningBusinessUnit, false);
/// <field name='OwningBusinessUnit' type='Sdk.Lookup'>Owning Business Unit : Shows the record owner's business unit.</field>
this.OwningBusinessUnit = {};
this.OwningBusinessUnit.getValue = function () {
 ///<summary>
 /// Gets the OwningBusinessUnit value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Shows the record owner's business unit.</returns>
 return OwningBusinessUnit.getValue();
}
// OwningBusinessUnit END --------------------------------------------------------------


// OwningTeam START --------------------------------------------------------------
var OwningTeam = new Sdk.Lookup("owningteam");
this.addAttribute(OwningTeam, false);
/// <field name='OwningTeam' type='Sdk.Lookup'>Owning Team : Unique identifier of the team that owns the task.</field>
this.OwningTeam = {};
this.OwningTeam.getValue = function () {
 ///<summary>
 /// Gets the OwningTeam value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Unique identifier of the team that owns the task.</returns>
 return OwningTeam.getValue();
}
// OwningTeam END --------------------------------------------------------------


// OwningUser START --------------------------------------------------------------
var OwningUser = new Sdk.Lookup("owninguser");
this.addAttribute(OwningUser, false);
/// <field name='OwningUser' type='Sdk.Lookup'>Owning User : Unique identifier of the user that owns the task.</field>
this.OwningUser = {};
this.OwningUser.getValue = function () {
 ///<summary>
 /// Gets the OwningUser value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Unique identifier of the user that owns the task.</returns>
 return OwningUser.getValue();
}
// OwningUser END --------------------------------------------------------------


// PercentComplete START --------------------------------------------------------------
var PercentComplete = new Sdk.Int("percentcomplete");
this.addAttribute(PercentComplete, false);
/// <field name='PercentComplete' type='Sdk.Int'>Percent Complete : Type the percentage complete value for the task to track tasks to completion.</field>
this.PercentComplete = {};
this.PercentComplete.setValue = function (value) {
 ///<summary>Sets the PercentComplete value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Percent Complete : Type the percentage complete value for the task to track tasks to completion.</para>
 /// <para>MaxValue: 2147483647</para>
 /// <para>MinValue: -2147483648</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 PercentComplete.setValue(value);
};
this.PercentComplete.getValue = function () {
 ///<summary>
 /// Gets the PercentComplete value
 ///</summary>
 /// <returns type="Number">Type the percentage complete value for the task to track tasks to completion.</returns>
 return PercentComplete.getValue();
}
// PercentComplete END --------------------------------------------------------------


// PriorityCode START --------------------------------------------------------------
var PriorityCode = new Sdk.OptionSet("prioritycode");
  this.addAttribute(PriorityCode, false);
  /// <field name='PriorityCode' type='Sdk.OptionSet'>Priority : Select the priority so that preferred customers or critical issues are handled quickly.</field>
  this.PriorityCode = {};
 this.PriorityCode.setValue = function (value) {
  ///<summary><para>Sets the PriorityCode (Priority) value</para>
   /// <para>Select the priority so that preferred customers or critical issues are handled quickly.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 0 : Low</para>
/// <para> 1 : Normal</para>
/// <para> 2 : High</para>
   /// </param>
   PriorityCode.setValue(value);
  };
  this.PriorityCode.getValue = function () {
   ///<summary>Gets the PriorityCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the priority so that preferred customers or critical issues are handled quickly.</returns>
   return PriorityCode.getValue();
  }
// PriorityCode END --------------------------------------------------------------


// ProcessId START --------------------------------------------------------------
var ProcessId = new Sdk.Guid("processid");
this.addAttribute(ProcessId, false);
 /// <field name='ProcessId' type='Sdk.Guid'>Process : Shows the ID of the process.</field>
this.ProcessId = {};
this.ProcessId.setValue = function (value) {
 ///<summary><para>Sets the ProcessId (Process) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="String" mayBeNull="true" optional="false">Shows the ID of the process.</param>
ProcessId.setValue(value);
};
this.ProcessId.getValue = function () {
 ///<summary>Gets the ProcessId value</summary>
 /// <returns type="String" mayBeNull="true">Shows the ID of the process.</returns>
return ProcessId.getValue();
}
// ProcessId END --------------------------------------------------------------


// RegardingObjectId START --------------------------------------------------------------
var RegardingObjectId = new Sdk.Lookup("regardingobjectid");
this.addAttribute(RegardingObjectId, false);
/// <field name='RegardingObjectId' type='Sdk.Lookup'>Regarding : Unique identifier of the object with which the task is associated.</field>
this.RegardingObjectId = {};
this.RegardingObjectId.setValue = function (value) {
///<summary><para>Sets the RegardingObjectId value</para>
/// <para>Display Name: Regarding</para>
/// <para>Targets: account,campaign,campaignactivity,contact,contract,incident,invoice,lead,msdyn_postalbum,opportunity,quote,salesorder</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Unique identifier of the object with which the task is associated.</param>
 RegardingObjectId.setValue(value);
};
this.RegardingObjectId.getValue = function () {
 ///<summary>
 /// Gets the RegardingObjectId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Unique identifier of the object with which the task is associated.</returns>
 return RegardingObjectId.getValue();
}
// RegardingObjectId END --------------------------------------------------------------


// ScheduledDurationMinutes START --------------------------------------------------------------
var ScheduledDurationMinutes = new Sdk.Int("scheduleddurationminutes");
this.addAttribute(ScheduledDurationMinutes, false);
/// <field name='ScheduledDurationMinutes' type='Sdk.Int'>Scheduled Duration : Scheduled duration of the task, specified in minutes.</field>
this.ScheduledDurationMinutes = {};
this.ScheduledDurationMinutes.getValue = function () {
 ///<summary>
 /// Gets the ScheduledDurationMinutes value
 ///</summary>
 /// <returns type="Number">Scheduled duration of the task, specified in minutes.</returns>
 return ScheduledDurationMinutes.getValue();
}
// ScheduledDurationMinutes END --------------------------------------------------------------


// ScheduledEnd START --------------------------------------------------------------
var ScheduledEnd = new Sdk.DateTime("scheduledend");
this.addAttribute(ScheduledEnd, false);
/// <field name='ScheduledEnd' type='Sdk.DateTime'>Due Date : Enter the expected due date and time.</field>
this.ScheduledEnd = {};
this.ScheduledEnd.setValue = function (value) {
 ///<summary><para>Sets the ScheduledEnd (Due Date) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="Date" optional="false">Enter the expected due date and time.</param>
 ScheduledEnd.setValue(value);
};
this.ScheduledEnd.getValue = function () {
 ///<summary>
 /// Gets the ScheduledEnd value
 ///</summary>
 /// <returns type="Date">Enter the expected due date and time.</returns>
 return ScheduledEnd.getValue();
}
// ScheduledEnd END --------------------------------------------------------------


// ScheduledStart START --------------------------------------------------------------
var ScheduledStart = new Sdk.DateTime("scheduledstart");
this.addAttribute(ScheduledStart, false);
/// <field name='ScheduledStart' type='Sdk.DateTime'>Start Date : Enter the expected due date and time.</field>
this.ScheduledStart = {};
this.ScheduledStart.setValue = function (value) {
 ///<summary><para>Sets the ScheduledStart (Start Date) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="Date" optional="false">Enter the expected due date and time.</param>
 ScheduledStart.setValue(value);
};
this.ScheduledStart.getValue = function () {
 ///<summary>
 /// Gets the ScheduledStart value
 ///</summary>
 /// <returns type="Date">Enter the expected due date and time.</returns>
 return ScheduledStart.getValue();
}
// ScheduledStart END --------------------------------------------------------------


// ServiceId START --------------------------------------------------------------
var ServiceId = new Sdk.Lookup("serviceid");
this.addAttribute(ServiceId, false);
/// <field name='ServiceId' type='Sdk.Lookup'>Service : Choose the service that is associated with this activity.</field>
this.ServiceId = {};
this.ServiceId.setValue = function (value) {
///<summary><para>Sets the ServiceId value</para>
/// <para>Display Name: Service</para>
/// <para>Targets: service</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Choose the service that is associated with this activity.</param>
 ServiceId.setValue(value);
};
this.ServiceId.getValue = function () {
 ///<summary>
 /// Gets the ServiceId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Choose the service that is associated with this activity.</returns>
 return ServiceId.getValue();
}
// ServiceId END --------------------------------------------------------------


// StageId START --------------------------------------------------------------
var StageId = new Sdk.Guid("stageid");
this.addAttribute(StageId, false);
 /// <field name='StageId' type='Sdk.Guid'>Process Stage : Shows the ID of the stage.</field>
this.StageId = {};
this.StageId.setValue = function (value) {
 ///<summary><para>Sets the StageId (Process Stage) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="String" mayBeNull="true" optional="false">Shows the ID of the stage.</param>
StageId.setValue(value);
};
this.StageId.getValue = function () {
 ///<summary>Gets the StageId value</summary>
 /// <returns type="String" mayBeNull="true">Shows the ID of the stage.</returns>
return StageId.getValue();
}
// StageId END --------------------------------------------------------------


// StateCode START --------------------------------------------------------------
var StateCode = new Sdk.OptionSet("statecode");
  this.addAttribute(StateCode, false);
  /// <field name='StateCode' type='Sdk.OptionSet'>Activity Status : Shows whether the task is open, completed, or canceled. Completed and canceled tasks are read-only and can't be edited.</field>
  this.StateCode = {};
  this.StateCode.getValue = function () {
   ///<summary>Gets the StateCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Shows whether the task is open, completed, or canceled. Completed and canceled tasks are read-only and can't be edited.</returns>
   return StateCode.getValue();
  }
// StateCode END --------------------------------------------------------------


// StatusCode START --------------------------------------------------------------
var StatusCode = new Sdk.OptionSet("statuscode");
  this.addAttribute(StatusCode, false);
  /// <field name='StatusCode' type='Sdk.OptionSet'>Status Reason : Select the task's status.</field>
  this.StatusCode = {};
 this.StatusCode.setValue = function (value) {
  ///<summary><para>Sets the StatusCode (Status Reason) value</para>
   /// <para>Select the task's status.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 2 : Not Started State 0</para>
/// <para> 3 : In Progress State 0</para>
/// <para> 4 : Waiting on someone else State 0</para>
/// <para> 5 : Completed State 1</para>
/// <para> 6 : Canceled State 2</para>
/// <para> 7 : Deferred State 0</para>
   /// </param>
   StatusCode.setValue(value);
  };
  this.StatusCode.getValue = function () {
   ///<summary>Gets the StatusCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the task's status.</returns>
   return StatusCode.getValue();
  }
// StatusCode END --------------------------------------------------------------


// Subcategory START --------------------------------------------------------------
  var Subcategory = new Sdk.String("subcategory");
  this.addAttribute(Subcategory, false);
  /// <field name='Subcategory' type='Sdk.String'>Sub-Category : Type a subcategory to identify the task type and relate the activity to a specific product, sales region, business group, or other function.</field>
this.Subcategory = {};
  this.Subcategory.setValue = function (value) {
   ///<summary>Sets the Subcategory value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Sub-Category : Type a subcategory to identify the task type and relate the activity to a specific product, sales region, business group, or other function.</para>
   /// <para>MaxLength: 250</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Subcategory.setValue(value);
  };
  this.Subcategory.getValue = function () {
   ///<summary>
   /// Gets the Subcategory value
   ///</summary>
   /// <returns type="String">Type a subcategory to identify the task type and relate the activity to a specific product, sales region, business group, or other function.</returns>
   return Subcategory.getValue();
  }
// Subcategory END --------------------------------------------------------------


// Subject START --------------------------------------------------------------
  var Subject = new Sdk.String("subject");
  this.addAttribute(Subject, false);
  /// <field name='Subject' type='Sdk.String'>Subject : Type a short description about the objective or primary topic of the task.</field>
this.Subject = {};
  this.Subject.setValue = function (value) {
   ///<summary>Sets the Subject value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Subject : Type a short description about the objective or primary topic of the task.</para>
   /// <para>MaxLength: 200</para>
   /// <para>RequiredLevel: ApplicationRequired</para>
   /// </param>
   Subject.setValue(value);
  };
  this.Subject.getValue = function () {
   ///<summary>
   /// Gets the Subject value
   ///</summary>
   /// <returns type="String">Type a short description about the objective or primary topic of the task.</returns>
   return Subject.getValue();
  }
// Subject END --------------------------------------------------------------


// SubscriptionId START --------------------------------------------------------------
var SubscriptionId = new Sdk.Guid("subscriptionid");
this.addAttribute(SubscriptionId, false);
 /// <field name='SubscriptionId' type='Sdk.Guid'>Subscription : For internal use only.</field>
this.SubscriptionId = {};
this.SubscriptionId.setValue = function (value) {
 ///<summary><para>Sets the SubscriptionId (Subscription) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="String" mayBeNull="true" optional="false">For internal use only.</param>
SubscriptionId.setValue(value);
};
// SubscriptionId END --------------------------------------------------------------


// TimeZoneRuleVersionNumber START --------------------------------------------------------------
var TimeZoneRuleVersionNumber = new Sdk.Int("timezoneruleversionnumber");
this.addAttribute(TimeZoneRuleVersionNumber, false);
/// <field name='TimeZoneRuleVersionNumber' type='Sdk.Int'>Time Zone Rule Version Number : For internal use only.</field>
this.TimeZoneRuleVersionNumber = {};
this.TimeZoneRuleVersionNumber.setValue = function (value) {
 ///<summary>Sets the TimeZoneRuleVersionNumber value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Time Zone Rule Version Number : For internal use only.</para>
 /// <para>MaxValue: 2147483647</para>
 /// <para>MinValue: -2147483648</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 TimeZoneRuleVersionNumber.setValue(value);
};
this.TimeZoneRuleVersionNumber.getValue = function () {
 ///<summary>
 /// Gets the TimeZoneRuleVersionNumber value
 ///</summary>
 /// <returns type="Number">For internal use only.</returns>
 return TimeZoneRuleVersionNumber.getValue();
}
// TimeZoneRuleVersionNumber END --------------------------------------------------------------


// TransactionCurrencyId START --------------------------------------------------------------
var TransactionCurrencyId = new Sdk.Lookup("transactioncurrencyid");
this.addAttribute(TransactionCurrencyId, false);
/// <field name='TransactionCurrencyId' type='Sdk.Lookup'>Currency : Choose the local currency for the record to make sure budgets are reported in the correct currency.</field>
this.TransactionCurrencyId = {};
this.TransactionCurrencyId.setValue = function (value) {
///<summary><para>Sets the TransactionCurrencyId value</para>
/// <para>Display Name: Currency</para>
/// <para>Targets: transactioncurrency</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Choose the local currency for the record to make sure budgets are reported in the correct currency.</param>
 TransactionCurrencyId.setValue(value);
};
this.TransactionCurrencyId.getValue = function () {
 ///<summary>
 /// Gets the TransactionCurrencyId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Choose the local currency for the record to make sure budgets are reported in the correct currency.</returns>
 return TransactionCurrencyId.getValue();
}
// TransactionCurrencyId END --------------------------------------------------------------


// UTCConversionTimeZoneCode START --------------------------------------------------------------
var UTCConversionTimeZoneCode = new Sdk.Int("utcconversiontimezonecode");
this.addAttribute(UTCConversionTimeZoneCode, false);
/// <field name='UTCConversionTimeZoneCode' type='Sdk.Int'>UTC Conversion Time Zone Code : Time zone code that was in use when the record was created.</field>
this.UTCConversionTimeZoneCode = {};
this.UTCConversionTimeZoneCode.setValue = function (value) {
 ///<summary>Sets the UTCConversionTimeZoneCode value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>UTC Conversion Time Zone Code : Time zone code that was in use when the record was created.</para>
 /// <para>MaxValue: 2147483647</para>
 /// <para>MinValue: -2147483648</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 UTCConversionTimeZoneCode.setValue(value);
};
this.UTCConversionTimeZoneCode.getValue = function () {
 ///<summary>
 /// Gets the UTCConversionTimeZoneCode value
 ///</summary>
 /// <returns type="Number">Time zone code that was in use when the record was created.</returns>
 return UTCConversionTimeZoneCode.getValue();
}
// UTCConversionTimeZoneCode END --------------------------------------------------------------


// VersionNumber START --------------------------------------------------------------
var VersionNumber = new Sdk.Long("versionnumber");
this.addAttribute(VersionNumber, false);
/// <field name='VersionNumber' type='Sdk.Long'>Version Number : Version number of the task.</field>
this.VersionNumber = {};
this.VersionNumber.getValue = function () {
 ///<summary>
 /// Gets the VersionNumber value
 ///</summary>
 /// <returns type="Number">Version number of the task.</returns>
 return VersionNumber.getValue();
}
// VersionNumber END --------------------------------------------------------------

 };
}).call(Sdk)
Sdk.Task.prototype = new Sdk.Entity("task");

(function () {
 this.OneToMany = function () {
  /// <summary>Properties represent the string values of One-to-Many relationships for Sdk.Task</summary>
  /// <field name="task_activity_parties" type="String" static="true"> Entity: activityparty  Attribute: activityid</field>
  /// <field name="Task_Annotation" type="String" static="true"> Entity: annotation  Attribute: objectid</field>
  /// <field name="Task_AsyncOperations" type="String" static="true"> Entity: asyncoperation  Attribute: regardingobjectid</field>
  /// <field name="Task_BulkDeleteFailures" type="String" static="true"> Entity: bulkdeletefailure  Attribute: regardingobjectid</field>
  /// <field name="task_connections1" type="String" static="true"> Entity: connection  Attribute: record1id</field>
  /// <field name="task_connections2" type="String" static="true"> Entity: connection  Attribute: record2id</field>
  /// <field name="Task_DuplicateBaseRecord" type="String" static="true"> Entity: duplicaterecord  Attribute: baserecordid</field>
  /// <field name="Task_DuplicateMatchingRecord" type="String" static="true"> Entity: duplicaterecord  Attribute: duplicaterecordid</field>
  /// <field name="task_PostFollows" type="String" static="true"> Entity: postfollow  Attribute: regardingobjectid</field>
  /// <field name="task_PostRegardings" type="String" static="true"> Entity: postregarding  Attribute: regardingobjectid</field>
  /// <field name="task_PostRoles" type="String" static="true"> Entity: postrole  Attribute: regardingobjectid</field>
  /// <field name="task_principalobjectattributeaccess" type="String" static="true"> Entity: principalobjectattributeaccess  Attribute: objectid</field>
  /// <field name="Task_ProcessSessions" type="String" static="true"> Entity: processsession  Attribute: regardingobjectid</field>
  /// <field name="Task_QueueItem" type="String" static="true"> Entity: queueitem  Attribute: objectid</field>
  /// <field name="userentityinstancedata_task" type="String" static="true"> Entity: userentityinstancedata  Attribute: objectid</field>
  throw new Error("Constructor not implemented this is a static enum.");
}
 this.OneToMany.__enum = true;
 this.OneToMany.__flags = true;
}).call(Sdk.Task);

Sdk.Task.OneToMany.prototype = {
 task_activity_parties: "task_activity_parties",
 Task_Annotation: "Task_Annotation",
 Task_AsyncOperations: "Task_AsyncOperations",
 Task_BulkDeleteFailures: "Task_BulkDeleteFailures",
 task_connections1: "task_connections1",
 task_connections2: "task_connections2",
 Task_DuplicateBaseRecord: "Task_DuplicateBaseRecord",
 Task_DuplicateMatchingRecord: "Task_DuplicateMatchingRecord",
 task_PostFollows: "task_PostFollows",
 task_PostRegardings: "task_PostRegardings",
 task_PostRoles: "task_PostRoles",
 task_principalobjectattributeaccess: "task_principalobjectattributeaccess",
 Task_ProcessSessions: "Task_ProcessSessions",
 Task_QueueItem: "Task_QueueItem",
 userentityinstancedata_task: "userentityinstancedata_task"};

Sdk.Task.OneToMany.task_activity_parties = "task_activity_parties";
Sdk.Task.OneToMany.Task_Annotation = "Task_Annotation";
Sdk.Task.OneToMany.Task_AsyncOperations = "Task_AsyncOperations";
Sdk.Task.OneToMany.Task_BulkDeleteFailures = "Task_BulkDeleteFailures";
Sdk.Task.OneToMany.task_connections1 = "task_connections1";
Sdk.Task.OneToMany.task_connections2 = "task_connections2";
Sdk.Task.OneToMany.Task_DuplicateBaseRecord = "Task_DuplicateBaseRecord";
Sdk.Task.OneToMany.Task_DuplicateMatchingRecord = "Task_DuplicateMatchingRecord";
Sdk.Task.OneToMany.task_PostFollows = "task_PostFollows";
Sdk.Task.OneToMany.task_PostRegardings = "task_PostRegardings";
Sdk.Task.OneToMany.task_PostRoles = "task_PostRoles";
Sdk.Task.OneToMany.task_principalobjectattributeaccess = "task_principalobjectattributeaccess";
Sdk.Task.OneToMany.Task_ProcessSessions = "Task_ProcessSessions";
Sdk.Task.OneToMany.Task_QueueItem = "Task_QueueItem";
Sdk.Task.OneToMany.userentityinstancedata_task = "userentityinstancedata_task";
Sdk.Task.OneToMany.__enum = true;
Sdk.Task.OneToMany.__flags = true;
