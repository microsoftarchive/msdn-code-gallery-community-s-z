© 2009 Microsoft Corporation.  All rights reserved.

Sync101 with Remote Change Application over WCF
===============================================

Overview
--------
This sample shows concepts of Microsoft Sync Framework. This sample illustrates 
how to implement a proxy provider that uses the remote change application (RCA) pattern to
synchronize over Windows Communication Foundation (WCF) with a provider on a remote computer.
This sample uses the metadata storage service as the store for the metadata information for each 
replica database. This greatly simplifies the logic required to implement data 
synchronization between data stores.

Required Software
-----------------
- Visual Studio 2008
- .NET Framework 2.0 SP1 or .NET Framework 3.x
- Microsoft Sync Framework 2.0

Steps
-----
1. Open the Sync101WithMetadataStore_VS2008.sln solution in Visual Studio.
2. Build the solution.
3. Run the application (MyTestProgram). This also starts the Sync101WCFService Web service. MyTestProgram 
   uses the the provider assembly (Sync101WithMetadataStore_Provider) and the WCF client and server assembly 
   (Sync101WebService) to synchronize data.