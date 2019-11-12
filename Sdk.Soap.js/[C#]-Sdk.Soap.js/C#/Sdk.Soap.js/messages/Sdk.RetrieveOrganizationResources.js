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
 this.RetrieveOrganizationResourcesRequest = function () {
  ///<summary>
  /// Contains the data that is needed to retrieve the resources that are used by an organization. 
  ///</summary>
  if (!(this instanceof Sdk.RetrieveOrganizationResourcesRequest)) {
   return new Sdk.RetrieveOrganizationResourcesRequest();
  }
  Sdk.OrganizationRequest.call(this);

  // This message has no parameters

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters />",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveOrganizationResources</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveOrganizationResourcesResponse);
  this.setRequestXml(getRequestXml());


 }
 this.RetrieveOrganizationResourcesRequest.__class = true;

 this.RetrieveOrganizationResourcesResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveOrganizationResourcesRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveOrganizationResourcesResponse)) {
   return new Sdk.RetrieveOrganizationResourcesResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _organizationResources = null;

  // Internal property setter functions

  function _setOrganizationResources(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='OrganizationResources']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _organizationResources = new Sdk.OrganizationResources();
    _organizationResources.setCurrentNumberOfActiveUsers(parseInt(Sdk.Xml.selectSingleNodeText(valueNode, "g:CurrentNumberOfActiveUsers"), 10));
    _organizationResources.setCurrentNumberOfCustomEntities(parseInt(Sdk.Xml.selectSingleNodeText(valueNode, "g:CurrentNumberOfCustomEntities"), 10));
    _organizationResources.setCurrentNumberOfNonInteractiveUsers(parseInt(Sdk.Xml.selectSingleNodeText(valueNode, "g:CurrentNumberOfNonInteractiveUsers"), 10));
    _organizationResources.setCurrentNumberOfPublishedWorkflows(parseInt(Sdk.Xml.selectSingleNodeText(valueNode, "g:CurrentNumberOfPublishedWorkflows"), 10));
    _organizationResources.setCurrentStorage(parseInt(Sdk.Xml.selectSingleNodeText(valueNode, "g:CurrentStorage"), 10));
    _organizationResources.setMaxNumberOfActiveUsers(parseInt(Sdk.Xml.selectSingleNodeText(valueNode, "g:MaxNumberOfActiveUsers"), 10));
    _organizationResources.setMaxNumberOfCustomEntities(parseInt(Sdk.Xml.selectSingleNodeText(valueNode, "g:MaxNumberOfCustomEntities"), 10));
    _organizationResources.setMaxNumberOfNonInteractiveUsers(parseInt(Sdk.Xml.selectSingleNodeText(valueNode, "g:MaxNumberOfNonInteractiveUsers"), 10));
    _organizationResources.setMaxNumberOfPublishedWorkflows(parseInt(Sdk.Xml.selectSingleNodeText(valueNode, "g:MaxNumberOfPublishedWorkflows"), 10));
    _organizationResources.setMaxStorage(parseInt(Sdk.Xml.selectSingleNodeText(valueNode, "g:MaxStorage"), 10));
   }
  }
  //Public Methods to retrieve properties
  this.getOrganizationResources = function () {
   ///<summary>
   /// Gets the data that describes the resources used by an organization. 
   ///</summary>
   ///<returns type="Sdk.OrganizationResources">
   /// The data that describes the resources used by an organization. 
   ///</returns>
   return _organizationResources;
  }

  //Set property values from responseXml constructor parameter
  _setOrganizationResources(responseXml);
 }
 this.RetrieveOrganizationResourcesResponse.__class = true;

 this.OrganizationResources = function () {
  var _currentNumberOfActiveUsers = null;
  var _currentNumberOfCustomEntities = null;
  var _currentNumberOfNonInteractiveUsers = null;
  var _currentNumberOfPublishedWorkflows = null;
  var _currentStorage = null;
  var _maxNumberOfActiveUsers = null;
  var _maxNumberOfCustomEntities = null;
  var _maxNumberOfNonInteractiveUsers = null;
  var _maxNumberOfPublishedWorkflows = null;
  var _maxStorage = null;

  function _setValidCurrentNumberOfActiveUsers(value) {
   if (typeof value == "number") {
    _currentNumberOfActiveUsers = value;
   }
   else {
    throw new Error("Sdk.OrganizationResources CurrentNumberOfActiveUsers property must be a Number.")
   }
  }
  function _setValidCurrentNumberOfCustomEntities(value) {
   if (typeof value == "number") {
    _currentNumberOfCustomEntities = value;
   }
   else {
    throw new Error("Sdk.OrganizationResources CurrentNumberOfCustomEntities property must be a Number.")
   }
  }
  function _setValidCurrentNumberOfNonInteractiveUsers(value) {
   if (typeof value == "number") {
    _currentNumberOfNonInteractiveUsers = value;
   }
   else {
    throw new Error("Sdk.OrganizationResources CurrentNumberOfNonInteractiveUsers property must be a Number.")
   }
  }
  function _setValidCurrentNumberOfPublishedWorkflows(value) {
   if (typeof value == "number") {
    _currentNumberOfPublishedWorkflows = value;
   }
   else {
    throw new Error("Sdk.OrganizationResources CurrentNumberOfPublishedWorkflows property must be a Number.")
   }
  }
  function _setValidCurrentStorage(value) {
   if (typeof value == "number") {
    _currentStorage = value;
   }
   else {
    throw new Error("Sdk.OrganizationResources CurrentStorage property must be a Number.")
   }
  }
  function _setValidMaxNumberOfActiveUsers(value) {
   if (typeof value == "number") {
    _maxNumberOfActiveUsers = value;
   }
   else {
    throw new Error("Sdk.OrganizationResources MaxNumberOfActiveUsers property must be a Number.")
   }
  }
  function _setValidMaxNumberOfCustomEntities(value) {
   if (typeof value == "number") {
    _maxNumberOfCustomEntities = value;
   }
   else {
    throw new Error("Sdk.OrganizationResources MaxNumberOfCustomEntities property must be a Number.")
   }
  }
  function _setValidMaxNumberOfNonInteractiveUsers(value) {
   if (typeof value == "number") {
    _maxNumberOfNonInteractiveUsers = value;
   }
   else {
    throw new Error("Sdk.OrganizationResources MaxNumberOfNonInteractiveUsers property must be a Number.")
   }
  }
  function _setValidMaxNumberOfPublishedWorkflows(value) {
   if (typeof value == "number") {
    _maxNumberOfPublishedWorkflows = value;
   }
   else {
    throw new Error("Sdk.OrganizationResources MaxNumberOfPublishedWorkflows property must be a Number.")
   }
  }
  function _setValidMaxStorage(value) {
   if (typeof value == "number") {
    _maxStorage = value;
   }
   else {
    throw new Error("Sdk.OrganizationResources MaxStorage property must be a Number.")
   }
  }

  this.getCurrentNumberOfActiveUsers = function () {
   ///<summary>
   /// Gets the current number of active users.
   ///</summary>
   ///<returns type="Number">
   /// The current number of active users.
   ///</returns>
   return _currentNumberOfActiveUsers;
  };
  this.getCurrentNumberOfCustomEntities = function () {
   ///<summary>
   /// Gets the current number of custom entities.
   ///</summary>
   ///<returns type="Number">
   /// The current number of custom entities.
   ///</returns>
   return _currentNumberOfCustomEntities;
  };
  this.getCurrentNumberOfNonInteractiveUsers = function () {
   ///<summary>
   /// Gets the current number of non-interactive users.
   ///</summary>
   ///<returns type="Number">
   /// The current number of non-interactive users.
   ///</returns>
   return _currentNumberOfNonInteractiveUsers;
  };
  this.getCurrentNumberOfPublishedWorkflows = function () {
   ///<summary>
   /// Gets the current number of published workflows.
   ///</summary>
   ///<returns type="Number">
   /// The current number of published workflows
   ///</returns>
   return _currentNumberOfPublishedWorkflows;
  };
  this.getCurrentStorage = function () {
   ///<summary>
   /// Gets the current storage used by the organization.
   ///</summary>
   ///<returns type="Number">
   /// The current storage used by the organization.
   ///</returns>
   return _currentStorage;
  };
  this.getMaxNumberOfActiveUsers = function () {
   ///<summary>
   /// Gets the maximum number of active users.
   ///</summary>
   ///<returns type="Number">
   /// The maximum number of active users.
   ///</returns>
   return _maxNumberOfActiveUsers;
  };
  this.getMaxNumberOfCustomEntities = function () {
   ///<summary>
   /// Gets the maximum number of custom entities.
   ///</summary>
   ///<returns type="Number">
   /// The maximum number of custom entities.
   ///</returns>
   return _maxNumberOfCustomEntities;
  };
  this.getMaxNumberOfNonInteractiveUsers = function () {
   ///<summary>
   /// Gets the maximum number of non-interactive users.
   ///</summary>
   ///<returns type="Number">
   /// The maximum number of non-interactive users.
   ///</returns>
   return _maxNumberOfNonInteractiveUsers;
  };
  this.getMaxNumberOfPublishedWorkflows = function () {
   ///<summary>
   /// Gets the maximum number of published workflows.
   ///</summary>
   ///<returns type="Number">
   /// The maximum number of published workflows.
   ///</returns>
   return _maxNumberOfPublishedWorkflows;
  };
  this.getMaxStorage = function () {
   ///<summary>
   /// Gets the maximum storage allowed for the organization.
   ///</summary>
   ///<returns type="Number">
   /// The maximum storage allowed for the organization.
   ///</returns>
   return _maxStorage;
  };

  this.setCurrentNumberOfActiveUsers = function (currentNumberOfActiveUsers) {
   ///<summary>
   /// For internal use only
   ///</summary>
   _setValidCurrentNumberOfActiveUsers(currentNumberOfActiveUsers);
  }
  this.setCurrentNumberOfCustomEntities = function (currentNumberOfCustomEntities) {
   ///<summary>
   /// For internal use only
   ///</summary>
   _setValidCurrentNumberOfCustomEntities(currentNumberOfCustomEntities);
  }
  this.setCurrentNumberOfNonInteractiveUsers = function (currentNumberOfNonInteractiveUsers) {
   ///<summary>
   /// For internal use only
   ///</summary>
   _setValidCurrentNumberOfNonInteractiveUsers(currentNumberOfNonInteractiveUsers);
  }
  this.setCurrentNumberOfPublishedWorkflows = function (currentNumberOfPublishedWorkflows) {
   ///<summary>
   /// For internal use only
   ///</summary>
   _setValidCurrentNumberOfPublishedWorkflows(currentNumberOfPublishedWorkflows);
  }
  this.setCurrentStorage = function (currentStorage) {
   ///<summary>
   /// For internal use only
   ///</summary>
   _setValidCurrentStorage(currentStorage);
  }
  this.setMaxNumberOfActiveUsers = function (maxNumberOfActiveUsers) {
   ///<summary>
   /// For internal use only
   ///</summary>
   _setValidMaxNumberOfActiveUsers(maxNumberOfActiveUsers);
  }
  this.setMaxNumberOfCustomEntities = function (maxNumberOfCustomEntities) {
   ///<summary>
   /// For internal use only
   ///</summary>
   _setValidMaxNumberOfCustomEntities(maxNumberOfCustomEntities);
  }
  this.setMaxNumberOfNonInteractiveUsers = function (maxNumberOfNonInteractiveUsers) {
   ///<summary>
   /// For internal use only
   ///</summary>
   _setValidMaxNumberOfNonInteractiveUsers(maxNumberOfNonInteractiveUsers);
  }
  this.setMaxNumberOfPublishedWorkflows = function (maxNumberOfPublishedWorkflows) {
   ///<summary>
   /// For internal use only
   ///</summary>
   _setValidMaxNumberOfPublishedWorkflows(maxNumberOfPublishedWorkflows);
  }
  this.setMaxStorage = function (maxStorage) {
   ///<summary>
   /// For internal use only
   ///</summary>
   _setValidMaxStorage(maxStorage);
  }


 }

}).call(Sdk)

Sdk.RetrieveOrganizationResourcesRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveOrganizationResourcesResponse.prototype = new Sdk.OrganizationResponse();
Sdk.OrganizationResources.prototype.view = function () {
 var rv = {}
 rv.CurrentNumberOfActiveUsers = this.getCurrentNumberOfActiveUsers();
 rv.CurrentNumberOfCustomEntities = this.getCurrentNumberOfCustomEntities();
 rv.CurrentNumberOfNonInteractiveUsers = this.getCurrentNumberOfNonInteractiveUsers();
 rv.CurrentNumberOfPublishedWorkflows = this.getCurrentNumberOfPublishedWorkflows();
 rv.CurrentStorage = this.getCurrentStorage();
 rv.MaxNumberOfActiveUsers = this.getMaxNumberOfActiveUsers();
 rv.MaxNumberOfCustomEntities = this.getMaxNumberOfCustomEntities();
 rv.MaxNumberOfNonInteractiveUsers = this.getMaxNumberOfNonInteractiveUsers();
 rv.MaxNumberOfPublishedWorkflows = this.getMaxNumberOfPublishedWorkflows();
 rv.MaxStorage = this.getMaxStorage();
 return rv;
}
