USE [master]
GO
/****** Object:  Database [MasterDetailSimple]    Script Date: 2/2/2017 2:13:28 AM ******/
CREATE DATABASE [MasterDetailSimple]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MasterDetailSimple', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MasterDetailSimple.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MasterDetailSimple_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MasterDetailSimple_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MasterDetailSimple] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MasterDetailSimple].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MasterDetailSimple] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET ARITHABORT OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MasterDetailSimple] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MasterDetailSimple] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MasterDetailSimple] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MasterDetailSimple] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MasterDetailSimple] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET RECOVERY FULL 
GO
ALTER DATABASE [MasterDetailSimple] SET  MULTI_USER 
GO
ALTER DATABASE [MasterDetailSimple] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MasterDetailSimple] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MasterDetailSimple] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MasterDetailSimple] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [MasterDetailSimple]
GO
USE [MasterDetailSimple]
GO
/****** Object:  Sequence [dbo].[GetInvoiceNumber]    Script Date: 2/2/2017 2:13:28 AM ******/
CREATE SEQUENCE [dbo].[GetInvoiceNumber] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE 1
 MAXVALUE 999
 CYCLE 
 CACHE  10 
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/2/2017 2:13:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
	[AccountNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 2/2/2017 2:13:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductName] [nvarchar](max) NULL,
	[UnitPrice] [money] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2/2/2017 2:13:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[OrderDate] [datetime2](7) NULL,
	[Invoice] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StateLookup]    Script Date: 2/2/2017 2:13:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StateLookup](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](32) NULL,
	[StateAbbrev] [char](2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (1, N'Stefanie', N'Buckley', N'36 West Fabien St.', N'Lincoln', N'Kentucky', N'59898     ', N'AFG111')
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (2, N'Jane', N'Mc Gee', N'935 Nobel Way', N'Arlington', N'Iowa', N'47471     ', N'AFG222')
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (3, N'Lee', N'Warren', N'91 Hague Parkway', N'Newark', N'Indiana', N'51737     ', N'BBB555')
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (4, N'Regina', N'Forbes', N'50 Cowley Avenue', N'Sacramento', N'New York', N'66301     ', N'WWW465')
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (5, N'Dennis', N'Nunez', N'48 Old Freeway', N'San Diego', N'Washington', N'07170     ', N'QQQ111')
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (6, N'Myra', N'Zuniga', N'545 New Way', N'Anchorage', N'Delaware', N'43313     ', N'RRR276')
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (7, N'Annie', N'Larson', N'16 Nobel St.', N'Fresno', N'New Jersey', N'01497     ', N'AFG333')
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (8, N'Herman', N'Anderson', N'361 Milton Way', N'Raleigh', N'Colorado', N'55855     ', N'QGH395')
INSERT [dbo].[Customer] ([id], [FirstName], [LastName], [Address], [City], [State], [ZipCode], [AccountNumber]) VALUES (9, N'Karen', N'Payne', N'89 Center St', N'Salem', N'Oregon', N'97303', N'KPF156')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (1, 8, N'Survenentor', 25.4500, 12)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (2, 8, N'Groerar', 5.0000, 8)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (3, 8, N'Varrobefazz', 3.0000, 6)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (4, 8, N'Cipdimor', 12.9900, 15)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (5, 12, N'Trunipor', 8.3400, 6)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (6, 12, N'Lomkiladex', 20.9900, 14)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (7, 12, N'Admunan', 60.2500, 9)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (8, 12, N'Winsipin', 2.9900, 4)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (9, 12, N'Varfropentor', 34.9900, 4)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (10, 12, N'Adpickollor', 1.9900, 6)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (11, 10, N'Emvenepistor', 14.6700, 11)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (12, 10, N'Emtumor', 5.9900, 2)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (13, 10, N'Cippebar', 9.7800, 6)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (14, 5, N'Hapnipplor', 3.9900, 6)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (15, 5, N'Infropantor', 22.9900, 9)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (16, 5, N'Haprobonazz', 50.5000, 2)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (17, 15, N'Uppickexex', 9.9900, 15)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (18, 15, N'Emmunefower', 17.9900, 6)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (19, 15, N'Repickimover', 1.9900, 9)
INSERT [dbo].[OrderDetails] ([id], [OrderId], [ProductName], [UnitPrice], [Quantity]) VALUES (20, 15, N'Unmunicin', 34.9900, 7)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (1, 7, CAST(N'2017-06-20 06:27:56.8903722' AS DateTime2), N'5MRV12O1ZW9NRUEKQHZ9TKTC2W076BYAQ89')
INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (2, 5, CAST(N'2017-09-23 07:46:08.9850208' AS DateTime2), N'I16UG509VUVD0ZXP76X76OJ1Y2KEWQMU6OVPB')
INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (3, 5, CAST(N'2017-11-09 16:21:36.3880337' AS DateTime2), N'QQPU5VXH5VBW9X6KXW7V9K15Q0SDUBQTNDP')
INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (4, 4, CAST(N'2017-02-05 22:39:06.0165091' AS DateTime2), N'O69709G23LAYAIUBYR0JBSYGEV9V4XY8JI1C1H8F')
INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (5, 3, CAST(N'2016-11-09 04:38:44.0000000' AS DateTime2), N'A57MFIC505UR5JPCAC2W8G6DB0V510XBRI18SC1')
INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (6, 4, CAST(N'2016-05-09 23:09:48.8897971' AS DateTime2), N'A57MFIC505UR5JPCA9C2W8GDB0V510XBRI18SC2')
INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (8, 1, CAST(N'2017-05-22 02:43:22.0000000' AS DateTime2), N'A57MFIC505UR5JPCA9C2W8G6DB0V510XBRI18SC4')
INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (9, 8, CAST(N'2016-05-04 08:58:22.1809519' AS DateTime2), N'A57MFIC505UR5JPCA9C2W8G6DB0V510XBRI14Y79')
INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (10, 3, CAST(N'2017-10-26 22:41:39.4873726' AS DateTime2), N'W3T7NJYHQBMFKU0FK4XG5G6JE2MBKDJPOHFT44')
INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (11, 7, CAST(N'2017-03-23 00:01:58.0392311' AS DateTime2), N'BID4DEDN7OLS38FTO26H2VLKFQE6VB213H8KGLH')
INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (12, 1, CAST(N'2016-08-09 12:32:15.0000000' AS DateTime2), N'JZZ5OAG9HS4DUK408GVSI9O67SSJWCBW1GYBYQ')
INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (13, 1, CAST(N'2016-11-28 06:40:42.0000000' AS DateTime2), N'16110005')
INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (14, 6, CAST(N'2016-11-27 06:48:14.6600000' AS DateTime2), N'16110006')
INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (15, 3, CAST(N'2016-11-27 06:49:53.5130000' AS DateTime2), N'16110007')
INSERT [dbo].[Orders] ([id], [CustomerId], [OrderDate], [Invoice]) VALUES (16, 9, CAST(N'2016-12-03 09:35:39.5930000' AS DateTime2), N'16120001')
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[StateLookup] ON 

INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (1, N'Alabama', N'AL')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (2, N'Alaska', N'AK')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (3, N'Arizona', N'AZ')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (4, N'Arkansas', N'AR')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (5, N'California', N'CA')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (6, N'Colorado', N'CO')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (7, N'Connecticut', N'CT')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (8, N'Delaware', N'DE')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (9, N'District of Columbia', N'DC')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (10, N'Florida', N'FL')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (11, N'Georgia', N'GA')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (12, N'Hawaii', N'HI')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (13, N'Idaho', N'ID')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (14, N'Illinois', N'IL')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (15, N'Indiana', N'IN')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (16, N'Iowa', N'IA')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (17, N'Kansas', N'KS')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (18, N'Kentucky', N'KY')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (19, N'Louisiana', N'LA')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (20, N'Maine', N'ME')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (21, N'Maryland', N'MD')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (22, N'Massachusetts', N'MA')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (23, N'Michigan', N'MI')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (24, N'Minnesota', N'MN')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (25, N'Mississippi', N'MS')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (26, N'Missouri', N'MO')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (27, N'Montana', N'MT')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (28, N'Nebraska', N'NE')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (29, N'Nevada', N'NV')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (30, N'New Hampshire', N'NH')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (31, N'New Jersey', N'NJ')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (32, N'New Mexico', N'NM')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (33, N'New York', N'NY')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (34, N'North Carolina', N'NC')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (35, N'North Dakota', N'ND')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (36, N'Ohio', N'OH')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (37, N'Oklahoma', N'OK')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (38, N'Oregon', N'OR')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (39, N'Pennsylvania', N'PA')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (40, N'Rhode Island', N'RI')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (41, N'South Carolina', N'SC')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (42, N'South Dakota', N'SD')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (43, N'Tennessee', N'TN')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (44, N'Texas', N'TX')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (45, N'Utah', N'UT')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (46, N'Vermont', N'VT')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (47, N'Virginia', N'VA')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (48, N'Washington', N'WA')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (49, N'West Virginia', N'WV')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (50, N'Wisconsin', N'WI')
INSERT [dbo].[StateLookup] ([id], [StateName], [StateAbbrev]) VALUES (51, N'Wyoming', N'WY')
SET IDENTITY_INSERT [dbo].[StateLookup] OFF
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer]
GO
USE [master]
GO
ALTER DATABASE [MasterDetailSimple] SET  READ_WRITE 
GO
