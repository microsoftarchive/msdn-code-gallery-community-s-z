//---------------------------------------------------------------------------------
// Copyright (c) 2014, Microsoft Corporation
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//---------------------------------------------------------------------------------

This Sample introduces the notion of Large Scale Secure Publishing to Event Hubs.
	A Publisher is a logical construct for sending messages into an Event Hub. 
	Each Publisher provides a unique endpoint that lives within an Event Hub, to which you can send messages.

This Sample Demonstrates 
	1. Sending Messages to Publisher Endpoints via REST in a Secure way
	2. All events sent to a Publisher can be consumed at the Same Partition

Steps to Run the Sample:
-----------------------
1.	Create a ServiceBus Namespace from Windows Azure Portal (http://msdn.microsoft.com/en-us/library/hh690931.aspx). 
	Since Event Hub is enabled only in some regions, please make sure that the Service Bus Namespace is in one of the following regions:
	a) Central US
	b) East US 2
	c) West Europe
	d) Southeast Asia [and lately couple more regions added :)]
2.  Get the SAS Connection String of the Namespace and 
	populate the property : "Microsoft.ServiceBus.ConnectionString" in App.Config of this Sample
3.	Now Run the Sample !