
/*

IMPORTANT: Use this file at design time for IntelliSense support ONLY.
Use the corresponding Sdk.Account.min.js in your project

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
this.Account = function (entity) {
///<summary>
/// Business that represents a customer or potential customer. The company that is billed in business transactions.
///</summary>
/// <param name='entity' type='Sdk.Entity' mayBeNull='true' optional='true'>
/// Optional. Use only to convert an Sdk.Entity into an Sdk.Account
///</param>
  if (!(this instanceof Sdk.Account)) {
   return new Sdk.Account();
  }
  Sdk.Entity.call(this);
  this.setType("account");
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
     throw new Error("Invalid type Sdk.Account entity constructor parameter must be an Sdk.Entity of Type account");
    }
   }
   else {
    throw new Error("Invalid argument Sdk.Account entity constructor parameter must be an Sdk.Entity");
   }
  }

// AccountCategoryCode START --------------------------------------------------------------
var AccountCategoryCode = new Sdk.OptionSet("accountcategorycode");
  this.addAttribute(AccountCategoryCode, false);
  /// <field name='AccountCategoryCode' type='Sdk.OptionSet'>Category : Select a category to indicate whether the customer account is standard or preferred.</field>
  this.AccountCategoryCode = {};
 this.AccountCategoryCode.setValue = function (value) {
  ///<summary><para>Sets the AccountCategoryCode (Category) value</para>
   /// <para>Select a category to indicate whether the customer account is standard or preferred.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Preferred Customer</para>
/// <para> 2 : Standard</para>
   /// </param>
   AccountCategoryCode.setValue(value);
  };
  this.AccountCategoryCode.getValue = function () {
   ///<summary>Gets the AccountCategoryCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select a category to indicate whether the customer account is standard or preferred.</returns>
   return AccountCategoryCode.getValue();
  }
// AccountCategoryCode END --------------------------------------------------------------


// AccountClassificationCode START --------------------------------------------------------------
var AccountClassificationCode = new Sdk.OptionSet("accountclassificationcode");
  this.addAttribute(AccountClassificationCode, false);
  /// <field name='AccountClassificationCode' type='Sdk.OptionSet'>Classification : Select a classification code to indicate the potential value of the customer account based on the projected return on investment, cooperation level, sales cycle length or other criteria.</field>
  this.AccountClassificationCode = {};
 this.AccountClassificationCode.setValue = function (value) {
  ///<summary><para>Sets the AccountClassificationCode (Classification) value</para>
   /// <para>Select a classification code to indicate the potential value of the customer account based on the projected return on investment, cooperation level, sales cycle length or other criteria.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Default Value</para>
   /// </param>
   AccountClassificationCode.setValue(value);
  };
  this.AccountClassificationCode.getValue = function () {
   ///<summary>Gets the AccountClassificationCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select a classification code to indicate the potential value of the customer account based on the projected return on investment, cooperation level, sales cycle length or other criteria.</returns>
   return AccountClassificationCode.getValue();
  }
// AccountClassificationCode END --------------------------------------------------------------


// AccountId START --------------------------------------------------------------
var AccountId = new Sdk.Guid("accountid");
this.addAttribute(AccountId, false);
 /// <field name='AccountId' type='Sdk.Guid'>Account : Unique identifier of the account.</field>
this.AccountId = {};
this.AccountId.setValue = function (value) {
 ///<summary><para>Sets the AccountId (Account) value</para>
 /// <para>RequiredLevel: SystemRequired</para>
 ///</summary>
 /// <param name="value" type="String" mayBeNull="true" optional="false">Unique identifier of the account.</param>
AccountId.setValue(value);
};
this.AccountId.getValue = function () {
 ///<summary>Gets the AccountId value</summary>
 /// <returns type="String" mayBeNull="true">Unique identifier of the account.</returns>
return AccountId.getValue();
}
// AccountId END --------------------------------------------------------------


// AccountNumber START --------------------------------------------------------------
  var AccountNumber = new Sdk.String("accountnumber");
  this.addAttribute(AccountNumber, false);
  /// <field name='AccountNumber' type='Sdk.String'>Account Number : Type an ID number or code for the account to quickly search and identify the account in system views.</field>
this.AccountNumber = {};
  this.AccountNumber.setValue = function (value) {
   ///<summary>Sets the AccountNumber value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Account Number : Type an ID number or code for the account to quickly search and identify the account in system views.</para>
   /// <para>MaxLength: 20</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   AccountNumber.setValue(value);
  };
  this.AccountNumber.getValue = function () {
   ///<summary>
   /// Gets the AccountNumber value
   ///</summary>
   /// <returns type="String">Type an ID number or code for the account to quickly search and identify the account in system views.</returns>
   return AccountNumber.getValue();
  }
// AccountNumber END --------------------------------------------------------------


// AccountRatingCode START --------------------------------------------------------------
var AccountRatingCode = new Sdk.OptionSet("accountratingcode");
  this.addAttribute(AccountRatingCode, false);
  /// <field name='AccountRatingCode' type='Sdk.OptionSet'>Account Rating : Select a rating to indicate the value of the customer account.</field>
  this.AccountRatingCode = {};
 this.AccountRatingCode.setValue = function (value) {
  ///<summary><para>Sets the AccountRatingCode (Account Rating) value</para>
   /// <para>Select a rating to indicate the value of the customer account.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Default Value</para>
   /// </param>
   AccountRatingCode.setValue(value);
  };
  this.AccountRatingCode.getValue = function () {
   ///<summary>Gets the AccountRatingCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select a rating to indicate the value of the customer account.</returns>
   return AccountRatingCode.getValue();
  }
// AccountRatingCode END --------------------------------------------------------------


// Address1_AddressId START --------------------------------------------------------------
var Address1_AddressId = new Sdk.Guid("address1_addressid");
this.addAttribute(Address1_AddressId, false);
 /// <field name='Address1_AddressId' type='Sdk.Guid'>Address 1: ID : Unique identifier for address 1.</field>
this.Address1_AddressId = {};
this.Address1_AddressId.setValue = function (value) {
 ///<summary><para>Sets the Address1_AddressId (Address 1: ID) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="String" mayBeNull="true" optional="false">Unique identifier for address 1.</param>
Address1_AddressId.setValue(value);
};
this.Address1_AddressId.getValue = function () {
 ///<summary>Gets the Address1_AddressId value</summary>
 /// <returns type="String" mayBeNull="true">Unique identifier for address 1.</returns>
return Address1_AddressId.getValue();
}
// Address1_AddressId END --------------------------------------------------------------


// Address1_AddressTypeCode START --------------------------------------------------------------
var Address1_AddressTypeCode = new Sdk.OptionSet("address1_addresstypecode");
  this.addAttribute(Address1_AddressTypeCode, false);
  /// <field name='Address1_AddressTypeCode' type='Sdk.OptionSet'>Address 1: Address Type : Select the primary address type.</field>
  this.Address1_AddressTypeCode = {};
 this.Address1_AddressTypeCode.setValue = function (value) {
  ///<summary><para>Sets the Address1_AddressTypeCode (Address 1: Address Type) value</para>
   /// <para>Select the primary address type.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Bill To</para>
/// <para> 2 : Ship To</para>
/// <para> 3 : Primary</para>
/// <para> 4 : Other</para>
   /// </param>
   Address1_AddressTypeCode.setValue(value);
  };
  this.Address1_AddressTypeCode.getValue = function () {
   ///<summary>Gets the Address1_AddressTypeCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the primary address type.</returns>
   return Address1_AddressTypeCode.getValue();
  }
// Address1_AddressTypeCode END --------------------------------------------------------------


// Address1_City START --------------------------------------------------------------
  var Address1_City = new Sdk.String("address1_city");
  this.addAttribute(Address1_City, false);
  /// <field name='Address1_City' type='Sdk.String'>Address 1: City : Type the city for the primary address.</field>
this.Address1_City = {};
  this.Address1_City.setValue = function (value) {
   ///<summary>Sets the Address1_City value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: City : Type the city for the primary address.</para>
   /// <para>MaxLength: 80</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_City.setValue(value);
  };
  this.Address1_City.getValue = function () {
   ///<summary>
   /// Gets the Address1_City value
   ///</summary>
   /// <returns type="String">Type the city for the primary address.</returns>
   return Address1_City.getValue();
  }
// Address1_City END --------------------------------------------------------------


// Address1_Composite START --------------------------------------------------------------
  var Address1_Composite = new Sdk.String("address1_composite");
  this.addAttribute(Address1_Composite, false);
  /// <field name='Address1_Composite' type='Sdk.String'>Address 1 : Shows the complete primary address.</field>
this.Address1_Composite = {};
  this.Address1_Composite.getValue = function () {
   ///<summary>
   /// Gets the Address1_Composite value
   ///</summary>
   /// <returns type="String">Shows the complete primary address.</returns>
   return Address1_Composite.getValue();
  }
// Address1_Composite END --------------------------------------------------------------


// Address1_Country START --------------------------------------------------------------
  var Address1_Country = new Sdk.String("address1_country");
  this.addAttribute(Address1_Country, false);
  /// <field name='Address1_Country' type='Sdk.String'>Address 1: Country/Region : Type the country or region for the primary address.</field>
this.Address1_Country = {};
  this.Address1_Country.setValue = function (value) {
   ///<summary>Sets the Address1_Country value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: Country/Region : Type the country or region for the primary address.</para>
   /// <para>MaxLength: 80</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_Country.setValue(value);
  };
  this.Address1_Country.getValue = function () {
   ///<summary>
   /// Gets the Address1_Country value
   ///</summary>
   /// <returns type="String">Type the country or region for the primary address.</returns>
   return Address1_Country.getValue();
  }
// Address1_Country END --------------------------------------------------------------


// Address1_County START --------------------------------------------------------------
  var Address1_County = new Sdk.String("address1_county");
  this.addAttribute(Address1_County, false);
  /// <field name='Address1_County' type='Sdk.String'>Address 1: County : Type the county for the primary address.</field>
this.Address1_County = {};
  this.Address1_County.setValue = function (value) {
   ///<summary>Sets the Address1_County value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: County : Type the county for the primary address.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_County.setValue(value);
  };
  this.Address1_County.getValue = function () {
   ///<summary>
   /// Gets the Address1_County value
   ///</summary>
   /// <returns type="String">Type the county for the primary address.</returns>
   return Address1_County.getValue();
  }
// Address1_County END --------------------------------------------------------------


// Address1_Fax START --------------------------------------------------------------
  var Address1_Fax = new Sdk.String("address1_fax");
  this.addAttribute(Address1_Fax, false);
  /// <field name='Address1_Fax' type='Sdk.String'>Address 1: Fax : Type the fax number associated with the primary address.</field>
this.Address1_Fax = {};
  this.Address1_Fax.setValue = function (value) {
   ///<summary>Sets the Address1_Fax value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: Fax : Type the fax number associated with the primary address.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_Fax.setValue(value);
  };
  this.Address1_Fax.getValue = function () {
   ///<summary>
   /// Gets the Address1_Fax value
   ///</summary>
   /// <returns type="String">Type the fax number associated with the primary address.</returns>
   return Address1_Fax.getValue();
  }
// Address1_Fax END --------------------------------------------------------------


// Address1_FreightTermsCode START --------------------------------------------------------------
var Address1_FreightTermsCode = new Sdk.OptionSet("address1_freighttermscode");
  this.addAttribute(Address1_FreightTermsCode, false);
  /// <field name='Address1_FreightTermsCode' type='Sdk.OptionSet'>Address 1: Freight Terms : Select the freight terms for the primary address to make sure shipping orders are processed correctly.</field>
  this.Address1_FreightTermsCode = {};
 this.Address1_FreightTermsCode.setValue = function (value) {
  ///<summary><para>Sets the Address1_FreightTermsCode (Address 1: Freight Terms) value</para>
   /// <para>Select the freight terms for the primary address to make sure shipping orders are processed correctly.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : FOB</para>
/// <para> 2 : No Charge</para>
   /// </param>
   Address1_FreightTermsCode.setValue(value);
  };
  this.Address1_FreightTermsCode.getValue = function () {
   ///<summary>Gets the Address1_FreightTermsCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the freight terms for the primary address to make sure shipping orders are processed correctly.</returns>
   return Address1_FreightTermsCode.getValue();
  }
// Address1_FreightTermsCode END --------------------------------------------------------------


// Address1_Latitude START --------------------------------------------------------------
var Address1_Latitude = new Sdk.Double("address1_latitude");
this.addAttribute(Address1_Latitude, false);
/// <field name='Address1_Latitude' type='Sdk.Double'>Address 1: Latitude : Type the latitude value for the primary address for use in mapping and other applications.</field>
this.Address1_Latitude = {};
this.Address1_Latitude.setValue = function (value) {
 ///<summary>Sets the Address1_Latitude value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Address 1: Latitude : Type the latitude value for the primary address for use in mapping and other applications.</para>
 /// <para>MaxValue: 100000000000</para>
 /// <para>MinValue: -100000000000</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 Address1_Latitude.setValue(value);
};
this.Address1_Latitude.getValue = function () {
 ///<summary>
 /// Gets the Address1_Latitude value
 ///</summary>
 /// <returns type="Number">Type the latitude value for the primary address for use in mapping and other applications.</returns>
 return Address1_Latitude.getValue();
}
// Address1_Latitude END --------------------------------------------------------------


// Address1_Line1 START --------------------------------------------------------------
  var Address1_Line1 = new Sdk.String("address1_line1");
  this.addAttribute(Address1_Line1, false);
  /// <field name='Address1_Line1' type='Sdk.String'>Address 1: Street 1 : Type the first line of the primary address.</field>
this.Address1_Line1 = {};
  this.Address1_Line1.setValue = function (value) {
   ///<summary>Sets the Address1_Line1 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: Street 1 : Type the first line of the primary address.</para>
   /// <para>MaxLength: 250</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_Line1.setValue(value);
  };
  this.Address1_Line1.getValue = function () {
   ///<summary>
   /// Gets the Address1_Line1 value
   ///</summary>
   /// <returns type="String">Type the first line of the primary address.</returns>
   return Address1_Line1.getValue();
  }
// Address1_Line1 END --------------------------------------------------------------


// Address1_Line2 START --------------------------------------------------------------
  var Address1_Line2 = new Sdk.String("address1_line2");
  this.addAttribute(Address1_Line2, false);
  /// <field name='Address1_Line2' type='Sdk.String'>Address 1: Street 2 : Type the second line of the primary address.</field>
this.Address1_Line2 = {};
  this.Address1_Line2.setValue = function (value) {
   ///<summary>Sets the Address1_Line2 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: Street 2 : Type the second line of the primary address.</para>
   /// <para>MaxLength: 250</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_Line2.setValue(value);
  };
  this.Address1_Line2.getValue = function () {
   ///<summary>
   /// Gets the Address1_Line2 value
   ///</summary>
   /// <returns type="String">Type the second line of the primary address.</returns>
   return Address1_Line2.getValue();
  }
// Address1_Line2 END --------------------------------------------------------------


// Address1_Line3 START --------------------------------------------------------------
  var Address1_Line3 = new Sdk.String("address1_line3");
  this.addAttribute(Address1_Line3, false);
  /// <field name='Address1_Line3' type='Sdk.String'>Address 1: Street 3 : Type the third line of the primary address.</field>
this.Address1_Line3 = {};
  this.Address1_Line3.setValue = function (value) {
   ///<summary>Sets the Address1_Line3 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: Street 3 : Type the third line of the primary address.</para>
   /// <para>MaxLength: 250</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_Line3.setValue(value);
  };
  this.Address1_Line3.getValue = function () {
   ///<summary>
   /// Gets the Address1_Line3 value
   ///</summary>
   /// <returns type="String">Type the third line of the primary address.</returns>
   return Address1_Line3.getValue();
  }
// Address1_Line3 END --------------------------------------------------------------


// Address1_Longitude START --------------------------------------------------------------
var Address1_Longitude = new Sdk.Double("address1_longitude");
this.addAttribute(Address1_Longitude, false);
/// <field name='Address1_Longitude' type='Sdk.Double'>Address 1: Longitude : Type the longitude value for the primary address for use in mapping and other applications.</field>
this.Address1_Longitude = {};
this.Address1_Longitude.setValue = function (value) {
 ///<summary>Sets the Address1_Longitude value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Address 1: Longitude : Type the longitude value for the primary address for use in mapping and other applications.</para>
 /// <para>MaxValue: 100000000000</para>
 /// <para>MinValue: -100000000000</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 Address1_Longitude.setValue(value);
};
this.Address1_Longitude.getValue = function () {
 ///<summary>
 /// Gets the Address1_Longitude value
 ///</summary>
 /// <returns type="Number">Type the longitude value for the primary address for use in mapping and other applications.</returns>
 return Address1_Longitude.getValue();
}
// Address1_Longitude END --------------------------------------------------------------


// Address1_Name START --------------------------------------------------------------
  var Address1_Name = new Sdk.String("address1_name");
  this.addAttribute(Address1_Name, false);
  /// <field name='Address1_Name' type='Sdk.String'>Address 1: Name : Type a descriptive name for the primary address, such as Corporate Headquarters.</field>
this.Address1_Name = {};
  this.Address1_Name.setValue = function (value) {
   ///<summary>Sets the Address1_Name value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: Name : Type a descriptive name for the primary address, such as Corporate Headquarters.</para>
   /// <para>MaxLength: 200</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_Name.setValue(value);
  };
  this.Address1_Name.getValue = function () {
   ///<summary>
   /// Gets the Address1_Name value
   ///</summary>
   /// <returns type="String">Type a descriptive name for the primary address, such as Corporate Headquarters.</returns>
   return Address1_Name.getValue();
  }
// Address1_Name END --------------------------------------------------------------


// Address1_PostalCode START --------------------------------------------------------------
  var Address1_PostalCode = new Sdk.String("address1_postalcode");
  this.addAttribute(Address1_PostalCode, false);
  /// <field name='Address1_PostalCode' type='Sdk.String'>Address 1: ZIP/Postal Code : Type the ZIP Code or postal code for the primary address.</field>
this.Address1_PostalCode = {};
  this.Address1_PostalCode.setValue = function (value) {
   ///<summary>Sets the Address1_PostalCode value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: ZIP/Postal Code : Type the ZIP Code or postal code for the primary address.</para>
   /// <para>MaxLength: 20</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_PostalCode.setValue(value);
  };
  this.Address1_PostalCode.getValue = function () {
   ///<summary>
   /// Gets the Address1_PostalCode value
   ///</summary>
   /// <returns type="String">Type the ZIP Code or postal code for the primary address.</returns>
   return Address1_PostalCode.getValue();
  }
// Address1_PostalCode END --------------------------------------------------------------


// Address1_PostOfficeBox START --------------------------------------------------------------
  var Address1_PostOfficeBox = new Sdk.String("address1_postofficebox");
  this.addAttribute(Address1_PostOfficeBox, false);
  /// <field name='Address1_PostOfficeBox' type='Sdk.String'>Address 1: Post Office Box : Type the post office box number of the primary address.</field>
this.Address1_PostOfficeBox = {};
  this.Address1_PostOfficeBox.setValue = function (value) {
   ///<summary>Sets the Address1_PostOfficeBox value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: Post Office Box : Type the post office box number of the primary address.</para>
   /// <para>MaxLength: 20</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_PostOfficeBox.setValue(value);
  };
  this.Address1_PostOfficeBox.getValue = function () {
   ///<summary>
   /// Gets the Address1_PostOfficeBox value
   ///</summary>
   /// <returns type="String">Type the post office box number of the primary address.</returns>
   return Address1_PostOfficeBox.getValue();
  }
// Address1_PostOfficeBox END --------------------------------------------------------------


// Address1_PrimaryContactName START --------------------------------------------------------------
  var Address1_PrimaryContactName = new Sdk.String("address1_primarycontactname");
  this.addAttribute(Address1_PrimaryContactName, false);
  /// <field name='Address1_PrimaryContactName' type='Sdk.String'>Address 1: Primary Contact Name : Type the name of the main contact at the account's primary address.</field>
this.Address1_PrimaryContactName = {};
  this.Address1_PrimaryContactName.setValue = function (value) {
   ///<summary>Sets the Address1_PrimaryContactName value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: Primary Contact Name : Type the name of the main contact at the account's primary address.</para>
   /// <para>MaxLength: 100</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_PrimaryContactName.setValue(value);
  };
  this.Address1_PrimaryContactName.getValue = function () {
   ///<summary>
   /// Gets the Address1_PrimaryContactName value
   ///</summary>
   /// <returns type="String">Type the name of the main contact at the account's primary address.</returns>
   return Address1_PrimaryContactName.getValue();
  }
// Address1_PrimaryContactName END --------------------------------------------------------------


// Address1_ShippingMethodCode START --------------------------------------------------------------
var Address1_ShippingMethodCode = new Sdk.OptionSet("address1_shippingmethodcode");
  this.addAttribute(Address1_ShippingMethodCode, false);
  /// <field name='Address1_ShippingMethodCode' type='Sdk.OptionSet'>Address 1: Shipping Method : Select a shipping method for deliveries sent to this address.</field>
  this.Address1_ShippingMethodCode = {};
 this.Address1_ShippingMethodCode.setValue = function (value) {
  ///<summary><para>Sets the Address1_ShippingMethodCode (Address 1: Shipping Method) value</para>
   /// <para>Select a shipping method for deliveries sent to this address.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Airborne</para>
/// <para> 2 : DHL</para>
/// <para> 3 : FedEx</para>
/// <para> 4 : UPS</para>
/// <para> 5 : Postal Mail</para>
/// <para> 6 : Full Load</para>
/// <para> 7 : Will Call</para>
   /// </param>
   Address1_ShippingMethodCode.setValue(value);
  };
  this.Address1_ShippingMethodCode.getValue = function () {
   ///<summary>Gets the Address1_ShippingMethodCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select a shipping method for deliveries sent to this address.</returns>
   return Address1_ShippingMethodCode.getValue();
  }
// Address1_ShippingMethodCode END --------------------------------------------------------------


// Address1_StateOrProvince START --------------------------------------------------------------
  var Address1_StateOrProvince = new Sdk.String("address1_stateorprovince");
  this.addAttribute(Address1_StateOrProvince, false);
  /// <field name='Address1_StateOrProvince' type='Sdk.String'>Address 1: State/Province : Type the state or province of the primary address.</field>
this.Address1_StateOrProvince = {};
  this.Address1_StateOrProvince.setValue = function (value) {
   ///<summary>Sets the Address1_StateOrProvince value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: State/Province : Type the state or province of the primary address.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_StateOrProvince.setValue(value);
  };
  this.Address1_StateOrProvince.getValue = function () {
   ///<summary>
   /// Gets the Address1_StateOrProvince value
   ///</summary>
   /// <returns type="String">Type the state or province of the primary address.</returns>
   return Address1_StateOrProvince.getValue();
  }
// Address1_StateOrProvince END --------------------------------------------------------------


// Address1_Telephone1 START --------------------------------------------------------------
  var Address1_Telephone1 = new Sdk.String("address1_telephone1");
  this.addAttribute(Address1_Telephone1, false);
  /// <field name='Address1_Telephone1' type='Sdk.String'>Address Phone : Type the main phone number associated with the primary address.</field>
this.Address1_Telephone1 = {};
  this.Address1_Telephone1.setValue = function (value) {
   ///<summary>Sets the Address1_Telephone1 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address Phone : Type the main phone number associated with the primary address.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_Telephone1.setValue(value);
  };
  this.Address1_Telephone1.getValue = function () {
   ///<summary>
   /// Gets the Address1_Telephone1 value
   ///</summary>
   /// <returns type="String">Type the main phone number associated with the primary address.</returns>
   return Address1_Telephone1.getValue();
  }
// Address1_Telephone1 END --------------------------------------------------------------


// Address1_Telephone2 START --------------------------------------------------------------
  var Address1_Telephone2 = new Sdk.String("address1_telephone2");
  this.addAttribute(Address1_Telephone2, false);
  /// <field name='Address1_Telephone2' type='Sdk.String'>Address 1: Telephone 2 : Type a second phone number associated with the primary address.</field>
this.Address1_Telephone2 = {};
  this.Address1_Telephone2.setValue = function (value) {
   ///<summary>Sets the Address1_Telephone2 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: Telephone 2 : Type a second phone number associated with the primary address.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_Telephone2.setValue(value);
  };
  this.Address1_Telephone2.getValue = function () {
   ///<summary>
   /// Gets the Address1_Telephone2 value
   ///</summary>
   /// <returns type="String">Type a second phone number associated with the primary address.</returns>
   return Address1_Telephone2.getValue();
  }
// Address1_Telephone2 END --------------------------------------------------------------


// Address1_Telephone3 START --------------------------------------------------------------
  var Address1_Telephone3 = new Sdk.String("address1_telephone3");
  this.addAttribute(Address1_Telephone3, false);
  /// <field name='Address1_Telephone3' type='Sdk.String'>Address 1: Telephone 3 : Type a third phone number associated with the primary address.</field>
this.Address1_Telephone3 = {};
  this.Address1_Telephone3.setValue = function (value) {
   ///<summary>Sets the Address1_Telephone3 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: Telephone 3 : Type a third phone number associated with the primary address.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_Telephone3.setValue(value);
  };
  this.Address1_Telephone3.getValue = function () {
   ///<summary>
   /// Gets the Address1_Telephone3 value
   ///</summary>
   /// <returns type="String">Type a third phone number associated with the primary address.</returns>
   return Address1_Telephone3.getValue();
  }
// Address1_Telephone3 END --------------------------------------------------------------


// Address1_UPSZone START --------------------------------------------------------------
  var Address1_UPSZone = new Sdk.String("address1_upszone");
  this.addAttribute(Address1_UPSZone, false);
  /// <field name='Address1_UPSZone' type='Sdk.String'>Address 1: UPS Zone : Type the UPS zone of the primary address to make sure shipping charges are calculated correctly and deliveries are made promptly, if shipped by UPS.</field>
this.Address1_UPSZone = {};
  this.Address1_UPSZone.setValue = function (value) {
   ///<summary>Sets the Address1_UPSZone value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 1: UPS Zone : Type the UPS zone of the primary address to make sure shipping charges are calculated correctly and deliveries are made promptly, if shipped by UPS.</para>
   /// <para>MaxLength: 4</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address1_UPSZone.setValue(value);
  };
  this.Address1_UPSZone.getValue = function () {
   ///<summary>
   /// Gets the Address1_UPSZone value
   ///</summary>
   /// <returns type="String">Type the UPS zone of the primary address to make sure shipping charges are calculated correctly and deliveries are made promptly, if shipped by UPS.</returns>
   return Address1_UPSZone.getValue();
  }
// Address1_UPSZone END --------------------------------------------------------------


// Address1_UTCOffset START --------------------------------------------------------------
var Address1_UTCOffset = new Sdk.Int("address1_utcoffset");
this.addAttribute(Address1_UTCOffset, false);
/// <field name='Address1_UTCOffset' type='Sdk.Int'>Address 1: UTC Offset : Select the time zone, or UTC offset, for this address so that other people can reference it when they contact someone at this address.</field>
this.Address1_UTCOffset = {};
this.Address1_UTCOffset.setValue = function (value) {
 ///<summary>Sets the Address1_UTCOffset value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Address 1: UTC Offset : Select the time zone, or UTC offset, for this address so that other people can reference it when they contact someone at this address.</para>
 /// <para>MaxValue: 2147483647</para>
 /// <para>MinValue: -2147483648</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 Address1_UTCOffset.setValue(value);
};
this.Address1_UTCOffset.getValue = function () {
 ///<summary>
 /// Gets the Address1_UTCOffset value
 ///</summary>
 /// <returns type="Number">Select the time zone, or UTC offset, for this address so that other people can reference it when they contact someone at this address.</returns>
 return Address1_UTCOffset.getValue();
}
// Address1_UTCOffset END --------------------------------------------------------------


// Address2_AddressId START --------------------------------------------------------------
var Address2_AddressId = new Sdk.Guid("address2_addressid");
this.addAttribute(Address2_AddressId, false);
 /// <field name='Address2_AddressId' type='Sdk.Guid'>Address 2: ID : Unique identifier for address 2.</field>
this.Address2_AddressId = {};
this.Address2_AddressId.setValue = function (value) {
 ///<summary><para>Sets the Address2_AddressId (Address 2: ID) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="String" mayBeNull="true" optional="false">Unique identifier for address 2.</param>
Address2_AddressId.setValue(value);
};
this.Address2_AddressId.getValue = function () {
 ///<summary>Gets the Address2_AddressId value</summary>
 /// <returns type="String" mayBeNull="true">Unique identifier for address 2.</returns>
return Address2_AddressId.getValue();
}
// Address2_AddressId END --------------------------------------------------------------


// Address2_AddressTypeCode START --------------------------------------------------------------
var Address2_AddressTypeCode = new Sdk.OptionSet("address2_addresstypecode");
  this.addAttribute(Address2_AddressTypeCode, false);
  /// <field name='Address2_AddressTypeCode' type='Sdk.OptionSet'>Address 2: Address Type : Select the secondary address type.</field>
  this.Address2_AddressTypeCode = {};
 this.Address2_AddressTypeCode.setValue = function (value) {
  ///<summary><para>Sets the Address2_AddressTypeCode (Address 2: Address Type) value</para>
   /// <para>Select the secondary address type.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Default Value</para>
   /// </param>
   Address2_AddressTypeCode.setValue(value);
  };
  this.Address2_AddressTypeCode.getValue = function () {
   ///<summary>Gets the Address2_AddressTypeCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the secondary address type.</returns>
   return Address2_AddressTypeCode.getValue();
  }
// Address2_AddressTypeCode END --------------------------------------------------------------


// Address2_City START --------------------------------------------------------------
  var Address2_City = new Sdk.String("address2_city");
  this.addAttribute(Address2_City, false);
  /// <field name='Address2_City' type='Sdk.String'>Address 2: City : Type the city for the secondary address.</field>
this.Address2_City = {};
  this.Address2_City.setValue = function (value) {
   ///<summary>Sets the Address2_City value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: City : Type the city for the secondary address.</para>
   /// <para>MaxLength: 80</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_City.setValue(value);
  };
  this.Address2_City.getValue = function () {
   ///<summary>
   /// Gets the Address2_City value
   ///</summary>
   /// <returns type="String">Type the city for the secondary address.</returns>
   return Address2_City.getValue();
  }
// Address2_City END --------------------------------------------------------------


// Address2_Composite START --------------------------------------------------------------
  var Address2_Composite = new Sdk.String("address2_composite");
  this.addAttribute(Address2_Composite, false);
  /// <field name='Address2_Composite' type='Sdk.String'>Address 2 : Shows the complete secondary address.</field>
this.Address2_Composite = {};
  this.Address2_Composite.getValue = function () {
   ///<summary>
   /// Gets the Address2_Composite value
   ///</summary>
   /// <returns type="String">Shows the complete secondary address.</returns>
   return Address2_Composite.getValue();
  }
// Address2_Composite END --------------------------------------------------------------


// Address2_Country START --------------------------------------------------------------
  var Address2_Country = new Sdk.String("address2_country");
  this.addAttribute(Address2_Country, false);
  /// <field name='Address2_Country' type='Sdk.String'>Address 2: Country/Region : Type the country or region for the secondary address.</field>
this.Address2_Country = {};
  this.Address2_Country.setValue = function (value) {
   ///<summary>Sets the Address2_Country value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: Country/Region : Type the country or region for the secondary address.</para>
   /// <para>MaxLength: 80</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_Country.setValue(value);
  };
  this.Address2_Country.getValue = function () {
   ///<summary>
   /// Gets the Address2_Country value
   ///</summary>
   /// <returns type="String">Type the country or region for the secondary address.</returns>
   return Address2_Country.getValue();
  }
// Address2_Country END --------------------------------------------------------------


// Address2_County START --------------------------------------------------------------
  var Address2_County = new Sdk.String("address2_county");
  this.addAttribute(Address2_County, false);
  /// <field name='Address2_County' type='Sdk.String'>Address 2: County : Type the county for the secondary address.</field>
this.Address2_County = {};
  this.Address2_County.setValue = function (value) {
   ///<summary>Sets the Address2_County value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: County : Type the county for the secondary address.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_County.setValue(value);
  };
  this.Address2_County.getValue = function () {
   ///<summary>
   /// Gets the Address2_County value
   ///</summary>
   /// <returns type="String">Type the county for the secondary address.</returns>
   return Address2_County.getValue();
  }
// Address2_County END --------------------------------------------------------------


// Address2_Fax START --------------------------------------------------------------
  var Address2_Fax = new Sdk.String("address2_fax");
  this.addAttribute(Address2_Fax, false);
  /// <field name='Address2_Fax' type='Sdk.String'>Address 2: Fax : Type the fax number associated with the secondary address.</field>
this.Address2_Fax = {};
  this.Address2_Fax.setValue = function (value) {
   ///<summary>Sets the Address2_Fax value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: Fax : Type the fax number associated with the secondary address.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_Fax.setValue(value);
  };
  this.Address2_Fax.getValue = function () {
   ///<summary>
   /// Gets the Address2_Fax value
   ///</summary>
   /// <returns type="String">Type the fax number associated with the secondary address.</returns>
   return Address2_Fax.getValue();
  }
// Address2_Fax END --------------------------------------------------------------


// Address2_FreightTermsCode START --------------------------------------------------------------
var Address2_FreightTermsCode = new Sdk.OptionSet("address2_freighttermscode");
  this.addAttribute(Address2_FreightTermsCode, false);
  /// <field name='Address2_FreightTermsCode' type='Sdk.OptionSet'>Address 2: Freight Terms : Select the freight terms for the secondary address to make sure shipping orders are processed correctly.</field>
  this.Address2_FreightTermsCode = {};
 this.Address2_FreightTermsCode.setValue = function (value) {
  ///<summary><para>Sets the Address2_FreightTermsCode (Address 2: Freight Terms) value</para>
   /// <para>Select the freight terms for the secondary address to make sure shipping orders are processed correctly.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Default Value</para>
   /// </param>
   Address2_FreightTermsCode.setValue(value);
  };
  this.Address2_FreightTermsCode.getValue = function () {
   ///<summary>Gets the Address2_FreightTermsCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the freight terms for the secondary address to make sure shipping orders are processed correctly.</returns>
   return Address2_FreightTermsCode.getValue();
  }
// Address2_FreightTermsCode END --------------------------------------------------------------


// Address2_Latitude START --------------------------------------------------------------
var Address2_Latitude = new Sdk.Double("address2_latitude");
this.addAttribute(Address2_Latitude, false);
/// <field name='Address2_Latitude' type='Sdk.Double'>Address 2: Latitude : Type the latitude value for the secondary address for use in mapping and other applications.</field>
this.Address2_Latitude = {};
this.Address2_Latitude.setValue = function (value) {
 ///<summary>Sets the Address2_Latitude value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Address 2: Latitude : Type the latitude value for the secondary address for use in mapping and other applications.</para>
 /// <para>MaxValue: 100000000000</para>
 /// <para>MinValue: -100000000000</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 Address2_Latitude.setValue(value);
};
this.Address2_Latitude.getValue = function () {
 ///<summary>
 /// Gets the Address2_Latitude value
 ///</summary>
 /// <returns type="Number">Type the latitude value for the secondary address for use in mapping and other applications.</returns>
 return Address2_Latitude.getValue();
}
// Address2_Latitude END --------------------------------------------------------------


// Address2_Line1 START --------------------------------------------------------------
  var Address2_Line1 = new Sdk.String("address2_line1");
  this.addAttribute(Address2_Line1, false);
  /// <field name='Address2_Line1' type='Sdk.String'>Address 2: Street 1 : Type the first line of the secondary address.</field>
this.Address2_Line1 = {};
  this.Address2_Line1.setValue = function (value) {
   ///<summary>Sets the Address2_Line1 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: Street 1 : Type the first line of the secondary address.</para>
   /// <para>MaxLength: 250</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_Line1.setValue(value);
  };
  this.Address2_Line1.getValue = function () {
   ///<summary>
   /// Gets the Address2_Line1 value
   ///</summary>
   /// <returns type="String">Type the first line of the secondary address.</returns>
   return Address2_Line1.getValue();
  }
// Address2_Line1 END --------------------------------------------------------------


// Address2_Line2 START --------------------------------------------------------------
  var Address2_Line2 = new Sdk.String("address2_line2");
  this.addAttribute(Address2_Line2, false);
  /// <field name='Address2_Line2' type='Sdk.String'>Address 2: Street 2 : Type the second line of the secondary address.</field>
this.Address2_Line2 = {};
  this.Address2_Line2.setValue = function (value) {
   ///<summary>Sets the Address2_Line2 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: Street 2 : Type the second line of the secondary address.</para>
   /// <para>MaxLength: 250</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_Line2.setValue(value);
  };
  this.Address2_Line2.getValue = function () {
   ///<summary>
   /// Gets the Address2_Line2 value
   ///</summary>
   /// <returns type="String">Type the second line of the secondary address.</returns>
   return Address2_Line2.getValue();
  }
// Address2_Line2 END --------------------------------------------------------------


// Address2_Line3 START --------------------------------------------------------------
  var Address2_Line3 = new Sdk.String("address2_line3");
  this.addAttribute(Address2_Line3, false);
  /// <field name='Address2_Line3' type='Sdk.String'>Address 2: Street 3 : Type the third line of the secondary address.</field>
this.Address2_Line3 = {};
  this.Address2_Line3.setValue = function (value) {
   ///<summary>Sets the Address2_Line3 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: Street 3 : Type the third line of the secondary address.</para>
   /// <para>MaxLength: 250</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_Line3.setValue(value);
  };
  this.Address2_Line3.getValue = function () {
   ///<summary>
   /// Gets the Address2_Line3 value
   ///</summary>
   /// <returns type="String">Type the third line of the secondary address.</returns>
   return Address2_Line3.getValue();
  }
// Address2_Line3 END --------------------------------------------------------------


// Address2_Longitude START --------------------------------------------------------------
var Address2_Longitude = new Sdk.Double("address2_longitude");
this.addAttribute(Address2_Longitude, false);
/// <field name='Address2_Longitude' type='Sdk.Double'>Address 2: Longitude : Type the longitude value for the secondary address for use in mapping and other applications.</field>
this.Address2_Longitude = {};
this.Address2_Longitude.setValue = function (value) {
 ///<summary>Sets the Address2_Longitude value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Address 2: Longitude : Type the longitude value for the secondary address for use in mapping and other applications.</para>
 /// <para>MaxValue: 100000000000</para>
 /// <para>MinValue: -100000000000</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 Address2_Longitude.setValue(value);
};
this.Address2_Longitude.getValue = function () {
 ///<summary>
 /// Gets the Address2_Longitude value
 ///</summary>
 /// <returns type="Number">Type the longitude value for the secondary address for use in mapping and other applications.</returns>
 return Address2_Longitude.getValue();
}
// Address2_Longitude END --------------------------------------------------------------


// Address2_Name START --------------------------------------------------------------
  var Address2_Name = new Sdk.String("address2_name");
  this.addAttribute(Address2_Name, false);
  /// <field name='Address2_Name' type='Sdk.String'>Address 2: Name : Type a descriptive name for the secondary address, such as Corporate Headquarters.</field>
this.Address2_Name = {};
  this.Address2_Name.setValue = function (value) {
   ///<summary>Sets the Address2_Name value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: Name : Type a descriptive name for the secondary address, such as Corporate Headquarters.</para>
   /// <para>MaxLength: 200</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_Name.setValue(value);
  };
  this.Address2_Name.getValue = function () {
   ///<summary>
   /// Gets the Address2_Name value
   ///</summary>
   /// <returns type="String">Type a descriptive name for the secondary address, such as Corporate Headquarters.</returns>
   return Address2_Name.getValue();
  }
// Address2_Name END --------------------------------------------------------------


// Address2_PostalCode START --------------------------------------------------------------
  var Address2_PostalCode = new Sdk.String("address2_postalcode");
  this.addAttribute(Address2_PostalCode, false);
  /// <field name='Address2_PostalCode' type='Sdk.String'>Address 2: ZIP/Postal Code : Type the ZIP Code or postal code for the secondary address.</field>
this.Address2_PostalCode = {};
  this.Address2_PostalCode.setValue = function (value) {
   ///<summary>Sets the Address2_PostalCode value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: ZIP/Postal Code : Type the ZIP Code or postal code for the secondary address.</para>
   /// <para>MaxLength: 20</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_PostalCode.setValue(value);
  };
  this.Address2_PostalCode.getValue = function () {
   ///<summary>
   /// Gets the Address2_PostalCode value
   ///</summary>
   /// <returns type="String">Type the ZIP Code or postal code for the secondary address.</returns>
   return Address2_PostalCode.getValue();
  }
// Address2_PostalCode END --------------------------------------------------------------


// Address2_PostOfficeBox START --------------------------------------------------------------
  var Address2_PostOfficeBox = new Sdk.String("address2_postofficebox");
  this.addAttribute(Address2_PostOfficeBox, false);
  /// <field name='Address2_PostOfficeBox' type='Sdk.String'>Address 2: Post Office Box : Type the post office box number of the secondary address.</field>
this.Address2_PostOfficeBox = {};
  this.Address2_PostOfficeBox.setValue = function (value) {
   ///<summary>Sets the Address2_PostOfficeBox value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: Post Office Box : Type the post office box number of the secondary address.</para>
   /// <para>MaxLength: 20</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_PostOfficeBox.setValue(value);
  };
  this.Address2_PostOfficeBox.getValue = function () {
   ///<summary>
   /// Gets the Address2_PostOfficeBox value
   ///</summary>
   /// <returns type="String">Type the post office box number of the secondary address.</returns>
   return Address2_PostOfficeBox.getValue();
  }
// Address2_PostOfficeBox END --------------------------------------------------------------


// Address2_PrimaryContactName START --------------------------------------------------------------
  var Address2_PrimaryContactName = new Sdk.String("address2_primarycontactname");
  this.addAttribute(Address2_PrimaryContactName, false);
  /// <field name='Address2_PrimaryContactName' type='Sdk.String'>Address 2: Primary Contact Name : Type the name of the main contact at the account's secondary address.</field>
this.Address2_PrimaryContactName = {};
  this.Address2_PrimaryContactName.setValue = function (value) {
   ///<summary>Sets the Address2_PrimaryContactName value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: Primary Contact Name : Type the name of the main contact at the account's secondary address.</para>
   /// <para>MaxLength: 100</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_PrimaryContactName.setValue(value);
  };
  this.Address2_PrimaryContactName.getValue = function () {
   ///<summary>
   /// Gets the Address2_PrimaryContactName value
   ///</summary>
   /// <returns type="String">Type the name of the main contact at the account's secondary address.</returns>
   return Address2_PrimaryContactName.getValue();
  }
// Address2_PrimaryContactName END --------------------------------------------------------------


// Address2_ShippingMethodCode START --------------------------------------------------------------
var Address2_ShippingMethodCode = new Sdk.OptionSet("address2_shippingmethodcode");
  this.addAttribute(Address2_ShippingMethodCode, false);
  /// <field name='Address2_ShippingMethodCode' type='Sdk.OptionSet'>Address 2: Shipping Method : Select a shipping method for deliveries sent to this address.</field>
  this.Address2_ShippingMethodCode = {};
 this.Address2_ShippingMethodCode.setValue = function (value) {
  ///<summary><para>Sets the Address2_ShippingMethodCode (Address 2: Shipping Method) value</para>
   /// <para>Select a shipping method for deliveries sent to this address.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Default Value</para>
   /// </param>
   Address2_ShippingMethodCode.setValue(value);
  };
  this.Address2_ShippingMethodCode.getValue = function () {
   ///<summary>Gets the Address2_ShippingMethodCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select a shipping method for deliveries sent to this address.</returns>
   return Address2_ShippingMethodCode.getValue();
  }
// Address2_ShippingMethodCode END --------------------------------------------------------------


// Address2_StateOrProvince START --------------------------------------------------------------
  var Address2_StateOrProvince = new Sdk.String("address2_stateorprovince");
  this.addAttribute(Address2_StateOrProvince, false);
  /// <field name='Address2_StateOrProvince' type='Sdk.String'>Address 2: State/Province : Type the state or province of the secondary address.</field>
this.Address2_StateOrProvince = {};
  this.Address2_StateOrProvince.setValue = function (value) {
   ///<summary>Sets the Address2_StateOrProvince value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: State/Province : Type the state or province of the secondary address.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_StateOrProvince.setValue(value);
  };
  this.Address2_StateOrProvince.getValue = function () {
   ///<summary>
   /// Gets the Address2_StateOrProvince value
   ///</summary>
   /// <returns type="String">Type the state or province of the secondary address.</returns>
   return Address2_StateOrProvince.getValue();
  }
// Address2_StateOrProvince END --------------------------------------------------------------


// Address2_Telephone1 START --------------------------------------------------------------
  var Address2_Telephone1 = new Sdk.String("address2_telephone1");
  this.addAttribute(Address2_Telephone1, false);
  /// <field name='Address2_Telephone1' type='Sdk.String'>Address 2: Telephone 1 : Type the main phone number associated with the secondary address.</field>
this.Address2_Telephone1 = {};
  this.Address2_Telephone1.setValue = function (value) {
   ///<summary>Sets the Address2_Telephone1 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: Telephone 1 : Type the main phone number associated with the secondary address.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_Telephone1.setValue(value);
  };
  this.Address2_Telephone1.getValue = function () {
   ///<summary>
   /// Gets the Address2_Telephone1 value
   ///</summary>
   /// <returns type="String">Type the main phone number associated with the secondary address.</returns>
   return Address2_Telephone1.getValue();
  }
// Address2_Telephone1 END --------------------------------------------------------------


// Address2_Telephone2 START --------------------------------------------------------------
  var Address2_Telephone2 = new Sdk.String("address2_telephone2");
  this.addAttribute(Address2_Telephone2, false);
  /// <field name='Address2_Telephone2' type='Sdk.String'>Address 2: Telephone 2 : Type a second phone number associated with the secondary address.</field>
this.Address2_Telephone2 = {};
  this.Address2_Telephone2.setValue = function (value) {
   ///<summary>Sets the Address2_Telephone2 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: Telephone 2 : Type a second phone number associated with the secondary address.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_Telephone2.setValue(value);
  };
  this.Address2_Telephone2.getValue = function () {
   ///<summary>
   /// Gets the Address2_Telephone2 value
   ///</summary>
   /// <returns type="String">Type a second phone number associated with the secondary address.</returns>
   return Address2_Telephone2.getValue();
  }
// Address2_Telephone2 END --------------------------------------------------------------


// Address2_Telephone3 START --------------------------------------------------------------
  var Address2_Telephone3 = new Sdk.String("address2_telephone3");
  this.addAttribute(Address2_Telephone3, false);
  /// <field name='Address2_Telephone3' type='Sdk.String'>Address 2: Telephone 3 : Type a third phone number associated with the secondary address.</field>
this.Address2_Telephone3 = {};
  this.Address2_Telephone3.setValue = function (value) {
   ///<summary>Sets the Address2_Telephone3 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: Telephone 3 : Type a third phone number associated with the secondary address.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_Telephone3.setValue(value);
  };
  this.Address2_Telephone3.getValue = function () {
   ///<summary>
   /// Gets the Address2_Telephone3 value
   ///</summary>
   /// <returns type="String">Type a third phone number associated with the secondary address.</returns>
   return Address2_Telephone3.getValue();
  }
// Address2_Telephone3 END --------------------------------------------------------------


// Address2_UPSZone START --------------------------------------------------------------
  var Address2_UPSZone = new Sdk.String("address2_upszone");
  this.addAttribute(Address2_UPSZone, false);
  /// <field name='Address2_UPSZone' type='Sdk.String'>Address 2: UPS Zone : Type the UPS zone of the secondary address to make sure shipping charges are calculated correctly and deliveries are made promptly, if shipped by UPS.</field>
this.Address2_UPSZone = {};
  this.Address2_UPSZone.setValue = function (value) {
   ///<summary>Sets the Address2_UPSZone value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Address 2: UPS Zone : Type the UPS zone of the secondary address to make sure shipping charges are calculated correctly and deliveries are made promptly, if shipped by UPS.</para>
   /// <para>MaxLength: 4</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Address2_UPSZone.setValue(value);
  };
  this.Address2_UPSZone.getValue = function () {
   ///<summary>
   /// Gets the Address2_UPSZone value
   ///</summary>
   /// <returns type="String">Type the UPS zone of the secondary address to make sure shipping charges are calculated correctly and deliveries are made promptly, if shipped by UPS.</returns>
   return Address2_UPSZone.getValue();
  }
// Address2_UPSZone END --------------------------------------------------------------


// Address2_UTCOffset START --------------------------------------------------------------
var Address2_UTCOffset = new Sdk.Int("address2_utcoffset");
this.addAttribute(Address2_UTCOffset, false);
/// <field name='Address2_UTCOffset' type='Sdk.Int'>Address 2: UTC Offset : Select the time zone, or UTC offset, for this address so that other people can reference it when they contact someone at this address.</field>
this.Address2_UTCOffset = {};
this.Address2_UTCOffset.setValue = function (value) {
 ///<summary>Sets the Address2_UTCOffset value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Address 2: UTC Offset : Select the time zone, or UTC offset, for this address so that other people can reference it when they contact someone at this address.</para>
 /// <para>MaxValue: 2147483647</para>
 /// <para>MinValue: -2147483648</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 Address2_UTCOffset.setValue(value);
};
this.Address2_UTCOffset.getValue = function () {
 ///<summary>
 /// Gets the Address2_UTCOffset value
 ///</summary>
 /// <returns type="Number">Select the time zone, or UTC offset, for this address so that other people can reference it when they contact someone at this address.</returns>
 return Address2_UTCOffset.getValue();
}
// Address2_UTCOffset END --------------------------------------------------------------


// Aging30 START --------------------------------------------------------------
var Aging30 = new Sdk.Money("aging30");
this.addAttribute(Aging30, false);
/// <field name='Aging30' type='Sdk.Money'>Aging 30 : For system use only.</field>
this.Aging30 = {};
this.Aging30.getValue = function () {
 ///<summary>
 /// Gets the Aging30 value
 ///</summary>
 /// <returns type="Number">For system use only.</returns>
 return Aging30.getValue();
}
// Aging30 END --------------------------------------------------------------


// Aging30_Base START --------------------------------------------------------------
var Aging30_Base = new Sdk.Money("aging30_base");
this.addAttribute(Aging30_Base, false);
/// <field name='Aging30_Base' type='Sdk.Money'>Aging 30 (Base) : The base currency equivalent of the aging 30 field.</field>
this.Aging30_Base = {};
this.Aging30_Base.getValue = function () {
 ///<summary>
 /// Gets the Aging30_Base value
 ///</summary>
 /// <returns type="Number">The base currency equivalent of the aging 30 field.</returns>
 return Aging30_Base.getValue();
}
// Aging30_Base END --------------------------------------------------------------


// Aging60 START --------------------------------------------------------------
var Aging60 = new Sdk.Money("aging60");
this.addAttribute(Aging60, false);
/// <field name='Aging60' type='Sdk.Money'>Aging 60 : For system use only.</field>
this.Aging60 = {};
this.Aging60.getValue = function () {
 ///<summary>
 /// Gets the Aging60 value
 ///</summary>
 /// <returns type="Number">For system use only.</returns>
 return Aging60.getValue();
}
// Aging60 END --------------------------------------------------------------


// Aging60_Base START --------------------------------------------------------------
var Aging60_Base = new Sdk.Money("aging60_base");
this.addAttribute(Aging60_Base, false);
/// <field name='Aging60_Base' type='Sdk.Money'>Aging 60 (Base) : The base currency equivalent of the aging 60 field.</field>
this.Aging60_Base = {};
this.Aging60_Base.getValue = function () {
 ///<summary>
 /// Gets the Aging60_Base value
 ///</summary>
 /// <returns type="Number">The base currency equivalent of the aging 60 field.</returns>
 return Aging60_Base.getValue();
}
// Aging60_Base END --------------------------------------------------------------


// Aging90 START --------------------------------------------------------------
var Aging90 = new Sdk.Money("aging90");
this.addAttribute(Aging90, false);
/// <field name='Aging90' type='Sdk.Money'>Aging 90 : For system use only.</field>
this.Aging90 = {};
this.Aging90.getValue = function () {
 ///<summary>
 /// Gets the Aging90 value
 ///</summary>
 /// <returns type="Number">For system use only.</returns>
 return Aging90.getValue();
}
// Aging90 END --------------------------------------------------------------


// Aging90_Base START --------------------------------------------------------------
var Aging90_Base = new Sdk.Money("aging90_base");
this.addAttribute(Aging90_Base, false);
/// <field name='Aging90_Base' type='Sdk.Money'>Aging 90 (Base) : The base currency equivalent of the aging 90 field.</field>
this.Aging90_Base = {};
this.Aging90_Base.getValue = function () {
 ///<summary>
 /// Gets the Aging90_Base value
 ///</summary>
 /// <returns type="Number">The base currency equivalent of the aging 90 field.</returns>
 return Aging90_Base.getValue();
}
// Aging90_Base END --------------------------------------------------------------


// BusinessTypeCode START --------------------------------------------------------------
var BusinessTypeCode = new Sdk.OptionSet("businesstypecode");
  this.addAttribute(BusinessTypeCode, false);
  /// <field name='BusinessTypeCode' type='Sdk.OptionSet'>Business Type : Select the legal designation or other business type of the account for contracts or reporting purposes.</field>
  this.BusinessTypeCode = {};
 this.BusinessTypeCode.setValue = function (value) {
  ///<summary><para>Sets the BusinessTypeCode (Business Type) value</para>
   /// <para>Select the legal designation or other business type of the account for contracts or reporting purposes.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Default Value</para>
   /// </param>
   BusinessTypeCode.setValue(value);
  };
  this.BusinessTypeCode.getValue = function () {
   ///<summary>Gets the BusinessTypeCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the legal designation or other business type of the account for contracts or reporting purposes.</returns>
   return BusinessTypeCode.getValue();
  }
// BusinessTypeCode END --------------------------------------------------------------


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


// CreditLimit START --------------------------------------------------------------
var CreditLimit = new Sdk.Money("creditlimit");
this.addAttribute(CreditLimit, false);
/// <field name='CreditLimit' type='Sdk.Money'>Credit Limit : Type the credit limit of the account. This is a useful reference when you address invoice and accounting issues with the customer.</field>
this.CreditLimit = {};
this.CreditLimit.setValue = function (value) {
 ///<summary>Sets the CreditLimit value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Credit Limit : Type the credit limit of the account. This is a useful reference when you address invoice and accounting issues with the customer.</para>
 /// <para>MaxValue: 922337203685477</para>
 /// <para>MinValue: -922337203685477</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 CreditLimit.setValue(value);
};
this.CreditLimit.getValue = function () {
 ///<summary>
 /// Gets the CreditLimit value
 ///</summary>
 /// <returns type="Number">Type the credit limit of the account. This is a useful reference when you address invoice and accounting issues with the customer.</returns>
 return CreditLimit.getValue();
}
// CreditLimit END --------------------------------------------------------------


// CreditLimit_Base START --------------------------------------------------------------
var CreditLimit_Base = new Sdk.Money("creditlimit_base");
this.addAttribute(CreditLimit_Base, false);
/// <field name='CreditLimit_Base' type='Sdk.Money'>Credit Limit (Base) : Shows the credit limit converted to the system's default base currency for reporting purposes.</field>
this.CreditLimit_Base = {};
this.CreditLimit_Base.getValue = function () {
 ///<summary>
 /// Gets the CreditLimit_Base value
 ///</summary>
 /// <returns type="Number">Shows the credit limit converted to the system's default base currency for reporting purposes.</returns>
 return CreditLimit_Base.getValue();
}
// CreditLimit_Base END --------------------------------------------------------------


// CreditOnHold START --------------------------------------------------------------
var CreditOnHold = new Sdk.Boolean("creditonhold");
this.addAttribute(CreditOnHold, false);
/// <field name='CreditOnHold' type='Sdk.String'>Credit Hold : Select whether the credit for the account is on hold. This is a useful reference while addressing the invoice and accounting issues with the customer. </field>
this.CreditOnHold = {};
this.CreditOnHold.setValue = function (value) {
 ///<summary>Sets the CreditOnHold value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Credit Hold  : Select whether the credit for the account is on hold. This is a useful reference while addressing the invoice and accounting issues with the customer. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: Yes</para>
 /// <para>False Label: No</para>
 /// </param>
CreditOnHold.setValue(value);
};
this.CreditOnHold.getValue = function () {
 ///<summary>
 /// Gets the CreditOnHold value
 ///</summary>
 /// <returns type="Boolean">Select whether the credit for the account is on hold. This is a useful reference while addressing the invoice and accounting issues with the customer.</returns>
return CreditOnHold.getValue();
}
// CreditOnHold END --------------------------------------------------------------


// CustomerSizeCode START --------------------------------------------------------------
var CustomerSizeCode = new Sdk.OptionSet("customersizecode");
  this.addAttribute(CustomerSizeCode, false);
  /// <field name='CustomerSizeCode' type='Sdk.OptionSet'>Customer Size : Select the size category or range of the account for segmentation and reporting purposes.</field>
  this.CustomerSizeCode = {};
 this.CustomerSizeCode.setValue = function (value) {
  ///<summary><para>Sets the CustomerSizeCode (Customer Size) value</para>
   /// <para>Select the size category or range of the account for segmentation and reporting purposes.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Default Value</para>
   /// </param>
   CustomerSizeCode.setValue(value);
  };
  this.CustomerSizeCode.getValue = function () {
   ///<summary>Gets the CustomerSizeCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the size category or range of the account for segmentation and reporting purposes.</returns>
   return CustomerSizeCode.getValue();
  }
// CustomerSizeCode END --------------------------------------------------------------


// CustomerTypeCode START --------------------------------------------------------------
var CustomerTypeCode = new Sdk.OptionSet("customertypecode");
  this.addAttribute(CustomerTypeCode, false);
  /// <field name='CustomerTypeCode' type='Sdk.OptionSet'>Relationship Type : Select the category that best describes the relationship between the account and your organization.</field>
  this.CustomerTypeCode = {};
 this.CustomerTypeCode.setValue = function (value) {
  ///<summary><para>Sets the CustomerTypeCode (Relationship Type) value</para>
   /// <para>Select the category that best describes the relationship between the account and your organization.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Competitor</para>
/// <para> 2 : Consultant</para>
/// <para> 3 : Customer</para>
/// <para> 4 : Investor</para>
/// <para> 5 : Partner</para>
/// <para> 6 : Influencer</para>
/// <para> 7 : Press</para>
/// <para> 8 : Prospect</para>
/// <para> 9 : Reseller</para>
/// <para> 10 : Supplier</para>
/// <para> 11 : Vendor</para>
/// <para> 12 : Other</para>
   /// </param>
   CustomerTypeCode.setValue(value);
  };
  this.CustomerTypeCode.getValue = function () {
   ///<summary>Gets the CustomerTypeCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the category that best describes the relationship between the account and your organization.</returns>
   return CustomerTypeCode.getValue();
  }
// CustomerTypeCode END --------------------------------------------------------------


// DefaultPriceLevelId START --------------------------------------------------------------
var DefaultPriceLevelId = new Sdk.Lookup("defaultpricelevelid");
this.addAttribute(DefaultPriceLevelId, false);
/// <field name='DefaultPriceLevelId' type='Sdk.Lookup'>Price List : Choose the default price list associated with the account to make sure the correct product prices for this customer are applied in sales opportunities, quotes, and orders.</field>
this.DefaultPriceLevelId = {};
this.DefaultPriceLevelId.setValue = function (value) {
///<summary><para>Sets the DefaultPriceLevelId value</para>
/// <para>Display Name: Price List</para>
/// <para>Targets: pricelevel</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Choose the default price list associated with the account to make sure the correct product prices for this customer are applied in sales opportunities, quotes, and orders.</param>
 DefaultPriceLevelId.setValue(value);
};
this.DefaultPriceLevelId.getValue = function () {
 ///<summary>
 /// Gets the DefaultPriceLevelId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Choose the default price list associated with the account to make sure the correct product prices for this customer are applied in sales opportunities, quotes, and orders.</returns>
 return DefaultPriceLevelId.getValue();
}
// DefaultPriceLevelId END --------------------------------------------------------------


// Description START --------------------------------------------------------------
  var Description = new Sdk.String("description");
  this.addAttribute(Description, false);
  /// <field name='Description' type='Sdk.String'>Description : Type additional information to describe the account, such as an excerpt from the company's website.</field>
this.Description = {};
  this.Description.setValue = function (value) {
   ///<summary>Sets the Description value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Description : Type additional information to describe the account, such as an excerpt from the company's website.</para>
   /// <para>MaxLength: 2000</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Description.setValue(value);
  };
  this.Description.getValue = function () {
   ///<summary>
   /// Gets the Description value
   ///</summary>
   /// <returns type="String">Type additional information to describe the account, such as an excerpt from the company's website.</returns>
   return Description.getValue();
  }
// Description END --------------------------------------------------------------


// DoNotBulkEMail START --------------------------------------------------------------
var DoNotBulkEMail = new Sdk.Boolean("donotbulkemail");
this.addAttribute(DoNotBulkEMail, false);
/// <field name='DoNotBulkEMail' type='Sdk.String'>Do not allow Bulk Emails : Select whether the account allows bulk email sent through campaigns. If Do Not Allow is selected, the account can be added to marketing lists, but is excluded from email. </field>
this.DoNotBulkEMail = {};
this.DoNotBulkEMail.setValue = function (value) {
 ///<summary>Sets the DoNotBulkEMail value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Do not allow Bulk Emails  : Select whether the account allows bulk email sent through campaigns. If Do Not Allow is selected, the account can be added to marketing lists, but is excluded from email. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: Do Not Allow</para>
 /// <para>False Label: Allow</para>
 /// </param>
DoNotBulkEMail.setValue(value);
};
this.DoNotBulkEMail.getValue = function () {
 ///<summary>
 /// Gets the DoNotBulkEMail value
 ///</summary>
 /// <returns type="Boolean">Select whether the account allows bulk email sent through campaigns. If Do Not Allow is selected, the account can be added to marketing lists, but is excluded from email.</returns>
return DoNotBulkEMail.getValue();
}
// DoNotBulkEMail END --------------------------------------------------------------


// DoNotBulkPostalMail START --------------------------------------------------------------
var DoNotBulkPostalMail = new Sdk.Boolean("donotbulkpostalmail");
this.addAttribute(DoNotBulkPostalMail, false);
/// <field name='DoNotBulkPostalMail' type='Sdk.String'>Do not allow Bulk Mails : Select whether the account allows bulk postal mail sent through marketing campaigns or quick campaigns. If Do Not Allow is selected, the account can be added to marketing lists, but will be excluded from the postal mail. </field>
this.DoNotBulkPostalMail = {};
this.DoNotBulkPostalMail.setValue = function (value) {
 ///<summary>Sets the DoNotBulkPostalMail value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Do not allow Bulk Mails  : Select whether the account allows bulk postal mail sent through marketing campaigns or quick campaigns. If Do Not Allow is selected, the account can be added to marketing lists, but will be excluded from the postal mail. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: Yes</para>
 /// <para>False Label: No</para>
 /// </param>
DoNotBulkPostalMail.setValue(value);
};
this.DoNotBulkPostalMail.getValue = function () {
 ///<summary>
 /// Gets the DoNotBulkPostalMail value
 ///</summary>
 /// <returns type="Boolean">Select whether the account allows bulk postal mail sent through marketing campaigns or quick campaigns. If Do Not Allow is selected, the account can be added to marketing lists, but will be excluded from the postal mail.</returns>
return DoNotBulkPostalMail.getValue();
}
// DoNotBulkPostalMail END --------------------------------------------------------------


// DoNotEMail START --------------------------------------------------------------
var DoNotEMail = new Sdk.Boolean("donotemail");
this.addAttribute(DoNotEMail, false);
/// <field name='DoNotEMail' type='Sdk.String'>Do not allow Emails : Select whether the account allows direct email sent from Microsoft Dynamics CRM. </field>
this.DoNotEMail = {};
this.DoNotEMail.setValue = function (value) {
 ///<summary>Sets the DoNotEMail value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Do not allow Emails  : Select whether the account allows direct email sent from Microsoft Dynamics CRM. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: Do Not Allow</para>
 /// <para>False Label: Allow</para>
 /// </param>
DoNotEMail.setValue(value);
};
this.DoNotEMail.getValue = function () {
 ///<summary>
 /// Gets the DoNotEMail value
 ///</summary>
 /// <returns type="Boolean">Select whether the account allows direct email sent from Microsoft Dynamics CRM.</returns>
return DoNotEMail.getValue();
}
// DoNotEMail END --------------------------------------------------------------


// DoNotFax START --------------------------------------------------------------
var DoNotFax = new Sdk.Boolean("donotfax");
this.addAttribute(DoNotFax, false);
/// <field name='DoNotFax' type='Sdk.String'>Do not allow Faxes : Select whether the account allows faxes. If Do Not Allow is selected, the account will be excluded from fax activities distributed in marketing campaigns. </field>
this.DoNotFax = {};
this.DoNotFax.setValue = function (value) {
 ///<summary>Sets the DoNotFax value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Do not allow Faxes  : Select whether the account allows faxes. If Do Not Allow is selected, the account will be excluded from fax activities distributed in marketing campaigns. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: Do Not Allow</para>
 /// <para>False Label: Allow</para>
 /// </param>
DoNotFax.setValue(value);
};
this.DoNotFax.getValue = function () {
 ///<summary>
 /// Gets the DoNotFax value
 ///</summary>
 /// <returns type="Boolean">Select whether the account allows faxes. If Do Not Allow is selected, the account will be excluded from fax activities distributed in marketing campaigns.</returns>
return DoNotFax.getValue();
}
// DoNotFax END --------------------------------------------------------------


// DoNotPhone START --------------------------------------------------------------
var DoNotPhone = new Sdk.Boolean("donotphone");
this.addAttribute(DoNotPhone, false);
/// <field name='DoNotPhone' type='Sdk.String'>Do not allow Phone Calls : Select whether the account allows phone calls. If Do Not Allow is selected, the account will be excluded from phone call activities distributed in marketing campaigns. </field>
this.DoNotPhone = {};
this.DoNotPhone.setValue = function (value) {
 ///<summary>Sets the DoNotPhone value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Do not allow Phone Calls  : Select whether the account allows phone calls. If Do Not Allow is selected, the account will be excluded from phone call activities distributed in marketing campaigns. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: Do Not Allow</para>
 /// <para>False Label: Allow</para>
 /// </param>
DoNotPhone.setValue(value);
};
this.DoNotPhone.getValue = function () {
 ///<summary>
 /// Gets the DoNotPhone value
 ///</summary>
 /// <returns type="Boolean">Select whether the account allows phone calls. If Do Not Allow is selected, the account will be excluded from phone call activities distributed in marketing campaigns.</returns>
return DoNotPhone.getValue();
}
// DoNotPhone END --------------------------------------------------------------


// DoNotPostalMail START --------------------------------------------------------------
var DoNotPostalMail = new Sdk.Boolean("donotpostalmail");
this.addAttribute(DoNotPostalMail, false);
/// <field name='DoNotPostalMail' type='Sdk.String'>Do not allow Mails : Select whether the account allows direct mail. If Do Not Allow is selected, the account will be excluded from letter activities distributed in marketing campaigns. </field>
this.DoNotPostalMail = {};
this.DoNotPostalMail.setValue = function (value) {
 ///<summary>Sets the DoNotPostalMail value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Do not allow Mails  : Select whether the account allows direct mail. If Do Not Allow is selected, the account will be excluded from letter activities distributed in marketing campaigns. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: Do Not Allow</para>
 /// <para>False Label: Allow</para>
 /// </param>
DoNotPostalMail.setValue(value);
};
this.DoNotPostalMail.getValue = function () {
 ///<summary>
 /// Gets the DoNotPostalMail value
 ///</summary>
 /// <returns type="Boolean">Select whether the account allows direct mail. If Do Not Allow is selected, the account will be excluded from letter activities distributed in marketing campaigns.</returns>
return DoNotPostalMail.getValue();
}
// DoNotPostalMail END --------------------------------------------------------------


// DoNotSendMM START --------------------------------------------------------------
var DoNotSendMM = new Sdk.Boolean("donotsendmm");
this.addAttribute(DoNotSendMM, false);
/// <field name='DoNotSendMM' type='Sdk.String'>Send Marketing Materials : Select whether the account accepts marketing materials, such as brochures or catalogs. </field>
this.DoNotSendMM = {};
this.DoNotSendMM.setValue = function (value) {
 ///<summary>Sets the DoNotSendMM value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Send Marketing Materials  : Select whether the account accepts marketing materials, such as brochures or catalogs. </para>
 /// <para>RequiredLevel: None</para>
 /// <para>True Label: Do Not Send</para>
 /// <para>False Label: Send</para>
 /// </param>
DoNotSendMM.setValue(value);
};
this.DoNotSendMM.getValue = function () {
 ///<summary>
 /// Gets the DoNotSendMM value
 ///</summary>
 /// <returns type="Boolean">Select whether the account accepts marketing materials, such as brochures or catalogs.</returns>
return DoNotSendMM.getValue();
}
// DoNotSendMM END --------------------------------------------------------------


// EMailAddress1 START --------------------------------------------------------------
  var EMailAddress1 = new Sdk.String("emailaddress1");
  this.addAttribute(EMailAddress1, false);
  /// <field name='EMailAddress1' type='Sdk.String'>Email : Type the primary email address for the account.</field>
this.EMailAddress1 = {};
  this.EMailAddress1.setValue = function (value) {
   ///<summary>Sets the EMailAddress1 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Email : Type the primary email address for the account.</para>
   /// <para>MaxLength: 100</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   EMailAddress1.setValue(value);
  };
  this.EMailAddress1.getValue = function () {
   ///<summary>
   /// Gets the EMailAddress1 value
   ///</summary>
   /// <returns type="String">Type the primary email address for the account.</returns>
   return EMailAddress1.getValue();
  }
// EMailAddress1 END --------------------------------------------------------------


// EMailAddress2 START --------------------------------------------------------------
  var EMailAddress2 = new Sdk.String("emailaddress2");
  this.addAttribute(EMailAddress2, false);
  /// <field name='EMailAddress2' type='Sdk.String'>Email Address 2 : Type the secondary email address for the account.</field>
this.EMailAddress2 = {};
  this.EMailAddress2.setValue = function (value) {
   ///<summary>Sets the EMailAddress2 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Email Address 2 : Type the secondary email address for the account.</para>
   /// <para>MaxLength: 100</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   EMailAddress2.setValue(value);
  };
  this.EMailAddress2.getValue = function () {
   ///<summary>
   /// Gets the EMailAddress2 value
   ///</summary>
   /// <returns type="String">Type the secondary email address for the account.</returns>
   return EMailAddress2.getValue();
  }
// EMailAddress2 END --------------------------------------------------------------


// EMailAddress3 START --------------------------------------------------------------
  var EMailAddress3 = new Sdk.String("emailaddress3");
  this.addAttribute(EMailAddress3, false);
  /// <field name='EMailAddress3' type='Sdk.String'>Email Address 3 : Type an alternate email address for the account.</field>
this.EMailAddress3 = {};
  this.EMailAddress3.setValue = function (value) {
   ///<summary>Sets the EMailAddress3 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Email Address 3 : Type an alternate email address for the account.</para>
   /// <para>MaxLength: 100</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   EMailAddress3.setValue(value);
  };
  this.EMailAddress3.getValue = function () {
   ///<summary>
   /// Gets the EMailAddress3 value
   ///</summary>
   /// <returns type="String">Type an alternate email address for the account.</returns>
   return EMailAddress3.getValue();
  }
// EMailAddress3 END --------------------------------------------------------------


// EntityImageId START --------------------------------------------------------------
var EntityImageId = new Sdk.Guid("entityimageid");
this.addAttribute(EntityImageId, false);
 /// <field name='EntityImageId' type='Sdk.Guid'>Entity Image Id : For internal use only.</field>
this.EntityImageId = {};
this.EntityImageId.getValue = function () {
 ///<summary>Gets the EntityImageId value</summary>
 /// <returns type="String" mayBeNull="true">For internal use only.</returns>
return EntityImageId.getValue();
}
// EntityImageId END --------------------------------------------------------------


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


// Fax START --------------------------------------------------------------
  var Fax = new Sdk.String("fax");
  this.addAttribute(Fax, false);
  /// <field name='Fax' type='Sdk.String'>Fax : Type the fax number for the account.</field>
this.Fax = {};
  this.Fax.setValue = function (value) {
   ///<summary>Sets the Fax value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Fax : Type the fax number for the account.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Fax.setValue(value);
  };
  this.Fax.getValue = function () {
   ///<summary>
   /// Gets the Fax value
   ///</summary>
   /// <returns type="String">Type the fax number for the account.</returns>
   return Fax.getValue();
  }
// Fax END --------------------------------------------------------------


// FtpSiteURL START --------------------------------------------------------------
  var FtpSiteURL = new Sdk.String("ftpsiteurl");
  this.addAttribute(FtpSiteURL, false);
  /// <field name='FtpSiteURL' type='Sdk.String'>FTP Site : Type the URL for the account's FTP site to enable users to access data and share documents.</field>
this.FtpSiteURL = {};
  this.FtpSiteURL.setValue = function (value) {
   ///<summary>Sets the FtpSiteURL value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>FTP Site : Type the URL for the account's FTP site to enable users to access data and share documents.</para>
   /// <para>MaxLength: 200</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   FtpSiteURL.setValue(value);
  };
  this.FtpSiteURL.getValue = function () {
   ///<summary>
   /// Gets the FtpSiteURL value
   ///</summary>
   /// <returns type="String">Type the URL for the account's FTP site to enable users to access data and share documents.</returns>
   return FtpSiteURL.getValue();
  }
// FtpSiteURL END --------------------------------------------------------------


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


// IndustryCode START --------------------------------------------------------------
var IndustryCode = new Sdk.OptionSet("industrycode");
  this.addAttribute(IndustryCode, false);
  /// <field name='IndustryCode' type='Sdk.OptionSet'>Industry : Select the account's primary industry for use in marketing segmentation and demographic analysis.</field>
  this.IndustryCode = {};
 this.IndustryCode.setValue = function (value) {
  ///<summary><para>Sets the IndustryCode (Industry) value</para>
   /// <para>Select the account's primary industry for use in marketing segmentation and demographic analysis.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Accounting</para>
/// <para> 2 : Agriculture and Non-petrol Natural Resource Extraction</para>
/// <para> 3 : Broadcasting Printing and Publishing</para>
/// <para> 4 : Brokers</para>
/// <para> 5 : Building Supply Retail</para>
/// <para> 6 : Business Services</para>
/// <para> 7 : Consulting</para>
/// <para> 8 : Consumer Services</para>
/// <para> 9 : Design, Direction and Creative Management</para>
/// <para> 10 : Distributors, Dispatchers and Processors</para>
/// <para> 11 : Doctor's Offices and Clinics</para>
/// <para> 12 : Durable Manufacturing</para>
/// <para> 13 : Eating and Drinking Places</para>
/// <para> 14 : Entertainment Retail</para>
/// <para> 15 : Equipment Rental and Leasing</para>
/// <para> 16 : Financial</para>
/// <para> 17 : Food and Tobacco Processing</para>
/// <para> 18 : Inbound Capital Intensive Processing</para>
/// <para> 19 : Inbound Repair and Services</para>
/// <para> 20 : Insurance</para>
/// <para> 21 : Legal Services</para>
/// <para> 22 : Non-Durable Merchandise Retail</para>
/// <para> 23 : Outbound Consumer Service</para>
/// <para> 24 : Petrochemical Extraction and Distribution</para>
/// <para> 25 : Service Retail</para>
/// <para> 26 : SIG Affiliations</para>
/// <para> 27 : Social Services</para>
/// <para> 28 : Special Outbound Trade Contractors</para>
/// <para> 29 : Specialty Realty</para>
/// <para> 30 : Transportation</para>
/// <para> 31 : Utility Creation and Distribution</para>
/// <para> 32 : Vehicle Retail</para>
/// <para> 33 : Wholesale</para>
   /// </param>
   IndustryCode.setValue(value);
  };
  this.IndustryCode.getValue = function () {
   ///<summary>Gets the IndustryCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the account's primary industry for use in marketing segmentation and demographic analysis.</returns>
   return IndustryCode.getValue();
  }
// IndustryCode END --------------------------------------------------------------


// IsPrivate START --------------------------------------------------------------
var IsPrivate = new Sdk.Boolean("isprivate");
this.addAttribute(IsPrivate, false);
/// <field name='IsPrivate' type='Sdk.String'>No Display Name : No Description </field>
this.IsPrivate = {};
// IsPrivate END --------------------------------------------------------------


// LastUsedInCampaign START --------------------------------------------------------------
var LastUsedInCampaign = new Sdk.DateTime("lastusedincampaign");
this.addAttribute(LastUsedInCampaign, false);
/// <field name='LastUsedInCampaign' type='Sdk.DateTime'>Last Date Included in Campaign : Shows the date when the account was last included in a marketing campaign or quick campaign.</field>
this.LastUsedInCampaign = {};
this.LastUsedInCampaign.setValue = function (value) {
 ///<summary><para>Sets the LastUsedInCampaign (Last Date Included in Campaign) value</para>
 /// <para>RequiredLevel: None</para>
 ///</summary>
 /// <param name="value" type="Date" optional="false">Shows the date when the account was last included in a marketing campaign or quick campaign.</param>
 LastUsedInCampaign.setValue(value);
};
this.LastUsedInCampaign.getValue = function () {
 ///<summary>
 /// Gets the LastUsedInCampaign value
 ///</summary>
 /// <returns type="Date">Shows the date when the account was last included in a marketing campaign or quick campaign.</returns>
 return LastUsedInCampaign.getValue();
}
// LastUsedInCampaign END --------------------------------------------------------------


// MarketCap START --------------------------------------------------------------
var MarketCap = new Sdk.Money("marketcap");
this.addAttribute(MarketCap, false);
/// <field name='MarketCap' type='Sdk.Money'>Market Capitalization : Type the market capitalization of the account to identify the company's equity, used as an indicator in financial performance analysis.</field>
this.MarketCap = {};
this.MarketCap.setValue = function (value) {
 ///<summary>Sets the MarketCap value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Market Capitalization : Type the market capitalization of the account to identify the company's equity, used as an indicator in financial performance analysis.</para>
 /// <para>MaxValue: 922337203685477</para>
 /// <para>MinValue: -922337203685477</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 MarketCap.setValue(value);
};
this.MarketCap.getValue = function () {
 ///<summary>
 /// Gets the MarketCap value
 ///</summary>
 /// <returns type="Number">Type the market capitalization of the account to identify the company's equity, used as an indicator in financial performance analysis.</returns>
 return MarketCap.getValue();
}
// MarketCap END --------------------------------------------------------------


// MarketCap_Base START --------------------------------------------------------------
var MarketCap_Base = new Sdk.Money("marketcap_base");
this.addAttribute(MarketCap_Base, false);
/// <field name='MarketCap_Base' type='Sdk.Money'>Market Capitalization (Base) : Shows the market capitalization converted to the system's default base currency.</field>
this.MarketCap_Base = {};
this.MarketCap_Base.getValue = function () {
 ///<summary>
 /// Gets the MarketCap_Base value
 ///</summary>
 /// <returns type="Number">Shows the market capitalization converted to the system's default base currency.</returns>
 return MarketCap_Base.getValue();
}
// MarketCap_Base END --------------------------------------------------------------


// MasterId START --------------------------------------------------------------
var MasterId = new Sdk.Lookup("masterid");
this.addAttribute(MasterId, false);
/// <field name='MasterId' type='Sdk.Lookup'>Master ID : Shows the master account that the account was merged with.</field>
this.MasterId = {};
this.MasterId.getValue = function () {
 ///<summary>
 /// Gets the MasterId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Shows the master account that the account was merged with.</returns>
 return MasterId.getValue();
}
// MasterId END --------------------------------------------------------------


// Merged START --------------------------------------------------------------
var Merged = new Sdk.Boolean("merged");
this.addAttribute(Merged, false);
/// <field name='Merged' type='Sdk.String'>Merged : Shows whether the account has been merged with another account. </field>
this.Merged = {};
this.Merged.getValue = function () {
 ///<summary>
 /// Gets the Merged value
 ///</summary>
 /// <returns type="Boolean">Shows whether the account has been merged with another account.</returns>
return Merged.getValue();
}
// Merged END --------------------------------------------------------------


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
/// <field name='ModifiedOnBehalfBy' type='Sdk.Lookup'>Modified By (Delegate) : Shows who created the record on behalf of another user.</field>
this.ModifiedOnBehalfBy = {};
this.ModifiedOnBehalfBy.getValue = function () {
 ///<summary>
 /// Gets the ModifiedOnBehalfBy value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Shows who created the record on behalf of another user.</returns>
 return ModifiedOnBehalfBy.getValue();
}
// ModifiedOnBehalfBy END --------------------------------------------------------------


// Name START --------------------------------------------------------------
  var Name = new Sdk.String("name");
  this.addAttribute(Name, false);
  /// <field name='Name' type='Sdk.String'>Account Name : Type the company or business name.</field>
this.Name = {};
  this.Name.setValue = function (value) {
   ///<summary>Sets the Name value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Account Name : Type the company or business name.</para>
   /// <para>MaxLength: 160</para>
   /// <para>RequiredLevel: ApplicationRequired</para>
   /// </param>
   Name.setValue(value);
  };
  this.Name.getValue = function () {
   ///<summary>
   /// Gets the Name value
   ///</summary>
   /// <returns type="String">Type the company or business name.</returns>
   return Name.getValue();
  }
// Name END --------------------------------------------------------------


// NumberOfEmployees START --------------------------------------------------------------
var NumberOfEmployees = new Sdk.Int("numberofemployees");
this.addAttribute(NumberOfEmployees, false);
/// <field name='NumberOfEmployees' type='Sdk.Int'>No. of Employees : Type the number of employees that work at the account for use in marketing segmentation and demographic analysis.</field>
this.NumberOfEmployees = {};
this.NumberOfEmployees.setValue = function (value) {
 ///<summary>Sets the NumberOfEmployees value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>No. of Employees : Type the number of employees that work at the account for use in marketing segmentation and demographic analysis.</para>
 /// <para>MaxValue: 2147483647</para>
 /// <para>MinValue: -2147483648</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 NumberOfEmployees.setValue(value);
};
this.NumberOfEmployees.getValue = function () {
 ///<summary>
 /// Gets the NumberOfEmployees value
 ///</summary>
 /// <returns type="Number">Type the number of employees that work at the account for use in marketing segmentation and demographic analysis.</returns>
 return NumberOfEmployees.getValue();
}
// NumberOfEmployees END --------------------------------------------------------------


// OriginatingLeadId START --------------------------------------------------------------
var OriginatingLeadId = new Sdk.Lookup("originatingleadid");
this.addAttribute(OriginatingLeadId, false);
/// <field name='OriginatingLeadId' type='Sdk.Lookup'>Originating Lead : Shows the lead that the account was created from if the account was created by converting a lead in Microsoft Dynamics CRM. This is used to relate the account to data on the originating lead for use in reporting and analytics.</field>
this.OriginatingLeadId = {};
this.OriginatingLeadId.setValue = function (value) {
///<summary><para>Sets the OriginatingLeadId value</para>
/// <para>Display Name: Originating Lead</para>
/// <para>Targets: lead</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Shows the lead that the account was created from if the account was created by converting a lead in Microsoft Dynamics CRM. This is used to relate the account to data on the originating lead for use in reporting and analytics.</param>
 OriginatingLeadId.setValue(value);
};
this.OriginatingLeadId.getValue = function () {
 ///<summary>
 /// Gets the OriginatingLeadId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Shows the lead that the account was created from if the account was created by converting a lead in Microsoft Dynamics CRM. This is used to relate the account to data on the originating lead for use in reporting and analytics.</returns>
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


// OwnershipCode START --------------------------------------------------------------
var OwnershipCode = new Sdk.OptionSet("ownershipcode");
  this.addAttribute(OwnershipCode, false);
  /// <field name='OwnershipCode' type='Sdk.OptionSet'>Ownership : Select the account's ownership structure, such as public or private.</field>
  this.OwnershipCode = {};
 this.OwnershipCode.setValue = function (value) {
  ///<summary><para>Sets the OwnershipCode (Ownership) value</para>
   /// <para>Select the account's ownership structure, such as public or private.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Public</para>
/// <para> 2 : Private</para>
/// <para> 3 : Subsidiary</para>
/// <para> 4 : Other</para>
   /// </param>
   OwnershipCode.setValue(value);
  };
  this.OwnershipCode.getValue = function () {
   ///<summary>Gets the OwnershipCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the account's ownership structure, such as public or private.</returns>
   return OwnershipCode.getValue();
  }
// OwnershipCode END --------------------------------------------------------------


// OwningBusinessUnit START --------------------------------------------------------------
var OwningBusinessUnit = new Sdk.Lookup("owningbusinessunit");
this.addAttribute(OwningBusinessUnit, false);
/// <field name='OwningBusinessUnit' type='Sdk.Lookup'>Owning Business Unit : Shows the business unit that the record owner belongs to.</field>
this.OwningBusinessUnit = {};
this.OwningBusinessUnit.getValue = function () {
 ///<summary>
 /// Gets the OwningBusinessUnit value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Shows the business unit that the record owner belongs to.</returns>
 return OwningBusinessUnit.getValue();
}
// OwningBusinessUnit END --------------------------------------------------------------


// OwningTeam START --------------------------------------------------------------
var OwningTeam = new Sdk.Lookup("owningteam");
this.addAttribute(OwningTeam, false);
/// <field name='OwningTeam' type='Sdk.Lookup'>Owning Team : Unique identifier of the team who owns the account.</field>
this.OwningTeam = {};
this.OwningTeam.getValue = function () {
 ///<summary>
 /// Gets the OwningTeam value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Unique identifier of the team who owns the account.</returns>
 return OwningTeam.getValue();
}
// OwningTeam END --------------------------------------------------------------


// OwningUser START --------------------------------------------------------------
var OwningUser = new Sdk.Lookup("owninguser");
this.addAttribute(OwningUser, false);
/// <field name='OwningUser' type='Sdk.Lookup'>Owning User : Unique identifier of the user who owns the account.</field>
this.OwningUser = {};
this.OwningUser.getValue = function () {
 ///<summary>
 /// Gets the OwningUser value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Unique identifier of the user who owns the account.</returns>
 return OwningUser.getValue();
}
// OwningUser END --------------------------------------------------------------


// ParentAccountId START --------------------------------------------------------------
var ParentAccountId = new Sdk.Lookup("parentaccountid");
this.addAttribute(ParentAccountId, false);
/// <field name='ParentAccountId' type='Sdk.Lookup'>Parent Account : Choose the parent account associated with this account to show parent and child businesses in reporting and analytics.</field>
this.ParentAccountId = {};
this.ParentAccountId.setValue = function (value) {
///<summary><para>Sets the ParentAccountId value</para>
/// <para>Display Name: Parent Account</para>
/// <para>Targets: account</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Choose the parent account associated with this account to show parent and child businesses in reporting and analytics.</param>
 ParentAccountId.setValue(value);
};
this.ParentAccountId.getValue = function () {
 ///<summary>
 /// Gets the ParentAccountId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Choose the parent account associated with this account to show parent and child businesses in reporting and analytics.</returns>
 return ParentAccountId.getValue();
}
// ParentAccountId END --------------------------------------------------------------


// ParticipatesInWorkflow START --------------------------------------------------------------
var ParticipatesInWorkflow = new Sdk.Boolean("participatesinworkflow");
this.addAttribute(ParticipatesInWorkflow, false);
/// <field name='ParticipatesInWorkflow' type='Sdk.String'>Participates in Workflow : For system use only. Legacy Microsoft Dynamics CRM 3.0 workflow data. </field>
this.ParticipatesInWorkflow = {};
this.ParticipatesInWorkflow.setValue = function (value) {
 ///<summary>Sets the ParticipatesInWorkflow value</summary>
 /// <param name="value" type="Boolean" optional="false">
 /// <para>Participates in Workflow  : For system use only. Legacy Microsoft Dynamics CRM 3.0 workflow data. </para>
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
 /// <returns type="Boolean">For system use only. Legacy Microsoft Dynamics CRM 3.0 workflow data.</returns>
return ParticipatesInWorkflow.getValue();
}
// ParticipatesInWorkflow END --------------------------------------------------------------


// PaymentTermsCode START --------------------------------------------------------------
var PaymentTermsCode = new Sdk.OptionSet("paymenttermscode");
  this.addAttribute(PaymentTermsCode, false);
  /// <field name='PaymentTermsCode' type='Sdk.OptionSet'>Payment Terms : Select the payment terms to indicate when the customer needs to pay the total amount.</field>
  this.PaymentTermsCode = {};
 this.PaymentTermsCode.setValue = function (value) {
  ///<summary><para>Sets the PaymentTermsCode (Payment Terms) value</para>
   /// <para>Select the payment terms to indicate when the customer needs to pay the total amount.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Net 30</para>
/// <para> 2 : 2% 10, Net 30</para>
/// <para> 3 : Net 45</para>
/// <para> 4 : Net 60</para>
   /// </param>
   PaymentTermsCode.setValue(value);
  };
  this.PaymentTermsCode.getValue = function () {
   ///<summary>Gets the PaymentTermsCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the payment terms to indicate when the customer needs to pay the total amount.</returns>
   return PaymentTermsCode.getValue();
  }
// PaymentTermsCode END --------------------------------------------------------------


// PreferredAppointmentDayCode START --------------------------------------------------------------
var PreferredAppointmentDayCode = new Sdk.OptionSet("preferredappointmentdaycode");
  this.addAttribute(PreferredAppointmentDayCode, false);
  /// <field name='PreferredAppointmentDayCode' type='Sdk.OptionSet'>Preferred Day : Select the preferred day of the week for service appointments.</field>
  this.PreferredAppointmentDayCode = {};
 this.PreferredAppointmentDayCode.setValue = function (value) {
  ///<summary><para>Sets the PreferredAppointmentDayCode (Preferred Day) value</para>
   /// <para>Select the preferred day of the week for service appointments.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 0 : Sunday</para>
/// <para> 1 : Monday</para>
/// <para> 2 : Tuesday</para>
/// <para> 3 : Wednesday</para>
/// <para> 4 : Thursday</para>
/// <para> 5 : Friday</para>
/// <para> 6 : Saturday</para>
   /// </param>
   PreferredAppointmentDayCode.setValue(value);
  };
  this.PreferredAppointmentDayCode.getValue = function () {
   ///<summary>Gets the PreferredAppointmentDayCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the preferred day of the week for service appointments.</returns>
   return PreferredAppointmentDayCode.getValue();
  }
// PreferredAppointmentDayCode END --------------------------------------------------------------


// PreferredAppointmentTimeCode START --------------------------------------------------------------
var PreferredAppointmentTimeCode = new Sdk.OptionSet("preferredappointmenttimecode");
  this.addAttribute(PreferredAppointmentTimeCode, false);
  /// <field name='PreferredAppointmentTimeCode' type='Sdk.OptionSet'>Preferred Time : Select the preferred time of day for service appointments.</field>
  this.PreferredAppointmentTimeCode = {};
 this.PreferredAppointmentTimeCode.setValue = function (value) {
  ///<summary><para>Sets the PreferredAppointmentTimeCode (Preferred Time) value</para>
   /// <para>Select the preferred time of day for service appointments.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Morning</para>
/// <para> 2 : Afternoon</para>
/// <para> 3 : Evening</para>
   /// </param>
   PreferredAppointmentTimeCode.setValue(value);
  };
  this.PreferredAppointmentTimeCode.getValue = function () {
   ///<summary>Gets the PreferredAppointmentTimeCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the preferred time of day for service appointments.</returns>
   return PreferredAppointmentTimeCode.getValue();
  }
// PreferredAppointmentTimeCode END --------------------------------------------------------------


// PreferredContactMethodCode START --------------------------------------------------------------
var PreferredContactMethodCode = new Sdk.OptionSet("preferredcontactmethodcode");
  this.addAttribute(PreferredContactMethodCode, false);
  /// <field name='PreferredContactMethodCode' type='Sdk.OptionSet'>Preferred Method of Contact : Select the preferred method of contact.</field>
  this.PreferredContactMethodCode = {};
 this.PreferredContactMethodCode.setValue = function (value) {
  ///<summary><para>Sets the PreferredContactMethodCode (Preferred Method of Contact) value</para>
   /// <para>Select the preferred method of contact.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Any</para>
/// <para> 2 : Email</para>
/// <para> 3 : Phone</para>
/// <para> 4 : Fax</para>
/// <para> 5 : Mail</para>
   /// </param>
   PreferredContactMethodCode.setValue(value);
  };
  this.PreferredContactMethodCode.getValue = function () {
   ///<summary>Gets the PreferredContactMethodCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the preferred method of contact.</returns>
   return PreferredContactMethodCode.getValue();
  }
// PreferredContactMethodCode END --------------------------------------------------------------


// PreferredEquipmentId START --------------------------------------------------------------
var PreferredEquipmentId = new Sdk.Lookup("preferredequipmentid");
this.addAttribute(PreferredEquipmentId, false);
/// <field name='PreferredEquipmentId' type='Sdk.Lookup'>Preferred Facility/Equipment : Choose the account's preferred service facility or equipment to make sure services are scheduled correctly for the customer.</field>
this.PreferredEquipmentId = {};
this.PreferredEquipmentId.setValue = function (value) {
///<summary><para>Sets the PreferredEquipmentId value</para>
/// <para>Display Name: Preferred Facility/Equipment</para>
/// <para>Targets: equipment</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Choose the account's preferred service facility or equipment to make sure services are scheduled correctly for the customer.</param>
 PreferredEquipmentId.setValue(value);
};
this.PreferredEquipmentId.getValue = function () {
 ///<summary>
 /// Gets the PreferredEquipmentId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Choose the account's preferred service facility or equipment to make sure services are scheduled correctly for the customer.</returns>
 return PreferredEquipmentId.getValue();
}
// PreferredEquipmentId END --------------------------------------------------------------


// PreferredServiceId START --------------------------------------------------------------
var PreferredServiceId = new Sdk.Lookup("preferredserviceid");
this.addAttribute(PreferredServiceId, false);
/// <field name='PreferredServiceId' type='Sdk.Lookup'>Preferred Service : Choose the account's preferred service for reference when you schedule service activities.</field>
this.PreferredServiceId = {};
this.PreferredServiceId.setValue = function (value) {
///<summary><para>Sets the PreferredServiceId value</para>
/// <para>Display Name: Preferred Service</para>
/// <para>Targets: service</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Choose the account's preferred service for reference when you schedule service activities.</param>
 PreferredServiceId.setValue(value);
};
this.PreferredServiceId.getValue = function () {
 ///<summary>
 /// Gets the PreferredServiceId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Choose the account's preferred service for reference when you schedule service activities.</returns>
 return PreferredServiceId.getValue();
}
// PreferredServiceId END --------------------------------------------------------------


// PreferredSystemUserId START --------------------------------------------------------------
var PreferredSystemUserId = new Sdk.Lookup("preferredsystemuserid");
this.addAttribute(PreferredSystemUserId, false);
/// <field name='PreferredSystemUserId' type='Sdk.Lookup'>Preferred User : Choose the preferred service representative for reference when you schedule service activities for the account.</field>
this.PreferredSystemUserId = {};
this.PreferredSystemUserId.setValue = function (value) {
///<summary><para>Sets the PreferredSystemUserId value</para>
/// <para>Display Name: Preferred User</para>
/// <para>Targets: systemuser</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Choose the preferred service representative for reference when you schedule service activities for the account.</param>
 PreferredSystemUserId.setValue(value);
};
this.PreferredSystemUserId.getValue = function () {
 ///<summary>
 /// Gets the PreferredSystemUserId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Choose the preferred service representative for reference when you schedule service activities for the account.</returns>
 return PreferredSystemUserId.getValue();
}
// PreferredSystemUserId END --------------------------------------------------------------


// PrimaryContactId START --------------------------------------------------------------
var PrimaryContactId = new Sdk.Lookup("primarycontactid");
this.addAttribute(PrimaryContactId, false);
/// <field name='PrimaryContactId' type='Sdk.Lookup'>Primary Contact : Choose the primary contact for the account to provide quick access to contact details.</field>
this.PrimaryContactId = {};
this.PrimaryContactId.setValue = function (value) {
///<summary><para>Sets the PrimaryContactId value</para>
/// <para>Display Name: Primary Contact</para>
/// <para>Targets: contact</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Choose the primary contact for the account to provide quick access to contact details.</param>
 PrimaryContactId.setValue(value);
};
this.PrimaryContactId.getValue = function () {
 ///<summary>
 /// Gets the PrimaryContactId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Choose the primary contact for the account to provide quick access to contact details.</returns>
 return PrimaryContactId.getValue();
}
// PrimaryContactId END --------------------------------------------------------------


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


// Revenue START --------------------------------------------------------------
var Revenue = new Sdk.Money("revenue");
this.addAttribute(Revenue, false);
/// <field name='Revenue' type='Sdk.Money'>Annual Revenue : Type the annual revenue for the account, used as an indicator in financial performance analysis.</field>
this.Revenue = {};
this.Revenue.setValue = function (value) {
 ///<summary>Sets the Revenue value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Annual Revenue : Type the annual revenue for the account, used as an indicator in financial performance analysis.</para>
 /// <para>MaxValue: 922337203685477</para>
 /// <para>MinValue: -922337203685477</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 Revenue.setValue(value);
};
this.Revenue.getValue = function () {
 ///<summary>
 /// Gets the Revenue value
 ///</summary>
 /// <returns type="Number">Type the annual revenue for the account, used as an indicator in financial performance analysis.</returns>
 return Revenue.getValue();
}
// Revenue END --------------------------------------------------------------


// Revenue_Base START --------------------------------------------------------------
var Revenue_Base = new Sdk.Money("revenue_base");
this.addAttribute(Revenue_Base, false);
/// <field name='Revenue_Base' type='Sdk.Money'>Annual Revenue (Base) : Shows the annual revenue converted to the system's default base currency. The calculations use the exchange rate specified in the Currencies area.</field>
this.Revenue_Base = {};
this.Revenue_Base.getValue = function () {
 ///<summary>
 /// Gets the Revenue_Base value
 ///</summary>
 /// <returns type="Number">Shows the annual revenue converted to the system's default base currency. The calculations use the exchange rate specified in the Currencies area.</returns>
 return Revenue_Base.getValue();
}
// Revenue_Base END --------------------------------------------------------------


// SharesOutstanding START --------------------------------------------------------------
var SharesOutstanding = new Sdk.Int("sharesoutstanding");
this.addAttribute(SharesOutstanding, false);
/// <field name='SharesOutstanding' type='Sdk.Int'>Shares Outstanding : Type the number of shares available to the public for the account. This number is used as an indicator in financial performance analysis.</field>
this.SharesOutstanding = {};
this.SharesOutstanding.setValue = function (value) {
 ///<summary>Sets the SharesOutstanding value</summary>
 /// <param name="value" type="Number" optional="false">
 /// <para>Shares Outstanding : Type the number of shares available to the public for the account. This number is used as an indicator in financial performance analysis.</para>
 /// <para>MaxValue: 2147483647</para>
 /// <para>MinValue: -2147483648</para>
 /// <para>RequiredLevel: None</para>
 /// </param>
 SharesOutstanding.setValue(value);
};
this.SharesOutstanding.getValue = function () {
 ///<summary>
 /// Gets the SharesOutstanding value
 ///</summary>
 /// <returns type="Number">Type the number of shares available to the public for the account. This number is used as an indicator in financial performance analysis.</returns>
 return SharesOutstanding.getValue();
}
// SharesOutstanding END --------------------------------------------------------------


// ShippingMethodCode START --------------------------------------------------------------
var ShippingMethodCode = new Sdk.OptionSet("shippingmethodcode");
  this.addAttribute(ShippingMethodCode, false);
  /// <field name='ShippingMethodCode' type='Sdk.OptionSet'>Shipping Method : Select a shipping method for deliveries sent to the account's address to designate the preferred carrier or other delivery option.</field>
  this.ShippingMethodCode = {};
 this.ShippingMethodCode.setValue = function (value) {
  ///<summary><para>Sets the ShippingMethodCode (Shipping Method) value</para>
   /// <para>Select a shipping method for deliveries sent to the account's address to designate the preferred carrier or other delivery option.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Default Value</para>
   /// </param>
   ShippingMethodCode.setValue(value);
  };
  this.ShippingMethodCode.getValue = function () {
   ///<summary>Gets the ShippingMethodCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select a shipping method for deliveries sent to the account's address to designate the preferred carrier or other delivery option.</returns>
   return ShippingMethodCode.getValue();
  }
// ShippingMethodCode END --------------------------------------------------------------


// SIC START --------------------------------------------------------------
  var SIC = new Sdk.String("sic");
  this.addAttribute(SIC, false);
  /// <field name='SIC' type='Sdk.String'>SIC Code : Type the Standard Industrial Classification (SIC) code that indicates the account's primary industry of business, for use in marketing segmentation and demographic analysis.</field>
this.SIC = {};
  this.SIC.setValue = function (value) {
   ///<summary>Sets the SIC value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>SIC Code : Type the Standard Industrial Classification (SIC) code that indicates the account's primary industry of business, for use in marketing segmentation and demographic analysis.</para>
   /// <para>MaxLength: 20</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   SIC.setValue(value);
  };
  this.SIC.getValue = function () {
   ///<summary>
   /// Gets the SIC value
   ///</summary>
   /// <returns type="String">Type the Standard Industrial Classification (SIC) code that indicates the account's primary industry of business, for use in marketing segmentation and demographic analysis.</returns>
   return SIC.getValue();
  }
// SIC END --------------------------------------------------------------


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
  /// <field name='StateCode' type='Sdk.OptionSet'>Status : Shows whether the account is active or inactive. Inactive accounts are read-only and can't be edited unless they are reactivated.</field>
  this.StateCode = {};
  this.StateCode.getValue = function () {
   ///<summary>Gets the StateCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Shows whether the account is active or inactive. Inactive accounts are read-only and can't be edited unless they are reactivated.</returns>
   return StateCode.getValue();
  }
// StateCode END --------------------------------------------------------------


// StatusCode START --------------------------------------------------------------
var StatusCode = new Sdk.OptionSet("statuscode");
  this.addAttribute(StatusCode, false);
  /// <field name='StatusCode' type='Sdk.OptionSet'>Status Reason : Select the account's status.</field>
  this.StatusCode = {};
 this.StatusCode.setValue = function (value) {
  ///<summary><para>Sets the StatusCode (Status Reason) value</para>
   /// <para>Select the account's status.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Active State 0</para>
/// <para> 2 : Inactive State 1</para>
   /// </param>
   StatusCode.setValue(value);
  };
  this.StatusCode.getValue = function () {
   ///<summary>Gets the StatusCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select the account's status.</returns>
   return StatusCode.getValue();
  }
// StatusCode END --------------------------------------------------------------


// StockExchange START --------------------------------------------------------------
  var StockExchange = new Sdk.String("stockexchange");
  this.addAttribute(StockExchange, false);
  /// <field name='StockExchange' type='Sdk.String'>Stock Exchange : Type the stock exchange at which the account is listed to track their stock and financial performance of the company.</field>
this.StockExchange = {};
  this.StockExchange.setValue = function (value) {
   ///<summary>Sets the StockExchange value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Stock Exchange : Type the stock exchange at which the account is listed to track their stock and financial performance of the company.</para>
   /// <para>MaxLength: 20</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   StockExchange.setValue(value);
  };
  this.StockExchange.getValue = function () {
   ///<summary>
   /// Gets the StockExchange value
   ///</summary>
   /// <returns type="String">Type the stock exchange at which the account is listed to track their stock and financial performance of the company.</returns>
   return StockExchange.getValue();
  }
// StockExchange END --------------------------------------------------------------


// Telephone1 START --------------------------------------------------------------
  var Telephone1 = new Sdk.String("telephone1");
  this.addAttribute(Telephone1, false);
  /// <field name='Telephone1' type='Sdk.String'>Main Phone : Type the main phone number for this account.</field>
this.Telephone1 = {};
  this.Telephone1.setValue = function (value) {
   ///<summary>Sets the Telephone1 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Main Phone : Type the main phone number for this account.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Telephone1.setValue(value);
  };
  this.Telephone1.getValue = function () {
   ///<summary>
   /// Gets the Telephone1 value
   ///</summary>
   /// <returns type="String">Type the main phone number for this account.</returns>
   return Telephone1.getValue();
  }
// Telephone1 END --------------------------------------------------------------


// Telephone2 START --------------------------------------------------------------
  var Telephone2 = new Sdk.String("telephone2");
  this.addAttribute(Telephone2, false);
  /// <field name='Telephone2' type='Sdk.String'>Other Phone : Type a second phone number for this account.</field>
this.Telephone2 = {};
  this.Telephone2.setValue = function (value) {
   ///<summary>Sets the Telephone2 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Other Phone : Type a second phone number for this account.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Telephone2.setValue(value);
  };
  this.Telephone2.getValue = function () {
   ///<summary>
   /// Gets the Telephone2 value
   ///</summary>
   /// <returns type="String">Type a second phone number for this account.</returns>
   return Telephone2.getValue();
  }
// Telephone2 END --------------------------------------------------------------


// Telephone3 START --------------------------------------------------------------
  var Telephone3 = new Sdk.String("telephone3");
  this.addAttribute(Telephone3, false);
  /// <field name='Telephone3' type='Sdk.String'>Telephone 3 : Type a third phone number for this account.</field>
this.Telephone3 = {};
  this.Telephone3.setValue = function (value) {
   ///<summary>Sets the Telephone3 value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Telephone 3 : Type a third phone number for this account.</para>
   /// <para>MaxLength: 50</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   Telephone3.setValue(value);
  };
  this.Telephone3.getValue = function () {
   ///<summary>
   /// Gets the Telephone3 value
   ///</summary>
   /// <returns type="String">Type a third phone number for this account.</returns>
   return Telephone3.getValue();
  }
// Telephone3 END --------------------------------------------------------------


// TerritoryCode START --------------------------------------------------------------
var TerritoryCode = new Sdk.OptionSet("territorycode");
  this.addAttribute(TerritoryCode, false);
  /// <field name='TerritoryCode' type='Sdk.OptionSet'>Territory Code : Select a region or territory for the account for use in segmentation and analysis.</field>
  this.TerritoryCode = {};
 this.TerritoryCode.setValue = function (value) {
  ///<summary><para>Sets the TerritoryCode (Territory Code) value</para>
   /// <para>Select a region or territory for the account for use in segmentation and analysis.</para>
   /// <para>RequiredLevel: None</para>
  ///</summary>
   /// <param name="value" type="Number" integer="true" mayBeNull="true" optional="false">
   /// <para>Options:</para>
/// <para> 1 : Default Value</para>
   /// </param>
   TerritoryCode.setValue(value);
  };
  this.TerritoryCode.getValue = function () {
   ///<summary>Gets the TerritoryCode value</summary>
 /// <returns type="Number" integer="true" mayBeNull="true">Select a region or territory for the account for use in segmentation and analysis.</returns>
   return TerritoryCode.getValue();
  }
// TerritoryCode END --------------------------------------------------------------


// TerritoryId START --------------------------------------------------------------
var TerritoryId = new Sdk.Lookup("territoryid");
this.addAttribute(TerritoryId, false);
/// <field name='TerritoryId' type='Sdk.Lookup'>Territory : Choose the sales region or territory for the account to make sure the account is assigned to the correct representative and for use in segmentation and analysis.</field>
this.TerritoryId = {};
this.TerritoryId.setValue = function (value) {
///<summary><para>Sets the TerritoryId value</para>
/// <para>Display Name: Territory</para>
/// <para>Targets: territory</para>
/// <para>RequiredLevel: None</para>
///</summary>
/// <param name="value" type="Sdk.EntityReference" optional="false">Choose the sales region or territory for the account to make sure the account is assigned to the correct representative and for use in segmentation and analysis.</param>
 TerritoryId.setValue(value);
};
this.TerritoryId.getValue = function () {
 ///<summary>
 /// Gets the TerritoryId value
 ///</summary>
 /// <returns type="Sdk.EntityReference">Choose the sales region or territory for the account to make sure the account is assigned to the correct representative and for use in segmentation and analysis.</returns>
 return TerritoryId.getValue();
}
// TerritoryId END --------------------------------------------------------------


// TickerSymbol START --------------------------------------------------------------
  var TickerSymbol = new Sdk.String("tickersymbol");
  this.addAttribute(TickerSymbol, false);
  /// <field name='TickerSymbol' type='Sdk.String'>Ticker Symbol : Type the stock exchange symbol for the account to track financial performance of the company. You can click the code entered in this field to access the latest trading information from MSN Money.</field>
this.TickerSymbol = {};
  this.TickerSymbol.setValue = function (value) {
   ///<summary>Sets the TickerSymbol value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Ticker Symbol : Type the stock exchange symbol for the account to track financial performance of the company. You can click the code entered in this field to access the latest trading information from MSN Money.</para>
   /// <para>MaxLength: 10</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   TickerSymbol.setValue(value);
  };
  this.TickerSymbol.getValue = function () {
   ///<summary>
   /// Gets the TickerSymbol value
   ///</summary>
   /// <returns type="String">Type the stock exchange symbol for the account to track financial performance of the company. You can click the code entered in this field to access the latest trading information from MSN Money.</returns>
   return TickerSymbol.getValue();
  }
// TickerSymbol END --------------------------------------------------------------


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
/// <field name='VersionNumber' type='Sdk.Long'>Version Number : Version number of the account.</field>
this.VersionNumber = {};
this.VersionNumber.getValue = function () {
 ///<summary>
 /// Gets the VersionNumber value
 ///</summary>
 /// <returns type="Number">Version number of the account.</returns>
 return VersionNumber.getValue();
}
// VersionNumber END --------------------------------------------------------------


// WebSiteURL START --------------------------------------------------------------
  var WebSiteURL = new Sdk.String("websiteurl");
  this.addAttribute(WebSiteURL, false);
  /// <field name='WebSiteURL' type='Sdk.String'>Website : Type the account's website URL to get quick details about the company profile.</field>
this.WebSiteURL = {};
  this.WebSiteURL.setValue = function (value) {
   ///<summary>Sets the WebSiteURL value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Website : Type the account's website URL to get quick details about the company profile.</para>
   /// <para>MaxLength: 200</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   WebSiteURL.setValue(value);
  };
  this.WebSiteURL.getValue = function () {
   ///<summary>
   /// Gets the WebSiteURL value
   ///</summary>
   /// <returns type="String">Type the account's website URL to get quick details about the company profile.</returns>
   return WebSiteURL.getValue();
  }
// WebSiteURL END --------------------------------------------------------------


// YomiName START --------------------------------------------------------------
  var YomiName = new Sdk.String("yominame");
  this.addAttribute(YomiName, false);
  /// <field name='YomiName' type='Sdk.String'>Yomi Account Name : Type the phonetic spelling of the company name, if specified in Japanese, to make sure the name is pronounced correctly in phone calls and other communications.</field>
this.YomiName = {};
  this.YomiName.setValue = function (value) {
   ///<summary>Sets the YomiName value</summary>
   /// <param name="value" type="String" optional="false">
   /// <para>Yomi Account Name : Type the phonetic spelling of the company name, if specified in Japanese, to make sure the name is pronounced correctly in phone calls and other communications.</para>
   /// <para>MaxLength: 160</para>
   /// <para>RequiredLevel: None</para>
   /// </param>
   YomiName.setValue(value);
  };
  this.YomiName.getValue = function () {
   ///<summary>
   /// Gets the YomiName value
   ///</summary>
   /// <returns type="String">Type the phonetic spelling of the company name, if specified in Japanese, to make sure the name is pronounced correctly in phone calls and other communications.</returns>
   return YomiName.getValue();
  }
// YomiName END --------------------------------------------------------------

 };
}).call(Sdk)
Sdk.Account.prototype = new Sdk.Entity("account");


(function () {
 this.OneToMany = function () {
  /// <summary>Properties represent the string values of One-to-Many relationships for Sdk.Account</summary>
  /// <field name="account_activity_parties" type="String" static="true"> Entity: activityparty  Attribute: partyid</field>
  /// <field name="Account_ActivityPointers" type="String" static="true"> Entity: activitypointer  Attribute: regardingobjectid</field>
  /// <field name="Account_Annotation" type="String" static="true"> Entity: annotation  Attribute: objectid</field>
  /// <field name="Account_Appointments" type="String" static="true"> Entity: appointment  Attribute: regardingobjectid</field>
  /// <field name="Account_AsyncOperations" type="String" static="true"> Entity: asyncoperation  Attribute: regardingobjectid</field>
  /// <field name="Account_BulkDeleteFailures" type="String" static="true"> Entity: bulkdeletefailure  Attribute: regardingobjectid</field>
  /// <field name="account_connections1" type="String" static="true"> Entity: connection  Attribute: record1id</field>
  /// <field name="account_connections2" type="String" static="true"> Entity: connection  Attribute: record2id</field>
  /// <field name="account_customer_opportunity_roles" type="String" static="true"> Entity: customeropportunityrole  Attribute: customerid</field>
  /// <field name="account_customer_relationship_customer" type="String" static="true"> Entity: customerrelationship  Attribute: customerid</field>
  /// <field name="account_customer_relationship_partner" type="String" static="true"> Entity: customerrelationship  Attribute: partnerid</field>
  /// <field name="Account_CustomerAddress" type="String" static="true"> Entity: customeraddress  Attribute: parentid</field>
  /// <field name="Account_DuplicateBaseRecord" type="String" static="true"> Entity: duplicaterecord  Attribute: baserecordid</field>
  /// <field name="Account_DuplicateMatchingRecord" type="String" static="true"> Entity: duplicaterecord  Attribute: duplicaterecordid</field>
  /// <field name="Account_Emails" type="String" static="true"> Entity: email  Attribute: regardingobjectid</field>
  /// <field name="Account_Faxes" type="String" static="true"> Entity: fax  Attribute: regardingobjectid</field>
  /// <field name="Account_Letters" type="String" static="true"> Entity: letter  Attribute: regardingobjectid</field>
  /// <field name="account_master_account" type="String" static="true"> Entity: account  Attribute: masterid</field>
  /// <field name="account_parent_account" type="String" static="true"> Entity: account  Attribute: parentaccountid</field>
  /// <field name="Account_Phonecalls" type="String" static="true"> Entity: phonecall  Attribute: regardingobjectid</field>
  /// <field name="account_PostFollows" type="String" static="true"> Entity: postfollow  Attribute: regardingobjectid</field>
  /// <field name="account_PostRegardings" type="String" static="true"> Entity: postregarding  Attribute: regardingobjectid</field>
  /// <field name="account_PostRoles" type="String" static="true"> Entity: postrole  Attribute: regardingobjectid</field>
  /// <field name="account_principalobjectattributeaccess" type="String" static="true"> Entity: principalobjectattributeaccess  Attribute: objectid</field>
  /// <field name="Account_ProcessSessions" type="String" static="true"> Entity: processsession  Attribute: regardingobjectid</field>
  /// <field name="Account_RecurringAppointmentMasters" type="String" static="true"> Entity: recurringappointmentmaster  Attribute: regardingobjectid</field>
  /// <field name="Account_ServiceAppointments" type="String" static="true"> Entity: serviceappointment  Attribute: regardingobjectid</field>
  /// <field name="Account_SharepointDocumentLocation" type="String" static="true"> Entity: sharepointdocumentlocation  Attribute: regardingobjectid</field>
  /// <field name="Account_Tasks" type="String" static="true"> Entity: task  Attribute: regardingobjectid</field>
  /// <field name="contact_customer_accounts" type="String" static="true"> Entity: contact  Attribute: parentcustomerid</field>
  /// <field name="contract_billingcustomer_accounts" type="String" static="true"> Entity: contract  Attribute: billingcustomerid</field>
  /// <field name="contract_customer_accounts" type="String" static="true"> Entity: contract  Attribute: customerid</field>
  /// <field name="contractlineitem_customer_accounts" type="String" static="true"> Entity: contractdetail  Attribute: customerid</field>
  /// <field name="CreatedAccount_BulkOperationLogs2" type="String" static="true"> Entity: bulkoperationlog  Attribute: createdobjectid</field>
  /// <field name="incident_customer_accounts" type="String" static="true"> Entity: incident  Attribute: customerid</field>
  /// <field name="invoice_customer_accounts" type="String" static="true"> Entity: invoice  Attribute: customerid</field>
  /// <field name="lead_customer_accounts" type="String" static="true"> Entity: lead  Attribute: customerid</field>
  /// <field name="lead_parent_account" type="String" static="true"> Entity: lead  Attribute: parentaccountid</field>
  /// <field name="opportunity_customer_accounts" type="String" static="true"> Entity: opportunity  Attribute: customerid</field>
  /// <field name="opportunity_parent_account" type="String" static="true"> Entity: opportunity  Attribute: parentaccountid</field>
  /// <field name="order_customer_accounts" type="String" static="true"> Entity: salesorder  Attribute: customerid</field>
  /// <field name="quote_customer_accounts" type="String" static="true"> Entity: quote  Attribute: customerid</field>
  /// <field name="SourceAccount_BulkOperationLogs" type="String" static="true"> Entity: bulkoperationlog  Attribute: regardingobjectid</field>
  /// <field name="userentityinstancedata_account" type="String" static="true"> Entity: userentityinstancedata  Attribute: objectid</field>
  throw new Error("Constructor not implemented this is a static enum.");
}
 this.OneToMany.__enum = true;
 this.OneToMany.__flags = true;
}).call(Sdk.Account);

Sdk.Account.OneToMany.prototype = {
 account_activity_parties: "account_activity_parties",
 Account_ActivityPointers: "Account_ActivityPointers",
 Account_Annotation: "Account_Annotation",
 Account_Appointments: "Account_Appointments",
 Account_AsyncOperations: "Account_AsyncOperations",
 Account_BulkDeleteFailures: "Account_BulkDeleteFailures",
 account_connections1: "account_connections1",
 account_connections2: "account_connections2",
 account_customer_opportunity_roles: "account_customer_opportunity_roles",
 account_customer_relationship_customer: "account_customer_relationship_customer",
 account_customer_relationship_partner: "account_customer_relationship_partner",
 Account_CustomerAddress: "Account_CustomerAddress",
 Account_DuplicateBaseRecord: "Account_DuplicateBaseRecord",
 Account_DuplicateMatchingRecord: "Account_DuplicateMatchingRecord",
 Account_Emails: "Account_Emails",
 Account_Faxes: "Account_Faxes",
 Account_Letters: "Account_Letters",
 account_master_account: "account_master_account",
 account_parent_account: "account_parent_account",
 Account_Phonecalls: "Account_Phonecalls",
 account_PostFollows: "account_PostFollows",
 account_PostRegardings: "account_PostRegardings",
 account_PostRoles: "account_PostRoles",
 account_principalobjectattributeaccess: "account_principalobjectattributeaccess",
 Account_ProcessSessions: "Account_ProcessSessions",
 Account_RecurringAppointmentMasters: "Account_RecurringAppointmentMasters",
 Account_ServiceAppointments: "Account_ServiceAppointments",
 Account_SharepointDocumentLocation: "Account_SharepointDocumentLocation",
 Account_Tasks: "Account_Tasks",
 contact_customer_accounts: "contact_customer_accounts",
 contract_billingcustomer_accounts: "contract_billingcustomer_accounts",
 contract_customer_accounts: "contract_customer_accounts",
 contractlineitem_customer_accounts: "contractlineitem_customer_accounts",
 CreatedAccount_BulkOperationLogs2: "CreatedAccount_BulkOperationLogs2",
 incident_customer_accounts: "incident_customer_accounts",
 invoice_customer_accounts: "invoice_customer_accounts",
 lead_customer_accounts: "lead_customer_accounts",
 lead_parent_account: "lead_parent_account",
 opportunity_customer_accounts: "opportunity_customer_accounts",
 opportunity_parent_account: "opportunity_parent_account",
 order_customer_accounts: "order_customer_accounts",
 quote_customer_accounts: "quote_customer_accounts",
 SourceAccount_BulkOperationLogs: "SourceAccount_BulkOperationLogs",
 userentityinstancedata_account: "userentityinstancedata_account"};

Sdk.Account.OneToMany.account_activity_parties = "account_activity_parties";
Sdk.Account.OneToMany.Account_ActivityPointers = "Account_ActivityPointers";
Sdk.Account.OneToMany.Account_Annotation = "Account_Annotation";
Sdk.Account.OneToMany.Account_Appointments = "Account_Appointments";
Sdk.Account.OneToMany.Account_AsyncOperations = "Account_AsyncOperations";
Sdk.Account.OneToMany.Account_BulkDeleteFailures = "Account_BulkDeleteFailures";
Sdk.Account.OneToMany.account_connections1 = "account_connections1";
Sdk.Account.OneToMany.account_connections2 = "account_connections2";
Sdk.Account.OneToMany.account_customer_opportunity_roles = "account_customer_opportunity_roles";
Sdk.Account.OneToMany.account_customer_relationship_customer = "account_customer_relationship_customer";
Sdk.Account.OneToMany.account_customer_relationship_partner = "account_customer_relationship_partner";
Sdk.Account.OneToMany.Account_CustomerAddress = "Account_CustomerAddress";
Sdk.Account.OneToMany.Account_DuplicateBaseRecord = "Account_DuplicateBaseRecord";
Sdk.Account.OneToMany.Account_DuplicateMatchingRecord = "Account_DuplicateMatchingRecord";
Sdk.Account.OneToMany.Account_Emails = "Account_Emails";
Sdk.Account.OneToMany.Account_Faxes = "Account_Faxes";
Sdk.Account.OneToMany.Account_Letters = "Account_Letters";
Sdk.Account.OneToMany.account_master_account = "account_master_account";
Sdk.Account.OneToMany.account_parent_account = "account_parent_account";
Sdk.Account.OneToMany.Account_Phonecalls = "Account_Phonecalls";
Sdk.Account.OneToMany.account_PostFollows = "account_PostFollows";
Sdk.Account.OneToMany.account_PostRegardings = "account_PostRegardings";
Sdk.Account.OneToMany.account_PostRoles = "account_PostRoles";
Sdk.Account.OneToMany.account_principalobjectattributeaccess = "account_principalobjectattributeaccess";
Sdk.Account.OneToMany.Account_ProcessSessions = "Account_ProcessSessions";
Sdk.Account.OneToMany.Account_RecurringAppointmentMasters = "Account_RecurringAppointmentMasters";
Sdk.Account.OneToMany.Account_ServiceAppointments = "Account_ServiceAppointments";
Sdk.Account.OneToMany.Account_SharepointDocumentLocation = "Account_SharepointDocumentLocation";
Sdk.Account.OneToMany.Account_Tasks = "Account_Tasks";
Sdk.Account.OneToMany.contact_customer_accounts = "contact_customer_accounts";
Sdk.Account.OneToMany.contract_billingcustomer_accounts = "contract_billingcustomer_accounts";
Sdk.Account.OneToMany.contract_customer_accounts = "contract_customer_accounts";
Sdk.Account.OneToMany.contractlineitem_customer_accounts = "contractlineitem_customer_accounts";
Sdk.Account.OneToMany.CreatedAccount_BulkOperationLogs2 = "CreatedAccount_BulkOperationLogs2";
Sdk.Account.OneToMany.incident_customer_accounts = "incident_customer_accounts";
Sdk.Account.OneToMany.invoice_customer_accounts = "invoice_customer_accounts";
Sdk.Account.OneToMany.lead_customer_accounts = "lead_customer_accounts";
Sdk.Account.OneToMany.lead_parent_account = "lead_parent_account";
Sdk.Account.OneToMany.opportunity_customer_accounts = "opportunity_customer_accounts";
Sdk.Account.OneToMany.opportunity_parent_account = "opportunity_parent_account";
Sdk.Account.OneToMany.order_customer_accounts = "order_customer_accounts";
Sdk.Account.OneToMany.quote_customer_accounts = "quote_customer_accounts";
Sdk.Account.OneToMany.SourceAccount_BulkOperationLogs = "SourceAccount_BulkOperationLogs";
Sdk.Account.OneToMany.userentityinstancedata_account = "userentityinstancedata_account";
Sdk.Account.OneToMany.__enum = true;
Sdk.Account.OneToMany.__flags = true;
