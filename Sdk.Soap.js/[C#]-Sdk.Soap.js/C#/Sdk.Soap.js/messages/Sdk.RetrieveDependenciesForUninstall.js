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
 this.RetrieveDependenciesForUninstallRequest = function (solutionUniqueName) {
  ///<summary>
  /// Contains the data that is needed to  retrieve a list of the solution component dependencies that can prevent you from uninstalling a managed solution. 
  ///</summary>
  ///<param name="solutionUniqueName"  type="String">
  /// Sets the name of the managed solution. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveDependenciesForUninstallRequest)) {
   return new Sdk.RetrieveDependenciesForUninstallRequest(solutionUniqueName);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _solutionUniqueName = null;

  // internal validation functions

  function _setValidSolutionUniqueName(value) {
   if (typeof value == "string") {
    _solutionUniqueName = value;
   }
   else {
    throw new Error("Sdk.RetrieveDependenciesForUninstallRequest SolutionUniqueName property is required and must be a String.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof solutionUniqueName != "undefined") {
   _setValidSolutionUniqueName(solutionUniqueName);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>SolutionUniqueName</b:key>",
              (_solutionUniqueName == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"c:string\">", _solutionUniqueName, "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>RetrieveDependenciesForUninstall</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveDependenciesForUninstallResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setSolutionUniqueName = function (value) {
   ///<summary>
   /// Sets the name of the managed solution. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The name of the managed solution.
   ///</param>
   _setValidSolutionUniqueName(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveDependenciesForUninstallRequest.__class = true;

 this.RetrieveDependenciesForUninstallResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveDependenciesForUninstallRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveDependenciesForUninstallResponse)) {
   return new Sdk.RetrieveDependenciesForUninstallResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _entityCollection = null;

  // Internal property setter functions

  function _setEntityCollection(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='EntityCollection']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _entityCollection = Sdk.Util.createEntityCollectionFromNode(valueNode);
   }
  }
  //Public Methods to retrieve properties
  this.getEntityCollection = function () {
   ///<summary>
   /// Gets a collection of Dependency records where the DependentComponentObjectId and DependentComponentType attributes represent the components that can prevent you from deleting the solution.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// A collection of Dependency records where the DependentComponentObjectId and DependentComponentType attributes represent the components that can prevent you from deleting the solution.
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.RetrieveDependenciesForUninstallResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveDependenciesForUninstallRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveDependenciesForUninstallResponse.prototype = new Sdk.OrganizationResponse();
