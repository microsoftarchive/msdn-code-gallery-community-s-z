/*
	Script for creating two tables in a database for a code sample which shows 
	how to do conditionals in a trigger.

	In this case I created TriggerDemoOrderApproval database first then 
	execute this script. You can name the database as you see fit.
*/

-- CHANGE THIS TO YOUR DATABASE
USE TriggerDemoOrderApproval
GO

/* Drop and Recreate Table */
IF EXISTS(SELECT * FROM sys.sysobjects WHERE type = 'U' AND name = 'TestTable')
BEGIN
    DROP TABLE dbo.TestTable;
END
GO

CREATE TABLE dbo.TestTable(
    Id int IDENTITY(1,1) NOT NULL,
	CompanyName NVARCHAR(MAX),
    FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,	
	OrderDate DATETIME NULL,
	OrderApprovalDateTime DATETIME NULL,
	OrderStatus VARCHAR(20) NULL,
	PRIMARY KEY CLUSTERED 
(
	Id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/* Drop and Recreate Table */
IF EXISTS(SELECT * FROM sys.sysobjects WHERE type = 'U' AND name = 'OrderStatus')
BEGIN
    DROP TABLE dbo.OrderStatus;
END
GO

CREATE TABLE dbo.OrderStatus(
	id INT IDENTITY(1,1) NOT NULL,
	Status NVARCHAR(MAX) NULL,
 CONSTRAINT PK_OrderStatus PRIMARY KEY CLUSTERED 
(
	id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/* Add rows */
INSERT INTO dbo.TestTable  (CompanyName,FirstName , LastName, OrderDate, OrderStatus)
VALUES  
	('Fast Miata', 'Karen' , 'Payne' , '20160101 08:34:09 AM' , 'Placed' ), 
	('Best Little Coffee shop', 'Bill' , 'Gallagher' , '20160101 11:12:00 AM' , 'Placed' ),
	('Guitar''s are us', 'Sean' , 'Hills' , '20160101 09:11:06 AM' , 'Placed' ),
	('Mary''s cartering service', 'Mary' , 'Adams' , '20160102 11:24:34 AM' , 'Placed' ) ,
	('ZZZ Inc', 'Frank' , 'Jenkins' , '20160102 13:10:00 PM' , 'Placed' ) 


INSERT INTO dbo.OrderStatus  ( Status )
VALUES ( N'Approved' ),	( N'Pending' ),	( N'Hold' ),( N'Denied'),( N'Placed'),( N'Unknown')

/* Drop and Recreate Trigger */
IF EXISTS(SELECT * FROM sys.sysobjects WHERE type = 'TR' AND name = 'trTriggerApprovalDate')
BEGIN
    DROP TRIGGER dbo.trTriggerApprovalDate;
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Description:	Sets OrderApprovalDateTime to the current date-time when
--				OrderStatus is et to Approved
-- =============================================
CREATE TRIGGER trTriggerApprovalDate ON dbo.TestTable
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.TestTable SET OrderApprovalDateTime =  
		(
			CASE WHEN 
				t.OrderStatus = 'Approved' THEN GETDATE() 
			ELSE 
				NULL 
			END)
	FROM  dbo.TestTable AS t 
	INNER JOIN inserted i ON t.ID=i.ID AND i.OrderStatus='Approved'
END

GO

/* 
	Do updates, invoke our trigger if you want to start with 
	various statuses, otherwise in the demo app set them.
*/
--UPDATE dbo.TestTable SET OrderStatus = 'Approved' WHERE Id = 1
--UPDATE dbo.TestTable SET OrderStatus = 'Pending' WHERE Id = 2
--UPDATE dbo.TestTable SET OrderStatus = 'Hold' WHERE Id = 3
--UPDATE dbo.TestTable SET OrderStatus = 'Approved' WHERE Id = 4
--UPDATE dbo.TestTable SET OrderStatus = 'Denied' WHERE Id = 5

/* Show our data */
SELECT 
	Id,
	CompanyName,
	CONCAT(FirstName,' ',LastName) AS Contact,
	FORMAT(CAST(OrderDate AS DATETIME),'MM/dd/yyyy hh:mm tt') AS Ordered,
	FORMAT(CAST(OrderApprovalDateTime AS DATETIME),'MM/dd/yyyy hh:mm tt') AS OrderApprovalDateTime,
	OrderStatus  
FROM TestTable

SELECT 
	id , 
	[Status]
FROM dbo.OrderStatus
