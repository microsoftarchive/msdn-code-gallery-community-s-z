--
-- Check the path for were the database is being generated before running this script.
--
USE [master]
GO
/****** Object:  Database [CustomersForCodeSample]    Script Date: 12/17/2016 3:06:33 PM ******/
CREATE DATABASE [CustomersForCodeSample]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CustomersForCodeSample', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CustomersForCodeSample.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CustomersForCodeSample_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CustomersForCodeSample_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CustomersForCodeSample] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CustomersForCodeSample].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CustomersForCodeSample] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET ARITHABORT OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CustomersForCodeSample] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CustomersForCodeSample] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CustomersForCodeSample] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CustomersForCodeSample] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CustomersForCodeSample] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET RECOVERY FULL 
GO
ALTER DATABASE [CustomersForCodeSample] SET  MULTI_USER 
GO
ALTER DATABASE [CustomersForCodeSample] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CustomersForCodeSample] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CustomersForCodeSample] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CustomersForCodeSample] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CustomersForCodeSample]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/17/2016 3:06:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[StateIdentifer] [int] NULL,
	[CityIdentifier] [int] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([id], [FirstName], [LastName], [StateIdentifer], [CityIdentifier]) VALUES (1, N'Karen', N'Payne', 41, 47)
INSERT [dbo].[Customers] ([id], [FirstName], [LastName], [StateIdentifer], [CityIdentifier]) VALUES (2, N'Mary', N'Jone', 41, 46)
INSERT [dbo].[Customers] ([id], [FirstName], [LastName], [StateIdentifer], [CityIdentifier]) VALUES (3, N'Stefanie', N'Buckley', 20, 48)
INSERT [dbo].[Customers] ([id], [FirstName], [LastName], [StateIdentifer], [CityIdentifier]) VALUES (4, N'Lee', N'Warren', 32, 50)
INSERT [dbo].[Customers] ([id], [FirstName], [LastName], [StateIdentifer], [CityIdentifier]) VALUES (5, N'Regina', N'Forbes', 41, 51)
INSERT [dbo].[Customers] ([id], [FirstName], [LastName], [StateIdentifer], [CityIdentifier]) VALUES (6, N'Myra', N'Zuniga', 51, 52)
INSERT [dbo].[Customers] ([id], [FirstName], [LastName], [StateIdentifer], [CityIdentifier]) VALUES (7, N'Jane', N'Adams', 2, 9)
INSERT [dbo].[Customers] ([id], [FirstName], [LastName], [StateIdentifer], [CityIdentifier]) VALUES (8, N'Kathy', N'Jenkins', 3, 18)
SET IDENTITY_INSERT [dbo].[Customers] OFF
USE [master]
GO
ALTER DATABASE [CustomersForCodeSample] SET  READ_WRITE 
GO
