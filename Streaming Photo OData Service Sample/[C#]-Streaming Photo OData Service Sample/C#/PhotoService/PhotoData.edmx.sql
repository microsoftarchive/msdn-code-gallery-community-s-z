--//*********************************************************
--//
--//    Copyright (c) Microsoft. All rights reserved.
--//    This code is licensed under the Microsoft Public License.
--//    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
--//    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
--//    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
--//    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
--//
--//*********************************************************

SET NOCOUNT ON
GO
USE master
GO

--- Create the process for the IIS process.
IF EXISTS (SELECT * FROM sys.syslogins WHERE name='NT AUTHORITY\NETWORK SERVICE')
		DROP LOGIN [NT AUTHORITY\NETWORK SERVICE];
		
CREATE LOGIN [NT AUTHORITY\NETWORK SERVICE] FROM WINDOWS 
WITH DEFAULT_LANGUAGE=[us_english];
GO

IF NOT EXISTS (SELECT * FROM sys.sysdatabases WHERE Name = N'PhotoStorage')
BEGIN
	CREATE DATABASE [PhotoStorage] 
END
GO

SET QUOTED_IDENTIFIER OFF;
GO
USE [PhotoStorage];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PhotoInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].PhotoInfo;
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PhotoInfo'
CREATE TABLE [dbo].[PhotoInfo] (
    [PhotoId] int IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(max)  NOT NULL,
    [FileSize] int  NULL,
    [DateTaken] datetime  NULL,
    [TakenBy] nvarchar(max)  NULL,
    [DateAdded] datetime  NOT NULL,
    [Aperature] decimal(18,0)  NULL,
    [ShutterSpeed] smallint  NULL,
    [FilmSpeed] smallint  NULL,
    [Height] smallint  NULL,
    [Width] smallint  NULL,
	[Comments] nvarchar(max) NULL,
    [DateModified] datetime  NOT NULL,
	[ContentType] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PhotoId] in table 'PhotoInfoes'
ALTER TABLE [dbo].[PhotoInfo]
ADD CONSTRAINT [PK_PhotoInfo]
    PRIMARY KEY CLUSTERED ([PhotoId] ASC);
GO

-- --------------------------------------------------
-- Insert data into PhotoInfo
-- --------------------------------------------------

SET quoted_identifier ON
GO
SET identity_insert "PhotoInfo" ON
Go
ALTER TABLE "PhotoInfo" NOCHECK CONSTRAINT ALL
Go
INSERT "PhotoInfo" ("PhotoId", "FileName", "FileSize", "DateTaken", "Height", "Width", "DateAdded", "DateModified", "ContentType")
	VALUES (1, 'train1.jpg', 18006, '01-01-2010', 256, 192, GETDATE(), GETDATE(), 'image/jpeg')
INSERT "PhotoInfo" ("PhotoId", "FileName", "FileSize", "DateTaken", "Height", "Width", "DateAdded", "DateModified", "ContentType")
	VALUES (2, 'train2.jpg', 16125, '02-01-2010', 256, 192, GETDATE(), GETDATE(),'image/jpeg')
INSERT "PhotoInfo" ("PhotoId", "FileName", "FileSize", "DateTaken", "Height", "Width", "DateAdded", "DateModified", "ContentType")
	VALUES (3, 'train3.jpg', 15672, '03-01-2010', 256, 192, GETDATE(), GETDATE(), 'image/jpeg')
Go
ALTER TABLE "PhotoInfo" CHECK CONSTRAINT ALL
Go
SET identity_insert "PhotoInfo" OFF
Go

USE PhotoStorage
GO

-----------------------------------------------------------
--Create the user for the IIS process. 
-----------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.sysusers WHERE name = 'NT AUTHORITY\NETWORK SERVICE')
BEGIN
	CREATE USER [NT AUTHORITY\NETWORK SERVICE] 
	FOR LOGIN [NT AUTHORITY\NETWORK SERVICE] WITH DEFAULT_SCHEMA=[dbo];

	ALTER LOGIN [NT AUTHORITY\NETWORK SERVICE] 
	WITH DEFAULT_DATABASE=[PhotoStorage];

	EXEC sp_addrolemember 'db_datareader', 'NT AUTHORITY\NETWORK SERVICE'
	EXEC sp_addrolemember 'db_datawriter', 'NT AUTHORITY\NETWORK SERVICE'
END
GO
