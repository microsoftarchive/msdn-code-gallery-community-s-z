USE [master]
GO
/****** Object:  Database [ApplicationProductionData]    Script Date: 11/26/2017 8:27:10 AM ******/
CREATE DATABASE [ApplicationProductionData]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ApplicationProductionData', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ApplicationProductionData.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ApplicationProductionData_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ApplicationProductionData_log.ldf' , SIZE = 2560KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ApplicationProductionData] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ApplicationProductionData].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ApplicationProductionData] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET ARITHABORT OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ApplicationProductionData] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ApplicationProductionData] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ApplicationProductionData] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ApplicationProductionData] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ApplicationProductionData] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET RECOVERY FULL 
GO
ALTER DATABASE [ApplicationProductionData] SET  MULTI_USER 
GO
ALTER DATABASE [ApplicationProductionData] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ApplicationProductionData] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ApplicationProductionData] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ApplicationProductionData] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ApplicationProductionData]
GO
/****** Object:  Table [dbo].[People]    Script Date: 11/26/2017 8:27:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Gender] [int] NULL,
	[BirthDay] [datetime2](7) NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[People] ON 

GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1, N'Ralph', N'Cross', 1, CAST(N'1997-11-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (2, N'Kent', N'Choi', 2, CAST(N'2007-07-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (3, N'Xavier', N'Beard', 2, CAST(N'1984-01-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (4, N'Jorge', N'Edwards', 3, CAST(N'1975-08-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (5, N'Greg', N'Higgins', 2, CAST(N'1953-08-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (6, N'Tricia', N'Tanner', 2, CAST(N'1955-12-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (7, N'Marlon', N'Campbell', 1, CAST(N'1991-05-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (8, N'Cara', N'Downs', 2, CAST(N'1977-09-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (9, N'Teresa', N'Tapia', 2, CAST(N'1978-12-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (10, N'Charlotte', N'Blevins', 2, CAST(N'1994-03-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (11, N'Angelica', N'Ayala', 2, CAST(N'1966-02-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (12, N'Alfred', N'Petty', 2, CAST(N'1985-06-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (13, N'Lea', N'Wise', 2, CAST(N'1974-01-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (14, N'Curtis', N'Alexander', 1, CAST(N'1983-04-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (15, N'Kelli', N'Stuart', 2, CAST(N'1996-01-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (16, N'Cornelius', N'Manning', 2, CAST(N'1982-01-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (17, N'Dawn', N'Pineda', 2, CAST(N'1982-11-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (18, N'Noah', N'Dominguez', 2, CAST(N'1979-02-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (19, N'Ramiro', N'Benjamin', 2, CAST(N'1996-03-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (20, N'Rebecca', N'Clark', 2, CAST(N'2000-06-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (21, N'Roland', N'Moon', 1, CAST(N'1972-02-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (22, N'Chastity', N'Copeland', 2, CAST(N'1998-08-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (23, N'Melissa', N'Herrera', 2, CAST(N'1989-09-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (24, N'Betsy', N'Gibbs', 2, CAST(N'1976-08-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (25, N'Eduardo', N'O''Connor', 2, CAST(N'1958-01-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (26, N'Toby', N'Perez', 1, CAST(N'1958-06-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (27, N'Ruby', N'Odom', 2, CAST(N'1973-07-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (28, N'Timmy', N'Clark', 2, CAST(N'1962-02-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (29, N'Adriana', N'Conner', 2, CAST(N'1988-11-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (30, N'Donnie', N'Conway', 2, CAST(N'1969-08-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (31, N'Clifton', N'Buckley', 1, CAST(N'1989-07-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (32, N'Donna', N'Ortega', 2, CAST(N'1980-11-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (33, N'Anita', N'Ramos', 2, CAST(N'2002-10-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (34, N'Lydia', N'Boyd', 2, CAST(N'1957-11-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (35, N'Kristi', N'Foster', 2, CAST(N'1955-03-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (36, N'Lonnie', N'Bailey', 2, CAST(N'2004-06-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (37, N'Walter', N'Bautista', 2, CAST(N'1971-11-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (38, N'Catherine', N'Gordon', 2, CAST(N'1958-11-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (39, N'Julius', N'Bryan', 2, CAST(N'1954-07-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (40, N'Trenton', N'Petty', 2, CAST(N'1965-07-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (41, N'Ivan', N'Estes', 2, CAST(N'1998-07-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (42, N'Tyler', N'Beard', 2, CAST(N'1975-06-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (43, N'Edward', N'Ford', 2, CAST(N'1992-12-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (44, N'Yvette', N'Bailey', 2, CAST(N'1953-11-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (45, N'Bobby', N'Christian', 2, CAST(N'1970-06-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (46, N'Simon', N'Travis', 1, CAST(N'1991-05-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (47, N'Tyler', N'Conway', 2, CAST(N'1981-08-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (48, N'Priscilla', N'Monroe', 2, CAST(N'1982-07-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (49, N'Lorenzo', N'Potts', 2, CAST(N'1994-04-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (50, N'Jennie', N'Crawford', 2, CAST(N'2001-02-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (51, N'Levi', N'Wheeler', 1, CAST(N'1981-09-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (52, N'Taryn', N'Woodward', 2, CAST(N'1981-12-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (53, N'Dominick', N'Dickson', 2, CAST(N'2007-10-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (54, N'Kristin', N'York', 2, CAST(N'2007-04-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (55, N'Tracey', N'Mc Mahon', 2, CAST(N'1970-10-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (56, N'Steve', N'Jacobson', 2, CAST(N'1960-05-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (57, N'Shari', N'Gardner', 2, CAST(N'1970-08-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (58, N'Philip', N'Khan', 1, CAST(N'2003-03-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (59, N'Anita', N'Wolfe', 2, CAST(N'1990-06-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (60, N'Dustin', N'Knox', 2, CAST(N'1982-04-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (61, N'Stefanie', N'Jackson', 2, CAST(N'1996-11-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (62, N'Kareem', N'Kramer', 2, CAST(N'1962-05-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (63, N'Cody', N'Marshall', 1, CAST(N'1957-09-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (64, N'Marcella', N'Price', 2, CAST(N'1993-04-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (65, N'Sonya', N'Wagner', 2, CAST(N'1990-08-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (66, N'Miriam', N'Hahn', 2, CAST(N'1969-02-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (67, N'Esther', N'Curtis', 2, CAST(N'1981-02-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (68, N'Kendall', N'Clark', 1, CAST(N'1999-07-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (69, N'Alicia', N'Pugh', 2, CAST(N'1963-02-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (70, N'Greg', N'Pittman', 2, CAST(N'1977-01-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (71, N'Anna', N'Wiley', 2, CAST(N'1977-08-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (72, N'Jana', N'Mahoney', 2, CAST(N'1983-08-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (73, N'Joanne', N'Baird', 2, CAST(N'1968-10-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (74, N'Milton', N'Crawford', 2, CAST(N'1981-08-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (75, N'Raul', N'Long', 2, CAST(N'1976-03-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (76, N'Quentin', N'Hammond', 2, CAST(N'2004-10-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (77, N'Melinda', N'Mccarty', 2, CAST(N'1995-08-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (78, N'Damian', N'Wolf', 1, CAST(N'1975-01-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (79, N'Mathew', N'Lowe', 1, CAST(N'1999-12-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (80, N'Julio', N'Dennis', 1, CAST(N'1987-07-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (81, N'Dustin', N'Castro', 2, CAST(N'2002-08-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (82, N'Kareem', N'Neal', 2, CAST(N'1976-07-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (83, N'Desiree', N'Mc Bride', 2, CAST(N'1960-10-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (84, N'Quentin', N'Novak', 1, CAST(N'2006-11-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (85, N'Marisol', N'Allison', 2, CAST(N'1986-02-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (86, N'Dorothy', N'Elliott', 2, CAST(N'1958-02-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (87, N'Dante', N'Monroe', 2, CAST(N'1955-11-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (88, N'Luz', N'Bowman', 2, CAST(N'1986-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (89, N'Duane', N'Griffith', 2, CAST(N'1964-07-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (90, N'Lindsey', N'Russo', 2, CAST(N'1996-04-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (91, N'Lorraine', N'Norton', 2, CAST(N'1959-05-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (92, N'Rickey', N'Armstrong', 2, CAST(N'1983-02-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (93, N'Jenny', N'Krueger', 2, CAST(N'1954-08-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (94, N'Mia', N'Arnold', 2, CAST(N'1966-01-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (95, N'Rita', N'Cooke', 2, CAST(N'1988-04-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (96, N'Luis', N'Cooley', 1, CAST(N'1968-08-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (97, N'Derick', N'Ingram', 1, CAST(N'1987-10-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (98, N'Steven', N'Tucker', 2, CAST(N'1975-03-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (99, N'Glenda', N'Wang', 2, CAST(N'1953-06-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (100, N'Bridgette', N'Bryan', 2, CAST(N'1991-01-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (101, N'Marcie', N'Hernandez', 2, CAST(N'1984-02-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (102, N'Victoria', N'Pittman', 2, CAST(N'1977-02-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (103, N'Gene', N'Combs', 1, CAST(N'1957-02-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (104, N'Jarrod', N'James', 1, CAST(N'1953-11-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (105, N'Chadwick', N'Schaefer', 1, CAST(N'1979-02-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (106, N'Bryce', N'Bradshaw', 2, CAST(N'1984-01-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (107, N'Dale', N'Stokes', 1, CAST(N'1973-12-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (108, N'Jessie', N'Swanson', 2, CAST(N'1992-08-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (109, N'Alvin', N'Boone', 2, CAST(N'1982-12-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (110, N'Patrick', N'Santiago', 1, CAST(N'1981-02-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (111, N'Jimmie', N'Carr', 2, CAST(N'1998-07-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (112, N'Rodney', N'Walker', 2, CAST(N'2002-09-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (113, N'Leticia', N'Wolfe', 2, CAST(N'2002-04-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (114, N'Walter', N'Raymond', 1, CAST(N'1993-10-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (115, N'Maribel', N'Freeman', 2, CAST(N'2004-11-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (116, N'Leonardo', N'Delacruz', 2, CAST(N'1994-05-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (117, N'Margarita', N'Dunn', 2, CAST(N'1957-06-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (118, N'Lewis', N'Davenport', 1, CAST(N'1964-01-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (119, N'Nichole', N'Boyer', 2, CAST(N'1978-03-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (120, N'Lynn', N'Barrera', 2, CAST(N'1965-10-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (121, N'Carrie', N'Ellison', 2, CAST(N'2006-08-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (122, N'Vicki', N'Ingram', 2, CAST(N'1988-09-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (123, N'Megan', N'Spence', 2, CAST(N'1971-04-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (124, N'Micah', N'Rose', 2, CAST(N'1953-07-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (125, N'Javier', N'Charles', 2, CAST(N'1966-05-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (126, N'Misty', N'Solomon', 2, CAST(N'1980-01-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (127, N'Lonnie', N'Pena', 2, CAST(N'1963-02-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (128, N'Annette', N'Costa', 2, CAST(N'1969-07-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (129, N'Chrystal', N'Carrillo', 2, CAST(N'1960-02-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (130, N'Tracey', N'Mc Donald', 2, CAST(N'1960-10-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (131, N'Rolando', N'Hubbard', 1, CAST(N'2007-10-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (132, N'Gail', N'Sandoval', 2, CAST(N'1999-06-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (133, N'Rachelle', N'Horne', 2, CAST(N'2004-07-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (134, N'Edward', N'Sampson', 2, CAST(N'1971-07-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (135, N'Terry', N'Weaver', 2, CAST(N'2007-06-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (136, N'Emma', N'Mccall', 2, CAST(N'1956-09-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (137, N'Chandra', N'Levine', 2, CAST(N'1953-07-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (138, N'Jennifer', N'Mc Mahon', 2, CAST(N'1985-04-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (139, N'Kent', N'Mc Mahon', 1, CAST(N'1987-01-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (140, N'Bernard', N'Gill', 1, CAST(N'1979-11-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (141, N'Janette', N'Nguyen', 2, CAST(N'1965-10-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (142, N'Pedro', N'Coffey', 2, CAST(N'1979-12-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (143, N'Kent', N'Noble', 2, CAST(N'1966-04-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (144, N'Tonia', N'Miles', 2, CAST(N'1986-03-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (145, N'Charlotte', N'Williamson', 2, CAST(N'1992-07-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (146, N'Timmy', N'Medina', 2, CAST(N'1960-09-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (147, N'Jonathan', N'Moyer', 1, CAST(N'1960-05-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (148, N'Gregory', N'Baker', 2, CAST(N'1980-04-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (149, N'Randolph', N'Phillips', 2, CAST(N'1991-06-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (150, N'Alma', N'Michael', 2, CAST(N'1983-04-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (151, N'Laurie', N'Brandt', 2, CAST(N'1964-03-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (152, N'Carlton', N'Burnett', 2, CAST(N'1983-04-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (153, N'Kellie', N'Meadows', 2, CAST(N'1978-04-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (154, N'Lawanda', N'Galvan', 2, CAST(N'1985-06-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (155, N'Dean', N'Roberson', 2, CAST(N'1996-05-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (156, N'Bridgette', N'Russo', 2, CAST(N'1993-10-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (157, N'Todd', N'Paul', 2, CAST(N'2005-10-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (158, N'Sheldon', N'Yates', 2, CAST(N'1995-06-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (159, N'Marisa', N'Carter', 2, CAST(N'2007-02-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (160, N'Caroline', N'Bauer', 2, CAST(N'1973-12-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (161, N'Gary', N'Garrison', 2, CAST(N'1957-06-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (162, N'Jolene', N'Baird', 2, CAST(N'1985-06-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (163, N'Stephanie', N'De Leon', 2, CAST(N'1975-03-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (164, N'Cherie', N'Haley', 2, CAST(N'1981-05-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (165, N'Andrea', N'Odom', 2, CAST(N'2007-02-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (166, N'Gustavo', N'Dixon', 2, CAST(N'2006-03-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (167, N'Penny', N'Mc Bride', 2, CAST(N'1983-10-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (168, N'Zachary', N'Salas', 1, CAST(N'1994-05-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (169, N'Adriana', N'Luna', 2, CAST(N'2001-02-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (170, N'Tracie', N'Villanueva', 2, CAST(N'1993-10-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (171, N'Elias', N'Cortez', 2, CAST(N'1980-03-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (172, N'Kristine', N'Rocha', 2, CAST(N'1985-01-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (173, N'Milton', N'Grant', 1, CAST(N'2006-05-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (174, N'Jessie', N'Humphrey', 2, CAST(N'1953-01-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (175, N'Adrienne', N'Bernard', 2, CAST(N'1979-09-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (176, N'Sara', N'Ibarra', 2, CAST(N'1975-06-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (177, N'Annette', N'Bruce', 2, CAST(N'1993-01-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (178, N'Tracy', N'Bray', 2, CAST(N'1968-12-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (179, N'Leanne', N'Walton', 2, CAST(N'1958-09-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (180, N'Cassie', N'Moses', 2, CAST(N'1972-08-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (181, N'Colin', N'Mckay', 2, CAST(N'1986-02-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (182, N'Jon', N'Diaz', 2, CAST(N'1985-11-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (183, N'Israel', N'Schwartz', 1, CAST(N'1985-06-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (184, N'David', N'Calderon', 1, CAST(N'1996-08-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (185, N'Roman', N'Buckley', 1, CAST(N'1969-03-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (186, N'Rachael', N'Jimenez', 2, CAST(N'1979-03-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (187, N'Milton', N'Morris', 2, CAST(N'1994-01-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (188, N'Andrea', N'Mathews', 2, CAST(N'1964-02-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (189, N'Kris', N'Griffin', 2, CAST(N'1970-11-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (190, N'Katrina', N'Ochoa', 2, CAST(N'1955-09-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (191, N'Allison', N'Norris', 2, CAST(N'1997-11-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (192, N'Carmen', N'Buckley', 2, CAST(N'1987-11-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (193, N'Vivian', N'Riggs', 2, CAST(N'1958-12-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (194, N'Rodolfo', N'Ingram', 1, CAST(N'1961-04-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (195, N'Shannon', N'Huerta', 2, CAST(N'2002-06-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (196, N'Joni', N'Parks', 2, CAST(N'1999-02-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (197, N'Sergio', N'Mc Cormick', 1, CAST(N'1957-10-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (198, N'Gerald', N'Bates', 2, CAST(N'1993-06-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (199, N'Jesus', N'White', 2, CAST(N'1962-07-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (200, N'Audrey', N'Ramsey', 2, CAST(N'1984-08-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (201, N'Cameron', N'Rojas', 1, CAST(N'1993-11-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (202, N'Serena', N'Ware', 2, CAST(N'1998-04-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (203, N'Sammy', N'Macias', 1, CAST(N'1996-06-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (204, N'Darin', N'Hodges', 1, CAST(N'1956-02-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (205, N'Ashley', N'Freeman', 2, CAST(N'1987-03-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (206, N'Roderick', N'Mc Daniel', 1, CAST(N'1984-12-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (207, N'Christie', N'Kelly', 2, CAST(N'1978-03-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (208, N'Gloria', N'Levine', 2, CAST(N'1958-10-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (209, N'Staci', N'Bonilla', 2, CAST(N'1973-11-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (210, N'Stacey', N'Morgan', 1, CAST(N'1953-09-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (211, N'Dora', N'Moody', 2, CAST(N'1989-11-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (212, N'Juan', N'Bennett', 2, CAST(N'1989-09-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (213, N'Joseph', N'Spencer', 2, CAST(N'1987-06-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (214, N'Clarence', N'Franklin', 1, CAST(N'1991-01-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (215, N'Doris', N'Knapp', 2, CAST(N'1979-05-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (216, N'Chasity', N'Frye', 2, CAST(N'2007-08-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (217, N'Brandon', N'Harrison', 1, CAST(N'1997-09-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (218, N'Luis', N'Fleming', 2, CAST(N'1992-09-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (219, N'Richard', N'Daniels', 2, CAST(N'1990-12-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (220, N'Patrick', N'Rodriguez', 2, CAST(N'1979-12-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (221, N'Denise', N'Tate', 3, CAST(N'1997-09-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (222, N'Daryl', N'King', 1, CAST(N'1983-04-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (223, N'Cameron', N'Fields', 3, CAST(N'1983-03-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (224, N'George', N'Daniels', 2, CAST(N'1987-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (225, N'Anthony', N'Ramirez', 2, CAST(N'1991-01-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (226, N'Kristie', N'Williamson', 2, CAST(N'2005-02-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (227, N'Rosemary', N'Lane', 2, CAST(N'2000-06-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (228, N'Ginger', N'Arellano', 2, CAST(N'1999-09-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (229, N'Joanna', N'Hale', 2, CAST(N'1985-03-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (230, N'Bradley', N'Cline', 1, CAST(N'1988-04-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (231, N'Randi', N'Rojas', 2, CAST(N'1983-07-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (232, N'Nicole', N'Mc Guire', 2, CAST(N'2004-03-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (233, N'Freddie', N'Finley', 1, CAST(N'1995-12-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (234, N'Kathy', N'Kelley', 2, CAST(N'2004-12-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (235, N'Ralph', N'Burgess', 2, CAST(N'1995-10-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (236, N'Melinda', N'Waller', 2, CAST(N'1997-05-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (237, N'Christie', N'Curry', 2, CAST(N'1982-05-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (238, N'Alicia', N'Barton', 2, CAST(N'1962-06-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (239, N'Sarah', N'Gray', 2, CAST(N'1992-03-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (240, N'Anitra', N'Wells', 2, CAST(N'1954-01-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (241, N'Greg', N'Hurst', 1, CAST(N'1988-03-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (242, N'Tamiko', N'Collins', 2, CAST(N'1998-03-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (243, N'Heath', N'Roberts', 1, CAST(N'1970-03-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (244, N'Sonja', N'Howell', 2, CAST(N'1973-11-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (245, N'Marci', N'Richard', 2, CAST(N'1961-02-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (246, N'Esmeralda', N'Lester', 2, CAST(N'1953-06-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (247, N'Adriana', N'Vance', 2, CAST(N'1975-11-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (248, N'Mitchell', N'Butler', 2, CAST(N'1989-12-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (249, N'Courtney', N'Castro', 2, CAST(N'2002-11-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (250, N'Sara', N'Hunt', 2, CAST(N'1954-05-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (251, N'Camille', N'Wallace', 2, CAST(N'1973-01-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (252, N'Rebecca', N'Anderson', 2, CAST(N'1955-07-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (253, N'Diane', N'Hooper', 2, CAST(N'1990-07-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (254, N'Dustin', N'Reeves', 1, CAST(N'1994-11-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (255, N'Tami', N'Manning', 2, CAST(N'1963-08-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (256, N'Demond', N'Bauer', 1, CAST(N'1968-02-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (257, N'Tiffany', N'O''Connor', 2, CAST(N'1958-05-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (258, N'Terence', N'Warren', 2, CAST(N'1973-10-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (259, N'Kurt', N'Gray', 2, CAST(N'1990-01-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (260, N'Sophia', N'Blanchard', 2, CAST(N'1992-06-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (261, N'Jana', N'Monroe', 2, CAST(N'1981-08-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (262, N'Mickey', N'Andersen', 2, CAST(N'1997-07-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (263, N'Rolando', N'Ashley', 2, CAST(N'1973-06-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (264, N'Jimmie', N'Yoder', 1, CAST(N'1993-07-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (265, N'Tia', N'Simon', 2, CAST(N'1999-07-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (266, N'Shari', N'Skinner', 2, CAST(N'1994-01-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (267, N'Freddie', N'Parsons', 1, CAST(N'1991-07-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (268, N'Walter', N'Carlson', 3, CAST(N'1963-03-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (269, N'Rex', N'Bonilla', 2, CAST(N'1968-05-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (270, N'Allyson', N'Bartlett', 2, CAST(N'1983-04-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (271, N'Forrest', N'Werner', 1, CAST(N'2006-09-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (272, N'Terra', N'Leonard', 2, CAST(N'1978-12-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (273, N'Kellie', N'Steele', 2, CAST(N'1962-07-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (274, N'Angelique', N'Perkins', 2, CAST(N'1993-02-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (275, N'Gregg', N'Olson', 2, CAST(N'1966-01-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (276, N'Lindsay', N'Cantu', 2, CAST(N'1970-03-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (277, N'Elisabeth', N'Fitzgerald', 2, CAST(N'1982-03-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (278, N'Angela', N'Short', 2, CAST(N'2004-09-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (279, N'Candace', N'Ochoa', 2, CAST(N'1977-07-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (280, N'Aaron', N'Pace', 2, CAST(N'1962-09-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (281, N'Cecilia', N'Snyder', 2, CAST(N'1990-04-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (282, N'Larry', N'Duke', 2, CAST(N'1982-12-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (283, N'Lorenzo', N'Shepherd', 1, CAST(N'1968-03-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (284, N'Elisabeth', N'Daniel', 2, CAST(N'1981-01-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (285, N'Angelo', N'Wilcox', 1, CAST(N'1966-08-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (286, N'Ralph', N'Lloyd', 1, CAST(N'1954-01-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (287, N'Ramon', N'Mcfarland', 1, CAST(N'1994-05-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (288, N'Dianna', N'Davila', 2, CAST(N'1980-08-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (289, N'Alberto', N'Burnett', 1, CAST(N'1991-12-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (290, N'Marissa', N'Gilbert', 2, CAST(N'1961-07-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (291, N'Desiree', N'Cortez', 2, CAST(N'1980-05-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (292, N'Alison', N'Lawrence', 2, CAST(N'2007-10-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (293, N'Christi', N'Gonzales', 2, CAST(N'1975-06-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (294, N'Lakisha', N'Castillo', 2, CAST(N'1959-08-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (295, N'Donovan', N'Barnes', 1, CAST(N'1953-08-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (296, N'Darin', N'Hansen', 2, CAST(N'2004-09-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (297, N'Darnell', N'Copeland', 2, CAST(N'1967-07-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (298, N'Irma', N'Watts', 2, CAST(N'1961-12-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (299, N'Stephen', N'Ramos', 2, CAST(N'1989-10-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (300, N'Derick', N'Marks', 2, CAST(N'2006-06-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (301, N'Courtney', N'Ritter', 2, CAST(N'1992-08-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (302, N'Eddie', N'Howell', 2, CAST(N'1994-01-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (303, N'Tammie', N'Luna', 2, CAST(N'1997-10-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (304, N'Jennie', N'Reyes', 2, CAST(N'1956-10-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (305, N'Tim', N'Grimes', 2, CAST(N'1964-08-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (306, N'Douglas', N'Walker', 1, CAST(N'1985-05-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (307, N'Quentin', N'Peters', 1, CAST(N'1978-06-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (308, N'Dorothy', N'Thornton', 2, CAST(N'1955-02-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (309, N'Jacquelyn', N'Jefferson', 2, CAST(N'1996-03-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (310, N'Leon', N'House', 2, CAST(N'1999-08-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (311, N'Lana', N'Bryan', 2, CAST(N'1993-05-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (312, N'Kristy', N'Horton', 2, CAST(N'1967-12-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (313, N'Tomas', N'Richards', 1, CAST(N'1976-10-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (314, N'Lesley', N'Chang', 2, CAST(N'1999-04-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (315, N'Desiree', N'Johnson', 2, CAST(N'1967-08-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (316, N'Teri', N'Dominguez', 2, CAST(N'1958-04-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (317, N'Herman', N'Caldwell', 1, CAST(N'1986-04-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (318, N'Lea', N'Holmes', 2, CAST(N'1979-11-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (319, N'Lloyd', N'Levy', 1, CAST(N'1998-06-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (320, N'Rochelle', N'Mahoney', 1, CAST(N'2007-08-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (321, N'Angelina', N'Fuentes', 2, CAST(N'1963-11-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (322, N'Amie', N'Yoder', 2, CAST(N'1979-04-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (323, N'Edward', N'Keith', 2, CAST(N'1959-10-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (324, N'Naomi', N'Robbins', 2, CAST(N'2006-12-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (325, N'Shanda', N'Santana', 2, CAST(N'1956-06-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (326, N'Tomas', N'Knight', 2, CAST(N'1955-11-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (327, N'Kendrick', N'Hart', 1, CAST(N'1992-07-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (328, N'Sherry', N'Griffin', 2, CAST(N'1969-05-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (329, N'Joy', N'Bird', 2, CAST(N'1955-09-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (330, N'Bonnie', N'Harper', 2, CAST(N'1959-07-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (331, N'Kellie', N'Hess', 2, CAST(N'1995-10-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (332, N'Felicia', N'Carpenter', 2, CAST(N'1995-10-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (333, N'Clint', N'Curry', 1, CAST(N'1964-04-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (334, N'Daphne', N'Holmes', 1, CAST(N'2005-09-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (335, N'Preston', N'Nichols', 1, CAST(N'1996-11-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (336, N'Mary', N'Merritt', 2, CAST(N'1978-05-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (337, N'Tomas', N'Olson', 1, CAST(N'1977-03-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (338, N'Nichole', N'Barnett', 2, CAST(N'1955-01-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (339, N'Roberta', N'Daugherty', 1, CAST(N'1976-09-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (340, N'Hector', N'Bowers', 2, CAST(N'1968-12-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (341, N'Ricky', N'Sweeney', 1, CAST(N'1978-07-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (342, N'Darcy', N'Skinner', 1, CAST(N'2003-10-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (343, N'Audrey', N'Davila', 2, CAST(N'1969-12-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (344, N'Damon', N'Floyd', 2, CAST(N'1995-01-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (345, N'Leo', N'Duffy', 1, CAST(N'1992-10-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (346, N'Marshall', N'Brandt', 1, CAST(N'2006-08-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (347, N'Bobbi', N'Faulkner', 1, CAST(N'1968-04-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (348, N'Sherri', N'Winters', 1, CAST(N'1993-12-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (349, N'Dylan', N'Perry', 2, CAST(N'1999-05-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (350, N'Guillermo', N'Blanchard', 1, CAST(N'1989-03-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (351, N'Clay', N'Reid', 1, CAST(N'2003-10-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (352, N'Andrea', N'Valenzuela', 1, CAST(N'1971-07-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (353, N'Jerome', N'Duran', 1, CAST(N'1990-02-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (354, N'Marjorie', N'Fleming', 1, CAST(N'1995-07-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (355, N'Nelson', N'West', 1, CAST(N'1966-05-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (356, N'Laurie', N'Schultz', 1, CAST(N'1987-04-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (357, N'Steve', N'Bradford', 2, CAST(N'1994-10-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (358, N'Damion', N'Thomas', 1, CAST(N'1957-11-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (359, N'Heath', N'Griffith', 1, CAST(N'1961-02-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (360, N'Bradford', N'Hodges', 2, CAST(N'1982-06-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (361, N'Annette', N'Arroyo', 2, CAST(N'1993-12-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (362, N'Becky', N'Watson', 2, CAST(N'1993-10-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (363, N'Kris', N'Reese', 1, CAST(N'1993-07-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (364, N'Kurt', N'Ball', 2, CAST(N'1993-01-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (365, N'Shelly', N'Fuller', 2, CAST(N'2005-07-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (366, N'Jake', N'Schwartz', 2, CAST(N'1980-03-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (367, N'Marcos', N'Levine', 1, CAST(N'1965-07-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (368, N'Clayton', N'Stewart', 2, CAST(N'2001-08-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (369, N'Danny', N'Oliver', 2, CAST(N'1978-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (370, N'Nicole', N'Contreras', 1, CAST(N'1987-11-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (371, N'Don', N'Knight', 1, CAST(N'1962-02-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (372, N'Johnathan', N'Smith', 2, CAST(N'1977-10-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (373, N'Brenda', N'Austin', 1, CAST(N'1974-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (374, N'Amanda', N'Malone', 1, CAST(N'1991-09-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (375, N'Wanda', N'Hudson', 2, CAST(N'1993-05-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (376, N'Judith', N'Downs', 1, CAST(N'1983-07-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (377, N'Elijah', N'Conrad', 1, CAST(N'1997-11-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (378, N'Ron', N'Hoffman', 2, CAST(N'1968-12-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (379, N'Ramona', N'Colon', 2, CAST(N'1967-02-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (380, N'Everett', N'Landry', 1, CAST(N'1957-10-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (381, N'Cary', N'Lambert', 1, CAST(N'1995-07-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (382, N'Joseph', N'Norton', 1, CAST(N'2006-07-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (383, N'Naomi', N'Jackson', 1, CAST(N'1977-12-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (384, N'Julie', N'Price', 1, CAST(N'1974-06-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (385, N'Billy', N'Hays', 2, CAST(N'1963-10-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (386, N'Shonda', N'Hurley', 1, CAST(N'1977-04-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (387, N'Alejandro', N'Sullivan', 2, CAST(N'1976-09-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (388, N'Shelia', N'Phillips', 2, CAST(N'1992-04-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (389, N'Norma', N'Beltran', 2, CAST(N'1962-08-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (390, N'Jess', N'Cole', 2, CAST(N'1991-08-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (391, N'Stuart', N'Stevens', 2, CAST(N'1972-05-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (392, N'Aimee', N'Krause', 1, CAST(N'2001-11-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (393, N'Herman', N'Lloyd', 2, CAST(N'2002-03-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (394, N'Gerardo', N'Melton', 1, CAST(N'1982-12-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (395, N'Edith', N'Moreno', 1, CAST(N'1963-03-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (396, N'Natasha', N'Decker', 2, CAST(N'1984-10-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (397, N'Dustin', N'Carpenter', 1, CAST(N'1997-06-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (398, N'Roger', N'Mc Bride', 2, CAST(N'1965-09-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (399, N'Derick', N'Huerta', 2, CAST(N'1994-02-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (400, N'Carolyn', N'Dodson', 1, CAST(N'1974-09-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (401, N'Vicki', N'Casey', 1, CAST(N'1968-04-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (402, N'Keisha', N'Michael', 2, CAST(N'1964-06-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (403, N'Samuel', N'Suarez', 1, CAST(N'1980-02-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (404, N'Johnny', N'Reid', 2, CAST(N'1978-12-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (405, N'Norman', N'Hartman', 2, CAST(N'2004-10-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (406, N'Ben', N'Rodriguez', 2, CAST(N'2006-06-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (407, N'Ebony', N'Cole', 2, CAST(N'1955-03-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (408, N'Marcia', N'Black', 1, CAST(N'1990-11-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (409, N'Tonya', N'Tyler', 1, CAST(N'1997-05-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (410, N'Lindsey', N'Moss', 1, CAST(N'1978-11-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (411, N'Denise', N'Kramer', 2, CAST(N'1998-10-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (412, N'Rafael', N'Petersen', 2, CAST(N'1956-05-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (413, N'Katie', N'Murray', 1, CAST(N'1994-11-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (414, N'Ted', N'Padilla', 2, CAST(N'1995-06-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (415, N'Mandi', N'Rivera', 2, CAST(N'1968-10-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (416, N'Glenda', N'Cohen', 2, CAST(N'1972-02-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (417, N'Monte', N'Mc Gee', 2, CAST(N'1982-04-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (418, N'Allan', N'Schroeder', 2, CAST(N'1981-04-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (419, N'Adam', N'Rivas', 2, CAST(N'1974-07-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (420, N'Pamela', N'Valentine', 2, CAST(N'1996-10-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (421, N'Tonya', N'Davis', 1, CAST(N'1962-04-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (422, N'Bonnie', N'Horton', 2, CAST(N'1969-02-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (423, N'Sheri', N'Kelley', 1, CAST(N'2004-04-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (424, N'Lonnie', N'Brooks', 1, CAST(N'1997-10-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (425, N'Virginia', N'Kelly', 2, CAST(N'1983-12-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (426, N'Emily', N'Hendricks', 2, CAST(N'1980-07-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (427, N'Tony', N'Randolph', 1, CAST(N'1961-09-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (428, N'Brady', N'Vance', 1, CAST(N'1953-07-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (429, N'Tonya', N'Spears', 2, CAST(N'1973-04-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (430, N'Jacquelyn', N'Burke', 2, CAST(N'1966-01-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (431, N'Jessie', N'Carney', 2, CAST(N'1979-07-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (432, N'Jonathon', N'Roberts', 1, CAST(N'1954-06-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (433, N'Angelia', N'Chung', 2, CAST(N'1971-09-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (434, N'Vicky', N'Patton', 2, CAST(N'1973-11-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (435, N'Irene', N'Vargas', 2, CAST(N'1966-07-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (436, N'Chandra', N'Malone', 1, CAST(N'2002-04-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (437, N'Dustin', N'Mosley', 1, CAST(N'1992-11-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (438, N'April', N'Terry', 1, CAST(N'1980-07-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (439, N'Jack', N'Glass', 2, CAST(N'1960-02-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (440, N'Shelley', N'Kaiser', 2, CAST(N'1974-07-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (441, N'Ronda', N'Hanna', 2, CAST(N'1954-06-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (442, N'Becky', N'Miranda', 2, CAST(N'1973-03-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (443, N'Ismael', N'Meadows', 2, CAST(N'1965-09-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (444, N'Jay', N'Golden', 1, CAST(N'1981-07-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (445, N'Nakia', N'Quinn', 2, CAST(N'1998-07-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (446, N'Rachael', N'Griffith', 2, CAST(N'1960-04-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (447, N'Abigail', N'Sandoval', 2, CAST(N'1995-07-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (448, N'Deborah', N'Osborne', 2, CAST(N'1976-12-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (449, N'Rachel', N'Cisneros', 2, CAST(N'1999-02-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (450, N'Nikki', N'Gordon', 2, CAST(N'1955-07-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (451, N'Ross', N'Dorsey', 2, CAST(N'1969-02-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (452, N'Eileen', N'Hendrix', 2, CAST(N'1999-02-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (453, N'Veronica', N'Marshall', 2, CAST(N'2005-05-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (454, N'Darrell', N'Meza', 1, CAST(N'1965-05-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (455, N'Sheri', N'Mc Donald', 2, CAST(N'2007-02-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (456, N'Ernest', N'Garrison', 1, CAST(N'1968-02-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (457, N'Miguel', N'Kirk', 1, CAST(N'1990-05-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (458, N'Caleb', N'Castro', 2, CAST(N'2003-01-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (459, N'Suzanne', N'Bullock', 2, CAST(N'1977-04-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (460, N'Vernon', N'Willis', 2, CAST(N'1997-09-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (461, N'Casey', N'Juarez', 2, CAST(N'1954-08-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (462, N'Lorraine', N'Swanson', 2, CAST(N'1970-07-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (463, N'Jocelyn', N'Harvey', 2, CAST(N'1984-05-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (464, N'Bradley', N'Burgess', 1, CAST(N'2007-05-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (465, N'Gavin', N'Gill', 2, CAST(N'1997-04-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (466, N'Carlton', N'Mercado', 1, CAST(N'1992-08-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (467, N'Kevin', N'Hobbs', 1, CAST(N'1974-01-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (468, N'Evan', N'Watts', 1, CAST(N'1957-03-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (469, N'Kerrie', N'Donaldson', 2, CAST(N'1977-11-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (470, N'Maria', N'Villanueva', 2, CAST(N'1997-06-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (471, N'Tammi', N'Wallace', 2, CAST(N'1953-10-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (472, N'Leah', N'Spears', 2, CAST(N'1967-06-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (473, N'Duane', N'Moses', 1, CAST(N'1975-03-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (474, N'Angie', N'Ellis', 2, CAST(N'1960-11-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (475, N'Myra', N'Montes', 2, CAST(N'2003-11-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (476, N'Marlon', N'De Leon', 1, CAST(N'1991-08-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (477, N'Mary', N'Juarez', 2, CAST(N'1969-03-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (478, N'Juan', N'O''Neal', 2, CAST(N'1993-05-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (479, N'Terrence', N'Barber', 1, CAST(N'1973-03-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (480, N'Carrie', N'Ballard', 2, CAST(N'1974-03-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (481, N'Aisha', N'Burke', 2, CAST(N'1984-07-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (482, N'Leah', N'Hooper', 2, CAST(N'1982-03-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (483, N'Sarah', N'Bennett', 2, CAST(N'1963-06-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (484, N'Andrew', N'Vargas', 1, CAST(N'1963-05-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (485, N'Louis', N'Simmons', 2, CAST(N'1963-05-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (486, N'Jennifer', N'Melendez', 2, CAST(N'1974-05-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (487, N'Darius', N'Delacruz', 1, CAST(N'1961-06-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (488, N'Sidney', N'Faulkner', 2, CAST(N'1992-01-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (489, N'Peggy', N'Mathews', 2, CAST(N'2006-05-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (490, N'Katrina', N'Sampson', 2, CAST(N'1964-11-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (491, N'Craig', N'Shaffer', 2, CAST(N'1997-11-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (492, N'Fernando', N'Heath', 2, CAST(N'1956-04-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (493, N'Jesse', N'Greer', 1, CAST(N'1970-06-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (494, N'Christian', N'Carey', 1, CAST(N'1972-12-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (495, N'Richard', N'Stokes', 2, CAST(N'1991-11-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (496, N'Daryl', N'Tran', 1, CAST(N'1996-10-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (497, N'Angelo', N'Maldonado', 2, CAST(N'1966-04-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (498, N'Elena', N'Chapman', 2, CAST(N'1992-03-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (499, N'Jocelyn', N'Barrera', 2, CAST(N'1958-11-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (500, N'Carla', N'Valenzuela', 2, CAST(N'1994-04-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (501, N'Blake', N'Hays', 1, CAST(N'1991-04-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (502, N'Jake', N'Atkins', 2, CAST(N'1974-09-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (503, N'Misty', N'Andersen', 2, CAST(N'1974-04-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (504, N'Marianne', N'Barton', 2, CAST(N'1966-02-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (505, N'Marlene', N'Golden', 1, CAST(N'1968-05-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (506, N'Alexandra', N'Hunt', 1, CAST(N'1984-09-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (507, N'Angelique', N'Fowler', 2, CAST(N'1983-02-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (508, N'Walter', N'Barrera', 1, CAST(N'1957-07-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (509, N'Derrick', N'Harper', 1, CAST(N'1956-03-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (510, N'Victor', N'Gordon', 1, CAST(N'1984-07-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (511, N'Shelby', N'Romero', 1, CAST(N'1987-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (512, N'Yolanda', N'Patrick', 1, CAST(N'1974-03-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (513, N'Kendrick', N'Park', 1, CAST(N'1962-08-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (514, N'Jo', N'Leach', 2, CAST(N'1957-01-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (515, N'Eugene', N'Knight', 1, CAST(N'1976-06-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (516, N'Robin', N'Mack', 2, CAST(N'1978-01-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (517, N'Teresa', N'Rice', 1, CAST(N'1996-05-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (518, N'Marcella', N'Pierce', 2, CAST(N'1973-11-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (519, N'Darlene', N'Norris', 2, CAST(N'1997-01-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (520, N'Christi', N'Krause', 1, CAST(N'1986-12-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (521, N'Jeffery', N'Young', 2, CAST(N'1971-04-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (522, N'Ericka', N'Gill', 2, CAST(N'1965-07-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (523, N'Deborah', N'George', 1, CAST(N'1973-02-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (524, N'Miranda', N'Edwards', 2, CAST(N'1956-11-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (525, N'Gregory', N'Knight', 2, CAST(N'1965-12-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (526, N'Colby', N'Pham', 1, CAST(N'2007-07-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (527, N'Larry', N'Munoz', 1, CAST(N'2005-07-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (528, N'Wayne', N'Leonard', 2, CAST(N'2004-12-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (529, N'Micah', N'Hodge', 1, CAST(N'1955-04-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (530, N'Bridgette', N'Valenzuela', 2, CAST(N'1977-01-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (531, N'Eric', N'Henry', 2, CAST(N'1960-02-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (532, N'Donovan', N'Lane', 2, CAST(N'1978-04-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (533, N'Rebecca', N'Ewing', 2, CAST(N'1984-12-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (534, N'Jeffrey', N'Andrade', 1, CAST(N'1987-06-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (535, N'Keith', N'Holloway', 2, CAST(N'1986-12-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (536, N'Shari', N'Mathews', 1, CAST(N'1990-12-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (537, N'Janine', N'Vang', 2, CAST(N'1962-11-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (538, N'Randolph', N'Camacho', 2, CAST(N'1960-12-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (539, N'Trent', N'Larsen', 1, CAST(N'2005-05-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (540, N'Ira', N'Terrell', 1, CAST(N'2003-01-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (541, N'Brad', N'Clarke', 1, CAST(N'1986-08-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (542, N'Leticia', N'Villegas', 2, CAST(N'1999-03-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (543, N'Marc', N'Ware', 2, CAST(N'1956-12-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (544, N'Tom', N'Maxwell', 1, CAST(N'1988-10-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (545, N'Abraham', N'Mcclain', 2, CAST(N'1974-10-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (546, N'Ty', N'Bright', 2, CAST(N'1998-08-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (547, N'Alfonso', N'Avery', 1, CAST(N'2007-03-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (548, N'Devon', N'Thornton', 2, CAST(N'2001-12-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (549, N'Judith', N'Kelly', 1, CAST(N'2002-12-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (550, N'Adam', N'White', 2, CAST(N'2003-06-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (551, N'Priscilla', N'Wells', 2, CAST(N'1975-12-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (552, N'Shawn', N'Rasmussen', 2, CAST(N'1977-04-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (553, N'Jamie', N'Mcfarland', 2, CAST(N'1958-03-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (554, N'Terry', N'O''Neal', 1, CAST(N'1995-07-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (555, N'Marco', N'Wilkins', 1, CAST(N'1981-09-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (556, N'Dana', N'Doyle', 1, CAST(N'1971-02-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (557, N'Stephan', N'Booker', 2, CAST(N'1970-10-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (558, N'Enrique', N'Harvey', 2, CAST(N'1961-04-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (559, N'Kate', N'Shaw', 2, CAST(N'1966-07-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (560, N'Beverly', N'Rowland', 1, CAST(N'1970-10-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (561, N'Elizabeth', N'Travis', 2, CAST(N'1987-09-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (562, N'Claude', N'Simmons', 2, CAST(N'1980-11-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (563, N'Miguel', N'Cain', 1, CAST(N'1988-06-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (564, N'Andy', N'Wilson', 2, CAST(N'2004-02-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (565, N'Angie', N'Lucero', 1, CAST(N'1959-04-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (566, N'Zachary', N'Serrano', 1, CAST(N'1997-04-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (567, N'Elijah', N'Eaton', 2, CAST(N'1983-03-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (568, N'Nicole', N'Ferguson', 1, CAST(N'1978-02-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (569, N'Tyler', N'Charles', 2, CAST(N'1993-07-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (570, N'Luz', N'De Leon', 2, CAST(N'1968-03-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (571, N'Keri', N'Colon', 2, CAST(N'1988-06-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (572, N'Seth', N'Villarreal', 2, CAST(N'1976-07-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (573, N'Amy', N'Blair', 2, CAST(N'2001-12-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (574, N'Gregory', N'Strickland', 2, CAST(N'1953-04-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (575, N'Melissa', N'Griffin', 1, CAST(N'1980-02-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (576, N'Tanisha', N'Dorsey', 1, CAST(N'1961-08-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (577, N'Craig', N'Glass', 1, CAST(N'1992-04-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (578, N'Kelley', N'Love', 1, CAST(N'1990-02-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (579, N'Cindy', N'Johnston', 1, CAST(N'1975-05-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (580, N'Joseph', N'George', 2, CAST(N'1972-05-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (581, N'Kristine', N'Rodgers', 2, CAST(N'2006-05-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (582, N'Randall', N'Hinton', 1, CAST(N'1956-01-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (583, N'Jeff', N'Bryan', 2, CAST(N'1960-04-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (584, N'Margaret', N'Barry', 1, CAST(N'1981-07-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (585, N'Benny', N'Anderson', 2, CAST(N'1992-02-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (586, N'Brooke', N'Fleming', 1, CAST(N'1953-12-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (587, N'Colby', N'Pierce', 1, CAST(N'1979-09-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (588, N'Eduardo', N'Ferrell', 1, CAST(N'1999-11-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (589, N'Damon', N'Davis', 1, CAST(N'1958-03-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (590, N'Cheryl', N'Matthews', 2, CAST(N'1972-11-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (591, N'Dion', N'Reyes', 1, CAST(N'2000-01-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (592, N'Elizabeth', N'Daniel', 2, CAST(N'2007-08-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (593, N'Rex', N'Sherman', 1, CAST(N'1991-11-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (594, N'Ray', N'Burnett', 1, CAST(N'2006-12-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (595, N'Autumn', N'Bentley', 2, CAST(N'1971-05-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (596, N'Sonya', N'Gordon', 1, CAST(N'1976-06-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (597, N'Kristi', N'Ayala', 2, CAST(N'1992-09-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (598, N'Pedro', N'Rocha', 1, CAST(N'1968-07-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (599, N'Roy', N'Barton', 1, CAST(N'1954-05-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (600, N'Ernesto', N'Horn', 1, CAST(N'1958-01-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (601, N'Demond', N'Macias', 1, CAST(N'1982-01-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (602, N'Sidney', N'Knapp', 2, CAST(N'1961-06-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (603, N'Allison', N'Mathews', 1, CAST(N'1987-10-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (604, N'Eugene', N'Conner', 2, CAST(N'1967-12-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (605, N'Alissa', N'Hess', 1, CAST(N'2007-05-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (606, N'Angie', N'Stokes', 1, CAST(N'1983-04-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (607, N'Lamar', N'Barker', 2, CAST(N'1957-12-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (608, N'Arlene', N'Hood', 2, CAST(N'1968-06-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (609, N'Marsha', N'Buckley', 1, CAST(N'1973-01-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (610, N'Bradford', N'Boyer', 1, CAST(N'1986-10-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (611, N'Lena', N'Carson', 1, CAST(N'1988-09-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (612, N'Philip', N'Hill', 1, CAST(N'1993-12-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (613, N'Beth', N'Davila', 1, CAST(N'2002-03-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (614, N'Janice', N'Fuentes', 1, CAST(N'1972-06-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (615, N'Kathryn', N'Kidd', 2, CAST(N'1984-08-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (616, N'Carol', N'Davenport', 1, CAST(N'1973-07-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (617, N'Lynn', N'Blackburn', 1, CAST(N'1959-12-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (618, N'Chanda', N'Hancock', 1, CAST(N'1958-04-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (619, N'Teri', N'Marquez', 2, CAST(N'1970-07-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (620, N'Tom', N'Orozco', 2, CAST(N'1991-04-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (621, N'Theresa', N'Warren', 2, CAST(N'1972-11-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (622, N'Jocelyn', N'Sharp', 1, CAST(N'1973-08-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (623, N'Danielle', N'Luna', 2, CAST(N'1976-03-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (624, N'Marcella', N'Dixon', 2, CAST(N'1988-10-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (625, N'Janine', N'Hawkins', 1, CAST(N'1992-09-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (626, N'Shaun', N'Klein', 2, CAST(N'1969-10-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (627, N'Shonda', N'Holden', 2, CAST(N'1954-05-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (628, N'Abraham', N'Caldwell', 1, CAST(N'1961-10-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (629, N'Johanna', N'Hodge', 2, CAST(N'1993-03-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (630, N'Gene', N'Cohen', 1, CAST(N'2007-08-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (631, N'Holly', N'Atkins', 1, CAST(N'1974-07-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (632, N'Shauna', N'Mccall', 2, CAST(N'1973-12-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (633, N'Robyn', N'Melton', 2, CAST(N'1967-05-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (634, N'Roland', N'Kerr', 2, CAST(N'1977-04-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (635, N'Marcus', N'Carroll', 1, CAST(N'2002-08-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (636, N'Darryl', N'Petty', 1, CAST(N'1980-07-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (637, N'Angelo', N'Carpenter', 1, CAST(N'1966-07-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (638, N'Gavin', N'Lloyd', 1, CAST(N'1992-10-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (639, N'Kerry', N'Mc Millan', 1, CAST(N'1978-08-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (640, N'Scot', N'Frye', 2, CAST(N'1974-10-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (641, N'Melanie', N'Avila', 1, CAST(N'1984-05-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (642, N'Fernando', N'Lawson', 1, CAST(N'1993-03-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (643, N'Edith', N'Jefferson', 1, CAST(N'1994-01-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (644, N'Justin', N'Mckenzie', 2, CAST(N'1964-04-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (645, N'Monte', N'Haynes', 1, CAST(N'1966-09-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (646, N'Robin', N'Lang', 1, CAST(N'1997-09-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (647, N'Tim', N'Yates', 2, CAST(N'1965-10-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (648, N'Sheila', N'Hanson', 2, CAST(N'2005-10-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (649, N'Angie', N'Norris', 1, CAST(N'1969-07-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (650, N'Rolando', N'Hampton', 2, CAST(N'1980-09-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (651, N'Phillip', N'Gibson', 1, CAST(N'1963-04-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (652, N'Lisa', N'Ross', 2, CAST(N'1991-10-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (653, N'Audra', N'Waller', 1, CAST(N'1974-09-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (654, N'Taryn', N'Lang', 1, CAST(N'1962-03-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (655, N'Mia', N'Quinn', 2, CAST(N'1995-10-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (656, N'Claire', N'Burke', 2, CAST(N'1964-08-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (657, N'Bernard', N'Parks', 1, CAST(N'1987-03-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (658, N'Marci', N'Barker', 2, CAST(N'1967-09-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (659, N'Bart', N'Mason', 1, CAST(N'1966-07-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (660, N'Dean', N'Quinn', 1, CAST(N'1956-07-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (661, N'Brad', N'Fields', 2, CAST(N'1959-09-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (662, N'Mia', N'Holmes', 1, CAST(N'1987-11-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (663, N'Shanda', N'Caldwell', 1, CAST(N'1987-02-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (664, N'Stephan', N'Proctor', 1, CAST(N'1967-03-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (665, N'Taryn', N'Santos', 2, CAST(N'1972-12-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (666, N'Scot', N'Barrett', 2, CAST(N'1987-10-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (667, N'Veronica', N'Mayer', 1, CAST(N'2003-03-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (668, N'Henry', N'Michael', 2, CAST(N'1990-01-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (669, N'Jami', N'Cline', 2, CAST(N'2001-01-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (670, N'Ryan', N'Trevino', 2, CAST(N'2001-05-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (671, N'Jason', N'Shaffer', 1, CAST(N'1980-03-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (672, N'Mathew', N'Mc Mahon', 1, CAST(N'1987-08-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (673, N'Marty', N'Pham', 2, CAST(N'2003-10-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (674, N'Charlene', N'Krause', 2, CAST(N'1987-09-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (675, N'Antoine', N'Vaughan', 2, CAST(N'1964-11-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (676, N'Carey', N'Everett', 1, CAST(N'1975-02-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (677, N'Shauna', N'English', 1, CAST(N'2002-12-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (678, N'Rebecca', N'Moyer', 2, CAST(N'1957-01-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (679, N'Robyn', N'Avila', 2, CAST(N'1987-01-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (680, N'Mandy', N'Parker', 2, CAST(N'1964-01-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (681, N'Erich', N'Delgado', 2, CAST(N'1976-09-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (682, N'Kristen', N'Choi', 1, CAST(N'1979-12-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (683, N'Kelli', N'Lara', 1, CAST(N'1964-04-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (684, N'James', N'Dyer', 1, CAST(N'1990-02-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (685, N'Margarita', N'Kent', 1, CAST(N'2000-08-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (686, N'Bret', N'Guzman', 2, CAST(N'1968-02-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (687, N'Kim', N'Everett', 1, CAST(N'1959-10-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (688, N'Celeste', N'Church', 1, CAST(N'1987-05-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (689, N'Curtis', N'Suarez', 2, CAST(N'1965-02-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (690, N'Shana', N'Kramer', 2, CAST(N'1971-03-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (691, N'Joe', N'Dixon', 2, CAST(N'1977-09-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (692, N'Shelby', N'Wood', 2, CAST(N'1958-04-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (693, N'Alfonso', N'Stanley', 1, CAST(N'1959-11-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (694, N'Abraham', N'Grimes', 2, CAST(N'2005-01-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (695, N'Yolanda', N'Peterson', 2, CAST(N'2001-09-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (696, N'Raul', N'Lane', 1, CAST(N'1962-11-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (697, N'Denise', N'Stafford', 2, CAST(N'1970-07-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (698, N'Tammy', N'Escobar', 2, CAST(N'1993-04-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (699, N'Katrina', N'Boyer', 2, CAST(N'1957-09-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (700, N'Timothy', N'Leach', 2, CAST(N'1976-02-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (701, N'Kimberly', N'Riggs', 1, CAST(N'1953-06-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (702, N'Adriana', N'Barnett', 2, CAST(N'1983-08-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (703, N'Sheldon', N'Sweeney', 2, CAST(N'1996-01-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (704, N'Jordan', N'Dillon', 2, CAST(N'1967-10-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (705, N'Jenny', N'Monroe', 1, CAST(N'1982-06-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (706, N'Katie', N'Mathews', 1, CAST(N'1961-03-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (707, N'Taryn', N'Rodgers', 1, CAST(N'2007-09-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (708, N'Alissa', N'Morton', 2, CAST(N'1965-01-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (709, N'Warren', N'Parrish', 2, CAST(N'1972-10-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (710, N'Allen', N'Santos', 2, CAST(N'1962-07-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (711, N'Theresa', N'Branch', 1, CAST(N'1977-07-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (712, N'Leonardo', N'Aguilar', 2, CAST(N'2003-09-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (713, N'Maria', N'Rivers', 2, CAST(N'1964-03-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (714, N'Celeste', N'Farmer', 2, CAST(N'1960-03-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (715, N'Hope', N'Vincent', 2, CAST(N'1990-10-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (716, N'Scott', N'Wall', 1, CAST(N'1995-03-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (717, N'Omar', N'Combs', 2, CAST(N'1988-02-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (718, N'Alice', N'Vang', 1, CAST(N'1983-04-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (719, N'Kendrick', N'Madden', 1, CAST(N'1985-02-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (720, N'Diane', N'Knox', 2, CAST(N'1966-12-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (721, N'Carla', N'Terry', 1, CAST(N'1955-03-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (722, N'Natalie', N'Robertson', 2, CAST(N'1975-07-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (723, N'Cara', N'Clark', 1, CAST(N'1985-07-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (724, N'Colby', N'West', 2, CAST(N'1990-03-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (725, N'Leigh', N'Moses', 2, CAST(N'1982-05-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (726, N'Laura', N'Norton', 1, CAST(N'1980-09-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (727, N'Fernando', N'Hardin', 1, CAST(N'1981-05-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (728, N'Melvin', N'Bauer', 2, CAST(N'1993-02-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (729, N'Jesus', N'Daniels', 1, CAST(N'1994-06-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (730, N'Trenton', N'Huang', 1, CAST(N'2001-09-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (731, N'Ivan', N'Hodges', 2, CAST(N'1959-04-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (732, N'Rolando', N'Massey', 1, CAST(N'1953-07-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (733, N'Micheal', N'Rowland', 2, CAST(N'1979-07-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (734, N'Darcy', N'Knight', 1, CAST(N'1988-08-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (735, N'Rusty', N'James', 1, CAST(N'2002-02-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (736, N'Shelly', N'Fisher', 2, CAST(N'1985-10-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (737, N'Francisco', N'Ibarra', 1, CAST(N'1993-08-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (738, N'Nicolas', N'Armstrong', 1, CAST(N'2006-08-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (739, N'Ernest', N'Craig', 1, CAST(N'1969-03-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (740, N'Heidi', N'Luna', 1, CAST(N'1975-05-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (741, N'Latonya', N'Underwood', 2, CAST(N'1958-04-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (742, N'Becky', N'Acosta', 2, CAST(N'1955-07-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (743, N'Tisha', N'Roman', 2, CAST(N'2001-08-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (744, N'Luke', N'Mcgrath', 2, CAST(N'1982-01-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (745, N'Lorie', N'Hart', 1, CAST(N'2002-02-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (746, N'Fernando', N'Krueger', 2, CAST(N'2007-09-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (747, N'Michael', N'Lane', 2, CAST(N'2002-02-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (748, N'Lloyd', N'Frank', 1, CAST(N'1963-12-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (749, N'Telly', N'Mc Dowell', 1, CAST(N'1975-08-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (750, N'Duane', N'Gibson', 1, CAST(N'1990-06-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (751, N'Don', N'Mc Intyre', 2, CAST(N'1963-01-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (752, N'Tami', N'Woodard', 2, CAST(N'1980-08-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (753, N'Kirsten', N'Osborn', 1, CAST(N'1962-03-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (754, N'Jeanette', N'Vincent', 1, CAST(N'2006-03-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (755, N'Betsy', N'Henry', 1, CAST(N'1961-01-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (756, N'Micheal', N'Monroe', 2, CAST(N'1963-06-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (757, N'Brock', N'Burnett', 2, CAST(N'1985-08-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (758, N'Clyde', N'Valenzuela', 2, CAST(N'1953-01-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (759, N'Robbie', N'Marshall', 2, CAST(N'1988-07-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (760, N'Micheal', N'Pierce', 1, CAST(N'1992-11-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (761, N'Robbie', N'Gillespie', 1, CAST(N'1991-09-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (762, N'Yvonne', N'Mason', 1, CAST(N'1987-08-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (763, N'Angelique', N'Fisher', 1, CAST(N'1976-02-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (764, N'Katherine', N'Bowman', 1, CAST(N'1983-11-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (765, N'Isaac', N'Arias', 2, CAST(N'1997-06-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (766, N'Simon', N'Lowe', 1, CAST(N'1963-08-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (767, N'Sergio', N'Roman', 2, CAST(N'1988-08-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (768, N'Clifton', N'Matthews', 2, CAST(N'1975-04-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (769, N'Summer', N'Meyers', 1, CAST(N'1996-09-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (770, N'Sherri', N'Maxwell', 2, CAST(N'1962-06-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (771, N'Gabriela', N'Stanton', 1, CAST(N'2002-06-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (772, N'Marc', N'Mcintosh', 2, CAST(N'1984-08-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (773, N'Alfred', N'Callahan', 1, CAST(N'1968-11-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (774, N'Randy', N'Park', 1, CAST(N'1999-08-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (775, N'Garry', N'Zuniga', 2, CAST(N'2004-12-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (776, N'Jerrod', N'Hebert', 2, CAST(N'1973-01-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (777, N'Jimmie', N'Burnett', 2, CAST(N'1991-12-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (778, N'Donovan', N'Ferguson', 1, CAST(N'1961-03-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (779, N'Rochelle', N'Hobbs', 1, CAST(N'1988-03-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (780, N'Kimberley', N'Boyer', 1, CAST(N'1980-12-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (781, N'Veronica', N'Wade', 1, CAST(N'1970-06-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (782, N'Mario', N'Potts', 2, CAST(N'1970-07-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (783, N'Maggie', N'Rogers', 1, CAST(N'1957-01-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (784, N'Janine', N'Benitez', 1, CAST(N'1991-09-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (785, N'Vicki', N'Stout', 1, CAST(N'1986-08-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (786, N'Bryon', N'Cameron', 1, CAST(N'1999-04-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (787, N'Rene', N'Becker', 1, CAST(N'1981-04-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (788, N'Bobbi', N'Nguyen', 1, CAST(N'1980-07-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (789, N'Judy', N'Pacheco', 2, CAST(N'1991-09-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (790, N'Sandra', N'Kirk', 2, CAST(N'1953-02-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (791, N'Mindy', N'Odom', 2, CAST(N'1993-07-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (792, N'Ricardo', N'James', 1, CAST(N'1971-01-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (793, N'Elijah', N'Boyer', 2, CAST(N'1991-09-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (794, N'Shad', N'O''Connor', 1, CAST(N'1978-08-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (795, N'Alexandra', N'Wong', 2, CAST(N'1987-06-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (796, N'Harvey', N'Lynch', 1, CAST(N'1970-10-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (797, N'Alvin', N'Hicks', 1, CAST(N'1992-07-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (798, N'Andre', N'Sanford', 1, CAST(N'1991-07-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (799, N'Sally', N'Page', 2, CAST(N'1972-01-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (800, N'Rose', N'Cuevas', 2, CAST(N'1979-11-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (801, N'Allyson', N'Madden', 1, CAST(N'1975-03-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (802, N'Cornelius', N'Hoffman', 1, CAST(N'1966-03-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (803, N'Gavin', N'Riley', 2, CAST(N'1995-12-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (804, N'Robin', N'Fritz', 2, CAST(N'1986-05-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (805, N'Darlene', N'Gray', 1, CAST(N'1964-09-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (806, N'Marcie', N'Russo', 2, CAST(N'1970-08-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (807, N'Marcus', N'Hurley', 2, CAST(N'1954-03-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (808, N'Jimmie', N'Espinoza', 2, CAST(N'1996-01-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (809, N'Herbert', N'Torres', 2, CAST(N'1979-07-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (810, N'Terri', N'Park', 2, CAST(N'1977-06-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (811, N'Helen', N'Parker', 1, CAST(N'1972-10-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (812, N'Kenny', N'Ballard', 1, CAST(N'1960-07-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (813, N'Kelli', N'Arnold', 1, CAST(N'1972-02-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (814, N'Victor', N'De Leon', 1, CAST(N'1974-03-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (815, N'Leo', N'Fleming', 1, CAST(N'1970-02-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (816, N'Levi', N'Adams', 1, CAST(N'1972-01-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (817, N'Alvin', N'Gregory', 2, CAST(N'2000-02-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (818, N'Laura', N'Nguyen', 1, CAST(N'1963-10-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (819, N'Andrea', N'Browning', 1, CAST(N'1972-05-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (820, N'Mark', N'Hawkins', 1, CAST(N'1960-05-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (821, N'Angel', N'Black', 2, CAST(N'2002-09-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (822, N'Kent', N'Moore', 2, CAST(N'1957-12-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (823, N'Kristina', N'Benitez', 2, CAST(N'1961-12-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (824, N'Lawrence', N'Woodard', 1, CAST(N'1966-08-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (825, N'Guillermo', N'Owen', 2, CAST(N'1992-07-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (826, N'Annette', N'Bullock', 2, CAST(N'1960-12-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (827, N'Beverly', N'Mullins', 1, CAST(N'1979-04-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (828, N'Bryon', N'Brock', 2, CAST(N'1993-07-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (829, N'Drew', N'Santos', 1, CAST(N'1974-02-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (830, N'Clayton', N'Thompson', 2, CAST(N'1976-08-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (831, N'Darren', N'Frost', 1, CAST(N'2004-09-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (832, N'Kareem', N'Fowler', 2, CAST(N'1961-12-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (833, N'Garry', N'Davis', 2, CAST(N'2001-11-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (834, N'Becky', N'Bowen', 1, CAST(N'2003-03-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (835, N'Brian', N'Booth', 2, CAST(N'1957-04-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (836, N'Judy', N'Benton', 2, CAST(N'1969-01-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (837, N'Shaun', N'Bright', 2, CAST(N'1958-04-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (838, N'Willie', N'Walter', 1, CAST(N'1974-11-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (839, N'Chester', N'Petty', 1, CAST(N'1981-09-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (840, N'Benjamin', N'Morton', 2, CAST(N'1980-02-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (841, N'Gabriel', N'Jacobson', 1, CAST(N'1992-06-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (842, N'Margaret', N'Casey', 2, CAST(N'1965-02-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (843, N'Gerardo', N'Bishop', 2, CAST(N'1983-09-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (844, N'Joe', N'Booker', 1, CAST(N'1973-09-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (845, N'Tanisha', N'Wilkinson', 1, CAST(N'1963-07-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (846, N'Melody', N'Hooper', 1, CAST(N'1965-03-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (847, N'Gail', N'Meyer', 1, CAST(N'1970-06-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (848, N'Luke', N'Gomez', 2, CAST(N'1961-07-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (849, N'Eric', N'Carr', 2, CAST(N'1968-05-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (850, N'Jack', N'Levine', 2, CAST(N'1978-08-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (851, N'Whitney', N'Barnes', 2, CAST(N'1981-10-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (852, N'Gerald', N'Hicks', 2, CAST(N'1972-03-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (853, N'Ismael', N'Boyd', 1, CAST(N'1964-09-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (854, N'Colin', N'Valentine', 2, CAST(N'1985-02-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (855, N'Maria', N'Kaufman', 1, CAST(N'1970-03-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (856, N'Ted', N'Cohen', 2, CAST(N'1956-11-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (857, N'Jenny', N'Sims', 1, CAST(N'1987-01-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (858, N'Tonia', N'Fowler', 1, CAST(N'1972-10-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (859, N'Cecilia', N'Bruce', 1, CAST(N'1980-03-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (860, N'Sandra', N'Davila', 2, CAST(N'1982-11-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (861, N'Suzanne', N'Moss', 2, CAST(N'1955-07-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (862, N'Stephen', N'Huber', 2, CAST(N'1958-06-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (863, N'Melisa', N'Middleton', 2, CAST(N'1953-11-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (864, N'Dan', N'Barker', 2, CAST(N'1976-02-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (865, N'Billy', N'Wong', 2, CAST(N'2006-08-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (866, N'Meghan', N'Lawson', 1, CAST(N'1978-04-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (867, N'Andres', N'Stephens', 1, CAST(N'1978-12-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (868, N'Christian', N'Sanders', 2, CAST(N'1965-10-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (869, N'Tabatha', N'Preston', 1, CAST(N'1955-12-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (870, N'Keith', N'Tran', 1, CAST(N'1994-11-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (871, N'Adriana', N'Cohen', 1, CAST(N'1996-11-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (872, N'Tanisha', N'Reese', 2, CAST(N'1998-08-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (873, N'Shad', N'Mc Connell', 2, CAST(N'1988-04-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (874, N'Andrew', N'Preston', 1, CAST(N'1963-03-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (875, N'Jeffery', N'Logan', 1, CAST(N'2000-11-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (876, N'Dustin', N'Rivas', 1, CAST(N'1986-08-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (877, N'Ebony', N'Booth', 1, CAST(N'1996-03-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (878, N'Jayson', N'Morris', 1, CAST(N'1956-01-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (879, N'Roger', N'Bryant', 1, CAST(N'1980-04-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (880, N'Karen', N'Davenport', 1, CAST(N'1998-06-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (881, N'Sherman', N'Bass', 1, CAST(N'1970-10-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (882, N'Roberta', N'Thornton', 1, CAST(N'1978-03-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (883, N'Cheryl', N'Walters', 1, CAST(N'2003-06-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (884, N'Joni', N'Mckinney', 1, CAST(N'2002-10-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (885, N'Elaine', N'Cantrell', 2, CAST(N'1985-07-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (886, N'Eva', N'Callahan', 1, CAST(N'2005-03-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (887, N'Elton', N'Simmons', 1, CAST(N'1969-09-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (888, N'Janette', N'Ferguson', 2, CAST(N'1985-12-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (889, N'Kisha', N'Harrington', 2, CAST(N'1953-05-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (890, N'Dorothy', N'Frazier', 2, CAST(N'1990-01-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (891, N'Tracie', N'Rosales', 1, CAST(N'1993-07-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (892, N'Alberto', N'Escobar', 2, CAST(N'2002-08-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (893, N'Patricia', N'Gomez', 1, CAST(N'1971-12-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (894, N'Keri', N'Rodriguez', 2, CAST(N'2005-03-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (895, N'Fernando', N'Vaughan', 2, CAST(N'1959-09-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (896, N'Cecilia', N'Barry', 1, CAST(N'1982-10-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (897, N'Kristin', N'Beltran', 1, CAST(N'2005-08-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (898, N'Candace', N'Boyer', 1, CAST(N'1964-11-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (899, N'Roberto', N'Graves', 1, CAST(N'1994-11-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (900, N'Carey', N'Hull', 1, CAST(N'1999-06-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (901, N'Anthony', N'Wood', 1, CAST(N'2003-09-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (902, N'Bridgette', N'Dennis', 1, CAST(N'1965-05-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (903, N'Derick', N'Parker', 2, CAST(N'1991-10-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (904, N'Angelina', N'Bond', 1, CAST(N'1992-11-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (905, N'Alvin', N'Shannon', 1, CAST(N'1981-07-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (906, N'Tiffany', N'Dawson', 1, CAST(N'1984-06-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (907, N'Monica', N'Mc Guire', 1, CAST(N'1974-12-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (908, N'Jamison', N'Cortez', 1, CAST(N'1977-05-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (909, N'Jeanette', N'Dawson', 2, CAST(N'1978-04-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (910, N'Eugene', N'Zamora', 2, CAST(N'1998-11-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (911, N'Vincent', N'Knight', 1, CAST(N'1969-09-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (912, N'Javier', N'Porter', 1, CAST(N'2007-12-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (913, N'Dana', N'Love', 1, CAST(N'1965-02-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (914, N'Benny', N'Campbell', 1, CAST(N'1985-04-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (915, N'Loretta', N'York', 1, CAST(N'1962-12-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (916, N'Grant', N'Mullins', 2, CAST(N'1959-01-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (917, N'Doris', N'Francis', 1, CAST(N'1998-08-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (918, N'Nelson', N'Hobbs', 1, CAST(N'1954-05-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (919, N'Christie', N'Alvarez', 2, CAST(N'2000-12-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (920, N'Glenda', N'Garcia', 1, CAST(N'1965-06-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (921, N'Melanie', N'Hancock', 2, CAST(N'1973-12-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (922, N'Tricia', N'Ball', 1, CAST(N'1954-05-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (923, N'Amber', N'Horn', 2, CAST(N'2002-03-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (924, N'Doris', N'Phelps', 1, CAST(N'1979-09-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (925, N'Cesar', N'Terry', 1, CAST(N'1991-01-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (926, N'Tanisha', N'Frederick', 2, CAST(N'1981-03-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (927, N'Tabitha', N'Huff', 1, CAST(N'1994-02-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (928, N'Sheila', N'Cline', 1, CAST(N'1956-10-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (929, N'Roberto', N'Frye', 1, CAST(N'1998-07-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (930, N'Mia', N'Bullock', 2, CAST(N'1999-03-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (931, N'Jeffery', N'Gallagher', 1, CAST(N'1993-05-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (932, N'Tina', N'Pennington', 1, CAST(N'2006-12-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (933, N'Betsy', N'Mays', 1, CAST(N'1975-01-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (934, N'Alfred', N'Bauer', 1, CAST(N'1965-11-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (935, N'Kristy', N'Zhang', 2, CAST(N'1964-09-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (936, N'Ricardo', N'Perkins', 2, CAST(N'1962-12-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (937, N'Rebekah', N'Lowery', 2, CAST(N'1956-12-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (938, N'Danielle', N'Carlson', 2, CAST(N'1973-10-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (939, N'Miguel', N'Chen', 2, CAST(N'2002-09-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (940, N'Kimberly', N'Huffman', 2, CAST(N'1983-02-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (941, N'Angela', N'Pineda', 2, CAST(N'1999-03-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (942, N'Orlando', N'Reynolds', 2, CAST(N'1976-10-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (943, N'Marla', N'Delacruz', 2, CAST(N'2002-09-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (944, N'Stacey', N'Stevenson', 1, CAST(N'2007-09-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (945, N'Trina', N'Skinner', 1, CAST(N'1993-01-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (946, N'Roxanne', N'Phillips', 2, CAST(N'1957-09-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (947, N'Rick', N'Marks', 1, CAST(N'1976-10-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (948, N'Marisa', N'Watson', 2, CAST(N'1960-01-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (949, N'Juanita', N'Carr', 2, CAST(N'1963-06-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (950, N'Beth', N'Holland', 1, CAST(N'1986-04-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (951, N'Hollie', N'Roman', 1, CAST(N'2006-06-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (952, N'Irene', N'Zhang', 2, CAST(N'1991-04-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (953, N'Alfonso', N'Lane', 1, CAST(N'1999-05-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (954, N'Manuel', N'Sexton', 1, CAST(N'1990-05-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (955, N'Jay', N'Schroeder', 2, CAST(N'1998-09-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (956, N'Marsha', N'Jackson', 2, CAST(N'1954-11-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (957, N'Miriam', N'Osborne', 1, CAST(N'2001-05-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (958, N'Andrew', N'Miller', 2, CAST(N'2001-09-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (959, N'Hope', N'Dawson', 1, CAST(N'1991-04-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (960, N'Mindy', N'Hood', 2, CAST(N'1974-06-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (961, N'Kari', N'Hester', 1, CAST(N'1953-04-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (962, N'Ted', N'Gentry', 1, CAST(N'1978-07-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (963, N'Kristin', N'Mc Bride', 2, CAST(N'1967-07-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (964, N'Frank', N'Zhang', 2, CAST(N'1973-03-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (965, N'Terri', N'Mc Lean', 1, CAST(N'1998-01-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (966, N'Kristine', N'Griffith', 1, CAST(N'1972-05-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (967, N'Devon', N'Silva', 2, CAST(N'2006-03-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (968, N'Kim', N'Mccarty', 2, CAST(N'2004-01-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (969, N'Tanya', N'James', 2, CAST(N'1994-08-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (970, N'Ericka', N'Simon', 1, CAST(N'1988-08-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (971, N'Yesenia', N'Macias', 1, CAST(N'1966-11-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (972, N'Marcos', N'Daniels', 1, CAST(N'1992-05-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (973, N'Scotty', N'Harmon', 1, CAST(N'1990-04-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (974, N'Latonya', N'Lamb', 2, CAST(N'1982-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (975, N'Ebony', N'Hudson', 1, CAST(N'1985-08-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (976, N'Dominick', N'Cervantes', 1, CAST(N'2007-07-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (977, N'Devin', N'Barr', 1, CAST(N'1979-12-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (978, N'Dan', N'Cunningham', 2, CAST(N'2006-01-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (979, N'Jeremiah', N'Gonzalez', 1, CAST(N'1976-07-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (980, N'Charity', N'Hopkins', 2, CAST(N'1997-04-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (981, N'Jose', N'Simpson', 2, CAST(N'1987-12-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (982, N'Terrence', N'Robles', 1, CAST(N'1991-07-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (983, N'Leanne', N'Gross', 1, CAST(N'1988-09-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (984, N'Bobby', N'Singleton', 1, CAST(N'1960-02-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (985, N'Cesar', N'Richards', 2, CAST(N'1953-07-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (986, N'Anne', N'Hartman', 1, CAST(N'1991-10-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (987, N'Melvin', N'Roberson', 2, CAST(N'1974-06-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (988, N'Jeanine', N'Morgan', 1, CAST(N'1982-04-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (989, N'Gilbert', N'King', 1, CAST(N'1972-03-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (990, N'Francis', N'Lucero', 2, CAST(N'1955-02-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (991, N'Gena', N'Ellison', 2, CAST(N'1980-05-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (992, N'Rachel', N'Herman', 1, CAST(N'1978-04-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (993, N'Lucas', N'Moyer', 1, CAST(N'1961-08-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (994, N'Lewis', N'Kline', 2, CAST(N'1998-12-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (995, N'Beverly', N'Hurst', 2, CAST(N'2006-03-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (996, N'Clinton', N'Reed', 2, CAST(N'1988-02-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (997, N'Mandi', N'Hodge', 1, CAST(N'1987-07-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (998, N'Dallas', N'Andrade', 1, CAST(N'2003-01-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (999, N'Sally', N'Cline', 1, CAST(N'1993-04-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1000, N'Kenny', N'Berry', 2, CAST(N'2006-07-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1001, N'Bridget', N'Valentine', 2, CAST(N'1980-09-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1002, N'Michael', N'Nielsen', 1, CAST(N'1973-06-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1003, N'Isaac', N'Lutz', 2, CAST(N'1982-11-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1004, N'Shonda', N'Blevins', 2, CAST(N'1972-05-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1005, N'Dexter', N'Trevino', 1, CAST(N'1967-01-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1006, N'Rene', N'Norris', 1, CAST(N'1953-12-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1007, N'Dexter', N'Houston', 1, CAST(N'1969-09-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1008, N'Frances', N'Huang', 1, CAST(N'1957-10-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1009, N'Alexandra', N'Petersen', 1, CAST(N'1999-03-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1010, N'Dianna', N'Irwin', 2, CAST(N'1982-12-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1011, N'Tim', N'Santos', 2, CAST(N'2003-05-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1012, N'Geoffrey', N'Mccoy', 2, CAST(N'1978-03-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1013, N'Alfonso', N'Cooley', 1, CAST(N'2002-01-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1014, N'Jenny', N'Bell', 2, CAST(N'1994-07-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1015, N'Stanley', N'Avila', 1, CAST(N'1969-09-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1016, N'Karla', N'Gill', 1, CAST(N'1997-11-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1017, N'Irma', N'Zimmerman', 2, CAST(N'1960-06-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1018, N'Janice', N'Dudley', 1, CAST(N'1972-09-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1019, N'Ricardo', N'Moon', 2, CAST(N'1959-04-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1020, N'Lynette', N'Ortega', 1, CAST(N'2005-12-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1021, N'Katherine', N'Boyle', 1, CAST(N'1976-12-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1022, N'Judy', N'Wagner', 1, CAST(N'1984-11-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1023, N'Sidney', N'Lynn', 1, CAST(N'1992-06-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1024, N'Traci', N'Castillo', 2, CAST(N'1961-03-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1025, N'Evan', N'Delacruz', 2, CAST(N'1965-11-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1026, N'Angela', N'Cantrell', 1, CAST(N'1967-02-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1027, N'Sandy', N'Rhodes', 1, CAST(N'1981-09-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1028, N'Jana', N'Villanueva', 1, CAST(N'1991-10-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1029, N'Todd', N'Mays', 1, CAST(N'1987-05-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1030, N'Donovan', N'Washington', 2, CAST(N'1972-05-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1031, N'Salvador', N'Kaufman', 2, CAST(N'2000-06-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1032, N'Suzanne', N'Ward', 1, CAST(N'1956-01-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1033, N'Bonnie', N'Roberson', 2, CAST(N'1991-03-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1034, N'Julius', N'Mc Mahon', 2, CAST(N'1998-09-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1035, N'Tasha', N'Maxwell', 1, CAST(N'1960-03-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1036, N'Allan', N'Blair', 1, CAST(N'1958-10-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1037, N'Natasha', N'Lloyd', 1, CAST(N'1995-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1038, N'Judith', N'Nicholson', 2, CAST(N'1994-06-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1039, N'Preston', N'Braun', 2, CAST(N'1990-10-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1040, N'Jayson', N'Church', 2, CAST(N'1957-10-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1041, N'Jody', N'Bonilla', 1, CAST(N'1977-06-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1042, N'Summer', N'Choi', 2, CAST(N'1981-01-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1043, N'Jacob', N'Hess', 1, CAST(N'1980-03-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1044, N'Adriana', N'Reynolds', 1, CAST(N'1987-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1045, N'Juan', N'Keith', 2, CAST(N'1985-01-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1046, N'Candace', N'Owen', 2, CAST(N'1983-10-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1047, N'Lorenzo', N'Dorsey', 2, CAST(N'1984-04-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1048, N'Jay', N'Zuniga', 1, CAST(N'1975-02-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1049, N'Isaac', N'Newman', 2, CAST(N'1982-03-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1050, N'Lana', N'Newman', 2, CAST(N'1961-05-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1051, N'Mitchell', N'Barrera', 1, CAST(N'1980-09-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1052, N'Gavin', N'Kemp', 1, CAST(N'1967-10-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1053, N'Mickey', N'Daugherty', 1, CAST(N'1996-09-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1054, N'Daryl', N'Schwartz', 2, CAST(N'1995-05-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1055, N'Jody', N'Mc Gee', 1, CAST(N'1982-08-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1056, N'Dwayne', N'Beasley', 1, CAST(N'2003-11-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1057, N'Lori', N'Cantrell', 2, CAST(N'1988-12-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1058, N'Meghan', N'Huber', 1, CAST(N'1974-08-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1059, N'Joe', N'Carlson', 2, CAST(N'1959-07-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1060, N'Tommy', N'English', 1, CAST(N'2007-12-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1061, N'Lakeisha', N'Moore', 2, CAST(N'1980-04-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1062, N'Lori', N'Blanchard', 2, CAST(N'1985-11-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1063, N'Gretchen', N'Burch', 2, CAST(N'1978-06-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1064, N'Vickie', N'Reese', 1, CAST(N'1979-10-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1065, N'Natalie', N'Thompson', 1, CAST(N'1990-07-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1066, N'Sammy', N'Lane', 1, CAST(N'2000-05-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1067, N'Patrick', N'Stafford', 2, CAST(N'1994-12-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1068, N'Annette', N'Boyd', 1, CAST(N'1956-04-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1069, N'Leslie', N'Vincent', 1, CAST(N'1987-04-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1070, N'Joe', N'Nelson', 2, CAST(N'2006-08-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1071, N'Rhonda', N'Pollard', 2, CAST(N'1992-01-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1072, N'Rachael', N'Mc Mahon', 2, CAST(N'1972-09-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1073, N'Ronnie', N'Holden', 2, CAST(N'1986-03-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1074, N'Katrina', N'Blanchard', 2, CAST(N'1976-06-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1075, N'Anne', N'Navarro', 2, CAST(N'2001-03-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1076, N'Irene', N'Werner', 2, CAST(N'2007-06-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1077, N'Terrell', N'Melton', 2, CAST(N'1956-10-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1078, N'Alonzo', N'Gentry', 2, CAST(N'1965-04-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1079, N'Sonny', N'Cobb', 1, CAST(N'1984-03-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1080, N'Dwight', N'Mendoza', 2, CAST(N'1990-01-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1081, N'Ebony', N'Dixon', 1, CAST(N'1990-10-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1082, N'Marla', N'Aguirre', 2, CAST(N'1959-07-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1083, N'Kate', N'Farmer', 2, CAST(N'1962-08-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1084, N'Trina', N'Nicholson', 2, CAST(N'1978-12-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1085, N'Leanne', N'Blake', 1, CAST(N'1999-09-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1086, N'Walter', N'Riley', 1, CAST(N'1985-08-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1087, N'Tom', N'Gordon', 1, CAST(N'1967-04-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1088, N'Curtis', N'Bishop', 2, CAST(N'2003-11-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1089, N'Erica', N'Walton', 1, CAST(N'1969-02-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1090, N'Erik', N'Casey', 2, CAST(N'1990-02-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1091, N'Belinda', N'Parrish', 2, CAST(N'1992-03-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1092, N'Johnathan', N'Leonard', 2, CAST(N'1989-03-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1093, N'Nicole', N'Banks', 2, CAST(N'1994-07-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1094, N'Ian', N'Evans', 1, CAST(N'1979-11-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1095, N'Miguel', N'Gamble', 2, CAST(N'2006-12-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1096, N'Omar', N'Wallace', 1, CAST(N'1954-03-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1097, N'Lakesha', N'Foster', 2, CAST(N'1997-09-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1098, N'Ty', N'Waters', 2, CAST(N'1992-08-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1099, N'Kristen', N'Hurley', 2, CAST(N'1996-10-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1100, N'Norman', N'Phelps', 1, CAST(N'1981-01-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1101, N'Mickey', N'Castro', 1, CAST(N'1995-10-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1102, N'Penny', N'Jacobs', 1, CAST(N'1983-07-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1103, N'Whitney', N'Terry', 2, CAST(N'1977-04-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1104, N'Salvador', N'Donaldson', 1, CAST(N'1960-12-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1105, N'Manuel', N'Mccall', 2, CAST(N'1989-08-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1106, N'Claudia', N'Morgan', 2, CAST(N'1973-04-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1107, N'Duane', N'Hendrix', 1, CAST(N'2002-03-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1108, N'Cory', N'Kramer', 1, CAST(N'1983-02-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1109, N'Johnnie', N'Carter', 1, CAST(N'1976-09-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1110, N'Randal', N'Fernandez', 1, CAST(N'1998-05-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1111, N'Darrick', N'Gross', 2, CAST(N'1977-06-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1112, N'Clarence', N'Powell', 1, CAST(N'1970-02-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1113, N'Abel', N'Short', 2, CAST(N'1973-09-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1114, N'Luke', N'Aguirre', 1, CAST(N'1976-04-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1115, N'Bradley', N'Juarez', 2, CAST(N'2007-06-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1116, N'Karla', N'Dawson', 2, CAST(N'1988-02-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1117, N'Brandi', N'Gamble', 1, CAST(N'1957-11-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1118, N'Laurie', N'Mc Millan', 2, CAST(N'1986-02-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1119, N'Clinton', N'Rivera', 2, CAST(N'1999-02-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1120, N'Terrell', N'Hampton', 1, CAST(N'1995-02-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1121, N'Stanley', N'Stark', 1, CAST(N'1975-12-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1122, N'Zachary', N'Potts', 1, CAST(N'1969-07-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1123, N'Rachel', N'Kirby', 2, CAST(N'2007-11-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1124, N'Felicia', N'Santiago', 2, CAST(N'1991-07-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1125, N'Saul', N'Aguirre', 1, CAST(N'1999-08-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1126, N'Belinda', N'Forbes', 1, CAST(N'1974-04-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1127, N'Tracy', N'Haynes', 2, CAST(N'1953-06-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1128, N'Gerardo', N'Rollins', 2, CAST(N'1955-07-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1129, N'Oliver', N'Olsen', 2, CAST(N'1975-07-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1130, N'Duane', N'Mc Dowell', 1, CAST(N'1999-07-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1131, N'Tabatha', N'Jackson', 2, CAST(N'2001-04-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1132, N'Janine', N'Vaughn', 1, CAST(N'1962-10-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1133, N'Amy', N'Whitaker', 2, CAST(N'1971-10-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1134, N'Salvatore', N'Shelton', 1, CAST(N'1987-01-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1135, N'Scotty', N'Hart', 1, CAST(N'1954-09-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1136, N'Cara', N'Elliott', 1, CAST(N'1991-09-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1137, N'Herbert', N'Cardenas', 2, CAST(N'2004-01-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1138, N'Kelvin', N'Hampton', 2, CAST(N'2001-12-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1139, N'Rose', N'Morales', 2, CAST(N'1954-09-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1140, N'Clarissa', N'Ortega', 2, CAST(N'1993-12-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1141, N'Nelson', N'Haas', 2, CAST(N'1972-03-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1142, N'Margarita', N'Kent', 1, CAST(N'1966-05-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1143, N'Jorge', N'Valdez', 2, CAST(N'2001-10-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1144, N'Harvey', N'Jensen', 2, CAST(N'1964-10-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1145, N'Dan', N'Matthews', 2, CAST(N'1977-06-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1146, N'Chadwick', N'Sloan', 2, CAST(N'1997-09-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1147, N'Jesse', N'Robbins', 2, CAST(N'1956-08-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1148, N'Curtis', N'Atkins', 1, CAST(N'2007-07-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1149, N'Roxanne', N'Woods', 2, CAST(N'1992-10-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1150, N'Roderick', N'Wong', 2, CAST(N'1959-07-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1151, N'Chris', N'Stevenson', 1, CAST(N'2005-09-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1152, N'Bridgett', N'Page', 1, CAST(N'1987-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1153, N'Kelly', N'Farley', 2, CAST(N'1993-11-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1154, N'Kristine', N'Moran', 2, CAST(N'1972-10-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1155, N'Teresa', N'Johns', 2, CAST(N'1966-12-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1156, N'Martha', N'Wright', 1, CAST(N'1977-06-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1157, N'Denise', N'Quinn', 1, CAST(N'1977-06-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1158, N'Wanda', N'Fisher', 2, CAST(N'1997-12-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1159, N'Chadwick', N'Watson', 2, CAST(N'1960-04-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1160, N'Leslie', N'Farrell', 2, CAST(N'1980-11-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1161, N'Fredrick', N'Velasquez', 2, CAST(N'1982-08-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1162, N'Angel', N'Cabrera', 2, CAST(N'1997-07-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1163, N'Micah', N'Montoya', 2, CAST(N'1954-02-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1164, N'Jill', N'Bowen', 1, CAST(N'2006-11-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1165, N'Gloria', N'Weeks', 2, CAST(N'1984-02-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1166, N'Stacey', N'Holder', 1, CAST(N'1960-04-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1167, N'Leroy', N'Castro', 2, CAST(N'1987-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1168, N'Brock', N'Morrison', 2, CAST(N'1954-12-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1169, N'Earnest', N'Palmer', 1, CAST(N'1997-03-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1170, N'Gordon', N'Rowe', 1, CAST(N'2005-10-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1171, N'Donnell', N'Marquez', 1, CAST(N'2004-06-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1172, N'Lori', N'Ritter', 2, CAST(N'1961-11-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1173, N'Connie', N'Romero', 1, CAST(N'1992-02-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1174, N'Dominic', N'Ayers', 2, CAST(N'1997-06-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1175, N'Faith', N'Barnes', 2, CAST(N'1954-02-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1176, N'Alexander', N'Bates', 2, CAST(N'1956-10-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1177, N'April', N'Rivera', 1, CAST(N'1956-02-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1178, N'Jorge', N'Keller', 2, CAST(N'1959-01-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1179, N'Carmen', N'Proctor', 1, CAST(N'1979-09-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1180, N'Malcolm', N'Huffman', 2, CAST(N'1975-03-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1181, N'Gregory', N'Escobar', 2, CAST(N'1976-04-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1182, N'Don', N'Watts', 1, CAST(N'1970-09-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1183, N'Dylan', N'Gross', 2, CAST(N'1953-12-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1184, N'Terri', N'Ramsey', 1, CAST(N'1989-06-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1185, N'Stefanie', N'Braun', 1, CAST(N'1992-12-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1186, N'Jodi', N'Valenzuela', 1, CAST(N'2003-07-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1187, N'Alissa', N'Galloway', 2, CAST(N'1976-12-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1188, N'Kristin', N'Holloway', 1, CAST(N'2006-12-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1189, N'Paige', N'Meyer', 2, CAST(N'1973-02-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1190, N'Krystal', N'Burns', 1, CAST(N'1985-03-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1191, N'Alberto', N'Mann', 2, CAST(N'1987-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1192, N'Bryant', N'Thomas', 1, CAST(N'1967-04-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1193, N'Trisha', N'Woodard', 2, CAST(N'1959-02-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1194, N'Ira', N'Mullins', 2, CAST(N'1994-09-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1195, N'Rochelle', N'Mora', 1, CAST(N'1964-05-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1196, N'Eric', N'Woodward', 2, CAST(N'1982-08-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1197, N'Regina', N'Frank', 2, CAST(N'1965-04-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1198, N'Toby', N'Nielsen', 1, CAST(N'2002-12-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1199, N'Lea', N'Schmidt', 1, CAST(N'1988-08-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1200, N'Charlie', N'Quinn', 1, CAST(N'1970-02-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1201, N'Tami', N'Bowers', 1, CAST(N'1995-10-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1202, N'Sherman', N'Preston', 1, CAST(N'1967-06-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1203, N'Hilary', N'Daugherty', 2, CAST(N'1954-09-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1204, N'Esther', N'Malone', 1, CAST(N'1977-08-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1205, N'Erich', N'Bradley', 2, CAST(N'1983-12-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1206, N'Jeff', N'Green', 2, CAST(N'1975-06-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1207, N'Kendrick', N'Reid', 2, CAST(N'1961-04-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1208, N'Timothy', N'Baldwin', 1, CAST(N'1992-09-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1209, N'Sally', N'Haney', 1, CAST(N'1969-01-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1210, N'Jordan', N'Perry', 2, CAST(N'1963-11-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1211, N'Leanne', N'Gardner', 1, CAST(N'1971-06-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1212, N'Natasha', N'Strickland', 1, CAST(N'2005-10-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1213, N'April', N'Hayden', 1, CAST(N'1975-09-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1214, N'Holly', N'Knight', 2, CAST(N'1991-12-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1215, N'Misty', N'Olson', 1, CAST(N'1963-03-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1216, N'Jeanne', N'Gordon', 1, CAST(N'1981-09-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1217, N'Sonny', N'Rangel', 1, CAST(N'1961-01-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1218, N'Gail', N'Frederick', 2, CAST(N'1971-05-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1219, N'Jessie', N'Little', 1, CAST(N'1987-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1220, N'Billie', N'Gilbert', 1, CAST(N'1966-11-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1221, N'Iris', N'Barry', 2, CAST(N'1988-08-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1222, N'Natasha', N'Lutz', 2, CAST(N'1991-05-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1223, N'Mark', N'Lowe', 1, CAST(N'1956-01-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1224, N'Staci', N'Rodriguez', 1, CAST(N'1977-02-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1225, N'Toby', N'Benitez', 2, CAST(N'1973-08-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1226, N'Latisha', N'Maxwell', 1, CAST(N'1990-03-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1227, N'Norma', N'Stevenson', 2, CAST(N'1955-09-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1228, N'Shonda', N'Levy', 2, CAST(N'2005-05-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1229, N'Philip', N'Short', 2, CAST(N'1968-08-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1230, N'Debbie', N'Dunn', 2, CAST(N'1997-10-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1231, N'Clint', N'Hunter', 2, CAST(N'1998-11-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1232, N'Angelina', N'Schroeder', 1, CAST(N'1964-02-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1233, N'Rex', N'Dominguez', 1, CAST(N'1999-01-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1234, N'Seth', N'Blanchard', 1, CAST(N'1988-07-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1235, N'Melody', N'Waters', 1, CAST(N'2007-03-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1236, N'Meghan', N'Hoffman', 1, CAST(N'1964-11-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1237, N'Kendra', N'Schaefer', 1, CAST(N'1987-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1238, N'Pamela', N'Mercado', 2, CAST(N'1959-10-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1239, N'Wendy', N'Mac Donald', 1, CAST(N'1970-07-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1240, N'Katherine', N'Ryan', 2, CAST(N'1995-04-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1241, N'Alicia', N'Arnold', 2, CAST(N'1992-03-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1242, N'Ramon', N'Roberts', 2, CAST(N'1990-12-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1243, N'Rudy', N'Whitaker', 2, CAST(N'1966-10-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1244, N'Shelia', N'Bender', 1, CAST(N'1969-06-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1245, N'Cornelius', N'Richards', 1, CAST(N'1955-10-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1246, N'Leonard', N'Chase', 2, CAST(N'1990-08-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1247, N'Carrie', N'Ford', 1, CAST(N'1974-07-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1248, N'Donovan', N'Keith', 2, CAST(N'2001-11-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1249, N'Maurice', N'Pham', 2, CAST(N'1989-02-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1250, N'Clint', N'Spence', 1, CAST(N'1953-01-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1251, N'Gilberto', N'Kline', 1, CAST(N'1986-10-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1252, N'Christa', N'Hartman', 2, CAST(N'1992-09-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1253, N'Darla', N'Bowen', 1, CAST(N'1998-04-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1254, N'Jana', N'Mcpherson', 1, CAST(N'1989-02-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1255, N'Francisco', N'Hartman', 2, CAST(N'1995-06-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1256, N'Garry', N'Sloan', 1, CAST(N'1981-03-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1257, N'Herman', N'Savage', 1, CAST(N'1978-01-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1258, N'Nicolas', N'Cummings', 2, CAST(N'2000-08-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1259, N'Antoine', N'Landry', 2, CAST(N'2002-12-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1260, N'Jordan', N'Frederick', 1, CAST(N'1994-10-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1261, N'Kenneth', N'Welch', 2, CAST(N'1972-12-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1262, N'Jeff', N'Hall', 2, CAST(N'1960-05-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1263, N'Jana', N'Davis', 2, CAST(N'1959-09-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1264, N'Andre', N'Summers', 1, CAST(N'1970-08-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1265, N'Virginia', N'Graves', 2, CAST(N'1956-06-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1266, N'Shauna', N'Gill', 2, CAST(N'1959-12-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1267, N'Audrey', N'Jacobson', 2, CAST(N'1982-06-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1268, N'Cherie', N'Rivas', 2, CAST(N'2004-03-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1269, N'Paige', N'Thompson', 2, CAST(N'1964-07-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1270, N'Fredrick', N'Atkinson', 1, CAST(N'2004-04-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1271, N'Marlon', N'Wall', 1, CAST(N'2001-04-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1272, N'Judy', N'Cochran', 2, CAST(N'1973-01-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1273, N'Sophia', N'Mc Millan', 2, CAST(N'1967-11-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1274, N'Angelo', N'Walsh', 2, CAST(N'1959-10-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1275, N'Becky', N'Dodson', 2, CAST(N'1973-09-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1276, N'Caroline', N'Figueroa', 2, CAST(N'1972-04-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1277, N'Aisha', N'Berg', 2, CAST(N'2002-08-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1278, N'Leticia', N'Daniels', 1, CAST(N'2005-01-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1279, N'Gretchen', N'Dunlap', 1, CAST(N'1960-02-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1280, N'Esteban', N'Irwin', 1, CAST(N'1960-08-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1281, N'Timmy', N'Rogers', 2, CAST(N'2004-12-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1282, N'Nicolas', N'Ferguson', 2, CAST(N'1983-01-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1283, N'Dwight', N'Rich', 1, CAST(N'1998-12-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1284, N'Clifford', N'Briggs', 2, CAST(N'1979-05-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1285, N'Johnathan', N'Savage', 1, CAST(N'2003-10-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1286, N'Tonia', N'Gross', 1, CAST(N'1965-12-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1287, N'Alisa', N'Dominguez', 2, CAST(N'1971-02-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1288, N'Darla', N'Bryan', 1, CAST(N'1977-06-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1289, N'Brett', N'Solomon', 1, CAST(N'1986-08-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1290, N'Sherman', N'Hall', 2, CAST(N'2000-06-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1291, N'Tamiko', N'Wright', 2, CAST(N'2002-08-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1292, N'Vanessa', N'Gregory', 1, CAST(N'1997-04-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1293, N'Jarrod', N'Mann', 1, CAST(N'2004-02-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1294, N'Darla', N'Singh', 1, CAST(N'1997-04-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1295, N'Marisol', N'Spears', 2, CAST(N'1959-06-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1296, N'Lamont', N'Washington', 2, CAST(N'1962-10-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1297, N'Kirk', N'Gallegos', 2, CAST(N'1973-10-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1298, N'Carol', N'Banks', 1, CAST(N'2007-04-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1299, N'Justin', N'Woodward', 1, CAST(N'1964-08-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1300, N'Gregg', N'Brennan', 1, CAST(N'1961-03-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1301, N'Angelique', N'Kaufman', 2, CAST(N'1978-05-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1302, N'Kristina', N'Combs', 2, CAST(N'1990-05-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1303, N'Ronda', N'Russo', 1, CAST(N'1992-10-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1304, N'Melvin', N'Mata', 1, CAST(N'1959-10-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1305, N'Dustin', N'Griffith', 2, CAST(N'1987-08-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1306, N'Harvey', N'Stephens', 2, CAST(N'1972-09-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1307, N'Joe', N'Gilmore', 2, CAST(N'1983-06-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1308, N'Alonzo', N'Reynolds', 2, CAST(N'1982-04-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1309, N'Adrian', N'Jordan', 2, CAST(N'1983-06-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1310, N'Jasmine', N'Norman', 1, CAST(N'2003-08-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1311, N'Anitra', N'Decker', 1, CAST(N'1995-10-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1312, N'Bill', N'Novak', 2, CAST(N'1987-03-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1313, N'Ann', N'Kerr', 2, CAST(N'1975-12-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1314, N'Dean', N'Foster', 2, CAST(N'1985-04-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1315, N'Mason', N'Ramsey', 1, CAST(N'1968-09-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1316, N'Orlando', N'Booker', 1, CAST(N'1960-09-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1317, N'Jay', N'Ortiz', 2, CAST(N'1964-05-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1318, N'Milton', N'Romero', 2, CAST(N'1979-10-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1319, N'Javier', N'Dougherty', 1, CAST(N'1985-12-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1320, N'Ernesto', N'Barajas', 2, CAST(N'1956-10-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1321, N'Mike', N'Whitaker', 1, CAST(N'2006-08-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1322, N'Vicky', N'Jensen', 2, CAST(N'1962-11-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1323, N'Keri', N'Meyer', 1, CAST(N'1976-12-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1324, N'Dawn', N'Brady', 1, CAST(N'1978-07-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1325, N'Devin', N'Sparks', 2, CAST(N'1953-05-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1326, N'Melody', N'Hurst', 2, CAST(N'1963-12-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1327, N'Scot', N'Crane', 2, CAST(N'2006-07-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1328, N'Beth', N'Reeves', 1, CAST(N'2003-04-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1329, N'Mario', N'Chambers', 1, CAST(N'1993-05-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1330, N'Gene', N'Herrera', 1, CAST(N'2006-12-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1331, N'Shanna', N'Thompson', 2, CAST(N'1990-04-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1332, N'Leanne', N'Yates', 2, CAST(N'1967-08-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1333, N'Moses', N'Meyers', 2, CAST(N'1998-03-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1334, N'Karla', N'Rangel', 1, CAST(N'1992-03-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1335, N'Tyler', N'Gordon', 1, CAST(N'1999-10-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1336, N'Teresa', N'Chan', 1, CAST(N'1984-02-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1337, N'Doris', N'Velez', 2, CAST(N'1990-06-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1338, N'Katherine', N'Greene', 1, CAST(N'1996-10-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1339, N'Virginia', N'Buchanan', 2, CAST(N'1955-09-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1340, N'Tonia', N'Rich', 2, CAST(N'1977-09-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1341, N'Jerry', N'Levine', 2, CAST(N'1969-12-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1342, N'Rosa', N'Pittman', 2, CAST(N'1954-06-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1343, N'Tami', N'Gillespie', 1, CAST(N'1969-12-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1344, N'Myra', N'Parsons', 1, CAST(N'1974-05-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1345, N'Tracie', N'Ware', 2, CAST(N'1982-02-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1346, N'Melinda', N'Huang', 2, CAST(N'2002-01-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1347, N'Rachael', N'Weeks', 2, CAST(N'1982-07-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1348, N'Olivia', N'Bell', 2, CAST(N'1999-08-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1349, N'Bryon', N'Barber', 1, CAST(N'1970-08-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1350, N'Jamey', N'Bray', 2, CAST(N'2004-11-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1351, N'Sonny', N'Clayton', 2, CAST(N'1957-05-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1352, N'Joanne', N'Calhoun', 1, CAST(N'1988-12-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1353, N'Ricardo', N'Melendez', 1, CAST(N'1961-02-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1354, N'Helen', N'Johns', 2, CAST(N'1977-09-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1355, N'Peter', N'Bush', 1, CAST(N'2003-09-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1356, N'Mandi', N'Owens', 1, CAST(N'1957-12-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1357, N'Donovan', N'Jackson', 1, CAST(N'1981-11-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1358, N'Brock', N'Howell', 2, CAST(N'1963-09-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1359, N'Floyd', N'Hancock', 2, CAST(N'1963-05-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1360, N'Ismael', N'Cortez', 2, CAST(N'1988-03-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1361, N'Eva', N'Carlson', 1, CAST(N'1963-04-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1362, N'Jamison', N'Sexton', 1, CAST(N'1996-11-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1363, N'Sherri', N'Romero', 1, CAST(N'2004-11-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1364, N'Katherine', N'Luna', 1, CAST(N'1961-04-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1365, N'Jake', N'Estes', 1, CAST(N'1995-02-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1366, N'Dewayne', N'Bishop', 1, CAST(N'1984-07-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1367, N'Raquel', N'Bass', 2, CAST(N'2007-06-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1368, N'Jacquelyn', N'Hancock', 1, CAST(N'1984-08-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1369, N'Teri', N'Steele', 1, CAST(N'1964-07-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1370, N'Adam', N'Hammond', 1, CAST(N'1975-07-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1371, N'Betsy', N'Carlson', 2, CAST(N'1977-01-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1372, N'Ira', N'Mullen', 2, CAST(N'1961-04-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1373, N'Allan', N'Small', 2, CAST(N'1994-11-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1374, N'Jolene', N'Ferguson', 1, CAST(N'2007-08-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1375, N'Keri', N'Cooper', 2, CAST(N'1961-06-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1376, N'Tyson', N'Forbes', 1, CAST(N'1960-01-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1377, N'Monica', N'Flynn', 1, CAST(N'1957-03-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1378, N'Lesley', N'Valenzuela', 2, CAST(N'1979-04-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1379, N'Kent', N'Rocha', 1, CAST(N'1969-12-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1380, N'Garrett', N'Hickman', 1, CAST(N'1976-12-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1381, N'Dwight', N'Haas', 1, CAST(N'1956-09-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1382, N'Cary', N'Reilly', 2, CAST(N'1975-09-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1383, N'Lance', N'Vang', 2, CAST(N'1955-01-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1384, N'Kelley', N'Simon', 2, CAST(N'1991-09-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1385, N'Dan', N'Grimes', 1, CAST(N'1963-04-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1386, N'Joseph', N'Walters', 2, CAST(N'1962-04-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1387, N'Krystal', N'Hendricks', 2, CAST(N'1984-01-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1388, N'Lorie', N'Choi', 1, CAST(N'1975-01-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1389, N'Wade', N'Manning', 2, CAST(N'1988-05-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1390, N'Bryant', N'Lewis', 1, CAST(N'1985-07-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1391, N'Brendan', N'Hammond', 1, CAST(N'1967-11-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1392, N'Rodolfo', N'Tyler', 1, CAST(N'1999-12-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1393, N'Bryant', N'Bond', 1, CAST(N'1967-04-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1394, N'Dena', N'Coleman', 1, CAST(N'1989-10-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1395, N'Frederick', N'Juarez', 1, CAST(N'1996-10-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1396, N'Yolanda', N'Fernandez', 2, CAST(N'1965-08-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1397, N'Israel', N'Campos', 1, CAST(N'1973-01-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1398, N'Angelo', N'Acosta', 1, CAST(N'1966-01-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1399, N'Judy', N'Randall', 2, CAST(N'1994-12-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1400, N'Jason', N'Tucker', 2, CAST(N'1983-02-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1401, N'Jose', N'Washington', 2, CAST(N'1967-12-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1402, N'Marianne', N'Bartlett', 1, CAST(N'1959-02-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1403, N'Charlotte', N'Pollard', 1, CAST(N'1982-04-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1404, N'Ronnie', N'Jacobson', 1, CAST(N'1982-07-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1405, N'Heath', N'Small', 2, CAST(N'2004-02-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1406, N'Freddie', N'Diaz', 2, CAST(N'2002-02-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1407, N'Raquel', N'Roberson', 2, CAST(N'1961-07-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1408, N'Cesar', N'Horn', 1, CAST(N'1969-04-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1409, N'Jodi', N'Espinoza', 1, CAST(N'1996-09-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1410, N'Kerry', N'Harrell', 1, CAST(N'1953-09-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1411, N'Sean', N'Nunez', 1, CAST(N'1955-08-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1412, N'Clint', N'Drake', 1, CAST(N'2001-10-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1413, N'Clint', N'Sampson', 1, CAST(N'1994-06-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1414, N'Dina', N'Juarez', 2, CAST(N'1984-06-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1415, N'Danielle', N'Ingram', 2, CAST(N'1995-07-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1416, N'Roberto', N'Nielsen', 1, CAST(N'1994-10-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1417, N'Lance', N'Glass', 1, CAST(N'1966-03-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1418, N'Kerri', N'Hardin', 1, CAST(N'2006-01-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1419, N'Franklin', N'Valencia', 2, CAST(N'1985-11-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1420, N'Micah', N'Salinas', 1, CAST(N'1953-06-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1421, N'Lynette', N'Snow', 2, CAST(N'1985-05-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1422, N'Elaine', N'Watkins', 1, CAST(N'2004-04-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1423, N'Trevor', N'Nunez', 2, CAST(N'1986-12-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1424, N'Jeremy', N'Cooke', 1, CAST(N'1960-09-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1425, N'Isabel', N'Hendricks', 1, CAST(N'1985-01-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1426, N'Cara', N'Schultz', 1, CAST(N'2001-12-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1427, N'Miriam', N'Anthony', 2, CAST(N'1987-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1428, N'Lamont', N'Rocha', 1, CAST(N'1958-01-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1429, N'Abraham', N'O''Connell', 2, CAST(N'1963-11-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1430, N'Telly', N'Hood', 2, CAST(N'2003-11-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1431, N'Miriam', N'Olson', 2, CAST(N'1999-02-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1432, N'Alison', N'Frazier', 1, CAST(N'1992-04-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1433, N'Elisabeth', N'Salas', 2, CAST(N'2007-05-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1434, N'Ruben', N'Mayer', 1, CAST(N'2001-10-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1435, N'Monte', N'Roberts', 2, CAST(N'1996-10-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1436, N'Karin', N'Carter', 1, CAST(N'1969-07-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1437, N'Vicky', N'Mcclain', 2, CAST(N'1980-10-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1438, N'Steven', N'Bird', 1, CAST(N'1962-02-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1439, N'Jamison', N'Spencer', 2, CAST(N'1967-02-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1440, N'Priscilla', N'Fernandez', 2, CAST(N'1968-02-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1441, N'Kristian', N'Wong', 1, CAST(N'1975-07-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1442, N'Joan', N'Hill', 2, CAST(N'1958-10-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1443, N'Earnest', N'Quinn', 1, CAST(N'1999-08-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1444, N'Louis', N'Castillo', 2, CAST(N'1984-10-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1445, N'Elias', N'Frey', 2, CAST(N'1965-03-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1446, N'Tabitha', N'Mccall', 1, CAST(N'2006-03-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1447, N'Rusty', N'Blackwell', 2, CAST(N'1980-11-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1448, N'Derrick', N'Carney', 2, CAST(N'1958-05-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1449, N'Angelique', N'Goodwin', 1, CAST(N'1954-03-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1450, N'Cedric', N'Hutchinson', 1, CAST(N'1978-10-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1451, N'Bill', N'Hancock', 2, CAST(N'1959-10-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1452, N'Brandy', N'Archer', 1, CAST(N'1967-12-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1453, N'Elaine', N'Holden', 1, CAST(N'1962-02-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1454, N'Jay', N'Hampton', 1, CAST(N'1970-01-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1455, N'Rachelle', N'Mccann', 1, CAST(N'2005-09-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1456, N'Amber', N'Hodges', 1, CAST(N'1971-09-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1457, N'Lindsey', N'Pollard', 2, CAST(N'1980-03-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1458, N'Jenifer', N'Joyce', 1, CAST(N'1974-07-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1459, N'Cecil', N'Sherman', 1, CAST(N'2005-07-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1460, N'Kisha', N'Lloyd', 2, CAST(N'1955-03-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1461, N'Anitra', N'Duffy', 2, CAST(N'1997-02-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1462, N'Priscilla', N'Yoder', 1, CAST(N'2005-09-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1463, N'Yvette', N'Villa', 1, CAST(N'1973-05-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1464, N'Leticia', N'Fuentes', 1, CAST(N'1954-09-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1465, N'Kimberley', N'Moreno', 2, CAST(N'1962-08-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1466, N'Christian', N'Peters', 1, CAST(N'1971-04-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1467, N'Angelia', N'Knight', 1, CAST(N'2002-05-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1468, N'Tyrone', N'Grimes', 1, CAST(N'2000-08-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1469, N'Kristen', N'Paul', 1, CAST(N'1995-09-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1470, N'Candice', N'Conway', 1, CAST(N'1979-01-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1471, N'Anne', N'Reyes', 1, CAST(N'1967-01-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1472, N'Francisco', N'Mc Millan', 2, CAST(N'1957-01-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1473, N'Amy', N'Hodges', 2, CAST(N'1991-11-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1474, N'April', N'Byrd', 2, CAST(N'1970-09-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1475, N'Sean', N'Curry', 1, CAST(N'1985-12-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1476, N'Doris', N'Gardner', 2, CAST(N'1979-07-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1477, N'Julie', N'Cantrell', 2, CAST(N'1957-08-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1478, N'Carol', N'Rubio', 2, CAST(N'1955-02-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1479, N'Lawanda', N'Lara', 1, CAST(N'1986-11-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1480, N'Sarah', N'Bonilla', 1, CAST(N'1974-01-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1481, N'Jocelyn', N'Morse', 1, CAST(N'2007-08-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1482, N'Naomi', N'Buchanan', 2, CAST(N'1962-08-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1483, N'Calvin', N'Proctor', 2, CAST(N'1978-01-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1484, N'Cathy', N'Leon', 1, CAST(N'1988-03-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1485, N'Ira', N'Weaver', 1, CAST(N'1984-02-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1486, N'Demond', N'Swanson', 2, CAST(N'1983-02-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1487, N'Forrest', N'Grant', 2, CAST(N'1990-04-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1488, N'Serena', N'Sanford', 2, CAST(N'2004-02-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1489, N'Autumn', N'Valencia', 1, CAST(N'1978-01-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1490, N'Dean', N'Gonzales', 2, CAST(N'1997-05-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1491, N'Marjorie', N'Mc Intyre', 2, CAST(N'1959-03-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1492, N'Cherie', N'Briggs', 2, CAST(N'1964-08-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1493, N'Joseph', N'Woodard', 1, CAST(N'1964-12-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1494, N'Willie', N'Fletcher', 2, CAST(N'1979-01-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1495, N'Candice', N'Roberson', 2, CAST(N'1977-10-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1496, N'Irene', N'Williamson', 1, CAST(N'1993-06-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1497, N'Owen', N'Moses', 1, CAST(N'1997-12-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1498, N'Frances', N'Fritz', 1, CAST(N'1975-03-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1499, N'Sonja', N'Hebert', 2, CAST(N'2001-12-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1500, N'Roxanne', N'Davenport', 2, CAST(N'1956-10-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1501, N'Gerald', N'Phillips', 1, CAST(N'1987-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1502, N'Elijah', N'Richard', 2, CAST(N'1988-03-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1503, N'Rachael', N'Jacobson', 1, CAST(N'1970-09-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1504, N'Jodi', N'Massey', 2, CAST(N'1983-02-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1505, N'Tracie', N'David', 1, CAST(N'1964-09-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1506, N'Alonzo', N'Fuentes', 2, CAST(N'1955-09-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1507, N'Ricardo', N'Glenn', 2, CAST(N'1984-01-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1508, N'Ericka', N'Hill', 2, CAST(N'1999-06-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1509, N'Lawanda', N'Lozano', 2, CAST(N'1992-02-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1510, N'Jake', N'Aguirre', 2, CAST(N'1979-02-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1511, N'Jean', N'Ward', 1, CAST(N'1967-02-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1512, N'Francis', N'Moreno', 2, CAST(N'1978-02-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1513, N'Marci', N'Daugherty', 2, CAST(N'1979-02-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1514, N'Derek', N'Mathis', 2, CAST(N'1971-09-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1515, N'Jamal', N'Cooper', 2, CAST(N'1989-02-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1516, N'Gregg', N'Lynch', 2, CAST(N'1997-06-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1517, N'Melisa', N'Estes', 2, CAST(N'1996-01-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1518, N'Warren', N'Phillips', 2, CAST(N'2003-04-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1519, N'Amber', N'Bright', 1, CAST(N'1974-06-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1520, N'Jamal', N'Everett', 1, CAST(N'1986-06-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1521, N'Melody', N'Garcia', 2, CAST(N'1996-02-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1522, N'Ericka', N'Gentry', 1, CAST(N'1965-01-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1523, N'Ronald', N'Spears', 2, CAST(N'2004-07-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1524, N'Tracy', N'Vincent', 1, CAST(N'1970-08-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1525, N'Bonnie', N'Lyons', 2, CAST(N'1989-09-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1526, N'Tim', N'Rios', 2, CAST(N'1960-11-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1527, N'Salvador', N'Browning', 2, CAST(N'2000-06-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1528, N'Warren', N'Huerta', 2, CAST(N'1979-12-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1529, N'Leah', N'Clements', 2, CAST(N'1999-08-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1530, N'Sharon', N'Zavala', 2, CAST(N'1961-02-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1531, N'Christa', N'Peterson', 1, CAST(N'1994-02-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1532, N'Marcy', N'Costa', 1, CAST(N'1967-08-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1533, N'Yesenia', N'Duarte', 2, CAST(N'1987-11-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1534, N'Rocky', N'Haas', 2, CAST(N'1954-07-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1535, N'Trent', N'Huber', 2, CAST(N'1983-01-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1536, N'Yvonne', N'Weaver', 2, CAST(N'1993-10-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1537, N'Sarah', N'Howe', 1, CAST(N'1989-12-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1538, N'Herbert', N'Thornton', 2, CAST(N'1987-06-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1539, N'Charlotte', N'Khan', 2, CAST(N'1966-05-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1540, N'Jane', N'Golden', 2, CAST(N'1985-07-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1541, N'Terrance', N'Rangel', 1, CAST(N'1953-01-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1542, N'Hugh', N'Gordon', 1, CAST(N'1991-09-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1543, N'Kerry', N'Hunter', 1, CAST(N'2006-03-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1544, N'Carla', N'Graham', 2, CAST(N'1977-12-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1545, N'Darcy', N'Adams', 1, CAST(N'1963-12-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1546, N'Guillermo', N'Combs', 2, CAST(N'1972-03-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1547, N'Wade', N'Dickerson', 1, CAST(N'1988-01-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1548, N'Andy', N'Alexander', 1, CAST(N'2000-12-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1549, N'Chadwick', N'Barrett', 1, CAST(N'1983-10-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1550, N'Curtis', N'Schwartz', 2, CAST(N'1989-08-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1551, N'Shanna', N'Higgins', 1, CAST(N'1989-09-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1552, N'Lloyd', N'Crosby', 1, CAST(N'1998-02-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1553, N'Kendrick', N'Riddle', 1, CAST(N'1976-06-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1554, N'Meredith', N'Branch', 2, CAST(N'1996-10-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1555, N'Martin', N'Rivas', 1, CAST(N'1958-10-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1556, N'Jennifer', N'Nunez', 2, CAST(N'1999-09-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1557, N'Lorenzo', N'Michael', 2, CAST(N'1991-09-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1558, N'Donovan', N'Foster', 2, CAST(N'1953-01-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1559, N'Harvey', N'Greene', 2, CAST(N'2001-06-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1560, N'Chastity', N'Fuentes', 2, CAST(N'1956-11-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1561, N'Carlos', N'Walls', 1, CAST(N'1987-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1562, N'Karl', N'Stephenson', 1, CAST(N'1963-04-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1563, N'Beth', N'Cunningham', 1, CAST(N'1957-02-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1564, N'Jamey', N'Michael', 2, CAST(N'2007-10-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1565, N'Dewayne', N'Ingram', 2, CAST(N'1983-12-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1566, N'Allen', N'Schmidt', 2, CAST(N'1993-01-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1567, N'Lawanda', N'Nichols', 1, CAST(N'2007-06-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1568, N'Frances', N'Mc Knight', 1, CAST(N'1998-03-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1569, N'Julia', N'Solomon', 2, CAST(N'1977-08-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1570, N'Jeannie', N'Brandt', 2, CAST(N'1996-08-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1571, N'Spencer', N'Patton', 2, CAST(N'2003-04-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1572, N'Margarita', N'Weiss', 1, CAST(N'1960-06-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1573, N'Devon', N'Blair', 1, CAST(N'1961-07-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1574, N'Raquel', N'Haynes', 1, CAST(N'1989-12-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1575, N'Terrance', N'Bailey', 1, CAST(N'1996-12-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1576, N'Amelia', N'Friedman', 1, CAST(N'1986-05-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1577, N'Monique', N'Bradford', 1, CAST(N'1957-06-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1578, N'Erick', N'Eaton', 1, CAST(N'1966-11-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1579, N'Emily', N'Roberson', 1, CAST(N'1979-07-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1580, N'Colby', N'Glass', 2, CAST(N'1959-09-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1581, N'Lillian', N'Atkins', 1, CAST(N'1980-10-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1582, N'Marcia', N'Henson', 2, CAST(N'2007-07-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1583, N'Stephen', N'Lamb', 2, CAST(N'2004-02-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1584, N'Michele', N'Combs', 2, CAST(N'1963-01-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1585, N'Bridgett', N'Weber', 2, CAST(N'1979-05-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1586, N'Francis', N'Levine', 1, CAST(N'2004-01-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1587, N'Trevor', N'Young', 1, CAST(N'1999-03-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1588, N'Alex', N'Quinn', 2, CAST(N'1999-01-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1589, N'Stacy', N'Greer', 2, CAST(N'2003-09-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1590, N'Priscilla', N'Daniel', 2, CAST(N'1991-05-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1591, N'Kirsten', N'Snow', 1, CAST(N'1955-02-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1592, N'Molly', N'Gibson', 2, CAST(N'1989-12-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1593, N'Dewayne', N'Olson', 1, CAST(N'1994-01-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1594, N'Randall', N'Cisneros', 1, CAST(N'1962-06-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1595, N'Jeanne', N'James', 1, CAST(N'1975-03-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1596, N'Tonia', N'Odom', 1, CAST(N'2003-12-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1597, N'Jeremiah', N'Joseph', 1, CAST(N'1991-12-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1598, N'Grace', N'Ibarra', 1, CAST(N'1975-03-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1599, N'Ron', N'Haley', 1, CAST(N'1992-12-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1600, N'Jeanine', N'Singh', 2, CAST(N'1964-06-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1601, N'Demond', N'Boyer', 2, CAST(N'1982-01-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1602, N'Suzanne', N'Simon', 1, CAST(N'1963-06-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1603, N'Amelia', N'Mc Gee', 1, CAST(N'1957-05-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1604, N'Darryl', N'Haley', 1, CAST(N'1988-06-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1605, N'Tonia', N'Vaughan', 1, CAST(N'1982-02-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1606, N'Camille', N'Juarez', 1, CAST(N'1981-03-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1607, N'Miguel', N'Dillon', 2, CAST(N'1961-02-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1608, N'Corey', N'Booker', 1, CAST(N'1987-07-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1609, N'Marilyn', N'Woodard', 2, CAST(N'1963-06-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1610, N'Tonia', N'Whitehead', 2, CAST(N'1954-05-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1611, N'Jonathon', N'Bryant', 2, CAST(N'1985-10-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1612, N'Meredith', N'Hess', 2, CAST(N'1965-02-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1613, N'Melissa', N'De Leon', 2, CAST(N'2001-04-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1614, N'Neal', N'Crane', 2, CAST(N'1984-01-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1615, N'Matthew', N'Weaver', 2, CAST(N'1984-02-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1616, N'Frankie', N'Cooke', 1, CAST(N'1963-10-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1617, N'Gary', N'Snow', 1, CAST(N'1960-12-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1618, N'Brendan', N'Harper', 1, CAST(N'1997-09-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1619, N'Amy', N'Hansen', 2, CAST(N'1957-08-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1620, N'Teri', N'Montgomery', 1, CAST(N'1996-12-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1621, N'Katina', N'Vasquez', 1, CAST(N'1961-04-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1622, N'Arnold', N'Atkinson', 1, CAST(N'2007-02-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1623, N'Summer', N'Ferguson', 1, CAST(N'1981-11-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1624, N'Spencer', N'Lara', 1, CAST(N'1958-03-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1625, N'Clarissa', N'House', 1, CAST(N'2001-03-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1626, N'Mindy', N'Potter', 1, CAST(N'1978-07-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1627, N'Kim', N'Williamson', 1, CAST(N'1975-07-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1628, N'Brenda', N'Marsh', 2, CAST(N'1980-06-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1629, N'Jana', N'Forbes', 1, CAST(N'1974-09-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1630, N'Chadwick', N'Arellano', 1, CAST(N'1990-05-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1631, N'Derek', N'Greene', 2, CAST(N'1973-07-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1632, N'Lora', N'Hernandez', 2, CAST(N'1999-09-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1633, N'Priscilla', N'Merritt', 2, CAST(N'1994-08-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1634, N'Alejandro', N'Sharp', 1, CAST(N'2003-03-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1635, N'Scottie', N'Rogers', 2, CAST(N'1996-06-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1636, N'Kendra', N'Obrien', 2, CAST(N'1970-04-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1637, N'Eileen', N'Fields', 1, CAST(N'2003-03-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1638, N'Linda', N'Salas', 1, CAST(N'1968-09-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1639, N'Judy', N'Pruitt', 1, CAST(N'1988-11-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1640, N'Raul', N'Raymond', 2, CAST(N'2006-03-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1641, N'Clint', N'Bates', 2, CAST(N'1995-11-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1642, N'Johnnie', N'Ruiz', 2, CAST(N'1964-09-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1643, N'Harvey', N'Stafford', 1, CAST(N'1988-08-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1644, N'Cory', N'Arroyo', 1, CAST(N'2002-05-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1645, N'Maggie', N'Walters', 2, CAST(N'1958-08-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1646, N'Sonya', N'Moreno', 2, CAST(N'1997-12-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1647, N'Lucas', N'Suarez', 2, CAST(N'1996-08-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1648, N'Latoya', N'Barrett', 1, CAST(N'1963-01-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1649, N'Jerrod', N'Stephenson', 1, CAST(N'1986-05-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1650, N'Misty', N'Reyes', 2, CAST(N'1964-06-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1651, N'Beth', N'Fields', 2, CAST(N'1996-01-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1652, N'Terrence', N'Wells', 1, CAST(N'2002-03-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1653, N'Jean', N'Floyd', 1, CAST(N'1970-08-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1654, N'Lester', N'Huffman', 2, CAST(N'2003-12-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1655, N'Laura', N'Weber', 2, CAST(N'1956-03-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1656, N'Mike', N'Young', 2, CAST(N'1982-11-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1657, N'Alejandro', N'Carpenter', 1, CAST(N'1989-08-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1658, N'Ramon', N'Waller', 1, CAST(N'2007-02-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1659, N'Adrienne', N'Sullivan', 1, CAST(N'1995-04-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1660, N'Joyce', N'Chang', 1, CAST(N'1956-08-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1661, N'Bruce', N'Payne', 1, CAST(N'1958-08-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1662, N'Sam', N'Webb', 2, CAST(N'1988-08-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1663, N'Alfonso', N'Villegas', 1, CAST(N'1965-10-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1664, N'Courtney', N'Mahoney', 1, CAST(N'1981-01-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1665, N'Autumn', N'Lindsey', 2, CAST(N'1988-11-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1666, N'Tina', N'Reynolds', 2, CAST(N'1994-02-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1667, N'Latonya', N'Pugh', 2, CAST(N'1978-07-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1668, N'Lindsey', N'Foster', 2, CAST(N'2006-01-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1669, N'Marcia', N'Conrad', 1, CAST(N'1995-07-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1670, N'Kerry', N'Lucero', 1, CAST(N'1966-10-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1671, N'Ryan', N'Pruitt', 1, CAST(N'1968-08-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1672, N'Quincy', N'Roberts', 1, CAST(N'2000-04-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1673, N'Brenda', N'Yates', 2, CAST(N'1961-10-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1674, N'Mason', N'Griffith', 1, CAST(N'1959-05-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1675, N'Ivan', N'Odom', 2, CAST(N'1954-02-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1676, N'Lawrence', N'Hernandez', 1, CAST(N'2004-08-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1677, N'Dianna', N'Cordova', 2, CAST(N'1971-06-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1678, N'Alexander', N'Haynes', 2, CAST(N'1987-06-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1679, N'Sharon', N'Bishop', 1, CAST(N'2007-08-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1680, N'Frederick', N'Foley', 1, CAST(N'1956-04-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1681, N'Anitra', N'Hull', 1, CAST(N'1989-11-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1682, N'Clifford', N'Benitez', 2, CAST(N'1965-07-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1683, N'Cynthia', N'Blackburn', 1, CAST(N'2002-02-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1684, N'James', N'Arellano', 1, CAST(N'1963-04-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1685, N'Dianna', N'Pitts', 1, CAST(N'2002-05-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1686, N'Cesar', N'Butler', 2, CAST(N'1979-04-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1687, N'Marlene', N'Serrano', 2, CAST(N'1982-02-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1688, N'Isaac', N'Reyes', 2, CAST(N'1998-09-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1689, N'Billie', N'Gibson', 2, CAST(N'1999-12-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1690, N'Natalie', N'Hall', 1, CAST(N'1966-07-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1691, N'Beverly', N'Harris', 2, CAST(N'1988-08-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1692, N'Damion', N'Espinoza', 2, CAST(N'2004-01-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1693, N'Naomi', N'Gallegos', 1, CAST(N'1981-05-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1694, N'Eileen', N'Byrd', 1, CAST(N'1985-04-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1695, N'Brad', N'Pitts', 1, CAST(N'2000-07-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1696, N'Matthew', N'Dixon', 1, CAST(N'1960-03-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1697, N'Charity', N'Aguilar', 1, CAST(N'2006-11-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1698, N'Meredith', N'Donaldson', 2, CAST(N'1960-08-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1699, N'Joanna', N'Hale', 2, CAST(N'1966-07-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1700, N'Joel', N'Dixon', 1, CAST(N'1972-07-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1701, N'Gerard', N'Mckinney', 2, CAST(N'1972-06-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1702, N'Marianne', N'Larsen', 1, CAST(N'1998-07-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1703, N'Clint', N'Trujillo', 1, CAST(N'1975-06-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1704, N'April', N'Knox', 1, CAST(N'1972-07-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1705, N'Diane', N'Padilla', 1, CAST(N'2003-11-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1706, N'Kenneth', N'Lawrence', 2, CAST(N'2003-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1707, N'Harry', N'Pitts', 1, CAST(N'1993-05-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1708, N'Mia', N'Barnes', 1, CAST(N'1964-03-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1709, N'Monica', N'Stephenson', 1, CAST(N'2002-11-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1710, N'Irene', N'Bishop', 1, CAST(N'1959-08-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1711, N'Chadwick', N'Harrison', 2, CAST(N'1964-05-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1712, N'Michael', N'Moyer', 2, CAST(N'1955-03-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1713, N'Kent', N'Macias', 2, CAST(N'2007-07-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1714, N'Latasha', N'Pope', 2, CAST(N'1991-12-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1715, N'Iris', N'Henson', 2, CAST(N'1974-09-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1716, N'Elias', N'George', 2, CAST(N'2001-02-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1717, N'Leo', N'Gregory', 1, CAST(N'1994-07-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1718, N'Irene', N'Anderson', 1, CAST(N'1955-06-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1719, N'Lakesha', N'Romero', 2, CAST(N'1986-08-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1720, N'Cassie', N'Rodgers', 2, CAST(N'1962-07-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1721, N'Sherrie', N'Davenport', 1, CAST(N'1964-12-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1722, N'Jami', N'Bartlett', 1, CAST(N'1987-10-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1723, N'Malcolm', N'Mooney', 1, CAST(N'1959-02-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1724, N'Mary', N'Ellison', 1, CAST(N'1982-01-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1725, N'Calvin', N'Cherry', 1, CAST(N'1986-03-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1726, N'Shelia', N'Cummings', 1, CAST(N'1972-07-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1727, N'Tanya', N'Lloyd', 2, CAST(N'1971-11-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1728, N'Aisha', N'Weaver', 2, CAST(N'1984-07-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1729, N'Rochelle', N'Stout', 2, CAST(N'1966-10-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1730, N'Molly', N'Michael', 1, CAST(N'2001-11-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1731, N'Denise', N'Boyle', 1, CAST(N'2005-09-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1732, N'Charity', N'Davis', 1, CAST(N'1963-10-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1733, N'Anne', N'Williams', 2, CAST(N'1973-11-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1734, N'Gregg', N'Hughes', 1, CAST(N'1988-02-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1735, N'Alfonso', N'Hanson', 1, CAST(N'1991-11-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1736, N'Chasity', N'Daniels', 2, CAST(N'1999-05-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1737, N'Christie', N'Parsons', 1, CAST(N'1998-02-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1738, N'Kelley', N'Fisher', 1, CAST(N'1982-07-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1739, N'Sheldon', N'Wall', 1, CAST(N'1967-05-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1740, N'Irene', N'Campos', 2, CAST(N'2006-09-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1741, N'George', N'Chan', 2, CAST(N'1993-12-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1742, N'Bryce', N'Barton', 2, CAST(N'1970-12-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1743, N'Eduardo', N'Potter', 2, CAST(N'2003-10-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1744, N'Sean', N'Richmond', 1, CAST(N'1993-05-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1745, N'Frankie', N'Booker', 1, CAST(N'1955-03-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1746, N'Armando', N'Romero', 1, CAST(N'1986-06-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1747, N'Kristi', N'Woodard', 1, CAST(N'2004-07-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1748, N'Maria', N'Bailey', 1, CAST(N'1997-05-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1749, N'Gena', N'Wiggins', 1, CAST(N'1963-07-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1750, N'Casey', N'Brady', 2, CAST(N'2007-06-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1751, N'Luis', N'Tapia', 1, CAST(N'1973-08-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1752, N'Sheldon', N'Carroll', 1, CAST(N'2004-05-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1753, N'Dustin', N'Sloan', 1, CAST(N'1982-01-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1754, N'Greg', N'Terrell', 2, CAST(N'1957-01-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1755, N'Ismael', N'Rosales', 2, CAST(N'1960-07-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1756, N'Elaine', N'Huffman', 2, CAST(N'1992-08-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1757, N'Brenda', N'Wyatt', 1, CAST(N'1992-06-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1758, N'Kristen', N'Hendricks', 1, CAST(N'2001-06-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1759, N'Regina', N'Giles', 1, CAST(N'1994-05-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1760, N'Shanda', N'Braun', 1, CAST(N'1984-05-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1761, N'Jenny', N'Solomon', 2, CAST(N'1984-11-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1762, N'Marianne', N'Cortez', 1, CAST(N'2005-05-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1763, N'Judy', N'Saunders', 1, CAST(N'1961-12-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1764, N'Jody', N'Stevens', 2, CAST(N'1953-07-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1765, N'Yvette', N'Haley', 2, CAST(N'1989-04-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1766, N'John', N'Kirk', 2, CAST(N'1972-06-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1767, N'Derick', N'Obrien', 2, CAST(N'1953-02-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1768, N'Alvin', N'Robles', 2, CAST(N'1983-05-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1769, N'Jill', N'House', 1, CAST(N'1956-01-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1770, N'Jennifer', N'Perkins', 1, CAST(N'1965-01-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1771, N'Donnell', N'Frank', 2, CAST(N'1996-02-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1772, N'Heath', N'Pruitt', 1, CAST(N'1987-12-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1773, N'James', N'Hooper', 1, CAST(N'1976-08-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1774, N'Donnell', N'West', 2, CAST(N'2002-01-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1775, N'Mitchell', N'Jennings', 2, CAST(N'1991-12-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1776, N'Loren', N'Foster', 2, CAST(N'1973-09-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1777, N'Casey', N'Best', 2, CAST(N'1979-11-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1778, N'Judy', N'Mc Lean', 1, CAST(N'2007-09-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1779, N'Sonya', N'Eaton', 1, CAST(N'1976-01-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1780, N'Jean', N'Hodges', 2, CAST(N'1982-06-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1781, N'Cameron', N'Morrow', 1, CAST(N'1973-12-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1782, N'Tammi', N'Fleming', 2, CAST(N'1967-05-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1783, N'Charlie', N'Odom', 1, CAST(N'1981-03-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1784, N'Lora', N'Phelps', 2, CAST(N'1954-04-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1785, N'Leigh', N'Fields', 2, CAST(N'1989-10-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1786, N'Debbie', N'Nguyen', 1, CAST(N'1969-10-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1787, N'Glenda', N'Flynn', 1, CAST(N'1980-07-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1788, N'Toby', N'Dillon', 1, CAST(N'2007-03-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1789, N'Leo', N'Wilkinson', 2, CAST(N'1959-11-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1790, N'Kristina', N'Roach', 1, CAST(N'2004-08-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1791, N'Taryn', N'Ortega', 2, CAST(N'1996-03-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1792, N'Janelle', N'Mathis', 2, CAST(N'1991-01-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1793, N'Steven', N'Shannon', 2, CAST(N'1974-10-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1794, N'Lorena', N'Bennett', 1, CAST(N'1973-07-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1795, N'Terra', N'Holloway', 2, CAST(N'2002-11-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1796, N'Angelo', N'Carrillo', 2, CAST(N'1984-06-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1797, N'Alexis', N'Reilly', 2, CAST(N'1954-08-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1798, N'Courtney', N'Rios', 1, CAST(N'2005-02-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1799, N'Trent', N'West', 1, CAST(N'1985-01-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1800, N'Johnathan', N'Arroyo', 2, CAST(N'1997-04-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1801, N'Adrienne', N'Wagner', 2, CAST(N'1988-02-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1802, N'Beth', N'Kane', 2, CAST(N'2004-05-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1803, N'Dina', N'Camacho', 1, CAST(N'1961-08-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1804, N'Jasmine', N'Hendricks', 1, CAST(N'1961-04-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1805, N'Henry', N'Davis', 2, CAST(N'2002-02-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1806, N'Brett', N'Wilson', 2, CAST(N'1988-06-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1807, N'Bryce', N'Sparks', 1, CAST(N'1966-06-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1808, N'Kendrick', N'Wade', 1, CAST(N'1953-08-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1809, N'Demetrius', N'Hess', 1, CAST(N'1971-10-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1810, N'Mia', N'Ponce', 1, CAST(N'1974-08-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1811, N'Marcia', N'Green', 2, CAST(N'1961-04-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1812, N'Bridgette', N'Beck', 1, CAST(N'1955-05-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1813, N'Chadwick', N'Estrada', 2, CAST(N'1995-11-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1814, N'Ricky', N'Bray', 2, CAST(N'1987-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1815, N'Terrell', N'Torres', 2, CAST(N'1990-12-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1816, N'Ruth', N'Daugherty', 2, CAST(N'1980-10-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1817, N'Kenny', N'Herring', 2, CAST(N'1960-09-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1818, N'Dewayne', N'Sosa', 2, CAST(N'1971-10-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1819, N'Marianne', N'Ayers', 1, CAST(N'1972-07-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1820, N'Arturo', N'Jenkins', 1, CAST(N'1999-11-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1821, N'Megan', N'Dickerson', 1, CAST(N'1953-11-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1822, N'Blake', N'Beltran', 1, CAST(N'1976-07-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1823, N'Eddie', N'Ward', 1, CAST(N'1959-05-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1824, N'Tamara', N'Villegas', 1, CAST(N'1976-11-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1825, N'Ginger', N'Chung', 1, CAST(N'1958-01-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1826, N'Tia', N'Hill', 1, CAST(N'1966-02-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1827, N'Jeanette', N'Zavala', 2, CAST(N'1999-06-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1828, N'Herman', N'Green', 2, CAST(N'1981-07-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1829, N'Gary', N'Mcfarland', 2, CAST(N'1997-02-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1830, N'Staci', N'Marks', 1, CAST(N'1997-04-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1831, N'Brandie', N'Wood', 2, CAST(N'1978-04-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1832, N'Julia', N'Sparks', 1, CAST(N'1955-07-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1833, N'Frankie', N'Conley', 1, CAST(N'1998-12-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1834, N'Nakia', N'Rosales', 2, CAST(N'1993-03-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1835, N'Kareem', N'Dennis', 2, CAST(N'1993-11-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1836, N'Victor', N'Preston', 1, CAST(N'1970-12-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1837, N'Nick', N'Jennings', 1, CAST(N'1972-07-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1838, N'Oliver', N'Ashley', 2, CAST(N'2000-12-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1839, N'Charity', N'Soto', 1, CAST(N'1995-08-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1840, N'Rhonda', N'Phillips', 1, CAST(N'1989-05-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1841, N'Marlene', N'Davis', 2, CAST(N'1967-01-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1842, N'Gwendolyn', N'Benson', 2, CAST(N'2006-08-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1843, N'Tanisha', N'Murphy', 2, CAST(N'1996-02-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1844, N'Thomas', N'Ayers', 2, CAST(N'1983-01-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1845, N'Marlon', N'Welch', 1, CAST(N'1954-06-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1846, N'Denise', N'Barrett', 1, CAST(N'1982-10-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1847, N'Raymond', N'Rodgers', 2, CAST(N'1972-06-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1848, N'Sally', N'Watson', 1, CAST(N'1997-04-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1849, N'Hector', N'Walker', 2, CAST(N'1990-07-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1850, N'Justin', N'Atkins', 1, CAST(N'1975-01-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1851, N'Martin', N'Dickerson', 2, CAST(N'1976-10-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1852, N'Travis', N'Cherry', 2, CAST(N'1990-10-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1853, N'Teresa', N'Clarke', 2, CAST(N'1985-08-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1854, N'Misti', N'White', 1, CAST(N'1993-03-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1855, N'Terrance', N'Greene', 2, CAST(N'1996-05-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1856, N'Quincy', N'Bishop', 2, CAST(N'1964-08-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1857, N'Adriana', N'Hood', 2, CAST(N'1998-01-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1858, N'Monica', N'Leach', 1, CAST(N'1992-10-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1859, N'Lee', N'Estes', 2, CAST(N'1956-04-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1860, N'Jamison', N'Branch', 2, CAST(N'1989-01-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1861, N'Elizabeth', N'Diaz', 1, CAST(N'1996-12-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1862, N'Shane', N'Townsend', 2, CAST(N'1992-12-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1863, N'Harry', N'Burnett', 1, CAST(N'1964-06-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1864, N'Tracy', N'Woodward', 1, CAST(N'1982-06-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1865, N'Sheri', N'Dunlap', 2, CAST(N'2004-05-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1866, N'Leo', N'Collier', 2, CAST(N'1992-02-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1867, N'Nina', N'Bartlett', 1, CAST(N'1970-05-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1868, N'Scot', N'Hurst', 1, CAST(N'1970-02-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1869, N'Andres', N'Short', 2, CAST(N'1954-12-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1870, N'Margarita', N'Cortez', 2, CAST(N'1973-01-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1871, N'Shelly', N'Phelps', 1, CAST(N'1961-03-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1872, N'Dominic', N'Shea', 1, CAST(N'1967-09-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1873, N'Yvette', N'Castaneda', 1, CAST(N'1984-02-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1874, N'Hugh', N'Nielsen', 1, CAST(N'1991-02-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1875, N'Angie', N'Ross', 1, CAST(N'1985-10-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1876, N'Desiree', N'Davidson', 1, CAST(N'1955-04-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1877, N'Ebony', N'Blevins', 1, CAST(N'1988-05-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1878, N'Sergio', N'Welch', 1, CAST(N'1984-04-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1879, N'Leonardo', N'Johns', 1, CAST(N'1975-05-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1880, N'Johnnie', N'Anthony', 2, CAST(N'1983-04-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1881, N'Cynthia', N'Russo', 1, CAST(N'2001-08-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1882, N'Bobbie', N'Frye', 1, CAST(N'1955-03-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1883, N'Jesus', N'Wilson', 1, CAST(N'1998-12-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1884, N'Christa', N'Stone', 1, CAST(N'1975-02-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1885, N'Betty', N'Ramirez', 2, CAST(N'1973-07-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1886, N'Lakesha', N'Romero', 1, CAST(N'1995-06-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1887, N'Morgan', N'Miller', 1, CAST(N'1977-12-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1888, N'Ryan', N'Bryan', 2, CAST(N'1958-10-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1889, N'Samantha', N'Ball', 2, CAST(N'2004-11-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1890, N'Jamie', N'Crawford', 1, CAST(N'1982-03-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1891, N'Lindsey', N'Cole', 1, CAST(N'1980-12-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1892, N'Brad', N'Gates', 1, CAST(N'1987-10-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1893, N'Debra', N'Frey', 1, CAST(N'1997-09-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1894, N'Bobbie', N'Guerrero', 2, CAST(N'1959-08-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1895, N'Josephine', N'Riddle', 2, CAST(N'2000-05-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1896, N'Ted', N'Conley', 1, CAST(N'1982-02-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1897, N'Whitney', N'David', 1, CAST(N'1995-02-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1898, N'Pablo', N'Kelley', 2, CAST(N'1966-08-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1899, N'George', N'Cuevas', 2, CAST(N'1986-09-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1900, N'Lea', N'Villanueva', 1, CAST(N'1970-05-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1901, N'Lea', N'Decker', 1, CAST(N'1965-06-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1902, N'Brandie', N'Barry', 2, CAST(N'1955-04-27 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1903, N'Terrence', N'Holloway', 1, CAST(N'1995-04-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1904, N'Vincent', N'Suarez', 1, CAST(N'1970-07-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1905, N'Candy', N'Villarreal', 2, CAST(N'1962-01-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1906, N'Leo', N'Sutton', 2, CAST(N'1959-08-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1907, N'Sara', N'Winters', 1, CAST(N'2002-07-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1908, N'Ruth', N'Krause', 1, CAST(N'1960-05-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1909, N'Darrell', N'Huerta', 1, CAST(N'1994-01-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1910, N'Carolyn', N'Simon', 1, CAST(N'1984-03-09 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1911, N'Jaime', N'Chambers', 2, CAST(N'1966-09-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1912, N'Lance', N'Murphy', 1, CAST(N'1970-06-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1913, N'Johnny', N'Estrada', 2, CAST(N'1980-12-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1914, N'Joyce', N'Sutton', 1, CAST(N'1995-05-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1915, N'Alonzo', N'Carpenter', 1, CAST(N'2001-12-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1916, N'Edith', N'Hubbard', 2, CAST(N'1997-05-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1917, N'Raquel', N'Arroyo', 2, CAST(N'1961-11-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1918, N'Tammy', N'Macias', 2, CAST(N'1967-03-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1919, N'Alonzo', N'Gallegos', 2, CAST(N'1964-07-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1920, N'Jenny', N'Grant', 1, CAST(N'1973-04-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1921, N'Paula', N'Dominguez', 2, CAST(N'1980-10-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1922, N'Tommy', N'Navarro', 1, CAST(N'2000-01-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1923, N'Shad', N'Weber', 2, CAST(N'1981-06-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1924, N'Rocky', N'Osborn', 2, CAST(N'1977-12-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1925, N'Jodie', N'Jackson', 1, CAST(N'1977-06-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1926, N'Kristie', N'Leonard', 2, CAST(N'1998-09-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1927, N'Mark', N'Huynh', 2, CAST(N'1956-09-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1928, N'Sonya', N'Montoya', 2, CAST(N'1968-02-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1929, N'Wanda', N'Frank', 2, CAST(N'1974-10-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1930, N'Kellie', N'Henson', 1, CAST(N'2005-08-01 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1931, N'Clay', N'Fowler', 2, CAST(N'1957-12-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1932, N'Rita', N'Odom', 2, CAST(N'1970-11-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1933, N'Kathryn', N'Clark', 2, CAST(N'1999-04-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1934, N'Taryn', N'Downs', 1, CAST(N'1967-12-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1935, N'Antonio', N'Cohen', 1, CAST(N'1981-05-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1936, N'Johanna', N'Mann', 1, CAST(N'1961-04-02 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1937, N'Karen', N'Freeman', 2, CAST(N'1964-06-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1938, N'Brian', N'Hodges', 1, CAST(N'1988-10-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1939, N'Jeremiah', N'Meza', 2, CAST(N'1983-05-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1940, N'Preston', N'Stanley', 1, CAST(N'2006-05-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1941, N'Latoya', N'Hodge', 2, CAST(N'1963-10-23 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1942, N'Hugh', N'Adkins', 2, CAST(N'2006-01-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1943, N'Jodie', N'Dorsey', 2, CAST(N'1967-03-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1944, N'Patrick', N'Crosby', 2, CAST(N'1970-04-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1945, N'Jonathan', N'Poole', 2, CAST(N'1969-09-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1946, N'Everett', N'Mc Clure', 2, CAST(N'1972-04-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1947, N'Eva', N'Frey', 2, CAST(N'1958-08-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1948, N'Lorena', N'Dorsey', 1, CAST(N'1988-02-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1949, N'Marianne', N'Harrison', 2, CAST(N'2005-10-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1950, N'Brenda', N'Harrington', 2, CAST(N'1957-09-19 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1951, N'Tyrone', N'Erickson', 1, CAST(N'1977-11-03 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1952, N'Lauren', N'Norris', 2, CAST(N'1956-03-04 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1953, N'Josh', N'Hunter', 2, CAST(N'1953-11-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1954, N'Danny', N'Moran', 2, CAST(N'1990-01-18 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1955, N'Jamal', N'Dawson', 2, CAST(N'1967-07-05 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1956, N'Marco', N'Shaw', 2, CAST(N'1978-06-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1957, N'Sonja', N'Francis', 1, CAST(N'1993-05-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1958, N'Robyn', N'Allen', 1, CAST(N'1992-01-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1959, N'Antonio', N'York', 2, CAST(N'1990-02-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1960, N'Clarence', N'Anderson', 2, CAST(N'1956-10-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1961, N'Steven', N'Bray', 1, CAST(N'1956-09-28 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1962, N'Barry', N'Mc Gee', 2, CAST(N'1978-12-10 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1963, N'Tania', N'Shaffer', 2, CAST(N'1962-06-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1964, N'Trevor', N'Leach', 1, CAST(N'1969-02-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1965, N'Andrew', N'Baker', 1, CAST(N'1965-06-26 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1966, N'Roberta', N'Reynolds', 2, CAST(N'1963-02-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1967, N'Samuel', N'Newman', 1, CAST(N'2004-01-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1968, N'Freddie', N'Robbins', 1, CAST(N'1979-10-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1969, N'Justin', N'Levy', 1, CAST(N'1973-07-31 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1970, N'Andy', N'Price', 2, CAST(N'1989-02-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1971, N'Cary', N'Silva', 2, CAST(N'2005-06-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1972, N'Mandy', N'Mc Gee', 2, CAST(N'1981-01-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1973, N'Dante', N'Potts', 2, CAST(N'1991-10-16 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1974, N'Lynn', N'Soto', 1, CAST(N'1966-03-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1975, N'Cindy', N'Richard', 1, CAST(N'1962-06-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1976, N'Francis', N'Spence', 2, CAST(N'1982-09-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1977, N'Laurie', N'Glenn', 2, CAST(N'1985-11-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1978, N'Walter', N'Carrillo', 2, CAST(N'1964-03-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1979, N'Terra', N'Hammond', 2, CAST(N'1961-04-06 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1980, N'Leah', N'Park', 1, CAST(N'1958-03-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1981, N'Natasha', N'Terry', 2, CAST(N'1993-01-24 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1982, N'Devon', N'Robinson', 2, CAST(N'1976-07-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1983, N'Anthony', N'Figueroa', 1, CAST(N'1970-05-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1984, N'Manuel', N'Cuevas', 2, CAST(N'1970-01-17 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1985, N'Bobbie', N'Maldonado', 1, CAST(N'1980-09-29 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1986, N'Nicolas', N'Haas', 2, CAST(N'1954-10-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1987, N'Ginger', N'Mc Connell', 1, CAST(N'1970-01-07 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1988, N'Garrett', N'Gilmore', 1, CAST(N'1962-04-12 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1989, N'Shari', N'Christian', 1, CAST(N'1953-06-14 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1990, N'Valerie', N'Moreno', 1, CAST(N'1955-12-08 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1991, N'Carrie', N'Lucero', 2, CAST(N'1975-11-20 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1992, N'Yolanda', N'Arroyo', 2, CAST(N'2006-08-30 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1993, N'Devon', N'Acevedo', 1, CAST(N'1979-08-13 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1994, N'Colleen', N'Bowen', 2, CAST(N'2002-08-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1995, N'Connie', N'Berry', 1, CAST(N'1992-11-11 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1996, N'Shawn', N'Waller', 2, CAST(N'1996-08-15 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1997, N'Jeffrey', N'Evans', 1, CAST(N'2006-01-25 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1998, N'Leticia', N'Buckley', 2, CAST(N'1957-10-21 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (1999, N'Roberta', N'Townsend', 1, CAST(N'1959-08-22 00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[People] ([Id], [FirstName], [LastName], [Gender], [BirthDay]) VALUES (2000, N'Morgan', N'Figueroa', 2, CAST(N'1976-03-28 00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[People] OFF
GO
USE [master]
GO
ALTER DATABASE [ApplicationProductionData] SET  READ_WRITE 
GO
