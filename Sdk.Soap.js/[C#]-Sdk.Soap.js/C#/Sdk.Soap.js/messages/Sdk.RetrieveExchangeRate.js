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
(function ()
{
 this.RetrieveExchangeRateRequest = function (transactionCurrencyId) {
  ///<summary>
  /// Contains the data that is needed to  retrieve the exchange rate.
  ///</summary>
  ///<param name="transactionCurrencyId"  type="String">
  /// Sets the ID of the currency. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveExchangeRateRequest)) {
   return new Sdk.RetrieveExchangeRateRequest(transactionCurrencyId);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _transactionCurrencyId = null;

  // internal validation functions

  function _setValidTransactionCurrencyId(value) {
   if (Sdk.Util.isGuid(value)) {
    _transactionCurrencyId = value;
   }
   else {
    throw new Error("Sdk.RetrieveExchangeRateRequest TransactionCurrencyId property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof transactionCurrencyId != "undefined") {
   _setValidTransactionCurrencyId(transactionCurrencyId);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>TransactionCurrencyId</b:key>",
              (_transactionCurrencyId == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"e:guid\">", _transactionCurrencyId, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveExchangeRate</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveExchangeRateResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setTransactionCurrencyId = function (value) {
   ///<summary>
   /// Sets the ID of the currency. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The ID of the currency.
   ///</param>
   _setValidTransactionCurrencyId(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveExchangeRateRequest.__class = true;

 this.RetrieveExchangeRateResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveExchangeRateRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveExchangeRateResponse)) {
   return new Sdk.RetrieveExchangeRateResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _exchangeRate = null;

  // Internal property setter functions

  function _setExchangeRate(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='ExchangeRate']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _exchangeRate = parseFloat(Sdk.Xml.getNodeText(valueNode));
   }
  }
  //Public Methods to retrieve properties
  this.getExchangeRate = function () {
   ///<summary>
   /// Gets the exchange rate for the currency.
   ///</summary>
   ///<returns type="Number">
   /// The exchange rate for the currency.
   ///</returns>
   return _exchangeRate;
  }

  //Set property values from responseXml constructor parameter
  _setExchangeRate(responseXml);
 }
 this.RetrieveExchangeRateResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveExchangeRateRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveExchangeRateResponse.prototype = new Sdk.OrganizationResponse();
