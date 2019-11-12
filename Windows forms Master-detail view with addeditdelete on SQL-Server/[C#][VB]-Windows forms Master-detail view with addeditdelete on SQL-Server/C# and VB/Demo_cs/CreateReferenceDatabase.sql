--
-- Check the path for were the database is being generated before running this script.
--
USE [master]
GO
/****** Object:  Database [CityStateReferences]    Script Date: 12/17/2016 3:04:32 PM ******/
CREATE DATABASE [CityStateReferences]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CityStateReferences', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CityStateReferences.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CityStateReferences_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CityStateReferences_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CityStateReferences] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CityStateReferences].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CityStateReferences] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CityStateReferences] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CityStateReferences] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CityStateReferences] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CityStateReferences] SET ARITHABORT OFF 
GO
ALTER DATABASE [CityStateReferences] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CityStateReferences] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CityStateReferences] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CityStateReferences] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CityStateReferences] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CityStateReferences] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CityStateReferences] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CityStateReferences] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CityStateReferences] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CityStateReferences] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CityStateReferences] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CityStateReferences] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CityStateReferences] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CityStateReferences] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CityStateReferences] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CityStateReferences] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CityStateReferences] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CityStateReferences] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CityStateReferences] SET RECOVERY FULL 
GO
ALTER DATABASE [CityStateReferences] SET  MULTI_USER 
GO
ALTER DATABASE [CityStateReferences] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CityStateReferences] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CityStateReferences] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CityStateReferences] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CityStateReferences]
GO
/****** Object:  Table [dbo].[US_Cities]    Script Date: 12/17/2016 3:04:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[US_Cities](
	[CityIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[StateIdentifier] [int] NULL,
	[CityName] [nvarchar](max) NULL,
 CONSTRAINT [PK_US_Cities] PRIMARY KEY CLUSTERED 
(
	[CityIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[US_States]    Script Date: 12/17/2016 3:04:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[US_States](
	[StateIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Abbreviation] [nvarchar](max) NULL,
 CONSTRAINT [PK_US_States] PRIMARY KEY CLUSTERED 
(
	[StateIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[US_Cities] ON 

INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (1, 1, N'Adamsville')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (2, 1, N'Blountsville')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (3, 1, N'Clio')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (4, 1, N'Dayton')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (5, 1, N'Fulton')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (6, 1, N'Greensboro')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (7, 1, N'Hayden')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (8, 1, N'Kansas')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (9, 2, N'Anchorage')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (10, 2, N'Fairbanks')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (11, 2, N'Kodiak')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (12, 2, N'Bethel')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (13, 2, N'Palmer')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (14, 2, N'Homer')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (15, 2, N'Nome')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (16, 2, N'Kotzebue')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (17, 3, N'Apache Junction')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (18, 3, N'Bullhead City')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (19, 3, N'Patagonia')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (20, 4, N'Scottsdale')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (21, 4, N'South Tucson')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (22, 4, N'Little Rock')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (23, 4, N'Fayetteville')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (24, 4, N'Siloam Springs')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (25, 5, N'Farmington')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (26, 5, N'Barstow')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (27, 6, N'California City')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (28, 6, N'Burbank')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (29, 6, N'Cloverdale')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (30, 6, N'Culver City')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (31, 6, N'Folsom')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (32, 6, N'Huntington Beach')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (33, 6, N'Los Angeles')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (34, 6, N'Malibu')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (35, 6, N'Murrieta')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (36, 6, N'Oakdale')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (37, 6, N'Palo Alto')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (38, 6, N'Black Hawk')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (39, 7, N'Brighton')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (40, 7, N'Castle Rock')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (41, 7, N'Coal Creek')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (42, 7, N'Garden City')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (43, 7, N'Glendale')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (44, 7, N'Kiowa')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (45, 7, N'Limon')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (46, 41, N'Salem')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (47, 41, N'Portland')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (48, 20, N'Adairville')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (49, 20, N'Bonnieville')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (50, 32, N'Lincoln')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (51, 41, N'Albany')
INSERT [dbo].[US_Cities] ([CityIdentifier], [StateIdentifier], [CityName]) VALUES (52, 51, N'Richmond')
SET IDENTITY_INSERT [dbo].[US_Cities] OFF
SET IDENTITY_INSERT [dbo].[US_States] ON 

INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (1, N'Alabama', N'AL')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (2, N'Alaska', N'AK')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (3, N'American Samoa', N'AS')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (4, N'Arizona', N'AZ')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (5, N'Arkansas', N'AR')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (6, N'California', N'CA')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (7, N'Colorado', N'CO')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (8, N'Connecticut', N'CT')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (9, N'Delaware', N'DE')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (10, N'Dist. of Columbia', N'DC')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (11, N'Florida', N'FL')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (12, N'Georgia', N'GA')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (13, N'Guam', N'GU')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (14, N'Hawaii', N'HI')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (15, N'Idaho', N'ID')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (16, N'Illinois', N'IL')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (17, N'Indiana', N'IN')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (18, N'Iowa', N'IA')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (19, N'Kansas', N'KS')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (20, N'Kentucky', N'KY')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (21, N'Louisiana', N'LA')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (22, N'Maine', N'ME')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (23, N'Maryland', N'MD')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (24, N'Marshall Islands', N'MH')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (25, N'Massachusetts', N'MA')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (26, N'Michigan', N'MI')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (27, N'Micronesia', N'FM')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (28, N'Minnesota', N'MN')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (29, N'Mississippi', N'MS')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (30, N'Missouri', N'MO')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (31, N'Montana', N'MT')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (32, N'Nebraska', N'NE')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (33, N'New Hampshire', N'NH')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (34, N'New Jersey', N'NJ')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (35, N'New Mexico', N'NM')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (36, N'New York', N'NY')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (37, N'North Carolina', N'NC')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (38, N'North Dakota', N'ND')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (39, N'Ohio', N'OH')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (40, N'Oklahoma', N'OK')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (41, N'Oregon', N'OR')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (42, N'Pennsylvania', N'PA')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (43, N'Puerto Rico', N'PR')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (44, N'Rhode Island', N'RI')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (45, N'South Carolina', N'SC')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (46, N'South Dakota', N'SD')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (47, N'Tennessee', N'TN')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (48, N'Texas', N'TX')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (49, N'Utah', N'UT')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (50, N'Vermont', N'VT')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (51, N'Virginia', N'VA')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (52, N'Virgin Islands', N'VI')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (53, N'Washington', N'WA')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (54, N'West Virginia', N'WV')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (55, N'Wisconsin', N'WI')
INSERT [dbo].[US_States] ([StateIdentifier], [Name], [Abbreviation]) VALUES (56, N'Wyoming', N'WI')
SET IDENTITY_INSERT [dbo].[US_States] OFF
USE [master]
GO
ALTER DATABASE [CityStateReferences] SET  READ_WRITE 
GO
