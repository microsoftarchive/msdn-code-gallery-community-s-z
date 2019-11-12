rem
rem  Copyright (c) 2012 Microsoft Corporation.  All rights reserved.
rem  
rem DISCLAIMER OF WARRANTY: The software is licensed "as-is." You 
rem bear the risk of using it. Microsoft gives no express warranties, 
rem guarantees or conditions. You may have additional consumer rights 
rem under your local laws which this agreement cannot change. To the extent 
rem permitted under your local laws, Microsoft excludes the implied warranties 
rem of merchantability, fitness for a particular purpose and non-infringement.
rem

@echo OFF
@if not "%ECHO%"== "" echo %ECHO%

if "%1%" == "" (
   echo Usage: databaseSetup [servername] [dbname] [user [password]]
   goto :EOF
) else set ServerName=%1

if "%1%" == "/?" (
   echo Usage: databaseSetup [servername] [dbname] [user [password]]
   goto :EOF
)

if "%2%" == "" (
   echo INFO: DBName not specified in commandline. Using default name 'PowerShellWorkflowExtendedStore'
   set DBName=PowerShellWorkflowExtendedStore
) else set DBName=%2

if "%3%" == "" (
   echo INFO: User not specified in commandline. Using current user.
) else (
set User=%3
set Password=%4
)

set scriptDir=%~dp0
set PowerShellWorkflowExtendedStoreSchema=%scriptDir%\PowerShellWorkflowExtendedStoreSetup.sql
set SqlWorkflowInstanceStoreSchema=%scriptDir%\SqlWorkflowInstanceStoreSchema.sql
set SqlWorkflowInstanceStoreLogic=%scriptDir%\SqlWorkflowInstanceStoreLogic.sql

if not exist %PowerShellWorkflowExtendedStoreSchema% (
        echo ERROR: File %PowerShellWorkflowExtendedStoreSchema% not found.
        goto: EOF
)

set DbSetupLog=%temp%\databaseSetup_%random%.log

set connection=-S %ServerName%

if "%User%" NEQ "" (
set connection=%connection% -U %User% -P %Password% -N -C
)

echo INFO: Dropping database if it exists...
sqlcmd %connection% -d master -Q "IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'%DBName%') ALTER DATABASE [%DBName%] SET SINGLE_USER WITH ROLLBACK IMMEDIATE" -b -o %DbSetupLog%
sqlcmd %connection% -d master -Q "DROP DATABASE [%DBName%]" -b -o %DbSetupLog%

echo INFO: Creating database...
sqlcmd %connection% -d master -Q "CREATE DATABASE [%DBName%]" -b -o %DbSetupLog% 
if not errorlevel 1 goto PREPAREDB
echo ERROR: An error occurred creating database. Review %DBSetupLog% for details.
goto :ONERROR

:PREPAREDB
set dbconnection=%connection% -d %DBName%

:INSTALLWFINSTANCESCHEMA
echo INFO: Installing SQL Workflow Instance schema...
sqlcmd %dbconnection% -i "%SqlWorkflowInstanceStoreSchema%" -b  -o %DbSetupLog%
if errorlevel 1 goto ONWFINSTANCESCHEMAERROR
sqlcmd %dbconnection% -i "%SqlWorkflowInstanceStoreLogic%" -b  -o %DbSetupLog% 
if errorlevel 1 goto ONWFINSTANCESCHEMAERROR
goto INSTALLSCHEMA
:ONWFINSTANCESCHEMAERROR
echo ERROR: An error occurred installing SQL Workflow Instance schema. Review %DBSetupLog% for details.
goto :ONERROR

:INSTALLSCHEMA
echo INFO: Installing PowerShellWorkflowExtendedStore schema...
sqlcmd %dbconnection% -i "%PowerShellWorkflowExtendedStoreSchema%" -b -o %DbSetupLog% 
if not errorlevel 1 goto eof
echo ERROR: An error occurred installing schema. Review %DBSetupLog% for details.
goto :ONERROR

:ONERROR
echo INFO: Error occurred during setup. Dropping database if it was created...
sqlcmd %connection% -d master -Q "DROP DATABASE [%DBName%]" -b

:EOF
