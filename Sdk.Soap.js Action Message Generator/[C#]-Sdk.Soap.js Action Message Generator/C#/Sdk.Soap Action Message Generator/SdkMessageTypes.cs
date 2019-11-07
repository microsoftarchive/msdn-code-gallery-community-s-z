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

//------------------------------------------------------------------------------
//This code is the edited output of the Code Generation Tool (CrmSvcUtil.exe)
//This file contains only the entity definitions for entities included in
//this code. Nonessential entities and relationships have been removed.
//------------------------------------------------------------------------------

[assembly: Microsoft.Xrm.Sdk.Client.ProxyTypesAssemblyAttribute()]

/// <summary>
/// Message that is supported by the SDK.
/// </summary>
[System.Runtime.Serialization.DataContractAttribute()]
[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("sdkmessage")]
[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "6.0.0000.0809")]
public partial class SdkMessage : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{

 /// <summary>
 /// Default Constructor.
 /// </summary>
 public SdkMessage() :
  base(EntityLogicalName)
 {
 }

 public const string EntityLogicalName = "sdkmessage";

 public const int EntityTypeCode = 4606;

 public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

 public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

 private void OnPropertyChanged(string propertyName)
 {
  if ((this.PropertyChanged != null))
  {
   this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
  }
 }

 private void OnPropertyChanging(string propertyName)
 {
  if ((this.PropertyChanging != null))
  {
   this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
  }
 }

 /// <summary>
 /// Information about whether the SDK message is automatically transacted.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("autotransact")]
 public System.Nullable<bool> AutoTransact
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("autotransact");
  }
  set
  {
   this.OnPropertyChanging("AutoTransact");
   this.SetAttributeValue("autotransact", value);
   this.OnPropertyChanged("AutoTransact");
  }
 }

 /// <summary>
 /// Identifies where a method will be exposed. 0 - Server, 1 - Client, 2 - both.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("availability")]
 public System.Nullable<int> Availability
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("availability");
  }
  set
  {
   this.OnPropertyChanging("Availability");
   this.SetAttributeValue("availability", value);
   this.OnPropertyChanged("Availability");
  }
 }

 /// <summary>
 /// If this is a categorized method, this is the name, otherwise None.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("categoryname")]
 public string CategoryName
 {
  get
  {
   return this.GetAttributeValue<string>("categoryname");
  }
  set
  {
   this.OnPropertyChanging("CategoryName");
   this.SetAttributeValue("categoryname", value);
   this.OnPropertyChanged("CategoryName");
  }
 }

 /// <summary>
 /// Unique identifier of the user who created the SDK message.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
  }
 }

 /// <summary>
 /// Date and time when the SDK message was created.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
 public System.Nullable<System.DateTime> CreatedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who created the sdkmessage.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
  }
 }

 /// <summary>
 /// Customization level of the SDK message.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customizationlevel")]
 public System.Nullable<int> CustomizationLevel
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("customizationlevel");
  }
 }

 /// <summary>
 /// Indicates whether the SDK message should have its requests expanded per primary entity defined in its filters.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("expand")]
 public System.Nullable<bool> Expand
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("expand");
  }
  set
  {
   this.OnPropertyChanging("Expand");
   this.SetAttributeValue("expand", value);
   this.OnPropertyChanged("Expand");
  }
 }

 /// <summary>
 /// Information about whether the SDK message is active.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isactive")]
 public System.Nullable<bool> IsActive
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("isactive");
  }
  set
  {
   this.OnPropertyChanging("IsActive");
   this.SetAttributeValue("isactive", value);
   this.OnPropertyChanged("IsActive");
  }
 }

 /// <summary>
 /// Indicates whether the SDK message is private.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isprivate")]
 public System.Nullable<bool> IsPrivate
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("isprivate");
  }
  set
  {
   this.OnPropertyChanging("IsPrivate");
   this.SetAttributeValue("isprivate", value);
   this.OnPropertyChanged("IsPrivate");
  }
 }

 /// <summary>
 /// For internal use only.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isvalidforexecuteasync")]
 public System.Nullable<bool> IsValidForExecuteAsync
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("isvalidforexecuteasync");
  }
 }

 /// <summary>
 /// Unique identifier of the user who last modified the SDK message.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
  }
 }

 /// <summary>
 /// Date and time when the SDK message was last modified.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
 public System.Nullable<System.DateTime> ModifiedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who last modified the sdkmessage.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
  }
 }

 /// <summary>
 /// Name of the SDK message.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
 public string Name
 {
  get
  {
   return this.GetAttributeValue<string>("name");
  }
  set
  {
   this.OnPropertyChanging("Name");
   this.SetAttributeValue("name", value);
   this.OnPropertyChanged("Name");
  }
 }

 /// <summary>
 /// Unique identifier of the organization with which the SDK message is associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
 public Microsoft.Xrm.Sdk.EntityReference OrganizationId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
  }
 }

 /// <summary>
 /// Unique identifier of the SDK message entity.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageid")]
 public System.Nullable<System.Guid> SdkMessageId
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessageid");
  }
  set
  {
   this.OnPropertyChanging("SdkMessageId");
   this.SetAttributeValue("sdkmessageid", value);
   if (value.HasValue)
   {
    base.Id = value.Value;
   }
   else
   {
    base.Id = System.Guid.Empty;
   }
   this.OnPropertyChanged("SdkMessageId");
  }
 }

 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageid")]
 public override System.Guid Id
 {
  get
  {
   return base.Id;
  }
  set
  {
   this.SdkMessageId = value;
  }
 }

 /// <summary>
 /// Unique identifier of the SDK message.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageidunique")]
 public System.Nullable<System.Guid> SdkMessageIdUnique
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessageidunique");
  }
 }

 /// <summary>
 /// Indicates whether the SDK message is a template.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("template")]
 public System.Nullable<bool> Template
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("template");
  }
  set
  {
   this.OnPropertyChanging("Template");
   this.SetAttributeValue("template", value);
   this.OnPropertyChanged("Template");
  }
 }

 /// <summary>
 /// For internal use only.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("throttlesettings")]
 public string ThrottleSettings
 {
  get
  {
   return this.GetAttributeValue<string>("throttlesettings");
  }
 }

 /// <summary>
 /// Number that identifies a specific revision of the SDK message. 
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
 public System.Nullable<long> VersionNumber
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
  }
 }

 /// <summary>
 /// 1:N message_sdkmessagepair
 /// </summary>
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("message_sdkmessagepair")]
 public System.Collections.Generic.IEnumerable<SdkMessagePair> message_sdkmessagepair
 {
  get
  {
   return this.GetRelatedEntities<SdkMessagePair>("message_sdkmessagepair", null);
  }
  set
  {
   this.OnPropertyChanging("message_sdkmessagepair");
   this.SetRelatedEntities<SdkMessagePair>("message_sdkmessagepair", null, value);
   this.OnPropertyChanged("message_sdkmessagepair");
  }
 }

 /// <summary>
 /// 1:N sdkmessageid_sdkmessagefilter
 /// </summary>
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("sdkmessageid_sdkmessagefilter")]
 public System.Collections.Generic.IEnumerable<SdkMessageFilter> sdkmessageid_sdkmessagefilter
 {
  get
  {
   return this.GetRelatedEntities<SdkMessageFilter>("sdkmessageid_sdkmessagefilter", null);
  }
  set
  {
   this.OnPropertyChanging("sdkmessageid_sdkmessagefilter");
   this.SetRelatedEntities<SdkMessageFilter>("sdkmessageid_sdkmessagefilter", null, value);
   this.OnPropertyChanged("sdkmessageid_sdkmessagefilter");
  }
 }

}

/// <summary>
/// Filter that defines which SDK messages are valid for each type of entity.
/// </summary>
[System.Runtime.Serialization.DataContractAttribute()]
[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("sdkmessagefilter")]
[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "6.0.0000.0809")]
public partial class SdkMessageFilter : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{

 /// <summary>
 /// Default Constructor.
 /// </summary>
 public SdkMessageFilter() :
  base(EntityLogicalName)
 {
 }

 public const string EntityLogicalName = "sdkmessagefilter";

 public const int EntityTypeCode = 4607;

 public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

 public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

 private void OnPropertyChanged(string propertyName)
 {
  if ((this.PropertyChanged != null))
  {
   this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
  }
 }

 private void OnPropertyChanging(string propertyName)
 {
  if ((this.PropertyChanging != null))
  {
   this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
  }
 }

 /// <summary>
 /// Identifies where a method will be exposed. 0 - Server, 1 - Client, 2 - both.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("availability")]
 public System.Nullable<int> Availability
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("availability");
  }
  set
  {
   this.OnPropertyChanging("Availability");
   this.SetAttributeValue("availability", value);
   this.OnPropertyChanged("Availability");
  }
 }

 /// <summary>
 /// Unique identifier of the user who created the SDK message filter.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
  }
 }

 /// <summary>
 /// Date and time when the SDK message filter was created.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
 public System.Nullable<System.DateTime> CreatedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who created the sdkmessagefilter.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
  }
 }

 /// <summary>
 /// Customization level of the SDK message filter.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customizationlevel")]
 public System.Nullable<int> CustomizationLevel
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("customizationlevel");
  }
 }

 /// <summary>
 /// Indicates whether a custom SDK message processing step is allowed.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("iscustomprocessingstepallowed")]
 public System.Nullable<bool> IsCustomProcessingStepAllowed
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("iscustomprocessingstepallowed");
  }
  set
  {
   this.OnPropertyChanging("IsCustomProcessingStepAllowed");
   this.SetAttributeValue("iscustomprocessingstepallowed", value);
   this.OnPropertyChanged("IsCustomProcessingStepAllowed");
  }
 }

 /// <summary>
 /// Indicates whether the filter should be visible.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isvisible")]
 public System.Nullable<bool> IsVisible
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("isvisible");
  }
 }

 /// <summary>
 /// Unique identifier of the user who last modified the SDK message filter.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
  }
 }

 /// <summary>
 /// Date and time when the SDK message filter was last modified.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
 public System.Nullable<System.DateTime> ModifiedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who last modified the sdkmessagefilter.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
  }
 }

 /// <summary>
 /// Unique identifier of the organization with which the SDK message filter is associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
 public Microsoft.Xrm.Sdk.EntityReference OrganizationId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
  }
 }

 /// <summary>
 /// Type of entity with which the SDK message filter is primarily associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("primaryobjecttypecode")]
 public string PrimaryObjectTypeCode
 {
  get
  {
   return this.GetAttributeValue<string>("primaryobjecttypecode");
  }
 }

 /// <summary>
 /// Unique identifier of the SDK message filter entity.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagefilterid")]
 public System.Nullable<System.Guid> SdkMessageFilterId
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessagefilterid");
  }
  set
  {
   this.OnPropertyChanging("SdkMessageFilterId");
   this.SetAttributeValue("sdkmessagefilterid", value);
   if (value.HasValue)
   {
    base.Id = value.Value;
   }
   else
   {
    base.Id = System.Guid.Empty;
   }
   this.OnPropertyChanged("SdkMessageFilterId");
  }
 }

 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagefilterid")]
 public override System.Guid Id
 {
  get
  {
   return base.Id;
  }
  set
  {
   this.SdkMessageFilterId = value;
  }
 }

 /// <summary>
 /// Unique identifier of the SDK message filter.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagefilteridunique")]
 public System.Nullable<System.Guid> SdkMessageFilterIdUnique
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessagefilteridunique");
  }
 }

 /// <summary>
 /// Unique identifier of the related SDK message.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageid")]
 public Microsoft.Xrm.Sdk.EntityReference SdkMessageId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("sdkmessageid");
  }
  set
  {
   this.OnPropertyChanging("SdkMessageId");
   this.SetAttributeValue("sdkmessageid", value);
   this.OnPropertyChanged("SdkMessageId");
  }
 }

 /// <summary>
 /// Type of entity with which the SDK message filter is secondarily associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("secondaryobjecttypecode")]
 public string SecondaryObjectTypeCode
 {
  get
  {
   return this.GetAttributeValue<string>("secondaryobjecttypecode");
  }
 }

 /// <summary>
 /// 
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
 public System.Nullable<long> VersionNumber
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
  }
 }





 /// <summary>
 /// N:1 sdkmessageid_sdkmessagefilter
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageid")]
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("sdkmessageid_sdkmessagefilter")]
 public SdkMessage sdkmessageid_sdkmessagefilter
 {
  get
  {
   return this.GetRelatedEntity<SdkMessage>("sdkmessageid_sdkmessagefilter", null);
  }
  set
  {
   this.OnPropertyChanging("sdkmessageid_sdkmessagefilter");
   this.SetRelatedEntity<SdkMessage>("sdkmessageid_sdkmessagefilter", null, value);
   this.OnPropertyChanged("sdkmessageid_sdkmessagefilter");
  }
 }
}

/// <summary>
/// For internal use only.
/// </summary>
[System.Runtime.Serialization.DataContractAttribute()]
[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("sdkmessagepair")]
[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "6.0.0000.0809")]
public partial class SdkMessagePair : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{

 /// <summary>
 /// Default Constructor.
 /// </summary>
 public SdkMessagePair() :
  base(EntityLogicalName)
 {
 }

 public const string EntityLogicalName = "sdkmessagepair";

 public const int EntityTypeCode = 4613;

 public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

 public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

 private void OnPropertyChanged(string propertyName)
 {
  if ((this.PropertyChanged != null))
  {
   this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
  }
 }

 private void OnPropertyChanging(string propertyName)
 {
  if ((this.PropertyChanging != null))
  {
   this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
  }
 }

 /// <summary>
 /// Unique identifier of the user who created the SDK message pair.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
  }
 }

 /// <summary>
 /// Date and time when the SDK message pair was created.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
 public System.Nullable<System.DateTime> CreatedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who created the sdkmessagepair.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
  }
 }

 /// <summary>
 /// Customization level of the SDK message filter.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customizationlevel")]
 public System.Nullable<int> CustomizationLevel
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("customizationlevel");
  }
 }

 /// <summary>
 /// Endpoint that the message pair is associated with.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("endpoint")]
 public string Endpoint
 {
  get
  {
   return this.GetAttributeValue<string>("endpoint");
  }
  set
  {
   this.OnPropertyChanging("Endpoint");
   this.SetAttributeValue("endpoint", value);
   this.OnPropertyChanged("Endpoint");
  }
 }

 /// <summary>
 /// Unique identifier of the user who last modified the SDK message pair.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
  }
 }

 /// <summary>
 /// Date and time when the SDK message pair was last modified.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
 public System.Nullable<System.DateTime> ModifiedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who last modified the sdkmessagepair.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
  }
 }

 /// <summary>
 /// Namespace that the message pair is associated with.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("namespace")]
 public string Namespace
 {
  get
  {
   return this.GetAttributeValue<string>("namespace");
  }
  set
  {
   this.OnPropertyChanging("Namespace");
   this.SetAttributeValue("namespace", value);
   this.OnPropertyChanged("Namespace");
  }
 }

 /// <summary>
 /// Unique identifier of the organization with which the SDK message pair is associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
 public Microsoft.Xrm.Sdk.EntityReference OrganizationId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
  }
 }

 /// <summary>
 /// Unique identifier of the message with which the SDK message pair is associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageid")]
 public Microsoft.Xrm.Sdk.EntityReference SdkMessageId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("sdkmessageid");
  }
 }

 /// <summary>
 /// Unique identifier of the SDK message pair entity.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagepairid")]
 public System.Nullable<System.Guid> SdkMessagePairId
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessagepairid");
  }
  set
  {
   this.OnPropertyChanging("SdkMessagePairId");
   this.SetAttributeValue("sdkmessagepairid", value);
   if (value.HasValue)
   {
    base.Id = value.Value;
   }
   else
   {
    base.Id = System.Guid.Empty;
   }
   this.OnPropertyChanged("SdkMessagePairId");
  }
 }

 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagepairid")]
 public override System.Guid Id
 {
  get
  {
   return base.Id;
  }
  set
  {
   this.SdkMessagePairId = value;
  }
 }

 /// <summary>
 /// Unique identifier of the SDK message pair.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagepairidunique")]
 public System.Nullable<System.Guid> SdkMessagePairIdUnique
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessagepairidunique");
  }
 }

 /// <summary>
 /// For internal use only.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
 public System.Nullable<long> VersionNumber
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
  }
 }

 /// <summary>
 /// 1:N messagepair_sdkmessagerequest
 /// </summary>
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("messagepair_sdkmessagerequest")]
 public System.Collections.Generic.IEnumerable<SdkMessageRequest> messagepair_sdkmessagerequest
 {
  get
  {
   return this.GetRelatedEntities<SdkMessageRequest>("messagepair_sdkmessagerequest", null);
  }
  set
  {
   this.OnPropertyChanging("messagepair_sdkmessagerequest");
   this.SetRelatedEntities<SdkMessageRequest>("messagepair_sdkmessagerequest", null, value);
   this.OnPropertyChanged("messagepair_sdkmessagerequest");
  }
 }







 /// <summary>
 /// N:1 message_sdkmessagepair
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageid")]
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("message_sdkmessagepair")]
 public SdkMessage message_sdkmessagepair
 {
  get
  {
   return this.GetRelatedEntity<SdkMessage>("message_sdkmessagepair", null);
  }
 }


}


/// <summary>
/// For internal use only.
/// </summary>
[System.Runtime.Serialization.DataContractAttribute()]
[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("sdkmessagerequest")]
[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "6.0.0000.0809")]
public partial class SdkMessageRequest : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{

 /// <summary>
 /// Default Constructor.
 /// </summary>
 public SdkMessageRequest() :
  base(EntityLogicalName)
 {
 }

 public const string EntityLogicalName = "sdkmessagerequest";

 public const int EntityTypeCode = 4609;

 public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

 public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

 private void OnPropertyChanged(string propertyName)
 {
  if ((this.PropertyChanged != null))
  {
   this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
  }
 }

 private void OnPropertyChanging(string propertyName)
 {
  if ((this.PropertyChanging != null))
  {
   this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
  }
 }

 /// <summary>
 /// Unique identifier of the user who created the SDK message request.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
  }
 }

 /// <summary>
 /// Date and time when the SDK message request was created.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
 public System.Nullable<System.DateTime> CreatedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who created the sdkmessagerequest.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
  }
 }

 /// <summary>
 /// Customization level of the SDK message request.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customizationlevel")]
 public System.Nullable<int> CustomizationLevel
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("customizationlevel");
  }
 }

 /// <summary>
 /// Unique identifier of the user who last modified the SDK message request.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
  }
 }

 /// <summary>
 /// Date and time when the SDK message request was last modified.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
 public System.Nullable<System.DateTime> ModifiedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who last modified the sdkmessagerequest.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
  }
 }

 /// <summary>
 /// Name of the SDK message request.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
 public string Name
 {
  get
  {
   return this.GetAttributeValue<string>("name");
  }
  set
  {
   this.OnPropertyChanging("Name");
   this.SetAttributeValue("name", value);
   this.OnPropertyChanged("Name");
  }
 }

 /// <summary>
 /// Unique identifier of the organization with which the SDK message request is associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
 public Microsoft.Xrm.Sdk.EntityReference OrganizationId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
  }
 }

 /// <summary>
 /// Type of entity with which the SDK request is associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("primaryobjecttypecode")]
 public string PrimaryObjectTypeCode
 {
  get
  {
   return this.GetAttributeValue<string>("primaryobjecttypecode");
  }
 }

 /// <summary>
 /// Unique identifier of the message pair with which the SDK message request is associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagepairid")]
 public Microsoft.Xrm.Sdk.EntityReference SdkMessagePairId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("sdkmessagepairid");
  }
 }

 /// <summary>
 /// Unique identifier of the SDK message request entity.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagerequestid")]
 public System.Nullable<System.Guid> SdkMessageRequestId
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessagerequestid");
  }
  set
  {
   this.OnPropertyChanging("SdkMessageRequestId");
   this.SetAttributeValue("sdkmessagerequestid", value);
   if (value.HasValue)
   {
    base.Id = value.Value;
   }
   else
   {
    base.Id = System.Guid.Empty;
   }
   this.OnPropertyChanged("SdkMessageRequestId");
  }
 }

 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagerequestid")]
 public override System.Guid Id
 {
  get
  {
   return base.Id;
  }
  set
  {
   this.SdkMessageRequestId = value;
  }
 }

 /// <summary>
 /// Unique identifier of the SDK message request.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagerequestidunique")]
 public System.Nullable<System.Guid> SdkMessageRequestIdUnique
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessagerequestidunique");
  }
 }

 /// <summary>
 /// 
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
 public System.Nullable<long> VersionNumber
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
  }
 }

 /// <summary>
 /// 1:N messagerequest_sdkmessagerequestfield
 /// </summary>
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("messagerequest_sdkmessagerequestfield")]
 public System.Collections.Generic.IEnumerable<SdkMessageRequestField> messagerequest_sdkmessagerequestfield
 {
  get
  {
   return this.GetRelatedEntities<SdkMessageRequestField>("messagerequest_sdkmessagerequestfield", null);
  }
  set
  {
   this.OnPropertyChanging("messagerequest_sdkmessagerequestfield");
   this.SetRelatedEntities<SdkMessageRequestField>("messagerequest_sdkmessagerequestfield", null, value);
   this.OnPropertyChanged("messagerequest_sdkmessagerequestfield");
  }
 }

 /// <summary>
 /// 1:N messagerequest_sdkmessageresponse
 /// </summary>
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("messagerequest_sdkmessageresponse")]
 public System.Collections.Generic.IEnumerable<SdkMessageResponse> messagerequest_sdkmessageresponse
 {
  get
  {
   return this.GetRelatedEntities<SdkMessageResponse>("messagerequest_sdkmessageresponse", null);
  }
  set
  {
   this.OnPropertyChanging("messagerequest_sdkmessageresponse");
   this.SetRelatedEntities<SdkMessageResponse>("messagerequest_sdkmessageresponse", null, value);
   this.OnPropertyChanged("messagerequest_sdkmessageresponse");
  }
 }




 /// <summary>
 /// N:1 messagepair_sdkmessagerequest
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagepairid")]
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("messagepair_sdkmessagerequest")]
 public SdkMessagePair messagepair_sdkmessagerequest
 {
  get
  {
   return this.GetRelatedEntity<SdkMessagePair>("messagepair_sdkmessagerequest", null);
  }
 }




}

/// <summary>
/// For internal use only.
/// </summary>
[System.Runtime.Serialization.DataContractAttribute()]
[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("sdkmessagerequestfield")]
[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "6.0.0000.0809")]
public partial class SdkMessageRequestField : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{

 /// <summary>
 /// Default Constructor.
 /// </summary>
 public SdkMessageRequestField() :
  base(EntityLogicalName)
 {
 }

 public const string EntityLogicalName = "sdkmessagerequestfield";

 public const int EntityTypeCode = 4614;

 public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

 public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

 private void OnPropertyChanged(string propertyName)
 {
  if ((this.PropertyChanged != null))
  {
   this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
  }
 }

 private void OnPropertyChanging(string propertyName)
 {
  if ((this.PropertyChanging != null))
  {
   this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
  }
 }

 /// <summary>
 /// Common language runtime (CLR)-based parser for the SDK message request field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("clrparser")]
 public string ClrParser
 {
  get
  {
   return this.GetAttributeValue<string>("clrparser");
  }
  set
  {
   this.OnPropertyChanging("ClrParser");
   this.SetAttributeValue("clrparser", value);
   this.OnPropertyChanged("ClrParser");
  }
 }

 /// <summary>
 /// Unique identifier of the user who created the SDK message request field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
  }
 }

 /// <summary>
 /// Date and time when the SDK message request field was created.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
 public System.Nullable<System.DateTime> CreatedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who created the sdkmessagerequestfield.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
  }
 }

 /// <summary>
 /// Customization level of the SDK message request field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customizationlevel")]
 public System.Nullable<int> CustomizationLevel
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("customizationlevel");
  }
 }

 /// <summary>
 /// Indicates how field contents are used during message processing. 1 - Primary entity, 2- Secondary entity
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fieldmask")]
 public System.Nullable<int> FieldMask
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("fieldmask");
  }
 }

 /// <summary>
 /// Unique identifier of the user who last modified the SDK message request field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
  }
 }

 /// <summary>
 /// Date and time when the SDK message request field was last modified.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
 public System.Nullable<System.DateTime> ModifiedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who last modified the sdkmessagerequestfield.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
  }
 }

 /// <summary>
 /// Name of the SDK message request field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
 public string Name
 {
  get
  {
   return this.GetAttributeValue<string>("name");
  }
  set
  {
   this.OnPropertyChanging("Name");
   this.SetAttributeValue("name", value);
   this.OnPropertyChanged("Name");
  }
 }

 /// <summary>
 /// Information about whether SDK message request field is optional.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("optional")]
 public System.Nullable<bool> Optional
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("optional");
  }
  set
  {
   this.OnPropertyChanging("Optional");
   this.SetAttributeValue("optional", value);
   this.OnPropertyChanged("Optional");
  }
 }

 /// <summary>
 /// Unique identifier of the organization with which the SDK message request field is associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
 public Microsoft.Xrm.Sdk.EntityReference OrganizationId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
  }
 }

 /// <summary>
 /// Parser for the SDK message request field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parser")]
 public string Parser
 {
  get
  {
   return this.GetAttributeValue<string>("parser");
  }
  set
  {
   this.OnPropertyChanging("Parser");
   this.SetAttributeValue("parser", value);
   this.OnPropertyChanged("Parser");
  }
 }

 /// <summary>
 /// Position of the Sdk message request field
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("position")]
 public System.Nullable<int> Position
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("position");
  }
 }

 /// <summary>
 /// Public name of the SDK message request field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("publicname")]
 public string PublicName
 {
  get
  {
   return this.GetAttributeValue<string>("publicname");
  }
  set
  {
   this.OnPropertyChanging("PublicName");
   this.SetAttributeValue("publicname", value);
   this.OnPropertyChanged("PublicName");
  }
 }

 /// <summary>
 /// Unique identifier of the SDK message request field entity.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagerequestfieldid")]
 public System.Nullable<System.Guid> SdkMessageRequestFieldId
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessagerequestfieldid");
  }
  set
  {
   this.OnPropertyChanging("SdkMessageRequestFieldId");
   this.SetAttributeValue("sdkmessagerequestfieldid", value);
   if (value.HasValue)
   {
    base.Id = value.Value;
   }
   else
   {
    base.Id = System.Guid.Empty;
   }
   this.OnPropertyChanged("SdkMessageRequestFieldId");
  }
 }

 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagerequestfieldid")]
 public override System.Guid Id
 {
  get
  {
   return base.Id;
  }
  set
  {
   this.SdkMessageRequestFieldId = value;
  }
 }

 /// <summary>
 /// Entity identifier of the SDK message request field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagerequestfieldidunique")]
 public System.Nullable<System.Guid> SdkMessageRequestFieldIdUnique
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessagerequestfieldidunique");
  }
 }

 /// <summary>
 /// Unique identifier of the message request with which the SDK message request field is associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagerequestid")]
 public Microsoft.Xrm.Sdk.EntityReference SdkMessageRequestId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("sdkmessagerequestid");
  }
 }

 /// <summary>
 /// For internal use only.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
 public System.Nullable<long> VersionNumber
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
  }
 }



 /// <summary>
 /// N:1 messagerequest_sdkmessagerequestfield
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagerequestid")]
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("messagerequest_sdkmessagerequestfield")]
 public SdkMessageRequest messagerequest_sdkmessagerequestfield
 {
  get
  {
   return this.GetRelatedEntity<SdkMessageRequest>("messagerequest_sdkmessagerequestfield", null);
  }
 }


}

/// <summary>
/// For internal use only.
/// </summary>
[System.Runtime.Serialization.DataContractAttribute()]
[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("sdkmessageresponse")]
[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "6.0.0000.0809")]
public partial class SdkMessageResponse : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{

 /// <summary>
 /// Default Constructor.
 /// </summary>
 public SdkMessageResponse() :
  base(EntityLogicalName)
 {
 }

 public const string EntityLogicalName = "sdkmessageresponse";

 public const int EntityTypeCode = 4610;

 public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

 public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

 private void OnPropertyChanged(string propertyName)
 {
  if ((this.PropertyChanged != null))
  {
   this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
  }
 }

 private void OnPropertyChanging(string propertyName)
 {
  if ((this.PropertyChanging != null))
  {
   this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
  }
 }

 /// <summary>
 /// Unique identifier of the user who created the SDK message response.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
  }
 }

 /// <summary>
 /// Date and time when the SDK message response was created.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
 public System.Nullable<System.DateTime> CreatedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who created the sdkmessageresponse.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
  }
 }

 /// <summary>
 /// Customization level of the SDK message response.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customizationlevel")]
 public System.Nullable<int> CustomizationLevel
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("customizationlevel");
  }
 }

 /// <summary>
 /// Unique identifier of the user who last modified the SDK message response.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
  }
 }

 /// <summary>
 /// Date and time when the SDK message response was last modified.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
 public System.Nullable<System.DateTime> ModifiedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who last modified the sdkmessageresponse.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
  }
 }

 /// <summary>
 /// Unique identifier of the organization with which the SDK message response is associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
 public Microsoft.Xrm.Sdk.EntityReference OrganizationId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
  }
 }

 /// <summary>
 /// Unique identifier of the message request with which the SDK message response is associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagerequestid")]
 public Microsoft.Xrm.Sdk.EntityReference SdkMessageRequestId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("sdkmessagerequestid");
  }
 }

 /// <summary>
 /// Unique identifier of the SDK message response entity.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageresponseid")]
 public System.Nullable<System.Guid> SdkMessageResponseId
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessageresponseid");
  }
  set
  {
   this.OnPropertyChanging("SdkMessageResponseId");
   this.SetAttributeValue("sdkmessageresponseid", value);
   if (value.HasValue)
   {
    base.Id = value.Value;
   }
   else
   {
    base.Id = System.Guid.Empty;
   }
   this.OnPropertyChanged("SdkMessageResponseId");
  }
 }

 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageresponseid")]
 public override System.Guid Id
 {
  get
  {
   return base.Id;
  }
  set
  {
   this.SdkMessageResponseId = value;
  }
 }

 /// <summary>
 /// Unique identifier of the SDK message response.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageresponseidunique")]
 public System.Nullable<System.Guid> SdkMessageResponseIdUnique
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessageresponseidunique");
  }
 }

 /// <summary>
 /// 
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
 public System.Nullable<long> VersionNumber
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
  }
 }

 /// <summary>
 /// 1:N messageresponse_sdkmessageresponsefield
 /// </summary>
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("messageresponse_sdkmessageresponsefield")]
 public System.Collections.Generic.IEnumerable<SdkMessageResponseField> messageresponse_sdkmessageresponsefield
 {
  get
  {
   return this.GetRelatedEntities<SdkMessageResponseField>("messageresponse_sdkmessageresponsefield", null);
  }
  set
  {
   this.OnPropertyChanging("messageresponse_sdkmessageresponsefield");
   this.SetRelatedEntities<SdkMessageResponseField>("messageresponse_sdkmessageresponsefield", null, value);
   this.OnPropertyChanged("messageresponse_sdkmessageresponsefield");
  }
 }



 /// <summary>
 /// N:1 messagerequest_sdkmessageresponse
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagerequestid")]
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("messagerequest_sdkmessageresponse")]
 public SdkMessageRequest messagerequest_sdkmessageresponse
 {
  get
  {
   return this.GetRelatedEntity<SdkMessageRequest>("messagerequest_sdkmessageresponse", null);
  }
 }


}

/// <summary>
/// For internal use only.
/// </summary>
[System.Runtime.Serialization.DataContractAttribute()]
[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("sdkmessageresponsefield")]
[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "6.0.0000.0809")]
public partial class SdkMessageResponseField : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{

 /// <summary>
 /// Default Constructor.
 /// </summary>
 public SdkMessageResponseField() :
  base(EntityLogicalName)
 {
 }

 public const string EntityLogicalName = "sdkmessageresponsefield";

 public const int EntityTypeCode = 4611;

 public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

 public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

 private void OnPropertyChanged(string propertyName)
 {
  if ((this.PropertyChanged != null))
  {
   this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
  }
 }

 private void OnPropertyChanging(string propertyName)
 {
  if ((this.PropertyChanging != null))
  {
   this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
  }
 }

 /// <summary>
 /// Common language runtime (CLR)-based formatter of the SDK message response field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("clrformatter")]
 public string ClrFormatter
 {
  get
  {
   return this.GetAttributeValue<string>("clrformatter");
  }
  set
  {
   this.OnPropertyChanging("ClrFormatter");
   this.SetAttributeValue("clrformatter", value);
   this.OnPropertyChanged("ClrFormatter");
  }
 }

 /// <summary>
 /// Unique identifier of the user who created the SDK message response field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
  }
 }

 /// <summary>
 /// Date and time when the SDK message response field was created.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
 public System.Nullable<System.DateTime> CreatedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who created the sdkmessageresponsefield.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
  }
 }

 /// <summary>
 /// Customization level of the SDK message response field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customizationlevel")]
 public System.Nullable<int> CustomizationLevel
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("customizationlevel");
  }
 }

 /// <summary>
 /// Formatter for the SDK message response field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("formatter")]
 public string Formatter
 {
  get
  {
   return this.GetAttributeValue<string>("formatter");
  }
  set
  {
   this.OnPropertyChanging("Formatter");
   this.SetAttributeValue("formatter", value);
   this.OnPropertyChanged("Formatter");
  }
 }

 /// <summary>
 /// Unique identifier of the user who last modified the SDK message response field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
  }
 }

 /// <summary>
 /// Date and time when the SDK message response field was last modified.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
 public System.Nullable<System.DateTime> ModifiedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who last modified the sdkmessageresponsefield.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
  }
 }

 /// <summary>
 /// Name of the SDK message response field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
 public string Name
 {
  get
  {
   return this.GetAttributeValue<string>("name");
  }
  set
  {
   this.OnPropertyChanging("Name");
   this.SetAttributeValue("name", value);
   this.OnPropertyChanged("Name");
  }
 }

 /// <summary>
 /// Unique identifier of the organization with which the SDK message response field is associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
 public Microsoft.Xrm.Sdk.EntityReference OrganizationId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
  }
 }

 /// <summary>
 /// Position of the Sdk message response field
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("position")]
 public System.Nullable<int> Position
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("position");
  }
 }

 /// <summary>
 /// Public name of the SDK message response field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("publicname")]
 public string PublicName
 {
  get
  {
   return this.GetAttributeValue<string>("publicname");
  }
  set
  {
   this.OnPropertyChanging("PublicName");
   this.SetAttributeValue("publicname", value);
   this.OnPropertyChanged("PublicName");
  }
 }

 /// <summary>
 /// Unique identifier of the SDK message response field entity.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageresponsefieldid")]
 public System.Nullable<System.Guid> SdkMessageResponseFieldId
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessageresponsefieldid");
  }
  set
  {
   this.OnPropertyChanging("SdkMessageResponseFieldId");
   this.SetAttributeValue("sdkmessageresponsefieldid", value);
   if (value.HasValue)
   {
    base.Id = value.Value;
   }
   else
   {
    base.Id = System.Guid.Empty;
   }
   this.OnPropertyChanged("SdkMessageResponseFieldId");
  }
 }

 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageresponsefieldid")]
 public override System.Guid Id
 {
  get
  {
   return base.Id;
  }
  set
  {
   this.SdkMessageResponseFieldId = value;
  }
 }

 /// <summary>
 /// Unique identifier of the SDK message response field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageresponsefieldidunique")]
 public System.Nullable<System.Guid> SdkMessageResponseFieldIdUnique
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessageresponsefieldidunique");
  }
 }

 /// <summary>
 /// Unique identifier of the message response with which the SDK message response field is associated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageresponseid")]
 public Microsoft.Xrm.Sdk.EntityReference SdkMessageResponseId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("sdkmessageresponseid");
  }
 }

 /// <summary>
 /// Actual value of the SDK message response field.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("value")]
 public string Value
 {
  get
  {
   return this.GetAttributeValue<string>("value");
  }
  set
  {
   this.OnPropertyChanging("Value");
   this.SetAttributeValue("value", value);
   this.OnPropertyChanged("Value");
  }
 }

 /// <summary>
 /// For internal use only.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
 public System.Nullable<long> VersionNumber
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
  }
 }



 


 /// <summary>
 /// N:1 messageresponse_sdkmessageresponsefield
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageresponseid")]
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("messageresponse_sdkmessageresponsefield")]
 public SdkMessageResponse messageresponse_sdkmessageresponsefield
 {
  get
  {
   return this.GetRelatedEntity<SdkMessageResponse>("messageresponse_sdkmessageresponsefield", null);
  }
 }


}

/// <summary>
/// Set of logical rules that define the steps necessary to automate a specific business process, task, or set of actions to be performed.
/// </summary>
[System.Runtime.Serialization.DataContractAttribute()]
[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("workflow")]
[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "6.0.0000.0809")]
public partial class Workflow : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{

 /// <summary>
 /// Default Constructor.
 /// </summary>
 public Workflow() :
  base(EntityLogicalName)
 {
 }

 public const string EntityLogicalName = "workflow";

 public const int EntityTypeCode = 4703;

 public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

 public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

 private void OnPropertyChanged(string propertyName)
 {
  if ((this.PropertyChanged != null))
  {
   this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
  }
 }

 private void OnPropertyChanging(string propertyName)
 {
  if ((this.PropertyChanging != null))
  {
   this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
  }
 }

 /// <summary>
 /// Unique identifier of the latest activation record for the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activeworkflowid")]
 public Microsoft.Xrm.Sdk.EntityReference ActiveWorkflowId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("activeworkflowid");
  }
 }

 /// <summary>
 /// Indicates whether the asynchronous system job is automatically deleted on completion.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("asyncautodelete")]
 public System.Nullable<bool> AsyncAutoDelete
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("asyncautodelete");
  }
  set
  {
   this.OnPropertyChanging("AsyncAutoDelete");
   this.SetAttributeValue("asyncautodelete", value);
   this.OnPropertyChanged("AsyncAutoDelete");
  }
 }

 /// <summary>
 /// Category of the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("category")]
 public Microsoft.Xrm.Sdk.OptionSetValue Category
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("category");
  }
  set
  {
   this.OnPropertyChanging("Category");
   this.SetAttributeValue("category", value);
   this.OnPropertyChanged("Category");
  }
 }

 /// <summary>
 /// Business logic converted into client data
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("clientdata")]
 public string ClientData
 {
  get
  {
   return this.GetAttributeValue<string>("clientdata");
  }
 }

 /// <summary>
 /// For internal use only.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("componentstate")]
 public Microsoft.Xrm.Sdk.OptionSetValue ComponentState
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("componentstate");
  }
 }

 /// <summary>
 /// Unique identifier of the user who created the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
  }
 }

 /// <summary>
 /// Date and time when the process was created.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
 public System.Nullable<System.DateTime> CreatedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who created the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
  }
 }

 /// <summary>
 /// Stage of the process when triggered on Create.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createstage")]
 public Microsoft.Xrm.Sdk.OptionSetValue CreateStage
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("createstage");
  }
  set
  {
   this.OnPropertyChanging("CreateStage");
   this.SetAttributeValue("createstage", value);
   this.OnPropertyChanged("CreateStage");
  }
 }

 /// <summary>
 /// Stage of the process when triggered on Delete.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("deletestage")]
 public Microsoft.Xrm.Sdk.OptionSetValue DeleteStage
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("deletestage");
  }
  set
  {
   this.OnPropertyChanging("DeleteStage");
   this.SetAttributeValue("deletestage", value);
   this.OnPropertyChanged("DeleteStage");
  }
 }

 /// <summary>
 /// Description of the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
 public string Description
 {
  get
  {
   return this.GetAttributeValue<string>("description");
  }
  set
  {
   this.OnPropertyChanging("Description");
   this.SetAttributeValue("description", value);
   this.OnPropertyChanged("Description");
  }
 }

 /// <summary>
 /// Input parameters to the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("inputparameters")]
 public string InputParameters
 {
  get
  {
   return this.GetAttributeValue<string>("inputparameters");
  }
  set
  {
   this.OnPropertyChanging("InputParameters");
   this.SetAttributeValue("inputparameters", value);
   this.OnPropertyChanged("InputParameters");
  }
 }

 /// <summary>
 /// Version in which the form is introduced.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("introducedversion")]
 public string IntroducedVersion
 {
  get
  {
   return this.GetAttributeValue<string>("introducedversion");
  }
  set
  {
   this.OnPropertyChanging("IntroducedVersion");
   this.SetAttributeValue("introducedversion", value);
   this.OnPropertyChanged("IntroducedVersion");
  }
 }

 /// <summary>
 /// Indicates whether the process was created using the Microsoft Dynamics CRM Web application.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("iscrmuiworkflow")]
 public System.Nullable<bool> IsCrmUIWorkflow
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("iscrmuiworkflow");
  }
 }

 /// <summary>
 /// Information that specifies whether this component can be customized.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("iscustomizable")]
 public Microsoft.Xrm.Sdk.BooleanManagedProperty IsCustomizable
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.BooleanManagedProperty>("iscustomizable");
  }
  set
  {
   this.OnPropertyChanging("IsCustomizable");
   this.SetAttributeValue("iscustomizable", value);
   this.OnPropertyChanged("IsCustomizable");
  }
 }

 /// <summary>
 /// Indicates whether the solution component is part of a managed solution.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ismanaged")]
 public System.Nullable<bool> IsManaged
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("ismanaged");
  }
 }

 /// <summary>
 /// Indicates whether the custom operation is automatically transacted.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("istransacted")]
 public System.Nullable<bool> IsTransacted
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("istransacted");
  }
  set
  {
   this.OnPropertyChanging("IsTransacted");
   this.SetAttributeValue("istransacted", value);
   this.OnPropertyChanged("IsTransacted");
  }
 }

 /// <summary>
 /// Language of the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("languagecode")]
 public System.Nullable<int> LanguageCode
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("languagecode");
  }
  set
  {
   this.OnPropertyChanging("LanguageCode");
   this.SetAttributeValue("languagecode", value);
   this.OnPropertyChanged("LanguageCode");
  }
 }

 /// <summary>
 /// Shows the mode of the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mode")]
 public Microsoft.Xrm.Sdk.OptionSetValue Mode
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("mode");
  }
  set
  {
   this.OnPropertyChanging("Mode");
   this.SetAttributeValue("mode", value);
   this.OnPropertyChanged("Mode");
  }
 }

 /// <summary>
 /// Unique identifier of the user who last modified the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
  }
 }

 /// <summary>
 /// Date and time when the process was last modified.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
 public System.Nullable<System.DateTime> ModifiedOn
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
  }
 }

 /// <summary>
 /// Unique identifier of the delegate user who last modified the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
 public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
  }
 }

 /// <summary>
 /// Name of the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
 public string Name
 {
  get
  {
   return this.GetAttributeValue<string>("name");
  }
  set
  {
   this.OnPropertyChanging("Name");
   this.SetAttributeValue("name", value);
   this.OnPropertyChanged("Name");
  }
 }

 /// <summary>
 /// Indicates whether the process is able to run as an on-demand process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ondemand")]
 public System.Nullable<bool> OnDemand
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("ondemand");
  }
  set
  {
   this.OnPropertyChanging("OnDemand");
   this.SetAttributeValue("ondemand", value);
   this.OnPropertyChanged("OnDemand");
  }
 }

 /// <summary>
 /// For internal use only.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overwritetime")]
 public System.Nullable<System.DateTime> OverwriteTime
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.DateTime>>("overwritetime");
  }
 }

 /// <summary>
 /// Unique identifier of the user or team who owns the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
 public Microsoft.Xrm.Sdk.EntityReference OwnerId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
  }
  set
  {
   this.OnPropertyChanging("OwnerId");
   this.SetAttributeValue("ownerid", value);
   this.OnPropertyChanged("OwnerId");
  }
 }

 /// <summary>
 /// Unique identifier of the business unit that owns the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
 public Microsoft.Xrm.Sdk.EntityReference OwningBusinessUnit
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
  }
 }

 /// <summary>
 /// Unique identifier of the team who owns the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
 public Microsoft.Xrm.Sdk.EntityReference OwningTeam
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
  }
 }

 /// <summary>
 /// Unique identifier of the user who owns the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
 public Microsoft.Xrm.Sdk.EntityReference OwningUser
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
  }
 }

 /// <summary>
 /// Unique identifier of the definition for process activation.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parentworkflowid")]
 public Microsoft.Xrm.Sdk.EntityReference ParentWorkflowId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("parentworkflowid");
  }
 }

 /// <summary>
 /// Unique identifier of the plug-in type.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("plugintypeid")]
 public Microsoft.Xrm.Sdk.EntityReference PluginTypeId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("plugintypeid");
  }
 }

 /// <summary>
 /// Primary entity for the process. The process can be associated for one or more SDK operations defined on the primary entity.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("primaryentity")]
 public string PrimaryEntity
 {
  get
  {
   return this.GetAttributeValue<string>("primaryentity");
  }
  set
  {
   this.OnPropertyChanging("PrimaryEntity");
   this.SetAttributeValue("primaryentity", value);
   this.OnPropertyChanged("PrimaryEntity");
  }
 }

 /// <summary>
 /// Type the business process flow order.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("processorder")]
 public System.Nullable<int> ProcessOrder
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("processorder");
  }
  set
  {
   this.OnPropertyChanging("ProcessOrder");
   this.SetAttributeValue("processorder", value);
   this.OnPropertyChanged("ProcessOrder");
  }
 }

 /// <summary>
 /// Contains the role assignment for the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("processroleassignment")]
 public string ProcessRoleAssignment
 {
  get
  {
   return this.GetAttributeValue<string>("processroleassignment");
  }
  set
  {
   this.OnPropertyChanging("ProcessRoleAssignment");
   this.SetAttributeValue("processroleassignment", value);
   this.OnPropertyChanged("ProcessRoleAssignment");
  }
 }

 /// <summary>
 /// Indicates the rank for order of execution for the synchronous workflow.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("rank")]
 public System.Nullable<int> Rank
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<int>>("rank");
  }
  set
  {
   this.OnPropertyChanging("Rank");
   this.SetAttributeValue("rank", value);
   this.OnPropertyChanged("Rank");
  }
 }

 /// <summary>
 /// Specifies the system user account under which a workflow executes.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("runas")]
 public Microsoft.Xrm.Sdk.OptionSetValue RunAs
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("runas");
  }
  set
  {
   this.OnPropertyChanging("RunAs");
   this.SetAttributeValue("runas", value);
   this.OnPropertyChanged("RunAs");
  }
 }

 /// <summary>
 /// Scope of the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("scope")]
 public Microsoft.Xrm.Sdk.OptionSetValue Scope
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("scope");
  }
  set
  {
   this.OnPropertyChanging("Scope");
   this.SetAttributeValue("scope", value);
   this.OnPropertyChanged("Scope");
  }
 }

 /// <summary>
 /// Unique identifier of the SDK Message associated with this workflow.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageid")]
 public Microsoft.Xrm.Sdk.EntityReference SdkMessageId
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("sdkmessageid");
  }
 }

 /// <summary>
 /// Unique identifier of the associated solution.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionid")]
 public System.Nullable<System.Guid> SolutionId
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("solutionid");
  }
 }

 /// <summary>
 /// Status of the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
 public System.Nullable<WorkflowState> StateCode
 {
  get
  {
   Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statecode");
   if ((optionSet != null))
   {
    return ((WorkflowState)(System.Enum.ToObject(typeof(WorkflowState), optionSet.Value)));
   }
   else
   {
    return null;
   }
  }
 }

 /// <summary>
 /// Additional information about status of the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
 public Microsoft.Xrm.Sdk.OptionSetValue StatusCode
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statuscode");
  }
  set
  {
   this.OnPropertyChanging("StatusCode");
   this.SetAttributeValue("statuscode", value);
   this.OnPropertyChanged("StatusCode");
  }
 }

 /// <summary>
 /// Indicates whether the process can be included in other processes as a child process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("subprocess")]
 public System.Nullable<bool> Subprocess
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("subprocess");
  }
  set
  {
   this.OnPropertyChanging("Subprocess");
   this.SetAttributeValue("subprocess", value);
   this.OnPropertyChanged("Subprocess");
  }
 }

 /// <summary>
 /// Select whether synchronous workflow failures will be saved to log files.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("syncworkflowlogonfailure")]
 public System.Nullable<bool> SyncWorkflowLogOnFailure
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("syncworkflowlogonfailure");
  }
  set
  {
   this.OnPropertyChanging("SyncWorkflowLogOnFailure");
   this.SetAttributeValue("syncworkflowlogonfailure", value);
   this.OnPropertyChanged("SyncWorkflowLogOnFailure");
  }
 }

 /// <summary>
 /// Indicates whether the process will be triggered when the primary entity is created.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("triggeroncreate")]
 public System.Nullable<bool> TriggerOnCreate
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("triggeroncreate");
  }
  set
  {
   this.OnPropertyChanging("TriggerOnCreate");
   this.SetAttributeValue("triggeroncreate", value);
   this.OnPropertyChanged("TriggerOnCreate");
  }
 }

 /// <summary>
 /// Indicates whether the process will be triggered on deletion of the primary entity.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("triggerondelete")]
 public System.Nullable<bool> TriggerOnDelete
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<bool>>("triggerondelete");
  }
  set
  {
   this.OnPropertyChanging("TriggerOnDelete");
   this.SetAttributeValue("triggerondelete", value);
   this.OnPropertyChanged("TriggerOnDelete");
  }
 }

 /// <summary>
 /// Attributes that trigger the process when updated.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("triggeronupdateattributelist")]
 public string TriggerOnUpdateAttributeList
 {
  get
  {
   return this.GetAttributeValue<string>("triggeronupdateattributelist");
  }
  set
  {
   this.OnPropertyChanging("TriggerOnUpdateAttributeList");
   this.SetAttributeValue("triggeronupdateattributelist", value);
   this.OnPropertyChanged("TriggerOnUpdateAttributeList");
  }
 }

 /// <summary>
 /// Type of the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("type")]
 public Microsoft.Xrm.Sdk.OptionSetValue Type
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("type");
  }
  set
  {
   this.OnPropertyChanging("Type");
   this.SetAttributeValue("type", value);
   this.OnPropertyChanged("Type");
  }
 }

 /// <summary>
 /// Type a name for the custom operation.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("uniquename")]
 public string UniqueName
 {
  get
  {
   return this.GetAttributeValue<string>("uniquename");
  }
  set
  {
   this.OnPropertyChanging("UniqueName");
   this.SetAttributeValue("uniquename", value);
   this.OnPropertyChanged("UniqueName");
  }
 }

 /// <summary>
 /// Select the stage a process will be triggered on update.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("updatestage")]
 public Microsoft.Xrm.Sdk.OptionSetValue UpdateStage
 {
  get
  {
   return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("updatestage");
  }
  set
  {
   this.OnPropertyChanging("UpdateStage");
   this.SetAttributeValue("updatestage", value);
   this.OnPropertyChanged("UpdateStage");
  }
 }

 /// <summary>
 /// 
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
 public System.Nullable<long> VersionNumber
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
  }
 }

 /// <summary>
 /// Unique identifier of the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("workflowid")]
 public System.Nullable<System.Guid> WorkflowId
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("workflowid");
  }
  set
  {
   this.OnPropertyChanging("WorkflowId");
   this.SetAttributeValue("workflowid", value);
   if (value.HasValue)
   {
    base.Id = value.Value;
   }
   else
   {
    base.Id = System.Guid.Empty;
   }
   this.OnPropertyChanged("WorkflowId");
  }
 }

 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("workflowid")]
 public override System.Guid Id
 {
  get
  {
   return base.Id;
  }
  set
  {
   this.WorkflowId = value;
  }
 }

 /// <summary>
 /// For internal use only.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("workflowidunique")]
 public System.Nullable<System.Guid> WorkflowIdUnique
 {
  get
  {
   return this.GetAttributeValue<System.Nullable<System.Guid>>("workflowidunique");
  }
 }

 /// <summary>
 /// XAML that defines the process.
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("xaml")]
 public string Xaml
 {
  get
  {
   return this.GetAttributeValue<string>("xaml");
  }
  set
  {
   this.OnPropertyChanging("Xaml");
   this.SetAttributeValue("xaml", value);
   this.OnPropertyChanged("Xaml");
  }
 }





 /// <summary>
 /// 1:N workflow_active_workflow
 /// </summary>
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("workflow_active_workflow", Microsoft.Xrm.Sdk.EntityRole.Referenced)]
 public System.Collections.Generic.IEnumerable<Workflow> Referencedworkflow_active_workflow
 {
  get
  {
   return this.GetRelatedEntities<Workflow>("workflow_active_workflow", Microsoft.Xrm.Sdk.EntityRole.Referenced);
  }
  set
  {
   this.OnPropertyChanging("Referencedworkflow_active_workflow");
   this.SetRelatedEntities<Workflow>("workflow_active_workflow", Microsoft.Xrm.Sdk.EntityRole.Referenced, value);
   this.OnPropertyChanged("Referencedworkflow_active_workflow");
  }
 }




 /// <summary>
 /// 1:N workflow_parent_workflow
 /// </summary>
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("workflow_parent_workflow", Microsoft.Xrm.Sdk.EntityRole.Referenced)]
 public System.Collections.Generic.IEnumerable<Workflow> Referencedworkflow_parent_workflow
 {
  get
  {
   return this.GetRelatedEntities<Workflow>("workflow_parent_workflow", Microsoft.Xrm.Sdk.EntityRole.Referenced);
  }
  set
  {
   this.OnPropertyChanging("Referencedworkflow_parent_workflow");
   this.SetRelatedEntities<Workflow>("workflow_parent_workflow", Microsoft.Xrm.Sdk.EntityRole.Referenced, value);
   this.OnPropertyChanged("Referencedworkflow_parent_workflow");
  }
 }






 /// <summary>
 /// N:1 workflow_active_workflow
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("activeworkflowid")]
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("workflow_active_workflow", Microsoft.Xrm.Sdk.EntityRole.Referencing)]
 public Workflow Referencingworkflow_active_workflow
 {
  get
  {
   return this.GetRelatedEntity<Workflow>("workflow_active_workflow", Microsoft.Xrm.Sdk.EntityRole.Referencing);
  }
 }




 /// <summary>
 /// N:1 workflow_parent_workflow
 /// </summary>
 [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parentworkflowid")]
 [Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("workflow_parent_workflow", Microsoft.Xrm.Sdk.EntityRole.Referencing)]
 public Workflow Referencingworkflow_parent_workflow
 {
  get
  {
   return this.GetRelatedEntity<Workflow>("workflow_parent_workflow", Microsoft.Xrm.Sdk.EntityRole.Referencing);
  }
 }
}


[System.Runtime.Serialization.DataContractAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "6.0.0000.0809")]
public enum WorkflowState
{

 [System.Runtime.Serialization.EnumMemberAttribute()]
 Draft = 0,

 [System.Runtime.Serialization.EnumMemberAttribute()]
 Activated = 1,
}
/// <summary>
/// Represents a source of entities bound to a CRM service. It tracks and manages changes made to the retrieved entities.
/// </summary>
[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "6.0.0000.0809")]
public partial class ServiceContext : Microsoft.Xrm.Sdk.Client.OrganizationServiceContext
{

 /// <summary>
 /// Constructor.
 /// </summary>
 public ServiceContext(Microsoft.Xrm.Sdk.IOrganizationService service) :
  base(service)
 {
 }

 /// <summary>
 /// Gets a binding to the set of all SdkMessage entities.
 /// </summary>
 public System.Linq.IQueryable<SdkMessage> SdkMessageSet
 {
  get
  {
   return this.CreateQuery<SdkMessage>();
  }
 }

 /// <summary>
 /// Gets a binding to the set of all SdkMessageFilter entities.
 /// </summary>
 public System.Linq.IQueryable<SdkMessageFilter> SdkMessageFilterSet
 {
  get
  {
   return this.CreateQuery<SdkMessageFilter>();
  }
 }

 /// <summary>
 /// Gets a binding to the set of all SdkMessagePair entities.
 /// </summary>
 public System.Linq.IQueryable<SdkMessagePair> SdkMessagePairSet
 {
  get
  {
   return this.CreateQuery<SdkMessagePair>();
  }
 }


 /// <summary>
 /// Gets a binding to the set of all SdkMessageRequest entities.
 /// </summary>
 public System.Linq.IQueryable<SdkMessageRequest> SdkMessageRequestSet
 {
  get
  {
   return this.CreateQuery<SdkMessageRequest>();
  }
 }

 /// <summary>
 /// Gets a binding to the set of all SdkMessageRequestField entities.
 /// </summary>
 public System.Linq.IQueryable<SdkMessageRequestField> SdkMessageRequestFieldSet
 {
  get
  {
   return this.CreateQuery<SdkMessageRequestField>();
  }
 }

 /// <summary>
 /// Gets a binding to the set of all SdkMessageResponse entities.
 /// </summary>
 public System.Linq.IQueryable<SdkMessageResponse> SdkMessageResponseSet
 {
  get
  {
   return this.CreateQuery<SdkMessageResponse>();
  }
 }

 /// <summary>
 /// Gets a binding to the set of all SdkMessageResponseField entities.
 /// </summary>
 public System.Linq.IQueryable<SdkMessageResponseField> SdkMessageResponseFieldSet
 {
  get
  {
   return this.CreateQuery<SdkMessageResponseField>();
  }
 }

 /// <summary>
 /// Gets a binding to the set of all Workflow entities.
 /// </summary>
 public System.Linq.IQueryable<Workflow> WorkflowSet
 {
  get
  {
   return this.CreateQuery<Workflow>();
  }
 }

}
