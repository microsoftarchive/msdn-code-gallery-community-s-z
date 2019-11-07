SQL Store Extensibility Sample
========================================
    This sample demonstrates the data store extensibility of the Windows PowerShell workflow engine.
    In the sample, a SQL database store class is created by deriving from the PSWorkflowInstanceStore
    class. An additional class is created to perform operations on the database. The sample also
    includes a SQL file that sets up the SQL database. A custom configuration is created by
    overriding the OutOfProcessActivity, AllowedActivity, and LanguageMode members of the
    PSWorkflowConfigurationProvider class. The custom configuration is then passed as the
    configuration provider when the PSWorkflowRuntime is created. Finally, the runtime is used to
    invoke a sample workflow.

    For Windows PowerShell Workflow information on MSDN, see http://go.microsoft.com/fwlink/?LinkID=178145


Sample Objectives
=================
     This sample demonstrates the following:

     1. How to host the Windows PowerShell Workflow runtime in an application.
     2. How to create a custom configuration by overriding members of the
        PSWorkflowConfigurationProvider class.


Sample Language Implementations
===============================
     This sample is available in the following language implementations:

     - C#


Prerequisite Steps
==================
    Before building and running this sample, you need to configure the SQL server and Windows
    PowerShell Workflow database.

    Configure the Windows PowerShell Workflow database using the DatabaseSetup.cmd setup file
    included with the sample. This file requires the following SQL script files:
        1. SqlWorkflowInstanceStoreSchema.sql located at %windir%\Microsoft.NET\Framework\v4.xxx\SQL\en
        2. SqlWorkflowInstanceStoreLogic.sql  located at %window%\Microsoft.NET\Framework\v4.xxx\SQL\en
        3. PowerShellWorkflowExtendedStoreSetup.sql which is included with this sample
	
    Before executing DatabaseSetup.cmd, copy the SQL script files listed above to the same
    directory as DatabaseSetup.cmd.

    After executing DatabaseSetup.cmd, update the following variables in the Program.cs file included with
    the sample with the corresponding server and database information:
        string dbServer = "";
        string database = "";


Building the Sample Using Visual Studio
=======================================
     1. Open File Explorer and navigate to the SQLStoreExtensibilitySample directory under the samples directory.
     2. Double-click the icon for the .sln (solution) file to open the file in Visual Studio.
     3. In the Build menu, select Build Solution.
     4. The SQLStoreExtensibilitySample.exe file will be built in the \bin\Debug directory.


Running the Sample
==================
     1. Start a Command Prompt.
     2. Navigate to the folder containing the sample executable.
     3. Run the executable.
