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
(function () {
 this.SearchRequest = function (appointmentRequest)
 {
  ///<summary>
  /// Contains the data needed to search for available time slots that fulfill the specified appointment request. 
  ///</summary>
  ///<param name="appointmentRequest"  type="Sdk.AppointmentRequest">
  /// Sets the appointment request. 
  ///</param>
  if (!(this instanceof Sdk.SearchRequest)) {
   return new Sdk.SearchRequest(appointmentRequest);
  }
  Sdk.OrganizationRequest.call(this);

  // Internal properties
  var _appointmentRequest = null;

  // internal validation functions

  function _setValidAppointmentRequest(value) {
   if (value instanceof Sdk.AppointmentRequest) {
    _appointmentRequest = value;
   }
   else {
    throw new Error("Sdk.SearchRequest AppointmentRequest property is required and must be a Sdk.AppointmentRequest.")
   }
  }

  //Set internal properties from constructor parameters
  if (typeof appointmentRequest != "undefined") {
   _setValidAppointmentRequest(appointmentRequest);
  }

  function getRequestXml() {
   return ["<d:request>",
           "<a:Parameters>",

             "<a:KeyValuePairOfstringanyType>",
               "<b:key>AppointmentRequest</b:key>",
              (_appointmentRequest == null) ? "<b:value i:nil=\"true\" />" :
              ["<b:value i:type=\"g:AppointmentRequest\">", _appointmentRequest.toValueXml(), "</b:value>"].join(""),
             "</a:KeyValuePairOfstringanyType>",

           "</a:Parameters>",
           "<a:RequestId i:nil=\"true\" />",
           "<a:RequestName>Search</a:RequestName>",
         "</d:request>"].join("");
  }

  this.setResponseType(Sdk.SearchResponse);
  this.setRequestXml(getRequestXml());

  // Public methods to set properties
  this.setAppointmentRequest = function (value) {
   ///<summary>
   /// Sets the appointment request. 
   ///</summary>
   ///<param name="value" type="Sdk.AppointmentRequest">
   /// The appointment request. 
   ///</param>
   _setValidAppointmentRequest(value);
   this.setRequestXml(getRequestXml());
  }

 }
 this.SearchRequest.__class = true;

 this.SearchResponse = function (responseXml) {
  ///<summary>
  /// Response to SearchRequest
  ///</summary>
  if (!(this instanceof Sdk.SearchResponse)) {
   return new Sdk.SearchResponse(responseXml);
  }
  Sdk.OrganizationResponse.call(this)

  // Internal properties
  var _searchResults = null;

  // Internal property setter functions

  function _setSearchResults(xml) {
   var valueNode = Sdk.Xml.selectSingleNode(xml, "//a:KeyValuePairOfstringanyType[b:key='SearchResults']/b:value");
   if (!Sdk.Xml.isNodeNull(valueNode)) {
    _searchResults = createSearchResultsFromNode(valueNode);
   }
  }

  function createSearchResultsFromNode(node){
   var results = new Sdk.SearchResults();

   var proposals = new Sdk.Collection(Sdk.AppointmentProposal);
   var proposalsNode = Sdk.Xml.selectSingleNode(node, "g:Proposals");
   for (var i = 0; i < proposalsNode.childNodes.length; i++) {
    proposals.add(createAppointmentProposalFromNode(proposalsNode.childNodes[i]));
   }

   results.setProposals(proposals);

   results.setTraceInfo(Sdk.Util.createTraceInfoFromNode(node));
   return results;
  }

  function createAppointmentProposalFromNode(node) {
   var rv = new Sdk.AppointmentProposal();
   var endDate = null;
   var endNode = Sdk.Xml.selectSingleNode(node, "g:End");
   if (!Sdk.Xml.isNodeNull(endNode))
   {
    endDate = new Date(Sdk.Xml.getNodeText(endNode));    
   }
   rv.setEnd(endDate);

   var pp = new Sdk.Collection(Sdk.ProposalParty);
   var ppNode = Sdk.Xml.selectSingleNode(node, "g:ProposalParties");
   for (var i = 0; i < ppNode.childNodes.length; i++) {
    pp.add(createProposalPartyFromNode(ppNode.childNodes[i]));
   }
   rv.setProposalParties(pp);

   rv.setSiteId(Sdk.Xml.selectSingleNodeText(node, "g:SiteId"));

   
   var siteNameNode = Sdk.Xml.selectSingleNode(node, "g:SiteName")
   if (!Sdk.Xml.isNodeNull(siteNameNode))
   {
    var siteName = Sdk.Xml.getNodeText(siteNameNode);
    if (siteName.length > 0)
    {
     rv.setSiteName(siteName);
    }
    
   }

   var startDate = null;
   var startNode = Sdk.Xml.selectSingleNode(node, "g:Start");
   if (!Sdk.Xml.isNodeNull(startNode)) {
    startDate = new Date(Sdk.Xml.getNodeText(startNode));
   }
   rv.setStart(startDate);
   return rv;
  }

  function createProposalPartyFromNode(node) {
   var rv = new Sdk.ProposalParty();
   rv.setDisplayName(Sdk.Xml.selectSingleNodeText(node, "g:DisplayName"));
   rv.setEffortRequired(parseInt(Sdk.Xml.selectSingleNodeText(node, "g:EffortRequired"),10));

   rv.setEntityName(Sdk.Xml.selectSingleNodeText(node, "g:EntityName"));
   rv.setResourceId(Sdk.Xml.selectSingleNodeText(node, "g:ResourceId"));
   rv.setResourceSpecId(Sdk.Xml.selectSingleNodeText(node, "g:ResourceSpecId"));

   
   return rv;
  }



  //Public Methods to retrieve properties
  this.getSearchResults = function () {
   ///<summary>
   /// Gets the results of the search. 
   ///</summary>   
   ///<returns type="Sdk.SearchResults">
   /// The results of the search.
   ///</returns>
   return _searchResults;
  }

  //Set property values from responseXml constructor parameter
  _setSearchResults(responseXml);
 }
 this.SearchResponse.__class = true;

 this.AppointmentRequest = function(){
  ///<summary>
  /// Provides the details of an appointment request for the SearchRequest class. 
  ///</summary>
  if (!(this instanceof Sdk.AppointmentRequest)) {
   return new Sdk.AppointmentRequest();
  }

  var _anchorOffset = 0;
  var _appointmentsToIgnore = null;
  var _constraints = null;
  var _direction = null;
  var _duration = null;
  var _numberOfResults = null;
  var _objectives = null;
  var _recurrenceDuration = 0;
  var _recurrenceTimeZoneCode = 0;
  var _requiredResources = new Sdk.Collection(Sdk.RequiredResource);
  var _searchRecurrenceRule = null;
  var _searchRecurrenceStart = null;
  var _searchWindowEnd = null;
  var _searchWindowStart = null;
  var _serviceId = null;
  var _sites = new Sdk.Collection(String);
  var _userTimeZoneCode = null;


  function _setValidAnchorOffset(value){
   if(typeof value == "number")
   { _anchorOffset = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest AnchorOffset property is required and must be a Number.")
   }
  };
  function _setValidAppointmentsToIgnore(value){
   if(value instanceof Sdk.AppointmentsToIgnore)
   { _appointmentsToIgnore = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest AppointmentsToIgnore property is required and must be an Sdk.AppointmentsToIgnore.")
   }
  };
  function _setValidConstraints(value){
   if(value instanceof Sdk.ConstraintRelation)
   { _constraints = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest Constraints property is required and must be an Sdk.ConstraintRelation.")
   }
  };
  function _setValidDirection(value){
   if(typeof value == "string" && (value == "Backward" || value == "Forward"))
   { _direction = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest Direction property is required and must be a String with the value of 'Backward' or 'Forward'.")
   }
  };
  function _setValidDuration(value){
   if(typeof value == "number")
   { _duration = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest Duration property is required and must be a Number.")
   }
  };
  function _setValidNumberOfResults(value){
   if(typeof value == "number")
   { _numberOfResults = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest NumberOfResults property is required and must be a Number.")
   }
  };
  function _setValidObjectives(value){
   if(value instanceof Sdk.ObjectiveRelation)
   { _objectives = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest Objectives property is required and must be an Sdk.ObjectiveRelation.")
   }
  };
  function _setValidRecurrenceDuration(value){
   if(typeof value == "number")
   { _recurrenceDuration = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest RecurrenceDuration property is required and must be a Number.")
   }
  };
  function _setValidRecurrenceTimeZoneCode(value){
   if(typeof value == "number")
   { _recurrenceTimeZoneCode = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest RecurrenceTimeZoneCode property is required and must be a Number.")
   }
  };
  function _setValidRequiredResources(value){
   if(Sdk.Util.isCollectionOf(value,Sdk.RequiredResource))
   { _requiredResources = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest RequiredResources property is required and must be and Sdk.Collection of Sdk.RequiredResource.")
   }
  };
  function _setValidSearchRecurrenceRule(value){
   if(typeof value == "string")
   { _searchRecurrenceRule = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest SearchRecurrenceRule property is required and must be a String.")
   }
  };
  function _setValidSearchRecurrenceStart(value){
   if(value instanceof Date || value == null)
   { _searchRecurrenceStart = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest SearchRecurrenceStart property must be a Date or null.")
   }
  };
  function _setValidSearchWindowEnd(value){
   if(value instanceof Date || value == null)
   { _searchWindowEnd = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest SearchWindowEnd property must be a Date or null.")
   }
  };
  function _setValidSearchWindowStart(value){
   if(value instanceof Date || value == null)
   { _searchWindowStart = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest SearchWindowStart property must be a Date or null.")
   }
  };
  function _setValidServiceId(value){
   if(Sdk.Util.isGuidOrNull(value))
   { _serviceId = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest ServiceId property must be a String representation of a GUID value.")
   }
  };
  function _setValidSites(value){
   if(Sdk.Util.isCollectionOf(value,String))
   { _sites = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest Sites property is required and must be an Sdk.Collection of string values.")
   }
  };
  function _setValidUserTimeZoneCode(value){
   if(typeof value == "number")
   { _userTimeZoneCode = value;}
   else
   {
    throw new Error("Sdk.AppointmentRequest UserTimeZoneCode property is required and must be a Number.")
   }
  };


  this.getAnchorOffset = function () {
   ///<summary>
   /// Gets the time offset in minutes, from midnight, when the first occurrence of the appointment can take place. 
   ///</summary>
   /// <returns type="Number">
   /// The time offset in minutes, from midnight, when the first occurrence of the appointment can take place. 
   /// </returns>
   return _anchorOffset;
  };
  this.getAppointmentsToIgnore = function () {
   ///<summary>
   /// Gets the appointments to ignore in the search for possible appointments.
   ///</summary>
   /// <returns type="Sdk.Collection">
   /// The appointments to ignore in the search for possible appointments.
   /// </returns>
   return _appointmentsToIgnore;
  };
  this.getConstraints = function () {
   ///<summary>
   /// Gets any additional constraints.  
   ///</summary>
   /// <returns type="Sdk.Collection">
   /// Any additional constraints. 
   /// </returns>
   return _constraints;
  };
  this.getDirection = function () {
   ///<summary>
   /// Gets the direction of the search. 
   ///</summary>
   /// <returns type="String">
   /// The direction of the search.  Either "Backward" or "Forward"
   /// </returns>
   return _direction;
  };
  this.getDuration = function () {
   ///<summary>
   /// Gets the appointment duration, in minutes. 
   ///</summary>
   /// <returns type="Number">
   /// The appointment duration, in minutes. 
   /// </returns>
   return _duration;
  };
  this.getNumberOfResults = function () {
   ///<summary>
   /// Gets the number of results to be returned from the search request. 
   ///</summary>
   /// <returns type="Number">
   /// The number of results to be returned from the search request. 
   /// </returns>
   return _numberOfResults;
  };  
  this.getObjectives = function () {
   ///<summary>
   /// Gets the scheduling strategy that overrides the default constraints. 
   ///</summary>
   /// <returns type="Sdk.Collection">
   /// The scheduling strategy that overrides the default constraints. 
   /// </returns>
   return _objectives;
  };
  this.getRecurrenceDuration = function () {
   ///<summary>
   /// Gets the time, in minutes, for which the appointment recurrence is valid. 
   ///</summary>
   /// <returns type="Number">
   /// The time, in minutes, for which the appointment recurrence is valid. 
   /// </returns>
   return _recurrenceDuration;
  };
  this.getRecurrenceTimeZoneCode = function () {
   ///<summary>
   /// Gets a value to override the time zone that is specified by the UserTimeZoneCode property.  
   ///</summary>
   /// <returns type="Number">
   /// A value to override the time zone that is specified by the UserTimeZoneCode property.  
   /// </returns>
   return _recurrenceTimeZoneCode;
  };  
  this.getRequiredResources = function () {
   ///<summary>
   /// Gets the resources that are needed for this appointment. 
   ///</summary>
   /// <returns type="Sdk.RequiredResource">
   /// The resources that are needed for this appointment. 
   /// </returns>
   return _requiredResources;
  };
  this.getSearchRecurrenceRule = function () {
   ///<summary>
   /// Gets the recurrence rule for appointment recurrence. 
   ///</summary>
   /// <returns type="String">
   /// The recurrence rule for appointment recurrence. 
   /// </returns>
   return _searchRecurrenceRule;
  };
  this.getSearchRecurrenceStart = function () {
   ///<summary>
   /// Gets the date and time for the first possible instance of the appointment. 
   ///</summary>
   /// <returns type="Date">
   /// The date and time for the first possible instance of the appointment. 
   /// </returns>
   return _searchRecurrenceStart;
  };
  this.getSearchWindowEnd = function () {
   ///<summary>
   /// Gets the date and time to end the search. 
   ///</summary>
   /// <returns type="Date">
   /// The date and time to end the search. 
   /// </returns>
   return _searchWindowEnd;
  };
  this.getSearchWindowStart = function () {
   ///<summary>
   /// Gets the date and time to begin the search. 
   ///</summary>
   /// <returns type="Date">
   /// The date and time to begin the search. 
   /// </returns>
   return _searchWindowStart
  };
  this.getServiceId = function () {
   ///<summary>
   /// Gets the ID of the service to search for. 
   ///</summary>
   /// <returns type="String">
   /// The ID of the service to search for. 
   /// </returns>
   return _serviceId;
  };
  this.getSites = function () {
   ///<summary>
   /// Gets the sites where the requested appointment can take place. 
   ///</summary>
   /// <returns type="Sdk.Collection">
   /// The sites where the requested appointment can take place. 
   /// </returns>
   return _sites;
  };
  this.getUserTimeZoneCode = function () {
   ///<summary>
   /// Gets the time zone code of the user who is requesting the appointment. 
   ///</summary>
   /// <returns type="Number">
   /// The time zone code of the user who is requesting the appointment. 
   /// </returns>
   return _userTimeZoneCode;
  };

  this.setAnchorOffset = function (anchorOffset) {
   ///<summary>
   /// Sets the time offset in minutes, from midnight, when the first occurrence of the appointment can take place. 
   ///</summary>
   /// <param type="Number" name="anchorOffset" optional="true" mayBeNull="false">
   /// The time offset in minutes, from midnight, when the first occurrence of the appointment can take place. 
   /// </param>
   _setValidAnchorOffset(anchorOffset);
  };
  this.setAppointmentsToIgnore = function (appointmentsToIgnore) {
   ///<summary>
   /// Sets the appointments to ignore in the search for possible appointments. 
   ///</summary>
   /// <param type="Sdk.AppointmentsToIgnore" name="appointmentsToIgnore" optional="true" mayBeNull="false">
   /// The appointments to ignore in the search for possible appointments. 
   /// </param>
   _setValidAppointmentsToIgnore(appointmentsToIgnore);
  };
  this.setConstraints = function (constraints) {
   ///<summary>
   /// Sets any additional constraints.  
   ///</summary>
   /// <param type="Sdk.ConstraintRelation" name="constraints" optional="false" mayBeNull="false">
   /// Any additional constraints.  
   /// </param>
   _setValidConstraints(constraints);
  };
  this.setDirection = function (direction) {
   ///<summary>
   /// Sets the direction of the search. 
   ///</summary>
   /// <param type="String" name="direction" optional="false" mayBeNull="false">
   /// The direction of the search. Either "Backward" or "Forward"
   /// </param>
   _setValidDirection(direction);
  };
  this.setDuration = function (duration) {
   ///<summary>
   /// Sets the appointment duration, in minutes. 
   ///</summary>
   /// <param type="Number" name="duration" optional="false" mayBeNull="false">
   /// The appointment duration, in minutes. 
   /// </param>
   _setValidDuration(duration);
  };
  this.setNumberOfResults = function (numberOfResults) {
   ///<summary>
   /// Sets the number of results to be returned from the search request. 
   ///</summary>
   /// <param type="Number" name="numberOfResults" optional="false" mayBeNull="false">
   /// The number of results to be returned from the search request.
   /// </param>
   _setValidNumberOfResults(numberOfResults);
  };
  this.setObjectives = function (objectives) {
   ///<summary>
   /// Sets the scheduling strategy that overrides the default constraints. 
   ///</summary>
   /// <param type="Sdk.ObjectiveRelation" name="objectives" optional="false" mayBeNull="false">
   /// The scheduling strategy that overrides the default constraints. 
   /// </param>
   _setValidObjectives(objectives);
  };
  this.setRecurrenceDuration = function (recurrenceDuration) {
   ///<summary>
   /// Sets the time, in minutes, for which the appointment recurrence is valid. 
   ///</summary>
   /// <param type="Number" name="recurrenceDuration" optional="false" mayBeNull="false">
   /// The time, in minutes, for which the appointment recurrence is valid. 
   /// </param>
   _setValidRecurrenceDuration(recurrenceDuration);
  };
  this.setRecurrenceTimeZoneCode = function (recurrenceTimeZoneCode) {
   ///<summary>
   ///  Sets a value to override the time zone that is specified by the UserTimeZoneCode property.  
   ///</summary>
   /// <param type="Number" name="recurrenceTimeZoneCode" optional="false" mayBeNull="false">
   /// A value to override the time zone that is specified by the UserTimeZoneCode property.  
   /// </param>
   _setValidRecurrenceTimeZoneCode(recurrenceTimeZoneCode);
  };
  this.setRequiredResources = function (requiredResources) {
   ///<summary>
   /// Sets the resources that are needed for this appointment.  
   ///</summary>   
   /// <param type="Sdk.RequiredResource" name="requiredResources" optional="false" mayBeNull="false">
   /// The resources that are needed for this appointment. 
   /// </param>
   _setValidRequiredResources(requiredResources);
  };
  this.setSearchRecurrenceRule = function (searchRecurrenceRule) {
   ///<summary>
   /// Sets the recurrence rule for appointment recurrence. 
   ///</summary>
   /// <param type="String" name="searchRecurrenceRule" optional="false" mayBeNull="false">
   /// The recurrence rule for appointment recurrence. 
   /// </param>
   _setValidSearchRecurrenceRule(searchRecurrenceRule);
  };
  this.setSearchRecurrenceStart = function (searchRecurrenceStart) {
   ///<summary>
   /// Sets the date and time for the first possible instance of the appointment. 
   ///</summary>
   /// <param type="Date" name="searchRecurrenceStart" optional="false" mayBeNull="true">
   /// The date and time for the first possible instance of the appointment. 
   /// </param>
   _setValidSearchRecurrenceStart(searchRecurrenceStart);
  };
  this.setSearchWindowEnd = function (searchWindowEnd) {
   ///<summary>
   /// Sets the date and time to end the search. 
   ///</summary>
   /// <param type="Date" name="searchWindowEnd" optional="false" mayBeNull="true">
   /// The date and time to end the search. 
   /// </param>
   _setValidSearchWindowEnd(searchWindowEnd);
  };
  this.setSearchWindowStart = function (searchWindowStart) {
   ///<summary>
   /// Sets the date and time to begin the search. 
   ///</summary>
   /// <param type="Date" name="searchWindowStart" optional="false" mayBeNull="true">
   /// The date and time to begin the search. 
   /// </param>
   _setValidSearchWindowStart(searchWindowStart);
  };
  this.setServiceId = function (serviceId) {
   ///<summary>
   /// Sets the ID of the service to search for. 
   ///</summary>
   /// <param type="String" name="serviceId" optional="false" mayBeNull="false">
   /// The ID of the service to search for. 
   /// </param>
   _setValidServiceId(serviceId);
  };
  this.setSites = function (sites) {
   ///<summary>
   /// Sets the sites where the requested appointment can take place. 
   ///</summary>
   /// <param type="Sdk.Collection" name="sites" optional="false" mayBeNull="false">
   /// The sites where the requested appointment can take place. 
   /// </param>
   _setValidSites(sites);
  };
  this.setUserTimeZoneCode = function (userTimeZoneCode) {
   ///<summary>
   /// Sets the time zone code of the user who is requesting the appointment. 
   ///</summary>
   /// <param type="Number" name="userTimeZoneCode" optional="false" mayBeNull="false">
   /// The time zone code of the user who is requesting the appointment. 
   /// </param>
   _setValidUserTimeZoneCode(userTimeZoneCode);
  };


 }
 this.AppointmentRequest.__class = true;

 this.AppointmentsToIgnore = function (appointments, resourceid) {
  ///<summary>
  /// Provides the details of an appointment request for the SearchRequest class. 
  ///</summary>
  ///<param name="appointments" type="Sdk.Collection" optional="true" mayBeNull="true" />
  /// The collection of IDs of appointments to ignore.
  ///</param>
  ///<param name="resourceid" type="String" optional="true" mayBeNull="true" />
  /// The resource for which appointments are to be ignored.
  ///</param>

  if (!(this instanceof Sdk.AppointmentsToIgnore)) {
   return new Sdk.AppointmentsToIgnore(appointments,resourceid);
  }

  var _appointments = new Sdk.Collection(String);
  var _resourceId = null;

  function _setValidAppointments(value){
   if(Sdk.Util.isCollectionOf(value,String))
   { _appointments = value;}
   else
   {
    throw new Error("Sdk.AppointmentsToIgnore Appointments property is required and must be an Sdk.Collection of String values.")
   }
  };
  function _setValidResourceId(value){
   if(Sdk.Util.isGuidOrNull)
   { _resourceId = value;}
   else
   {
    throw new Error("Sdk.AppointmentsToIgnore ResourceId property is required and must be a String representation of a GUID value or null.")
   }
  };

  //Set internal properties from constructor parameters
  if(typeof appointments != "undefined")
  {
   _setValidAppointments(appointments);
  }

  if(typeof resourceid != "undefined")
  {
   _setValidResourceId(resourceid);
  }
 
  this.getAppointments = function () {
   ///<summary>
   /// Gets a collection of IDs of appointments to ignore. 
   ///</summary>
   /// <returns type="Sdk.Collection">
   /// A collection of IDs of appointments to ignore. 
   /// </returns>
   return _appointments;
  };
  this.getResourceId = function () {
   ///<summary>
   /// Gets the resource for which appointments are to be ignored. 
   ///</summary>
   /// <returns type="String">
   /// The  resource for which appointments are to be ignored. 
   /// </returns>
   return _resourceId;
  };
 
  this.setAppointments = function (appointments) {
   ///<summary>
   /// Sets a collection of IDs of appointments to ignore.  
   ///</summary>
   /// <param type="Sdk.Collection" name="appointments" optional="true" mayBeNull="false">
   ///  A collection of IDs of appointments to ignore.  
   /// </param>
   _setValidAppointments(appointments);
  };
  this.setResourceId = function (resourceId) {
   ///<summary>
   /// Sets the resource for which appointments are to be ignored. 
   ///</summary>
   /// <param type="String" name="resourceId" optional="true" mayBeNull="false">
   /// The resource for which appointments are to be ignored. 
   /// </param>
   _setValidResourceId(resourceId);
  };
 
 }
 this.AppointmentsToIgnore.__class = true;

 this.ConstraintRelation = function(objectid,constraints){
  ///<summary>
  /// Specifies additional constraints to be applied when you select resources for appointments. 
  ///</summary>
  ///<param name="objectid"  type="String">
  /// The ID of the calendar rule.
  ///</param>
  ///<param name="constraints"  type="String">
  /// The set of constraints.
  ///</param>
  if (!(this instanceof Sdk.ConstraintRelation )) {
   return new Sdk.ConstraintRelation (objectid,constraints);
  }

  var _objectid = null;
  var _constraintType = "Resource Selection";
  var _constraints = null;



  function _setValidObjectId(value){
   if(Sdk.Util.isGuidOrNull(value))
   { _objectid = value;}
   else
   {
    throw new Error("Sdk.ConstraintRelation ObjectId property is required and must be an String representation of a GUID value.")
   }
  };

  function _setValidContraintType(value){
   if(typeof value == "string")
   { _constraintType = value;}
   else
   {
    throw new Error("Sdk.ConstraintRelation ContraintType property is required and must be an String.")
   }
  };

  function _setValidConstraints(value){
   if(typeof value == "string")
   { _constraints = value;}
   else
   {
    throw new Error("Sdk.ConstraintRelation Constraints property is required and must be an String.")
   }
  };


  //Set internal properties from constructor parameters
  if(typeof objectid != "undefined")
  {
   _setValidObjectId(objectid);
  }
  if(typeof constraints != "undefined")
  {
   _setValidConstraints(constraints);
  }


 
  this.getObjectId = function () {
   ///<summary>
   /// Gets the ID of the calendar rule to which the constraint is applied. 
   ///</summary>
   /// <returns type="String">
   /// The ID of the calendar rule to which the constraint is applied. 
   /// </returns>
   return _objectid;
  };
  this.getConstraintType = function () {
   ///<summary>
   /// Gets the type of constraints. 
   ///</summary>
   /// <returns type="String">
   /// The  type of constraints. 
   /// </returns>
   return _constraintType;
  };
  this.getContraints = function () {
   ///<summary>
   /// Gets the set of additional constraints. 
   ///</summary>
   /// <returns type="String">
   /// The set of additional constraints. 
   /// </returns>
   return _constraints;
  };
 
  this.setObjectId = function (objectid) {
   ///<summary>
   /// Sets the ID of the calendar rule to which the constraint is applied. 
   ///</summary>
   /// <param type="String" name="objectid" optional="true" mayBeNull="false">
   /// The ID of the calendar rule to which the constraint is applied. 
   /// </param>
   _setValidObjectId(objectid);
  };
  this.setConstraintType = function (constraintType) {
   ///<summary>
   /// Sets the type of constraints. 
   ///</summary>
   /// <param type="String" name="constraintType" optional="true" mayBeNull="false">
   /// The type of constraints. 
   /// </param>
   _setValidContraintType(constraintType);
  };
  this.setConstraints = function (constraints) {
   ///<summary>
   /// Sets the set of additional constraints. 
   ///</summary>
   /// <param type="String" name="constraints" optional="true" mayBeNull="false">
   /// The set of additional constraints. 
   /// </param>
   _setValidConstraints(constraints);
  };
 
 }
 this.ConstraintRelation.__class = true;

 this.ObjectiveRelation = function (resourceSpecId, objectiveExpression) {
  ///<summary>
  /// Contains the data that describes the scheduling strategy for an AppointmentRequest and that overrides the default constraints. 
  ///</summary>
  ///<param name="resourceSpecId"  type="String">
  /// The ID of the resource specification.
  ///</param>
  ///<param name="objectiveExpression"  type="String">
  /// The search strategy to use in the appointment request.
  ///</param>

  if (!(this instanceof Sdk.ObjectiveRelation )) {
   return new Sdk.ObjectiveRelation (resourceSpecId,objectiveExpression);
  }

  var _resourceSpecId = null;
  var _objectiveExpression = null;


  function _setValidResourceSpecId(value){
   if(Sdk.Util.isGuidOrNull(value))
   { _resourceSpecId = value;}
   else
   {
    throw new Error("Sdk.ObjectiveRelation ResourceSpecId property is required and must be an String representation of a GUID value.")
   }
  };

  function _setValidObjectiveExpression(value){
   if(typeof value == "string")
   { _objectiveExpression = value;}
   else
   {
    throw new Error("Sdk.ObjectiveRelation ObjectiveExpression property is required and must be an String.")
   }
  };

  //Set internal properties from constructor parameters
  if(typeof resourceSpecId != "undefined")
  {
   _setValidResourceSpecId(resourceSpecId);
  }
  if(typeof objectiveExpression != "undefined")
  {
   _setValidObjectiveExpression(objectiveExpression);
  }
 
  this.getResourceSpecId = function () {
   ///<summary>
   /// Gets the ID of the resource specification. 
   ///</summary>
   /// <returns type="String">
   /// The  ID of the resource specification. 
   /// </returns>
   return _resourceSpecId;
  };
  this.getObjectiveExpression = function () {
   ///<summary>
   /// Gets the search strategy to use in the appointment request for the SearchRequest message. 
   ///</summary>
   /// <returns type="String">
   /// The search strategy to use in the appointment request for the SearchRequest message. 
   /// </returns>
   return _objectiveExpression;
  };
 
  this.setResourceSpecId = function (resourceSpecId) {
   ///<summary>
   /// Sets the ID of the resource specification. 
   ///</summary>
   /// <param type="String" name="resourceSpecId" optional="true" mayBeNull="false">
   /// The ID of the resource specification. 
   /// </param>
   _setValidResourceSpecId(resourceSpecId);
  };
  this.setObjectiveExpression = function (objectiveExpression) {
   ///<summary>
   /// Sets the search strategy to use in the appointment request for the SearchRequest message. 
   ///</summary>
   /// <param type="String" name="objectiveExpression" optional="true" mayBeNull="false">
   /// The search strategy to use in the appointment request for the SearchRequest message. 
   /// </param>
   _setValidObjectiveExpression(objectiveExpression);
  };
 
 }
 this.ObjectiveRelation .__class = true;

 this.RequiredResource = function (resourceId, resourceSpecId) {
  ///<summary>
  /// Specifies a resource that is required for a scheduling operation. 
  ///</summary>
  ///<param name="resourceId"  type="String">
  /// The ID of the required resource.
  ///</param>
  ///<param name="resourceSpecId"  type="String">
  /// The ID of the required resource specification.
  ///</param>

  if (!(this instanceof Sdk.RequiredResource  )) {
   return new Sdk.RequiredResource  (resourceId,resourceSpecId);
  }

  var _resourceId = null;
  var _resourceSpecId = null;
 

  function _setValidResourceId(value){
   if(Sdk.Util.isGuidOrNull(value))
   { _resourceId = value;}
   else
   {
    throw new Error("Sdk.RequiredResource ResourceId property is required and must be an String representation of a GUID value.")
   }
  };


  function _setValidResourceSpecId(value){
   if(Sdk.Util.isGuidOrNull(value))
   { _resourceSpecId = value;}
   else
   {
    throw new Error("Sdk.RequiredResource ResourceSpecId property is required and must be an String representation of a GUID value.")
   }
  };



  //Set internal properties from constructor parameters
  if(typeof resourceId != "undefined")
  {
   _setValidResourceId(resourceId);
  }
  if(typeof resourceSpecId != "undefined")
  {
   _setValidResourceSpecId(resourceSpecId);
  }

  this.getResourceId = function () {
   ///<summary>
   /// Gets the ID of the required resource. 
   ///</summary>
   /// <returns type="String">
   /// The ID of the required resource. 
   /// </returns>
   return _resourceId;
  };
  this.getResourceSpecId = function () {
   ///<summary>
   /// Gets the ID of the required resource specification. 
   ///</summary>
   /// <returns type="String">
   /// The ID of the required resource specification. 
   /// </returns>
   return _resourceSpecId;
  };

  this.setResourceId = function (resourceId) {
   ///<summary>
   /// Sets the ID of the required resource. 
   ///</summary>
   /// <param type="String" name="resourceId" optional="true" mayBeNull="false">
   /// The ID of the required resource. 
   /// </param>
   _setValidResourceId(resourceId);
  };
  this.setResourceSpecId = function (resourceSpecId) {
   ///<summary>
   /// Sets the ID of the required resource specification. 
   ///</summary>
   /// <param type="String" name="resourceSpecId" optional="true" mayBeNull="false">
   /// The ID of the required resource specification. 
   /// </param>
   _setValidResourceSpecId(resourceSpecId);
  };

 
 }
 this.RequiredResource.__class = true;

 this.SearchResults = function () {
  ///<summary>
  /// Contains the results from the SearchRequest message. 
  ///</summary>


  if (!(this instanceof Sdk.SearchResults)) {
   return new Sdk.SearchResults();
  }

  var _proposals = new Sdk.Collection(Sdk.AppointmentProposal);
  var _traceInfo = null;
 

  function _setValidProposals(value){
   if(Sdk.Util.isCollectionOf(value,Sdk.AppointmentProposal))
   { _proposals = value;}
   else
   {
    throw new Error("Sdk.SearchResults Proposals property must be an Sdk.Collection of Sdk.AppointmentProposal.")
   }
  };

  function _setValidTraceInfo(value){
   if(value instanceof Sdk.TraceInfo)
   { _traceInfo = value;}
   else
   {
    throw new Error("Sdk.SearchResults TraceInfo property must be an Sdk.TraceInfo.")
   }
  };

  this.getProposals = function () {
   ///<summary>
   /// Gets the set of proposed appointments that meet the appointment request criteria. 
   ///</summary>   
   /// <returns type="Sdk.Collection">
   /// The set of proposed appointments that meet the appointment request criteria. 
   /// </returns>
   return _proposals;
  };
  this.getTraceInfo = function () {
   ///<summary>
   /// Gets information regarding the results of the search.  
   ///</summary>
   /// <returns type="Sdk.TraceInfo">
   /// Information regarding the results of the search.   
   /// </returns>
   return _traceInfo;
  };
  

  this.setProposals = function (proposals) {
   ///<summary>
   /// Sets the set of proposed appointments that meet the appointment request criteria. 
   ///</summary>
   /// <param type="Sdk.AppointmentProposal" name="proposals" optional="true" mayBeNull="false">
   /// The set of proposed appointments that meet the appointment request criteria. 
   /// </param>
   _setValidProposals(proposals);
  };
  this.setTraceInfo = function (traceInfo) {
   ///<summary>
   /// Sets information regarding the results of the search. 
   ///</summary>
   /// <param type="Sdk.TraceInfo" name="traceInfo" optional="true" mayBeNull="false">
   /// Information regarding the results of the search. 
   /// </param>
   _setValidTraceInfo(traceInfo);
  };

 }
 this.SearchResults.__class = true;

 this.AppointmentProposal = function () {
  ///<summary>
  /// Represents a proposed appointment time and date as a result of the SearchRequest message. 
  ///</summary>
  if (!(this instanceof Sdk.AppointmentProposal)) {
   return new Sdk.AppointmentProposal();
  }

  var _end = null;
  var _proposalParties = new Sdk.Collection(Sdk.ProposalParty);
  var _siteId = null;
  var _siteName = null;
  var _start = null;
 

  function _setValidEnd(value){
   if(value == null || value instanceof Date)
   { _end = value;}
   else
   {
    throw new Error("Sdk.AppointmentProposal End property must be a Date or null.")
   }
  };

  function _setValidProposalParties(value){
   if(Sdk.Util.isCollectionOf(value,Sdk.ProposalParty))
   { _proposalParties = value;}
   else
   {
    throw new Error("Sdk.AppointmentProposal ProposalParties property must be an Sdk.Collection of Sdk.ProposalParty.")
   }
  };

  function _setValidSiteId(value){
   if(Sdk.Util.isGuidOrNull(value))
   { _siteId = value;}
   else
   {
    throw new Error("Sdk.AppointmentProposal SiteId property must be a String representation of a GUID value or null.")
   }
  };

  function _setValidSiteName(value){
   if(typeof value == "string")
   { _siteName = value;}
   else
   {
    throw new Error("Sdk.AppointmentProposal SiteName property must be a String.")
   }
  };

  function _setValidStart(value){
   if(value == null || value instanceof Date)
   { _start = value;}
   else
   {
    throw new Error("Sdk.AppointmentProposal Start property must be a Date or null.")
   }
  };

  this.getEnd = function () {
   ///<summary>
   /// Gets the proposed appointment end date and time. 
   ///</summary>
   /// <returns type="Date">
   /// The  proposed appointment end date and time. 
   /// </returns>
   return _end;
  };
  this.getProposalParties = function () {
   ///<summary>
   /// Gets a collection of parties needed for the proposed appointment.  
   ///</summary>
   /// <returns type="Sdk.Collection">
   /// A collection of parties needed for the proposed appointment.  
   /// </returns>
   return _proposalParties;
  };
  this.getSiteId = function () {
   ///<summary>
   /// Gets the ID of the site for the proposed appointment. 
   ///</summary>
   /// <returns type="String">
   /// The  ID of the site for the proposed appointment. 
   /// </returns>
   return _siteId;
  };
  this.getSiteName = function () {
   ///<summary>
   /// Gets the name of the site for the proposed appointment. 
   ///</summary>
   /// <returns type="String">
   /// The name of the site for the proposed appointment. 
   /// </returns>
   return _siteName;
  };
  this.getStart = function () {
   ///<summary>
   /// Gets the proposed appointment start date and time. 
   ///</summary>
   /// <returns type="Date">
   /// The proposed appointment start date and time. 
   /// </returns>
   return _start;
  };

  this.setEnd = function (end) {
   ///<summary>
   /// Sets the proposed appointment end date and time. 
   ///</summary>
   /// <param type="Date" name="end" optional="true" mayBeNull="true">
   /// The proposed appointment end date and time. 
   /// </param>
   _setValidEnd(end);
  };
  this.setProposalParties = function (proposalParties) {
   ///<summary>
   /// Sets a collection of parties needed for the proposed appointment.   
   ///</summary>
   /// <param type="Sdk.Collection" name="proposalParties" optional="true" mayBeNull="false">
   /// A collection of parties needed for the proposed appointment.   
   /// </param>
   _setValidProposalParties(proposalParties);
  };
  this.setSiteId = function (siteid) {
   ///<summary>
   /// Sets the ID of the site for the proposed appointment. 
   ///</summary>
   /// <param type="String" name="siteid" optional="false" mayBeNull="false">
   /// The ID of the site for the proposed appointment. 
   /// </param>
   _setValidSiteId(siteid);
  };
  this.setSiteName = function (sitename) {
   ///<summary>
   /// Sets the name of the site for the proposed appointment. 
   ///</summary>
   /// <param type="String" name="sitename" optional="true" mayBeNull="true">
   /// The name of the site for the proposed appointment. 
   /// </param>
   _setValidSiteName(sitename);
  };
  this.setStart = function (start) {
   ///<summary>
   /// Sets the proposed appointment start date and time. 
   ///</summary>
   /// <param type="Date" name="start" optional="true" mayBeNull="false">
   /// The proposed appointment start date and time. 
   /// </param>
   _setValidStart(start);
  };
 }
 this.AppointmentProposal.__class = true;

 this.ProposalParty = function(){
  ///<summary>
  /// Represents a party (user, team, or resource) that is needed for the proposed appointment. 
  ///</summary>
  if (!(this instanceof Sdk.ProposalParty)) {
   return new Sdk.ProposalParty();
  }

  var _displayName = null;
  var _effortRequired = null;
  var _entityName = null;
  var _resourceId = null;
  var _resourceSpecId = null;
 

  function _setValidDisplayName(value){
   if(typeof value == "string")
   { _displayName = value;}
   else
   {
    throw new Error("Sdk.ProposalParty DisplayName property must be a String.")
   }
  };

  function _setValidEffortRequired(value){
   if(typeof value == "number")
   { _effortRequired = value;}
   else
   {
    throw new Error("Sdk.ProposalParty EffortRequired property must be a Number.")
   }
  };

  function _setValidEntityName(value){
   if(typeof value == "string")
   { _entityName = value;}
   else
   {
    throw new Error("Sdk.ProposalParty EntityName property must be a String.")
   }
  };

  function _setValidResourceId(value){
   if(Sdk.Util.isGuidOrNull(value))
   { _resourceId = value;}
   else
   {
    throw new Error("Sdk.ProposalParty ResourceId property must be a String representation of a GUID value.")
   }
  };

  function _setValidResourceSpecId(value){
   if(Sdk.Util.isGuidOrNull(value))
   { _resourceSpecId = value;}
   else
   {
    throw new Error("Sdk.ProposalParty ResourceSpecId property must be a String representation of a GUID value.")
   }
  };

  this.getDisplayName = function(){
   ///<summary>
   /// Gets the display name for the party. 
   ///</summary>
   /// <returns type="String">
   /// The  display name for the party. 
   /// </returns>
   return _displayName;
  };
  this.getEffortRequired = function () {
   ///<summary>
   /// Gets the percentage of time that is required to perform the service. 
   ///</summary>
   /// <returns type="Number">
   /// The percentage of time that is required to perform the service. 
   /// </returns>
   return _effortRequired;
  };
  this.getEntityName = function () {
   ///<summary>
   /// Gets the logical name of the type of entity that is represented by this party. 
   ///</summary>
   /// <returns type="String">
   /// The logical name of the type of entity that is represented by this party. 
   /// </returns>
   return _entityName;
  };
  this.getResourceId = function () {
   ///<summary>
   /// Gets the ID of the resource that is represented by this party. 
   ///</summary>
   /// <returns type="String">
   /// The ID of the resource that is represented by this party. 
   /// </returns>
   return _resourceId;
  };
  this.getResourceSpecId = function () {
   ///<summary>
   /// Gets the ID of the resource specification that is represented by this party. 
   ///</summary>
   /// <returns type="String">
   /// The  ID of the resource specification that is represented by this party. 
   /// </returns>
   return _resourceSpecId;
  };

  this.setDisplayName = function (displayName) {
   ///<summary>
   /// Sets the display name for the party. 
   ///</summary>
   /// <param type="String" name="displayName" optional="true" mayBeNull="false">
   /// The display name for the party. 
   /// </param>
   _setValidDisplayName(displayName);
  };
  this.setEffortRequired = function (effortRequired) {
   ///<summary>
   /// Sets the percentage of time that is required to perform the service. 
   ///</summary>
   /// <param type="Number" name="effortRequired" optional="true" mayBeNull="false">
   /// The percentage of time that is required to perform the service. 
   /// </param>
   _setValidEffortRequired(effortRequired);
  };
  this.setEntityName = function (entityName) {
   ///<summary>
   /// Sets the logical name of the type of entity that is represented by this party. 
   ///</summary>
   /// <param type="String" name="entityName" optional="true" mayBeNull="false">
   /// The logical name of the type of entity that is represented by this party. 
   /// </param>
   _setValidEntityName(entityName);
  };  
  this.setResourceId = function (resourceId) {
   ///<summary>
   /// Sets the ID of the resource that is represented by this party. 
   ///</summary>
   /// <param type="String" name="resourceId" optional="true" mayBeNull="false">
   /// The ID of the resource that is represented by this party. 
   /// </param>
   _setValidResourceId(resourceId);
  };
  this.setResourceSpecId = function (resourceSpecId) {
   ///<summary>
   /// Sets the ID of the resource specification that is represented by this party. 
   ///</summary>
   /// <param type="String" name="resourceSpecId" optional="true" mayBeNull="false">
   /// The ID of the resource specification that is represented by this party. 
   /// </param>
   _setValidResourceSpecId(resourceSpecId);
  };

 }
 this.ProposalParty.__class = true;

}).call(Sdk)

Sdk.SearchRequest.prototype = new Sdk.OrganizationRequest();
Sdk.SearchResponse.prototype = new Sdk.OrganizationResponse();

Sdk.AppointmentRequest.prototype.toValueXml = function () {
 

 return [
 (this.getAnchorOffset() == null)? "<g:AnchorOffset i:nil=\"true\" />":"<g:AnchorOffset>"+this.getAnchorOffset()+"</g:AnchorOffset>",  
 (this.getAppointmentsToIgnore() == null)? "<g:AppointmentsToIgnore />":"<g:AppointmentsToIgnore>"+this.getAppointmentsToIgnore().toValueXml()+"</g:AppointmentsToIgnore>",  
 (this.getConstraints() == null)? "<g:Constraints />":"<g:Constraints>"+this.getConstraints().toValueXml()+"</g:Constraints>",
 (this.getDirection() == null)? "<g:Direction i:nil=\"true\" />":"<g:Direction>"+this.getDirection()+"</g:Direction>",
 (this.getDuration() == null)? "<g:Duration i:nil=\"true\" />":"<g:Duration>"+this.getDuration()+"</g:Duration>",
 (this.getNumberOfResults() == null)? "<g:NumberOfResults i:nil=\"true\" />":"<g:NumberOfResults>"+this.getNumberOfResults()+"</g:NumberOfResults>",  
 (this.getObjectives() == null)? "<g:Objectives />":"<g:Objectives>"+this.getObjectives().toValueXml()+"</g:Objectives>",
 (this.getRecurrenceDuration() == null)? "<g:RecurrenceDuration i:nil=\"true\" />":"<g:RecurrenceDuration>"+this.getRecurrenceDuration()+"</g:RecurrenceDuration>",
 (this.getRecurrenceTimeZoneCode() == null)? "<g:RecurrenceTimeZoneCode i:nil=\"true\" />":"<g:RecurrenceTimeZoneCode>"+this.getRecurrenceTimeZoneCode()+"</g:RecurrenceTimeZoneCode>",
 (this.getRequiredResources().getCount() == 0)? "<g:RequiredResources />":"<g:RequiredResources>"+this.getRequiredResources().toArrayOfValueXml("g:RequiredResource")+"</g:RequiredResources>",
 (this.getSearchRecurrenceRule() == null)? "<g:SearchRecurrenceRule i:nil=\"true\" />":"<g:SearchRecurrenceRule>"+this.getSearchRecurrenceRule()+"</g:SearchRecurrenceRule>",
 (this.getSearchRecurrenceStart() == null)? "<g:SearchRecurrenceStart i:nil=\"true\" />":"<g:SearchRecurrenceStart>"+this.getSearchRecurrenceStart().toISOString()+"</g:SearchRecurrenceStart>",
 (this.getSearchWindowEnd() == null)? "<g:SearchWindowEnd i:nil=\"true\" />":"<g:SearchWindowEnd>"+this.getSearchWindowEnd().toISOString()+"</g:SearchWindowEnd>",
 (this.getSearchWindowStart() == null)? "<g:SearchWindowStart i:nil=\"true\" />":"<g:SearchWindowStart>"+this.getSearchWindowStart().toISOString()+"</g:SearchWindowStart>",
 (this.getServiceId() == null)? "<g:ServiceId i:nil=\"true\" />":"<g:ServiceId>"+this.getServiceId()+"</g:ServiceId>",
 (this.getSites().getCount() == 0) ? "<g:Sites />" : "<g:Sites>" + this.getSites().toArrayOfValueXml("g:Site") + "</g:Sites>", ///TODO: test this
 (this.getUserTimeZoneCode() == null)? "<g:UserTimeZoneCode i:nil=\"true\" />":"<g:UserTimeZoneCode>"+this.getUserTimeZoneCode()+"</g:UserTimeZoneCode>"].join("");
}

Sdk.AppointmentsToIgnore.prototype.toValueXml = function(){
 return [(this.getAppointments() == null)? "<g:Appointments />":"<g:Appointments>"+this.getAppointments().toArrayOfValueXml("f:guid")+"</g:Appointments>",
 (this.getResourceId() == null)? "<g:ResourceId i:nil=\"true\" />":"<g:ResourceId>"+this.getResourceId()+"</g:ResourceId>"].join("");
}

Sdk.ConstraintRelation.prototype.toValueXml = function(){
 return [
  (this.getObjectId() == null)? "<g:ObjectId i:nil=\"true\" />":"<g:ObjectId>"+this.getObjectId()+"</g:ObjectId>",
  (this.getContraintType() == null)? "<g:ContraintType i:nil=\"true\" />":"<g:ContraintType>"+this.getContraintType()+"</g:ContraintType>",
  (this.getConstraints() == null)? "<g:Constraints i:nil=\"true\" />":"<g:Constraints>"+this.getConstraints()+"</g:Constraints>"].join("");
}

Sdk.ObjectiveRelation.prototype.toValueXml = function(){
 return [
 (this.getResourceSpecId() == null)? "<g:ResourceSpecId i:nil=\"true\" />":"<g:ResourceSpecId>"+this.getResourceSpecId()+"</g:ResourceSpecId>",
 (this.getObjectiveExpression() == null)? "<g:ObjectiveExpression i:nil=\"true\" />":"<g:ObjectiveExpression>"+this.getObjectiveExpression()+"</g:ObjectiveExpression>"].join("");
}


Sdk.RequiredResource.prototype.toXml = function(){
 return ["<g:RequiredResource>",
 this.toValueXml(),
 "</g:RequiredResource>"].join("");
}

Sdk.RequiredResource.prototype.toValueXml = function(){
 
 var resourceIdValue = (this.getResourceId() == null)? "<g:ResourceId i:nil=\"true\" />":"<g:ResourceId>"+this.getResourceId()+"</g:ResourceId>";
 var resourceSpecIdValue = (this.getResourceSpecId() == null)? "<g:ResourceSpecId i:nil=\"true\" />":"<g:ResourceSpecId>"+this.getResourceSpecId()+"</g:ResourceSpecId>";
 return resourceIdValue+resourceSpecIdValue;
                                 
}

Sdk.ProposalParty.prototype.view = function () {
 var rv = {};
 rv.DisplayName = this.getDisplayName();
 rv.EffortRequired = this.getEffortRequired();
 rv.EntityName = this.getEntityName();
 rv.ResourceId = this.getResourceId();
 rv.ResourceSpecId = this.getResourceSpecId();
 return rv;

}

Sdk.AppointmentProposal.prototype.view = function () {
 var rv = {};
rv.End = this.getEnd();
rv.ProposalParties = [];
this.getProposalParties().forEach(function (pp, i) {
 rv.ProposalParties.push(pp.view());
})
rv.SiteId = this.getSiteId();
rv.SiteName = this.getSiteName();
rv.Start = this.getStart();
 return rv;

}

Sdk.SearchResults.prototype.view = function () {
 var rv = {};
 rv.Proposals = [];

 this.getProposals().forEach(function (p, i) {
  rv.Proposals.push(p.view());
 });

 rv.TraceInfo = this.getTraceInfo().view();

 return rv;

}