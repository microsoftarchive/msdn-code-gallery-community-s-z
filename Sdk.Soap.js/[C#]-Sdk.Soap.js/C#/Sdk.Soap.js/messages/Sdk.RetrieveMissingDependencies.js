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
 this.RetrieveMissingDependenciesRequest = function (solutionUniqueName) {
  ///<summary>
  /// Contains the data that is needed to  retrieve any required solution components that are not included in the solution. 
  ///</summary>
  ///<param name="solutionUniqueName"  type="String">
  /// Sets the name of the solution. Required.
  ///</param>
  if (!(this instanceof Sdk.RetrieveMissingDependenciesRequest)) {
   return new Sdk.RetrieveMissingDependenciesRequest(solutionUniqueName);
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
    throw new Error("Sdk.RetrieveMissingDependenciesRequest SolutionUniqueName property is required and must be a String.")
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
           "<a:RequestName>RetrieveMissingDependencies</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.RetrieveMissingDependenciesResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setSolutionUniqueName = function (value) {
   ///<summary>
   /// Sets the name of the solution. Required.
   ///</summary>
   ///<param name="value" type="String">
   /// The name of the solution.
   ///</param>
   _setValidSolutionUniqueName(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.RetrieveMissingDependenciesRequest.__class = true;

 this.RetrieveMissingDependenciesResponse = function (responseXml) {
  ///<summary>
  /// Response to RetrieveMissingDependenciesRequest
  ///</summary>
  if (!(this instanceof Sdk.RetrieveMissingDependenciesResponse)) {
   return new Sdk.RetrieveMissingDependenciesResponse(responseXml);
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
   /// Gets an entity collection that represents the solution components that the solution requires in the target system.
   ///</summary>
   ///<returns type="Sdk.EntityCollection">
   /// An entity collection that represents the solution components that the solution requires in the target system.
   ///</returns>
   return _entityCollection;
  }

  //Set property values from responseXml constructor parameter
  _setEntityCollection(responseXml);
 }
 this.RetrieveMissingDependenciesResponse.__class = true;
}).call(Sdk)

Sdk.RetrieveMissingDependenciesRequest.prototype = new Sdk.OrganizationRequest();
Sdk.RetrieveMissingDependenciesResponse.prototype = new Sdk.OrganizationResponse();
