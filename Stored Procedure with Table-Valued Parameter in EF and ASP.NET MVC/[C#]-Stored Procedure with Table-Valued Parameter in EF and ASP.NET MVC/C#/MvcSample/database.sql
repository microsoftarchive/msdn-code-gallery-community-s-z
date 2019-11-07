USE [Contacting]
GO

--- table to insert data to

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Contact](
	[ContactID] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](80) NOT NULL,
	[LastName] [nvarchar](80) NOT NULL,
	[Email] [nvarchar](80) NOT NULL,
	[Phone] [varchar](25) NULL,
	[Created] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[Contact] ADD  DEFAULT (getdate()) FOR [Created]
GO

--- table type for procedure
CREATE TYPE [dbo].[ContactStruct] AS TABLE(
	[ContactID] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](80) NOT NULL,
	[LastName] [nvarchar](80) NOT NULL,
	[Email] [nvarchar](80) NOT NULL,
	[Phone] [varchar](25) NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO

-- procedure tho save data from table value parameter
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertContacts]
	@contacts AS ContactStruct READONLY
AS
	INSERT INTO Contact(ContactID, FirstName, LastName, Email, Phone)
	SELECT ContactID, FirstName, LastName, Email, Phone FROM @contacts;
RETURN 0
GO
