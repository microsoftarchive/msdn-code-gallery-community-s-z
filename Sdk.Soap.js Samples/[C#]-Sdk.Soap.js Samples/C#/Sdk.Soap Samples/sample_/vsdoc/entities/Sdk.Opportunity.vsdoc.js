/*

IMPORTANT: Use this file at design time for IntelliSense support ONLY.
Use the corresponding Sdk.Opportunity.min.js in your project

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
this.Opportunity = function (entity) {
///<summary>
/// Potential revenue-generating event, or sale to an account, which needs to be tracked through a sales process to completion.
///</summary>
/// <param name='entity' type='Sdk.Entity' mayBeNull='true' optional='true'>
/// Optional. Use only to convert an Sdk.Entity into an Sdk.Opportunity
///</param>
  if (!(this instanceof Sdk.Opportunity)) {
   return new Sdk.Opportunity();
  }
  Sdk.Entity.call(this);
  this.setType("opportunity");
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
     throw new Error("Invalid type Sdk.Opportunity entity constructor parameter must be an Sdk.Entity of Type opportunity");
    }
   }
   else {
    throw new Error("Invalid argument Sdk.Opportunity entity constructor parameter must be an Sdk.Entity");
   }
  }

// AccountId START --------------------------------------------------------------
var AccountId = new Sdk.Lookup("accountid");
this.addAttribute(AccountId, false);
/// <field name='AccountId' type='Sdk.Lookup'>Account : Unique identifier of the account with which the opportunity is associated.</field>
this.AccountId = {};
this.AccountId.getValue = function () {
 ///<summary>
 /// Gets the AccountId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Unique identifier of the account with which the opportunity is associated.</returns>
 return AccountId.getValue();
}
// AccountId END --------------------------------------------------------------


// ActualCloseDate START --------------------------------------------------------------
var ActualCloseDate = new Sdk.DateTime("actualclosedate");
this.addAttribute(ActualCloseDate, false);
/// <field name='ActualCloseDate' type='Sdk.DateTime'>Actual Close Date : Shows the date and time when the opportunity was closed or canceled.</field>
this.ActualCloseDate = {};
this.ActualCloseDate.setValue = function (value) {
 ///<summary><para>Sets the ActualCloseDate (Actual Close Date) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="Date" optional="false">Shows the date and time when the opportunity was closed or canceled.</param>
 ActualCloseDate.setValue(value);
};
this.ActualCloseDate.getValue = function () {
 ///<summary>
 /// Gets the ActualCloseDate value
 ///</summary>
 /// <returns type="Date">Shows the date and time when the opportunity was closed or canceled.</returns>
 return ActualCloseDate.getValue();
}
// ActualCloseDate END --------------------------------------------------------------


// ActualValue START --------------------------------------------------------------
var ActualValue = new Sdk.Money("actualvalue");
this.addAttribute(ActualValue, false);
/// <field name='ActualValue' type='Sdk.Money'>Actual Revenue : Type the actual revenue amount for the opportunity for reporting and analysis of estimated versus actual sales. Field defaults to the Est. Revenue value when an opportunity is won.</field>
this.ActualValue = {};
this.ActualValue.setValue = function (value) {
 ///<summary>Sets the ActualValue value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Actual Revenue : Type the actual revenue amount for the opportunity for reporting and analysis of estimated versus actual sales. Field defaults to the Est. Revenue value when an opportunity is won.</para>
 /// <para>MaxValue: 922337203685477</para>
 /// <para>MinValue: -922337203685477</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 ActualValue.setValue(value);
};
this.ActualValue.getValue = function () {
 ///<summary>
 /// Gets the ActualValue value
 ///</summary>
 /// <returns type="Number">Type the actual revenue amount for the opportunity for reporting and analysis of estimated versus actual sales. Field defaults to the Est. Revenue value when an opportunity is won.</returns>
 return ActualValue.getValue();
}
// ActualValue END --------------------------------------------------------------


// ActualValue_Base START --------------------------------------------------------------
var ActualValue_Base = new Sdk.Money("actualvalue_base");
this.addAttribute(ActualValue_Base, false);
/// <field name='ActualValue_Base' type='Sdk.Money'>Actual Revenue (Base) : Shows the Actual Revenue field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</field>
this.ActualValue_Base = {};
this.ActualValue_Base.getValue = function () {
 ///<summary>
 /// Gets the ActualValue_Base value
 ///</summary>
 /// <returns type="Number">Shows the Actual Revenue field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</returns>
 return ActualValue_Base.getValue();
}
// ActualValue_Base END --------------------------------------------------------------


// BudgetAmount START --------------------------------------------------------------
var BudgetAmount = new Sdk.Money("budgetamount");
this.addAttribute(BudgetAmount, false);
/// <field name='BudgetAmount' type='Sdk.Money'>Budget Amount : Type a value between 0 and 1,000,000,000,000 to indicate the lead's potential available budget.</field>
this.BudgetAmount = {};
this.BudgetAmount.setValue = function (value) {
 ///<summary>Sets the BudgetAmount value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Budget Amount : Type a value between 0 and 1,000,000,000,000 to indicate the lead's potential available budget.</para>
 /// <para>MaxValue: 922337203685477</para>
 /// <para>MinValue: -922337203685477</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 BudgetAmount.setValue(value);
};
this.BudgetAmount.getValue = function () {
 ///<summary>
 /// Gets the BudgetAmount value
 ///</summary>
 /// <returns type="Number">Type a value between 0 and 1,000,000,000,000 to indicate the lead's potential available budget.</returns>
 return BudgetAmount.getValue();
}
// BudgetAmount END --------------------------------------------------------------


// BudgetAmount_Base START --------------------------------------------------------------
var BudgetAmount_Base = new Sdk.Money("budgetamount_base");
this.addAttribute(BudgetAmount_Base, false);
/// <field name='BudgetAmount_Base' type='Sdk.Money'>Budget Amount (Base) : Shows the budget amount converted to the system's base currency.</field>
this.BudgetAmount_Base = {};
this.BudgetAmount_Base.getValue = function () {
 ///<summary>
 /// Gets the BudgetAmount_Base value
 ///</summary>
 /// <returns type="Number">Shows the budget amount converted to the system's base currency.</returns>
 return BudgetAmount_Base.getValue();
}
// BudgetAmount_Base END --------------------------------------------------------------


// BudgetStatus START --------------------------------------------------------------
var BudgetStatus = new Sdk.OptionSet("budgetstatus");
  this.addAttribute(BudgetStatus, false);
  /// <field name='BudgetStatus' type='Sdk.OptionSet'>Budget : Select the likely budget status for the lead's company. This may help determine the lead rating or your sales approach.</field>
  this.BudgetStatus = {};
 this.BudgetStatus.setValue = function (value) {
  ///<summary><para>Sets the BudgetStatus (Budget) value</para>
   /// <para>Select the likely budget status for the lead's company. This may help determine the lead rating or your sales approach.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 0 : No Committed Budget</para>
/// <para> 1 : May Buy</para>
/// <para> 2 : Can Buy</para>
/// <para> 3 : Will Buy</para>
   /// </param>
   BudgetStatus.setValue(value);
  };
  this.BudgetStatus.getValue = function () {
   ///<summary>Gets the BudgetStatus value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the likely budget status for the lead's company. This may help determine the lead rating or your sales approach.</returns>
   return BudgetStatus.getValue();
  }
// BudgetStatus END --------------------------------------------------------------


// CampaignId START --------------------------------------------------------------
var CampaignId = new Sdk.Lookup("campaignid");
this.addAttribute(CampaignId, false);
/// <field name='CampaignId' type='Sdk.Lookup'>Source Campaign : Shows the campaign that the opportunity was created from. The ID is used for tracking the success of the campaign.</field>
this.CampaignId = {};
this.CampaignId.setValue = function (value) {
///<summary><para>Sets the CampaignId value</para>
/// <para>Display Name: Source Campaign</para>
/// <para>Targets: campaign</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Shows the campaign that the opportunity was created from. The ID is used for tracking the success of the campaign.</param>
 CampaignId.setValue(value);
};
this.CampaignId.getValue = function () {
 ///<summary>
 /// Gets the CampaignId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Shows the campaign that the opportunity was created from. The ID is used for tracking the success of the campaign.</returns>
 return CampaignId.getValue();
}
// CampaignId END --------------------------------------------------------------


// CaptureProposalFeedback START --------------------------------------------------------------
var CaptureProposalFeedback = new Sdk.Boolean("captureproposalfeedback");
this.addAttribute(CaptureProposalFeedback, false);
/// <field name='CaptureProposalFeedback' type='Sdk.String'>Proposal Feedback Captured : Choose whether the proposal feedback has been captured for the opportunity. </field>
this.CaptureProposalFeedback = {};
this.CaptureProposalFeedback.setValue = function (value) {
 ///<summary>Sets the CaptureProposalFeedback value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Proposal Feedback Captured  : Choose whether the proposal feedback has been captured for the opportunity. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: No</para>
 /// <para>False Label: Yes</para>
 /// </param>
CaptureProposalFeedback.setValue(value);
};
this.CaptureProposalFeedback.getValue = function () {
 ///<summary>
 /// Gets the CaptureProposalFeedback value
 ///</summary>
 /// <returns type="Boolean">Choose whether the proposal feedback has been captured for the opportunity.</returns>
return CaptureProposalFeedback.getValue();
}
// CaptureProposalFeedback END --------------------------------------------------------------


// CloseProbability START --------------------------------------------------------------
var CloseProbability = new Sdk.Int("closeprobability");
this.addAttribute(CloseProbability, false);
/// <field name='CloseProbability' type='Sdk.Int'>Probability : Type a number from 0 to 100 that represents the likelihood of closing the opportunity. This can aid the sales team in their efforts to convert the opportunity in a sale.</field>
this.CloseProbability = {};
this.CloseProbability.setValue = function (value) {
 ///<summary>Sets the CloseProbability value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Probability : Type a number from 0 to 100 that represents the likelihood of closing the opportunity. This can aid the sales team in their efforts to convert the opportunity in a sale.</para>
 /// <para>MaxValue: 2147483647</para>
 /// <para>MinValue: -2147483648</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 CloseProbability.setValue(value);
};
this.CloseProbability.getValue = function () {
 ///<summary>
 /// Gets the CloseProbability value
 ///</summary>
 /// <returns type="Number">Type a number from 0 to 100 that represents the likelihood of closing the opportunity. This can aid the sales team in their efforts to convert the opportunity in a sale.</returns>
 return CloseProbability.getValue();
}
// CloseProbability END --------------------------------------------------------------


// CompleteFinalProposal START --------------------------------------------------------------
var CompleteFinalProposal = new Sdk.Boolean("completefinalproposal");
this.addAttribute(CompleteFinalProposal, false);
/// <field name='CompleteFinalProposal' type='Sdk.String'>Final Proposal Ready : Select whether a final proposal has been completed for the opportunity. </field>
this.CompleteFinalProposal = {};
this.CompleteFinalProposal.setValue = function (value) {
 ///<summary>Sets the CompleteFinalProposal value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Final Proposal Ready  : Select whether a final proposal has been completed for the opportunity. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: completed</para>
 /// <para>False Label: mark complete</para>
 /// </param>
CompleteFinalProposal.setValue(value);
};
this.CompleteFinalProposal.getValue = function () {
 ///<summary>
 /// Gets the CompleteFinalProposal value
 ///</summary>
 /// <returns type="Boolean">Select whether a final proposal has been completed for the opportunity.</returns>
return CompleteFinalProposal.getValue();
}
// CompleteFinalProposal END --------------------------------------------------------------


// CompleteInternalReview START --------------------------------------------------------------
var CompleteInternalReview = new Sdk.Boolean("completeinternalreview");
this.addAttribute(CompleteInternalReview, false);
/// <field name='CompleteInternalReview' type='Sdk.String'>Complete Internal Review : Select whether an internal review has been completed for this opportunity. </field>
this.CompleteInternalReview = {};
this.CompleteInternalReview.setValue = function (value) {
 ///<summary>Sets the CompleteInternalReview value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Complete Internal Review  : Select whether an internal review has been completed for this opportunity. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: completed</para>
 /// <para>False Label: mark complete</para>
 /// </param>
CompleteInternalReview.setValue(value);
};
this.CompleteInternalReview.getValue = function () {
 ///<summary>
 /// Gets the CompleteInternalReview value
 ///</summary>
 /// <returns type="Boolean">Select whether an internal review has been completed for this opportunity.</returns>
return CompleteInternalReview.getValue();
}
// CompleteInternalReview END --------------------------------------------------------------


// ConfirmInterest START --------------------------------------------------------------
var ConfirmInterest = new Sdk.Boolean("confirminterest");
this.addAttribute(ConfirmInterest, false);
/// <field name='ConfirmInterest' type='Sdk.String'>Confirm Interest : Select whether the lead confirmed interest in your offerings. This helps in determining the lead quality and the probability of it turning into an opportunity. </field>
this.ConfirmInterest = {};
this.ConfirmInterest.setValue = function (value) {
 ///<summary>Sets the ConfirmInterest value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Confirm Interest  : Select whether the lead confirmed interest in your offerings. This helps in determining the lead quality and the probability of it turning into an opportunity. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: No</para>
 /// <para>False Label: Yes</para>
 /// </param>
ConfirmInterest.setValue(value);
};
this.ConfirmInterest.getValue = function () {
 ///<summary>
 /// Gets the ConfirmInterest value
 ///</summary>
 /// <returns type="Boolean">Select whether the lead confirmed interest in your offerings. This helps in determining the lead quality and the probability of it turning into an opportunity.</returns>
return ConfirmInterest.getValue();
}
// ConfirmInterest END --------------------------------------------------------------


// ContactId START --------------------------------------------------------------
var ContactId = new Sdk.Lookup("contactid");
this.addAttribute(ContactId, false);
/// <field name='ContactId' type='Sdk.Lookup'>Contact : Unique identifier of the contact associated with the opportunity.</field>
this.ContactId = {};
this.ContactId.getValue = function () {
 ///<summary>
 /// Gets the ContactId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Unique identifier of the contact associated with the opportunity.</returns>
 return ContactId.getValue();
}
// ContactId END --------------------------------------------------------------


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


// CurrentSituation START --------------------------------------------------------------
  var CurrentSituation = new Sdk.String("currentsituation");
  this.addAttribute(CurrentSituation, false);
  /// <field name='CurrentSituation' type='Sdk.String'>Current Situation : Type notes about the company or organization associated with the opportunity.</field>
this.CurrentSituation = {};
  this.CurrentSituation.setValue = function (value) {
   ///<summary>Sets the CurrentSituation value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Current Situation : Type notes about the company or organization associated with the opportunity.</para>
   /// <para>MaxLength: 2000</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   CurrentSituation.setValue(value);
  };
  this.CurrentSituation.getValue = function () {
   ///<summary>
   /// Gets the CurrentSituation value
   ///</summary>
   /// <returns type="String">Type notes about the company or organization associated with the opportunity.</returns>
   return CurrentSituation.getValue();
  }
// CurrentSituation END --------------------------------------------------------------


// CustomerId START --------------------------------------------------------------
var CustomerId = new Sdk.Lookup("customerid");
this.addAttribute(CustomerId, false);
/// <field name='CustomerId' type='Sdk.Lookup'>Potential Customer : Select the customer account or contact to provide a quick link to additional customer details, such as address, phone number, activities, and orders.</field>
this.CustomerId = {};
this.CustomerId.setValue = function (value) {
///<summary><para>Sets the CustomerId value</para>
/// <para>Display Name: Potential Customer</para>
/// <para>Targets: account,contact</para>
/// <para>RequiredLevel: ApplicationRequired</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Select the customer account or contact to provide a quick link to additional customer details, such as address, phone number, activities, and orders.</param>
 CustomerId.setValue(value);
};
this.CustomerId.getValue = function () {
 ///<summary>
 /// Gets the CustomerId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Select the customer account or contact to provide a quick link to additional customer details, such as address, phone number, activities, and orders.</returns>
 return CustomerId.getValue();
}
// CustomerId END --------------------------------------------------------------


// CustomerNeed START --------------------------------------------------------------
  var CustomerNeed = new Sdk.String("customerneed");
  this.addAttribute(CustomerNeed, false);
  /// <field name='CustomerNeed' type='Sdk.String'>Customer Need : Type some notes about the customer's requirements, to help the sales team identify products and services that could meet their requirements.</field>
this.CustomerNeed = {};
  this.CustomerNeed.setValue = function (value) {
   ///<summary>Sets the CustomerNeed value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Customer Need : Type some notes about the customer's requirements, to help the sales team identify products and services that could meet their requirements.</para>
   /// <para>MaxLength: 2000</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   CustomerNeed.setValue(value);
  };
  this.CustomerNeed.getValue = function () {
   ///<summary>
   /// Gets the CustomerNeed value
   ///</summary>
   /// <returns type="String">Type some notes about the customer's requirements, to help the sales team identify products and services that could meet their requirements.</returns>
   return CustomerNeed.getValue();
  }
// CustomerNeed END --------------------------------------------------------------


// CustomerPainPoints START --------------------------------------------------------------
  var CustomerPainPoints = new Sdk.String("customerpainpoints");
  this.addAttribute(CustomerPainPoints, false);
  /// <field name='CustomerPainPoints' type='Sdk.String'>Customer Pain Points : Type notes about the customer's pain points to help the sales team identify products and services that could address these pain points.</field>
this.CustomerPainPoints = {};
  this.CustomerPainPoints.setValue = function (value) {
   ///<summary>Sets the CustomerPainPoints value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Customer Pain Points : Type notes about the customer's pain points to help the sales team identify products and services that could address these pain points.</para>
   /// <para>MaxLength: 2000</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   CustomerPainPoints.setValue(value);
  };
  this.CustomerPainPoints.getValue = function () {
   ///<summary>
   /// Gets the CustomerPainPoints value
   ///</summary>
   /// <returns type="String">Type notes about the customer's pain points to help the sales team identify products and services that could address these pain points.</returns>
   return CustomerPainPoints.getValue();
  }
// CustomerPainPoints END --------------------------------------------------------------


// DecisionMaker START --------------------------------------------------------------
var DecisionMaker = new Sdk.Boolean("decisionmaker");
this.addAttribute(DecisionMaker, false);
/// <field name='DecisionMaker' type='Sdk.String'>Decision Maker? : Select whether your notes include information about who makes the purchase decisions at the lead's company. </field>
this.DecisionMaker = {};
this.DecisionMaker.setValue = function (value) {
 ///<summary>Sets the DecisionMaker value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Decision Maker?  : Select whether your notes include information about who makes the purchase decisions at the lead's company. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: completed</para>
 /// <para>False Label: mark complete</para>
 /// </param>
DecisionMaker.setValue(value);
};
this.DecisionMaker.getValue = function () {
 ///<summary>
 /// Gets the DecisionMaker value
 ///</summary>
 /// <returns type="Boolean">Select whether your notes include information about who makes the purchase decisions at the lead's company.</returns>
return DecisionMaker.getValue();
}
// DecisionMaker END --------------------------------------------------------------


// Description START --------------------------------------------------------------
  var Description = new Sdk.String("description");
  this.addAttribute(Description, false);
  /// <field name='Description' type='Sdk.String'>Description : Type additional information to describe the opportunity, such as possible products to sell or past purchases from the customer.</field>
this.Description = {};
  this.Description.setValue = function (value) {
   ///<summary>Sets the Description value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Description : Type additional information to describe the opportunity, such as possible products to sell or past purchases from the customer.</para>
   /// <para>MaxLength: 2000</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Description.setValue(value);
  };
  this.Description.getValue = function () {
   ///<summary>
   /// Gets the Description value
   ///</summary>
   /// <returns type="String">Type additional information to describe the opportunity, such as possible products to sell or past purchases from the customer.</returns>
   return Description.getValue();
  }
// Description END --------------------------------------------------------------


// DevelopProposal START --------------------------------------------------------------
var DevelopProposal = new Sdk.Boolean("developproposal");
this.addAttribute(DevelopProposal, false);
/// <field name='DevelopProposal' type='Sdk.String'>Develop Proposal : Select whether a proposal has been developed for the opportunity. </field>
this.DevelopProposal = {};
this.DevelopProposal.setValue = function (value) {
 ///<summary>Sets the DevelopProposal value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Develop Proposal  : Select whether a proposal has been developed for the opportunity. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: completed</para>
 /// <para>False Label: mark complete</para>
 /// </param>
DevelopProposal.setValue(value);
};
this.DevelopProposal.getValue = function () {
 ///<summary>
 /// Gets the DevelopProposal value
 ///</summary>
 /// <returns type="Boolean">Select whether a proposal has been developed for the opportunity.</returns>
return DevelopProposal.getValue();
}
// DevelopProposal END --------------------------------------------------------------


// DiscountAmount START --------------------------------------------------------------
var DiscountAmount = new Sdk.Money("discountamount");
this.addAttribute(DiscountAmount, false);
/// <field name='DiscountAmount' type='Sdk.Money'>Opportunity Discount Amount : Type the discount amount for the opportunity if the customer is eligible for special savings.</field>
this.DiscountAmount = {};
this.DiscountAmount.setValue = function (value) {
 ///<summary>Sets the DiscountAmount value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Opportunity Discount Amount : Type the discount amount for the opportunity if the customer is eligible for special savings.</para>
 /// <para>MaxValue: 922337203685477</para>
 /// <para>MinValue: -922337203685477</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 DiscountAmount.setValue(value);
};
this.DiscountAmount.getValue = function () {
 ///<summary>
 /// Gets the DiscountAmount value
 ///</summary>
 /// <returns type="Number">Type the discount amount for the opportunity if the customer is eligible for special savings.</returns>
 return DiscountAmount.getValue();
}
// DiscountAmount END --------------------------------------------------------------


// DiscountAmount_Base START --------------------------------------------------------------
var DiscountAmount_Base = new Sdk.Money("discountamount_base");
this.addAttribute(DiscountAmount_Base, false);
/// <field name='DiscountAmount_Base' type='Sdk.Money'>Opportunity Discount Amount (Base) : Shows the Opportunity Discount Amount field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</field>
this.DiscountAmount_Base = {};
this.DiscountAmount_Base.getValue = function () {
 ///<summary>
 /// Gets the DiscountAmount_Base value
 ///</summary>
 /// <returns type="Number">Shows the Opportunity Discount Amount field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</returns>
 return DiscountAmount_Base.getValue();
}
// DiscountAmount_Base END --------------------------------------------------------------


// DiscountPercentage START --------------------------------------------------------------
var DiscountPercentage = new Sdk.Decimal("discountpercentage");
this.addAttribute(DiscountPercentage, false);
/// <field name='DiscountPercentage' type='Sdk.Decimal'>Opportunity Discount (%) : Type the discount rate that should be applied to the Product Totals field to include additional savings for the customer in the opportunity.</field>
this.DiscountPercentage = {};
this.DiscountPercentage.setValue = function (value) {
 ///<summary>Sets the DiscountPercentage value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Opportunity Discount (%) : Type the discount rate that should be applied to the Product Totals field to include additional savings for the customer in the opportunity.</para>
 /// <para>MaxValue: 100000000000</para>
 /// <para>MinValue: -100000000000</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 DiscountPercentage.setValue(value);
};
this.DiscountPercentage.getValue = function () {
 ///<summary>
 /// Gets the DiscountPercentage value
 ///</summary>
 /// <returns type="Number">Type the discount rate that should be applied to the Product Totals field to include additional savings for the customer in the opportunity.</returns>
 return DiscountPercentage.getValue();
}
// DiscountPercentage END --------------------------------------------------------------


// EstimatedCloseDate START --------------------------------------------------------------
var EstimatedCloseDate = new Sdk.DateTime("estimatedclosedate");
this.addAttribute(EstimatedCloseDate, false);
/// <field name='EstimatedCloseDate' type='Sdk.DateTime'>Est. Close Date : Enter the expected closing date of the opportunity to help make accurate revenue forecasts.</field>
this.EstimatedCloseDate = {};
this.EstimatedCloseDate.setValue = function (value) {
 ///<summary><para>Sets the EstimatedCloseDate (Est. Close Date) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="Date" optional="false">Enter the expected closing date of the opportunity to help make accurate revenue forecasts.</param>
 EstimatedCloseDate.setValue(value);
};
this.EstimatedCloseDate.getValue = function () {
 ///<summary>
 /// Gets the EstimatedCloseDate value
 ///</summary>
 /// <returns type="Date">Enter the expected closing date of the opportunity to help make accurate revenue forecasts.</returns>
 return EstimatedCloseDate.getValue();
}
// EstimatedCloseDate END --------------------------------------------------------------


// EstimatedValue START --------------------------------------------------------------
var EstimatedValue = new Sdk.Money("estimatedvalue");
this.addAttribute(EstimatedValue, false);
/// <field name='EstimatedValue' type='Sdk.Money'>Est. Revenue : Type the estimated revenue amount to indicate the potential sale or value of the opportunity for revenue forecasting. This field can be either system-populated or editable based on the selection in the Revenue field.</field>
this.EstimatedValue = {};
this.EstimatedValue.setValue = function (value) {
 ///<summary>Sets the EstimatedValue value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Est. Revenue : Type the estimated revenue amount to indicate the potential sale or value of the opportunity for revenue forecasting. This field can be either system-populated or editable based on the selection in the Revenue field.</para>
 /// <para>MaxValue: 922337203685477</para>
 /// <para>MinValue: -922337203685477</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 EstimatedValue.setValue(value);
};
this.EstimatedValue.getValue = function () {
 ///<summary>
 /// Gets the EstimatedValue value
 ///</summary>
 /// <returns type="Number">Type the estimated revenue amount to indicate the potential sale or value of the opportunity for revenue forecasting. This field can be either system-populated or editable based on the selection in the Revenue field.</returns>
 return EstimatedValue.getValue();
}
// EstimatedValue END --------------------------------------------------------------


// EstimatedValue_Base START --------------------------------------------------------------
var EstimatedValue_Base = new Sdk.Money("estimatedvalue_base");
this.addAttribute(EstimatedValue_Base, false);
/// <field name='EstimatedValue_Base' type='Sdk.Money'>Est. Revenue (Base) : Shows the Actual Revenue field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</field>
this.EstimatedValue_Base = {};
this.EstimatedValue_Base.getValue = function () {
 ///<summary>
 /// Gets the EstimatedValue_Base value
 ///</summary>
 /// <returns type="Number">Shows the Actual Revenue field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</returns>
 return EstimatedValue_Base.getValue();
}
// EstimatedValue_Base END --------------------------------------------------------------


// EvaluateFit START --------------------------------------------------------------
var EvaluateFit = new Sdk.Boolean("evaluatefit");
this.addAttribute(EvaluateFit, false);
/// <field name='EvaluateFit' type='Sdk.String'>Evaluate Fit : Select whether the fit between the lead's requirements and your offerings was evaluated. </field>
this.EvaluateFit = {};
this.EvaluateFit.setValue = function (value) {
 ///<summary>Sets the EvaluateFit value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Evaluate Fit  : Select whether the fit between the lead's requirements and your offerings was evaluated. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: No</para>
 /// <para>False Label: Yes</para>
 /// </param>
EvaluateFit.setValue(value);
};
this.EvaluateFit.getValue = function () {
 ///<summary>
 /// Gets the EvaluateFit value
 ///</summary>
 /// <returns type="Boolean">Select whether the fit between the lead's requirements and your offerings was evaluated.</returns>
return EvaluateFit.getValue();
}
// EvaluateFit END --------------------------------------------------------------


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


// FileDebrief START --------------------------------------------------------------
var FileDebrief = new Sdk.Boolean("filedebrief");
this.addAttribute(FileDebrief, false);
/// <field name='FileDebrief' type='Sdk.String'>File Debrief : Choose whether the sales team has recorded detailed notes on the proposals and the account's responses. </field>
this.FileDebrief = {};
this.FileDebrief.setValue = function (value) {
 ///<summary>Sets the FileDebrief value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>File Debrief  : Choose whether the sales team has recorded detailed notes on the proposals and the account's responses. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: completed</para>
 /// <para>False Label: mark complete</para>
 /// </param>
FileDebrief.setValue(value);
};
this.FileDebrief.getValue = function () {
 ///<summary>
 /// Gets the FileDebrief value
 ///</summary>
 /// <returns type="Boolean">Choose whether the sales team has recorded detailed notes on the proposals and the account's responses.</returns>
return FileDebrief.getValue();
}
// FileDebrief END --------------------------------------------------------------


// FinalDecisionDate START --------------------------------------------------------------
var FinalDecisionDate = new Sdk.DateTime("finaldecisiondate");
this.addAttribute(FinalDecisionDate, false);
/// <field name='FinalDecisionDate' type='Sdk.DateTime'>Final Decision Date : Enter the date and time when the final decision of the opportunity was made.</field>
this.FinalDecisionDate = {};
this.FinalDecisionDate.setValue = function (value) {
 ///<summary><para>Sets the FinalDecisionDate (Final Decision Date) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="Date" optional="false">Enter the date and time when the final decision of the opportunity was made.</param>
 FinalDecisionDate.setValue(value);
};
this.FinalDecisionDate.getValue = function () {
 ///<summary>
 /// Gets the FinalDecisionDate value
 ///</summary>
 /// <returns type="Date">Enter the date and time when the final decision of the opportunity was made.</returns>
 return FinalDecisionDate.getValue();
}
// FinalDecisionDate END --------------------------------------------------------------


// FreightAmount START --------------------------------------------------------------
var FreightAmount = new Sdk.Money("freightamount");
this.addAttribute(FreightAmount, false);
/// <field name='FreightAmount' type='Sdk.Money'>Freight Amount : Type the cost of freight or shipping for the products included in the opportunity for use in calculating the Total Amount field.</field>
this.FreightAmount = {};
this.FreightAmount.setValue = function (value) {
 ///<summary>Sets the FreightAmount value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Freight Amount : Type the cost of freight or shipping for the products included in the opportunity for use in calculating the Total Amount field.</para>
 /// <para>MaxValue: 922337203685477</para>
 /// <para>MinValue: -922337203685477</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 FreightAmount.setValue(value);
};
this.FreightAmount.getValue = function () {
 ///<summary>
 /// Gets the FreightAmount value
 ///</summary>
 /// <returns type="Number">Type the cost of freight or shipping for the products included in the opportunity for use in calculating the Total Amount field.</returns>
 return FreightAmount.getValue();
}
// FreightAmount END --------------------------------------------------------------


// FreightAmount_Base START --------------------------------------------------------------
var FreightAmount_Base = new Sdk.Money("freightamount_base");
this.addAttribute(FreightAmount_Base, false);
/// <field name='FreightAmount_Base' type='Sdk.Money'>Freight Amount (Base) : Shows the Freight Amount field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</field>
this.FreightAmount_Base = {};
this.FreightAmount_Base.getValue = function () {
 ///<summary>
 /// Gets the FreightAmount_Base value
 ///</summary>
 /// <returns type="Number">Shows the Freight Amount field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</returns>
 return FreightAmount_Base.getValue();
}
// FreightAmount_Base END --------------------------------------------------------------


// IdentifyCompetitors START --------------------------------------------------------------
var IdentifyCompetitors = new Sdk.Boolean("identifycompetitors");
this.addAttribute(IdentifyCompetitors, false);
/// <field name='IdentifyCompetitors' type='Sdk.String'>Identify Competitors : Select whether information about competitors is included. </field>
this.IdentifyCompetitors = {};
this.IdentifyCompetitors.setValue = function (value) {
 ///<summary>Sets the IdentifyCompetitors value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Identify Competitors  : Select whether information about competitors is included. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: completed</para>
 /// <para>False Label: mark complete</para>
 /// </param>
IdentifyCompetitors.setValue(value);
};
this.IdentifyCompetitors.getValue = function () {
 ///<summary>
 /// Gets the IdentifyCompetitors value
 ///</summary>
 /// <returns type="Boolean">Select whether information about competitors is included.</returns>
return IdentifyCompetitors.getValue();
}
// IdentifyCompetitors END --------------------------------------------------------------


// IdentifyCustomerContacts START --------------------------------------------------------------
var IdentifyCustomerContacts = new Sdk.Boolean("identifycustomercontacts");
this.addAttribute(IdentifyCustomerContacts, false);
/// <field name='IdentifyCustomerContacts' type='Sdk.String'>Identify Customer Contacts : Select whether the customer contacts for this opportunity have been identified. </field>
this.IdentifyCustomerContacts = {};
this.IdentifyCustomerContacts.setValue = function (value) {
 ///<summary>Sets the IdentifyCustomerContacts value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Identify Customer Contacts  : Select whether the customer contacts for this opportunity have been identified. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: completed</para>
 /// <para>False Label: mark complete</para>
 /// </param>
IdentifyCustomerContacts.setValue(value);
};
this.IdentifyCustomerContacts.getValue = function () {
 ///<summary>
 /// Gets the IdentifyCustomerContacts value
 ///</summary>
 /// <returns type="Boolean">Select whether the customer contacts for this opportunity have been identified.</returns>
return IdentifyCustomerContacts.getValue();
}
// IdentifyCustomerContacts END --------------------------------------------------------------


// IdentifyPursuitTeam START --------------------------------------------------------------
var IdentifyPursuitTeam = new Sdk.Boolean("identifypursuitteam");
this.addAttribute(IdentifyPursuitTeam, false);
/// <field name='IdentifyPursuitTeam' type='Sdk.String'>Identify Sales Team : Choose whether you have recorded who will pursue the opportunity. </field>
this.IdentifyPursuitTeam = {};
this.IdentifyPursuitTeam.setValue = function (value) {
 ///<summary>Sets the IdentifyPursuitTeam value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Identify Sales Team  : Choose whether you have recorded who will pursue the opportunity. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: completed</para>
 /// <para>False Label: mark complete</para>
 /// </param>
IdentifyPursuitTeam.setValue(value);
};
this.IdentifyPursuitTeam.getValue = function () {
 ///<summary>
 /// Gets the IdentifyPursuitTeam value
 ///</summary>
 /// <returns type="Boolean">Choose whether you have recorded who will pursue the opportunity.</returns>
return IdentifyPursuitTeam.getValue();
}
// IdentifyPursuitTeam END --------------------------------------------------------------


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


// InitialCommunication START --------------------------------------------------------------
var InitialCommunication = new Sdk.OptionSet("initialcommunication");
  this.addAttribute(InitialCommunication, false);
  /// <field name='InitialCommunication' type='Sdk.OptionSet'>Initial Communication : Choose whether someone from the sales team contacted this lead earlier.</field>
  this.InitialCommunication = {};
 this.InitialCommunication.setValue = function (value) {
  ///<summary><para>Sets the InitialCommunication (Initial Communication) value</para>
   /// <para>Choose whether someone from the sales team contacted this lead earlier.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 0 : Contacted</para>
/// <para> 1 : Not Contacted</para>
   /// </param>
   InitialCommunication.setValue(value);
  };
  this.InitialCommunication.getValue = function () {
   ///<summary>Gets the InitialCommunication value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Choose whether someone from the sales team contacted this lead earlier.</returns>
   return InitialCommunication.getValue();
  }
// InitialCommunication END --------------------------------------------------------------


// IsPrivate START --------------------------------------------------------------
var IsPrivate = new Sdk.Boolean("isprivate");
this.addAttribute(IsPrivate, false);
/// <field name='IsPrivate' type='Sdk.String'>Is Private : Indicates whether the opportunity is private or visible to the entire organization. </field>
this.IsPrivate = {};
// IsPrivate END --------------------------------------------------------------


// IsRevenueSystemCalculated START --------------------------------------------------------------
var IsRevenueSystemCalculated = new Sdk.Boolean("isrevenuesystemcalculated");
this.addAttribute(IsRevenueSystemCalculated, false);
/// <field name='IsRevenueSystemCalculated' type='Sdk.String'>Revenue : Select whether the estimated revenue for the opportunity is calculated automatically based on the products entered or entered manually by a user. </field>
this.IsRevenueSystemCalculated = {};
this.IsRevenueSystemCalculated.setValue = function (value) {
 ///<summary>Sets the IsRevenueSystemCalculated value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Revenue  : Select whether the estimated revenue for the opportunity is calculated automatically based on the products entered or entered manually by a user. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: System Calculated</para>
 /// <para>False Label: User Provided</para>
 /// </param>
IsRevenueSystemCalculated.setValue(value);
};
this.IsRevenueSystemCalculated.getValue = function () {
 ///<summary>
 /// Gets the IsRevenueSystemCalculated value
 ///</summary>
 /// <returns type="Boolean">Select whether the estimated revenue for the opportunity is calculated automatically based on the products entered or entered manually by a user.</returns>
return IsRevenueSystemCalculated.getValue();
}
// IsRevenueSystemCalculated END --------------------------------------------------------------


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


// Name START --------------------------------------------------------------
  var Name = new Sdk.String("name");
  this.addAttribute(Name, false);
  /// <field name='Name' type='Sdk.String'>Topic : Type a subject or descriptive name, such as the expected order or company name, for the opportunity.</field>
this.Name = {};
  this.Name.setValue = function (value) {
   ///<summary>Sets the Name value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Topic : Type a subject or descriptive name, such as the expected order or company name, for the opportunity.</para>
   /// <para>MaxLength: 300</para>
   /// <para>RequiredLevel: ApplicationRequired</para>
   /// </param>
   Name.setValue(value);
  };
  this.Name.getValue = function () {
   ///<summary>
   /// Gets the Name value
   ///</summary>
   /// <returns type="String">Type a subject or descriptive name, such as the expected order or company name, for the opportunity.</returns>
   return Name.getValue();
  }
// Name END --------------------------------------------------------------


// Need START --------------------------------------------------------------
var Need = new Sdk.OptionSet("need");
  this.addAttribute(Need, false);
  /// <field name='Need' type='Sdk.OptionSet'>Need : Choose how high the level of need is for the lead's company.</field>
  this.Need = {};
 this.Need.setValue = function (value) {
  ///<summary><para>Sets the Need (Need) value</para>
   /// <para>Choose how high the level of need is for the lead's company.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 0 : Must have</para>
/// <para> 1 : Should have</para>
/// <para> 2 : Good to have</para>
/// <para> 3 : No need</para>
   /// </param>
   Need.setValue(value);
  };
  this.Need.getValue = function () {
   ///<summary>Gets the Need value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Choose how high the level of need is for the lead's company.</returns>
   return Need.getValue();
  }
// Need END --------------------------------------------------------------


// OpportunityId START --------------------------------------------------------------
var OpportunityId = new Sdk.Guid("opportunityid");
this.addAttribute(OpportunityId, false);
 /// <field name='OpportunityId' type='Sdk.Guid'>Opportunity : Unique identifier of the opportunity.</field>
this.OpportunityId = {};
this.OpportunityId.setValue = function (value) {
 ///<summary><para>Sets the OpportunityId (Opportunity) value</para>
 /// <para>RequiredLevel: SystemRequired</para>
 ///</summary>
 /// <param name="value" type="String" mayBeNull="true" optional="false">Unique identifier of the opportunity.</param>
OpportunityId.setValue(value);
};
this.OpportunityId.getValue = function () {
 ///<summary>Gets the OpportunityId value</summary>
 /// <returns type="String" mayBeNull="true">Unique identifier of the opportunity.</returns>
return OpportunityId.getValue();
}
// OpportunityId END --------------------------------------------------------------


// OpportunityRatingCode START --------------------------------------------------------------
var OpportunityRatingCode = new Sdk.OptionSet("opportunityratingcode");
  this.addAttribute(OpportunityRatingCode, false);
  /// <field name='OpportunityRatingCode' type='Sdk.OptionSet'>Rating : Select the expected value or priority of the opportunity based on revenue, customer status, or closing probability.</field>
  this.OpportunityRatingCode = {};
 this.OpportunityRatingCode.setValue = function (value) {
  ///<summary><para>Sets the OpportunityRatingCode (Rating) value</para>
   /// <para>Select the expected value or priority of the opportunity based on revenue, customer status, or closing probability.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Hot</para>
/// <para> 2 : Warm</para>
/// <para> 3 : Cold</para>
   /// </param>
   OpportunityRatingCode.setValue(value);
  };
  this.OpportunityRatingCode.getValue = function () {
   ///<summary>Gets the OpportunityRatingCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the expected value or priority of the opportunity based on revenue, customer status, or closing probability.</returns>
   return OpportunityRatingCode.getValue();
  }
// OpportunityRatingCode END --------------------------------------------------------------


// OriginatingLeadId START --------------------------------------------------------------
var OriginatingLeadId = new Sdk.Lookup("originatingleadid");
this.addAttribute(OriginatingLeadId, false);
/// <field name='OriginatingLeadId' type='Sdk.Lookup'>Originating Lead : Choose the lead that the opportunity was created from for reporting and analytics. The field is read-only after the opportunity is created and defaults to the correct lead when an opportunity is created from a converted lead.</field>
this.OriginatingLeadId = {};
this.OriginatingLeadId.setValue = function (value) {
///<summary><para>Sets the OriginatingLeadId value</para>
/// <para>Display Name: Originating Lead</para>
/// <para>Targets: lead</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Choose the lead that the opportunity was created from for reporting and analytics. The field is read-only after the opportunity is created and defaults to the correct lead when an opportunity is created from a converted lead.</param>
 OriginatingLeadId.setValue(value);
};
this.OriginatingLeadId.getValue = function () {
 ///<summary>
 /// Gets the OriginatingLeadId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Choose the lead that the opportunity was created from for reporting and analytics. The field is read-only after the opportunity is created and defaults to the correct lead when an opportunity is created from a converted lead.</returns>
 return OriginatingLeadId.getValue();
}
// OriginatingLeadId END --------------------------------------------------------------


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
/// <field name='OwningBusinessUnit' type='Sdk.Lookup'>Owning Business Unit : Unique identifier of the business unit that owns the opportunity.</field>
this.OwningBusinessUnit = {};
this.OwningBusinessUnit.getValue = function () {
 ///<summary>
 /// Gets the OwningBusinessUnit value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Unique identifier of the business unit that owns the opportunity.</returns>
 return OwningBusinessUnit.getValue();
}
// OwningBusinessUnit END --------------------------------------------------------------


// OwningTeam START --------------------------------------------------------------
var OwningTeam = new Sdk.Lookup("owningteam");
this.addAttribute(OwningTeam, false);
/// <field name='OwningTeam' type='Sdk.Lookup'>Owning Team : Unique identifier of the team who owns the opportunity.</field>
this.OwningTeam = {};
this.OwningTeam.getValue = function () {
 ///<summary>
 /// Gets the OwningTeam value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Unique identifier of the team who owns the opportunity.</returns>
 return OwningTeam.getValue();
}
// OwningTeam END --------------------------------------------------------------


// OwningUser START --------------------------------------------------------------
var OwningUser = new Sdk.Lookup("owninguser");
this.addAttribute(OwningUser, false);
/// <field name='OwningUser' type='Sdk.Lookup'>Owning User : Unique identifier of the user who owns the opportunity.</field>
this.OwningUser = {};
this.OwningUser.getValue = function () {
 ///<summary>
 /// Gets the OwningUser value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Unique identifier of the user who owns the opportunity.</returns>
 return OwningUser.getValue();
}
// OwningUser END --------------------------------------------------------------


// ParentAccountId START --------------------------------------------------------------
var ParentAccountId = new Sdk.Lookup("parentaccountid");
this.addAttribute(ParentAccountId, false);
/// <field name='ParentAccountId' type='Sdk.Lookup'>Account : Choose an account to connect this opportunity to, so that the relationship is visible in reports and analytics, and to provide a quick link to additional details, such as financial information and activities.</field>
this.ParentAccountId = {};
this.ParentAccountId.setValue = function (value) {
///<summary><para>Sets the ParentAccountId value</para>
/// <para>Display Name: Account</para>
/// <para>Targets: account</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Choose an account to connect this opportunity to, so that the relationship is visible in reports and analytics, and to provide a quick link to additional details, such as financial information and activities.</param>
 ParentAccountId.setValue(value);
};
this.ParentAccountId.getValue = function () {
 ///<summary>
 /// Gets the ParentAccountId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Choose an account to connect this opportunity to, so that the relationship is visible in reports and analytics, and to provide a quick link to additional details, such as financial information and activities.</returns>
 return ParentAccountId.getValue();
}
// ParentAccountId END --------------------------------------------------------------


// ParentContactId START --------------------------------------------------------------
var ParentContactId = new Sdk.Lookup("parentcontactid");
this.addAttribute(ParentContactId, false);
/// <field name='ParentContactId' type='Sdk.Lookup'>Contact : Choose a contact to connect this opportunity to, so that the relationship is visible in reports and analytics.</field>
this.ParentContactId = {};
this.ParentContactId.setValue = function (value) {
///<summary><para>Sets the ParentContactId value</para>
/// <para>Display Name: Contact</para>
/// <para>Targets: contact</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Choose a contact to connect this opportunity to, so that the relationship is visible in reports and analytics.</param>
 ParentContactId.setValue(value);
};
this.ParentContactId.getValue = function () {
 ///<summary>
 /// Gets the ParentContactId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Choose a contact to connect this opportunity to, so that the relationship is visible in reports and analytics.</returns>
 return ParentContactId.getValue();
}
// ParentContactId END --------------------------------------------------------------


// ParticipatesInWorkflow START --------------------------------------------------------------
var ParticipatesInWorkflow = new Sdk.Boolean("participatesinworkflow");
this.addAttribute(ParticipatesInWorkflow, false);
/// <field name='ParticipatesInWorkflow' type='Sdk.String'>Participates in Workflow : Information about whether the opportunity participates in workflow rules. </field>
this.ParticipatesInWorkflow = {};
this.ParticipatesInWorkflow.setValue = function (value) {
 ///<summary>Sets the ParticipatesInWorkflow value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Participates in Workflow  : Information about whether the opportunity participates in workflow rules. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: Yes</para>
 /// <para>False Label: No</para>
 /// </param>
ParticipatesInWorkflow.setValue(value);
};
this.ParticipatesInWorkflow.getValue = function () {
 ///<summary>
 /// Gets the ParticipatesInWorkflow value
 ///</summary>
 /// <returns type="Boolean">Information about whether the opportunity participates in workflow rules.</returns>
return ParticipatesInWorkflow.getValue();
}
// ParticipatesInWorkflow END --------------------------------------------------------------


// PresentFinalProposal START --------------------------------------------------------------
var PresentFinalProposal = new Sdk.Boolean("presentfinalproposal");
this.addAttribute(PresentFinalProposal, false);
/// <field name='PresentFinalProposal' type='Sdk.String'>Present Final Proposal : Select whether the final proposal has been presented to the account. </field>
this.PresentFinalProposal = {};
this.PresentFinalProposal.setValue = function (value) {
 ///<summary>Sets the PresentFinalProposal value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Present Final Proposal  : Select whether the final proposal has been presented to the account. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: completed</para>
 /// <para>False Label: mark complete</para>
 /// </param>
PresentFinalProposal.setValue(value);
};
this.PresentFinalProposal.getValue = function () {
 ///<summary>
 /// Gets the PresentFinalProposal value
 ///</summary>
 /// <returns type="Boolean">Select whether the final proposal has been presented to the account.</returns>
return PresentFinalProposal.getValue();
}
// PresentFinalProposal END --------------------------------------------------------------


// PresentProposal START --------------------------------------------------------------
var PresentProposal = new Sdk.Boolean("presentproposal");
this.addAttribute(PresentProposal, false);
/// <field name='PresentProposal' type='Sdk.String'>Presented Proposal : Select whether a proposal for the opportunity has been presented to the account. </field>
this.PresentProposal = {};
this.PresentProposal.setValue = function (value) {
 ///<summary>Sets the PresentProposal value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Presented Proposal  : Select whether a proposal for the opportunity has been presented to the account. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: completed</para>
 /// <para>False Label: mark complete</para>
 /// </param>
PresentProposal.setValue(value);
};
this.PresentProposal.getValue = function () {
 ///<summary>
 /// Gets the PresentProposal value
 ///</summary>
 /// <returns type="Boolean">Select whether a proposal for the opportunity has been presented to the account.</returns>
return PresentProposal.getValue();
}
// PresentProposal END --------------------------------------------------------------


// PriceLevelId START --------------------------------------------------------------
var PriceLevelId = new Sdk.Lookup("pricelevelid");
this.addAttribute(PriceLevelId, false);
/// <field name='PriceLevelId' type='Sdk.Lookup'>Price List : Choose the price list associated with this record to make sure the products associated with the campaign are offered at the correct prices.</field>
this.PriceLevelId = {};
this.PriceLevelId.setValue = function (value) {
///<summary><para>Sets the PriceLevelId value</para>
/// <para>Display Name: Price List</para>
/// <para>Targets: pricelevel</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Choose the price list associated with this record to make sure the products associated with the campaign are offered at the correct prices.</param>
 PriceLevelId.setValue(value);
};
this.PriceLevelId.getValue = function () {
 ///<summary>
 /// Gets the PriceLevelId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Choose the price list associated with this record to make sure the products associated with the campaign are offered at the correct prices.</returns>
 return PriceLevelId.getValue();
}
// PriceLevelId END --------------------------------------------------------------


// PricingErrorCode START --------------------------------------------------------------
var PricingErrorCode = new Sdk.OptionSet("pricingerrorcode");
  this.addAttribute(PricingErrorCode, false);
  /// <field name='PricingErrorCode' type='Sdk.OptionSet'>Pricing Error  : Pricing error for the opportunity.</field>
  this.PricingErrorCode = {};
 this.PricingErrorCode.setValue = function (value) {
  ///<summary><para>Sets the PricingErrorCode (Pricing Error ) value</para>
   /// <para>Pricing error for the opportunity.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 0 : None</para>
/// <para> 1 : Detail Error</para>
/// <para> 2 : Missing Price Level</para>
/// <para> 3 : Inactive Price Level</para>
/// <para> 4 : Missing Quantity</para>
/// <para> 5 : Missing Unit Price</para>
/// <para> 6 : Missing Product</para>
/// <para> 7 : Invalid Product</para>
/// <para> 8 : Missing Pricing Code</para>
/// <para> 9 : Invalid Pricing Code</para>
/// <para> 10 : Missing UOM</para>
/// <para> 11 : Product Not In Price Level</para>
/// <para> 12 : Missing Price Level Amount</para>
/// <para> 13 : Missing Price Level Percentage</para>
/// <para> 14 : Missing Price</para>
/// <para> 15 : Missing Current Cost</para>
/// <para> 16 : Missing Standard Cost</para>
/// <para> 17 : Invalid Price Level Amount</para>
/// <para> 18 : Invalid Price Level Percentage</para>
/// <para> 19 : Invalid Price</para>
/// <para> 20 : Invalid Current Cost</para>
/// <para> 21 : Invalid Standard Cost</para>
/// <para> 22 : Invalid Rounding Policy</para>
/// <para> 23 : Invalid Rounding Option</para>
/// <para> 24 : Invalid Rounding Amount</para>
/// <para> 25 : Price Calculation Error</para>
/// <para> 26 : Invalid Discount Type</para>
/// <para> 27 : Discount Type Invalid State</para>
/// <para> 28 : Invalid Discount</para>
/// <para> 29 : Invalid Quantity</para>
/// <para> 30 : Invalid Pricing Precision</para>
/// <para> 31 : Missing Product Default UOM</para>
/// <para> 32 : Missing Product UOM Schedule </para>
/// <para> 33 : Inactive Discount Type</para>
/// <para> 34 : Invalid Price Level Currency</para>
/// <para> 35 : Price Attribute Out Of Range</para>
/// <para> 36 : Base Currency Attribute Overflow</para>
/// <para> 37 : Base Currency Attribute Underflow</para>
   /// </param>
   PricingErrorCode.setValue(value);
  };
  this.PricingErrorCode.getValue = function () {
   ///<summary>Gets the PricingErrorCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Pricing error for the opportunity.</returns>
   return PricingErrorCode.getValue();
  }
// PricingErrorCode END --------------------------------------------------------------


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
/// <para> 1 : Default Value</para>
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


// ProposedSolution START --------------------------------------------------------------
  var ProposedSolution = new Sdk.String("proposedsolution");
  this.addAttribute(ProposedSolution, false);
  /// <field name='ProposedSolution' type='Sdk.String'>Proposed Solution : Type notes about the proposed solution for the opportunity.</field>
this.ProposedSolution = {};
  this.ProposedSolution.setValue = function (value) {
   ///<summary>Sets the ProposedSolution value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Proposed Solution : Type notes about the proposed solution for the opportunity.</para>
   /// <para>MaxLength: 2000</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   ProposedSolution.setValue(value);
  };
  this.ProposedSolution.getValue = function () {
   ///<summary>
   /// Gets the ProposedSolution value
   ///</summary>
   /// <returns type="String">Type notes about the proposed solution for the opportunity.</returns>
   return ProposedSolution.getValue();
  }
// ProposedSolution END --------------------------------------------------------------


// PurchaseProcess START --------------------------------------------------------------
var PurchaseProcess = new Sdk.OptionSet("purchaseprocess");
  this.addAttribute(PurchaseProcess, false);
  /// <field name='PurchaseProcess' type='Sdk.OptionSet'>Purchase Process : Choose whether an individual or a committee will be involved in the purchase process for the lead.</field>
  this.PurchaseProcess = {};
 this.PurchaseProcess.setValue = function (value) {
  ///<summary><para>Sets the PurchaseProcess (Purchase Process) value</para>
   /// <para>Choose whether an individual or a committee will be involved in the purchase process for the lead.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 0 : Individual</para>
/// <para> 1 : Committee</para>
/// <para> 2 : Unknown</para>
   /// </param>
   PurchaseProcess.setValue(value);
  };
  this.PurchaseProcess.getValue = function () {
   ///<summary>Gets the PurchaseProcess value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Choose whether an individual or a committee will be involved in the purchase process for the lead.</returns>
   return PurchaseProcess.getValue();
  }
// PurchaseProcess END --------------------------------------------------------------


// PurchaseTimeframe START --------------------------------------------------------------
var PurchaseTimeframe = new Sdk.OptionSet("purchasetimeframe");
  this.addAttribute(PurchaseTimeframe, false);
  /// <field name='PurchaseTimeframe' type='Sdk.OptionSet'>Purchase Timeframe : Choose how long the lead will likely take to make the purchase.</field>
  this.PurchaseTimeframe = {};
 this.PurchaseTimeframe.setValue = function (value) {
  ///<summary><para>Sets the PurchaseTimeframe (Purchase Timeframe) value</para>
   /// <para>Choose how long the lead will likely take to make the purchase.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 0 : Immediate</para>
/// <para> 1 : This Quarter</para>
/// <para> 2 : Next Quarter</para>
/// <para> 3 : This Year</para>
/// <para> 4 : Unknown</para>
   /// </param>
   PurchaseTimeframe.setValue(value);
  };
  this.PurchaseTimeframe.getValue = function () {
   ///<summary>Gets the PurchaseTimeframe value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Choose how long the lead will likely take to make the purchase.</returns>
   return PurchaseTimeframe.getValue();
  }
// PurchaseTimeframe END --------------------------------------------------------------


// PursuitDecision START --------------------------------------------------------------
var PursuitDecision = new Sdk.Boolean("pursuitdecision");
this.addAttribute(PursuitDecision, false);
/// <field name='PursuitDecision' type='Sdk.String'>Decide Go/No-Go : Select whether the decision about pursuing the opportunity has been made. </field>
this.PursuitDecision = {};
this.PursuitDecision.setValue = function (value) {
 ///<summary>Sets the PursuitDecision value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Decide Go/No-Go  : Select whether the decision about pursuing the opportunity has been made. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: No</para>
 /// <para>False Label: Yes</para>
 /// </param>
PursuitDecision.setValue(value);
};
this.PursuitDecision.getValue = function () {
 ///<summary>
 /// Gets the PursuitDecision value
 ///</summary>
 /// <returns type="Boolean">Select whether the decision about pursuing the opportunity has been made.</returns>
return PursuitDecision.getValue();
}
// PursuitDecision END --------------------------------------------------------------


// QualificationComments START --------------------------------------------------------------
  var QualificationComments = new Sdk.String("qualificationcomments");
  this.addAttribute(QualificationComments, false);
  /// <field name='QualificationComments' type='Sdk.String'>Qualification Comments : Type comments about the qualification or scoring of the lead.</field>
this.QualificationComments = {};
  this.QualificationComments.setValue = function (value) {
   ///<summary>Sets the QualificationComments value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Qualification Comments : Type comments about the qualification or scoring of the lead.</para>
   /// <para>MaxLength: 2000</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   QualificationComments.setValue(value);
  };
  this.QualificationComments.getValue = function () {
   ///<summary>
   /// Gets the QualificationComments value
   ///</summary>
   /// <returns type="String">Type comments about the qualification or scoring of the lead.</returns>
   return QualificationComments.getValue();
  }
// QualificationComments END --------------------------------------------------------------


// QuoteComments START --------------------------------------------------------------
  var QuoteComments = new Sdk.String("quotecomments");
  this.addAttribute(QuoteComments, false);
  /// <field name='QuoteComments' type='Sdk.String'>Quote Comments : Type comments about the quotes associated with the opportunity.</field>
this.QuoteComments = {};
  this.QuoteComments.setValue = function (value) {
   ///<summary>Sets the QuoteComments value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Quote Comments : Type comments about the quotes associated with the opportunity.</para>
   /// <para>MaxLength: 2000</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   QuoteComments.setValue(value);
  };
  this.QuoteComments.getValue = function () {
   ///<summary>
   /// Gets the QuoteComments value
   ///</summary>
   /// <returns type="String">Type comments about the quotes associated with the opportunity.</returns>
   return QuoteComments.getValue();
  }
// QuoteComments END --------------------------------------------------------------


// ResolveFeedback START --------------------------------------------------------------
var ResolveFeedback = new Sdk.Boolean("resolvefeedback");
this.addAttribute(ResolveFeedback, false);
/// <field name='ResolveFeedback' type='Sdk.String'>Feedback Resolved : Choose whether the proposal feedback has been captured and resolved for the opportunity. </field>
this.ResolveFeedback = {};
this.ResolveFeedback.setValue = function (value) {
 ///<summary>Sets the ResolveFeedback value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Feedback Resolved  : Choose whether the proposal feedback has been captured and resolved for the opportunity. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: No</para>
 /// <para>False Label: Yes</para>
 /// </param>
ResolveFeedback.setValue(value);
};
this.ResolveFeedback.getValue = function () {
 ///<summary>
 /// Gets the ResolveFeedback value
 ///</summary>
 /// <returns type="Boolean">Choose whether the proposal feedback has been captured and resolved for the opportunity.</returns>
return ResolveFeedback.getValue();
}
// ResolveFeedback END --------------------------------------------------------------


// SalesStage START --------------------------------------------------------------
var SalesStage = new Sdk.OptionSet("salesstage");
  this.addAttribute(SalesStage, false);
  /// <field name='SalesStage' type='Sdk.OptionSet'>Sales Stage : Select the sales stage of this opportunity to aid the sales team in their efforts to win this opportunity.</field>
  this.SalesStage = {};
 this.SalesStage.setValue = function (value) {
  ///<summary><para>Sets the SalesStage (Sales Stage) value</para>
   /// <para>Select the sales stage of this opportunity to aid the sales team in their efforts to win this opportunity.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 0 : Qualify</para>
/// <para> 1 : Develop</para>
/// <para> 2 : Propose</para>
/// <para> 3 : Close</para>
   /// </param>
   SalesStage.setValue(value);
  };
  this.SalesStage.getValue = function () {
   ///<summary>Gets the SalesStage value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the sales stage of this opportunity to aid the sales team in their efforts to win this opportunity.</returns>
   return SalesStage.getValue();
  }
// SalesStage END --------------------------------------------------------------


// SalesStageCode START --------------------------------------------------------------
var SalesStageCode = new Sdk.OptionSet("salesstagecode");
  this.addAttribute(SalesStageCode, false);
  /// <field name='SalesStageCode' type='Sdk.OptionSet'>Process Code : Select the sales process stage for the opportunity to indicate the probability of closing the opportunity.</field>
  this.SalesStageCode = {};
 this.SalesStageCode.setValue = function (value) {
  ///<summary><para>Sets the SalesStageCode (Process Code) value</para>
   /// <para>Select the sales process stage for the opportunity to indicate the probability of closing the opportunity.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Default Value</para>
   /// </param>
   SalesStageCode.setValue(value);
  };
  this.SalesStageCode.getValue = function () {
   ///<summary>Gets the SalesStageCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the sales process stage for the opportunity to indicate the probability of closing the opportunity.</returns>
   return SalesStageCode.getValue();
  }
// SalesStageCode END --------------------------------------------------------------


// ScheduleFollowup_Prospect START --------------------------------------------------------------
var ScheduleFollowup_Prospect = new Sdk.DateTime("schedulefollowup_prospect");
this.addAttribute(ScheduleFollowup_Prospect, false);
/// <field name='ScheduleFollowup_Prospect' type='Sdk.DateTime'>Scheduled Follow up (Prospect) : Enter the date and time of the prospecting follow-up meeting with the lead.</field>
this.ScheduleFollowup_Prospect = {};
this.ScheduleFollowup_Prospect.setValue = function (value) {
 ///<summary><para>Sets the ScheduleFollowup_Prospect (Scheduled Follow up (Prospect)) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="Date" optional="false">Enter the date and time of the prospecting follow-up meeting with the lead.</param>
 ScheduleFollowup_Prospect.setValue(value);
};
this.ScheduleFollowup_Prospect.getValue = function () {
 ///<summary>
 /// Gets the ScheduleFollowup_Prospect value
 ///</summary>
 /// <returns type="Date">Enter the date and time of the prospecting follow-up meeting with the lead.</returns>
 return ScheduleFollowup_Prospect.getValue();
}
// ScheduleFollowup_Prospect END --------------------------------------------------------------


// ScheduleFollowup_Qualify START --------------------------------------------------------------
var ScheduleFollowup_Qualify = new Sdk.DateTime("schedulefollowup_qualify");
this.addAttribute(ScheduleFollowup_Qualify, false);
/// <field name='ScheduleFollowup_Qualify' type='Sdk.DateTime'>Scheduled Follow up (Qualify) : Enter the date and time of the qualifying follow-up meeting with the lead.</field>
this.ScheduleFollowup_Qualify = {};
this.ScheduleFollowup_Qualify.setValue = function (value) {
 ///<summary><para>Sets the ScheduleFollowup_Qualify (Scheduled Follow up (Qualify)) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="Date" optional="false">Enter the date and time of the qualifying follow-up meeting with the lead.</param>
 ScheduleFollowup_Qualify.setValue(value);
};
this.ScheduleFollowup_Qualify.getValue = function () {
 ///<summary>
 /// Gets the ScheduleFollowup_Qualify value
 ///</summary>
 /// <returns type="Date">Enter the date and time of the qualifying follow-up meeting with the lead.</returns>
 return ScheduleFollowup_Qualify.getValue();
}
// ScheduleFollowup_Qualify END --------------------------------------------------------------


// ScheduleProposalMeeting START --------------------------------------------------------------
var ScheduleProposalMeeting = new Sdk.DateTime("scheduleproposalmeeting");
this.addAttribute(ScheduleProposalMeeting, false);
/// <field name='ScheduleProposalMeeting' type='Sdk.DateTime'>Schedule Proposal Meeting : Enter the date and time of the proposal meeting for the opportunity.</field>
this.ScheduleProposalMeeting = {};
this.ScheduleProposalMeeting.setValue = function (value) {
 ///<summary><para>Sets the ScheduleProposalMeeting (Schedule Proposal Meeting) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="Date" optional="false">Enter the date and time of the proposal meeting for the opportunity.</param>
 ScheduleProposalMeeting.setValue(value);
};
this.ScheduleProposalMeeting.getValue = function () {
 ///<summary>
 /// Gets the ScheduleProposalMeeting value
 ///</summary>
 /// <returns type="Date">Enter the date and time of the proposal meeting for the opportunity.</returns>
 return ScheduleProposalMeeting.getValue();
}
// ScheduleProposalMeeting END --------------------------------------------------------------


// SendThankYouNote START --------------------------------------------------------------
var SendThankYouNote = new Sdk.Boolean("sendthankyounote");
this.addAttribute(SendThankYouNote, false);
/// <field name='SendThankYouNote' type='Sdk.String'>Send Thank You Note : Select whether a thank you note has been sent to the account for considering the proposal. </field>
this.SendThankYouNote = {};
this.SendThankYouNote.setValue = function (value) {
 ///<summary>Sets the SendThankYouNote value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Send Thank You Note  : Select whether a thank you note has been sent to the account for considering the proposal. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: completed</para>
 /// <para>False Label: mark complete</para>
 /// </param>
SendThankYouNote.setValue(value);
};
this.SendThankYouNote.getValue = function () {
 ///<summary>
 /// Gets the SendThankYouNote value
 ///</summary>
 /// <returns type="Boolean">Select whether a thank you note has been sent to the account for considering the proposal.</returns>
return SendThankYouNote.getValue();
}
// SendThankYouNote END --------------------------------------------------------------


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
  /// <field name='StateCode' type='Sdk.OptionSet'>Status : Shows whether the opportunity is open, won, or lost. Won and lost opportunities are read-only and can't be edited until they are reactivated.</field>
  this.StateCode = {};
  this.StateCode.getValue = function () {
   ///<summary>Gets the StateCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Shows whether the opportunity is open, won, or lost. Won and lost opportunities are read-only and can't be edited until they are reactivated.</returns>
   return StateCode.getValue();
  }
// StateCode END --------------------------------------------------------------


// StatusCode START --------------------------------------------------------------
var StatusCode = new Sdk.OptionSet("statuscode");
  this.addAttribute(StatusCode, false);
  /// <field name='StatusCode' type='Sdk.OptionSet'>Status Reason : Select the opportunity's status.</field>
  this.StatusCode = {};
 this.StatusCode.setValue = function (value) {
  ///<summary><para>Sets the StatusCode (Status Reason) value</para>
   /// <para>Select the opportunity's status.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : In Progress State 0</para>
/// <para> 2 : On Hold State 0</para>
/// <para> 3 : Won State 1</para>
/// <para> 4 : Canceled State 2</para>
/// <para> 5 : Out-Sold State 2</para>
   /// </param>
   StatusCode.setValue(value);
  };
  this.StatusCode.getValue = function () {
   ///<summary>Gets the StatusCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the opportunity's status.</returns>
   return StatusCode.getValue();
  }
// StatusCode END --------------------------------------------------------------


// StepId START --------------------------------------------------------------
var StepId = new Sdk.Guid("stepid");
this.addAttribute(StepId, false);
 /// <field name='StepId' type='Sdk.Guid'>Step : Shows the ID of the workflow step.</field>
this.StepId = {};
this.StepId.setValue = function (value) {
 ///<summary><para>Sets the StepId (Step) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="String" mayBeNull="true" optional="false">Shows the ID of the workflow step.</param>
StepId.setValue(value);
};
this.StepId.getValue = function () {
 ///<summary>Gets the StepId value</summary>
 /// <returns type="String" mayBeNull="true">Shows the ID of the workflow step.</returns>
return StepId.getValue();
}
// StepId END --------------------------------------------------------------


// StepName START --------------------------------------------------------------
  var StepName = new Sdk.String("stepname");
  this.addAttribute(StepName, false);
  /// <field name='StepName' type='Sdk.String'>Pipeline Phase : Shows the current phase in the sales pipeline for the opportunity. This is updated by a workflow.</field>
this.StepName = {};
  this.StepName.setValue = function (value) {
   ///<summary>Sets the StepName value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Pipeline Phase : Shows the current phase in the sales pipeline for the opportunity. This is updated by a workflow.</para>
   /// <para>MaxLength: 200</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   StepName.setValue(value);
  };
  this.StepName.getValue = function () {
   ///<summary>
   /// Gets the StepName value
   ///</summary>
   /// <returns type="String">Shows the current phase in the sales pipeline for the opportunity. This is updated by a workflow.</returns>
   return StepName.getValue();
  }
// StepName END --------------------------------------------------------------


// TimeLine START --------------------------------------------------------------
var TimeLine = new Sdk.OptionSet("timeline");
  this.addAttribute(TimeLine, false);
  /// <field name='TimeLine' type='Sdk.OptionSet'>Timeline : Select when the opportunity is likely to be closed.</field>
  this.TimeLine = {};
 this.TimeLine.setValue = function (value) {
  ///<summary><para>Sets the TimeLine (Timeline) value</para>
   /// <para>Select when the opportunity is likely to be closed.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 0 : Immediate</para>
/// <para> 1 : This Quarter</para>
/// <para> 2 : Next Quarter</para>
/// <para> 3 : This Year</para>
/// <para> 4 : Not known</para>
   /// </param>
   TimeLine.setValue(value);
  };
  this.TimeLine.getValue = function () {
   ///<summary>Gets the TimeLine value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select when the opportunity is likely to be closed.</returns>
   return TimeLine.getValue();
  }
// TimeLine END --------------------------------------------------------------


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


// TotalAmount START --------------------------------------------------------------
var TotalAmount = new Sdk.Money("totalamount");
this.addAttribute(TotalAmount, false);
/// <field name='TotalAmount' type='Sdk.Money'>Total Amount : Shows the total amount due, calculated as the sum of the products, discounts, freight, and taxes for the opportunity.</field>
this.TotalAmount = {};
this.TotalAmount.getValue = function () {
 ///<summary>
 /// Gets the TotalAmount value
 ///</summary>
 /// <returns type="Number">Shows the total amount due, calculated as the sum of the products, discounts, freight, and taxes for the opportunity.</returns>
 return TotalAmount.getValue();
}
// TotalAmount END --------------------------------------------------------------


// TotalAmount_Base START --------------------------------------------------------------
var TotalAmount_Base = new Sdk.Money("totalamount_base");
this.addAttribute(TotalAmount_Base, false);
/// <field name='TotalAmount_Base' type='Sdk.Money'>Total Amount (Base) : Shows the Total Amount field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</field>
this.TotalAmount_Base = {};
this.TotalAmount_Base.getValue = function () {
 ///<summary>
 /// Gets the TotalAmount_Base value
 ///</summary>
 /// <returns type="Number">Shows the Total Amount field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</returns>
 return TotalAmount_Base.getValue();
}
// TotalAmount_Base END --------------------------------------------------------------


// TotalAmountLessFreight START --------------------------------------------------------------
var TotalAmountLessFreight = new Sdk.Money("totalamountlessfreight");
this.addAttribute(TotalAmountLessFreight, false);
/// <field name='TotalAmountLessFreight' type='Sdk.Money'>Total Pre-Freight Amount : Shows the total product amount for the opportunity, minus any discounts. This value is added to freight and tax amounts in the calculation for the total amount of the opportunity.</field>
this.TotalAmountLessFreight = {};
this.TotalAmountLessFreight.getValue = function () {
 ///<summary>
 /// Gets the TotalAmountLessFreight value
 ///</summary>
 /// <returns type="Number">Shows the total product amount for the opportunity, minus any discounts. This value is added to freight and tax amounts in the calculation for the total amount of the opportunity.</returns>
 return TotalAmountLessFreight.getValue();
}
// TotalAmountLessFreight END --------------------------------------------------------------


// TotalAmountLessFreight_Base START --------------------------------------------------------------
var TotalAmountLessFreight_Base = new Sdk.Money("totalamountlessfreight_base");
this.addAttribute(TotalAmountLessFreight_Base, false);
/// <field name='TotalAmountLessFreight_Base' type='Sdk.Money'>Total Pre-Freight Amount (Base) : Shows the Total Pre-Freight Amount field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</field>
this.TotalAmountLessFreight_Base = {};
this.TotalAmountLessFreight_Base.getValue = function () {
 ///<summary>
 /// Gets the TotalAmountLessFreight_Base value
 ///</summary>
 /// <returns type="Number">Shows the Total Pre-Freight Amount field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</returns>
 return TotalAmountLessFreight_Base.getValue();
}
// TotalAmountLessFreight_Base END --------------------------------------------------------------


// TotalDiscountAmount START --------------------------------------------------------------
var TotalDiscountAmount = new Sdk.Money("totaldiscountamount");
this.addAttribute(TotalDiscountAmount, false);
/// <field name='TotalDiscountAmount' type='Sdk.Money'>Total Discount Amount : Shows the total discount amount, based on the discount price and rate entered on the opportunity.</field>
this.TotalDiscountAmount = {};
this.TotalDiscountAmount.getValue = function () {
 ///<summary>
 /// Gets the TotalDiscountAmount value
 ///</summary>
 /// <returns type="Number">Shows the total discount amount, based on the discount price and rate entered on the opportunity.</returns>
 return TotalDiscountAmount.getValue();
}
// TotalDiscountAmount END --------------------------------------------------------------


// TotalDiscountAmount_Base START --------------------------------------------------------------
var TotalDiscountAmount_Base = new Sdk.Money("totaldiscountamount_base");
this.addAttribute(TotalDiscountAmount_Base, false);
/// <field name='TotalDiscountAmount_Base' type='Sdk.Money'>Total Discount Amount (Base) : Shows the Total Discount Amount field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</field>
this.TotalDiscountAmount_Base = {};
this.TotalDiscountAmount_Base.getValue = function () {
 ///<summary>
 /// Gets the TotalDiscountAmount_Base value
 ///</summary>
 /// <returns type="Number">Shows the Total Discount Amount field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</returns>
 return TotalDiscountAmount_Base.getValue();
}
// TotalDiscountAmount_Base END --------------------------------------------------------------


// TotalLineItemAmount START --------------------------------------------------------------
var TotalLineItemAmount = new Sdk.Money("totallineitemamount");
this.addAttribute(TotalLineItemAmount, false);
/// <field name='TotalLineItemAmount' type='Sdk.Money'>Total Detail Amount : Shows the sum of all existing and write-in products included on the opportunity, based on the specified price list and quantities.</field>
this.TotalLineItemAmount = {};
this.TotalLineItemAmount.getValue = function () {
 ///<summary>
 /// Gets the TotalLineItemAmount value
 ///</summary>
 /// <returns type="Number">Shows the sum of all existing and write-in products included on the opportunity, based on the specified price list and quantities.</returns>
 return TotalLineItemAmount.getValue();
}
// TotalLineItemAmount END --------------------------------------------------------------


// TotalLineItemAmount_Base START --------------------------------------------------------------
var TotalLineItemAmount_Base = new Sdk.Money("totallineitemamount_base");
this.addAttribute(TotalLineItemAmount_Base, false);
/// <field name='TotalLineItemAmount_Base' type='Sdk.Money'>Total Detail Amount (Base) : Shows the Total Detail Amount field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</field>
this.TotalLineItemAmount_Base = {};
this.TotalLineItemAmount_Base.getValue = function () {
 ///<summary>
 /// Gets the TotalLineItemAmount_Base value
 ///</summary>
 /// <returns type="Number">Shows the Total Detail Amount field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</returns>
 return TotalLineItemAmount_Base.getValue();
}
// TotalLineItemAmount_Base END --------------------------------------------------------------


// TotalLineItemDiscountAmount START --------------------------------------------------------------
var TotalLineItemDiscountAmount = new Sdk.Money("totallineitemdiscountamount");
this.addAttribute(TotalLineItemDiscountAmount, false);
/// <field name='TotalLineItemDiscountAmount' type='Sdk.Money'>Total Line Item Discount Amount : Shows the total of the Manual Discount amounts specified on all products included in the opportunity. This value is reflected in the Total Detail Amount field on the opportunity and is added to any discount amount or rate specified on the opportunity.</field>
this.TotalLineItemDiscountAmount = {};
this.TotalLineItemDiscountAmount.getValue = function () {
 ///<summary>
 /// Gets the TotalLineItemDiscountAmount value
 ///</summary>
 /// <returns type="Number">Shows the total of the Manual Discount amounts specified on all products included in the opportunity. This value is reflected in the Total Detail Amount field on the opportunity and is added to any discount amount or rate specified on the opportunity.</returns>
 return TotalLineItemDiscountAmount.getValue();
}
// TotalLineItemDiscountAmount END --------------------------------------------------------------


// TotalLineItemDiscountAmount_Base START --------------------------------------------------------------
var TotalLineItemDiscountAmount_Base = new Sdk.Money("totallineitemdiscountamount_base");
this.addAttribute(TotalLineItemDiscountAmount_Base, false);
/// <field name='TotalLineItemDiscountAmount_Base' type='Sdk.Money'>Total Line Item Discount Amount (Base) : Shows the Total Line Item Discount Amount field to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</field>
this.TotalLineItemDiscountAmount_Base = {};
this.TotalLineItemDiscountAmount_Base.getValue = function () {
 ///<summary>
 /// Gets the TotalLineItemDiscountAmount_Base value
 ///</summary>
 /// <returns type="Number">Shows the Total Line Item Discount Amount field to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</returns>
 return TotalLineItemDiscountAmount_Base.getValue();
}
// TotalLineItemDiscountAmount_Base END --------------------------------------------------------------


// TotalTax START --------------------------------------------------------------
var TotalTax = new Sdk.Money("totaltax");
this.addAttribute(TotalTax, false);
/// <field name='TotalTax' type='Sdk.Money'>Total Tax : Shows the total of the Tax amounts specified on all products included in the opportunity, included in the Total Amount field calculation for the opportunity.</field>
this.TotalTax = {};
this.TotalTax.getValue = function () {
 ///<summary>
 /// Gets the TotalTax value
 ///</summary>
 /// <returns type="Number">Shows the total of the Tax amounts specified on all products included in the opportunity, included in the Total Amount field calculation for the opportunity.</returns>
 return TotalTax.getValue();
}
// TotalTax END --------------------------------------------------------------


// TotalTax_Base START --------------------------------------------------------------
var TotalTax_Base = new Sdk.Money("totaltax_base");
this.addAttribute(TotalTax_Base, false);
/// <field name='TotalTax_Base' type='Sdk.Money'>Total Tax (Base) : Shows the Total Tax field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</field>
this.TotalTax_Base = {};
this.TotalTax_Base.getValue = function () {
 ///<summary>
 /// Gets the TotalTax_Base value
 ///</summary>
 /// <returns type="Number">Shows the Total Tax field converted to the system's default base currency for reporting purposes. The calculation uses the exchange rate specified in the Currencies area.</returns>
 return TotalTax_Base.getValue();
}
// TotalTax_Base END --------------------------------------------------------------


// TransactionCurrencyId START --------------------------------------------------------------
var TransactionCurrencyId = new Sdk.Lookup("transactioncurrencyid");
this.addAttribute(TransactionCurrencyId, false);
/// <field name='TransactionCurrencyId' type='Sdk.Lookup'>Currency : Choose the local currency for the record to make sure budgets are reported in the correct currency.</field>
this.TransactionCurrencyId = {};
this.TransactionCurrencyId.setValue = function (value) {
///<summary><para>Sets the TransactionCurrencyId value</para>
/// <para>Display Name: Currency</para>
/// <para>Targets: transactioncurrency</para>
/// <para>RequiredLevel: ApplicationRequired</para>
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
/// <field name='VersionNumber' type='Sdk.Long'>Version Number : Version number of the opportunity.</field>
this.VersionNumber = {};
this.VersionNumber.getValue = function () {
 ///<summary>
 /// Gets the VersionNumber value
 ///</summary>
 /// <returns type="Number">Version number of the opportunity.</returns>
 return VersionNumber.getValue();
}
// VersionNumber END --------------------------------------------------------------

 };
}).call(Sdk)
Sdk.Opportunity.prototype = new Sdk.Entity("opportunity");

(function () {
 this.OneToMany = function () {
  /// <summary>Properties represent the string values of One-to-Many relationships for Sdk.Opportunity</summary>
  /// <field name="CreatedOpportunity_BulkOperationLogs" type="String" static="true"> Entity: bulkoperationlog  Attribute: createdobjectid</field>
  /// <field name="lead_qualifying_opportunity" type="String" static="true"> Entity: lead  Attribute: qualifyingopportunityid</field>
  /// <field name="opportunity_activity_parties" type="String" static="true"> Entity: activityparty  Attribute: partyid</field>
  /// <field name="Opportunity_ActivityPointers" type="String" static="true"> Entity: activitypointer  Attribute: regardingobjectid</field>
  /// <field name="Opportunity_Annotation" type="String" static="true"> Entity: annotation  Attribute: objectid</field>
  /// <field name="Opportunity_Appointments" type="String" static="true"> Entity: appointment  Attribute: regardingobjectid</field>
  /// <field name="Opportunity_AsyncOperations" type="String" static="true"> Entity: asyncoperation  Attribute: regardingobjectid</field>
  /// <field name="Opportunity_BulkDeleteFailures" type="String" static="true"> Entity: bulkdeletefailure  Attribute: regardingobjectid</field>
  /// <field name="opportunity_connections1" type="String" static="true"> Entity: connection  Attribute: record1id</field>
  /// <field name="opportunity_connections2" type="String" static="true"> Entity: connection  Attribute: record2id</field>
  /// <field name="opportunity_customer_opportunity_roles" type="String" static="true"> Entity: customeropportunityrole  Attribute: opportunityid</field>
  /// <field name="Opportunity_DuplicateBaseRecord" type="String" static="true"> Entity: duplicaterecord  Attribute: baserecordid</field>
  /// <field name="Opportunity_DuplicateMatchingRecord" type="String" static="true"> Entity: duplicaterecord  Attribute: duplicaterecordid</field>
  /// <field name="Opportunity_Emails" type="String" static="true"> Entity: email  Attribute: regardingobjectid</field>
  /// <field name="Opportunity_Faxes" type="String" static="true"> Entity: fax  Attribute: regardingobjectid</field>
  /// <field name="opportunity_invoices" type="String" static="true"> Entity: invoice  Attribute: opportunityid</field>
  /// <field name="Opportunity_Letters" type="String" static="true"> Entity: letter  Attribute: regardingobjectid</field>
  /// <field name="Opportunity_OpportunityClose" type="String" static="true"> Entity: opportunityclose  Attribute: opportunityid</field>
  /// <field name="Opportunity_Phonecalls" type="String" static="true"> Entity: phonecall  Attribute: regardingobjectid</field>
  /// <field name="opportunity_PostFollows" type="String" static="true"> Entity: postfollow  Attribute: regardingobjectid</field>
  /// <field name="opportunity_PostRegardings" type="String" static="true"> Entity: postregarding  Attribute: regardingobjectid</field>
  /// <field name="opportunity_PostRoles" type="String" static="true"> Entity: postrole  Attribute: regardingobjectid</field>
  /// <field name="opportunity_principalobjectattributeaccess" type="String" static="true"> Entity: principalobjectattributeaccess  Attribute: objectid</field>
  /// <field name="Opportunity_ProcessSessions" type="String" static="true"> Entity: processsession  Attribute: regardingobjectid</field>
  /// <field name="opportunity_quotes" type="String" static="true"> Entity: quote  Attribute: opportunityid</field>
  /// <field name="Opportunity_RecurringAppointmentMasters" type="String" static="true"> Entity: recurringappointmentmaster  Attribute: regardingobjectid</field>
  /// <field name="opportunity_sales_orders" type="String" static="true"> Entity: salesorder  Attribute: opportunityid</field>
  /// <field name="Opportunity_ServiceAppointments" type="String" static="true"> Entity: serviceappointment  Attribute: regardingobjectid</field>
  /// <field name="Opportunity_SharepointDocumentLocation" type="String" static="true"> Entity: sharepointdocumentlocation  Attribute: regardingobjectid</field>
  /// <field name="Opportunity_Tasks" type="String" static="true"> Entity: task  Attribute: regardingobjectid</field>
  /// <field name="opportunity_Teams" type="String" static="true"> Entity: team  Attribute: regardingobjectid</field>
  /// <field name="product_opportunities" type="String" static="true"> Entity: opportunityproduct  Attribute: opportunityid</field>
  /// <field name="userentityinstancedata_opportunity" type="String" static="true"> Entity: userentityinstancedata  Attribute: objectid</field>
  throw new Error("Constructor not implemented this is a static enum.");
}
 this.OneToMany.__enum = true;
 this.OneToMany.__flags = true;
}).call(Sdk.Opportunity);

Sdk.Opportunity.OneToMany.prototype = {
 CreatedOpportunity_BulkOperationLogs: "CreatedOpportunity_BulkOperationLogs",
 lead_qualifying_opportunity: "lead_qualifying_opportunity",
 opportunity_activity_parties: "opportunity_activity_parties",
 Opportunity_ActivityPointers: "Opportunity_ActivityPointers",
 Opportunity_Annotation: "Opportunity_Annotation",
 Opportunity_Appointments: "Opportunity_Appointments",
 Opportunity_AsyncOperations: "Opportunity_AsyncOperations",
 Opportunity_BulkDeleteFailures: "Opportunity_BulkDeleteFailures",
 opportunity_connections1: "opportunity_connections1",
 opportunity_connections2: "opportunity_connections2",
 opportunity_customer_opportunity_roles: "opportunity_customer_opportunity_roles",
 Opportunity_DuplicateBaseRecord: "Opportunity_DuplicateBaseRecord",
 Opportunity_DuplicateMatchingRecord: "Opportunity_DuplicateMatchingRecord",
 Opportunity_Emails: "Opportunity_Emails",
 Opportunity_Faxes: "Opportunity_Faxes",
 opportunity_invoices: "opportunity_invoices",
 Opportunity_Letters: "Opportunity_Letters",
 Opportunity_OpportunityClose: "Opportunity_OpportunityClose",
 Opportunity_Phonecalls: "Opportunity_Phonecalls",
 opportunity_PostFollows: "opportunity_PostFollows",
 opportunity_PostRegardings: "opportunity_PostRegardings",
 opportunity_PostRoles: "opportunity_PostRoles",
 opportunity_principalobjectattributeaccess: "opportunity_principalobjectattributeaccess",
 Opportunity_ProcessSessions: "Opportunity_ProcessSessions",
 opportunity_quotes: "opportunity_quotes",
 Opportunity_RecurringAppointmentMasters: "Opportunity_RecurringAppointmentMasters",
 opportunity_sales_orders: "opportunity_sales_orders",
 Opportunity_ServiceAppointments: "Opportunity_ServiceAppointments",
 Opportunity_SharepointDocumentLocation: "Opportunity_SharepointDocumentLocation",
 Opportunity_Tasks: "Opportunity_Tasks",
 opportunity_Teams: "opportunity_Teams",
 product_opportunities: "product_opportunities",
 userentityinstancedata_opportunity: "userentityinstancedata_opportunity"};

Sdk.Opportunity.OneToMany.CreatedOpportunity_BulkOperationLogs = "CreatedOpportunity_BulkOperationLogs";
Sdk.Opportunity.OneToMany.lead_qualifying_opportunity = "lead_qualifying_opportunity";
Sdk.Opportunity.OneToMany.opportunity_activity_parties = "opportunity_activity_parties";
Sdk.Opportunity.OneToMany.Opportunity_ActivityPointers = "Opportunity_ActivityPointers";
Sdk.Opportunity.OneToMany.Opportunity_Annotation = "Opportunity_Annotation";
Sdk.Opportunity.OneToMany.Opportunity_Appointments = "Opportunity_Appointments";
Sdk.Opportunity.OneToMany.Opportunity_AsyncOperations = "Opportunity_AsyncOperations";
Sdk.Opportunity.OneToMany.Opportunity_BulkDeleteFailures = "Opportunity_BulkDeleteFailures";
Sdk.Opportunity.OneToMany.opportunity_connections1 = "opportunity_connections1";
Sdk.Opportunity.OneToMany.opportunity_connections2 = "opportunity_connections2";
Sdk.Opportunity.OneToMany.opportunity_customer_opportunity_roles = "opportunity_customer_opportunity_roles";
Sdk.Opportunity.OneToMany.Opportunity_DuplicateBaseRecord = "Opportunity_DuplicateBaseRecord";
Sdk.Opportunity.OneToMany.Opportunity_DuplicateMatchingRecord = "Opportunity_DuplicateMatchingRecord";
Sdk.Opportunity.OneToMany.Opportunity_Emails = "Opportunity_Emails";
Sdk.Opportunity.OneToMany.Opportunity_Faxes = "Opportunity_Faxes";
Sdk.Opportunity.OneToMany.opportunity_invoices = "opportunity_invoices";
Sdk.Opportunity.OneToMany.Opportunity_Letters = "Opportunity_Letters";
Sdk.Opportunity.OneToMany.Opportunity_OpportunityClose = "Opportunity_OpportunityClose";
Sdk.Opportunity.OneToMany.Opportunity_Phonecalls = "Opportunity_Phonecalls";
Sdk.Opportunity.OneToMany.opportunity_PostFollows = "opportunity_PostFollows";
Sdk.Opportunity.OneToMany.opportunity_PostRegardings = "opportunity_PostRegardings";
Sdk.Opportunity.OneToMany.opportunity_PostRoles = "opportunity_PostRoles";
Sdk.Opportunity.OneToMany.opportunity_principalobjectattributeaccess = "opportunity_principalobjectattributeaccess";
Sdk.Opportunity.OneToMany.Opportunity_ProcessSessions = "Opportunity_ProcessSessions";
Sdk.Opportunity.OneToMany.opportunity_quotes = "opportunity_quotes";
Sdk.Opportunity.OneToMany.Opportunity_RecurringAppointmentMasters = "Opportunity_RecurringAppointmentMasters";
Sdk.Opportunity.OneToMany.opportunity_sales_orders = "opportunity_sales_orders";
Sdk.Opportunity.OneToMany.Opportunity_ServiceAppointments = "Opportunity_ServiceAppointments";
Sdk.Opportunity.OneToMany.Opportunity_SharepointDocumentLocation = "Opportunity_SharepointDocumentLocation";
Sdk.Opportunity.OneToMany.Opportunity_Tasks = "Opportunity_Tasks";
Sdk.Opportunity.OneToMany.opportunity_Teams = "opportunity_Teams";
Sdk.Opportunity.OneToMany.product_opportunities = "product_opportunities";
Sdk.Opportunity.OneToMany.userentityinstancedata_opportunity = "userentityinstancedata_opportunity";
Sdk.Opportunity.OneToMany.__enum = true;
Sdk.Opportunity.OneToMany.__flags = true;
